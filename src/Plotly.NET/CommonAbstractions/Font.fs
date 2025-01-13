namespace Plotly.NET

open System.Runtime.InteropServices

open DynamicObj

/// Font type inherits from dynamic object
type Font() =
    inherit DynamicObj()

    /// Init Font()
    static member init
        (
            ?Family: StyleParam.FontFamily,
            ?Size: float,
            ?Color: Color
        ) =
        Font() |> Font.style (?Family = Family, ?Size = Size, ?Color = Color)


    // Applies the styles to Font()
    static member style
        (
            ?Family: StyleParam.FontFamily,
            ?Size: float,
            ?Color: Color
        ) =
        (fun (font: Font) ->
            font
            |> DynObj.withOptionalPropertyBy "family" Family StyleParam.FontFamily.toString
            |> DynObj.withOptionalProperty "size" Size
            |> DynObj.withOptionalProperty "color" Color
        )
