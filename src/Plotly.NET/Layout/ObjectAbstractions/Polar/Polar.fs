namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices


type Polar() =
    inherit DynamicObj()

    /// <summary>
    /// Initialize a Polar object that contains layout options concerned with polar plots.
    /// </summary>
    /// <param name="Domain">Sets the domain of this polar subplot</param>
    /// <param name="Sector">Sets angular span of this polar subplot with two angles (in degrees). Sector are assumed to be spanned in the counterclockwise direction with "0" corresponding to rightmost limit of the polar subplot.</param>
    /// <param name="Hole">Sets the fraction of the radius to cut out of the polar subplot.</param>
    /// <param name="BGColor">Set the background color of the subplot</param>
    /// <param name="RadialAxis">Sets the radial axis of the polar subplot.</param>
    /// <param name="AngularAxis">Sets the angular axis of the polar subplot.</param>
    /// <param name="GridShape">Determines if the radial axis grid lines and angular axis line are drawn as "circular" sectors or as "linear" (polygon) sectors. Has an effect only when the angular axis has `type` "category". Note that `radialaxis.angle` is snapped to the angle of the closest vertex when `gridshape` is "circular" (so that radial axis scale is the same as the data scale).</param>
    /// <param name="UIRevision">Controls persistence of user-driven changes in axis attributes, if not overridden in the individual axes. Defaults to `layout.uirevision`.</param>
    static member init
        (
            ?Domain: Domain,
            ?Sector: float * float,
            ?Hole: float,
            ?BGColor: Color,
            ?RadialAxis: RadialAxis,
            ?AngularAxis: AngularAxis,
            ?GridShape: StyleParam.PolarGridShape,
            ?UIRevision: string
        ) =
        Polar()
        |> Polar.style (
            ?Domain = Domain,
            ?Sector = Sector,
            ?Hole = Hole,
            ?BGColor = BGColor,
            ?RadialAxis = RadialAxis,
            ?AngularAxis = AngularAxis,
            ?GridShape = GridShape,
            ?UIRevision = UIRevision
        )

    /// <summary>
    /// Create a function that applies the given style parameters to a Polar object
    /// </summary>
    /// <param name="Domain">Sets the domain of this polar subplot</param>
    /// <param name="Sector">Sets angular span of this polar subplot with two angles (in degrees). Sector are assumed to be spanned in the counterclockwise direction with "0" corresponding to rightmost limit of the polar subplot.</param>
    /// <param name="Hole">Sets the fraction of the radius to cut out of the polar subplot.</param>
    /// <param name="BGColor">Set the background color of the subplot</param>
    /// <param name="RadialAxis">Sets the radial axis of the polar subplot.</param>
    /// <param name="AngularAxis">Sets the angular axis of the polar subplot.</param>
    /// <param name="GridShape">Determines if the radial axis grid lines and angular axis line are drawn as "circular" sectors or as "linear" (polygon) sectors. Has an effect only when the angular axis has `type` "category". Note that `radialaxis.angle` is snapped to the angle of the closest vertex when `gridshape` is "circular" (so that radial axis scale is the same as the data scale).</param>
    /// <param name="UIRevision">Controls persistence of user-driven changes in axis attributes, if not overridden in the individual axes. Defaults to `layout.uirevision`.</param>
    /// <param name="BarMode">Determines how bars at the same location coordinate are displayed on the graph. With "stack", the bars are stacked on top of one another With "relative", the bars are stacked on top of one another, with negative values below the axis, positive values above With "group", the bars are plotted next to one another centered around the shared location. With "overlay", the bars are plotted over one another, you might need to an "opacity" to see multiple bars.</param>
    /// <param name="BarGap">Sets the gap (in plot fraction) between bars of adjacent location coordinates.</param>
    static member style
        (
            ?Domain: Domain,
            ?Sector: float * float,
            ?Hole: float,
            ?BGColor: Color,
            ?RadialAxis: RadialAxis,
            ?AngularAxis: AngularAxis,
            ?GridShape: StyleParam.PolarGridShape,
            ?UIRevision: string,
            ?BarMode: StyleParam.BarMode,
            ?BarGap: float
        ) =
        fun (polar: Polar) ->
            polar
            |> DynObj.withOptionalProperty   "domain"      Domain      
            |> DynObj.withOptionalPropertyBy "sector"      Sector      (fun (a, b) -> [| a; b |])
            |> DynObj.withOptionalProperty   "hole"        Hole        
            |> DynObj.withOptionalProperty   "bgcolor"     BGColor     
            |> DynObj.withOptionalProperty   "radialaxis"  RadialAxis  
            |> DynObj.withOptionalProperty   "angularaxis" AngularAxis 
            |> DynObj.withOptionalPropertyBy "gridshape"   GridShape   StyleParam.PolarGridShape.convert
            |> DynObj.withOptionalProperty   "uirevision"  UIRevision  
            |> DynObj.withOptionalPropertyBy "barmode"     BarMode     StyleParam.BarMode.convert
            |> DynObj.withOptionalProperty   "bargap"      BarGap      

    /// <summary>
    /// Returns Some(dynamic member value) of the object's underlying DynamicObj when a dynamic member with the given name exists, and None otherwise.
    /// </summary>
    /// <param name="propName">The name of the dynamic member to get the value of</param>
    /// <param name="polar">The object to get the dynamic member value from</param>
    static member tryGetTypedMember<'T> (propName: string) (polar: Polar) = polar.TryGetTypedPropertyValue<'T>(propName)

    /// <summary>
    /// Returns the AngularAxis object of the given polar object.
    ///
    /// If there is no AngularAxis set, returns an empty AngularAxis object.
    /// </summary>
    /// <param name="polar">The polar object to get the AngularAxis from</param>
    static member getAngularAxis(polar: Polar) =
        polar |> Polar.tryGetTypedMember<AngularAxis> "angularaxis" |> Option.defaultValue (AngularAxis.init ())

    /// <summary>
    /// Returns a function that sets the AngularAxis object of the given polar object.
    /// </summary>
    /// <param name="angularAxis">The new AngularAxis object</param>
    static member setAngularAxis(angularAxis: AngularAxis) =
        (fun (polar: Polar) ->
            polar.SetProperty("angularaxis", angularAxis)
            polar)

    /// <summary>
    /// Returns the RadialAxis object of the given polar object.
    ///
    /// If there is no RadialAxis set, returns an empty RadialAxis object.
    /// </summary>
    /// <param name="polar">The polar object to get the RadialAxis from</param>
    static member getRadialAxis(polar: Polar) =
        polar |> Polar.tryGetTypedMember<RadialAxis> "radialaxis" |> Option.defaultValue (RadialAxis.init ())

    /// <summary>
    /// Returns a function that sets the RadialAxis object of the given polar object.
    /// </summary>
    /// <param name="radialAxis">The new RadialAxis object</param>
    static member setRadialAxis(radialAxis: RadialAxis) =
        (fun (polar: Polar) ->
            polar.SetProperty("radialaxis", radialAxis)
            polar)
