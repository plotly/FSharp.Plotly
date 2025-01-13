namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

type ModeBar() =
    inherit DynamicObj()

    static member init
        (
            ?ActiveColor: Color,
            ?Add: seq<string>,
            ?BGColor: Color,
            ?Color: Color,
            ?Orientation: StyleParam.Orientation,
            ?Remove: string,
            ?UIRevision: string
        ) =
        ModeBar()
        |> ModeBar.style (
            ?ActiveColor = ActiveColor,
            ?Add = Add,
            ?BGColor = BGColor,
            ?Color = Color,
            ?Orientation = Orientation,
            ?Remove = Remove,
            ?UIRevision = UIRevision
        )

    static member style
        (
            ?ActiveColor: Color,
            ?Add: seq<string>,
            ?BGColor: Color,
            ?Color: Color,
            ?Orientation: StyleParam.Orientation,
            ?Remove: string,
            ?UIRevision: string
        ) =
        (fun (modeBar: ModeBar) ->

            modeBar
            |> DynObj.withOptionalProperty "activecolor" ActiveColor
            |> DynObj.withOptionalProperty "add" Add
            |> DynObj.withOptionalProperty "bgcolor" BGColor
            |> DynObj.withOptionalProperty "color" Color
            |> DynObj.withOptionalPropertyBy "orientation" Orientation StyleParam.Orientation.convert
            |> DynObj.withOptionalProperty "remove" Remove
            |> DynObj.withOptionalProperty "uirevision " UIRevision
        )
