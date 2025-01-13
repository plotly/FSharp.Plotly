namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

/// Dimensions type inherits from dynamic object
type Dimension() =
    inherit DynamicObj()

    /// Initializes dimensions object to be used with parcats and parcoords plots
    static member initParallel
        (
            ?ConstraintRange: StyleParam.Range,
            ?Label: #IConvertible,
            ?MultiSelect: bool,
            ?Name: string,
            ?Range: StyleParam.Range,
            ?TemplateItemName: string,
            ?TickFormat: StyleParam.TickMode,
            ?TickText: seq<#IConvertible>,
            ?Tickvals: seq<#IConvertible>,
            ?Values: seq<#IConvertible>,
            ?Visible: bool
        ) =
        Dimension()
        |> Dimension.style (
            ?ConstraintRange = ConstraintRange,
            ?Label = Label,
            ?MultiSelect = MultiSelect,
            ?Name = Name,
            ?Range = Range,
            ?TemplateItemName = TemplateItemName,
            ?TickFormat = TickFormat,
            ?TickText = TickText,
            ?Tickvals = Tickvals,
            ?Values = Values,
            ?Visible = Visible

        )


    /// Initializes dimensions object to be used with SPLOM plots
    static member initSplom
        (
            ?AxisMatches: bool,
            ?AxisType: StyleParam.AxisType,
            ?Label: #IConvertible,
            ?Name: string,
            ?TemplateItemName: string,
            ?Values: seq<#IConvertible>,
            ?Visible: bool
        ) =
        Dimension()
        |> Dimension.style (
            ?AxisMatches = AxisMatches,
            ?AxisType = AxisType,
            ?Label = Label,
            ?Name = Name,
            ?TemplateItemName = TemplateItemName,
            ?Values = Values,
            ?Visible = Visible

        )


    // Applies the styles to Dimensions()
    static member style
        (
            ?Label: #IConvertible,
            ?Name: string,
            ?TemplateItemName: string,
            ?Values: seq<#IConvertible>,
            ?Visible: bool,
            ?ConstraintRange: StyleParam.Range,
            ?MultiSelect: bool,
            ?Range: StyleParam.Range,
            ?TickFormat: StyleParam.TickMode,
            ?TickText: seq<#IConvertible>,
            ?Tickvals: seq<#IConvertible>,
            ?AxisMatches: bool,
            ?AxisType: StyleParam.AxisType
        ) =
        fun (dims: Dimension) ->

            let axis =
                LinearAxis.init (?AxisType = AxisType)
                |> DynObj.withOptionalProperty "matches" AxisMatches

            dims
            |> DynObj.withOptionalProperty "label" Label
            |> DynObj.withOptionalProperty "name" Name
            |> DynObj.withOptionalProperty "templateitemname" TemplateItemName
            |> DynObj.withOptionalProperty "values" Values
            |> DynObj.withOptionalProperty "visible" Visible
            |> DynObj.withOptionalPropertyBy "constraintrange" ConstraintRange StyleParam.Range.convert
            |> DynObj.withOptionalProperty "multiselect" MultiSelect
            |> DynObj.withOptionalPropertyBy "range" Range StyleParam.Range.convert
            |> DynObj.withOptionalPropertyBy "tickformat" TickFormat StyleParam.TickMode.convert
            |> DynObj.withOptionalProperty "ticktext" TickText
            |> DynObj.withOptionalProperty "tickvals" Tickvals
            |> DynObj.withProperty "axis" axis
