namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

/// <summary>Determines the style of the map shown in geo traces</summary>
type Geo() =

    inherit DynamicObj()

    /// <summary>Initialize a Geo object that determines the style of the map shown in geo traces</summary>
    /// <param name="FitBounds">Determines if and how this subplot's view settings are auto-computed to fit trace data</param>
    /// <param name="Resolution">Sets the resolution of the base layers</param>
    /// <param name="Scope">Set the scope of the map.</param>
    /// <param name="Projection">Determines the type of projection used to display the map</param>
    /// <param name="Center">Sets the (lon,lat) coordinates of the map's center. By default, the map's longitude center lies at the middle of the longitude range for scoped projection and above `projection.rotation.lon` otherwise. For all projection types, the map's latitude center lies at the middle of the latitude range by default.</param>
    /// <param name="Visible">Whether or not the base layers are visible</param>
    /// <param name="Domain">The domain of this geo subplot</param>
    /// <param name="ShowCoastLines">Sets whether or not the coastlines are drawn.</param>
    /// <param name="CoastLineColor">Sets the coastline color.</param>
    /// <param name="CoastLineWidth">Sets the coastline stroke width (in px).</param>
    /// <param name="ShowLand">Sets whether or not land masses are filled in color.</param>
    /// <param name="LandColor">Sets the land mass color.</param>
    /// <param name="ShowOcean">Sets whether or not oceans are filled in color.</param>
    /// <param name="OceanColor">Sets the ocean color</param>
    /// <param name="ShowLakes">Sets whether or not lakes are drawn.</param>
    /// <param name="LakeColor">Sets the color of the lakes.</param>
    /// <param name="ShowRivers">Sets whether or not rivers are drawn.</param>
    /// <param name="RiverColor">Sets color of the rivers.</param>
    /// <param name="RiverWidth">Sets the stroke width (in px) of the rivers.</param>
    /// <param name="ShowCountries">Sets whether or not country boundaries are drawn.</param>
    /// <param name="CountryColor">Sets line color of the country boundaries.</param>
    /// <param name="CountryWidth">Sets line width (in px) of the country boundaries.</param>
    /// <param name="ShowSubunits">Sets whether or not boundaries of subunits within countries (e.g. states, provinces) are drawn.</param>
    /// <param name="SubunitColor">Sets the color of the subunits boundaries.</param>
    /// <param name="SubunitWidth">Sets the stroke width (in px) of the subunits boundaries.</param>
    /// <param name="ShowFrame">Sets whether or not a frame is drawn around the map.</param>
    /// <param name="FrameColor">Sets the color the frame.</param>
    /// <param name="FrameWidth">Sets the stroke width (in px) of the frame.</param>
    /// <param name="BgColor">Set the background color of the map</param>
    /// <param name="LatAxis">Sets the latitudinal axis for this geo trace</param>
    /// <param name="LonAxis">Sets the longitudinal axis for this geo trace</param>
    static member init
        (
            ?FitBounds: StyleParam.GeoFitBounds,
            ?Resolution: StyleParam.GeoResolution,
            ?Scope: StyleParam.GeoScope,
            ?Projection: GeoProjection,
            ?Center: (float * float),
            ?Visible: bool,
            ?Domain: Domain,
            ?ShowCoastLines: bool,
            ?CoastLineColor: Color,
            ?CoastLineWidth: float,
            ?ShowLand: bool,
            ?LandColor: Color,
            ?ShowOcean: bool,
            ?OceanColor: Color,
            ?ShowLakes: bool,
            ?LakeColor: Color,
            ?ShowRivers: bool,
            ?RiverColor: Color,
            ?RiverWidth: float,
            ?ShowCountries: bool,
            ?CountryColor: Color,
            ?CountryWidth: float,
            ?ShowSubunits: bool,
            ?SubunitColor: Color,
            ?SubunitWidth: float,
            ?ShowFrame: bool,
            ?FrameColor: Color,
            ?FrameWidth: float,
            ?BgColor: Color,
            ?LatAxis: LinearAxis,
            ?LonAxis: LinearAxis
        ) =
        Geo()
        |> Geo.style (
            ?FitBounds = FitBounds,
            ?Resolution = Resolution,
            ?Scope = Scope,
            ?Projection = Projection,
            ?Center = Center,
            ?Visible = Visible,
            ?Domain = Domain,
            ?ShowCoastLines = ShowCoastLines,
            ?CoastLineColor = CoastLineColor,
            ?CoastLineWidth = CoastLineWidth,
            ?ShowLand = ShowLand,
            ?LandColor = LandColor,
            ?ShowOcean = ShowOcean,
            ?OceanColor = OceanColor,
            ?ShowLakes = ShowLakes,
            ?LakeColor = LakeColor,
            ?ShowRivers = ShowRivers,
            ?RiverColor = RiverColor,
            ?RiverWidth = RiverWidth,
            ?ShowCountries = ShowCountries,
            ?CountryColor = CountryColor,
            ?CountryWidth = CountryWidth,
            ?ShowSubunits = ShowSubunits,
            ?SubunitColor = SubunitColor,
            ?SubunitWidth = SubunitWidth,
            ?ShowFrame = ShowFrame,
            ?FrameColor = FrameColor,
            ?FrameWidth = FrameWidth,
            ?BgColor = BgColor,
            ?LatAxis = LatAxis,
            ?LonAxis = LonAxis
        )

    /// <summary>Create a function that applies the given style parameters to a Geo object.</summary>
    /// <param name="FitBounds">Determines if and how this subplot's view settings are auto-computed to fit trace data</param>
    /// <param name="Resolution">Sets the resolution of the base layers</param>
    /// <param name="Scope">Set the scope of the map.</param>
    /// <param name="Projection">Determines the type of projection used to display the map</param>
    /// <param name="Center">Sets the (lon,lat) coordinates of the map's center. By default, the map's longitude center lies at the middle of the longitude range for scoped projection and above `projection.rotation.lon` otherwise. For all projection types, the map's latitude center lies at the middle of the latitude range by default.</param>
    /// <param name="Visible">Whether or not the base layers are visible</param>
    /// <param name="Domain">The domain of this geo subplot</param>
    /// <param name="ShowCoastLines">Sets whether or not the coastlines are drawn.</param>
    /// <param name="CoastLineColor">Sets the coastline color.</param>
    /// <param name="CoastLineWidth">Sets the coastline stroke width (in px).</param>
    /// <param name="ShowLand">Sets whether or not land masses are filled in color.</param>
    /// <param name="LandColor">Sets the land mass color.</param>
    /// <param name="ShowOcean">Sets whether or not oceans are filled in color.</param>
    /// <param name="OceanColor">Sets the ocean color</param>
    /// <param name="ShowLakes">Sets whether or not lakes are drawn.</param>
    /// <param name="LakeColor">Sets the color of the lakes.</param>
    /// <param name="ShowRivers">Sets whether or not rivers are drawn.</param>
    /// <param name="RiverColor">Sets color of the rivers.</param>
    /// <param name="RiverWidth">Sets the stroke width (in px) of the rivers.</param>
    /// <param name="ShowCountries">Sets whether or not country boundaries are drawn.</param>
    /// <param name="CountryColor">Sets line color of the country boundaries.</param>
    /// <param name="CountryWidth">Sets line width (in px) of the country boundaries.</param>
    /// <param name="ShowSubunits">Sets whether or not boundaries of subunits within countries (e.g. states, provinces) are drawn.</param>
    /// <param name="SubunitColor">Sets the color of the subunits boundaries.</param>
    /// <param name="SubunitWidth">Sets the stroke width (in px) of the subunits boundaries.</param>
    /// <param name="ShowFrame">Sets whether or not a frame is drawn around the map.</param>
    /// <param name="FrameColor">Sets the color the frame.</param>
    /// <param name="FrameWidth">Sets the stroke width (in px) of the frame.</param>
    /// <param name="BgColor">Set the background color of the map</param>
    /// <param name="LatAxis">Sets the latitudinal axis for this geo trace</param>
    /// <param name="LonAxis">Sets the longitudinal axis for this geo trace</param>
    static member style
        (
            ?FitBounds: StyleParam.GeoFitBounds,
            ?Resolution: StyleParam.GeoResolution,
            ?Scope: StyleParam.GeoScope,
            ?Projection: GeoProjection,
            ?Center: (float * float),
            ?Visible: bool,
            ?Domain: Domain,
            ?ShowCoastLines: bool,
            ?CoastLineColor: Color,
            ?CoastLineWidth: float,
            ?ShowLand: bool,
            ?LandColor: Color,
            ?ShowOcean: bool,
            ?OceanColor: Color,
            ?ShowLakes: bool,
            ?LakeColor: Color,
            ?ShowRivers: bool,
            ?RiverColor: Color,
            ?RiverWidth: float,
            ?ShowCountries: bool,
            ?CountryColor: Color,
            ?CountryWidth: float,
            ?ShowSubunits: bool,
            ?SubunitColor: Color,
            ?SubunitWidth: float,
            ?ShowFrame: bool,
            ?FrameColor: Color,
            ?FrameWidth: float,
            ?BgColor: Color,
            ?LatAxis: LinearAxis,
            ?LonAxis: LinearAxis
        ) =
        fun (geo: Geo) ->

            let center =
                Center
                |> Option.map (fun (lon, lat) ->
                    DynamicObj()
                    |> DynObj.withProperty "lon" lon
                    |> DynObj.withProperty "lat" lat
                )

            geo
            |> DynObj.withOptionalProperty   "domain"         Domain          
            |> DynObj.withOptionalPropertyBy "fitbounds"      FitBounds       StyleParam.GeoFitBounds.convert
            |> DynObj.withOptionalPropertyBy "resolution"     Resolution      StyleParam.GeoResolution.convert
            |> DynObj.withOptionalPropertyBy "scope"          Scope           StyleParam.GeoScope.convert
            |> DynObj.withOptionalProperty   "projection"     Projection      
            |> DynObj.withOptionalProperty   "center"         center          
            |> DynObj.withOptionalProperty   "visible"        Visible         
            |> DynObj.withOptionalProperty   "showcoastline"  ShowCoastLines  
            |> DynObj.withOptionalProperty   "coastlinecolor" CoastLineColor  
            |> DynObj.withOptionalProperty   "coastlinewidth" CoastLineWidth  
            |> DynObj.withOptionalProperty   "showland"       ShowLand        
            |> DynObj.withOptionalProperty   "landcolor"      LandColor       
            |> DynObj.withOptionalProperty   "showocean"      ShowOcean       
            |> DynObj.withOptionalProperty   "oceancolor"     OceanColor      
            |> DynObj.withOptionalProperty   "showlakes"      ShowLakes       
            |> DynObj.withOptionalProperty   "lakecolor"      LakeColor       
            |> DynObj.withOptionalProperty   "showrivers"     ShowRivers      
            |> DynObj.withOptionalProperty   "rivercolor"     RiverColor      
            |> DynObj.withOptionalProperty   "riverwidth"     RiverWidth      
            |> DynObj.withOptionalProperty   "showcountries"  ShowCountries   
            |> DynObj.withOptionalProperty   "countrycolor"   CountryColor    
            |> DynObj.withOptionalProperty   "countrywidth"   CountryWidth    
            |> DynObj.withOptionalProperty   "showsubunits"   ShowSubunits    
            |> DynObj.withOptionalProperty   "subunitcolor"   SubunitColor    
            |> DynObj.withOptionalProperty   "subunitwidth"   SubunitWidth    
            |> DynObj.withOptionalProperty   "showframe"      ShowFrame       
            |> DynObj.withOptionalProperty   "framecolor"     FrameColor      
            |> DynObj.withOptionalProperty   "framewidth"     FrameWidth      
            |> DynObj.withOptionalProperty   "bgcolor"        BgColor         
            |> DynObj.withOptionalProperty   "lataxis"        LatAxis         
            |> DynObj.withOptionalProperty   "lonaxis"        LonAxis         
