namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

type NewShape() =
    inherit DynamicObj()

    /// <summary>
    /// Returns Some(dynamic member value) of the NewShape object's underlying DynamicObj when a dynamic member with the given name exists, and None otherwise.
    /// </summary>
    /// <param name="propName">The name of the dynamic member to get the value of</param>
    /// <param name="newShape">The NewShape to get the dynamic member value from</param>
    static member tryGetTypedMember<'T> (propName: string) (newShape:NewShape) = newShape.TryGetTypedPropertyValue<'T>(propName)

    /// <summary>
    /// Returns the Legend anchor of the given NewShape.
    ///
    /// If there is no Legend set, returns "legend".
    /// </summary>
    /// <param name="newShape">The NewShape to get the Legend anchor from</param>
    static member getLegendAnchor(newShape: NewShape) =
        let idString =
            newShape |> NewShape.tryGetTypedMember<string> ("legend") |> Option.defaultValue "legend"

        if idString = "legend" then
            StyleParam.SubPlotId.Legend 1
        else
            StyleParam.SubPlotId.Legend(idString.Replace("legend", "") |> int)

    /// <summary>
    /// Returns a function that sets the Legend anchor of the given NewShape.
    /// </summary>
    /// <param name="legendId">The new Legend anchor</param>
    static member setLegendAnchor(legendId: int) =
        let id =
            StyleParam.SubPlotId.Legend legendId

        (fun (newShape: NewShape) -> newShape |> DynObj.withProperty "legend" (StyleParam.SubPlotId.convert id))

    /// <summary>
    /// Returns a new NewShape object with the given styling.
    /// </summary>
    /// <param name="DrawDirection">When `dragmode` is set to "drawrect", "drawline" or "drawcircle" this limits the drag to be horizontal, vertical or diagonal. Using "diagonal" there is no limit e.g. in drawing lines in any direction. "ortho" limits the draw to be either horizontal or vertical. "horizontal" allows horizontal extend. "vertical" allows vertical extend.</param>
    /// <param name="FillColor">Sets the color filling new shapes' interior. Please note that if using a fillcolor with alpha greater than half, drag inside the active shape starts moving the shape underneath, otherwise a new shape could be started over.</param>
    /// <param name="FillRule">Determines the path's interior. For more info please visit https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/fill-rule</param>
    /// <param name="Layer">Specifies whether new shapes are drawn below or above traces.</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this shape is shown in the legend.</param>
    /// <param name="Legend">Sets the reference to a legend to show this shape in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this shape. Items and groups with smaller ranks are presented on top/left side while with "reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items. When having unranked or equal rank items shapes would be displayed after traces i.e. according to their order in data and layout.</param>
    /// <param name="LegendGroup">Sets the legend group for this shape. Traces and shapes part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this shape.</param>
    /// <param name="LegendWidth">Sets the width (in px or fraction) of the legend for this shape.</param>
    /// <param name="Line">Sets the outline of new shapes.</param>
    /// <param name="Name">Sets new shape name. The name appears as the legend item.</param> 
    /// <param name="Opacity">Sets the opacity of new shapes.</param>
    /// <param name="Visible">Determines whether or not new shape is visible. If "legendonly", the shape is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    static member init
        (
            ?DrawDirection: StyleParam.DrawDirection,
            ?FillColor: Color,
            ?FillRule: StyleParam.FillRule,
            ?Layer: StyleParam.Layer,
            ?ShowLegend: bool,
            ?Legend: StyleParam.SubPlotId,
            ?LegendRank: int,
            ?LegendGroup: string,
            ?LegendGroupTitle: Title,
            ?LegendWidth: float,
            ?Line: Line,
            ?Name: string,
            ?Opacity: float,
            ?Visible: StyleParam.Visible
        ) =
        NewShape()
        |> NewShape.style (
            ?DrawDirection = DrawDirection,
            ?FillColor = FillColor,
            ?FillRule = FillRule,
            ?Layer = Layer,
            ?ShowLegend = ShowLegend,
            ?Legend = Legend,
            ?LegendRank = LegendRank,
            ?LegendGroup = LegendGroup,
            ?LegendGroupTitle = LegendGroupTitle,
            ?LegendWidth = LegendWidth,
            ?Line = Line,
            ?Name = Name,
            ?Opacity = Opacity,
            ?Visible = Visible
        )

    /// <summary>
    /// Returns a function that applies the given styles to a NewShape object
    /// </summary>
    /// <param name="DrawDirection">When `dragmode` is set to "drawrect", "drawline" or "drawcircle" this limits the drag to be horizontal, vertical or diagonal. Using "diagonal" there is no limit e.g. in drawing lines in any direction. "ortho" limits the draw to be either horizontal or vertical. "horizontal" allows horizontal extend. "vertical" allows vertical extend.</param>
    /// <param name="FillColor">Sets the color filling new shapes' interior. Please note that if using a fillcolor with alpha greater than half, drag inside the active shape starts moving the shape underneath, otherwise a new shape could be started over.</param>
    /// <param name="FillRule">Determines the path's interior. For more info please visit https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/fill-rule</param>
    /// <param name="Layer">Specifies whether new shapes are drawn below or above traces.</param>
    /// <param name="ShowLegend">Determines whether or not an item corresponding to this shape is shown in the legend.</param>
    /// <param name="Legend">Sets the reference to a legend to show this shape in. References to these legends are "legend", "legend2", "legend3", etc. Settings for these legends are set in the layout, under `layout.legend`, `layout.legend2`, etc.</param>
    /// <param name="LegendRank">Sets the legend rank for this shape. Items and groups with smaller ranks are presented on top/left side while with "reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items. When having unranked or equal rank items shapes would be displayed after traces i.e. according to their order in data and layout.</param>
    /// <param name="LegendGroup">Sets the legend group for this shape. Traces and shapes part of the same legend group hide/show at the same time when toggling legend items.</param>
    /// <param name="LegendGroupTitle">Sets the legend group title for this shape.</param>
    /// <param name="LegendWidth">Sets the width (in px or fraction) of the legend for this shape.</param>
    /// <param name="Line">Sets the outline of new shapes.</param>
    /// <param name="Name">Sets new shape name. The name appears as the legend item.</param> 
    /// <param name="Opacity">Sets the opacity of new shapes.</param>
    /// <param name="Visible">Determines whether or not new shape is visible. If "legendonly", the shape is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
    static member style
        (
            ?DrawDirection: StyleParam.DrawDirection,
            ?FillColor: Color,
            ?FillRule: StyleParam.FillRule,
            ?Layer: StyleParam.Layer,
            ?ShowLegend: bool,
            ?Legend: StyleParam.SubPlotId,
            ?LegendRank: int,
            ?LegendGroup: string,
            ?LegendGroupTitle: Title,
            ?LegendWidth: float,
            ?Line: Line,
            ?Name: string,
            ?Opacity: float,
            ?Visible: StyleParam.Visible
        ) =
        (fun (newShape: NewShape) ->

            newShape
            |> DynObj.withOptionalPropertyBy "drawdirection" DrawDirection StyleParam.DrawDirection.convert
            |> DynObj.withOptionalProperty "fillcolor" FillColor
            |> DynObj.withOptionalPropertyBy "fillrule" FillRule StyleParam.FillRule.convert
            |> DynObj.withOptionalPropertyBy "layer" Layer StyleParam.Layer.convert
            |> DynObj.withOptionalProperty "showlegend" ShowLegend
            |> DynObj.withOptionalPropertyBy "legend" Legend StyleParam.SubPlotId.convert
            |> DynObj.withOptionalProperty "legendrank" LegendRank
            |> DynObj.withOptionalProperty "legendgroup" LegendGroup
            |> DynObj.withOptionalProperty "legendgrouptitle" LegendGroupTitle
            |> DynObj.withOptionalProperty "legendwidth" LegendWidth
            |> DynObj.withOptionalProperty "line" Line
            |> DynObj.withOptionalProperty "name" Name
            |> DynObj.withOptionalProperty "opacity" Opacity
            |> DynObj.withOptionalPropertyBy "visible" Visible StyleParam.Visible.convert
        )
