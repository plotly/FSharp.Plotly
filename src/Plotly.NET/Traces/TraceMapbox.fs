namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open System
open System.Runtime.InteropServices


//Figures can include two different types of map subplots: geo subplots for outline maps and mapbox subplots for tile maps.
///The following trace types support attributes named geo or mapbox, whose values must refer to corresponding objects in the layout
///i.e. geo="geo2" etc. Note that attributes such as layout.geo2 and layout.mapbox etc do not have to be explicitly defined, in which
///case default values will be inferred. Multiple traces of a compatible type can be placed on the same subplot.
///
/// The following trace types are compatible with geo subplots via the geo attribute:
///
/// - scattergeo, which can be used to draw individual markers, line and curves and filled areas on outline maps
///
/// - choropleth: colored polygons on outline maps
///
/// The following trace types are compatible with mapbox subplots via the mapbox attribute:
///
/// - scattermapbox, which can be used to draw individual markers, lines and curves and filled areas on tile maps
///
/// - choroplethmapbox: colored polygons on tile maps
///
/// - densitymapbox: density heatmaps on tile maps

type TraceMapbox(traceTypeName) =

    inherit Trace(traceTypeName)

    ///initializes a trace of type "scattermapbox" applying the given trace styling function
    static member initScatterMapbox(applyStyle: TraceMapbox -> TraceMapbox) =
        TraceMapbox("scattermapbox") |> applyStyle

    ///initializes a trace of type "choroplethmapbox" applying the given trace styling function
    static member initChoroplethMapbox(applyStyle: TraceMapbox -> TraceMapbox) =
        TraceMapbox("choroplethmapbox") |> applyStyle

    ///initializes a trace of type "densitymapbox" applying the given trace styling function
    static member initDensityMapbox(applyStyle: TraceMapbox -> TraceMapbox) =
        TraceMapbox("densitymapbox") |> applyStyle

type TraceMapboxStyle() =

    static member SetMapbox(?MapboxId: StyleParam.SubPlotId) =
        fun (trace: TraceMapbox) ->
            trace |> DynObj.withOptionalPropertyBy "subplot" MapboxId StyleParam.SubPlotId.toString


    /// <summary>
    /// Create a function that applies the styles of a mapbox scatter plot to a Trace object
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
    /// <param name="Lat">Sets the latitude coordinates (in degrees North).</param>
    /// <param name="Lon">Sets the longitude coordinates (in degrees East).</param>
    /// <param name="Cluster">Sets the clustering options for points on this trace.</param>
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
    /// <param name="Below">Determines if this scattermapbox trace's layers are to be inserted before the layer with the specified ID. By default, scattermapbox layers are inserted above all the base layers. To place the scattermapbox layers above every other layer, set `below` to "''".</param>
    /// <param name="ConnectGaps">Determines whether or not gaps (i.e. {nan} or missing values) in the provided data arrays are connected.</param>
    /// <param name="Fill">Sets the area to fill with a solid color. Use with `fillcolor` if not "none". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape.</param>
    /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
    /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member ScatterMapbox
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
            ?Lat: #IConvertible seq,
            ?Lon: #IConvertible seq,
            ?Cluster: MapboxCluster,
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
            ?Below: string,
            ?ConnectGaps: bool,
            ?Fill: StyleParam.Fill,
            ?FillColor: Color,
            ?HoverLabel: Hoverlabel,
            ?UIRevision: string
        ) =
        fun (trace: #Trace) ->

            trace
            |> DynObj.withOptionalProperty                   "name"               Name                                
            |> DynObj.withOptionalPropertyBy                 "visible"            Visible                             StyleParam.Visible.convert
            |> DynObj.withOptionalProperty                   "showlegend"         ShowLegend                          
            |> DynObj.withOptionalProperty                   "legendrank"         LegendRank                          
            |> DynObj.withOptionalProperty                   "legendgroup"        LegendGroup                         
            |> DynObj.withOptionalProperty                   "legendgrouptitle"   LegendGroupTitle                    
            |> DynObj.withOptionalProperty                   "opacity"            Opacity                             
            |> DynObj.withOptionalPropertyBy                 "mode"               Mode                                StyleParam.Mode.convert
            |> DynObj.withOptionalProperty                   "ids"                Ids                                 
            |> DynObj.withOptionalProperty                   "lat"                Lat                                 
            |> DynObj.withOptionalProperty                   "lon"                Lon                                 
            |> DynObj.withOptionalProperty                   "cluster"            Cluster                             
            |> DynObj.withOptionalSingleOrMultiProperty      "text"               (Text, MultiText)                   
            |> DynObj.withOptionalSingleOrMultiPropertyBy    "textposition"       (TextPosition, MultiTextPosition)   StyleParam.TextPosition.convert
            |> DynObj.withOptionalSingleOrMultiProperty      "texttemplate"       (TextTemplate, MultiTextTemplate)   
            |> DynObj.withOptionalSingleOrMultiProperty      "hovertext"          (HoverText, MultiHoverText)         
            |> DynObj.withOptionalPropertyBy                 "hoverinfo"          HoverInfo                           StyleParam.HoverInfo.convert
            |> DynObj.withOptionalSingleOrMultiProperty      "hovertemplate"      (HoverTemplate, MultiHoverTemplate) 
            |> DynObj.withOptionalProperty                   "meta"               Meta                                
            |> DynObj.withOptionalProperty                   "customdata"         CustomData                          
            |> DynObj.withOptionalPropertyBy                 "subplot"            SubPlot                             StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty                   "marker"             Marker                              
            |> DynObj.withOptionalProperty                   "line"               Line                                
            |> DynObj.withOptionalProperty                   "textfont"           TextFont                            
            |> DynObj.withOptionalProperty                   "selectedpoints"     SelectedPoints                      
            |> DynObj.withOptionalProperty                   "selected"           Selected                            
            |> DynObj.withOptionalProperty                   "unselected"         Unselected                          
            |> DynObj.withOptionalProperty                   "below"              Below                               
            |> DynObj.withOptionalProperty                   "connectgaps"        ConnectGaps                         
            |> DynObj.withOptionalPropertyBy                 "fill"               Fill                                StyleParam.Fill.convert
            |> DynObj.withOptionalProperty                   "fillcolor"          FillColor                           
            |> DynObj.withOptionalProperty                   "hoverlabel"         HoverLabel                          
            |> DynObj.withOptionalProperty                   "uirevision"         UIRevision                          

    /// <summary>
    /// Create a function that applies the styles of a choropleth mapbox plot to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="Z">Sets the color values.</param>
    /// <param name="GeoJson">Sets the GeoJSON data associated with this trace. It can be set as a valid GeoJSON object or as a URL string. Note that we only accept GeoJSONs of type "FeatureCollection" or "Feature" with geometries of type "Polygon" or "MultiPolygon".</param>
    /// <param name="FeatureIdKey">Sets the key in GeoJSON features which is used as id to match the items included in the `locations` array. Support nested property, for example "properties.name".</param>
    /// <param name="Locations">Sets which features found in "geojson" to plot using their feature `id` field.</param>
    /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="HoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="MultiHoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
    /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="MultiHoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="SubPlot">Sets a reference between this trace's data coordinates and a mapbox subplot. If "mapbox" (the default value), the data refer to `layout.mapbox`. If "mapbox2", the data refer to `layout.mapbox2`, and so on.</param>
    /// <param name="ColorAxis">Sets a reference to a shared color axis. References to these shared color axes are "coloraxis", "coloraxis2", "coloraxis3", etc. Settings for these shared color axes are set in the layout, under `layout.coloraxis`, `layout.coloraxis2`, etc. Note that multiple color scales can be linked to the same color axis.</param>
    /// <param name="Marker">Sets the marker of this trace.</param>
    /// <param name="ColorBar">Sets the color bar of this trace.</param>
    /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `colorscale`. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
    /// <param name="ColorScale">Sets the colorscale. The colorscale must be an array containing arrays mapping a normalized value to an rgb, rgba, hex, hsl, hsv, or named color string. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 'rgb(0,0,255)'], [1, 'rgb(255,0,0)']]`. To control the bounds of the colorscale in color space, use`zmin` and `zmax`. Alternatively, `colorscale` may be a palette name string of the following list: Blackbody,Bluered,Blues,Cividis,Earth,Electric,Greens,Greys,Hot,Jet,Picnic,Portland,Rainbow,RdBu,Reds,Viridis,YlGnBu,YlOrRd.</param>
    /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace.</param>
    /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
    /// <param name="ZAuto">Determines whether or not the color domain is computed with respect to the input data (here in `z`) or the bounds set in `zmin` and `zmax` Defaults to `false` when `zmin` and `zmax` are set by the user.</param>
    /// <param name="Zmax">Sets the upper bound of the color domain. Value should have the same units as in `z` and if set, `zmin` must be set as well.</param>
    /// <param name="Zmid">Sets the mid-point of the color domain by scaling `zmin` and/or `zmax` to be equidistant to this point. Value should have the same units as in `z`. Has no effect when `zauto` is `false`.</param>
    /// <param name="Zmin">Sets the lower bound of the color domain. Value should have the same units as in `z` and if set, `zmax` must be set as well.</param>
    /// <param name="SelectedPoints">Array containing integer indices of selected points. Has an effect only for traces that support selections. Note that an empty array means an empty selection where the `unselected` are turned on for all points, whereas, any other non-array values means no selection all where the `selected` and `unselected` styles have no effect.</param>
    /// <param name="Selected">Sets the style of selected points of this trace.</param>
    /// <param name="Unselected">Sets the style of unselected points of this trace.</param>
    /// <param name="Below">Determines if the choropleth polygons will be inserted before the layer with the specified ID. By default, choroplethmapbox traces are placed above the water layers. If set to '', the layer will be inserted above every existing layer.</param>
    /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member ChoroplethMapbox
        (
            ?Name: string,
            ?Visible: StyleParam.Visible,
            ?ShowLegend: bool,
            ?Legend: StyleParam.SubPlotId,
            ?LegendRank: int,
            ?LegendGroup: string,
            ?LegendGroupTitle: Title,
            ?Ids: seq<#IConvertible>,
            ?Z: seq<#IConvertible>,
            ?GeoJson: obj,
            ?FeatureIdKey: string,
            ?Locations: seq<string>,
            ?Text: #IConvertible,
            ?MultiText: seq<#IConvertible>,
            ?HoverText: string,
            ?MultiHoverText: seq<string>,
            ?HoverInfo: StyleParam.HoverInfo,
            ?HoverTemplate: string,
            ?MultiHoverTemplate: seq<string>,
            ?Meta: string,
            ?CustomData: seq<#IConvertible>,
            ?SubPlot: StyleParam.SubPlotId,
            ?ColorAxis: StyleParam.SubPlotId,
            ?Marker: Marker,
            ?ColorBar: ColorBar,
            ?AutoColorScale: bool,
            ?ColorScale: StyleParam.Colorscale,
            ?ShowScale: bool,
            ?ReverseScale: bool,
            ?ZAuto: bool,
            ?Zmax: float,
            ?Zmid: float,
            ?Zmin: float,
            ?SelectedPoints: seq<#IConvertible>,
            ?Selected: TraceSelection,
            ?Unselected: TraceSelection,
            ?Below: string,
            ?HoverLabel: Hoverlabel,
            ?UIRevision: string
        ) =
        fun (trace: #Trace) ->
            trace
            |> DynObj.withOptionalProperty               "name"             Name                                
            |> DynObj.withOptionalPropertyBy             "visible"          Visible                             StyleParam.Visible.convert
            |> DynObj.withOptionalProperty               "showlegend"       ShowLegend                          
            |> DynObj.withOptionalProperty               "legendrank"       LegendRank                          
            |> DynObj.withOptionalProperty               "legendgroup"      LegendGroup                         
            |> DynObj.withOptionalProperty               "legendgrouptitle" LegendGroupTitle                    
            |> DynObj.withOptionalProperty               "ids"              Ids                                 
            |> DynObj.withOptionalProperty               "z"                Z                                   
            |> DynObj.withOptionalProperty               "geojson"          GeoJson                             
            |> DynObj.withOptionalProperty               "featureidkey"     FeatureIdKey                        
            |> DynObj.withOptionalProperty               "locations"        Locations                           
            |> DynObj.withOptionalSingleOrMultiProperty  "text"             (Text, MultiText)                   
            |> DynObj.withOptionalSingleOrMultiProperty  "hovertext"        (HoverText, MultiHoverText)         
            |> DynObj.withOptionalPropertyBy             "hoverinfo"        HoverInfo                           StyleParam.HoverInfo.convert
            |> DynObj.withOptionalSingleOrMultiProperty  "hovertemplate"    (HoverTemplate, MultiHoverTemplate) 
            |> DynObj.withOptionalProperty               "meta"             Meta                                
            |> DynObj.withOptionalProperty               "customdata"       CustomData                          
            |> DynObj.withOptionalPropertyBy             "subplot"          SubPlot                             StyleParam.SubPlotId.convert
            |> DynObj.withOptionalPropertyBy             "coloraxis"        ColorAxis                           StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty               "marker"           Marker                              
            |> DynObj.withOptionalProperty               "colorbar"         ColorBar                            
            |> DynObj.withOptionalProperty               "autocolorscale"   AutoColorScale                      
            |> DynObj.withOptionalPropertyBy             "colorscale"       ColorScale                          StyleParam.Colorscale.convert
            |> DynObj.withOptionalProperty               "showscale"        ShowScale                           
            |> DynObj.withOptionalProperty               "reversescale"     ReverseScale                        
            |> DynObj.withOptionalProperty               "zauto"            ZAuto                               
            |> DynObj.withOptionalProperty               "zmin"             Zmin                                
            |> DynObj.withOptionalProperty               "zmid"             Zmid                                
            |> DynObj.withOptionalProperty               "zmax"             Zmax                                
            |> DynObj.withOptionalProperty               "selectedpoints"   SelectedPoints                      
            |> DynObj.withOptionalProperty               "selected"         Selected                            
            |> DynObj.withOptionalProperty               "unselected"       Unselected                          
            |> DynObj.withOptionalProperty               "below"            Below                               
            |> DynObj.withOptionalProperty               "hoverlabel"       HoverLabel                          
            |> DynObj.withOptionalProperty               "uirevision"       UIRevision                          

    /// <summary>
    /// Create a function that applies the styles of a density mapbox plot to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Opacity">Sets the opacity of the trace.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="Z">Sets the points' weight. For example, a value of 10 would be equivalent to having 10 points of weight 1 in the same spot</param>
    /// <param name="Radius">Sets the radius of influence of one `lon` / `lat` point in pixels. Increasing the value makes the densitymapbox trace smoother, but less detailed.</param>
    /// <param name="Lat">Sets the latitude coordinates (in degrees North).</param>
    /// <param name="Lon">Sets the longitude coordinates (in degrees East).</param>
    /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="HoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="MultiHoverText">Sets hover text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
    /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="MultiHoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="SubPlot">Sets a reference between this trace's data coordinates and a mapbox subplot. If "mapbox" (the default value), the data refer to `layout.mapbox`. If "mapbox2", the data refer to `layout.mapbox2`, and so on.</param>
    /// <param name="ColorAxis">Sets a reference to a shared color axis. References to these shared color axes are "coloraxis", "coloraxis2", "coloraxis3", etc. Settings for these shared color axes are set in the layout, under `layout.coloraxis`, `layout.coloraxis2`, etc. Note that multiple color scales can be linked to the same color axis.</param>
    /// <param name="Marker">Sets the marker of this trace.</param>
    /// <param name="ColorBar">Sets the color bar of this trace.</param>
    /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `colorscale`. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
    /// <param name="ColorScale">Sets the colorscale. The colorscale must be an array containing arrays mapping a normalized value to an rgb, rgba, hex, hsl, hsv, or named color string. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 'rgb(0,0,255)'], [1, 'rgb(255,0,0)']]`. To control the bounds of the colorscale in color space, use`zmin` and `zmax`. Alternatively, `colorscale` may be a palette name string of the following list: Blackbody,Bluered,Blues,Cividis,Earth,Electric,Greens,Greys,Hot,Jet,Picnic,Portland,Rainbow,RdBu,Reds,Viridis,YlGnBu,YlOrRd.</param>
    /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace.</param>
    /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
    /// <param name="ZAuto">Determines whether or not the color domain is computed with respect to the input data (here in `z`) or the bounds set in `zmin` and `zmax` Defaults to `false` when `zmin` and `zmax` are set by the user.</param>
    /// <param name="Zmax">Sets the upper bound of the color domain. Value should have the same units as in `z` and if set, `zmin` must be set as well.</param>
    /// <param name="Zmid">Sets the mid-point of the color domain by scaling `zmin` and/or `zmax` to be equidistant to this point. Value should have the same units as in `z`. Has no effect when `zauto` is `false`.</param>
    /// <param name="Zmin">Sets the lower bound of the color domain. Value should have the same units as in `z` and if set, `zmax` must be set as well.</param>
    /// <param name="Below">Determines if the densitymapbox trace will be inserted before the layer with the specified ID. By default, densitymapbox traces are placed below the first layer of type symbol If set to '', the layer will be inserted above every existing layer.</param>
    /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member DensityMapbox
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
            ?Radius: int,
            ?Lat: #IConvertible seq,
            ?Lon: #IConvertible seq,
            ?Text: #IConvertible,
            ?MultiText: seq<#IConvertible>,
            ?HoverText: string,
            ?MultiHoverText: seq<string>,
            ?HoverInfo: StyleParam.HoverInfo,
            ?HoverTemplate: string,
            ?MultiHoverTemplate: seq<string>,
            ?Meta: string,
            ?CustomData: seq<#IConvertible>,
            ?SubPlot: StyleParam.SubPlotId,
            ?ColorAxis: StyleParam.SubPlotId,
            ?Marker: Marker,
            ?ColorBar: ColorBar,
            ?AutoColorScale: bool,
            ?ColorScale: StyleParam.Colorscale,
            ?ShowScale: bool,
            ?ReverseScale: bool,
            ?ZAuto: bool,
            ?Zmin: float,
            ?Zmid: float,
            ?Zmax: float,
            ?Below: string,
            ?HoverLabel: Hoverlabel,
            ?UIRevision: string
        ) =
        fun (trace: #Trace) ->
            trace
            |> DynObj.withOptionalProperty               "name"             Name                                
            |> DynObj.withOptionalPropertyBy             "visible"          Visible                             StyleParam.Visible.convert
            |> DynObj.withOptionalProperty               "showlegend"       ShowLegend                          
            |> DynObj.withOptionalPropertyBy             "legend"           Legend                              StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty               "legendrank"       LegendRank                          
            |> DynObj.withOptionalProperty               "legendgroup"      LegendGroup                         
            |> DynObj.withOptionalProperty               "legendgrouptitle" LegendGroupTitle                    
            |> DynObj.withOptionalProperty               "opacity"          Opacity                             
            |> DynObj.withOptionalProperty               "ids"              Ids                                 
            |> DynObj.withOptionalProperty               "z"                Z                                   
            |> DynObj.withOptionalProperty               "radius"           Radius                              
            |> DynObj.withOptionalProperty               "lat"              Lat                                 
            |> DynObj.withOptionalProperty               "lon"              Lon                                 
            |> DynObj.withOptionalSingleOrMultiProperty  "text"             (Text, MultiText)                   
            |> DynObj.withOptionalSingleOrMultiProperty  "hovertext"        (HoverText, MultiHoverText)         
            |> DynObj.withOptionalPropertyBy             "hoverinfo"        HoverInfo                           StyleParam.HoverInfo.convert
            |> DynObj.withOptionalSingleOrMultiProperty  "hovertemplate"    (HoverTemplate, MultiHoverTemplate) 
            |> DynObj.withOptionalProperty               "meta"             Meta                                
            |> DynObj.withOptionalProperty               "customdata"       CustomData                          
            |> DynObj.withOptionalPropertyBy             "subplot"          SubPlot                             StyleParam.SubPlotId.convert
            |> DynObj.withOptionalPropertyBy             "coloraxis"        ColorAxis                           StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty               "marker"           Marker                              
            |> DynObj.withOptionalProperty               "colorbar"         ColorBar                            
            |> DynObj.withOptionalProperty               "autocolorscale"   AutoColorScale                      
            |> DynObj.withOptionalPropertyBy             "colorscale"       ColorScale                          StyleParam.Colorscale.convert
            |> DynObj.withOptionalProperty               "showscale"        ShowScale                           
            |> DynObj.withOptionalProperty               "reversescale"     ReverseScale                        
            |> DynObj.withOptionalProperty               "zauto"            ZAuto                               
            |> DynObj.withOptionalProperty               "zmin"             Zmin                                
            |> DynObj.withOptionalProperty               "zmid"             Zmid                                
            |> DynObj.withOptionalProperty               "zmax"             Zmax                                
            |> DynObj.withOptionalProperty               "below"            Below                               
            |> DynObj.withOptionalProperty               "hoverlabel"       HoverLabel                          
            |> DynObj.withOptionalProperty               "uirevision"       UIRevision                          
