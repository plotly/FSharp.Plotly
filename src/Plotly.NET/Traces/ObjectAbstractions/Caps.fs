namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type CapFill() =
    inherit DynamicObj()

    static member init
        (
            ?Fill: float,
            ?Show: bool
        ) =
        CapFill() |> CapFill.style (?Fill = Fill, ?Show = Show)

    static member style
        (
            ?Fill: float,
            ?Show: bool
        ) =

        fun (capFill: CapFill) ->

            capFill
            |> DynObj.withOptionalProperty "fill" Fill
            |> DynObj.withOptionalProperty "show" Show


type Caps() =
    inherit DynamicObj()

    static member init
        (
            ?X: CapFill,
            ?Y: CapFill,
            ?Z: CapFill
        ) =

        Caps() |> Caps.style (?X = X, ?Y = Y, ?Z = Z)

    static member style
        (
            ?X: CapFill,
            ?Y: CapFill,
            ?Z: CapFill
        ) =
        fun (caps: Caps) ->

            caps
            |> DynObj.withOptionalProperty "x" X
            |> DynObj.withOptionalProperty "y" Y
            |> DynObj.withOptionalProperty "z" Z
