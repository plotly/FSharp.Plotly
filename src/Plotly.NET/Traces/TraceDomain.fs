namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type TraceDomain(traceTypeName) =

    inherit Trace(traceTypeName)

    ///initializes a trace of type "pie" applying the given trace styling function
    static member initPie(applyStyle: TraceDomain -> TraceDomain) = TraceDomain("pie") |> applyStyle

    ///initializes a trace of type "funnelarea" applying the given trace styling function
    static member initFunnelArea(applyStyle: TraceDomain -> TraceDomain) = TraceDomain("funnelarea") |> applyStyle

    ///initializes a trace of type "sunburst" applying the given trace styling function
    static member initSunburst(applyStyle: TraceDomain -> TraceDomain) = TraceDomain("sunburst") |> applyStyle

    ///initializes a trace of type "treemap" applying the given trace styling function
    static member initTreemap(applyStyle: TraceDomain -> TraceDomain) = TraceDomain("treemap") |> applyStyle

    ///initializes a trace of type "parcoords" applying the given trace styling function
    static member initParallelCoord(applyStyle: TraceDomain -> TraceDomain) = TraceDomain("parcoords") |> applyStyle

    ///initializes a trace of type "parcats" applying the given trace styling function
    static member initParallelCategories(applyStyle: TraceDomain -> TraceDomain) = TraceDomain("parcats") |> applyStyle

    ///initializes a trace of type "sankey" applying the given trace styling function
    static member initSankey(applyStyle: TraceDomain -> TraceDomain) = TraceDomain("sankey") |> applyStyle

    ///initializes a trace of type "Table" applying the given trace styling function
    static member initTable(applyStyle: TraceDomain -> TraceDomain) = TraceDomain("table") |> applyStyle

    ///initializes a trace of type "indicator" applying the given trace styling function
    static member initIndicator(applyStyle: TraceDomain -> TraceDomain) = TraceDomain("indicator") |> applyStyle

    ///initializes a trace of type "icicle" applying the given trace styling function
    static member initIcicle(applyStyle: TraceDomain -> TraceDomain) = TraceDomain("icicle") |> applyStyle

type TraceDomainStyle() =

    static member SetDomain(?Domain: Domain) =
        fun (trace: TraceDomain) ->
            trace |> DynObj.withOptionalProperty "domain" Domain

    /// <summary>
    /// Creates a function that applies the styles of a pie chart to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Title">Sets the title of this trace.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Opacity">Sets the opacity of the trace.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="Values">Sets the values of the sectors. If omitted, we count occurrences of each label.</param>
    /// <param name="Labels">Sets the sector labels. If `labels` entries are duplicated, we sum associated `values` or simply count occurrences if `values` is not provided. For other array attributes (including color) we use the first non-empty entry among all occurrences of the label.</param>
    /// <param name="DLabel">Sets the label step. See `label0` for more info.</param>
    /// <param name="Label0">Alternate to `labels`. Builds a numeric set of labels. Use with `dlabel` where `label0` is the starting label and `dlabel` the step.</param>
    /// <param name="Pull">Sets the fraction of larger radius to pull the sectors out from the center. This can be a constant to pull all slices apart from each other equally or an array to highlight one or more slices.</param>
    /// <param name="MultiPull">Sets the fraction of larger radius to pull the sectors out from the center. This can be a constant to pull all slices apart from each other equally or an array to highlight one or more slices.</param>
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
    /// <param name="Domain">Sets the domain of this trace.</param>
    /// <param name="AutoMargin">Determines whether outside text labels can push the margins.</param>
    /// <param name="Marker">Sets the marker of this trace.</param>
    /// <param name="TextFont">Sets the text font of this trace.</param>
    /// <param name="TextInfo">Determines which trace information appear on the graph.</param>
    /// <param name="Direction">Specifies the direction at which succeeding sectors follow one another.</param>
    /// <param name="Hole">Sets the fraction of the radius to cut out of the pie. Use this to make a donut chart.</param>
    /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
    /// <param name="InsideTextFont">Sets the font used for `textinfo` lying inside the sector.</param>
    /// <param name="InsideTextOrientation">Controls the orientation of the text inside chart sectors. When set to "auto", text may be oriented in any direction in order to be as big as possible in the middle of a sector. The "horizontal" option orients text to be parallel with the bottom of the chart, and may make text smaller in order to achieve that goal. The "radial" option orients text along the radius of the sector. The "tangential" option orients text perpendicular to the radius of the sector.</param>
    /// <param name="OutsideTextFont">Sets the font used for `textinfo` lying outside the sector.</param>
    /// <param name="Rotation">Instead of the first slice starting at 12 o'clock, rotate to some other angle.</param>
    /// <param name="ScaleGroup">If there are multiple pie charts that should be sized according to their totals, link them by providing a non-empty group id here shared by every trace in the same group.</param>
    /// <param name="Sort">Determines whether or not the sectors are reordered from largest to smallest.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member Pie
        (
            ?Name: string,
            ?Title: Title,
            ?Visible: StyleParam.Visible,
            ?ShowLegend: bool,
            ?Legend: StyleParam.SubPlotId,
            ?LegendRank: int,
            ?LegendGroup: string,
            ?LegendGroupTitle: Title,
            ?Opacity: float,
            ?Ids: seq<#IConvertible>,
            ?Values: seq<#IConvertible>,
            ?Labels: seq<#IConvertible>,
            ?DLabel: #IConvertible,
            ?Label0: #IConvertible,
            ?Pull: float,
            ?MultiPull: seq<float>,
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
            ?Meta: seq<#IConvertible>,
            ?CustomData: seq<#IConvertible>,
            ?Domain: Domain,
            ?AutoMargin: bool,
            ?Marker: Marker,
            ?TextFont: Font,
            ?TextInfo: StyleParam.TextInfo,
            ?Direction: StyleParam.Direction,
            ?Hole: float,
            ?HoverLabel: Hoverlabel,
            ?InsideTextFont: Font,
            ?InsideTextOrientation: StyleParam.InsideTextOrientation,
            ?OutsideTextFont: Font,
            ?Rotation: float,
            ?ScaleGroup: string,
            ?Sort: bool,
            ?UIRevision: string
        ) =
        fun (trace: ('T :> Trace)) ->
            trace
            |> DynObj.withOptionalProperty                   "name"                  Name                                
            |> DynObj.withOptionalProperty                   "title"                 Title                               
            |> DynObj.withOptionalPropertyBy                 "visible"               Visible                             StyleParam.Visible.convert
            |> DynObj.withOptionalProperty                   "showlegend"            ShowLegend                          
            |> DynObj.withOptionalPropertyBy                 "legend"                Legend                              StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty                   "legendrank"            LegendRank                          
            |> DynObj.withOptionalProperty                   "legendgroup"           LegendGroup                         
            |> DynObj.withOptionalProperty                   "legendgrouptitle"      LegendGroupTitle                    
            |> DynObj.withOptionalProperty                   "opacity"               Opacity                             
            |> DynObj.withOptionalProperty                   "ids"                   Ids                                 
            |> DynObj.withOptionalProperty                   "values"                Values                              
            |> DynObj.withOptionalProperty                   "labels"                Labels                              
            |> DynObj.withOptionalProperty                   "dlabel"                DLabel                              
            |> DynObj.withOptionalProperty                   "label0"                Label0                              
            |> DynObj.withOptionalSingleOrMultiProperty      "pull"                  (Pull, MultiPull)                   
            |> DynObj.withOptionalSingleOrMultiProperty      "text"                  (Text, MultiText)                   
            |> DynObj.withOptionalSingleOrMultiPropertyBy    "textposition"          (TextPosition, MultiTextPosition)   StyleParam.TextPosition.convert
            |> DynObj.withOptionalSingleOrMultiProperty      "texttemplate"          (TextTemplate, MultiTextTemplate)   
            |> DynObj.withOptionalSingleOrMultiProperty      "hovertext"             (HoverText, MultiHoverText)         
            |> DynObj.withOptionalPropertyBy                 "hoverinfo"             HoverInfo                           StyleParam.HoverInfo.convert
            |> DynObj.withOptionalSingleOrMultiProperty      "hovertemplate"         (HoverTemplate, MultiHoverTemplate) 
            |> DynObj.withOptionalProperty                   "meta"                  Meta                                
            |> DynObj.withOptionalProperty                   "customdata"            CustomData                          
            |> DynObj.withOptionalProperty                   "domain"                Domain                              
            |> DynObj.withOptionalProperty                   "automargin"            AutoMargin                          
            |> DynObj.withOptionalProperty                   "marker"                Marker                              
            |> DynObj.withOptionalProperty                   "textfont"              TextFont                            
            |> DynObj.withOptionalPropertyBy                 "textinfo"              TextInfo                            StyleParam.TextInfo.convert
            |> DynObj.withOptionalPropertyBy                 "direction"             Direction                           StyleParam.Direction.convert
            |> DynObj.withOptionalProperty                   "hole"                  Hole                                
            |> DynObj.withOptionalProperty                   "hoverlabel"            HoverLabel                          
            |> DynObj.withOptionalProperty                   "insidetextfont"        InsideTextFont                      
            |> DynObj.withOptionalPropertyBy                 "insidetextorientation" InsideTextOrientation               StyleParam.InsideTextOrientation.convert
            |> DynObj.withOptionalProperty                   "outsidetextfont"       OutsideTextFont         
            |> DynObj.withOptionalProperty                   "rotation"              Rotation                
            |> DynObj.withOptionalProperty                   "scalegroup"            ScaleGroup              
            |> DynObj.withOptionalProperty                   "sort"                  Sort                    
            |> DynObj.withOptionalProperty                   "uirevision"            UIRevision              

    /// <summary>
    /// Creates a function that applies the styles of a funnel area chart to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Title">Sets the title of this trace.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Opacity">Sets the opacity of the trace.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="Values">Sets the values of the sectors. If omitted, we count occurrences of each label.</param>
    /// <param name="Labels">Sets the sector labels. If `labels` entries are duplicated, we sum associated `values` or simply count occurrences if `values` is not provided. For other array attributes (including color) we use the first non-empty entry among all occurrences of the label.</param>
    /// <param name="DLabel">Sets the label step. See `label0` for more info.</param>
    /// <param name="Label0">Alternate to `labels`. Builds a numeric set of labels. Use with `dlabel` where `label0` is the starting label and `dlabel` the step.</param>
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
    /// <param name="Domain">Sets the domain of this trace.</param>
    /// <param name="Marker">Sets the marker of this trace.</param>
    /// <param name="TextFont">ets the text font of this trace.</param>
    /// <param name="TextInfo">Determines which trace information appear on the graph.</param>
    /// <param name="AspectRatio">Sets the ratio between height and width</param>
    /// <param name="BaseRatio">Sets the ratio between bottom length and maximum top length.</param>
    /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
    /// <param name="InsideTextFont">Sets the font used for `textinfo` lying inside the sector.</param>
    /// <param name="ScaleGroup">If there are multiple pie charts that should be sized according to their totals, link them by providing a non-empty group id here shared by every trace in the same group.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member FunnelArea
        (
            ?Name: string,
            ?Title: Title,
            ?Visible: StyleParam.Visible,
            ?ShowLegend: bool,
            ?Legend: StyleParam.SubPlotId,
            ?LegendRank: int,
            ?LegendGroup: string,
            ?LegendGroupTitle: Title,
            ?Opacity: float,
            ?Ids: seq<#IConvertible>,
            ?Values: seq<#IConvertible>,
            ?Labels: seq<#IConvertible>,
            ?DLabel: #IConvertible,
            ?Label0: #IConvertible,
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
            ?Meta: seq<#IConvertible>,
            ?CustomData: seq<#IConvertible>,
            ?Domain: Domain,
            ?Marker: Marker,
            ?TextFont: Font,
            ?TextInfo: StyleParam.TextInfo,
            ?AspectRatio: float,
            ?BaseRatio: float,
            ?HoverLabel: Hoverlabel,
            ?InsideTextFont: Font,
            ?ScaleGroup: string,
            ?UIRevision: string
        ) =
        fun (trace: ('T :> Trace)) ->
            trace
            |> DynObj.withOptionalProperty                   "name"            Name                                
            |> DynObj.withOptionalProperty                   "title"           Title                               
            |> DynObj.withOptionalPropertyBy                 "visible"         Visible                             StyleParam.Visible.convert
            |> DynObj.withOptionalProperty                   "showlegend"      ShowLegend                          
            |> DynObj.withOptionalPropertyBy                 "legend"          Legend                              StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty                   "legendrank"      LegendRank                          
            |> DynObj.withOptionalProperty                   "legendgroup"     LegendGroup                         
            |> DynObj.withOptionalProperty                   "legendgrouptitle"LegendGroupTitle                    
            |> DynObj.withOptionalProperty                   "opacity"         Opacity                             
            |> DynObj.withOptionalProperty                   "ids"             Ids                                 
            |> DynObj.withOptionalProperty                   "values"          Values                              
            |> DynObj.withOptionalProperty                   "labels"          Labels                              
            |> DynObj.withOptionalProperty                   "dlabel"          DLabel                              
            |> DynObj.withOptionalProperty                   "label0"          Label0                              
            |> DynObj.withOptionalSingleOrMultiProperty      "text"            (Text, MultiText)                   
            |> DynObj.withOptionalSingleOrMultiPropertyBy    "textposition"    (TextPosition, MultiTextPosition)   StyleParam.TextPosition.convert
            |> DynObj.withOptionalSingleOrMultiProperty      "texttemplate"    (TextTemplate, MultiTextTemplate)   
            |> DynObj.withOptionalSingleOrMultiProperty      "hovertext"       (HoverText, MultiHoverText)         
            |> DynObj.withOptionalPropertyBy                 "hoverinfo"       HoverInfo                           StyleParam.HoverInfo.convert
            |> DynObj.withOptionalSingleOrMultiProperty      "hovertemplate"   (HoverTemplate, MultiHoverTemplate) 
            |> DynObj.withOptionalProperty                   "meta"            Meta                                
            |> DynObj.withOptionalProperty                   "customdata"      CustomData                          
            |> DynObj.withOptionalProperty                   "domain"          Domain                              
            |> DynObj.withOptionalProperty                   "marker"          Marker                              
            |> DynObj.withOptionalProperty                   "textfont"        TextFont                            
            |> DynObj.withOptionalPropertyBy                 "textinfo"        TextInfo                            StyleParam.TextInfo.convert
            |> DynObj.withOptionalProperty                   "aspectratio"     AspectRatio                         
            |> DynObj.withOptionalProperty                   "baseratio"       BaseRatio                           
            |> DynObj.withOptionalProperty                   "hoverlabel"      HoverLabel                          
            |> DynObj.withOptionalProperty                   "insidetextfont"  InsideTextFont                      
            |> DynObj.withOptionalProperty                   "scalegroup"      ScaleGroup                          
            |> DynObj.withOptionalProperty                   "uirevision"      UIRevision                          

    /// <summary>
    /// Creates a function that applies the styles of a sunburst chart to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Title">Sets the title of this trace.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Opacity">Sets the opacity of the trace.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="Parents">Sets the parent sectors for each of the sectors. Empty string items '' are understood to reference the root node in the hierarchy. If `ids` is filled, `parents` items are understood to be "ids" themselves. When `ids` is not set, plotly attempts to find matching items in `labels`, but beware they must be unique.</param>
    /// <param name="Values">Sets the values associated with each of the sectors. Use with `branchvalues` to determine how the values are summed.</param>
    /// <param name="Labels">Sets the labels of each of the sectors.</param>
    /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="TextTemplate">Template string used for rendering the information text that appear on points. Note that this will override `textinfo`. Variables are inserted using %{variable}, for example "y: %{y}". Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. Every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available.</param>
    /// <param name="MultiTextTemplate">Template string used for rendering the information text that appear on points. Note that this will override `textinfo`. Variables are inserted using %{variable}, for example "y: %{y}". Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. Every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available.</param>
    /// <param name="HoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="MultiHoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
    /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="MultiHoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="Domain">Sets the domain of this trace.</param>
    /// <param name="Marker">Sets the marker of this trace.</param>
    /// <param name="TextFont">ets the text font of this trace.</param>
    /// <param name="TextInfo">Determines which trace information appear on the graph.</param>
    /// <param name="BranchValues">Determines how the items in `values` are summed. When set to "total", items in `values` are taken to be value of all its descendants. When set to "remainder", items in `values` corresponding to the root and the branches sectors are taken to be the extra part not part of the sum of the values at their leaves.</param>
    /// <param name="Count">Determines default for `values` when it is not provided, by inferring a 1 for each of the "leaves" and/or "branches", otherwise 0.</param>
    /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
    /// <param name="InsideTextFont">Sets the font used for `textinfo` lying inside the sector.</param>
    /// <param name="InsideTextOrientation">Controls the orientation of the text inside chart sectors. When set to "auto", text may be oriented in any direction in order to be as big as possible in the middle of a sector. The "horizontal" option orients text to be parallel with the bottom of the chart, and may make text smaller in order to achieve that goal. The "radial" option orients text along the radius of the sector. The "tangential" option orients text perpendicular to the radius of the sector.</param>
    /// <param name="OutsideTextFont">Sets the font used for `textinfo` lying outside the sector.</param>
    /// <param name="Root">Sets the styles for the root of this trace.</param>
    /// <param name="Leaf">Sets the styles for the leaves of this trace.</param>
    /// <param name="Level">Sets the level from which this trace hierarchy is rendered. Set `level` to `''` to start from the root node in the hierarchy. Must be an "id" if `ids` is filled in, otherwise plotly attempts to find a matching item in `labels`.</param>
    /// <param name="MaxDepth">Sets the number of rendered sectors from any given `level`. Set `maxdepth` to "-1" to render all the levels in the hierarchy.</param>
    /// <param name="Rotation">Rotates the whole diagram counterclockwise by some angle. By default the first slice starts at 3 o'clock.</param>
    /// <param name="Sort">Determines whether or not the sectors are reordered from largest to smallest.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member Sunburst
        (
            ?Name: string,
            ?Title: Title,
            ?Visible: StyleParam.Visible,
            ?ShowLegend: bool,
            ?Legend: StyleParam.SubPlotId,
            ?LegendGroup: string,
            ?LegendRank: int,
            ?LegendGroupTitle: Title,
            ?Opacity: float,
            ?Ids: seq<#IConvertible>,
            ?Parents: seq<#IConvertible>,
            ?Values: seq<#IConvertible>,
            ?Labels: seq<#IConvertible>,
            ?Text: #IConvertible,
            ?MultiText: seq<#IConvertible>,
            ?TextTemplate: string,
            ?MultiTextTemplate: seq<string>,
            ?HoverText: string,
            ?MultiHoverText: seq<string>,
            ?HoverInfo: StyleParam.HoverInfo,
            ?HoverTemplate: string,
            ?MultiHoverTemplate: seq<string>,
            ?Meta: seq<#IConvertible>,
            ?CustomData: seq<#IConvertible>,
            ?Domain: Domain,
            ?Marker: Marker,
            ?TextFont: Font,
            ?TextInfo: StyleParam.TextInfo,
            ?BranchValues: StyleParam.BranchValues,
            ?Count: string,
            ?HoverLabel: Hoverlabel,
            ?InsideTextFont: Font,
            ?InsideTextOrientation: StyleParam.InsideTextOrientation,
            ?OutsideTextFont: Font,
            ?Root: SunburstRoot,
            ?Leaf: SunburstLeaf,
            ?Level: string,
            ?MaxDepth: int,
            ?Rotation: int,
            ?Sort: bool,
            ?UIRevision: string
        ) =
        fun (trace: ('T :> Trace)) ->
            
            trace
            |> DynObj.withOptionalProperty               "name"                    Name                                
            |> DynObj.withOptionalProperty               "title"                   Title                               
            |> DynObj.withOptionalPropertyBy             "visible"                 Visible                             StyleParam.Visible.convert
            |> DynObj.withOptionalProperty               "showlegend"              ShowLegend                          
            |> DynObj.withOptionalPropertyBy             "legend"                  Legend                              StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty               "legendrank"              LegendRank                          
            |> DynObj.withOptionalProperty               "legendgroup"             LegendGroup                         
            |> DynObj.withOptionalProperty               "legendgrouptitle"        LegendGroupTitle                    
            |> DynObj.withOptionalProperty               "opacity"                 Opacity                             
            |> DynObj.withOptionalProperty               "ids"                     Ids                                 
            |> DynObj.withOptionalProperty               "parents"                 Parents                             
            |> DynObj.withOptionalProperty               "values"                  Values                              
            |> DynObj.withOptionalProperty               "labels"                  Labels                              
            |> DynObj.withOptionalSingleOrMultiProperty  "text"                    (Text, MultiText)                   
            |> DynObj.withOptionalSingleOrMultiProperty  "texttemplate"            (TextTemplate, MultiTextTemplate)   
            |> DynObj.withOptionalSingleOrMultiProperty  "hovertext"               (HoverText, MultiHoverText)         
            |> DynObj.withOptionalPropertyBy             "hoverinfo"               HoverInfo                           StyleParam.HoverInfo.convert
            |> DynObj.withOptionalSingleOrMultiProperty  "hovertemplate"           (HoverTemplate, MultiHoverTemplate) 
            |> DynObj.withOptionalProperty               "meta"                    Meta                                
            |> DynObj.withOptionalProperty               "customdata"              CustomData                          
            |> DynObj.withOptionalProperty               "domain"                  Domain                              
            |> DynObj.withOptionalProperty               "marker"                  Marker                              
            |> DynObj.withOptionalProperty               "textfont"                TextFont                            
            |> DynObj.withOptionalPropertyBy             "textinfo"                TextInfo                            StyleParam.TextInfo.convert
            |> DynObj.withOptionalPropertyBy             "branchvalues"            BranchValues                        StyleParam.BranchValues.convert
            |> DynObj.withOptionalProperty               "count"                   Count                               
            |> DynObj.withOptionalProperty               "hoverlabel"              HoverLabel                          
            |> DynObj.withOptionalProperty               "insidetextfont"          InsideTextFont                      
            |> DynObj.withOptionalPropertyBy             "insidetextorientation"   InsideTextOrientation               StyleParam.InsideTextOrientation.convert
            |> DynObj.withOptionalProperty               "outsidetextfont"         OutsideTextFont                     
            |> DynObj.withOptionalProperty               "root"                    Root                                
            |> DynObj.withOptionalProperty               "leaf"                    Leaf                                
            |> DynObj.withOptionalProperty               "level"                   Level                               
            |> DynObj.withOptionalProperty               "maxdepth"                MaxDepth                            
            |> DynObj.withOptionalProperty               "rotation"                Rotation                            
            |> DynObj.withOptionalProperty               "sort"                    Sort                                
            |> DynObj.withOptionalProperty               "uirevision"              UIRevision                          

    /// <summary>
    /// Creates a function that applies the styles of a treemap chart to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Title">Sets the title of this trace.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Opacity">Sets the opacity of the trace.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="Parents">Sets the parent sectors for each of the sectors. Empty string items '' are understood to reference the root node in the hierarchy. If `ids` is filled, `parents` items are understood to be "ids" themselves. When `ids` is not set, plotly attempts to find matching items in `labels`, but beware they must be unique.</param>
    /// <param name="Values">Sets the values associated with each of the sectors. Use with `branchvalues` to determine how the values are summed.</param>
    /// <param name="Labels">Sets the labels of each of the sectors.</param>
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
    /// <param name="Domain">Sets the domain of this trace.</param>
    /// <param name="Marker">Sets the marker of this trace.</param>
    /// <param name="TextFont">ets the text font of this trace.</param>
    /// <param name="TextInfo">Determines which trace information appear on the graph.</param>
    /// <param name="BranchValues">Determines how the items in `values` are summed. When set to "total", items in `values` are taken to be value of all its descendants. When set to "remainder", items in `values` corresponding to the root and the branches sectors are taken to be the extra part not part of the sum of the values at their leaves.</param>
    /// <param name="Count">Determines default for `values` when it is not provided, by inferring a 1 for each of the "leaves" and/or "branches", otherwise 0.</param>
    /// <param name="Tiling">Sets the tiling for this trace.</param>
    /// <param name="PathBar">Sets the path bar for this trace.</param>
    /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
    /// <param name="InsideTextFont">Sets the font used for `textinfo` lying inside the sector.</param>
    /// <param name="OutsideTextFont">Sets the font used for `textinfo` lying outside the sector.</param>
    /// <param name="Root">Sets the styles for the root of this trace.</param>
    /// <param name="Level">Sets the level from which this trace hierarchy is rendered. Set `level` to `''` to start from the root node in the hierarchy. Must be an "id" if `ids` is filled in, otherwise plotly attempts to find a matching item in `labels`.</param>
    /// <param name="MaxDepth">Sets the number of rendered sectors from any given `level`. Set `maxdepth` to "-1" to render all the levels in the hierarchy.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member Treemap
        (
            ?Name: string,
            ?Title: Title,
            ?Visible: StyleParam.Visible,
            ?ShowLegend: bool,
            ?Legend: StyleParam.SubPlotId,
            ?LegendRank: int,
            ?LegendGroup: string,
            ?LegendGroupTitle: Title,
            ?Opacity: float,
            ?Ids: seq<#IConvertible>,
            ?Parents: seq<#IConvertible>,
            ?Values: seq<#IConvertible>,
            ?Labels: seq<#IConvertible>,
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
            ?Meta: seq<#IConvertible>,
            ?CustomData: seq<#IConvertible>,
            ?Domain: Domain,
            ?Marker: Marker,
            ?TextFont: Font,
            ?TextInfo: StyleParam.TextInfo,
            ?BranchValues: StyleParam.BranchValues,
            ?Count: string,
            ?Tiling: TreemapTiling,
            ?PathBar: Pathbar,
            ?HoverLabel: Hoverlabel,
            ?InsideTextFont: Font,
            ?OutsideTextFont: Font,
            ?Root: TreemapRoot,
            ?Level: string,
            ?MaxDepth: int,
            ?UIRevision: string
        ) =
        fun (trace: ('T :> Trace)) ->

            trace
            |> DynObj.withOptionalProperty                   "name"            Name                                
            |> DynObj.withOptionalProperty                   "title"           Title                               
            |> DynObj.withOptionalPropertyBy                 "visible"         Visible                             StyleParam.Visible.convert
            |> DynObj.withOptionalProperty                   "showlegend"      ShowLegend                          
            |> DynObj.withOptionalPropertyBy                 "legend"          Legend                              StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty                   "legendrank"      LegendRank                          
            |> DynObj.withOptionalProperty                   "legendgroup"     LegendGroup                         
            |> DynObj.withOptionalProperty                   "legendgrouptitle"LegendGroupTitle                    
            |> DynObj.withOptionalProperty                   "opacity"         Opacity                             
            |> DynObj.withOptionalProperty                   "ids"             Ids                                 
            |> DynObj.withOptionalProperty                   "parents"         Parents                             
            |> DynObj.withOptionalProperty                   "values"          Values                              
            |> DynObj.withOptionalProperty                   "labels"          Labels                              
            |> DynObj.withOptionalSingleOrMultiProperty      "text"            (Text, MultiText)                   
            |> DynObj.withOptionalSingleOrMultiPropertyBy    "textposition"    (TextPosition, MultiTextPosition)   StyleParam.TextPosition.convert
            |> DynObj.withOptionalSingleOrMultiProperty      "texttemplate"    (TextTemplate, MultiTextTemplate)   
            |> DynObj.withOptionalSingleOrMultiProperty      "hovertext"       (HoverText, MultiHoverText)         
            |> DynObj.withOptionalPropertyBy                 "hoverinfo"       HoverInfo                           StyleParam.HoverInfo.convert
            |> DynObj.withOptionalSingleOrMultiProperty      "hovertemplate"   (HoverTemplate, MultiHoverTemplate) 
            |> DynObj.withOptionalProperty                   "meta"            Meta                                
            |> DynObj.withOptionalProperty                   "customdata"      CustomData                          
            |> DynObj.withOptionalProperty                   "domain"          Domain                              
            |> DynObj.withOptionalProperty                   "marker"          Marker                              
            |> DynObj.withOptionalProperty                   "textfont"        TextFont                            
            |> DynObj.withOptionalPropertyBy                 "textinfo"        TextInfo                            StyleParam.TextInfo.convert
            |> DynObj.withOptionalPropertyBy                 "branchvalues"    BranchValues                        StyleParam.BranchValues.convert
            |> DynObj.withOptionalProperty                   "count"           Count                               
            |> DynObj.withOptionalProperty                   "tiling"          Tiling                              
            |> DynObj.withOptionalProperty                   "pathbar"         PathBar                             
            |> DynObj.withOptionalProperty                   "hoverlabel"      HoverLabel                          
            |> DynObj.withOptionalProperty                   "insidetextfont"  InsideTextFont                      
            |> DynObj.withOptionalProperty                   "outsidetextfont" OutsideTextFont                     
            |> DynObj.withOptionalProperty                   "root"            Root                                
            |> DynObj.withOptionalProperty                   "level"           Level                               
            |> DynObj.withOptionalProperty                   "maxdepth"        MaxDepth                            
            |> DynObj.withOptionalProperty                   "uirevision"      UIRevision                          

    /// <summary>
    /// Creates a function that applies the styles of a parallel coordinates plot to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="Dimensions">Sets the dimensions of this trace.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="Domain">Sets the domain of this trace.</param>
    /// <param name="Line">Sets the line of this trace.</param>
    /// <param name="Unselected">Sets the styles of unselected lines in this trace.</param>
    /// <param name="LabelAngle">Sets the angle of the labels with respect to the horizontal. For example, a `tickangle` of -90 draws the labels vertically. Tilted labels with "labelangle" may be positioned better inside margins when `labelposition` is set to "bottom".</param>
    /// <param name="LabelFont">Sets the label font of this trace.</param>
    /// <param name="LabelSide">Specifies the location of the `label`. "top" positions labels above, next to the title "bottom" positions labels below the graph Tilted labels with "labelangle" may be positioned better inside margins when `labelposition` is set to "bottom".</param>
    /// <param name="RangeFont">Sets the range font of this trace.</param>
    /// <param name="TickFont">Sets the tick font of this trace.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member ParallelCoord
        (
            ?Name: string,
            ?Visible: StyleParam.Visible,
            ?Legend: StyleParam.SubPlotId,
            ?LegendRank: int,
            ?LegendGroup: string,
            ?LegendGroupTitle: Title,
            ?Ids: seq<#IConvertible>,
            ?Dimensions: seq<Dimension>,
            ?Meta: seq<#IConvertible>,
            ?CustomData: seq<#IConvertible>,
            ?Domain: Domain,
            ?Line: Line,
            ?Unselected: TraceSelection,
            ?LabelAngle: int,
            ?LabelFont: Font,
            ?LabelSide: StyleParam.Side,
            ?RangeFont: Font,
            ?TickFont: Font,
            ?UIRevision: string
        ) =
        fun (trace: ('T :> Trace)) ->
            trace
            |> DynObj.withOptionalProperty   "name"             Name               
            |> DynObj.withOptionalPropertyBy "visible"          Visible            StyleParam.Visible.convert
            |> DynObj.withOptionalPropertyBy "legend"           Legend             StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty   "legendrank"       LegendRank         
            |> DynObj.withOptionalProperty   "legendgroup"      LegendGroup        
            |> DynObj.withOptionalProperty   "legendgrouptitle" LegendGroupTitle   
            |> DynObj.withOptionalProperty   "ids"              Ids                
            |> DynObj.withOptionalProperty   "dimensions"       Dimensions         
            |> DynObj.withOptionalProperty   "meta"             Meta               
            |> DynObj.withOptionalProperty   "customdata"       CustomData         
            |> DynObj.withOptionalProperty   "domain"           Domain             
            |> DynObj.withOptionalProperty   "line"             Line               
            |> DynObj.withOptionalProperty   "unselected"       Unselected         
            |> DynObj.withOptionalProperty   "labelangle"       LabelAngle         
            |> DynObj.withOptionalProperty   "labelfont"        LabelFont          
            |> DynObj.withOptionalProperty   "labelside"        LabelSide          
            |> DynObj.withOptionalProperty   "rangefont"        RangeFont          
            |> DynObj.withOptionalProperty   "tickfont "        TickFont           
            |> DynObj.withOptionalProperty   "uirevision"       UIRevision         

    /// <summary>
    /// Creates a function that applies the styles of a parallel categories plot to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Counts">The number of observations represented by each state. Defaults to 1 so that each state represents one observation</param>
    /// <param name="Dimensions">Sets the dimensions of this trace</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
    /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="MultiHoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="Domain">Sets the domain of this trace.</param>
    /// <param name="Line">Sets the line of this trace.</param>
    /// <param name="Arrangement">Sets the drag interaction mode for categories and dimensions. If `perpendicular`, the categories can only move along a line perpendicular to the paths. If `freeform`, the categories can freely move on the plane. If `fixed`, the categories and dimensions are stationary.</param>
    /// <param name="BundleColors">Sort paths so that like colors are bundled together within each category.</param>
    /// <param name="SortPaths">Sets the path sorting algorithm. If `forward`, sort paths based on dimension categories from left to right. If `backward`, sort paths based on dimensions categories from right to left.</param>
    /// <param name="Hoveron">Sets the hover interaction mode for the parcats diagram. If `category`, hover interaction take place per category. If `color`, hover interactions take place per color per category. If `dimension`, hover interactions take place across all categories per dimension.</param>
    /// <param name="LabelFont">Sets the label font of this trace.</param>
    /// <param name="TickFont">Sets the tick font of this trace.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member ParallelCategories
        (
            ?Name: string,
            ?Visible: StyleParam.Visible,
            ?Legend: StyleParam.SubPlotId,
            ?LegendGroup: string,
            ?LegendGroupTitle: Title,
            ?Counts: int,
            ?Dimensions: seq<Dimension>,
            ?HoverInfo: StyleParam.HoverInfo,
            ?HoverTemplate: string,
            ?MultiHoverTemplate: seq<string>,
            ?Meta: seq<#IConvertible>,
            ?Domain: Domain,
            ?Line: Line,
            ?Arrangement: StyleParam.CategoryArrangement,
            ?BundleColors: bool,
            ?SortPaths: StyleParam.SortAlgorithm,
            ?Hoveron: StyleParam.HoverOn,
            ?LabelFont: Font,
            ?TickFont: Font,
            ?UIRevision: string
        ) =
        fun (trace: ('T :> Trace)) ->
            
            trace
            |> DynObj.withOptionalProperty               "name"            Name                                
            |> DynObj.withOptionalPropertyBy             "visible"         Visible                             StyleParam.Visible.convert
            |> DynObj.withOptionalPropertyBy             "legend"          Legend                              StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty               "legendgroup"     LegendGroup                         
            |> DynObj.withOptionalProperty               "legendgrouptitle"LegendGroupTitle                    
            |> DynObj.withOptionalProperty               "counts"          Counts                              
            |> DynObj.withOptionalProperty               "dimensions"      Dimensions                          
            |> DynObj.withOptionalPropertyBy             "hoverinfo"       HoverInfo                           StyleParam.HoverInfo.convert
            |> DynObj.withOptionalSingleOrMultiProperty  "hovertemplate"   (HoverTemplate, MultiHoverTemplate) 
            |> DynObj.withOptionalProperty               "meta"            Meta                                
            |> DynObj.withOptionalProperty               "domain"          Domain                              
            |> DynObj.withOptionalProperty               "line"            Line                                
            |> DynObj.withOptionalPropertyBy             "arrangement"     Arrangement                         StyleParam.CategoryArrangement.convert
            |> DynObj.withOptionalProperty               "bundlecolors"    BundleColors                        
            |> DynObj.withOptionalPropertyBy             "sortpaths"       SortPaths                           StyleParam.SortAlgorithm.convert
            |> DynObj.withOptionalPropertyBy             "hoveron"         Hoveron                             StyleParam.HoverOn.convert
            |> DynObj.withOptionalProperty               "labelfont"       LabelFont                           
            |> DynObj.withOptionalProperty               "tickfont "       TickFont                            
            |> DynObj.withOptionalProperty               "uirevision"      UIRevision                          

    /// <summary>
    /// Creates a function that applies the styles of a sankey chart to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired. Note that this attribute is superseded by `node.hoverinfo` and `node.hoverinfo` for nodes and links respectively.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="Domain">Sets the domain of this trace.</param>
    /// <param name="Orientation">Sets the orientation of the Sankey diagram.</param>
    /// <param name="Node">The nodes of the Sankey plot.</param>
    /// <param name="Link">The links of the Sankey plot.</param>
    /// <param name="TextFont">Sets the text font of this trace.</param>
    /// <param name="SelectedPoints">Array containing integer indices of selected points. Has an effect only for traces that support selections. Note that an empty array means an empty selection where the `unselected` are turned on for all points, whereas, any other non-array values means no selection all where the `selected` and `unselected` styles have no effect.</param>
    /// <param name="Arrangement">If value is `snap` (the default), the node arrangement is assisted by automatic snapping of elements to preserve space between nodes specified via `nodepad`. If value is `perpendicular`, the nodes can only move along a line perpendicular to the flow. If value is `freeform`, the nodes can freely move on the plane. If value is `fixed`, the nodes are stationary.</param>
    /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
    /// <param name="ValueFormat">Sets the value formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.</param>
    /// <param name="ValueSuffix">Adds a unit to follow the value in the hover tooltip. Add a space if a separation is necessary from the value.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member Sankey
        (
            ?Name: string,
            ?Visible: StyleParam.Visible,
            ?Legend: StyleParam.SubPlotId,
            ?LegendRank: int,
            ?LegendGroup: string,
            ?LegendGroupTitle: Title,
            ?Ids: seq<#IConvertible>,
            ?HoverInfo: StyleParam.HoverInfo,
            ?Meta: seq<#IConvertible>,
            ?CustomData: seq<#IConvertible>,
            ?Domain: Domain,
            ?Orientation: StyleParam.Orientation,
            ?Node: SankeyNodes,
            ?Link: SankeyLinks,
            ?TextFont: Font,
            ?SelectedPoints: seq<#IConvertible>,
            ?Arrangement: StyleParam.CategoryArrangement,
            ?HoverLabel: Hoverlabel,
            ?ValueFormat: string,
            ?ValueSuffix: string,
            ?UIRevision: string
        ) =
        fun (trace: ('T :> Trace)) ->

            trace
            |> DynObj.withOptionalProperty   "name"            Name                
            |> DynObj.withOptionalPropertyBy "visible"         Visible             StyleParam.Visible.convert
            |> DynObj.withOptionalPropertyBy "legend"          Legend              StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty   "legendrank"      LegendRank          
            |> DynObj.withOptionalProperty   "legendgroup"     LegendGroup         
            |> DynObj.withOptionalProperty   "legendgrouptitle"LegendGroupTitle    
            |> DynObj.withOptionalProperty   "ids"             Ids                 
            |> DynObj.withOptionalPropertyBy "hoverinfo"       HoverInfo           StyleParam.HoverInfo.convert
            |> DynObj.withOptionalProperty   "meta"            Meta                
            |> DynObj.withOptionalProperty   "customdata"      CustomData          
            |> DynObj.withOptionalProperty   "domain"          Domain              
            |> DynObj.withOptionalPropertyBy "orientation"     Orientation         StyleParam.Orientation.convert
            |> DynObj.withOptionalProperty   "node"            Node                
            |> DynObj.withOptionalProperty   "link"            Link                
            |> DynObj.withOptionalProperty   "textfont"        TextFont            
            |> DynObj.withOptionalProperty   "selectedpoints"  SelectedPoints      
            |> DynObj.withOptionalPropertyBy "arrangement"     Arrangement         StyleParam.CategoryArrangement.convert
            |> DynObj.withOptionalProperty   "hoverlabel"      HoverLabel          
            |> DynObj.withOptionalProperty   "valueformat"     ValueFormat         
            |> DynObj.withOptionalProperty   "valuesuffix"     ValueSuffix         
            |> DynObj.withOptionalProperty   "uirevision"      UIRevision          


    /// <summary>
    /// Creates a function that applies the styles of a table to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="ColumnOrder">Specifies the rendered order of the data columns; for example, a value `2` at position `0` means that column index `0` in the data will be rendered as the third column, as columns have an index base of zero.</param>
    /// <param name="ColumnWidth">The width of columns expressed as a ratio. Columns fill the available width in proportion of their specified column widths.</param>
    /// <param name="MultiColumnWidth">The width of columns expressed as a ratio. Columns fill the available width in proportion of their specified column widths.</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="Domain">Sets the domain of this trace.</param>
    /// <param name="Cells">Sets the table cells of this trace.</param>
    /// <param name="Header">Sets the table header of this trace.</param>
    /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member Table
        (
            ?Name: string,
            ?Visible: StyleParam.Visible,
            ?Legend: StyleParam.SubPlotId,
            ?LegendRank: bool,
            ?LegendGroupTitle: Title,
            ?Ids: seq<#IConvertible>,
            ?ColumnOrder: seq<int>,
            ?ColumnWidth: float,
            ?MultiColumnWidth: seq<float>,
            ?HoverInfo: StyleParam.HoverInfo,
            ?Meta: seq<#IConvertible>,
            ?CustomData: seq<#IConvertible>,
            ?Domain: Domain,
            ?Cells: TableCells,
            ?Header: TableHeader,
            ?HoverLabel: Hoverlabel,
            ?UIRevision: string
        ) =
        fun (trace: ('T :> Trace)) ->
            trace
            |> DynObj.withOptionalProperty               "name"            Name                            
            |> DynObj.withOptionalPropertyBy             "visible"         Visible                         StyleParam.Visible.convert
            |> DynObj.withOptionalPropertyBy             "legend"          Legend                          StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty               "legendrank"      LegendRank                      
            |> DynObj.withOptionalProperty               "legendgrouptitle"LegendGroupTitle                
            |> DynObj.withOptionalProperty               "ids"             Ids                             
            |> DynObj.withOptionalProperty               "columnorder"     ColumnOrder                     
            |> DynObj.withOptionalSingleOrMultiProperty  "columnwidth"     (ColumnWidth, MultiColumnWidth) 
            |> DynObj.withOptionalPropertyBy             "hoverinfo"       HoverInfo                       StyleParam.HoverInfo.convert
            |> DynObj.withOptionalProperty               "meta"            Meta                            
            |> DynObj.withOptionalProperty               "customdata"      CustomData                      
            |> DynObj.withOptionalProperty               "domain"          Domain                          
            |> DynObj.withOptionalProperty               "cells"           Cells                           
            |> DynObj.withOptionalProperty               "header"          Header                          
            |> DynObj.withOptionalProperty               "hoverlabel"      HoverLabel                      
            |> DynObj.withOptionalProperty               "uirevision"      UIRevision                      

    /// <summary>
    /// Creates a function that applies the styles of an indicator to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Title">Sets the title of this trace.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="Mode">Determines how the value is displayed on the graph. `number` displays the value numerically in text. `delta` displays the difference to a reference value in text. Finally, `gauge` displays the value graphically on an axis.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="Value">Sets the number to be displayed.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="Domain">Sets the domain of this trace.</param>
    /// <param name="Align">Sets the horizontal alignment of the `text` within the box. Note that this attribute has no effect if an angular gauge is displayed: in this case, it is always centered</param>
    /// <param name="Delta">Sets the styling options for delta display.</param>
    /// <param name="Number">Sets the styling options for number display.</param>
    /// <param name="Gauge">Sets the styling options for gauge display.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member Indicator
        (
            ?Name: string,
            ?Title: string,
            ?Visible: StyleParam.Visible,
            ?Legend: StyleParam.SubPlotId,
            ?LegendRank: int,
            ?LegendGroupTitle: Title,
            ?Mode: StyleParam.IndicatorMode,
            ?Ids: seq<#IConvertible>,
            ?Value: #IConvertible,
            ?Meta: string,
            ?CustomData: seq<#IConvertible>,
            ?Domain: Domain,
            ?Align: StyleParam.IndicatorAlignment,
            ?Delta: IndicatorDelta,
            ?Number: IndicatorNumber,
            ?Gauge: IndicatorGauge,
            ?UIRevision: string
        ) =
        fun (trace: #Trace) ->
            
            trace
            |> DynObj.withOptionalProperty   "name"            Name                
            |> DynObj.withOptionalProperty   "title"           Title               
            |> DynObj.withOptionalPropertyBy "visible"         Visible             StyleParam.Visible.convert
            |> DynObj.withOptionalPropertyBy "legend"          Legend              StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty   "legendrank"      LegendRank          
            |> DynObj.withOptionalProperty   "legendgrouptitle"LegendGroupTitle    
            |> DynObj.withOptionalPropertyBy "mode"            Mode                StyleParam.IndicatorMode.convert
            |> DynObj.withOptionalProperty   "ids"             Ids                 
            |> DynObj.withOptionalProperty   "value"           Value               
            |> DynObj.withOptionalProperty   "meta"            Meta                
            |> DynObj.withOptionalProperty   "customdata"      CustomData          
            |> DynObj.withOptionalProperty   "domain"          Domain              
            |> DynObj.withOptionalPropertyBy "align"           Align               StyleParam.IndicatorAlignment.convert
            |> DynObj.withOptionalProperty   "delta"           Delta               
            |> DynObj.withOptionalProperty   "number"          Number              
            |> DynObj.withOptionalProperty   "gauge"           Gauge               
            |> DynObj.withOptionalProperty   "uirevision"      UIRevision          

    /// <summary>
    /// Creates a function that applies the styles of an icicle chart to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="Opacity">Sets the opacity of the trace.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="Parents">Sets the parent sectors for each of the sectors. Empty string items '' are understood to reference the root node in the hierarchy. If `ids` is filled, `parents` items are understood to be "ids" themselves. When `ids` is not set, plotly attempts to find matching items in `labels`, but beware they must be unique.</param>
    /// <param name="Values">Sets the values associated with each of the sectors. Use with `branchvalues` to determine how the values are summed.</param>
    /// <param name="Labels">Sets the labels of each of the sectors.</param>
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
    /// <param name="Domain">Sets the domain of this trace.</param>
    /// <param name="Marker">Sets the marker of this trace.</param>
    /// <param name="TextFont">ets the text font of this trace.</param>
    /// <param name="TextInfo">Determines which trace information appear on the graph.</param>
    /// <param name="BranchValues">Determines how the items in `values` are summed. When set to "total", items in `values` are taken to be value of all its descendants. When set to "remainder", items in `values` corresponding to the root and the branches sectors are taken to be the extra part not part of the sum of the values at their leaves.</param>
    /// <param name="Count">Determines default for `values` when it is not provided, by inferring a 1 for each of the "leaves" and/or "branches", otherwise 0.</param>
    /// <param name="Tiling">Sets the tiling for this trace.</param>
    /// <param name="PathBar">Sets the path bar for this trace.</param>
    /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
    /// <param name="InsideTextFont">Sets the font used for `textinfo` lying inside the sector.</param>
    /// <param name="OutsideTextFont">Sets the font used for `textinfo` lying outside the sector.</param>
    /// <param name="Root">Sets the styles for the root of this trace.</param>
    /// <param name="Leaf">Sets the leaves for the root of this trace.</param>
    /// <param name="Level">Sets the level from which this trace hierarchy is rendered. Set `level` to `''` to start from the root node in the hierarchy. Must be an "id" if `ids` is filled in, otherwise plotly attempts to find a matching item in `labels`.</param>
    /// <param name="MaxDepth">Sets the number of rendered sectors from any given `level`. Set `maxdepth` to "-1" to render all the levels in the hierarchy.</param>
    /// <param name="Sort">Determines whether or not the sectors are reordered from largest to smallest.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member Icicle
        (
            ?Name: string,
            ?Visible: StyleParam.Visible,
            ?Legend: StyleParam.SubPlotId,
            ?LegendRank: int,
            ?LegendGroupTitle: Title,
            ?Opacity: float,
            ?Ids: seq<#IConvertible>,
            ?Parents: seq<#IConvertible>,
            ?Values: seq<#IConvertible>,
            ?Labels: seq<#IConvertible>,
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
            ?Domain: Domain,
            ?Marker: Marker,
            ?TextFont: Font,
            ?TextInfo: StyleParam.TextInfo,
            ?BranchValues: StyleParam.BranchValues,
            ?Count: StyleParam.IcicleCount,
            ?Tiling: IcicleTiling,
            ?PathBar: Pathbar,
            ?HoverLabel: Hoverlabel,
            ?InsideTextFont: Font,
            ?OutsideTextFont: Font,
            ?Root: IcicleRoot,
            ?Leaf: IcicleLeaf,
            ?Level: string,
            ?MaxDepth: int,
            ?Sort: bool,
            ?UIRevision: string
        ) =
        fun (trace: #Trace) ->

            trace
            |> DynObj.withOptionalProperty                   "name"            Name                                
            |> DynObj.withOptionalPropertyBy                 "visible"         Visible                             StyleParam.Visible.convert
            |> DynObj.withOptionalPropertyBy                 "legend"          Legend                              StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty                   "legendrank"      LegendRank                          
            |> DynObj.withOptionalProperty                   "legendgrouptitle"LegendGroupTitle                    
            |> DynObj.withOptionalProperty                   "opacity"         Opacity                             
            |> DynObj.withOptionalProperty                   "ids"             Ids                                 
            |> DynObj.withOptionalProperty                   "parents"         Parents                             
            |> DynObj.withOptionalProperty                   "values"          Values                              
            |> DynObj.withOptionalProperty                   "labels"          Labels                              
            |> DynObj.withOptionalSingleOrMultiProperty      "text"            (Text, MultiText)                   
            |> DynObj.withOptionalSingleOrMultiPropertyBy    "textposition"    (TextPosition, MultiTextPosition)   StyleParam.TextPosition.convert
            |> DynObj.withOptionalSingleOrMultiProperty      "texttemplate"    (TextTemplate, MultiTextTemplate)   
            |> DynObj.withOptionalSingleOrMultiProperty      "hovertext"       (HoverText, MultiHoverText)         
            |> DynObj.withOptionalPropertyBy                 "hoverinfo"       HoverInfo                           StyleParam.HoverInfo.convert
            |> DynObj.withOptionalSingleOrMultiProperty      "hovertemplate"   (HoverTemplate, MultiHoverTemplate) 
            |> DynObj.withOptionalProperty                   "meta"            Meta                                
            |> DynObj.withOptionalProperty                   "customdata"      CustomData                          
            |> DynObj.withOptionalProperty                   "domain"          Domain                              
            |> DynObj.withOptionalProperty                   "marker"          Marker                              
            |> DynObj.withOptionalProperty                   "textfont"        TextFont                            
            |> DynObj.withOptionalPropertyBy                 "textinfo"        TextInfo                            StyleParam.TextInfo.convert
            |> DynObj.withOptionalPropertyBy                 "branchvalues"    BranchValues                        StyleParam.BranchValues.convert
            |> DynObj.withOptionalPropertyBy                 "count"           Count                               StyleParam.IcicleCount.convert
            |> DynObj.withOptionalProperty                   "tiling"          Tiling                              
            |> DynObj.withOptionalProperty                   "pathbar"         PathBar                             
            |> DynObj.withOptionalProperty                   "hoverlabel"      HoverLabel                          
            |> DynObj.withOptionalProperty                   "insidetextfont"  InsideTextFont                      
            |> DynObj.withOptionalProperty                   "outsidetextfont" OutsideTextFont                     
            |> DynObj.withOptionalProperty                   "root"            Root                                
            |> DynObj.withOptionalProperty                   "leaf"            Leaf                                
            |> DynObj.withOptionalProperty                   "level"           Level                               
            |> DynObj.withOptionalProperty                   "maxdepth"        MaxDepth                            
            |> DynObj.withOptionalProperty                   "sort"            Sort                                
            |> DynObj.withOptionalProperty                   "uirevision"      UIRevision                          