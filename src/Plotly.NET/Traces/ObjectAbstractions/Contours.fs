namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type ContourProject() =
    inherit DynamicObj()

    static member init
        (
            ?X: bool,
            ?Y: bool,
            ?Z: bool
        ) =
        ContourProject() |> ContourProject.style (?X = X, ?Y = Y, ?Z = Z)

    static member style
        (
            ?X: bool,
            ?Y: bool,
            ?Z: bool
        ) =

        fun (contourProject: ContourProject) ->

            contourProject
            |> DynObj.withOptionalProperty "x" X
            |> DynObj.withOptionalProperty "y" Y
            |> DynObj.withOptionalProperty "z" Z

/// Contour object inherits from dynamic object
type Contour() =
    inherit DynamicObj()

    /// Initialized a Contour object
    static member init
        (
            ?Color: Color,
            ?End: float,
            ?Highlight: bool,
            ?HighlightColor: Color,
            ?HighlightWidth: float,
            ?Project: ContourProject,
            ?Show: bool,
            ?Size: float,
            ?Start: float,
            ?UseColorMap: bool,
            ?Width: float
        ) =
        Contour()
        |> Contour.style (
            ?Color = Color,
            ?End = End,
            ?Highlight = Highlight,
            ?HighlightColor = HighlightColor,
            ?HighlightWidth = HighlightWidth,
            ?Project = Project,
            ?Show = Show,
            ?Size = Size,
            ?Start = Start,
            ?UseColorMap = UseColorMap,
            ?Width = Width
        )


    // Applies the styles to Contours()
    static member style
        (
            ?Color: Color,
            ?End: float,
            ?Highlight: bool,
            ?HighlightColor: Color,
            ?HighlightWidth: float,
            ?Project: ContourProject,
            ?Show: bool,
            ?Size: float,
            ?Start: float,
            ?UseColorMap: bool,
            ?Width: float
        ) =

        fun (contour: Contour) ->
            contour
            |> DynObj.withOptionalProperty "color" Color
            |> DynObj.withOptionalProperty "end" End
            |> DynObj.withOptionalProperty "highlight" Highlight
            |> DynObj.withOptionalProperty "highlightcolor" HighlightColor
            |> DynObj.withOptionalProperty "highlightwidth" HighlightWidth
            |> DynObj.withOptionalProperty "project" Project
            |> DynObj.withOptionalProperty "show" Show
            |> DynObj.withOptionalProperty "size" Size
            |> DynObj.withOptionalProperty "start" Start
            |> DynObj.withOptionalProperty "usecolormap" UseColorMap
            |> DynObj.withOptionalProperty "width" Width

/// Contours type inherits from dynamic object
type Contours() =
    inherit DynamicObj()

    static member init
        (
            ?Coloring: StyleParam.ContourColoring,
            ?End: float,
            ?LabelFont: Font,
            ?LabelFormat: string,
            ?Operation: StyleParam.ConstraintOperation,
            ?ShowLabels: bool,
            ?ShowLines: bool,
            ?Size: float,
            ?Start: float,
            ?Type: StyleParam.ContourType,
            ?Value: #IConvertible
        ) =
        Contours()
        |> Contours.style (
            ?Coloring = Coloring,
            ?End = End,
            ?LabelFont = LabelFont,
            ?LabelFormat = LabelFormat,
            ?Operation = Operation,
            ?ShowLabels = ShowLabels,
            ?ShowLines = ShowLines,
            ?Size = Size,
            ?Start = Start,
            ?Type = Type,
            ?Value = Value

        )


    /// Initialized Contours object
    static member initSurface
        (
            ?X: Contour,
            ?Y: Contour,
            ?Z: Contour
        ) =
        Contours() |> Contours.style (?X = X, ?Y = Y, ?Z = Z)

    // Applies the styles to Contours()
    static member style
        (
            ?X: Contour,
            ?Y: Contour,
            ?Z: Contour,
            ?Coloring: StyleParam.ContourColoring,
            ?End: float,
            ?LabelFont: Font,
            ?LabelFormat: string,
            ?Operation: StyleParam.ConstraintOperation,
            ?ShowLabels: bool,
            ?ShowLines: bool,
            ?Size: float,
            ?Start: float,
            ?Type: StyleParam.ContourType,
            ?Value: #IConvertible
        ) =

        fun (contours: Contours) ->

            contours
            |> DynObj.withOptionalProperty "x" X
            |> DynObj.withOptionalProperty "y" Y
            |> DynObj.withOptionalProperty "z" Z
            |> DynObj.withOptionalPropertyBy "coloring" Coloring StyleParam.ContourColoring.convert
            |> DynObj.withOptionalProperty "end" End
            |> DynObj.withOptionalProperty "labelfont" LabelFont
            |> DynObj.withOptionalProperty "labelformat" LabelFormat
            |> DynObj.withOptionalPropertyBy "operation" Operation StyleParam.ConstraintOperation.convert
            |> DynObj.withOptionalProperty "showlabels" ShowLabels
            |> DynObj.withOptionalProperty "showlines" ShowLines
            |> DynObj.withOptionalProperty "size" Size
            |> DynObj.withOptionalProperty "start" Start
            |> DynObj.withOptionalPropertyBy "type" Type StyleParam.ContourType.convert
            |> DynObj.withOptionalProperty "value" Value

    // Initialized x-y-z-Contours with the same properties
    static member initXyz
        (
            ?Color: Color,
            ?End: float,
            ?Highlight: bool,
            ?HighlightColor: Color,
            ?HighlightWidth: float,
            ?Project: ContourProject,
            ?Show: bool,
            ?Size: float,
            ?Start: float,
            ?UseColorMap: bool,
            ?Width: float
        ) =
        Contours()
        |> Contours.styleXyz (
            ?Color = Color,
            ?End = End,
            ?Highlight = Highlight,
            ?HighlightColor = HighlightColor,
            ?HighlightWidth = HighlightWidth,
            ?Project = Project,
            ?Show = Show,
            ?Size = Size,
            ?Start = Start,
            ?UseColorMap = UseColorMap,
            ?Width = Width
        )

    // Applies the styles to Contours()
    static member styleXyz
        (
            ?Color: Color,
            ?End: float,
            ?Highlight: bool,
            ?HighlightColor: Color,
            ?HighlightWidth: float,
            ?Project: ContourProject,
            ?Show: bool,
            ?Size: float,
            ?Start: float,
            ?UseColorMap: bool,
            ?Width: float
        ) =

        (fun (contours: Contours) ->
            let xyzContour =
                Contour.init (
                    ?Show = Show,
                    ?Color = Color,
                    ?UseColorMap = UseColorMap,
                    ?Width = Width,
                    ?Highlight = Highlight,
                    ?HighlightColor = HighlightColor,
                    ?HighlightWidth = HighlightWidth,
                    ?Project = Project
                )

            contours |> Contours.style (X = xyzContour, Y = xyzContour, Z = xyzContour))
