namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type Gradient() =
    inherit DynamicObj()

    static member init
        (
            ?Color: Color,
            ?Type: StyleParam.GradientType,
            ?MultiTypes: seq<StyleParam.GradientType>
        ) =
        Gradient() |> Gradient.style (?Color = Color, ?Type = Type, ?MultiTypes = MultiTypes)

    static member style
        (
            ?Color: Color,
            ?Type: StyleParam.GradientType,
            ?MultiTypes: seq<StyleParam.GradientType>
        ) =

        fun (gradient: Gradient) ->

            gradient
            |> DynObj.withOptionalSingleOrMultiProperty "type" (Type, MultiTypes)
            |> DynObj.setOptionalProperty "color" Color
