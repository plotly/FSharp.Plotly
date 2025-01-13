namespace Plotly.NET.LayoutObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

/// Scene
type Scene() =
    inherit DynamicObj()

    /// <summary>
    /// Initialize a categorical Scene object that can be used as a laxout anchor for a 3D coordinate system.
    /// </summary>
    /// <param name="Annotations">An annotation is a text element that can be placed anywhere in the plot. It can be positioned with respect to relative coordinates in the plot or with respect to the actual data coordinates of the graph. Annotations can be shown with or without an arrow.</param>
    /// <param name="AspectMode">If "cube", this scene's axes are drawn as a cube, regardless of the axes' ranges. If "data", this scene's axes are drawn in proportion with the axes' ranges. If "manual", this scene's axes are drawn in proportion with the input of "aspectratio" (the default behavior if "aspectratio" is provided). If "auto", this scene's axes are drawn using the results of "data" except when one axis is more than four times the size of the two others, where in that case the results of "cube" are used.</param>
    /// <param name="AspectRatio">Sets this scene's axis aspectratio.</param>
    /// <param name="BGColor">Sets this scene's background color.</param>
    /// <param name="Camera">Sets this scene's camera</param>
    /// <param name="Domain">Sets this scene's domain</param>
    /// <param name="DragMode">Determines the mode of drag interactions for this scene.</param>
    /// <param name="HoverMode">Determines the mode of hover interactions for this scene.</param>
    /// <param name="UIRevision">Controls persistence of user-driven changes in camera attributes. Defaults to `layout.uirevision`.</param>
    /// <param name="XAxis">Sets this scene's xaxis</param>
    /// <param name="YAxis">Sets this scene's yaxis</param>
    /// <param name="ZAxis">Sets this scene's zaxis</param>
    static member init
        (
            ?Annotations: seq<Annotation>,
            ?AspectMode: StyleParam.AspectMode,
            ?AspectRatio: AspectRatio,
            ?BGColor: Color,
            ?Camera: Camera,
            ?Domain: Domain,
            ?DragMode: StyleParam.DragMode,
            ?HoverMode: StyleParam.HoverMode,
            ?UIRevision: string,
            ?XAxis: LinearAxis,
            ?YAxis: LinearAxis,
            ?ZAxis: LinearAxis
        ) =
        Scene()
        |> Scene.style (
            ?Annotations = Annotations,
            ?AspectMode = AspectMode,
            ?AspectRatio = AspectRatio,
            ?BGColor = BGColor,
            ?Camera = Camera,
            ?Domain = Domain,
            ?DragMode = DragMode,
            ?HoverMode = HoverMode,
            ?UIRevision = UIRevision,
            ?XAxis = XAxis,
            ?YAxis = YAxis,
            ?ZAxis = ZAxis
        )

    /// <summary>
    /// Creates a function that applies the given style parameters to a Scene object
    /// </summary>
    /// <param name="Annotations">An annotation is a text element that can be placed anywhere in the plot. It can be positioned with respect to relative coordinates in the plot or with respect to the actual data coordinates of the graph. Annotations can be shown with or without an arrow.</param>
    /// <param name="AspectMode">If "cube", this scene's axes are drawn as a cube, regardless of the axes' ranges. If "data", this scene's axes are drawn in proportion with the axes' ranges. If "manual", this scene's axes are drawn in proportion with the input of "aspectratio" (the default behavior if "aspectratio" is provided). If "auto", this scene's axes are drawn using the results of "data" except when one axis is more than four times the size of the two others, where in that case the results of "cube" are used.</param>
    /// <param name="AspectRatio">Sets this scene's axis aspectratio.</param>
    /// <param name="BGColor">Sets this scene's background color.</param>
    /// <param name="Camera">Sets this scene's camera</param>
    /// <param name="Domain">Sets this scene's domain</param>
    /// <param name="DragMode">Determines the mode of drag interactions for this scene.</param>
    /// <param name="HoverMode">Determines the mode of hover interactions for this scene.</param>
    /// <param name="UIRevision">Controls persistence of user-driven changes in camera attributes. Defaults to `layout.uirevision`.</param>
    /// <param name="XAxis">Sets this scene's xaxis</param>
    /// <param name="YAxis">Sets this scene's yaxis</param>
    /// <param name="ZAxis">Sets this scene's zaxis</param>
    static member style
        (
            ?Annotations: seq<Annotation>,
            ?AspectMode: StyleParam.AspectMode,
            ?AspectRatio: AspectRatio,
            ?BGColor: Color,
            ?Camera: Camera,
            ?Domain: Domain,
            ?DragMode: StyleParam.DragMode,
            ?HoverMode: StyleParam.HoverMode,
            ?UIRevision: string,
            ?XAxis: LinearAxis,
            ?YAxis: LinearAxis,
            ?ZAxis: LinearAxis
        ) =
        fun (scene: Scene) ->

            scene
            |> DynObj.withOptionalProperty   "annotations" Annotations 
            |> DynObj.withOptionalPropertyBy "aspectmode"  AspectMode  StyleParam.AspectMode.convert
            |> DynObj.withOptionalProperty   "aspectratio" AspectRatio 
            |> DynObj.withOptionalProperty   "bgcolor"     BGColor     
            |> DynObj.withOptionalProperty   "camera"      Camera      
            |> DynObj.withOptionalProperty   "domain"      Domain      
            |> DynObj.withOptionalPropertyBy "dragmode"    DragMode    StyleParam.DragMode.convert
            |> DynObj.withOptionalPropertyBy "hovermode"   HoverMode   StyleParam.HoverMode.convert
            |> DynObj.withOptionalProperty   "uirevision"  UIRevision  
            |> DynObj.withOptionalProperty   "xaxis"       XAxis       
            |> DynObj.withOptionalProperty   "yaxis"       YAxis       
            |> DynObj.withOptionalProperty   "zaxis"       ZAxis       

    /// <summary>
    /// Returns Some(dynamic member value) of the scene object's underlying DynamicObj when a dynamic member with the given name exists, and None otherwise.
    /// </summary>
    /// <param name="propName">The name of the dynamic member to get the value of</param>
    /// <param name="scene">The scene to get the dynamic member value from</param>
    static member tryGetTypedMember<'T> (propName: string) (scene: Scene) = scene.TryGetTypedPropertyValue<'T>(propName)

    /// <summary>
    /// Returns the x axis object of the given scene.
    ///
    /// If there is no x axis set, returns an empty LinearAxis object.
    /// </summary>
    /// <param name="scene">The scene to get the x axis from</param>
    static member getXAxis(scene: Scene) =
        scene |> Scene.tryGetTypedMember<LinearAxis> "xaxis" |> Option.defaultValue (LinearAxis.init ())

    /// <summary>
    /// Returns a function that sets the x axis object of the given scene.
    /// </summary>
    /// <param name="xAxis">The new x axis object</param>
    static member setXAxis(xAxis: LinearAxis) =
        (fun (scene: Scene) ->
            scene.SetProperty("xaxis", xAxis)
            scene)

    /// <summary>
    /// Returns the y axis object of the given scene.
    ///
    /// If there is no y axis set, returns an empty LinearAxis object.
    /// </summary>
    /// <param name="scene">The scene to get the y axis from</param>
    static member getYAxis(scene: Scene) =
        scene |> Scene.tryGetTypedMember<LinearAxis> "yaxis" |> Option.defaultValue (LinearAxis.init ())

    /// <summary>
    /// Returns a function that sets the y axis object of the given scene.
    /// </summary>
    /// <param name="yAxis">The new y axis object</param>
    static member setYAxis(yAxis: LinearAxis) =
        (fun (scene: Scene) ->
            scene.SetProperty("yaxis", yAxis)
            scene)

    /// <summary>
    /// Returns the z axis object of the given scene.
    ///
    /// If there is no z axis set, returns an empty LinearAxis object.
    /// </summary>
    /// <param name="scene">The scene to get the z axis from</param>
    static member getZAxis(scene: Scene) =
        scene |> Scene.tryGetTypedMember<LinearAxis> "zaxis" |> Option.defaultValue (LinearAxis.init ())

    /// <summary>
    /// Returns a function that sets the z axis object of the given scene.
    /// </summary>
    /// <param name="zAxis">The new z axis object</param>
    static member setZAxis(zAxis: LinearAxis) =
        (fun (scene: Scene) ->
            scene.SetProperty("zaxis", zAxis)
            scene)
