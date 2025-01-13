namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

/// <summary></summary>
type MapboxLayer() =

    inherit DynamicObj()

    /// <summary>Initialize a MapboxLayer object</summary>

    static member init
        (
            ?Visible: bool,
            ?SourceType: StyleParam.MapboxLayerSourceType,
            ?Source: #IConvertible,
            ?SourceLayer: string,
            ?SourceAttribution: string,
            ?Type: StyleParam.MapboxLayerType,
            ?Coordinates: seq<#IConvertible * #IConvertible>,
            ?Below: string,
            ?Color: Color,
            ?Opacity: float,
            ?MinZoom: float,
            ?MaxZoom: float,
            ?CircleRadius: float,
            ?Line: Line,
            ?FillOutlineColor: Color,
            ?Symbol: MapboxLayerSymbol,
            ?Name: string
        ) =
        MapboxLayer()
        |> MapboxLayer.style (
            ?Visible = Visible,
            ?SourceType = SourceType,
            ?Source = Source,
            ?SourceLayer = SourceLayer,
            ?SourceAttribution = SourceAttribution,
            ?Type = Type,
            ?Coordinates = Coordinates,
            ?Below = Below,
            ?Color = Color,
            ?Opacity = Opacity,
            ?MinZoom = MinZoom,
            ?MaxZoom = MaxZoom,
            ?CircleRadius = CircleRadius,
            ?Line = Line,
            ?FillOutlineColor = FillOutlineColor,
            ?Symbol = Symbol,
            ?Name = Name
        )

    /// <summary>Create a function that applies the given style parameters to a MapboxLayer object.</summary>

    static member style
        (
            ?Visible: bool,
            ?SourceType: StyleParam.MapboxLayerSourceType,
            ?Source: #IConvertible,
            ?SourceLayer: string,
            ?SourceAttribution: string,
            ?Type: StyleParam.MapboxLayerType,
            ?Coordinates: seq<#IConvertible * #IConvertible>,
            ?Below: string,
            ?Color: Color,
            ?Opacity: float,
            ?MinZoom: float,
            ?MaxZoom: float,
            ?CircleRadius: float,
            ?Line: Line,
            ?FillOutlineColor: Color,
            ?Symbol: MapboxLayerSymbol,
            ?Name: string
        ) =
        fun (mapBoxLayer: MapboxLayer) ->

            let circle =
                CircleRadius
                |> Option.map (fun r ->
                    DynamicObj() |> DynObj.withProperty "radius" r
                )

            let fill =
                FillOutlineColor
                |> Option.map (fun c ->
                    DynamicObj() |> DynObj.withProperty "outlinecolor" c
                )

            mapBoxLayer
            |> DynObj.withOptionalProperty   "visible"           Visible           
            |> DynObj.withOptionalPropertyBy "sourcetype"        SourceType        StyleParam.MapboxLayerSourceType.convert
            |> DynObj.withOptionalProperty   "source"            Source            
            |> DynObj.withOptionalProperty   "sourcelayer"       SourceLayer       
            |> DynObj.withOptionalProperty   "sourceattribution" SourceAttribution 
            |> DynObj.withOptionalPropertyBy "type"              Type              StyleParam.MapboxLayerType.convert
            |> DynObj.withOptionalProperty   "coordinates"       Coordinates       
            |> DynObj.withOptionalProperty   "below"             Below             
            |> DynObj.withOptionalProperty   "color"             Color             
            |> DynObj.withOptionalProperty   "opacity"           Opacity           
            |> DynObj.withOptionalProperty   "minzoom"           MinZoom           
            |> DynObj.withOptionalProperty   "maxzoom"           MaxZoom           
            |> DynObj.withOptionalProperty   "circle"            circle            
            |> DynObj.withOptionalProperty   "line"              Line              
            |> DynObj.withOptionalProperty   "fill"              fill              
            |> DynObj.withOptionalProperty   "symbol"            Symbol            
            |> DynObj.withOptionalProperty   "name"              Name              
