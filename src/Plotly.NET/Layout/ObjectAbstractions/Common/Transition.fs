namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

type Transition() =
    inherit DynamicObj()

    static member init
        (
            ?Duration: int,
            ?Easing: StyleParam.TransitionEasing,
            ?Ordering: StyleParam.TransitionOrdering
        ) =
        Transition() |> Transition.style (?Duration = Duration, ?Easing = Easing, ?Ordering = Ordering)

    static member style
        (
            ?Duration: int,
            ?Easing: StyleParam.TransitionEasing,
            ?Ordering: StyleParam.TransitionOrdering
        ) =
        (fun (transition: Transition) ->

            transition
            |> DynObj.withOptionalProperty "duration" Duration
            |> DynObj.withOptionalPropertyBy "easing" Easing StyleParam.TransitionEasing.convert
            |> DynObj.withOptionalPropertyBy "ordering" Ordering StyleParam.TransitionOrdering.convert

        )
