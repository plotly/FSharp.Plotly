namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type SankeyNodes() =
    inherit DynamicObj()

    static member init
        (
            ?Color: Color,
            ?CustomData: seq<#IConvertible>,
            ?Groups: seq<#seq<int>>,
            ?HoverInfo: StyleParam.HoverInfo,
            ?HoverLabel: Hoverlabel,
            ?HoverTemplate: string,
            ?MultiHoverTemplate: seq<string>,
            ?Label: seq<string>,
            ?Line: Line,
            ?Pad: int,
            ?Thickness: int,
            ?X: seq<#IConvertible>,
            ?Y: seq<#IConvertible>
        ) =

        SankeyNodes()
        |> SankeyNodes.style (
            ?Color = Color,
            ?CustomData = CustomData,
            ?Groups = Groups,
            ?HoverInfo = HoverInfo,
            ?HoverLabel = HoverLabel,
            ?HoverTemplate = HoverTemplate,
            ?MultiHoverTemplate = MultiHoverTemplate,
            ?Label = Label,
            ?Line = Line,
            ?Pad = Pad,
            ?Thickness = Thickness,
            ?X = X,
            ?Y = Y

        )

    static member style
        (
            ?Color: Color,
            ?CustomData: seq<#IConvertible>,
            ?Groups: seq<#seq<int>>,
            ?HoverInfo: StyleParam.HoverInfo,
            ?HoverLabel: Hoverlabel,
            ?HoverTemplate: string,
            ?MultiHoverTemplate: seq<string>,
            ?Label: seq<string>,
            ?Line: Line,
            ?Pad: int,
            ?Thickness: int,
            ?X: seq<#IConvertible>,
            ?Y: seq<#IConvertible>
        ) =
        fun (sankeyNodes: SankeyNodes) ->
            sankeyNodes
            |> DynObj.withOptionalProperty "color" Color
            |> DynObj.withOptionalProperty "customdata" CustomData
            |> DynObj.withOptionalProperty "groups" Groups
            |> DynObj.withOptionalPropertyBy "hoverinfo" HoverInfo StyleParam.HoverInfo.convert
            |> DynObj.withOptionalProperty "hoverlabel" HoverLabel
            |> DynObj.withOptionalSingleOrMultiProperty "hovertemplate" (HoverTemplate, MultiHoverTemplate)
            |> DynObj.withOptionalProperty "label" Label
            |> DynObj.withOptionalProperty "line" Line
            |> DynObj.withOptionalProperty "pad" Pad
            |> DynObj.withOptionalProperty "thickness" Thickness
            |> DynObj.withOptionalProperty "x" X
            |> DynObj.withOptionalProperty "y" Y

type SankeyLinkColorscale() =
    inherit DynamicObj()

    static member init
        (
            ?CMax: float,
            ?CMin: float,
            ?ColorScale: StyleParam.Colorscale,
            ?Label: string,
            ?Name: string,
            ?TemplateItemName: string
        ) =

        SankeyLinkColorscale()
        |> SankeyLinkColorscale.style (
            ?CMax = CMax,
            ?CMin = CMin,
            ?ColorScale = ColorScale,
            ?Label = Label,
            ?Name = Name,
            ?TemplateItemName = TemplateItemName

        )

    static member style
        (
            ?CMax: float,
            ?CMin: float,
            ?ColorScale: StyleParam.Colorscale,
            ?Label: string,
            ?Name: string,
            ?TemplateItemName: string
        ) =
        fun (sankeyLinkColorscale: SankeyLinkColorscale) ->

            sankeyLinkColorscale
            |> DynObj.withOptionalProperty "cmax" CMax
            |> DynObj.withOptionalProperty "cmin" CMin
            |> DynObj.withOptionalPropertyBy "colorscale" ColorScale StyleParam.Colorscale.convert
            |> DynObj.withOptionalProperty "label" Label
            |> DynObj.withOptionalProperty "name" Name
            |> DynObj.withOptionalProperty "templateitemname" TemplateItemName

type SankeyLinks() =
    inherit DynamicObj()

    static member init
        (
            ?ArrowLen: int,
            ?Color: Color,
            ?ColorScales: seq<SankeyLinkColorscale>,
            ?CustomData: seq<#IConvertible>,
            ?HoverInfo: StyleParam.HoverInfo,
            ?HoverLabel: Hoverlabel,
            ?HoverTemplate: string,
            ?MultiHoverTemplate: seq<string>,
            ?Label: seq<string>,
            ?Line: Line,
            ?Source: seq<int>,
            ?Target: seq<int>,
            ?Value: seq<#IConvertible>
        ) =

        SankeyLinks()
        |> SankeyLinks.style (
            ?ArrowLen = ArrowLen,
            ?Color = Color,
            ?ColorScales = ColorScales,
            ?CustomData = CustomData,
            ?HoverInfo = HoverInfo,
            ?HoverLabel = HoverLabel,
            ?HoverTemplate = HoverTemplate,
            ?MultiHoverTemplate = MultiHoverTemplate,
            ?Label = Label,
            ?Line = Line,
            ?Source = Source,
            ?Target = Target,
            ?Value = Value

        )

    static member style
        (
            ?ArrowLen: int,
            ?Color: Color,
            ?ColorScales: seq<SankeyLinkColorscale>,
            ?CustomData: seq<#IConvertible>,
            ?HoverInfo: StyleParam.HoverInfo,
            ?HoverLabel: Hoverlabel,
            ?HoverTemplate: string,
            ?MultiHoverTemplate: seq<string>,
            ?Label: seq<string>,
            ?Line: Line,
            ?Source: seq<int>,
            ?Target: seq<int>,
            ?Value: seq<#IConvertible>
        ) =
        fun (sankeyLinks: SankeyLinks) ->

            sankeyLinks
            |> DynObj.withOptionalProperty "arrowlen" ArrowLen
            |> DynObj.withOptionalProperty "color" Color
            |> DynObj.withOptionalProperty "colorscales" ColorScales
            |> DynObj.withOptionalProperty "customdata" CustomData
            |> DynObj.withOptionalPropertyBy "hoverinfo" HoverInfo StyleParam.HoverInfo.convert
            |> DynObj.withOptionalProperty "hoverlabel" HoverLabel
            |> DynObj.withOptionalSingleOrMultiProperty "hovertemplate" (HoverTemplate, MultiHoverTemplate)
            |> DynObj.withOptionalProperty "label" Label
            |> DynObj.withOptionalProperty "line" Line
            |> DynObj.withOptionalProperty "source" Source
            |> DynObj.withOptionalProperty "target" Target
            |> DynObj.withOptionalProperty "value" Value

