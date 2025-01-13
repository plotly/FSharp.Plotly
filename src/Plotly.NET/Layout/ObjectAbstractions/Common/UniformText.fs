namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

type UniformText() =
    inherit DynamicObj()

    static member init
        (
            ?MinSize: int,
            ?Mode: StyleParam.UniformTextMode
        ) =
        UniformText() |> UniformText.style (?MinSize = MinSize, ?Mode = Mode)

    static member style
        (
            ?MinSize: int,
            ?Mode: StyleParam.UniformTextMode
        ) =
        (fun (uniformText: UniformText) ->

            uniformText
            |> DynObj.withOptionalProperty "minsize" MinSize
            |> DynObj.withOptionalPropertyBy "mode" Mode StyleParam.UniformTextMode.convert
        )
