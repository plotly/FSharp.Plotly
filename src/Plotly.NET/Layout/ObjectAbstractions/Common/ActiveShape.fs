namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

type ActiveShape() =
    inherit DynamicObj()

    static member init
        (
            ?FillColor: Color,
            ?Opacity: float
        ) =
        ActiveShape() |> ActiveShape.style (?FillColor = FillColor, ?Opacity = Opacity)

    static member style
        (
            ?FillColor: Color,
            ?Opacity: float
        ) =
        (fun (activeShape: ActiveShape) ->

            activeShape
            |> DynObj.withOptionalProperty "fillcolor" FillColor
            |> DynObj.withOptionalProperty "opacity" Opacity
        )
