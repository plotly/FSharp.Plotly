namespace Plotly.NET.LayoutObjects

open DynamicObj
open System.Runtime.InteropServices

/// Margin
type Margin() =
    inherit DynamicObj()

    /// Init Margin type
    static member init
        (
            ?Left,
            ?Right,
            ?Top,
            ?Bottom,
            ?Pad,
            ?Autoexpand
        ) =
        Margin()
        |> Margin.style (
            ?Left = Left,
            ?Right = Right,
            ?Top = Top,
            ?Bottom = Bottom,
            ?Pad = Pad,
            ?Autoexpand = Autoexpand
        )


    // Applies the styles to Margin()
    static member style
        (
            ?Left,
            ?Right,
            ?Top,
            ?Bottom,
            ?Pad,
            ?Autoexpand
        ) =
        (fun (margin: Margin) ->

            margin
            |> DynObj.withOptionalProperty "l" Left
            |> DynObj.withOptionalProperty "r" Right
            |> DynObj.withOptionalProperty "t" Top
            |> DynObj.withOptionalProperty "b" Bottom
            |> DynObj.withOptionalProperty "pad" Pad
            |> DynObj.withOptionalProperty "autoexpand" Autoexpand
        )
