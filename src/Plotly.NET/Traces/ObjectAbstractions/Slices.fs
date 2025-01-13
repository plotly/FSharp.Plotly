namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type SlicesFill() =
    inherit DynamicObj()

    static member init
        (
            ?Fill: float,
            ?Locations: seq<#IConvertible>,
            ?Show: bool
        ) =
        SlicesFill() |> SlicesFill.style (?Fill = Fill, ?Locations = Locations, ?Show = Show)

    static member style
        (
            ?Fill: float,
            ?Locations: seq<#IConvertible>,
            ?Show: bool
        ) =

        fun (slicesFill: SlicesFill) ->

            slicesFill
            |> DynObj.withOptionalProperty "fill" Fill
            |> DynObj.withOptionalProperty "locations" Locations
            |> DynObj.withOptionalProperty "show" Show


type Slices() =
    inherit DynamicObj()

    static member init
        (
            ?X: SlicesFill,
            ?Y: SlicesFill,
            ?Z: SlicesFill
        ) =

        Slices() |> Slices.style (?X = X, ?Y = Y, ?Z = Z)

    static member style
        (
            ?X: SlicesFill,
            ?Y: SlicesFill,
            ?Z: SlicesFill
        ) =
        fun (slices: Slices) ->

            slices
            |> DynObj.withOptionalProperty "x" X
            |> DynObj.withOptionalProperty "y" Y
            |> DynObj.withOptionalProperty "z" Z
