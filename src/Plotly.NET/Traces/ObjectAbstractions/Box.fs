namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

/// Box type inherits from dynamic object (parent violin)
type Box() =
    inherit DynamicObj()

    /// Initialized Line object
    static member init
        (
            ?Visible: bool,
            ?Width: float,
            ?FillColor: Color,
            ?LineColor: Color,
            ?LineWidth: float
        ) =
        Box()
        |> Box.style (
            ?Visible = Visible,
            ?Width = Width,
            ?FillColor = FillColor,
            ?LineColor = LineColor,
            ?LineWidth = LineWidth
        )


    // Applies the styles to Line()
    static member style
        (
            ?Visible: bool,
            ?Width: float,
            ?FillColor: Color,
            ?LineColor: Color,
            ?LineWidth: float
        ) =
        fun (box: Box) ->

            let line =
                if LineColor.IsSome || LineWidth.IsSome then
                    Some(Line.init (?Color = LineColor, ?Width = LineWidth))
                else
                    None

            box
            |> DynObj.withOptionalProperty "visible" Visible
            |> DynObj.withOptionalProperty "width" Width
            |> DynObj.withOptionalProperty "fillcolor" FillColor
            |> DynObj.withOptionalProperty "line" line
