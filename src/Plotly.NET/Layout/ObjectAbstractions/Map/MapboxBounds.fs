namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

/// <summary></summary>
type MapboxBounds() =

    inherit DynamicObj()

    /// <summary>
    /// Returns a new MapboxBounds object with the given styles
    /// </summary>
    /// <param name="East">Sets the maximum longitude of the map (in degrees East) if `west`, `south` and `north` are declared.</param>
    /// <param name="North">Sets the maximum latitude of the map (in degrees North) if `east`, `west` and `south` are declared.</param>
    /// <param name="South">Sets the minimum latitude of the map (in degrees North) if `east`, `west` and `north` are declared.</param>
    /// <param name="West">Sets the minimum latitude of the map (in degrees North) if `east`, `west` and `north` are declared.</param>
    static member init
        (
            ?East: float,
            ?North: float,
            ?South: float,
            ?West: float
        ) =
        MapboxBounds() |> MapboxBounds.style (?East = East, ?North = North, ?South = South, ?West = West)

    /// <summary>
    /// Returns a function that applies the given styles to a MapoxBounds object.
    /// </summary>
    /// <param name="East">Sets the maximum longitude of the map (in degrees East) if `west`, `south` and `north` are declared.</param>
    /// <param name="North">Sets the maximum latitude of the map (in degrees North) if `east`, `west` and `south` are declared.</param>
    /// <param name="South">Sets the minimum latitude of the map (in degrees North) if `east`, `west` and `north` are declared.</param>
    /// <param name="West">Sets the minimum latitude of the map (in degrees North) if `east`, `west` and `north` are declared.</param>
    static member style
        (
            ?East: float,
            ?North: float,
            ?South: float,
            ?West: float
        ) =
        fun (mapboxBounds: MapboxBounds) ->

            mapboxBounds
            |> DynObj.withOptionalProperty "east"  East    
            |> DynObj.withOptionalProperty "north" North   
            |> DynObj.withOptionalProperty "south" South   
            |> DynObj.withOptionalProperty "west"  West    