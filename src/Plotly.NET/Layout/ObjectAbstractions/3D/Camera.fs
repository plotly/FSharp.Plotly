namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices



type CameraCenter() =
    inherit DynamicObj()

    static member init
        (
            ?X: float,
            ?Y: float,
            ?Z: float
        ) =
        CameraCenter() |> CameraCenter.style (?X = X, ?Y = Y, ?Z = Z)

    static member style
        (
            ?X: float,
            ?Y: float,
            ?Z: float
        ) =

        fun (cameraCenter: CameraCenter) ->
            
            cameraCenter
            |> DynObj.withOptionalProperty "x" X 
            |> DynObj.withOptionalProperty "y" Y 
            |> DynObj.withOptionalProperty "z" Z 

type CameraEye() =
    inherit DynamicObj()

    static member init
        (
            ?X: float,
            ?Y: float,
            ?Z: float
        ) =
        CameraEye() |> CameraEye.style (?X = X, ?Y = Y, ?Z = Z)

    static member style
        (
            ?X: float,
            ?Y: float,
            ?Z: float
        ) =

        fun (cameraEye: CameraEye) ->

            cameraEye
            |> DynObj.withOptionalProperty "x" X 
            |> DynObj.withOptionalProperty "y" Y 
            |> DynObj.withOptionalProperty "z" Z 

type CameraUp() =
    inherit DynamicObj()

    static member init
        (
            ?X: float,
            ?Y: float,
            ?Z: float
        ) =
        CameraUp() |> CameraUp.style (?X = X, ?Y = Y, ?Z = Z)

    static member style
        (
            ?X: float,
            ?Y: float,
            ?Z: float
        ) =

        fun (cameraUp: CameraUp) ->

            cameraUp
            |> DynObj.withOptionalProperty "x" X 
            |> DynObj.withOptionalProperty "y" Y 
            |> DynObj.withOptionalProperty "z" Z 


type CameraProjection() =
    inherit DynamicObj()

    static member init(?ProjectionType: StyleParam.CameraProjectionType) =
        CameraProjection() |> CameraProjection.style (?ProjectionType = ProjectionType)

    static member style(?ProjectionType: StyleParam.CameraProjectionType) =

        fun (cameraProjection: CameraProjection) ->

            cameraProjection |> DynObj.withOptionalPropertyBy "type" ProjectionType StyleParam.CameraProjectionType.convert

            

type Camera() =
    inherit DynamicObj()

    static member init
        (
            ?Center: CameraCenter,
            ?Eye: CameraEye,
            ?Projection: CameraProjection,
            ?Up: CameraUp
        ) =
        Camera() |> Camera.style (?Center = Center, ?Eye = Eye, ?Projection = Projection, ?Up = Up)

    static member style
        (
            ?Center: CameraCenter,
            ?Eye: CameraEye,
            ?Projection: CameraProjection,
            ?Up: CameraUp
        ) =

        fun (camera: Camera) ->

            camera
            |> DynObj.withOptionalProperty "center"     Center    
            |> DynObj.withOptionalProperty "eye"        Eye       
            |> DynObj.withOptionalProperty "projection" Projection
            |> DynObj.withOptionalProperty "up"         Up        

