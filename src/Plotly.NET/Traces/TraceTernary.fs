namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type TraceTernary(traceTypeName) =

    inherit Trace(traceTypeName)

    ///initializes a trace of type "scatterternary" applying the given trace styling function
    static member initScatterTernary(applyStyle: TraceTernary -> TraceTernary) =
        TraceTernary("scatterternary") |> applyStyle

type TraceTernaryStyle() =

    static member SetTernary(?TernaryId: StyleParam.SubPlotId) =
        fun (trace: TraceTernary) ->
            trace |> DynObj.withOptionalPropertyBy  "subplot" TernaryId  StyleParam.SubPlotId.toString

    /// <summary>
    /// Create a function that applies the styles of a ternary scatter plot to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Opacity">Sets the opacity of the trace.</param>
    /// <param name="Mode">Determines the drawing mode for this scatter trace. If the provided `mode` includes "text" then the `text` elements appear at the coordinates. Otherwise, the `text` elements appear on hover. If there are less than 20 points and the trace is not stacked then the default is "lines+markers". Otherwise, "lines".</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="A">Sets the quantity of component `a` in each data point. If `a`, `b`, and `c` are all provided, they need not be normalized, only the relative values matter. If only two arrays are provided they must be normalized to match `ternary&lt;i&gt;.sum`.</param>
    /// <param name="B">Sets the quantity of component `b` in each data point. If `a`, `b`, and `c` are all provided, they need not be normalized, only the relative values matter. If only two arrays are provided they must be normalized to match `ternary&lt;i&gt;.sum`.</param>
    /// <param name="C">Sets the quantity of component `c` in each data point. If `a`, `b`, and `c` are all provided, they need not be normalized, only the relative values matter. If only two arrays are provided they must be normalized to match `ternary&lt;i&gt;.sum`.</param>
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
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="SubPlot">Sets a reference between this trace's data coordinates and a mapbox subplot. If "mapbox" (the default value), the data refer to `layout.mapbox`. If "mapbox2", the data refer to `layout.mapbox2`, and so on.</param>
    /// <param name="Marker">Sets the marker of this trace.</param>
    /// <param name="Line">Sets the line of this trace</param>
    /// <param name="TextFont">Sets the text font of this trace</param>
    /// <param name="SelectedPoints">Array containing integer indices of selected points. Has an effect only for traces that support selections. Note that an empty array means an empty selection where the `unselected` are turned on for all points, whereas, any other non-array values means no selection all where the `selected` and `unselected` styles have no effect.</param>
    /// <param name="Selected">Sets the style of selected points of this trace.</param>
    /// <param name="Unselected">Sets the style of unselected points of this trace.</param>
    /// <param name="ClipOnAxis">Determines whether or not markers and text nodes are clipped about the subplot axes. To show markers and text nodes above axis lines and tick labels, make sure to set `xaxis.layer` and `yaxis.layer` to "below traces".</param>
    /// <param name="ConnectGaps">Determines whether or not gaps (i.e. {nan} or missing values) in the provided data arrays are connected.</param>
    /// <param name="Fill">Sets the area to fill with a solid color. Use with `fillcolor` if not "none". scatterternary has a subset of the options available to scatter. "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape. "tonext" fills the space between two traces if one completely encloses the other (eg consecutive contour lines), and behaves like "toself" if there is no trace before it. "tonext" should not be used if one trace does not enclose the other.</param>
    /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
    /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
    /// <param name="HoverOn">Do the hover effects highlight individual points (markers or line points) or do they highlight filled regions? If the fill is "toself" or "tonext" and there are no markers or text, then the default is "fills", otherwise it is "points".</param>
    /// <param name="Sum">The number each triplet should sum to, if only two of `a`, `b`, and `c` are provided. This overrides `ternary&lt;i&gt;.sum` to normalize this specific trace, but does not affect the values displayed on the axes. 0 (or missing) means to use ternary&lt;i&gt;.sum</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member ScatterTernary
        (
            ?Name: string,
            ?Visible: StyleParam.Visible,
            ?ShowLegend: bool,
            ?Legend: StyleParam.SubPlotId,
            ?LegendRank: int,
            ?LegendGroup: string,
            ?LegendGroupTitle: Title,
            ?Opacity: float,
            ?Mode: StyleParam.Mode,
            ?Ids: seq<#IConvertible>,
            ?A: seq<#IConvertible>,
            ?B: seq<#IConvertible>,
            ?C: seq<#IConvertible>,
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
            ?Meta: string,
            ?CustomData: seq<#IConvertible>,
            ?SubPlot: StyleParam.SubPlotId,
            ?Marker: Marker,
            ?Line: Line,
            ?TextFont: Font,
            ?SelectedPoints: seq<#IConvertible>,
            ?Selected: TraceSelection,
            ?Unselected: TraceSelection,
            ?ClipOnAxis: bool,
            ?ConnectGaps: bool,
            ?Fill: StyleParam.Fill,
            ?FillColor: Color,
            ?HoverLabel: Hoverlabel,
            ?HoverOn: StyleParam.HoverOn,
            ?Sum: #IConvertible,
            ?UIRevision: string
        ) =
        fun (trace: #Trace) ->

            trace
            |> DynObj.withOptionalProperty                   "name"            Name                                
            |> DynObj.withOptionalPropertyBy                 "visible"         Visible                             StyleParam.Visible.convert
            |> DynObj.withOptionalProperty                   "showlegend"      ShowLegend                          
            |> DynObj.withOptionalPropertyBy                 "legend"          Legend                              StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty                   "legendrank"      LegendRank                          
            |> DynObj.withOptionalProperty                   "legendgroup"     LegendGroup                         
            |> DynObj.withOptionalProperty                   "legendgrouptitle"LegendGroupTitle                    
            |> DynObj.withOptionalProperty                   "opacity"         Opacity                             
            |> DynObj.withOptionalPropertyBy                 "mode"            Mode                                StyleParam.Mode.convert
            |> DynObj.withOptionalProperty                   "ids"             Ids                                 
            |> DynObj.withOptionalProperty                   "a"               A                                   
            |> DynObj.withOptionalProperty                   "b"               B                                   
            |> DynObj.withOptionalProperty                   "c"               C                                   
            |> DynObj.withOptionalSingleOrMultiProperty      "text"            (Text, MultiText)                   
            |> DynObj.withOptionalSingleOrMultiPropertyBy    "textposition"    (TextPosition, MultiTextPosition)   StyleParam.TextPosition.convert
            |> DynObj.withOptionalSingleOrMultiProperty      "texttemplate"    (TextTemplate, MultiTextTemplate)   
            |> DynObj.withOptionalSingleOrMultiProperty      "hovertext"       (HoverText, MultiHoverText)         
            |> DynObj.withOptionalPropertyBy                 "hoverinfo"       HoverInfo                           StyleParam.HoverInfo.convert
            |> DynObj.withOptionalSingleOrMultiProperty      "hovertemplate"   (HoverTemplate, MultiHoverTemplate) 
            |> DynObj.withOptionalProperty                   "meta"            Meta                                
            |> DynObj.withOptionalProperty                   "customdata"      CustomData                          
            |> DynObj.withOptionalPropertyBy                 "subplot"         SubPlot                             StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty                   "marker"          Marker                              
            |> DynObj.withOptionalProperty                   "line"            Line                                
            |> DynObj.withOptionalProperty                   "textfont"        TextFont                            
            |> DynObj.withOptionalProperty                   "selectedpoints"  SelectedPoints                      
            |> DynObj.withOptionalProperty                   "selected"        Selected                            
            |> DynObj.withOptionalProperty                   "unselected"      Unselected                          
            |> DynObj.withOptionalProperty                   "cliponaxis"      ClipOnAxis                          
            |> DynObj.withOptionalProperty                   "connectgaps"     ConnectGaps                         
            |> DynObj.withOptionalPropertyBy                 "fill"            Fill                                StyleParam.Fill.convert
            |> DynObj.withOptionalProperty                   "fillcolor"       FillColor                           
            |> DynObj.withOptionalProperty                   "hoverlabel"      HoverLabel                          
            |> DynObj.withOptionalPropertyBy                 "hoveron"         HoverOn                             StyleParam.HoverOn.convert
            |> DynObj.withOptionalProperty                   "sum"             Sum                                 
            |> DynObj.withOptionalProperty                   "uirevision"      UIRevision                          
