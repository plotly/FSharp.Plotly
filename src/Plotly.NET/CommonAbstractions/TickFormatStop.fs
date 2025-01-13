namespace Plotly.NET

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

type TickFormatStop() =
    inherit DynamicObj()

    static member init
        (
            ?Enabled: bool,
            ?DTickRange: seq<string * string>,
            ?Value: string,
            ?Name: string,
            ?TemplateItemName: string
        ) =
        TickFormatStop()
        |> TickFormatStop.style (
            ?Enabled = Enabled,
            ?DTickRange = DTickRange,
            ?Value = Value,
            ?Name = Name,
            ?TemplateItemName = TemplateItemName
        )

    static member style
        (
            ?Enabled: bool,
            ?DTickRange: seq<string * string>,
            ?Value: string,
            ?Name: string,
            ?TemplateItemName: string
        ) =
        (fun (tickFormatStop: TickFormatStop) ->

            tickFormatStop
            |> DynObj.withOptionalProperty "enabled" Enabled
            |> DynObj.withOptionalProperty "dtickrange" DTickRange
            |> DynObj.withOptionalProperty "value" Value
            |> DynObj.withOptionalProperty "name" Name
            |> DynObj.withOptionalProperty "templateitemname" TemplateItemName
        )
