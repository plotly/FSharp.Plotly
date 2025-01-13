namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

/// Styles for connector lines in Funnel Charts.
///
/// Parameters:
///
/// Line          : Sets the Line style for this WaterfallConnector
///
/// Visible       : Whether or not connectors are visible
///
/// ConnectorMode : Sets the shape of connector lines.
type FunnelConnector() =
    inherit DynamicObj()

    static member init
        (
            ?FillColor: Color,
            ?Line: Line,
            ?Visible: bool
        ) =

        FunnelConnector() |> FunnelConnector.style (?FillColor = FillColor, ?Line = Line, ?Visible = Visible)

    static member style
        (
            ?FillColor: Color,
            ?Line: Line,
            ?Visible: bool
        ) =
        fun (connector: FunnelConnector) ->

            connector
            |> DynObj.withOptionalProperty "fillcolor" FillColor
            |> DynObj.withOptionalProperty "line" Line
            |> DynObj.withOptionalProperty "visible" Visible
