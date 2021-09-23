namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open DynamicObj
open System
open System.IO

open GenericChart
open StyleParam
open System.Runtime.InteropServices
open System.Runtime.CompilerServices

[<AutoOpen>]
module ChartPolar =

    [<Extension>]
    type Chart =
        [<Extension>]
        static member internal renderScatterPolarTrace (useWebGL:bool) (style: TracePolar -> TracePolar) =
            if useWebGL then
                TracePolar.initScatterPolarGL style
                |> GenericChart.ofTraceObject
            else
                TracePolar.initScatterPolar style
                |> GenericChart.ofTraceObject

        /// Uses points, line or both depending on the mode to represent data points in a polar chart
        [<Extension>]
        static member ScatterPolar
            (
                r, theta, mode,
                [<Optional;DefaultParameterValue(null)>]  ?Name,
                [<Optional;DefaultParameterValue(null)>]  ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>]  ?MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>]  ?Color,
                [<Optional;DefaultParameterValue(null)>]  ?Opacity,
                [<Optional;DefaultParameterValue(null)>]  ?Labels,
                [<Optional;DefaultParameterValue(null)>]  ?TextPosition,
                [<Optional;DefaultParameterValue(null)>]  ?TextFont,
                [<Optional;DefaultParameterValue(null)>]  ?Dash,
                [<Optional;DefaultParameterValue(null)>]  ?Width,
                [<Optional;DefaultParameterValue(null)>]  ?UseWebGL
            ) = 

                let style = 
                    TracePolarStyle.ScatterPolar(
                        R       = r,
                        Theta   = theta, 
                        Mode    = mode
                    ) 
                    >> TraceStyle.TraceInfo(?Name=Name,?ShowLegend=ShowLegend,?Opacity=Opacity)
                    >> TraceStyle.Line(?Color=Color,?Dash=Dash,?Width=Width)
                    >> TraceStyle.Marker(?Color=Color,?Symbol=MarkerSymbol)
                    >> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
        
                let useWebGL = defaultArg UseWebGL false

                Chart.renderScatterPolarTrace useWebGL style

         /// Uses points, line or both depending on the mode to represent data points in a polar chart
        [<Extension>]
        static member ScatterPolar
            (
                rtheta, mode,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?Labels,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?TextFont,
                [<Optional;DefaultParameterValue(null)>] ?Dash,
                [<Optional;DefaultParameterValue(null)>] ?Width,
                [<Optional;DefaultParameterValue(null)>] ?UseWebGL
            ) = 

                let r,t = Seq.unzip rtheta

                Chart.ScatterPolar(
                    r, t, mode,
                    ?Name=Name,
                    ?ShowLegend=ShowLegend,
                    ?MarkerSymbol=MarkerSymbol,
                    ?Color=Color,
                    ?Opacity=Opacity,
                    ?Labels=Labels,
                    ?TextPosition=TextPosition,
                    ?TextFont=TextFont,
                    ?Dash=Dash,
                    ?Width=Width,
                    ?UseWebGL = UseWebGL
                )

        /// 
        [<Extension>]
        static member PointPolar
            (
                r, theta,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?Labels,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?TextFont,
                [<Optional;DefaultParameterValue(null)>] ?UseWebGL
            ) = 

                let changeMode = StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)
            
                let style = 
                    TracePolarStyle.ScatterPolar(
                        R       = r,
                        Theta   = theta, 
                        Mode    = changeMode StyleParam.Mode.Markers
                    ) 
                    >> TraceStyle.TraceInfo(?Name=Name,?ShowLegend=ShowLegend,?Opacity=Opacity)
                    >> TraceStyle.Marker(?Color=Color,?Symbol=MarkerSymbol)
                    >> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)

                let useWebGL = defaultArg UseWebGL false
            
                Chart.renderScatterPolarTrace useWebGL style

        /// 
        [<Extension>]
        static member PointPolar
            (
                rTheta,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?Labels,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?TextFont,
                [<Optional;DefaultParameterValue(null)>] ?UseWebGL
            ) = 
                let r,t = Seq.unzip rTheta

                Chart.PointPolar(
                    r, t,
                    ?Name           = Name,
                    ?ShowLegend     = ShowLegend,
                    ?MarkerSymbol   = MarkerSymbol,
                    ?Color          = Color,
                    ?Opacity        = Opacity,
                    ?Labels         = Labels,
                    ?TextPosition   = TextPosition,
                    ?TextFont       = TextFont,
                    ?UseWebGL       = UseWebGL
                )
            
        ///
        [<Extension>]
        static member LinePolar 
            (
                r, theta,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?ShowMarkers,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?Labels,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?TextFont,
                [<Optional;DefaultParameterValue(null)>] ?Dash,
                [<Optional;DefaultParameterValue(null)>] ?Width,
                [<Optional;DefaultParameterValue(null)>] ?UseWebGL
            ) =
                let changeMode = 
                    let isShowMarker =
                        match ShowMarkers with
                        | Some isShow -> isShow
                        | Option.None        -> false
                    StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)                       
                    >> StyleParam.ModeUtils.showMarker (isShowMarker)

                let style =
                    TracePolarStyle.ScatterPolar(
                        R       = r,
                        Theta   = theta, 
                        Mode    = changeMode StyleParam.Mode.Lines
                    ) 
                    >> TraceStyle.TraceInfo(?Name=Name,?ShowLegend=ShowLegend,?Opacity=Opacity)
                    >> TraceStyle.Line(?Color=Color,?Dash=Dash,?Width=Width)
                    >> TraceStyle.Marker(?Color=Color,?Symbol=MarkerSymbol)
                    >> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)

                let useWebGL = defaultArg UseWebGL false
            
                Chart.renderScatterPolarTrace useWebGL style

        ///
        [<Extension>]
        static member LinePolar 
            (
                rTheta,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?ShowMarkers,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?Labels,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?TextFont,
                [<Optional;DefaultParameterValue(null)>] ?Dash,
                [<Optional;DefaultParameterValue(null)>] ?Width,
                [<Optional;DefaultParameterValue(null)>] ?UseWebGL
            ) =
                 let r,t = Seq.unzip rTheta

                 Chart.LinePolar(
                    r, t,
                    ?Name           = Name,
                    ?ShowLegend     = ShowLegend,
                    ?ShowMarkers    = ShowMarkers,
                    ?MarkerSymbol   = MarkerSymbol,
                    ?Color          = Color,
                    ?Opacity        = Opacity,
                    ?Labels         = Labels,
                    ?TextPosition   = TextPosition,
                    ?TextFont       = TextFont,
                    ?Dash           = Dash,
                    ?Width          = Width,
                    ?UseWebGL       = UseWebGL
                 )

        ///
        [<Extension>]
        static member SplinePolar 
            (
                r, theta,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?ShowMarkers,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?Labels,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?TextFont,
                [<Optional;DefaultParameterValue(null)>] ?Smoothing,
                [<Optional;DefaultParameterValue(null)>] ?Dash,
                [<Optional;DefaultParameterValue(null)>] ?Width,
                [<Optional;DefaultParameterValue(null)>] ?UseWebGL
            ) =
                let changeMode = 
                    let isShowMarker =
                        match ShowMarkers with
                        | Some isShow -> isShow
                        | Option.None        -> false
                    StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)                       
                    >> StyleParam.ModeUtils.showMarker (isShowMarker)

                let style =
                    TracePolarStyle.ScatterPolar(
                        R       = r,
                        Theta   = theta, 
                        Mode    = changeMode StyleParam.Mode.Lines
                    ) 
                    >> TraceStyle.TraceInfo(?Name=Name,?ShowLegend=ShowLegend,?Opacity=Opacity)
                    >> TraceStyle.Line(?Color=Color,?Dash=Dash,?Width=Width, Shape=StyleParam.Shape.Spline, ?Smoothing=Smoothing)
                    >> TraceStyle.Marker(?Color=Color,?Symbol=MarkerSymbol)
                    >> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)

                let useWebGL = defaultArg UseWebGL false
            
                Chart.renderScatterPolarTrace useWebGL style
        ///
        [<Extension>]
        static member SplinePolar 
            (
                rTheta,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?ShowMarkers,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?Labels,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?TextFont,
                [<Optional;DefaultParameterValue(null)>] ?Smoothing,
                [<Optional;DefaultParameterValue(null)>] ?Dash,
                [<Optional;DefaultParameterValue(null)>] ?Width,
                [<Optional;DefaultParameterValue(null)>] ?UseWebGL
            ) =
                 let r,t = Seq.unzip rTheta

                 Chart.SplinePolar(
                    r, t,
                    ?Name           = Name,
                    ?ShowLegend     = ShowLegend,
                    ?ShowMarkers    = ShowMarkers,
                    ?MarkerSymbol   = MarkerSymbol,
                    ?Color          = Color,
                    ?Opacity        = Opacity,
                    ?Labels         = Labels,
                    ?TextPosition   = TextPosition,
                    ?TextFont       = TextFont,
                    ?Smoothing      = Smoothing,
                    ?Dash           = Dash,
                    ?Width          = Width,
                    ?UseWebGL       = UseWebGL
                 )

        /// 
        [<Extension>]
        static member BubblePolar
            (
                r, theta, sizes:seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?Labels,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?TextFont,
                [<Optional;DefaultParameterValue(null)>] ?UseWebGL
            ) = 

                let changeMode = StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)
            
                let style = 
                    TracePolarStyle.ScatterPolar(
                        R       = r,
                        Theta   = theta, 
                        Mode    = changeMode StyleParam.Mode.Markers
                    ) 
                    >> TraceStyle.TraceInfo(?Name=Name,?ShowLegend=ShowLegend,?Opacity=Opacity)
                    >> TraceStyle.Marker(?Color=Color,?Symbol=MarkerSymbol,MultiSize=sizes)
                    >> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)

                let useWebGL = defaultArg UseWebGL false
            
                Chart.renderScatterPolarTrace useWebGL style

        /// 
        [<Extension>]
        static member BubblePolar
            (
                rThetaSizes:seq<#IConvertible*#IConvertible*#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?Labels,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?TextFont,
                [<Optional;DefaultParameterValue(null)>] ?UseWebGL
            ) = 
                let r,t,sizes = Seq.unzip3 rThetaSizes

                Chart.BubblePolar(
                    r, t, sizes,
                    ?Name           = Name,
                    ?ShowLegend     = ShowLegend,
                    ?MarkerSymbol   = MarkerSymbol,
                    ?Color          = Color,
                    ?Opacity        = Opacity,
                    ?Labels         = Labels,
                    ?TextPosition   = TextPosition,
                    ?TextFont       = TextFont,
                    ?UseWebGL       = UseWebGL
                )

        /// 
        [<Extension>]
        static member BarPolar
            (
                r, theta,
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity,
                [<Optional;DefaultParameterValue(null)>] ?Labels,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?TextFont,
                [<Optional;DefaultParameterValue(null)>] ?Dash,
                [<Optional;DefaultParameterValue(null)>] ?LineWidth
            ) = 
                TracePolar.initBarPolar(
                    TracePolarStyle.BarPolar(
                        R = r, Theta = theta
                    )
                )
                |> TraceStyle.TraceInfo(?Name=Name,?ShowLegend=ShowLegend,?Opacity=Opacity)
                |> TraceStyle.Line(?Color=Color,?Dash=Dash,?Width=LineWidth)
                |> TraceStyle.Marker(?Color=Color)
                |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
                |> GenericChart.ofTraceObject 