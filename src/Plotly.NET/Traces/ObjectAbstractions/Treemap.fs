namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices


type TreemapRoot() =
    inherit DynamicObj()

    static member init(?Color: Color) =

        TreemapRoot() |> TreemapRoot.style (?Color = Color)

    static member style(?Color: Color) =
        fun (root: TreemapRoot) ->
            root
            |> DynObj.withProperty "color" Color

type TreemapLeaf() =
    inherit DynamicObj()

    static member init(?Opacity: float) =

        TreemapLeaf() |> TreemapLeaf.style (?Opacity = Opacity)

    static member style(?Opacity: float) =
        fun (leaf: TreemapLeaf) ->

            leaf
            |> DynObj.withOptionalProperty "opacity" Opacity


type TreemapTiling() =
    inherit DynamicObj()

    static member init
        (
            ?Packing: StyleParam.TreemapTilingPacking,
            ?SquarifyRatio: float,
            ?Flip: StyleParam.TilingFlip,
            ?Pad: float
        ) =

        TreemapTiling()
        |> TreemapTiling.style (?Packing = Packing, ?SquarifyRatio = SquarifyRatio, ?Flip = Flip, ?Pad = Pad)

    static member style
        (
            ?Packing: StyleParam.TreemapTilingPacking,
            ?SquarifyRatio: float,
            ?Flip: StyleParam.TilingFlip,
            ?Pad: float
        ) =
        fun (tiling: TreemapTiling) ->

            tiling
            |> DynObj.withOptionalPropertyBy "packing" Packing StyleParam.TreemapTilingPacking.convert
            |> DynObj.withOptionalProperty "squarifyRatio" SquarifyRatio
            |> DynObj.withOptionalPropertyBy "flip" Flip StyleParam.TilingFlip.convert
            |> DynObj.withOptionalProperty "pad" Pad
