namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

/// <summary>Determines the style of the map shown in mapbox traces</summary>
type Mapbox() =

    inherit DynamicObj()

    /// <summary>
    /// Returns a new Mapbox object with the given styles applied.
    /// </summary>
    /// <param name="Domain">Sets the domain of the Mapbox subplot</param>
    /// <param name="AccessToken">Sets the mapbox access token to be used for this mapbox map. Alternatively, the mapbox access token can be set in the configuration options under `mapboxAccessToken`. Note that accessToken are only required when `style` (e.g with values : basic, streets, outdoors, light, dark, satellite, satellite-streets ) and/or a layout layer references the Mapbox server.</param>
    /// <param name="Style">Defines the map layers that are rendered by default below the trace layers defined in `data`, which are themselves by default rendered below the layers defined in `layout.mapbox.layers`. These layers can be defined either explicitly as a Mapbox Style object which can contain multiple layer definitions that load data from any public or private Tile Map Service (TMS or XYZ) or Web Map Service (WMS) or implicitly by using one of the built-in style objects which use WMSes which do not require any access tokens, or by using a default Mapbox style or custom Mapbox style URL, both of which require a Mapbox access token Note that Mapbox access token can be set in the `accesstoken` attribute or in the `mapboxAccessToken` config option. Mapbox Style objects are of the form described in the Mapbox GL JS documentation available at https://docs.mapbox.com/mapbox-gl-js/style-spec The built-in plotly.js styles objects are: carto-darkmatter, carto-positron, open-street-map, stamen-terrain, stamen-toner, stamen-watercolor, white-bg The built-in Mapbox styles are: basic, streets, outdoors, light, dark, satellite, satellite-streets Mapbox style URLs are of the form: mapbox://mapbox.mapbox/name/version</param>
    /// <param name="Bounds">Sets the bounds of the map</param>
    /// <param name="Center">Sets the (lon,lat) coordinates of the center of the map view</param>
    /// <param name="Zoom">Sets the zoom level of the map (mapbox.zoom).</param>
    /// <param name="Bearing">Sets the bearing angle of the map in degrees counter-clockwise from North (mapbox.bearing).</param>
    /// <param name="Pitch">Sets the pitch angle of the map (in degrees, where "0" means perpendicular to the surface of the map) (mapbox.pitch).</param>
    /// <param name="Layers">Sets the layers of this Mapbox</param>
    static member init
        (
            ?Domain: Domain,
            ?AccessToken: string,
            ?Style: StyleParam.MapboxStyle,
            ?Bounds: MapboxBounds,
            ?Center: (float * float),
            ?Zoom: float,
            ?Bearing: float,
            ?Pitch: float,
            ?Layers: seq<MapboxLayer>
        ) =
        Mapbox()
        |> Mapbox.style (
            ?Domain = Domain,
            ?AccessToken = AccessToken,
            ?Style = Style,
            ?Bounds = Bounds,
            ?Center = Center,
            ?Zoom = Zoom,
            ?Bearing = Bearing,
            ?Pitch = Pitch,
            ?Layers = Layers
        )

    /// <summary>Create a function that applies the given style parameters to a Mapbox object.</summary>
    /// <param name="Domain">Sets the domain of the Mapbox subplot</param>
    /// <param name="AccessToken">Sets the mapbox access token to be used for this mapbox map. Alternatively, the mapbox access token can be set in the configuration options under `mapboxAccessToken`. Note that accessToken are only required when `style` (e.g with values : basic, streets, outdoors, light, dark, satellite, satellite-streets ) and/or a layout layer references the Mapbox server.</param>
    /// <param name="Style">Defines the map layers that are rendered by default below the trace layers defined in `data`, which are themselves by default rendered below the layers defined in `layout.mapbox.layers`. These layers can be defined either explicitly as a Mapbox Style object which can contain multiple layer definitions that load data from any public or private Tile Map Service (TMS or XYZ) or Web Map Service (WMS) or implicitly by using one of the built-in style objects which use WMSes which do not require any access tokens, or by using a default Mapbox style or custom Mapbox style URL, both of which require a Mapbox access token Note that Mapbox access token can be set in the `accesstoken` attribute or in the `mapboxAccessToken` config option. Mapbox Style objects are of the form described in the Mapbox GL JS documentation available at https://docs.mapbox.com/mapbox-gl-js/style-spec The built-in plotly.js styles objects are: carto-darkmatter, carto-positron, open-street-map, stamen-terrain, stamen-toner, stamen-watercolor, white-bg The built-in Mapbox styles are: basic, streets, outdoors, light, dark, satellite, satellite-streets Mapbox style URLs are of the form: mapbox://mapbox.mapbox/name/version</param>
    /// <param name="Bounds">Sets the bounds of the map</param>
    /// <param name="Center">Sets the (lon,lat) coordinates of the center of the map view</param>
    /// <param name="Zoom">Sets the zoom level of the map (mapbox.zoom).</param>
    /// <param name="Bearing">Sets the bearing angle of the map in degrees counter-clockwise from North (mapbox.bearing).</param>
    /// <param name="Pitch">Sets the pitch angle of the map (in degrees, where "0" means perpendicular to the surface of the map) (mapbox.pitch).</param>
    /// <param name="Layers">Sets the layers of this Mapbox</param>
    static member style
        (
            ?Domain: Domain,
            ?AccessToken: string,
            ?Style: StyleParam.MapboxStyle,
            ?Bounds: MapboxBounds,
            ?Center: (float * float),
            ?Zoom: float,
            ?Bearing: float,
            ?Pitch: float,
            ?Layers: seq<MapboxLayer>
        ) =
        fun (mapBox: Mapbox) ->

            let center =
                Center
                |> Option.map (fun (lon, lat) ->
                    DynamicObj()
                    |> DynObj.withProperty "lon" lon
                    |> DynObj.withProperty "lat" lat
                )

            mapBox
            |> DynObj.withOptionalProperty   "domain"      Domain      
            |> DynObj.withOptionalProperty   "accesstoken" AccessToken 
            |> DynObj.withOptionalPropertyBy "style"       Style       StyleParam.MapboxStyle.convert
            |> DynObj.withOptionalProperty   "bounds"      Bounds      
            |> DynObj.withOptionalProperty   "center"      center      
            |> DynObj.withOptionalProperty   "zoom"        Zoom        
            |> DynObj.withOptionalProperty   "bearing"     Bearing     
            |> DynObj.withOptionalProperty   "pitch"       Pitch       
            |> DynObj.withOptionalProperty   "layers"      Layers      
