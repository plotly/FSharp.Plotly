namespace Plotly.NET
//http://www.niwa.nu/2013/05/math-behind-colorspace-conversions-rgb-hsl/
open Newtonsoft.Json
open System

module internal Hex =

    open System

    let toHexDigit n =
        if n < 10 then
            char (n + 0x30)
        else
            char (n + 0x37)

    let fromHexDigit c =
        if c >= '0' && c <= '9' then
            int c - int '0'
        elif c >= 'A' && c <= 'F' then
            (int c - int 'A') + 10
        elif c >= 'a' && c <= 'f' then
            (int c - int 'a') + 10
        else
            raise <| ArgumentException()

    let encode (prefix: string) (color: byte array) =
        let hex =
            Array.zeroCreate (color.Length * 2)

        let mutable n = 0

        for i = 0 to color.Length - 1 do
            hex.[n] <- toHexDigit ((int color.[i] &&& 0xF0) >>> 4)
            n <- n + 1
            hex.[n] <- toHexDigit (int color.[i] &&& 0xF)
            n <- n + 1

        String.Concat(prefix, String(hex))

    let decode (s: string) =
        match s with
        | null -> nullArg "s"
        | _ when s.Length = 0 -> Array.empty
        | _ ->
            let mutable len = s.Length
            let mutable i = 0

            if len >= 2 && s.[0] = '0' && (s.[1] = 'x' || s.[1] = 'X') then
                do
                    len <- len - 2
                    i <- i + 2

            if len % 2 <> 0 then
                invalidArg "s" "Invalid hex format"
            else
                let buf = Array.zeroCreate (len / 2)
                let mutable n = 0

                while i < s.Length do
                    buf.[n] <- byte (((fromHexDigit s.[i]) <<< 4) ||| (fromHexDigit s.[i + 1]))
                    i <- i + 2
                    n <- n + 1

                buf

/// Represents an ARGB (alpha, red, green, blue) color
[<JsonConverter(typeof<ARGBConverter>)>]
type ARGB =
    {
        /// The alpha component value of this Color structure.
        A: byte
        /// The red component value of this Color structure.
        R: byte
        /// The green component value of this Color structure.
        G: byte
        /// The blue component value of this Color structure.
        B: byte
    }

    /// Creates a Argb Color from the four ARGB component (alpha, red, green, and blue) values.
    static member create a r g b =
        let fi v =
            if v < 0 || v > 255 then
                failwithf "Value for component needs to be between 0 and 255."
            else
                byte v

        {
            A = fi a
            R = fi r
            G = fi g
            B = fi b
        }

    /// Creates a Argb color from the specified color values (red, green, and blue).
    /// The alpha value is implicitly 255 (fully opaque).
    static member fromRGB r g b = ARGB.create 255 r g b

    /// Gets the hex representataion (FFFFFF) of a color (with valid prefix "0xFFFFFF")
    static member toHex prefix (c: ARGB) =
        let prefix' = if prefix then "0x" else ""
        Hex.encode prefix' [| c.R; c.G; c.B |]

    /// Gets color from hex representataion (FFFFFF) or (0xFFFFFF)
    static member fromHex(s: string) =
        match (Hex.decode s) with
        | [| r; g; b |] -> ARGB.fromRGB (int r) (int g) (int b)
        | _ -> failwithf "Invalid hex color format"

    /// Gets the web color representataion (#FFFFFF)
    static member toWebHex c = Hex.encode "#" [| c.R; c.G; c.B |]

    /// Gets color from web color (#FFFFFF)
    static member fromWebHex(s: string) =
        let s' = s.TrimStart([| '#' |])

        match (Hex.decode s') with
        | [| r; g; b |] -> ARGB.fromRGB (int r) (int g) (int b)
        | _ -> failwithf "Invalid hex color format"

    /// Converts this Color structure to a human-readable string.
    static member toString c =
        let a, r, g, b =
            (int c.A, int c.R, int c.G, int c.B)

        sprintf "{Alpha: %i Red: %i Green: %i Blue: %i}" a r g b

    static member fromKeyword(c: ColorKeyword) =
        c |> ColorKeyword.toRGB |> (fun (r, g, b) -> ARGB.fromRGB r g b)

and ARGBConverter() =
    inherit JsonConverter()

    override _.CanConvert(objectType) = objectType = typeof<ARGB>

    override _.ReadJson(reader, t, existingValue, serializer) =
        raise (System.NotImplementedException())
    //unbox reader.Value

    override _.WriteJson(writer, value, serializer) =
        let argb = value :?> ARGB
        //writer.WriteValue(sprintf "rgba(%i, %i, %i, %0.1f)" argb.R argb.G argb.B argb.A )
        writer.WriteValue(sprintf "rgba(%i, %i, %i, %0.1f)" argb.R argb.G argb.B (float argb.A / 255.))

/// Plotly color can be a single color, a sequence of colors, or a sequence of numeric values referencing the color of the colorscale obj
[<JsonConverter(typeof<ColorConverter>)>]
type Color private (obj: obj) =

    /// Creates a Color from the four ARGB component (alpha, red, green, and blue) values.
    static member fromARGB a r g b = ARGB.create a r g b |> unbox |> Color

    /// Creates a Color from the specified color values (red, green, and blue).
    /// The alpha value is implicitly 1. (fully opaque).
    static member fromRGB r g b = Color.fromARGB 255 r g b

    /// Color from web color (#FFFFFF) or hex representataion (FFFFFF) / (0xFFFFFF)
    static member fromHex(s: string) =
        let s' = s.TrimStart('#')

        match (Hex.decode s') with
        | [| r; g; b |] -> Color.fromRGB (int r) (int g) (int b)
        | _ -> failwithf "Invalid hex color format"

    /// Color
    static member fromColors(c: seq<Color>) =
        let tmp = c |> Seq.map (fun v -> v.Value)
        Color(unbox tmp)

    /// Color from a raw string input, no check for correctness performed
    static member fromString(c: string) = Color(unbox c)

    /// Values are interpreted relative to color scale
    static member fromColorScaleValues(c: seq<#IConvertible>) = Color(unbox c)

    /// Color from a standard web color keyword, e.g. White -> "white" (see //https://www.w3.org/TR/2011/REC-SVG11-20110816/types.html#ColorKeywords)
    static member fromKeyword(c: ColorKeyword) = Color(unbox (ARGB.fromKeyword c))

    override this.Equals(other) =
        match other with
        | :? Color as otherColor -> this.Value = otherColor.Value
        | _ -> false

    override this.GetHashCode() = this.Value.GetHashCode()

    /// extractor
    member this.Value = obj

and ColorConverter() =
    inherit JsonConverter()

    override _.CanConvert(objectType) = objectType = typeof<Color>

    override _.ReadJson(reader, t, existingValue, serializer) =
        raise (System.NotImplementedException())

    override _.WriteJson(writer, value, serializer) =
        let c = value :?> Color

        let jc =
            JsonConvert.SerializeObject(c.Value)

        writer.WriteRawValue(jc)
