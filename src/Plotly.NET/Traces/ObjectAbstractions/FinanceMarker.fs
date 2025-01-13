namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type FinanceMarker() =
    inherit DynamicObj()

    static member init
        (
            ?FillColor: Color,
            ?LineColor: Color,
            ?LineWidth: float,
            ?LineDash: StyleParam.DrawingStyle
        ) =
        FinanceMarker()
        |> FinanceMarker.style (
            ?FillColor = FillColor,
            ?LineColor = LineColor,
            ?LineWidth = LineWidth,
            ?LineDash = LineDash

        )

    static member style
        (
            ?FillColor: Color,
            ?LineColor: Color,
            ?LineWidth: float,
            ?LineDash: StyleParam.DrawingStyle
        ) =
        fun (financeMarker: FinanceMarker) ->

            let line =
                financeMarker.TryGetTypedPropertyValue<Line>("line")
                |> Option.defaultValue(Plotly.NET.Line.init())
                |> Line.style (?Color = LineColor, ?Width = LineWidth, ?Dash = LineDash)

            financeMarker
            |> DynObj.withOptionalProperty "fillcolor" FillColor
            |> DynObj.withProperty "line" line
