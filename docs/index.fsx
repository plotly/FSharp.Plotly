(*** hide ***)

(*** condition: prepare ***)
#r "nuget: Deedle"
#r "nuget: FsHttp"
#r "nuget: Newtonsoft.JSON, 13.0.1"
#r "nuget: DynamicObj, 2.0.0"
#r "nuget: Giraffe.ViewEngine.StrongName, 2.0.0-alpha1"
#r "../src/Plotly.NET/bin/Release/netstandard2.0/Plotly.NET.dll"

Plotly.NET.Defaults.DefaultDisplayOptions <-
    Plotly.NET.DisplayOptions.init (PlotlyJSReference = Plotly.NET.PlotlyJSReference.NoReference)

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#endif // IPYNB

(**
# Plotly.NET
 
[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

Plotly.NET provides functions for generating and rendering plotly.js charts in **.NET** programming languages 📈🚀. 

**This documentation page is almost exclusively for the core F# API of Plotly.NET.** 

It should be easy to translate them into C#. However, as work on the idiomatic C# API progresses, we will provide native C# docs as well.

### Table of contents 

- [Installation](#Installation)
    - [For applications and libraries](#For-applications-and-libraries)
    - [For scripting](#For-scripting)
    - [For dotnet interactive notebooks](#For-dotnet-interactive-notebooks)
- [Overview](#Overview)
    - [Basics](#Basics)
        - [Initializing a chart](#Initializing-a-chart)
        - [Styling a chart](#Styling-a-chart)
        - [Displaying a chart](#Displaying-a-chart)
    - [Comparison: Usage in F# and C#](#Comparison-Usage-in-F-and-C)
        - [Functional pipeline style in F#](#Functional-pipeline-style-in-F)
        - [Fluent interface style in C#](#Fluent-interface-style-in-C)
        - [Declarative style in F# using the underlying `DynamicObj`](#Declarative-style-in-F-using-the-underlying)
        - [Declarative style in C# using the underlying `DynamicObj`](#Declarative-style-in-C-using-the-underlying)
- [Contributing and copyright](#Contributing-and-copyright)

# Installation

Plotly.NET consists of multiple packages. The two main ones are:

- Plotly.NET [![](https://img.shields.io/nuget/vpre/Plotly.NET)](https://www.nuget.org/packages/Plotly.NET/), the core API written in F#. 
- Plotly.NET.CSharp [![](https://img.shields.io/nuget/vpre/Plotly.NET.CSharp)](https://www.nuget.org/packages/Plotly.NET.CSharp/), native C# bindings that make the usage of Plotly.NET more idiomatic from C#. This is work in progress. Missing charts and/or styling must be done via the core API. 

### For applications and libraries

Plotly.NET packages are available on NuGet to plug into your favorite package manager.

 - dotnet CLI

    ```shell
    dotnet add package Plotly.NET --version {{fsdocs-package-version}}
    ```

 - paket CLI

    ```shell
    paket add Plotly.NET --version {{fsdocs-package-version}}
    ```

 - package manager

    ```shell
    Install-Package Plotly.NET -Version {{fsdocs-package-version}}
    ```

    Or add the package reference directly to your `.*proj` file:

    ```
    <PackageReference Include="Plotly.NET" Version="{{fsdocs-package-version}}" />
    ```

### For scripting

You can include the package via an inline package reference:

```
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
```

### For dotnet interactive notebooks

You can use the same inline package reference as in scripts, but as an additional goodie
the interactive extensions for dotnet interactive have you covered for seamless chart rendering:

```
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
```

_Note_: 

Due to the currently fast development cycles of .NET Interactive, there might be increments in their versioning that render the current version of Plotly.NET.Interactive incompatible (example [here](https://github.com/plotly/Plotly.NET/issues/67)).

If the interactive extension does not work, please file an issue and we will try to get it running again as soon as possible.

A possible fix for this is the inclusion of Dotnet.Interactive preview package sources. To use these, add the following lines before referencing Plotly.NET.Interactive:

```no-hl
#i "nuget:https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet5/nuget/v3/index.json"
#i "nuget:https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-tools/nuget/v3/index.json"
```

# Overview

## Basics

The general, high-level API of Plotly.NET implements the following visualization flow:

- **initialize** a `GenericChart` object from the data you want to visualize by using the respective `Chart.*` function, optionally setting some specific style parameters
- further **style** the chart with fine-grained control, e.g. by setting axis titles, tick intervals, etc.
- **display** (in the browser or as cell result in a notebook) or save the chart 

### Initializing a chart

The `Chart` module contains a lot of functions named after the type of chart they will create, e.g. 
`Chart.Point` will create a point chart, `Chart.Scatter3d` wil create a 3D scatter chart, and so on.

The respective functions all contain specific arguments, but they all have in common that the first 
mandatory arguments are the data to visualize. 

Example: The first two arguments of the `Chart.Point` function are the x and y data. You can therefore initialize a point chart like this:

*)
open Plotly.NET
let xData = [ 0. .. 10. ]
let yData = [ 0. .. 10. ]
let myFirstChart = Chart.Point(xData, yData)

(**

### Styling a chart

Styling functions are generally the `Chart.with*` naming convention. The following styling example does:

 - set the chart title via `Chart.withTitle`
 - set the x axis title and removes the gridline from the axis via `Chart.withXAxisStyle`
 - set the y axis title and removes the gridline from the axis via `Chart.withYAxisStyle`

*)

let myFirstStyledChart =
    Chart.Point(xData, yData)
    |> Chart.withTitle "Hello world!"
    |> Chart.withXAxisStyle ("xAxis")
    |> Chart.withYAxisStyle ("yAxis")

(**
**Attention:** Styling functions mutate 😈 the input chart, therefore possibly affecting bindings to intermediary results. 
We recommend creating a single chart for each workflow to prevent unexpected results.

### Displaying a chart in the browser

The `Chart.Show` function will open a browser window and render the input chart there. When working in a notebook context, after
[referencing Plotly.NET.Interactive](#For-dotnet-interactive-notebooks), the function is not necessary, just end the cell with the value of the chart.

*)

(***do-not-eval***)
myFirstChart |> Chart.show

(**Should render this chart in your browser:*)

(***hide***)
myFirstChart |> GenericChart.toChartHTML
(*** include-it-raw ***)

(***do-not-eval***)
myFirstStyledChart |> Chart.show

(**And here is what happened after applying the styles from above:*)

(***hide***)
myFirstStyledChart |> GenericChart.toChartHTML
(*** include-it-raw ***)


(**
### Displaying a chart in a notebook cell output

In a notebook context, you usually have (at least when running on a Jupyter server like Binder) no access to the browser on the machine where plotly runs on.
That's why you can render charts directly in the cell output. Just end the cell with the chart value:
*)

let xData' = [ 0. .. 10. ]
let yData' = [ 0. .. 10. ]
Chart.Point(xData', yData')

(**Here is the styled chart:*)

Chart.Point(xData, yData)
|> Chart.withTitle "Hello world!"
|> Chart.withXAxisStyle ("xAxis")
|> Chart.withYAxisStyle ("yAxis")


(**
## Comparison: Usage in F# and C#

One of the main design points of Plotly.NET is to provide support for multiple flavors of chart generation. Here are two examples in different styles and languages that create equivalent charts:
 
### Functional pipeline style in F#:
*)

[ (1, 5); (2, 10) ]
|> Chart.Point
|> Chart.withTraceInfo (Name = "Hello from F#")
|> Chart.withYAxisStyle (TitleText = "xAxis")
|> Chart.withXAxisStyle (TitleText = "yAxis")

(**
### Fluent interface style in C#:

This example uses the high-level native C# bindings for Plotly.NET that are provided by the `Plotly.NET.CSharp` package.

```csharp
using System;
using Plotly.NET.CSharp;

Chart.Point<double, double, string>(
    x: new double[] { 1, 2 }, 
    y: new double[] { 5, 10 }
)
.WithTraceInfo("Hello from C#", ShowLegend: true)
.WithXAxisStyle<double, double, string>(Title: Plotly.NET.Title.init("xAxis"))
.WithYAxisStyle<double, double, string>(Title: Plotly.NET.Title.init("yAxis"))
.Show();
```

### Declarative style in F# using the underlying `DynamicObj`:

This API is the most low-level and closest to the original plotly.js syntax. Make sure to spell dynamic members exactly as they are used in the plotly.js json schema.
*)

open Plotly.NET.LayoutObjects

let xAxis =
    let tmp = LinearAxis()
    tmp?title <- "xAxis"
    tmp?showgrid <- false
    tmp?showline <- true
    tmp

let yAxis =
    let tmp = LinearAxis()
    tmp?title <- "yAxis"
    tmp?showgrid <- false
    tmp?showline <- true
    tmp

let layout =
    let tmp = Layout()
    tmp?xaxis <- xAxis
    tmp?yaxis <- yAxis
    tmp?showlegend <- true
    tmp

let trace =
    let tmp = Trace("scatter")
    tmp?x <- [ 1; 2 ]
    tmp?y <- [ 5; 10 ]
    tmp?mode <- "markers"
    tmp?name <- "Hello from F#"
    tmp

GenericChart.ofTraceObject true trace |> GenericChart.setLayout layout

(**
### Declarative style in C# using the underlying `DynamicObj`:

Note that this works only when using the Plotly.NET core API, as the C# bindings only target the high level API.

```csharp
using System;
using Plotly.NET;
using Plotly.NET.LayoutObjects;

double[] x = new double[] { 1, 2 };
double[] y = new double[] { 5, 10 };

LinearAxis xAxis = new LinearAxis();
xAxis.SetValue("title", "xAxis");
xAxis.SetValue("showgrid", false);
xAxis.SetValue("showline", true);

LinearAxis yAxis = new LinearAxis();
yAxis.SetValue("title", "yAxis");
yAxis.SetValue("showgrid", false);
yAxis.SetValue("showline", true);

Layout layout = new Layout();
layout.SetValue("xaxis", xAxis);
layout.SetValue("yaxis", yAxis);
layout.SetValue("showlegend", true);

Trace trace = new Trace("scatter");
trace.SetValue("x", x);
trace.SetValue("y", y);
trace.SetValue("mode", "markers");
trace.SetValue("name", "Hello from C#");

GenericChart
    .ofTraceObject(true, trace)
    .WithLayout(layout)
    .Show();
```

# Contributing and copyright

The project is hosted on [GitHub][gh] where you can [report issues][issues], fork 
the project and submit pull requests. If you're adding a new public API, please also 
consider adding [samples][docs] that can be turned into a documentation. You might
also want to read the [library design notes][readme] to understand how it works.

The library is available under the OSI-approved MIT license which allows modification and 
redistribution for both commercial and non-commercial purposes. For more information, see the 
[License file][license] in the GitHub repository. 

  [docs]: https://github.com/plotly/Plotly.NET/tree/dev/docs
  [gh]: https://github.com/plotly/Plotly.NET
  [issues]: https://github.com/plotly/Plotly.NET/issues
  [readme]: https://github.com/plotly/Plotly.NET/blob/dev/README.md
  [license]: https://github.com/plotly/Plotly.NET/blob/dev/LICENSE
*)
