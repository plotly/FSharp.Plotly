namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type Surface() =
    inherit DynamicObj()

    static member init
        (
            ?Count: int,
            ?Fill: float,
            ?Pattern: StyleParam.SurfacePattern,
            ?Show: bool
        ) =
        Surface() |> Surface.style (?Count = Count, ?Fill = Fill, ?Pattern = Pattern, ?Show = Show)

    static member style
        (
            ?Count: int,
            ?Fill: float,
            ?Pattern: StyleParam.SurfacePattern,
            ?Show: bool
        ) =

        fun (surface: Surface) ->

            surface
            |> DynObj.withOptionalProperty "count" Count
            |> DynObj.withOptionalProperty "fill" Fill
            |> DynObj.withOptionalPropertyBy "pattern" Pattern StyleParam.SurfacePattern.convert
            |> DynObj.withOptionalProperty "show" Show
