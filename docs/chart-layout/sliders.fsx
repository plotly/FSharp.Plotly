(**
---
title: Sliders
category: Chart Layout
categoryindex: 2
index: 7
---
*)

(*** hide ***)

(*** condition: prepare ***)
#r "nuget: Newtonsoft.JSON, 13.0.1"
#r "nuget: DynamicObj, 2.0.0"
#r "nuget: Giraffe.ViewEngine.StrongName, 2.0.0-alpha1"
#r "../../src/Plotly.NET/bin/Release/netstandard2.0/Plotly.NET.dll"

Plotly.NET.Defaults.DefaultDisplayOptions <-
    Plotly.NET.DisplayOptions.init (PlotlyJSReference = Plotly.NET.PlotlyJSReference.NoReference)

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#endif // IPYNB

(** 
# Sliders

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create charts with sliders in F#.

The sliders give the option of passing the arguments to the Plotly chart. In the example we use the visibility parameter to make the step chosen in the slider visible.

The original example is written in Python and can be found [here](https://plotly.com/python/sliders)
*)

open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

/// Similar to numpy.arrange
let nparange (start: double) (stop: double) (step: double) =
    let stepsCount = ((stop - start) / step) |> int
    seq { for i in 0..stepsCount -> start + double (i) * step } |> Array.ofSeq

let steps = nparange 0. 5. 0.1

let scattersChart =
    steps
    |> Seq.map (fun step ->
        // Create a scatter plot for every step
        let x = nparange 0. 10. 0.01
        let y = seq { for x_ in x -> sin (step * x_) }
        // Some plot must be visible here or the chart is empty at the beginning
        let chartVisibility =
            if step = 0. then
                StyleParam.Visible.True
            else
                StyleParam.Visible.False

        let go =
            Chart.Scatter(
                x = x,
                y = y,
                mode = StyleParam.Mode.Lines,
                Name = "v = " + string (step),
                Marker = Marker.init (Color = Color.fromHex ("#00CED1"), Size = 6)
            )
            |> Chart.withTraceInfo (Visible = chartVisibility)

        go)
    |> GenericChart.combine

let sliderSteps =
    steps
    |> Seq.indexed
    |> Seq.map (fun (i, step) ->
        // Create a visibility and a title parameter
        // The visibility parameter includes an array where every parameter
        // is mapped onto the trace visibility
        let visible =
            // Set true only for the current step
            (fun index -> index = i) |> Array.init steps.Length |> box

        let title = sprintf "Slider switched to step: %f" step |> box

        SliderStep.init (
            Args = [ "visible", visible; "title", title ],
            Method = StyleParam.Method.Update,
            Label = "v = " + string (step)
        ))

let slider =
    Slider.init (
        CurrentValue = SliderCurrentValue.init (Prefix = "Frequency: "),
        Padding = Padding.init (T = 50),
        Steps = sliderSteps
    )

let chart = scattersChart |> Chart.withSlider slider

(*** condition: ipynb ***)
#if IPYNB
chart
#endif // IPYNB

(***hide***)
chart |> GenericChart.toChartHTML
(***include-it-raw***)
