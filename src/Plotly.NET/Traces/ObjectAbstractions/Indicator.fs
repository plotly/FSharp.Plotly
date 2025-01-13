namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices


type IndicatorSymbol() =
    inherit DynamicObj()

    static member init
        (
            ?Color: Color,
            ?Symbol: string
        ) =
        IndicatorSymbol() |> IndicatorSymbol.style (?Color = Color, ?Symbol = Symbol)

    static member style
        (
            ?Color: Color,
            ?Symbol: string
        ) =
        fun (indicatorDirection: IndicatorSymbol) ->

            indicatorDirection
            |> DynObj.withOptionalProperty "color" Color
            |> DynObj.withOptionalProperty "symbol" Symbol

type IndicatorDelta() =
    inherit DynamicObj()

    /// <summary>
    /// Returns a new IndicatorDelta object with the given styles
    /// </summary>
    /// <param name="Decreasing">Sets the style of decreasing deltas.</param>
    /// <param name="Font">Set the font used to display the delta</param>
    /// <param name="Increasing">Sets the style of increasing deltas.</param>
    /// <param name="Position">Sets the position of delta with respect to the number.</param>
    /// <param name="Prefix">Sets a prefix appearing before the delta.</param>
    /// <param name="Reference">Sets the reference value to compute the delta. By default, it is set to the current value.</param>
    /// <param name="Relative">Show relative change</param>
    /// <param name="Suffix">Sets a suffix appearing next to the delta.</param>
    /// <param name="ValueFormat">Sets the value formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.</param>
    static member init
        (
            ?Decreasing: IndicatorSymbol,
            ?Font: Font,
            ?Increasing: IndicatorSymbol,
            ?Position: StyleParam.IndicatorDeltaPosition,
            ?Prefix: string,
            ?Reference: #IConvertible,
            ?Relative: bool,
            ?Suffix: string,
            ?ValueFormat: string
        ) =
        IndicatorDelta()
        |> IndicatorDelta.style (
            ?Decreasing = Decreasing,
            ?Font = Font,
            ?Increasing = Increasing,
            ?Position = Position,
            ?Prefix = Prefix,
            ?Reference = Reference,
            ?Relative = Relative,
            ?Suffix = Suffix,
            ?ValueFormat = ValueFormat
        )

    /// <summary>
    /// Returns a function that applies the given styles to an IndicatorDelta object
    /// </summary>
    /// <param name="Decreasing">Sets the style of decreasing deltas.</param>
    /// <param name="Font">Set the font used to display the delta</param>
    /// <param name="Increasing">Sets the style of increasing deltas.</param>
    /// <param name="Position">Sets the position of delta with respect to the number.</param>
    /// <param name="Prefix">Sets a prefix appearing before the delta.</param>
    /// <param name="Reference">Sets the reference value to compute the delta. By default, it is set to the current value.</param>
    /// <param name="Relative">Show relative change</param>
    /// <param name="Suffix">Sets a suffix appearing next to the delta.</param>
    /// <param name="ValueFormat">Sets the value formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.</param>
    static member style
        (
            ?Decreasing: IndicatorSymbol,
            ?Font: Font,
            ?Increasing: IndicatorSymbol,
            ?Position: StyleParam.IndicatorDeltaPosition,
            ?Prefix: string,
            ?Reference: #IConvertible,
            ?Relative: bool,
            ?Suffix: string,
            ?ValueFormat: string
        ) =
        fun (indicatorDelta: IndicatorDelta) ->

            indicatorDelta
            |> DynObj.withOptionalProperty "decreasing" Decreasing
            |> DynObj.withOptionalProperty "font" Font
            |> DynObj.withOptionalProperty "increasing" Increasing
            |> DynObj.withOptionalPropertyBy "position" Position StyleParam.IndicatorDeltaPosition.convert
            |> DynObj.withOptionalProperty "prefix" Prefix
            |> DynObj.withOptionalProperty "reference" Reference
            |> DynObj.withOptionalProperty "relative" Relative
            |> DynObj.withOptionalProperty "suffix" Suffix
            |> DynObj.withOptionalProperty "valueformat" ValueFormat

type IndicatorNumber() =
    inherit DynamicObj()

    static member init
        (
            ?Font: Font,
            ?Prefix: string,
            ?Suffix: string,
            ?ValueFormat: string
        ) =
        IndicatorNumber()
        |> IndicatorNumber.style (?Font = Font, ?Prefix = Prefix, ?Suffix = Suffix, ?ValueFormat = ValueFormat)

    static member style
        (
            ?Font: Font,
            ?Prefix: string,
            ?Suffix: string,
            ?ValueFormat: string
        ) =
        fun (indicatorNumber: IndicatorNumber) ->

            indicatorNumber
            |> DynObj.withOptionalProperty "font" Font
            |> DynObj.withOptionalProperty "prefix" Prefix
            |> DynObj.withOptionalProperty "suffix" Suffix
            |> DynObj.withOptionalProperty "valueformat" ValueFormat


type IndicatorBar() =
    inherit DynamicObj()

    static member init
        (
            ?Color: Color,
            ?Line: Line,
            ?Thickness: float
        ) =
        IndicatorBar() |> IndicatorBar.style (?Color = Color, ?Line = Line, ?Thickness = Thickness)

    static member style
        (
            ?Color: Color,
            ?Line: Line,
            ?Thickness: float
        ) =
        fun (indicatorBar: IndicatorBar) ->
            indicatorBar
            |> DynObj.withOptionalProperty "color" Color
            |> DynObj.withOptionalProperty "line" Line
            |> DynObj.withOptionalProperty "thickness" Thickness
            

type IndicatorStep() =
    inherit DynamicObj()

    static member init
        (
            ?Color: Color,
            ?Line: Line,
            ?Name: string,
            ?Range: StyleParam.Range,
            ?TemplateItemName: string,
            ?Thickness: float
        ) =
        IndicatorStep()
        |> IndicatorStep.style (
            ?Color = Color,
            ?Line = Line,
            ?Name = Name,
            ?Range = Range,
            ?TemplateItemName = TemplateItemName,
            ?Thickness = Thickness
        )

    static member style
        (
            ?Color: Color,
            ?Line: Line,
            ?Name: string,
            ?Range: StyleParam.Range,
            ?TemplateItemName: string,
            ?Thickness: float
        ) =
        fun (indicatorSteps: IndicatorStep) ->

            indicatorSteps
            |> DynObj.withOptionalProperty "color" Color
            |> DynObj.withOptionalProperty "line" Line
            |> DynObj.withOptionalProperty "name" Name
            |> DynObj.withOptionalPropertyBy "range" Range StyleParam.Range.convert
            |> DynObj.withOptionalProperty "templateitemname" TemplateItemName
            |> DynObj.withOptionalProperty "thickness" Thickness


type IndicatorThreshold() =
    inherit DynamicObj()

    static member init
        (
            ?Line: Line,
            ?Thickness: float,
            ?Value: #IConvertible
        ) =
        IndicatorThreshold() |> IndicatorThreshold.style (?Line = Line, ?Thickness = Thickness, ?Value = Value)

    static member style
        (
            ?Line: Line,
            ?Thickness: float,
            ?Value: #IConvertible
        ) =
        fun (indicatorThreshold: IndicatorThreshold) ->

            indicatorThreshold
            |> DynObj.withOptionalProperty "line" Line
            |> DynObj.withOptionalProperty "thickness" Thickness
            |> DynObj.withOptionalProperty "value" Value


type IndicatorGauge() =
    inherit DynamicObj()

    static member init
        (
            ?Axis: LinearAxis,
            ?Bar: IndicatorBar,
            ?BGColor: Color,
            ?BorderColor: Color,
            ?BorderWidth: int,
            ?Shape: StyleParam.IndicatorGaugeShape,
            ?Steps: seq<IndicatorStep>,
            ?Threshold: IndicatorThreshold
        ) =
        IndicatorGauge()
        |> IndicatorGauge.style (
            ?Axis = Axis,
            ?Bar = Bar,
            ?BGColor = BGColor,
            ?BorderColor = BorderColor,
            ?BorderWidth = BorderWidth,
            ?Shape = Shape,
            ?Steps = Steps,
            ?Threshold = Threshold
        )

    static member style
        (
            ?Axis: LinearAxis,
            ?Bar: IndicatorBar,
            ?BGColor: Color,
            ?BorderColor: Color,
            ?BorderWidth: int,
            ?Shape: StyleParam.IndicatorGaugeShape,
            ?Steps: seq<IndicatorStep>,
            ?Threshold: IndicatorThreshold
        ) =
        fun (indicatorGauge: IndicatorGauge) ->

            indicatorGauge
            |> DynObj.withOptionalProperty "axis" Axis
            |> DynObj.withOptionalProperty "bar" Bar
            |> DynObj.withOptionalProperty "bgcolor" BGColor
            |> DynObj.withOptionalProperty "bordercolor" BorderColor
            |> DynObj.withOptionalProperty "borderwidth" BorderWidth
            |> DynObj.withOptionalPropertyBy "shape" Shape StyleParam.IndicatorGaugeShape.convert
            |> DynObj.withOptionalProperty "steps" Steps
            |> DynObj.withOptionalProperty "threshold" Threshold
