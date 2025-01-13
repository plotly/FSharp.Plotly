namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices


/// Dimensions type inherits from dynamic object
type RangeSelector() =
    inherit DynamicObj()

    static member init
        (
            ?Visible: bool,
            ?Buttons: seq<Button>,
            ?X: float,
            ?XAnchor: StyleParam.XAnchorPosition,
            ?Y: float,
            ?YAnchor: StyleParam.YAnchorPosition,
            ?Font: Font,
            ?BGColor: Color,
            ?ActiveColor: Color,
            ?BorderColor: Color,
            ?BorderWidth: int
        ) =
        RangeSelector()
        |> RangeSelector.style (
            ?Visible = Visible,
            ?Buttons = Buttons,
            ?X = X,
            ?XAnchor = XAnchor,
            ?Y = Y,
            ?YAnchor = YAnchor,
            ?Font = Font,
            ?BGColor = BGColor,
            ?ActiveColor = ActiveColor,
            ?BorderColor = BorderColor,
            ?BorderWidth = BorderWidth
        )

    static member style
        (
            ?Visible: bool,
            ?Buttons: seq<Button>,
            ?X: float,
            ?XAnchor: StyleParam.XAnchorPosition,
            ?Y: float,
            ?YAnchor: StyleParam.YAnchorPosition,
            ?Font: Font,
            ?BGColor: Color,
            ?ActiveColor: Color,
            ?BorderColor: Color,
            ?BorderWidth: int
        ) =
        (fun (rangeSelector: RangeSelector) ->

            rangeSelector
            |> DynObj.withOptionalProperty "visible" Visible
            |> DynObj.withOptionalProperty "buttons" Buttons
            |> DynObj.withOptionalProperty "x" X
            |> DynObj.withOptionalPropertyBy "xanchor" XAnchor StyleParam.XAnchorPosition.convert
            |> DynObj.withOptionalProperty "y" Y
            |> DynObj.withOptionalPropertyBy "yanchor" YAnchor StyleParam.YAnchorPosition.convert
            |> DynObj.withOptionalProperty "font" Font
            |> DynObj.withOptionalProperty "bgcolor" BGColor
            |> DynObj.withOptionalProperty "activecolor" ActiveColor
            |> DynObj.withOptionalProperty "bordercolor" BorderColor
            |> DynObj.withOptionalProperty "borderwidth" BorderWidth
        )
