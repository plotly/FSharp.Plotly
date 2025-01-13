namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

type DefaultColorScales() =
    inherit DynamicObj()

    static member init
        (
            ?Diverging: StyleParam.Colorscale,
            ?Sequential: StyleParam.Colorscale,
            ?SequentialMinus: StyleParam.Colorscale
        ) =
        DefaultColorScales()
        |> DefaultColorScales.style (
            ?Diverging = Diverging,
            ?Sequential = Sequential,
            ?SequentialMinus = SequentialMinus
        )

    static member style
        (
            ?Diverging: StyleParam.Colorscale,
            ?Sequential: StyleParam.Colorscale,
            ?SequentialMinus: StyleParam.Colorscale
        ) =
        (fun (defaultColorScales: DefaultColorScales) ->

            defaultColorScales
            |> DynObj.withOptionalPropertyBy "diverging" Diverging StyleParam.Colorscale.convert
            |> DynObj.withOptionalPropertyBy "sequential" Sequential StyleParam.Colorscale.convert
            |> DynObj.withOptionalPropertyBy "sequentialminus" SequentialMinus StyleParam.Colorscale.convert
        )
