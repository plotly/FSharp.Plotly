namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type TraceCarpet(traceTypeName) =

    inherit Trace(traceTypeName)

    ///initializes a trace of type "carpet" applying the given trace styling function
    static member initCarpet(applyStyle: TraceCarpet -> TraceCarpet) = TraceCarpet("carpet") |> applyStyle

    ///initializes a trace of type "scattercarpet" applying the given trace styling function
    static member initScatterCarpet(applyStyle: TraceCarpet -> TraceCarpet) =
        TraceCarpet("scattercarpet") |> applyStyle

    ///initializes a trace of type "contourcarpet" applying the given trace styling function
    static member initContourCarpet(applyStyle: TraceCarpet -> TraceCarpet) =
        TraceCarpet("contourcarpet") |> applyStyle

type TraceCarpetStyle() =

    /// Sets the given axis anchor id(s) on a Trace object.
    static member SetAxisAnchor
        (
            ?X: StyleParam.LinearAxisId,
            ?Y: StyleParam.LinearAxisId
        ) =
        fun (trace: TraceCarpet) ->

            trace
            |> DynObj.withOptionalPropertyBy "xaxis" X StyleParam.LinearAxisId.toString
            |> DynObj.withOptionalPropertyBy "yaxis" Y StyleParam.LinearAxisId.toString

    static member SetCarpet(?CarpetId: StyleParam.SubPlotId) =
        fun (trace: TraceCarpet) ->
            trace  |> DynObj.withOptionalPropertyBy "carpet" CarpetId  StyleParam.SubPlotId.toString

    /// <summary>
    /// Create a function that applies the styles of a carpet to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Opacity">Sets the opacity of the trace.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="X">A one dimensional array of x coordinates matching the dimensions of `a` and `b`.</param>
    /// <param name="MultiX">A two dimensional array of x coordinates at each carpet point. If omitted, the plot is a cheater plot and the xaxis is hidden by default.</param>
    /// <param name="Y">A one dimensional array of y coordinates matching the dimensions of `a` and `b`.</param>
    /// <param name="MultiY">A two dimensional array of y coordinates at each carpet point.</param>
    /// <param name="A">An array containing values of the first parameter value</param>
    /// <param name="A0">Alternate to `a`. Builds a linear space of a coordinates. Use with `da` where `a0` is the starting coordinate and `da` the step.</param>
    /// <param name="DA">Sets the a coordinate step. See `a0` for more info.</param>
    /// <param name="B">An array containing values of the second parameter value</param>
    /// <param name="B0">Alternate to `b`. Builds a linear space of a coordinates. Use with `db` where `b0` is the starting coordinate and `db` the step.</param>
    /// <param name="DB">Sets the b coordinate step. See `b0` for more info.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="AAxis">Sets this carpet's a axis.</param>
    /// <param name="BAxis">Sets this carpet's b axis.</param>
    /// <param name="XAxis">Sets a reference between this trace's x coordinates and a 2D cartesian x axis. If "x" (the default value), the x coordinates refer to `layout.xaxis`. If "x2", the x coordinates refer to `layout.xaxis2`, and so on.</param>
    /// <param name="YAxis">Sets a reference between this trace's y coordinates and a 2D cartesian y axis. If "y" (the default value), the y coordinates refer to `layout.yaxis`. If "y2", the y coordinates refer to `layout.yaxis2`, and so on.</param>
    /// <param name="Color">Sets default for all colors associated with this axis all at once: line, font, tick, and grid colors. Grid color is lightened by blending this with the plot background Individual pieces can override this.</param>
    /// <param name="Carpet">An identifier for this carpet, so that `scattercarpet` and `contourcarpet` traces can specify a carpet plot on which they lie</param>
    /// <param name="CheaterSlope">The shift applied to each successive row of data in creating a cheater plot. Only used if `x` is been omitted.</param>
    /// <param name="Font">Sets the font of this trace.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member Carpet
        (
            ?Name: string,
            ?Visible: StyleParam.Visible,
            ?ShowLegend: bool,
            ?Legend: StyleParam.SubPlotId,
            ?LegendRank: int,
            ?LegendGroup: string,
            ?LegendGroupTitle: Title,
            ?Opacity: float,
            ?Ids: seq<#IConvertible>,
            ?X: seq<#IConvertible>,
            ?MultiX: seq<#seq<#IConvertible>>,
            ?Y: seq<#IConvertible>,
            ?MultiY: seq<#seq<#IConvertible>>,
            ?A: seq<#IConvertible>,
            ?A0: #IConvertible,
            ?DA: #IConvertible,
            ?B: seq<#IConvertible>,
            ?B0: #IConvertible,
            ?DB: #IConvertible,
            ?Meta: string,
            ?CustomData: seq<#IConvertible>,
            ?AAxis: LinearAxis,
            ?BAxis: LinearAxis,
            ?XAxis: StyleParam.LinearAxisId,
            ?YAxis: StyleParam.LinearAxisId,
            ?Color: Color,
            ?Carpet: StyleParam.SubPlotId,
            ?CheaterSlope: float,
            ?Font: Font,
            ?UIRevision: string
        ) =
        fun (trace: #Trace) ->

            trace
            |> DynObj.withOptionalProperty               "name"            Name                
            |> DynObj.withOptionalPropertyBy             "visible"         Visible             StyleParam.Visible.convert
            |> DynObj.withOptionalProperty               "showlegend"      ShowLegend          
            |> DynObj.withOptionalPropertyBy             "legend"          Legend              StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty               "legendrank"      LegendRank          
            |> DynObj.withOptionalProperty               "opacity"         LegendGroup         
            |> DynObj.withOptionalProperty               "legendgrouptitle"LegendGroupTitle    
            |> DynObj.withOptionalProperty               "opacity"         Opacity             
            |> DynObj.withOptionalProperty               "ids"             Ids                 
            |> DynObj.withOptionalSingleOrAnyProperty    "x"               (X, MultiX)         
            |> DynObj.withOptionalSingleOrAnyProperty    "y"               (Y, MultiY)         
            |> DynObj.withOptionalProperty               "a"               A                   
            |> DynObj.withOptionalProperty               "a0"              A0                  
            |> DynObj.withOptionalProperty               "da"              DA                  
            |> DynObj.withOptionalProperty               "b"               B                   
            |> DynObj.withOptionalProperty               "b0"              B0                  
            |> DynObj.withOptionalProperty               "db"              DB                  
            |> DynObj.withOptionalProperty               "meta"            Meta                
            |> DynObj.withOptionalProperty               "customdata"      CustomData          
            |> DynObj.withOptionalProperty               "aaxis"           AAxis               
            |> DynObj.withOptionalProperty               "baxis"           BAxis               
            |> DynObj.withOptionalPropertyBy             "xaxis"           XAxis               StyleParam.LinearAxisId.convert
            |> DynObj.withOptionalPropertyBy             "yaxis"           YAxis               StyleParam.LinearAxisId.convert
            |> DynObj.withOptionalProperty               "color"           Color               
            |> DynObj.withOptionalPropertyBy             "carpet"          Carpet              StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty               "cheaterslope"    CheaterSlope        
            |> DynObj.withOptionalProperty               "font"            Font                
            |> DynObj.withOptionalProperty               "uirevision"      UIRevision          

    /// <summary>
    /// Create a function that applies the styles of a scatter carpet plot to a Trace object
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
    /// <param name="A">Sets the a-axis coordinates.</param>
    /// <param name="B">Sets the b-axis coordinates.</param>
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
    /// <param name="XAxis">Sets a reference between this trace's x coordinates and a 2D cartesian x axis. If "x" (the default value), the x coordinates refer to `layout.xaxis`. If "x2", the x coordinates refer to `layout.xaxis2`, and so on.</param>
    /// <param name="YAxis">Sets a reference between this trace's y coordinates and a 2D cartesian y axis. If "y" (the default value), the y coordinates refer to `layout.yaxis`. If "y2", the y coordinates refer to `layout.yaxis2`, and so on.</param>
    /// <param name="Marker">Sets the marker of this trace.</param>
    /// <param name="Line">Sets the line of this trace.</param>
    /// <param name="TextFont">Sets the text font of this trace.</param>
    /// <param name="SelectedPoints">Array containing integer indices of selected points. Has an effect only for traces that support selections. Note that an empty array means an empty selection where the `unselected` are turned on for all points, whereas, any other non-array values means no selection all where the `selected` and `unselected` styles have no effect.</param>
    /// <param name="Selected">Sets the style of selected points of this trace.</param>
    /// <param name="Unselected">Sets the style of unselected points of this trace.</param>
    /// <param name="Carpet">An identifier for this carpet, so that `scattercarpet` and `contourcarpet` traces can specify a carpet plot on which they lie</param>
    /// <param name="ConnectGaps">Determines whether or not gaps (i.e. {nan} or missing values) in the provided data arrays are connected.</param>
    /// <param name="Fill">Sets the area to fill with a solid color. Use with `fillcolor` if not "none". scatterternary has a subset of the options available to scatter. "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape. "tonext" fills the space between two traces if one completely encloses the other (eg consecutive contour lines), and behaves like "toself" if there is no trace before it. "tonext" should not be used if one trace does not enclose the other.</param>
    /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
    /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
    /// <param name="HoverOn">Do the hover effects highlight individual points (markers or line points) or do they highlight filled regions? If the fill is "toself" or "tonext" and there are no markers or text, then the default is "fills", otherwise it is "points".</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member ScatterCarpet
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
            ?XAxis: StyleParam.LinearAxisId,
            ?YAxis: StyleParam.LinearAxisId,
            ?Marker: Marker,
            ?Line: Line,
            ?TextFont: Font,
            ?SelectedPoints: seq<#IConvertible>,
            ?Selected: TraceSelection,
            ?Unselected: TraceSelection,
            ?Carpet: StyleParam.SubPlotId,
            ?ConnectGaps: bool,
            ?Fill: StyleParam.Fill,
            ?FillColor: Color,
            ?HoverLabel: Hoverlabel,
            ?HoverOn: StyleParam.HoverOn,
            ?UIRevision: string
        ) =
        fun (trace: #Trace) ->
            
            trace
            |> DynObj.withOptionalProperty                   "name"            Name                                   
            |> DynObj.withOptionalPropertyBy                 "visible"         Visible                                StyleParam.Visible.convert
            |> DynObj.withOptionalProperty                   "showlegend"      ShowLegend                             
            |> DynObj.withOptionalPropertyBy                 "legend"          Legend                                 StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty                   "legendrank"      LegendRank                             
            |> DynObj.withOptionalProperty                   "legendgroup"     LegendGroup                            
            |> DynObj.withOptionalProperty                   "legendgrouptitle"LegendGroupTitle                       
            |> DynObj.withOptionalProperty                   "opacity"         Opacity                                
            |> DynObj.withOptionalPropertyBy                 "mode"            Mode                                   StyleParam.Mode.convert
            |> DynObj.withOptionalProperty                   "ids"             Ids                                    
            |> DynObj.withOptionalProperty                   "a"               A                                      
            |> DynObj.withOptionalProperty                   "b"               B                                      
            |> DynObj.withOptionalSingleOrMultiProperty      "text"            (Text, MultiText)                      
            |> DynObj.withOptionalSingleOrMultiPropertyBy    "textposition"    (TextPosition, MultiTextPosition)      StyleParam.TextPosition.convert
            |> DynObj.withOptionalSingleOrMultiProperty      "texttemplate"    (TextTemplate, MultiTextTemplate)      
            |> DynObj.withOptionalSingleOrMultiProperty      "hovertext"       (HoverText, MultiHoverText)            
            |> DynObj.withOptionalPropertyBy                 "hoverinfo"       HoverInfo                              StyleParam.HoverInfo.convert
            |> DynObj.withOptionalSingleOrMultiProperty      "hovertemplate"   (HoverTemplate, MultiHoverTemplate)    
            |> DynObj.withOptionalProperty                   "meta"            Meta                                   
            |> DynObj.withOptionalProperty                   "customdata"      CustomData                             
            |> DynObj.withOptionalPropertyBy                 "xaxis"           XAxis                                  StyleParam.LinearAxisId.convert
            |> DynObj.withOptionalPropertyBy                 "yaxis"           YAxis                                  StyleParam.LinearAxisId.convert
            |> DynObj.withOptionalProperty                   "marker"          Marker                                 
            |> DynObj.withOptionalProperty                   "line"            Line                                   
            |> DynObj.withOptionalProperty                   "textfont"        TextFont                               
            |> DynObj.withOptionalProperty                   "selectedpoints"  SelectedPoints                         
            |> DynObj.withOptionalProperty                   "selected"        Selected                               
            |> DynObj.withOptionalProperty                   "unselected"      Unselected                             
            |> DynObj.withOptionalPropertyBy                 "carpet"          Carpet                                 StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty                   "connectgaps"     ConnectGaps                            
            |> DynObj.withOptionalPropertyBy                 "fill"            Fill                                   StyleParam.Fill.convert
            |> DynObj.withOptionalProperty                   "fillcolor"       FillColor                              
            |> DynObj.withOptionalProperty                   "hoverlabel"      HoverLabel                             
            |> DynObj.withOptionalPropertyBy                 "hoveron"         HoverOn                                StyleParam.HoverOn.convert
            |> DynObj.withOptionalProperty                   "uirevision"      UIRevision                             

    /// <summary>
    /// Create a function that applies the styles of a carpet contour scatter plot to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Opacity">Sets the opacity of the trace.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="Z">Sets the z data.</param>
    /// <param name="A">Sets the a coordinates.</param>
    /// <param name="AType">If "array", the heatmap's a coordinates are given by "a" (the default behavior when `a` is provided). If "scaled", the heatmap's a coordinates are given by "a0" and "da" (the default behavior when `a` is not provided).</param>
    /// <param name="A0">Alternate to `a`. Builds a linear space of x coordinates. Use with `da` where `a0` is the starting coordinate and `da` the step.</param>
    /// <param name="DA">Sets the a coordinate step. See `a0` for more info.</param>
    /// <param name="B">Sets the b coordinates.</param>
    /// <param name="BType">If "array", the heatmap's a coordinates are given by "b" (the default behavior when `b` is provided). If "scaled", the heatmap's b coordinates are given by "b0" and "db" (the default behavior when `b` is not provided).</param>
    /// <param name="B0">Alternate to `b`. Builds a linear space of x coordinates. Use with `db` where `b0` is the starting coordinate and `db` the step.</param>
    /// <param name="DB">Sets the a coordinate step. See `b0` for more info.</param>
    /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="HoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="MultiHoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="XAxis">Sets a reference between this trace's x coordinates and a 2D cartesian x axis. If "x" (the default value), the x coordinates refer to `layout.xaxis`. If "x2", the x coordinates refer to `layout.xaxis2`, and so on.</param>
    /// <param name="YAxis">Sets a reference between this trace's y coordinates and a 2D cartesian y axis. If "y" (the default value), the y coordinates refer to `layout.yaxis`. If "y2", the y coordinates refer to `layout.yaxis2`, and so on.</param>
    /// <param name="ColorAxis">Sets a reference to a shared color axis. References to these shared color axes are "coloraxis", "coloraxis2", "coloraxis3", etc. Settings for these shared color axes are set in the layout, under `layout.coloraxis`, `layout.coloraxis2`, etc. Note that multiple color scales can be linked to the same color axis.</param>
    /// <param name="Line">Sets the line of this trace.</param>
    /// <param name="ColorBar">Sets the color bar of this trace.</param>
    /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `colorscale`. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
    /// <param name="ColorScale">Sets the colorscale. The colorscale must be an array containing arrays mapping a normalized value to an rgb, rgba, hex, hsl, hsv, or named color string. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 'rgb(0,0,255)'], [1, 'rgb(255,0,0)']]`. To control the bounds of the colorscale in color space, use`zmin` and `zmax`. Alternatively, `colorscale` may be a palette name string of the following list: Blackbody,Bluered,Blues,Cividis,Earth,Electric,Greens,Greys,Hot,Jet,Picnic,Portland,Rainbow,RdBu,Reds,Viridis,YlGnBu,YlOrRd.</param>
    /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace.</param>
    /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
    /// <param name="ZAuto">Determines whether or not the color domain is computed with respect to the input data (here in `z`) or the bounds set in `zmin` and `zmax` Defaults to `false` when `zmin` and `zmax` are set by the user.</param>
    /// <param name="ZMax">Sets the upper bound of the color domain. Value should have the same units as in `z` and if set, `zmin` must be set as well.</param>
    /// <param name="ZMid">Sets the mid-point of the color domain by scaling `zmin` and/or `zmax` to be equidistant to this point. Value should have the same units as in `z`. Has no effect when `zauto` is `false`.</param>
    /// <param name="ZMin">Sets the lower bound of the color domain. Value should have the same units as in `z` and if set, `zmax` must be set as well.</param>
    /// <param name="AutoContour">Determines whether or not the contour level attributes are picked by an algorithm. If "true", the number of contour levels can be set in `ncontours`. If "false", set the contour level attributes in `contours`.</param>
    /// <param name="Carpet">The `carpet` of the carpet axes on which this contour trace lies</param>
    /// <param name="Contours">Sets the contours of this trace</param>
    /// <param name="FillColor">Sets the fill color if `contours.type` is "constraint". Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
    /// <param name="NContours">Sets the maximum number of contour levels. The actual number of contours will be chosen automatically to be less than or equal to the value of `ncontours`. Has an effect only if `autocontour` is "true" or if `contours.size` is missing.</param>
    /// <param name="Transpose">Transposes the z data.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member ContourCarpet
        (
            ?Name: string,
            ?Visible: StyleParam.Visible,
            ?ShowLegend: bool,
            ?Legend: StyleParam.SubPlotId,
            ?LegendRank: int,
            ?LegendGroup: string,
            ?LegendGroupTitle: Title,
            ?Opacity: float,
            ?Ids: seq<#IConvertible>,
            ?Z: seq<#IConvertible>,
            ?A: seq<#IConvertible>,
            ?AType: StyleParam.CoordinateType,
            ?A0: #IConvertible,
            ?DA: #IConvertible,
            ?B: seq<#IConvertible>,
            ?BType: StyleParam.CoordinateType,
            ?B0: #IConvertible,
            ?DB: #IConvertible,
            ?Text: #IConvertible,
            ?MultiText: seq<#IConvertible>,
            ?HoverText: string,
            ?MultiHoverText: seq<string>,
            ?Meta: string,
            ?CustomData: seq<#IConvertible>,
            ?XAxis: StyleParam.LinearAxisId,
            ?YAxis: StyleParam.LinearAxisId,
            ?ColorAxis: StyleParam.SubPlotId,
            ?Line: Line,
            ?ColorBar: ColorBar,
            ?AutoColorScale: bool,
            ?ColorScale: StyleParam.Colorscale,
            ?ShowScale: bool,
            ?ReverseScale: bool,
            ?ZAuto: bool,
            ?ZMax: #IConvertible,
            ?ZMid: #IConvertible,
            ?ZMin: #IConvertible,
            ?AutoContour: bool,
            ?Carpet: StyleParam.SubPlotId,
            ?Contours: Contours,
            ?FillColor: Color,
            ?NContours: int,
            ?Transpose: bool,
            ?UIRevision: string
        ) =
        fun (trace: #Trace) ->

            trace
            |> DynObj.withOptionalProperty               "name"            Name                        
            |> DynObj.withOptionalPropertyBy             "visible"         Visible                     StyleParam.Visible.convert
            |> DynObj.withOptionalProperty               "showlegend"      ShowLegend                  
            |> DynObj.withOptionalPropertyBy             "legend"          Legend                      StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty               "legendrank"      LegendRank                  
            |> DynObj.withOptionalProperty               "legendgroup"     LegendGroup                 
            |> DynObj.withOptionalProperty               "legendgrouptitle"LegendGroupTitle            
            |> DynObj.withOptionalProperty               "opacity"         Opacity                     
            |> DynObj.withOptionalProperty               "ids"             Ids                         
            |> DynObj.withOptionalProperty               "z"               Z                           
            |> DynObj.withOptionalProperty               "a"               A                           
            |> DynObj.withOptionalPropertyBy             "atype"           AType                       StyleParam.CoordinateType.convert
            |> DynObj.withOptionalProperty               "a0"              A0                          
            |> DynObj.withOptionalProperty               "da"              DA                          
            |> DynObj.withOptionalProperty               "b"               B                           
            |> DynObj.withOptionalPropertyBy             "btype"           BType                       StyleParam.CoordinateType.convert
            |> DynObj.withOptionalProperty               "b0"              B0                          
            |> DynObj.withOptionalProperty               "db"              DB                          
            |> DynObj.withOptionalSingleOrMultiProperty  "text"            (Text, MultiText)           
            |> DynObj.withOptionalSingleOrMultiProperty  "hovertext"       (HoverText, MultiHoverText) 
            |> DynObj.withOptionalProperty               "meta"            Meta                        
            |> DynObj.withOptionalProperty               "customdata"      CustomData                  
            |> DynObj.withOptionalPropertyBy             "xaxis"           XAxis                       StyleParam.LinearAxisId.convert
            |> DynObj.withOptionalPropertyBy             "yaxis"           YAxis                       StyleParam.LinearAxisId.convert
            |> DynObj.withOptionalPropertyBy             "coloraxis"       ColorAxis                   StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty               "line"            Line                        
            |> DynObj.withOptionalProperty               "colorbar"        ColorBar                    
            |> DynObj.withOptionalProperty               "autocolorscale"  AutoColorScale              
            |> DynObj.withOptionalPropertyBy             "colorscale"      ColorScale                  StyleParam.Colorscale.convert
            |> DynObj.withOptionalProperty               "showscale"       ShowScale                   
            |> DynObj.withOptionalProperty               "reversescale"    ReverseScale                
            |> DynObj.withOptionalProperty               "zauto"           ZAuto                       
            |> DynObj.withOptionalProperty               "zmax"            ZMax                        
            |> DynObj.withOptionalProperty               "zmid"            ZMid                        
            |> DynObj.withOptionalProperty               "zmin"            ZMin                        
            |> DynObj.withOptionalProperty               "autocontour"     AutoContour                 
            |> DynObj.withOptionalPropertyBy             "carpet"          Carpet                      StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty               "contours"        Contours                    
            |> DynObj.withOptionalProperty               "fillcolor"       FillColor                   
            |> DynObj.withOptionalProperty               "ncontours"       NContours                   
            |> DynObj.withOptionalProperty               "transpose"       Transpose                   
            |> DynObj.withOptionalProperty               "uirevision"      UIRevision                  
