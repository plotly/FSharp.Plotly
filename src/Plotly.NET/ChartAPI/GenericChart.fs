namespace Plotly.NET

open DynamicObj
open System
open Newtonsoft.Json
open System.Runtime.CompilerServices
open Giraffe.ViewEngine
open System
open System.IO
open System.Collections.Generic

/// Figure is a domain transfer object that can be used to serialize a Chart to JSON. It is used internally and for most use cases should not be used directly.
///
/// Use `GenericChart.toJson` to create a JSON string of a Chart containing the data, layout and config of the GenericChart, or `GenericChart.toFigureJson` for json objects with the data, layout, and an empty frame array.
type Figure =
    {
        [<JsonProperty("data")>]
        Data: Trace list
        [<JsonProperty("layout")>]
        Layout: Layout
        [<JsonProperty("frames")>]
        Frames: Frame list
    }
    static member create data layout =
        {
            Data = data
            Layout = layout
            Frames = []
        }

/// ChartDTO is a domain transfer object that can be used to serialize a Chart to JSON. It is used internally and for most use cases should not be used directly.
///
/// Use `GenericChart.toJson` to create a JSON string of a Chart containing the data, layout and config of the GenericChart, or `GenericChart.toFigureJson` for json objects with the data, layout, and an empty frame array.
type ChartDTO =
    {
        [<JsonProperty("data")>]
        Data: Trace list
        [<JsonProperty("layout")>]
        Layout: Layout
        [<JsonProperty("config")>]
        Config: Config
    }
    static member create data layout config =
        {
            Data = data
            Layout = layout
            Config = config
        }

/// The central type that gets created by all Chart constructors is GenericChart, which itself represents either a single chart or a multi chart (as a Discriminate Union type).
/// 
/// A GenericChart consists of four top level objects: Trace (multiple of those in the case of a MultiChart), Layout, Config, and DisplayOptions.
/// 
/// - `Trace` is in principle the representation of a dataset on a chart, including for example the data itself, color and shape of the visualization, etc.
///
/// - `Layout` is everything of the chart that is not dataset specific - e.g. the shape and style of axes, the chart title, etc.
///
/// - `Config` is an object that configures high level properties of the chart like making all chart elements editable or the tool bar on top
///
/// - `DisplayOptions` is an object that contains meta information about how the html document that contains the chart.
[<TypeFormatterSourceAttribute(typeof<GenericChartFormatterSource>)>]
type GenericChart =
    | Chart of data: Trace * layout: Layout * config: Config * displayOpts: DisplayOptions
    | MultiChart of data: Trace list * layout: Layout * config: Config * displayOpts: DisplayOptions
        
    /// Method to support dumping charts in LINQPad.
    // See https://www.linqpad.net/CustomizingDump.aspx
    member private this.ToDump () : System.Object =
        let html = GenericChart.toEmbeddedHTML this
    
        let iFrameType = Type.GetType("LINQPad.Controls.IFrame, LINQPad.Runtime")
            
        if isNull iFrameType then
            this
        else
            let iFrame = System.Activator.CreateInstance(iFrameType, html, true);
            iFrame

    /// <summary>
    /// Creates a Figure DTO from the given GenericChart.
    /// </summary>
    /// <param name="gChart">The GenericChart to convert</param>
    static member toFigure (gChart: GenericChart) =
        Figure.create 
            (GenericChart.getTraces gChart)
            (GenericChart.getLayout gChart)

    /// <summary>
    /// Creates a GenericChart from the given Figure DTO.
    /// </summary>
    /// <param name="fig">The Figure DTO to convert</param>
    static member fromFigure (fig: Figure) =
        let traces = fig.Data
        let layout = fig.Layout

        if traces.Length <> 1 then
            MultiChart(traces, layout, Defaults.DefaultConfig, Defaults.DefaultDisplayOptions)
        else
            Chart(traces.[0], layout, Defaults.DefaultConfig, Defaults.DefaultDisplayOptions)

    /// <summary>
    /// Creates a ChartDTO from the given GenericChart.
    /// </summary>
    /// <param name="gChart">The GenericChart to convert</param>
    static member toChartDTO (gChart: GenericChart) =
        ChartDTO.create 
            (GenericChart.getTraces gChart)
            (GenericChart.getLayout gChart)
            (GenericChart.getConfig gChart)

    /// <summary>
    /// Creates a GenericChart from the given ChartDTO.
    /// </summary>
    /// <param name="dto">The ChartDTO to convert</param>
    static member fromChartDTO (dto: ChartDTO) =
        let traces = dto.Data
        let layout = dto.Layout
        let config = dto.Config

        if traces.Length <> 1 then
            MultiChart(traces, layout, config, Defaults.DefaultDisplayOptions)
        else
            Chart(traces.[0], layout, config, Defaults.DefaultDisplayOptions)

    /// <summary>
    /// Returns all traces of a given GenericChart.
    /// </summary>
    /// <param name="gChart">the input GenericChart to get all traces from</param>
    static member getTraces gChart =
        match gChart with
        | Chart(trace, _, _, _) -> [ trace ]
        | MultiChart(traces, _, _, _) -> traces

    /// <summary>
    /// Returns the layout of a given GenericChart.
    /// </summary>
    /// <param name="gChart">the input GenericChart to get the layout from</param>
    static member getLayout gChart =
        match gChart with
        | Chart(_, layout, _, _) -> layout
        | MultiChart(_, layout, _, _) -> layout

    /// <summary>
    /// Returns a new GenericChart with the given layout.
    /// </summary>
    /// <param name="layout">the layout to set</param>
    /// <param name="gChart">the input GenericChart to set the layout on</param>
    static member setLayout layout gChart =
        match gChart with
        | Chart(t, _, c, d) -> Chart(t, layout, c, d)
        | MultiChart(t, _, c, d) -> MultiChart(t, layout, c, d)

    /// <summary>
    /// Returns a new GenericChart with the given layout combined with the given GenericChart's existing layout.
    /// </summary>
    /// <param name="layout">the layout to add</param>
    /// <param name="gChart">the input GenericChart to set the layout on</param>
    static member addLayout layout gChart =
        match gChart with
        | Chart(trace, l', c, d) -> Chart(trace, (Layout.combine l' layout), c, d)
        | MultiChart(traces, l', c, d) -> MultiChart(traces, (Layout.combine l' layout), c, d)

    /// <summary>
    /// Returns a tuple containing the width and height of a GenericChart's layout if the property is set, otherwise None.
    /// </summary>
    /// <param name="gChart">the input GenericChart to get the layout size from</param>
    static member tryGetLayoutSize gChart =
        let layout = GenericChart.getLayout gChart
        layout.TryGetTypedPropertyValue<int> "width", layout.TryGetTypedPropertyValue<int> "height"

    /// <summary>
    /// Returns the config of a given GenericChart.
    /// </summary>
    /// <param name="gChart">the input GenericChart to get the config from</param>
    static member getConfig gChart =
        match gChart with
        | Chart(_, _, c, _) -> c
        | MultiChart(_, _, c, _) -> c

    /// <summary>
    /// Returns a new GenericChart with the given config.
    /// </summary>
    /// <param name="config">the config to set</param>
    /// <param name="gChart">the input GenericChart to set the config on</param>
    static member setConfig config gChart =
        match gChart with
        | Chart(t, l, _, d) -> Chart(t, l, config, d)
        | MultiChart(t, l, _, d) -> MultiChart(t, l, config, d)

    /// <summary>
    /// Returns a new GenericChart with the given config combined with the given GenericChart's existing config.
    /// </summary>
    /// <param name="config">the config to add</param>
    /// <param name="gChart">the input GenericChart to set the config on</param>
    static member addConfig config gChart =
        match gChart with
        | Chart(trace, l, c', d) -> Chart(trace, l, (Config.combine c' config), d)
        | MultiChart(traces, l, c', d) -> MultiChart(traces, l, (Config.combine c' config), d)

    /// <summary>
    /// Returns the DisplayOptions of a given GenericChart.
    /// </summary>
    /// <param name="gChart">the input GenericChart to get the DisplayOptions from</param>
    static member getDisplayOptions gChart =
        match gChart with
        | Chart(_, _, _, d) -> d
        | MultiChart(_, _, _, d) -> d

    /// <summary>
    /// Returns a new GenericChart with the given DisplayOptions.
    /// </summary>
    /// <param name="displayOpts">the DisplayOptions to set</param>
    /// <param name="gChart">the input GenericChart to set the DisplayOptions on</param>
    static member setDisplayOptions displayOpts gChart =
        match gChart with
        | Chart(t, l, c, _) -> Chart(t, l, c, displayOpts)
        | MultiChart(t, l, c, _) -> MultiChart(t, l, c, displayOpts)

    /// <summary>
    /// Returns a new GenericChart with the given DisplayOptions combined with the given GenericChart's existing DisplayOptions.
    /// </summary>
    /// <param name="displayOpts">the DisplayOptions to add</param>
    /// <param name="gChart">the input GenericChart to set the DisplayOptions on</param>
    static member addDisplayOptions displayOpts gChart =
        match gChart with
        | Chart(t, l, c, d') -> Chart(t, l, c, (DisplayOptions.combine d' displayOpts))
        | MultiChart(t, l, c, d') -> MultiChart(t, l, c, (DisplayOptions.combine d' displayOpts))

    /// <summary>
    /// Combines a collection of GenericCharts, meaning that the traces, layout, config and display options of all elements are combined and returned as a single new GenericChart.
    ///
    /// Combination occurs step-wise in a `Seq.reduce`, where duplicate properties are overwritten on the accumulator by the current element in the collection.
    ///
    /// Traces are simply appended to a single list accumulator.
    ///
    /// Layout, Config, and DisplayOptions can contain properties that themselves are collections. These are combined by appending the values of the second to the first:
    ///
    /// - Layout: annotations, shapes, selections, images, sliders, hiddenlabels, updatemenus
    ///
    /// - Config: modeBarButtonsToAdd
    ///
    /// - DisplayOptions: AdditionalHeadTags, Description
    /// </summary>
    /// <param name="gCharts">the input GenericCharts to combine</param>
    static member combine (gCharts: seq<GenericChart>) =
        // temporary hard fix for some props, see https://github.com/CSBiology/DynamicObj/issues/11

        gCharts
        |> Seq.reduce (fun acc elem ->
            match acc, elem with
            | MultiChart(traces, l1, c1, d1), Chart(trace, l2, c2, d2) ->
                MultiChart(
                    List.append traces [ trace ],
                    Layout.combine l1 l2,
                    Config.combine c1 c2,
                    DisplayOptions.combine d1 d2
                )
            | MultiChart(traces1, l1, c1, d1), MultiChart(traces2, l2, c2, d2) ->
                MultiChart(
                    List.append traces1 traces2,
                    Layout.combine l1 l2,
                    Config.combine c1 c2,
                    DisplayOptions.combine d1 d2
                )
            | Chart(trace1, l1, c1, d1), Chart(trace2, l2, c2, d2) ->
                MultiChart(
                    [ trace1; trace2 ],
                    Layout.combine l1 l2,
                    Config.combine c1 c2,
                    DisplayOptions.combine d1 d2
                )
            | Chart(trace, l1, c1, d1), MultiChart(traces, l2, c2, d2) ->
                MultiChart(
                    List.append [ trace ] traces,
                    Layout.combine l1 l2,
                    Config.combine c1 c2,
                    DisplayOptions.combine d1 d2
                ))

    /// <summary>
    /// Returns the HTML node representation of a given GenericChart.
    ///
    /// The resulting HTML node contains a a div tag containing the chart, and a script tag containing the javascript to create it.
    ///
    /// Note that no references to the necessary scripts are included, so these must be added separately.
    /// </summary>
    /// <param name="gChart">The input GenericCharts to return as HTML nodes</param>
    static member toChartHTMLNodes gChart =
        let tracesJson =
            let traces = GenericChart.getTraces gChart
            JsonConvert.SerializeObject(traces, Globals.JSON_CONFIG)

        let layoutJson =
            let layout = GenericChart.getLayout gChart
            JsonConvert.SerializeObject(layout, Globals.JSON_CONFIG)

        let configJson =
            let config = GenericChart.getConfig gChart
            JsonConvert.SerializeObject(config, Globals.JSON_CONFIG)

        let displayOpts = GenericChart.getDisplayOptions gChart

        let chartDescription =
            displayOpts |> DisplayOptions.getChartDescription

        let plotlyReference =
            displayOpts |> DisplayOptions.getPlotlyReference

        div
            []
            [
                yield!
                    HTML.CreateChartHTML(
                        data = tracesJson,
                        layout = layoutJson,
                        config = configJson,
                        plotlyReference = plotlyReference
                    )
                yield! chartDescription
            ]

    /// <summary>
    /// Returns the HTML string representation of a given GenericChart.
    ///
    /// The resulting HTML string contains a a div tag containing the chart, and a script tag containing the javascript to create it.
    ///
    /// Note that no references to the necessary scripts are included, so these must be added separately.
    /// </summary>
    /// <param name="gChart">The input GenericChart to return as HTML string</param>
    static member toChartHTML gChart =
        gChart |> GenericChart.toChartHTMLNodes |> RenderView.AsString.htmlNode

    /// <summary>
    /// Returns the HTML string representation of a given GenericChart embedded into a full HTML document.
    ///
    /// The resulting HTML string contains a head tag with references according to the input GenericChart's DisplayOptions, 
    /// and a body tag containing the chart div, a script tag containing the javascript to create the chart, and a div tag containing the chart description.
    /// </summary>
    /// <param name="gChart">The input GenericChart to return as HTML string</param>
    static member toEmbeddedHTML gChart =

        let tracesJson =
            let traces = GenericChart.getTraces gChart
            JsonConvert.SerializeObject(traces, Globals.JSON_CONFIG)

        let layoutJson =
            let layout = GenericChart.getLayout gChart
            JsonConvert.SerializeObject(layout, Globals.JSON_CONFIG)

        let configJson =
            let config = GenericChart.getConfig gChart
            JsonConvert.SerializeObject(config, Globals.JSON_CONFIG)

        let displayOpts = GenericChart.getDisplayOptions gChart

        let documentTitle =
            (displayOpts |> DisplayOptions.getDocumentTitle)

        let documentDescription =
            (displayOpts |> DisplayOptions.getDocumentDescription)

        let documentCharset =
            (displayOpts |> DisplayOptions.getDocumentCharset)

        let documentFavicon =
            (displayOpts |> DisplayOptions.getDocumentFavicon)

        let additionalHeadTags =
            (displayOpts |> DisplayOptions.getAdditionalHeadTags)

        let chartDescription =
            (displayOpts |> DisplayOptions.getChartDescription)

        let plotlyReference =
            displayOpts |> DisplayOptions.getPlotlyReference

        HTML.Doc(
            documentTitle = documentTitle,
            documentDescription = documentDescription,
            documentCharset = documentCharset,
            documentFavicon = documentFavicon,
            chart =
                HTML.CreateChartHTML(
                    data = tracesJson,
                    layout = layoutJson,
                    config = configJson,
                    plotlyReference = plotlyReference
                ),
            plotlyReference = plotlyReference,
            AdditionalHeadTags = additionalHeadTags,
            ChartDescription = chartDescription
        )
        |> RenderView.AsString.htmlDocument

    /// <summary>
    /// Serializes a GenericChart to a JSON string, representing the data and layout of the GenericChart, together with an empty frame array (not supported):
    ///
    /// {
    ///
    /// "data": [ -serialized traces array- ] ,
    ///
    /// "layout": { -serialized layout object- } ,
    ///
    /// "frames": [ -empty array, not supported yet- ]
    ///
    /// }
    /// </summary>
    /// <param name="gChart">the chart to serialize</param>
    static member toFigureJson gChart =
        gChart
        |> GenericChart.toFigure
        |> fun f -> JsonConvert.SerializeObject(f, Globals.JSON_CONFIG)

    /// <summary>
    /// Serializes a GenericChart to a JSON string, representing the data, layout and config of the GenericChart:
    ///
    /// {
    ///
    /// "data": [ -serialized traces array- ] ,
    ///
    /// "layout": { -serialized layout object- } ,
    ///
    /// "config": { -serialized config object- }
    ///
    /// }
    /// </summary>
    /// <param name="gChart">the chart to serialize</param>
    static member toJson gChart =

        gChart
        |> GenericChart.toChartDTO

        |> fun dto -> JsonConvert.SerializeObject(dto, Globals.JSON_CONFIG)

    /// <summary>
    /// Creates a new GenericChart whose traces are the results of applying the given function to each trace item of the input GenericChart.
    /// </summary>
    /// <param name="f">the function to apply to each trace item</param>
    /// <param name="gChart">the input GenericChart</param>
    static member mapTrace f gChart =
        match gChart with
        | Chart(trace, layout, config, displayOpts) -> Chart(f trace, layout, config, displayOpts)
        | MultiChart(traces, layout, config, displayOpts) ->
            MultiChart(traces |> List.map f, layout, config, displayOpts)

    /// <summary>
    /// Creates a new GenericChart whose traces are the results of applying the given function to each trace item of the input GenericChart.
    ///
    /// The integer index passed to the function indicates the index (from 0) of element being transformed.
    /// </summary>
    /// <param name="f">the function to apply to each trace item</param>
    /// <param name="gChart">the input GenericChart</param>
    static member mapiTrace f gChart =
        match gChart with
        | Chart(trace, layout, config, displayOpts) -> Chart(f 0 trace, layout, config, displayOpts)
        | MultiChart(traces, layout, config, displayOpts) ->
            MultiChart(traces |> List.mapi f, layout, config, displayOpts)

    /// <summary>
    /// Returns the number of traces in the given GenericChart.
    /// </summary>
    /// <param name="gChart">the input GenericChart</param>
    static member countTrace gChart =
        match gChart with
        | Chart(_) -> 1
        | MultiChart(traces, _, _, _) -> traces |> Seq.length

    /// <summary>
    /// Returns true if the given chart contains a trace for which the predicate function returns true
    /// </summary>
    /// <param name="predicate">the predicate to check for the trace items</param>
    /// <param name="gChart">the input GenericChart</param>
    static member existsTrace (predicate: Trace -> bool) gChart =
        match gChart with
        | Chart(trace, _, _, _) -> predicate trace
        | MultiChart(traces, _, _, _) -> traces |> List.exists predicate

    /// <summary>
    /// Creates a GenericChart from a list of trace objects.
    ///
    /// The objects set for the Layout, Config and DisplayOptions depend on `useDefaults`:
    /// 
    /// If true, the default objects found in `Defaults` are used.
    ///
    /// If false, empty objects are used.
    /// </summary>
    /// <param name="useDefaults">wether or not to set default objects for Layout, Config and DisplayOptions</param>
    /// <param name="traces">the input Trace collection</param>
    static member ofTraceObjects (useDefaults: bool) (traces: #seq<Trace>) = // layout =

        let traces = traces |> List.ofSeq

        if useDefaults then
            // copy default instances so we can safely manipulate the respective objects of the created chart without changing global default objects
            let defaultConfig = Config()
            Defaults.DefaultConfig.CopyDynamicPropertiesTo defaultConfig

            let defaultDisplayOpts = DisplayOptions()
            Defaults.DefaultDisplayOptions.CopyDynamicPropertiesTo defaultDisplayOpts

            let defaultTemplate = Template()
            Defaults.DefaultTemplate.CopyDynamicPropertiesTo defaultTemplate

            let defaultLayout = 
                Layout.init (
                    Width = Defaults.DefaultWidth,
                    Height = Defaults.DefaultHeight,
                    Template = (defaultTemplate :> DynamicObj)
                )

            if Seq.length traces <> 1 then
                GenericChart.MultiChart(
                    traces,
                    defaultLayout,
                    defaultConfig,
                    defaultDisplayOpts
                )
            else
                GenericChart.Chart(
                    traces[0],
                    defaultLayout,
                    defaultConfig,
                    defaultDisplayOpts
                )
        else
            if Seq.length traces <> 1 then
                GenericChart.MultiChart(traces, Layout(), Config(), DisplayOptions.initCDNOnly ())
            else
                GenericChart.Chart(traces[0], Layout(), Config(), DisplayOptions.initCDNOnly ())

    /// <summary>
    /// Creates a GenericChart from a trace object.
    ///
    /// The objects set for the Layout, Config and DisplayOptions depend on `useDefaults`:
    /// 
    /// If true, the default objects found in `Defaults` are used.
    ///
    /// If false, empty objects are used.
    /// </summary>
    /// <param name="useDefaults">wether or not to set default objects for Layout, Config and DisplayOptions</param>
    /// <param name="trace">the input Trace</param>
    static member ofTraceObject (useDefaults: bool) (trace: Trace) = GenericChart.ofTraceObjects useDefaults (Seq.singleton trace)

    /// <summary>
    /// Creates a new GenericChart whose layout is the results of applying the given function to the layout of the input GenericChart.
    /// </summary>
    /// <param name="f">the function to apply to the layout</param>
    /// <param name="gChart">the input GenericChart</param>
    static member mapLayout f gChart =
        match gChart with
        | Chart(trace, layout, config, displayOpts) -> Chart(trace, f layout, config, displayOpts)
        | MultiChart(traces, layout, config, displayOpts) -> MultiChart(traces, f layout, config, displayOpts)

    /// <summary>
    /// Creates a new GenericChart whose config is the results of applying the given function to the config of the input GenericChart.
    /// </summary>
    /// <param name="f">the function to apply to the config</param>
    /// <param name="gChart">the input GenericChart</param>
    static member mapConfig f gChart =
        match gChart with
        | Chart(trace, layout, config, displayOpts) -> Chart(trace, layout, f config, displayOpts)
        | MultiChart(traces, layout, config, displayOpts) -> MultiChart(traces, layout, f config, displayOpts)

    /// <summary>
    /// Creates a new GenericChart whose DisplayOptions is the results of applying the given function to the DisplayOptions of the input GenericChart.
    /// </summary>
    /// <param name="f">the function to apply to the DisplayOptions</param>
    /// <param name="gChart">the input GenericChart</param>
    static member mapDisplayOptions f gChart =
        match gChart with
        | Chart(trace, layout, config, displayOpts) -> Chart(trace, layout, config, f displayOpts)
        | MultiChart(traces, layout, config, displayOpts) -> MultiChart(traces, layout, config, f displayOpts)

    /// <summary>
    /// returns a single TraceID (when all traces of the charts are of the same type), or traceID.Multi if the chart contains traces of multiple different types
    /// </summary>
    /// <param name="gChart">the input genericChart</param>
    static member getTraceID gChart =
        match gChart with
        | Chart(trace, _, _, _) -> TraceID.ofTrace trace
        | MultiChart(traces, layout, config, displayOpts) -> TraceID.ofTraces traces

    /// <summary>
    /// returns a list of TraceIDs representing the types of all traces contained in the chart.
    /// </summary>
    /// <param name="gChart">the input genericChart</param>
    static member getTraceIDs gChart =
        match gChart with
        | Chart(trace, _, _, _) -> [ TraceID.ofTrace trace ]
        | MultiChart(traces, _, _, _) -> traces |> List.map TraceID.ofTrace

and GenericChartFormatter() =
        let mutable mimeType = "text/html"
        member this.MimeType
            with get() = mimeType
            and set(v) = mimeType <- v
        member this.Format(instance:obj, writer:TextWriter) = 
            match instance with
            | :? GenericChart as c -> 
                writer.Write("LOL!")
                true
            | _ -> false

and GenericChartFormatterSource =
        member this.CreateTypeFormatters() : seq<obj> =
            seq {
                yield GenericChartFormatter()
            }

