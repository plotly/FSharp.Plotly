namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices


type SunburstRoot() =
    inherit DynamicObj()

    static member init(?Color: Color) =

        SunburstRoot() |> SunburstRoot.style (?Color = Color)

    static member style(?Color: Color) =
        fun (root: SunburstRoot) ->
            root
            |> DynObj.withOptionalProperty "color" Color

type SunburstLeaf() =
    inherit DynamicObj()

    static member init(?Opacity: float) =

        SunburstLeaf() |> SunburstLeaf.style (?Opacity = Opacity)

    static member style(?Opacity: float) =
        fun (leaf: SunburstLeaf) ->

            leaf
            |> DynObj.withOptionalProperty "opacity" Opacity

