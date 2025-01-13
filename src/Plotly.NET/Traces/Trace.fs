namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open System
open System.Runtime.InteropServices
open System.Text.RegularExpressions

/// A Trace object in the context of plotly charts contains the data to visualize and additional styling parameters.
///
/// This is the base object that contains visualization-unspecific getters and setters for the underlying DynamicObj.
///
/// Visualization-specific equivalents are suffixed with the respective trace subtype, e.g. `Trace2D`
type Trace(traceTypeName: string) =
    inherit DynamicObj()

    member val ``type`` = traceTypeName with get, set

    /// <summary>
    /// Returns Some(dynamic member value) of the trace object's underlying DynamicObj when a dynamic member with the given name exists, and None otherwise.
    /// </summary>
    /// <param name="propName">The name of the dynamic member to get the value of</param>
    /// <param name="trace">The trace to get the dynamic member value from</param>
    static member tryGetTypedMember<'T> (propName: string) (trace: Trace) = trace.TryGetTypedPropertyValue<'T>(propName)

    /// <summary>
    /// Returns the Marker object of the given trace.
    ///
    /// If there is no marker set, returns an empty marker object.
    /// </summary>
    /// <param name="trace">The trace to get the marker from</param>
    static member getMarker(trace: #Trace) =
        trace |> Trace.tryGetTypedMember<Marker> "marker" |> Option.defaultValue (Marker.init ())

    /// <summary>
    /// Returns a function that sets the Marker object of the given trace.
    /// </summary>
    /// <param name="marker">The new marker object</param>
    static member setMarker(marker: Marker) =
        (fun (trace: ('T :> Trace)) ->
            trace.SetProperty("marker", marker)
            trace)

    /// <summary>
    /// Combines the given marker object with the one already present on the trace.
    /// </summary>
    /// <param name="marker">The updated Trace object</param>
    static member updateMarker(marker: Marker) =
        (fun (trace: #Trace) ->
            let combined =
                (DynObj.combine (trace |> Trace.getMarker) marker) |> unbox<Marker>

            trace |> Trace.setMarker combined)

    /// <summary>
    /// Returns the Line object of the given trace.
    ///
    /// If there is no line set, returns an empty line object.
    /// </summary>
    /// <param name="trace">The trace to get the line from</param>
    static member getLine(trace: #Trace) =
        trace |> Trace.tryGetTypedMember<Line> "line" |> Option.defaultValue (Line.init ())

    /// <summary>
    /// Returns a function that sets the Line object of the given trace.
    /// </summary>
    /// <param name="line">The new line object</param>
    static member setLine(line: Line) =
        (fun (trace: #Trace) ->
            trace.SetProperty("line", line)
            trace)

    /// <summary>
    /// Combines the given Line object with the one already present on the trace.
    /// </summary>
    /// <param name="line">The updated Line object</param>
    static member updateLine(line: Line) =
        (fun (trace: #Trace) ->
            let combined =
                (DynObj.combine (trace |> Trace.getLine) line) |> unbox<Line>

            trace |> Trace.setLine combined)

    /// <summary>
    /// Returns the Error object for the x dimension of the given trace.
    ///
    /// If there is no error set, returns an empty error object.
    /// </summary>
    /// <param name="trace">The trace to get the x error from</param>
    static member getXError(trace: #Trace) =
        trace |> Trace.tryGetTypedMember<Error> "error_x" |> Option.defaultValue (Error.init ())

    /// <summary>
    /// Returns a function that sets the Error object for the x dimension of the given trace.
    /// </summary>
    /// <param name="error">The new error object</param>
    static member setXError(error: Error) =
        (fun (trace: #Trace) ->
            trace.SetProperty("error_x", error)
            trace)

    /// <summary>
    /// Combines the given Error object for the x dimension with the one already present on the trace.
    /// </summary>
    /// <param name="error">The updated Error object</param>
    static member updateXError(error: Error) =
        (fun (trace: #Trace) ->
            let combined =
                (DynObj.combine (trace |> Trace.getXError) error) |> unbox<Error>

            trace |> Trace.setXError combined)

    /// <summary>
    /// Returns the Error object for the y dimension of the given trace.
    ///
    /// If there is no error set, returns an empty error object.
    /// </summary>
    /// <param name="trace">The trace to get the y error from</param>
    static member getYError(trace: #Trace) =
        trace |> Trace.tryGetTypedMember<Error> "error_y" |> Option.defaultValue (Error.init ())

    /// <summary>
    /// Returns a function that sets the Error object for the x dimension of the given trace.
    /// </summary>
    /// <param name="error">The new error object</param>
    static member setYError(error: Error) =
        (fun (trace: #Trace) ->
            trace.SetProperty("error_y", error)
            trace)

    /// <summary>
    /// Combines the given Error object for the y dimension with the one already present on the trace.
    /// </summary>
    /// <param name="error">The updated Error object</param>
    static member updateYError(error: Error) =
        (fun (trace: #Trace) ->
            let combined =
                (DynObj.combine (trace |> Trace.getYError) error) |> unbox<Error>

            trace |> Trace.setYError combined)

    /// <summary>
    /// Returns the Error object for the z dimension of the given trace.
    ///
    /// If there is no error set, returns an empty error object.
    /// </summary>
    /// <param name="trace">The trace to get the z error from</param>
    static member getZError(trace: #Trace) =
        trace |> Trace.tryGetTypedMember<Error> "error_z" |> Option.defaultValue (Error.init ())

    /// <summary>
    /// Returns a function that sets the Error object for the x dimension of the given trace.
    /// </summary>
    /// <param name="error">The new error object</param>
    static member setZError(error: Error) =
        (fun (trace: #Trace) ->
            trace.SetProperty("error_z", error)
            trace)

    /// <summary>
    /// Combines the given Error object for the z dimension with the one already present on the trace.
    /// </summary>
    /// <param name="error">The updated Error object</param>
    static member updateZError(error: Error) =
        (fun (trace: #Trace) ->
            let combined =
                (DynObj.combine (trace |> Trace.getZError) error) |> unbox<Error>

            trace |> Trace.setZError combined)

    /// <summary>
    /// Returns the color axis anchor of the given trace.
    ///
    /// If there is no color axis set, returns "coloraxis".
    /// </summary>
    /// <param name="trace">The trace to get the color axis anchor from</param>
    static member getColorAxisAnchor(trace: #Trace) =
        let idString =
            trace |> Trace.tryGetTypedMember<string> ("coloraxis") |> Option.defaultValue "coloraxis"

        if idString = "coloraxis" then
            StyleParam.SubPlotId.ColorAxis 1
        else
            StyleParam.SubPlotId.ColorAxis(idString.Replace("coloraxis", "") |> int)

    /// <summary>
    /// Returns a function that sets the color axis anchor of the given trace.
    /// </summary>
    /// <param name="colorAxisId">The new color axis anchor</param>
    static member setColorAxisAnchor(colorAxisId: int) =
        let id =
            StyleParam.SubPlotId.ColorAxis colorAxisId

        (fun (trace: #Trace) ->
            trace.SetProperty("coloraxis", StyleParam.SubPlotId.convert id)
            trace)

     /// <summary>
    /// Returns the Legend anchor of the given trace.
    ///
    /// If there is no Legend set, returns "legend".
    /// </summary>
    /// <param name="trace">The trace to get the Legend anchor from</param>
    static member getLegendAnchor(trace: #Trace) =
        let idString =
            trace |> Trace.tryGetTypedMember<string> ("legend") |> Option.defaultValue "legend"

        if idString = "legend" then
            StyleParam.SubPlotId.Legend 1
        else
            StyleParam.SubPlotId.Legend(idString.Replace("legend", "") |> int)

    /// <summary>
    /// Returns a function that sets the Legend anchor of the given trace.
    /// </summary>
    /// <param name="legendId">The new Legend anchor</param>
    static member setLegendAnchor(legendId: int) =
        let id =
            StyleParam.SubPlotId.Legend legendId

        (fun (trace: #Trace) ->
            trace.SetProperty("legend", StyleParam.SubPlotId.convert id)
            trace)

    /// <summary>
    /// Returns the domain of the given trace.
    ///
    /// If there is no domain set, returns an empty Domain object.
    /// </summary>
    /// <param name="trace">The trace to get the cdomain from</param>
    static member getDomain(trace: #Trace) =
        trace |> Trace.tryGetTypedMember<Domain> "domain" |> Option.defaultValue (Domain.init ())

    /// <summary>
    /// Returns a function that sets the domain of the given trace.
    /// </summary>
    /// <param name="domain">The new domain</param>
    static member setDomain(domain: Domain) =
        (fun (trace: ('T :> Trace)) ->
            trace.SetProperty("domain", domain)
            trace)

    /// <summary>
    /// Combines the given Domain object with the one already present on the trace.
    /// </summary>
    /// <param name="domain">The updated Domain object</param>
    static member updateDomain(domain: Domain) =
        (fun (trace: #Trace) ->
            let combined =
                (DynObj.combine (trace |> Trace.getDomain) domain) |> unbox<Domain>

            trace |> Trace.setDomain combined)

    /// <summary>
    /// Returns the stackgroup of the given trace.
    ///
    /// If there is no stackgroup set, returns "stackgroup".
    /// </summary>
    /// <param name="trace">The trace to get the stackgroup from</param>
    static member getStackGroup(trace: #Trace) =
        trace |> Trace.tryGetTypedMember<string> "stackgroup" |> Option.defaultValue ("")

    /// <summary>
    /// Returns a function that sets the stackgroup of the given trace.
    /// </summary>
    /// <param name="stackgroup">The new stackgroup</param>
    static member setStackGroup(stackgroup: string) =
        (fun (trace: ('T :> Trace)) ->
            trace.SetProperty("stackgroup", stackgroup)
            trace)

    /// <summary>
    /// Returns the colorbar of the given trace.
    ///
    /// If there is no colorbar set, returns an empty ColorBar object.
    /// </summary>
    /// <param name="trace">The trace to get the cdomain from</param>
    static member getColorBar(trace: #Trace) =
        trace |> Trace.tryGetTypedMember<ColorBar> "colorbar" |> Option.defaultValue (ColorBar.init ())

    /// <summary>
    /// Returns a function that sets the ColorBar of the given trace.
    /// </summary>
    /// <param name="colorBar">The new ColorBar</param>
    static member setColorBar(colorBar: ColorBar) =
        (fun (trace: ('T :> Trace)) ->

            trace.SetProperty("colorbar", colorBar)
            trace)

    /// <summary>
    /// Combines the given ColorBar object with the one already present on the trace.
    /// </summary>
    /// <param name="colorBar">The updated ColorBar object</param>
    static member updateColorBar(colorBar: ColorBar) =
        (fun (trace: #Trace) ->
            let combined =
                DynObj.combine (trace |> Trace.getColorBar) colorBar |> unbox<ColorBar>

            trace |> Trace.setColorBar combined)

//-------------------------------------------------------------------------------------------------------------------------------------------------
/// Contains general, visualization-unspecific functions to style Trace objects.
///
/// These functions are used internally to style traces of Chart objects.
/// Users should usually be pointed to the API layer provided by the `Chart` module/object first.
///
/// Visualization-specific equivalents are suffixed with the respective trace subtype, e.g. `TraceStyle2D`
type TraceStyle() =

    /// <summary>
    /// Sets trace information on the given trace.
    /// </summary>
    /// <param name="Name">Sets the name of the chart's trace(s). When the chart is a multichart (it contains multiple traces), the name is suffixed by '_%i' where %i is the index of the trace.</param>
    /// <param name="Visible">Whether or not the chart's traces are visible</param>
    /// <param name="ShowLegend">Determines whether or not item(s) corresponding to this chart's trace(s) is/are shown in the legend.</param>
    /// <param name="LegendRank">Sets the legend rank for the chart's trace(s). Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for the chart's trace(s). Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the title for the chart's trace legend group </param>
    static member TraceInfo
        (
            ?Name: string,
            ?Visible: StyleParam.Visible,
            ?ShowLegend: bool,
            ?LegendRank: int,
            ?LegendGroup: string,
            ?LegendGroupTitle: Title
        ) =
        fun (trace: #Trace) ->
            trace
            |> DynObj.withOptionalProperty "name" Name
            |> DynObj.withOptionalPropertyBy "visible" Visible StyleParam.Visible.convert
            |> DynObj.withOptionalProperty "showlegend" ShowLegend
            |> DynObj.withOptionalProperty "legendrank" LegendRank
            |> DynObj.withOptionalProperty "legendgroup" LegendGroup
            |> DynObj.withOptionalProperty "legendgrouptitle" LegendGroupTitle

    /// <summary>
    /// Returns a function that applies the given styles to the trace's marker object. Overwrites attributes with the same name that are already set.
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
    static member Marker
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
        (fun (trace: ('T :> Trace)) ->
            let marker =
                trace
                |> Trace.getMarker
                |> Marker.style (
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

            trace |> Trace.setMarker (marker))

    /// <summary>
    /// Returns a function that applies the given styles to the trace's line object. Overwrites attributes with the same name that are already set.
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
    static member Line
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
        (fun (trace: ('T :> Trace)) ->
            let line =
                trace
                |> Trace.getLine
                |> Line.style (
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

            trace |> Trace.setLine (line))

    /// <summary>
    /// Returns a function that applies the given styles to the trace's Error object for the x dimension. Overwrites attributes with the same name that are already set.
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
    static member XError
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
        (fun (trace: ('T :> Trace)) ->
            let xerror =
                trace
                |> Trace.getXError
                |> Error.style (
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

            trace |> Trace.setXError (xerror))

    /// <summary>
    /// Returns a function that applies the given styles to the trace's Error object for the y dimension. Overwrites attributes with the same name that are already set.
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
    static member YError
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
        (fun (trace: ('T :> Trace)) ->
            let yerror =
                trace
                |> Trace.getYError
                |> Error.style (
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

            trace |> Trace.setYError (yerror))

    /// <summary>
    /// Returns a function that applies the given styles to the trace's Error object for the z dimension.
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
    static member ZError
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
        (fun (trace: ('T :> Trace)) ->
            let zerror =
                trace
                |> Trace.getZError
                |> Error.style (
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

            trace |> Trace.setZError (zerror))

    /// <summary>
    /// Returns a function that applies the given styles to the trace's selection.
    /// </summary>
    /// <param name="SelectedPoints">Array containing integer indices of selected points. Has an effect only for traces that support selections. Note that an empty array means an empty selection where the `unselected` are turned on for all points, whereas, any other non-array values means no selection all where the `selected` and `unselected` styles have no effect.</param>
    /// <param name="Selected">Sets the style of selected points of this trace.</param>
    /// <param name="Unselected">Sets the style of unselected points of this trace.</param>
    static member Selection
        (
            ?SelectedPoints: seq<#IConvertible>,
            ?Selected: TraceSelection,
            ?Unselected: TraceSelection
        ) =
        fun (trace: #Trace) ->
            trace
            |> DynObj.withOptionalProperty "selectedpoints" SelectedPoints
            |> DynObj.withOptionalProperty "selected" Selected
            |> DynObj.withOptionalProperty "unselected" Unselected

    /// <summary>
    /// Returns a function that applies the given styles to the trace's text items.
    /// </summary>
    /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="TextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
    /// <param name="MultiTextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
    /// <param name="TextTemplate">Template string used for rendering the information text that appear on points. Note that this will override `textinfo`. Variables are inserted using %{variable}, for example "y: %{y}". Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. Every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available.</param>
    /// <param name="MultiTextTemplate">Template string used for rendering the information text that appear on points. Note that this will override `textinfo`. Variables are inserted using %{variable}, for example "y: %{y}". Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. Every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available.</param>
    /// <param name="HoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="MultiHoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
    /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="MultiHoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="TextFont">Sets the text font of this trace.</param>
    static member TextLabel
        (
            ?Text: #IConvertible,
            ?MultiText: seq<#IConvertible>,
            ?TextPosition: StyleParam.TextPosition,
            ?MultiTextPosition: seq<StyleParam.TextPosition>,
            ?TextTemplate: string,
            ?MultiTextTemplate: seq<string>,
            ?HoverText: string,
            ?MultiHoverText: seq<string>,
            ?HoverInfo: StyleParam.HoverInfo,
            ?HoverTemplate: string,
            ?MultiHoverTemplate: seq<string>,
            ?TextFont: Font
        ) =
        fun (trace: #Trace) ->
            trace
            |> DynObj.withOptionalSingleOrMultiProperty "text" (Text, MultiText)
            |> DynObj.withOptionalSingleOrMultiPropertyBy "textposition" (TextPosition, MultiTextPosition) StyleParam.TextPosition.convert
            |> DynObj.withOptionalSingleOrMultiProperty "texttemplate" (TextTemplate, MultiTextTemplate)
            |> DynObj.withOptionalSingleOrMultiProperty "hovertext" (HoverText, MultiHoverText)
            |> DynObj.withOptionalPropertyBy "hoverinfo" HoverInfo StyleParam.HoverInfo.convert
            |> DynObj.withOptionalSingleOrMultiProperty "hovertemplate" (HoverTemplate, MultiHoverTemplate)
            |> DynObj.withOptionalProperty "textfont" TextFont


    // <summary>
    /// Returns a function that applies the given styles to the trace's domain object.
    /// </summary>
    static member Domain
        (
            ?X: StyleParam.Range,
            ?Y: StyleParam.Range,
            ?Row: int,
            ?Column: int
        ) =
        (fun (trace: ('T :> Trace)) ->
            let domain =
                trace |> Trace.getDomain |> Domain.style (?X = X, ?Y = Y, ?Row = Row, ?Column = Column)

            trace |> Trace.setDomain domain)
