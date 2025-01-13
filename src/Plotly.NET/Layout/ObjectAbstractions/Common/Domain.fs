namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

/// Dimensions type inherits from dynamic object
type Domain() =
    inherit DynamicObj()

    /// Initialized Dimensions object
    static member init
        (
            ?X: StyleParam.Range,
            ?Y: StyleParam.Range,
            ?Row: int,
            ?Column: int
        ) =
        Domain() |> Domain.style (?X = X, ?Y = Y, ?Row = Row, ?Column = Column)


    // Applies the styles to Dimensions()
    static member style
        (
            ?X: StyleParam.Range,
            ?Y: StyleParam.Range,
            ?Row: int,
            ?Column: int
        ) =
        (fun (dom: Domain) ->

            dom
            |> DynObj.withOptionalPropertyBy "x" X StyleParam.Range.convert
            |> DynObj.withOptionalPropertyBy "y" Y StyleParam.Range.convert
            |> DynObj.withOptionalProperty "row" Row
            |> DynObj.withOptionalProperty "column" Column
        )
