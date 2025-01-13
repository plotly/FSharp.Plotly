namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

//rangeslider
//Parent: layout.xaxis
//Type: object containing one or more of the keys listed below.
type RangeSlider() =
    inherit DynamicObj()

    static member init
        (
            ?BgColor: Color,
            ?BorderColor: Color,
            ?BorderWidth: float,
            ?AutoRange: bool,
            ?Range: StyleParam.Range,
            ?Thickness: float,
            ?Visible: bool,
            ?YAxisRangeMode: StyleParam.RangesliderRangeMode,
            ?YAxisRange: StyleParam.Range
        ) =
        RangeSlider()
        |> RangeSlider.style (
            ?BgColor = BgColor,
            ?BorderColor = BorderColor,
            ?BorderWidth = BorderWidth,
            ?AutoRange = AutoRange,
            ?Range = Range,
            ?Thickness = Thickness,
            ?Visible = Visible,
            ?YAxisRangeMode = YAxisRangeMode,
            ?YAxisRange = YAxisRange
        )


    static member style
        (
            ?BgColor: Color,
            ?BorderColor: Color,
            ?BorderWidth: float,
            ?AutoRange: bool,
            ?Range: StyleParam.Range,
            ?Thickness: float,
            ?Visible: bool,
            ?YAxisRangeMode: StyleParam.RangesliderRangeMode,
            ?YAxisRange: StyleParam.Range
        ) =
        fun (rangeslider: RangeSlider) ->

            let yAxis =
                DynamicObj()
                |> DynObj.withOptionalPropertyBy "rangemode" YAxisRangeMode StyleParam.RangesliderRangeMode.convert
                |> DynObj.withOptionalPropertyBy "range" YAxisRange StyleParam.Range.convert

            rangeslider
            |> DynObj.withOptionalProperty "bgcolor" BgColor
            |> DynObj.withOptionalProperty "bordercolor" BorderColor
            |> DynObj.withOptionalProperty "borderwidth" BorderWidth
            |> DynObj.withOptionalProperty "autorange" AutoRange
            |> DynObj.withOptionalPropertyBy "range" Range StyleParam.Range.convert
            |> DynObj.withOptionalProperty "thickness" Thickness
            |> DynObj.withOptionalProperty "visible" Visible
            |> DynObj.withProperty "yaxis" yAxis

