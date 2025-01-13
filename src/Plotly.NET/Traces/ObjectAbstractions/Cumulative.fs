namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

//enabled (boolean)
//If true, display the cumulative distribution by summing the binned values. Use the `direction` and `centralbin` attributes to tune the accumulation method. Note: in this mode, the "density" `histnorm` settings behave the same as their equivalents without "density": "" and "density" both rise to the number of data points, and "probability" and "probability density" both rise to the number of sample points.
//direction ( enumerated : "increasing" | "decreasing" )
//default: "increasing"
//Only applies if cumulative is enabled. If "increasing" (default) we sum all prior bins, so the result increases from left to right. If "decreasing" we sum later bins so the result decreases from left to right.
//currentbin ( enumerated : "include" | "exclude" | "half" )
//default: "include"
//Only applies if cumulative is enabled. Sets whether the current bin is included, excluded, or has half of its value included in the current cumulative value. "include" is the default for compatibility with various other tools, however it introduces a half-bin bias to the results. "exclude" makes the opposite half-bin bias, and "half" removes it.


/// Cumulative type inherits from dynamic object
type Cumulative() =
    inherit DynamicObj()

    // Init Cumulative()
    static member init
        (
            ?Enabled: bool,
            ?Direction: StyleParam.CumulativeDirection,
            ?Currentbin: StyleParam.Currentbin
        ) =
        Cumulative() |> Cumulative.style (?Enabled = Enabled, ?Direction = Direction, ?Currentbin = Currentbin)


    // Applies the styles to Cumulative()
    static member style
        (
            ?Enabled: bool,
            ?Direction: StyleParam.CumulativeDirection,
            ?Currentbin: StyleParam.Currentbin
        ) =

        fun (cumulative: Cumulative) ->

            cumulative
            |> DynObj.withOptionalProperty "enabled" Enabled
            |> DynObj.withOptionalPropertyBy "direction" Direction StyleParam.CumulativeDirection.convert
            |> DynObj.withOptionalPropertyBy "currentbin" Currentbin StyleParam.Currentbin.convert
