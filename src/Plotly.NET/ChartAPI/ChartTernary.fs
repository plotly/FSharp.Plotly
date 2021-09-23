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
module ChartTernary =

    [<Extension>]
    type Chart =
        
        static member ScatterTernary
            (
                [<Optional;DefaultParameterValue(null)>] ?A             : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?B             : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?C             : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?Mode          : StyleParam.Mode,
                [<Optional;DefaultParameterValue(null)>] ?Sum           : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?Labels        : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?Name          : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend    : bool,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol  : StyleParam.MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?Color         : Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity       : float,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition  : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?TextFont      : Font,
                [<Optional;DefaultParameterValue(null)>] ?Dash          : StyleParam.DrawingStyle,
                [<Optional;DefaultParameterValue(null)>] ?Width         : float 

            ) =
                TraceTernary.initScatterTernary(
                    TraceTernaryStyle.ScatterTernary(
                        ?A      = A,
                        ?B      = B,
                        ?C      = C,
                        ?Mode   = Mode,
                        ?Sum    = Sum
                    )
                )
                |> TraceStyle.TraceInfo(?Name=Name,?ShowLegend=ShowLegend,?Opacity=Opacity)
                |> TraceStyle.Line(?Color=Color,?Dash=Dash,?Width=Width)
                |> TraceStyle.Marker(?Color=Color,?Symbol=MarkerSymbol)
                |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
                |> GenericChart.ofTraceObject

        static member ScatterTernary
            (
                abc,
                [<Optional;DefaultParameterValue(null)>] ?Mode          : StyleParam.Mode,
                [<Optional;DefaultParameterValue(null)>] ?Sum           : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?Labels        : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?Name          : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend    : bool,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol  : StyleParam.MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?Color         : Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity       : float,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition  : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?TextFont      : Font,
                [<Optional;DefaultParameterValue(null)>] ?Dash          : StyleParam.DrawingStyle,
                [<Optional;DefaultParameterValue(null)>] ?Width         : float 
            ) =
                let a,b,c = Seq.unzip3 abc
                Chart.ScatterTernary(
                    A             = a           ,
                    B             = b           ,
                    C             = c           ,
                    ?Mode         = Mode        ,
                    ?Sum          = Sum         ,
                    ?Labels       = Labels      ,
                    ?Name         = Name        ,
                    ?ShowLegend   = ShowLegend  ,
                    ?MarkerSymbol = MarkerSymbol,
                    ?Color        = Color       ,
                    ?Opacity      = Opacity     ,
                    ?TextPosition = TextPosition,
                    ?TextFont     = TextFont    ,
                    ?Dash         = Dash        ,
                    ?Width        = Width       
                )

        static member PointTernary
            (
                [<Optional;DefaultParameterValue(null)>] ?A             : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?B             : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?C             : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?Sum           : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?Labels        : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?Name          : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend    : bool,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol  : StyleParam.MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?Color         : Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity       : float,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition  : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?TextFont      : Font
            ) =

                let changeMode = StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)

                TraceTernary.initScatterTernary(
                    TraceTernaryStyle.ScatterTernary(
                        ?A      = A,
                        ?B      = B,
                        ?C      = C,
                        Mode    = changeMode StyleParam.Mode.Markers, 
                        ?Sum    = Sum
                    )
                )
                |> TraceStyle.TraceInfo(?Name=Name,?ShowLegend=ShowLegend,?Opacity=Opacity)
                |> TraceStyle.Marker(?Color=Color,?Symbol=MarkerSymbol)
                |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
                |> GenericChart.ofTraceObject

        static member PointTernary
            (
                abc,
                [<Optional;DefaultParameterValue(null)>] ?Labels        : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?Name          : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend    : bool,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol  : StyleParam.MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?Color         : Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity       : float,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition  : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?TextFont      : Font

            ) =
                let changeMode = StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)
                let a,b,c = Seq.unzip3 abc

                TraceTernary.initScatterTernary(
                    TraceTernaryStyle.ScatterTernary(
                        A       = a,
                        B       = b,
                        C       = c,
                        Mode    = changeMode StyleParam.Mode.Markers
                    )
                )
                |> TraceStyle.TraceInfo(?Name=Name,?ShowLegend=ShowLegend,?Opacity=Opacity)
                |> TraceStyle.Marker(?Color=Color,?Symbol=MarkerSymbol)
                |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
                |> GenericChart.ofTraceObject

        static member LineTernary
            (
                [<Optional;DefaultParameterValue(null)>] ?A             : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?B             : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?C             : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?Sum           : #IConvertible,
                [<Optional;DefaultParameterValue(null)>] ?Labels        : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?Name          : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend    : bool,
                [<Optional;DefaultParameterValue(null)>] ?ShowMarkers   : bool,
                [<Optional;DefaultParameterValue(null)>] ?Dash          : StyleParam.DrawingStyle,
                [<Optional;DefaultParameterValue(null)>] ?Width         : float,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol  : StyleParam.MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?Color         : Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity       : float,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition  : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?TextFont      : Font
            ) =

                let changeMode = 
                    let isShowMarker =
                        match ShowMarkers with
                        | Some isShow -> isShow
                        | Option.None        -> false
                    StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)                       
                    >> StyleParam.ModeUtils.showMarker (isShowMarker)

                TraceTernary.initScatterTernary(
                    TraceTernaryStyle.ScatterTernary(
                        ?A      = A,
                        ?B      = B,
                        ?C      = C,
                        Mode    = changeMode StyleParam.Mode.Lines, 
                        ?Sum    = Sum
                    )
                )
                |> TraceStyle.Line(?Color=Color,?Dash=Dash,?Width=Width)
                |> TraceStyle.TraceInfo(?Name=Name,?ShowLegend=ShowLegend,?Opacity=Opacity)
                |> TraceStyle.Marker(?Color=Color,?Symbol=MarkerSymbol)
                |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
                |> GenericChart.ofTraceObject

        static member LineTernary
            (
                abc,
                [<Optional;DefaultParameterValue(null)>] ?Labels        : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?Name          : string,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend    : bool,
                [<Optional;DefaultParameterValue(null)>] ?ShowMarkers   : bool,
                [<Optional;DefaultParameterValue(null)>] ?Dash          : StyleParam.DrawingStyle,
                [<Optional;DefaultParameterValue(null)>] ?Width         : float,
                [<Optional;DefaultParameterValue(null)>] ?MarkerSymbol  : StyleParam.MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?Color         : Color,
                [<Optional;DefaultParameterValue(null)>] ?Opacity       : float,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition  : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?TextFont      : Font
            ) =
                let a,b,c = Seq.unzip3 abc

                let changeMode = 
                    let isShowMarker =
                        match ShowMarkers with
                        | Some isShow -> isShow
                        | Option.None        -> false
                    StyleParam.ModeUtils.showText (TextPosition.IsSome || TextFont.IsSome)                       
                    >> StyleParam.ModeUtils.showMarker (isShowMarker)

                TraceTernary.initScatterTernary(
                    TraceTernaryStyle.ScatterTernary(
                        A       = a,
                        B       = b,
                        C       = c,
                        Mode    = changeMode StyleParam.Mode.Lines
                    )
                )
                |> TraceStyle.Line(?Color=Color,?Dash=Dash,?Width=Width)
                |> TraceStyle.TraceInfo(?Name=Name,?ShowLegend=ShowLegend,?Opacity=Opacity)
                |> TraceStyle.Marker(?Color=Color,?Symbol=MarkerSymbol)
                |> TraceStyle.TextLabel(?Text=Labels,?Textposition=TextPosition,?Textfont=TextFont)
                |> GenericChart.ofTraceObject