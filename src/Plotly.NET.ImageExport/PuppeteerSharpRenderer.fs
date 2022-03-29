﻿namespace Plotly.NET.ImageExport

open Plotly.NET
open PuppeteerSharp

open System
open System.IO
open System.Text
open System.Text.RegularExpressions
open DynamicObj

module PuppeteerSharpRendererOptions =

    let mutable launchOptions = LaunchOptions()
    launchOptions.Timeout <- 60000

    let mutable localBrowserExecutablePath = None

module internal Path =

    /// checks whether provided path has correct extension and sets if no extension provided
    let ensureFileExtension (ext: string) (path: string) =
        match Path.GetExtension(path) with
        | "" -> sprintf "%s%s" path ext
        | e when String.Compare(e, ext, StringComparison.OrdinalIgnoreCase) = 0 -> path
        | _ as e -> failwithf "Provided path contains wrong file extension. Expected '%s' got '%s'." ext e

type PuppeteerSharpRenderer() =

    /// adapted from the original C# implementation by @ilyalatt : https://github.com/ilyalatt/Plotly.NET.PuppeteerRenderer
    ///
    /// creates a full screen html site for the given chart
    let toFullScreenHtml (gChart: GenericChart.GenericChart) =

        gChart
        |> GenericChart.mapConfig
            (fun c ->
                DynObj.setValue c "responsive" true
                c)
        |> GenericChart.mapLayout
            (fun l ->
                DynObj.setValue l "width" "100%"
                DynObj.setValue l "height" "100%"
                l)
        |> GenericChart.toChartHTML
        |> fun html -> html.Replace("width: 600px; height: 600px;", "width: 100%; height: 100%;")

    /// adapted from the original C# implementation by @ilyalatt : https://github.com/ilyalatt/Plotly.NET.PuppeteerRenderer
    ///
    /// adds the necessary js function calls to render an image with plotly.js
    let patchHtml width height (format: StyleParam.ImageFormat) html =
        let regex = Regex(@"(Plotly\.newPlot\(.+?\))")

        let patchedHtml =
            regex.Replace(
                html,
                (fun (x: Match) ->
                    x.Result(
                        "$1"
                        + $".then(x => Plotly.toImage(x, {{ format: '{StyleParam.ImageFormat.toString format}', scale: 1, width: {width}, height: {height} }}))"
                        + ".then(img => window.plotlyImage = img)"
                    ))
            )

        patchedHtml

    /// adapted from the original C# implementation by @ilyalatt : https://github.com/ilyalatt/Plotly.NET.PuppeteerRenderer
    ///
    /// attempts to render a chart as static image of the given format with the given dimensions from the given html string
    let tryRenderAsync (browser: Browser) (width: int) (height: int) (format: StyleParam.ImageFormat) (html: string) =
        async {
            let! page = browser.NewPageAsync() |> Async.AwaitTask

            try
                let! _ = page.SetContentAsync(patchHtml width height format html) |> Async.AwaitTask
                let! imgHandle = page.WaitForExpressionAsync("window.plotlyImage") |> Async.AwaitTask
                let! imgStr = imgHandle.JsonValueAsync<string>() |> Async.AwaitTask
                return imgStr

            finally
                page.CloseAsync() |> Async.AwaitTask |> Async.RunSynchronously
        }

    /// attempts to render a chart as static image of the given format with the given dimensions from the given html string
    let tryRender (browser: Browser) (width: int) (height: int) (format: StyleParam.ImageFormat) (html: string) =
        tryRenderAsync browser width height format html |> Async.RunSynchronously

    /// Initalizes headless browser
    let fetchAndLaunchBrowserAsync () =
        async {
            match PuppeteerSharpRendererOptions.localBrowserExecutablePath with
            | None ->
                use browserFetcher = new BrowserFetcher()

                let! revision = browserFetcher.DownloadAsync() |> Async.AwaitTask

                let launchOptions =
                    PuppeteerSharpRendererOptions.launchOptions

                launchOptions.ExecutablePath <- revision.ExecutablePath

                return! Puppeteer.LaunchAsync(launchOptions) |> Async.AwaitTask
            | Some p ->
                let launchOptions =
                    PuppeteerSharpRendererOptions.launchOptions

                launchOptions.ExecutablePath <- p

                return! Puppeteer.LaunchAsync(launchOptions) |> Async.AwaitTask
        }

    /// Initalizes headless browser
    let fetchAndLaunchBrowser () =
        fetchAndLaunchBrowserAsync () |> Async.RunSynchronously

    /// skips the data type part of the given URI
    let skipDataTypeString (base64: string) =
        let imgBase64StartIdx =
            base64.IndexOf(",", StringComparison.Ordinal) + 1

        base64.Substring(imgBase64StartIdx)

    /// converst a base64 encoded string URI to a byte array
    let getBytesFromBase64String (base64: string) =
        base64 |> skipDataTypeString |> Convert.FromBase64String

    interface IGenericChartRenderer with

        member this.RenderJPGAsync(width: int, height: int, gChart: GenericChart.GenericChart) =
            async {
                use! browser = fetchAndLaunchBrowserAsync ()

                return! tryRenderAsync browser width height StyleParam.ImageFormat.JPEG (gChart |> toFullScreenHtml)
            }

        member this.RenderJPG(width: int, height: int, gChart: GenericChart.GenericChart) =
            (this :> IGenericChartRenderer)
                .RenderJPGAsync(width, height, gChart)
            |> Async.RunSynchronously

        member this.SaveJPGAsync(path: string, width: int, height: int, gChart: GenericChart.GenericChart) =
            async {
                let! rendered =
                    (this :> IGenericChartRenderer)
                        .RenderJPGAsync(width, height, gChart)
                
                let path = Path.ensureFileExtension ".jpg" path

                return rendered |> getBytesFromBase64String |> fun base64 -> File.WriteAllBytes(path, base64)
            }

        member this.SaveJPG(path: string, width: int, height: int, gChart: GenericChart.GenericChart) =
            (this :> IGenericChartRenderer)
                .SaveJPGAsync(path, width, height, gChart)
            |> Async.RunSynchronously

        member this.RenderPNGAsync(width: int, height: int, gChart: GenericChart.GenericChart) =
            async {
                use! browser = fetchAndLaunchBrowserAsync ()

                return! tryRenderAsync browser width height StyleParam.ImageFormat.PNG (gChart |> toFullScreenHtml)
            }

        member this.RenderPNG(width: int, height: int, gChart: GenericChart.GenericChart) =
            (this :> IGenericChartRenderer)
                .RenderPNGAsync(width, height, gChart)
            |> Async.RunSynchronously

        member this.SavePNGAsync(path: string, width: int, height: int, gChart: GenericChart.GenericChart) =
            async {
                let! rendered =
                    (this :> IGenericChartRenderer)
                        .RenderPNGAsync(width, height, gChart)

                let path = Path.ensureFileExtension ".png" path

                return rendered |> getBytesFromBase64String |> fun base64 -> File.WriteAllBytes(path, base64)
            }

        member this.SavePNG(path: string, width: int, height: int, gChart: GenericChart.GenericChart) =
            (this :> IGenericChartRenderer)
                .SavePNGAsync(path, width, height, gChart)
            |> Async.RunSynchronously

        member this.RenderSVGAsync(width: int, height: int, gChart: GenericChart.GenericChart) =
            async {
                use! browser = fetchAndLaunchBrowserAsync ()

                let! renderedString =
                    tryRenderAsync browser width height StyleParam.ImageFormat.SVG (gChart |> toFullScreenHtml)

                return renderedString |> fun svg -> System.Uri.UnescapeDataString(svg) |> skipDataTypeString
            }

        member this.RenderSVG(width: int, height: int, gChart: GenericChart.GenericChart) =
            (this :> IGenericChartRenderer)
                .RenderSVGAsync(width, height, gChart)
            |> Async.RunSynchronously

        member this.SaveSVGAsync(path: string, width: int, height: int, gChart: GenericChart.GenericChart) =
            async {
                let! rendered =
                    (this :> IGenericChartRenderer)
                        .RenderSVGAsync(width, height, gChart)
                    
                let path = Path.ensureFileExtension ".svg" path

                return rendered |> fun svg -> File.WriteAllText(path, svg)
            }

        member this.SaveSVG(path: string, width: int, height: int, gChart: GenericChart.GenericChart) =
            (this :> IGenericChartRenderer)
                .SaveSVGAsync(path, width, height, gChart)
            |> Async.RunSynchronously
