namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

/// Bin type inherits from dynamic object
type Bins() =
    inherit DynamicObj()

    // Init Bins()
    static member init
        (
            ?Start: float,
            ?End: float,
            ?Size: float
        ) =
        Bins() |> Bins.style (?Start = Start, ?End = End, ?Size = Size)


    // Applies the styles to Bins()
    static member style
        (
            ?Start: float,
            ?End: float,
            ?Size: float
        ) =

        fun (bins: Bins) ->

            bins
            |> DynObj.withOptionalProperty "start" Start
            |> DynObj.withOptionalProperty "end" End
            |> DynObj.withOptionalProperty "size" Size
