namespace Plotly.NET.ConfigObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

/// The Edits object holds information about which elements of the chart are editable.
type Edits() =
    inherit DynamicObj()

    /// <summary>
    /// Returns a new Edits Object with the given styling.
    /// </summary>
    /// <param name="AnnotationPosition">Determines if the main anchor of the annotation is editable. The main anchor corresponds to the text (if no arrow) or the arrow (which drags the whole thing leaving the arrow length and direction unchanged).</param>
    /// <param name="AnnotationTail">Has only an effect for annotations with arrows. Enables changing the length and direction of the arrow.</param>
    /// <param name="AnnotationText">Enables editing annotation text.</param>
    /// <param name="AxisTitleText">Enables editing axis title text.</param>
    /// <param name="ColorbarPosition">Enables moving colorbars.</param>
    /// <param name="ColorbarTitleText">Enables moving colorbars.</param>
    /// <param name="LegendPosition">Enables moving colorbars.</param>
    /// <param name="LegendText">Enables editing the trace name fields from the legend</param>
    /// <param name="ShapePosition">Enables editing the trace name fields from the legend</param>
    /// <param name="TitleText">Enables editing the global layout title.</param>
    static member init
        (
            ?AnnotationPosition: bool,
            ?AnnotationTail: bool,
            ?AnnotationText: bool,
            ?AxisTitleText: bool,
            ?ColorbarPosition: bool,
            ?ColorbarTitleText: bool,
            ?LegendPosition: bool,
            ?LegendText: bool,
            ?ShapePosition: bool,
            ?TitleText: bool
        ) =
        Edits()
        |> Edits.style (
            ?AnnotationPosition = AnnotationPosition,
            ?AnnotationTail = AnnotationTail,
            ?AnnotationText = AnnotationText,
            ?AxisTitleText = AxisTitleText,
            ?ColorbarPosition = ColorbarPosition,
            ?ColorbarTitleText = ColorbarTitleText,
            ?LegendPosition = LegendPosition,
            ?LegendText = LegendText,
            ?ShapePosition = ShapePosition,
            ?TitleText = TitleText

        )

    /// <summary>
    /// Returns a function that apllioes the given styles to an Edits Object.
    /// </summary>
    /// <param name="AnnotationPosition">Determines if the main anchor of the annotation is editable. The main anchor corresponds to the text (if no arrow) or the arrow (which drags the whole thing leaving the arrow length and direction unchanged).</param>
    /// <param name="AnnotationTail">Has only an effect for annotations with arrows. Enables changing the length and direction of the arrow.</param>
    /// <param name="AnnotationText">Enables editing annotation text.</param>
    /// <param name="AxisTitleText">Enables editing axis title text.</param>
    /// <param name="ColorbarPosition">Enables moving colorbars.</param>
    /// <param name="ColorbarTitleText">Enables moving colorbars.</param>
    /// <param name="LegendPosition">Enables moving colorbars.</param>
    /// <param name="LegendText">Enables editing the trace name fields from the legend</param>
    /// <param name="ShapePosition">Enables editing the trace name fields from the legend</param>
    /// <param name="TitleText">Enables editing the global layout title.</param>
    static member style
        (
            ?AnnotationPosition: bool,
            ?AnnotationTail: bool,
            ?AnnotationText: bool,
            ?AxisTitleText: bool,
            ?ColorbarPosition: bool,
            ?ColorbarTitleText: bool,
            ?LegendPosition: bool,
            ?LegendText: bool,
            ?ShapePosition: bool,
            ?TitleText: bool
        ) =
        fun (edits: Edits) ->
            edits
            |> DynObj.withOptionalProperty "annotationPosition" AnnotationPosition  
            |> DynObj.withOptionalProperty "annotationTail"     AnnotationTail      
            |> DynObj.withOptionalProperty "annotationText"     AnnotationText      
            |> DynObj.withOptionalProperty "axisTitleText"      AxisTitleText       
            |> DynObj.withOptionalProperty "colorbarPosition"   ColorbarPosition    
            |> DynObj.withOptionalProperty "colorbarTitleText"  ColorbarTitleText   
            |> DynObj.withOptionalProperty "legendPosition"     LegendPosition      
            |> DynObj.withOptionalProperty "legendText"         LegendText          
            |> DynObj.withOptionalProperty "shapePosition"      ShapePosition       
            |> DynObj.withOptionalProperty "titleText"          TitleText           
