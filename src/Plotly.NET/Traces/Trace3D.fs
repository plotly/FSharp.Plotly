namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open System
open System.Runtime.InteropServices

/// Traces for 3D subplots, using layout.scene as anchors.
///
/// These trace types are compatible with 3D subplots via the scene attribute, which contains special camera controls:
///
/// - scatter3d, which can be used to draw individual markers, 3d bubble charts and lines and curves
///
/// - surface and mesh: 3d surface trace types
///
/// - cone and streamtube: 3d vector field trace types


type Trace3D(traceTypeName) =
    inherit Trace(traceTypeName)

    ///initializes a trace of type "scatter3d" applying the givin trace styling function
    static member initScatter3D(applyStyle: Trace3D -> Trace3D) = Trace3D("scatter3d") |> applyStyle

    ///initializes a trace of type "surface" applying the givin trace styling function
    static member initSurface(applyStyle: Trace3D -> Trace3D) = Trace3D("surface") |> applyStyle

    ///initializes a trace of type "mesh3d" applying the givin trace styling function
    static member initMesh3D(applyStyle: Trace3D -> Trace3D) = Trace3D("mesh3d") |> applyStyle

    ///initializes a trace of type "cone" applying the givin trace styling function
    static member initCone(applyStyle: Trace3D -> Trace3D) = Trace3D("cone") |> applyStyle

    ///initializes a trace of type "streamtube" applying the givin trace styling function
    static member initStreamTube(applyStyle: Trace3D -> Trace3D) = Trace3D("streamtube") |> applyStyle

    ///initializes a trace of type "volume" applying the givin trace styling function
    static member initVolume(applyStyle: Trace3D -> Trace3D) = Trace3D("volume") |> applyStyle

    ///initializes a trace of type "isosurface" applying the givin trace styling function
    static member initIsoSurface(applyStyle: Trace3D -> Trace3D) = Trace3D("isosurface") |> applyStyle


//-------------------------------------------------------------------------------------------------------------------------------------------------
/// Create various functions for applying 3D chart styles to traces
type Trace3DStyle() =

    // ######################## 3d-Charts

    static member SetScene(?SceneId: StyleParam.SubPlotId) =
        fun (trace: Trace3D) ->
            trace
            |> DynObj.withOptionalPropertyBy "scene" SceneId StyleParam.SubPlotId.toString

    /// <summary>
    /// Create a function that applies the styles of a 3D scatter plot to a Trace object
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title</param>
    /// <param name="Opacity">Sets the opacity of the trace.</param>
    /// <param name="Mode">Determines the drawing mode for this scatter trace. If the provided `mode` includes "text" then the `text` elements appear at the coordinates. Otherwise, the `text` elements appear on hover. If there are less than 20 points and the trace is not stacked then the default is "lines+markers". Otherwise, "lines".</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="X">Sets the x coordinates.</param>
    /// <param name="Y">Sets the y coordinates.</param>
    /// <param name="Z">Sets the z coordinates.</param>
    /// <param name="SurfaceColor">Sets the surface fill color.</param>
    /// <param name="Text">Sets text elements associated with each (x,y,z) triplet. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y,z) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="MultiText">Sets text elements associated with each (x,y,z) triplet. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y,z) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="TextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
    /// <param name="MultiTextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
    /// <param name="TextTemplate">Template string used for rendering the information text that appear on points. Note that this will override `textinfo`. Variables are inserted using %{variable}, for example "y: %{y}". Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. Every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available.</param>
    /// <param name="MultiTextTemplate">Template string used for rendering the information text that appear on points. Note that this will override `textinfo`. Variables are inserted using %{variable}, for example "y: %{y}". Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. Every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available.</param>
    /// <param name="HoverText">Sets text elements associated with each (x,y,z) triplet. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y,z) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="MultiHoverText">Sets text elements associated with each (x,y,z) triplet. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y,z) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
    /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="MultiHoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="XHoverFormat">Sets the hover text formatting rulefor `x` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="YHoverFormat">Sets the hover text formatting rulefor `y` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `yaxis.hoverformat`.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="Scene">Sets a reference between this trace's 3D coordinate system and a 3D scene. If "scene" (the default value), the (x,y,z) coordinates refer to `layout.scene`. If "scene2", the (x,y,z) coordinates refer to `layout.scene2`, and so on.</param>
    /// <param name="Marker">Sets the marker of this trace.</param>
    /// <param name="Line">Sets the line of this trace.</param>
    /// <param name="TextFont">Sets the text font of this trace.</param>
    /// <param name="XError">Sets the x Error of this trace.</param>
    /// <param name="YError">Sets the y Error of this trace.</param>
    /// <param name="ZError">Sets the z Error of this trace.</param>
    /// <param name="ZHoverFormat">Sets the hover text formatting rulefor `z` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `zaxis.hoverformat`.</param>
    /// <param name="ConnectGaps">Determines whether or not gaps (i.e. {nan} or missing values) in the provided data arrays are connected.</param>
    /// <param name="Hoverlabel">Sets the hoverlabel of this trace.</param>
    /// <param name="Projection">Sets the projection of this trace.</param>
    /// <param name="Surfaceaxis">If "-1", the scatter points are not fill with a surface If "0", "1", "2", the scatter points are filled with a Delaunay surface about the x, y, z respectively.</param>
    /// <param name="XCalendar">Sets the calendar system to use with `x` date data.</param>
    /// <param name="YCalendar">Sets the calendar system to use with `y` date data.</param>
    /// <param name="ZCalendar">Sets the calendar system to use with `z` date data.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member Scatter3D
        (
            ?Name: string,
            ?Visible: StyleParam.Visible,
            ?ShowLegend: bool,
            ?Legend: StyleParam.SubPlotId,
            ?LegendRank: int,
            ?LegendGroup: string,
            ?LegendGroupTitle: Title,
            ?Mode: StyleParam.Mode,
            ?Opacity: float,
            ?Ids: seq<#IConvertible>,
            ?X: seq<#IConvertible>,
            ?Y: seq<#IConvertible>,
            ?Z: seq<#IConvertible>,
            ?SurfaceColor: Color,
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
            ?XHoverFormat: string,
            ?YHoverFormat: string,
            ?Meta: string,
            ?CustomData: seq<#IConvertible>,
            ?Scene: StyleParam.SubPlotId,
            ?Marker: Marker,
            ?Line: Line,
            ?TextFont: Font,
            ?XError: Error,
            ?YError: Error,
            ?ZError: Error,
            ?ZHoverFormat: string,
            ?ConnectGaps: bool,
            ?Hoverlabel: Hoverlabel,
            ?Projection: Projection,
            ?Surfaceaxis: StyleParam.SurfaceAxis,
            ?XCalendar: StyleParam.Calendar,
            ?YCalendar: StyleParam.Calendar,
            ?ZCalendar: StyleParam.Calendar,
            ?UIRevision: string
        ) =

        fun (scatter: #Trace) ->

            scatter
            |> DynObj.withOptionalProperty                   "name"              Name                                
            |> DynObj.withOptionalPropertyBy                 "visible"           Visible                             StyleParam.Visible.convert
            |> DynObj.withOptionalProperty                   "showlegend"        ShowLegend                          
            |> DynObj.withOptionalPropertyBy                 "legend"            Legend                              StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty                   "legendrank"        LegendRank                          
            |> DynObj.withOptionalProperty                   "legendgroup"       LegendGroup                         
            |> DynObj.withOptionalProperty                   "legendgrouptitle"  LegendGroupTitle                    
            |> DynObj.withOptionalPropertyBy                 "mode"              Mode                                StyleParam.Mode.convert
            |> DynObj.withOptionalProperty                   "opacity"           Opacity                             
            |> DynObj.withOptionalProperty                   "ids"               Ids                                 
            |> DynObj.withOptionalProperty                   "x"                 X                                   
            |> DynObj.withOptionalProperty                   "y"                 Y                                   
            |> DynObj.withOptionalProperty                   "z"                 Z                                   
            |> DynObj.withOptionalProperty                   "surfacecolor"      SurfaceColor                        
            |> DynObj.withOptionalSingleOrMultiProperty      "text"              (Text, MultiText)                   
            |> DynObj.withOptionalSingleOrMultiPropertyBy    "textposition"      (TextPosition, MultiTextPosition)   StyleParam.TextPosition.convert
            |> DynObj.withOptionalSingleOrMultiProperty      "texttemplate"      (TextTemplate, MultiTextTemplate)   
            |> DynObj.withOptionalSingleOrMultiProperty      "hovertext"         (HoverText, MultiHoverText)         
            |> DynObj.withOptionalPropertyBy                 "hoverinfo"         HoverInfo                           StyleParam.HoverInfo.convert
            |> DynObj.withOptionalSingleOrMultiProperty      "hovertemplate"     (HoverTemplate, MultiHoverTemplate) 
            |> DynObj.withOptionalProperty                   "xhoverformat"      XHoverFormat                        
            |> DynObj.withOptionalProperty                   "yhoverformat"      YHoverFormat                        
            |> DynObj.withOptionalProperty                   "zhoverformat"      ZHoverFormat                        
            |> DynObj.withOptionalProperty                   "meta"              Meta                                
            |> DynObj.withOptionalProperty                   "customdata"        CustomData                          
            |> DynObj.withOptionalPropertyBy                 "scene"             Scene                               StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty                   "marker"            Marker                              
            |> DynObj.withOptionalProperty                   "line"              Line                                
            |> DynObj.withOptionalProperty                   "textfont"          TextFont                            
            |> DynObj.withOptionalProperty                   "error_x"           XError                              
            |> DynObj.withOptionalProperty                   "error_y"           YError                              
            |> DynObj.withOptionalProperty                   "error_z"           ZError                              
            |> DynObj.withOptionalProperty                   "connectgaps"       ConnectGaps                         
            |> DynObj.withOptionalProperty                   "hoverlabel"        Hoverlabel                          
            |> DynObj.withOptionalProperty                   "projection"        Projection                          
            |> DynObj.withOptionalPropertyBy                 "surfaceaxis"       Surfaceaxis                         StyleParam.SurfaceAxis.convert
            |> DynObj.withOptionalPropertyBy                 "xcalendar"         XCalendar                           StyleParam.Calendar.convert
            |> DynObj.withOptionalPropertyBy                 "ycalendar"         YCalendar                           StyleParam.Calendar.convert
            |> DynObj.withOptionalPropertyBy                 "zcalendar"         ZCalendar                           StyleParam.Calendar.convert
            |> DynObj.withOptionalProperty                   "uirevision"        UIRevision                          

    /// <summary>
    /// Create a function that applies the styles of a surface chart to the given trace
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Opacity">Sets the opacity of the surface. Please note that in the case of using high `opacity` values for example a value greater than or equal to 0.5 on two surfaces (and 0.25 with four surfaces), an overlay of multiple transparent surfaces may not perfectly be sorted in depth by the webgl API. This behavior may be improved in the near future and is subject to change.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="X">Sets the x coordinates.</param>
    /// <param name="Y">Sets the y coordinates.</param>
    /// <param name="Z">Sets the z coordinates.</param>
    /// <param name="SurfaceColor">Sets the surface color values, used for setting a color scale independent of `z`.</param>
    /// <param name="Text">Sets the text elements associated with each z value. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="MultiText">Sets the text elements associated with each z value. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="HoverText">Same as `text`.</param>
    /// <param name="MultiHoverText">Same as `text`.</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
    /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="MultiHoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="XHoverFormat">Sets the hover text formatting rulefor `x` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="YHoverFormat">Sets the hover text formatting rulefor `y` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `yaxis.hoverformat`.</param>
    /// <param name="ZHoverFormat">Sets the hover text formatting rulefor `z` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `zaxis.hoverformat`.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="Scene">Sets a reference between this trace's 3D coordinate system and a 3D scene. If "scene" (the default value), the (x,y,z) coordinates refer to `layout.scene`. If "scene2", the (x,y,z) coordinates refer to `layout.scene2`, and so on.</param>
    /// <param name="ColorAxis">Sets a reference to a shared color axis. References to these shared color axes are "coloraxis", "coloraxis2", "coloraxis3", etc. Settings for these shared color axes are set in the layout, under `layout.coloraxis`, `layout.coloraxis2`, etc. Note that multiple color scales can be linked to the same color axis.</param>
    /// <param name="ColorBar">Sets the colorbar of this trace.</param>
    /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `colorscale`. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
    /// <param name="ColorScale">Sets the colorscale. The colorscale must be an array containing arrays mapping a normalized value to an rgb, rgba, hex, hsl, hsv, or named color string. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 'rgb(0,0,255)'], [1, 'rgb(255,0,0)']]`. To control the bounds of the colorscale in color space, use`cmin` and `cmax`. Alternatively, `colorscale` may be a palette name string of the following list: Blackbody,Bluered,Blues,Cividis,Earth,Electric,Greens,Greys,Hot,Jet,Picnic,Portland,Rainbow,RdBu,Reds,Viridis,YlGnBu,YlOrRd.</param>
    /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace.</param>
    /// <param name="ReverseScale">Reverses the color mapping if true. If true, `cmin` will correspond to the last color in the array and `cmax` will correspond to the first color.</param>
    /// <param name="CAuto">Determines whether or not the color domain is computed with respect to the input data (here z or surfacecolor) or the bounds set in `cmin` and `cmax` Defaults to `false` when `cmin` and `cmax` are set by the user.</param>
    /// <param name="CMin">Sets the lower bound of the color domain. Value should have the same units as z or surfacecolor and if set, `cmax` must be set as well.</param>
    /// <param name="CMid">Sets the mid-point of the color domain by scaling `cmin` and/or `cmax` to be equidistant to this point. Value should have the same units as z or surfacecolor. Has no effect when `cauto` is `false`.</param>
    /// <param name="CMax">Sets the upper bound of the color domain. Value should have the same units as z or surfacecolor and if set, `cmin` must be set as well.</param>
    /// <param name="ConnectGaps">Determines whether or not gaps (i.e. {nan} or missing values) in the `z` data are filled in.</param>
    /// <param name="Contours">Sets the contours of this trace.</param>
    /// <param name="HideSurface">Determines whether or not a surface is drawn. For example, set `hidesurface` to "false" `contours.x.show` to "true" and `contours.y.show` to "true" to draw a wire frame plot.</param>
    /// <param name="Hoverlabel">Sets the hoverlabel style of this trace.</param>
    /// <param name="Lighting">Sets the Lighting style of this trace.</param>
    /// <param name="LightPosition">Sets the LightPosition style of this trace.</param>
    /// <param name="OpacityScale">Sets the opacityscale. The opacityscale must be an array containing arrays mapping a normalized value to an opacity value. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 1], [0.5, 0.2], [1, 1]]` means that higher/lower values would have higher opacity values and those in the middle would be more transparent Alternatively, `opacityscale` may be a palette name string of the following list: 'min', 'max', 'extremes' and 'uniform'. The default is 'uniform'.</param>
    /// <param name="XCalendar">Sets the calendar system to use with `x` date data.</param>
    /// <param name="YCalendar">Sets the calendar system to use with `y` date data.</param>
    /// <param name="ZCalendar">Sets the calendar system to use with `z` date data.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member Surface
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
            ?Y: seq<#IConvertible>,
            ?Z: seq<#seq<#IConvertible>>,
            ?SurfaceColor: Color,
            ?Text: #IConvertible,
            ?MultiText: seq<#IConvertible>,
            ?HoverText: string,
            ?MultiHoverText: seq<string>,
            ?HoverInfo: StyleParam.HoverInfo,
            ?HoverTemplate: string,
            ?MultiHoverTemplate: seq<string>,
            ?XHoverFormat: string,
            ?YHoverFormat: string,
            ?Meta: string,
            ?CustomData: seq<#IConvertible>,
            ?Scene: StyleParam.SubPlotId,
            ?ColorAxis: StyleParam.SubPlotId,
            ?ColorBar: ColorBar,
            ?AutoColorScale: bool,
            ?ColorScale: StyleParam.Colorscale,
            ?ShowScale: bool,
            ?ReverseScale: bool,
            ?ZHoverFormat: string,
            ?CAuto: bool,
            ?CMax: float,
            ?CMid: float,
            ?CMin: float,
            ?ConnectGaps: bool,
            ?Contours: Contours,
            ?HideSurface: bool,
            ?Hoverlabel: Hoverlabel,
            ?Lighting: Lighting,
            ?LightPosition: LightPosition,
            ?OpacityScale: seq<#seq<#IConvertible>>,
            ?XCalendar: StyleParam.Calendar,
            ?YCalendar: StyleParam.Calendar,
            ?ZCalendar: StyleParam.Calendar,
            ?UIRevision: string
        ) =
        fun (surface: #Trace) ->

            surface
            |> DynObj.withOptionalProperty               "name"              Name                                
            |> DynObj.withOptionalPropertyBy             "visible"           Visible                             StyleParam.Visible.convert
            |> DynObj.withOptionalProperty               "showlegend"        ShowLegend                          
            |> DynObj.withOptionalPropertyBy             "legend"            Legend                              StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty               "legendrank"        LegendRank                          
            |> DynObj.withOptionalProperty               "legendgroup"       LegendGroup                         
            |> DynObj.withOptionalProperty               "legendgrouptitle"  LegendGroupTitle                    
            |> DynObj.withOptionalProperty               "opacity"           Opacity                             
            |> DynObj.withOptionalProperty               "ids"               Ids                                 
            |> DynObj.withOptionalProperty               "x"                 X                                   
            |> DynObj.withOptionalProperty               "y"                 Y                                   
            |> DynObj.withOptionalProperty               "z"                 Z                                   
            |> DynObj.withOptionalProperty               "surfacecolor"      SurfaceColor                        
            |> DynObj.withOptionalSingleOrMultiProperty  "text"              (Text, MultiText)                   
            |> DynObj.withOptionalSingleOrMultiProperty  "hovertext"         (HoverText, MultiHoverText)         
            |> DynObj.withOptionalPropertyBy             "hoverinfo"         HoverInfo                           StyleParam.HoverInfo.convert
            |> DynObj.withOptionalSingleOrMultiProperty  "hovertemplate"     (HoverTemplate, MultiHoverTemplate) 
            |> DynObj.withOptionalProperty               "xhoverformat"      XHoverFormat                        
            |> DynObj.withOptionalProperty               "yhoverformat"      YHoverFormat                        
            |> DynObj.withOptionalProperty               "zhoverformat"      ZHoverFormat                        
            |> DynObj.withOptionalProperty               "meta"              Meta                                
            |> DynObj.withOptionalProperty               "customdata"        CustomData                          
            |> DynObj.withOptionalPropertyBy             "scene"             Scene                               StyleParam.SubPlotId.convert
            |> DynObj.withOptionalPropertyBy             "coloraxis"         ColorAxis                           StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty               "colorbar"          ColorBar                            
            |> DynObj.withOptionalProperty               "autocolorscale"    AutoColorScale                      
            |> DynObj.withOptionalPropertyBy             "colorscale"        ColorScale                          StyleParam.Colorscale.convert
            |> DynObj.withOptionalProperty               "showscale"         ShowScale                           
            |> DynObj.withOptionalProperty               "reversescale"      ReverseScale                        
            |> DynObj.withOptionalProperty               "cauto"             CAuto                               
            |> DynObj.withOptionalProperty               "cmin"              CMin                                
            |> DynObj.withOptionalProperty               "cmid"              CMid                                
            |> DynObj.withOptionalProperty               "cmax"              CMax                                
            |> DynObj.withOptionalProperty               "connectgaps"       ConnectGaps                         
            |> DynObj.withOptionalProperty               "contours"          Contours                            
            |> DynObj.withOptionalProperty               "hidesurface"       HideSurface                         
            |> DynObj.withOptionalProperty               "hoverlabel"        Hoverlabel                          
            |> DynObj.withOptionalProperty               "lighting"          Lighting                            
            |> DynObj.withOptionalProperty               "lightposition"     LightPosition                       
            |> DynObj.withOptionalProperty               "opacityscale"      OpacityScale                        
            |> DynObj.withOptionalPropertyBy             "xcalendar"         XCalendar                           StyleParam.Calendar.convert
            |> DynObj.withOptionalPropertyBy             "ycalendar"         YCalendar                           StyleParam.Calendar.convert
            |> DynObj.withOptionalPropertyBy             "zcalendar"         ZCalendar                           StyleParam.Calendar.convert
            |> DynObj.withOptionalProperty               "uirevision"        UIRevision                          

    /// <summary>
    /// Create a function that applies the styles of a mesh3d chart to the given trace
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Opacity">Sets the opacity of the surface. Please note that in the case of using high `opacity` values for example a value greater than or equal to 0.5 on two surfaces (and 0.25 with four surfaces), an overlay of multiple transparent surfaces may not perfectly be sorted in depth by the webgl API. This behavior may be improved in the near future and is subject to change.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="X">Sets the X coordinates of the vertices. The nth element of vectors `x`, `y` and `z` jointly represent the X, Y and Z coordinates of the nth vertex.</param>
    /// <param name="Y">Sets the Y coordinates of the vertices. The nth element of vectors `x`, `y` and `z` jointly represent the X, Y and Z coordinates of the nth vertex.</param>
    /// <param name="Z">Sets the Z coordinates of the vertices. The nth element of vectors `x`, `y` and `z` jointly represent the X, Y and Z coordinates of the nth vertex.</param>
    /// <param name="I">A vector of vertex indices, i.e. integer values between 0 and the length of the vertex vectors, representing the "first" vertex of a triangle. For example, `{i[m], j[m], k[m]}` together represent face m (triangle m) in the mesh, where `i[m] = n` points to the triplet `{x[n], y[n], z[n]}` in the vertex arrays. Therefore, each element in `i` represents a point in space, which is the first vertex of a triangle.</param>
    /// <param name="J">A vector of vertex indices, i.e. integer values between 0 and the length of the vertex vectors, representing the "second" vertex of a triangle. For example, `{i[m], j[m], k[m]}` together represent face m (triangle m) in the mesh, where `j[m] = n` points to the triplet `{x[n], y[n], z[n]}` in the vertex arrays. Therefore, each element in `j` represents a point in space, which is the second vertex of a triangle.</param>
    /// <param name="K">A vector of vertex indices, i.e. integer values between 0 and the length of the vertex vectors, representing the "third" vertex of a triangle. For example, `{i[m], j[m], k[m]}` together represent face m (triangle m) in the mesh, where `k[m] = n` points to the triplet `{x[n], y[n], z[n]}` in the vertex arrays. Therefore, each element in `k` represents a point in space, which is the third vertex of a triangle.</param>
    /// <param name="FaceColor">Sets the color of each face Overrides "color" and "vertexcolor".</param>
    /// <param name="Intensity">Sets the intensity values for vertices or cells as defined by `intensitymode`. It can be used for plotting fields on meshes.</param>
    /// <param name="IntensityMode">Determines the source of `intensity` values.</param>
    /// <param name="VertexColor">Sets the color of each vertex Overrides "color". While Red, green and blue colors are in the range of 0 and 255; in the case of having vertex color data in RGBA format, the alpha color should be normalized to be between 0 and 1.</param>
    /// <param name="Text">Sets the text elements associated with the vertices. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="MultiText">Sets the text elements associated with the vertices. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="HoverText">Same as `text`.</param>
    /// <param name="MultiHoverText">Same as `text`.</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
    /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="MultiHoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="XHoverFormat">Sets the hover text formatting rulefor `x` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="YHoverFormat">Sets the hover text formatting rulefor `y` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `yaxis.hoverformat`.</param>
    /// <param name="ZHoverFormat">Sets the hover text formatting rulefor `z` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `zaxis.hoverformat`.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="Scene">Sets a reference between this trace's 3D coordinate system and a 3D scene. If "scene" (the default value), the (x,y,z) coordinates refer to `layout.scene`. If "scene2", the (x,y,z) coordinates refer to `layout.scene2`, and so on.</param>
    /// <param name="Color">Sets the color values, used for setting a color scale independent of `z`.</param>
    /// <param name="ColorAxis">Sets a reference to a shared color axis. References to these shared color axes are "coloraxis", "coloraxis2", "coloraxis3", etc. Settings for these shared color axes are set in the layout, under `layout.coloraxis`, `layout.coloraxis2`, etc. Note that multiple color scales can be linked to the same color axis.</param>
    /// <param name="ColorBar">Sets the colorbar of this trace.</param>
    /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `colorscale`. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
    /// <param name="ColorScale">Sets the colorscale. The colorscale must be an array containing arrays mapping a normalized value to an rgb, rgba, hex, hsl, hsv, or named color string. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 'rgb(0,0,255)'], [1, 'rgb(255,0,0)']]`. To control the bounds of the colorscale in color space, use`cmin` and `cmax`. Alternatively, `colorscale` may be a palette name string of the following list: Blackbody,Bluered,Blues,Cividis,Earth,Electric,Greens,Greys,Hot,Jet,Picnic,Portland,Rainbow,RdBu,Reds,Viridis,YlGnBu,YlOrRd.</param>
    /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace.</param>
    /// <param name="ReverseScale">Reverses the color mapping if true. If true, `cmin` will correspond to the last color in the array and `cmax` will correspond to the first color.</param>
    /// <param name="CAuto">Determines whether or not the color domain is computed with respect to the input data (here z or surfacecolor) or the bounds set in `cmin` and `cmax` Defaults to `false` when `cmin` and `cmax` are set by the user.</param>
    /// <param name="CMin">Sets the lower bound of the color domain. Value should have the same units as z or surfacecolor and if set, `cmax` must be set as well.</param>
    /// <param name="CMid">Sets the mid-point of the color domain by scaling `cmin` and/or `cmax` to be equidistant to this point. Value should have the same units as z or surfacecolor. Has no effect when `cauto` is `false`.</param>
    /// <param name="CMax">Sets the upper bound of the color domain. Value should have the same units as z or surfacecolor and if set, `cmin` must be set as well.</param>
    /// <param name="AlphaHull">Determines how the mesh surface triangles are derived from the set of vertices (points) represented by the `x`, `y` and `z` arrays, if the `i`, `j`, `k` arrays are not supplied. For general use of `mesh3d` it is preferred that `i`, `j`, `k` are supplied. If "-1", Delaunay triangulation is used, which is mainly suitable if the mesh is a single, more or less layer surface that is perpendicular to `delaunayaxis`. In case the `delaunayaxis` intersects the mesh surface at more than one point it will result triangles that are very long in the dimension of `delaunayaxis`. If ">0", the alpha-shape algorithm is used. In this case, the positive `alphahull` value signals the use of the alpha-shape algorithm, _and_ its value acts as the parameter for the mesh fitting. If "0", the convex-hull algorithm is used. It is suitable for convex bodies or if the intention is to enclose the `x`, `y` and `z` point set into a convex hull.</param>
    /// <param name="Delaunayaxis">Sets the Delaunay axis, which is the axis that is perpendicular to the surface of the Delaunay triangulation. It has an effect if `i`, `j`, `k` are not provided and `alphahull` is set to indicate Delaunay triangulation.</param>
    /// <param name="Contour">Sets the contour of this trace</param>
    /// <param name="FlatShading">Determines whether or not normal smoothing is applied to the meshes, creating meshes with an angular, low-poly look via flat reflections.</param>
    /// <param name="Hoverlabel">Sets the hoverlabel style of this trace.</param>
    /// <param name="Lighting">Sets the Lighting style of this trace.</param>
    /// <param name="LightPosition">Sets the LightPosition style of this trace.</param>
    /// <param name="XCalendar">Sets the calendar system to use with `x` date data.</param>
    /// <param name="YCalendar">Sets the calendar system to use with `y` date data.</param>
    /// <param name="ZCalendar">Sets the calendar system to use with `z` date data.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member Mesh3D
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
            ?Y: seq<#IConvertible>,
            ?Z: seq<#IConvertible>,
            ?I: seq<#IConvertible>,
            ?J: seq<#IConvertible>,
            ?K: seq<#IConvertible>,
            ?FaceColor: Color,
            ?Intensity: seq<#IConvertible>,
            ?IntensityMode: StyleParam.IntensityMode,
            ?VertexColor: Color,
            ?Text: #IConvertible,
            ?MultiText: seq<#IConvertible>,
            ?HoverText: string,
            ?MultiHoverText: seq<string>,
            ?HoverInfo: StyleParam.HoverInfo,
            ?HoverTemplate: string,
            ?MultiHoverTemplate: seq<string>,
            ?XHoverFormat: string,
            ?YHoverFormat: string,
            ?Meta: string,
            ?CustomData: seq<#IConvertible>,
            ?Scene: StyleParam.SubPlotId,
            ?Color: Color,
            ?ColorAxis: StyleParam.SubPlotId,
            ?ColorBar: ColorBar,
            ?AutoColorScale: bool,
            ?ColorScale: StyleParam.Colorscale,
            ?ShowScale: bool,
            ?ReverseScale: bool,
            ?ZHoverFormat: string,
            ?CAuto: bool,
            ?CMax: float,
            ?CMid: float,
            ?CMin: float,
            ?AlphaHull: StyleParam.TriangulationAlgorithm,
            ?Delaunayaxis: StyleParam.Delaunayaxis,
            ?Contour: Contour,
            ?FlatShading: bool,
            ?Hoverlabel: Hoverlabel,
            ?Lighting: Lighting,
            ?LightPosition: LightPosition,
            ?XCalendar: StyleParam.Calendar,
            ?YCalendar: StyleParam.Calendar,
            ?ZCalendar: StyleParam.Calendar,
            ?UIRevision: string
        ) =

        fun (mesh3d: #Trace) ->

            mesh3d
            |> DynObj.withOptionalProperty               "name"               Name                                
            |> DynObj.withOptionalPropertyBy             "visible"            Visible                             StyleParam.Visible.convert
            |> DynObj.withOptionalProperty               "showlegend"         ShowLegend                          
            |> DynObj.withOptionalPropertyBy             "legend"             Legend                              StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty               "legendrank"         LegendRank                          
            |> DynObj.withOptionalProperty               "legendgroup"        LegendGroup                         
            |> DynObj.withOptionalProperty               "legendgrouptitle"   LegendGroupTitle                    
            |> DynObj.withOptionalProperty               "opacity"            Opacity                             
            |> DynObj.withOptionalProperty               "ids"                Ids                                 
            |> DynObj.withOptionalProperty               "x"                  X                                   
            |> DynObj.withOptionalProperty               "y"                  Y                                   
            |> DynObj.withOptionalProperty               "z"                  Z                                   
            |> DynObj.withOptionalProperty               "i"                  I                                   
            |> DynObj.withOptionalProperty               "j"                  J                                   
            |> DynObj.withOptionalProperty               "k"                  K                                   
            |> DynObj.withOptionalProperty               "facecolor"          FaceColor                           
            |> DynObj.withOptionalProperty               "intensity"          Intensity                           
            |> DynObj.withOptionalPropertyBy             "intensitymode"      IntensityMode                       StyleParam.IntensityMode.convert
            |> DynObj.withOptionalProperty               "vertexcolor"        VertexColor                         
            |> DynObj.withOptionalSingleOrMultiProperty  "text"               (Text, MultiText)                   
            |> DynObj.withOptionalSingleOrMultiProperty  "hovertext"          (HoverText, MultiHoverText)         
            |> DynObj.withOptionalPropertyBy             "hoverinfo"          HoverInfo                           StyleParam.HoverInfo.convert
            |> DynObj.withOptionalSingleOrMultiProperty  "hovertemplate"      (HoverTemplate, MultiHoverTemplate) 
            |> DynObj.withOptionalProperty               "xhoverformat"       XHoverFormat                        
            |> DynObj.withOptionalProperty               "yhoverformat"       YHoverFormat                        
            |> DynObj.withOptionalProperty               "zhoverformat"       ZHoverFormat                        
            |> DynObj.withOptionalProperty               "meta"               Meta                                
            |> DynObj.withOptionalProperty               "customdata"         CustomData                          
            |> DynObj.withOptionalPropertyBy             "scene"              Scene                               StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty               "color"              Color                               
            |> DynObj.withOptionalPropertyBy             "coloraxis"          ColorAxis                           StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty               "colorbar"           ColorBar                            
            |> DynObj.withOptionalProperty               "autocolorscale"     AutoColorScale                      
            |> DynObj.withOptionalPropertyBy             "colorscale"         ColorScale                          StyleParam.Colorscale.convert
            |> DynObj.withOptionalProperty               "showscale"          ShowScale                           
            |> DynObj.withOptionalProperty               "reversescale"       ReverseScale                        
            |> DynObj.withOptionalProperty               "cauto"              CAuto                               
            |> DynObj.withOptionalProperty               "cmin"               CMin                                
            |> DynObj.withOptionalProperty               "cmid"               CMid                                
            |> DynObj.withOptionalProperty               "cmax"               CMax                                
            |> DynObj.withOptionalPropertyBy             "alphahull"          AlphaHull                           StyleParam.TriangulationAlgorithm.convert
            |> DynObj.withOptionalPropertyBy             "delaunayaxis"       Delaunayaxis                        StyleParam.Delaunayaxis.convert
            |> DynObj.withOptionalProperty               "contour"            Contour                             
            |> DynObj.withOptionalProperty               "flatshading"        FlatShading                         
            |> DynObj.withOptionalProperty               "hoverlabel"         Hoverlabel                          
            |> DynObj.withOptionalProperty               "lighting"           Lighting                            
            |> DynObj.withOptionalProperty               "lightposition"      LightPosition                       
            |> DynObj.withOptionalPropertyBy             "xcalendar"          XCalendar                           StyleParam.Calendar.convert
            |> DynObj.withOptionalPropertyBy             "ycalendar"          YCalendar                           StyleParam.Calendar.convert
            |> DynObj.withOptionalPropertyBy             "zcalendar"          ZCalendar                           StyleParam.Calendar.convert
            |> DynObj.withOptionalProperty               "uirevision"         UIRevision                          


    /// <summary>
    /// Create a function that applies the styles of a cone chart to the given trace
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Opacity">Sets the opacity of the surface. Please note that in the case of using high `opacity` values for example a value greater than or equal to 0.5 on two surfaces (and 0.25 with four surfaces), an overlay of multiple transparent surfaces may not perfectly be sorted in depth by the webgl API. This behavior may be improved in the near future and is subject to change.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="X">Sets the x coordinates of the vector field and of the displayed cones.</param>
    /// <param name="Y">Sets the y coordinates of the vector field and of the displayed cones.</param>
    /// <param name="Z">Sets the z coordinates of the vector field and of the displayed cones.</param>
    /// <param name="U">Sets the x components of the vector field.</param>
    /// <param name="V">Sets the y components of the vector field.</param>
    /// <param name="W">Sets the z components of the vector field.</param>
    /// <param name="Text">Sets the text elements associated with the cones. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="MultiText">Sets the text elements associated with the cones. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="HoverText">Same as `text`.</param>
    /// <param name="MultiHoverText">Same as `text`.</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
    /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="MultiHoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="XHoverFormat">Sets the hover text formatting rulefor `x` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="YHoverFormat">Sets the hover text formatting rulefor `y` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `yaxis.hoverformat`.</param>
    /// <param name="ZHoverFormat">Sets the hover text formatting rulefor `z` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `zaxis.hoverformat`</param>
    /// <param name="UHoverFormat">Sets the hover text formatting rulefor `u` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.By default the values are formatted using generic number format.</param>
    /// <param name="VHoverFormat">Sets the hover text formatting rulefor `v` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.By default the values are formatted using generic number format.</param>
    /// <param name="WHoverFormat">Sets the hover text formatting rulefor `w` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.By default the values are formatted using generic number format.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="Scene">Sets a reference between this trace's 3D coordinate system and a 3D scene. If "scene" (the default value), the (x,y,z) coordinates refer to `layout.scene`. If "scene2", the (x,y,z) coordinates refer to `layout.scene2`, and so on.</param>
    /// <param name="ColorAxis">Sets a reference to a shared color axis. References to these shared color axes are "coloraxis", "coloraxis2", "coloraxis3", etc. Settings for these shared color axes are set in the layout, under `layout.coloraxis`, `layout.coloraxis2`, etc. Note that multiple color scales can be linked to the same color axis.</param>
    /// <param name="ColorBar">Sets the ColorBar object associated with the color scale of the cones</param>
    /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `colorscale`. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
    /// <param name="ColorScale">Sets the colorscale. The colorscale must be an array containing arrays mapping a normalized value to an rgb, rgba, hex, hsl, hsv, or named color string. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 'rgb(0,0,255)'], [1, 'rgb(255,0,0)']]`. To control the bounds of the colorscale in color space, use`cmin` and `cmax`. Alternatively, `colorscale` may be a palette name string of the following list: Blackbody,Bluered,Blues,Cividis,Earth,Electric,Greens,Greys,Hot,Jet,Picnic,Portland,Rainbow,RdBu,Reds,Viridis,YlGnBu,YlOrRd.</param>
    /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace.</param>
    /// <param name="ReverseScale">Reverses the color mapping if true. If true, `cmin` will correspond to the last color in the array and `cmax` will correspond to the first color.</param>
    /// <param name="CAuto">Determines whether or not the color domain is computed with respect to the input data (here u/v/w norm) or the bounds set in `cmin` and `cmax` Defaults to `false` when `cmin` and `cmax` are set by the user.</param>
    /// <param name="CMax">Sets the upper bound of the color domain. Value should have the same units as u/v/w norm and if set, `cmin` must be set as well.</param>
    /// <param name="CMid">Sets the mid-point of the color domain by scaling `cmin` and/or `cmax` to be equidistant to this point. Value should have the same units as u/v/w norm. Has no effect when `cauto` is `false`.</param>
    /// <param name="CMin">Sets the lower bound of the color domain. Value should have the same units as u/v/w norm and if set, `cmax` must be set as well.</param>
    /// <param name="Anchor">Sets the cones' anchor with respect to their x/y/z positions. Note that "cm" denote the cone's center of mass which corresponds to 1/4 from the tail to tip.</param>
    /// <param name="HoverLabel">Sets the hover labels of this cone trace.</param>
    /// <param name="Lighting">Sets the Lighting of this cone trace.</param>
    /// <param name="LightPosition">Sets the LightPosition of this cone trace.</param>
    /// <param name="SizeMode">Determines whether `sizeref` is set as a "scaled" (i.e unitless) scalar (normalized by the max u/v/w norm in the vector field) or as "absolute" value (in the same units as the vector field).</param>
    /// <param name="SizeRef">Adjusts the cone size scaling. The size of the cones is determined by their u/v/w norm multiplied a factor and `sizeref`. This factor (computed internally) corresponds to the minimum "time" to travel across two successive x/y/z positions at the average velocity of those two successive positions. All cones in a given trace use the same factor. With `sizemode` set to "scaled", `sizeref` is unitless, its default value is "0.5" With `sizemode` set to "absolute", `sizeref` has the same units as the u/v/w vector field, its the default value is half the sample's maximum vector norm.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member Cone
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
            ?Y: seq<#IConvertible>,
            ?Z: seq<#IConvertible>,
            ?U: seq<#IConvertible>,
            ?V: seq<#IConvertible>,
            ?W: seq<#IConvertible>,
            ?Text: #IConvertible,
            ?MultiText: seq<#IConvertible>,
            ?HoverText: string,
            ?MultiHoverText: seq<string>,
            ?HoverInfo: StyleParam.HoverInfo,
            ?HoverTemplate: string,
            ?MultiHoverTemplate: seq<string>,
            ?XHoverFormat: string,
            ?YHoverFormat: string,
            ?UHoverFormat: string,
            ?VHoverFormat: string,
            ?WHoverFormat: string,
            ?Meta: seq<#IConvertible>,
            ?CustomData: seq<#IConvertible>,
            ?Scene: StyleParam.SubPlotId,
            ?ColorAxis: StyleParam.SubPlotId,
            ?ColorBar: ColorBar,
            ?AutoColorScale: bool,
            ?ColorScale: StyleParam.Colorscale,
            ?ShowScale: bool,
            ?ReverseScale: bool,
            ?ZHoverFormat: string,
            ?CAuto: bool,
            ?CMax: float,
            ?CMid: float,
            ?CMin: float,
            ?Anchor: StyleParam.ConeAnchor,
            ?HoverLabel: Hoverlabel,
            ?Lighting: Lighting,
            ?LightPosition: LightPosition,
            ?SizeMode: StyleParam.ConeSizeMode,
            ?SizeRef: float,
            ?UIRevision: seq<#IConvertible>
        ) =
        fun (cone: #Trace) ->
            cone
            |> DynObj.withOptionalProperty               "name"                Name                                
            |> DynObj.withOptionalPropertyBy             "visible"             Visible                             StyleParam.Visible.convert
            |> DynObj.withOptionalProperty               "showlegend"          ShowLegend                          
            |> DynObj.withOptionalPropertyBy             "legend"              Legend                              StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty               "legendrank"          LegendRank                          
            |> DynObj.withOptionalProperty               "legendgroup"         LegendGroup                         
            |> DynObj.withOptionalProperty               "legendgrouptitle"    LegendGroupTitle                    
            |> DynObj.withOptionalProperty               "opacity"             Opacity                             
            |> DynObj.withOptionalProperty               "ids"                 Ids                                 
            |> DynObj.withOptionalProperty               "x"                   X                                   
            |> DynObj.withOptionalProperty               "y"                   Y                                   
            |> DynObj.withOptionalProperty               "z"                   Z                                   
            |> DynObj.withOptionalProperty               "u"                   U                                   
            |> DynObj.withOptionalProperty               "v"                   V                                   
            |> DynObj.withOptionalProperty               "w"                   W                                   
            |> DynObj.withOptionalSingleOrMultiProperty  "text"                (Text, MultiText)                   
            |> DynObj.withOptionalSingleOrMultiProperty  "hovertext"           (HoverText, MultiHoverText)         
            |> DynObj.withOptionalPropertyBy             "hoverinfo"           HoverInfo                           StyleParam.HoverInfo.convert
            |> DynObj.withOptionalSingleOrMultiProperty  "hovertemplate"       (HoverTemplate, MultiHoverTemplate) 
            |> DynObj.withOptionalProperty               "xhoverformat"        XHoverFormat                        
            |> DynObj.withOptionalProperty               "yhoverformat"        YHoverFormat                        
            |> DynObj.withOptionalProperty               "zhoverformat"        ZHoverFormat                        
            |> DynObj.withOptionalProperty               "uhoverformat"        UHoverFormat                        
            |> DynObj.withOptionalProperty               "vhoverformat"        VHoverFormat                        
            |> DynObj.withOptionalProperty               "whoverformat"        WHoverFormat                        
            |> DynObj.withOptionalProperty               "meta"                Meta                                
            |> DynObj.withOptionalProperty               "customdata"          CustomData                          
            |> DynObj.withOptionalPropertyBy             "scene"               Scene                               StyleParam.SubPlotId.convert
            |> DynObj.withOptionalPropertyBy             "coloraxis"           ColorAxis                           StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty               "colorbar"            ColorBar                            
            |> DynObj.withOptionalProperty               "autocolorscale"      AutoColorScale                      
            |> DynObj.withOptionalPropertyBy             "colorscale"          ColorScale                          StyleParam.Colorscale.convert
            |> DynObj.withOptionalProperty               "showscale"           ShowScale                           
            |> DynObj.withOptionalProperty               "reversescale"        ReverseScale                        
            |> DynObj.withOptionalProperty               "cauto"               CAuto                               
            |> DynObj.withOptionalProperty               "cmin"                CMin                                
            |> DynObj.withOptionalProperty               "cmid"                CMid                                
            |> DynObj.withOptionalProperty               "cmax"                CMax                                
            |> DynObj.withOptionalPropertyBy             "anchor"              Anchor                              StyleParam.ConeAnchor.convert
            |> DynObj.withOptionalProperty               "hoverlabel"          HoverLabel                          
            |> DynObj.withOptionalProperty               "lighting"            Lighting                            
            |> DynObj.withOptionalProperty               "lightposition"       LightPosition                       
            |> DynObj.withOptionalPropertyBy             "sizemode"            SizeMode                            StyleParam.ConeSizeMode.convert
            |> DynObj.withOptionalProperty               "sizeref"             SizeRef                             
            |> DynObj.withOptionalProperty               "uirevision"          UIRevision                          

    /// <summary>
    /// Create a function that applies the styles of a streamtube chart to the given trace
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
    /// <param name="Opacity">Sets the opacity of the surface. Please note that in the case of using high `opacity` values for example a value greater than or equal to 0.5 on two surfaces (and 0.25 with four surfaces), an overlay of multiple transparent surfaces may not perfectly be sorted in depth by the webgl API. This behavior may be improved in the near future and is subject to change.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="X">Sets the x coordinates of the vector field.</param>
    /// <param name="Y">Sets the y coordinates of the vector field.</param>
    /// <param name="Z">Sets the z coordinates of the vector field.</param>
    /// <param name="U">Sets the x components of the vector field.</param>
    /// <param name="V">Sets the y components of the vector field.</param>
    /// <param name="W">Sets the z components of the vector field.</param>
    /// <param name="Text">Sets a text element associated with this trace. If trace `hoverinfo` contains a "text" flag, this text element will be seen in all hover labels. Note that streamtube traces do not support array `text` values.</param>
    /// <param name="MultiText">Sets a text element associated with this trace. If trace `hoverinfo` contains a "text" flag, this text element will be seen in all hover labels. Note that streamtube traces do not support array `text` values.</param>
    /// <param name="HoverText">Same as `text`.</param>
    /// <param name="MultiHoverText">Same as `text`.</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
    /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="MultiHoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="XHoverFormat">Sets the hover text formatting rulefor `x` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="YHoverFormat">Sets the hover text formatting rulefor `y` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `yaxis.hoverformat`.</param>
    /// <param name="ZHoverFormat">Sets the hover text formatting rulefor `z` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `zaxis.hoverformat`</param>
    /// <param name="UHoverFormat">Sets the hover text formatting rulefor `u` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.By default the values are formatted using generic number format.</param>
    /// <param name="VHoverFormat">Sets the hover text formatting rulefor `v` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.By default the values are formatted using generic number format.</param>
    /// <param name="WHoverFormat">Sets the hover text formatting rulefor `w` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.By default the values are formatted using generic number format.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="Scene">Sets a reference between this trace's 3D coordinate system and a 3D scene. If "scene" (the default value), the (x,y,z) coordinates refer to `layout.scene`. If "scene2", the (x,y,z) coordinates refer to `layout.scene2`, and so on.</param>
    /// <param name="ColorAxis">Sets a reference to a shared color axis. References to these shared color axes are "coloraxis", "coloraxis2", "coloraxis3", etc. Settings for these shared color axes are set in the layout, under `layout.coloraxis`, `layout.coloraxis2`, etc. Note that multiple color scales can be linked to the same color axis.</param>
    /// <param name="ColorBar">Sets the ColorBar object associated with the color scale of the streamtubes</param>
    /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `colorscale`. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
    /// <param name="ColorScale">Sets the colorscale. The colorscale must be an array containing arrays mapping a normalized value to an rgb, rgba, hex, hsl, hsv, or named color string. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 'rgb(0,0,255)'], [1, 'rgb(255,0,0)']]`. To control the bounds of the colorscale in color space, use`cmin` and `cmax`. Alternatively, `colorscale` may be a palette name string of the following list: Blackbody,Bluered,Blues,Cividis,Earth,Electric,Greens,Greys,Hot,Jet,Picnic,Portland,Rainbow,RdBu,Reds,Viridis,YlGnBu,YlOrRd.</param>
    /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace.</param>
    /// <param name="ReverseScale">Reverses the color mapping if true. If true, `cmin` will correspond to the last color in the array and `cmax` will correspond to the first color.</param>
    /// <param name="CAuto">Determines whether or not the color domain is computed with respect to the input data (here u/v/w norm) or the bounds set in `cmin` and `cmax` Defaults to `false` when `cmin` and `cmax` are set by the user.</param>
    /// <param name="CMax">Sets the upper bound of the color domain. Value should have the same units as u/v/w norm and if set, `cmin` must be set as well.</param>
    /// <param name="CMid">Sets the mid-point of the color domain by scaling `cmin` and/or `cmax` to be equidistant to this point. Value should have the same units as u/v/w norm. Has no effect when `cauto` is `false`.</param>
    /// <param name="CMin">Sets the lower bound of the color domain. Value should have the same units as u/v/w norm and if set, `cmax` must be set as well.</param>
    /// <param name="HoverLabel">Sets the hover labels of this trace.</param>
    /// <param name="Lighting">Sets the Lighting of this trace.</param>
    /// <param name="LightPosition">Sets the LightPosition of this trace.</param>
    /// <param name="MaxDisplayed">The maximum number of displayed segments in a streamtube.</param>
    /// <param name="SizeRef">The scaling factor for the streamtubes. The default is 1, which avoids two max divergence tubes from touching at adjacent starting positions.</param>
    /// <param name="Starts">Sets the streamtube starting positions</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member StreamTube
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
            ?Y: seq<#IConvertible>,
            ?Z: seq<#IConvertible>,
            ?U: seq<#IConvertible>,
            ?V: seq<#IConvertible>,
            ?W: seq<#IConvertible>,
            ?Text: #IConvertible,
            ?MultiText: seq<#IConvertible>,
            ?HoverText: string,
            ?MultiHoverText: seq<string>,
            ?HoverInfo: StyleParam.HoverInfo,
            ?HoverTemplate: string,
            ?MultiHoverTemplate: seq<string>,
            ?XHoverFormat: string,
            ?YHoverFormat: string,
            ?UHoverFormat: string,
            ?VHoverFormat: string,
            ?WHoverFormat: string,
            ?Meta: seq<#IConvertible>,
            ?CustomData: seq<#IConvertible>,
            ?Scene: StyleParam.SubPlotId,
            ?ColorAxis: StyleParam.SubPlotId,
            ?ColorBar: ColorBar,
            ?AutoColorScale: bool,
            ?ColorScale: StyleParam.Colorscale,
            ?ShowScale: bool,
            ?ReverseScale: bool,
            ?ZHoverFormat: string,
            ?CAuto: bool,
            ?CMax: float,
            ?CMid: float,
            ?CMin: float,
            ?HoverLabel: Hoverlabel,
            ?Lighting: Lighting,
            ?LightPosition: LightPosition,
            ?MaxDisplayed: int,
            ?SizeRef: float,
            ?Starts: StreamTubeStarts,
            ?UIRevision: seq<#IConvertible>
        ) =
        fun (streamTube: #Trace) ->
            streamTube
            |> DynObj.withOptionalProperty               "name"              Name                                
            |> DynObj.withOptionalPropertyBy             "visible"           Visible                             StyleParam.Visible.convert
            |> DynObj.withOptionalProperty               "showlegend"        ShowLegend                          
            |> DynObj.withOptionalPropertyBy             "legend"            Legend                              StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty               "legendrank"        LegendRank                          
            |> DynObj.withOptionalProperty               "legendgroup"       LegendGroup                         
            |> DynObj.withOptionalProperty               "legendgrouptitle"  LegendGroupTitle                    
            |> DynObj.withOptionalProperty               "opacity"           Opacity                             
            |> DynObj.withOptionalProperty               "ids"               Ids                                 
            |> DynObj.withOptionalProperty               "x"                 X                                   
            |> DynObj.withOptionalProperty               "y"                 Y                                   
            |> DynObj.withOptionalProperty               "z"                 Z                                   
            |> DynObj.withOptionalProperty               "u"                 U                                   
            |> DynObj.withOptionalProperty               "v"                 V                                   
            |> DynObj.withOptionalProperty               "w"                 W                                   
            |> DynObj.withOptionalSingleOrMultiProperty  "text"              (Text, MultiText)                   
            |> DynObj.withOptionalSingleOrMultiProperty  "hovertext"         (HoverText, MultiHoverText)         
            |> DynObj.withOptionalPropertyBy             "hoverinfo"         HoverInfo                           StyleParam.HoverInfo.convert
            |> DynObj.withOptionalSingleOrMultiProperty  "hovertemplate"     (HoverTemplate, MultiHoverTemplate) 
            |> DynObj.withOptionalProperty               "xhoverformat"      XHoverFormat                        
            |> DynObj.withOptionalProperty               "yhoverformat"      YHoverFormat                        
            |> DynObj.withOptionalProperty               "zhoverformat"      ZHoverFormat                        
            |> DynObj.withOptionalProperty               "uhoverformat"      UHoverFormat                        
            |> DynObj.withOptionalProperty               "vhoverformat"      VHoverFormat                        
            |> DynObj.withOptionalProperty               "whoverformat"      WHoverFormat                        
            |> DynObj.withOptionalProperty               "meta"              Meta                                
            |> DynObj.withOptionalProperty               "customdata"        CustomData                          
            |> DynObj.withOptionalPropertyBy             "scene"             Scene                               StyleParam.SubPlotId.convert
            |> DynObj.withOptionalPropertyBy             "coloraxis"         ColorAxis                           StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty               "colorbar"          ColorBar                            
            |> DynObj.withOptionalProperty               "autocolorscale"    AutoColorScale                      
            |> DynObj.withOptionalPropertyBy             "colorscale"        ColorScale                          StyleParam.Colorscale.convert
            |> DynObj.withOptionalProperty               "showscale"         ShowScale                           
            |> DynObj.withOptionalProperty               "reversescale"      ReverseScale                        
            |> DynObj.withOptionalProperty               "cauto"             CAuto                               
            |> DynObj.withOptionalProperty               "cmin"              CMin                                
            |> DynObj.withOptionalProperty               "cmid"              CMid                                
            |> DynObj.withOptionalProperty               "cmax"              CMax                                
            |> DynObj.withOptionalProperty               "hoverlabel"        HoverLabel                          
            |> DynObj.withOptionalProperty               "lighting"          Lighting                            
            |> DynObj.withOptionalProperty               "lightposition"     LightPosition                       
            |> DynObj.withOptionalProperty               "maxdisplayed"      MaxDisplayed                        
            |> DynObj.withOptionalProperty               "sizeref"           SizeRef                             
            |> DynObj.withOptionalProperty               "starts"            Starts                              
            |> DynObj.withOptionalProperty               "uirevision"        UIRevision                          

    /// <summary>
    /// Create a function that applies the styles of a volume chart to the given trace
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the title of the legendgroup</param>
    /// <param name="Opacity">Sets the opacity of the surface. Please note that in the case of using high `opacity` values for example a value greater than or equal to 0.5 on two surfaces (and 0.25 with four surfaces), an overlay of multiple transparent surfaces may not perfectly be sorted in depth by the webgl API. This behavior may be improved in the near future and is subject to change.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="X">Sets the X coordinates of the vertices on X axis.</param>
    /// <param name="Y">Sets the Y coordinates of the vertices on Y axis.</param>
    /// <param name="Z">Sets the Z coordinates of the vertices on Z axis.</param>
    /// <param name="Value">Sets the 4th dimension (value) of the vertices.</param>
    /// <param name="Text">Sets the text elements associated with the vertices. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="MultiText">Sets the text elements associated with the vertices. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="HoverText">Same as `text`.</param>
    /// <param name="MultiHoverText">Same as `text`.</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
    /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="MultiHoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="XHoverFormat">Sets the hover text formatting rulefor `x` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="YHoverFormat">Sets the hover text formatting rulefor `y` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `yaxis.hoverformat`.</param>
    /// <param name="ZHoverFormat">Sets the hover text formatting rulefor `z` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `zaxis.hoverformat`</param>
    /// <param name="ValueHoverFormat">Sets the hover text formatting rulefor `value` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.By default the values are formatted using generic number format.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="Scene">Sets a reference between this trace's 3D coordinate system and a 3D scene. If "scene" (the default value), the (x,y,z) coordinates refer to `layout.scene`. If "scene2", the (x,y,z) coordinates refer to `layout.scene2`, and so on.</param>
    /// <param name="ColorAxis">Sets a reference to a shared color axis. References to these shared color axes are "coloraxis", "coloraxis2", "coloraxis3", etc. Settings for these shared color axes are set in the layout, under `layout.coloraxis`, `layout.coloraxis2`, etc. Note that multiple color scales can be linked to the same color axis.</param>
    /// <param name="ColorBar">Sets the colorbar of this trace</param>
    /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `colorscale`. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
    /// <param name="ColorScale">Sets the colorscale. The colorscale must be an array containing arrays mapping a normalized value to an rgb, rgba, hex, hsl, hsv, or named color string. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 'rgb(0,0,255)'], [1, 'rgb(255,0,0)']]`. To control the bounds of the colorscale in color space, use`cmin` and `cmax`. Alternatively, `colorscale` may be a palette name string of the following list: Blackbody,Bluered,Blues,Cividis,Earth,Electric,Greens,Greys,Hot,Jet,Picnic,Portland,Rainbow,RdBu,Reds,Viridis,YlGnBu,YlOrRd.</param>
    /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace.</param>
    /// <param name="ReverseScale">Reverses the color mapping if true. If true, `cmin` will correspond to the last color in the array and `cmax` will correspond to the first color.</param>
    /// <param name="CAuto">Determines whether or not the color domain is computed with respect to the input data (here `value`) or the bounds set in `cmin` and `cmax` Defaults to `false` when `cmin` and `cmax` are set by the user.</param>
    /// <param name="CMin">Sets the lower bound of the color domain. Value should have the same units as `value` and if set, `cmax` must be set as well.</param>
    /// <param name="CMid">Sets the mid-point of the color domain by scaling `cmin` and/or `cmax` to be equidistant to this point. Value should have the same units as `value`. Has no effect when `cauto` is `false`.</param>
    /// <param name="CMax">Sets the upper bound of the color domain. Value should have the same units as `value` and if set, `cmin` must be set as well.</param>
    /// <param name="Caps">Sets the caps of this trace caps (color-coded surfaces on the sides of the visualization domain)</param>
    /// <param name="Contour">Sets the contour of this trace.</param>
    /// <param name="FlatShading">Determines whether or not normal smoothing is applied to the meshes, creating meshes with an angular, low-poly look via flat reflections.</param>
    /// <param name="HoverLabel">Sets the hover labels of this trace.</param>
    /// <param name="IsoMax">Sets the maximum boundary for iso-surface plot.</param>
    /// <param name="IsoMin">Sets the minimum boundary for iso-surface plot.</param>
    /// <param name="Lighting">Sets the Lighting of this trace.</param>
    /// <param name="LightPosition">Sets the LightPosition of this trace.</param>
    /// <param name="OpacityScale">Sets the opacityscale. The opacityscale must be an array containing arrays mapping a normalized value to an opacity value. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 1], [0.5, 0.2], [1, 1]]` means that higher/lower values would have higher opacity values and those in the middle would be more transparent Alternatively, `opacityscale` may be a palette name string of the following list: 'min', 'max', 'extremes' and 'uniform'. The default is 'uniform'.</param>
    /// <param name="Slices">Sets slices through the volume</param>
    /// <param name="SpaceFrame">Sets the SpaceFrame of this trace.</param>
    /// <param name="Surface">Sets the Surface of this trace.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member Volume
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
            ?Y: seq<#IConvertible>,
            ?Z: seq<#IConvertible>,
            ?Value: seq<#IConvertible>,
            ?Text: #IConvertible,
            ?MultiText: seq<#IConvertible>,
            ?HoverText: string,
            ?MultiHoverText: seq<string>,
            ?HoverInfo: StyleParam.HoverInfo,
            ?HoverTemplate: string,
            ?MultiHoverTemplate: seq<string>,
            ?XHoverFormat: string,
            ?YHoverFormat: string,
            ?ValueHoverFormat: string,
            ?Meta: seq<#IConvertible>,
            ?CustomData: seq<#IConvertible>,
            ?Scene: StyleParam.SubPlotId,
            ?ColorAxis: StyleParam.SubPlotId,
            ?ColorBar: ColorBar,
            ?AutoColorScale: bool,
            ?ColorScale: StyleParam.Colorscale,
            ?ShowScale: bool,
            ?ReverseScale: bool,
            ?ZHoverFormat: string,
            ?CAuto: bool,
            ?CMax: float,
            ?CMid: float,
            ?CMin: float,
            ?Caps: Caps,
            ?Contour: Contour,
            ?FlatShading: bool,
            ?HoverLabel: Hoverlabel,
            ?IsoMax: float,
            ?IsoMin: float,
            ?Lighting: Lighting,
            ?LightPosition: LightPosition,
            ?OpacityScale: seq<#seq<#IConvertible>>,
            ?Slices: Slices,
            ?SpaceFrame: Spaceframe,
            ?Surface: Surface,
            ?UIRevision: seq<#IConvertible>
        ) =
        fun (volume: #Trace) ->

            volume
            |> DynObj.withOptionalProperty               "name"               Name                                
            |> DynObj.withOptionalPropertyBy             "visible"            Visible                             StyleParam.Visible.convert
            |> DynObj.withOptionalProperty               "showlegend"         ShowLegend                          
            |> DynObj.withOptionalPropertyBy             "legend"             Legend                              StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty               "legendrank"         LegendRank                          
            |> DynObj.withOptionalProperty               "legendgroup"        LegendGroup                         
            |> DynObj.withOptionalProperty               "legendgrouptitle"   LegendGroupTitle                    
            |> DynObj.withOptionalProperty               "opacity"            Opacity                             
            |> DynObj.withOptionalProperty               "ids"                Ids                                 
            |> DynObj.withOptionalProperty               "x"                  X                                   
            |> DynObj.withOptionalProperty               "y"                  Y                                   
            |> DynObj.withOptionalProperty               "z"                  Z                                   
            |> DynObj.withOptionalProperty               "value"              Value                               
            |> DynObj.withOptionalSingleOrMultiProperty  "text"               (Text, MultiText)                   
            |> DynObj.withOptionalSingleOrMultiProperty  "hovertext"          (HoverText, MultiHoverText)         
            |> DynObj.withOptionalPropertyBy             "hoverinfo"          HoverInfo                           StyleParam.HoverInfo.convert
            |> DynObj.withOptionalSingleOrMultiProperty  "hovertemplate"      (HoverTemplate, MultiHoverTemplate) 
            |> DynObj.withOptionalProperty               "xhoverformat"       XHoverFormat                        
            |> DynObj.withOptionalProperty               "yhoverformat"       YHoverFormat                        
            |> DynObj.withOptionalProperty               "zhoverformat"       ZHoverFormat                        
            |> DynObj.withOptionalProperty               "valuehoverformat"   ValueHoverFormat                    
            |> DynObj.withOptionalProperty               "meta"               Meta                                
            |> DynObj.withOptionalProperty               "customdata"         CustomData                          
            |> DynObj.withOptionalPropertyBy             "scene"              Scene                               StyleParam.SubPlotId.convert
            |> DynObj.withOptionalPropertyBy             "coloraxis"          ColorAxis                           StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty               "colorbar"           ColorBar                            
            |> DynObj.withOptionalProperty               "autocolorscale"     AutoColorScale                      
            |> DynObj.withOptionalPropertyBy             "colorscale"         ColorScale                          StyleParam.Colorscale.convert
            |> DynObj.withOptionalProperty               "showscale"          ShowScale                           
            |> DynObj.withOptionalProperty               "reversescale"       ReverseScale                        
            |> DynObj.withOptionalProperty               "cauto"              CAuto                               
            |> DynObj.withOptionalProperty               "cmin"               CMin                                
            |> DynObj.withOptionalProperty               "cmid"               CMid                                
            |> DynObj.withOptionalProperty               "cmax"               CMax                                
            |> DynObj.withOptionalProperty               "caps"               Caps                                
            |> DynObj.withOptionalProperty               "contour"            Contour                             
            |> DynObj.withOptionalProperty               "flatshading"        FlatShading                         
            |> DynObj.withOptionalProperty               "hoverlabel"         HoverLabel                          
            |> DynObj.withOptionalProperty               "isomax"             IsoMax                              
            |> DynObj.withOptionalProperty               "isomin"             IsoMin                              
            |> DynObj.withOptionalProperty               "lighting"           Lighting                            
            |> DynObj.withOptionalProperty               "lightposition"      LightPosition                       
            |> DynObj.withOptionalProperty               "opacityscale"       OpacityScale                        
            |> DynObj.withOptionalProperty               "slices"             Slices                              
            |> DynObj.withOptionalProperty               "spaceframe"         SpaceFrame                          
            |> DynObj.withOptionalProperty               "surface"            Surface                             
            |> DynObj.withOptionalProperty               "uirevision"         UIRevision                          

    /// <summary>
    /// Create a function that applies the styles of a isosurface chart to the given trace
    /// </summary>
    /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
    /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
    /// <param name="Legend">Sets the reference to a legend to show this trace in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
    /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the title of the legendgroup</param>
    /// <param name="Opacity">Sets the opacity of the surface. Please note that in the case of using high `opacity` values for example a value greater than or equal to 0.5 on two surfaces (and 0.25 with four surfaces), an overlay of multiple transparent surfaces may not perfectly be sorted in depth by the webgl API. This behavior may be improved in the near future and is subject to change.</param>
    /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
    /// <param name="X">Sets the X coordinates of the vertices on X axis.</param>
    /// <param name="Y">Sets the Y coordinates of the vertices on Y axis.</param>
    /// <param name="Z">Sets the Z coordinates of the vertices on Z axis.</param>
    /// <param name="Value">Sets the 4th dimension (value) of the vertices.</param>
    /// <param name="Text">Sets the text elements associated with the vertices. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="MultiText">Sets the text elements associated with the vertices. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
    /// <param name="HoverText">Same as `text`.</param>
    /// <param name="MultiHoverText">Same as `text`.</param>
    /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
    /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="MultiHoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
    /// <param name="XHoverFormat">Sets the hover text formatting rulefor `x` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
    /// <param name="YHoverFormat">Sets the hover text formatting rulefor `y` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `yaxis.hoverformat`.</param>
    /// <param name="ZHoverFormat">Sets the hover text formatting rulefor `z` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `zaxis.hoverformat`</param>
    /// <param name="ValueHoverFormat">Sets the hover text formatting rulefor `value` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.By default the values are formatted using generic number format.</param>
    /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
    /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
    /// <param name="Scene">Sets a reference between this trace's 3D coordinate system and a 3D scene. If "scene" (the default value), the (x,y,z) coordinates refer to `layout.scene`. If "scene2", the (x,y,z) coordinates refer to `layout.scene2`, and so on.</param>
    /// <param name="ColorAxis">Sets a reference to a shared color axis. References to these shared color axes are "coloraxis", "coloraxis2", "coloraxis3", etc. Settings for these shared color axes are set in the layout, under `layout.coloraxis`, `layout.coloraxis2`, etc. Note that multiple color scales can be linked to the same color axis.</param>
    /// <param name="ColorBar">Sets the colorbar of this trace</param>
    /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `colorscale`. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
    /// <param name="ColorScale">Sets the colorscale. The colorscale must be an array containing arrays mapping a normalized value to an rgb, rgba, hex, hsl, hsv, or named color string. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 'rgb(0,0,255)'], [1, 'rgb(255,0,0)']]`. To control the bounds of the colorscale in color space, use`cmin` and `cmax`. Alternatively, `colorscale` may be a palette name string of the following list: Blackbody,Bluered,Blues,Cividis,Earth,Electric,Greens,Greys,Hot,Jet,Picnic,Portland,Rainbow,RdBu,Reds,Viridis,YlGnBu,YlOrRd.</param>
    /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace.</param>
    /// <param name="ReverseScale">Reverses the color mapping if true. If true, `cmin` will correspond to the last color in the array and `cmax` will correspond to the first color.</param>
    /// <param name="CAuto">Determines whether or not the color domain is computed with respect to the input data (here `value`) or the bounds set in `cmin` and `cmax` Defaults to `false` when `cmin` and `cmax` are set by the user.</param>
    /// <param name="CMin">Sets the lower bound of the color domain. Value should have the same units as `value` and if set, `cmax` must be set as well.</param>
    /// <param name="CMid">Sets the mid-point of the color domain by scaling `cmin` and/or `cmax` to be equidistant to this point. Value should have the same units as `value`. Has no effect when `cauto` is `false`.</param>
    /// <param name="CMax">Sets the upper bound of the color domain. Value should have the same units as `value` and if set, `cmin` must be set as well.</param>
    /// <param name="Caps">Sets the caps of this trace caps (color-coded surfaces on the sides of the visualization domain)</param>
    /// <param name="Contour">Sets the contour of this trace.</param>
    /// <param name="FlatShading">Determines whether or not normal smoothing is applied to the meshes, creating meshes with an angular, low-poly look via flat reflections.</param>
    /// <param name="HoverLabel">Sets the hover labels of this trace.</param>
    /// <param name="IsoMax">Sets the maximum boundary for iso-surface plot.</param>
    /// <param name="IsoMin">Sets the minimum boundary for iso-surface plot.</param>
    /// <param name="Lighting">Sets the Lighting of this trace.</param>
    /// <param name="LightPosition">Sets the LightPosition of this trace.</param>
    /// <param name="OpacityScale">Sets the opacityscale. The opacityscale must be an array containing arrays mapping a normalized value to an opacity value. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 1], [0.5, 0.2], [1, 1]]` means that higher/lower values would have higher opacity values and those in the middle would be more transparent Alternatively, `opacityscale` may be a palette name string of the following list: 'min', 'max', 'extremes' and 'uniform'. The default is 'uniform'.</param>
    /// <param name="Slices">Sets slices through the volume</param>
    /// <param name="SpaceFrame">Sets the SpaceFrame of this trace.</param>
    /// <param name="Surface">Sets the Surface of this trace.</param>
    /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
    static member IsoSurface
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
            ?Y: seq<#IConvertible>,
            ?Z: seq<#IConvertible>,
            ?Value: seq<#IConvertible>,
            ?Text: #IConvertible,
            ?MultiText: seq<#IConvertible>,
            ?HoverText: string,
            ?MultiHoverText: seq<string>,
            ?HoverInfo: StyleParam.HoverInfo,
            ?HoverTemplate: string,
            ?MultiHoverTemplate: seq<string>,
            ?XHoverFormat: string,
            ?YHoverFormat: string,
            ?ValueHoverFormat: string,
            ?Meta: seq<#IConvertible>,
            ?CustomData: seq<#IConvertible>,
            ?Scene: StyleParam.SubPlotId,
            ?ColorAxis: StyleParam.SubPlotId,
            ?ColorBar: ColorBar,
            ?AutoColorScale: bool,
            ?ColorScale: StyleParam.Colorscale,
            ?ShowScale: bool,
            ?ReverseScale: bool,
            ?ZHoverFormat: string,
            ?CAuto: bool,
            ?CMax: float,
            ?CMid: float,
            ?CMin: float,
            ?Caps: Caps,
            ?Contour: Contour,
            ?FlatShading: bool,
            ?HoverLabel: Hoverlabel,
            ?IsoMax: float,
            ?IsoMin: float,
            ?Lighting: Lighting,
            ?LightPosition: LightPosition,
            ?OpacityScale: seq<#seq<#IConvertible>>,
            ?Slices: Slices,
            ?SpaceFrame: Spaceframe,
            ?Surface: Surface,
            ?UIRevision: seq<#IConvertible>
        ) =
        fun (isoSurface: #Trace) ->

            isoSurface
            |> DynObj.withOptionalProperty               "name"               Name                                
            |> DynObj.withOptionalPropertyBy             "visible"            Visible                             StyleParam.Visible.convert
            |> DynObj.withOptionalProperty               "showlegend"         ShowLegend                          
            |> DynObj.withOptionalPropertyBy             "legend"             Legend                              StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty               "legendrank"         LegendRank                          
            |> DynObj.withOptionalProperty               "legendgroup"        LegendGroup                         
            |> DynObj.withOptionalProperty               "legendgrouptitle"   LegendGroupTitle                    
            |> DynObj.withOptionalProperty               "opacity"            Opacity                             
            |> DynObj.withOptionalProperty               "ids"                Ids                                 
            |> DynObj.withOptionalProperty               "x"                  X                                   
            |> DynObj.withOptionalProperty               "y"                  Y                                   
            |> DynObj.withOptionalProperty               "z"                  Z                                   
            |> DynObj.withOptionalProperty               "value"              Value                               
            |> DynObj.withOptionalSingleOrMultiProperty  "text"               (Text, MultiText)                   
            |> DynObj.withOptionalSingleOrMultiProperty  "hovertext"          (HoverText, MultiHoverText)         
            |> DynObj.withOptionalPropertyBy             "hoverinfo"          HoverInfo                           StyleParam.HoverInfo.convert
            |> DynObj.withOptionalSingleOrMultiProperty  "hovertemplate"      (HoverTemplate, MultiHoverTemplate) 
            |> DynObj.withOptionalProperty               "xhoverformat"       XHoverFormat                        
            |> DynObj.withOptionalProperty               "yhoverformat"       YHoverFormat                        
            |> DynObj.withOptionalProperty               "zhoverformat"       ZHoverFormat                        
            |> DynObj.withOptionalProperty               "valuehoverformat"   ValueHoverFormat                    
            |> DynObj.withOptionalProperty               "meta"               Meta                                
            |> DynObj.withOptionalProperty               "customdata"         CustomData                          
            |> DynObj.withOptionalPropertyBy             "scene"              Scene                               StyleParam.SubPlotId.convert
            |> DynObj.withOptionalPropertyBy             "coloraxis"          ColorAxis                           StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty               "colorbar"           ColorBar                            
            |> DynObj.withOptionalProperty               "autocolorscale"     AutoColorScale                      
            |> DynObj.withOptionalPropertyBy             "colorscale"         ColorScale                          StyleParam.Colorscale.convert
            |> DynObj.withOptionalProperty               "showscale"          ShowScale                           
            |> DynObj.withOptionalProperty               "reversescale"       ReverseScale                        
            |> DynObj.withOptionalProperty               "cauto"              CAuto                               
            |> DynObj.withOptionalProperty               "cmin"               CMin                                
            |> DynObj.withOptionalProperty               "cmid"               CMid                                
            |> DynObj.withOptionalProperty               "cmax"               CMax                                
            |> DynObj.withOptionalProperty               "caps"               Caps                                
            |> DynObj.withOptionalProperty               "contour"            Contour                             
            |> DynObj.withOptionalProperty               "flatshading"        FlatShading                         
            |> DynObj.withOptionalProperty               "hoverlabel"         HoverLabel                          
            |> DynObj.withOptionalProperty               "isomax"             IsoMax                              
            |> DynObj.withOptionalProperty               "isomin"             IsoMin                              
            |> DynObj.withOptionalProperty               "lighting"           Lighting                            
            |> DynObj.withOptionalProperty               "lightposition"      LightPosition                       
            |> DynObj.withOptionalProperty               "opacityscale"       OpacityScale                        
            |> DynObj.withOptionalProperty               "slices"             Slices                              
            |> DynObj.withOptionalProperty               "spaceframe"         SpaceFrame                          
            |> DynObj.withOptionalProperty               "surface"            Surface                             
            |> DynObj.withOptionalProperty               "uirevision"         UIRevision                          