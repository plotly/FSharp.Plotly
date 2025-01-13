namespace Plotly.NET

open DynamicObj
open InternalUtils
open Plotly.NET.LayoutObjects
open System
open System.Runtime.InteropServices

/// A Layout object in the context of plotly charts contains all styling options that are not directly related to the visualization of the data itself, such as axes, legends, watermarks, etc.
type Layout() =
    inherit DynamicObj()

    /// <summary>
    /// Returns a new Layout object with the given styling.
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
    static member init
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
        Layout()
        |> Layout.style (
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

    /// <summary>
    /// Returns a function that applies the given styles to a Layout object.
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
    static member style
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
        (fun (layout: Layout) ->
            layout
            |> DynObj.withOptionalProperty   "title"                  Title                  
            |> DynObj.withOptionalProperty   "showlegend"             ShowLegend             
            |> DynObj.withOptionalProperty   "margin"                 Margin                 
            |> DynObj.withOptionalProperty   "autosize"               AutoSize               
            |> DynObj.withOptionalProperty   "width"                  Width                  
            |> DynObj.withOptionalProperty   "height"                 Height                 
            |> DynObj.withOptionalProperty   "font"                   Font                   
            |> DynObj.withOptionalProperty   "uniformtext"            UniformText            
            |> DynObj.withOptionalProperty   "separators"             Separators             
            |> DynObj.withOptionalProperty   "paper_bgcolor"          PaperBGColor           
            |> DynObj.withOptionalProperty   "plot_bgcolor"           PlotBGColor            
            |> DynObj.withOptionalPropertyBy "autotypenumbers"        AutoTypeNumbers        StyleParam.AutoTypeNumbers.convert
            |> DynObj.withOptionalProperty   "colorscale"             Colorscale             
            |> DynObj.withOptionalProperty   "colorway"               Colorway               
            |> DynObj.withOptionalProperty   "modebar"                ModeBar                
            |> DynObj.withOptionalPropertyBy "hovermode"              HoverMode              StyleParam.HoverMode.convert
            |> DynObj.withOptionalPropertyBy "clickmode"              ClickMode              StyleParam.ClickMode.convert
            |> DynObj.withOptionalPropertyBy "dragmode"               DragMode               StyleParam.DragMode.convert
            |> DynObj.withOptionalPropertyBy "selectdirection"        SelectDirection        StyleParam.SelectDirection.convert
            |> DynObj.withOptionalProperty   "activeselection"        ActiveSelection        
            |> DynObj.withOptionalProperty   "newselection"           NewSelection           
            |> DynObj.withOptionalProperty   "hoverdistance"          HoverDistance          
            |> DynObj.withOptionalProperty   "spikedistance"          SpikeDistance          
            |> DynObj.withOptionalProperty   "hoverlabel"             Hoverlabel             
            |> DynObj.withOptionalProperty   "transition"             Transition             
            |> DynObj.withOptionalProperty   "datarevision"           DataRevision           
            |> DynObj.withOptionalProperty   "uirevision"             UIRevision             
            |> DynObj.withOptionalProperty   "editrevision"           EditRevision           
            |> DynObj.withOptionalProperty   "selectrevision"         SelectRevision         
            |> DynObj.withOptionalProperty   "template"               Template               
            |> DynObj.withOptionalProperty   "meta"                   Meta                   
            |> DynObj.withOptionalProperty   "computed"               Computed               
            |> DynObj.withOptionalProperty   "grid"                   Grid                   
            |> DynObj.withOptionalPropertyBy "calendar"               Calendar               StyleParam.Calendar.convert
            |> DynObj.withOptionalProperty   "minreducedheight"       MinReducedHeight       
            |> DynObj.withOptionalProperty   "minreducedwidth"        MinReducedWidth        
            |> DynObj.withOptionalProperty   "newshape"               NewShape               
            |> DynObj.withOptionalProperty   "activeshape"            ActiveShape            
            |> DynObj.withOptionalProperty   "hidesources"            HideSources            
            |> DynObj.withOptionalProperty   "scattergap"             ScatterGap             
            |> DynObj.withOptionalPropertyBy "scattermode"            ScatterMode            StyleParam.ScatterMode.convert
            |> DynObj.withOptionalProperty   "bargap"                 BarGap                 
            |> DynObj.withOptionalProperty   "bargroupgap"            BarGroupGap            
            |> DynObj.withOptionalPropertyBy "barmode"                BarMode                StyleParam.BarMode.convert
            |> DynObj.withOptionalPropertyBy "barnorm"                BarNorm                StyleParam.BarNorm.convert
            |> DynObj.withOptionalProperty   "extendpiecolors"        ExtendPieColors        
            |> DynObj.withOptionalProperty   "hiddenlabels"           HiddenLabels           
            |> DynObj.withOptionalProperty   "piecolorway"            PieColorWay            
            |> DynObj.withOptionalProperty   "boxgap"                 BoxGap                 
            |> DynObj.withOptionalProperty   "boxgroupgap"            BoxGroupGap            
            |> DynObj.withOptionalPropertyBy "boxmode"                BoxMode                StyleParam.BoxMode.convert
            |> DynObj.withOptionalProperty   "violingap"              ViolinGap              
            |> DynObj.withOptionalProperty   "violingroupgap"         ViolinGroupGap         
            |> DynObj.withOptionalPropertyBy "violinmode"             ViolinMode             StyleParam.ViolinMode.convert
            |> DynObj.withOptionalProperty   "waterfallgap"           WaterfallGap           
            |> DynObj.withOptionalProperty   "waterfallgroupgap"      WaterfallGroupGap      
            |> DynObj.withOptionalPropertyBy "waterfallmode"          WaterfallMode          StyleParam.WaterfallMode.convert
            |> DynObj.withOptionalProperty   "funnelgap"              FunnelGap              
            |> DynObj.withOptionalProperty   "funnelgroupgap"         FunnelGroupGap         
            |> DynObj.withOptionalPropertyBy "funnelmode"             FunnelMode             StyleParam.FunnelMode.convert
            |> DynObj.withOptionalProperty   "extendfunnelareacolors" ExtendFunnelAreaColors 
            |> DynObj.withOptionalProperty   "funnelareacolorway"     FunnelAreaColorWay     
            |> DynObj.withOptionalProperty   "extendsunburstcolors"   ExtendSunBurstColors   
            |> DynObj.withOptionalProperty   "sunburstcolorway"       SunBurstColorWay       
            |> DynObj.withOptionalProperty   "extendtreemapcolors"    ExtendTreeMapColors    
            |> DynObj.withOptionalProperty   "treemapcolorway"        TreeMapColorWay        
            |> DynObj.withOptionalProperty   "extendiciclecolors"     ExtendIcicleColors     
            |> DynObj.withOptionalProperty   "iciclecolorway"         IcicleColorWay         
            |> DynObj.withOptionalProperty   "annotations"            Annotations            
            |> DynObj.withOptionalProperty   "shapes"                 Shapes                 
            |> DynObj.withOptionalProperty   "selections"             Selections             
            |> DynObj.withOptionalProperty   "images"                 Images                 
            |> DynObj.withOptionalProperty   "sliders"                Sliders                
            |> DynObj.withOptionalProperty   "updatemenus"            UpdateMenus            
        )

    /// <summary>
    /// Combines two Layout objects.
    ///
    /// In case of duplicate dynamic member values, the values of the second Layout are used.
    ///
    /// For the collections used for the dynamic members
    ///
    /// annotations, shapes, selections, images, sliders, hiddenlabels, updatemenus
    ///
    /// the values from the second Layout are appended to those of the first instead.
    /// </summary>
    /// <param name="first">The first Layout to combine with the second</param>
    /// <param name="second">The second Layout to combine with the first</param>
    static member combine (first: Layout) (second: Layout) =

        let annotations =
            InternalUtils.combineOptSeqs
                (first.TryGetTypedPropertyValue<seq<Annotation>>("annotations"))
                (second.TryGetTypedPropertyValue<seq<Annotation>>("annotations"))

        let shapes =
            InternalUtils.combineOptSeqs
                (first.TryGetTypedPropertyValue<seq<Shape>>("shapes"))
                (second.TryGetTypedPropertyValue<seq<Shape>>("shapes"))

        let selections =
            InternalUtils.combineOptSeqs
                (first.TryGetTypedPropertyValue<seq<Selection>>("selections"))
                (second.TryGetTypedPropertyValue<seq<Selection>>("selections"))

        let images =
            InternalUtils.combineOptSeqs
                (first.TryGetTypedPropertyValue<seq<LayoutImage>>("images"))
                (second.TryGetTypedPropertyValue<seq<LayoutImage>>("images"))

        let sliders =
            InternalUtils.combineOptSeqs
                (first.TryGetTypedPropertyValue<seq<Slider>>("sliders"))
                (second.TryGetTypedPropertyValue<seq<Slider>>("sliders"))

        let hiddenLabels =
            InternalUtils.combineOptSeqs
                (first.TryGetTypedPropertyValue<seq<string>>("hiddenlabels"))
                (second.TryGetTypedPropertyValue<seq<string>>("hiddenlabels"))

        let updateMenus =
            InternalUtils.combineOptSeqs
                (first.TryGetTypedPropertyValue<seq<UpdateMenu>>("updatemenus"))
                (second.TryGetTypedPropertyValue<seq<UpdateMenu>>("updatemenus"))

        DynObj.combine first second
        |> unbox<Layout>
        |> Layout.style (
            ?Annotations = annotations,
            ?Shapes = shapes,
            ?Selections = selections,
            ?Images = images,
            ?Sliders = sliders,
            ?HiddenLabels = hiddenLabels,
            ?UpdateMenus = updateMenus
        )

    /// <summary>
    /// Returns Some(dynamic member value) of the trace object's underlying DynamicObj when a dynamic member with the given name exists, and None otherwise.
    /// </summary>
    /// <param name="propName">The name of the dynamic member to get the value of</param>
    /// <param name="layout">The layout to get the dynamic member value from</param>
    static member tryGetTypedMember<'T> (propName: string) (layout: Layout) = layout.TryGetTypedPropertyValue<'T>(propName)

    /// <summary>
    /// Returns Some(LinearAxis) if there is an axis object set on the layout with the given id, and None otherwise.
    /// </summary>
    /// <param name="id">The target axis id</param>
    static member tryGetLinearAxisById(id: StyleParam.SubPlotId) =
        (fun (layout: Layout) -> layout.TryGetTypedPropertyValue<LinearAxis>(StyleParam.SubPlotId.toString id))

    /// <summary>
    /// Combines the given axis object with the one already present on the layout.
    /// </summary>
    /// <param name="id">The target axis id</param>
    /// <param name="axis">The updated axis object.</param>
    static member updateLinearAxisById(id: StyleParam.SubPlotId, axis: LinearAxis) =
        (fun (layout: Layout) ->
            match id with
            | StyleParam.SubPlotId.XAxis _
            | StyleParam.SubPlotId.YAxis _ ->
                let axis' =
                    match Layout.tryGetLinearAxisById id layout with
                    | Some a -> DynObj.combine a axis |> unbox<LinearAxis>
                    | None -> axis
                layout
                |> DynObj.withProperty (StyleParam.SubPlotId.toString id) axis'
            | _ ->
                failwith
                    $"{StyleParam.SubPlotId.toString id} is an invalid subplot id for setting a linear axis on layout")

    /// <summary>
    /// Returns the linear axis object of the layout with the given id.
    ///
    /// If there is no linear axis set, returns an empty LinearAxis object.
    /// </summary>
    /// <param name="id">The target axis id</param>
    static member getLinearAxisById(id: StyleParam.SubPlotId) =
        (fun (layout: Layout) -> layout |> Layout.tryGetLinearAxisById id |> Option.defaultValue (LinearAxis.init ()))

    /// <summary>
    /// Returns a sequence of key-value pairs of the layout's dynamic members that are valid x axes (if the key matches and object can be cast to the correct type).
    /// </summary>
    /// <param name="layout">The layout to get the x axes from</param>
    static member getXAxes (layout: Layout) =
        layout.GetProperties(includeInstanceProperties = false)
        |> Array.ofSeq
        |> Array.choose (fun kv -> 
            if StyleParam.SubPlotId.isValidXAxisId kv.Key then
                match layout.TryGetTypedPropertyValue<LinearAxis>(kv.Key) with
                | Some axis -> Some (kv.Key, axis)
                | None -> None
            else None
        )

    /// <summary>
    /// Returns a sequence of key-value pairs of the layout's dynamic members that are valid y axes (if the key matches and object can be cast to the correct type).
    /// </summary>
    /// <param name="layout">The layout to get the y axes from</param>
    static member getYAxes (layout: Layout) =
        layout.GetProperties(includeInstanceProperties = false)
        |> Array.ofSeq
        |> Array.choose (fun kv -> 
            if StyleParam.SubPlotId.isValidYAxisId kv.Key then
                match layout.TryGetTypedPropertyValue<LinearAxis>(kv.Key) with
                | Some axis -> Some (kv.Key, axis)
                | None -> None
            else None
        )

    /// <summary>
    /// Sets a linear axis object on the layout as a dynamic property with the given axis id.
    /// </summary>
    /// <param name="id">The axis id of the new axis</param>
    /// <param name="axis">The axis to add to the layout.</param>
    static member setLinearAxis(id: StyleParam.SubPlotId, axis: LinearAxis) =
        (fun (layout: Layout) ->

            match id with
            | StyleParam.SubPlotId.XAxis _
            | StyleParam.SubPlotId.YAxis _ ->
                layout |> DynObj.withProperty (StyleParam.SubPlotId.toString id) axis
            | _ ->
                failwith
                    $"{StyleParam.SubPlotId.toString id} is an invalid subplot id for setting a linear axis on layout")

    /// <summary>
    /// Returns Some(Scene) if there is a scene object set on the layout with the given id, and None otherwise.
    /// </summary>
    /// <param name="id">The target scene id</param>
    static member tryGetSceneById(id: StyleParam.SubPlotId) =
        (fun (layout: Layout) -> layout.TryGetTypedPropertyValue<Scene>(StyleParam.SubPlotId.toString id))

    /// <summary>
    /// Combines the given scene object with the one already present on the layout.
    /// </summary>
    /// <param name="id">The target scene id</param>
    /// <param name="scene">The updated scene object.</param>
    static member updateSceneById(id: StyleParam.SubPlotId, scene: Scene) =
        (fun (layout: Layout) ->
            let scene' =
                match Layout.tryGetSceneById id layout with
                | Some a -> DynObj.combine a scene
                | None -> scene
            layout
            |> DynObj.withProperty (StyleParam.SubPlotId.toString id) scene'
        )

    /// <summary>
    /// Returns the Scene object of the layout with the given id.
    ///
    /// If there is no scene set, returns an empty Scene object.
    /// </summary>
    /// <param name="id">The target scene id</param>
    static member getSceneById(id: StyleParam.SubPlotId) =
        (fun (layout: Layout) -> layout |> Layout.tryGetSceneById id |> Option.defaultValue (Scene.init ()))


    /// <summary>
    /// Returns a sequence of key-value pairs of the layout's dynamic members that are valid scenes (if the key matches and object can be cast to the correct type).
    /// </summary>
    /// <param name="layout">The layout to get the scenes from</param>
    static member getScenes (layout: Layout) =
        layout.GetProperties(includeInstanceProperties = false)
        |> Array.ofSeq
        |> Array.choose (fun kv -> 
            if StyleParam.SubPlotId.isValidSceneId kv.Key then
                match layout.TryGetTypedPropertyValue<Scene>(kv.Key) with
                | Some scene -> Some (kv.Key, scene)
                | None -> None
            else None
        )

    /// <summary>
    /// Sets a scene object on the layout as a dynamic property with the given scene id.
    /// </summary>
    /// <param name="id">The scene id of the new scene</param>
    /// <param name="scene">The scene to add to the layout.</param>
    static member setScene(id: StyleParam.SubPlotId, scene: Scene) =
        (fun (layout: Layout) ->
            layout |> DynObj.withProperty (StyleParam.SubPlotId.toString id) scene
        )

    /// <summary>
    /// Returns Some(Geo) if there is a geo object set on the layout with the given id, and None otherwise.
    /// </summary>
    /// <param name="id">The target geo id</param>
    static member tryGetGeoById(id: StyleParam.SubPlotId) =
        (fun (layout: Layout) -> layout.TryGetTypedPropertyValue<Geo>(StyleParam.SubPlotId.toString id))

    /// <summary>
    /// Combines the given geo object with the one already present on the layout.
    /// </summary>
    /// <param name="id">The target geo id</param>
    /// <param name="geo">The updated geo object.</param>
    static member updateGeoById(id: StyleParam.SubPlotId, geo: Geo) =
        (fun (layout: Layout) ->
            let geo' =
                match Layout.tryGetGeoById id layout with
                | Some a -> DynObj.combine a geo
                | None -> geo

            layout|> DynObj.withProperty (StyleParam.SubPlotId.toString id) geo'
        )

    /// <summary>
    /// Returns the Geo object of the layout with the given id.
    ///
    /// If there is no geo set, returns an empty Geo object.
    /// </summary>
    /// <param name="id">The target geo id</param>
    static member getGeoById(id: StyleParam.SubPlotId) =
        (fun (layout: Layout) -> layout |> Layout.tryGetGeoById id |> Option.defaultValue (Geo.init ()))

    /// <summary>
    /// Returns a sequence of key-value pairs of the layout's dynamic members that are valid geo subplots (if the key matches and object can be cast to the correct type).
    /// </summary>
    /// <param name="layout">The layout to get the geos from</param>
    static member getGeos (layout: Layout) =
        layout.GetProperties(includeInstanceProperties = false)
        |> Array.ofSeq
        |> Array.choose (fun kv -> 
            if StyleParam.SubPlotId.isValidGeoId kv.Key then
                match layout.TryGetTypedPropertyValue<Geo>(kv.Key) with
                | Some geo -> Some (kv.Key, geo)
                | None -> None
            else None
        )

    /// <summary>
    /// Sets a geo object on the layout as a dynamic property with the given geo id.
    /// </summary>
    /// <param name="id">The scene id of the new geo</param>
    /// <param name="geo">The geo to add to the layout.</param>
    static member setGeo(id: StyleParam.SubPlotId, geo: Geo) =
        (fun (layout: Layout) ->
            layout |> DynObj.withProperty (StyleParam.SubPlotId.toString id) geo
        )

    /// <summary>
    /// Returns Some(Mapbox) if there is amapbox object set on the layout with the given id, and None otherwise.
    /// </summary>
    /// <param name="id">The target mapbox id</param>
    static member tryGetMapboxById(id: StyleParam.SubPlotId) =
        (fun (layout: Layout) -> layout.TryGetTypedPropertyValue<Mapbox>(StyleParam.SubPlotId.toString id))

    /// <summary>
    /// Combines the given mapbox object with the one already present on the layout.
    /// </summary>
    /// <param name="id">The target mapbox id</param>
    /// <param name="mapbox">The updated mapbox object.</param>
    static member updateMapboxById(id: StyleParam.SubPlotId, mapbox: Mapbox) =
        (fun (layout: Layout) ->
            let mapbox' =
                match Layout.tryGetMapboxById id layout with
                | Some a -> DynObj.combine a mapbox
                | None -> mapbox

            layout |> DynObj.withProperty  (StyleParam.SubPlotId.toString id) mapbox' 
        )

    /// <summary>
    /// Returns the Mapbox object of the layout with the given id.
    ///
    /// If there is no mapbox set, returns an empty Mapbox object.
    /// </summary>
    /// <param name="id">The target mapbox id</param>
    static member getMapboxById(id: StyleParam.SubPlotId) =
        (fun (layout: Layout) -> layout |> Layout.tryGetMapboxById id |> Option.defaultValue (Mapbox.init ()))

    /// <summary>
    /// Returns a sequence of key-value pairs of the layout's dynamic members that are valid mapbox subplots (if the key matches and object can be cast to the correct type).
    /// </summary>
    /// <param name="layout">The layout to get the mapboxes from</param>
    static member getMapboxes (layout: Layout) =
        layout.GetProperties(includeInstanceProperties = false)
        |> Array.ofSeq
        |> Array.choose (fun kv -> 
            if StyleParam.SubPlotId.isValidMapboxId kv.Key then
                match layout.TryGetTypedPropertyValue<Mapbox>(kv.Key) with
                | Some mapbox -> Some (kv.Key, mapbox)
                | None -> None
            else None
        )

    /// <summary>
    /// Sets a mapbox object on the layout as a dynamic property with the given mapbox id.
    /// </summary>
    /// <param name="id">The mapbox id of the new mapbox</param>
    /// <param name="mapbox">The mapbox to add to the layout.</param>
    static member setMapbox(id: StyleParam.SubPlotId, mapbox: Mapbox) =
        (fun (layout: Layout) ->
             layout |> DynObj.withProperty  (StyleParam.SubPlotId.toString id) mapbox
        )

    /// <summary>
    /// Returns Some(Polar) if there is a polar object set on the layout with the given id, and None otherwise.
    /// </summary>
    /// <param name="id">he target polar id</param>
    static member tryGetPolarById(id: StyleParam.SubPlotId) =
        (fun (layout: Layout) -> layout.TryGetTypedPropertyValue<Polar>(StyleParam.SubPlotId.toString id))

    /// <summary>
    /// Combines the given polar object with the one already present on the layout.
    /// </summary>
    /// <param name="id">The target polar id</param>
    /// <param name="polar">The updated polar object.</param>
    static member updatePolarById(id: StyleParam.SubPlotId, polar: Polar) =
        (fun (layout: Layout) ->

            let polar' =
                match layout |> Layout.tryGetPolarById (id) with
                | Some a -> DynObj.combine a polar
                | None -> polar

            layout |> DynObj.withProperty (StyleParam.SubPlotId.toString id) polar'
        )

    /// <summary>
    /// Returns the Polar object of the layout with the given id.
    ///
    /// If there is no polar set, returns an empty Polar object.
    /// </summary>
    /// <param name="id">The target polar id</param>
    static member getPolarById(id: StyleParam.SubPlotId) =
        (fun (layout: Layout) -> layout |> Layout.tryGetPolarById id |> Option.defaultValue (Polar.init ()))

    /// <summary>
    /// Returns a sequence of key-value pairs of the layout's dynamic members that are valid polar subplots (if the key matches and object can be cast to the correct type).
    /// </summary>
    /// <param name="layout">The layout to get the polars from</param>
    static member getPolars (layout: Layout) =
        layout.GetProperties(includeInstanceProperties = false)
        |> Array.ofSeq
        |> Array.choose (fun kv -> 
            if StyleParam.SubPlotId.isValidPolarId kv.Key then
                match layout.TryGetTypedPropertyValue<Polar>(kv.Key) with
                | Some polar -> Some (kv.Key, polar)
                | None -> None
            else None
        )

    /// <summary>
    /// Sets a polar object on the layout as a dynamic property with the given polar id.
    /// </summary>
    /// <param name="id">The scene id of the new geo</param>
    /// <param name="polar">The polar to add to the layout.</param>
    static member setPolar(id: StyleParam.SubPlotId, polar: Polar) =
        (fun (layout: Layout) ->
            layout |> DynObj.withProperty  (StyleParam.SubPlotId.toString id) polar 
        )

    /// <summary>
    /// Returns Some(smith) if there is a smith object set on the layout with the given id, and None otherwise.
    /// </summary>
    /// <param name="id">the target Smith id</param>
    static member tryGetSmithById(id: StyleParam.SubPlotId) =
        (fun (layout: Layout) -> layout.TryGetTypedPropertyValue<Smith>(StyleParam.SubPlotId.toString id))

    /// <summary>
    /// Combines the given Smith object with the one already present on the layout.
    /// </summary>
    /// <param name="id">The target smith id</param>
    /// <param name="smith">The updated smith object.</param>
    static member updateSmithById(id: StyleParam.SubPlotId, smith: Smith) =
        (fun (layout: Layout) ->

            let smith' =
                match layout |> Layout.tryGetSmithById (id) with
                | Some a -> DynObj.combine a smith
                | None -> smith

            layout  |> DynObj.withProperty (StyleParam.SubPlotId.toString id) smith'
        )

    /// <summary>
    /// Returns the Smith object of the layout with the given id.
    ///
    /// If there is no smith set, returns an empty Smith object.
    /// </summary>
    /// <param name="id">The target smith id</param>
    static member getSmithById(id: StyleParam.SubPlotId) =
        (fun (layout: Layout) -> layout |> Layout.tryGetSmithById id |> Option.defaultValue (Smith.init ()))

    /// <summary>
    /// Returns a sequence of key-value pairs of the layout's dynamic members that are valid smith subplots (if the key matches and object can be cast to the correct type).
    /// </summary>
    /// <param name="layout">The layout to get the smiths from</param>
    static member getSmiths (layout: Layout) =
        layout.GetProperties(includeInstanceProperties = false)
        |> Array.ofSeq
        |> Array.choose (fun kv -> 
            if StyleParam.SubPlotId.isValidSmithId kv.Key then
                match layout.TryGetTypedPropertyValue<Smith>(kv.Key) with
                | Some smith -> Some (kv.Key, smith)
                | None -> None
            else None
        )

    /// <summary>
    /// Sets a smith object on the layout as a dynamic property with the given smith id.
    /// </summary>
    /// <param name="id">The scene id of the new geo</param>
    /// <param name="smith">The smith to add to the layout.</param>
    static member setSmith(id: StyleParam.SubPlotId, smith: Smith) =
        (fun (layout: Layout) ->
            layout |> DynObj.withProperty (StyleParam.SubPlotId.toString id) smith
        )

    /// <summary>
    /// Returns Some(ColorAxis) if there is a ColorAxis object set on the layout with the given id, and None otherwise.
    /// </summary>
    /// <param name="id">The target ColorAxis id</param>
    static member tryGetColorAxisById(id: StyleParam.SubPlotId) =
        (fun (layout: Layout) -> layout.TryGetTypedPropertyValue<ColorAxis>(StyleParam.SubPlotId.toString id))

    /// <summary>
    /// Combines the given colorAxis object with the one already present on the layout.
    /// </summary>
    /// <param name="id">The target ColorAxis id</param>
    /// <param name="colorAxis">The updated ColorAxis object.</param>
    static member updateColorAxisById(id: StyleParam.SubPlotId, colorAxis: ColorAxis) =
        (fun (layout: Layout) ->

            let colorAxis' =
                match layout |> Layout.tryGetColorAxisById (id) with
                | Some a -> DynObj.combine a colorAxis
                | None -> colorAxis

            layout |> DynObj.withProperty (StyleParam.SubPlotId.toString id) colorAxis'
        )

    /// <summary>
    /// Returns the ColorAxis object of the layout with the given id.
    ///
    /// If there is no color axis set, returns an empty ColorAxis object.
    /// </summary>
    /// <param name="id">The target color axis id</param>
    static member getColorAxisById(id: StyleParam.SubPlotId) =
        (fun (layout: Layout) -> layout |> Layout.tryGetColorAxisById id |> Option.defaultValue (ColorAxis.init ()))

    /// <summary>
    /// Returns a sequence of key-value pairs of the layout's dynamic members that are valid color axes (if the key matches and object can be cast to the correct type).
    /// </summary>
    /// <param name="layout">The layout to get the color axes from</param>
    static member getColorAxes (layout: Layout) =
        layout.GetProperties(includeInstanceProperties = false)
        |> Array.ofSeq
        |> Array.choose (fun kv -> 
            if StyleParam.SubPlotId.isValidColorAxisId kv.Key then
                match layout.TryGetTypedPropertyValue<ColorAxis>(kv.Key) with
                | Some colorAxis -> Some (kv.Key, colorAxis)
                | None -> None
            else None
        )

    /// <summary>
    /// Sets a ColorAxis object on the layout as a dynamic property with the given ColorAxis id.
    /// </summary>
    /// <param name="id">The ColorAxis id of the new ColorAxis</param>
    /// <param name="colorAxis">The ColorAxis to add to the layout.</param>
    static member setColorAxis(id: StyleParam.SubPlotId, colorAxis: ColorAxis) =
        (fun (layout: Layout) ->
             layout |> DynObj.withProperty (StyleParam.SubPlotId.toString id) colorAxis
        )

    /// <summary>
    /// Returns Some(Ternary) if there is a ColorAxis object set on the layout with the given id, and None otherwise.
    /// </summary>
    /// <param name="id">The target Ternary id</param>
    static member tryGetTernaryById(id: StyleParam.SubPlotId) =
        (fun (layout: Layout) -> layout.TryGetTypedPropertyValue<Ternary>(StyleParam.SubPlotId.toString id))

    /// <summary>
    /// Combines the given ternary object with the one already present on the layout.
    /// </summary>
    /// <param name="id">The target Ternary id</param>
    /// <param name="ternary">The updated Ternary object.</param>
    static member updateTernaryById(id: StyleParam.SubPlotId, ternary: Ternary) =
        (fun (layout: Layout) ->

            let ternary' =
                match layout |> Layout.tryGetTernaryById (id) with
                | Some a -> DynObj.combine a ternary
                | None -> ternary

            layout |> DynObj.withProperty (StyleParam.SubPlotId.toString id) ternary'
        )

    /// <summary>
    /// Returns the Ternary object of the layout with the given id.
    ///
    /// If there is no ternary set, returns an empty Ternary object.
    /// </summary>
    /// <param name="id">The target ternary id</param>
    static member getTernaryById(id: StyleParam.SubPlotId) =
        (fun (layout: Layout) -> layout |> Layout.tryGetTernaryById id |> Option.defaultValue (Ternary.init ()))

    /// <summary>
    /// Returns a sequence of key-value pairs of the layout's dynamic members that are valid ternary subplots (if the key matches and object can be cast to the correct type).
    /// </summary>
    /// <param name="layout">The layout to get the ternaries from</param>
    static member getTernaries (layout: Layout) =
        layout.GetProperties(includeInstanceProperties = false)
        |> Array.ofSeq
        |> Array.choose (fun kv -> 
            if StyleParam.SubPlotId.isValidTernaryId kv.Key then
                match layout.TryGetTypedPropertyValue<Ternary>(kv.Key) with
                | Some ternary -> Some (kv.Key, ternary)
                | None -> None
            else None
        )

    /// <summary>
    /// Sets a Ternary object on the layout as a dynamic property with the given Ternary id.
    /// </summary>
    /// <param name="id">The Ternary id of the new ColorAxis</param>
    /// <param name="ternary">The Ternary to add to the layout.</param>
    static member setTernary(id: StyleParam.SubPlotId, ternary: Ternary) =
        (fun (layout: Layout) ->
            layout |> DynObj.withProperty (StyleParam.SubPlotId.toString id) ternary
        )

    /// <summary>
    /// Returns the LayoutGrid object of the given layout.
    ///
    /// If there is no grid set, returns an empty LayoutGrid object.
    /// </summary>
    /// <param name="layout">The layout to get the grid from</param>
    static member getLayoutGrid(layout: Layout) =
        layout |> Layout.tryGetTypedMember<LayoutGrid> "grid" |> Option.defaultValue (LayoutGrid.init ())

    /// <summary>
    /// Returns a function that sets the LayoutGrid object of the given trace.
    /// </summary>
    /// <param name="layoutGrid">The new LayoutGrid object</param>
    static member setLayoutGrid(layoutGrid: LayoutGrid) =
        (fun (layout: Layout) ->
            layout |> DynObj.withProperty "grid" layoutGrid
        )

    /// <summary>
    /// Combines the given layoutGrid object with the one already present on the layout.
    /// </summary>
    /// <param name="layoutGrid">The updated LayoutGrid object</param>
    static member updateLayoutGrid(layoutGrid: LayoutGrid) =
        (fun (layout: Layout) ->
            let combined =
                DynObj.combine (layout |> Layout.getLayoutGrid) layoutGrid |> unbox<LayoutGrid>

            layout |> Layout.setLayoutGrid combined)

    /// <summary>
    /// Returns Some(Legend) if there is an Legend object set on the layout with the given id, and None otherwise.
    /// </summary>
    /// <param name="id">The target Legend id</param>
    static member tryGetLegendById(id: StyleParam.SubPlotId) =
        (fun (layout: Layout) -> layout.TryGetTypedPropertyValue<Legend>(StyleParam.SubPlotId.toString id))

    /// <summary>
    /// Returns a sequence of key-value pairs of the layout's dynamic members that are valid legends (if the key matches and object can be cast to the correct type).
    /// </summary>
    /// <param name="layout">The layout to get the color axes from</param>
    static member getLegends (layout: Layout) =
        layout.GetProperties(includeInstanceProperties = false)
        |> Array.ofSeq
        |> Array.choose (fun kv -> 
            if StyleParam.SubPlotId.isValidLegendId kv.Key then
                match layout.TryGetTypedPropertyValue<Legend>(kv.Key) with
                | Some legend -> Some (kv.Key, legend)
                | None -> None
            else None
        )

    /// <summary>
    /// Combines the given Legend object with the one already present on the layout.
    /// </summary>
    /// <param name="id">The target Legend id</param>
    /// <param name="legend">The updated Legend object.</param>
    static member updateLegendById(id: StyleParam.SubPlotId, legend: Legend) =
        (fun (layout: Layout) ->

            match id with
            | StyleParam.SubPlotId.Legend _ ->

                let legend' =
                    match Layout.tryGetLegendById id layout with
                    | Some l -> DynObj.combine l legend
                    | None -> legend

                layout |> DynObj.withProperty (StyleParam.SubPlotId.toString id) legend'
                
            | _ ->
                failwith
                    $"{StyleParam.SubPlotId.toString id} is an invalid subplot id for setting a legend on layout")

    /// <summary>
    /// Returns the Legend object of the layout with the given id.
    ///
    /// If there is no Legend set, returns an empty Legend object.
    /// </summary>
    /// <param name="id">The target Legend id</param>
    static member getLegendById(id: StyleParam.SubPlotId) =
        (fun (layout: Layout) -> layout |> Layout.tryGetLegendById id |> Option.defaultValue (Legend.init ()))

    /// <summary>
    /// Sets a linear Legend object on the layout as a dynamic property with the given Legend id.
    /// </summary>
    /// <param name="id">The Legend id of the new Legend</param>
    /// <param name="legend">The Legend to add to the layout.</param>
    static member setLegend(id: StyleParam.SubPlotId, legend: Legend) =
        (fun (layout: Layout) ->

            match id with
            | StyleParam.SubPlotId.Legend _ ->
                layout |> DynObj.withProperty (StyleParam.SubPlotId.toString id) legend

            | _ ->
                failwith
                    $"{StyleParam.SubPlotId.toString id} is an invalid subplot id for setting a Legend on layout")
