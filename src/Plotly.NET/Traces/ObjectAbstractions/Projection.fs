namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices


type ProjectionDimension() =
    inherit DynamicObj()

    static member init
        (
            ?Opacity: float,
            ?Scale: float,
            ?Show: bool
        ) =
        ProjectionDimension() |> ProjectionDimension.style (?Opacity = Opacity, ?Scale = Scale, ?Show = Show)

    static member style
        (
            ?Opacity: float,
            ?Scale: float,
            ?Show: bool
        ) =

        fun (projectionDimension: ProjectionDimension) ->

            projectionDimension
            |> DynObj.withOptionalProperty "opacity" Opacity
            |> DynObj.withOptionalProperty "scale" Scale
            |> DynObj.withOptionalProperty "show" Show

type Projection() =
    inherit DynamicObj()

    static member init
        (
            ?X: ProjectionDimension,
            ?Y: ProjectionDimension,
            ?Z: ProjectionDimension
        ) =
        Projection() |> Projection.style (?X = X, ?Y = Y, ?Z = Z)

    static member style
        (
            ?X: ProjectionDimension,
            ?Y: ProjectionDimension,
            ?Z: ProjectionDimension
        ) =

        fun (projection: Projection) ->

            projection
            |> DynObj.withOptionalProperty "x" X
            |> DynObj.withOptionalProperty "y" Y
            |> DynObj.withOptionalProperty "z" Z