namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

/// Styles for connector lines in Waterfall Charts.
///
/// Parameters:
///
/// Line          : Sets the Line style for this WaterfallConnector
///
/// Visible       : Whether or not connectors are visible
///
/// ConnectorMode : Sets the shape of connector lines.
type WaterfallConnector() =
    inherit DynamicObj()

    static member init
        (
            ?Line: Line,
            ?Visible: bool,
            ?ConnectorMode: StyleParam.ConnectorMode
        ) =

        WaterfallConnector()
        |> WaterfallConnector.style (?Line = Line, ?Visible = Visible, ?ConnectorMode = ConnectorMode)

    static member style
        (
            ?Line: Line,
            ?Visible: bool,
            ?ConnectorMode: StyleParam.ConnectorMode
        ) =
        fun (connector: WaterfallConnector) ->

            connector
            |> DynObj.withOptionalProperty "line" Line
            |> DynObj.withOptionalProperty "visible" Visible
            |> DynObj.withOptionalPropertyBy "mode" ConnectorMode StyleParam.ConnectorMode.convert
