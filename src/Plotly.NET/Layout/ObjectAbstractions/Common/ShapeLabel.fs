namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices


///<summary>
///The label of a shape.
///</summary>
type ShapeLabel() =
    inherit DynamicObj()

    /// <summary>
    /// Returns a new ShapeLabel object with the given styling.
    /// </summary>
    /// <param name="Font">Sets the shape label text font.</param>
    /// <param name="Padding">Sets padding (in px) between edge of label and edge of shape.</param>
    /// <param name="Text">Sets padding (in px) between edge of label and edge of shape.</param>
    /// <param name="TextAngle">Sets padding (in px) between edge of label and edge of shape.</param>
    /// <param name="TextPosition">Sets the position of the label text relative to the shape. Supported values for rectangles, circles and paths are "top left", "top center", "top right", "middle left", "middle center", "middle right", "bottom left", "bottom center", and "bottom right". Supported values for lines are "start", "middle", and "end". Default: "middle center" for rectangles, circles, and paths; "middle" for lines.</param>
    /// <param name="TextTemplate">Template string used for rendering the shape's label. Note that this will override `text`. Variables are inserted using %{variable}, for example "x0: %{x0}". Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{x0:$.2f}". See https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{x0|%m %b %Y}". See https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. A single multiplication or division operation may be applied to numeric variables, and combined with d3 number formatting, for example "Length in cm: %{x0"2.54}", "%{slope"60:.1f} meters per second." For log axes, variable values are given in log units. For date axes, x/y coordinate variables and center variables use datetimes, while all other variable values use values in ms. Finally, the template string has access to variables `x0`, `x1`, `y0`, `y1`, `slope`, `dx`, `dy`, `width`, `height`, `length`, `xcenter` and `ycenter`.</param>
    /// <param name="XAnchor">Sets the label's horizontal position anchor This anchor binds the specified `textposition` to the "left", "center" or "right" of the label text. For example, if `textposition` is set to "top right" and `xanchor` to "right" then the right-most portion of the label text lines up with the right-most edge of the shape.</param>
    /// <param name="YAnchor">Sets the label's vertical position anchor This anchor binds the specified `textposition` to the "top", "middle" or "bottom" of the label text. For example, if `textposition` is set to "top right" and `yanchor` to "top" then the top-most portion of the label text lines up with the top-most edge of the shape.</param>
    static member init
        (
            ?Font: Font,
            ?Padding: int,
            ?Text: string,
            ?TextAngle: StyleParam.TextAngle,
            ?TextPosition: StyleParam.TextPosition,
            ?TextTemplate: string,
            ?XAnchor: StyleParam.XAnchorPosition,
            ?YAnchor: StyleParam.YAnchorPosition
        ) =

        ShapeLabel()
        |> ShapeLabel.style (
            ?Font           = Font,
            ?Padding        = Padding,
            ?Text           = Text,
            ?TextAngle      = TextAngle,
            ?TextPosition   = TextPosition,
            ?TextTemplate   = TextTemplate,
            ?XAnchor        = XAnchor,
            ?YAnchor        = YAnchor
        )

    /// <summary>
    /// Returns a function that applies the given styles to a ShapeLabel object
    /// </summary>
    /// <param name="Font">Sets the shape label text font.</param>
    /// <param name="Padding">Sets padding (in px) between edge of label and edge of shape.</param>
    /// <param name="Text">Sets padding (in px) between edge of label and edge of shape.</param>
    /// <param name="TextAngle">Sets padding (in px) between edge of label and edge of shape.</param>
    /// <param name="TextPosition">Sets the position of the label text relative to the shape. Supported values for rectangles, circles and paths are "top left", "top center", "top right", "middle left", "middle center", "middle right", "bottom left", "bottom center", and "bottom right". Supported values for lines are "start", "middle", and "end". Default: "middle center" for rectangles, circles, and paths; "middle" for lines.</param>
    /// <param name="TextTemplate">Template string used for rendering the shape's label. Note that this will override `text`. Variables are inserted using %{variable}, for example "x0: %{x0}". Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{x0:$.2f}". See https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{x0|%m %b %Y}". See https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. A single multiplication or division operation may be applied to numeric variables, and combined with d3 number formatting, for example "Length in cm: %{x0"2.54}", "%{slope"60:.1f} meters per second." For log axes, variable values are given in log units. For date axes, x/y coordinate variables and center variables use datetimes, while all other variable values use values in ms. Finally, the template string has access to variables `x0`, `x1`, `y0`, `y1`, `slope`, `dx`, `dy`, `width`, `height`, `length`, `xcenter` and `ycenter`.</param>
    /// <param name="XAnchor">Sets the label's horizontal position anchor This anchor binds the specified `textposition` to the "left", "center" or "right" of the label text. For example, if `textposition` is set to "top right" and `xanchor` to "right" then the right-most portion of the label text lines up with the right-most edge of the shape.</param>
    /// <param name="YAnchor">Sets the label's vertical position anchor This anchor binds the specified `textposition` to the "top", "middle" or "bottom" of the label text. For example, if `textposition` is set to "top right" and `yanchor` to "top" then the top-most portion of the label text lines up with the top-most edge of the shape.</param>
    static member style
        (
            ?Font: Font,
            ?Padding: int,
            ?Text: string,
            ?TextAngle: StyleParam.TextAngle,
            ?TextPosition: StyleParam.TextPosition,
            ?TextTemplate: string,
            ?XAnchor: StyleParam.XAnchorPosition,
            ?YAnchor: StyleParam.YAnchorPosition
        ) =

        (fun (shapeLabel: ShapeLabel) ->
        
            shapeLabel
            |> DynObj.withOptionalProperty "font" Font
            |> DynObj.withOptionalProperty "padding" Padding
            |> DynObj.withOptionalProperty "text" Text
            |> DynObj.withOptionalPropertyBy "textangle" TextAngle StyleParam.TextAngle.convert
            |> DynObj.withOptionalPropertyBy "textposition" TextPosition StyleParam.TextPosition.convert
            |> DynObj.withOptionalProperty "texttemplate" TextTemplate
            |> DynObj.withOptionalPropertyBy "xanchor" XAnchor StyleParam.XAnchorPosition.convert
            |> DynObj.withOptionalPropertyBy "yanchor" YAnchor StyleParam.YAnchorPosition.convert
        )