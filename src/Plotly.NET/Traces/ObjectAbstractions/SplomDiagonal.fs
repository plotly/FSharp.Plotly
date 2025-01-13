namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type SplomDiagonal() =
    inherit DynamicObj()

    static member init(?Visible: bool) =
        SplomDiagonal() |> SplomDiagonal.style (?Visible = Visible)

    static member style(?Visible: bool) =

        fun (splomDiagonal: SplomDiagonal) ->

            splomDiagonal
            |> DynObj.withOptionalProperty "visible" Visible
