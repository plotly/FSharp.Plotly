module Tests.ImageExport

open System.Runtime.InteropServices
open Expecto
open Plotly.NET
open Plotly.NET.ImageExport

open System
open System.IO

let readTestFilePlatformSpecific filePostfix =
    if RuntimeInformation.IsOSPlatform(OSPlatform.Linux) then
        let content = File.ReadAllText (__SOURCE_DIRECTORY__ + $"/data/linux{filePostfix}")
        content.Substring(0, content.Length - 1) // Because on Linux you're expected to newline terminate the file
    else if RuntimeInformation.IsOSPlatform(OSPlatform.Windows) then
        File.ReadAllText (__SOURCE_DIRECTORY__ + $"/data/win{filePostfix}")
    else
        raise (Exception "Running tests on the current OS is not supported :(")
         
// https://github.com/hardkoded/puppeteer-sharp/issues/2792 maybe
// generation fails on linux CI, workaround like this?
PuppeteerSharpRendererOptions.launchOptions.Args <- Array.concat [PuppeteerSharpRendererOptions.launchOptions.Args; [| "--no-sandbox" |]]

[<Tests>]
let ``Image export base64 strings tests`` =
    // this has to run in sequence as the first call will establish chromium dependencies.
    // assigning exact equality on the produced images seems hard to do. 
    // the jpeg test for example works on windows, but produces a very slightly different base64 string on ubuntu.
    // This is very frustrating stuff.
    testSequencedGroup "ImageExport_Sequenced" (
        // skipping this for now, cannot make it work atm (pTestAsync -> testAsync for running it)
        testList "base64 strings" [
            ptestAsync "Chart.toBase64JPGStringAsync" {
                let testBase64JPG = readTestFilePlatformSpecific "TestBase64JPG.txt"
                
                let! actual = (Chart.Point([1.,1.]) |> Chart.toBase64JPGStringAsync() |> Async.AwaitTask)

                return 
                    Expect.equal
                        actual
                        testBase64JPG
                        "Invalid base64 string for Chart.toBase64JPGStringAsync"
            }
            ptestAsync "Chart.toBase64PNGStringAsync" {
                let testBase64PNG = readTestFilePlatformSpecific "TestBase64PNG.txt"
                
                let! actual = (Chart.Point([1.,1.]) |> Chart.toBase64PNGStringAsync() |> Async.AwaitTask)

                return 
                    Expect.equal
                        actual
                        testBase64PNG
                        "Invalid base64 string for Chart.toBase64PNGStringAsync"
            }
            testCase "Chart.toBase64JPGString terminates" <| fun () ->
                let actual = Chart.Point([1.,1.]) |> Chart.toBase64JPGString()
                Expect.isTrue (actual.Length > 100) ""

            testCase "Chart.toBase64PNGString terminates" <| fun () ->
                let actual = Chart.Point([1.,1.]) |> Chart.toBase64PNGString()
                Expect.isTrue (actual.Length > 100) ""            

            testCase "Chart.toSVGString terminates" <| fun () ->
                let actual = Chart.Point([1.,1.]) |> Chart.toSVGString()
                Expect.isTrue (actual.Length > 100) ""
        ]
    )

[<Tests>]
let ``Image export save files tests`` =
    testSequencedGroup "ImageExport_Sequenced" (
        testList "save files" [
            testCase "Chart.saveJPG creates file" <| fun () ->
                Chart.Point([1.,1.]) |> Chart.saveJPG("testChart.jpg")
                Expect.isTrue (File.Exists("testChart.jpg.jpg")) "file does not exist."
            testCase "Chart.savePNG creates file" <| fun () ->
                Chart.Point([1.,1.]) |> Chart.savePNG("testChart.png")
                Expect.isTrue (File.Exists("testChart.png.png")) "file does not exist."
            testCase "Chart.saveSVG creates file" <| fun () ->
                Chart.Point([1.,1.]) |> Chart.saveSVG("testChart.svg")
                Expect.isTrue (File.Exists("testChart.svg.svg")) "file does not exist."
        ]
    )
