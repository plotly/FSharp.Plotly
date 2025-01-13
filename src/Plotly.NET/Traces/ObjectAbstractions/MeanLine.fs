namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

/// Meanline type inherits from dynamic object (parent violin)
type MeanLine() =
    inherit DynamicObj()

    /// Initialized Line object
    static member init
        (
            ?Visible: bool,
            ?Color: Color,
            ?Width: float
        ) =
        MeanLine() |> MeanLine.style (?Visible = Visible, ?Color = Color, ?Width = Width)


    // Applies the styles to Line()
    static member style
        (
            ?Visible: bool,
            ?Color: Color,
            ?Width: float
        ) =
        fun (line: MeanLine) ->

            line
            |> DynObj.withOptionalProperty "visible" Visible
            |> DynObj.withOptionalProperty "color" Color
            |> DynObj.withOptionalProperty "width" Width
