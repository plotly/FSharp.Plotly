namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open DynamicObj
open System
open System.IO
open System.Runtime.CompilerServices

open System.Runtime.InteropServices

[<AutoOpen>]
module Chart2D =
    [<Extension>]
    type Chart =
        [<Extension>]
        static member internal renderScatterTrace (useDefaults: bool) (useWebGL: bool) (style: Trace2D -> Trace2D) =
            if useWebGL then
                Trace2D.initScatterGL style |> GenericChart.ofTraceObject useDefaults
            else
                Trace2D.initScatter style |> GenericChart.ofTraceObject useDefaults

        [<Extension>]
        static member internal renderHeatmapTrace (useDefaults: bool) (useWebGL: bool) (style: Trace2D -> Trace2D) =
            if useWebGL then
                Trace2D.initHeatmapGL style |> GenericChart.ofTraceObject useDefaults
            else
                Trace2D.initHeatmap style |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a Scatter plot.
        ///
        /// Scatter charts are the basis of Point, Line, and Bubble Charts, and can be customized as such. We also provide abstractions for those: Chart.Line, Chart.Point, Chart.Bubble
        /// </summary>
        /// <param name="X">Sets the x coordinates of the plotted data.</param>
        /// <param name="MultiX">Sets the x coordinates of the plotted data. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Y">Sets the y coordinates of the plotted data.</param>
        /// <param name="MultiY">Sets the x coordinates of the plotted data. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Mode">Determines the drawing mode for this scatter trace.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="Fill">Sets the area to fill with a solid color. Defaults to "none" unless this trace is stacked, then it gets "tonexty" ("tonextx") if `orientation` is "v" ("h") Use with `FillColor` if not "none". "tozerox" and "tozeroy" fill to x=0 and y=0 respectively. "tonextx" and "tonexty" fill between the endpoints of this trace and the endpoints of the trace before it, connecting those endpoints with straight lines (to make a stacked area graph); if there is no trace before it, they behave like "tozerox" and "tozeroy". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape. "tonext" fills the space between two traces if one completely encloses the other (eg consecutive contour lines), and behaves like "toself" if there is no trace before it. "tonext" should not be used if one trace does not enclose the other. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order.</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="FillPattern">Sets the pattern within the marker.</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Scatter
            (
                ?X: seq<#IConvertible>,
                ?MultiX: seq<seq<#IConvertible>>,
                ?Y: seq<#IConvertible>,
                ?MultiY: seq<seq<#IConvertible>>,
                ?Mode: StyleParam.Mode,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?StackGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?Fill: StyleParam.Fill,
                ?FillColor: Color,
                ?FillPattern: Pattern,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (
                    ?Color = MarkerColor,
                    ?Outline = MarkerOutline,
                    ?Symbol = MarkerSymbol,
                    ?MultiSymbol = MultiMarkerSymbol,
                    ?Colorscale = MarkerColorScale,
                    ?MultiOpacity = MultiOpacity
                )

            let line =
                Line
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    ?Color = LineColor,
                    ?Dash = LineDash,
                    ?Colorscale = LineColorScale,
                    ?Width = LineWidth
                )

            let style =
                Trace2DStyle.Scatter(
                    ?X = X,
                    ?MultiX = MultiX,
                    ?Y = Y,
                    ?MultiY = MultiY,
                    ?Mode = Mode,
                    Marker = marker,
                    Line = line,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?AlignmentGroup = AlignmentGroup,
                    ?OffsetGroup = OffsetGroup,
                    ?StackGroup = StackGroup,
                    ?Orientation = Orientation,
                    ?GroupNorm = GroupNorm,
                    ?Fill = Fill,
                    ?FillColor = FillColor,
                    ?FillPattern = FillPattern
                )

            let useWebGL = defaultArg UseWebGL false

            Chart.renderScatterTrace useDefaults useWebGL style

        /// <summary>
        /// Creates a Scatter plot.
        ///
        /// Scatter charts are the basis of Point, Line, and Bubble Charts, and can be customized as such. We also provide abstractions for those: Chart.Line, Chart.Point, Chart.Bubble
        /// </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="mode">Determines the drawing mode for this scatter trace.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="Fill">Sets the area to fill with a solid color. Defaults to "none" unless this trace is stacked, then it gets "tonexty" ("tonextx") if `orientation` is "v" ("h") Use with `FillColor` if not "none". "tozerox" and "tozeroy" fill to x=0 and y=0 respectively. "tonextx" and "tonexty" fill between the endpoints of this trace and the endpoints of the trace before it, connecting those endpoints with straight lines (to make a stacked area graph); if there is no trace before it, they behave like "tozerox" and "tozeroy". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape. "tonext" fills the space between two traces if one completely encloses the other (eg consecutive contour lines), and behaves like "toself" if there is no trace before it. "tonext" should not be used if one trace does not enclose the other. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order.</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="FillPattern">Sets the pattern within the marker.</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Scatter
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                mode: StyleParam.Mode,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?StackGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?Fill: StyleParam.Fill,
                ?FillColor: Color,
                ?FillPattern: Pattern,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =
            Chart.Scatter(
                X = x,
                Y = y,
                Mode = mode,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?StackGroup = StackGroup,
                ?Orientation = Orientation,
                ?GroupNorm = GroupNorm,
                ?Fill = Fill,
                ?FillColor = FillColor,
                ?FillPattern = FillPattern,
                ?UseWebGL = UseWebGL,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a Scatter chart. Scatter charts are the basis of Point, Line, and Bubble Charts in Plotly, and can be customized as such. We also provide abstractions for those: Chart.Line, Chart.Point, Chart.Bubble
        /// </summary>
        /// <param name="xy">Sets the x and y coordinates of the plotted data.</param>
        /// <param name="mode">Determines the drawing mode for this scatter trace.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="Fill">Sets the area to fill with a solid color. Defaults to "none" unless this trace is stacked, then it gets "tonexty" ("tonextx") if `orientation` is "v" ("h") Use with `FillColor` if not "none". "tozerox" and "tozeroy" fill to x=0 and y=0 respectively. "tonextx" and "tonexty" fill between the endpoints of this trace and the endpoints of the trace before it, connecting those endpoints with straight lines (to make a stacked area graph); if there is no trace before it, they behave like "tozerox" and "tozeroy". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape. "tonext" fills the space between two traces if one completely encloses the other (eg consecutive contour lines), and behaves like "toself" if there is no trace before it. "tonext" should not be used if one trace does not enclose the other. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order.</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="FillPattern">Sets the pattern within the marker.</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Scatter
            (
                xy: seq<#IConvertible * #IConvertible>,
                mode: StyleParam.Mode,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?StackGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?Fill: StyleParam.Fill,
                ?FillColor: Color,
                ?FillPattern: Pattern,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =

            let x, y = Seq.unzip xy

            Chart.Scatter(
                x = x,
                y = y,
                mode = mode,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?StackGroup = StackGroup,
                ?Orientation = Orientation,
                ?GroupNorm = GroupNorm,
                ?Fill = Fill,
                ?FillColor = FillColor,
                ?FillPattern = FillPattern,
                ?UseWebGL = UseWebGL,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a Point chart, which uses Points in a 2D space to visualize data.
        /// </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Point
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?StackGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =

            // if text position or font is set, then show labels (not only when hovering)
            let changeMode =
                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)

            Chart.Scatter(
                x = x,
                y = y,
                mode = changeMode StyleParam.Mode.Markers,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?StackGroup = StackGroup,
                ?Orientation = Orientation,
                ?GroupNorm = GroupNorm,
                ?UseWebGL = UseWebGL,
                ?UseDefaults = UseDefaults
            )


        /// <summary>Creates a Point chart, which uses Points in a 2D space to visualize data. </summary>
        /// <param name="xy">Sets the x and y coordinates of the plotted data.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Point
            (
                xy: seq<#IConvertible * #IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?StackGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =
            let x, y = Seq.unzip xy

            Chart.Point(
                x = x,
                y = y,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?StackGroup = StackGroup,
                ?Orientation = Orientation,
                ?GroupNorm = GroupNorm,
                ?UseWebGL = UseWebGL,
                ?UseDefaults = UseDefaults
            )


        /// <summary> Creates a Line chart, which uses a Line plotted between the given datums in a 2D space to visualize typically an evolution of Y depending on X.</summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="ShowMarkers">Whether to show markers for the individual data points</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="Fill">Sets the area to fill with a solid color. Defaults to "none" unless this trace is stacked, then it gets "tonexty" ("tonextx") if `orientation` is "v" ("h") Use with `FillColor` if not "none". "tozerox" and "tozeroy" fill to x=0 and y=0 respectively. "tonextx" and "tonexty" fill between the endpoints of this trace and the endpoints of the trace before it, connecting those endpoints with straight lines (to make a stacked area graph); if there is no trace before it, they behave like "tozerox" and "tozeroy". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape. "tonext" fills the space between two traces if one completely encloses the other (eg consecutive contour lines), and behaves like "toself" if there is no trace before it. "tonext" should not be used if one trace does not enclose the other. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order.</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="FillPattern">Sets the pattern within the marker.</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Line
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                ?ShowMarkers: bool,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?StackGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?Fill: StyleParam.Fill,
                ?FillColor: Color,
                ?FillPattern: Pattern,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =

            // if text position or font is set than show labels (not only when hovering)
            let changeMode =
                let isShowMarker =
                    match ShowMarkers with
                    | Some isShow -> isShow
                    | Option.None -> false

                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)
                >> StyleParam.ModeUtils.showMarker (isShowMarker)

            Chart.Scatter(
                x = x,
                y = y,
                mode = changeMode StyleParam.Mode.Lines,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?StackGroup = StackGroup,
                ?Orientation = Orientation,
                ?GroupNorm = GroupNorm,
                ?Fill = Fill,
                ?FillColor = FillColor,
                ?FillPattern = FillPattern,
                ?UseWebGL = UseWebGL,
                ?UseDefaults = UseDefaults

            )



        /// <summary>Creates a Line chart, which uses a Line plotted between the given datums in a 2D space to visualize typically an evolution of Y depending on X.</summary>
        /// <param name="xy">Sets the x,y coordinates of the plotted data.</param>
        /// <param name="ShowMarkers">Whether to show markers for the individual data points</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="Fill">Sets the area to fill with a solid color. Defaults to "none" unless this trace is stacked, then it gets "tonexty" ("tonextx") if `orientation` is "v" ("h") Use with `FillColor` if not "none". "tozerox" and "tozeroy" fill to x=0 and y=0 respectively. "tonextx" and "tonexty" fill between the endpoints of this trace and the endpoints of the trace before it, connecting those endpoints with straight lines (to make a stacked area graph); if there is no trace before it, they behave like "tozerox" and "tozeroy". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape. "tonext" fills the space between two traces if one completely encloses the other (eg consecutive contour lines), and behaves like "toself" if there is no trace before it. "tonext" should not be used if one trace does not enclose the other. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order.</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="FillPattern">Sets the pattern within the marker.</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Line
            (
                xy: seq<#IConvertible * #IConvertible>,
                ?ShowMarkers: bool,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?StackGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?Fill: StyleParam.Fill,
                ?FillColor: Color,
                ?FillPattern: Pattern,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =
            let x, y = Seq.unzip xy

            Chart.Line(
                x = x,
                y = y,
                ?ShowMarkers = ShowMarkers,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?StackGroup = StackGroup,
                ?Orientation = Orientation,
                ?GroupNorm = GroupNorm,
                ?Fill = Fill,
                ?FillColor = FillColor,
                ?FillPattern = FillPattern,
                ?UseWebGL = UseWebGL,
                ?UseDefaults = UseDefaults
            )


        /// <summary>Creates a Spline chart. A spline chart is a line chart in which data points are connected by smoothed curves: this modification is aimed to improve the design of a chart.
        /// Very similar to Line Plots, spline charts are typically used to visualize an evolution of Y depending on X. </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="ShowMarkers">Whether to show markers for the individual data points</param>
        /// <param name="Smoothing">Sets the amount of smoothing. "0" corresponds to no smoothing (equivalent to a "linear" shape).  Use values between 0. and 1.3</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="Fill">Sets the area to fill with a solid color. Defaults to "none" unless this trace is stacked, then it gets "tonexty" ("tonextx") if `orientation` is "v" ("h") Use with `FillColor` if not "none". "tozerox" and "tozeroy" fill to x=0 and y=0 respectively. "tonextx" and "tonexty" fill between the endpoints of this trace and the endpoints of the trace before it, connecting those endpoints with straight lines (to make a stacked area graph); if there is no trace before it, they behave like "tozerox" and "tozeroy". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape. "tonext" fills the space between two traces if one completely encloses the other (eg consecutive contour lines), and behaves like "toself" if there is no trace before it. "tonext" should not be used if one trace does not enclose the other. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order.</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="FillPattern">Sets the pattern within the marker.</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Spline
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                ?ShowMarkers: bool,
                ?Smoothing: float,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?StackGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?Fill: StyleParam.Fill,
                ?FillColor: Color,
                ?FillPattern: Pattern,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =

            // if text position set then show labels (not only when hovering)
            let changeMode =
                let isShowMarker =
                    match ShowMarkers with
                    | Some isShow -> isShow
                    | Option.None -> false

                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)
                >> StyleParam.ModeUtils.showMarker (isShowMarker)

            let useDefaults =
                defaultArg UseDefaults true

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (
                    ?Color = MarkerColor,
                    ?Outline = MarkerOutline,
                    ?Symbol = MarkerSymbol,
                    ?MultiSymbol = MultiMarkerSymbol,
                    ?Colorscale = MarkerColorScale,
                    ?MultiOpacity = MultiOpacity
                )

            let line =
                Line
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    ?Color = LineColor,
                    ?Dash = LineDash,
                    ?Colorscale = LineColorScale,
                    ?Width = LineWidth,
                    Shape = StyleParam.Shape.Spline,
                    ?Smoothing = Smoothing

                )

            let style =
                Trace2DStyle.Scatter(
                    X = x,
                    Y = y,
                    Mode = changeMode StyleParam.Mode.Lines,
                    Marker = marker,
                    Line = line,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?AlignmentGroup = AlignmentGroup,
                    ?OffsetGroup = OffsetGroup,
                    ?StackGroup = StackGroup,
                    ?Orientation = Orientation,
                    ?GroupNorm = GroupNorm,
                    ?Fill = Fill,
                    ?FillColor = FillColor,
                    ?FillPattern = FillPattern
                )

            let useWebGL = defaultArg UseWebGL false

            Chart.renderScatterTrace useDefaults useWebGL style


        /// <summary>
        /// Creates a Spline chart. A spline chart is a line chart in which data points are connected by smoothed curves: this modification is aimed to improve the design of a chart.
        /// Very similar to Line Plots, spline charts are typically used to visualize an evolution of Y depending on X.
        /// </summary>
        /// <param name="xy">Sets the x,y coordinates of the plotted data.</param>
        /// <param name="ShowMarkers">Whether to show markers for the individual data points</param>
        /// <param name="Smoothing">Sets the amount of smoothing. "0" corresponds to no smoothing (equivalent to a "linear" shape).  Use values between 0. and 1.3</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="Fill">Sets the area to fill with a solid color. Defaults to "none" unless this trace is stacked, then it gets "tonexty" ("tonextx") if `orientation` is "v" ("h") Use with `FillColor` if not "none". "tozerox" and "tozeroy" fill to x=0 and y=0 respectively. "tonextx" and "tonexty" fill between the endpoints of this trace and the endpoints of the trace before it, connecting those endpoints with straight lines (to make a stacked area graph); if there is no trace before it, they behave like "tozerox" and "tozeroy". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape. "tonext" fills the space between two traces if one completely encloses the other (eg consecutive contour lines), and behaves like "toself" if there is no trace before it. "tonext" should not be used if one trace does not enclose the other. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order.</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="FillPattern">Sets the pattern within the marker.</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Spline
            (
                xy: seq<#IConvertible * #IConvertible>,
                ?ShowMarkers: bool,
                ?Smoothing: float,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?StackGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?Fill: StyleParam.Fill,
                ?FillColor: Color,
                ?FillPattern: Pattern,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =
            let x, y = Seq.unzip xy

            Chart.Spline(
                x = x,
                y = y,
                ?ShowMarkers = ShowMarkers,
                ?Smoothing = Smoothing,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?StackGroup = StackGroup,
                ?Orientation = Orientation,
                ?GroupNorm = GroupNorm,
                ?Fill = Fill,
                ?FillColor = FillColor,
                ?FillPattern = FillPattern,
                ?UseWebGL = UseWebGL,
                ?UseDefaults = UseDefaults

            )


        /// <summary>Creates a bubble chart. A bubble chart is a variation of the Point chart, where the data points get an additional scale by being rendered as bubbles of different sizes.</summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="sizes">Sets the bubble size of the plotted data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Bubble
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                sizes: seq<int>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?StackGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            // if text position or font is set than show labels (not only when hovering)
            let changeMode =
                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (
                    ?Color = MarkerColor,
                    ?Outline = MarkerOutline,
                    ?Symbol = MarkerSymbol,
                    ?MultiSymbol = MultiMarkerSymbol,
                    ?Colorscale = MarkerColorScale,
                    ?MultiOpacity = MultiOpacity,
                    MultiSize = sizes
                )

            let line =
                Line
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    ?Color = LineColor,
                    ?Dash = LineDash,
                    ?Colorscale = LineColorScale,
                    ?Width = LineWidth
                )

            let style =
                Trace2DStyle.Scatter(
                    X = x,
                    Y = y,
                    Mode = changeMode StyleParam.Mode.Markers,
                    Marker = marker,
                    Line = line,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?AlignmentGroup = AlignmentGroup,
                    ?OffsetGroup = OffsetGroup,
                    ?StackGroup = StackGroup,
                    ?Orientation = Orientation,
                    ?GroupNorm = GroupNorm
                )

            let useWebGL = defaultArg UseWebGL false

            Chart.renderScatterTrace useDefaults useWebGL style

        /// <summary>Creates a bubble chart. A bubble chart is a variation of the Point chart, where the data points get an additional scale by being rendered as bubbles of different sizes.</summary>
        /// <param name="xysizes">Sets the x coordinates, y coordinates, and bubble sizes of the plotted data.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Bubble
            (
                xysizes: seq<#IConvertible * #IConvertible * int>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?StackGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =
            let x, y, sizes = Seq.unzip3 xysizes

            Chart.Bubble(
                x = x,
                y = y,
                sizes = sizes,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?StackGroup = StackGroup,
                ?Orientation = Orientation,
                ?GroupNorm = GroupNorm,
                ?UseWebGL = UseWebGL,
                ?UseDefaults = UseDefaults

            )

        /// <summary>
        /// Displays a range of data by plotting three Y values per data point (upper, mid, lower).
        ///
        /// The mid Y value usually resembles some kind of central tendency and the upper/lower Y values some kind of spread.
        /// </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data for the mid Y value.</param>
        /// <param name="upper">Sets the y coordinates of the plotted data for the upper Y value.</param>
        /// <param name="lower">Sets the y coordinates of the plotted data for the lower Y value.</param>
        /// <param name="mode">Determines the drawing mode for this scatter trace.</param>
        /// <param name="Name">Sets the trace name of the mid Y values. The trace name appear as the legend item and on hover</param>
        /// <param name="GroupName">Sets the name of the legendgroup for the three traces of this plot.</param>
        /// <param name="ShowMarkers">Determines whether or not an To show markers for each datum.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Text">Sets a text associated with each datum for the mid Y values.</param>
        /// <param name="MultiText">Sets individual text for each datum for the mid Y values.</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker for the mid Y values.</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker for the mid Y values.</param>
        /// <param name="MarkerOutline">Sets the outline of the marker for the mid Y values.</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum for the mid Y values.</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum for the mid Y values.</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments) for the mid Y values.</param>
        /// <param name="LineColor">Sets the color of the line for the mid Y values.</param>
        /// <param name="LineColorScale">Sets the colorscale of the line for the mid Y values.</param>
        /// <param name="LineWidth">Sets the width of the line for the mid Y values.</param>
        /// <param name="LineDash">sets the drawing style of the line for the mid Y values.</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments) for the mid Y values.</param>
        /// <param name="RangeColor">Sets the color of the range between upper and lower Y values.</param>
        /// <param name="RangePattern">Sets the pattern of the range between upper and lower Y values.</param>
        /// <param name="UpperText">Sets a text associated with each datum for the upper Y values.</param>
        /// <param name="MultiUpperText">Sets individual text for each datum for the upper Y values.</param>
        /// <param name="LowerText">Sets a text associated with each datum for the lower Y values.</param>
        /// <param name="MultiLowerText">Sets individual text for each datum for the lower Y values.</param>
        /// <param name="TextFont">Sets the text font for all Text items</param>
        /// <param name="LowerName">Sets the name of the lower Y value trace.</param>
        /// <param name="LowerLine">Sets the line for the lower Y values.</param>
        /// <param name="LowerMarker">Sets the marker for the lower Y values.</param>
        /// <param name="UpperName">Sets the name of the uper Y value trace.</param>
        /// <param name="UpperLine">Sets the line for the upper Y values.</param>
        /// <param name="UpperMarker">Sets the marker for the upper Y values.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Range
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                upper: seq<#IConvertible>,
                lower: seq<#IConvertible>,
                mode: StyleParam.Mode,
                ?Name: string,
                ?GroupName: string,
                ?ShowMarkers: bool,
                ?ShowLegend: bool,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?UpperMarker: Marker,
                ?LowerMarker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?UpperLine: Line,
                ?LowerLine: Line,
                ?RangeColor: Color,
                ?RangePattern: Pattern,
                ?UpperText: #IConvertible,
                ?MultiUpperText: seq<#IConvertible>,
                ?LowerText: #IConvertible,
                ?MultiLowerText: seq<#IConvertible>,
                ?TextFont: Font,
                ?LowerName: string,
                ?UpperName: string,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let upperName = defaultArg UpperName "upper"
            let lowerName = defaultArg LowerName "lower"

            // if text position or font is set than show labels (not only when hovering)
            let changeMode =
                let isShowMarker =
                    match ShowMarkers with
                    | Some isShow -> isShow
                    | Option.None -> false

                StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)
                >> StyleParam.ModeUtils.showMarker (isShowMarker)

            let trace =
                Chart.Scatter(
                    x = x,
                    y = y,
                    mode = changeMode mode,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?MarkerColor = MarkerColor,
                    ?MarkerColorScale = MarkerColorScale,
                    ?MarkerOutline = MarkerOutline,
                    ?MarkerSymbol = MarkerSymbol,
                    ?MultiMarkerSymbol = MultiMarkerSymbol,
                    ?Marker = Marker,
                    ?LineColor = LineColor,
                    ?LineColorScale = LineColorScale,
                    ?LineWidth = LineWidth,
                    ?LineDash = LineDash,
                    ?Line = Line
                )
                |> GenericChart.mapTrace (
                    Trace2DStyle.Scatter(
                        LegendGroup = (defaultArg GroupName "Range"),
                        LegendGroupTitle = (Title.init (Text = (defaultArg GroupName "Range")))
                    )
                )

            let lower =
                Trace2D.initScatter (
                    Trace2DStyle.Scatter(
                        X = x,
                        Y = lower,
                        Mode = changeMode mode,
                        ?FillColor = RangeColor,
                        ?Name = Some lowerName,
                        ShowLegend = (defaultArg ShowLegend true),
                        ?Text = LowerText,
                        ?MultiText = MultiLowerText,
                        ?TextPosition = TextPosition,
                        ?TextFont = TextFont,
                        ?Marker = LowerMarker,
                        ?Line = LowerLine,
                        LegendGroup = (defaultArg GroupName "Range")
                    )
                )
                |> TraceStyle.Marker(
                    Color =
                        if RangeColor.IsSome then
                            RangeColor.Value
                        else
                            (Plotly.NET.Color.fromString "rgba(0,0,0,0.5)")
                )

            let upper =
                Trace2D.initScatter (
                    Trace2DStyle.Scatter(
                        X = x,
                        Y = upper,
                        Mode = changeMode mode,
                        Fill = StyleParam.Fill.ToNext_y,
                        ?FillColor = RangeColor,
                        ?FillPattern = RangePattern,
                        ?Name = Some upperName,
                        ShowLegend = (defaultArg ShowLegend true),
                        ?Text = UpperText,
                        ?MultiText = MultiUpperText,
                        ?TextPosition = TextPosition,
                        ?TextFont = TextFont,
                        ?Marker = UpperMarker,
                        ?Line = UpperLine,
                        LegendGroup = (defaultArg GroupName "Range")
                    )
                )
                |> TraceStyle.Marker(
                    Color =
                        if RangeColor.IsSome then
                            RangeColor.Value
                        else
                            (Plotly.NET.Color.fromString "rgba(0,0,0,0.5)")
                )

            GenericChart.ofTraceObjects
                useDefaults
                [
                    lower
                    upper
                    yield! (GenericChart.getTraces trace)
                ]

        /// <summary>
        /// Displays a range of data by plotting three Y values per data point (upper, mid, lower).
        ///
        /// The mid Y value usually resembles some kind of central tendency and the upper/lower Y values some kind of spread.
        /// </summary>
        /// <param name="xy">Sets the x and y coordinates of the plotted data (x is used for all y data, the y coordinates are those of the mod values).</param>
        /// <param name="upper">Sets the y coordinates of the plotted data for the upper Y value.</param>
        /// <param name="lower">Sets the y coordinates of the plotted data for the lower Y value.</param>
        /// <param name="mode">Determines the drawing mode for this scatter trace.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="GroupName">Sets the name of the legendgroup for the three traces of this plot.</param>
        /// <param name="ShowMarkers">Determines whether or not an To show markers for each datum.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Text">Sets a text associated with each datum for the mid Y values.</param>
        /// <param name="MultiText">Sets individual text for each datum for the mid Y values.</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker for the mid Y values.</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker for the mid Y values.</param>
        /// <param name="MarkerOutline">Sets the outline of the marker for the mid Y values.</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum for the mid Y values.</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum for the mid Y values.</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments) for the mid Y values.</param>
        /// <param name="LineColor">Sets the color of the line for the mid Y values.</param>
        /// <param name="LineColorScale">Sets the colorscale of the line for the mid Y values.</param>
        /// <param name="LineWidth">Sets the width of the line for the mid Y values.</param>
        /// <param name="LineDash">sets the drawing style of the line for the mid Y values.</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments) for the mid Y values.</param>
        /// <param name="RangeColor">Sets the color of the range between upper and lower Y values.</param>
        /// <param name="RangePattern">Sets the pattern of the range between upper and lower Y values.</param>
        /// <param name="UpperText">Sets a text associated with each datum for the upper Y values.</param>
        /// <param name="MultiUpperText">Sets individual text for each datum for the upper Y values.</param>
        /// <param name="LowerText">Sets a text associated with each datum for the lower Y values.</param>
        /// <param name="MultiLowerText">Sets individual text for each datum for the lower Y values.</param>
        /// <param name="TextFont">Sets the text font for all Text items</param>
        /// <param name="LowerName">Sets the name of the lower Y value trace.</param>
        /// <param name="LowerLine">Sets the line for the lower Y values.</param>
        /// <param name="LowerMarker">Sets the marker for the lower Y values.</param>
        /// <param name="UpperName">Sets the name of the uper Y value trace.</param>
        /// <param name="UpperLine">Sets the line for the upper Y values.</param>
        /// <param name="UpperMarker">Sets the marker for the upper Y values.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Range
            (
                xy: seq<#IConvertible * #IConvertible>,
                upper: seq<#IConvertible>,
                lower: seq<#IConvertible>,
                mode: StyleParam.Mode,
                ?Name: string,
                ?GroupName: string,
                ?ShowMarkers: bool,
                ?ShowLegend: bool,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?UpperMarker: Marker,
                ?LowerMarker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?UpperLine: Line,
                ?LowerLine: Line,
                ?RangeColor: Color,
                ?RangePattern: Pattern,
                ?UpperText: #IConvertible,
                ?MultiUpperText: seq<#IConvertible>,
                ?LowerText: #IConvertible,
                ?MultiLowerText: seq<#IConvertible>,
                ?TextFont: Font,
                ?LowerName: string,
                ?UpperName: string,
                ?UseDefaults: bool
            ) =
            let x, y = Seq.unzip xy

            Chart.Range(
                x = x,
                y = y,
                upper = upper,
                lower = lower,
                mode = mode,
                ?Name = Name,
                ?GroupName = GroupName,
                ?ShowMarkers = ShowMarkers,
                ?ShowLegend = ShowLegend,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?UpperMarker = UpperMarker,
                ?LowerMarker = LowerMarker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?UpperLine = UpperLine,
                ?LowerLine = LowerLine,
                ?RangeColor = RangeColor,
                ?RangePattern = RangePattern,
                ?UpperText = UpperText,
                ?MultiUpperText = MultiUpperText,
                ?LowerText = LowerText,
                ?MultiLowerText = MultiLowerText,
                ?TextFont = TextFont,
                ?LowerName = LowerName,
                ?UpperName = UpperName,
                ?UseDefaults = UseDefaults
            )
            
        /// <summary> Creates an Area chart, which uses a Line plotted between the given datums in a 2D space, additionally colouring the area between the line and the Y Axis.</summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="ShowMarkers">Whether to show markers for the individual data points</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="FillPatternShape">Sets a pattern shape for the area fill</param>
        /// <param name="FillPattern">Sets the pattern within the area. (use this for more finegrained control than the other fillpattern-associated arguments).</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Area
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                ?ShowMarkers: bool,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?StackGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?FillColor: Color,
                ?FillPatternShape: StyleParam.PatternShape,
                ?FillPattern: Pattern,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =

            let fillpattern =
                FillPattern
                |> Option.defaultValue (TraceObjects.Pattern.init ())
                |> TraceObjects.Pattern.style (?Shape = FillPatternShape)

            Chart.Line(
                x = x,
                y = y,
                Fill = StyleParam.Fill.ToZero_y,
                ?ShowMarkers = ShowMarkers,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?StackGroup = StackGroup,
                ?Orientation = Orientation,
                ?GroupNorm = GroupNorm,
                FillPattern = fillpattern,
                ?FillColor = FillColor,
                ?UseWebGL = UseWebGL,
                ?UseDefaults = UseDefaults
            )



        /// <summary> Creates an Area chart, which uses a Line plotted between the given datums in a 2D space, additionally colouring the area between the line and the Y Axis.</summary>
        /// <param name="xy">Sets the x and y coordinates of the plotted data.</param>
        /// <param name="ShowMarkers">Whether to show markers for the individual data points</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="FillColor">ets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="FillPatternShape">Sets a pattern shape for the area fill</param>
        /// <param name="FillPattern">Sets the pattern within the area. (use this for more finegrained control than the other fillpattern-associated arguments).</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Area
            (
                xy: seq<#IConvertible * #IConvertible>,
                ?ShowMarkers: bool,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?StackGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?FillColor: Color,
                ?FillPatternShape: StyleParam.PatternShape,
                ?FillPattern: Pattern,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =

            let x, y = Seq.unzip xy

            Chart.Area(
                x = x,
                y = y,
                ?ShowMarkers = ShowMarkers,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?StackGroup = StackGroup,
                ?Orientation = Orientation,
                ?GroupNorm = GroupNorm,
                ?FillColor = FillColor,
                ?FillPatternShape = FillPatternShape,
                ?FillPattern = FillPattern,
                ?UseWebGL = UseWebGL,
                ?UseDefaults = UseDefaults
            )


        /// <summary>Creates a Spline area chart, which uses a smoothed Line plotted between the given datums in a 2D space, additionally colouring the area between the line and the Y Axis.</summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="ShowMarkers">Whether to show markers for the individual data points</param>
        /// <param name="Smoothing">Sets the amount of smoothing. "0" corresponds to no smoothing (equivalent to a "linear" shape).  Use values between 0. and 1.3</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="FillColor">ets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="FillPatternShape">Sets a pattern shape for the area fill</param>
        /// <param name="FillPattern">Sets the pattern within the area. (use this for more finegrained control than the other fillpattern-associated arguments).</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member SplineArea
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                ?ShowMarkers: bool,
                ?Smoothing: float,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?StackGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?FillColor: Color,
                ?FillPatternShape: StyleParam.PatternShape,
                ?FillPattern: Pattern,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =

            let fillpattern =
                FillPattern
                |> Option.defaultValue (TraceObjects.Pattern.init ())
                |> TraceObjects.Pattern.style (?Shape = FillPatternShape)

            Chart.Spline(
                x = x,
                y = y,
                Fill = StyleParam.Fill.ToZero_y,
                ?ShowMarkers = ShowMarkers,
                ?Smoothing = Smoothing,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?StackGroup = StackGroup,
                ?Orientation = Orientation,
                ?GroupNorm = GroupNorm,
                ?FillColor = FillColor,
                FillPattern = fillpattern,
                ?UseWebGL = UseWebGL,
                ?UseDefaults = UseDefaults

            )

        /// <summary>Creates a Spline area chart, which uses a smoothed Line plotted between the given datums in a 2D space, additionally colouring the area between the line and the Y Axis.</summary>
        /// <param name="xy">Sets the x and y coordinates of the plotted data.</param>
        /// <param name="ShowMarkers">Whether to show markers for the individual data points</param>
        /// <param name="Smoothing">Sets the amount of smoothing. "0" corresponds to no smoothing (equivalent to a "linear" shape).  Use values between 0. and 1.3</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="FillColor">ets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="FillPatternShape">Sets a pattern shape for the area fill</param>
        /// <param name="FillPattern">Sets the pattern within the area. (use this for more finegrained control than the other fillpattern-associated arguments).</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        static member SplineArea
            (
                xy: seq<#IConvertible * #IConvertible>,
                ?ShowMarkers: bool,
                ?Smoothing: float,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?StackGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?FillColor: Color,
                ?FillPatternShape: StyleParam.PatternShape,
                ?FillPattern: Pattern,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =

            let x, y = Seq.unzip xy

            Chart.SplineArea(
                x = x,
                y = y,
                ?ShowMarkers = ShowMarkers,
                ?Smoothing = Smoothing,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?StackGroup = StackGroup,
                ?Orientation = Orientation,
                ?GroupNorm = GroupNorm,
                ?FillColor = FillColor,
                ?FillPatternShape = FillPatternShape,
                ?FillPattern = FillPattern,
                ?UseWebGL = UseWebGL,
                ?UseDefaults = UseDefaults
            )

        /// <summary> Creates a stacked Area chart, which uses a Line plotted between the given datums in a 2D space, additionally colouring the area between the line and the Y Axis. Multiple Charts of this type are stacked on top of each others y dimensions</summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="ShowMarkers">Whether to show markers for the individual data points</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="FillColor">ets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="FillPatternShape">Sets a pattern shape for the area fill</param>
        /// <param name="FillPattern">Sets the pattern within the area. (use this for more finegrained control than the other fillpattern-associated arguments).</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member StackedArea
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                ?ShowMarkers: bool,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?FillColor: Color,
                ?FillPatternShape: StyleParam.PatternShape,
                ?FillPattern: Pattern,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =

            let fillpattern =
                FillPattern
                |> Option.defaultValue (TraceObjects.Pattern.init ())
                |> TraceObjects.Pattern.style (?Shape = FillPatternShape)

            Chart.Line(
                x = x,
                y = y,
                Fill = StyleParam.Fill.ToNext_y,
                ?ShowMarkers = ShowMarkers,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                StackGroup = "stackedarea",
                ?Orientation = Orientation,
                ?GroupNorm = GroupNorm,
                ?FillColor = FillColor,
                FillPattern = fillpattern,
                ?UseWebGL = UseWebGL,
                ?UseDefaults = UseDefaults
            )

        /// <summary> Creates a stacked Area chart, which uses a Line plotted between the given datums in a 2D space, additionally colouring the area between the line and the Y Axis. Multiple Charts of this type are stacked on top of each others y dimensions</summary>
        /// <param name="xy">Sets the x and y coordinates of the plotted data.</param>
        /// <param name="ShowMarkers">Whether to show markers for the individual data points</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="FillColor">ets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="FillPatternShape">Sets a pattern shape for the area fill</param>
        /// <param name="FillPattern">Sets the pattern within the area. (use this for more finegrained control than the other fillpattern-associated arguments).</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member StackedArea
            (
                xy: seq<#IConvertible * #IConvertible>,
                ?ShowMarkers: bool,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?Orientation: StyleParam.Orientation,
                ?GroupNorm: StyleParam.GroupNorm,
                ?FillColor: Color,
                ?FillPatternShape: StyleParam.PatternShape,
                ?FillPattern: Pattern,
                ?UseWebGL: bool,
                ?UseDefaults: bool
            ) =

            let x, y = Seq.unzip xy

            Chart.StackedArea(
                x = x,
                y = y,
                ?ShowMarkers = ShowMarkers,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?Orientation = Orientation,
                ?GroupNorm = GroupNorm,
                ?FillPatternShape = FillPatternShape,
                ?FillPattern = FillPattern,
                ?FillColor = FillColor,
                ?UseWebGL = UseWebGL,
                ?UseDefaults = UseDefaults
            )


        /// <summary>
        /// Creates a Funnel chart.
        ///
        /// Funnel charts visualize stages in a process using length-encoded bars. This trace can be used to show data in either a part-to-whole representation wherein each item appears in a single stage, or in a "drop-off" representation wherein each item appears in each stage it traversed. See also the "funnelarea" trace type for a different approach to visualizing funnel data.
        /// </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="Width">Sets the bar width (in position axis units).</param>
        /// <param name="Offset">Shifts the position where the bar is drawn (in position axis units). In "group" barmode, traces that set "offset" will be excluded and drawn in "overlay" mode instead.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="Orientation">Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used - including if `visible` is "legendonly" but not if it is `false`. Sets the stacking direction. With "v" ("h"), the y (x) values of subsequent traces are added. Also affects the default value of `fill`.</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="MarkerColor">Sets the color of the bars.</param>
        /// <param name="MarkerOutline">Sets the color of the bar outline.</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="TextInfo">Determines which trace information appear on the graph. In the case of having multiple funnels, percentages and totals are computed separately (per trace).</param>
        /// <param name="ConnectorLineColor">Sets the line color of the funnel connector</param>
        /// <param name="ConnectorLineStyle">Sets the line style of the funnel connector</param>
        /// <param name="ConnectorFillColor">Sets the fill color of the funnel connector</param>
        /// <param name="ConnectorLine">Sets the line of the funnel connector (use this for more finegrained control than the other connector line associated arguments).</param>
        /// <param name="Connector">Sets the funnel connector (use this for more finegrained control than the other connector-associated arguments).</param>
        /// <param name="InsideTextFont">Sets the font used for `text` lying inside the bar.</param>
        /// <param name="OutsideTextFont">Sets the font used for `text` lying outside the bar.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Funnel
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Width: float,
                ?Offset: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?Orientation: StyleParam.Orientation,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?MarkerColor: Color,
                ?MarkerOutline: Line,
                ?Marker: Marker,
                ?TextInfo: StyleParam.TextInfo,
                ?ConnectorLineColor: Color,
                ?ConnectorLineStyle: StyleParam.DrawingStyle,
                ?ConnectorFillColor: Color,
                ?ConnectorLine: Line,
                ?Connector: FunnelConnector,
                ?InsideTextFont: Font,
                ?OutsideTextFont: Font,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (?Color = MarkerColor, ?Outline = MarkerOutline)

            let connectorLine =
                ConnectorLine
                |> Option.map (Plotly.NET.Line.style (?Color = ConnectorLineColor, ?Dash = ConnectorLineStyle))

            let connector =
                Connector
                |> Option.defaultValue (TraceObjects.FunnelConnector.init ())
                |> TraceObjects.FunnelConnector.style (?FillColor = ConnectorFillColor, ?Line = connectorLine)

            Trace2D.initFunnel (
                Trace2DStyle.Funnel(
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    X = x,
                    Y = y,
                    ?Width = Width,
                    ?Offset = Offset,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?Orientation = Orientation,
                    ?AlignmentGroup = AlignmentGroup,
                    ?OffsetGroup = OffsetGroup,
                    Marker = marker,
                    ?TextInfo = TextInfo,
                    Connector = connector,
                    ?InsideTextFont = InsideTextFont,
                    ?OutsideTextFont = OutsideTextFont

                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a stacked Funnel chart, a variation of the funnel chart where multiple funnel bars of each stage are stacked on top of each other.
        /// To create this type of chart, combine multiple of these charts via `Chart.combine`.
        ///
        /// Funnel charts visualize stages in a process using length-encoded bars. This trace can be used to show data in either a part-to-whole representation wherein each item appears in a single stage, or in a "drop-off" representation wherein each item appears in each stage it traversed. See also the "funnelarea" trace type for a different approach to visualizing funnel data.
        /// </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="Width">Sets the bar width (in position axis units).</param>
        /// <param name="Offset">Shifts the position where the bar is drawn (in position axis units). In "group" barmode, traces that set "offset" will be excluded and drawn in "overlay" mode instead.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="Orientation">Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used - including if `visible` is "legendonly" but not if it is `false`. Sets the stacking direction. With "v" ("h"), the y (x) values of subsequent traces are added. Also affects the default value of `fill`.</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="MarkerColor">Sets the color of the bars.</param>
        /// <param name="MarkerOutline">Sets the color of the bar outline.</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="TextInfo">Determines which trace information appear on the graph. In the case of having multiple funnels, percentages and totals are computed separately (per trace).</param>
        /// <param name="ConnectorLineColor">Sets the line color of the funnel connector</param>
        /// <param name="ConnectorLineStyle">Sets the line style of the funnel connector</param>
        /// <param name="ConnectorFillColor">Sets the fill color of the funnel connector</param>
        /// <param name="ConnectorLine">Sets the line of the funnel connector (use this for more finegrained control than the other connector line associated arguments).</param>
        /// <param name="Connector">Sets the funnel connector (use this for more finegrained control than the other connector-associated arguments).</param>
        /// <param name="InsideTextFont">Sets the font used for `text` lying inside the bar.</param>
        /// <param name="OutsideTextFont">Sets the font used for `text` lying outside the bar.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        static member StackedFunnel
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Width: float,
                ?Offset: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?Orientation: StyleParam.Orientation,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?MarkerColor: Color,
                ?MarkerOutline: Line,
                ?Marker: Marker,
                ?TextInfo: StyleParam.TextInfo,
                ?ConnectorLineColor: Color,
                ?ConnectorLineStyle: StyleParam.DrawingStyle,
                ?ConnectorFillColor: Color,
                ?ConnectorLine: Line,
                ?Connector: FunnelConnector,
                ?InsideTextFont: Font,
                ?OutsideTextFont: Font,
                ?UseDefaults: bool
            ) =
            Chart.Funnel(
                x = x,
                y = y,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?Width = Width,
                ?Offset = Offset,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?Orientation = Orientation,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?MarkerColor = MarkerColor,
                ?MarkerOutline = MarkerOutline,
                ?Marker = Marker,
                ?TextInfo = TextInfo,
                ?ConnectorLineColor = ConnectorLineColor,
                ?ConnectorLineStyle = ConnectorLineStyle,
                ?ConnectorFillColor = ConnectorFillColor,
                ?ConnectorLine = ConnectorLine,
                ?Connector = Connector,
                ?InsideTextFont = InsideTextFont,
                ?OutsideTextFont = OutsideTextFont,
                ?UseDefaults = UseDefaults

            )
            |> GenericChart.mapLayout (Layout.style (FunnelMode = StyleParam.FunnelMode.Stack))

        /// <summary>
        /// Creates a waterfall chart.
        ///
        /// Waterfall charts are special bar charts that help visualizing the cumulative effect of sequentially introduced positive or negative values
        /// </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="IncreasingColor">Sets the color of increasing values</param>
        /// <param name="Increasing">Sets the style options of increasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="DecreasingColor">Sets the color of decreasing values</param>
        /// <param name="Decreasing">Sets the style options of decreasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="TotalsColor">Sets the color of total values</param>
        /// <param name="Totals">Sets the style options of total values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units).</param>
        /// <param name="MultiWidth">Sets the individual bar width of each datum (in position axis units).</param>
        /// <param name="Opacity">Sets the opacity of the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="TextFont">Sets the font used for `text`.</param>
        /// <param name="Connector">Sets the waterfall connector of this trace</param>
        /// <param name="Measure">An array containing types of measures. By default the values are considered as 'relative'. However; it is possible to use 'total' to compute the sums. Also 'absolute' could be applied to reset the computed total or to declare an initial value where needed.</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="Orientation">Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used - including if `visible` is "legendonly" but not if it is `false`. Sets the stacking direction. With "v" ("h"), the y (x) values of subsequent traces are added. Also affects the default value of `fill`.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Waterfall
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?IncreasingColor: Color,
                ?Increasing: FinanceMarker,
                ?DecreasingColor: Color,
                ?Decreasing: FinanceMarker,
                ?TotalsColor: Color,
                ?Totals: FinanceMarker,
                ?Base: float,
                ?Width: float,
                ?MultiWidth: seq<float>,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?TextFont: Font,
                ?Connector: WaterfallConnector,
                ?Measure: StyleParam.WaterfallMeasure seq,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let increasing =
                Increasing
                |> Option.defaultValue (FinanceMarker.init ())
                |> FinanceMarker.style (?FillColor = IncreasingColor)

            let decreasing =
                Decreasing
                |> Option.defaultValue (FinanceMarker.init ())
                |> FinanceMarker.style (?FillColor = DecreasingColor)

            let totals =
                Totals
                |> Option.defaultValue (FinanceMarker.init ())
                |> FinanceMarker.style (?FillColor = TotalsColor)

            Trace2D.initWaterfall (
                Trace2DStyle.Waterfall(
                    X = x,
                    Y = y,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    Increasing = increasing,
                    Decreasing = decreasing,
                    Totals = totals,
                    ?Base = Base,
                    ?Width = Width,
                    ?MultiWidth = MultiWidth,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?TextFont = TextFont,
                    ?Connector = Connector,
                    ?Measure = Measure,
                    ?AlignmentGroup = AlignmentGroup,
                    ?OffsetGroup = OffsetGroup,
                    ?Orientation = Orientation
                )
            )
            |> GenericChart.ofTraceObject useDefaults


        /// <summary>
        /// Creates a waterfall chart.
        ///
        /// Waterfall charts are special bar charts that help visualizing the cumulative effect of sequentially introduced positive or negative values
        /// </summary>
        /// <param name="xy">Sets the x and y coordinates of the plotted data.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="IncreasingColor">Sets the color of increasing values</param>
        /// <param name="Increasing">Sets the style options of increasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="DecreasingColor">Sets the color of decreasing values</param>
        /// <param name="Decreasing">Sets the style options of decreasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="TotalsColor">Sets the color of total values</param>
        /// <param name="Totals">Sets the style options of total values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units).</param>
        /// <param name="MultiWidth">Sets the individual bar width of each datum (in position axis units).</param>
        /// <param name="Opacity">Sets the opacity of the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="TextFont">Sets the font used for `text`.</param>
        /// <param name="Connector">Sets the waterfall connector of this trace</param>
        /// <param name="Measure">An array containing types of measures. By default the values are considered as 'relative'. However; it is possible to use 'total' to compute the sums. Also 'absolute' could be applied to reset the computed total or to declare an initial value where needed.</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="Orientation">Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used - including if `visible` is "legendonly" but not if it is `false`. Sets the stacking direction. With "v" ("h"), the y (x) values of subsequent traces are added. Also affects the default value of `fill`.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Waterfall
            (
                xy: seq<#IConvertible * #IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?IncreasingColor: Color,
                ?Increasing: FinanceMarker,
                ?DecreasingColor: Color,
                ?Decreasing: FinanceMarker,
                ?TotalsColor: Color,
                ?Totals: FinanceMarker,
                ?Base: float,
                ?Width: float,
                ?MultiWidth: seq<float>,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?TextFont: Font,
                ?Connector: WaterfallConnector,
                ?Measure: StyleParam.WaterfallMeasure seq,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?UseDefaults: bool
            ) =

            let x, y = Seq.unzip xy

            Chart.Waterfall(
                x = x,
                y = y,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?IncreasingColor = IncreasingColor,
                ?Increasing = Increasing,
                ?DecreasingColor = DecreasingColor,
                ?Decreasing = Decreasing,
                ?TotalsColor = TotalsColor,
                ?Totals = Totals,
                ?Base = Base,
                ?Width = Width,
                ?MultiWidth = MultiWidth,
                ?Opacity = Opacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?TextFont = TextFont,
                ?Connector = Connector,
                ?Measure = Measure,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?Orientation = Orientation,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a waterfall chart.
        ///
        /// Waterfall charts are special bar charts that help visualizing the cumulative effect of sequentially introduced positive or negative values
        /// </summary>
        /// <param name="xymeasures">Sets the x and y coordinates of the plotted data, together with a measure for each (x,y) pair that defines the type of computation done for each pair.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="IncreasingColor">Sets the color of increasing values</param>
        /// <param name="Increasing">Sets the style options of increasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="DecreasingColor">Sets the color of decreasing values</param>
        /// <param name="Decreasing">Sets the style options of decreasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="TotalsColor">Sets the color of total values</param>
        /// <param name="Totals">Sets the style options of total values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units).</param>
        /// <param name="MultiWidth">Sets the individual bar width of each datum (in position axis units).</param>
        /// <param name="Opacity">Sets the opacity of the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="TextFont">Sets the font used for `text`.</param>
        /// <param name="Connector">Sets the waterfall connector of this trace</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="Orientation">Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used - including if `visible` is "legendonly" but not if it is `false`. Sets the stacking direction. With "v" ("h"), the y (x) values of subsequent traces are added. Also affects the default value of `fill`.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Waterfall
            (
                xymeasures: seq<#IConvertible * #IConvertible * StyleParam.WaterfallMeasure>,
                ?Name: string,
                ?ShowLegend: bool,
                ?IncreasingColor: Color,
                ?Increasing: FinanceMarker,
                ?DecreasingColor: Color,
                ?Decreasing: FinanceMarker,
                ?TotalsColor: Color,
                ?Totals: FinanceMarker,
                ?Base: float,
                ?Width: float,
                ?MultiWidth: seq<float>,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?TextFont: Font,
                ?Connector: WaterfallConnector,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?Orientation: StyleParam.Orientation,
                ?UseDefaults: bool
            ) =

            let x, y, measure = Seq.unzip3 xymeasures

            Chart.Waterfall(
                x = x,
                y = y,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?IncreasingColor = IncreasingColor,
                ?Increasing = Increasing,
                ?DecreasingColor = DecreasingColor,
                ?Decreasing = Decreasing,
                ?TotalsColor = TotalsColor,
                ?Totals = Totals,
                ?Base = Base,
                ?Width = Width,
                ?MultiWidth = MultiWidth,
                ?Opacity = Opacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?TextFont = TextFont,
                ?Connector = Connector,
                Measure = measure,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?Orientation = Orientation,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a bar chart, with bars plotted horizontally
        ///
        /// A bar chart is a chart that presents categorical data with rectangular bars with heights or lengths proportional to the values that they represent.
        /// </summary>
        /// <param name="values">Sets the values that are plotted as the size of each bar.</param>
        /// <param name="Keys">Sets the keys associated with each bar.</param>
        /// <param name="MultiKeys">Sets the keys associated with each bar. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="MultiOpacity">Sets the Opacity of each individual bar.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="MarkerColor">Sets the color of the bars</param>
        /// <param name="MarkerColorScale">Sets the colorscale for the bars. To have an effect, `MarkerColor` must map to color scale values.</param>
        /// <param name="MarkerOutline">Sets the color of the bar outlines</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all bars</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each bar</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the bars (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units) of all bars.</param>
        /// <param name="MultiWidth">Sets the individual bar width (in position axis units) for each bar.</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Bar
            (
                values: seq<#IConvertible>,
                ?Keys: seq<#IConvertible>,
                ?MultiKeys: seq<seq<#IConvertible>>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?Base: #IConvertible,
                ?Width: #IConvertible,
                ?MultiWidth: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let pattern =
                MarkerPattern
                |> Option.defaultValue (TraceObjects.Pattern.init ())
                |> TraceObjects.Pattern.style (?Shape = MarkerPatternShape, ?MultiShape = MultiMarkerPatternShape)

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (
                    ?Color = MarkerColor,
                    Pattern = pattern,
                    ?MultiOpacity = MultiOpacity,
                    ?Colorscale = MarkerColorScale,
                    ?Outline = MarkerOutline
                )


            Trace2D.initBar (
                Trace2DStyle.Bar(
                    X = values,
                    ?Y = Keys,
                    ?MultiY = MultiKeys,
                    Orientation = StyleParam.Orientation.Horizontal,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?Base = Base,
                    ?Width = Width,
                    ?MultiWidth = MultiWidth,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    Marker = marker
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a bar chart, with bars plotted horizontally
        ///
        /// A bar chart is a chart that presents categorical data with rectangular bars with heights or lengths proportional to the values that they represent.
        /// </summary>
        /// <param name="keysValues">Sets the (key,value) pairs that are plotted as the size and key of each bar.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="MultiOpacity">Sets the Opacity of each individual bar.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="MarkerColor">Sets the color of the bars</param>
        /// <param name="MarkerColorScale">Sets the colorscale for the bars. To have an effect, `MarkerColor` must map to color scale values.</param>
        /// <param name="MarkerOutline">Sets the color of the bar outlines</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all bars</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each bar</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the bars (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units) of all bars.</param>
        /// <param name="MultiWidth">Sets the individual bar width (in position axis units) for each bar.</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Bar
            (
                keysValues: seq<#IConvertible * #IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?Base: #IConvertible,
                ?Width: #IConvertible,
                ?MultiWidth: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?UseDefaults: bool
            ) =

            let keys, values = Seq.unzip keysValues

            Chart.Bar(
                values = values,
                Keys = keys,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerPatternShape = MarkerPatternShape,
                ?MultiMarkerPatternShape = MultiMarkerPatternShape,
                ?MarkerPattern = MarkerPattern,
                ?Marker = Marker,
                ?Base = Base,
                ?Width = Width,
                ?MultiWidth = MultiWidth,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?UseDefaults = UseDefaults
            )


        /// <summary>
        /// Creates a stacked bar chart, with bars plotted horizontally. Values with the same key are stacked on top of each other in the X dimension.
        /// To create this type of chart, combine multiple of these charts via `Chart.combine`.
        ///
        /// A bar chart is a chart that presents categorical data with rectangular bars with heights or lengths proportional to the values that they represent.
        /// </summary>
        /// <param name="values">Sets the values that are plotted as the size of each bar.</param>
        /// <param name="Keys">Sets the keys associated with each bar.</param>
        /// <param name="MultiKeys">Sets the keys associated with each bar. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="MultiOpacity">Sets the Opacity of each individual bar.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="MarkerColor">Sets the color of the bars</param>
        /// <param name="MarkerColorScale">Sets the colorscale for the bars. To have an effect, `MarkerColor` must map to color scale values.</param>
        /// <param name="MarkerOutline">Sets the color of the bar outlines</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all bars</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each bar</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the bars (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units) of all bars.</param>
        /// <param name="MultiWidth">Sets the individual bar width (in position axis units) for each bar.</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member StackedBar
            (
                values: seq<#IConvertible>,
                ?Keys: seq<#IConvertible>,
                ?MultiKeys: seq<seq<#IConvertible>>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?Base: #IConvertible,
                ?Width: #IConvertible,
                ?MultiWidth: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?UseDefaults: bool
            ) =

            Chart.Bar(
                values = values,
                ?Keys = Keys,
                ?MultiKeys = MultiKeys,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerPatternShape = MarkerPatternShape,
                ?MultiMarkerPatternShape = MultiMarkerPatternShape,
                ?MarkerPattern = MarkerPattern,
                ?Marker = Marker,
                ?Base = Base,
                ?Width = Width,
                ?MultiWidth = MultiWidth,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?UseDefaults = UseDefaults
            )
            |> GenericChart.mapLayout (Layout.style (BarMode = StyleParam.BarMode.Stack))


        /// <summary>
        /// Creates a stacked bar chart, with bars plotted horizontally. Values with the same key are stacked on top of each other in the X dimension.
        /// To create this type of chart, combine multiple of these charts via `Chart.combine`.
        ///
        /// A bar chart is a chart that presents categorical data with rectangular bars with heights or lengths proportional to the values that they represent.
        /// </summary>
        /// <param name="keysValues">Sets the (key,value) pairs that are plotted as the size and key of each bar.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="MultiOpacity">Sets the Opacity of each individual bar.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="MarkerColor">Sets the color of the bars</param>
        /// <param name="MarkerColorScale">Sets the colorscale for the bars. To have an effect, `MarkerColor` must map to color scale values.</param>
        /// <param name="MarkerOutline">Sets the color of the bar outlines</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all bars</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each bar</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the bars (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units) of all bars.</param>
        /// <param name="MultiWidth">Sets the individual bar width (in position axis units) for each bar.</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member StackedBar
            (
                keysValues: seq<#IConvertible * #IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?Base: #IConvertible,
                ?Width: #IConvertible,
                ?MultiWidth: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?UseDefaults: bool
            ) =

            let keys, values = Seq.unzip keysValues

            Chart.StackedBar(
                values = values,
                Keys = keys,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerPatternShape = MarkerPatternShape,
                ?MultiMarkerPatternShape = MultiMarkerPatternShape,
                ?MarkerPattern = MarkerPattern,
                ?Marker = Marker,
                ?Base = Base,
                ?Width = Width,
                ?MultiWidth = MultiWidth,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a column chart, with bars plotted vertically
        ///
        /// A column chart is a chart that presents categorical data with rectangular bars with heights or lengths proportional to the values that they represent.
        /// </summary>
        /// <param name="values">Sets the values that are plotted as the size of each bar.</param>
        /// <param name="Keys">Sets the keys associated with each bar.</param>
        /// <param name="MultiKeys">Sets the keys associated with each bar. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="MultiOpacity">Sets the Opacity of each individual bar.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="MarkerColor">Sets the color of the bars</param>
        /// <param name="MarkerColorScale">Sets the colorscale for the bars. To have an effect, `MarkerColor` must map to color scale values.</param>
        /// <param name="MarkerOutline">Sets the color of the bar outlines</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all bars</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each bar</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the bars (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units) of all bars.</param>
        /// <param name="MultiWidth">Sets the individual bar width (in position axis units) for each bar.</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Column
            (
                values: seq<#IConvertible>,
                ?Keys: seq<#IConvertible>,
                ?MultiKeys: seq<seq<#IConvertible>>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?Base: #IConvertible,
                ?Width: #IConvertible,
                ?MultiWidth: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let pattern =
                MarkerPattern
                |> Option.defaultValue (TraceObjects.Pattern.init ())
                |> TraceObjects.Pattern.style (?Shape = MarkerPatternShape, ?MultiShape = MultiMarkerPatternShape)

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (
                    ?Color = MarkerColor,
                    Pattern = pattern,
                    ?MultiOpacity = MultiOpacity,
                    ?Colorscale = MarkerColorScale,
                    ?Outline = MarkerOutline
                )


            Trace2D.initBar (
                Trace2DStyle.Bar(
                    Y = values,
                    ?X = Keys,
                    ?MultiX = MultiKeys,
                    Orientation = StyleParam.Orientation.Vertical,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?Base = Base,
                    ?Width = Width,
                    ?MultiWidth = MultiWidth,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    Marker = marker
                )
            )
            |> GenericChart.ofTraceObject useDefaults


        /// <summary>
        /// Creates a column chart, with bars plotted vertically
        ///
        /// A column chart is a chart that presents categorical data with rectangular bars with heights or lengths proportional to the values that they represent.
        /// </summary>
        /// <param name="keysValues">Sets the (key,value) pairs that are plotted as the size and key of each bar.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="MultiOpacity">Sets the Opacity of each individual bar.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="MarkerColor">Sets the color of the bars</param>
        /// <param name="MarkerColorScale">Sets the colorscale for the bars. To have an effect, `MarkerColor` must map to color scale values.</param>
        /// <param name="MarkerOutline">Sets the color of the bar outlines</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all bars</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each bar</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the bars (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units) of all bars.</param>
        /// <param name="MultiWidth">Sets the individual bar width (in position axis units) for each bar.</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Column
            (
                keysValues: seq<#IConvertible * #IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?Base: #IConvertible,
                ?Width: #IConvertible,
                ?MultiWidth: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?UseDefaults: bool
            ) =

            let keys, values = Seq.unzip keysValues

            Chart.Column(
                values = values,
                Keys = keys,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerPatternShape = MarkerPatternShape,
                ?MultiMarkerPatternShape = MultiMarkerPatternShape,
                ?MarkerPattern = MarkerPattern,
                ?Marker = Marker,
                ?Base = Base,
                ?Width = Width,
                ?MultiWidth = MultiWidth,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?UseDefaults = UseDefaults
            )


        /// <summary>
        /// Creates a stacked column chart, with bars plotted vertically. Values with the same key are stacked on top of each other in the Y dimension.
        /// To create this type of chart, combine multiple of these charts via `Chart.combine`.
        ///
        /// A bar chart is a chart that presents categorical data with rectangular bars with heights or lengths proportional to the values that they represent.
        /// </summary>
        /// <param name="values">Sets the values that are plotted as the size of each bar.</param>
        /// <param name="Keys">Sets the keys associated with each bar.</param>
        /// <param name="MultiKeys">Sets the keys associated with each bar. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="MultiOpacity">Sets the Opacity of each individual bar.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="MarkerColor">Sets the color of the bars</param>
        /// <param name="MarkerColorScale">Sets the colorscale for the bars. To have an effect, `MarkerColor` must map to color scale values.</param>
        /// <param name="MarkerOutline">Sets the color of the bar outlines</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all bars</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each bar</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the bars (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units) of all bars.</param>
        /// <param name="MultiWidth">Sets the individual bar width (in position axis units) for each bar.</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member StackedColumn
            (
                values: seq<#IConvertible>,
                ?Keys: seq<#IConvertible>,
                ?MultiKeys: seq<seq<#IConvertible>>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?Base: #IConvertible,
                ?Width: #IConvertible,
                ?MultiWidth: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?UseDefaults: bool
            ) =

            Chart.Column(
                values = values,
                ?Keys = Keys,
                ?MultiKeys = MultiKeys,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerPatternShape = MarkerPatternShape,
                ?MultiMarkerPatternShape = MultiMarkerPatternShape,
                ?MarkerPattern = MarkerPattern,
                ?Marker = Marker,
                ?Base = Base,
                ?Width = Width,
                ?MultiWidth = MultiWidth,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?UseDefaults = UseDefaults
            )
            |> GenericChart.mapLayout (Layout.style (BarMode = StyleParam.BarMode.Stack))


        /// <summary>
        /// Creates a stacked column chart, with bars plotted vertically. Values with the same key are stacked on top of each other in the Y dimension.
        /// To create this type of chart, combine multiple of these charts via `Chart.combine`.
        ///
        /// A bar chart is a chart that presents categorical data with rectangular bars with heights or lengths proportional to the values that they represent.
        /// </summary>
        /// <param name="keysValues">Sets the (key,value) pairs that are plotted as the size and key of each bar.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="MultiOpacity">Sets the Opacity of each individual bar.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="MarkerColor">Sets the color of the bars</param>
        /// <param name="MarkerColorScale">Sets the colorscale for the bars. To have an effect, `MarkerColor` must map to color scale values.</param>
        /// <param name="MarkerOutline">Sets the color of the bar outlines</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all bars</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each bar</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the bars (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units) of all bars.</param>
        /// <param name="MultiWidth">Sets the individual bar width (in position axis units) for each bar.</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member StackedColumn
            (
                keysValues: seq<#IConvertible * #IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?Base: #IConvertible,
                ?Width: #IConvertible,
                ?MultiWidth: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?UseDefaults: bool
            ) =

            let keys, values = Seq.unzip keysValues

            Chart.StackedColumn(
                values = values,
                Keys = keys,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerPatternShape = MarkerPatternShape,
                ?MultiMarkerPatternShape = MultiMarkerPatternShape,
                ?MarkerPattern = MarkerPattern,
                ?Marker = Marker,
                ?Base = Base,
                ?Width = Width,
                ?MultiWidth = MultiWidth,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?UseDefaults = UseDefaults
            )


        /// <summary>
        /// Visualizes the distribution of the input data as a histogram.
        ///
        /// A histogram is an approximate representation of the distribution of numerical data. To construct a histogram, the first step is to "bin"  the range of values - that is, divide the entire range of values into a series of intervals - and then count how many values fall into each interval.
        /// The bins are usually specified as consecutive, non-overlapping intervals of a variable.
        ///
        /// The sample data from which statistics are computed is set in `x` for vertically spanning histograms and in `y` for horizontally spanning histograms. Binning options are set `xbins` and `ybins` respectively if no aggregation data is provided.
        /// </summary>
        /// <param name="X">Sets the sample data to be binned on the x axis.</param>
        /// <param name="MultiX">Sets the sample data to be binned on the x axis. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Y">Sets the sample data to be binned on the y axis.</param>
        /// <param name="MultiY">Sets the sample data to be binned on the y axis. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Orientation">Sets the orientation of the bars. With "v" ("h"), the value of the each bar spans along the vertical (horizontal).</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="HistFunc">Specifies the binning function used for this histogram trace. If "count", the histogram values are computed by counting the number of values lying inside each bin. If "sum", "avg", "min", "max", the histogram values are computed using the sum, the average, the minimum or the maximum of the values lying inside each bin respectively.</param>
        /// <param name="HistNorm">Specifies the type of normalization used for this histogram trace. If "", the span of each bar corresponds to the number of occurrences (i.e. the number of data points lying inside the bins). If "percent" / "probability", the span of each bar corresponds to the percentage / fraction of occurrences with respect to the total number of sample points (here, the sum of all bin HEIGHTS equals 100% / 1). If "density", the span of each bar corresponds to the number of occurrences in a bin divided by the size of the bin interval (here, the sum of all bin AREAS equals the total number of sample points). If "probability density", the area of each bar corresponds to the probability that an event will fall into the corresponding bin (here, the sum of all bin AREAS equals 1).</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="NBinsX">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `xbins.size` is provided.</param>
        /// <param name="NBinsY">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `ybins.size` is provided.</param>
        /// <param name="BinGroup">Set a group of histogram traces which will have compatible bin settings. Note that traces on the same subplot and with the same "orientation" under `barmode` "stack", "relative" and "group" are forced into the same bingroup, Using `bingroup`, traces under `barmode` "overlay" and on different axes (of the same axis type) can have compatible bin settings. Note that histogram and histogram2d" trace can share the same `bingroup`</param>
        /// <param name="XBins">Sets the binning across the x dimension</param>
        /// <param name="YBins">Sets the binning across the y dimension</param>
        /// <param name="MarkerColor">Sets the color of the bars</param>
        /// <param name="MarkerColorScale">Sets the colorscale for the bars. To have an effect, `MarkerColor` must map to color scale values.</param>
        /// <param name="MarkerOutline">Sets the color of the bar outlines</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all bars</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each bar</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker of this trace.</param>
        /// <param name="Line">Sets the outline of the histogram's bars.</param>
        /// <param name="XError">Sets the x error of this trace.</param>
        /// <param name="YError">Sets the y error of this trace.</param>
        /// <param name="Cumulative">Sets whether and how the cumulative distribution is displayed</param>
        /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Histogram
            (
                ?X: seq<#IConvertible>,
                ?MultiX: seq<seq<#IConvertible>>,
                ?Y: seq<#IConvertible>,
                ?MultiY: seq<seq<#IConvertible>>,
                ?Orientation: StyleParam.Orientation,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?HistFunc: StyleParam.HistFunc,
                ?HistNorm: StyleParam.HistNorm,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?NBinsX: int,
                ?NBinsY: int,
                ?BinGroup: string,
                ?XBins: Bins,
                ?YBins: Bins,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?Line: Line,
                ?XError: Error,
                ?YError: Error,
                ?Cumulative: Cumulative,
                ?HoverLabel: Hoverlabel,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let pattern =
                MarkerPattern
                |> Option.defaultValue (TraceObjects.Pattern.init ())
                |> TraceObjects.Pattern.style (?Shape = MarkerPatternShape, ?MultiShape = MultiMarkerPatternShape)

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (
                    ?Color = MarkerColor,
                    Pattern = pattern,
                    ?Colorscale = MarkerColorScale,
                    ?Outline = MarkerOutline
                )

            Trace2D.initHistogram (
                Trace2DStyle.Histogram(
                    ?X = X,
                    ?MultiX = MultiX,
                    ?Y = Y,
                    ?MultiY = MultiY,
                    ?Orientation = Orientation,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?HistFunc = HistFunc,
                    ?HistNorm = HistNorm,
                    ?AlignmentGroup = AlignmentGroup,
                    ?OffsetGroup = OffsetGroup,
                    ?NBinsX = NBinsX,
                    ?NBinsY = NBinsY,
                    ?BinGroup = BinGroup,
                    ?XBins = XBins,
                    ?YBins = YBins,
                    Marker = marker,
                    ?Line = Line,
                    ?XError = XError,
                    ?YError = YError,
                    ?Cumulative = Cumulative,
                    ?HoverLabel = HoverLabel
                )
            )
            |> GenericChart.ofTraceObject useDefaults


        /// <summary>
        /// Visualizes the distribution of the input data as a histogram, automatically determining if the data is to be used for the x or y dimension based on the `orientation` parameter.
        ///
        /// A histogram is an approximate representation of the distribution of numerical data. To construct a histogram, the first step is to "bin"  the range of values - that is, divide the entire range of values into a series of intervals - and then count how many values fall into each interval.
        /// The bins are usually specified as consecutive, non-overlapping intervals of a variable.
        ///
        /// Binning options are set `xbins` and `ybins` respectively if no aggregation data is provided.
        /// </summary>
        /// <param name="data">Sets the sample data to be binned</param>
        /// <param name="orientation">Sets the orientation of the bars. With "v" ("h"), the value of the each bar spans along the vertical (horizontal).</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="HistFunc">Specifies the binning function used for this histogram trace. If "count", the histogram values are computed by counting the number of values lying inside each bin. If "sum", "avg", "min", "max", the histogram values are computed using the sum, the average, the minimum or the maximum of the values lying inside each bin respectively.</param>
        /// <param name="HistNorm">Specifies the type of normalization used for this histogram trace. If "", the span of each bar corresponds to the number of occurrences (i.e. the number of data points lying inside the bins). If "percent" / "probability", the span of each bar corresponds to the percentage / fraction of occurrences with respect to the total number of sample points (here, the sum of all bin HEIGHTS equals 100% / 1). If "density", the span of each bar corresponds to the number of occurrences in a bin divided by the size of the bin interval (here, the sum of all bin AREAS equals the total number of sample points). If "probability density", the area of each bar corresponds to the probability that an event will fall into the corresponding bin (here, the sum of all bin AREAS equals 1).</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="NBinsX">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `xbins.size` is provided.</param>
        /// <param name="NBinsY">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `ybins.size` is provided.</param>
        /// <param name="BinGroup">Set a group of histogram traces which will have compatible bin settings. Note that traces on the same subplot and with the same "orientation" under `barmode` "stack", "relative" and "group" are forced into the same bingroup, Using `bingroup`, traces under `barmode` "overlay" and on different axes (of the same axis type) can have compatible bin settings. Note that histogram and histogram2d" trace can share the same `bingroup`</param>
        /// <param name="XBins">Sets the binning across the x dimension</param>
        /// <param name="YBins">Sets the binning across the y dimension</param>
        /// <param name="MarkerColor">Sets the color of the histogram's bars.</param>
        /// <param name="Marker">Sets the marker for the histogram's bars (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="Line">Sets the outline of the histogram's bars.</param>
        /// <param name="XError">Sets the x error of this trace.</param>
        /// <param name="YError">Sets the y error of this trace.</param>
        /// <param name="Cumulative">Sets whether and how the cumulative distribution is displayed</param>
        /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Histogram
            (
                data: seq<#IConvertible>,
                orientation: StyleParam.Orientation,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?HistFunc: StyleParam.HistFunc,
                ?HistNorm: StyleParam.HistNorm,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?NBinsX: int,
                ?NBinsY: int,
                ?BinGroup: string,
                ?XBins: Bins,
                ?YBins: Bins,
                ?MarkerColor: Color,
                ?Marker: Marker,
                ?Line: Line,
                ?XError: Error,
                ?YError: Error,
                ?Cumulative: Cumulative,
                ?HoverLabel: Hoverlabel,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let histChart =
                Trace2D.initHistogram (
                    Trace2DStyle.Histogram(
                        ?Opacity = Opacity,
                        ?Text = Text,
                        ?MultiText = MultiText,
                        Orientation = orientation,
                        ?HistFunc = HistFunc,
                        ?HistNorm = HistNorm,
                        ?AlignmentGroup = AlignmentGroup,
                        ?OffsetGroup = OffsetGroup,
                        ?NBinsX = NBinsX,
                        ?NBinsY = NBinsY,
                        ?BinGroup = BinGroup,
                        ?XBins = XBins,
                        ?YBins = YBins,
                        ?Marker = Marker,
                        ?Line = Line,
                        ?XError = XError,
                        ?YError = YError,
                        ?Cumulative = Cumulative,
                        ?HoverLabel = HoverLabel
                    )
                )
                |> TraceStyle.Marker(?Color = MarkerColor)
                |> TraceStyle.TraceInfo(?Name = Name, ?ShowLegend = ShowLegend)
                |> GenericChart.ofTraceObject useDefaults

            match orientation with
            | StyleParam.Orientation.Horizontal -> histChart |> GenericChart.mapTrace (Trace2DStyle.Histogram(Y = data))
            | StyleParam.Orientation.Vertical -> histChart |> GenericChart.mapTrace (Trace2DStyle.Histogram(X = data))

        /// <summary>
        /// Visualizes the distribution of the 2-dimensional input data as 2D Histogram.
        ///
        ///The sample data from which statistics are computed is set in `x` and `y` (where `x` and `y` represent marginal distributions, binning is set in `xbins` and `ybins` in this case) or `z` (where `z` represent the 2D distribution and binning set, binning is set by `x` and `y` in this case). The resulting distribution is visualized as a heatmap.
        /// </summary>
        /// <param name="X">Sets the sample data to be binned on the x axis.</param>
        /// <param name="MultiX">Sets the sample data to be binned on the x axis. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Y">Sets the sample data to be binned on the y axis.</param>
        /// <param name="MultiY">Sets the sample data to be binned on the y axis. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Z">Sets the aggregation data.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="XGap">Sets the horizontal gap (in pixels) between bricks.</param>
        /// <param name="YGap">Sets the vertical gap (in pixels) between bricks.</param>
        /// <param name="HistFunc">Specifies the binning function used for this histogram trace. If "count", the histogram values are computed by counting the number of values lying inside each bin. If "sum", "avg", "min", "max", the histogram values are computed using the sum, the average, the minimum or the maximum of the values lying inside each bin respectively.</param>
        /// <param name="HistNorm">Specifies the type of normalization used for this histogram trace. If "", the span of each bar corresponds to the number of occurrences (i.e. the number of data points lying inside the bins). If "percent" / "probability", the span of each bar corresponds to the percentage / fraction of occurrences with respect to the total number of sample points (here, the sum of all bin HEIGHTS equals 100% / 1). If "density", the span of each bar corresponds to the number of occurrences in a bin divided by the size of the bin interval (here, the sum of all bin AREAS equals the total number of sample points). If "probability density", the area of each bar corresponds to the probability that an event will fall into the corresponding bin (here, the sum of all bin AREAS equals 1).</param>
        /// <param name="NBinsX">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `xbins.size` is provided.</param>
        /// <param name="NBinsY">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `ybins.size` is provided.</param>
        /// <param name="XBins">Sets the binning across the x dimension</param>
        /// <param name="YBins">Sets the binning across the y dimension</param>
        /// <param name="ColorBar">Sets the styles of the colorbar for this trace.</param>
        /// <param name="ColorScale">Sets the colorscale for this trace.</param>
        /// <param name="ShowScale">Whether or not to show the colorscale/colorbar</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
        /// <param name="ZSmooth">Picks a smoothing algorithm use to smooth `z` data.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Histogram2D
            (
                ?X: seq<#IConvertible>,
                ?MultiX: seq<seq<#IConvertible>>,
                ?Y: seq<#IConvertible>,
                ?MultiY: seq<seq<#IConvertible>>,
                ?Z: seq<#seq<#IConvertible>>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?XGap: int,
                ?YGap: int,
                ?HistFunc: StyleParam.HistFunc,
                ?HistNorm: StyleParam.HistNorm,
                ?NBinsX: int,
                ?NBinsY: int,
                ?XBins: Bins,
                ?YBins: Bins,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ReverseScale: bool,
                ?ZSmooth: StyleParam.SmoothAlg,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            Trace2D.initHistogram2D (
                Trace2DStyle.Histogram2D(
                    ?X = X,
                    ?MultiX = MultiX,
                    ?Y = Y,
                    ?MultiY = MultiY,
                    ?Z = Z,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?XGap = XGap,
                    ?YGap = YGap,
                    ?HistFunc = HistFunc,
                    ?HistNorm = HistNorm,
                    ?NBinsX = NBinsX,
                    ?NBinsY = NBinsY,
                    ?XBins = XBins,
                    ?YBins = YBins,
                    ?ColorBar = ColorBar,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ReverseScale = ReverseScale,
                    ?ZSmooth = ZSmooth
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Visualizes the distribution of the 2-dimensional input data as 2D Histogram.
        ///
        ///The sample data from which statistics are computed is set in `x` and `y` (where `x` and `y` represent marginal distributions, binning is set in `xbins` and `ybins` in this case) or `z` (where `z` represent the 2D distribution and binning set, binning is set by `x` and `y` in this case). The resulting distribution is visualized as a heatmap.
        /// </summary>
        /// <param name="x">Sets the sample data to be binned on the x axis.</param>
        /// <param name="y">Sets the sample data to be binned on the y axis.</param>
        /// <param name="Z">Sets the aggregation data.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="XGap">Sets the horizontal gap (in pixels) between bricks.</param>
        /// <param name="YGap">Sets the vertical gap (in pixels) between bricks.</param>
        /// <param name="HistFunc">Specifies the binning function used for this histogram trace. If "count", the histogram values are computed by counting the number of values lying inside each bin. If "sum", "avg", "min", "max", the histogram values are computed using the sum, the average, the minimum or the maximum of the values lying inside each bin respectively.</param>
        /// <param name="HistNorm">Specifies the type of normalization used for this histogram trace. If "", the span of each bar corresponds to the number of occurrences (i.e. the number of data points lying inside the bins). If "percent" / "probability", the span of each bar corresponds to the percentage / fraction of occurrences with respect to the total number of sample points (here, the sum of all bin HEIGHTS equals 100% / 1). If "density", the span of each bar corresponds to the number of occurrences in a bin divided by the size of the bin interval (here, the sum of all bin AREAS equals the total number of sample points). If "probability density", the area of each bar corresponds to the probability that an event will fall into the corresponding bin (here, the sum of all bin AREAS equals 1).</param>
        /// <param name="NBinsX">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `xbins.size` is provided.</param>
        /// <param name="NBinsY">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `ybins.size` is provided.</param>
        /// <param name="XBins">Sets the binning across the x dimension</param>
        /// <param name="YBins">Sets the binning across the y dimension</param>
        /// <param name="ColorBar">Sets the styles of the colorbar for this trace.</param>
        /// <param name="ColorScale">Sets the colorscale for this trace.</param>
        /// <param name="ShowScale">Whether or not to show the colorscale/colorbar</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
        /// <param name="ZSmooth">Picks a smoothing algorithm use to smooth `z` data.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Histogram2D
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                ?Z: seq<#seq<#IConvertible>>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?XGap: int,
                ?YGap: int,
                ?HistFunc: StyleParam.HistFunc,
                ?HistNorm: StyleParam.HistNorm,
                ?NBinsX: int,
                ?NBinsY: int,
                ?XBins: Bins,
                ?YBins: Bins,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ReverseScale: bool,
                ?ZSmooth: StyleParam.SmoothAlg,
                ?UseDefaults: bool
            ) =

            Chart.Histogram2D(
                X = x,
                Y = y,
                ?Z = Z,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?XGap = XGap,
                ?YGap = YGap,
                ?HistFunc = HistFunc,
                ?HistNorm = HistNorm,
                ?NBinsX = NBinsX,
                ?NBinsY = NBinsY,
                ?XBins = XBins,
                ?YBins = YBins,
                ?ColorBar = ColorBar,
                ?ColorScale = ColorScale,
                ?ShowScale = ShowScale,
                ?ReverseScale = ReverseScale,
                ?ZSmooth = ZSmooth,
                ?UseDefaults = UseDefaults
            )


        /// <summary>
        /// Visualizes the distribution of the input data as a box plot.
        ///
        /// A box plot is a method for graphically demonstrating the locality, spread and skewness groups of numerical data through their quartiles.
        /// The default style is based on the five number summary: minimum, first quartile, median, third quartile, and maximum.
        ///
        /// The sample data from which statistics are computed is set in `x` for vertically spanning boxes and in `y` for horizontally spanning boxes.
        /// </summary>
        /// <param name="X">Sets the x sample data or coordinates</param>
        /// <param name="MultiX">Sets the x sample data or coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Y">Sets the y sample data or coordinates</param>
        /// <param name="MultiY">Sets the y sample data or coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="MarkerColor">Sets the marker color.</param>
        /// <param name="Marker">Sets the marker for the box (use this for more finegrained control than the other marker-associated arguments).</param>// <param name="Opacity">Sets the opacity of this trace.</param>
        /// <param name="WhiskerWidth">Sets the width of the whiskers relative to the box' width. For example, with 1, the whiskers are as wide as the box(es).</param>
        /// <param name="BoxPoints">If "outliers", only the sample points lying outside the whiskers are shown If "suspectedoutliers", the outlier points are shown and points either less than 4"Q1-3"Q3 or greater than 4"Q3-3"Q1 are highlighted (see `outliercolor`) If "all", all sample points are shown If "false", only the box(es) are shown with no sample points Defaults to "suspectedoutliers" when `marker.outliercolor` or `marker.line.outliercolor` is set. Defaults to "all" under the q1/median/q3 signature. Otherwise defaults to "outliers".</param>
        /// <param name="BoxMean">If "true", the mean of the box(es)' underlying distribution is drawn as a dashed line inside the box(es). If "sd" the standard deviation is also drawn. Defaults to "true" when `mean` is set. Defaults to "sd" when `sd` is set Otherwise defaults to "false".</param>
        /// <param name="Jitter">Sets the amount of jitter in the sample points drawn. If "0", the sample points align along the distribution axis. If "1", the sample points are drawn in a random jitter of width equal to the width of the box(es).</param>
        /// <param name="PointPos">Sets the position of the sample points in relation to the box(es). If "0", the sample points are places over the center of the box(es). Positive (negative) values correspond to positions to the right (left) for vertical boxes and above (below) for horizontal boxes</param>
        /// <param name="Orientation">Sets the orientation of the box(es). If "v" ("h"), the distribution is visualized along the vertical (horizontal).</param>
        /// <param name="OutlineColor">Sets the color of the box outline</param>
        /// <param name="OutlineWidth">Sets the width of the box outline</param>
        /// <param name="Outline">Sets the box outline (use this for more finegrained control than the other outline-associated arguments).</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="Notched">Determines whether or not notches are drawn. Notches displays a confidence interval around the median. We compute the confidence interval as median +/- 1.57 " IQR / sqrt(N), where IQR is the interquartile range and N is the sample size. If two boxes' notches do not overlap there is 95% confidence their medians differ. See https://sites.google.com/site/davidsstatistics/home/notched-box-plots for more info. Defaults to "false" unless `notchwidth` or `notchspan` is set.</param>
        /// <param name="NotchWidth">Sets the width of the notches relative to the box' width. For example, with 0, the notches are as wide as the box(es).</param>
        /// <param name="QuartileMethod">Sets the method used to compute the sample's Q1 and Q3 quartiles. The "linear" method uses the 25th percentile for Q1 and 75th percentile for Q3 as computed using method #10 (listed on http://www.amstat.org/publications/jse/v14n3/langford.html). The "exclusive" method uses the median to divide the ordered dataset into two halves if the sample is odd, it does not include the median in either half - Q1 is then the median of the lower half and Q3 the median of the upper half. The "inclusive" method also uses the median to divide the ordered dataset into two halves but if the sample is odd, it includes the median in both halves - Q1 is then the median of the lower half and Q3 the median of the upper half.</param>
        /// <param name="SizeMode">Sets the upper and lower bound for the boxes quartiles means box is drawn between Q1 and Q3 SD means the box is drawn between Mean +- Standard Deviation Argument sdmultiple (default 1) to scale the box size So it could be drawn 1-stddev, 3-stddev etc</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member BoxPlot
            (
                ?X: seq<#IConvertible>,
                ?MultiX: seq<seq<#IConvertible>>,
                ?Y: seq<#IConvertible>,
                ?MultiY: seq<seq<#IConvertible>>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?FillColor: Color,
                ?MarkerColor: Color,
                ?Marker: Marker,
                ?Opacity: float,
                ?WhiskerWidth: float,
                ?BoxPoints: StyleParam.BoxPoints,
                ?BoxMean: StyleParam.BoxMean,
                ?Jitter: float,
                ?PointPos: float,
                ?Orientation: StyleParam.Orientation,
                ?OutlineColor: Color,
                ?OutlineWidth: float,
                ?Outline: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?Notched: bool,
                ?NotchWidth: float,
                ?QuartileMethod: StyleParam.QuartileMethod,
                ?SizeMode: StyleParam.BoxSizeMode,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let outline =
                Outline
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (?Color = OutlineColor, ?Width = OutlineWidth)

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (?Color = MarkerColor)


            Trace2D.initBoxPlot (
                Trace2DStyle.BoxPlot(
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?X = X,
                    ?MultiX = MultiX,
                    ?Y = Y,
                    ?MultiY = MultiY,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?WhiskerWidth = WhiskerWidth,
                    ?BoxPoints = BoxPoints,
                    ?BoxMean = BoxMean,
                    ?Jitter = Jitter,
                    ?PointPos = PointPos,
                    ?Orientation = Orientation,
                    ?FillColor = FillColor,
                    Marker = marker,
                    Line = outline,
                    ?AlignmentGroup = AlignmentGroup,
                    ?OffsetGroup = OffsetGroup,
                    ?Notched = Notched,
                    ?NotchWidth = NotchWidth,
                    ?QuartileMethod = QuartileMethod,
                    ?SizeMode = SizeMode
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Visualizes the distribution of the input data as a box plot.
        ///
        /// A box plot is a method for graphically demonstrating the locality, spread and skewness groups of numerical data through their quartiles.
        /// The default style is based on the five number summary: minimum, first quartile, median, third quartile, and maximum.
        ///
        /// The sample data from which statistics are computed is set in `x` for vertically spanning boxes and in `y` for horizontally spanning boxes.
        /// </summary>
        /// <param name="data">Sets the sample data or coordinates</param>
        /// <param name="orientation">Sets the orientation of the box.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="MarkerColor">Sets the marker color.</param>
        /// <param name="Marker">Sets the marker for the box (use this for more finegrained control than the other marker-associated arguments).</param>// <param name="Opacity">Sets the opacity of this trace.</param>
        /// <param name="WhiskerWidth">Sets the width of the whiskers relative to the box' width. For example, with 1, the whiskers are as wide as the box(es).</param>
        /// <param name="BoxPoints">If "outliers", only the sample points lying outside the whiskers are shown If "suspectedoutliers", the outlier points are shown and points either less than 4"Q1-3"Q3 or greater than 4"Q3-3"Q1 are highlighted (see `outliercolor`) If "all", all sample points are shown If "false", only the box(es) are shown with no sample points Defaults to "suspectedoutliers" when `marker.outliercolor` or `marker.line.outliercolor` is set. Defaults to "all" under the q1/median/q3 signature. Otherwise defaults to "outliers".</param>
        /// <param name="BoxMean">If "true", the mean of the box(es)' underlying distribution is drawn as a dashed line inside the box(es). If "sd" the standard deviation is also drawn. Defaults to "true" when `mean` is set. Defaults to "sd" when `sd` is set Otherwise defaults to "false".</param>
        /// <param name="Jitter">Sets the amount of jitter in the sample points drawn. If "0", the sample points align along the distribution axis. If "1", the sample points are drawn in a random jitter of width equal to the width of the box(es).</param>
        /// <param name="PointPos">Sets the position of the sample points in relation to the box(es). If "0", the sample points are places over the center of the box(es). Positive (negative) values correspond to positions to the right (left) for vertical boxes and above (below) for horizontal boxes</param>
        /// <param name="OutlineColor">Sets the color of the box outline</param>
        /// <param name="OutlineWidth">Sets the width of the box outline</param>
        /// <param name="Outline">Sets the box outline (use this for more finegrained control than the other outline-associated arguments).</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="Notched">Determines whether or not notches are drawn. Notches displays a confidence interval around the median. We compute the confidence interval as median +/- 1.57 " IQR / sqrt(N), where IQR is the interquartile range and N is the sample size. If two boxes' notches do not overlap there is 95% confidence their medians differ. See https://sites.google.com/site/davidsstatistics/home/notched-box-plots for more info. Defaults to "false" unless `notchwidth` or `notchspan` is set.</param>
        /// <param name="NotchWidth">Sets the width of the notches relative to the box' width. For example, with 0, the notches are as wide as the box(es).</param>
        /// <param name="QuartileMethod">Sets the method used to compute the sample's Q1 and Q3 quartiles. The "linear" method uses the 25th percentile for Q1 and 75th percentile for Q3 as computed using method #10 (listed on http://www.amstat.org/publications/jse/v14n3/langford.html). The "exclusive" method uses the median to divide the ordered dataset into two halves if the sample is odd, it does not include the median in either half - Q1 is then the median of the lower half and Q3 the median of the upper half. The "inclusive" method also uses the median to divide the ordered dataset into two halves but if the sample is odd, it includes the median in both halves - Q1 is then the median of the lower half and Q3 the median of the upper half.</param>
        /// <param name="SizeMode">Sets the upper and lower bound for the boxes quartiles means box is drawn between Q1 and Q3 SD means the box is drawn between Mean +- Standard Deviation Argument sdmultiple (default 1) to scale the box size So it could be drawn 1-stddev, 3-stddev etc</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member BoxPlot
            (
                data: seq<#IConvertible>,
                orientation: StyleParam.Orientation,
                ?Name: string,
                ?ShowLegend: bool,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?FillColor: Color,
                ?MarkerColor: Color,
                ?Marker: Marker,
                ?Opacity: float,
                ?WhiskerWidth: float,
                ?BoxPoints: StyleParam.BoxPoints,
                ?BoxMean: StyleParam.BoxMean,
                ?Jitter: float,
                ?PointPos: float,
                ?OutlineColor: Color,
                ?OutlineWidth: float,
                ?Outline: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?Notched: bool,
                ?NotchWidth: float,
                ?QuartileMethod: StyleParam.QuartileMethod,
                ?SizeMode: StyleParam.BoxSizeMode,
                ?UseDefaults: bool
            ) =

            let boxplot =
                Chart.BoxPlot(
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?FillColor = FillColor,
                    ?MarkerColor = MarkerColor,
                    ?Marker = Marker,
                    ?Opacity = Opacity,
                    ?WhiskerWidth = WhiskerWidth,
                    ?BoxPoints = BoxPoints,
                    ?BoxMean = BoxMean,
                    ?Jitter = Jitter,
                    ?PointPos = PointPos,
                    ?OutlineColor = OutlineColor,
                    ?OutlineWidth = OutlineWidth,
                    ?Outline = Outline,
                    ?AlignmentGroup = AlignmentGroup,
                    ?OffsetGroup = OffsetGroup,
                    ?Notched = Notched,
                    ?NotchWidth = NotchWidth,
                    ?QuartileMethod = QuartileMethod,
                    ?SizeMode = SizeMode,
                    ?UseDefaults = UseDefaults
                )

            match orientation with
            | StyleParam.Orientation.Horizontal -> boxplot |> GenericChart.mapTrace (Trace2DStyle.BoxPlot(X = data))
            | StyleParam.Orientation.Vertical -> boxplot |> GenericChart.mapTrace (Trace2DStyle.BoxPlot(Y = data))


        /// <summary>
        /// Visualizes the distribution of the input data as a box plot.
        ///
        /// A box plot is a method for graphically demonstrating the locality, spread and skewness groups of numerical data through their quartiles.
        /// The default style is based on the five number summary: minimum, first quartile, median, third quartile, and maximum.
        ///
        /// The sample data from which statistics are computed is set in `x` for vertically spanning boxes and in `y` for horizontally spanning boxes.
        /// </summary>
        /// <param name="xy">Sets the xy sample data or coordinate pairs</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="MarkerColor">Sets the marker color.</param>
        /// <param name="Marker">Sets the marker for the box (use this for more finegrained control than the other marker-associated arguments).</param>// <param name="Opacity">Sets the opacity of this trace.</param>
        /// <param name="WhiskerWidth">Sets the width of the whiskers relative to the box' width. For example, with 1, the whiskers are as wide as the box(es).</param>
        /// <param name="BoxPoints">If "outliers", only the sample points lying outside the whiskers are shown If "suspectedoutliers", the outlier points are shown and points either less than 4"Q1-3"Q3 or greater than 4"Q3-3"Q1 are highlighted (see `outliercolor`) If "all", all sample points are shown If "false", only the box(es) are shown with no sample points Defaults to "suspectedoutliers" when `marker.outliercolor` or `marker.line.outliercolor` is set. Defaults to "all" under the q1/median/q3 signature. Otherwise defaults to "outliers".</param>
        /// <param name="BoxMean">If "true", the mean of the box(es)' underlying distribution is drawn as a dashed line inside the box(es). If "sd" the standard deviation is also drawn. Defaults to "true" when `mean` is set. Defaults to "sd" when `sd` is set Otherwise defaults to "false".</param>
        /// <param name="Jitter">Sets the amount of jitter in the sample points drawn. If "0", the sample points align along the distribution axis. If "1", the sample points are drawn in a random jitter of width equal to the width of the box(es).</param>
        /// <param name="PointPos">Sets the position of the sample points in relation to the box(es). If "0", the sample points are places over the center of the box(es). Positive (negative) values correspond to positions to the right (left) for vertical boxes and above (below) for horizontal boxes</param>
        /// <param name="Orientation">Sets the orientation of the box(es). If "v" ("h"), the distribution is visualized along the vertical (horizontal).</param>
        /// <param name="OutlineColor">Sets the color of the box outline</param>
        /// <param name="OutlineWidth">Sets the width of the box outline</param>
        /// <param name="Outline">Sets the box outline (use this for more finegrained control than the other outline-associated arguments).</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="Notched">Determines whether or not notches are drawn. Notches displays a confidence interval around the median. We compute the confidence interval as median +/- 1.57 " IQR / sqrt(N), where IQR is the interquartile range and N is the sample size. If two boxes' notches do not overlap there is 95% confidence their medians differ. See https://sites.google.com/site/davidsstatistics/home/notched-box-plots for more info. Defaults to "false" unless `notchwidth` or `notchspan` is set.</param>
        /// <param name="NotchWidth">Sets the width of the notches relative to the box' width. For example, with 0, the notches are as wide as the box(es).</param>
        /// <param name="QuartileMethod">Sets the method used to compute the sample's Q1 and Q3 quartiles. The "linear" method uses the 25th percentile for Q1 and 75th percentile for Q3 as computed using method #10 (listed on http://www.amstat.org/publications/jse/v14n3/langford.html). The "exclusive" method uses the median to divide the ordered dataset into two halves if the sample is odd, it does not include the median in either half - Q1 is then the median of the lower half and Q3 the median of the upper half. The "inclusive" method also uses the median to divide the ordered dataset into two halves but if the sample is odd, it includes the median in both halves - Q1 is then the median of the lower half and Q3 the median of the upper half.</param>
        /// <param name="SizeMode">Sets the upper and lower bound for the boxes quartiles means box is drawn between Q1 and Q3 SD means the box is drawn between Mean +- Standard Deviation Argument sdmultiple (default 1) to scale the box size So it could be drawn 1-stddev, 3-stddev etc</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member BoxPlot
            (
                xy: seq<#IConvertible * #IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?FillColor: Color,
                ?MarkerColor: Color,
                ?Marker: Marker,
                ?Opacity: float,
                ?WhiskerWidth: float,
                ?BoxPoints: StyleParam.BoxPoints,
                ?BoxMean: StyleParam.BoxMean,
                ?Jitter: float,
                ?PointPos: float,
                ?Orientation: StyleParam.Orientation,
                ?OutlineColor: Color,
                ?OutlineWidth: float,
                ?Outline: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?Notched: bool,
                ?NotchWidth: float,
                ?QuartileMethod: StyleParam.QuartileMethod,
                ?SizeMode: StyleParam.BoxSizeMode,
                ?UseDefaults: bool
            ) =

            let x, y = Seq.unzip xy

            Chart.BoxPlot(
                X = x,
                Y = y,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Text = Text,
                ?MultiText = MultiText,
                ?FillColor = FillColor,
                ?MarkerColor = MarkerColor,
                ?Marker = Marker,
                ?Opacity = Opacity,
                ?WhiskerWidth = WhiskerWidth,
                ?BoxPoints = BoxPoints,
                ?BoxMean = BoxMean,
                ?Jitter = Jitter,
                ?PointPos = PointPos,
                ?Orientation = Orientation,
                ?OutlineColor = OutlineColor,
                ?OutlineWidth = OutlineWidth,
                ?Outline = Outline,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?Notched = Notched,
                ?NotchWidth = NotchWidth,
                ?QuartileMethod = QuartileMethod,
                ?SizeMode = SizeMode,
                ?UseDefaults = UseDefaults
            )


        /// <summary>
        /// Visualizes the distribution of the input data as a violin plot.
        ///
        /// A violin plot is a method of plotting numeric data. It is similar to a box plot, except that they also show the probability density of the data at different values, usually smoothed by a kernel density estimator.
        ///
        /// In vertical (horizontal) violin plots, statistics are computed using `y` (`x`) values. By supplying an `x` (`y`) array, one violin per distinct x (y) value is drawn If no `x` (`y`) array is provided, a single violin is drawn. That violin position is then positioned with with `name` or with `x0` (`y0`) if provided.
        /// </summary>
        /// <param name="X">Sets the x sample data or coordinates</param>
        /// <param name="MultiX">Sets the x sample data or coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Y">Sets the y sample data or coordinates</param>
        /// <param name="MultiY">Sets the y sample data or coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Points">If "outliers", only the sample points lying outside the whiskers are shown If "suspectedoutliers", the outlier points are shown and points either less than 4"Q1-3"Q3 or greater than 4"Q3-3"Q1 are highlighted (see `outliercolor`) If "all", all sample points are shown If "false", only the violins are shown with no sample points. Defaults to "suspectedoutliers" when `marker.outliercolor` or `marker.line.outliercolor` is set, otherwise defaults to "outliers".</param>
        /// <param name="Jitter">Sets the amount of jitter in the sample points drawn. If "0", the sample points align along the distribution axis. If "1", the sample points are drawn in a random jitter of width equal to the width of the box(es).</param>
        /// <param name="PointPos">Sets the position of the sample points in relation to the box(es). If "0", the sample points are places over the center of the box(es). Positive (negative) values correspond to positions to the right (left) for vertical boxes and above (below) for horizontal boxes</param>
        /// <param name="Orientation">Sets the orientation of the violin(s). If "v" ("h"), the distribution is visualized along the vertical (horizontal).</param>
        /// <param name="Width">Sets the width of the violin in data coordinates. If "0" (default value) the width is automatically selected based on the positions of other violin traces in the same subplot.</param>
        /// <param name="MarkerColor">Sets the marker color.</param>
        /// <param name="Marker">Sets the marker for the violin (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="OutlineColor">Sets the color of the box outline</param>
        /// <param name="OutlineWidth">Sets the width of the box outline</param>
        /// <param name="Outline">Sets the box outline (use this for more finegrained control than the other outline-associated arguments).</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="ShowBox">Whether and how to draw a miniature box plot</param>
        /// <param name="BoxWidth">Sets the width of the miniature box plot</param>
        /// <param name="BoxFillColor">Sets the fill color of the miniature box plot</param>
        /// <param name="Box">Sets the styles of the miniature box plot (use this for more finegrained control than the other box-associated arguments)</param>
        /// <param name="BandWidth">Sets the bandwidth used to compute the kernel density estimate. By default, the bandwidth is determined by Silverman's rule of thumb.</param>
        /// <param name="MeanLine">Whether and how to draw the meanline</param>
        /// <param name="ScaleGroup">If there are multiple violins that should be sized according to to some metric (see `scalemode`), link them by providing a non-empty group id here shared by every trace in the same group. If a violin's `width` is undefined, `scalegroup` will default to the trace's name. In this case, violins with the same names will be linked together</param>
        /// <param name="ScaleMode">Sets the metric by which the width of each violin is determined."width" means each violin has the same (max) width"count" means the violins are scaled by the number of sample points makingup each violin.</param>
        /// <param name="Side">Determines on which side of the position value the density function making up one half of a violin is plotted. Useful when comparing two violin traces under "overlay" mode, where one trace has `side` set to "positive" and the other to "negative".</param>
        /// <param name="Span">Sets the span in data space for which the density function will be computed. Has an effect only when `spanmode` is set to "manual".</param>
        /// <param name="SpanMode">Sets the method by which the span in data space where the density function will be computed. "soft" means the span goes from the sample's minimum value minus two bandwidths to the sample's maximum value plus two bandwidths. "hard" means the span goes from the sample's minimum to its maximum value. For custom span settings, use mode "manual" and fill in the `span` attribute.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Violin
            (
                ?X: seq<#IConvertible>,
                ?MultiX: seq<seq<#IConvertible>>,
                ?Y: seq<#IConvertible>,
                ?MultiY: seq<seq<#IConvertible>>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?FillColor: Color,
                ?Opacity: float,
                ?Points: StyleParam.JitterPoints,
                ?Jitter: float,
                ?PointPos: float,
                ?Orientation: StyleParam.Orientation,
                ?Width: float,
                ?MarkerColor: Color,
                ?Marker: Marker,
                ?OutlineColor: Color,
                ?OutlineWidth: float,
                ?Outline: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?ShowBox: bool,
                ?BoxWidth: float,
                ?BoxFillColor: Color,
                ?Box: Box,
                ?BandWidth: float,
                ?MeanLine: MeanLine,
                ?ScaleGroup: string,
                ?ScaleMode: StyleParam.ScaleMode,
                ?Side: StyleParam.ViolinSide,
                ?Span: StyleParam.Range,
                ?SpanMode: StyleParam.SpanMode,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let box =
                Box
                |> Option.defaultValue (TraceObjects.Box.init ())
                |> TraceObjects.Box.style (?Visible = ShowBox, ?Width = BoxWidth, ?FillColor = BoxFillColor)

            let outline =
                Outline
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (?Color = OutlineColor, ?Width = OutlineWidth)

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (?Color = MarkerColor)

            Trace2D.initViolin (
                Trace2DStyle.Violin(
                    ?X = X,
                    ?MultiX = MultiX,
                    ?Y = Y,
                    ?MultiY = MultiY,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?FillColor = FillColor,
                    ?Points = Points,
                    ?Jitter = Jitter,
                    ?PointPos = PointPos,
                    ?Orientation = Orientation,
                    ?Width = Width,
                    Marker = marker,
                    Line = outline,
                    ?AlignmentGroup = AlignmentGroup,
                    ?OffsetGroup = OffsetGroup,
                    Box = box,
                    ?BandWidth = BandWidth,
                    ?MeanLine = MeanLine,
                    ?ScaleGroup = ScaleGroup,
                    ?ScaleMode = ScaleMode,
                    ?Side = Side,
                    ?Span = Span,
                    ?SpanMode = SpanMode
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Visualizes the distribution of the input data as a violin plot.
        ///
        /// A violin plot is a method of plotting numeric data. It is similar to a box plot, except that they also show the probability density of the data at different values, usually smoothed by a kernel density estimator.
        ///
        /// In vertical (horizontal) violin plots, statistics are computed using `y` (`x`) values. By supplying an `x` (`y`) array, one violin per distinct x (y) value is drawn If no `x` (`y`) array is provided, a single violin is drawn. That violin position is then positioned with with `name` or with `x0` (`y0`) if provided.
        /// </summary>
        /// <param name="data">Sets the sample data or coordinate pairs</param>
        /// <param name="orientation">Sets the orientation of the violin(s). If "v" ("h"), the distribution is visualized along the vertical (horizontal).</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Points">If "outliers", only the sample points lying outside the whiskers are shown If "suspectedoutliers", the outlier points are shown and points either less than 4"Q1-3"Q3 or greater than 4"Q3-3"Q1 are highlighted (see `outliercolor`) If "all", all sample points are shown If "false", only the violins are shown with no sample points. Defaults to "suspectedoutliers" when `marker.outliercolor` or `marker.line.outliercolor` is set, otherwise defaults to "outliers".</param>
        /// <param name="Jitter">Sets the amount of jitter in the sample points drawn. If "0", the sample points align along the distribution axis. If "1", the sample points are drawn in a random jitter of width equal to the width of the box(es).</param>
        /// <param name="PointPos">Sets the position of the sample points in relation to the box(es). If "0", the sample points are places over the center of the box(es). Positive (negative) values correspond to positions to the right (left) for vertical boxes and above (below) for horizontal boxes</param>
        /// <param name="Width">Sets the width of the violin in data coordinates. If "0" (default value) the width is automatically selected based on the positions of other violin traces in the same subplot.</param>
        /// <param name="MarkerColor">Sets the marker color.</param>
        /// <param name="Marker">Sets the marker for the violin (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="OutlineColor">Sets the color of the box outline</param>
        /// <param name="OutlineWidth">Sets the width of the box outline</param>
        /// <param name="Outline">Sets the box outline (use this for more finegrained control than the other outline-associated arguments).</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="ShowBox">Whether and how to draw a miniature box plot</param>
        /// <param name="BoxWidth">Sets the width of the miniature box plot</param>
        /// <param name="BoxFillColor">Sets the fill color of the miniature box plot</param>
        /// <param name="Box">Sets the styles of the miniature box plot (use this for more finegrained control than the other box-associated arguments)</param>
        /// <param name="BandWidth">Sets the bandwidth used to compute the kernel density estimate. By default, the bandwidth is determined by Silverman's rule of thumb.</param>
        /// <param name="MeanLine">Whether and how to draw the meanline</param>
        /// <param name="ScaleGroup">If there are multiple violins that should be sized according to to some metric (see `scalemode`), link them by providing a non-empty group id here shared by every trace in the same group. If a violin's `width` is undefined, `scalegroup` will default to the trace's name. In this case, violins with the same names will be linked together</param>
        /// <param name="ScaleMode">Sets the metric by which the width of each violin is determined."width" means each violin has the same (max) width"count" means the violins are scaled by the number of sample points makingup each violin.</param>
        /// <param name="Side">Determines on which side of the position value the density function making up one half of a violin is plotted. Useful when comparing two violin traces under "overlay" mode, where one trace has `side` set to "positive" and the other to "negative".</param>
        /// <param name="Span">Sets the span in data space for which the density function will be computed. Has an effect only when `spanmode` is set to "manual".</param>
        /// <param name="SpanMode">Sets the method by which the span in data space where the density function will be computed. "soft" means the span goes from the sample's minimum value minus two bandwidths to the sample's maximum value plus two bandwidths. "hard" means the span goes from the sample's minimum to its maximum value. For custom span settings, use mode "manual" and fill in the `span` attribute.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Violin
            (
                data: seq<#IConvertible>,
                orientation: StyleParam.Orientation,
                ?Name: string,
                ?ShowLegend: bool,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?FillColor: Color,
                ?Opacity: float,
                ?Points: StyleParam.JitterPoints,
                ?Jitter: float,
                ?PointPos: float,
                ?Width: float,
                ?MarkerColor: Color,
                ?Marker: Marker,
                ?OutlineColor: Color,
                ?OutlineWidth: float,
                ?Outline: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?ShowBox: bool,
                ?BoxWidth: float,
                ?BoxFillColor: Color,
                ?Box: Box,
                ?BandWidth: float,
                ?MeanLine: MeanLine,
                ?ScaleGroup: string,
                ?ScaleMode: StyleParam.ScaleMode,
                ?Side: StyleParam.ViolinSide,
                ?Span: StyleParam.Range,
                ?SpanMode: StyleParam.SpanMode,
                ?UseDefaults: bool
            ) =

            let violin =
                Chart.Violin(
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?FillColor = FillColor,
                    ?Opacity = Opacity,
                    ?Points = Points,
                    ?Jitter = Jitter,
                    ?PointPos = PointPos,
                    ?Width = Width,
                    ?MarkerColor = MarkerColor,
                    ?Marker = Marker,
                    ?OutlineColor = OutlineColor,
                    ?OutlineWidth = OutlineWidth,
                    ?Outline = Outline,
                    ?AlignmentGroup = AlignmentGroup,
                    ?OffsetGroup = OffsetGroup,
                    ?ShowBox = ShowBox,
                    ?BoxWidth = BoxWidth,
                    ?BoxFillColor = BoxFillColor,
                    ?Box = Box,
                    ?BandWidth = BandWidth,
                    ?MeanLine = MeanLine,
                    ?ScaleGroup = ScaleGroup,
                    ?ScaleMode = ScaleMode,
                    ?Side = Side,
                    ?Span = Span,
                    ?SpanMode = SpanMode,
                    ?UseDefaults = UseDefaults
                )

            match orientation with
            | StyleParam.Orientation.Horizontal -> violin |> GenericChart.mapTrace (Trace2DStyle.Violin(X = data))
            | StyleParam.Orientation.Vertical -> violin |> GenericChart.mapTrace (Trace2DStyle.Violin(Y = data))

        /// <summary>
        /// Visualizes the distribution of the input data as a violin plot.
        ///
        /// A violin plot is a method of plotting numeric data. It is similar to a box plot, except that they also show the probability density of the data at different values, usually smoothed by a kernel density estimator.
        ///
        /// In vertical (horizontal) violin plots, statistics are computed using `y` (`x`) values. By supplying an `x` (`y`) array, one violin per distinct x (y) value is drawn If no `x` (`y`) array is provided, a single violin is drawn. That violin position is then positioned with with `name` or with `x0` (`y0`) if provided.
        /// </summary>
        /// <param name="xy">Sets the xy sample data or coordinate pairs</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="Points">If "outliers", only the sample points lying outside the whiskers are shown If "suspectedoutliers", the outlier points are shown and points either less than 4"Q1-3"Q3 or greater than 4"Q3-3"Q1 are highlighted (see `outliercolor`) If "all", all sample points are shown If "false", only the violins are shown with no sample points. Defaults to "suspectedoutliers" when `marker.outliercolor` or `marker.line.outliercolor` is set, otherwise defaults to "outliers".</param>
        /// <param name="Jitter">Sets the amount of jitter in the sample points drawn. If "0", the sample points align along the distribution axis. If "1", the sample points are drawn in a random jitter of width equal to the width of the box(es).</param>
        /// <param name="PointPos">Sets the position of the sample points in relation to the box(es). If "0", the sample points are places over the center of the box(es). Positive (negative) values correspond to positions to the right (left) for vertical boxes and above (below) for horizontal boxes</param>
        /// <param name="Orientation">Sets the orientation of the violin(s). If "v" ("h"), the distribution is visualized along the vertical (horizontal).</param>
        /// <param name="Width">Sets the width of the violin in data coordinates. If "0" (default value) the width is automatically selected based on the positions of other violin traces in the same subplot.</param>
        /// <param name="MarkerColor">Sets the marker color.</param>
        /// <param name="Marker">Sets the marker for the violin (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="OutlineColor">Sets the color of the box outline</param>
        /// <param name="OutlineWidth">Sets the width of the box outline</param>
        /// <param name="Outline">Sets the box outline (use this for more finegrained control than the other outline-associated arguments).</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="ShowBox">Whether and how to draw a miniature box plot</param>
        /// <param name="BoxWidth">Sets the width of the miniature box plot</param>
        /// <param name="BoxFillColor">Sets the fill color of the miniature box plot</param>
        /// <param name="Box">Sets the styles of the miniature box plot (use this for more finegrained control than the other box-associated arguments)</param>
        /// <param name="BandWidth">Sets the bandwidth used to compute the kernel density estimate. By default, the bandwidth is determined by Silverman's rule of thumb.</param>
        /// <param name="MeanLine">Whether and how to draw the meanline</param>
        /// <param name="ScaleGroup">If there are multiple violins that should be sized according to to some metric (see `scalemode`), link them by providing a non-empty group id here shared by every trace in the same group. If a violin's `width` is undefined, `scalegroup` will default to the trace's name. In this case, violins with the same names will be linked together</param>
        /// <param name="ScaleMode">Sets the metric by which the width of each violin is determined."width" means each violin has the same (max) width"count" means the violins are scaled by the number of sample points makingup each violin.</param>
        /// <param name="Side">Determines on which side of the position value the density function making up one half of a violin is plotted. Useful when comparing two violin traces under "overlay" mode, where one trace has `side` set to "positive" and the other to "negative".</param>
        /// <param name="Span">Sets the span in data space for which the density function will be computed. Has an effect only when `spanmode` is set to "manual".</param>
        /// <param name="SpanMode">Sets the method by which the span in data space where the density function will be computed. "soft" means the span goes from the sample's minimum value minus two bandwidths to the sample's maximum value plus two bandwidths. "hard" means the span goes from the sample's minimum to its maximum value. For custom span settings, use mode "manual" and fill in the `span` attribute.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Violin
            (
                xy: seq<#IConvertible * #IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?FillColor: Color,
                ?Opacity: float,
                ?Points: StyleParam.JitterPoints,
                ?Jitter: float,
                ?PointPos: float,
                ?Orientation: StyleParam.Orientation,
                ?Width: float,
                ?MarkerColor: Color,
                ?Marker: Marker,
                ?OutlineColor: Color,
                ?OutlineWidth: float,
                ?Outline: Line,
                ?AlignmentGroup: string,
                ?OffsetGroup: string,
                ?ShowBox: bool,
                ?BoxWidth: float,
                ?BoxFillColor: Color,
                ?Box: Box,
                ?BandWidth: float,
                ?MeanLine: MeanLine,
                ?ScaleGroup: string,
                ?ScaleMode: StyleParam.ScaleMode,
                ?Side: StyleParam.ViolinSide,
                ?Span: StyleParam.Range,
                ?SpanMode: StyleParam.SpanMode,
                ?UseDefaults: bool
            ) =

            let x, y = Seq.unzip xy

            Chart.Violin(
                X = x,
                Y = y,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Text = Text,
                ?MultiText = MultiText,
                ?FillColor = FillColor,
                ?Opacity = Opacity,
                ?Points = Points,
                ?Jitter = Jitter,
                ?PointPos = PointPos,
                ?Orientation = Orientation,
                ?Width = Width,
                ?MarkerColor = MarkerColor,
                ?Marker = Marker,
                ?OutlineColor = OutlineColor,
                ?OutlineWidth = OutlineWidth,
                ?Outline = Outline,
                ?AlignmentGroup = AlignmentGroup,
                ?OffsetGroup = OffsetGroup,
                ?ShowBox = ShowBox,
                ?BoxWidth = BoxWidth,
                ?BoxFillColor = BoxFillColor,
                ?Box = Box,
                ?BandWidth = BandWidth,
                ?MeanLine = MeanLine,
                ?ScaleGroup = ScaleGroup,
                ?ScaleMode = ScaleMode,
                ?Side = Side,
                ?Span = Span,
                ?SpanMode = SpanMode,
                ?UseDefaults = UseDefaults
            )


        /// <summary>
        /// Computes a 2D histogram contour plot, also known as a density contour plot, which is a 2-dimensional generalization of a histogram which resembles a contour plot but is computed by grouping a set of points specified by their x and y coordinates into bins, and applying an aggregation function such as count or sum (if z is provided) to compute the value to be used to compute contours.
        ///
        /// The sample data from which statistics are computed is set in `x` and `y` (where `x` and `y` represent marginal distributions, binning is set in `xbins` and `ybins` in this case) or `z` (where `z` represent the 2D distribution and binning set, binning is set by `x` and `y` in this case). The resulting distribution is visualized as a contour plot.
        /// </summary>
        /// <param name="X">Sets the sample data to be binned on the x axis.</param>
        /// <param name="MultiX">Sets the sample data to be binned on the x axis. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Y">Sets the sample data to be binned on the y axis.</param>
        /// <param name="MultiY">Sets the sample data to be binned on the y axis. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Z">Sets the aggregation data.</param>
        /// <param name="HistFunc">Specifies the binning function used for this histogram trace. If "count", the histogram values are computed by counting the number of values lying inside each bin. If "sum", "avg", "min", "max", the histogram values are computed using the sum, the average, the minimum or the maximum of the values lying inside each bin respectively.</param>
        /// <param name="HistNorm">Specifies the type of normalization used for this histogram trace. If "", the span of each bar corresponds to the number of occurrences (i.e. the number of data points lying inside the bins). If "percent" / "probability", the span of each bar corresponds to the percentage / fraction of occurrences with respect to the total number of sample points (here, the sum of all bin HEIGHTS equals 100% / 1). If "density", the span of each bar corresponds to the number of occurrences in a bin divided by the size of the bin interval (here, the sum of all bin AREAS equals the total number of sample points). If "probability density", the area of each bar corresponds to the probability that an event will fall into the corresponding bin (here, the sum of all bin AREAS equals 1).</param>
        /// <param name="NBinsX">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `xbins.size` is provided.</param>
        /// <param name="NBinsY">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `ybins.size` is provided.</param>
        /// <param name="BinGroup">Set the `xbingroup` and `ybingroup` default prefix For example, setting a `bingroup` of "1" on two histogram2d traces will make them their x-bins and y-bins match separately.</param>
        /// <param name="XBinGroup">Set a group of histogram traces which will have compatible x-bin settings. Using `xbingroup`, histogram2d and histogram2dcontour traces (on axes of the same axis type) can have compatible x-bin settings. Note that the same `xbingroup` value can be used to set (1D) histogram `bingroup`</param>
        /// <param name="XBins">Sets the binning across the x dimension</param>
        /// <param name="YBinGroup">Set a group of histogram traces which will have compatible y-bin settings. Using `ybingroup`, histogram2d and histogram2dcontour traces (on axes of the same axis type) can have compatible y-bin settings. Note that the same `ybingroup` value can be used to set (1D) histogram `bingroup`</param>
        /// <param name="YBins">Sets the binning across the y dimension</param>
        /// <param name="Marker">Sets the marker of this trace.</param>
        /// <param name="ContourLinesDash">Sets the contour line dash style</param>
        /// <param name="ContourLinesColor">Sets the contour line color</param>
        /// <param name="ContourLinesSmoothing">Sets the amount of smoothing for the contour lines, where "0" corresponds to no smoothing.</param>
        /// <param name="ContourLinesWidth">Sets the width of the contour lines</param>
        /// <param name="ContourLines">Sets the contour lines (use this for more finegrained control than the other contourline-associated arguments).</param>
        /// <param name="ShowContourLines">Wether or not to show the contour line</param>
        /// <param name="ContoursColoring">Determines the coloring method showing the contour values. If "fill", coloring is done evenly between each contour level If "heatmap", a heatmap gradient coloring is applied between each contour level. If "lines", coloring is done on the contour lines. If "none", no coloring is applied on this trace.</param>
        /// <param name="ContoursOperation">Sets the constraint operation. "=" keeps regions equal to `value` "&lt;" and "&lt;=" keep regions less than `value` "&gt;" and "&gt;=" keep regions greater than `value` "[]", "()", "[)", and "(]" keep regions inside `value[0]` to `value[1]` "][", ")(", "](", ")[" keep regions outside `value[0]` to value[1]` Open vs. closed intervals make no difference to constraint display, but all versions are allowed for consistency with filter transforms.</param>
        /// <param name="ContoursType">If `levels`, the data is represented as a contour plot with multiple levels displayed. If `constraint`, the data is represented as constraints with the invalid region shaded as specified by the `operation` and `value` parameters.</param>
        /// <param name="ShowContoursLabels">Determines whether to label the contour lines with their values.</param>
        /// <param name="ContoursLabelFont">Sets the font used for labeling the contour levels. The default color comes from the lines, if shown. The default family and size come from `layout.font`.</param>
        /// <param name="ContoursStart">Sets the starting contour level value. Must be less than `contours.end`</param>
        /// <param name="ContoursEnd">Sets the end contour level value. Must be more than `contours.start`</param>
        /// <param name="Contours">Sets the styles of the contours (use this for more finegrained control than the other contour-associated arguments).</param>
        /// <param name="ColorBar">Sets the styles of the colorbar for this trace.</param>
        /// <param name="ColorScale">Sets the colorscale for this trace.</param>
        /// <param name="ShowScale">Whether or not to show the colorscale/colorbar</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
        /// <param name="NContours">Sets the maximum number of contour levels. The actual number of contours will be chosen automatically to be less than or equal to the value of `ncontours`. Has an effect only if `autocontour` is "true" or if `contours.size` is missing.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Histogram2DContour
            (
                ?X: seq<#IConvertible>,
                ?MultiX: seq<seq<#IConvertible>>,
                ?Y: seq<#IConvertible>,
                ?MultiY: seq<seq<#IConvertible>>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Z: seq<#seq<#IConvertible>>,
                ?HistFunc: StyleParam.HistFunc,
                ?HistNorm: StyleParam.HistNorm,
                ?NBinsX: int,
                ?NBinsY: int,
                ?BinGroup: string,
                ?XBinGroup: string,
                ?XBins: Bins,
                ?YBinGroup: string,
                ?YBins: Bins,
                ?Marker: Marker,
                ?ContourLinesColor: Color,
                ?ContourLinesDash: StyleParam.DrawingStyle,
                ?ContourLinesSmoothing: float,
                ?ContourLinesWidth: float,
                ?ContourLines: Line,
                ?ShowContourLines: bool,
                ?ContoursColoring: StyleParam.ContourColoring,
                ?ContoursOperation: StyleParam.ConstraintOperation,
                ?ContoursType: StyleParam.ContourType,
                ?ShowContoursLabels: bool,
                ?ContoursLabelFont: Font,
                ?ContoursStart: float,
                ?ContoursEnd: float,
                ?Contours: Contours,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ReverseScale: bool,
                ?NContours: int,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let showContourLines =
                defaultArg ShowContourLines false

            let contourLineWidth =
                ContourLinesWidth |> Option.map (fun v -> if showContourLines then v else 0.) |> Option.defaultValue 0.

            let contours =
                Contours
                |> Option.defaultValue (TraceObjects.Contours.init ())
                |> TraceObjects.Contours.style (
                    ?Coloring = ContoursColoring,
                    ?Operation = ContoursOperation,
                    ?Start = ContoursStart,
                    ?End = ContoursEnd,
                    ?Type = ContoursType,
                    ?ShowLabels = ShowContoursLabels,
                    ?LabelFont = ContoursLabelFont
                )

            let contourLines =
                ContourLines
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    Width = contourLineWidth,
                    ?Color = ContourLinesColor,
                    ?Dash = ContourLinesDash,
                    ?Smoothing = ContourLinesSmoothing
                )

            Trace2D.initHistogram2DContour (
                Trace2DStyle.Histogram2DContour(
                    ?X = X,
                    ?MultiX = MultiX,
                    ?Y = Y,
                    ?MultiY = MultiY,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Z = Z,
                    ?HistFunc = HistFunc,
                    ?HistNorm = HistNorm,
                    ?NBinsX = NBinsX,
                    ?NBinsY = NBinsY,
                    ?BinGroup = BinGroup,
                    ?XBinGroup = XBinGroup,
                    ?XBins = XBins,
                    ?YBinGroup = YBinGroup,
                    ?YBins = YBins,
                    ?Marker = Marker,
                    Line = contourLines,
                    ?ColorBar = ColorBar,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ReverseScale = ReverseScale,
                    Contours = contours,
                    ?NContours = NContours
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Computes a 2D histogram contour plot, also known as a density contour plot, which is a 2-dimensional generalization of a histogram which resembles a contour plot but is computed by grouping a set of points specified by their x and y coordinates into bins, and applying an aggregation function such as count or sum (if z is provided) to compute the value to be used to compute contours.
        ///
        /// The sample data from which statistics are computed is set in `x` and `y` (where `x` and `y` represent marginal distributions, binning is set in `xbins` and `ybins` in this case) or `z` (where `z` represent the 2D distribution and binning set, binning is set by `x` and `y` in this case). The resulting distribution is visualized as a contour plot.
        /// </summary>
        /// <param name="x">Sets the sample data to be binned on the x axis.</param>
        /// <param name="y">Sets the sample data to be binned on the y axis.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Z">Sets the aggregation data.</param>
        /// <param name="HistFunc">Specifies the binning function used for this histogram trace. If "count", the histogram values are computed by counting the number of values lying inside each bin. If "sum", "avg", "min", "max", the histogram values are computed using the sum, the average, the minimum or the maximum of the values lying inside each bin respectively.</param>
        /// <param name="HistNorm">Specifies the type of normalization used for this histogram trace. If "", the span of each bar corresponds to the number of occurrences (i.e. the number of data points lying inside the bins). If "percent" / "probability", the span of each bar corresponds to the percentage / fraction of occurrences with respect to the total number of sample points (here, the sum of all bin HEIGHTS equals 100% / 1). If "density", the span of each bar corresponds to the number of occurrences in a bin divided by the size of the bin interval (here, the sum of all bin AREAS equals the total number of sample points). If "probability density", the area of each bar corresponds to the probability that an event will fall into the corresponding bin (here, the sum of all bin AREAS equals 1).</param>
        /// <param name="NBinsX">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `xbins.size` is provided.</param>
        /// <param name="NBinsY">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `ybins.size` is provided.</param>
        /// <param name="BinGroup">Set the `xbingroup` and `ybingroup` default prefix For example, setting a `bingroup` of "1" on two histogram2d traces will make them their x-bins and y-bins match separately.</param>
        /// <param name="XBinGroup">Set a group of histogram traces which will have compatible x-bin settings. Using `xbingroup`, histogram2d and histogram2dcontour traces (on axes of the same axis type) can have compatible x-bin settings. Note that the same `xbingroup` value can be used to set (1D) histogram `bingroup`</param>
        /// <param name="XBins">Sets the binning across the x dimension</param>
        /// <param name="YBinGroup">Set a group of histogram traces which will have compatible y-bin settings. Using `ybingroup`, histogram2d and histogram2dcontour traces (on axes of the same axis type) can have compatible y-bin settings. Note that the same `ybingroup` value can be used to set (1D) histogram `bingroup`</param>
        /// <param name="YBins">Sets the binning across the y dimension</param>
        /// <param name="Marker">Sets the marker of this trace.</param>
        /// <param name="ContourLinesDash">Sets the contour line dash style</param>
        /// <param name="ContourLinesColor">Sets the contour line color</param>
        /// <param name="ContourLinesSmoothing">Sets the amount of smoothing for the contour lines, where "0" corresponds to no smoothing.</param>
        /// <param name="ContourLinesWidth">Sets the width of the contour lines</param>
        /// <param name="ContourLines">Sets the contour lines (use this for more finegrained control than the other contourline-associated arguments).</param>
        /// <param name="ShowContourLines">Wether or not to show the contour line</param>
        /// <param name="ContoursColoring">Determines the coloring method showing the contour values. If "fill", coloring is done evenly between each contour level If "heatmap", a heatmap gradient coloring is applied between each contour level. If "lines", coloring is done on the contour lines. If "none", no coloring is applied on this trace.</param>
        /// <param name="ContoursOperation">Sets the constraint operation. "=" keeps regions equal to `value` "&lt;" and "&lt;=" keep regions less than `value` "&gt;" and "&gt;=" keep regions greater than `value` "[]", "()", "[)", and "(]" keep regions inside `value[0]` to `value[1]` "][", ")(", "](", ")[" keep regions outside `value[0]` to value[1]` Open vs. closed intervals make no difference to constraint display, but all versions are allowed for consistency with filter transforms.</param>
        /// <param name="ContoursType">If `levels`, the data is represented as a contour plot with multiple levels displayed. If `constraint`, the data is represented as constraints with the invalid region shaded as specified by the `operation` and `value` parameters.</param>
        /// <param name="ShowContoursLabels">Determines whether to label the contour lines with their values.</param>
        /// <param name="ContoursLabelFont">Sets the font used for labeling the contour levels. The default color comes from the lines, if shown. The default family and size come from `layout.font`.</param>
        /// <param name="ContoursStart">Sets the starting contour level value. Must be less than `contours.end`</param>
        /// <param name="ContoursEnd">Sets the end contour level value. Must be more than `contours.start`</param>
        /// <param name="Contours">Sets the styles of the contours (use this for more finegrained control than the other contour-associated arguments).</param>
        /// <param name="ColorBar">Sets the styles of the colorbar for this trace.</param>
        /// <param name="ColorScale">Sets the colorscale for this trace.</param>
        /// <param name="ShowScale">Whether or not to show the colorscale/colorbar</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
        /// <param name="NContours">Sets the maximum number of contour levels. The actual number of contours will be chosen automatically to be less than or equal to the value of `ncontours`. Has an effect only if `autocontour` is "true" or if `contours.size` is missing.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Histogram2DContour
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Z: seq<#seq<#IConvertible>>,
                ?HistFunc: StyleParam.HistFunc,
                ?HistNorm: StyleParam.HistNorm,
                ?NBinsX: int,
                ?NBinsY: int,
                ?BinGroup: string,
                ?XBinGroup: string,
                ?XBins: Bins,
                ?YBinGroup: string,
                ?YBins: Bins,
                ?Marker: Marker,
                ?ContourLinesColor: Color,
                ?ContourLinesDash: StyleParam.DrawingStyle,
                ?ContourLinesSmoothing: float,
                ?ContourLinesWidth: float,
                ?ContourLines: Line,
                ?ShowContourLines: bool,
                ?ContoursColoring: StyleParam.ContourColoring,
                ?ContoursOperation: StyleParam.ConstraintOperation,
                ?ContoursType: StyleParam.ContourType,
                ?ShowContoursLabels: bool,
                ?ContoursLabelFont: Font,
                ?ContoursStart: float,
                ?ContoursEnd: float,
                ?Contours: Contours,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ReverseScale: bool,
                ?NContours: int,
                ?UseDefaults: bool
            ) =
            Chart.Histogram2DContour(
                X = x,
                Y = y,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?Z = Z,
                ?HistFunc = HistFunc,
                ?HistNorm = HistNorm,
                ?NBinsX = NBinsX,
                ?NBinsY = NBinsY,
                ?BinGroup = BinGroup,
                ?XBinGroup = XBinGroup,
                ?XBins = XBins,
                ?YBinGroup = YBinGroup,
                ?YBins = YBins,
                ?Marker = Marker,
                ?ContourLinesColor = ContourLinesColor,
                ?ContourLinesDash = ContourLinesDash,
                ?ContourLinesSmoothing = ContourLinesSmoothing,
                ?ContourLinesWidth = ContourLinesWidth,
                ?ContourLines = ContourLines,
                ?ShowContourLines= ShowContourLines,
                ?ContoursColoring = ContoursColoring,
                ?ContoursOperation = ContoursOperation,
                ?ContoursType = ContoursType,
                ?ShowContoursLabels = ShowContoursLabels,
                ?ContoursLabelFont = ContoursLabelFont,
                ?ContoursStart = ContoursStart,
                ?ContoursEnd = ContoursEnd,
                ?Contours = Contours,
                ?ColorBar = ColorBar,
                ?ColorScale = ColorScale,
                ?ShowScale = ShowScale,
                ?ReverseScale = ReverseScale,
                ?NContours = NContours,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a heatmap.
        ///
        /// A heatmap is a data visualization technique that shows magnitude of a phenomenon as color in two dimensions.
        /// </summary>
        /// <param name="zData">Sets the 2-dimensional z data, which will be visualized with the color scale.</param>
        /// <param name="X">Sets the x coordinates</param>
        /// <param name="MultiX">Sets the x coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Y">Sets the y coordinates</param>
        /// <param name="MultiY">Sets the y coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="XGap">Sets the horizontal gap (in pixels) between bricks.</param>
        /// <param name="YGap">Sets the vertical gap (in pixels) between bricks.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorBar">Sets the styles of the colorbar for this trace.</param>
        /// <param name="ColorScale">Sets the colorscale for this trace.</param>
        /// <param name="ShowScale">Whether or not to show the colorscale/colorbar</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
        /// <param name="ZSmooth">Picks a smoothing algorithm use to smooth `z` data.</param>
        /// <param name="Transpose">Transposes the z data.</param>
        /// <param name="UseWebGL">Whether or not to use WebGL to render this trace</param>
        /// <param name="ReverseYAxis">Whether or not to reverse the y axis. If true, (0,0) will lie on the top left and increase downwards.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Heatmap
            (
                zData: seq<#seq<#IConvertible>>,
                ?X: seq<#IConvertible>,
                ?MultiX: seq<seq<#IConvertible>>,
                ?Y: seq<#IConvertible>,
                ?MultiY: seq<seq<#IConvertible>>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?XGap: int,
                ?YGap: int,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ReverseScale: bool,
                ?ZSmooth: StyleParam.SmoothAlg,
                ?Transpose: bool,
                ?UseWebGL: bool,
                ?ReverseYAxis: bool,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let reverseYAxis =
                defaultArg ReverseYAxis false

            let style =
                Trace2DStyle.Heatmap(
                    Z = zData,
                    ?X = X,
                    ?MultiX = MultiX,
                    ?Y = Y,
                    ?MultiY = MultiY,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?XGap = XGap,
                    ?YGap = YGap,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?ColorBar = ColorBar,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ReverseScale = ReverseScale,
                    ?ZSmooth = ZSmooth,
                    ?Transpose = Transpose
                )

            let useWebGL = defaultArg UseWebGL false

            Chart.renderHeatmapTrace useDefaults useWebGL style
            |> fun c ->
                if reverseYAxis then
                    c |> Chart.withYAxis (LinearAxis.init (AutoRange = StyleParam.AutoRange.Reversed))
                else
                    c

        /// <summary>
        /// Creates a heatmap.
        ///
        /// A heatmap is a data visualization technique that shows magnitude of a phenomenon as color in two dimensions.
        /// </summary>
        /// <param name="zData">Sets the 2-dimensional z data, which will be visualized with the color scale.</param>
        /// <param name="colNames">Sets names for each column (as x coordinates)</param>
        /// <param name="rowNames">Sets names for each row (as y coordinates)</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="XGap">Sets the horizontal gap (in pixels) between bricks.</param>
        /// <param name="YGap">Sets the vertical gap (in pixels) between bricks.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorBar">Sets the styles of the colorbar for this trace.</param>
        /// <param name="ColorScale">Sets the colorscale for this trace.</param>
        /// <param name="ShowScale">Whether or not to show the colorscale/colorbar</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
        /// <param name="ZSmooth">Picks a smoothing algorithm use to smooth `z` data.</param>
        /// <param name="Transpose">Transposes the z data.</param>
        /// <param name="UseWebGL">Whether or not to use WebGL to render this trace</param>
        /// <param name="ReverseYAxis">Whether or not to reverse the y axis. If true, (0,0) will lie on the top left and increase downwards.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Heatmap
            (
                zData: seq<#seq<#IConvertible>>,
                colNames: seq<string>,
                rowNames: seq<string>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?XGap: int,
                ?YGap: int,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ReverseScale: bool,
                ?ZSmooth: StyleParam.SmoothAlg,
                ?Transpose: bool,
                ?UseWebGL: bool,
                ?ReverseYAxis: bool,
                ?UseDefaults: bool
            ) =

            Chart.Heatmap(
                zData = zData,
                X = colNames,
                Y = rowNames,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?XGap = XGap,
                ?YGap = YGap,
                ?Text = Text,
                ?MultiText = MultiText,
                ?ColorBar = ColorBar,
                ?ColorScale = ColorScale,
                ?ShowScale = ShowScale,
                ?ReverseScale = ReverseScale,
                ?ZSmooth = ZSmooth,
                ?Transpose = Transpose,
                ?UseWebGL = UseWebGL,
                ?ReverseYAxis = ReverseYAxis,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a annotated heatmap.
        ///
        /// A heatmap is a data visualization technique that shows magnitude of a phenomenon as color in two dimensions.
        ///
        /// The annotated heatmap additionally contains annotation text on each datum.
        /// </summary>
        /// <param name="zData">Sets the 2-dimensional z data, which will be visualized with the color scale.</param>
        /// <param name="annotationText">Sets the text to display as annotation for each datum.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="X">Sets the x coordinates.</param>
        /// <param name="MultiX">Sets the x coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="XGap">Sets the horizontal gap (in pixels) between bricks.</param>
        /// <param name="Y">Sets the y coordinates.</param>
        /// <param name="MultiY">Sets the y coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="YGap">Sets the vertical gap (in pixels) between bricks.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorBar">Sets the styles of the colorbar for this trace.</param>
        /// <param name="ColorScale">Sets the colorscale for this trace.</param>
        /// <param name="ShowScale">Whether or not to show the colorscale/colorbar</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
        /// <param name="ZSmooth">Picks a smoothing algorithm use to smooth `z` data.</param>
        /// <param name="Transpose">Transposes the z data.</param>
        /// <param name="UseWebGL">Whether or not to use WebGL to render this trace</param>
        /// <param name="ReverseYAxis">Whether or not to reverse the y axis. If true, (0,0) will lie on the top left and increase downwards.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member AnnotatedHeatmap
            (
                zData: seq<#seq<#IConvertible>>,
                annotationText: seq<#seq<string>>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?X: seq<#IConvertible>,
                ?MultiX: seq<seq<#IConvertible>>,
                ?XGap: int,
                ?Y: seq<#IConvertible>,
                ?MultiY: seq<seq<#IConvertible>>,
                ?YGap: int,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ReverseScale: bool,
                ?ZSmooth: StyleParam.SmoothAlg,
                ?Transpose: bool,
                ?UseWebGL: bool,
                ?ReverseYAxis: bool,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let reverseYAxis =
                defaultArg ReverseYAxis false

            let dims = Seq.length zData
            let dims2 = Seq.length annotationText

            if dims <> dims2 then
                failwith "incompatible dims"

            let style =
                Trace2DStyle.Heatmap(
                    Z = zData,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?X = X,
                    ?MultiX = MultiX,
                    ?XGap = XGap,
                    ?Y = Y,
                    ?MultiY = MultiY,
                    ?YGap = YGap,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?ColorBar = ColorBar,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ReverseScale = ReverseScale,
                    ?ZSmooth = ZSmooth,
                    ?Transpose = Transpose
                )

            let useWebGL = defaultArg UseWebGL false

            Chart.renderHeatmapTrace useDefaults useWebGL style
            |> fun c ->
                if reverseYAxis then
                    c |> Chart.withYAxis (LinearAxis.init (AutoRange = StyleParam.AutoRange.Reversed))
                else
                    c
            |> Chart.withAnnotations (
                annotationText
                |> Seq.mapi (fun y inner ->
                    inner |> Seq.mapi (fun x text -> Annotation.init (x, y, Text = (string text), ShowArrow = false)))
                |> Seq.concat
            )


        /// <summary>
        /// Creates a annotated heatmap.
        ///
        /// A heatmap is a data visualization technique that shows magnitude of a phenomenon as color in two dimensions.
        ///
        /// The annotated heatmap additionally contains annotation text on each datum.
        /// </summary>
        /// <param name="dataAnnotations">Sets the 2-dimensional z data, which will be visualized with the color scale together with the respective annotation text.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="X">Sets the x coordinates.</param>
        /// <param name="MultiX">Sets the x coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="XGap">Sets the horizontal gap (in pixels) between bricks.</param>
        /// <param name="Y">Sets the y coordinates.</param>
        /// <param name="MultiY">Sets the y coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="YGap">Sets the vertical gap (in pixels) between bricks.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorBar">Sets the styles of the colorbar for this trace.</param>
        /// <param name="ColorScale">Sets the colorscale for this trace.</param>
        /// <param name="ShowScale">Whether or not to show the colorscale/colorbar</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
        /// <param name="ZSmooth">Picks a smoothing algorithm use to smooth `z` data.</param>
        /// <param name="Transpose">Transposes the z data.</param>
        /// <param name="UseWebGL">Whether or not to use WebGL to render this trace</param>
        /// <param name="ReverseYAxis">Whether or not to reverse the y axis. If true, (0,0) will lie on the top left and increase downwards.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member AnnotatedHeatmap
            (
                dataAnnotations: seq<#seq<#IConvertible * string>>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?X: seq<#IConvertible>,
                ?MultiX: seq<seq<#IConvertible>>,
                ?XGap: int,
                ?Y: seq<#IConvertible>,
                ?MultiY: seq<seq<#IConvertible>>,
                ?YGap: int,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ReverseScale: bool,
                ?ZSmooth: StyleParam.SmoothAlg,
                ?Transpose: bool,
                ?UseWebGL: bool,
                ?ReverseYAxis: bool,
                ?UseDefaults: bool
            ) =

            let zData =
                dataAnnotations |> Seq.map (Seq.map fst)

            let annotationText =
                dataAnnotations |> Seq.map (Seq.map snd)

            Chart.AnnotatedHeatmap(
                zData = zData,
                annotationText = annotationText,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?X = X,
                ?MultiX = MultiX,
                ?XGap = XGap,
                ?Y = Y,
                ?MultiY = MultiY,
                ?YGap = YGap,
                ?Text = Text,
                ?MultiText = MultiText,
                ?ColorBar = ColorBar,
                ?ColorScale = ColorScale,
                ?ShowScale = ShowScale,
                ?ReverseScale = ReverseScale,
                ?ZSmooth = ZSmooth,
                ?Transpose = Transpose,
                ?UseWebGL = UseWebGL,
                ?ReverseYAxis = ReverseYAxis,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Display an image, i.e. data on a 2D regular raster. By default, when an image is displayed in a subplot, its y axis will be reversed (ie. `autorange: 'reversed'`), constrained to the domain (ie. `constrain: 'domain'`) and it will have the same scale as its x axis (ie. `scaleanchor: 'x,`) in order for pixels to be rendered as squares.
        /// </summary>
        /// <param name="Z">A 2-dimensional array in which each element is an array of 3 or 4 numbers representing a color.</param>
        /// <param name="Source">Specifies the data URI of the image to be visualized. The URI consists of "data:image/[&lt;media subtype&gt;][;base64],&lt;data&gt;"</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
        /// <param name="ColorModel">Color model used to map the numerical color components described in `z` into colors. If `source` is specified, this attribute will be set to `rgba256` otherwise it defaults to `rgb`.</param>
        /// <param name="ZMax">Sets the upper bound of the color domain. Value should have the same units as in `z` and if set, `zmin` must be set as well.</param>
        /// <param name="ZMin">Sets the lower bound of the color domain. Value should have the same units as in `z` and if set, `zmax` must be set as well.</param>
        /// <param name="ZSmooth">Picks a smoothing algorithm use to smooth `z` data.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Image
            (
                ?Z: seq<#seq<#seq<int>>>,
                ?Source: string,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Ids: seq<#IConvertible>,
                ?ColorModel: StyleParam.ColorModel,
                ?ZMax: StyleParam.ColorComponentBound,
                ?ZMin: StyleParam.ColorComponentBound,
                ?ZSmooth: StyleParam.SmoothAlg,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            Trace2D.initImage (
                Trace2DStyle.Image(
                    ?Z = Z,
                    ?Source = Source,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Ids = Ids,
                    ?ColorModel = ColorModel,
                    ?ZMax = ZMax,
                    ?ZMin = ZMin,
                    ?ZSmooth = ZSmooth
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Display an image, i.e. data on a 2D regular raster. By default, when an image is displayed in a subplot, its y axis will be reversed (ie. `autorange: 'reversed'`), constrained to the domain (ie. `constrain: 'domain'`) and it will have the same scale as its x axis (ie. `scaleanchor: 'x,`) in order for pixels to be rendered as squares.
        /// </summary>
        /// <param name="z">A 2-dimensional array containing Plotly.NETs ARGB color object.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
        /// <param name="ZMax">Sets the upper bound of the color domain. Value should have the same units as in `z` and if set, `zmin` must be set as well.</param>
        /// <param name="ZMin">Sets the lower bound of the color domain. Value should have the same units as in `z` and if set, `zmax` must be set as well.</param>
        /// <param name="ZSmooth">Picks a smoothing algorithm use to smooth `z` data.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Image
            (
                z: seq<#seq<ARGB>>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Ids: seq<#IConvertible>,
                ?ZMax: StyleParam.ColorComponentBound,
                ?ZMin: StyleParam.ColorComponentBound,
                ?ZSmooth: StyleParam.SmoothAlg,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let z' =
                z
                |> Seq.map (
                    Seq.map (fun argb ->
                        seq {
                            int argb.R
                            int argb.G
                            int argb.B
                            int argb.A
                        })
                )


            Trace2D.initImage (
                Trace2DStyle.Image(
                    Z = z',
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Ids = Ids,
                    ColorModel = StyleParam.ColorModel.RGBA,
                    ?ZMax = ZMax,
                    ?ZMin = ZMin,
                    ?ZSmooth = ZSmooth
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a 2D contour plot, which shows the contour lines of a 2D numerical array z, i.e. interpolated lines of isovalues of z.
        ///
        /// A contour line (also isoline, isopleth, or isarithm) of a function of two variables is a curve along which the function has a constant value, so that the curve joins points of equal value
        ///
        /// The data from which contour lines are computed is set in `z`. Data in `z` must be a 2D array of numbers. Say that `z` has N rows and M columns, then by default, these N rows correspond to N y coordinates (set in `y` or auto-generated) and the M columns correspond to M x coordinates (set in `x` or auto-generated). By setting `transpose` to "true", the above behavior is flipped.
        /// </summary>
        /// <param name="zData">Sets the z data which is used for computing the contour lines.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="X">Sets the x coordinates.</param>
        /// <param name="MultiX">Sets the x coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Y">Sets the y coordinates.</param>
        /// <param name="MultiY">Sets the y coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorBar">Sets the styles of the colorbar for this trace.</param>
        /// <param name="ColorScale">Sets the colorscale for this trace.</param>
        /// <param name="ShowScale">Whether or not to show the colorscale/colorbar</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
        /// <param name="Transpose">Transposes the z data.</param>
        /// <param name="ContourLinesDash">Sets the contour line dash style</param>
        /// <param name="ContourLinesColor">Sets the contour line color</param>
        /// <param name="ContourLinesSmoothing">Sets the amount of smoothing for the contour lines, where "0" corresponds to no smoothing.</param>
        /// <param name="ContourLinesWidth">Sets the width of the contour lines</param>
        /// <param name="ContourLines">Sets the contour lines (use this for more finegrained control than the other contourline-associated arguments).</param>
        /// <param name="ShowContourLines">Wether or not to show the contour line</param>
        /// <param name="ContoursColoring">Determines the coloring method showing the contour values. If "fill", coloring is done evenly between each contour level If "heatmap", a heatmap gradient coloring is applied between each contour level. If "lines", coloring is done on the contour lines. If "none", no coloring is applied on this trace.</param>
        /// <param name="ContoursOperation">Sets the constraint operation. "=" keeps regions equal to `value` "&lt;" and "&lt;=" keep regions less than `value` "&gt;" and "&gt;=" keep regions greater than `value` "[]", "()", "[)", and "(]" keep regions inside `value[0]` to `value[1]` "][", ")(", "](", ")[" keep regions outside `value[0]` to value[1]` Open vs. closed intervals make no difference to constraint display, but all versions are allowed for consistency with filter transforms.</param>
        /// <param name="ContoursType">If `levels`, the data is represented as a contour plot with multiple levels displayed. If `constraint`, the data is represented as constraints with the invalid region shaded as specified by the `operation` and `value` parameters.</param>
        /// <param name="ShowContoursLabels">Determines whether to label the contour lines with their values.</param>
        /// <param name="ContoursLabelFont">Sets the font used for labeling the contour levels. The default color comes from the lines, if shown. The default family and size come from `layout.font`.</param>
        /// <param name="ContoursStart">Sets the starting contour level value. Must be less than `contours.end`</param>
        /// <param name="ContoursEnd">Sets the end contour level value. Must be more than `contours.start`</param>
        /// <param name="Contours">Sets the styles of the contours (use this for more finegrained control than the other contour-associated arguments).</param>
        /// <param name="FillColor">Sets the fill color if `contours.type` is "constraint". Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="NContours">Sets the maximum number of contour levels. The actual number of contours will be chosen automatically to be less than or equal to the value of `ncontours`. Has an effect only if `autocontour` is "true" or if `contours.size` is missing.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Contour
            (
                zData: seq<#seq<#IConvertible>>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?X: seq<#IConvertible>,
                ?MultiX: seq<seq<#IConvertible>>,
                ?Y: seq<#IConvertible>,
                ?MultiY: seq<seq<#IConvertible>>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ReverseScale: bool,
                ?Transpose: bool,
                ?ContourLinesColor: Color,
                ?ContourLinesDash: StyleParam.DrawingStyle,
                ?ContourLinesSmoothing: float,
                ?ContourLinesWidth: float,
                ?ContourLines: Line,
                ?ShowContourLines: bool,
                ?ContoursColoring: StyleParam.ContourColoring,
                ?ContoursOperation: StyleParam.ConstraintOperation,
                ?ContoursType: StyleParam.ContourType,
                ?ShowContoursLabels: bool,
                ?ContoursLabelFont: Font,
                ?ContoursStart: float,
                ?ContoursEnd: float,
                ?Contours: Contours,
                ?FillColor: Color,
                ?NContours: int,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let showContourLines =
                defaultArg ShowContourLines false

            let contourLinesWidth =
                ContourLinesWidth |> Option.map (fun v -> if showContourLines then v else 0.) |> Option.defaultValue 0.

            let contours =
                Contours
                |> Option.defaultValue (TraceObjects.Contours.init ())
                |> TraceObjects.Contours.style (
                    ?Coloring = ContoursColoring,
                    ?Operation = ContoursOperation,
                    ?Start = ContoursStart,
                    ?End = ContoursEnd,
                    ?Type = ContoursType,
                    ?ShowLabels = ShowContoursLabels,
                    ?LabelFont = ContoursLabelFont
                )

            let contourLines =
                ContourLines
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    Width = contourLinesWidth,
                    ?Color = ContourLinesColor,
                    ?Dash = ContourLinesDash,
                    ?Smoothing = ContourLinesSmoothing
                )

            Trace2D.initContour (
                Trace2DStyle.Contour(
                    Z = zData,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?X = X,
                    ?MultiX = MultiX,
                    ?Y = Y,
                    ?MultiY = MultiY,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?ColorBar = ColorBar,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ReverseScale = ReverseScale,
                    ?Transpose = Transpose,
                    ?FillColor = FillColor,
                    ?NContours = NContours,
                    Contours = contours,
                    Line = contourLines
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates an OHLC chart.
        ///
        /// The ohlc (short for Open-High-Low-Close) is a style of financial chart describing open, high, low and close for a given `x` coordinate (most likely time). The tip of the lines represent the `low` and `high` values and the horizontal segments represent the `open` and `close` values. Sample points where the close value is higher (lower) then the open value are called increasing (decreasing). By default, increasing items are drawn in green whereas decreasing are drawn in red.
        /// </summary>
        /// <param name="open">Sets the open values.</param>
        /// <param name="high">Sets the high values.</param>
        /// <param name="low">Sets the low values.</param>
        /// <param name="close">Sets the close values.</param>
        /// <param name="X">Sets the x coordinates. If absent, linear coordinate will be generated.</param>
        /// <param name="MultiX">Sets the x coordinates. If absent, linear coordinate will be generated. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="Line">Sets the line of this trace.</param>
        /// <param name="IncreasingColor">Sets the color of increasing values</param>
        /// <param name="Increasing">Sets the style options of increasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="DecreasingColor">Sets the color of decreasing values</param>
        /// <param name="Decreasing">Sets the style options of decreasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="TickWidth">Sets the width of the open/close tick marks relative to the "x" minimal interval.</param>
        /// <param name="ShowXAxisRangeSlider">Whether or not to show a rangeslider for the xaxis</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member OHLC
            (
                ``open``: #IConvertible seq,
                high: #IConvertible seq,
                low: #IConvertible seq,
                close: #IConvertible seq,
                ?X: seq<#IConvertible>,
                ?MultiX: seq<seq<#IConvertible>>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?Line: Line,
                ?IncreasingColor: Color,
                ?Increasing: FinanceMarker,
                ?DecreasingColor: Color,
                ?Decreasing: FinanceMarker,
                ?TickWidth: float,
                ?ShowXAxisRangeSlider: bool,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let increasing =
                Increasing
                |> Option.defaultValue (FinanceMarker.init ())
                |> FinanceMarker.style (?LineColor = IncreasingColor)

            let decreasing =
                Decreasing
                |> Option.defaultValue (FinanceMarker.init ())
                |> FinanceMarker.style (?LineColor = DecreasingColor)

            Trace2D.initOHLC (
                Trace2DStyle.OHLC(
                    Open = ``open``,
                    High = high,
                    Low = low,
                    Close = close,
                    ?X = X,
                    ?MultiX = MultiX,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?Line = Line,
                    Increasing = increasing,
                    Decreasing = decreasing,
                    ?TickWidth = TickWidth
                )
            )
            |> GenericChart.ofTraceObject useDefaults
            |> GenericChart.addLayout (
                Layout.init ()
                |> Layout.setLinearAxis (
                    id = StyleParam.SubPlotId.XAxis 1,
                    axis = LinearAxis.init (RangeSlider = RangeSlider.init (?Visible = ShowXAxisRangeSlider))
                )
            )

        /// <summary>
        /// Creates an OHLC chart.
        ///
        /// The ohlc (short for Open-High-Low-Close) is a style of financial chart describing open, high, low and close for a given `x` coordinate (most likely time). The tip of the lines represent the `low` and `high` values and the horizontal segments represent the `open` and `close` values. Sample points where the close value is higher (lower) then the open value are called increasing (decreasing). By default, increasing items are drawn in green whereas decreasing are drawn in red.
        /// </summary>
        /// <param name="open">Sets the open values.</param>
        /// <param name="high">Sets the high values.</param>
        /// <param name="low">Sets the low values.</param>
        /// <param name="close">Sets the close values.</param>
        /// <param name="x">Sets the x coordinates. If absent, linear coordinate will be generated.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="Line">Sets the line of this trace.</param>
        /// <param name="IncreasingColor">Sets the color of increasing values</param>
        /// <param name="Increasing">Sets the style options of increasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="DecreasingColor">Sets the color of decreasing values</param>
        /// <param name="Decreasing">Sets the style options of decreasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="TickWidth">Sets the width of the open/close tick marks relative to the "x" minimal interval.</param>
        /// <param name="ShowXAxisRangeSlider">Whether or not to show a rangeslider for the xaxis</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member OHLC
            (
                ``open``: #IConvertible seq,
                high: #IConvertible seq,
                low: #IConvertible seq,
                close: #IConvertible seq,
                x: #IConvertible seq,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?Line: Line,
                ?IncreasingColor: Color,
                ?Increasing: FinanceMarker,
                ?DecreasingColor: Color,
                ?Decreasing: FinanceMarker,
                ?TickWidth: float,
                ?ShowXAxisRangeSlider: bool,
                ?UseDefaults: bool
            ) =

            Chart.OHLC(
                ``open`` = ``open``,
                high = high,
                low = low,
                close = close,
                X = x,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?Line = Line,
                ?IncreasingColor = IncreasingColor,
                ?Increasing = Increasing,
                ?DecreasingColor = DecreasingColor,
                ?Decreasing = Decreasing,
                ?TickWidth = TickWidth,
                ?ShowXAxisRangeSlider = ShowXAxisRangeSlider,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates an OHLC chart.
        ///
        /// The ohlc (short for Open-High-Low-Close) is a style of financial chart describing open, high, low and close for a given `x` coordinate (most likely time). The tip of the lines represent the `low` and `high` values and the horizontal segments represent the `open` and `close` values. Sample points where the close value is higher (lower) then the open value are called increasing (decreasing). By default, increasing items are drawn in green whereas decreasing are drawn in red.
        /// </summary>
        /// <param name="stockTimeSeries">a series of (time,StockData), where StockData contains opwn, high, low and close values.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="Line">Sets the line of this trace.</param>
        /// <param name="IncreasingColor">Sets the color of increasing values</param>
        /// <param name="Increasing">Sets the style options of increasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="DecreasingColor">Sets the color of decreasing values</param>
        /// <param name="Decreasing">Sets the style options of decreasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="TickWidth">Sets the width of the open/close tick marks relative to the "x" minimal interval.</param>
        /// <param name="ShowXAxisRangeSlider">Whether or not to show a rangeslider for the xaxis</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member OHLC
            (
                stockTimeSeries: seq<System.DateTime * StockData>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?Line: Line,
                ?IncreasingColor: Color,
                ?Increasing: FinanceMarker,
                ?DecreasingColor: Color,
                ?Decreasing: FinanceMarker,
                ?TickWidth: float,
                ?ShowXAxisRangeSlider: bool,
                ?UseDefaults: bool
            ) =

            Chart.OHLC(
                ``open`` = (stockTimeSeries |> Seq.map (snd >> (fun x -> x.Open))),
                high = (stockTimeSeries |> Seq.map (snd >> (fun x -> x.High))),
                low = (stockTimeSeries |> Seq.map (snd >> (fun x -> x.Low))),
                close = (stockTimeSeries |> Seq.map (snd >> (fun x -> x.Close))),
                x = (stockTimeSeries |> Seq.map fst),
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?Line = Line,
                ?IncreasingColor = IncreasingColor,
                ?Increasing = Increasing,
                ?DecreasingColor = DecreasingColor,
                ?Decreasing = Decreasing,
                ?TickWidth = TickWidth,
                ?ShowXAxisRangeSlider = ShowXAxisRangeSlider,
                ?UseDefaults = UseDefaults
            )



        /// <summary>
        /// Creates a candlestick chart.
        ///
        /// The candlestick is a style of financial chart describing open, high, low and close for a given `x` coordinate (most likely time). The boxes represent the spread between the `open` and `close` values and the lines represent the spread between the `low` and `high` values Sample points where the close value is higher (lower) then the open value are called increasing (decreasing). By default, increasing candles are drawn in green whereas decreasing are drawn in red.
        /// </summary>
        /// <param name="open">Sets the open values.</param>
        /// <param name="high">Sets the high values.</param>
        /// <param name="low">Sets the low values.</param>
        /// <param name="close">Sets the close values.</param>
        /// <param name="X">Sets the x coordinates. If absent, linear coordinate will be generated.</param>
        /// <param name="MultiX">Sets the x coordinates. If absent, linear coordinate will be generated. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="Line">Sets the line of this trace.</param>
        /// <param name="IncreasingColor">Sets the color of increasing values</param>
        /// <param name="Increasing">Sets the style options of increasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="DecreasingColor">Sets the color of decreasing values</param>
        /// <param name="Decreasing">Sets the style options of decreasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="WhiskerWidth">Sets the width of the whiskers relative to the box' width. For example, with 1, the whiskers are as wide as the box(es).</param>
        /// <param name="ShowXAxisRangeSlider">Whether or not to show a rangeslider for the xaxis</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        static member Candlestick
            (
                ``open``: #IConvertible seq,
                high: #IConvertible seq,
                low: #IConvertible seq,
                close: #IConvertible seq,
                ?X: seq<#IConvertible>,
                ?MultiX: seq<seq<#IConvertible>>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?Line: Line,
                ?IncreasingColor: Color,
                ?Increasing: FinanceMarker,
                ?DecreasingColor: Color,
                ?Decreasing: FinanceMarker,
                ?WhiskerWidth: float,
                ?ShowXAxisRangeSlider: bool,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let increasing =
                Increasing
                |> Option.defaultValue (FinanceMarker.init ())
                |> FinanceMarker.style (?LineColor = IncreasingColor)

            let decreasing =
                Decreasing
                |> Option.defaultValue (FinanceMarker.init ())
                |> FinanceMarker.style (?LineColor = DecreasingColor)

            Trace2D.initCandlestick (
                Trace2DStyle.Candlestick(
                    Open = ``open``,
                    High = high,
                    Low = low,
                    Close = close,
                    ?X = X,
                    ?MultiX = MultiX,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?Line = Line,
                    Increasing = increasing,
                    Decreasing = decreasing,
                    ?WhiskerWidth = WhiskerWidth
                )
            )
            |> GenericChart.ofTraceObject useDefaults
            |> GenericChart.addLayout (
                Layout.init ()
                |> Layout.setLinearAxis (
                    id = StyleParam.SubPlotId.XAxis 1,
                    axis = LinearAxis.init (RangeSlider = RangeSlider.init (?Visible = ShowXAxisRangeSlider))
                )
            )

        /// <summary>
        /// Creates a candlestick chart.
        ///
        /// The candlestick is a style of financial chart describing open, high, low and close for a given `x` coordinate (most likely time). The boxes represent the spread between the `open` and `close` values and the lines represent the spread between the `low` and `high` values Sample points where the close value is higher (lower) then the open value are called increasing (decreasing). By default, increasing candles are drawn in green whereas decreasing are drawn in red.
        /// </summary>
        /// <param name="open">Sets the open values.</param>
        /// <param name="high">Sets the high values.</param>
        /// <param name="low">Sets the low values.</param>
        /// <param name="close">Sets the close values.</param>
        /// <param name="x">Sets the x coordinates. If absent, linear coordinate will be generated.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="Line">Sets the line of this trace.</param>
        /// <param name="IncreasingColor">Sets the color of increasing values</param>
        /// <param name="Increasing">Sets the style options of increasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="DecreasingColor">Sets the color of decreasing values</param>
        /// <param name="Decreasing">Sets the style options of decreasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="WhiskerWidth">Sets the width of the whiskers relative to the box' width. For example, with 1, the whiskers are as wide as the box(es).</param>
        /// <param name="ShowXAxisRangeSlider">Whether or not to show a rangeslider for the xaxis</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Candlestick
            (
                ``open``: #IConvertible seq,
                high: #IConvertible seq,
                low: #IConvertible seq,
                close: #IConvertible seq,
                x: #IConvertible seq,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?Line: Line,
                ?IncreasingColor: Color,
                ?Increasing: FinanceMarker,
                ?DecreasingColor: Color,
                ?Decreasing: FinanceMarker,
                ?WhiskerWidth: float,
                ?ShowXAxisRangeSlider: bool,
                ?UseDefaults: bool
            ) =

            Chart.Candlestick(
                ``open`` = ``open``,
                high = high,
                low = low,
                close = close,
                X = x,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?Line = Line,
                ?IncreasingColor = IncreasingColor,
                ?Increasing = Increasing,
                ?DecreasingColor = DecreasingColor,
                ?Decreasing = Decreasing,
                ?WhiskerWidth = WhiskerWidth,
                ?ShowXAxisRangeSlider = ShowXAxisRangeSlider,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a candlestick chart.
        ///
        /// The candlestick is a style of financial chart describing open, high, low and close for a given `x` coordinate (most likely time). The boxes represent the spread between the `open` and `close` values and the lines represent the spread between the `low` and `high` values Sample points where the close value is higher (lower) then the open value are called increasing (decreasing). By default, increasing candles are drawn in green whereas decreasing are drawn in red.
        /// </summary>
        /// <param name="stockTimeSeries">a series of (time,StockData), where StockData contains opwn, high, low and close values.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="Line">Sets the line of this trace.</param>
        /// <param name="IncreasingColor">Sets the color of increasing values</param>
        /// <param name="Increasing">Sets the style options of increasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="DecreasingColor">Sets the color of decreasing values</param>
        /// <param name="Decreasing">Sets the style options of decreasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="WhiskerWidth">Sets the width of the whiskers relative to the box' width. For example, with 1, the whiskers are as wide as the box(es).</param>
        /// <param name="ShowXAxisRangeSlider">Whether or not to show a rangeslider for the xaxis</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Candlestick
            (
                stockTimeSeries: seq<System.DateTime * StockData>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?Line: Line,
                ?IncreasingColor: Color,
                ?Increasing: FinanceMarker,
                ?DecreasingColor: Color,
                ?Decreasing: FinanceMarker,
                ?WhiskerWidth: float,
                ?ShowXAxisRangeSlider: bool,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            Chart.Candlestick(
                ``open`` = (stockTimeSeries |> Seq.map (snd >> (fun x -> x.Open))),
                high = (stockTimeSeries |> Seq.map (snd >> (fun x -> x.High))),
                low = (stockTimeSeries |> Seq.map (snd >> (fun x -> x.Low))),
                close = (stockTimeSeries |> Seq.map (snd >> (fun x -> x.Close))),
                x = (stockTimeSeries |> Seq.map fst),
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?Line = Line,
                ?IncreasingColor = IncreasingColor,
                ?Increasing = Increasing,
                ?DecreasingColor = DecreasingColor,
                ?Decreasing = Decreasing,
                ?WhiskerWidth = WhiskerWidth,
                ?ShowXAxisRangeSlider = ShowXAxisRangeSlider,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a scatter plot matrix (SPLOM) from multiple input dimensions.
        ///
        /// Each splom `dimensions` items correspond to a generated axis. Values for each of those dimensions are set in `dimensions[i].values`. Splom traces support all `scattergl` marker style attributes. Specify `layout.grid` attributes and/or layout x-axis and y-axis attributes for more control over the axis positioning and style.
        /// </summary>
        /// <param name="dimensions">Sets the dimensions of the scatter plot matrix, where each item corresponds to a generated axis.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="MarkerColor">Sets the color of the marker.</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker. Use `Color.fromColorScaleValues` to map marker colors to a colorscale.</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the symbol of all marker</param>
        /// <param name="MultiMarkerSymbol">Sets the symbol of each individual marker</param>
        /// <param name="Marker">Sets the markers (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="ShowDiagonal">Whether or not to show the matrix diagional</param>
        /// <param name="Diagonal">Sets the styles applied to the scatter plot matrix diagonal</param>
        /// <param name="ShowLowerHalf">Determines whether or not subplots on the lower half from the diagonal are displayed.</param>
        /// <param name="ShowUpperHalf">Determines whether or not subplots on the upper half from the diagonal are displayed.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Splom
            (
                dimensions: seq<Dimension>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?ShowDiagonal: bool,
                ?Diagonal: SplomDiagonal,
                ?ShowLowerHalf: bool,
                ?ShowUpperHalf: bool,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (
                    ?Color = MarkerColor,
                    ?Outline = MarkerOutline,
                    ?Symbol = MarkerSymbol,
                    ?MultiSymbol = MultiMarkerSymbol,
                    ?Colorscale = MarkerColorScale
                )

            let diagonal =
                Diagonal
                |> Option.defaultValue (TraceObjects.SplomDiagonal.init ())
                |> TraceObjects.SplomDiagonal.style (?Visible = ShowDiagonal)

            Trace2D.initSplom (
                Trace2DStyle.Splom(
                    Dimensions = dimensions,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    Marker = marker,
                    Diagonal = diagonal,
                    ?ShowLowerHalf = ShowLowerHalf,
                    ?ShowUpperHalf = ShowUpperHalf
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a scatter plot matrix (SPLOM) from multiple input dimensions.
        ///
        /// Each splom `dimensions` items correspond to a generated axis. Values for each of those dimensions are set in `dimensions[i].values`. Splom traces support all `scattergl` marker style attributes. Specify `layout.grid` attributes and/or layout x-axis and y-axis attributes for more control over the axis positioning and style.
        /// </summary>
        /// <param name="keyValues">Sets the dimensions of the scatter plot matrix as (dimensionKey,dimensionValues) pairs, where each such pair corresponds to a generated axis.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="MarkerColor">Sets the color of the marker.</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker. Use `Color.fromColorScaleValues` to map marker colors to a colorscale.</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the symbol of all marker</param>
        /// <param name="MultiMarkerSymbol">Sets the symbol of each individual marker</param>
        /// <param name="Marker">Sets the markers (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="ShowDiagonal">Whether or not to show the matrix diagional</param>
        /// <param name="Diagonal">Sets the styles applied to the scatter plot matrix diagonal</param>
        /// <param name="ShowLowerHalf">Determines whether or not subplots on the lower half from the diagonal are displayed.</param>
        /// <param name="ShowUpperHalf">Determines whether or not subplots on the upper half from the diagonal are displayed.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Splom
            (
                keyValues: seq<string * #seq<#IConvertible>>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol>,
                ?Marker: Marker,
                ?ShowDiagonal: bool,
                ?Diagonal: SplomDiagonal,
                ?ShowLowerHalf: bool,
                ?ShowUpperHalf: bool,
                ?UseDefaults: bool
            ) =

            let dims =
                keyValues |> Seq.map (fun (key, vals) -> Dimension.initSplom (Label = key, Values = vals))

            Chart.Splom(
                dims,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?ShowDiagonal = ShowDiagonal,
                ?Diagonal = Diagonal,
                ?ShowLowerHalf = ShowLowerHalf,
                ?ShowUpperHalf = ShowUpperHalf,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a point density plot - a combination of a Scatter plot and Histogram2DContour.
        ///
        /// Additionally to plotting the (x,y) data as points on a 2D plane, a density contour plot is computed by grouping a set of points specified by their x and y coordinates into bins, and applying a count aggregation function to compute the value to be used to compute contours.
        /// The sample data from which statistics are computed is set in `x` and `y` (where `x` and `y` represent marginal distributions, binning is set in `xbins` and `ybins` in this case). The resulting distribution is visualized as a contour plot.
        ///
        /// </summary>
        /// <param name="x">Sets the x coordinates of the plotted data as well as the sample data to be binned on the x axis.</param>
        /// <param name="y">Sets the y coordinates of the plotted data as well as the sample data to be binned on the y axis.</param>
        /// <param name="PointOpacity">Sets the opacity of the point trace.</param>
        /// <param name="PointMarkerColor">Sets the marker color of the point trace.</param>
        /// <param name="PointMarkerSymbol">Sets the marker symbol of the point trace.</param>
        /// <param name="PointMarkerSize">Sets the marker size of the point trace.</param>
        /// <param name="ContourLinesDash">Sets the contour line dash style</param>
        /// <param name="ContourLinesColor">Sets the contour line color</param>
        /// <param name="ContourLinesSmoothing">Sets the amount of smoothing for the contour lines, where "0" corresponds to no smoothing.</param>
        /// <param name="ContourLinesWidth">Sets the width of the contour lines</param>
        /// <param name="ContourLines">Sets the contour lines (use this for more finegrained control than the other contourline-associated arguments).</param>
        /// <param name="ShowContourLines">Wether or not to show the contour line</param>
        /// <param name="ContoursColoring">Determines the coloring method showing the contour values. If "fill", coloring is done evenly between each contour level If "heatmap", a heatmap gradient coloring is applied between each contour level. If "lines", coloring is done on the contour lines. If "none", no coloring is applied on this trace.</param>
        /// <param name="ContoursOperation">Sets the constraint operation. "=" keeps regions equal to `value` "&lt;" and "&lt;=" keep regions less than `value` "&gt;" and "&gt;=" keep regions greater than `value` "[]", "()", "[)", and "(]" keep regions inside `value[0]` to `value[1]` "][", ")(", "](", ")[" keep regions outside `value[0]` to value[1]` Open vs. closed intervals make no difference to constraint display, but all versions are allowed for consistency with filter transforms.</param>
        /// <param name="ContoursType">If `levels`, the data is represented as a contour plot with multiple levels displayed. If `constraint`, the data is represented as constraints with the invalid region shaded as specified by the `operation` and `value` parameters.</param>
        /// <param name="ShowContoursLabels">Determines whether to label the contour lines with their values.</param>
        /// <param name="ContoursLabelFont">Sets the font used for labeling the contour levels. The default color comes from the lines, if shown. The default family and size come from `layout.font`.</param>
        /// <param name="ContoursStart">Sets the starting contour level value. Must be less than `contours.end`</param>
        /// <param name="ContoursEnd">Sets the end contour level value. Must be more than `contours.start`</param>
        /// <param name="Contours">Sets the styles of the contours (use this for more finegrained control than the other contour-associated arguments).</param>
        /// <param name="NContours">Sets the maximum number of contour levels. The actual number of contours will be chosen automatically to be less than or equal to the value of `ncontours`. Has an effect only if `autocontour` is "true" or if `contours.size` is missing.</param>
        /// <param name="HistNorm">Specifies the type of normalization used for this histogram trace. If "", the span of each bar corresponds to the number of occurrences (i.e. the number of data points lying inside the bins). If "percent" / "probability", the span of each bar corresponds to the percentage / fraction of occurrences with respect to the total number of sample points (here, the sum of all bin HEIGHTS equals 100% / 1). If "density", the span of each bar corresponds to the number of occurrences in a bin divided by the size of the bin interval (here, the sum of all bin AREAS equals the total number of sample points). If "probability density", the area of each bar corresponds to the probability that an event will fall into the corresponding bin (here, the sum of all bin AREAS equals 1).</param>
        /// <param name="ContourOpacity">Sets the opacity of the histogram2dcontour trace.</param>
        /// <param name="ColorBar">Sets the color bar.</param>
        /// <param name="ColorScale">Sets the colorscale of the histogram2dcontour trace.</param>
        /// <param name="ShowScale">whether or not to show the colorbar</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member PointDensity
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                ?PointOpacity: float,
                ?PointMarkerColor: Color,
                ?PointMarkerSymbol: StyleParam.MarkerSymbol,
                ?PointMarkerSize: int,
                ?ContourLinesColor: Color,
                ?ContourLinesDash: StyleParam.DrawingStyle,
                ?ContourLinesSmoothing: float,
                ?ContourLinesWidth: float,
                ?ContourLines: Line,
                ?ShowContourLines: bool,
                ?ContoursColoring: StyleParam.ContourColoring,
                ?ContoursOperation: StyleParam.ConstraintOperation,
                ?ContoursType: StyleParam.ContourType,
                ?ShowContoursLabels: bool,
                ?ContoursLabelFont: Font,
                ?ContoursStart: float,
                ?ContoursEnd: float,
                ?Contours: Contours,
                ?NContours: int,
                ?HistNorm: StyleParam.HistNorm,
                ?ContourOpacity: float,
                ?ColorBar: ColorBar,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?UseDefaults: bool
            ) =

            let showContourLines =
                defaultArg ShowContourLines false

            let pointOpacity =
                defaultArg PointOpacity 0.3

            let contoursColoring =
                defaultArg ContoursColoring StyleParam.ContourColoring.Fill

            let useDefaults =
                defaultArg UseDefaults true

            let contourLinesWidth =
                ContourLinesWidth |> Option.map (fun v -> if showContourLines then v else 0.) |> Option.defaultValue 0.

            let marker =
                Marker.init (?Color = PointMarkerColor, ?Symbol = PointMarkerSymbol, ?Size = PointMarkerSize)

            let pointTrace =
                Trace2D.initScatter (
                    Trace2DStyle.Scatter(
                        X = x,
                        Y = y,
                        Mode = StyleParam.Mode.Markers,
                        Marker = marker,
                        Opacity = pointOpacity
                    )
                )

            let contourLines =
                ContourLines
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    Width = contourLinesWidth,
                    ?Color = ContourLinesColor,
                    ?Dash = ContourLinesDash,
                    ?Smoothing = ContourLinesSmoothing
                )

            let contours =
                Contours
                |> Option.defaultValue (TraceObjects.Contours.init ())
                |> TraceObjects.Contours.style (
                    Coloring = contoursColoring,
                    ?Operation = ContoursOperation,
                    ?Start = ContoursStart,
                    ?End = ContoursEnd,
                    ?Type = ContoursType,
                    ?ShowLabels = ShowContoursLabels,
                    ?LabelFont = ContoursLabelFont
                )

            let densityContourTrace =
                Trace2D.initHistogram2DContour (
                    Trace2DStyle.Histogram2DContour(
                        X = x,
                        Y = y,
                        Contours = contours,
                        Line = contourLines,
                        ?NContours = NContours,
                        ?ColorBar = ColorBar,
                        ?ColorScale = ColorScale,
                        ?ShowScale = ShowScale,
                        ?HistNorm = HistNorm,
                        ?Opacity = ContourOpacity
                    )
                )

            [
                densityContourTrace :> Trace
                pointTrace :> Trace
            ]
            |> GenericChart.ofTraceObjects useDefaults

        /// <summary> Creates a Pareto chart. </summary>
        /// <param name="keysValues">Sets the (key,value) pairs that are plotted as the size and key of each bar.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="Label">Sets the y axis label.</param>
        /// <param name="ShowGrid">Determines whether or not grid lines are drawn. If "true", the grid lines are drawn for the pareto distribution figure; defaults to true.</param>
        [<Extension>]
        static member Pareto
            (
                keysValues: seq<#IConvertible * float>
                , ?Name: string
                , ?Label: string
                , ?ShowGrid: bool
            ) =
            let orderedLabels, orderedValues =
                keysValues
                |> Seq.sortByDescending snd
                |> Seq.unzip
               
            let sum = orderedValues |> Seq.sum
            let topPaddingRatio = 0.05
            let cumulativeSum = 
                Seq.scan (+) 0. orderedValues
                |> Seq.skip 1
               
            let paretoValues = 
               Seq.zip orderedLabels cumulativeSum
               |> Seq.map (fun (label,value) -> label, value / sum * 100.) 
               
            let bars = Chart.Column(Seq.zip orderedLabels orderedValues,?Name=Name)
            
            let lines = 
                Chart.Line(
                    paretoValues
                    , Name        = "Cumulative %"
                    , ShowLegend  = true
                    , ShowMarkers = true
                    , Marker      = Marker.init(Size = 8, Symbol = StyleParam.MarkerSymbol.Cross, Angle = 45.)
                ) 
                |> Chart.withAxisAnchor (Y = 2)
                   
            [bars;lines] 
            |> Chart.combine 
            |> Chart.withYAxisStyle (
                    ?TitleText = Label
                    , Id       = StyleParam.SubPlotId.YAxis 1
                    , ShowGrid = false
                    , MinMax   = (0.,sum * (1.+topPaddingRatio))
                )
            |> Chart.withYAxisStyle (
                    TitleText    = "%"
                    , Side       = StyleParam.Side.Right
                    , Id         = StyleParam.SubPlotId.YAxis 2
                    , MinMax     = (0.,100. * (1.+topPaddingRatio))
                    , Overlaying = StyleParam.LinearAxisId.Y 1
                    , ?ShowGrid  = ShowGrid
                )     
            
        /// <summary> Creates a Pareto chart. </summary>
        /// <param name="labels">Sets the labels that are matching the <see paramref="values"/>.</param>
        /// <param name="values">Sets the values that are plotted as the size of each bar.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="Label">Sets the y axis label.</param>
        /// <param name="ShowGrid">Determines whether or not grid lines are drawn. If "true", the grid lines are drawn for the pareto distribution figure; defaults to true.</param>
        static member Pareto
            (
                labels: seq<#IConvertible>
                , values: seq<float>
                , ?Name: string
                , ?Label: string
                , ?ShowGrid: bool
            ) =
            Chart.Pareto(Seq.zip labels values, ?Name=Name, ?Label=Label, ?ShowGrid=ShowGrid)