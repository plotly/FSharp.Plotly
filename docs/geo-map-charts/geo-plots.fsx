(**
---
title: Scatter and line plots on Geo maps
category: Geo map charts
categoryindex: 6
index: 2
---
*)

(*** hide ***)

(*** condition: prepare ***)
#r "nuget: Newtonsoft.JSON, 13.0.1"
#r "nuget: DynamicObj, 2.0.0"
#r "nuget: Giraffe.ViewEngine.StrongName, 2.0.0-alpha1"
#r "nuget: Deedle"
#r "../../src/Plotly.NET/bin/Release/netstandard2.0/Plotly.NET.dll"

Plotly.NET.Defaults.DefaultDisplayOptions <-
    Plotly.NET.DisplayOptions.init (PlotlyJSReference = Plotly.NET.PlotlyJSReference.NoReference)

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#endif // IPYNB

(** 
# Scatter and line plots on Geo maps

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/plotly.net/gh-pages?urlpath=/tree/home/jovyan/{{fsdocs-source-basename}}.ipynb)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create Point and Line charts on geo maps in F#.

Let's first create some data for the purpose of creating example charts:
*)
open Plotly.NET

let cityNames =
    [ "Montreal"
      "Toronto"
      "Vancouver"
      "Calgary"
      "Edmonton"
      "Ottawa"
      "Halifax"
      "Victoria"
      "Winnepeg"
      "Regina" ]

let lon =
    [ -73.57
      -79.24
      -123.06
      -114.1
      -113.28
      -75.43
      -63.57
      -123.21
      -97.13
      -104.6 ]

let lat = [ 45.5; 43.4; 49.13; 51.1; 53.34; 45.24; 44.64; 48.25; 49.89; 50.45 ]

(**
The simplest type of geo plot is plotting the (lon,lat) pairs of a location via `Chart.PointGeo`. 
Here is an example using the location of Canadian cities:
*)

open Plotly.NET.LayoutObjects

let pointGeo =
    Chart.PointGeo(
        longitudes = lon,
        latitudes = lat,
        MultiText = cityNames,
        TextPosition = StyleParam.TextPosition.TopCenter
    )
    |> Chart.withGeoStyle (
        Scope = StyleParam.GeoScope.NorthAmerica,
        Projection = GeoProjection.init (StyleParam.GeoProjectionType.AzimuthalEqualArea),
        CountryColor = Color.fromString "lightgrey"
    )
    |> Chart.withMarginSize (0, 0, 0, 0)

(*** condition: ipynb ***)
#if IPYNB
pointGeo
#endif // IPYNB

(***hide***)
pointGeo |> GenericChart.toChartHTML
(***include-it-raw***)


(**
To connect the given (lon,lat) pairs via straight lines, use `Chart.LineGeo`. 
Below is an example that pulls external data as a Deedle data 
frame containing the source and target locations of American Airlines flights from Feb. 2011:
*)

open Deedle
open System.IO
open System.Text

let data =
    __SOURCE_DIRECTORY__ + "/../data/2011_february_aa_flight_paths.csv"
    |> fun csv -> Frame.ReadCsv(csv, true, separators = ",")

let opacityVals: float[] =
    data.["cnt"]
    |> Series.values
    |> fun s -> s |> Seq.map (fun v -> v / (Seq.max s)) |> Array.ofSeq

let startCoords = Series.zipInner data.["start_lon"] data.["start_lat"]
let endCoords = Series.zipInner data.["end_lon"] data.["end_lat"]
let coords = Series.zipInner startCoords endCoords |> Series.values

let flights =
    coords
    |> Seq.mapi (fun i (startCoords, endCoords) ->
        Chart.LineGeo(
            lonlat = [ startCoords; endCoords ],
            Opacity = opacityVals.[i],
            MarkerColor = Color.fromString "red"
        ))
    |> Chart.combine
    |> Chart.withLegend (false)
    |> Chart.withGeoStyle (
        Scope = StyleParam.GeoScope.NorthAmerica,
        Projection = GeoProjection.init (StyleParam.GeoProjectionType.AzimuthalEqualArea),
        ShowLand = true,
        LandColor = Color.fromString "lightgrey"
    )
    |> Chart.withMarginSize (0, 0, 50, 0)
    |> Chart.withTitle "Feb. 2011 American Airline flights"

(*** condition: ipynb ***)
#if IPYNB
flights
#endif // IPYNB

(***hide***)
flights |> GenericChart.toChartHTML
(***include-it-raw***)
