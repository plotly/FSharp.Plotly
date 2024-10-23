namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Plotly.NET.ConfigObjects

open DynamicObj
open System
open System.IO
open Giraffe.ViewEngine
open System.Runtime.InteropServices

/// Provides a set of static methods for creating and styling charts.
type Chart =

    //==============================================================================================================
    //================================================ Core methods ================================================
    //==============================================================================================================

    /// <summary>
    /// Saves the given Chart as html file at the given path (.html file extension is added if not present).
    /// Optionally opens the generated file in the browser.
    /// </summary>
    /// <param name="path">The path to save the chart html at.</param>
    /// <param name="OpenInBrowser">Whether or not to open the generated file in the browser (default: false)</param>
    static member saveHtml(path: string, ?OpenInBrowser: bool) =
        fun (ch: GenericChart) ->
            let show = defaultArg OpenInBrowser false

            let html = GenericChart.toEmbeddedHTML ch

            let file =
                if path.EndsWith(".html") then
                    path
                else
                    $"{path}.html"

            File.WriteAllText(file, html)

            if show then
                file |> openOsSpecificFile

    /// <summary>
    /// Saves the given chart as a temporary html file and opens it in the browser.
    /// </summary>
    /// <param name="ch">The chart to show in the browser</param>
    static member show(ch: GenericChart) =
        let guid = Guid.NewGuid().ToString()
        let tempPath = Path.GetTempPath()
        let file = sprintf "%s.html" guid
        let path = Path.Combine(tempPath, file)
        ch |> Chart.saveHtml (path, true)

    // #######################
    /// Create a combined chart with the given charts merged
    static member combine(gCharts: seq<GenericChart>) = GenericChart.combine gCharts

    //==============================================================================================================
    //============================================= Unspecific charts ==============================================
    //==============================================================================================================

    /// <summary>Creates a chart that is completely invisible when rendered. The Chart object however is NOT empty! Combining this chart with other charts will have unforseen consequences (it has for example invisible axes that can override other axes if used in Chart.Combine)</summary>
    static member Invisible() =
        let hiddenAxis () =
            LinearAxis.init (ShowGrid = false, ShowLine = false, ShowTickLabels = false, ZeroLine = false)

        let trace = Trace2D.initScatter (id)
        trace.RemoveProperty("type") |> ignore

        GenericChart.ofTraceObject false trace
        |> GenericChart.mapLayout (fun l ->
            l
            |> Layout.setLinearAxis (StyleParam.SubPlotId.XAxis 1, hiddenAxis ())
            |> Layout.setLinearAxis (StyleParam.SubPlotId.YAxis 1, hiddenAxis ()))

    //==============================================================================================================
    //======================================== General Trace object styling ========================================
    //==============================================================================================================

    /// <summary>
    /// Sets trace information on the given chart.
    /// </summary>
    /// <param name="Name">Sets the name of the chart's trace(s). When the chart is a multichart (it contains multiple traces), the name is suffixed by '_%i' where %i is the index of the trace.</param>
    /// <param name="Visible">Whether or not the chart's traces are visible</param>
    /// <param name="ShowLegend">Determines whether or not item(s) corresponding to this chart's trace(s) is/are shown in the legend.</param>
    /// <param name="LegendRank">Sets the legend rank for the chart's trace(s). Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for the chart's trace(s). Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the title for the chart's trace legend group </param>
    static member withTraceInfo
        (
            ?Name: string,
            ?Visible: StyleParam.Visible,
            ?ShowLegend: bool,
            ?LegendRank: int,
            ?LegendGroup: string,
            ?LegendGroupTitle: Title
        ) =
        fun (ch: GenericChart) ->
            ch
            |> GenericChart.mapiTrace (fun i trace ->
                let naming i name =
                    name |> Option.map (fun v -> if i = 0 then v else sprintf "%s_%i" v i)

                trace
                |> TraceStyle.TraceInfo(
                    ?Name = (naming i Name),
                    ?Visible = Visible,
                    ?ShowLegend = ShowLegend,
                    ?LegendRank = LegendRank,
                    ?LegendGroup = LegendGroup,
                    ?LegendGroupTitle = LegendGroupTitle

                ))

    /// <summary>
    /// Sets the axis anchor ids for the chart's cartesian and/or carpet trace(s).
    ///
    /// If the traces are not of these types, nothing will be set and a warning message will be displayed.
    /// </summary>
    /// <param name="X">The new x axis anchor id for the chart's cartesian and/or carpet trace(s)</param>
    /// <param name="Y">The new x axis anchor id for the chart's cartesian and/or carpet trace(s)</param>
    static member withAxisAnchor
        (
            ?X,
            ?Y
        ) =
        let idx =
            X |> Option.map StyleParam.LinearAxisId.X

        let idy =
            Y |> Option.map StyleParam.LinearAxisId.Y

        fun (ch: GenericChart) ->
            ch
            |> GenericChart.mapTrace (fun trace ->
                match trace with
                | :? Trace2D as trace -> trace |> Trace2DStyle.SetAxisAnchor(?X = idx, ?Y = idy) :> Trace
                | :? TraceCarpet as trace when trace.``type`` = "carpet" ->
                    trace |> TraceCarpetStyle.SetAxisAnchor(?X = idx, ?Y = idy) :> Trace
                | _ ->
                    printfn "the input was not a 2D cartesian or carpet trace. no axis anchors set."
                    trace)

    /// <summary>
    /// Sets the color axis id for the chart's trace(s).
    /// </summary>
    /// <param name="id">The new color axis id for the chart's trace(s)</param>
    static member withColorAxisAnchor(id: int) =
        fun (ch: GenericChart) -> ch |> GenericChart.mapTrace (Trace.setColorAxisAnchor id)

    /// <summary>
    /// Sets the legend id for the chart's trace(s).
    /// </summary>
    /// <param name="id">The new Legend id for the chart's trace(s)</param>
    static member withLegendAnchor(id: int) =
        fun (ch: GenericChart) -> ch |> GenericChart.mapTrace (Trace.setLegendAnchor id)

    /// <summary>
    /// Sets the marker for the chart's trace(s).
    /// </summary>
    /// <param name="marker">The new marker for the chart's trace(s)</param>
    /// <param name="Combine">Whether or not to combine the objects if there is already a marker (default is false)</param>
    static member setMarker(marker: Marker, ?Combine: bool) =
        let combine = defaultArg Combine false

        (fun (ch: GenericChart) ->
            if combine then
                ch |> GenericChart.mapTrace (Trace.updateMarker marker)
            else
                ch |> GenericChart.mapTrace (Trace.setMarker marker))

    /// <summary>
    /// Sets the marker for the chart's trace(s).
    ///
    /// If there is already a marker set, the objects are combined.
    /// </summary>
    /// <param name="marker">The new marker for the chart's trace(s)</param>
    static member withMarker(marker: Marker) =
        (fun (ch: GenericChart) -> ch |> Chart.setMarker (marker, true))

    /// <summary>
    /// Applies the given styles to the marker object(s) of the chart's trace(s). Overwrites attributes with the same name that are already set.
    /// </summary>
    /// <param name="Angle">Sets the marker angle in respect to `angleref`.</param>
    /// <param name="AngleRef">Sets the reference for marker angle. With "previous", angle 0 points along the line from the previous point to this one. With "up", angle 0 points toward the top of the screen.</param>
    /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `marker.colorscale`. Has an effect only if in `marker.color`is set to a numerical array. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
    /// <param name="CAuto">Determines whether or not the color domain is computed with respect to the input data (here in `marker.color`) or the bounds set in `marker.cmin` and `marker.cmax` Has an effect only if in `marker.color`is set to a numerical array. Defaults to `false` when `marker.cmin` and `marker.cmax` are set by the user.</param>
    /// <param name="CMax">Sets the upper bound of the color domain. Has an effect only if in `marker.color`is set to a numerical array. Value should have the same units as in `marker.color` and if set, `marker.cmin` must be set as well.</param>
    /// <param name="CMid">Sets the mid-point of the color domain by scaling `marker.cmin` and/or `marker.cmax` to be equidistant to this point. Has an effect only if in `marker.color`is set to a numerical array. Value should have the same units as in `marker.color`. Has no effect when `marker.cauto` is `false`.</param>
    /// <param name="CMin">Sets the lower bound of the color domain. Has an effect only if in `marker.color`is set to a numerical array. Value should have the same units as in `marker.color` and if set, `marker.cmax` must be set as well.</param>
    /// <param name="Color">Sets the marker color. It accepts either a specific color or an array of numbers that are mapped to the colorscale relative to the max and min values of the array or relative to `marker.cmin` and `marker.cmax` if set.</param>
    /// <param name="Colors">Sets the color of each sector. If not specified, the default trace color set is used to pick the sector colors.</param>
    /// <param name="ColorAxis">Sets a reference to a shared color axis. References to these shared color axes are "coloraxis", "coloraxis2", "coloraxis3", etc. Settings for these shared color axes are set in the layout, under `layout.coloraxis`, `layout.coloraxis2`, etc. Note that multiple color scales can be linked to the same color axis.</param>
    /// <param name="ColorBar">Sets the marker's color bar.</param>
    /// <param name="Colorscale">Sets the colorscale. Has an effect only if colors is set to a numerical array. The colorscale must be an array containing arrays mapping a normalized value to an rgb, rgba, hex, hsl, hsv, or named color string. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 'rgb(0,0,255)'], [1, 'rgb(255,0,0)']]`. To control the bounds of the colorscale in color space, use `marker.cmin` and `marker.cmax`. Alternatively, `colorscale` may be a palette name string of the following list: Blackbody,Bluered,Blues,Cividis,Earth,Electric,Greens,Greys,Hot,Jet,Picnic,Portland,Rainbow,RdBu,Reds,Viridis,YlGnBu,YlOrRd.</param>
    /// <param name="CornerRadius">Sets the maximum rounding of corners (in px).</param>
    /// <param name="Gradient">Sets the marker's gradient</param>
    /// <param name="Outline">Sets the marker's outline.</param>
    /// <param name="Opacity">Sets the marker opacity.</param>
    /// <param name="MaxDisplayed">Sets a maximum number of points to be drawn on the graph. "0" corresponds to no limit.</param>
    /// <param name="MultiOpacity">Sets the individual marker opacity.</param>
    /// <param name="Pattern">Sets the pattern within the marker.</param>
    /// <param name="ReverseScale">Reverses the color mapping if true. Has an effect only if in `marker.color`is set to a numerical array. If true, `marker.cmin` will correspond to the last color in the array and `marker.cmax` will correspond to the first color.</param>
    /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace. Has an effect only if in `marker.color`is set to a numerical array.</param>
    /// <param name="Size">Sets the marker's size.</param>
    /// <param name="MultiSize">Sets the individual marker's size.</param>
    /// <param name="SizeMin">Has an effect only if `marker.size` is set to a numerical array. Sets the minimum size (in px) of the rendered marker points.</param>
    /// <param name="SizeMode">Has an effect only if `marker.size` is set to a numerical array. Sets the rule for which the data in `size` is converted to pixels.</param>
    /// <param name="SizeRef">Has an effect only if `marker.size` is set to a numerical array. Sets the scale factor used to determine the rendered size of marker points. Use with `sizemin` and `sizemode`.</param>
    /// <param name="StandOff">Moves the marker away from the data point in the direction of `angle` (in px). This can be useful for example if you have another marker at this location and you want to point an arrowhead marker at it.</param>
    /// <param name="MultiStandOff">Moves the marker away from the data point in the direction of `angle` (in px). This can be useful for example if you have another marker at this location and you want to point an arrowhead marker at it.</param>
    /// <param name="Symbol">Sets the marker symbol.</param>
    /// <param name="MultiSymbol">Sets the individual marker symbols.</param>
    /// <param name="Symbol3D">Sets the marker symbol for 3d traces.</param>
    /// <param name="MultiSymbol3D">Sets the individual marker symbols for 3d traces.</param>
    /// <param name="OutlierColor">Sets the color of the outlier sample points.</param>
    /// <param name="OutlierWidth">Sets the width of the outlier sample points.</param>
    static member withMarkerStyle
        (
            ?Angle: float,
            ?AngleRef: StyleParam.AngleRef,
            ?AutoColorScale: bool,
            ?CAuto: bool,
            ?CMax: float,
            ?CMid: float,
            ?CMin: float,
            ?Color: Color,
            ?Colors: seq<Color>,
            ?ColorAxis: StyleParam.SubPlotId,
            ?ColorBar: ColorBar,
            ?Colorscale: StyleParam.Colorscale,
            ?CornerRadius: int,
            ?Gradient: Gradient,
            ?Outline: Line,
            ?MaxDisplayed: int,
            ?Opacity: float,
            ?MultiOpacity: seq<float>,
            ?Pattern: Pattern,
            ?ReverseScale: bool,
            ?ShowScale: bool,
            ?Size: int,
            ?MultiSize: seq<int>,
            ?SizeMin: int,
            ?SizeMode: StyleParam.MarkerSizeMode,
            ?SizeRef: int,
            ?StandOff: float,
            ?MultiStandOff: seq<float>,
            ?Symbol: StyleParam.MarkerSymbol,
            ?MultiSymbol: seq<StyleParam.MarkerSymbol>,
            ?Symbol3D: StyleParam.MarkerSymbol3D,
            ?MultiSymbol3D: seq<StyleParam.MarkerSymbol3D>,
            ?OutlierColor: Color,
            ?OutlierWidth: int
        ) =
        fun (ch: GenericChart) ->
            ch
            |> GenericChart.mapTrace (
                TraceStyle.Marker(
                    ?Angle = Angle,
                    ?AngleRef = AngleRef,
                    ?AutoColorScale = AutoColorScale,
                    ?CAuto = CAuto,
                    ?CMax = CMax,
                    ?CMid = CMid,
                    ?CMin = CMin,
                    ?Color = Color,
                    ?Colors = Colors,
                    ?ColorAxis = ColorAxis,
                    ?ColorBar = ColorBar,
                    ?Colorscale = Colorscale,
                    ?CornerRadius = CornerRadius,
                    ?Gradient = Gradient,
                    ?Outline = Outline,
                    ?Size = Size,
                    ?MultiSize = MultiSize,
                    ?Opacity = Opacity,
                    ?Pattern = Pattern,
                    ?MultiOpacity = MultiOpacity,
                    ?Symbol = Symbol,
                    ?MultiSymbol = MultiSymbol,
                    ?Symbol3D = Symbol3D,
                    ?MultiSymbol3D = MultiSymbol3D,
                    ?OutlierColor = OutlierColor,
                    ?OutlierWidth = OutlierWidth,
                    ?MaxDisplayed = MaxDisplayed,
                    ?ReverseScale = ReverseScale,
                    ?ShowScale = ShowScale,
                    ?SizeMin = SizeMin,
                    ?SizeMode = SizeMode,
                    ?SizeRef = SizeRef,
                    ?StandOff = StandOff,
                    ?MultiStandOff = MultiStandOff
                )
            )

    /// <summary>
    /// Sets the line for the chart's trace(s).
    /// </summary>
    /// <param name="line">The new Line for the chart's trace(s)</param>
    /// <param name="Combine">Whether or not to combine the objects if there is already a Line (default is false)</param>
    static member setLine(line: Line, ?Combine: bool) =
        let combine = defaultArg Combine false

        (fun (ch: GenericChart) ->
            if combine then
                ch |> GenericChart.mapTrace (Trace.updateLine line)
            else
                ch |> GenericChart.mapTrace (Trace.setLine line))

    /// <summary>
    /// Sets the line for the chart's trace(s).
    ///
    /// If there is already a Line set, the objects are combined.
    /// </summary>
    /// <param name="line">The new line for the chart's trace(s)</param>
    static member withLine(line: Line) =
        (fun (ch: GenericChart) -> ch |> Chart.setLine (line, true))

    /// <summary>
    /// Applies the given styles to the line object(s) of the chart's trace(s). Overwrites attributes with the same name that are already set.
    /// </summary>
    /// <param name="BackOff">Sets the line back off from the end point of the nth line segment (in px). This option is useful e.g. to avoid overlap with arrowhead markers. With "auto" the lines would trim before markers if `marker.angleref` is set to "previous".</param>
    /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `line.colorscale`. Has an effect only if in `line.color`is set to a numerical array. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
    /// <param name="CAuto">Determines whether or not the color domain is computed with respect to the input data (here in `line.color`) or the bounds set in `line.cmin` and `line.cmax` Has an effect only if in `line.color`is set to a numerical array. Defaults to `false` when `line.cmin` and `line.cmax` are set by the user.</param>
    /// <param name="CMax">Sets the upper bound of the color domain. Has an effect only if in `line.color`is set to a numerical array. Value should have the same units as in `line.color` and if set, `line.cmin` must be set as well.</param>
    /// <param name="CMid">Sets the mid-point of the color domain by scaling `line.cmin` and/or `line.cmax` to be equidistant to this point. Has an effect only if in `line.color`is set to a numerical array. Value should have the same units as in `line.color`. Has no effect when `line.cauto` is `false`.</param>
    /// <param name="CMin">Sets the lower bound of the color domain. Has an effect only if in `line.color`is set to a numerical array. Value should have the same units as in `line.color` and if set, `line.cmax` must be set as well.</param>
    /// <param name="Color">Sets the line color.</param>
    /// <param name="ColorAxis">Sets a reference to a shared color axis. References to these shared color axes are "coloraxis", "coloraxis2", "coloraxis3", etc. Settings for these shared color axes are set in the layout, under `layout.coloraxis`, `layout.coloraxis2`, etc. Note that multiple color scales can be linked to the same color axis.</param>
    /// <param name="Colorscale">Sets the line colorscale</param>
    /// <param name="ReverseScale">Reverses the color mapping if true.</param>
    /// <param name="ShowScale">Whether or not to show the color bar</param>
    /// <param name="ColorBar">Sets the colorbar.</param>
    /// <param name="Dash">Sets the dash style of lines. Set to a dash type string ("solid", "dot", "dash", "longdash", "dashdot", or "longdashdot") or a dash length list in px (eg "5px,10px,2px,2px").</param>
    /// <param name="Shape">Determines the line shape. With "spline" the lines are drawn using spline interpolation. The other available values correspond to step-wise line shapes.</param>
    /// <param name="Simplify">Simplifies lines by removing nearly-collinear points. When transitioning lines, it may be desirable to disable this so that the number of points along the resulting SVG path is unaffected.</param>
    /// <param name="Smoothing">Has an effect only if `shape` is set to "spline" Sets the amount of smoothing. "0" corresponds to no smoothing (equivalent to a "linear" shape).</param>
    /// <param name="Width">Sets the line width (in px).</param>
    /// <param name="MultiWidth">Sets the individual line width (in px).</param>
    /// <param name="OutlierColor">Sets the color of the outline of outliers</param>
    /// <param name="OutlierWidth">Sets the width of the outline of outliers</param>
    static member withLineStyle
        (
            ?BackOff: StyleParam.BackOff,
            ?AutoColorScale: bool,
            ?CAuto: bool,
            ?CMax: float,
            ?CMid: float,
            ?CMin: float,
            ?Color: Color,
            ?ColorAxis: StyleParam.SubPlotId,
            ?Colorscale: StyleParam.Colorscale,
            ?ReverseScale: bool,
            ?ShowScale: bool,
            ?ColorBar: ColorBar,
            ?Dash: StyleParam.DrawingStyle,
            ?Shape: StyleParam.Shape,
            ?Simplify: bool,
            ?Smoothing: float,
            ?Width: float,
            ?MultiWidth: seq<float>,
            ?OutlierColor: Color,
            ?OutlierWidth: float
        ) =
        fun (ch: GenericChart) ->
            ch
            |> GenericChart.mapTrace (
                TraceStyle.Line(
                    ?BackOff = BackOff,
                    ?AutoColorScale = AutoColorScale,
                    ?CAuto = CAuto,
                    ?CMax = CMax,
                    ?CMid = CMid,
                    ?CMin = CMin,
                    ?Color = Color,
                    ?ColorAxis = ColorAxis,
                    ?Colorscale = Colorscale,
                    ?ReverseScale = ReverseScale,
                    ?ShowScale = ShowScale,
                    ?ColorBar = ColorBar,
                    ?Dash = Dash,
                    ?Shape = Shape,
                    ?Simplify = Simplify,
                    ?Smoothing = Smoothing,
                    ?Width = Width,
                    ?MultiWidth = MultiWidth,
                    ?OutlierColor = OutlierColor,
                    ?OutlierWidth = OutlierWidth
                )
            )

    /// <summary>
    /// Sets the error for the x dimension for the chart's trace(s).
    /// </summary>
    /// <param name="xError">The new Error in the x dimension for the chart's trace(s)</param>
    /// <param name="Combine">Whether or not to combine the objects if there is already an Error object set (default is false)</param>
    static member setXError(xError: Error, ?Combine: bool) =
        let combine = defaultArg Combine false

        (fun (ch: GenericChart) ->
            if combine then
                ch |> GenericChart.mapTrace (Trace.updateXError xError)
            else
                ch |> GenericChart.mapTrace (Trace.setXError xError))

    /// <summary>
    /// Sets the error in the x dimension for the chart's trace(s).
    ///
    /// If there is already an error set, the objects are combined.
    /// </summary>
    /// <param name="xError">The new error for the chart's trace(s)</param>
    static member withXError(xError: Error) =
        (fun (ch: GenericChart) -> ch |> Chart.setXError (xError, true))

    /// <summary>
    /// Applies the given styles to the error object(s) in the x dimension of the chart's trace(s). Overwrites attributes with the same name that are already set.
    /// </summary>
    /// <param name ="Visible">Determines whether or not this set of error bars is visible.</param>
    /// <param name ="Type">Determines the rule used to generate the error bars. If "constant`, the bar lengths are of a constant value. Set this constant in `value`. If "percent", the bar lengths correspond to a percentage of underlying data. Set this percentage in `value`. If "sqrt", the bar lengths correspond to the square of the underlying data. If "data", the bar lengths are set with data set `array`.</param>
    /// <param name ="Symmetric">Determines whether or not the error bars have the same length in both direction (top/bottom for vertical bars, left/right for horizontal bars.</param>
    /// <param name ="Array">Sets the data corresponding the length of each error bar. Values are plotted relative to the underlying data.</param>
    /// <param name ="Arrayminus">Sets the data corresponding the length of each error bar in the bottom (left) direction for vertical (horizontal) bars Values are plotted relative to the underlying data.</param>
    /// <param name ="Value">Sets the value of either the percentage (if `type` is set to "percent") or the constant (if `type` is set to "constant") corresponding to the lengths of the error bars.</param>
    /// <param name ="Valueminus">Sets the value of either the percentage (if `type` is set to "percent") or the constant (if `type` is set to "constant") corresponding to the lengths of the error bars in the bottom (left) direction for vertical (horizontal) bars</param>
    /// <param name ="Traceref"></param>
    /// <param name ="Tracerefminus"></param>
    /// <param name ="Copy_ystyle"></param>
    /// <param name ="Color">Sets the stoke color of the error bars.</param>
    /// <param name ="Thickness">Sets the thickness (in px) of the error bars.</param>
    /// <param name ="Width">Sets the width (in px) of the cross-bar at both ends of the error bars.</param>
    static member withXErrorStyle
        (
            ?Visible: bool,
            ?Type: StyleParam.ErrorType,
            ?Symmetric: bool,
            ?Array: seq<#IConvertible>,
            ?Arrayminus: seq<#IConvertible>,
            ?Value: float,
            ?Valueminus: float,
            ?Traceref: int,
            ?Tracerefminus: int,
            ?Copy_ystyle: bool,
            ?Color: Color,
            ?Thickness: float,
            ?Width: float
        ) =
        fun (ch: GenericChart) ->
            ch
            |> GenericChart.mapTrace (
                TraceStyle.XError(
                    ?Visible = Visible,
                    ?Type = Type,
                    ?Symmetric = Symmetric,
                    ?Array = Array,
                    ?Arrayminus = Arrayminus,
                    ?Value = Value,
                    ?Valueminus = Valueminus,
                    ?Traceref = Traceref,
                    ?Tracerefminus = Tracerefminus,
                    ?Copy_ystyle = Copy_ystyle,
                    ?Color = Color,
                    ?Thickness = Thickness,
                    ?Width = Width
                )
            )

    /// <summary>
    /// Sets the error for the y dimension for the chart's trace(s).
    /// </summary>
    /// <param name="yError">The new Error in the x dimension for the chart's trace(s)</param>
    /// <param name="Combine">Whether or not to combine the objects if there is already an Error object set (default is false)</param>
    static member setYError(yError: Error, ?Combine: bool) =
        let combine = defaultArg Combine false

        (fun (ch: GenericChart) ->
            if combine then
                ch |> GenericChart.mapTrace (Trace.updateYError yError)
            else
                ch |> GenericChart.mapTrace (Trace.setYError yError))

    /// <summary>
    /// Sets the error in the y dimension for the chart's trace(s).
    ///
    /// If there is already an error set, the objects are combined.
    /// </summary>
    /// <param name="yError">The new error for the chart's trace(s)</param>
    static member withYError(yError: Error) =
        (fun (ch: GenericChart) -> ch |> Chart.setYError (yError, true))

    /// <summary>
    /// Applies the given styles to the error object(s) in the y dimension of the chart's trace(s). Overwrites attributes with the same name that are already set.
    /// </summary>
    /// <param name ="Visible">Determines whether or not this set of error bars is visible.</param>
    /// <param name ="Type">Determines the rule used to generate the error bars. If "constant`, the bar lengths are of a constant value. Set this constant in `value`. If "percent", the bar lengths correspond to a percentage of underlying data. Set this percentage in `value`. If "sqrt", the bar lengths correspond to the square of the underlying data. If "data", the bar lengths are set with data set `array`.</param>
    /// <param name ="Symmetric">Determines whether or not the error bars have the same length in both direction (top/bottom for vertical bars, left/right for horizontal bars.</param>
    /// <param name ="Array">Sets the data corresponding the length of each error bar. Values are plotted relative to the underlying data.</param>
    /// <param name ="Arrayminus">Sets the data corresponding the length of each error bar in the bottom (left) direction for vertical (horizontal) bars Values are plotted relative to the underlying data.</param>
    /// <param name ="Value">Sets the value of either the percentage (if `type` is set to "percent") or the constant (if `type` is set to "constant") corresponding to the lengths of the error bars.</param>
    /// <param name ="Valueminus">Sets the value of either the percentage (if `type` is set to "percent") or the constant (if `type` is set to "constant") corresponding to the lengths of the error bars in the bottom (left) direction for vertical (horizontal) bars</param>
    /// <param name ="Traceref"></param>
    /// <param name ="Tracerefminus"></param>
    /// <param name ="Copy_ystyle"></param>
    /// <param name ="Color">Sets the stoke color of the error bars.</param>
    /// <param name ="Thickness">Sets the thickness (in px) of the error bars.</param>
    /// <param name ="Width">Sets the width (in px) of the cross-bar at both ends of the error bars.</param>
    static member withYErrorStyle
        (
            ?Visible: bool,
            ?Type: StyleParam.ErrorType,
            ?Symmetric: bool,
            ?Array: seq<#IConvertible>,
            ?Arrayminus: seq<#IConvertible>,
            ?Value: float,
            ?Valueminus: float,
            ?Traceref: int,
            ?Tracerefminus: int,
            ?Copy_ystyle: bool,
            ?Color: Color,
            ?Thickness: float,
            ?Width: float
        ) =
        fun (ch: GenericChart) ->
            ch
            |> GenericChart.mapTrace (
                TraceStyle.YError(
                    ?Visible = Visible,
                    ?Type = Type,
                    ?Symmetric = Symmetric,
                    ?Array = Array,
                    ?Arrayminus = Arrayminus,
                    ?Value = Value,
                    ?Valueminus = Valueminus,
                    ?Traceref = Traceref,
                    ?Tracerefminus = Tracerefminus,
                    ?Copy_ystyle = Copy_ystyle,
                    ?Color = Color,
                    ?Thickness = Thickness,
                    ?Width = Width
                )
            )

    /// <summary>
    /// Sets the error for the z dimension for the chart's trace(s).
    /// </summary>
    /// <param name="zError">The new Error in the x dimension for the chart's trace(s)</param>
    /// <param name="Combine">Whether or not to combine the objects if there is already an Error object set (default is false)</param>
    static member setZError(zError: Error, ?Combine: bool) =
        let combine = defaultArg Combine false

        (fun (ch: GenericChart) ->
            if combine then
                ch |> GenericChart.mapTrace (Trace.updateZError zError)
            else
                ch |> GenericChart.mapTrace (Trace.setZError zError))

    /// <summary>
    /// Sets the error in the z dimension for the chart's trace(s).
    ///
    /// If there is already an error set, the objects are combined.
    /// </summary>
    /// <param name="zError">The new error for the chart's trace(s)</param>
    static member withZError(zError: Error) =
        (fun (ch: GenericChart) -> ch |> Chart.setZError (zError, true))

    /// <summary>
    /// Applies the given styles to the error object(s) in the z dimension of the chart's trace(s). Overwrites attributes with the same name that are already set.
    /// </summary>
    /// <param name ="Visible">Determines whether or not this set of error bars is visible.</param>
    /// <param name ="Type">Determines the rule used to generate the error bars. If "constant`, the bar lengths are of a constant value. Set this constant in `value`. If "percent", the bar lengths correspond to a percentage of underlying data. Set this percentage in `value`. If "sqrt", the bar lengths correspond to the square of the underlying data. If "data", the bar lengths are set with data set `array`.</param>
    /// <param name ="Symmetric">Determines whether or not the error bars have the same length in both direction (top/bottom for vertical bars, left/right for horizontal bars.</param>
    /// <param name ="Array">Sets the data corresponding the length of each error bar. Values are plotted relative to the underlying data.</param>
    /// <param name ="Arrayminus">Sets the data corresponding the length of each error bar in the bottom (left) direction for vertical (horizontal) bars Values are plotted relative to the underlying data.</param>
    /// <param name ="Value">Sets the value of either the percentage (if `type` is set to "percent") or the constant (if `type` is set to "constant") corresponding to the lengths of the error bars.</param>
    /// <param name ="Valueminus">Sets the value of either the percentage (if `type` is set to "percent") or the constant (if `type` is set to "constant") corresponding to the lengths of the error bars in the bottom (left) direction for vertical (horizontal) bars</param>
    /// <param name ="Traceref"></param>
    /// <param name ="Tracerefminus"></param>
    /// <param name ="Copy_ystyle"></param>
    /// <param name ="Color">Sets the stoke color of the error bars.</param>
    /// <param name ="Thickness">Sets the thickness (in px) of the error bars.</param>
    /// <param name ="Width">Sets the width (in px) of the cross-bar at both ends of the error bars.</param>
    static member withZErrorStyle
        (
            ?Visible: bool,
            ?Type: StyleParam.ErrorType,
            ?Symmetric: bool,
            ?Array: seq<#IConvertible>,
            ?Arrayminus: seq<#IConvertible>,
            ?Value: float,
            ?Valueminus: float,
            ?Traceref: int,
            ?Tracerefminus: int,
            ?Copy_ystyle: bool,
            ?Color: Color,
            ?Thickness: float,
            ?Width: float
        ) =
        fun (ch: GenericChart) ->
            ch
            |> GenericChart.mapTrace (
                TraceStyle.ZError(
                    ?Visible = Visible,
                    ?Type = Type,
                    ?Symmetric = Symmetric,
                    ?Array = Array,
                    ?Arrayminus = Arrayminus,
                    ?Value = Value,
                    ?Valueminus = Valueminus,
                    ?Traceref = Traceref,
                    ?Tracerefminus = Tracerefminus,
                    ?Copy_ystyle = Copy_ystyle,
                    ?Color = Color,
                    ?Thickness = Thickness,
                    ?Width = Width
                )
            )

    /// <summary>
    /// Sets the ColorBar for the chart's trace(s).
    /// </summary>
    /// <param name="colorBar">The new ColorBar for the chart's trace(s)</param>
    /// <param name="Combine">Whether or not to combine the objects if there is already a ColorBar object set (default is false)</param>
    static member setColorBar(colorBar: ColorBar, ?Combine: bool) =
        let combine = defaultArg Combine false

        (fun (ch: GenericChart) ->
            if combine then
                ch |> GenericChart.mapTrace (Trace.updateColorBar colorBar)
            else
                ch |> GenericChart.mapTrace (Trace.setColorBar colorBar))

    /// <summary>
    /// Sets the ColorBar for the chart's trace(s).
    ///
    /// If there is already a ColorBar set, the objects are combined.
    /// </summary>
    /// <param name="colorbar">The new ColorBar for the chart's trace(s)</param>
    static member withColorBar(colorbar: ColorBar) =
        (fun (ch: GenericChart) -> ch |> Chart.setColorBar (colorbar, true))

    /// <summary>
    /// Applies the given styles to the ColorBar object(s) of the chart's trace(s). Overwrites attributes with the same name that are already set.
    /// </summary>
    /// <param name="TitleText">Sets the colorbar's title</param>
    /// <param name="TitleFont">Sets the title font.</param>
    /// <param name="TitleStandoff">Sets the standoff distance (in px) between the axis labels and the title text The default value is a function of the axis tick labels, the title `font.size` and the axis `linewidth`. Note that the axis title position is always constrained within the margins, so the actual standoff distance is always less than the set or default value. By setting `standoff` and turning on `automargin`, plotly.js will push the margins to fit the axis title at given standoff distance.</param>
    /// <param name="Title">Sets the Title object (use this for more finegrained control than the other title-associated arguments)</param>
    /// <param name="BGColor">Sets the color of padded area.</param>
    /// <param name="BorderColor">Sets the axis line color.</param>
    /// <param name="BorderWidth">Sets the width (in px) or the border enclosing this color bar.</param>
    /// <param name="DTick">Sets the step in-between ticks on this axis. Use with `tick0`. Must be a positive number, or special strings available to "log" and "date" axes. If the axis `type` is "log", then ticks are set every 10^(n"dtick) where n is the tick number. For example, to set a tick mark at 1, 10, 100, 1000, ... set dtick to 1. To set tick marks at 1, 100, 10000, ... set dtick to 2. To set tick marks at 1, 5, 25, 125, 625, 3125, ... set dtick to log_10(5), or 0.69897000433. "log" has several special values; "L&lt;f&gt;", where `f` is a positive number, gives ticks linearly spaced in value (but not position). For example `tick0` = 0.1, `dtick` = "L0.5" will put ticks at 0.1, 0.6, 1.1, 1.6 etc. To show powers of 10 plus small digits between, use "D1" (all digits) or "D2" (only 2 and 5). `tick0` is ignored for "D1" and "D2". If the axis `type` is "date", then you must convert the time to milliseconds. For example, to set the interval between ticks to one day, set `dtick` to 86400000.0. "date" also has special values "M&lt;n&gt;" gives ticks spaced by a number of months. `n` must be a positive integer. To set ticks on the 15th of every third month, set `tick0` to "2000-01-15" and `dtick` to "M3". To set ticks every 4 years, set `dtick` to "M48"</param>
    /// <param name="ExponentFormat">Determines a formatting rule for the tick exponents. For example, consider the number 1,000,000,000. If "none", it appears as 1,000,000,000. If "e", 1e+9. If "E", 1E+9. If "power", 1x10^9 (with 9 in a super script). If "SI", 1G. If "B", 1B.</param>
    /// <param name="LabelAlias">Replacement text for specific tick or hover labels. For example using {US: 'USA', CA: 'Canada'} changes US to USA and CA to Canada. The labels we would have shown must match the keys exactly, after adding any tickprefix or ticksuffix. labelalias can be used with any axis type, and both keys (if needed) and values (if desired) can include html-like tags or MathJax.</param>
    /// <param name="Len">Sets the length of the color bar This measure excludes the padding of both ends. That is, the color bar length is this length minus the padding on both ends.</param>
    /// <param name="LenMode">Determines whether this color bar's length (i.e. the measure in the color variation direction) is set in units of plot "fraction" or in "pixels. Use `len` to set the value.</param>
    /// <param name="MinExponent">Hide SI prefix for 10^n if |n| is below this number. This only has an effect when `tickformat` is "SI" or "B".</param>
    /// <param name="NTicks">Specifies the maximum number of ticks for the particular axis. The actual number of ticks will be chosen automatically to be less than or equal to `nticks`. Has an effect only if `tickmode` is set to "auto".</param>
    /// <param name="Orientation">Sets the orientation of the colorbar.</param>
    /// <param name="OutlineColor">Sets the axis line color.</param>
    /// <param name="OutlineWidth">Sets the width (in px) of the axis line.</param>
    /// <param name="SeparateThousands">If "true", even 4-digit integers are separated</param>
    /// <param name="ShowExponent">If "all", all exponents are shown besides their significands. If "first", only the exponent of the first tick is shown. If "last", only the exponent of the last tick is shown. If "none", no exponents appear.</param>
    /// <param name="ShowTickLabels">Determines whether or not the tick labels are drawn.</param>
    /// <param name="ShowTickPrefix">If "all", all tick labels are displayed with a prefix. If "first", only the first tick is displayed with a prefix. If "last", only the last tick is displayed with a suffix. If "none", tick prefixes are hidden.</param>
    /// <param name="ShowTickSuffix">Same as `showtickprefix` but for tick suffixes.</param>
    /// <param name="Thickness">Sets the thickness of the color bar This measure excludes the size of the padding, ticks and labels.</param>
    /// <param name="ThicknessMode">Determines whether this color bar's thickness (i.e. the measure in the constant color direction) is set in units of plot "fraction" or in "pixels". Use `thickness` to set the value.</param>
    /// <param name="Tick0">Sets the placement of the first tick on this axis. Use with `dtick`. If the axis `type` is "log", then you must take the log of your starting tick (e.g. to set the starting tick to 100, set the `tick0` to 2) except when `dtick`="L&gt;f&lt;" (see `dtick` for more info). If the axis `type` is "date", it should be a date string, like date data. If the axis `type` is "category", it should be a number, using the scale where each category is assigned a serial number from zero in the order it appears.</param>
    /// <param name="TickAngle">Sets the angle of the tick labels with respect to the horizontal. For example, a `tickangle` of -90 draws the tick labels vertically.</param>
    /// <param name="TickColor">Sets the tick color.</param>
    /// <param name="TickFont">Sets the color bar's tick label font</param>
    /// <param name="TickFormat">Sets the tick label formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"</param>
    /// <param name="TickFormatStops">Set rules for customizing TickFormat on different zoom levels</param>
    /// <param name="TickLabelOverflow">Determines how we handle tick labels that would overflow either the graph div or the domain of the axis. The default value for inside tick labels is "hide past domain". In other cases the default is "hide past div".</param>
    /// <param name="TickLabelPosition">Determines where tick labels are drawn.</param>
    /// <param name="TickLabelStep">Sets the spacing between tick labels as compared to the spacing between ticks. A value of 1 (default) means each tick gets a label. A value of 2 means shows every 2nd label. A larger value n means only every nth tick is labeled. `tick0` determines which labels are shown. Not implemented for axes with `type` "log" or "multicategory", or when `tickmode` is "array".</param>    /// <param name="TickLen">Sets the tick length (in px).</param>
    /// <param name="TickMode">Sets the tick mode for this axis. If "auto", the number of ticks is set via `nticks`. If "linear", the placement of the ticks is determined by a starting position `tick0` and a tick step `dtick` ("linear" is the default value if `tick0` and `dtick` are provided). If "array", the placement of the ticks is set via `tickvals` and the tick text is `ticktext`. ("array" is the default value if `tickvals` is provided).</param>
    /// <param name="TickPrefix">Sets a tick label prefix.</param>
    /// <param name="Ticks">Determines whether ticks are drawn or not. If "", this axis' ticks are not drawn. If "outside" ("inside"), this axis' are drawn outside (inside) the axis lines.</param>
    /// <param name="TickSuffix">Sets a tick label suffix.</param>
    /// <param name="TickText">Sets the text displayed at the ticks position via `tickvals`. Only has an effect if `tickmode` is set to "array". Used with `tickvals`.</param>
    /// <param name="TickVals">Sets the values at which ticks on this axis appear. Only has an effect if `tickmode` is set to "array". Used with `ticktext`.</param>
    /// <param name="TickWidth">Sets the tick width (in px).</param>
    /// <param name="X">Sets the x position of the color bar (in plot fraction).</param>
    /// <param name="XAnchor">Sets this color bar's horizontal position anchor. This anchor binds the `x` position to the "left", "center" or "right" of the color bar.</param>
    /// <param name="XPad">Sets the amount of padding (in px) along the x direction.</param>
    /// <param name="XRef">Sets the container `x` refers to. "container" spans the entire `width` of the plot. "paper" refers to the width of the plotting area only.</param>
    /// <param name="Y">Sets the y position of the color bar (in plot fraction).</param>
    /// <param name="YAnchor">Sets this color bar's vertical position anchor This anchor binds the `y` position to the "top", "middle" or "bottom" of the color bar.</param>
    /// <param name="YPad">Sets the amount of padding (in px) along the y direction.</param>
    /// <param name="YRef">Sets the container `y` refers to. "container" spans the entire `height` of the plot. "paper" refers to the height of the plotting area only.</param>
    static member withColorBarStyle
        (
            ?TitleText: string,
            ?TitleFont: Font,
            ?TitleStandoff: int,
            ?Title: Title,
            ?BGColor: Color,
            ?BorderColor: Color,
            ?BorderWidth: float,
            ?DTick: IConvertible,
            ?ExponentFormat: StyleParam.ExponentFormat,
            ?LabelAlias: DynamicObj,
            ?Len: float,
            ?LenMode: StyleParam.UnitMode,
            ?MinExponent: float,
            ?NTicks: int,
            ?Orientation: StyleParam.Orientation,
            ?OutlineColor: Color,
            ?OutlineWidth: float,
            ?SeparateThousands: bool,
            ?ShowExponent: StyleParam.ShowExponent,
            ?ShowTickLabels: bool,
            ?ShowTickPrefix: StyleParam.ShowTickOption,
            ?ShowTickSuffix: StyleParam.ShowTickOption,
            ?Thickness: float,
            ?ThicknessMode: StyleParam.UnitMode,
            ?Tick0: IConvertible,
            ?TickAngle: int,
            ?TickColor: Color,
            ?TickFont: Font,
            ?TickFormat: string,
            ?TickFormatStops: seq<TickFormatStop>,
            ?TickLabelOverflow: StyleParam.TickLabelOverflow,
            ?TickLabelPosition: StyleParam.TickLabelPosition,
            ?TickLabelStep: int,
            ?TickLen: float,
            ?TickMode: StyleParam.TickMode,
            ?TickPrefix: string,
            ?Ticks: StyleParam.TickOptions,
            ?TickSuffix: string,
            ?TickText: seq<#IConvertible>,
            ?TickVals: seq<#IConvertible>,
            ?TickWidth: float,
            ?X: float,
            ?XAnchor: StyleParam.HorizontalAlign,
            ?XPad: float,
            ?XRef: string,
            ?Y: float,
            ?YAnchor: StyleParam.VerticalAlign,
            ?YPad: float,
            ?YRef: string
        ) =

        let title =
            Title
            |> Option.defaultValue (Plotly.NET.Title())
            |> Plotly.NET.Title.style (?Text = TitleText, ?Font = TitleFont, ?Standoff = TitleStandoff)

        let colorbar =
            ColorBar.init (
                Title = title,
                ?BGColor = BGColor,
                ?BorderColor = BorderColor,
                ?BorderWidth = BorderWidth,
                ?DTick = DTick,
                ?ExponentFormat = ExponentFormat,
                ?LabelAlias = LabelAlias,
                ?Len = Len,
                ?LenMode = LenMode,
                ?MinExponent = MinExponent,
                ?NTicks = NTicks,
                ?Orientation = Orientation,
                ?OutlineColor = OutlineColor,
                ?OutlineWidth = OutlineWidth,
                ?SeparateThousands = SeparateThousands,
                ?ShowExponent = ShowExponent,
                ?ShowTickLabels = ShowTickLabels,
                ?ShowTickPrefix = ShowTickPrefix,
                ?ShowTickSuffix = ShowTickSuffix,
                ?Thickness = Thickness,
                ?ThicknessMode = ThicknessMode,
                ?Tick0 = Tick0,
                ?TickAngle = TickAngle,
                ?TickColor = TickColor,
                ?TickFont = TickFont,
                ?TickFormat = TickFormat,
                ?TickFormatStops = TickFormatStops,
                ?TickLabelOverflow = TickLabelOverflow,
                ?TickLabelPosition = TickLabelPosition,
                ?TickLabelStep = TickLabelStep,
                ?TickLen = TickLen,
                ?TickMode = TickMode,
                ?TickPrefix = TickPrefix,
                ?Ticks = Ticks,
                ?TickSuffix = TickSuffix,
                ?TickText = TickText,
                ?TickVals = TickVals,
                ?TickWidth = TickWidth,
                ?X = X,
                ?XAnchor = XAnchor,
                ?XPad = XPad,
                ?XRef = XRef,
                ?Y = Y,
                ?YAnchor = YAnchor,
                ?YPad = YPad,
                ?YRef = YRef
            )

        Chart.withColorBar (colorbar)

    //==============================================================================================================
    //======================================= General Layout object styling ========================================
    //==============================================================================================================

    // <summary>
    /// Sets the given layout on the input chart.
    ///
    /// If there is already an layout set, the object is replaced.
    /// </summary>
    static member setLayout(layout: Layout) =
        (fun (ch: GenericChart) -> GenericChart.setLayout layout ch)

    /// <summary>
    /// Sets the given layout on the input chart.
    ///
    /// If there is already an layout set, the objects are combined.
    /// </summary>
    static member withLayout(layout: Layout) =
        (fun (ch: GenericChart) -> GenericChart.addLayout layout ch)

    /// <summary>
    /// Applies the given styles to the chart's Layout object. Overwrites attributes with the same name that are already set.
    /// </summary>
    /// <param name="Title">Sets the title of the layout.</param>
    /// <param name="ShowLegend">Determines whether or not a legend is drawn. Default is `true` if there is a trace to show and any of these: a) Two or more traces would by default be shown in the legend. b) One pie trace is shown in the legend. c) One trace is explicitly given with `showlegend: true`.</param>
    /// <param name="Margin">Sets the margins around the layout.</param>
    /// <param name="AutoSize">Determines whether or not a layout width or height that has been left undefined by the user is initialized on each relayout. Note that, regardless of this attribute, an undefined layout width or height is always initialized on the first call to plot.</param>
    /// <param name="Width">Sets the plot's width (in px).</param>
    /// <param name="Height">Sets the plot's height (in px).</param>
    /// <param name="Font">Sets the global font. Note that fonts used in traces and other layout components inherit from the global font.</param>
    /// <param name="UniformText">Determines how the font size for various text elements are uniformed between each trace type.</param>
    /// <param name="Separators">Sets the decimal and thousand separators. For example, ". " puts a '.' before decimals and a space between thousands. In English locales, dflt is ".," but other locales may alter this default.</param>
    /// <param name="PaperBGColor">Sets the background color of the paper where the graph is drawn.</param>
    /// <param name="PlotBGColor">Sets the background color of the plotting area in-between x and y axes.</param>
    /// <param name="AutoTypeNumbers">Using "strict" a numeric string in trace data is not converted to a number. Using "convert types" a numeric string in trace data may be treated as a number during automatic axis `type` detection. This is the default value; however it could be overridden for individual axes.</param>
    /// <param name="Colorscale">Sets the default colorscales that are used by plots using autocolorscale.</param>
    /// <param name="Colorway">Sets the default trace colors.</param>
    /// <param name="ModeBar">Sets the modebar of the layout.</param>
    /// <param name="HoverMode">Determines the mode of hover interactions. If "closest", a single hoverlabel will appear for the "closest" point within the `hoverdistance`. If "x" (or "y"), multiple hoverlabels will appear for multiple points at the "closest" x- (or y-) coordinate within the `hoverdistance`, with the caveat that no more than one hoverlabel will appear per trace. If "x unified" (or "y unified"), a single hoverlabel will appear multiple points at the closest x- (or y-) coordinate within the `hoverdistance` with the caveat that no more than one hoverlabel will appear per trace. In this mode, spikelines are enabled by default perpendicular to the specified axis. If false, hover interactions are disabled.</param>
    /// <param name="ClickMode">Determines the mode of single click interactions. "event" is the default value and emits the `plotly_click` event. In addition this mode emits the `plotly_selected` event in drag modes "lasso" and "select", but with no event data attached (kept for compatibility reasons). The "select" flag enables selecting single data points via click. This mode also supports persistent selections, meaning that pressing Shift while clicking, adds to / subtracts from an existing selection. "select" with `hovermode`: "x" can be confusing, consider explicitly setting `hovermode`: "closest" when using this feature. Selection events are sent accordingly as long as "event" flag is set as well. When the "event" flag is missing, `plotly_click` and `plotly_selected` events are not fired.</param>
    /// <param name="DragMode">Determines the mode of drag interactions. "select" and "lasso" apply only to scatter traces with markers or text. "orbit" and "turntable" apply only to 3D scenes.</param>
    /// <param name="SelectDirection">When `dragmode` is set to "select", this limits the selection of the drag to horizontal, vertical or diagonal. "h" only allows horizontal selection, "v" only vertical, "d" only diagonal and "any" sets no limit.</param>
    /// <param name="ActiveSelection">Sets the styling of the active selection</param>
    /// <param name="NewSelection">Controls the behavior of newly drawn selections</param>
    /// <param name="HoverDistance">Sets the default distance (in pixels) to look for data to add hover labels (-1 means no cutoff, 0 means no looking for data). This is only a real distance for hovering on point-like objects, like scatter points. For area-like objects (bars, scatter fills, etc) hovering is on inside the area and off outside, but these objects will not supersede hover on point-like objects in case of conflict.</param>
    /// <param name="SpikeDistance">Sets the default distance (in pixels) to look for data to draw spikelines to (-1 means no cutoff, 0 means no looking for data). As with hoverdistance, distance does not apply to area-like objects. In addition, some objects can be hovered on but will not generate spikelines, such as scatter fills.</param>
    /// <param name="Hoverlabel">Sets the style ov hover labels.</param>
    /// <param name="Transition">Sets transition options used during Plotly.react updates.</param>
    /// <param name="DataRevision">If provided, a changed value tells `Plotly.react` that one or more data arrays has changed. This way you can modify arrays in-place rather than making a complete new copy for an incremental change. If NOT provided, `Plotly.react` assumes that data arrays are being treated as immutable, thus any data array with a different identity from its predecessor contains new data.</param>
    /// <param name="UIRevision">Used to allow user interactions with the plot to persist after `Plotly.react` calls that are unaware of these interactions. If `uirevision` is omitted, or if it is given and it changed from the previous `Plotly.react` call, the exact new figure is used. If `uirevision` is truthy and did NOT change, any attribute that has been affected by user interactions and did not receive a different value in the new figure will keep the interaction value. `layout.uirevision` attribute serves as the default for `uirevision` attributes in various sub-containers. For finer control you can set these sub-attributes directly. For example, if your app separately controls the data on the x and y axes you might set `xaxis.uirevision="time"` and `yaxis.uirevision="cost"`. Then if only the y data is changed, you can update `yaxis.uirevision="quantity"` and the y axis range will reset but the x axis range will retain any user-driven zoom.</param>
    /// <param name="EditRevision">Controls persistence of user-driven changes in `editable: true` configuration, other than trace names and axis titles. Defaults to `layout.uirevision`.</param>
    /// <param name="SelectRevision">Controls persistence of user-driven changes in `editable: true` configuration, other than trace names and axis titles. Defaults to `layout.uirevision`.</param>
    /// <param name="Template">Default attributes to be applied to the plot. Templates can be created from existing plots using `Plotly.makeTemplate`, or created manually. They should be objects with format: `{layout: layoutTemplate, data: {[type]: [traceTemplate, ...]}, ...}` `layoutTemplate` and `traceTemplate` are objects matching the attribute structure of `layout` and a data trace. Trace templates are applied cyclically to traces of each type. Container arrays (eg `annotations`) have special handling: An object ending in `defaults` (eg `annotationdefaults`) is applied to each array item. But if an item has a `templateitemname` key we look in the template array for an item with matching `name` and apply that instead. If no matching `name` is found we mark the item invisible. Any named template item not referenced is appended to the end of the array, so you can use this for a watermark annotation or a logo image, for example. To omit one of these items on the plot, make an item with matching `templateitemname` and `visible: false`.</param>
    /// <param name="Meta">Assigns extra meta information that can be used in various `text` attributes. Attributes such as the graph, axis and colorbar `title.text`, annotation `text` `trace.name` in legend items, `rangeselector`, `updatemenus` and `sliders` `label` text all support `meta`. One can access `meta` fields using template strings: `%{meta[i]}` where `i` is the index of the `meta` item in question. `meta` can also be an object for example `{key: value}` which can be accessed %{meta[key]}.</param>
    /// <param name="Computed">Placeholder for exporting automargin-impacting values namely `margin.t`, `margin.b`, `margin.l` and `margin.r` in "full-json" mode.</param>
    /// <param name="Grid">Sets the layout grid for arranging multiple plots</param>
    /// <param name="Calendar">Sets the default calendar system to use for interpreting and displaying dates throughout the plot.</param>
    /// <param name="MinReducedHeight">Minimum height of the plot with margin.automargin applied (in px)</param>
    /// <param name="MinReducedWidth">Minimum width of the plot with margin.automargin applied (in px)</param>
    /// <param name="NewShape">Controls the behavior of newly drawn shapes</param>
    /// <param name="ActiveShape">Sets the styling of the active shape</param>
    /// <param name="HideSources">Determines whether or not a text link citing the data source is placed at the bottom-right cored of the figure. Has only an effect only on graphs that have been generated via forked graphs from the Chart Studio Cloud (at https://chart-studio.plotly.com or on-premise).</param>
    /// <param name="ScatterGap">Sets the gap (in plot fraction) between scatter points of adjacent location coordinates. Defaults to `bargap`.</param>
    /// <param name="ScatterMode">Determines how scatter points at the same location coordinate are displayed on the graph. With "group", the scatter points are plotted next to one another centered around the shared location. With "overlay", the scatter points are plotted over one another, you might need to reduce "opacity" to see multiple scatter points.</param>
    /// <param name="BarGap">Sets the gap (in plot fraction) between bars of adjacent location coordinates.</param>
    /// <param name="BarGroupGap">Sets the gap (in plot fraction) between bars of adjacent location coordinates.</param>
    /// <param name="BarMode">Determines how bars at the same location coordinate are displayed on the graph. With "stack", the bars are stacked on top of one another With "relative", the bars are stacked on top of one another, with negative values below the axis, positive values above With "group", the bars are plotted next to one another centered around the shared location. With "overlay", the bars are plotted over one another, you might need to an "opacity" to see multiple bars.</param>
    /// <param name="BarNorm">Sets the normalization for bar traces on the graph. With "fraction", the value of each bar is divided by the sum of all values at that location coordinate. "percent" is the same but multiplied by 100 to show percentages.</param>
    /// <param name="ExtendPieColors">If `true`, the pie slice colors (whether given by `piecolorway` or inherited from `colorway`) will be extended to three times its original length by first repeating every color 20% lighter then each color 20% darker. This is intended to reduce the likelihood of reusing the same color when you have many slices, but you can set `false` to disable. Colors provided in the trace, using `marker.colors`, are never extended.</param>
    /// <param name="HiddenLabels">If `true`, the pie slice colors (whether given by `piecolorway` or inherited from `colorway`) will be extended to three times its original length by first repeating every color 20% lighter then each color 20% darker. This is intended to reduce the likelihood of reusing the same color when you have many slices, but you can set `false` to disable. Colors provided in the trace, using `marker.colors`, are never extended.</param>
    /// <param name="PieColorWay">Sets the default pie slice colors. Defaults to the main `colorway` used for trace colors. If you specify a new list here it can still be extended with lighter and darker colors, see `extendpiecolors`.</param>
    /// <param name="BoxGap">Sets the gap (in plot fraction) between boxes of adjacent location coordinates. Has no effect on traces that have "width" set.</param>
    /// <param name="BoxGroupGap">Sets the gap (in plot fraction) between boxes of the same location coordinate. Has no effect on traces that have "width" set.</param>
    /// <param name="BoxMode">Sets the gap (in plot fraction) between boxes of the same location coordinate. Has no effect on traces that have "width" set.</param>
    /// <param name="ViolinGap">Sets the gap (in plot fraction) between boxes of the same location coordinate. Has no effect on traces that have "width" set.</param>
    /// <param name="ViolinGroupGap">Sets the gap (in plot fraction) between violins of the same location coordinate. Has no effect on traces that have "width" set.</param>
    /// <param name="ViolinMode">Determines how violins at the same location coordinate are displayed on the graph. If "group", the violins are plotted next to one another centered around the shared location. If "overlay", the violins are plotted over one another, you might need to set "opacity" to see them multiple violins. Has no effect on traces that have "width" set.</param>
    /// <param name="WaterfallGap">Sets the gap (in plot fraction) between bars of adjacent location coordinates.</param>
    /// <param name="WaterfallGroupGap">Sets the gap (in plot fraction) between bars of the same location coordinate.</param>
    /// <param name="WaterfallMode">Determines how bars at the same location coordinate are displayed on the graph. With "group", the bars are plotted next to one another centered around the shared location. With "overlay", the bars are plotted over one another, you might need to an "opacity" to see multiple bars.</param>
    /// <param name="FunnelGap">Sets the gap (in plot fraction) between bars of adjacent location coordinates.</param>
    /// <param name="FunnelGroupGap">Sets the gap (in plot fraction) between bars of adjacent location coordinates.</param>
    /// <param name="FunnelMode">Determines how bars at the same location coordinate are displayed on the graph. With "stack", the bars are stacked on top of one another With "group", the bars are plotted next to one another centered around the shared location. With "overlay", the bars are plotted over one another, you might need to an "opacity" to see multiple bars.</param>
    /// <param name="ExtendFunnelAreaColors">If `true`, the funnelarea slice colors (whether given by `funnelareacolorway` or inherited from `colorway`) will be extended to three times its original length by first repeating every color 20% lighter then each color 20% darker. This is intended to reduce the likelihood of reusing the same color when you have many slices, but you can set `false` to disable. Colors provided in the trace, using `marker.colors`, are never extended.</param>
    /// <param name="FunnelAreaColorWay">Sets the default funnelarea slice colors. Defaults to the main `colorway` used for trace colors. If you specify a new list here it can still be extended with lighter and darker colors, see `extendfunnelareacolors`.</param>
    /// <param name="ExtendSunBurstColors">If `true`, the sunburst slice colors (whether given by `sunburstcolorway` or inherited from `colorway`) will be extended to three times its original length by first repeating every color 20% lighter then each color 20% darker. This is intended to reduce the likelihood of reusing the same color when you have many slices, but you can set `false` to disable. Colors provided in the trace, using `marker.colors`, are never extended.</param>
    /// <param name="SunBurstColorWay">If `true`, the sunburst slice colors (whether given by `sunburstcolorway` or inherited from `colorway`) will be extended to three times its original length by first repeating every color 20% lighter then each color 20% darker. This is intended to reduce the likelihood of reusing the same color when you have many slices, but you can set `false` to disable. Colors provided in the trace, using `marker.colors`, are never extended.</param>
    /// <param name="ExtendTreeMapColors">If `true`, the treemap slice colors (whether given by `treemapcolorway` or inherited from `colorway`) will be extended to three times its original length by first repeating every color 20% lighter then each color 20% darker. This is intended to reduce the likelihood of reusing the same color when you have many slices, but you can set `false` to disable. Colors provided in the trace, using `marker.colors`, are never extended.</param>
    /// <param name="TreeMapColorWay">Sets the default treemap slice colors. Defaults to the main `colorway` used for trace colors. If you specify a new list here it can still be extended with lighter and darker colors, see `extendtreemapcolors`.</param>
    /// <param name="ExtendIcicleColors">If `true`, the icicle slice colors (whether given by `iciclecolorway` or inherited from `colorway`) will be extended to three times its original length by first repeating every color 20% lighter then each color 20% darker. This is intended to reduce the likelihood of reusing the same color when you have many slices, but you can set `false` to disable. Colors provided in the trace, using `marker.colors`, are never extended.</param>
    /// <param name="IcicleColorWay">Sets the default icicle slice colors. Defaults to the main `colorway` used for trace colors. If you specify a new list here it can still be extended with lighter and darker colors, see `extendiciclecolors`.</param>
    /// <param name="Annotations">A collection containing all Annotations of this layout. An annotation is a text element that can be placed anywhere in the plot. It can be positioned with respect to relative coordinates in the plot or with respect to the actual data coordinates of the graph. Annotations can be shown with or without an arrow.</param>
    /// <param name="Shapes">A collection containing all Shapes of this layout.</param>
    /// <param name="Selections">A collection containing all Selections of this layout.</param>
    /// <param name="Images">A collection containing all Images of this layout. </param>
    /// <param name="Sliders">A collection containing all Sliders of this layout. </param>
    /// <param name="UpdateMenus">A collection containing all UpdateMenus of this layout. </param>
    static member withLayoutStyle
        (
            ?Title: Title,
            ?ShowLegend: bool,
            ?Margin: Margin,
            ?AutoSize: bool,
            ?Width: int,
            ?Height: int,
            ?Font: Font,
            ?UniformText: UniformText,
            ?Separators: string,
            ?PaperBGColor: Color,
            ?PlotBGColor: Color,
            ?AutoTypeNumbers: StyleParam.AutoTypeNumbers,
            ?Colorscale: DefaultColorScales,
            ?Colorway: Color,
            ?ModeBar: ModeBar,
            ?HoverMode: StyleParam.HoverMode,
            ?ClickMode: StyleParam.ClickMode,
            ?DragMode: StyleParam.DragMode,
            ?SelectDirection: StyleParam.SelectDirection,
            ?ActiveSelection: ActiveSelection,
            ?NewSelection: NewSelection,
            ?HoverDistance: int,
            ?SpikeDistance: int,
            ?Hoverlabel: Hoverlabel,
            ?Transition: Transition,
            ?DataRevision: string,
            ?UIRevision: string,
            ?EditRevision: string,
            ?SelectRevision: string,
            ?Template: DynamicObj,
            ?Meta: string,
            ?Computed: string,
            ?Grid: LayoutGrid,
            ?Calendar: StyleParam.Calendar,
            ?MinReducedHeight: int,
            ?MinReducedWidth: int,
            ?NewShape: NewShape,
            ?ActiveShape: ActiveShape,
            ?HideSources: bool,
            ?ScatterGap: float,
            ?ScatterMode: StyleParam.ScatterMode,
            ?BarGap: float,
            ?BarGroupGap: float,
            ?BarMode: StyleParam.BarMode,
            ?BarNorm: StyleParam.BarNorm,
            ?ExtendPieColors: bool,
            ?HiddenLabels: seq<#IConvertible>,
            ?PieColorWay: Color,
            ?BoxGap: float,
            ?BoxGroupGap: float,
            ?BoxMode: StyleParam.BoxMode,
            ?ViolinGap: float,
            ?ViolinGroupGap: float,
            ?ViolinMode: StyleParam.ViolinMode,
            ?WaterfallGap: float,
            ?WaterfallGroupGap: float,
            ?WaterfallMode: StyleParam.WaterfallMode,
            ?FunnelGap: float,
            ?FunnelGroupGap: float,
            ?FunnelMode: StyleParam.FunnelMode,
            ?ExtendFunnelAreaColors: bool,
            ?FunnelAreaColorWay: Color,
            ?ExtendSunBurstColors: bool,
            ?SunBurstColorWay: Color,
            ?ExtendTreeMapColors: bool,
            ?TreeMapColorWay: Color,
            ?ExtendIcicleColors: bool,
            ?IcicleColorWay: Color,
            ?Annotations: seq<Annotation>,
            ?Shapes: seq<Shape>,
            ?Selections: seq<Selection>,
            ?Images: seq<LayoutImage>,
            ?Sliders: seq<Slider>,
            ?UpdateMenus: seq<UpdateMenu>
        ) =
        (fun (ch: GenericChart) ->

            let layout' =
                Layout.init (
                    ?Title = Title,
                    ?ShowLegend = ShowLegend,
                    ?Margin = Margin,
                    ?AutoSize = AutoSize,
                    ?Width = Width,
                    ?Height = Height,
                    ?Font = Font,
                    ?UniformText = UniformText,
                    ?Separators = Separators,
                    ?PaperBGColor = PaperBGColor,
                    ?PlotBGColor = PlotBGColor,
                    ?AutoTypeNumbers = AutoTypeNumbers,
                    ?Colorscale = Colorscale,
                    ?Colorway = Colorway,
                    ?ModeBar = ModeBar,
                    ?HoverMode = HoverMode,
                    ?ClickMode = ClickMode,
                    ?DragMode = DragMode,
                    ?SelectDirection = SelectDirection,
                    ?NewSelection = NewSelection,
                    ?ActiveSelection = ActiveSelection,
                    ?HoverDistance = HoverDistance,
                    ?SpikeDistance = SpikeDistance,
                    ?Hoverlabel = Hoverlabel,
                    ?Transition = Transition,
                    ?DataRevision = DataRevision,
                    ?UIRevision = UIRevision,
                    ?EditRevision = EditRevision,
                    ?SelectRevision = SelectRevision,
                    ?Template = Template,
                    ?Meta = Meta,
                    ?Computed = Computed,
                    ?Grid = Grid,
                    ?Calendar = Calendar,
                    ?NewShape = NewShape,
                    ?MinReducedHeight = MinReducedHeight,
                    ?MinReducedWidth = MinReducedWidth,
                    ?ActiveShape = ActiveShape,
                    ?HideSources = HideSources,
                    ?ScatterGap = ScatterGap,
                    ?ScatterMode = ScatterMode,
                    ?BarGap = BarGap,
                    ?BarGroupGap = BarGroupGap,
                    ?BarMode = BarMode,
                    ?BarNorm = BarNorm,
                    ?ExtendPieColors = ExtendPieColors,
                    ?HiddenLabels = HiddenLabels,
                    ?PieColorWay = PieColorWay,
                    ?BoxGap = BoxGap,
                    ?BoxGroupGap = BoxGroupGap,
                    ?BoxMode = BoxMode,
                    ?ViolinGap = ViolinGap,
                    ?ViolinGroupGap = ViolinGroupGap,
                    ?ViolinMode = ViolinMode,
                    ?WaterfallGap = WaterfallGap,
                    ?WaterfallGroupGap = WaterfallGroupGap,
                    ?WaterfallMode = WaterfallMode,
                    ?FunnelGap = FunnelGap,
                    ?FunnelGroupGap = FunnelGroupGap,
                    ?FunnelMode = FunnelMode,
                    ?ExtendFunnelAreaColors = ExtendFunnelAreaColors,
                    ?FunnelAreaColorWay = FunnelAreaColorWay,
                    ?ExtendSunBurstColors = ExtendSunBurstColors,
                    ?SunBurstColorWay = SunBurstColorWay,
                    ?ExtendTreeMapColors = ExtendTreeMapColors,
                    ?TreeMapColorWay = TreeMapColorWay,
                    ?ExtendIcicleColors = ExtendIcicleColors,
                    ?IcicleColorWay = IcicleColorWay,
                    ?Annotations = Annotations,
                    ?Shapes = Shapes,
                    ?Selections = Selections,
                    ?Images = Images,
                    ?Sliders = Sliders,
                    ?UpdateMenus = UpdateMenus
                )

            GenericChart.addLayout layout' ch)

    /// <summary>
    /// Sets the given axis with the given id on the input chart's layout.
    /// </summary>
    /// <param name="axis">The x axis to set on the chart's layout</param>
    /// <param name="id">The target axis id with which the axis should be set.</param>
    /// <param name="SceneAxis">If set on a scene, define whether it is the x, y or z axis. default is x.</param>
    /// <param name="Combine">Whether or not to combine the objects if there is already an axis set (default is false)</param>
    static member setAxis
        (
            axis: LinearAxis,
            id: StyleParam.SubPlotId,
            ?SceneAxis: StyleParam.SubPlotId,
            ?Combine: bool
        ) =

        fun (ch: GenericChart) ->

            let combine = defaultArg Combine false

            match id with
            // x and y axes for 2d cartesion plots are set on the layout directly
            | StyleParam.SubPlotId.XAxis _
            | StyleParam.SubPlotId.YAxis _ ->
                ch
                |> GenericChart.mapLayout (fun layout ->

                    if combine then
                        layout |> Layout.updateLinearAxisById (id, axis = axis)
                    else
                        layout |> Layout.setLinearAxis (id, axis = axis))

            // x, y, and z axes for 3d cartesion plots are set on the scene object on the layout.
            | StyleParam.SubPlotId.Scene _ ->

                // we need to know which axis to set on the scene
                let sceneAxisId =
                    defaultArg SceneAxis (StyleParam.SubPlotId.XAxis 1)

                ch
                |> GenericChart.mapLayout (fun layout ->
                    let scene =
                        layout |> Layout.getSceneById sceneAxisId

                    if combine then
                        let currentAxis =
                            match sceneAxisId with
                            | StyleParam.SubPlotId.XAxis _ -> scene |> Scene.getXAxis
                            | StyleParam.SubPlotId.YAxis _ -> scene |> Scene.getYAxis
                            | StyleParam.SubPlotId.ZAxis   -> scene |> Scene.getZAxis
                            | _ -> failwith "invalid scene axis id"

                        let updatedAxis = DynObj.combine currentAxis axis

                        let updatedScene =
                            scene
                            |> fun s ->
                                match sceneAxisId with
                                | StyleParam.SubPlotId.XAxis _ -> s |> Scene.setXAxis axis
                                | StyleParam.SubPlotId.YAxis _ -> s |> Scene.setYAxis axis
                                | StyleParam.SubPlotId.ZAxis   -> s |> Scene.setZAxis axis
                                | _ -> failwith "invalid scene axis id"

                        layout |> Layout.updateSceneById (id, updatedScene)

                    else
                        let updatedScene =
                            layout
                            |> Layout.getSceneById id
                            |> fun s ->
                                match sceneAxisId with
                                | StyleParam.SubPlotId.XAxis _ -> s |> Scene.setXAxis axis
                                | StyleParam.SubPlotId.YAxis _ -> s |> Scene.setYAxis axis
                                | StyleParam.SubPlotId.ZAxis   -> s |> Scene.setZAxis axis
                                | _ -> failwith "invalid scene axis id"

                        layout |> Layout.updateSceneById (id, updatedScene))

            | _ -> failwith $"{StyleParam.SubPlotId.toString id} is an invalid subplot id for setting a xaxis"

    /// <summary>
    /// Sets the given x axis on the input chart's layout, optionally passing a target axis id.
    ///
    /// If there is already an axis set at the given id, the axis objects are combined.
    /// </summary>
    /// <param name="xAxis">The x axis to set on the chart's layout</param>
    /// <param name="Id">The target axis id with which the axis should be set. Default is 1.</param>
    static member withXAxis(xAxis: LinearAxis, ?Id: StyleParam.SubPlotId) =
        let id =
            defaultArg Id (StyleParam.SubPlotId.XAxis 1)

        fun (ch: GenericChart) ->
            ch |> Chart.setAxis (xAxis, id, SceneAxis = StyleParam.SubPlotId.XAxis 1, Combine = true)

    /// <summary>
    /// Sets the given x axis styles on the input chart's layout.
    ///
    /// If there is already an axis set at the given id, the styles are applied to it. If there is no axis present, a new LinearAxis object with the given styles will be set.
    /// </summary>
    /// <param name="TitleText">Sets the text of the axis title.</param>
    /// <param name="TitleFont">Sets the font of the axis title.</param>
    /// <param name="TitleStandoff">Sets the standoff distance (in px) between the axis labels and the title text.</param>
    /// <param name="Title">Sets the Title (use this for more finegrained control than the other title-associated arguments)</param>
    /// <param name="Color">Sets default for all colors associated with this axis all at once: line, font, tick, and grid colors.</param>
    /// <param name="AxisType">Sets the axis type. By default, plotly attempts to determined the axis type by looking into the data of the traces that referenced the axis in question.</param>
    /// <param name="MinMax">Tuple of (Min*Max value). Sets the range of this axis (the axis will go from Min to Max). If the axis `type` is "log", then you must take the log of your desired range (e.g. to set the range from 1 to 100, set the range from 0 to 2).</param>
    /// <param name="Mirror">Determines if and how the axis lines or/and ticks are mirrored to the opposite side of the plotting area.</param>
    /// <param name="ShowSpikes">Determines whether or not spikes (aka droplines) are drawn for this axis.</param>
    /// <param name="SpikeColor">Sets the spike color. If not set, will use the series color</param>
    /// <param name="SpikeThickness">Sets the width (in px) of the zero line.</param>
    /// <param name="ShowLine">Determines whether or not a line bounding this axis is drawn.</param>
    /// <param name="LineColor">Sets the axis line color.</param>
    /// <param name="ShowGrid">Determines whether or not grid lines are drawn. If "true", the grid lines are drawn at every tick mark.</param>
    /// <param name="GridColor">Sets the color of the grid lines.</param>
    /// <param name="GridDash">Sets the dash style of lines. Set to a dash type string ("solid", "dot", "dash", "longdash", "dashdot", or "longdashdot") or a dash length list in px (eg "5px,10px,2px,2px").</param>
    /// <param name="ZeroLine">Determines whether or not a line is drawn at along the 0 value of this axis. If "true", the zero line is drawn on top of the grid lines.</param>
    /// <param name="ZeroLineColor">Sets the line color of the zero line.</param>
    /// <param name="Anchor">If set to an opposite-letter axis id (e.g. `x2`, `y`), this axis is bound to the corresponding opposite-letter axis. If set to "free", this axis' position is determined by `position`.</param>
    /// <param name="Side">Determines whether a x (y) axis is positioned at the "bottom" ("left") or "top" ("right") of the plotting area.</param>
    /// <param name="Overlaying">If set a same-letter axis id, this axis is overlaid on top of the corresponding same-letter axis, with traces and axes visible for both axes. If "false", this axis does not overlay any same-letter axes. In this case, for axes with overlapping domains only the highest-numbered axis will be visible.</param>
    /// <param name="Domain">Tuple of (X*Y fractions). Sets the domain of this axis (in plot fraction).</param>
    /// <param name="Position">Sets the position of this axis in the plotting space (in normalized coordinates). Only has an effect if `anchor` is set to "free".</param>
    /// <param name="CategoryOrder">Specifies the ordering logic for the case of categorical variables. By default, plotly uses "trace", which specifies the order that is present in the data supplied. Set `categoryorder` to "category ascending" or "category descending" if order should be determined by the alphanumerical order of the category names. Set `categoryorder` to "array" to derive the ordering from the attribute `categoryarray`. If a category is not found in the `categoryarray` array, the sorting behavior for that attribute will be identical to the "trace" mode. The unspecified categories will follow the categories in `categoryarray`. Set `categoryorder` to "total ascending" or "total descending" if order should be determined by the numerical order of the values. Similarly, the order can be determined by the min, max, sum, mean or median of all the values.</param>
    /// <param name="CategoryArray">Sets the order in which categories on this axis appear. Only has an effect if `categoryorder` is set to "array". Used with `categoryorder`.</param>
    /// <param name="RangeSlider">Sets a range slider for this axis</param>
    /// <param name="RangeSelector">Sets a range selector for this axis. This object contains toggable presets for the rangeslider.</param>
    /// <param name="BackgroundColor">Sets the background color of this axis' wall. (Only has an effect on 3D scenes)</param>
    /// <param name="ShowBackground">Sets whether or not this axis' wall has a background color. (Only has an effect on 3D scenes)</param>
    /// <param name="Id">The target axis id on which the styles should be applied. Default is 1.</param>
    static member withXAxisStyle
        (
            ?TitleText: string,
            ?TitleFont: Font,
            ?TitleStandoff: int,
            ?Title: Title,
            ?Color: Color,
            ?AxisType: StyleParam.AxisType,
            ?MinMax: #IConvertible * #IConvertible,
            ?Mirror: StyleParam.Mirror,
            ?ShowSpikes: bool,
            ?SpikeColor: Color,
            ?SpikeThickness: int,
            ?ShowLine: bool,
            ?LineColor: Color,
            ?ShowGrid: bool,
            ?GridColor: Color,
            ?GridDash: StyleParam.DrawingStyle,
            ?ZeroLine: bool,
            ?ZeroLineColor: Color,
            ?Anchor: StyleParam.LinearAxisId,
            ?Side: StyleParam.Side,
            ?Overlaying: StyleParam.LinearAxisId,
            ?Domain: float * float,
            ?Position: float,
            ?CategoryOrder: StyleParam.CategoryOrder,
            ?CategoryArray: seq<#IConvertible>,
            ?RangeSlider: RangeSlider,
            ?RangeSelector: RangeSelector,
            ?BackgroundColor: Color,
            ?ShowBackground: bool,
            ?Id: StyleParam.SubPlotId
        ) =
        let range =
            MinMax |> Option.map StyleParam.Range.ofMinMax

        let domain =
            Domain |> Option.map StyleParam.Range.ofMinMax

        let title =
            Title
            |> Option.defaultValue (Plotly.NET.Title())
            |> Plotly.NET.Title.style (?Text = TitleText, ?Font = TitleFont, ?Standoff = TitleStandoff)

        let xaxis =
            LinearAxis.init (
                Title = title,
                ?Range = range,
                ?Domain = domain,
                ?Color = Color,
                ?AxisType = AxisType,
                ?Mirror = Mirror,
                ?ShowSpikes = ShowSpikes,
                ?SpikeColor = SpikeColor,
                ?SpikeThickness = SpikeThickness,
                ?ShowLine = ShowLine,
                ?LineColor = LineColor,
                ?ShowGrid = ShowGrid,
                ?GridColor = GridColor,
                ?GridDash = GridDash,
                ?ZeroLine = ZeroLine,
                ?ZeroLineColor = ZeroLineColor,
                ?Anchor = Anchor,
                ?Side = Side,
                ?Overlaying = Overlaying,
                ?Position = Position,
                ?CategoryOrder = CategoryOrder,
                ?CategoryArray = CategoryArray,
                ?RangeSlider = RangeSlider,
                ?RangeSelector = RangeSelector,
                ?BackgroundColor = BackgroundColor,
                ?ShowBackground = ShowBackground

            )

        Chart.withXAxis (xaxis, ?Id = Id)

    /// Sets the range slider for the xAxis
    static member withXAxisRangeSlider(rangeSlider: RangeSlider, ?Id) =
        let xaxis =
            LinearAxis.init (RangeSlider = rangeSlider)

        Chart.withXAxis (xaxis, ?Id = Id)

    /// <summary>
    /// Sets the given y axis on the input chart's layout, optionally passing a target axis id.
    ///
    /// If there is already an axis set at the given id, the axis objects are combined.
    /// </summary>
    /// <param name="yAxis">The y axis to set on the chart's layout</param>
    /// <param name="Id">The target axis id with which the axis should be set. Default is 1.</param>
    static member withYAxis(yAxis: LinearAxis, ?Id: StyleParam.SubPlotId) =
        let id =
            defaultArg Id (StyleParam.SubPlotId.YAxis 1)

        fun (ch: GenericChart) ->
            ch |> Chart.setAxis (yAxis, id, SceneAxis = StyleParam.SubPlotId.YAxis 1, Combine = true)

    /// <summary>
    /// Sets the given y axis styles on the input chart's layout.
    ///
    /// If there is already an axis set at the given id, the styles are applied to it. If there is no axis present, a new LinearAxis object with the given styles will be set.
    /// </summary>
    /// <param name="TitleText">Sets the text of the axis title.</param>
    /// <param name="TitleFont">Sets the font of the axis title.</param>
    /// <param name="TitleStandoff">Sets the standoff distance (in px) between the axis labels and the title text.</param>
    /// <param name="Title">Sets the Title (use this for more finegrained control than the other title-associated arguments)</param>
    /// <param name="Color">Sets default for all colors associated with this axis all at once: line, font, tick, and grid colors.</param>
    /// <param name="AxisType">Sets the axis type. By default, plotly attempts to determined the axis type by looking into the data of the traces that referenced the axis in question.</param>
    /// <param name="MinMax">Tuple of (Min*Max value). Sets the range of this axis (the axis will go from Min to Max). If the axis `type` is "log", then you must take the log of your desired range (e.g. to set the range from 1 to 100, set the range from 0 to 2).</param>
    /// <param name="Mirror">Determines if and how the axis lines or/and ticks are mirrored to the opposite side of the plotting area.</param>
    /// <param name="ShowSpikes">Determines whether or not spikes (aka droplines) are drawn for this axis.</param>
    /// <param name="SpikeColor">Sets the spike color. If not set, will use the series color</param>
    /// <param name="SpikeThickness">Sets the width (in px) of the zero line.</param>
    /// <param name="ShowLine">Determines whether or not a line bounding this axis is drawn.</param>
    /// <param name="LineColor">Sets the axis line color.</param>
    /// <param name="ShowGrid">Determines whether or not grid lines are drawn. If "true", the grid lines are drawn at every tick mark.</param>
    /// <param name="GridColor">Sets the color of the grid lines.</param>
    /// <param name="GridDash">Sets the dash style of lines. Set to a dash type string ("solid", "dot", "dash", "longdash", "dashdot", or "longdashdot") or a dash length list in px (eg "5px,10px,2px,2px").</param>
    /// <param name="ZeroLine">Determines whether or not a line is drawn at along the 0 value of this axis. If "true", the zero line is drawn on top of the grid lines.</param>
    /// <param name="ZeroLineColor">Sets the line color of the zero line.</param>
    /// <param name="Anchor">If set to an opposite-letter axis id (e.g. `x2`, `y`), this axis is bound to the corresponding opposite-letter axis. If set to "free", this axis' position is determined by `position`.</param>
    /// <param name="Side">Determines whether a x (y) axis is positioned at the "bottom" ("left") or "top" ("right") of the plotting area.</param>
    /// <param name="Overlaying">If set a same-letter axis id, this axis is overlaid on top of the corresponding same-letter axis, with traces and axes visible for both axes. If "false", this axis does not overlay any same-letter axes. In this case, for axes with overlapping domains only the highest-numbered axis will be visible.</param>
    /// <param name="AutoShift">Automatically reposition the axis to avoid overlap with other axes with the same `overlaying` value. This repositioning will account for any `shift` amount applied to other axes on the same side with `autoshift` is set to true. Only has an effect if `anchor` is set to "free".</param>
    /// <param name="Shift">Moves the axis a given number of pixels from where it would have been otherwise. Accepts both positive and negative values, which will shift the axis either right or left, respectively. If `autoshift` is set to true, then this defaults to a padding of -3 if `side` is set to "left". and defaults to +3 if `side` is set to "right". Defaults to 0 if `autoshift` is set to false. Only has an effect if `anchor` is set to "free".</param>
    /// <param name="Domain">Tuple of (X*Y fractions). Sets the domain of this axis (in plot fraction).</param>
    /// <param name="Position">Sets the position of this axis in the plotting space (in normalized coordinates). Only has an effect if `anchor` is set to "free".</param>
    /// <param name="CategoryOrder">Specifies the ordering logic for the case of categorical variables. By default, plotly uses "trace", which specifies the order that is present in the data supplied. Set `categoryorder` to "category ascending" or "category descending" if order should be determined by the alphanumerical order of the category names. Set `categoryorder` to "array" to derive the ordering from the attribute `categoryarray`. If a category is not found in the `categoryarray` array, the sorting behavior for that attribute will be identical to the "trace" mode. The unspecified categories will follow the categories in `categoryarray`. Set `categoryorder` to "total ascending" or "total descending" if order should be determined by the numerical order of the values. Similarly, the order can be determined by the min, max, sum, mean or median of all the values.</param>
    /// <param name="CategoryArray">Sets the order in which categories on this axis appear. Only has an effect if `categoryorder` is set to "array". Used with `categoryorder`.</param>
    /// <param name="RangeSlider">Sets a range slider for this axis</param>
    /// <param name="RangeSelector">Sets a range selector for this axis. This object contains toggable presets for the rangeslider.</param>
    /// <param name="BackgroundColor">Sets the background color of this axis' wall. (Only has an effect on 3D scenes)</param>
    /// <param name="ShowBackground">Sets whether or not this axis' wall has a background color. (Only has an effect on 3D scenes)</param>
    /// <param name="Id">The target axis id on which the styles should be applied. Default is 1.</param>
    static member withYAxisStyle
        (
            ?TitleText: string,
            ?TitleFont: Font,
            ?TitleStandoff: int,
            ?Title: Title,
            ?Color: Color,
            ?AxisType: StyleParam.AxisType,
            ?MinMax: #IConvertible * #IConvertible,
            ?Mirror: StyleParam.Mirror,
            ?ShowSpikes: bool,
            ?SpikeColor: Color,
            ?SpikeThickness: int,
            ?ShowLine: bool,
            ?LineColor: Color,
            ?ShowGrid: bool,
            ?GridColor: Color,
            ?GridDash: StyleParam.DrawingStyle,
            ?ZeroLine: bool,
            ?ZeroLineColor: Color,
            ?Anchor: StyleParam.LinearAxisId,
            ?Side: StyleParam.Side,
            ?Overlaying: StyleParam.LinearAxisId,
            ?AutoShift: bool,
            ?Shift: int,
            ?Domain: float * float,
            ?Position: float,
            ?CategoryOrder: StyleParam.CategoryOrder,
            ?CategoryArray: seq<#IConvertible>,
            ?RangeSlider: RangeSlider,
            ?RangeSelector: RangeSelector,
            ?BackgroundColor: Color,
            ?ShowBackground: bool,
            ?Id: StyleParam.SubPlotId
        ) =
        let range =
            MinMax |> Option.map StyleParam.Range.ofMinMax

        let domain =
            Domain |> Option.map StyleParam.Range.ofMinMax

        let title =
            Title
            |> Option.defaultValue (Plotly.NET.Title())
            |> Plotly.NET.Title.style (?Text = TitleText, ?Font = TitleFont, ?Standoff = TitleStandoff)

        let yaxis =
            LinearAxis.init (
                Title = title,
                ?Range = range,
                ?Domain = domain,
                ?Color = Color,
                ?AxisType = AxisType,
                ?Mirror = Mirror,
                ?ShowSpikes = ShowSpikes,
                ?SpikeColor = SpikeColor,
                ?SpikeThickness = SpikeThickness,
                ?ShowLine = ShowLine,
                ?LineColor = LineColor,
                ?ShowGrid = ShowGrid,
                ?GridColor = GridColor,
                ?GridDash = GridDash,
                ?ZeroLine = ZeroLine,
                ?ZeroLineColor = ZeroLineColor,
                ?Anchor = Anchor,
                ?Side = Side,
                ?Overlaying = Overlaying,
                ?AutoShift = AutoShift,
                ?Shift = Shift,
                ?Position = Position,
                ?CategoryOrder = CategoryOrder,
                ?CategoryArray = CategoryArray,
                ?RangeSlider = RangeSlider,
                ?RangeSelector = RangeSelector,
                ?BackgroundColor = BackgroundColor,
                ?ShowBackground = ShowBackground
            )

        Chart.withYAxis (yaxis, ?Id = Id)


    /// <summary>
    /// Sets the given z axis on the input chart's scene, optionally passing a scene axis id.
    ///
    /// If there is already an axis set at the given id, the axis objects are combined.
    /// </summary>
    /// <param name="zAxis">The z axis to set on the chart's layout</param>
    /// <param name="Id">The target scene id on which the axis should be set. Default is 1.</param>
    static member withZAxis(zAxis: LinearAxis, ?Id: int) =
        let id =
            Id |> Option.defaultValue 1 |> StyleParam.SubPlotId.Scene

        fun (ch: GenericChart) ->
            ch |> Chart.setAxis (zAxis, id, SceneAxis = StyleParam.SubPlotId.ZAxis, Combine = true)

    /// <summary>
    /// Sets the given z axis styles on the input chart's scene.
    ///
    /// If there is already an axis set at the given id, the styles are applied to it. If there is no axis present, a new LinearAxis object with the given styles will be set.
    /// </summary>
    /// <param name="TitleText">Sets the text of the axis title.</param>
    /// <param name="TitleFont">Sets the font of the axis title.</param>
    /// <param name="TitleStandoff">Sets the standoff distance (in px) between the axis labels and the title text.</param>
    /// <param name="Title">Sets the Title (use this for more finegrained control than the other title-associated arguments)</param>
    /// <param name="Color">Sets default for all colors associated with this axis all at once: line, font, tick, and grid colors.</param>
    /// <param name="AxisType">Sets the axis type. By default, plotly attempts to determined the axis type by looking into the data of the traces that referenced the axis in question.</param>
    /// <param name="MinMax">Tuple of (Min*Max value). Sets the range of this axis (the axis will go from Min to Max). If the axis `type` is "log", then you must take the log of your desired range (e.g. to set the range from 1 to 100, set the range from 0 to 2).</param>
    /// <param name="Mirror">Determines if and how the axis lines or/and ticks are mirrored to the opposite side of the plotting area.</param>
    /// <param name="ShowSpikes">Determines whether or not spikes (aka droplines) are drawn for this axis.</param>
    /// <param name="SpikeColor">Sets the spike color. If not set, will use the series color</param>
    /// <param name="SpikeThickness">Sets the width (in px) of the zero line.</param>
    /// <param name="ShowLine">Determines whether or not a line bounding this axis is drawn.</param>
    /// <param name="LineColor">Sets the axis line color.</param>
    /// <param name="ShowGrid">Determines whether or not grid lines are drawn. If "true", the grid lines are drawn at every tick mark.</param>
    /// <param name="GridColor">Sets the color of the grid lines.</param>
    /// <param name="ZeroLine">Determines whether or not a line is drawn at along the 0 value of this axis. If "true", the zero line is drawn on top of the grid lines.</param>
    /// <param name="ZeroLineColor">Sets the line color of the zero line.</param>
    /// <param name="Anchor">If set to an opposite-letter axis id (e.g. `x2`, `y`), this axis is bound to the corresponding opposite-letter axis. If set to "free", this axis' position is determined by `position`.</param>
    /// <param name="Side">Determines whether a x (y) axis is positioned at the "bottom" ("left") or "top" ("right") of the plotting area.</param>
    /// <param name="Overlaying">If set a same-letter axis id, this axis is overlaid on top of the corresponding same-letter axis, with traces and axes visible for both axes. If "false", this axis does not overlay any same-letter axes. In this case, for axes with overlapping domains only the highest-numbered axis will be visible.</param>
    /// <param name="Domain">Tuple of (X*Y fractions). Sets the domain of this axis (in plot fraction).</param>
    /// <param name="Position">Sets the position of this axis in the plotting space (in normalized coordinates). Only has an effect if `anchor` is set to "free".</param>
    /// <param name="CategoryOrder">Specifies the ordering logic for the case of categorical variables. By default, plotly uses "trace", which specifies the order that is present in the data supplied. Set `categoryorder` to "category ascending" or "category descending" if order should be determined by the alphanumerical order of the category names. Set `categoryorder` to "array" to derive the ordering from the attribute `categoryarray`. If a category is not found in the `categoryarray` array, the sorting behavior for that attribute will be identical to the "trace" mode. The unspecified categories will follow the categories in `categoryarray`. Set `categoryorder` to "total ascending" or "total descending" if order should be determined by the numerical order of the values. Similarly, the order can be determined by the min, max, sum, mean or median of all the values.</param>
    /// <param name="CategoryArray">Sets the order in which categories on this axis appear. Only has an effect if `categoryorder` is set to "array". Used with `categoryorder`.</param>
    /// <param name="RangeSlider">Sets a range slider for this axis</param>
    /// <param name="RangeSelector">Sets a range selector for this axis. This object contains toggable presets for the rangeslider.</param>
    /// <param name="BackgroundColor">Sets the background color of this axis' wall. (Only has an effect on 3D scenes)</param>
    /// <param name="ShowBackground">Sets whether or not this axis' wall has a background color. (Only has an effect on 3D scenes)</param>
    /// <param name="Id">The target scene id on which the axis styles should be applied. Default is 1.</param>
    static member withZAxisStyle
        (
            ?TitleText: string,
            ?TitleFont: Font,
            ?TitleStandoff: int,
            ?Title: Title,
            ?Color: Color,
            ?AxisType: StyleParam.AxisType,
            ?MinMax: #IConvertible * #IConvertible,
            ?Mirror: StyleParam.Mirror,
            ?ShowSpikes: bool,
            ?SpikeColor: Color,
            ?SpikeThickness: int,
            ?ShowLine: bool,
            ?LineColor: Color,
            ?ShowGrid: bool,
            ?GridColor: Color,
            ?ZeroLine: bool,
            ?ZeroLineColor: Color,
            ?Anchor: StyleParam.LinearAxisId,
            ?Side: StyleParam.Side,
            ?Overlaying: StyleParam.LinearAxisId,
            ?Domain: float * float,
            ?Position: float,
            ?CategoryOrder: StyleParam.CategoryOrder,
            ?CategoryArray: seq<#IConvertible>,
            ?RangeSlider: RangeSlider,
            ?RangeSelector: RangeSelector,
            ?BackgroundColor: Color,
            ?ShowBackground: bool,
            ?Id: int
        ) =
        let range =
            MinMax |> Option.map StyleParam.Range.ofMinMax

        let domain =
            Domain |> Option.map StyleParam.Range.ofMinMax

        let title =
            Title
            |> Option.defaultValue (Plotly.NET.Title())
            |> Plotly.NET.Title.style (?Text = TitleText, ?Font = TitleFont, ?Standoff = TitleStandoff)

        let yaxis =
            LinearAxis.init (
                Title = title,
                ?Range = range,
                ?Domain = domain,
                ?Color = Color,
                ?AxisType = AxisType,
                ?Mirror = Mirror,
                ?ShowSpikes = ShowSpikes,
                ?SpikeColor = SpikeColor,
                ?SpikeThickness = SpikeThickness,
                ?ShowLine = ShowLine,
                ?LineColor = LineColor,
                ?ShowGrid = ShowGrid,
                ?GridColor = GridColor,
                ?ZeroLine = ZeroLine,
                ?ZeroLineColor = ZeroLineColor,
                ?Anchor = Anchor,
                ?Side = Side,
                ?Overlaying = Overlaying,
                ?Position = Position,
                ?CategoryOrder = CategoryOrder,
                ?CategoryArray = CategoryArray,
                ?RangeSlider = RangeSlider,
                ?RangeSelector = RangeSelector,
                ?BackgroundColor = BackgroundColor,
                ?ShowBackground = ShowBackground

            )

        Chart.withZAxis (yaxis, ?Id = Id)

    /// <summary>
    /// Sets the given Scene object with the given id on the input chart's layout.
    /// </summary>
    /// <param name="scene">The Scene object to set on the chart's layout</param>
    /// <param name="id">The target scene id with which the Scene object should be set.</param>
    /// <param name="Combine">Whether or not to combine the objects if there is already an Scene set (default is false)</param>
    static member setScene
        (
            scene: Scene,
            id: StyleParam.SubPlotId,
            ?Combine: bool
        ) =

        let combine = defaultArg Combine false

        (fun (ch: GenericChart) ->
            if combine then
                ch |> GenericChart.mapLayout (Layout.updateSceneById (id, scene))
            else
                ch |> GenericChart.mapLayout (Layout.setScene (id, scene)))

    /// <summary>
    /// Sets the Scene for the chart's layout
    ///
    /// If there is already a Scene set, the objects are combined.
    /// </summary>
    /// <param name="scene">The Scene to set on the chart's layout</param>
    /// <param name="Id">The target scene id on which the scene should be set. Default is 1.</param>
    static member withScene(scene: Scene, ?Id: int) =
        let id =
            Id |> Option.defaultValue 1 |> StyleParam.SubPlotId.Scene

        (fun (ch: GenericChart) -> ch |> Chart.setScene (scene, id, true))

    /// <summary>
    /// Sets the given Scene styles on the target Scene object on the input chart's layout.
    ///
    /// If there is already a Scene set, the styles are applied to it. If there is no Scene present, a new Scene object with the given styles will be set.
    /// </summary>
    /// <param name="Annotations">An annotation is a text element that can be placed anywhere in the plot. It can be positioned with respect to relative coordinates in the plot or with respect to the actual data coordinates of the graph. Annotations can be shown with or without an arrow.</param>
    /// <param name="AspectMode">If "cube", this scene's axes are drawn as a cube, regardless of the axes' ranges. If "data", this scene's axes are drawn in proportion with the axes' ranges. If "manual", this scene's axes are drawn in proportion with the input of "aspectratio" (the default behavior if "aspectratio" is provided). If "auto", this scene's axes are drawn using the results of "data" except when one axis is more than four times the size of the two others, where in that case the results of "cube" are used.</param>
    /// <param name="AspectRatio">Sets this scene's axis aspectratio.</param>
    /// <param name="BGColor">Sets this scene's background color.</param>
    /// <param name="Camera">Sets this scene's camera</param>
    /// <param name="Domain">Sets this scene's domain</param>
    /// <param name="DragMode">Determines the mode of drag interactions for this scene.</param>
    /// <param name="HoverMode">Determines the mode of hover interactions for this scene.</param>
    /// <param name="UIRevision">Controls persistence of user-driven changes in camera attributes. Defaults to `layout.uirevision`.</param>
    /// <param name="XAxis">Sets this scene's xaxis</param>
    /// <param name="YAxis">Sets this scene's yaxis</param>
    /// <param name="ZAxis">Sets this scene's zaxis</param>
    /// <param name="Id">The target scene id</param>
    static member withSceneStyle
        (
            ?Annotations: seq<Annotation>,
            ?AspectMode: StyleParam.AspectMode,
            ?AspectRatio: AspectRatio,
            ?BGColor: Color,
            ?Camera: Camera,
            ?Domain: Domain,
            ?DragMode: StyleParam.DragMode,
            ?HoverMode: StyleParam.HoverMode,
            ?UIRevision: string,
            ?XAxis: LinearAxis,
            ?YAxis: LinearAxis,
            ?ZAxis: LinearAxis,
            ?Id: int
        ) =
        (fun (ch: GenericChart) ->
            let scene =
                Scene.init (
                    ?Annotations = Annotations,
                    ?AspectMode = AspectMode,
                    ?AspectRatio = AspectRatio,
                    ?BGColor = BGColor,
                    ?Camera = Camera,
                    ?Domain = Domain,
                    ?DragMode = DragMode,
                    ?HoverMode = HoverMode,
                    ?UIRevision = UIRevision,
                    ?XAxis = XAxis,
                    ?YAxis = YAxis,
                    ?ZAxis = ZAxis
                )

            ch |> Chart.withScene (scene, ?Id = Id))

    /// <summary>
    /// Sets the given Polar object with the given id on the input chart's layout.
    /// </summary>
    /// <param name="polar">The Polar object to set on the chart's layout</param>
    /// <param name="id">The target polar id with which the Polar object should be set.</param>
    /// <param name="Combine">Whether or not to combine the objects if there is already an Polar set (default is false)</param>
    static member setPolar
        (
            polar: Polar,
            id: StyleParam.SubPlotId,
            ?Combine: bool
        ) =

        let combine = defaultArg Combine false

        (fun (ch: GenericChart) ->
            if combine then
                ch |> GenericChart.mapLayout (Layout.updatePolarById (id, polar))
            else
                ch |> GenericChart.mapLayout (Layout.setPolar (id, polar)))

    /// <summary>
    /// Sets the Polar for the chart's layout
    ///
    /// If there is already a Polar set, the objects are combined.
    /// </summary>
    /// <param name="polar">The new Polar for the chart's layout</param>
    /// <param name="Id">The target polar id on which the polar object should be set. Default is 1.</param>
    static member withPolar(polar: Polar, ?Id: int) =
        let id =
            Id |> Option.defaultValue 1 |> StyleParam.SubPlotId.Polar

        (fun (ch: GenericChart) -> ch |> Chart.setPolar (polar, id, true))

    /// <summary>
    /// Sets the given Polar styles on the target Polar object on the input chart's layout.
    ///
    /// If there is already a Polar set, the styles are applied to it. If there is no Polar present, a new Polar object with the given styles will be set.
    /// </summary>
    /// <param name="Domain">Sets the domain of this polar subplot</param>
    /// <param name="Sector">Sets angular span of this polar subplot with two angles (in degrees). Sector are assumed to be spanned in the counterclockwise direction with "0" corresponding to rightmost limit of the polar subplot.</param>
    /// <param name="Hole">Sets the fraction of the radius to cut out of the polar subplot.</param>
    /// <param name="BGColor">Set the background color of the subplot</param>
    /// <param name="RadialAxis">Sets the radial axis of the polar subplot.</param>
    /// <param name="AngularAxis">Sets the angular axis of the polar subplot.</param>
    /// <param name="GridShape">Determines if the radial axis grid lines and angular axis line are drawn as "circular" sectors or as "linear" (polygon) sectors. Has an effect only when the angular axis has `type` "category". Note that `radialaxis.angle` is snapped to the angle of the closest vertex when `gridshape` is "circular" (so that radial axis scale is the same as the data scale).</param>
    /// <param name="UIRevision">Controls persistence of user-driven changes in axis attributes, if not overridden in the individual axes. Defaults to `layout.uirevision`.</param>
    /// <param name="Id">The target polar id</param>
    static member withPolarStyle
        (
            ?Domain: Domain,
            ?Sector: float * float,
            ?Hole: float,
            ?BGColor: Color,
            ?RadialAxis: RadialAxis,
            ?AngularAxis: AngularAxis,
            ?GridShape: StyleParam.PolarGridShape,
            ?UIRevision: string,
            ?Id: int
        ) =
        (fun (ch: GenericChart) ->
            let polar =
                Polar.init (
                    ?Domain = Domain,
                    ?Sector = Sector,
                    ?Hole = Hole,
                    ?BGColor = BGColor,
                    ?RadialAxis = RadialAxis,
                    ?AngularAxis = AngularAxis,
                    ?GridShape = GridShape,
                    ?UIRevision = UIRevision
                )

            ch |> Chart.withPolar (polar, ?Id = Id))

    /// <summary>
    /// Sets the angular axis on the polar object with the given id on the input chart's layout.
    /// </summary>
    /// <param name="angularAxis">The AngularAxis to set on the target polar object on the chart's layout</param>
    /// <param name="id">The target polar id with which the AngularAxis should be set.(default is 1)</param>
    /// <param name="Combine">Whether or not to combine the objects if there is already an axis set (default is false)</param>
    static member setAngularAxis
        (
            angularAxis: AngularAxis,
            id: StyleParam.SubPlotId,
            ?Combine: bool
        ) =

        fun (ch: GenericChart) ->

            let combine = defaultArg Combine false

            match id with
            | StyleParam.SubPlotId.Polar _ ->

                ch
                |> GenericChart.mapLayout (fun layout ->
                    let polar = layout |> Layout.getPolarById id

                    if combine then
                        let currentAxis =
                            polar |> Polar.getAngularAxis

                        let updatedAxis = DynObj.combine currentAxis angularAxis |> unbox<AngularAxis>

                        let updatedPolar =
                            polar |> Polar.setAngularAxis updatedAxis

                        layout |> Layout.updatePolarById (id, updatedPolar)

                    else
                        let updatedPolar =
                            layout |> Layout.getPolarById id |> Polar.setAngularAxis angularAxis

                        layout |> Layout.updatePolarById (id, updatedPolar))

            | _ -> failwith $"{StyleParam.SubPlotId.toString id} is an invalid subplot id for setting an angular axis"

    /// <summary>
    /// Sets the AngularAxis on the polar object with the given id on the input chart's layout.
    ///
    /// If there is already a AngularAxis set on the polar object, the AngularAxis objects are combined.
    /// </summary>
    /// <param name="angularAxis">The new AngularAxis for the chart layout's polar object</param>
    /// <param name="Id">The target polar id on which the AngularAxis should be set. Default is 1.</param>
    static member withAngularAxis(angularAxis: AngularAxis, ?Id: int) =
        let id =
            Id |> Option.defaultValue 1 |> StyleParam.SubPlotId.Polar

        (fun (ch: GenericChart) -> ch |> Chart.setAngularAxis (angularAxis, id, true))

    /// <summary>
    /// Sets the RadialAxis on the polar object with the given id on the input chart's layout.
    /// </summary>
    /// <param name="radialAxis">The RadialAxis to set on the target polar object on the chart's layout</param>
    /// <param name="id">The target polar id with which the RadialAxis should be set.(default is 1)</param>
    /// <param name="Combine">Whether or not to combine the objects if there is already an axis set (default is false)</param>
    static member setRadialAxis
        (
            radialAxis: RadialAxis,
            id: StyleParam.SubPlotId,
            ?Combine: bool
        ) =

        fun (ch: GenericChart) ->

            let combine = defaultArg Combine false

            match id with
            | StyleParam.SubPlotId.Polar _ ->

                ch
                |> GenericChart.mapLayout (fun layout ->
                    let polar = layout |> Layout.getPolarById id

                    if combine then
                        let currentAxis =
                            polar |> Polar.getRadialAxis

                        let updatedAxis =
                            DynObj.combine currentAxis radialAxis |> unbox<RadialAxis>

                        let updatedPolar =
                            polar |> Polar.setRadialAxis updatedAxis

                        layout |> Layout.updatePolarById (id, updatedPolar)

                    else
                        let updatedPolar =
                            layout |> Layout.getPolarById id |> Polar.setRadialAxis radialAxis

                        layout |> Layout.updatePolarById (id, updatedPolar))

            | _ -> failwith $"{StyleParam.SubPlotId.toString id} is an invalid subplot id for setting an radial axis"

    /// <summary>
    /// Sets the RadialAxis on the polar object with the given id on the input chart's layout.
    ///
    /// If there is already a RadialAxis set on the polar object, the RadialAxis objects are combined.
    /// </summary>
    /// <param name="radialAxis">The new RadialAxis for the chart layout's polar object</param>
    /// <param name="Id">The target polar id on which the RadialAxis should be set. Default is 1.</param>
    static member withRadialAxis(radialAxis: RadialAxis, ?Id: int) =
        let id =
            Id |> Option.defaultValue 1 |> StyleParam.SubPlotId.Polar

        (fun (ch: GenericChart) -> ch |> Chart.setRadialAxis (radialAxis, id, true))

    /// <summary>
    /// Sets the given Smith object with the given id on the input chart's layout.
    /// </summary>
    /// <param name="smith">The Smith object to set on the chart's layout</param>
    /// <param name="id">The target smith id with which the Smith object should be set.</param>
    /// <param name="Combine">Whether or not to combine the objects if there is already an Smith set (default is false)</param>
    static member setSmith
        (
            smith: Smith,
            id: StyleParam.SubPlotId,
            ?Combine: bool
        ) =

        let combine = defaultArg Combine false

        (fun (ch: GenericChart) ->
            if combine then
                ch |> GenericChart.mapLayout (Layout.updateSmithById (id, smith))
            else
                ch |> GenericChart.mapLayout (Layout.setSmith (id, smith)))

    /// <summary>
    /// Sets the Smith for the chart's layout
    ///
    /// If there is already a Smith set, the objects are combined.
    /// </summary>
    /// <param name="smith">The new Smith for the chart's layout</param>
    /// <param name="Id">The target smith id on which the smith object should be set. Default is 1.</param>
    static member withSmith(smith: Smith, ?Id: int) =
        let id =
            Id |> Option.defaultValue 1 |> StyleParam.SubPlotId.Smith

        (fun (ch: GenericChart) -> ch |> Chart.setSmith (smith, id, true))

    /// <summary>
    /// Sets the given Smith styles on the target Smith object on the input chart's layout.
    ///
    /// If there is already a Smith set, the styles are applied to it. If there is no Smith present, a new Smith object with the given styles will be set.
    /// </summary>
    static member withSmithStyle
        (
            ?BGColor: Color,
            ?Domain: Domain,
            ?ImaginaryAxis: ImaginaryAxis,
            ?RealAxis: RealAxis,
            ?Id: int
        ) =
        (fun (ch: GenericChart) ->
            let smith =
                Smith.init (?BGColor = BGColor, ?Domain = Domain, ?ImaginaryAxis = ImaginaryAxis, ?RealAxis = RealAxis)

            ch |> Chart.withSmith (smith, ?Id = Id))

    /// <summary>
    /// Sets the imaginary Axis on the polar object with the given id on the input chart's layout.
    /// </summary>
    /// <param name="imaginaryAxis">The ImaginaryAxis to set on the target polar object on the chart's layout</param>
    /// <param name="id">The target polar id with which the ImaginaryAxis should be set.(default is 1)</param>
    /// <param name="Combine">Whether or not to combine the objects if there is already an axis set (default is false)</param>
    static member setImaginaryAxis
        (
            imaginaryAxis: ImaginaryAxis,
            id: StyleParam.SubPlotId,
            ?Combine: bool
        ) =

        fun (ch: GenericChart) ->

            let combine = defaultArg Combine false

            match id with
            | StyleParam.SubPlotId.Smith _ ->

                ch
                |> GenericChart.mapLayout (fun layout ->
                    let smith = layout |> Layout.getSmithById id

                    if combine then
                        let currentAxis =
                            smith |> Smith.getImaginaryAxis

                        let updatedAxis = DynObj.combine currentAxis imaginaryAxis |> unbox<ImaginaryAxis>

                        let updatedSmith =
                            smith |> Smith.setImaginaryAxis updatedAxis 

                        layout |> Layout.updateSmithById (id, updatedSmith)

                    else
                        let updatedSmith =
                            layout |> Layout.getSmithById id |> Smith.setImaginaryAxis imaginaryAxis

                        layout |> Layout.updateSmithById (id, updatedSmith))

            | _ -> failwith $"{StyleParam.SubPlotId.toString id} is an invalid subplot id for setting an imaginary Axis"

    /// <summary>
    /// Sets the ImaginaryAxis on the smith object with the given id on the input chart's layout.
    ///
    /// If there is already a ImaginaryAxis set on the smith object, the ImaginaryAxis objects are combined.
    /// </summary>
    /// <param name="imaginaryAxis">The new ImaginaryAxis for the chart layout's smith object</param>
    /// <param name="Id">The target smith id on which the ImaginaryAxis should be set. Default is 1.</param>
    static member withImaginaryAxis(imaginaryAxis: ImaginaryAxis, ?Id: int) =
        let id =
            Id |> Option.defaultValue 1 |> StyleParam.SubPlotId.Smith

        (fun (ch: GenericChart) -> ch |> Chart.setImaginaryAxis (imaginaryAxis, id, true))

    /// <summary>
    /// Sets the RealAxis on the smith object with the given id on the input chart's layout.
    /// </summary>
    /// <param name="realAxis">The RealAxis to set on the target smith object on the chart's layout</param>
    /// <param name="id">The target smith id with which the RealAxis should be set.(default is 1)</param>
    /// <param name="Combine">Whether or not to combine the objects if there is already an axis set (default is false)</param>
    static member setRealAxis
        (
            realAxis: RealAxis,
            id: StyleParam.SubPlotId,
            ?Combine: bool
        ) =

        fun (ch: GenericChart) ->

            let combine = defaultArg Combine false

            match id with
            | StyleParam.SubPlotId.Smith _ ->

                ch
                |> GenericChart.mapLayout (fun layout ->
                    let smith = layout |> Layout.getSmithById id

                    if combine then
                        let currentAxis = smith |> Smith.getRealAxis

                        let updatedAxis = DynObj.combine currentAxis realAxis |> unbox<RealAxis>

                        let updatedSmith =
                            smith |> Smith.setRealAxis updatedAxis 

                        layout |> Layout.updateSmithById (id, updatedSmith)

                    else
                        let updatedSmith =
                            layout |> Layout.getSmithById id |> Smith.setRealAxis realAxis

                        layout |> Layout.updateSmithById (id, updatedSmith))

            | _ -> failwith $"{StyleParam.SubPlotId.toString id} is an invalid subplot id for setting an real axis"

    /// <summary>
    /// Sets the RealAxis on the smith object with the given id on the input chart's layout.
    ///
    /// If there is already a RealAxis set on the smith object, the RealAxis objects are combined.
    /// </summary>
    /// <param name="realAxis">The new RealAxis for the chart layout's smith object</param>
    /// <param name="Id">The target smith id on which the RealAxis should be set. Default is 1.</param>
    static member withRealAxis(realAxis: RealAxis, ?Id: int) =
        let id =
            Id |> Option.defaultValue 1 |> StyleParam.SubPlotId.Smith

        (fun (ch: GenericChart) -> ch |> Chart.setRealAxis (realAxis, id, true))

    /// <summary>
    /// Sets the given Geo object with the given id on the input chart's layout.
    /// </summary>
    /// <param name="geo">The Geo object to set on the chart's layout</param>
    /// <param name="id">The target Geo id with which the Geo object should be set.</param>
    /// <param name="Combine">Whether or not to combine the objects if there is already an Geo set (default is false)</param>
    static member setGeo(geo: Geo, id: StyleParam.SubPlotId, ?Combine: bool) =

        let combine = defaultArg Combine false

        (fun (ch: GenericChart) ->
            if combine then
                ch |> GenericChart.mapLayout (Layout.updateGeoById (id, geo))
            else
                ch |> GenericChart.mapLayout (Layout.setGeo (id, geo)))

    /// <summary>
    /// Sets the Geo for the chart's layout
    ///
    /// If there is already a Geo set, the objects are combined.
    /// </summary>
    /// <param name="geo">The new Geo for the chart's layout</param>
    /// <param name="Id">The target geo id on which the Geo should be set. Default is 1.</param>
    static member withGeo(geo: Geo, ?Id: int) =
        let id =
            Id |> Option.defaultValue 1 |> StyleParam.SubPlotId.Geo

        (fun (ch: GenericChart) -> ch |> Chart.setGeo (geo, id, true))

    /// <summary>
    /// Sets the given Geo styles on the target geo on the input chart's layout.
    ///
    /// If there is already a Geo set, the styles are applied to it. If there is no Geo present, a new Geo object with the given styles will be set.
    /// </summary>
    /// <param name="FitBounds">Determines if and how this subplot's view settings are auto-computed to fit trace data</param>
    /// <param name="Resolution">Sets the resolution of the base layers</param>
    /// <param name="Scope">Set the scope of the map.</param>
    /// <param name="Projection">Determines the type of projection used to display the map</param>
    /// <param name="Center">Sets the (lon,lat) coordinates of the map's center. By default, the map's longitude center lies at the middle of the longitude range for scoped projection and above `projection.rotation.lon` otherwise. For all projection types, the map's latitude center lies at the middle of the latitude range by default.</param>
    /// <param name="Visible">Whether or not the base layers are visible</param>
    /// <param name="Domain">The domain of this geo subplot</param>
    /// <param name="ShowCoastLines">Sets whether or not the coastlines are drawn.</param>
    /// <param name="CoastLineColor">Sets the coastline color.</param>
    /// <param name="CoastLineWidth">Sets the coastline stroke width (in px).</param>
    /// <param name="ShowLand">Sets whether or not land masses are filled in color.</param>
    /// <param name="LandColor">Sets the land mass color.</param>
    /// <param name="ShowOcean">Sets whether or not oceans are filled in color.</param>
    /// <param name="OceanColor">Sets the ocean color</param>
    /// <param name="ShowLakes">Sets whether or not lakes are drawn.</param>
    /// <param name="LakeColor">Sets the color of the lakes.</param>
    /// <param name="ShowRivers">Sets whether or not rivers are drawn.</param>
    /// <param name="RiverColor">Sets color of the rivers.</param>
    /// <param name="RiverWidth">Sets the stroke width (in px) of the rivers.</param>
    /// <param name="ShowCountries">Sets whether or not country boundaries are drawn.</param>
    /// <param name="CountryColor">Sets line color of the country boundaries.</param>
    /// <param name="CountryWidth">Sets line width (in px) of the country boundaries.</param>
    /// <param name="ShowSubunits">Sets whether or not boundaries of subunits within countries (e.g. states, provinces) are drawn.</param>
    /// <param name="SubunitColor">Sets the color of the subunits boundaries.</param>
    /// <param name="SubunitWidth">Sets the stroke width (in px) of the subunits boundaries.</param>
    /// <param name="ShowFrame">Sets whether or not a frame is drawn around the map.</param>
    /// <param name="FrameColor">Sets the color the frame.</param>
    /// <param name="FrameWidth">Sets the stroke width (in px) of the frame.</param>
    /// <param name="BgColor">Set the background color of the map</param>
    /// <param name="LatAxis">Sets the latitudinal axis for this geo trace</param>
    /// <param name="LonAxis">Sets the longitudinal axis for this geo trace</param>
    /// <param name="Id">the target geo id</param>
    static member withGeoStyle
        (
            ?FitBounds: StyleParam.GeoFitBounds,
            ?Resolution: StyleParam.GeoResolution,
            ?Scope: StyleParam.GeoScope,
            ?Projection: GeoProjection,
            ?Center: (float * float),
            ?Visible: bool,
            ?Domain: Domain,
            ?ShowCoastLines: bool,
            ?CoastLineColor: Color,
            ?CoastLineWidth: float,
            ?ShowLand: bool,
            ?LandColor: Color,
            ?ShowOcean: bool,
            ?OceanColor: Color,
            ?ShowLakes: bool,
            ?LakeColor: Color,
            ?ShowRivers: bool,
            ?RiverColor: Color,
            ?RiverWidth: float,
            ?ShowCountries: bool,
            ?CountryColor: Color,
            ?CountryWidth: float,
            ?ShowSubunits: bool,
            ?SubunitColor: Color,
            ?SubunitWidth: float,
            ?ShowFrame: bool,
            ?FrameColor: Color,
            ?FrameWidth: float,
            ?BgColor: Color,
            ?LatAxis: LinearAxis,
            ?LonAxis: LinearAxis,
            ?Id: int
        ) =
        (fun (ch: GenericChart) ->
            let geo =
                Geo.init (
                    ?FitBounds = FitBounds,
                    ?Resolution = Resolution,
                    ?Scope = Scope,
                    ?Projection = Projection,
                    ?Center = Center,
                    ?Visible = Visible,
                    ?Domain = Domain,
                    ?ShowCoastLines = ShowCoastLines,
                    ?CoastLineColor = CoastLineColor,
                    ?CoastLineWidth = CoastLineWidth,
                    ?ShowLand = ShowLand,
                    ?LandColor = LandColor,
                    ?ShowOcean = ShowOcean,
                    ?OceanColor = OceanColor,
                    ?ShowLakes = ShowLakes,
                    ?LakeColor = LakeColor,
                    ?ShowRivers = ShowRivers,
                    ?RiverColor = RiverColor,
                    ?RiverWidth = RiverWidth,
                    ?ShowCountries = ShowCountries,
                    ?CountryColor = CountryColor,
                    ?CountryWidth = CountryWidth,
                    ?ShowSubunits = ShowSubunits,
                    ?SubunitColor = SubunitColor,
                    ?SubunitWidth = SubunitWidth,
                    ?ShowFrame = ShowFrame,
                    ?FrameColor = FrameColor,
                    ?FrameWidth = FrameWidth,
                    ?BgColor = BgColor,
                    ?LatAxis = LatAxis,
                    ?LonAxis = LonAxis
                )

            ch |> Chart.withGeo (geo, ?Id = Id))

    /// <summary>
    /// Sets the given Geo Projection styles on the target geo on the input chart's layout.
    ///
    /// If there is already a Geo set, the styles are applied to it. If there is no Geo present, a new Geo object with the given styles will be set.
    /// </summary>
    /// <param name="projectionType">Sets the type of projection</param>
    /// <param name="Rotation">Sets the rotation applied to the map</param>
    /// <param name="Parallels">For conic projection types only. Sets the parallels (tangent, secant) where the cone intersects the sphere.</param>
    /// <param name="Scale">Zooms in or out on the map view. A scale of "1" corresponds to the largest zoom level that fits the map's lon and lat ranges.</param>
    /// <param name="Id">the target geo id</param>
    static member withGeoProjection
        (
            projectionType: StyleParam.GeoProjectionType,
            ?Rotation,
            ?Parallels,
            ?Scale,
            ?Id: int
        ) =
        (fun (ch: GenericChart) ->

            let projection =
                GeoProjection.init (
                    projectionType = projectionType,
                    ?Rotation = Rotation,
                    ?Parallels = Parallels,
                    ?Scale = Scale
                )

            let map = Geo.init (Projection = projection)

            ch |> Chart.withGeo (map, ?Id = Id))

    /// <summary>
    /// Sets the given Mapbox object with the given id on the input chart's layout.
    /// </summary>
    /// <param name="mapbox">The Mapbox object to set on the chart's layout</param>
    /// <param name="id">The target Mapbox id with which the Mapbox object should be set.</param>
    /// <param name="Combine">Whether or not to combine the objects if there is already an Mapbox set (default is false)</param>
    static member setMapbox
        (
            mapbox: Mapbox,
            id: StyleParam.SubPlotId,
            ?Combine: bool
        ) =

        let combine = defaultArg Combine false

        (fun (ch: GenericChart) ->
            if combine then
                ch |> GenericChart.mapLayout (Layout.updateMapboxById (id, mapbox))
            else
                ch |> GenericChart.mapLayout (Layout.setMapbox (id, mapbox)))

    /// <summary>
    /// Sets the Mapbox for the chart's layout
    ///
    /// If there is already a Mapbox set, the objects are combined.
    /// </summary>
    /// <param name="mapbox">The Mapbox to set on the chart's layout</param>
    /// <param name="Id">The target mapbox id on which the Mapbox should be set. Default is 1.</param>
    static member withMapbox(mapbox: Mapbox, ?Id: int) =
        let id =
            Id |> Option.defaultValue 1 |> StyleParam.SubPlotId.Mapbox

        (fun (ch: GenericChart) -> ch |> Chart.setMapbox (mapbox, id, true))

    /// <summary>
    /// Sets the given Mapbox styles on the target Mapbox object on the input chart's layout.
    ///
    /// If there is already a Mapbox set, the styles are applied to it. If there is no Mapbox present, a new Mapbox object with the given styles will be set.
    /// </summary>
    /// <param name="Domain">Sets the domain of the Mapbox subplot</param>
    /// <param name="AccessToken">Sets the mapbox access token to be used for this mapbox map. Alternatively, the mapbox access token can be set in the configuration options under `mapboxAccessToken`. Note that accessToken are only required when `style` (e.g with values : basic, streets, outdoors, light, dark, satellite, satellite-streets ) and/or a layout layer references the Mapbox server.</param>
    /// <param name="Style">Defines the map layers that are rendered by default below the trace layers defined in `data`, which are themselves by default rendered below the layers defined in `layout.mapbox.layers`. These layers can be defined either explicitly as a Mapbox Style object which can contain multiple layer definitions that load data from any public or private Tile Map Service (TMS or XYZ) or Web Map Service (WMS) or implicitly by using one of the built-in style objects which use WMSes which do not require any access tokens, or by using a default Mapbox style or custom Mapbox style URL, both of which require a Mapbox access token Note that Mapbox access token can be set in the `accesstoken` attribute or in the `mapboxAccessToken` config option. Mapbox Style objects are of the form described in the Mapbox GL JS documentation available at https://docs.mapbox.com/mapbox-gl-js/style-spec The built-in plotly.js styles objects are: carto-darkmatter, carto-positron, open-street-map, stamen-terrain, stamen-toner, stamen-watercolor, white-bg The built-in Mapbox styles are: basic, streets, outdoors, light, dark, satellite, satellite-streets Mapbox style URLs are of the form: mapbox://mapbox.mapbox/name/version</param>
    /// <param name="Center">Sets the (lon,lat) coordinates of the center of the map view</param>
    /// <param name="Zoom">Sets the zoom level of the map (mapbox.zoom).</param>
    /// <param name="Bearing">Sets the bearing angle of the map in degrees counter-clockwise from North (mapbox.bearing).</param>
    /// <param name="Pitch">Sets the pitch angle of the map (in degrees, where "0" means perpendicular to the surface of the map) (mapbox.pitch).</param>
    /// <param name="Layers">Sets the layers of this Mapbox</param>
    /// <param name="Id">The target mapbox id</param>
    static member withMapboxStyle
        (
            ?Domain: Domain,
            ?AccessToken: string,
            ?Style: StyleParam.MapboxStyle,
            ?Center: (float * float),
            ?Zoom: float,
            ?Bearing: float,
            ?Pitch: float,
            ?Layers: seq<MapboxLayer>,
            ?Id: int
        ) =
        (fun (ch: GenericChart) ->
            let mapbox =
                Mapbox.init (
                    ?Domain = Domain,
                    ?AccessToken = AccessToken,
                    ?Style = Style,
                    ?Center = Center,
                    ?Zoom = Zoom,
                    ?Bearing = Bearing,
                    ?Pitch = Pitch,
                    ?Layers = Layers
                )

            ch |> Chart.withMapbox (mapbox, ?Id = Id))

    /// <summary>
    /// Sets the given Ternary object with the given id on the input chart's layout.
    /// </summary>
    /// <param name="ternary">The Ternary object to set on the chart's layout</param>
    /// <param name="id">The target Ternary id with which the Ternary object should be set.</param>
    /// <param name="Combine">Whether or not to combine the objects if there is already an Ternary set (default is false)</param>
    static member setTernary
        (
            ternary: Ternary,
            id: StyleParam.SubPlotId,
            ?Combine: bool
        ) =

        let combine = defaultArg Combine false

        (fun (ch: GenericChart) ->
            if combine then
                ch |> GenericChart.mapLayout (Layout.updateTernaryById (id, ternary))
            else
                ch |> GenericChart.mapLayout (Layout.setTernary (id, ternary)))

    /// <summary>
    /// Sets the Ternary for the chart's layout
    ///
    /// If there is already a Ternary set, the objects are combined.
    /// </summary>
    /// <param name="ternary">The Ternary to set on the chart's layout</param>
    /// <param name="Id">The target ternary id on which the Ternary should be set. Default is 1.</param>
    static member withTernary(ternary: Ternary, ?Id: int) =
        let id =
            Id |> Option.defaultValue 1 |> StyleParam.SubPlotId.Ternary

        (fun (ch: GenericChart) -> ch |> Chart.setTernary (ternary, id, true))

    /// <summary>
    /// Sets the given Ternary styles on the target Ternary object on the input chart's layout.
    ///
    /// If there is already a Ternary set, the styles are applied to it. If there is no Ternary present, a new Ternary object with the given styles will be set.
    /// </summary>
    /// <param name="AAxis">Sets the ternary A Axis</param>
    /// <param name="BAxis">Sets the ternary B Axis</param>
    /// <param name="CAxis">Sets the ternary C Axis</param>
    /// <param name="Domain">Sets the ternary domain</param>
    /// <param name="Sum">The number each triplet should sum to, and the maximum range of each axis</param>
    /// <param name="BGColor">Sets the background color of the ternary layout.</param>
    /// <param name="Id">The target Ternary id</param>
    static member withTernaryStyle
        (
            ?AAxis: LinearAxis,
            ?BAxis: LinearAxis,
            ?CAxis: LinearAxis,
            ?Domain: Domain,
            ?Sum: #IConvertible,
            ?BGColor: Color,
            ?Id: int
        ) =
        (fun (ch: GenericChart) ->
            let ternary =
                Ternary.init (
                    ?AAxis = AAxis,
                    ?BAxis = BAxis,
                    ?CAxis = CAxis,
                    ?Domain = Domain,
                    ?Sum = Sum,
                    ?BGColor = BGColor
                )

            ch |> Chart.withTernary (ternary, ?Id = Id))

    /// <summary>
    /// Sets the a axis on the ternary object with the given id on the input chart's layout.
    /// </summary>
    /// <param name="aAxis">The a Axis to set on the target ternary object on the chart's layout</param>
    /// <param name="id">The target ternary id with which the a Axis should be set.(default is 1)</param>
    /// <param name="Combine">Whether or not to combine the objects if there is already an axis set (default is false)</param>
    static member setAAxis
        (
            aAxis: LinearAxis,
            id: StyleParam.SubPlotId,
            ?Combine: bool
        ) =

        fun (ch: GenericChart) ->

            let combine = defaultArg Combine false

            match id with
            | StyleParam.SubPlotId.Ternary _ ->

                ch
                |> GenericChart.mapLayout (fun layout ->
                    let ternary =
                        layout |> Layout.getTernaryById id

                    if combine then
                        let currentAxis =
                            ternary |> Ternary.getAAxis

                        let updatedAxis = DynObj.combine currentAxis aAxis |> unbox<LinearAxis>

                        let updatedTernary =
                            ternary |> Ternary.setAAxis updatedAxis 

                        layout |> Layout.updateTernaryById (id, updatedTernary)

                    else
                        let updatedTernary =
                            layout |> Layout.getTernaryById id |> Ternary.setAAxis aAxis

                        layout |> Layout.updateTernaryById (id, updatedTernary))

            | _ -> failwith $"{StyleParam.SubPlotId.toString id} is an invalid subplot id for setting an a axis"

    /// <summary>
    /// Sets the a axis on the ternary object with the given id on the input chart's layout.
    ///
    /// If there is already a a axis set on the ternary object, the a axis objects are combined.
    /// </summary>
    /// <param name="aAxis">The new a axis for the chart layout's ternary object</param>
    /// <param name="Id">The target ternary id on which the a axis should be set. Default is 1.</param>
    static member withAAxis(aAxis: LinearAxis, ?Id: int) =
        let id =
            Id |> Option.defaultValue 1 |> StyleParam.SubPlotId.Ternary

        (fun (ch: GenericChart) -> ch |> Chart.setAAxis (aAxis, id, true))

    /// <summary>
    /// Sets the b axis on the ternary object with the given id on the input chart's layout.
    /// </summary>
    /// <param name="bAxis">The b Axis to set on the target ternary object on the chart's layout</param>
    /// <param name="id">The target ternary id with which the b Axis should be set.(default is 1)</param>
    /// <param name="Combine">Whether or not to combine the objects if there is already an axis set (default is false)</param>
    static member setBAxis
        (
            bAxis: LinearAxis,
            id: StyleParam.SubPlotId,
            ?Combine: bool
        ) =

        fun (ch: GenericChart) ->

            let combine = defaultArg Combine false

            match id with
            | StyleParam.SubPlotId.Ternary _ ->

                ch
                |> GenericChart.mapLayout (fun layout ->
                    let ternary =
                        layout |> Layout.getTernaryById id

                    if combine then
                        let currentAxis =
                            ternary |> Ternary.getBAxis

                        let updatedAxis = DynObj.combine currentAxis bAxis |> unbox<LinearAxis>

                        let updatedTernary =
                            ternary |> Ternary.setBAxis updatedAxis

                        layout |> Layout.updateTernaryById (id, updatedTernary)

                    else
                        let updatedTernary =
                            layout |> Layout.getTernaryById id |> Ternary.setBAxis bAxis

                        layout |> Layout.updateTernaryById (id, updatedTernary))

            | _ -> failwith $"{StyleParam.SubPlotId.toString id} is an invalid subplot id for setting a b axis"

    /// <summary>
    /// Sets the b axis on the ternary object with the given id on the input chart's layout.
    ///
    /// If there is already a b axis set on the ternary object, the b axis objects are combined.
    /// </summary>
    /// <param name="bAxis">The new b axis for the chart layout's ternary object</param>
    /// <param name="Id">The target ternary id on which the b axis should be set. Default is 1.</param>
    static member withBAxis(bAxis: LinearAxis, ?Id: int) =
        let id =
            Id |> Option.defaultValue 1 |> StyleParam.SubPlotId.Ternary

        (fun (ch: GenericChart) -> ch |> Chart.setBAxis (bAxis, id, true))

    /// <summary>
    /// Sets the c axis on the ternary object with the given id on the input chart's layout.
    /// </summary>
    /// <param name="cAxis">The c Axis to set on the target ternary object on the chart's layout</param>
    /// <param name="id">The target ternary id with which the c Axis should be set.(default is 1)</param>
    /// <param name="Combine">Whether or not to combine the objects if there is already an axis set (default is false)</param>
    static member setCAxis
        (
            cAxis: LinearAxis,
            id: StyleParam.SubPlotId,
            ?Combine: bool
        ) =

        fun (ch: GenericChart) ->

            let combine = defaultArg Combine false

            match id with
            | StyleParam.SubPlotId.Ternary _ ->

                ch
                |> GenericChart.mapLayout (fun layout ->
                    let ternary =
                        layout |> Layout.getTernaryById id

                    if combine then
                        let currentAxis =
                            ternary |> Ternary.getCAxis

                        let updatedAxis = DynObj.combine currentAxis cAxis |> unbox<LinearAxis>

                        let updatedTernary =
                            ternary |> Ternary.setCAxis updatedAxis

                        layout |> Layout.updateTernaryById (id, updatedTernary)

                    else
                        let updatedTernary =
                            layout |> Layout.getTernaryById id |> Ternary.setBAxis cAxis

                        layout |> Layout.updateTernaryById (id, updatedTernary))

            | _ -> failwith $"{StyleParam.SubPlotId.toString id} is an invalid subplot id for setting a c axis"

    /// <summary>
    /// Sets the c axis on the ternary object with the given id on the input chart's layout.
    ///
    /// If there is already a c axis set on the ternary object, the c axis objects are combined.
    /// </summary>
    /// <param name="cAxis">The new c axis for the chart layout's ternary object</param>
    /// <param name="Id">The target ternary id on which the c axis should be set. Default is 1.</param>
    static member withCAxis(cAxis: LinearAxis, ?Id: int) =
        let id =
            Id |> Option.defaultValue 1 |> StyleParam.SubPlotId.Ternary

        (fun (ch: GenericChart) -> ch |> Chart.setCAxis (cAxis, id, true))

    /// <summary>
    /// Sets the LayoutGrid for the chart's layout.
    /// </summary>
    /// <param name="layoutGrid">The new LayoutGrid for the chart's layout</param>
    /// <param name="Combine">Whether or not to combine the objects if there is already a ColorBar object set (default is false)</param>
    static member setLayoutGrid(layoutGrid: LayoutGrid, ?Combine: bool) =
        let combine = defaultArg Combine false

        (fun (ch: GenericChart) ->
            if combine then
                ch |> GenericChart.mapLayout (Layout.updateLayoutGrid layoutGrid)
            else
                ch |> GenericChart.mapLayout (Layout.setLayoutGrid layoutGrid))

    /// <summary>
    /// Sets the LayoutGrid for the chart's layout
    ///
    /// If there is already a LayoutGrid set, the objects are combined.
    /// </summary>
    /// <param name="layoutGrid">The new LayoutGrid for the chart's layout</param>
    static member withLayoutGrid(layoutGrid: LayoutGrid) =
        (fun (ch: GenericChart) -> ch |> Chart.setLayoutGrid (layoutGrid, true))

    /// <summary>
    /// Sets the given LayoutGrid styles on the input chart's LayoutGrid.
    ///
    /// If there is already a LayoutGrid set , the styles are applied to it. If there is no LayoutGrid present, a new LayoutGrid object with the given styles will be set.
    /// </summary>
    /// <param name ="Rows">The number of rows in the grid. If you provide a 2D `subplots` array or a `yaxes` array, its length is used as the default. But it's also possible to have a different length, if you want to leave a row at the end for non-cartesian subplots.</param>
    /// <param name ="Columns">The number of columns in the grid. If you provide a 2D `subplots` array, the length of its longest row is used as the default. If you give an `xaxes` array, its length is used as the default. But it's also possible to have a different length, if you want to leave a row at the end for non-cartesian subplots.</param>
    /// <param name ="SubPlots">Used for freeform grids, where some axes may be shared across subplots but others are not. Each entry should be a cartesian subplot id, like "xy" or "x3y2", or "" to leave that cell empty. You may reuse x axes within the same column, and y axes within the same row. Non-cartesian subplots and traces that support `domain` can place themselves in this grid separately using the `gridcell` attribute.</param>
    /// <param name ="XAxes">Used with `yaxes` when the x and y axes are shared across columns and rows. Each entry should be an y axis id like "y", "y2", etc., or "" to not put a y axis in that row. Entries other than "" must be unique. Ignored if `subplots` is present. If missing but `xaxes` is present, will generate consecutive IDs.</param>
    /// <param name ="YAxes">Used with `yaxes` when the x and y axes are shared across columns and rows. Each entry should be an x axis id like "x", "x2", etc., or "" to not put an x axis in that column. Entries other than "" must be unique. Ignored if `subplots` is present. If missing but `yaxes` is present, will generate consecutive IDs.</param>
    /// <param name ="RowOrder">Is the first row the top or the bottom? Note that columns are always enumerated from left to right.</param>
    /// <param name ="Pattern">If no `subplots`, `xaxes`, or `yaxes` are given but we do have `rows` and `columns`, we can generate defaults using consecutive axis IDs, in two ways: "coupled" gives one x axis per column and one y axis per row. "independent" uses a new xy pair for each cell, left-to-right across each row then iterating rows according to `roworder`.</param>
    /// <param name ="XGap">Horizontal space between grid cells, expressed as a fraction of the total width available to one cell. Defaults to 0.1 for coupled-axes grids and 0.2 for independent grids.</param>
    /// <param name ="YGap">Vertical space between grid cells, expressed as a fraction of the total height available to one cell. Defaults to 0.1 for coupled-axes grids and 0.3 for independent grids.</param>
    /// <param name ="Domain">Sets the domains of this grid subplot (in plot fraction). The first and last cells end exactly at the domain edges, with no grout around the edges.</param>
    /// <param name ="XSide">Sets where the x axis labels and titles go. "bottom" means the very bottom of the grid. "bottom plot" is the lowest plot that each x axis is used in. "top" and "top plot" are similar.</param>
    /// <param name ="YSide">Sets where the y axis labels and titles go. "left" means the very left edge of the grid. "left plot" is the leftmost plot that each y axis is used in. "right" and "right plot" are similar.</param>
    static member withLayoutGridStyle
        (
            ?SubPlots: (StyleParam.LinearAxisId * StyleParam.LinearAxisId)[][],
            ?XAxes: StyleParam.LinearAxisId[],
            ?YAxes: StyleParam.LinearAxisId[],
            ?Rows: int,
            ?Columns: int,
            ?RowOrder: StyleParam.LayoutGridRowOrder,
            ?Pattern: StyleParam.LayoutGridPattern,
            ?XGap: float,
            ?YGap: float,
            ?Domain: Domain,
            ?XSide: StyleParam.LayoutGridXSide,
            ?YSide: StyleParam.LayoutGridYSide
        ) =
        (fun (ch: GenericChart) ->
            let grid =
                LayoutGrid.init (
                    ?SubPlots = SubPlots,
                    ?XAxes = XAxes,
                    ?YAxes = YAxes,
                    ?Rows = Rows,
                    ?Columns = Columns,
                    ?RowOrder = RowOrder,
                    ?Pattern = Pattern,
                    ?XGap = XGap,
                    ?YGap = YGap,
                    ?Domain = Domain,
                    ?XSide = XSide,
                    ?YSide = YSide

                )

            ch |> Chart.withLayoutGrid grid)

    /// <summary>
    /// Sets the given Legend with the given id on the input chart's layout.
    /// </summary>
    /// <param name="legend">The Legend to set on the chart's layout</param>
    /// <param name="id">The target Legend id with which the Legend should be set.</param>
    /// <param name="Combine">Whether or not to combine the objects if there is already an Legend set (default is false)</param>
    static member setLegend
        (
            legend: Legend,
            id: StyleParam.SubPlotId,
            ?Combine: bool
        ) =
            let combine = defaultArg Combine false

            (fun (ch: GenericChart) ->
                if combine then
                    ch |> GenericChart.mapLayout (Layout.updateLegendById(id, legend))
                else
                    ch |> GenericChart.mapLayout (Layout.setLegend(id,legend))
            )

    /// <summary>
    /// Sets the given Legend on the input chart's layout, optionally passing a target Legend id.
    ///
    /// If there is already an Legend set at the given id, the Legend objects are combined.
    /// </summary>
    /// <param name="legend">The Legend to set on the chart's layout</param>
    /// <param name="Id">The target Legend id with which the Legend should be set. Default is 1.</param>
    static member withLegend(legend: Legend, ?Id: int) =
        let id =
            Id |> Option.defaultValue 1 |> StyleParam.SubPlotId.Legend

        fun (ch: GenericChart) ->
            ch |> Chart.setLegend (legend, id, Combine = true)

    /// <summary>
    /// Sets the given Legend styles on the input chart's Legend, optionally passing a target Legend id.
    ///
    /// If there is already a Legend set , the styles are applied to it. If there is no Legend present, a new Legend object with the given styles will be set.
    /// </summary>
    /// <param name="BGColor">Sets the legend background color. Defaults to `layout.paper_bgcolor`.</param>
    /// <param name="BorderColor">Sets the color of the border enclosing the legend.</param>
    /// <param name="BorderWidth">Sets the width (in px) of the border enclosing the legend.</param>
    /// <param name="EntryWidth">Sets the width (in px or fraction) of the legend. Use 0 to size the entry based on the text width, when `entrywidthmode` is set to "pixels".</param>
    /// <param name="EntryWidthMode">Determines what entrywidth means.</param>
    /// <param name="Font">Sets the font used to text the legend items.</param>
    /// <param name="GroupClick">Determines the behavior on legend group item click. "toggleitem" toggles the visibility of the individual item clicked on the graph. "togglegroup" toggles the visibility of all items in the same legendgroup as the item clicked on the graph.</param>
    /// <param name="GroupTitleFont">Sets the font for group titles in legend. Defaults to `legend.font` with its size increased about 10%.</param>
    /// <param name="ItemClick">Determines the behavior on legend item click. "toggle" toggles the visibility of the item clicked on the graph. "toggleothers" makes the clicked item the sole visible item on the graph. "false" disables legend item click interactions.</param>
    /// <param name="ItemDoubleClick">Determines the behavior on legend item double-click. "toggle" toggles the visibility of the item clicked on the graph. "toggleothers" makes the clicked item the sole visible item on the graph. "false" disables legend item double-click interactions.</param>
    /// <param name="ItemSizing">Determines if the legend items symbols scale with their corresponding "trace" attributes or remain "constant" independent of the symbol size on the graph.</param>
    /// <param name="ItemWidth">Sets the width (in px) of the legend item symbols (the part other than the title.text).</param>
    /// <param name="Orientation">Sets the orientation of the legend.</param>
    /// <param name="Title">Sets the title of the legend.</param>
    /// <param name="TraceGroupGap">Sets the amount of vertical space (in px) between legend groups.</param>
    /// <param name="TraceOrder">Determines the order at which the legend items are displayed. If "normal", the items are displayed top-to-bottom in the same order as the input data. If "reversed", the items are displayed in the opposite order as "normal". If "grouped", the items are displayed in groups (when a trace `legendgroup` is provided). if "grouped+reversed", the items are displayed in the opposite order as "grouped".</param>
    /// <param name="UIRevision">Controls persistence of legend-driven changes in trace and pie label visibility. Defaults to `layout.uirevision`.</param>
    /// <param name="VerticalAlign">Sets the vertical alignment of the symbols with respect to their associated text.</param>
    /// <param name="Visible">Determines whether or not this legend is visible.</param>
    /// <param name="X">Sets the x position (in normalized coordinates) of the legend. Defaults to "1.02" for vertical legends and defaults to "0" for horizontal legends.</param>
    /// <param name="XAnchor">Sets the legend's horizontal position anchor. This anchor binds the `x` position to the "left", "center" or "right" of the legend. Value "auto" anchors legends to the right for `x` values greater than or equal to 2/3, anchors legends to the left for `x` values less than or equal to 1/3 and anchors legends with respect to their center otherwise.</param>
    /// <param name="XRef">Sets the container `x` refers to. "container" spans the entire `width` of the plot. "paper" refers to the width of the plotting area only.</param>
    /// <param name="Y">Sets the y position (in normalized coordinates) of the legend. Defaults to "1" for vertical legends, defaults to "-0.1" for horizontal legends on graphs w/o range sliders and defaults to "1.1" for horizontal legends on graph with one or multiple range sliders.</param>
    /// <param name="YAnchor">Sets the legend's vertical position anchor This anchor binds the `y` position to the "top", "middle" or "bottom" of the legend. Value "auto" anchors legends at their bottom for `y` values less than or equal to 1/3, anchors legends to at their top for `y` values greater than or equal to 2/3 and anchors legends with respect to their middle otherwise.</param>
    /// <param name="YRef">Sets the container `y` refers to. "container" spans the entire `height` of the plot. "paper" refers to the height of the plotting area only.</param>
    /// <param name="Id">The target Legend id. Default is 1.</param>
    static member withLegendStyle
        (
            ?BGColor: Color,
            ?BorderColor: Color,
            ?BorderWidth: float,
            ?EntryWidth: float,
            ?EntryWidthMode: StyleParam.EntryWidthMode,
            ?Font: Font,
            ?GroupClick: StyleParam.TraceGroupClickOptions,
            ?GroupTitleFont: Font,
            ?ItemClick: StyleParam.TraceItemClickOptions,
            ?ItemDoubleClick: StyleParam.TraceItemClickOptions,
            ?ItemSizing: StyleParam.TraceItemSizing,
            ?ItemWidth: int,
            ?Orientation: StyleParam.Orientation,
            ?Title: Title,
            ?TraceGroupGap: float,
            ?TraceOrder: StyleParam.TraceOrder,
            ?UIRevision: string,
            ?VerticalAlign: StyleParam.VerticalAlign,
            ?Visible: bool,
            ?X: float,
            ?XAnchor: StyleParam.XAnchorPosition,
            ?XRef: string,
            ?Y: float,
            ?YAnchor: StyleParam.YAnchorPosition,
            ?YRef: string,
            ?Id: int
        ) =
        (fun (ch: GenericChart) ->
            let legend =
                Legend.init (
                    ?BGColor = BGColor,
                    ?BorderColor = BorderColor,
                    ?BorderWidth = BorderWidth,
                    ?EntryWidth = EntryWidth,
                    ?EntryWidthMode = EntryWidthMode,
                    ?Font = Font,
                    ?GroupClick = GroupClick,
                    ?GroupTitleFont = GroupTitleFont,
                    ?ItemClick = ItemClick,
                    ?ItemDoubleClick = ItemDoubleClick,
                    ?ItemSizing = ItemSizing,
                    ?ItemWidth = ItemWidth,
                    ?Orientation = Orientation,
                    ?Title = Title,
                    ?TraceGroupGap = TraceGroupGap,
                    ?TraceOrder = TraceOrder,
                    ?UIRevision = UIRevision,
                    ?VerticalAlign = VerticalAlign,
                    ?Visible = Visible,
                    ?X = X,
                    ?XAnchor = XAnchor,
                    ?XRef = XRef,
                    ?Y = Y,
                    ?YAnchor = YAnchor,
                    ?YRef = YRef
                )

            ch |> Chart.withLegend(legend, ?Id = Id))

    /// <summary>
    /// Sets the given annotations on the input chart's layout. Use the 'Append' argument to decide what should happen if there are already annotations set.
    /// </summary>
    /// <param name="annotations">The annotations to add to the input charts layout</param>
    /// <param name="Append">If true, the input annotations will be appended to existing annotations, otherwise existing annotations will be removed (default: true)</param>
    static member withAnnotations
        (
            annotations: seq<Annotation>,
            ?Append: bool
        ) =
        let append = defaultArg Append true

        fun (ch: GenericChart) ->

            let annotations' =

                if append then

                    let layout = GenericChart.getLayout ch

                    layout.TryGetTypedPropertyValue<seq<Annotation>>("annotations")
                    |> Option.defaultValue Seq.empty
                    |> Seq.append annotations

                else
                    annotations

            ch |> GenericChart.mapLayout (Layout.style (Annotations = annotations'))

    /// <summary>
    /// Sets the given annotation on the input chart's layout. Use the 'Append' argument to decide what should happen if there are already annotations set.
    /// </summary>
    /// <param name="annotation">The annotations to add to the input charts layout</param>
    /// <param name="Append">If true, the input annotation will be appended to existing annotations, otherwise existing annotations will be removed (default: true)</param>
    static member withAnnotation(annotation: Annotation, ?Append: bool) =
        Chart.withAnnotations ([ annotation ], ?Append = Append)

    // Set the title of a Chart
    static member withTitle(title, ?TitleFont) =
        (fun (ch: GenericChart) ->
            let layout =
                Layout() |> Layout.style (Title = Title.init (Text = title, ?Font = TitleFont))

            GenericChart.addLayout layout ch)

    // Set the title of a Chart
    static member withTitle(title) =
        (fun (ch: GenericChart) ->
            let layout =
                Layout() |> Layout.style (Title = title)

            GenericChart.addLayout layout ch)

    /// Sets the size of a Chart (in pixels)
    static member withSize
        (
            ?Width: int,
            ?Height: int
        ) =

        fun (ch: GenericChart) ->
            let layout =
                GenericChart.getLayout ch |> Layout.style (?Width = Width, ?Height = Height)

            GenericChart.setLayout layout ch



    // Set the size of a Chart
    static member withSize(width: float, height: float) =
        Chart.withSize (Width = int width, Height = int height)

    // Set the margin of a Chart
    static member withMargin(margin: Margin) =
        (fun (ch: GenericChart) ->
            let layout =
                GenericChart.getLayout ch |> Layout.style (Margin = margin)

            GenericChart.setLayout layout ch)

    // Set the margin of a Chart
    static member withMarginSize
        (
            ?Left,
            ?Right,
            ?Top,
            ?Bottom,
            ?Pad,
            ?Autoexpand
        ) =
        let margin =
            Margin.init (
                ?Left = Left,
                ?Right = Right,
                ?Top = Top,
                ?Bottom = Bottom,
                ?Pad = Pad,
                ?Autoexpand = Autoexpand
            )

        Chart.withMargin (margin)

    static member withTemplate(template: Template) =
        (fun (ch: GenericChart) -> ch |> GenericChart.mapLayout (Layout.style (Template = (template :> DynamicObj))))

    /// <summary>
    /// Sets the given shapes on the input chart's layout. Use the 'Append' argument to decide what should happen if there are already shapes set.
    /// </summary>
    /// <param name="shapes">The shapes to add to the input charts layout</param>
    /// <param name="Append">If true, the input shapes will be appended to existing shapes, otherwise existing shapes will be removed (default: true)</param>
    static member withShapes(shapes: seq<Shape>, ?Append: bool) =
        let append = defaultArg Append true

        fun (ch: GenericChart) ->

            let shapes' =

                if append then

                    let layout = GenericChart.getLayout ch

                    layout.TryGetTypedPropertyValue<seq<Shape>>("shapes") |> Option.defaultValue Seq.empty |> Seq.append shapes

                else
                    shapes

            ch |> GenericChart.mapLayout (Layout.style (Shapes = shapes'))

    /// <summary>
    /// Sets the given shape on the input chart's layout. Use the 'Append' argument to decide what should happen if there are already shapes set.
    /// </summary>
    /// <param name="shape">The shapes to add to the input charts layout</param>
    /// <param name="Append">If true, the input shape will be appended to existing shapes, otherwise existing annotations will be shapes (default: true)</param>
    static member withShape(shape: Shape, ?Append: bool) =
        Chart.withShapes ([ shape ], ?Append = Append)

    /// <summary>
    /// Sets the given selections on the input chart's layout. Use the 'Append' argument to decide what should happen if there are already selections set.
    /// </summary>
    /// <param name="selections">The selections to add to the input charts layout</param>
    /// <param name="Append">If true, the input selections will be appended to existing selections, otherwise existing selections will be removed (default: true)</param>
    static member withSelections(selections: seq<Selection>, ?Append: bool) =
        let append = defaultArg Append true

        fun (ch: GenericChart) ->

            let selections' =

                if append then

                    let layout = GenericChart.getLayout ch

                    layout.TryGetTypedPropertyValue<seq<Selection>>("selections")
                    |> Option.defaultValue Seq.empty
                    |> Seq.append selections

                else
                    selections

            ch |> GenericChart.mapLayout (Layout.style (Selections = selections'))

    /// <summary>
    /// Sets the given selection on the input chart's layout. Use the 'Append' argument to decide what should happen if there are already selections set.
    /// </summary>
    /// <param name="selection">The selections to add to the input charts layout</param>
    /// <param name="Append">If true, the input selection will be appended to existing selections, otherwise existing selections will be removed (default: true)</param>
    static member withSelection(selection: Selection, ?Append: bool) =
        Chart.withSelections ([ selection ], ?Append = Append)

    //==============================================================================================================
    //======================================= General Config object styling ========================================
    //==============================================================================================================

    // <summary>
    /// Sets the given config on the input chart.
    ///
    /// If there is already a config set, the object is replaced.
    /// </summary>
    static member setConfig(config: Config) =
        (fun (ch: GenericChart) -> GenericChart.setConfig config ch)

    // <summary>
    /// Sets the given config on the input chart.
    ///
    /// If there is already a config set, the objects are combined.
    /// </summary>
    static member withConfig(config: Config) =
        (fun (ch: GenericChart) -> GenericChart.addConfig config ch)

    /// <summary>
    /// Applies the given styles to the chart's Config object. Overwrites attributes with the same name that are already set.
    /// </summary>
    /// <param name="StaticPlot">Determines whether the graphs are interactive or not. If *false*, no interactivity, for export or image generation.</param>
    /// <param name="TypesetMath">Determines whether math should be typeset or not, when MathJax (either v2 or v3) is present on the page.</param>
    /// <param name="PlotlyServerUrl">When set it determines base URL form the \'Edit in Chart Studio\' `showEditInChartStudio`/`showSendToCloud` mode bar button and the showLink/sendData on-graph link. To enable sending your data to Chart Studio Cloud, you need to set both `plotlyServerURL` to \'https://chart-studio.plotly.com\' and also set `showSendToCloud` to true.</param>
    /// <param name="Editable">Determines whether the graph is editable or not. Sets all pieces of `edits` unless a separate `edits` config item overrides individual parts.</param>
    /// <param name="Edits">Determines if the main anchor of the annotation is editable. The main anchor corresponds to the text (if no arrow) or the arrow (which drags the whole thing leaving the arrow length and direction unchanged).</param>
    /// <param name="EditSelection">Enables moving selections.</param>
    /// <param name="Autosizable">Determines whether the graphs are plotted with respect to layout.autosize:true and infer its container size.</param>
    /// <param name="Responsive">Determines whether to change the layout size when window is resized. In v3, this option will be removed and will always be true.</param>
    /// <param name="FillFrame">When `layout.autosize` is turned on, determines whether the grap fills the container (the default) or the screen (if set to *true*).</param>
    /// <param name="FrameMargins">When `layout.autosize` is turned on, set the frame margins in fraction of the graph size.'</param>
    /// <param name="ScrollZoom">Determines whether mouse wheel or two-finger scroll zooms is enable. Turned on by default for gl3d, geo and mapbox subplots (as these subplot types do not have zoombox via pan, but turned off by default for cartesian subplots. Set `scrollZoom` to *false* to disable scrolling for all subplots.</param>
    /// <param name="DoubleClick">Sets the double click interaction mode. Has an effect only in cartesian plots. If *false*, double click is disable. If *reset*, double click resets the axis ranges to their initial values. If *autosize*, double click set the axis ranges to their autorange values. If *reset+autosize*, the odd double clicks resets the axis ranges to their initial values and even double clicks set the axis ranges to their autorange values.</param>
    /// <param name="DoubleClickDelay">Sets the delay for registering a double-click in ms. This is the time interval (in ms) between first mousedown and 2nd mouseup to constitute a double-click. This setting propagates to all on-subplot double clicks (except for geo and mapbox) and on-legend double clicks.</param>
    /// <param name="ShowAxisDragHandles">Set to *false* to omit cartesian axis pan/zoom drag handles.</param>
    /// <param name="ShowAxisRangeEntryBoxes">Set to *false* to omit direct range entry at the pan/zoom drag points, note that `showAxisDragHandles` must be enabled to have an effect.</param>
    /// <param name="ShowTips">Determines whether or not tips are shown while interacting with the resulting graphs.</param>
    /// <param name="ShowLink">Determines whether a link to Chart Studio Cloud is displayed at the bottom right corner of resulting graphs. Use with `sendData` and `linkText`.</param>
    /// <param name="LinkText">Sets the text appearing in the `showLink` link.</param>
    /// <param name="SendData">If *showLink* is true, does it contain data just link to a Chart Studio Cloud file?</param>
    /// <param name="ShowSources">Adds a source-displaying function to show sources on the resulting graphs.</param>
    /// <param name="DisplayModeBar">Determines the mode bar display mode. If *true*, the mode bar is always visible. If *false*, the mode bar is always hidden. If *hover*, the mode bar is visible while the mouse cursor is on the graph container.</param>
    /// <param name="ShowSendToCloud">Should we include a ModeBar button, labeled "Edit in Chart Studio that sends this chart to chart-studio.plotly.com (formerly plot.ly) or another plotly server as specified by `plotlyServerURL` for editing, export, etc? Prior to version 1.43.0 this button was included by default, now it is opt-in using this flag. Note that this button can (depending on `plotlyServerURL` being set) send your data to an external server. However that server does not persist your data until you arrive at the Chart Studio and explicitly click "Save".</param>
    /// <param name="ShowEditInChartStudio">Same as `showSendToCloud`, but use a pencil icon instead of a floppy-disk. Note that if both `showSendToCloud` and `showEditInChartStudio` are turned only `showEditInChartStudio` will be honored.</param>
    /// <param name="ModeBarButtonsToRemove">Remove mode bar buttons by name. See ./components/modebar/buttons.js for the list of names.</param>
    /// <param name="ModeBarButtonsToAdd">Add mode bar button using config objects. See ./components/modebar/buttons.js for list of arguments. To enable predefined modebar buttons e.g. shape drawing, hover and spikelines simply provide their string name(s). This could include: *v1hovermode*, *hoverclosest*, *hovercompare*, *togglehover*, *togglespikelines*, *drawline*, *drawopenpath*, *drawclosedpath*, *drawcircle*, *drawrect* and *eraseshape*. Please note that these predefined buttons will only be shown if they are compatible with all trace types used in a graph.</param>
    /// <param name="ModeBarButtons">Define fully custom mode bar buttons as nested array where the outer arrays represents button groups, and the inner arrays have buttons config objects or names of default buttons. See ./components/modebar/buttons.js for more info.'</param>
    /// <param name="ToImageButtonOptions">Statically override options for toImage modebar button allowed keys are format, filename, width, height, scale', see ../components/modebar/buttons.js</param>
    /// <param name="Displaylogo">Determines whether or not the plotly logo is displayed on the end of the mode bar.</param>
    /// <param name="Watermark">watermark the images with the company\'s logo</param>
    /// <param name="plotGlPixelRatio">Set the pixel ratio during WebGL image export. This config option was formerly named `plot3dPixelRatio` which is now deprecated.</param>
    /// <param name="SetBackground">Set function to add the background color (i.e. `layout.paper_color`) to a different container. This function take the graph div as first argument and the current background color as second argument. Alternatively, set to string *opaque* to ensure there is white behind it.</param>
    /// <param name="TopojsonURL">Set the URL to topojson used in geo charts. By default, the topojson files are fetched from cdn.plot.ly. For example, set this option to: &lt;path-to-plotly.js&gt;/dist/topojson to render geographical feature using the topojson files that ship with the plotly.js module.</param>
    /// <param name="MapboxAccessToken">Mapbox access token (required to plot mapbox trace types). If using an Mapbox Atlas server, set this option to \'\' so that plotly.js won\'t attempt to authenticate to the public Mapbox server.</param>
    /// <param name="Logging">Turn all console logging on or off (errors will be thrown). This should ONLY be set via Plotly.setPlotConfig Available levels: 0: no logs 1: warnings and errors, but not informational messages 2: verbose logs</param>
    /// <param name="NotifyOnLogging">Turn all console logging on or off (errors will be thrown). This should ONLY be set via Plotly.setPlotConfig Available levels: 0: no logs 1: warnings and errors, but not informational messages 2: verbose logs</param>
    /// <param name="QueueLength">Sets the length of the undo/redo queue.</param>
    /// <param name="GlobalTransforms">Set global transform to be applied to all traces with no specification needed</param>
    /// <param name="Locale">Which localization should we use? Should be a string like \'en\' or \'en-US\'.</param>
    /// <param name="Locales">
    /// Localization definitions
    /// Locales can be provided either here (specific to one chart) or globally
    /// by registering them as modules.
    /// Should be an object of objects {locale: {dictionary: {...}, format: {...}}}'
    /// {
    ///   da: {
    ///       dictionary: {\'Reset axes\': \'Nulstil aksler\', ...},
    ///       format: {months: [...], shortMonths: [...]}',
    ///   },
    ///   ...
    /// }
    /// All parts are optional. When looking for translation or format fields, we
    /// look first for an exact match in a config locale, then in a registered
    /// module. If those fail, we strip off any regionalization (\'en-US\' -> \'en\')
    /// and try each (config, registry) again. The final fallback for translation
    /// is untranslated (which is US English) and for formats is the base English
    /// (the only consequence being the last fallback date format %x is DD/MM/YYYY
    /// instead of MM/DD/YYYY). Currently `grouping` and `currency` are ignored
    /// for our automatic number formatting, but can be used in custom formats.
    /// </param>
    static member withConfigStyle
        (
            ?StaticPlot: bool,
            ?TypesetMath: bool,
            ?PlotlyServerUrl: string,
            ?Editable: bool,
            ?Edits: Edits,
            ?EditSelection: bool,
            ?Autosizable: bool,
            ?Responsive: bool,
            ?FillFrame: bool,
            ?FrameMargins: float,
            ?ScrollZoom: StyleParam.ScrollZoom,
            ?DoubleClick: StyleParam.DoubleClick,
            ?DoubleClickDelay: int,
            ?ShowAxisDragHandles: bool,
            ?ShowAxisRangeEntryBoxes: bool,
            ?ShowTips: bool,
            ?ShowLink: bool,
            ?LinkText: string,
            ?SendData: bool,
            ?ShowSources: obj,
            ?DisplayModeBar: bool,
            ?ShowSendToCloud: bool,
            ?ShowEditInChartStudio: bool,
            ?ModeBarButtonsToRemove: seq<StyleParam.ModeBarButton>,
            ?ModeBarButtonsToAdd: seq<StyleParam.ModeBarButton>,
            ?ModeBarButtons: seq<seq<StyleParam.ModeBarButton>>,
            ?ToImageButtonOptions: ToImageButtonOptions,
            ?Displaylogo: bool,
            ?Watermark: bool,
            ?plotGlPixelRatio: float,
            ?SetBackground: obj,
            ?TopojsonURL: string,
            ?MapboxAccessToken: string,
            ?Logging: int,
            ?NotifyOnLogging: int,
            ?QueueLength: int,
            ?GlobalTransforms: obj,
            ?Locale: string,
            ?Locales: obj
        ) =
        (fun (ch: GenericChart) ->

            let config =
                Config.init (
                    ?StaticPlot = StaticPlot,
                    ?TypesetMath = TypesetMath,
                    ?PlotlyServerUrl = PlotlyServerUrl,
                    ?Editable = Editable,
                    ?Edits = Edits,
                    ?EditSelection = EditSelection,
                    ?Autosizable = Autosizable,
                    ?Responsive = Responsive,
                    ?FillFrame = FillFrame,
                    ?FrameMargins = FrameMargins,
                    ?ScrollZoom = ScrollZoom,
                    ?DoubleClick = DoubleClick,
                    ?DoubleClickDelay = DoubleClickDelay,
                    ?ShowAxisDragHandles = ShowAxisDragHandles,
                    ?ShowAxisRangeEntryBoxes = ShowAxisRangeEntryBoxes,
                    ?ShowTips = ShowTips,
                    ?ShowLink = ShowLink,
                    ?LinkText = LinkText,
                    ?SendData = SendData,
                    ?ShowSources = ShowSources,
                    ?DisplayModeBar = DisplayModeBar,
                    ?ShowSendToCloud = ShowSendToCloud,
                    ?ShowEditInChartStudio = ShowEditInChartStudio,
                    ?ModeBarButtonsToRemove = ModeBarButtonsToRemove,
                    ?ModeBarButtonsToAdd = ModeBarButtonsToAdd,
                    ?ModeBarButtons = ModeBarButtons,
                    ?ToImageButtonOptions = ToImageButtonOptions,
                    ?Displaylogo = Displaylogo,
                    ?Watermark = Watermark,
                    ?plotGlPixelRatio = plotGlPixelRatio,
                    ?SetBackground = SetBackground,
                    ?TopojsonURL = TopojsonURL,
                    ?MapboxAccessToken = MapboxAccessToken,
                    ?Logging = Logging,
                    ?NotifyOnLogging = NotifyOnLogging,
                    ?QueueLength = QueueLength,
                    ?GlobalTransforms = GlobalTransforms,
                    ?Locale = Locale,
                    ?Locales = Locales
                )

            ch |> Chart.withConfig config)

    //==============================================================================================================
    //================================= More complicated composite methods =========================================
    //==============================================================================================================


    /// <summary>
    /// Creates a subplot grid with the given dimensions (nRows x nCols) for the input charts. The default row order is from top to bottom.
    ///
    /// For each input chart, a corresponding subplot cell is created in the grid. The following limitations apply to the individual grid cells:
    ///
    /// - only one pair of 2D cartesian axes is allowed per cell. If there are multiple x or y axes on an input chart, the first one is used, and the rest is discarded (meaning, it is removed from the combined layout).
    ///   if you need multiple axes per grid cell, create a custom grid by manually creating axes with custom domains instead.
    ///   The new id of the axes corresponds to the number of the grid cell, e.g. the third grid cell will contain xaxis3 and yaxis3
    ///
    /// - For other subplot layouts (Cartesian3D, Polar, Ternary, Geo, Mapbox, Smith), the same rule applies: only one subplot per grid cell, the first one is used, the rest is discarded.
    ///   The new id of the subplot layout corresponds to the number of the grid cell, e.g. the third grid cell will contain scene3 etc.
    ///
    /// - The Domain of traces that calculate their position by domain only (e.g. Pie traces) are replaced by a domain pointing to the new grid position.
    ///
    /// - If SubPlotTitles are provided, they are used as the titles of the individual cells in ascending order. If the number of titles is less than the number of subplots, the remaining subplots are left without a title.
    /// </summary>
    /// <param name ="nRows">The number of rows in the grid. If you provide a 2D `subplots` array or a `yaxes` array, its length is used as the default. But it's also possible to have a different length, if you want to leave a row at the end for non-cartesian subplots.</param>
    /// <param name ="nCols">The number of columns in the grid. If you provide a 2D `subplots` array, the length of its longest row is used as the default. If you give an `xaxes` array, its length is used as the default. But it's also possible to have a different length, if you want to leave a row at the end for non-cartesian subplots.</param>
    /// <param name ="SubPlotTitles">A collection of titles for the individual subplots.</param>
    /// <param name ="SubPlotTitleFont">The font of the subplot titles</param>
    /// <param name ="SubPlotTitleOffset">A vertical offset applied to each subplot title, moving it upwards if positive and vice versa</param>
    /// <param name ="SubPlots">Used for freeform grids, where some axes may be shared across subplots but others are not. Each entry should be a cartesian subplot id, like "xy" or "x3y2", or "" to leave that cell empty. You may reuse x axes within the same column, and y axes within the same row. Non-cartesian subplots and traces that support `domain` can place themselves in this grid separately using the `gridcell` attribute.</param>
    /// <param name ="XAxes">Used with `yaxes` when the x and y axes are shared across columns and rows. Each entry should be an y axis id like "y", "y2", etc., or "" to not put a y axis in that row. Entries other than "" must be unique. Ignored if `subplots` is present. If missing but `xaxes` is present, will generate consecutive IDs.</param>
    /// <param name ="YAxes">Used with `yaxes` when the x and y axes are shared across columns and rows. Each entry should be an x axis id like "x", "x2", etc., or "" to not put an x axis in that column. Entries other than "" must be unique. Ignored if `subplots` is present. If missing but `yaxes` is present, will generate consecutive IDs.</param>
    /// <param name ="RowOrder">Is the first row the top or the bottom? Note that columns are always enumerated from left to right.</param>
    /// <param name ="Pattern">If no `subplots`, `xaxes`, or `yaxes` are given but we do have `rows` and `columns`, we can generate defaults using consecutive axis IDs, in two ways: "coupled" gives one x axis per column and one y axis per row. "independent" uses a new xy pair for each cell, left-to-right across each row then iterating rows according to `roworder`.</param>
    /// <param name ="XGap">Horizontal space between grid cells, expressed as a fraction of the total width available to one cell. Defaults to 0.1 for coupled-axes grids and 0.2 for independent grids.</param>
    /// <param name ="YGap">Vertical space between grid cells, expressed as a fraction of the total height available to one cell. Defaults to 0.1 for coupled-axes grids and 0.3 for independent grids.</param>
    /// <param name ="Domain">Sets the domains of this grid subplot (in plot fraction). The first and last cells end exactly at the domain edges, with no grout around the edges.</param>
    /// <param name ="XSide">Sets where the x axis labels and titles go. "bottom" means the very bottom of the grid. "bottom plot" is the lowest plot that each x axis is used in. "top" and "top plot" are similar.</param>
    /// <param name ="YSide">Sets where the y axis labels and titles go. "left" means the very left edge of the grid. "left plot" is the leftmost plot that each y axis is used in. "right" and "right plot" are similar.</param>
    static member Grid
        (
            nRows: int,
            nCols: int,
            ?SubPlotTitles: #seq<string>,
            ?SubPlotTitleFont: Font,
            ?SubPlotTitleOffset: float,
            ?SubPlots: (StyleParam.LinearAxisId * StyleParam.LinearAxisId)[][],
            ?XAxes: StyleParam.LinearAxisId[],
            ?YAxes: StyleParam.LinearAxisId[],
            ?RowOrder: StyleParam.LayoutGridRowOrder,
            ?Pattern: StyleParam.LayoutGridPattern,
            ?XGap: float,
            ?YGap: float,
            ?Domain: Domain,
            ?XSide: StyleParam.LayoutGridXSide,
            ?YSide: StyleParam.LayoutGridYSide
        ) =
        fun (gCharts: #seq<GenericChart>) ->

            // calculates the grid cell dimensions (in fractions of paper size), that is, the start and end points of each cell in a row or column
            let getGridCellDimensions (gridDimensionStart: float) (gridDimensionEnd: float) (gap: float) (length: int) (reversed: bool) =
                // adapted from grid cell layout logic directly in plotly.js source code: https://github.com/plotly/plotly.js/blob/5d6d45758f485ca309691bc7f33e799ef80f2cd5/src/components/grid/index.js#L224-L238
    
                let step = (gridDimensionEnd - gridDimensionStart) / (float length - gap)
                let cellDomain = step * (1. - gap)

                Array.init length (fun i -> 
                    let cellStart = gridDimensionStart + (step * float i)
                    (cellStart, cellStart + cellDomain)
                )
                |> fun p -> if reversed then p else Array.rev p

            // calculates the positions of the subplot titles
            // titles are placed in the middle of the top edge of each cell in a layout grid as annotations with paper copordinates.
            let calculateSubplotTitlePositions (gridDimensionStart: float) (gridDimensionEnd: float) (xgap: float) (ygap: float) (nrows: int) (ncols: int) (reversed:bool) =
    
                let subPlotTitleOffset = defaultArg SubPlotTitleOffset 0.

                let xDomains = getGridCellDimensions gridDimensionStart gridDimensionEnd xgap ncols true
                let yDomains = getGridCellDimensions gridDimensionStart gridDimensionEnd ygap nrows reversed

                Array.init nrows (fun r -> 
                    Array.init ncols (fun c -> 
                        let xStart = fst xDomains.[c]
                        let xEnd = snd xDomains.[c]
                        let yEnd = snd yDomains.[r]
                        (r,c), ((xStart + xEnd) / 2., yEnd + subPlotTitleOffset)
                    )
                )
                |> Array.concat

            let pattern =
                defaultArg Pattern StyleParam.LayoutGridPattern.Independent

            let rowOrder = defaultArg RowOrder StyleParam.LayoutGridRowOrder.TopToBottom

            let xGap = defaultArg XGap (if pattern = StyleParam.LayoutGridPattern.Coupled then 0.1 else 0.2)
            let yGap = defaultArg YGap (if pattern = StyleParam.LayoutGridPattern.Coupled then 0.1 else 0.3)


            let hasSharedAxes =
                pattern = StyleParam.LayoutGridPattern.Coupled

            let subPlotTitleAnnotations =
                match SubPlotTitles with
                | Some titles ->

                    let reversed = rowOrder = StyleParam.LayoutGridRowOrder.BottomToTop

                    let positions =
                        calculateSubplotTitlePositions 0. 1. xGap yGap nRows nCols reversed

                    titles
                    |> Array.ofSeq
                    |> Array.zip positions[0 .. (Seq.length titles) - 1]
                    |> Array.map (fun (((rowIndex, colIndex), (x, y)), title) ->
                        Annotation.init(
                            X = x,
                            XRef = "paper",
                            XAnchor = StyleParam.XAnchorPosition.Center,
                            Y = y,
                            YRef = "paper",
                            YAnchor = StyleParam.YAnchorPosition.Bottom,
                            Text = title,
                            ShowArrow = false,
                            ?Font = SubPlotTitleFont
                        )
                    )
                | None -> [||]

            // rows x cols coordinate grid
            let gridCoordinates =
                Array.init nRows (fun rowIndex -> Array.init nCols (fun colIndex -> rowIndex + 1, colIndex + 1))
                |> Array.concat

            gCharts
            |> Seq.zip gridCoordinates
            |> Array.ofSeq
            |> Array.mapi (fun i ((rowIndex, colIndex), gChart) ->

                let layout =
                    gChart |> GenericChart.getLayout

                match TraceID.ofTraces (gChart |> GenericChart.getTraces) with
                | TraceID.Multi ->
                    failwith
                        $"the trace for ({rowIndex},{colIndex}) contains multiple different subplot types. this is not supported."
                | TraceID.Cartesian2D
                | TraceID.Carpet ->

                    let xAxis =
                        layout.TryGetTypedPropertyValue<LinearAxis> "xaxis" |> Option.defaultValue (LinearAxis.init ())

                    let yAxis =
                        layout.TryGetTypedPropertyValue<LinearAxis> "yaxis" |> Option.defaultValue (LinearAxis.init ())

                    let allXAxes = Layout.getXAxes layout |> Array.map fst
                    let allYAxes = Layout.getYAxes layout |> Array.map fst

                    // remove all axes from layout. Only cartesian axis in each dimension is supported per grid cell, and leaving anything else on this layout may lead to property name clashes on combine.
                    allXAxes |> Array.iter (fun propName -> layout.RemoveProperty(propName) |> ignore)
                    allYAxes |> Array.iter (fun propName -> layout.RemoveProperty(propName) |> ignore)

                    let xAnchor, yAnchor =
                        if hasSharedAxes then
                            colIndex, rowIndex //set axis anchors according to grid coordinates
                        else
                            i + 1, i + 1

                    let lol = 
                        gChart
                        |> Chart.withAxisAnchor (xAnchor, yAnchor) // set adapted axis anchors
                        |> Chart.withXAxis (xAxis, (StyleParam.SubPlotId.XAxis(i + 1))) // set previous axis with adapted id (one individual axis for each subplot, whether or not they will be used later)
                        |> Chart.withYAxis (yAxis, (StyleParam.SubPlotId.YAxis(i + 1))) // set previous axis with adapted id (one individual axis for each subplot, whether or not they will be used later)
                    lol
                | TraceID.Cartesian3D ->

                    let scene =
                        layout.TryGetTypedPropertyValue<Scene> "scene"
                        |> Option.defaultValue (Scene.init ())
                        |> Scene.style (Domain = LayoutObjects.Domain.init (Row = rowIndex - 1, Column = colIndex - 1))

                    let allScenes = Layout.getScenes layout |> Array.map fst

                    // remove all scenes from layout. Only one scene is supported per grid cell, and leaving anything else on this layout may lead to property name clashes on combine.
                    allScenes |> Array.iter (fun propName -> layout.RemoveProperty(propName) |> ignore)

                    let sceneAnchor =
                        StyleParam.SubPlotId.Scene(i + 1)

                    gChart
                    |> GenericChart.mapTrace (fun t -> t :?> Trace3D |> Trace3DStyle.SetScene sceneAnchor :> Trace)
                    |> Chart.withScene (scene, (i + 1))
                | TraceID.Polar ->

                    let polar =
                        layout.TryGetTypedPropertyValue<Polar> "polar"
                        |> Option.defaultValue (Polar.init ())
                        |> Polar.style (Domain = LayoutObjects.Domain.init (Row = rowIndex - 1, Column = colIndex - 1))

                    let allPolars = Layout.getPolars layout |> Array.map fst

                    // remove all polar subplots from layout. Only one polar subplot is supported per grid cell, and leaving anything else on this layout may lead to property name clashes on combine.
                    allPolars |> Array.iter (fun propName -> layout.RemoveProperty(propName) |> ignore)

                    let polarAnchor =
                        StyleParam.SubPlotId.Polar(i + 1)

                    gChart
                    |> GenericChart.mapTrace (fun t ->
                        t :?> TracePolar |> TracePolarStyle.SetPolar polarAnchor :> Trace)
                    |> Chart.withPolar (polar, (i + 1))

                | TraceID.Smith ->

                    let smith =
                        layout.TryGetTypedPropertyValue<Smith> "smith"
                        |> Option.defaultValue (Smith.init ())
                        |> Smith.style (Domain = LayoutObjects.Domain.init (Row = rowIndex - 1, Column = colIndex - 1))
                    
                    let allSmiths = Layout.getSmiths layout |> Array.map fst

                    // remove all smith subplots from layout. Only one smith subplot is supported per grid cell, and leaving anything else on this layout may lead to property name clashes on combine.
                    allSmiths |> Array.iter (fun propName -> layout.RemoveProperty(propName) |> ignore)

                    let polarAnchor =
                        StyleParam.SubPlotId.Smith(i + 1)

                    gChart
                    |> GenericChart.mapTrace (fun t ->
                        t :?> TraceSmith |> TraceSmithStyle.SetSmith polarAnchor :> Trace)
                    |> Chart.withSmith (smith, (i + 1))

                | TraceID.Geo ->
                    let geo =
                        layout.TryGetTypedPropertyValue<Geo> "geo"
                        |> Option.defaultValue (Geo.init ())
                        |> Geo.style (Domain = LayoutObjects.Domain.init (Row = rowIndex - 1, Column = colIndex - 1))

                    let allGeos = Layout.getGeos layout |> Array.map fst

                    // remove all geo subplots from layout. Only one geo subplot is supported per grid cell, and leaving anything else on this layout may lead to property name clashes on combine.
                    allGeos |> Array.iter (fun propName -> layout.RemoveProperty(propName) |> ignore)

                    let geoAnchor =
                        StyleParam.SubPlotId.Geo(i + 1)

                    gChart
                    |> GenericChart.mapTrace (fun t -> t :?> TraceGeo |> TraceGeoStyle.SetGeo geoAnchor :> Trace)
                    |> Chart.withGeo (geo, (i + 1))

                | TraceID.Mapbox ->
                    let mapbox =
                        layout.TryGetTypedPropertyValue<Mapbox> "mapbox"
                        |> Option.defaultValue (Mapbox.init ())
                        |> Mapbox.style (
                            Domain = LayoutObjects.Domain.init (Row = rowIndex - 1, Column = colIndex - 1)
                        )

                    let allMapboxes = Layout.getMapboxes layout |> Array.map fst

                    // remove all mapbox subplots from layout. Only one mapbox subplot is supported per grid cell, and leaving anything else on this layout may lead to property name clashes on combine.
                    allMapboxes |> Array.iter (fun propName -> layout.RemoveProperty(propName) |> ignore)

                    let geoAnchor =
                        StyleParam.SubPlotId.Geo(i + 1)

                    let mapboxAnchor =
                        StyleParam.SubPlotId.Mapbox(i + 1)

                    gChart
                    |> GenericChart.mapTrace (fun t ->
                        t :?> TraceMapbox |> TraceMapboxStyle.SetMapbox mapboxAnchor :> Trace)
                    |> Chart.withMapbox (mapbox, (i + 1))

                | TraceID.Ternary ->

                    let ternary =
                        layout.TryGetTypedPropertyValue<Ternary> "ternary"
                        |> Option.defaultValue (Ternary.init ())
                        |> Ternary.style (
                            Domain = LayoutObjects.Domain.init (Row = rowIndex - 1, Column = colIndex - 1)
                        )

                    let allTernaries = Layout.getTernaries layout |> Array.map fst

                    // remove all ternary subplots from layout. Only one ternary subplot is supported per grid cell, and leaving anything else on this layout may lead to property name clashes on combine.
                    allTernaries |> Array.iter (fun propName -> layout.RemoveProperty(propName) |> ignore)

                    let ternaryAnchor =
                        StyleParam.SubPlotId.Ternary(i + 1)

                    gChart
                    |> GenericChart.mapTrace (fun t ->
                        t :?> TraceTernary |> TraceTernaryStyle.SetTernary ternaryAnchor :> Trace)
                    |> Chart.withTernary (ternary, (i + 1))

                | TraceID.Domain ->

                    // no need to remove existing domains, as only one domain can exist on the original layout. Just replace it.
                    let newDomain =
                        LayoutObjects.Domain.init (Row = rowIndex - 1, Column = colIndex - 1)

                    gChart
                    |> GenericChart.mapTrace (fun t ->
                        t :?> TraceDomain |> TraceDomainStyle.SetDomain newDomain :> Trace)
            )
            |> Chart.combine
            |> Chart.withAnnotations(subPlotTitleAnnotations, Append=true)
            |> Chart.withLayoutGrid (
                LayoutGrid.init (
                    Rows = nRows,
                    Columns = nCols,
                    Pattern = pattern,
                    RowOrder = rowOrder,
                    ?SubPlots = SubPlots,
                    ?XAxes = XAxes,
                    ?YAxes = YAxes,
                    ?XGap = XGap,
                    ?YGap = YGap,
                    ?Domain = Domain,
                    ?XSide = XSide,
                    ?YSide = YSide
                )
            )

    /// <summary>
    /// Creates a subplot grid with the the dimensions of the input 2D sequence containing the charts to render in the respective cells.
    ///
    /// ATTENTION: when the individual rows do not have the same amount of charts, they will be filled with dummy charts TO THE RIGHT.
    ///
    /// prevent this behaviour by using Chart.Invisible at the cells that should be empty.
    ///
    /// For each input chart, a corresponding subplot cell is created in the grid. The following limitations apply to the individual grid cells:
    ///
    /// - only one pair of 2D cartesian axes is allowed per cell. If there are multiple x or y axes on an input chart, the first one is used, and the rest is discarded (meaning, it is removed from the combined layout).
    ///   if you need multiple axes per grid cell, create a custom grid by manually creating axes with custom domains instead.
    ///   The new id of the axes corresponds to the number of the grid cell, e.g. the third grid cell will contain xaxis3 and yaxis3
    ///
    /// - For other subplot layouts (Cartesian3D, Polar, Ternary, Geo, Mapbox, Smith), the same rule applies: only one subplot per grid cell, the first one is used, the rest is discarded.
    ///   The new id of the subplot layout corresponds to the number of the grid cell, e.g. the third grid cell will contain scene3 etc.
    ///
    /// - The Domain of traces that calculate their position by domain only (e.g. Pie traces) are replaced by a domain pointing to the new grid position.
    ///
    /// - If SubPlotTitles are provided, they are used as the titles of the individual cells in ascending order. If the number of titles is less than the number of subplots, the remaining subplots are left without a title.
    /// </summary>
    /// <param name ="SubPlotTitles">A collection of titles for the individual subplots.</param>
    /// <param name ="SubPlotTitleFont">The font of the subplot titles</param>
    /// <param name ="SubPlotTitleOffset">A vertical offset applied to each subplot title, moving it upwards if positive and vice versa</param>
    /// <param name ="SubPlots">Used for freeform grids, where some axes may be shared across subplots but others are not. Each entry should be a cartesian subplot id, like "xy" or "x3y2", or "" to leave that cell empty. You may reuse x axes within the same column, and y axes within the same row. Non-cartesian subplots and traces that support `domain` can place themselves in this grid separately using the `gridcell` attribute.</param>
    /// <param name ="XAxes">Used with `yaxes` when the x and y axes are shared across columns and rows. Each entry should be an y axis id like "y", "y2", etc., or "" to not put a y axis in that row. Entries other than "" must be unique. Ignored if `subplots` is present. If missing but `xaxes` is present, will generate consecutive IDs.</param>
    /// <param name ="YAxes">Used with `yaxes` when the x and y axes are shared across columns and rows. Each entry should be an x axis id like "x", "x2", etc., or "" to not put an x axis in that column. Entries other than "" must be unique. Ignored if `subplots` is present. If missing but `yaxes` is present, will generate consecutive IDs.</param>
    /// <param name ="RowOrder">Is the first row the top or the bottom? Note that columns are always enumerated from left to right.</param>
    /// <param name ="Pattern">If no `subplots`, `xaxes`, or `yaxes` are given but we do have `rows` and `columns`, we can generate defaults using consecutive axis IDs, in two ways: "coupled" gives one x axis per column and one y axis per row. "independent" uses a new xy pair for each cell, left-to-right across each row then iterating rows according to `roworder`.</param>
    /// <param name ="XGap">Horizontal space between grid cells, expressed as a fraction of the total width available to one cell. Defaults to 0.1 for coupled-axes grids and 0.2 for independent grids.</param>
    /// <param name ="YGap">Vertical space between grid cells, expressed as a fraction of the total height available to one cell. Defaults to 0.1 for coupled-axes grids and 0.3 for independent grids.</param>
    /// <param name ="Domain">Sets the domains of this grid subplot (in plot fraction). The first and last cells end exactly at the domain edges, with no grout around the edges.</param>
    /// <param name ="XSide">Sets where the x axis labels and titles go. "bottom" means the very bottom of the grid. "bottom plot" is the lowest plot that each x axis is used in. "top" and "top plot" are similar.</param>
    /// <param name ="YSide">Sets where the y axis labels and titles go. "left" means the very left edge of the grid. "left plot" is the leftmost plot that each y axis is used in. "right" and "right plot" are similar.</param>
    static member Grid
        (
            ?SubPlotTitles: #seq<string>,
            ?SubPlotTitleFont: Font,
            ?SubPlotTitleOffset: float,
            ?SubPlots: (StyleParam.LinearAxisId * StyleParam.LinearAxisId)[][],
            ?XAxes: StyleParam.LinearAxisId[],
            ?YAxes: StyleParam.LinearAxisId[],
            ?RowOrder: StyleParam.LayoutGridRowOrder,
            ?Pattern: StyleParam.LayoutGridPattern,
            ?XGap: float,
            ?YGap: float,
            ?Domain: Domain,
            ?XSide: StyleParam.LayoutGridXSide,
            ?YSide: StyleParam.LayoutGridYSide
        ) =
        fun (gCharts: #seq<#seq<GenericChart>>) ->

            let nRows = Seq.length gCharts

            let nCols =
                Seq.maxBy Seq.length gCharts |> Seq.length

            if Seq.exists (fun s -> (s |> Seq.length) <> nCols) gCharts then
                printfn "WARNING: not all rows contain the same amount of charts."
                printfn "The rows will be filled TO THE RIGHT with invisible dummy charts."

                printfn
                    "To have more positional control, use Chart.Empty() in your Grid where you want to have empty cells."

                let copy =
                    gCharts |> Seq.map Seq.cast<GenericChart> // this is ugly but i did not find another way for the inner seq to be be a flexible type (so you can use list, array, and seq).

                let newGrid =
                    copy
                    |> Seq.map (fun (row) ->
                        let nCharts = Seq.length row

                        if nCharts <> nCols then
                            seq {
                                yield! row

                                for i in nCharts .. nCols - 1 do
                                    yield Chart.Invisible()
                            }
                        else
                            row)
                    |> Seq.concat

                newGrid
                |> Chart.Grid(
                    nRows,
                    nCols,
                    ?SubPlotTitles = SubPlotTitles,
                    ?SubPlotTitleFont = SubPlotTitleFont,
                    ?SubPlotTitleOffset = SubPlotTitleOffset,
                    ?SubPlots = SubPlots,
                    ?XAxes = XAxes,
                    ?YAxes = YAxes,
                    ?RowOrder = RowOrder,
                    ?Pattern = Pattern,
                    ?XGap = XGap,
                    ?YGap = YGap,
                    ?Domain = Domain,
                    ?XSide = XSide,
                    ?YSide = YSide
                )
            else
                gCharts
                |> Seq.concat
                |> Chart.Grid(
                    nRows,
                    nCols,
                    ?SubPlotTitles = SubPlotTitles,
                    ?SubPlotTitleFont = SubPlotTitleFont,
                    ?SubPlotTitleOffset = SubPlotTitleOffset,
                    ?SubPlots = SubPlots,
                    ?XAxes = XAxes,
                    ?YAxes = YAxes,
                    ?RowOrder = RowOrder,
                    ?Pattern = Pattern,
                    ?XGap = XGap,
                    ?YGap = YGap,
                    ?Domain = Domain,
                    ?XSide = XSide,
                    ?YSide = YSide
                )

    /// Creates a chart stack (a subplot grid with one column) from the input charts.
    ///
    /// For each input chart, a corresponding subplot cell is created in the column. The following limitations apply to the individual grid cells:
    ///
    /// - only one pair of 2D cartesian axes is allowed per cell. If there are multiple x or y axes on an input chart, the first one is used, and the rest is discarded (meaning, it is removed from the combined layout).
    ///   if you need multiple axes per grid cell, create a custom grid by manually creating axes with custom domains instead.
    ///   The new id of the axes corresponds to the number of the grid cell, e.g. the third grid cell will contain xaxis3 and yaxis3
    ///
    /// - For other subplot layouts (Cartesian3D, Polar, Ternary, Geo, Mapbox, Smith), the same rule applies: only one subplot per grid cell, the first one is used, the rest is discarded.
    ///   The new id of the subplot layout corresponds to the number of the grid cell, e.g. the third grid cell will contain scene3 etc.
    ///
    /// - The Domain of traces that calculate their position by domain only (e.g. Pie traces) are replaced by a domain pointing to the new grid position.
    ///
    /// - If SubPlotTitles are provided, they are used as the titles of the individual cells in ascending order. If the number of titles is less than the number of subplots, the remaining subplots are left without a title.
    /// </summary>
    /// <param name ="SubPlotTitles">A collection of titles for the individual subplots.</param>
    /// <param name ="SubPlotTitleFont">The font of the subplot titles</param>
    /// <param name ="SubPlotTitleOffset">A vertical offset applied to each subplot title, moving it upwards if positive and vice versa</param>
    /// <param name ="SubPlots">Used for freeform grids, where some axes may be shared across subplots but others are not. Each entry should be a cartesian subplot id, like "xy" or "x3y2", or "" to leave that cell empty. You may reuse x axes within the same column, and y axes within the same row. Non-cartesian subplots and traces that support `domain` can place themselves in this grid separately using the `gridcell` attribute.</param>
    /// <param name ="XAxes">Used with `yaxes` when the x and y axes are shared across columns and rows. Each entry should be an y axis id like "y", "y2", etc., or "" to not put a y axis in that row. Entries other than "" must be unique. Ignored if `subplots` is present. If missing but `xaxes` is present, will generate consecutive IDs.</param>
    /// <param name ="YAxes">Used with `yaxes` when the x and y axes are shared across columns and rows. Each entry should be an x axis id like "x", "x2", etc., or "" to not put an x axis in that column. Entries other than "" must be unique. Ignored if `subplots` is present. If missing but `yaxes` is present, will generate consecutive IDs.</param>
    /// <param name ="RowOrder">Is the first row the top or the bottom? Note that columns are always enumerated from left to right.</param>
    /// <param name ="Pattern">If no `subplots`, `xaxes`, or `yaxes` are given but we do have `rows` and `columns`, we can generate defaults using consecutive axis IDs, in two ways: "coupled" gives one x axis per column and one y axis per row. "independent" uses a new xy pair for each cell, left-to-right across each row then iterating rows according to `roworder`.</param>
    /// <param name ="XGap">Horizontal space between grid cells, expressed as a fraction of the total width available to one cell. Defaults to 0.1 for coupled-axes grids and 0.2 for independent grids.</param>
    /// <param name ="YGap">Vertical space between grid cells, expressed as a fraction of the total height available to one cell. Defaults to 0.1 for coupled-axes grids and 0.3 for independent grids.</param>
    /// <param name ="Domain">Sets the domains of this grid subplot (in plot fraction). The first and last cells end exactly at the domain edges, with no grout around the edges.</param>
    /// <param name ="XSide">Sets where the x axis labels and titles go. "bottom" means the very bottom of the grid. "bottom plot" is the lowest plot that each x axis is used in. "top" and "top plot" are similar.</param>
    /// <param name ="YSide">Sets where the y axis labels and titles go. "left" means the very left edge of the grid. "left plot" is the leftmost plot that each y axis is used in. "right" and "right plot" are similar.</param>
    static member SingleStack
        (
            ?SubPlotTitles: #seq<string>,
            ?SubPlotTitleFont: Font,
            ?SubPlotTitleOffset: float,
            ?SubPlots: (StyleParam.LinearAxisId * StyleParam.LinearAxisId)[][],
            ?XAxes: StyleParam.LinearAxisId[],
            ?YAxes: StyleParam.LinearAxisId[],
            ?RowOrder: StyleParam.LayoutGridRowOrder,
            ?Pattern: StyleParam.LayoutGridPattern,
            ?XGap: float,
            ?YGap: float,
            ?Domain: Domain,
            ?XSide: StyleParam.LayoutGridXSide,
            ?YSide: StyleParam.LayoutGridYSide
        ) =

        fun (gCharts: #seq<GenericChart>) ->

            gCharts
            |> Chart.Grid(
                nRows = Seq.length gCharts,
                nCols = 1,
                ?SubPlotTitles = SubPlotTitles,
                ?SubPlotTitleFont = SubPlotTitleFont,
                ?SubPlotTitleOffset = SubPlotTitleOffset,
                ?SubPlots = SubPlots,
                ?XAxes = XAxes,
                ?YAxes = YAxes,
                ?RowOrder = RowOrder,
                ?Pattern = Pattern,
                ?XGap = XGap,
                ?YGap = YGap,
                ?Domain = Domain,
                ?XSide = XSide,
                ?YSide = YSide
            )


    /// Sets the color axis with the given id on the chart layout
    static member withColorAxis(colorAxis: ColorAxis, ?Id) =
        (fun (ch: GenericChart) ->
            let layout =
                let id =
                    defaultArg Id (StyleParam.SubPlotId.ColorAxis 1)

                GenericChart.getLayout ch |> Layout.updateColorAxisById (id, colorAxis)

            GenericChart.setLayout layout ch)

    /// <summary>
    /// Sets the given images on the input chart's layout. Use the 'Append' argument to decide what should happen if there are already images set.
    /// </summary>
    /// <param name="images">The images to add to the input charts layout</param>
    /// <param name="Append">If true, the input images will be appended to existing images, otherwise existing images will be removed (default: true)</param>
    static member withLayoutImages(images: seq<LayoutImage>, ?Append: bool) =
        let append = defaultArg Append true

        fun (ch: GenericChart) ->

            let images' =

                if append then

                    let layout = GenericChart.getLayout ch

                    layout.TryGetTypedPropertyValue<seq<LayoutImage>>("images")
                    |> Option.defaultValue Seq.empty
                    |> Seq.append images

                else
                    images

            ch |> GenericChart.mapLayout (Layout.style (Images = images'))

    /// <summary>
    /// Sets the given image on the input chart's layout. Use the 'Append' argument to decide what should happen if there are already images set.
    /// </summary>
    /// <param name="image">The images to add to the input charts layout</param>
    /// <param name="Append">If true, the input image will be appended to existing images, otherwise existing images will be removed (default: true)</param>
    static member withLayoutImage(image: LayoutImage, ?Append: bool) =

        Chart.withLayoutImages ([ image ], ?Append = Append)

    /// <summary>
    /// Sets the given update menus on the input chart's layout. Use the 'Append' argument to decide what should happen if there are already update menus set.
    /// </summary>
    /// <param name="updateMenus">The updatmenus to add to the input charts layout</param>
    /// <param name="Append">If true, the update menus will be appended to existing update menus, otherwise existing update menus will be removed (default: true)</param>
    static member withUpdateMenus
        (
            updateMenus: seq<UpdateMenu>,
            ?Append: bool
        ) =
        let append = defaultArg Append true

        fun (ch: GenericChart) ->

            let updateMenus' =

                if append then

                    let layout = GenericChart.getLayout ch

                    layout.TryGetTypedPropertyValue<seq<UpdateMenu>>("updatemenus")
                    |> Option.defaultValue Seq.empty
                    |> Seq.append updateMenus

                else
                    updateMenus

            ch |> GenericChart.mapLayout (Layout.style (UpdateMenus = updateMenus'))

    /// <summary>
    /// Sets the given update menu on the input chart's layout. Use the 'Append' argument to decide what should happen if there are already update menus set.
    /// </summary>
    /// <param name="updateMenu">The updatmenus to add to the input charts layout</param>
    /// <param name="Append">If true, the update menu will be appended to existing update menus, otherwise existing update menus will be removed (default: true)</param>
    static member withUpdateMenu(updateMenu: UpdateMenu, ?Append: bool) =

        Chart.withUpdateMenus ([ updateMenu ], ?Append = Append)

    /// <summary>
    /// Sets the given sliders on the input chart's layout. Use the 'Append' argument to decide what should happen if there are already update menus set.
    /// </summary>
    /// <param name="sliders">The sliders to add to the input charts layout</param>
    /// <param name="Append">If true, the sliders will be appended to existing sliders, otherwise existing sliders will be removed (default: true)</param>
    static member withSliders(
        sliders: seq<Slider>,
        ?Append: bool
    ) =
        let append = defaultArg Append true

        fun (ch: GenericChart) ->

            let sliders' =

                if append then

                    let layout = GenericChart.getLayout ch

                    layout.TryGetTypedPropertyValue<seq<Slider>>("sliders")
                    |> Option.defaultValue Seq.empty
                    |> Seq.append sliders

                else
                    sliders

            ch |> GenericChart.mapLayout (Layout.style (Sliders = sliders'))

    /// <summary>
    /// Sets the given slider on the input chart's layout. Use the 'Append' argument to decide what should happen if there are already update menus set.
    /// </summary>
    /// <param name="slider">The slider to add to the input charts layout</param>
    /// <param name="Append">If true, the slider will be appended to existing sliders, otherwise existing sliders will be removed (default: true)</param>
    static member withSlider(slider: Slider, ?Append: bool) = Chart.withSliders ([ slider ], ?Append = Append)


    // ############################################################
    // ####################### Apply to DisplayOptions

    // <summary>
    /// Sets the given DisplayOptions on the input chart.
    ///
    /// If there is already an DisplayOptions set, the object is replaced.
    /// </summary>
    static member setDisplayOptions(displayOpts: DisplayOptions) =
        (fun (ch: GenericChart) -> GenericChart.setDisplayOptions displayOpts ch)

    /// <summary>
    /// Sets the given DisplayOptions on the input chart.
    ///
    /// If there is already an DisplayOptions set, the objects are combined.
    /// </summary>
    static member withDisplayOptions(displayOpts: DisplayOptions) =
        (fun (ch: GenericChart) -> GenericChart.addDisplayOptions displayOpts ch)

    /// <summary>
    /// Applies the given styles to the chart's DisplayOptions object. Overwrites attributes with the same name that are already set.
    /// </summary>
    /// <param name="DocumentTitle">The title metadata for the document</param>
    /// <param name="DocumentCharset">The document charset</param>
    /// <param name="DocumentDescription">The description metadata for the document</param>
    /// <param name="DocumentFavicon">base64 encoded favicon image</param>
    /// <param name="AdditionalHeadTags">Additional tags that will be included in the document's head </param>
    /// <param name="ChartDescription">HTML tags that appear below the chart in HTML docs</param>
    /// <param name="PlotlyJSReference">Sets how plotly is referenced in the head of html docs. When CDN, a script tag that references the plotly.js CDN is included in the output. When Full, a script tag containing the plotly.js source code (~3MB) is included in the output. HTML files generated with this option are fully self-contained and can be used offline</param>
    static member withDisplayOptionsStyle
        (
            ?DocumentTitle: string,
            ?DocumentCharset: string,
            ?DocumentDescription: string,
            ?DocumentFavicon: XmlNode,
            ?AdditionalHeadTags: XmlNode list,
            ?ChartDescription: XmlNode list,
            ?PlotlyJSReference: PlotlyJSReference
        ) =
        (fun (ch: GenericChart) ->

            let displayOpts' =
                DisplayOptions.init (
                    ?DocumentTitle = DocumentTitle,
                    ?DocumentCharset = DocumentCharset,
                    ?DocumentDescription = DocumentDescription,
                    ?DocumentFavicon = DocumentFavicon,
                    ?AdditionalHeadTags = AdditionalHeadTags,
                    ?ChartDescription = ChartDescription,
                    ?PlotlyJSReference = PlotlyJSReference
                )

            GenericChart.addDisplayOptions displayOpts' ch)


    /// <summary>
    /// Adds the given chart deycription the to chart's DisplayOptions. They will be included in the document's head
    /// </summary>
    /// <param name="chartDescription">The chart description to add to the given chart's DisplayOptions object</param>
    /// <param name="ch">The chart to add a description to</param>
    static member withDescription (chartDescription: XmlNode list) (ch: GenericChart) =
        ch |> GenericChart.mapDisplayOptions (DisplayOptions.addChartDescription chartDescription)

    /// Adds the given additional html tags on the chart's DisplayOptions. They will be included in the document's head
    static member withAdditionalHeadTags (additionalHeadTags: XmlNode list) (ch: GenericChart) =
        ch |> GenericChart.mapDisplayOptions (DisplayOptions.addAdditionalHeadTags additionalHeadTags)

    /// Sets the given additional head tags on the chart's DisplayOptions. They will be included in the document's head
    static member withHeadTags (additionalHeadTags: XmlNode list) (ch: GenericChart) =
        ch |> GenericChart.mapDisplayOptions (DisplayOptions.setAdditionalHeadTags additionalHeadTags)


    /// Adds the necessary script tags to render tex strings to the chart's DisplayOptions
    static member withMathTex
        (
            ?AppendTags: bool,
            ?MathJaxVersion: int
        ) =
        let version =
            MathJaxVersion |> Option.defaultValue 3

        let tags =
            if version = 2 then
                Globals.MATHJAX_V2_TAGS
            else
                Globals.MATHJAX_V3_TAGS

        (fun (ch: GenericChart) ->

            if (AppendTags |> Option.defaultValue true) then
                ch |> Chart.withAdditionalHeadTags tags |> Chart.withConfigStyle (TypesetMath = true)
            else
                ch |> Chart.withHeadTags tags |> Chart.withConfigStyle (TypesetMath = true))
