namespace Plotly.NET

open Plotly.NET.ConfigObjects
open DynamicObj
open System.Runtime.InteropServices

/// The Config object gets passed to the plotly renderer and contains render-specific options.
type Config() =
    inherit DynamicObj()

    /// <summary>
    /// Returns a new Config Object with the given styling.
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
    static member init
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
        Config()
        |> Config.style (
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


    /// <summary>
    /// Returns a function that applies the given styles to a Config object.
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
    static member style
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
        fun (config: Config) ->
            
            config
            |> DynObj.withOptionalProperty   "staticPlot"             StaticPlot              
            |> DynObj.withOptionalProperty   "typesetMath"            TypesetMath             
            |> DynObj.withOptionalProperty   "plotlyServerUrl"        PlotlyServerUrl         
            |> DynObj.withOptionalProperty   "editable"               Editable                
            |> DynObj.withOptionalProperty   "edits"                  Edits                   
            |> DynObj.withOptionalProperty   "editSelection"          EditSelection           
            |> DynObj.withOptionalProperty   "autosizable"            Autosizable             
            |> DynObj.withOptionalProperty   "responsive"             Responsive              
            |> DynObj.withOptionalProperty   "fillFrame"              FillFrame               
            |> DynObj.withOptionalProperty   "frameMargins"           FrameMargins            
            |> DynObj.withOptionalPropertyBy "scrollZoom"             ScrollZoom              StyleParam.ScrollZoom.convert
            |> DynObj.withOptionalPropertyBy "doubleClick"            DoubleClick             StyleParam.DoubleClick.convert
            |> DynObj.withOptionalProperty   "doubleClickDelay"       DoubleClickDelay        
            |> DynObj.withOptionalProperty   "showAxisDragHandles"    ShowAxisDragHandles     
            |> DynObj.withOptionalProperty   "showAxisRangeEntryBoxes"ShowAxisRangeEntryBoxes 
            |> DynObj.withOptionalProperty   "showTips"               ShowTips                
            |> DynObj.withOptionalProperty   "showLink"               ShowLink                
            |> DynObj.withOptionalProperty   "linkText"               LinkText                
            |> DynObj.withOptionalProperty   "sendData"               SendData                
            |> DynObj.withOptionalProperty   "showSources"            ShowSources             
            |> DynObj.withOptionalProperty   "displayModeBar"         DisplayModeBar          
            |> DynObj.withOptionalProperty   "showSendToCloud"        ShowSendToCloud         
            |> DynObj.withOptionalProperty   "showEditInChartStudio"  ShowEditInChartStudio   
            |> DynObj.withOptionalPropertyBy "modeBarButtonsToRemove" ModeBarButtonsToRemove  (fun x -> x |> Seq.map StyleParam.ModeBarButton.toString)
            |> DynObj.withOptionalPropertyBy "modeBarButtonsToAdd"    ModeBarButtonsToAdd     (fun x -> x |> Seq.map StyleParam.ModeBarButton.toString)
            |> DynObj.withOptionalPropertyBy "modeBarButtons"         ModeBarButtons          (fun x -> x |> Seq.map (Seq.map StyleParam.ModeBarButton.toString))
            |> DynObj.withOptionalProperty   "toImageButtonOptions"   ToImageButtonOptions    
            |> DynObj.withOptionalProperty   "displaylogo"            Displaylogo             
            |> DynObj.withOptionalProperty   "watermark"              Watermark               
            |> DynObj.withOptionalProperty   "plotGlPixelRatio"       plotGlPixelRatio        
            |> DynObj.withOptionalProperty   "setBackground"          SetBackground           
            |> DynObj.withOptionalProperty   "topojsonURL"            TopojsonURL             
            |> DynObj.withOptionalProperty   "mapboxAccessToken"      MapboxAccessToken       
            |> DynObj.withOptionalProperty   "logging"                Logging                 
            |> DynObj.withOptionalProperty   "notifyOnLogging"        NotifyOnLogging         
            |> DynObj.withOptionalProperty   "queueLength"            QueueLength             
            |> DynObj.withOptionalProperty   "globalTransforms"       GlobalTransforms        
            |> DynObj.withOptionalProperty   "locale"                 Locale                  
            |> DynObj.withOptionalProperty   "locales"                Locales                 

    /// <summary>
    /// Combines two Config objects.
    ///
    /// In case of duplicate dynamic member values, the values of the second Config are used.
    ///
    /// For the collections used for the dynamic members
    ///
    /// modeBarButtonsToAdd
    ///
    /// the values from the second Config are appended to those of the first instead.
    /// </summary>
    /// <param name="first">The first Config to combine with the second</param>
    /// <param name="second">The second Config to combine with the first</param>
    static member combine (first: Config) (second: Config) =

        let modeBarButtonsToRemove =
            InternalUtils.combineOptSeqs
                (first.TryGetTypedPropertyValue<seq<string>>("modeBarButtonsToRemove"))
                (second.TryGetTypedPropertyValue<seq<string>>("modeBarButtonsToRemove"))

        let modeBarButtonsToAdd =
            InternalUtils.combineOptSeqs
                (first.TryGetTypedPropertyValue<seq<string>>("modeBarButtonsToAdd"))
                (second.TryGetTypedPropertyValue<seq<string>>("modeBarButtonsToAdd"))

        let modeBarButtons =
            InternalUtils.combineOptSeqs
                (first.TryGetTypedPropertyValue<seq<seq<string>>>("modeBarButtons"))
                (second.TryGetTypedPropertyValue<seq<seq<string>>>("modeBarButtons"))

        DynObj.combine first second
        |> unbox<Config>
        |> Config.style (
            ?ModeBarButtonsToRemove = (modeBarButtonsToRemove |> Option.map (Seq.map StyleParam.ModeBarButton.ofString)),
            ?ModeBarButtonsToAdd = (modeBarButtonsToAdd |> Option.map (Seq.map StyleParam.ModeBarButton.ofString)),
            ?ModeBarButtons = (modeBarButtons |> Option.map (Seq.map (Seq.map StyleParam.ModeBarButton.ofString)))
        )
