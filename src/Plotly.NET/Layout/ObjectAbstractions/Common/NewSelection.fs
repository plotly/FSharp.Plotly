namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

type NewSelection() =
    inherit DynamicObj()

    /// <summary>
    /// Returns a new NewSelection object with the given styles
    /// </summary>
    /// <param name="LineColor">Sets the line color. By default uses either dark grey or white to increase contrast with background color.</param>
    /// <param name="LineDash">Sets the dash style of lines. Set to a dash type string ("solid", "dot", "dash", "longdash", "dashdot", or "longdashdot") or a dash length list in px (eg "5px,10px,2px,2px").</param>
    /// <param name="LineWidth">Sets the line width (in px).</param>
    /// <param name="Mode">Describes how a new selection is created. If `immediate`, a new selection is created after first mouse up. If `gradual`, a new selection is not created after first mouse. By adding to and subtracting from the initial selection, this option allows declaring extra outlines of the selection.</param>
    static member init
        (
            ?LineColor: Color,
            ?LineDash: StyleParam.DrawingStyle,
            ?LineWidth: float,
            ?Mode: StyleParam.NewSelectionMode
        ) =
        NewSelection()
        |> NewSelection.style (?LineColor = LineColor, ?LineDash = LineDash, ?LineWidth = LineWidth, ?Mode = Mode)

    /// <summary>
    /// Returns a function that applies the given styles to a NewSelection object
    /// </summary>
    /// <param name="LineColor">Sets the line color. By default uses either dark grey or white to increase contrast with background color.</param>
    /// <param name="LineDash">Sets the dash style of lines. Set to a dash type string ("solid", "dot", "dash", "longdash", "dashdot", or "longdashdot") or a dash length list in px (eg "5px,10px,2px,2px").</param>
    /// <param name="LineWidth">Sets the line width (in px).</param>
    /// <param name="Mode">Describes how a new selection is created. If `immediate`, a new selection is created after first mouse up. If `gradual`, a new selection is not created after first mouse. By adding to and subtracting from the initial selection, this option allows declaring extra outlines of the selection.</param>
    static member style
        (
            ?LineColor: Color,
            ?LineDash: StyleParam.DrawingStyle,
            ?LineWidth: float,
            ?Mode: StyleParam.NewSelectionMode
        ) =
        (fun (newSelection: NewSelection) ->

            let line =
                Line.init (?Color = LineColor, ?Dash = LineDash, ?Width = LineWidth)

            newSelection
            |> DynObj.withProperty "line" line
            |> DynObj.withOptionalPropertyBy "mode" Mode StyleParam.NewSelectionMode.convert
        )
