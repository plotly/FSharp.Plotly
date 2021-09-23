namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open System
open System.Runtime.InteropServices

/// The most commonly-used kind of subplot is a two-dimensional Cartesian subplot. Traces compatible with these subplots 
/// support xaxis and yaxis attributes whose values must refer to corresponding objects in the layout portion of the figure. 
/// For example, if xaxis="x", and yaxis="y" (which is the default) then this trace is drawn on the subplot at the intersection 
/// of the axes configured under layout.xaxis and layout.yaxis, but if xaxis="x2" and yaxis="y3" then the trace is drawn at the 
/// intersection of the axes configured under layout.xaxis2 and layout.yaxis3. Note that attributes such as layout.xaxis and 
/// layout.xaxis2 etc do not have to be explicitly defined, in which case default values will be inferred. Multiple traces of 
/// different types can be drawn on the same subplot.
///
/// X- and Y-axes support the type attribute, which enables them to represent continuous values (type="linear", type="log"), 
/// temporal values (type="date") or categorical values (type="category", type="multicategory). Axes can also be overlaid on 
/// top of one another to create dual-axis or multiple-axis charts. 2-d cartesian subplots lend themselves very well to creating 
/// "small multiples" figures, also known as facet or trellis plots.
///
/// The following trace types are compatible with 2d-cartesian subplots via the xaxis and yaxis attributes:
///
/// - scatter-like trace types: scatter and scattergl can be used to draw scatter plots, line plots and curves, time-series plots, 
/// bubble charts, dot plots and filled areas and also support error bars
///
/// - bar, funnel, waterfall: bar-like trace types which can also be used to draw timelines and Gantt charts
///
/// - histogram: an aggregating bar-like trace type
///
/// - box and violin: 1-dimensional distribution-like trace types
///
/// - histogram2d and histogram2dcontour: 2-dimensional distribution-like density trace types
///
/// - image, heatmap and contour: matrix trace types
///
/// - ohlc and candlestick: stock-like trace types
///
/// - splom: multi-dimensional scatter plots which implicitly refer to many 2-d cartesian subplots at once.


type Trace2D(traceTypeName) =

    inherit Trace (traceTypeName)

    ///initializes a trace of type "scatter" applying the given trace styling function
    static member initScatter (applyStyle: Trace2D -> Trace2D) = 
        Trace2D("scatter") |> applyStyle

    ///initializes a trace of type "scattergl" applying the given trace styling function
    static member initScatterGL (applyStyle: Trace2D -> Trace2D) = 
        Trace2D("scattergl") |> applyStyle

    ///initializes a trace of type "bar" applying the given trace styling function
    static member initBar (applyStyle: Trace2D -> Trace2D) = 
        Trace2D("bar") |> applyStyle

    ///initializes a trace of type "funnel" applying the given trace styling function
    static member initFunnel (applyStyle: Trace2D -> Trace2D) = 
        Trace2D("funnel") |> applyStyle

    ///initializes a trace of type "waterfall" applying the given trace styling function
    static member initWaterfall (applyStyle: Trace2D -> Trace2D) = 
        Trace2D("waterfall") |> applyStyle
         
    ///initializes a trace of type "histogram" applying the given trace styling function
    static member initHistogram (applyStyle: Trace2D -> Trace2D) = 
        Trace2D("histogram") |> applyStyle

    ///initializes a trace of type "box" applying the given trace styling function
    static member initBoxPlot (applyStyle: Trace2D -> Trace2D) = 
        Trace2D("box") |> applyStyle

    ///initializes a trace of type "violin" applying the given trace styling function
    static member initViolin (applyStyle: Trace2D -> Trace2D) = 
        Trace2D("violin") |> applyStyle

    ///initializes a trace of type "histogram2d" applying the given trace styling function
    static member initHistogram2d (applyStyle: Trace2D -> Trace2D) = 
        Trace2D("histogram2d") |> applyStyle

    ///initializes a trace of type "histogram2dcontour" applying the given trace styling function
    static member initHistogram2dContour (applyStyle: Trace2D -> Trace2D) = 
        Trace2D("histogram2dcontour") |> applyStyle

    ///initializes a trace of type "image" applying the given trace styling function
    static member initImage (applyStyle: Trace2D -> Trace2D) = 
         Trace2D("image") |> applyStyle
    
    ///initializes a trace of type "heatmap" applying the given trace styling function
    static member initHeatmap (applyStyle: Trace2D -> Trace2D) = 
        Trace2D("heatmap") |> applyStyle

    ///initializes a trace of type "heatmapgl" applying the given trace styling function
    static member initHeatmapGL (applyStyle: Trace2D -> Trace2D) = 
        Trace2D("heatmapgl") |> applyStyle

    ///initializes a trace of type "contour" applying the given trace styling function
    static member initContour (applyStyle: Trace2D -> Trace2D) = 
        Trace2D("contour") |> applyStyle

    ///initializes a trace of type "ohlc" applying the given trace styling function
    static member initOHLC (applyStyle: Trace2D -> Trace2D) = 
        Trace2D("ohlc") |> applyStyle

    ///initializes a trace of type "candlestick" applying the given trace styling function
    static member initCandlestick (applyStyle: Trace2D -> Trace2D) = 
        Trace2D("candlestick") |> applyStyle

    ///initializes a trace of type "SPLOM" applying the given trace styling function
    static member initSplom (applyStyle: Trace2D -> Trace2D) = 
        Trace2D("splom") |> applyStyle


type Trace2DStyle() =
    
    /// Sets the given axis anchor id(s) on a Trace object.
    static member SetAxisAnchor
        (
            [<Optional;DefaultParameterValue(null)>] ?X:StyleParam.LinearAxisId,
            [<Optional;DefaultParameterValue(null)>] ?Y:StyleParam.LinearAxisId
        ) =  
            (fun (trace:Trace2D) ->

                X     |> DynObj.setValueOptBy trace "xaxis" StyleParam.LinearAxisId.toString
                Y     |> DynObj.setValueOptBy trace "yaxis" StyleParam.LinearAxisId.toString
                    
                trace
            )

    /// <summary>
    /// Create a function that applies the styles of a scatter plot to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Opacity">Sets the opacity of the trace.</param>
    /// <param name="Mode">Determines the drawing mode for this scatter trace. If the provided `mode` includes "text" then the `text` elements appear at the coordinates. Otherwise, the `text` elements appear on hover. If there are less than 20 points and the trace is not stacked then the default is "lines+markers". Otherwise, "lines".</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="X">Sets the x coordinates.</param>
    /// <param name="X0">Alternate to `x`. Builds a linear space of x coordinates. Use with `dx` where `x0` is the starting coordinate and `dx` the step.</param>
    /// <param name="DX">Sets the x coordinate step. See `x0` for more info.</param>
    /// <param name="Y">Sets the y coordinates.</param>
    /// <param name="Y0">Alternate to `y`. Builds a linear space of y coordinates. Use with `dy` where `y0` is the starting coordinate and `dy` the step.</param>
    /// <param name="DY">Sets the y coordinate step. See `y0` for more info.</param>
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
    /// <param name="XHoverFormat">Sets the hover text formatting rulefor `x` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="YHoverFormat">Sets the hover text formatting rulefor `y` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="XAxis">Sets a reference between this trace's x coordinates and a 2D cartesian x axis. If "x" (the default value), the x coordinates refer to `layout.xaxis`. If "x2", the x coordinates refer to `layout.xaxis2`, and so on.</param>
    /// <param name="YAxis">Sets a reference between this trace's y coordinates and a 2D cartesian y axis. If "y" (the default value), the y coordinates refer to `layout.yaxis`. If "y2", the y coordinates refer to `layout.yaxis2`, and so on.</param>
    /// <param name="Orientation">Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used - including if `visible` is "legendonly" but not if it is `false`. Sets the stacking direction. With "v" ("h"), the y (x) values of subsequent traces are added. Also affects the default value of `fill`.</param>
    /// <param name="GroupNorm">Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used - including if `visible` is "legendonly" but not if it is `false`. Sets the normalization for the sum of this `stackgroup`. With "fraction", the value of each trace at each location is divided by the sum of all trace values at that location. "percent" is the same but multiplied by 100 to show percentages. If there are multiple subplots, or multiple `stackgroup`s on one subplot, each will be normalized within its own set.</param>
    /// <param name="StackGroup">Set several scatter traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `orientation` is "h"). If blank or omitted this trace will not be stacked. Stacking also turns `fill` on by default, using "tonexty" ("tonextx") if `orientation` is "h" ("v") and sets the default `mode` to "lines" irrespective of point count. You can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order.</param>
    /// <param name="XPeriod">Only relevant when the axis `type` is "date". Sets the period positioning in milliseconds or "M&lt;n&gt;" on the x axis. Special values in the form of "M&lt;n&gt;" could be used to declare the number of months. In this case `n` must be a positive integer.</param>
    /// <param name="XPeriodAlignment">Only relevant when the axis `type` is "date". Sets the alignment of data points on the x axis.</param>
    /// <param name="XPeriod0">Only relevant when the axis `type` is "date". Sets the base for period positioning in milliseconds or date string on the x0 axis. When `x0period` is round number of weeks, the `x0period0` by default would be on a Sunday i.e. 2000-01-02, otherwise it would be at 2000-01-01.</param>
    /// <param name="YPeriod">Only relevant when the axis `type` is "date". Sets the period positioning in milliseconds or "M&lt;n&gt;" on the y axis. Special values in the form of "M&lt;n&gt;" could be used to declare the number of months. In this case `n` must be a positive integer.</param>
    /// <param name="YPeriodAlignment">Only relevant when the axis `type` is "date". Sets the alignment of data points on the y axis.</param>
    /// <param name="YPeriod0">Only relevant when the axis `type` is "date". Sets the base for period positioning in milliseconds or date string on the y0 axis. When `y0period` is round number of weeks, the `y0period0` by default would be on a Sunday i.e. 2000-01-02, otherwise it would be at 2000-01-01.</param>
    /// <param name="Marker">Sets the marker of this trace.</param>
    /// <param name="Line">Sets the line of this trace.</param>
    /// <param name="TextFont">Sets the text font of this trace.</param>
    /// <param name="ErrorX">Sets the x error of this trace.</param>
    /// <param name="ErrorY">Sets the y error of this trace.</param>
    /// <param name="SelectedPoints">Array containing integer indices of selected points. Has an effect only for traces that support selections. Note that an empty array means an empty selection where the `unselected` are turned on for all points, whereas, any other non-array values means no selection all where the `selected` and `unselected` styles have no effect.</param>
    /// <param name="Selected">Sets the style of selected points of this trace.</param>
    /// <param name="Unselected">Sets the style of unselected points of this trace.</param>
    /// <param name="ClipOnAxis">Determines whether or not markers and text nodes are clipped about the subplot axes. To show markers and text nodes above axis lines and tick labels, make sure to set `xaxis.layer` and `yaxis.layer` to "below traces".</param>
    /// <param name="ConnectGaps">Determines whether or not gaps (i.e. {nan} or missing values) in the provided data arrays are connected.</param>
    /// <param name="Fill">Sets the area to fill with a solid color. Defaults to "none" unless this trace is stacked, then it gets "tonexty" ("tonextx") if `orientation` is "v" ("h") Use with `fillcolor` if not "none". "tozerox" and "tozeroy" fill to x=0 and y=0 respectively. "tonextx" and "tonexty" fill between the endpoints of this trace and the endpoints of the trace before it, connecting those endpoints with straight lines (to make a stacked area graph); if there is no trace before it, they behave like "tozerox" and "tozeroy". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape. "tonext" fills the space between two traces if one completely encloses the other (eg consecutive contour lines), and behaves like "toself" if there is no trace before it. "tonext" should not be used if one trace does not enclose the other. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order.</param>
    /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
    /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
    /// <param name="HoverOn">Do the hover effects highlight individual points (markers or line points) or do they highlight filled regions? If the fill is "toself" or "tonext" and there are no markers or text, then the default is "fills", otherwise it is "points".</param>
    /// <param name="StackGaps">Only relevant when `stackgroup` is used, and only the first `stackgaps` found in the `stackgroup` will be used - including if `visible` is "legendonly" but not if it is `false`. Determines how we handle locations at which other traces in this group have data but this one does not. With "infer zero" we insert a zero at these locations. With "interpolate" we linearly interpolate between existing values, and extrapolate a constant beyond the existing values.</param>
    /// <param name="XCalendar">Sets the calendar system to use with `x` date data.</param>
    /// <param name="YCalendar">Sets the calendar system to use with `y` date data.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member Scatter
        (   
            [<Optional;DefaultParameterValue(null)>] ?Name               : string,
            [<Optional;DefaultParameterValue(null)>] ?Visible            : StyleParam.Visible,
            [<Optional;DefaultParameterValue(null)>] ?ShowLegend         : bool,
            [<Optional;DefaultParameterValue(null)>] ?LegendRank         : int,
            [<Optional;DefaultParameterValue(null)>] ?LegendGroup        : string,
            [<Optional;DefaultParameterValue(null)>] ?LegendGroupTitle   : Title,
            [<Optional;DefaultParameterValue(null)>] ?Opacity            : float,
            [<Optional;DefaultParameterValue(null)>] ?Mode               : StyleParam.Mode,         
            [<Optional;DefaultParameterValue(null)>] ?Ids                : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?X                  : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?X0                 : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?DX                 : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?Y                  : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Y0                 : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?DY                 : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?Text               : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?MultiText          : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition       : StyleParam.TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition  : seq<StyleParam.TextPosition>,
            [<Optional;DefaultParameterValue(null)>] ?TextTemplate       : string,
            [<Optional;DefaultParameterValue(null)>] ?MultiTextTemplate  : seq<string>,
            [<Optional;DefaultParameterValue(null)>] ?HoverText          : string,
            [<Optional;DefaultParameterValue(null)>] ?MultiHoverText     : seq<string>,
            [<Optional;DefaultParameterValue(null)>] ?HoverInfo          : StyleParam.HoverInfo,
            [<Optional;DefaultParameterValue(null)>] ?HoverTemplate      : string,
            [<Optional;DefaultParameterValue(null)>] ?MultiHoverTemplate : seq<string>,
            [<Optional;DefaultParameterValue(null)>] ?XHoverFormat       : string,
            [<Optional;DefaultParameterValue(null)>] ?YHoverFormat       : string,
            [<Optional;DefaultParameterValue(null)>] ?Meta               : string,
            [<Optional;DefaultParameterValue(null)>] ?CustomData         : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?XAxis              : StyleParam.LinearAxisId,
            [<Optional;DefaultParameterValue(null)>] ?YAxis              : StyleParam.LinearAxisId,
            [<Optional;DefaultParameterValue(null)>] ?Orientation        : StyleParam.Orientation,
            [<Optional;DefaultParameterValue(null)>] ?GroupNorm          : StyleParam.GroupNorm, 
            [<Optional;DefaultParameterValue(null)>] ?StackGroup         : string,
            [<Optional;DefaultParameterValue(null)>] ?XPeriod            : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?XPeriodAlignment   : StyleParam.PeriodAlignment,            
            [<Optional;DefaultParameterValue(null)>] ?XPeriod0           : #IConvertible,            
            [<Optional;DefaultParameterValue(null)>] ?YPeriod            : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?YPeriodAlignment   : StyleParam.PeriodAlignment,
            [<Optional;DefaultParameterValue(null)>] ?YPeriod0           : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?Marker             : Marker,
            [<Optional;DefaultParameterValue(null)>] ?Line               : Line,
            [<Optional;DefaultParameterValue(null)>] ?TextFont           : Font,
            [<Optional;DefaultParameterValue(null)>] ?ErrorX             : Error,
            [<Optional;DefaultParameterValue(null)>] ?ErrorY             : Error,
            [<Optional;DefaultParameterValue(null)>] ?SelectedPoints     : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Selected           : Selection,
            [<Optional;DefaultParameterValue(null)>] ?Unselected         : Selection,
            [<Optional;DefaultParameterValue(null)>] ?ClipOnAxis         : bool,
            [<Optional;DefaultParameterValue(null)>] ?ConnectGaps        : bool,
            [<Optional;DefaultParameterValue(null)>] ?Fill               : StyleParam.Fill,
            [<Optional;DefaultParameterValue(null)>] ?FillColor          : Color,
            [<Optional;DefaultParameterValue(null)>] ?HoverLabel         : Hoverlabel,
            [<Optional;DefaultParameterValue(null)>] ?HoverOn            : StyleParam.HoverOn,
            [<Optional;DefaultParameterValue(null)>] ?StackGaps          : StyleParam.StackGaps,
            [<Optional;DefaultParameterValue(null)>] ?XCalendar          : StyleParam.Calendar,
            [<Optional;DefaultParameterValue(null)>] ?YCalendar          : StyleParam.Calendar,
            [<Optional;DefaultParameterValue(null)>] ?UIRevision         : string
        ) =
            (fun (trace:('T :> Trace)) ->    
                
                Name                                |> DynObj.setValueOpt trace "name"
                Visible                             |> DynObj.setValueOptBy trace "visible" StyleParam.Visible.convert
                ShowLegend                          |> DynObj.setValueOpt trace "showlegend"
                LegendRank                          |> DynObj.setValueOpt trace "legendrank"
                LegendGroup                         |> DynObj.setValueOpt trace "legendgroup"
                LegendGroupTitle                    |> DynObj.setValueOpt trace "legendgrouptitle"
                Opacity                             |> DynObj.setValueOpt trace "opacity"
                Mode                                |> DynObj.setValueOptBy trace "mode" StyleParam.Mode.convert
                Ids                                 |> DynObj.setValueOpt trace "ids"
                X                                   |> DynObj.setValueOpt trace "x"
                X0                                  |> DynObj.setValueOpt trace "x0"
                DX                                  |> DynObj.setValueOpt trace "dx"
                Y                                   |> DynObj.setValueOpt trace "y"
                Y0                                  |> DynObj.setValueOpt trace "y0"
                DY                                  |> DynObj.setValueOpt trace "dy"
                (Text, MultiText)                   |> DynObj.setSingleOrMultiOpt trace "text"
                (TextPosition, MultiTextPosition)   |> DynObj.setSingleOrMultiOptBy trace "textposition" StyleParam.TextPosition.convert
                (TextTemplate, MultiTextTemplate)   |> DynObj.setSingleOrMultiOpt trace "texttemplate"
                (HoverText, MultiHoverText)         |> DynObj.setSingleOrMultiOpt trace "hovertext"
                HoverInfo                           |> DynObj.setValueOptBy trace "hoverinfo" StyleParam.HoverInfo.convert
                (HoverTemplate, MultiHoverTemplate) |> DynObj.setSingleOrMultiOpt trace "hovertemplate"
                XHoverFormat                        |> DynObj.setValueOpt trace "xhoverformat"
                YHoverFormat                        |> DynObj.setValueOpt trace "yhoverformat"
                Meta                                |> DynObj.setValueOpt trace "meta"
                CustomData                          |> DynObj.setValueOpt trace "customdata"
                XAxis                               |> DynObj.setValueOptBy trace "xaxis" StyleParam.LinearAxisId.convert
                YAxis                               |> DynObj.setValueOptBy trace "yaxis" StyleParam.LinearAxisId.convert
                Orientation                         |> DynObj.setValueOptBy trace "orientation" StyleParam.Orientation.convert
                GroupNorm                           |> DynObj.setValueOptBy trace "groupnorm" StyleParam.GroupNorm.convert
                StackGroup                          |> DynObj.setValueOpt trace "stackgroup"
                XPeriod                             |> DynObj.setValueOpt trace "xperiod"
                XPeriodAlignment                    |> DynObj.setValueOptBy trace "xperiodalignment" StyleParam.PeriodAlignment.convert
                XPeriod0                            |> DynObj.setValueOpt trace "xperiod0"
                YPeriod                             |> DynObj.setValueOpt trace "yperiod"
                YPeriodAlignment                    |> DynObj.setValueOptBy trace "yperiodalignment" StyleParam.PeriodAlignment.convert
                YPeriod0                            |> DynObj.setValueOpt trace "yperiod0"
                Marker                              |> DynObj.setValueOpt trace "marker"
                Line                                |> DynObj.setValueOpt trace "line"
                TextFont                            |> DynObj.setValueOpt trace "textfont"
                ErrorX                              |> DynObj.setValueOpt trace "error_x"
                ErrorY                              |> DynObj.setValueOpt trace "error_y"
                SelectedPoints                      |> DynObj.setValueOpt trace "selectedpoints"
                Selected                            |> DynObj.setValueOpt trace "selected"
                Unselected                          |> DynObj.setValueOpt trace "unselected"
                ClipOnAxis                          |> DynObj.setValueOpt trace "cliponaxis"
                ConnectGaps                         |> DynObj.setValueOpt trace "connectgaps"
                Fill                                |> DynObj.setValueOptBy trace "fill" StyleParam.Fill.convert
                FillColor                           |> DynObj.setValueOpt trace "fillcolor"
                HoverLabel                          |> DynObj.setValueOpt trace "hoverlabel"
                HoverOn                             |> DynObj.setValueOptBy trace "hoveron" StyleParam.HoverOn.convert
                StackGaps                           |> DynObj.setValueOptBy trace "stackgaps" StyleParam.StackGaps.convert
                XCalendar                           |> DynObj.setValueOptBy trace "xcalendar" StyleParam.Calendar.convert
                YCalendar                           |> DynObj.setValueOptBy trace "ycalendar" StyleParam.Calendar.convert
                UIRevision                          |> DynObj.setValueOpt trace "uirevision"

                trace
            ) 

    /// <summary>Create a function that applies the styles of a bar plot to a Trace object</summary>
    static member Bar
        (   
            [<Optional;DefaultParameterValue(null)>] ?Name              : string,
            [<Optional;DefaultParameterValue(null)>] ?Visible           : StyleParam.Visible,
            [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
            [<Optional;DefaultParameterValue(null)>] ?LegendRank        : int,
            [<Optional;DefaultParameterValue(null)>] ?LegendGroup       : string,
            [<Optional;DefaultParameterValue(null)>] ?LegendGroupTitle  : Title,
            [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
            [<Optional;DefaultParameterValue(null)>] ?Ids               : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?X                 : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?X0                : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?DX                : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?Y                 : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Y0                : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?DY                : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?Base              : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?Width             : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?MultiWidth        : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Offset            : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?MultiOffset       : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Text              : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?MultiText         : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?TextPosition      : StyleParam.TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?MultiTextPosition : seq<StyleParam.TextPosition>,
            [<Optional;DefaultParameterValue(null)>] ?TextTemplate      : string,
            [<Optional;DefaultParameterValue(null)>] ?MultiTextTemplate : seq<string>,
            [<Optional;DefaultParameterValue(null)>] ?HoverText         : string,
            [<Optional;DefaultParameterValue(null)>] ?MultiHoverText    : seq<string>,
            [<Optional;DefaultParameterValue(null)>] ?HoverInfo         : StyleParam.HoverInfo,
            [<Optional;DefaultParameterValue(null)>] ?HoverTemplate     : string,
            [<Optional;DefaultParameterValue(null)>] ?MultiHoverTemplate: seq<string>,
            [<Optional;DefaultParameterValue(null)>] ?XHoverFormat      : string,
            [<Optional;DefaultParameterValue(null)>] ?YHoverFormat      : string,
            [<Optional;DefaultParameterValue(null)>] ?Meta              : string,
            [<Optional;DefaultParameterValue(null)>] ?CustomData        : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?XAxis             : StyleParam.LinearAxisId,
            [<Optional;DefaultParameterValue(null)>] ?YAxis             : StyleParam.LinearAxisId,
            [<Optional;DefaultParameterValue(null)>] ?Orientation       : StyleParam.Orientation,
            [<Optional;DefaultParameterValue(null)>] ?AlignmentGroup    : string,
            [<Optional;DefaultParameterValue(null)>] ?OffsetGroup       : string,
            [<Optional;DefaultParameterValue(null)>] ?XPeriod           : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?XPeriodAlignment  : StyleParam.PeriodAlignment,            
            [<Optional;DefaultParameterValue(null)>] ?XPeriod0          : #IConvertible,            
            [<Optional;DefaultParameterValue(null)>] ?YPeriod           : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?YPeriodAlignment  : StyleParam.PeriodAlignment,
            [<Optional;DefaultParameterValue(null)>] ?YPeriod0          : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?Marker            : Marker,
            [<Optional;DefaultParameterValue(null)>] ?TextAngle         : float,
            [<Optional;DefaultParameterValue(null)>] ?TextFont          : Font,
            [<Optional;DefaultParameterValue(null)>] ?ErrorX            : Error,
            [<Optional;DefaultParameterValue(null)>] ?ErrorY            : Error,
            [<Optional;DefaultParameterValue(null)>] ?SelectedPoints    : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Selected          : Selection,
            [<Optional;DefaultParameterValue(null)>] ?Unselected        : Selection,
            [<Optional;DefaultParameterValue(null)>] ?ClipOnAxis        : bool,
            [<Optional;DefaultParameterValue(null)>] ?Constraintext     : StyleParam.ConstrainText,
            [<Optional;DefaultParameterValue(null)>] ?HoverLabel        : Hoverlabel,
            [<Optional;DefaultParameterValue(null)>] ?InsideTextAnchor  : StyleParam.InsideTextAnchor,
            [<Optional;DefaultParameterValue(null)>] ?InsideTextFont    : Font,
            [<Optional;DefaultParameterValue(null)>] ?OutsideTextFont   : Font,
            [<Optional;DefaultParameterValue(null)>] ?XCalendar         : StyleParam.Calendar,
            [<Optional;DefaultParameterValue(null)>] ?YCalendar         : StyleParam.Calendar,
            [<Optional;DefaultParameterValue(null)>] ?UIRevision        : string

        ) =
            (fun (bar:('T :> Trace)) ->    
               
                Name                                |> DynObj.setValueOpt bar "name"
                Visible                             |> DynObj.setValueOptBy bar "visible" StyleParam.Visible.convert
                ShowLegend                          |> DynObj.setValueOpt bar "showlegend"
                LegendRank                          |> DynObj.setValueOpt bar "legendrank"
                LegendGroup                         |> DynObj.setValueOpt bar "legendgroup"
                LegendGroupTitle                    |> DynObj.setValueOpt bar "legendgrouptitle"
                Opacity                             |> DynObj.setValueOpt bar "opacity"
                Ids                                 |> DynObj.setValueOpt bar "ids"
                X                                   |> DynObj.setValueOpt bar "x"
                X0                                  |> DynObj.setValueOpt bar "x0"
                DX                                  |> DynObj.setValueOpt bar "dx"
                Y                                   |> DynObj.setValueOpt bar "y"
                Y0                                  |> DynObj.setValueOpt bar "y0"
                DY                                  |> DynObj.setValueOpt bar "dy"
                Base                                |> DynObj.setValueOpt bar "base"
                (Width, MultiWidth)                 |> DynObj.setSingleOrMultiOpt bar "width"
                (Offset, MultiOffset)               |> DynObj.setSingleOrMultiOpt bar "offset"
                (Text, MultiText)                   |> DynObj.setSingleOrMultiOpt bar "text"
                (TextPosition, MultiTextPosition)   |> DynObj.setSingleOrMultiOptBy bar "textposition" StyleParam.TextPosition.convert
                (TextTemplate, MultiTextTemplate)   |> DynObj.setSingleOrMultiOpt bar "texttemplate"
                (HoverText, MultiHoverText)         |> DynObj.setSingleOrMultiOpt bar "hovertext"
                HoverInfo                           |> DynObj.setValueOptBy bar "hoverinfo"  StyleParam.HoverInfo.convert
                (HoverTemplate, MultiHoverTemplate) |> DynObj.setSingleOrMultiOpt bar "hovertemplate"
                XHoverFormat                        |> DynObj.setValueOpt bar "xhoverformat"
                YHoverFormat                        |> DynObj.setValueOpt bar "yhoverformat"
                Meta                                |> DynObj.setValueOpt bar "meta"
                CustomData                          |> DynObj.setValueOpt bar "customdata"
                XAxis                               |> DynObj.setValueOptBy bar "xaxis" StyleParam.LinearAxisId.convert
                YAxis                               |> DynObj.setValueOptBy bar "yaxis"  StyleParam.LinearAxisId.convert
                Orientation                         |> DynObj.setValueOptBy bar "orientation" StyleParam.Orientation.convert
                AlignmentGroup                      |> DynObj.setValueOpt bar "alignmentgroup"
                OffsetGroup                         |> DynObj.setValueOpt bar "offsetgroup"
                XPeriod                             |> DynObj.setValueOpt bar "xperiod"
                XPeriodAlignment                    |> DynObj.setValueOptBy bar "xperiodalignment" StyleParam.PeriodAlignment.convert
                XPeriod0                            |> DynObj.setValueOpt bar "xperiod0"
                YPeriod                             |> DynObj.setValueOpt bar "yperiod"
                YPeriodAlignment                    |> DynObj.setValueOptBy bar "yperiodalignment" StyleParam.PeriodAlignment.convert
                YPeriod0                            |> DynObj.setValueOpt bar "yperiod0"
                Marker                              |> DynObj.setValueOpt bar "marker"
                TextAngle                           |> DynObj.setValueOpt bar "textangle"
                TextFont                            |> DynObj.setValueOpt bar "textfont"
                ErrorX                              |> DynObj.setValueOpt bar "errorx"
                ErrorY                              |> DynObj.setValueOpt bar "errory"
                SelectedPoints                      |> DynObj.setValueOpt bar "selectedpoints"
                Selected                            |> DynObj.setValueOpt bar "selected"
                Unselected                          |> DynObj.setValueOpt bar "unselected"
                ClipOnAxis                          |> DynObj.setValueOpt bar "cliponaxis"
                Constraintext                       |> DynObj.setValueOptBy bar "constraintext" StyleParam.ConstrainText.convert
                HoverLabel                          |> DynObj.setValueOpt bar "hoverlabel"
                InsideTextAnchor                    |> DynObj.setValueOptBy bar "insidetextanchor" StyleParam.InsideTextAnchor.convert
                InsideTextFont                      |> DynObj.setValueOpt bar "insidetextfont"
                OutsideTextFont                     |> DynObj.setValueOpt bar "outsidetextfont"
                XCalendar                           |> DynObj.setValueOptBy bar "xcalendar" StyleParam.Calendar.convert
                YCalendar                           |> DynObj.setValueOptBy bar "ycalendar" StyleParam.Calendar.convert
                UIRevision                          |> DynObj.setValueOpt bar "uirevision"

                bar

            ) 
    
    static member Funnel
        (
            x               : seq<#IConvertible>,
            y               : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?x0,
            [<Optional;DefaultParameterValue(null)>] ?dX             : float,
            [<Optional;DefaultParameterValue(null)>] ?y0,
            [<Optional;DefaultParameterValue(null)>] ?dY             : float,
            [<Optional;DefaultParameterValue(null)>] ?Width          : float,
            [<Optional;DefaultParameterValue(null)>] ?Offset         : float,
            [<Optional;DefaultParameterValue(null)>] ?Orientation    : StyleParam.Orientation,
            [<Optional;DefaultParameterValue(null)>] ?Alignmentgroup : string,
            [<Optional;DefaultParameterValue(null)>] ?Offsetgroup    : string,
            [<Optional;DefaultParameterValue(null)>] ?Cliponaxis     : bool,
            [<Optional;DefaultParameterValue(null)>] ?Connector      : FunnelConnector,
            [<Optional;DefaultParameterValue(null)>] ?Insidetextfont : Font,
            [<Optional;DefaultParameterValue(null)>] ?Outsidetextfont: Font
        ) = 
            (fun (trace:('T :> Trace)) -> 
                
                x               |> DynObj.setValue      trace "x"
                y               |> DynObj.setValue      trace "y"
                x0              |> DynObj.setValueOpt   trace "x0"
                dX              |> DynObj.setValueOpt   trace "dx"
                y0              |> DynObj.setValueOpt   trace "y0"
                dY              |> DynObj.setValueOpt   trace "dy"
                Width           |> DynObj.setValueOpt   trace "width"
                Offset          |> DynObj.setValueOpt   trace "offset"
                Orientation     |> DynObj.setValueOptBy trace "orientation" StyleParam.Orientation.convert
                Alignmentgroup  |> DynObj.setValueOpt   trace "alignmentgroup"
                Offsetgroup     |> DynObj.setValueOpt   trace "offsetgroup"
                Cliponaxis      |> DynObj.setValueOpt   trace "cliponaxis"
                Connector       |> DynObj.setValueOpt   trace "connector"
                Insidetextfont  |> DynObj.setValueOpt   trace "insidetextfont"
                Outsidetextfont |> DynObj.setValueOpt   trace "outsidetextfont"

                trace

            )
    
        
    /// Applies the styles of candlestick plot to TraceObjects 
    ///
    /// Parameters:
    ///
    /// x               : Sets the x coordinates.
    ///
    /// y               : Sets the y coordinates.
    ///
    /// Base            : Sets where the bar base is drawn (in position axis units).
    ///
    /// Width           : Sets the bar width (in position axis units).
    ///
    /// Measure         : An array containing types of values. By default the values are considered as 'relative'. However; it is possible to use 'total' to compute the sums. Also 'absolute' could be applied to reset the computed total or to declare an initial value where needed.
    ///
    /// Orientation     : Sets the orientation of the bars. With "v" ("h"), the value of the each bar spans along the vertical (horizontal).
    ///
    /// Connector       : Sets the styling of the connector lines
    ///
    /// AlignmentGroup  : Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.
    ///
    /// OffsetGroup     : Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.
    ///
    /// Offset          : Shifts the position where the bar is drawn (in position axis units). In "group" barmode, traces that set "offset" will be excluded and drawn in "overlay" mode instead.
    static member Waterfall 
        (
            x               : #IConvertible seq,
            y               : #IConvertible seq,
            [<Optional;DefaultParameterValue(null)>] ?Base           : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?Width          : float,
            [<Optional;DefaultParameterValue(null)>] ?Measure        : StyleParam.WaterfallMeasure seq,
            [<Optional;DefaultParameterValue(null)>] ?Orientation    : StyleParam.Orientation,
            [<Optional;DefaultParameterValue(null)>] ?Connector      : WaterfallConnector,
            [<Optional;DefaultParameterValue(null)>] ?AlignmentGroup : string,
            [<Optional;DefaultParameterValue(null)>] ?OffsetGroup    : string,
            [<Optional;DefaultParameterValue(null)>] ?Offset             

        ) =
            (fun (trace:('T :> Trace)) ->
                    
                x               |> DynObj.setValue      trace "x"
                y               |> DynObj.setValue      trace "y"
                Base            |> DynObj.setValueOpt   trace "base"
                Width           |> DynObj.setValueOpt   trace "width"
                Measure         |> DynObj.setValueOptBy trace "measure" (Seq.map StyleParam.WaterfallMeasure.convert)
                Orientation     |> DynObj.setValueOptBy trace "orientation" StyleParam.Orientation.convert
                AlignmentGroup  |> DynObj.setValueOpt   trace "alignmentgroup"
                Connector       |> DynObj.setValueOpt   trace "connector"
                OffsetGroup     |> DynObj.setValueOpt   trace "offsetgroup"
                Offset          |> DynObj.setValueOpt   trace "offset"
                    
                trace
            )


    // Applies the styles of histogram to TraceObjects
    static member Histogram
        (            
            [<Optional;DefaultParameterValue(null)>] ?X : seq<#IConvertible>       ,
            [<Optional;DefaultParameterValue(null)>] ?Y : seq<#IConvertible>       ,            
            [<Optional;DefaultParameterValue(null)>] ?Text : seq<string>           ,   
            [<Optional;DefaultParameterValue(null)>] ?xAxis                        ,
            [<Optional;DefaultParameterValue(null)>] ?yAxis                        ,
            [<Optional;DefaultParameterValue(null)>] ?Xsrc                         ,
            [<Optional;DefaultParameterValue(null)>] ?Ysrc                         ,
            [<Optional;DefaultParameterValue(null)>] ?Orientation                  , 
            [<Optional;DefaultParameterValue(null)>] ?HistFunc                     ,
            [<Optional;DefaultParameterValue(null)>] ?HistNorm                     ,
            [<Optional;DefaultParameterValue(null)>] ?Cumulative : Cumulative      ,
            [<Optional;DefaultParameterValue(null)>] ?Autobinx    : bool           ,
            [<Optional;DefaultParameterValue(null)>] ?nBinsx      : int            ,
            [<Optional;DefaultParameterValue(null)>] ?xBins       : Bins           ,
            [<Optional;DefaultParameterValue(null)>] ?Autobiny    : bool           ,
            [<Optional;DefaultParameterValue(null)>] ?nBinsy      : int            ,
            [<Optional;DefaultParameterValue(null)>] ?yBins       : Bins           ,
            [<Optional;DefaultParameterValue(null)>] ?Marker      : Marker         ,
            [<Optional;DefaultParameterValue(null)>] ?xError       : Error         ,
            [<Optional;DefaultParameterValue(null)>] ?yError       : Error

        ) =
            (fun (histogram:('T :> Trace)) ->
        
                X              |> DynObj.setValueOpt histogram "x"               
                Y              |> DynObj.setValueOpt histogram "y"                          
                Text           |> DynObj.setValueOpt histogram "text"
                xAxis          |> DynObj.setValueOpt histogram "xaxis"         
                yAxis          |> DynObj.setValueOpt histogram "yaxis"                
                Xsrc           |> DynObj.setValueOpt histogram "xsrc"       
                Ysrc           |> DynObj.setValueOpt histogram "ysrc"  

                Orientation    |> DynObj.setValueOptBy histogram "orientation" StyleParam.Orientation.convert
                HistFunc       |> DynObj.setValueOptBy histogram "histfunc"    StyleParam.HistFunc.convert
                HistNorm       |> DynObj.setValueOptBy histogram "histnorm"    StyleParam.HistNorm.convert
                Cumulative     |> DynObj.setValueOpt histogram "cumulative"

                Autobinx       |> DynObj.setValueOpt histogram "autobinx"
                nBinsx         |> DynObj.setValueOpt histogram "nbinsx"
                xBins          |> DynObj.setValueOpt histogram "xbins"
                Autobiny       |> DynObj.setValueOpt histogram "autobiny"
                nBinsy         |> DynObj.setValueOpt histogram "nbinsy"
                yBins          |> DynObj.setValueOpt histogram "ybins"

                // Update                
                Marker         |> DynObj.setValueOpt histogram "marker"
                xError         |> DynObj.setValueOpt histogram "error_x"
                yError         |> DynObj.setValueOpt histogram "error_y"
                    
                // out ->
                histogram
            ) 
    
    // Applies the styles of box plot plot to TraceObjects 
    static member BoxPlot
        (            
            [<Optional;DefaultParameterValue(null)>] ?Y,           
            [<Optional;DefaultParameterValue(null)>] ?X,           
            [<Optional;DefaultParameterValue(null)>] ?X0,          
            [<Optional;DefaultParameterValue(null)>] ?Y0,          
            [<Optional;DefaultParameterValue(null)>] ?Whiskerwidth,
            [<Optional;DefaultParameterValue(null)>] ?Boxpoints,   
            [<Optional;DefaultParameterValue(null)>] ?Boxmean,
            [<Optional;DefaultParameterValue(null)>] ?Jitter,      
            [<Optional;DefaultParameterValue(null)>] ?Pointpos,    
            [<Optional;DefaultParameterValue(null)>] ?Orientation, 
            [<Optional;DefaultParameterValue(null)>] ?Fillcolor : Color,                   
            [<Optional;DefaultParameterValue(null)>] ?Marker:Marker,
            [<Optional;DefaultParameterValue(null)>] ?Line:Line,
            [<Optional;DefaultParameterValue(null)>] ?Alignmentgroup,
            [<Optional;DefaultParameterValue(null)>] ?Offsetgroup,
            [<Optional;DefaultParameterValue(null)>] ?Notched:bool,
            [<Optional;DefaultParameterValue(null)>] ?NotchWidth:float,
            [<Optional;DefaultParameterValue(null)>] ?QuartileMethod:StyleParam.QuartileMethod,
            [<Optional;DefaultParameterValue(null)>] ?xAxis,       
            [<Optional;DefaultParameterValue(null)>] ?yAxis,       
            [<Optional;DefaultParameterValue(null)>] ?Ysrc,        
            [<Optional;DefaultParameterValue(null)>] ?Xsrc        

        ) =
            (fun (boxPlot:('T :> Trace)) ->

                Y               |> DynObj.setValueOpt boxPlot "y"           
                X               |> DynObj.setValueOpt boxPlot "x"           
                X0              |> DynObj.setValueOpt boxPlot "x0"          
                Y0              |> DynObj.setValueOpt boxPlot "y0"          
                Whiskerwidth    |> DynObj.setValueOpt boxPlot "whiskerwidth"
                Boxpoints       |> DynObj.setValueOptBy boxPlot "boxpoints"  StyleParam.Boxpoints.convert  
                Boxmean         |> DynObj.setValueOptBy boxPlot "boxmean"    StyleParam.BoxMean.convert    
                Jitter          |> DynObj.setValueOpt boxPlot "jitter"      
                Pointpos        |> DynObj.setValueOpt boxPlot "pointpos"    
                Orientation     |> DynObj.setValueOptBy boxPlot "orientation" StyleParam.Orientation.convert
                Fillcolor       |> DynObj.setValueOpt boxPlot "fillcolor"   
                Marker          |> DynObj.setValueOpt boxPlot "marker"   
                Line            |> DynObj.setValueOpt boxPlot "line"   
                Alignmentgroup  |> DynObj.setValueOpt boxPlot "alignmentgroup"   
                Offsetgroup     |> DynObj.setValueOpt boxPlot "offsetgroup"                     
                Notched         |> DynObj.setValueOpt boxPlot "notched"   
                NotchWidth      |> DynObj.setValueOpt boxPlot "notchwidth"   
                QuartileMethod  |> DynObj.setValueOptBy boxPlot "quartilemethod" StyleParam.QuartileMethod.convert

                xAxis           |> DynObj.setValueOpt boxPlot "xaxis"       
                yAxis           |> DynObj.setValueOpt boxPlot "yaxis"       
                Ysrc            |> DynObj.setValueOpt boxPlot "ysrc"        
                Xsrc            |> DynObj.setValueOpt boxPlot "xsrc"        
                    
                // out ->
                boxPlot
            ) 


    // Applies the styles of violin plot plot to TraceObjects 
    static member Violin
        (            
            [<Optional;DefaultParameterValue(null)>] ?Y,           
            [<Optional;DefaultParameterValue(null)>] ?X,           
            [<Optional;DefaultParameterValue(null)>] ?X0,          
            [<Optional;DefaultParameterValue(null)>] ?Y0,          
            [<Optional;DefaultParameterValue(null)>] ?Width,
            [<Optional;DefaultParameterValue(null)>] ?Marker:Marker,
            [<Optional;DefaultParameterValue(null)>] ?Line:Line,
            [<Optional;DefaultParameterValue(null)>] ?Alignmentgroup,
            [<Optional;DefaultParameterValue(null)>] ?Offsetgroup,
            [<Optional;DefaultParameterValue(null)>] ?Box:Box,
            [<Optional;DefaultParameterValue(null)>] ?Bandwidth,
            [<Optional;DefaultParameterValue(null)>] ?Meanline:Meanline,
            [<Optional;DefaultParameterValue(null)>] ?Scalegroup,
            [<Optional;DefaultParameterValue(null)>] ?Scalemode,
            [<Optional;DefaultParameterValue(null)>] ?Side,
            [<Optional;DefaultParameterValue(null)>] ?Span,
            [<Optional;DefaultParameterValue(null)>] ?SpanMode,
            [<Optional;DefaultParameterValue(null)>] ?Uirevision,
            [<Optional;DefaultParameterValue(null)>] ?Points,     
            [<Optional;DefaultParameterValue(null)>] ?Jitter,      
            [<Optional;DefaultParameterValue(null)>] ?Pointpos,    
            [<Optional;DefaultParameterValue(null)>] ?Orientation, 
            [<Optional;DefaultParameterValue(null)>] ?Fillcolor: Color,   
            [<Optional;DefaultParameterValue(null)>] ?xAxis,       
            [<Optional;DefaultParameterValue(null)>] ?yAxis,       
            [<Optional;DefaultParameterValue(null)>] ?Ysrc,        
            [<Optional;DefaultParameterValue(null)>] ?Xsrc        

        ) =
            (fun (boxPlot:('T :> Trace)) ->

                Y                |> DynObj.setValueOpt boxPlot "y"           
                X                |> DynObj.setValueOpt boxPlot "x"           
                X0               |> DynObj.setValueOpt boxPlot "x0"          
                Y0               |> DynObj.setValueOpt boxPlot "y0"          
                Points           |> DynObj.setValueOptBy boxPlot "points"  StyleParam.Jitterpoints.convert      
                Jitter           |> DynObj.setValueOpt boxPlot "jitter"      
                Pointpos         |> DynObj.setValueOpt boxPlot "pointpos"    
                Orientation      |> DynObj.setValueOptBy boxPlot "orientation" StyleParam.Orientation.convert
                Fillcolor        |> DynObj.setValueOpt boxPlot "fillcolor"   
                                     
                Width            |> DynObj.setValueOpt boxPlot "width"  
                Marker           |> DynObj.setValueOpt boxPlot "marker"   
                Line             |> DynObj.setValueOpt boxPlot "line" 
                Alignmentgroup   |> DynObj.setValueOpt boxPlot "alignmentgroup"   
                Offsetgroup      |> DynObj.setValueOpt boxPlot "offsetgroup"  
                                    
                Box              |> DynObj.setValueOpt boxPlot "box"  
                Bandwidth        |> DynObj.setValueOpt boxPlot "bandwidth"  
                Meanline         |> DynObj.setValueOpt boxPlot "meanline"  
                Scalegroup       |> DynObj.setValueOpt boxPlot "scalegroup"  
                Scalemode        |> DynObj.setValueOpt boxPlot "scalemode"  
                Side             |> DynObj.setValueOpt boxPlot "side"  
                Span             |> DynObj.setValueOpt boxPlot "span"  
                SpanMode         |> DynObj.setValueOpt boxPlot "spanmode"  
                Uirevision       |> DynObj.setValueOpt boxPlot "uirevision"  

                    
                xAxis        |> DynObj.setValueOpt boxPlot "xaxis"       
                yAxis        |> DynObj.setValueOpt boxPlot "yaxis"       
                Ysrc         |> DynObj.setValueOpt boxPlot "ysrc"        
                Xsrc         |> DynObj.setValueOpt boxPlot "xsrc"        
                    
                // out ->
                boxPlot
            ) 

            
    static member Histogram2d
        (            
            [<Optional;DefaultParameterValue(null)>] ?X : seq<#IConvertible>       ,
            [<Optional;DefaultParameterValue(null)>] ?Y : seq<#IConvertible>       ,            
            [<Optional;DefaultParameterValue(null)>] ?Z : seq<#seq<#IConvertible>> ,                
            [<Optional;DefaultParameterValue(null)>] ?X0                           ,
            [<Optional;DefaultParameterValue(null)>] ?dX                           ,
            [<Optional;DefaultParameterValue(null)>] ?Y0                           ,
            [<Optional;DefaultParameterValue(null)>] ?dY                           ,
            [<Optional;DefaultParameterValue(null)>] ?xType                        ,
            [<Optional;DefaultParameterValue(null)>] ?yType                        ,
            [<Optional;DefaultParameterValue(null)>] ?xAxis                        ,
            [<Optional;DefaultParameterValue(null)>] ?yAxis                        ,
            [<Optional;DefaultParameterValue(null)>] ?Zsrc                         ,
            [<Optional;DefaultParameterValue(null)>] ?Xsrc                         ,
            [<Optional;DefaultParameterValue(null)>] ?Ysrc                         ,
            [<Optional;DefaultParameterValue(null)>] ?Marker      : Marker         , 
            [<Optional;DefaultParameterValue(null)>] ?Orientation                  , 
            [<Optional;DefaultParameterValue(null)>] ?HistFunc                     ,
            [<Optional;DefaultParameterValue(null)>] ?HistNorm                     ,
            [<Optional;DefaultParameterValue(null)>] ?Autobinx    : bool           ,
            [<Optional;DefaultParameterValue(null)>] ?nBinsx      : int            ,
            [<Optional;DefaultParameterValue(null)>] ?xBins       : Bins           ,
            [<Optional;DefaultParameterValue(null)>] ?Autobiny    : bool           ,
            [<Optional;DefaultParameterValue(null)>] ?nBinsy      : int            ,
            [<Optional;DefaultParameterValue(null)>] ?yBins       : Bins           ,
            [<Optional;DefaultParameterValue(null)>] ?Xgap           ,         
            [<Optional;DefaultParameterValue(null)>] ?Ygap           ,
            [<Optional;DefaultParameterValue(null)>] ?Transpose      ,
            [<Optional;DefaultParameterValue(null)>] ?zAuto          ,
            [<Optional;DefaultParameterValue(null)>] ?zMin           ,
            [<Optional;DefaultParameterValue(null)>] ?zMax           ,
            [<Optional;DefaultParameterValue(null)>] ?Colorscale     ,
            [<Optional;DefaultParameterValue(null)>] ?Autocolorscale ,
            [<Optional;DefaultParameterValue(null)>] ?Reversescale   ,
            [<Optional;DefaultParameterValue(null)>] ?Showscale      ,
            [<Optional;DefaultParameterValue(null)>] ?zSmooth        ,
            [<Optional;DefaultParameterValue(null)>] ?ColorBar      

        ) =
            (fun (histogram2d:('T :> Trace)) ->

                Z              |> DynObj.setValueOpt histogram2d "z"         
                X              |> DynObj.setValueOpt histogram2d "x"               
                Y              |> DynObj.setValueOpt histogram2d "y"
                X0             |> DynObj.setValueOpt histogram2d "x0"             
                dX             |> DynObj.setValueOpt histogram2d "dx"             
                Y0             |> DynObj.setValueOpt histogram2d "y0"            
                dY             |> DynObj.setValueOpt histogram2d "dy"            
                xType          |> DynObj.setValueOpt histogram2d "xtype"         
                yType          |> DynObj.setValueOpt histogram2d "ytype"                          
                xAxis          |> DynObj.setValueOpt histogram2d "xaxis"         
                yAxis          |> DynObj.setValueOpt histogram2d "yaxis"         
                Zsrc           |> DynObj.setValueOpt histogram2d "zsrc"       
                Xsrc           |> DynObj.setValueOpt histogram2d "xsrc"       
                Ysrc           |> DynObj.setValueOpt histogram2d "ysrc"  

                Orientation    |> DynObj.setValueOptBy histogram2d "orientation" StyleParam.Orientation.convert
                //Connectgaps    |> DynObj.setValueOptBy histogram2d "connectgaps" StyleParam.Orientation.convert
                HistFunc       |> DynObj.setValueOptBy histogram2d "histfunc   " StyleParam.HistFunc.convert
                HistNorm       |> DynObj.setValueOptBy histogram2d "histnorm   " StyleParam.HistNorm.convert
                Autobinx       |> DynObj.setValueOpt histogram2d "autobinx"
                nBinsx         |> DynObj.setValueOpt histogram2d "nbinsx"
                xBins          |> DynObj.setValueOpt histogram2d "xbins"
                Autobiny       |> DynObj.setValueOpt histogram2d "autobiny"
                nBinsy         |> DynObj.setValueOpt histogram2d "nbinsy"
                yBins          |> DynObj.setValueOpt histogram2d "ybins"
                    
                Xgap           |> DynObj.setValueOpt histogram2d   "xgap"       
                Ygap           |> DynObj.setValueOpt histogram2d   "ygap"  
                Transpose      |> DynObj.setValueOpt histogram2d   "transpose" 
                zAuto          |> DynObj.setValueOpt histogram2d   "zauto"     
                zMin           |> DynObj.setValueOpt histogram2d   "zmin"      
                zMax           |> DynObj.setValueOpt histogram2d   "zmax"      
                Colorscale     |> DynObj.setValueOptBy histogram2d "colorscale" StyleParam.Colorscale.convert 
                Autocolorscale |> DynObj.setValueOpt histogram2d   "autocolorscale"
                Reversescale   |> DynObj.setValueOpt histogram2d   "reversescale"  
                Showscale      |> DynObj.setValueOpt histogram2d   "showscale"     
                zSmooth        |> DynObj.setValueOptBy histogram2d "zsmooth" StyleParam.SmoothAlg.convert   
                ColorBar       |> DynObj.setValueOpt histogram2d   "colorbar"    

                // Update                
                Marker       |> DynObj.setValueOpt histogram2d "marker"  
                    
                // out ->
                histogram2d
            ) 


    static member Histogram2dContour
        (            
            [<Optional;DefaultParameterValue(null)>] ?X : seq<#IConvertible>       ,
            [<Optional;DefaultParameterValue(null)>] ?Y : seq<#IConvertible>       ,            
            [<Optional;DefaultParameterValue(null)>] ?Z : seq<#seq<#IConvertible>> ,                
            [<Optional;DefaultParameterValue(null)>] ?X0                           ,
            [<Optional;DefaultParameterValue(null)>] ?dX                           ,
            [<Optional;DefaultParameterValue(null)>] ?Y0                           ,
            [<Optional;DefaultParameterValue(null)>] ?dY                           ,
            [<Optional;DefaultParameterValue(null)>] ?xType                        ,
            [<Optional;DefaultParameterValue(null)>] ?yType                        ,
            [<Optional;DefaultParameterValue(null)>] ?xAxis                        ,
            [<Optional;DefaultParameterValue(null)>] ?yAxis                        ,
            [<Optional;DefaultParameterValue(null)>] ?Zsrc                         ,
            [<Optional;DefaultParameterValue(null)>] ?Xsrc                         ,
            [<Optional;DefaultParameterValue(null)>] ?Ysrc                         ,
            [<Optional;DefaultParameterValue(null)>] ?Marker      : Marker         , 
            [<Optional;DefaultParameterValue(null)>] ?Orientation                  , 
            [<Optional;DefaultParameterValue(null)>] ?HistFunc                     ,
            [<Optional;DefaultParameterValue(null)>] ?HistNorm                     ,
            [<Optional;DefaultParameterValue(null)>] ?Autobinx    : bool           ,
            [<Optional;DefaultParameterValue(null)>] ?nBinsx      : int            ,
            [<Optional;DefaultParameterValue(null)>] ?xBins       : Bins           ,
            [<Optional;DefaultParameterValue(null)>] ?Autobiny    : bool           ,
            [<Optional;DefaultParameterValue(null)>] ?nBinsy      : int            ,
            [<Optional;DefaultParameterValue(null)>] ?yBins       : Bins           ,
            [<Optional;DefaultParameterValue(null)>] ?nContours   : int            ,
            [<Optional;DefaultParameterValue(null)>] ?Contours    : Contour        ,
            [<Optional;DefaultParameterValue(null)>] ?Line        : Line           ,
            [<Optional;DefaultParameterValue(null)>] ?Xgap           ,         
            [<Optional;DefaultParameterValue(null)>] ?Ygap           ,
            [<Optional;DefaultParameterValue(null)>] ?Transpose      ,
            [<Optional;DefaultParameterValue(null)>] ?zAuto          ,
            [<Optional;DefaultParameterValue(null)>] ?zMin           ,
            [<Optional;DefaultParameterValue(null)>] ?zMax           ,
            [<Optional;DefaultParameterValue(null)>] ?Colorscale     ,
            [<Optional;DefaultParameterValue(null)>] ?Autocolorscale ,
            [<Optional;DefaultParameterValue(null)>] ?Reversescale   ,
            [<Optional;DefaultParameterValue(null)>] ?Showscale      ,
            [<Optional;DefaultParameterValue(null)>] ?zSmooth        ,
            [<Optional;DefaultParameterValue(null)>] ?ColorBar      
        ) =
            (fun (histogram2dContour:('T :> Trace)) ->

                Z              |> DynObj.setValueOpt histogram2dContour "z"         
                X              |> DynObj.setValueOpt histogram2dContour "x"               
                Y              |> DynObj.setValueOpt histogram2dContour "y"
                X0             |> DynObj.setValueOpt histogram2dContour "x0"             
                dX             |> DynObj.setValueOpt histogram2dContour "dx"             
                Y0             |> DynObj.setValueOpt histogram2dContour "y0"            
                dY             |> DynObj.setValueOpt histogram2dContour "dy"            
                xType          |> DynObj.setValueOpt histogram2dContour "xtype"         
                yType          |> DynObj.setValueOpt histogram2dContour "ytype"                          
                xAxis          |> DynObj.setValueOpt histogram2dContour "xaxis"         
                yAxis          |> DynObj.setValueOpt histogram2dContour "yaxis"         
                Zsrc           |> DynObj.setValueOpt histogram2dContour "zsrc"       
                Xsrc           |> DynObj.setValueOpt histogram2dContour "xsrc"       
                Ysrc           |> DynObj.setValueOpt histogram2dContour "ysrc"  

                Orientation    |> DynObj.setValueOptBy histogram2dContour "orientation" StyleParam.Orientation.convert
                //Connectgaps    |> DynObj.setValueOptBy histogram2dContour< "connectgaps" StyleParam.Orientation.convert
                HistFunc       |> DynObj.setValueOptBy histogram2dContour "histfunc   " StyleParam.HistFunc.convert
                HistNorm       |> DynObj.setValueOptBy histogram2dContour "histnorm   " StyleParam.HistNorm.convert
                Autobinx       |> DynObj.setValueOpt histogram2dContour "autobinx"
                nBinsx         |> DynObj.setValueOpt histogram2dContour "nbinsx"
                xBins          |> DynObj.setValueOpt histogram2dContour "xbins"
                Autobiny       |> DynObj.setValueOpt histogram2dContour "autobiny"
                nBinsy         |> DynObj.setValueOpt histogram2dContour "nbinsy"
                yBins          |> DynObj.setValueOpt histogram2dContour "ybins"

                nContours      |> DynObj.setValueOpt histogram2dContour   "ncontours"       
                Contours       |> DynObj.setValueOpt histogram2dContour   "contours"  
                Line           |> DynObj.setValueOpt histogram2dContour   "line"                     
                Xgap           |> DynObj.setValueOpt histogram2dContour   "xgap"       
                Ygap           |> DynObj.setValueOpt histogram2dContour   "ygap"  
                Transpose      |> DynObj.setValueOpt histogram2dContour   "transpose" 
                zAuto          |> DynObj.setValueOpt histogram2dContour   "zauto"     
                zMin           |> DynObj.setValueOpt histogram2dContour   "zmin"      
                zMax           |> DynObj.setValueOpt histogram2dContour   "zmax"      
                Colorscale     |> DynObj.setValueOptBy histogram2dContour "colorscale" StyleParam.Colorscale.convert 
                Autocolorscale |> DynObj.setValueOpt histogram2dContour   "autocolorscale"
                Reversescale   |> DynObj.setValueOpt histogram2dContour   "reversescale"  
                Showscale      |> DynObj.setValueOpt histogram2dContour   "showscale"     
                zSmooth        |> DynObj.setValueOptBy histogram2dContour "zsmooth" StyleParam.SmoothAlg.convert   
                ColorBar       |> DynObj.setValueOpt histogram2dContour   "colorbar"    

                // Update                
                Marker       |> DynObj.setValueOpt histogram2dContour "marker"  
                    
                // out ->
                histogram2dContour
            ) 


    // Applies the styles of heatmap to TraceObjects 
    static member Heatmap
        (                
            [<Optional;DefaultParameterValue(null)>] ?Z : seq<#seq<#IConvertible>>,
            [<Optional;DefaultParameterValue(null)>] ?X : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Y : seq<#IConvertible>,            
            [<Optional;DefaultParameterValue(null)>] ?X0             ,
            [<Optional;DefaultParameterValue(null)>] ?dX             ,
            [<Optional;DefaultParameterValue(null)>] ?Y0             ,
            [<Optional;DefaultParameterValue(null)>] ?dY             ,
            [<Optional;DefaultParameterValue(null)>] ?xType          ,
            [<Optional;DefaultParameterValue(null)>] ?yType          ,
            [<Optional;DefaultParameterValue(null)>] ?xAxis          ,
            [<Optional;DefaultParameterValue(null)>] ?yAxis          ,
            [<Optional;DefaultParameterValue(null)>] ?Zsrc           ,
            [<Optional;DefaultParameterValue(null)>] ?Xsrc           ,
            [<Optional;DefaultParameterValue(null)>] ?Ysrc           ,
            [<Optional;DefaultParameterValue(null)>] ?Xgap           ,         
            [<Optional;DefaultParameterValue(null)>] ?Ygap           ,
            [<Optional;DefaultParameterValue(null)>] ?Transpose      ,
            [<Optional;DefaultParameterValue(null)>] ?zAuto          ,
            [<Optional;DefaultParameterValue(null)>] ?zMin           ,
            [<Optional;DefaultParameterValue(null)>] ?zMax           ,
            [<Optional;DefaultParameterValue(null)>] ?Colorscale     ,
            [<Optional;DefaultParameterValue(null)>] ?Autocolorscale ,
            [<Optional;DefaultParameterValue(null)>] ?Reversescale   ,
            [<Optional;DefaultParameterValue(null)>] ?Showscale      ,
            [<Optional;DefaultParameterValue(null)>] ?zSmooth        ,
            [<Optional;DefaultParameterValue(null)>] ?ColorBar
        ) =
            (fun (heatmap:('T :> Trace)) -> 
            
                Z              |> DynObj.setValueOpt heatmap "z"         
                X              |> DynObj.setValueOpt heatmap "x"               
                Y              |> DynObj.setValueOpt heatmap "y"
                X0             |> DynObj.setValueOpt heatmap "x0"             
                dX             |> DynObj.setValueOpt heatmap "dx"             
                Y0             |> DynObj.setValueOpt heatmap "y0"            
                dY             |> DynObj.setValueOpt heatmap "dy"            
                xType          |> DynObj.setValueOpt heatmap "xtype"         
                yType          |> DynObj.setValueOpt heatmap "ytype"                          
                xAxis          |> DynObj.setValueOpt heatmap "xaxis"         
                yAxis          |> DynObj.setValueOpt heatmap "yaxis"         
                Zsrc           |> DynObj.setValueOpt heatmap "zsrc"       
                Xsrc           |> DynObj.setValueOpt heatmap "xsrc"       
                Ysrc           |> DynObj.setValueOpt heatmap "ysrc"  

                Xgap           |> DynObj.setValueOpt heatmap "xgap"       
                Ygap           |> DynObj.setValueOpt heatmap "ygap"  
                Transpose      |> DynObj.setValueOpt heatmap "transpose" 
                zAuto          |> DynObj.setValueOpt heatmap "zauto"     
                zMin           |> DynObj.setValueOpt heatmap "zmin"      
                zMax           |> DynObj.setValueOpt heatmap "zmax"      
                Colorscale     |> DynObj.setValueOptBy heatmap "colorscale" StyleParam.Colorscale.convert 
                Autocolorscale |> DynObj.setValueOpt heatmap "autocolorscale"
                Reversescale   |> DynObj.setValueOpt heatmap "reversescale"  
                Showscale      |> DynObj.setValueOpt heatmap "showscale"     
                zSmooth        |> DynObj.setValueOptBy heatmap "zsmooth" StyleParam.SmoothAlg.convert   
                ColorBar       |> DynObj.setValueOpt heatmap "colorbar"    

                // out ->
                heatmap 
            ) 
            
    // Applies the styles of heatmap to TraceObjects 
    static member Image
        (                
            [<Optional;DefaultParameterValue(null)>] ?Name              : string,
            [<Optional;DefaultParameterValue(null)>] ?Visible           : StyleParam.Visible,
            [<Optional;DefaultParameterValue(null)>] ?ShowLegend        : bool,
            [<Optional;DefaultParameterValue(null)>] ?LegendRank        : int,
            [<Optional;DefaultParameterValue(null)>] ?LegendGroup       : string,
            [<Optional;DefaultParameterValue(null)>] ?LegendGroupTitle  : Title,
            [<Optional;DefaultParameterValue(null)>] ?Opacity           : float, 
            [<Optional;DefaultParameterValue(null)>] ?Ids               : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?X                 : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?X0                : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?DX                : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?Y                 : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Y0                : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?DY                : #IConvertible,
            [<Optional;DefaultParameterValue(null)>] ?Z                 : #seq<#seq<#seq<int>>>,
            [<Optional;DefaultParameterValue(null)>] ?Source            : string,
            [<Optional;DefaultParameterValue(null)>] ?Text              : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?HoverText         : string,
            [<Optional;DefaultParameterValue(null)>] ?HoverInfo         : StyleParam.HoverInfo,
            [<Optional;DefaultParameterValue(null)>] ?HoverTemplate     : string,
            [<Optional;DefaultParameterValue(null)>] ?Meta              : string,
            [<Optional;DefaultParameterValue(null)>] ?CustomData        : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?XAxis             : StyleParam.LinearAxisId,
            [<Optional;DefaultParameterValue(null)>] ?YAxis             : StyleParam.LinearAxisId,
            [<Optional;DefaultParameterValue(null)>] ?ColorModel        : StyleParam.ColorModel,
            [<Optional;DefaultParameterValue(null)>] ?ZMax              : StyleParam.ColorComponentBound,
            [<Optional;DefaultParameterValue(null)>] ?ZMin              : StyleParam.ColorComponentBound,
            [<Optional;DefaultParameterValue(null)>] ?ZSmooth           : StyleParam.SmoothAlg,
            [<Optional;DefaultParameterValue(null)>] ?HoverLabel        : Hoverlabel,
            [<Optional;DefaultParameterValue(null)>] ?UIRevision        : string
        ) =
            (fun (image: ('T :> Trace)) -> 

                Name              |> DynObj.setValueOpt image "name"
                Visible           |> DynObj.setValueOptBy image "visible" StyleParam.Visible.convert
                ShowLegend        |> DynObj.setValueOpt image "showlegend"
                LegendRank        |> DynObj.setValueOpt image "legendrank"
                LegendGroup       |> DynObj.setValueOpt image "legendgroup"
                LegendGroupTitle  |> DynObj.setValueOpt image "legendgrouptitle"
                Opacity           |> DynObj.setValueOpt image "opacity"
                Ids               |> DynObj.setValueOpt image "ids"
                X                 |> DynObj.setValueOpt image "x"
                X0                |> DynObj.setValueOpt image "x0"
                DX                |> DynObj.setValueOpt image "dx"
                Y                 |> DynObj.setValueOpt image "y"
                Y0                |> DynObj.setValueOpt image "y0"
                DY                |> DynObj.setValueOpt image "dy"
                Z                 |> DynObj.setValueOpt image "z"
                Source            |> DynObj.setValueOpt image "source"
                Text              |> DynObj.setValueOpt image "text"
                HoverText         |> DynObj.setValueOpt image "hovertext"
                HoverInfo         |> DynObj.setValueOptBy image "hoverinfo" StyleParam.HoverInfo.convert
                HoverTemplate     |> DynObj.setValueOpt image "hovertemplate"
                Meta              |> DynObj.setValueOpt image "meta"
                CustomData        |> DynObj.setValueOpt image "customdata"
                XAxis             |> DynObj.setValueOptBy image "xaxis"       StyleParam.LinearAxisId.convert
                YAxis             |> DynObj.setValueOptBy image "yaxis"       StyleParam.LinearAxisId.convert
                ColorModel        |> DynObj.setValueOptBy image "colormodel"  StyleParam.ColorModel.convert
                ZMax              |> DynObj.setValueOptBy image "zmax"        StyleParam.ColorComponentBound.convert
                ZMin              |> DynObj.setValueOptBy image "zmin"        StyleParam.ColorComponentBound.convert
                ZSmooth           |> DynObj.setValueOptBy image "zsmooth"     StyleParam.SmoothAlg.convert
                HoverLabel        |> DynObj.setValueOpt image "hoverlabel"
                UIRevision        |> DynObj.setValueOpt image "uirevision"

                // out ->
                image 
            ) 


    static member Contour
        (                
            [<Optional;DefaultParameterValue(null)>] ?Z : seq<#seq<#IConvertible>>,
            [<Optional;DefaultParameterValue(null)>] ?X : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Y : seq<#IConvertible>,            
            [<Optional;DefaultParameterValue(null)>] ?X0             ,
            [<Optional;DefaultParameterValue(null)>] ?dX             ,
            [<Optional;DefaultParameterValue(null)>] ?Y0             ,
            [<Optional;DefaultParameterValue(null)>] ?dY             ,
            [<Optional;DefaultParameterValue(null)>] ?xType          ,
            [<Optional;DefaultParameterValue(null)>] ?yType          ,
            [<Optional;DefaultParameterValue(null)>] ?xAxis          ,
            [<Optional;DefaultParameterValue(null)>] ?yAxis          ,
            [<Optional;DefaultParameterValue(null)>] ?Zsrc           ,
            [<Optional;DefaultParameterValue(null)>] ?Xsrc           ,
            [<Optional;DefaultParameterValue(null)>] ?Ysrc           ,
            [<Optional;DefaultParameterValue(null)>] ?Xgap           ,         
            [<Optional;DefaultParameterValue(null)>] ?Ygap           ,
            [<Optional;DefaultParameterValue(null)>] ?Transpose      ,
            [<Optional;DefaultParameterValue(null)>] ?zAuto          ,
            [<Optional;DefaultParameterValue(null)>] ?zMin           ,
            [<Optional;DefaultParameterValue(null)>] ?zMax           ,
            [<Optional;DefaultParameterValue(null)>] ?Colorscale     ,
            [<Optional;DefaultParameterValue(null)>] ?Autocolorscale ,
            [<Optional;DefaultParameterValue(null)>] ?Reversescale   ,
            [<Optional;DefaultParameterValue(null)>] ?Showscale      ,
            [<Optional;DefaultParameterValue(null)>] ?zSmooth        ,
            [<Optional;DefaultParameterValue(null)>] ?ColorBar
        ) =
            (fun (contour:('T :> Trace)) -> 
            
                Z              |> DynObj.setValueOpt contour "z"         
                X              |> DynObj.setValueOpt contour "x"               
                Y              |> DynObj.setValueOpt contour "y"
                X0             |> DynObj.setValueOpt contour "x0"             
                dX             |> DynObj.setValueOpt contour "dx"             
                Y0             |> DynObj.setValueOpt contour "y0"            
                dY             |> DynObj.setValueOpt contour "dy"            
                xType          |> DynObj.setValueOpt contour "xtype"         
                yType          |> DynObj.setValueOpt contour "ytype"                          
                xAxis          |> DynObj.setValueOpt contour "xaxis"         
                yAxis          |> DynObj.setValueOpt contour "yaxis"         
                Zsrc           |> DynObj.setValueOpt contour "zsrc"       
                Xsrc           |> DynObj.setValueOpt contour "xsrc"       
                Ysrc           |> DynObj.setValueOpt contour "ysrc"  

                Xgap           |> DynObj.setValueOpt contour   "xgap"       
                Ygap           |> DynObj.setValueOpt contour   "ygap"  
                Transpose      |> DynObj.setValueOpt contour   "transpose" 
                zAuto          |> DynObj.setValueOpt contour   "zauto"     
                zMin           |> DynObj.setValueOpt contour   "zmin"      
                zMax           |> DynObj.setValueOpt contour   "zmax"      
                Colorscale     |> DynObj.setValueOptBy contour "colorscale" StyleParam.Colorscale.convert 
                Autocolorscale |> DynObj.setValueOpt contour   "autocolorscale"
                Reversescale   |> DynObj.setValueOpt contour   "reversescale"  
                Showscale      |> DynObj.setValueOpt contour   "showscale"     
                zSmooth        |> DynObj.setValueOptBy contour "zsmooth" StyleParam.SmoothAlg.convert   
                ColorBar       |> DynObj.setValueOpt contour   "colorbar"    

                // out ->
                contour 
            )

            
        
    /// Applies the styles of ohlc plot to TraceObjects 
    ///
    /// ``open``    : Sets the open values.
    ///
    /// high        : Sets the high values.
    ///
    /// low         : Sets the low values.
    ///
    /// close       : Sets the close values.
    ///
    /// x           : Sets the x coordinates. If absent, linear coordinate will be generated.
    ///
    /// ?Increasing : Sets the Line style of the Increasing part of the chart
    ///
    /// ?Decreasing : Sets the Line style of the Decreasing part of the chart
    ///
    /// ?Line       : Sets the Line style of both the Decreasing and Increasing part of the chart
    ///
    /// ?Tickwidth  : Sets the width of the open/close tick marks relative to the "x" minimal interval.
    ///
    /// ?XCalendar  : Sets the calendar system to use with `x` date data.
    static member OHLC
        (
            ``open``        : #IConvertible seq,
            high            : #IConvertible seq,
            low             : #IConvertible seq,
            close           : #IConvertible seq,
            x               : #IConvertible seq,
            [<Optional;DefaultParameterValue(null)>] ?Increasing     : Line,
            [<Optional;DefaultParameterValue(null)>] ?Decreasing     : Line,
            [<Optional;DefaultParameterValue(null)>] ?Line           : Line,
            [<Optional;DefaultParameterValue(null)>] ?Tickwidth      : float,
            [<Optional;DefaultParameterValue(null)>] ?XCalendar      : StyleParam.Calendar
        ) =
            (fun (trace:('T :> Trace)) ->
                DynObj.setValue     trace "open"        ``open``
                DynObj.setValue     trace "high"        high
                DynObj.setValue     trace "low"         low
                DynObj.setValue     trace "close"       close
                DynObj.setValue     trace "x"           x
                DynObj.setValue     trace "xaxis"       "x"
                DynObj.setValue     trace "yaxis"       "y"
                DynObj.setValueOpt  trace "increasing"  Increasing
                DynObj.setValueOpt  trace "decreasing"  Decreasing
                DynObj.setValueOpt  trace "tickwidth"   Tickwidth
                DynObj.setValueOpt  trace "line"        Line
                DynObj.setValueOpt  trace "xcalendar"   XCalendar
                    
                trace
            )


    /// Applies the styles of candlestick plot to TraceObjects 
    ///
    /// ``open``        : Sets the open values.
    ///
    /// high            : Sets the high values.
    ///
    /// low             : Sets the low values.
    ///
    /// close           : Sets the close values.
    ///
    /// x               : Sets the x coordinates. If absent, linear coordinate will be generated.
    ///
    /// ?Increasing     : Sets the Line style of the Increasing part of the chart
    ///
    /// ?Decreasing     : Sets the Line style of the Decreasing part of the chart
    ///
    /// ?Line           : Sets the Line style of both the Decreasing and Increasing part of the chart
    ///
    /// ?WhiskerWidth   : Sets the width of the whiskers relative to the box' width. For example, with 1, the whiskers are as wide as the box(es).
    ///
    /// ?XCalendar      : Sets the calendar system to use with `x` date data.
    static member Candlestick
        (
            ``open``        : #IConvertible seq,
            high            : #IConvertible seq,
            low             : #IConvertible seq,
            close           : #IConvertible seq,
            x               : #IConvertible seq,
            [<Optional;DefaultParameterValue(null)>] ?Increasing     : Line,
            [<Optional;DefaultParameterValue(null)>] ?Decreasing     : Line,
            [<Optional;DefaultParameterValue(null)>] ?WhiskerWidth   : float,
            [<Optional;DefaultParameterValue(null)>] ?Line           : Line,
            [<Optional;DefaultParameterValue(null)>] ?XCalendar      : StyleParam.Calendar
        ) =
            (fun (trace:('T :> Trace)) ->
                DynObj.setValue     trace "open"        ``open``
                DynObj.setValue     trace "high"        high
                DynObj.setValue     trace "low"         low
                DynObj.setValue     trace "close"       close
                DynObj.setValue     trace "x"           x
                DynObj.setValue     trace "xaxis"       "x"
                DynObj.setValue     trace "yaxis"       "y"
                DynObj.setValueOpt  trace "increasing"  Increasing
                DynObj.setValueOpt  trace "decreasing"  Decreasing
                DynObj.setValueOpt  trace "whiskerwidth"WhiskerWidth
                DynObj.setValueOpt  trace "line"        Line
                DynObj.setValueOpt  trace "xcalendar"   XCalendar

                trace
            )

    // Applies the styles of Splom plot to TraceObjects 
    static member Splom
        (   
            [<Optional;DefaultParameterValue(null)>] ?Dimensions : seq<Dimensions>
        ) =
            (fun (trace:('T :> Trace)) ->
                Dimensions   |> DynObj.setValueOpt trace "dimensions"
                        
                // out ->
                trace
            )