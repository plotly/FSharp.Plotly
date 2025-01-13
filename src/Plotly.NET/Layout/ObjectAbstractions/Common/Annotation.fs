namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

/// Text annotations inside a plot
type Annotation() =
    inherit DynamicObj()

    /// Init Annotation type
    static member init
        (
            ?X: #IConvertible,
            ?Y: #IConvertible,
            ?Align: StyleParam.AnnotationAlignment,
            ?ArrowColor: Color,
            ?ArrowHead: StyleParam.ArrowHead,
            ?ArrowSide: StyleParam.ArrowSide,
            ?ArrowSize: float,
            ?AX: #IConvertible,
            ?AXRef: #IConvertible,
            ?AY: #IConvertible,
            ?AYRef: #IConvertible,
            ?BGColor: Color,
            ?BorderColor: Color,
            ?BorderPad: int,
            ?BorderWidth: int,
            ?CaptureEvents: bool,
            ?ClickToShow: StyleParam.ClickToShow,
            ?Font: Font,
            ?Height: int,
            ?HoverLabel: Hoverlabel,
            ?HoverText: string,
            ?Name: string,
            ?Opacity: float,
            ?ShowArrow: bool,
            ?StandOff: int,
            ?StartArrowHead: int,
            ?StartArrowSize: float,
            ?StartStandOff: int,
            ?TemplateItemName: string,
            ?Text: string,
            ?TextAngle: float,
            ?VAlign: StyleParam.VerticalAlign,
            ?Visible: bool,
            ?Width: int,
            ?XAnchor: StyleParam.XAnchorPosition,
            ?XClick: #IConvertible,
            ?XRef: #IConvertible,
            ?XShift: int,
            ?YAnchor: StyleParam.YAnchorPosition,
            ?YClick: #IConvertible,
            ?YRef: #IConvertible,
            ?YShift: int
        ) =
        Annotation()
        |> Annotation.style (
            ?Align = Align,
            ?ArrowColor = ArrowColor,
            ?ArrowHead = ArrowHead,
            ?ArrowSide = ArrowSide,
            ?ArrowSize = ArrowSize,
            ?AX = AX,
            ?AXRef = AXRef,
            ?AY = AY,
            ?AYRef = AYRef,
            ?BGColor = BGColor,
            ?BorderColor = BorderColor,
            ?BorderPad = BorderPad,
            ?BorderWidth = BorderWidth,
            ?CaptureEvents = CaptureEvents,
            ?ClickToShow = ClickToShow,
            ?Font = Font,
            ?Height = Height,
            ?HoverLabel = HoverLabel,
            ?HoverText = HoverText,
            ?Name = Name,
            ?Opacity = Opacity,
            ?ShowArrow = ShowArrow,
            ?StandOff = StandOff,
            ?StartArrowHead = StartArrowHead,
            ?StartArrowSize = StartArrowSize,
            ?StartStandOff = StartStandOff,
            ?TemplateItemName = TemplateItemName,
            ?Text = Text,
            ?TextAngle = TextAngle,
            ?VAlign = VAlign,
            ?Visible = Visible,
            ?Width = Width,
            ?X = X,
            ?XAnchor = XAnchor,
            ?XClick = XClick,
            ?XRef = XRef,
            ?XShift = XShift,
            ?Y = Y,
            ?YAnchor = YAnchor,
            ?YClick = YClick,
            ?YRef = YRef,
            ?YShift = YShift
        )

    static member style
        (
            ?X: #IConvertible,
            ?Y: #IConvertible,
            ?Align: StyleParam.AnnotationAlignment,
            ?ArrowColor: Color,
            ?ArrowHead: StyleParam.ArrowHead,
            ?ArrowSide: StyleParam.ArrowSide,
            ?ArrowSize: float,
            ?AX: #IConvertible,
            ?AXRef: #IConvertible,
            ?AY: #IConvertible,
            ?AYRef: #IConvertible,
            ?BGColor: Color,
            ?BorderColor: Color,
            ?BorderPad: int,
            ?BorderWidth: int,
            ?CaptureEvents: bool,
            ?ClickToShow: StyleParam.ClickToShow,
            ?Font: Font,
            ?Height: int,
            ?HoverLabel: Hoverlabel,
            ?HoverText: string,
            ?Name: string,
            ?Opacity: float,
            ?ShowArrow: bool,
            ?StandOff: int,
            ?StartArrowHead: int,
            ?StartArrowSize: float,
            ?StartStandOff: int,
            ?TemplateItemName: string,
            ?Text: string,
            ?TextAngle: float,
            ?VAlign: StyleParam.VerticalAlign,
            ?Visible: bool,
            ?Width: int,
            ?XAnchor: StyleParam.XAnchorPosition,
            ?XClick: #IConvertible,
            ?XRef: #IConvertible,
            ?XShift: int,
            ?YAnchor: StyleParam.YAnchorPosition,
            ?YClick: #IConvertible,
            ?YRef: #IConvertible,
            ?YShift: int
        ) =
        (fun (ann: Annotation) ->

            ann
            |> DynObj.withOptionalProperty "x" X
            |> DynObj.withOptionalProperty "y" Y
            |> DynObj.withOptionalPropertyBy "align" Align StyleParam.AnnotationAlignment.convert
            |> DynObj.withOptionalProperty "arrowcolor" ArrowColor
            |> DynObj.withOptionalPropertyBy "arrowhead" ArrowHead StyleParam.ArrowHead.convert
            |> DynObj.withOptionalPropertyBy "arrowside" ArrowSide StyleParam.ArrowSide.convert
            |> DynObj.withOptionalProperty "arrowsize" ArrowSize
            |> DynObj.withOptionalProperty "ax" AX
            |> DynObj.withOptionalProperty "axref" AXRef
            |> DynObj.withOptionalProperty "ay" AY
            |> DynObj.withOptionalProperty "ayref" AYRef
            |> DynObj.withOptionalProperty "bgcolor" BGColor
            |> DynObj.withOptionalProperty "bordercolor" BorderColor
            |> DynObj.withOptionalProperty "borderpad" BorderPad
            |> DynObj.withOptionalProperty "borderwidth" BorderWidth
            |> DynObj.withOptionalProperty "captureevents" CaptureEvents
            |> DynObj.withOptionalPropertyBy "clicktoshow" ClickToShow StyleParam.ClickToShow.convert
            |> DynObj.withOptionalProperty "font" Font
            |> DynObj.withOptionalProperty "height" Height
            |> DynObj.withOptionalProperty "hoverlabel" HoverLabel
            |> DynObj.withOptionalProperty "hovertext" HoverText
            |> DynObj.withOptionalProperty "name" Name
            |> DynObj.withOptionalProperty "opacity" Opacity
            |> DynObj.withOptionalProperty "showarrow" ShowArrow
            |> DynObj.withOptionalProperty "standoff" StandOff
            |> DynObj.withOptionalProperty "startarrowhead" StartArrowHead
            |> DynObj.withOptionalProperty "startarrowsize" StartArrowSize
            |> DynObj.withOptionalProperty "startstandoff" StartStandOff
            |> DynObj.withOptionalProperty "templateitemname" TemplateItemName
            |> DynObj.withOptionalProperty "text" Text
            |> DynObj.withOptionalProperty "textangle" TextAngle
            |> DynObj.withOptionalPropertyBy "valign" VAlign StyleParam.VerticalAlign.convert
            |> DynObj.withOptionalProperty "visible" Visible
            |> DynObj.withOptionalProperty "width" Width
            |> DynObj.withOptionalPropertyBy "xanchor" XAnchor StyleParam.XAnchorPosition.convert
            |> DynObj.withOptionalProperty "xclick" XClick
            |> DynObj.withOptionalProperty "xref" XRef
            |> DynObj.withOptionalProperty "xshift" XShift
            |> DynObj.withOptionalPropertyBy "yanchor" YAnchor StyleParam.YAnchorPosition.convert
            |> DynObj.withOptionalProperty "yclick" YClick
            |> DynObj.withOptionalProperty "yref" YRef
            |> DynObj.withOptionalProperty "yshift" YShift
        )
