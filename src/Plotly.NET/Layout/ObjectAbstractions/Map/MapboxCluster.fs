namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

/// <summary>Clustering options for points on mapbox traces</summary>
type MapboxCluster() =

    inherit DynamicObj()

    /// <summary>
    /// Returns a new MapboxCluster object with the given styles
    /// </summary>
    /// <param name="Color">Sets the color for each cluster step.</param>
    /// <param name="Enabled">Determines whether clustering is enabled or disabled.</param>
    /// <param name="MaxZoom">Sets the maximum zoom level. At zoom levels equal to or greater than this, points will never be clustered.</param>
    /// <param name="Opacity">Sets the marker opacity.</param>
    /// <param name="Size">Sets the size for each cluster step.</param>
    /// <param name="MultiSize">Sets the size for each cluster step.</param>
    /// <param name="Step">Sets how many points it takes to create a cluster or advance to the next cluster step. Use this in conjunction with arrays for `size` and / or `color`. If an integer, steps start at multiples of this number. If an array, each step extends from the given value until one less than the next value.</param>
    /// <param name="MultiStep">Sets how many points it takes to create a cluster or advance to the next cluster step. Use this in conjunction with arrays for `size` and / or `color`. If an integer, steps start at multiples of this number. If an array, each step extends from the given value until one less than the next value.</param>
    static member init
        (
            ?Color: Color,
            ?Enabled: bool,
            ?MaxZoom: float,
            ?Opacity: float,
            ?Size: int,
            ?MultiSize: seq<int>,
            ?Step: int,
            ?MultiStep: seq<int>
        ) =
        MapboxCluster()
        |> MapboxCluster.style (
            ?Color = Color,
            ?Enabled = Enabled,
            ?MaxZoom = MaxZoom,
            ?Opacity = Opacity,
            ?Size = Size,
            ?MultiSize = MultiSize,
            ?Step = Step,
            ?MultiStep = MultiStep
        )

    /// <summary>
    /// Returns a function that applies the given styles to a MapboxCluster object.
    /// </summary>
    /// <param name="Color">Sets the color for each cluster step.</param>
    /// <param name="Enabled">Determines whether clustering is enabled or disabled.</param>
    /// <param name="MaxZoom">Sets the maximum zoom level. At zoom levels equal to or greater than this, points will never be clustered.</param>
    /// <param name="Opacity">Sets the marker opacity.</param>
    /// <param name="Size">Sets the size for each cluster step.</param>
    /// <param name="MultiSize">Sets the size for each cluster step.</param>
    /// <param name="Step">Sets how many points it takes to create a cluster or advance to the next cluster step. Use this in conjunction with arrays for `size` and / or `color`. If an integer, steps start at multiples of this number. If an array, each step extends from the given value until one less than the next value.</param>
    /// <param name="MultiStep">Sets how many points it takes to create a cluster or advance to the next cluster step. Use this in conjunction with arrays for `size` and / or `color`. If an integer, steps start at multiples of this number. If an array, each step extends from the given value until one less than the next value.</param>
    static member style
        (
            ?Color: Color,
            ?Enabled: bool,
            ?MaxZoom: float,
            ?Opacity: float,
            ?Size: int,
            ?MultiSize: seq<int>,
            ?Step: int,
            ?MultiStep: seq<int>

        ) =
        fun (mapboxCluster: MapboxCluster) ->
            mapboxCluster
            |> DynObj.withOptionalProperty             "color"   Color               
            |> DynObj.withOptionalProperty             "enabled" Enabled             
            |> DynObj.withOptionalProperty             "maxzoom" MaxZoom             
            |> DynObj.withOptionalProperty             "opacity" Opacity             
            |> DynObj.withOptionalSingleOrMultiProperty"size"    (Size, MultiSize)   
            |> DynObj.withOptionalSingleOrMultiProperty"step"    (Step, MultiStep)   
