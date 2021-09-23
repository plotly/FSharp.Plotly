namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open DynamicObj
open System
open System.IO
//open FSharp.Care.Collections

open GenericChart
open StyleParam
open System.Runtime.InteropServices
open System.Runtime.CompilerServices

[<AutoOpen>]
module Chart3D =

    [<Extension>]
    type Chart =

        /// Uses points, line or both depending on the mode to represent 3d-data points
        [<Extension>]
        static member Scatter3d
            (
                x, y, z, mode,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?Labels,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?TextFont,
                [<Optional;DefaultParameterValue(null)>] ?Dash,
                [<Optional;DefaultParameterValue(null)>] ?Width
            ) = 
                Trace3D.initScatter3d (Trace3DStyle.Scatter3d(X = x,Y = y,Z=z, Mode=mode) )              
                |> TraceStyle.TraceInfo(?Name=Name,?ShowLegend=ShowLegend,?Opacity=Opacity)
                |> TraceStyle.Line(?Color=Color,?Dash=Dash,?Width=Width)
                |> TraceStyle.Marker(?Color=Color,?Symbol=MarkerSymbol)
                |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
                |> GenericChart.ofTraceObject 
      

        /// Uses points, line or both depending on the mode to represent 3d-data points
        [<Extension>]
        static member Scatter3d(xyz, mode, 
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?Labels,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?TextFont,
                [<Optional;DefaultParameterValue(null)>] ?Dash,
                [<Optional;DefaultParameterValue(null)>] ?Width) = 
            let x,y,z = Seq.unzip3 xyz
            Chart.Scatter3d(x, y, z, mode, ?Name=Name,?ShowLegend=ShowLegend,?MarkerSymbol=MarkerSymbol,?Color=Color,?Opacity=Opacity,?Labels=Labels,?TextPosition=TextPosition,?TextFont=TextFont,?Dash=Dash,?Width=Width) 

        ///
        [<Extension>]
        static member Point3d 
            (
                x, y, z,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?Labels,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?TextFont
            ) =
                // if text position or font is set, then show labels (not only when hovering)
                let changeMode = StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)

                Chart.Scatter3d(
                    x = x, 
                    y = y, 
                    z = z,
                    mode            = changeMode StyleParam.Mode.Markers,
                    ?Name           = Name,
                    ?ShowLegend     = ShowLegend,
                    ?MarkerSymbol   = MarkerSymbol,
                    ?Color          = Color,
                    ?Opacity        = Opacity,
                    ?Labels         = Labels,
                    ?TextPosition   = TextPosition,
                    ?TextFont       = TextFont
                )
        
        ///
        [<Extension>]
        static member Point3d 
            (
                xyz,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?Labels,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?TextFont
            ) =
                let x, y, z = Seq.unzip3 xyz

                Chart.Point3d(
                    x, y, z,
                    ?Name           = Name,
                    ?ShowLegend     = ShowLegend,
                    ?MarkerSymbol   = MarkerSymbol,
                    ?Color          = Color,
                    ?Opacity        = Opacity,
                    ?Labels         = Labels,
                    ?TextPosition   = TextPosition,
                    ?TextFont       = TextFont
                )


        /// Uses points, line or both depending on the mode to represent 3d-data points
        [<Extension>]
        static member Line3d
            (
                x, y, z,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowMarkers,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?Labels,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?TextFont,
                [<Optional;DefaultParameterValue(null)>] ?Dash,
                [<Optional;DefaultParameterValue(null)>] ?Width
            ) = 
                let changeMode = 
                    let isShowMarker =
                        match ShowMarkers with
                        | Some isShow -> isShow
                        | Option.None        -> false
                    StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)                       
                    >> StyleParam.ModeUtils.showMarker (isShowMarker)

                Chart.Scatter3d(
                    x = x,
                    y = y,
                    z = z,
                    mode = changeMode StyleParam.Mode.Lines,
                    ?Name           = Name        ,
                    ?ShowLegend     = ShowLegend  ,
                    ?MarkerSymbol   = MarkerSymbol,
                    ?Color          = Color       ,
                    ?Opacity        = Opacity     ,
                    ?Labels         = Labels      ,
                    ?TextPosition   = TextPosition,
                    ?TextFont       = TextFont    ,
                    ?Dash           = Dash        ,
                    ?Width          = Width       
                )
        
        /// Uses points, line or both depending on the mode to represent 3d-data points
        [<Extension>]
        static member Line3d
            (
                xyz,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowMarkers,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?Labels,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?TextFont,
                [<Optional;DefaultParameterValue(null)>] ?Dash,
                [<Optional;DefaultParameterValue(null)>] ?Width
            ) = 
                let x, y, z = Seq.unzip3 xyz

                Chart.Line3d(
                    x, y, z,
                    ?Name           = Name        ,
                    ?ShowMarkers    = ShowMarkers ,
                    ?ShowLegend     = ShowLegend  ,
                    ?MarkerSymbol   = MarkerSymbol,
                    ?Color          = Color       ,
                    ?Opacity        = Opacity     ,
                    ?Labels         = Labels      ,
                    ?TextPosition   = TextPosition,
                    ?TextFont       = TextFont    ,
                    ?Dash           = Dash        ,
                    ?Width          = Width       
                )

        ///
        [<Extension>]
        static member Bubble3d 
            (
                x, y, z, sizes,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?Labels,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?TextFont
            ) =
                let changeMode = StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)
        
                Trace3D.initScatter3d (
                    Trace3DStyle.Scatter3d(
                        X = x,
                        Y = y, 
                        Z = z,
                        Mode=changeMode StyleParam.Mode.Markers
                    )
                )
                |> TraceStyle.TraceInfo(?Name=Name,?ShowLegend=ShowLegend,?Opacity=Opacity)
                |> TraceStyle.Marker(?Color=Color,?Symbol=MarkerSymbol, MultiSize=sizes)
                |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
                |> GenericChart.ofTraceObject
    
        ///
        [<Extension>]
        static member Bubble3d 
            (
                xyz, sizes,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?Labels,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?TextFont
            ) =
                let x, y, z = Seq.unzip3 xyz

                Chart.Bubble3d(
                    x, y, z, sizes,
                    ?Name           = Name,
                    ?ShowLegend     = ShowLegend,
                    ?MarkerSymbol   = MarkerSymbol,
                    ?Color          = Color,
                    ?Opacity        = Opacity,
                    ?Labels         = Labels,
                    ?TextPosition   = TextPosition,
                    ?TextFont       = TextFont
                )


        /// Uses points, line or both depending on the mode to represent 3d-data points
        [<Extension>]
        static member Surface
            (
                zData,
                [<Optional;DefaultParameterValue(null)>] ?X,
                [<Optional;DefaultParameterValue(null)>] ?Y,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?Contours,
                [<Optional;DefaultParameterValue(null)>] ?ColorScale,
                [<Optional;DefaultParameterValue(null)>] ?ShowScale,
                [<Optional;DefaultParameterValue(null)>] ?ColorBar
            ) = 
            Trace3D.initSurface (
                Trace3DStyle.Surface(
                    ?X=X, 
                    ?Y=Y,
                    Z=zData,
                    ?Contours=Contours,
                    ?ColorScale=ColorScale,
                    ?ShowScale=ShowScale,
                    ?ColorBar=ColorBar 
                )
            )              
            |> TraceStyle.TraceInfo(?Name=Name,?ShowLegend=ShowLegend,?Opacity=Opacity)
            |> GenericChart.ofTraceObject 


        /// Uses points, line or both depending on the mode to represent 3d-data points
        [<Extension>]
        static member Mesh3d
            (
                x, y, z, 
                [<Optional;DefaultParameterValue(null)>] ?I,
                [<Optional;DefaultParameterValue(null)>] ?J,
                [<Optional;DefaultParameterValue(null)>] ?K,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?Contours,
                [<Optional;DefaultParameterValue(null)>] ?ColorScale,
                [<Optional;DefaultParameterValue(null)>] ?ShowScale,
                [<Optional;DefaultParameterValue(null)>] ?ColorBar
            ) = 
            Trace3D.initMesh3d (
                Trace3DStyle.Mesh3d(
                    X   = x,
                    Y   = y,
                    Z   = z,
                    ?I  = I,
                    ?J  = J,
                    ?K  = K
                ) 
            )              
            |> TraceStyle.TraceInfo(?Name=Name,?ShowLegend=ShowLegend,?Opacity=Opacity)
            |> GenericChart.ofTraceObject 

        [<Extension>]
        static member Cone 
            (
                x, y, z, u, v, w,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?ColorScale,
                [<Optional;DefaultParameterValue(null)>] ?ShowScale,
                [<Optional;DefaultParameterValue(null)>] ?ColorBar
            ) =

                Trace3D.initCone(
                    Trace3DStyle.Cone(
                        X = x,
                        Y = y,
                        Z = z,
                        U = u,
                        V = v,
                        W = w,
                        ?Name       = Name,
                        ?ShowLegend = ShowLegend,
                        ?Opacity    = Opacity,
                        ?ColorScale = ColorScale,
                        ?ShowScale  = ShowScale,
                        ?ColorBar   = ColorBar
                    )
                )
                |> TraceStyle.TraceInfo(?Name=Name,?ShowLegend=ShowLegend,?Opacity=Opacity)
                |> GenericChart.ofTraceObject 

        [<Extension>]
        static member Cone 
            (
                coneXYZ, coneUVW,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?ColorScale,
                [<Optional;DefaultParameterValue(null)>] ?ShowScale,
                [<Optional;DefaultParameterValue(null)>] ?ColorBar
            ) =
                let x, y, z = Seq.unzip3 coneXYZ
                let u, v, w = Seq.unzip3 coneUVW

                Chart.Cone(
                    x, y, z, u, v, w,
                    ?Name       = Name          ,
                    ?ShowLegend = ShowLegend    ,
                    ?Opacity    = Opacity       ,
                    ?ColorScale = ColorScale    ,
                    ?ShowScale  = ShowScale     ,
                    ?ColorBar   = ColorBar
                )


        [<Extension>]
        static member StreamTube 
            (
                x, y, z, u, v, w,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?ColorScale,
                [<Optional;DefaultParameterValue(null)>] ?ShowScale,
                [<Optional;DefaultParameterValue(null)>] ?ColorBar,
                [<Optional;DefaultParameterValue(null)>] ?MaxDisplayed: int,
                [<Optional;DefaultParameterValue(null)>] ?Starts: StreamTubeStarts

            ) =

                Trace3D.initStreamTube(
                    Trace3DStyle.StreamTube(
                        X = x,
                        Y = y,
                        Z = z,
                        U = u,
                        V = v,
                        W = w,
                        ?Name           = Name,
                        ?ShowLegend     = ShowLegend,
                        ?Opacity        = Opacity,
                        ?ColorScale     = ColorScale,
                        ?ShowScale      = ShowScale,
                        ?ColorBar       = ColorBar,
                        ?MaxDisplayed   = MaxDisplayed,
                        ?Starts         = Starts
                    )
                )
                |> TraceStyle.TraceInfo(?Name=Name,?ShowLegend=ShowLegend,?Opacity=Opacity)
                |> GenericChart.ofTraceObject 


        [<Extension>]
        static member StreamTube 
            (
                streamTubeXYZ, streamTubeUVW,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?ColorScale,
                [<Optional;DefaultParameterValue(null)>] ?ShowScale,
                [<Optional;DefaultParameterValue(null)>] ?ColorBar,
                [<Optional;DefaultParameterValue(null)>] ?MaxDisplayed: int,
                [<Optional;DefaultParameterValue(null)>] ?Starts: StreamTubeStarts
            ) =
                let x, y, z = Seq.unzip3 streamTubeXYZ
                let u, v, w = Seq.unzip3 streamTubeUVW

                Chart.StreamTube(
                    x, y, z, u, v, w,
                    ?Name           = Name          ,
                    ?ShowLegend     = ShowLegend    ,
                    ?Opacity        = Opacity       ,
                    ?ColorScale     = ColorScale    ,
                    ?ShowScale      = ShowScale     ,
                    ?ColorBar       = ColorBar      ,
                    ?MaxDisplayed   = MaxDisplayed  ,
                    ?Starts         = Starts
                )
        
        
        [<Extension>]
        static member Volume 
            (
                x,y,z,value,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?ColorScale,
                [<Optional;DefaultParameterValue(null)>] ?ShowScale,
                [<Optional;DefaultParameterValue(null)>] ?ColorBar,
                [<Optional;DefaultParameterValue(null)>] ?IsoMin,
                [<Optional;DefaultParameterValue(null)>] ?IsoMax,
                [<Optional;DefaultParameterValue(null)>] ?Caps : Caps,
                [<Optional;DefaultParameterValue(null)>] ?Slices : Slices,
                [<Optional;DefaultParameterValue(null)>] ?Surface : Surface
            ) =
                Trace3D.initVolume(
                    Trace3DStyle.Volume(
                        X = x,
                        Y = y,
                        Z = z,
                        Value = value,
                        ?Name           = Name,
                        ?ShowLegend     = ShowLegend,
                        ?Opacity        = Opacity,
                        ?ColorScale     = ColorScale,
                        ?ShowScale      = ShowScale,
                        ?ColorBar       = ColorBar,
                        ?IsoMin         = IsoMin,
                        ?IsoMax         = IsoMax,
                        ?Caps           = Caps,
                        ?Slices         = Slices,
                        ?Surface        = Surface   
                    )
                )
                |> TraceStyle.TraceInfo(?Name=Name,?ShowLegend=ShowLegend,?Opacity=Opacity)
                |> GenericChart.ofTraceObject 

                
        [<Extension>]
        static member IsoSurface 
            (
                x,y,z,value,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?ColorScale,
                [<Optional;DefaultParameterValue(null)>] ?ShowScale,
                [<Optional;DefaultParameterValue(null)>] ?ColorBar,
                [<Optional;DefaultParameterValue(null)>] ?IsoMin,
                [<Optional;DefaultParameterValue(null)>] ?IsoMax,
                [<Optional;DefaultParameterValue(null)>] ?Caps : Caps,
                [<Optional;DefaultParameterValue(null)>] ?Slices : Slices,
                [<Optional;DefaultParameterValue(null)>] ?Surface : Surface
            ) =
                Trace3D.initIsoSurface(
                    Trace3DStyle.IsoSurface(
                        X = x,
                        Y = y,
                        Z = z,
                        Value = value,
                        ?Name           = Name,
                        ?ShowLegend     = ShowLegend,
                        ?Opacity        = Opacity,
                        ?ColorScale     = ColorScale,
                        ?ShowScale      = ShowScale,
                        ?ColorBar       = ColorBar,
                        ?IsoMin         = IsoMin,
                        ?IsoMax         = IsoMax,
                        ?Caps           = Caps,
                        ?Slices         = Slices,
                        ?Surface        = Surface   
                    )
                )
                |> TraceStyle.TraceInfo(?Name=Name,?ShowLegend=ShowLegend,?Opacity=Opacity)
                |> GenericChart.ofTraceObject 
        