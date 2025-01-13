namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

type ActiveSelection() =
    inherit DynamicObj()

    static member init
        (
            ?FillColor: Color,
            ?Opacity: float
        ) =
        ActiveSelection() |> ActiveSelection.style (?FillColor = FillColor, ?Opacity = Opacity)

    static member style
        (
            ?FillColor: Color,
            ?Opacity: float
        ) =
        (fun (activeSelection: ActiveSelection) ->

            activeSelection
            |> DynObj.withOptionalProperty "fillcolor" FillColor
            |> DynObj.withOptionalProperty "opacity" Opacity
        )
