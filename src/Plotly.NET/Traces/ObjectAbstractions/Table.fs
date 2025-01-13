namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

/// CellColor type inherits from dynamic object
type TableFill() =
    inherit DynamicObj()

    static member init(?Color: Color) =
        TableFill() |> TableFill.style (?Color = Color)

    static member style(?Color: Color) =
        fun (fill: TableFill) ->
            fill
            |> DynObj.withOptionalProperty "color" Color

/// Cells type inherits from dynamic object
type TableCells() =
    inherit DynamicObj()

    /// Initialized Cells object
    static member init
        (
            ?Align: StyleParam.HorizontalAlign,
            ?MultiAlign: seq<StyleParam.HorizontalAlign>,
            ?Fill: TableFill,
            ?Font: Font,
            ?Format: seq<string>,
            ?Height: int,
            ?Line: Line,
            ?Prefix: string,
            ?MultiPrefix: seq<string>,
            ?Suffix: string,
            ?MultiSuffix: seq<string>,
            ?Values: seq<#seq<#IConvertible>>
        ) =
        TableCells()
        |> TableCells.style (
            ?Align = Align,
            ?MultiAlign = MultiAlign,
            ?Fill = Fill,
            ?Font = Font,
            ?Format = Format,
            ?Height = Height,
            ?Line = Line,
            ?Prefix = Prefix,
            ?MultiPrefix = MultiPrefix,
            ?Suffix = Suffix,
            ?MultiSuffix = MultiSuffix,
            ?Values = Values
        )

    //Applies the styles to TableCells()
    static member style
        (
            ?Align: StyleParam.HorizontalAlign,
            ?MultiAlign: seq<StyleParam.HorizontalAlign>,
            ?Fill: TableFill,
            ?Font: Font,
            ?Format: seq<string>,
            ?Height: int,
            ?Line: Line,
            ?Prefix: string,
            ?MultiPrefix: seq<string>,
            ?Suffix: string,
            ?MultiSuffix: seq<string>,
            ?Values: seq<#seq<#IConvertible>>
        ) =
        fun (cells: TableCells) ->

            cells
            |> DynObj.withOptionalSingleOrMultiPropertyBy "align" (Align, MultiAlign) StyleParam.HorizontalAlign.convert
            |> DynObj.withOptionalProperty "fill" Fill
            |> DynObj.withOptionalProperty "font" Font
            |> DynObj.withOptionalProperty "format" Format
            |> DynObj.withOptionalProperty "height" Height
            |> DynObj.withOptionalProperty "line" Line
            |> DynObj.withOptionalSingleOrMultiProperty "prefix" (Prefix, MultiPrefix)
            |> DynObj.withOptionalSingleOrMultiProperty "suffix" (Suffix, MultiSuffix)
            |> DynObj.withOptionalProperty "values" Values

type TableHeader = TableCells
