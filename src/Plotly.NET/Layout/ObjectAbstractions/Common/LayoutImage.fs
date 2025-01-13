namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

/// Dimensions type inherits from dynamic object
type LayoutImage() =
    inherit DynamicObj()

    static member init
        (
            ?Layer: StyleParam.Layer,
            ?Name: string,
            ?Opacity: float,
            ?SizeX: int,
            ?SizeY: int,
            ?Sizing: StyleParam.LayoutImageSizing,
            ?Source: string,
            ?TemplateItemname: string,
            ?Visible: bool,
            ?X: #IConvertible,
            ?XAnchor: StyleParam.XAnchorPosition,
            ?XRef: string,
            ?Y: #IConvertible,
            ?YAnchor: StyleParam.YAnchorPosition,
            ?YRef: string
        ) =
        LayoutImage()
        |> LayoutImage.style (
            ?Layer = Layer,
            ?Name = Name,
            ?Opacity = Opacity,
            ?SizeX = SizeX,
            ?SizeY = SizeY,
            ?Sizing = Sizing,
            ?Source = Source,
            ?TemplateItemname = TemplateItemname,
            ?Visible = Visible,
            ?X = X,
            ?XAnchor = XAnchor,
            ?XRef = XRef,
            ?Y = Y,
            ?YAnchor = YAnchor,
            ?YRef = YRef
        )

    static member style
        (
            ?Layer: StyleParam.Layer,
            ?Name: string,
            ?Opacity: float,
            ?SizeX: int,
            ?SizeY: int,
            ?Sizing: StyleParam.LayoutImageSizing,
            ?Source: string,
            ?TemplateItemname: string,
            ?Visible: bool,
            ?X: #IConvertible,
            ?XAnchor: StyleParam.XAnchorPosition,
            ?XRef: string,
            ?Y: #IConvertible,
            ?YAnchor: StyleParam.YAnchorPosition,
            ?YRef: string
        ) =
        (fun (layoutImage: LayoutImage) ->
            layoutImage
            |> DynObj.withOptionalPropertyBy "layer" Layer StyleParam.Layer.convert
            |> DynObj.withOptionalProperty "name" Name
            |> DynObj.withOptionalProperty "opacity" Opacity
            |> DynObj.withOptionalProperty "sizex" SizeX
            |> DynObj.withOptionalProperty "sizey" SizeY
            |> DynObj.withOptionalPropertyBy "sizing" Sizing StyleParam.LayoutImageSizing.convert
            |> DynObj.withOptionalProperty "source" Source
            |> DynObj.withOptionalProperty "templateitemname" TemplateItemname
            |> DynObj.withOptionalProperty "visible" Visible
            |> DynObj.withOptionalProperty "x" X
            |> DynObj.withOptionalPropertyBy "xanchor" XAnchor StyleParam.XAnchorPosition.convert
            |> DynObj.withOptionalProperty "xref" XRef
            |> DynObj.withOptionalProperty "y" Y
            |> DynObj.withOptionalPropertyBy "yanchor" YAnchor StyleParam.YAnchorPosition.convert
            |> DynObj.withOptionalProperty "yref" YRef
        )
