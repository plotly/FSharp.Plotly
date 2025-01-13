namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

type AspectRatio() =

    inherit DynamicObj()

    static member init
        (
            ?X: float,
            ?Y: float,
            ?Z: float
        ) =
        AspectRatio() |> AspectRatio.style (?X = X, ?Y = Y, ?Z = Z)

    static member style
        (
            ?X: float,
            ?Y: float,
            ?Z: float
        ) =

        fun (aspectRatio: AspectRatio) ->

            aspectRatio
            |> DynObj.withOptionalProperty "x" X 
            |> DynObj.withOptionalProperty "y" Y 
            |> DynObj.withOptionalProperty "z" Z 

