namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

/// <summary></summary>
type MapboxLayerSymbol() =

    inherit DynamicObj()

    /// <summary>Initialize a MapboxLayer object</summary>

    static member init
        (
            ?Icon: string,
            ?IconSize: float,
            ?Text: string,
            ?Placement: StyleParam.MapboxLayerSymbolPlacement,
            ?TextFont: Font,
            ?TextPosition: StyleParam.TextPosition
        ) =
        MapboxLayerSymbol()
        |> MapboxLayerSymbol.style (
            ?Icon = Icon,
            ?IconSize = IconSize,
            ?Text = Text,
            ?Placement = Placement,
            ?TextFont = TextFont,
            ?TextPosition = TextPosition
        )

    /// <summary>Create a function that applies the given style parameters to a MapboxLayer object.</summary>

    static member style
        (
            ?Icon: string,
            ?IconSize: float,
            ?Text: string,
            ?Placement: StyleParam.MapboxLayerSymbolPlacement,
            ?TextFont: Font,
            ?TextPosition: StyleParam.TextPosition
        ) =
        fun (mapBoxLayerSymbol: MapboxLayerSymbol) ->

            mapBoxLayerSymbol
            |> DynObj.withOptionalProperty   "icon"         Icon         
            |> DynObj.withOptionalProperty   "iconsize"     IconSize     
            |> DynObj.withOptionalProperty   "text"         Text         
            |> DynObj.withOptionalPropertyBy "placement"    Placement    StyleParam.MapboxLayerSymbolPlacement.convert
            |> DynObj.withOptionalProperty   "textfont"     TextFont     
            |> DynObj.withOptionalPropertyBy "textposition" TextPosition StyleParam.TextPosition.convert
