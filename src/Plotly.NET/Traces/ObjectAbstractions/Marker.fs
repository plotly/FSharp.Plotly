namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

/// Marker type inherits from dynamic object
type Marker () =
    inherit DynamicObj ()

    /// Initialized Marker object
    static member init
        (   
            [<Optional;DefaultParameterValue(null)>] ?AutoColorScale    : bool,
            [<Optional;DefaultParameterValue(null)>] ?CAuto             : bool,
            [<Optional;DefaultParameterValue(null)>] ?CMax              : float,
            [<Optional;DefaultParameterValue(null)>] ?CMid              : float,
            [<Optional;DefaultParameterValue(null)>] ?CMin              : float,
            [<Optional;DefaultParameterValue(null)>] ?Color             : Color,
            [<Optional;DefaultParameterValue(null)>] ?Colors            : seq<Color>,
            [<Optional;DefaultParameterValue(null)>] ?ColorAxis         : StyleParam.SubPlotId,
            [<Optional;DefaultParameterValue(null)>] ?ColorBar          : ColorBar,
            [<Optional;DefaultParameterValue(null)>] ?Colorscale        : StyleParam.Colorscale,
            [<Optional;DefaultParameterValue(null)>] ?Gradient          : Gradient,
            [<Optional;DefaultParameterValue(null)>] ?Outline           : Line,
            [<Optional;DefaultParameterValue(null)>] ?Size              : int,
            [<Optional;DefaultParameterValue(null)>] ?MultiSize         : seq<int>,
            [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
            [<Optional;DefaultParameterValue(null)>] ?Pattern           : Pattern,
            [<Optional;DefaultParameterValue(null)>] ?MultiOpacity      : seq<float>,
            [<Optional;DefaultParameterValue(null)>] ?Symbol            : StyleParam.MarkerSymbol,
            [<Optional;DefaultParameterValue(null)>] ?MultiSymbols      : seq<StyleParam.MarkerSymbol>,
            [<Optional;DefaultParameterValue(null)>] ?OutlierColor      : Color,
            [<Optional;DefaultParameterValue(null)>] ?Maxdisplayed      : int,
            [<Optional;DefaultParameterValue(null)>] ?ReverseScale      : bool,
            [<Optional;DefaultParameterValue(null)>] ?ShowScale         : bool,
            [<Optional;DefaultParameterValue(null)>] ?SizeMin           : int,
            [<Optional;DefaultParameterValue(null)>] ?SizeMode          : StyleParam.MarkerSizeMode,
            [<Optional;DefaultParameterValue(null)>] ?SizeRef           : int

        ) =
        Marker () 
        |> Marker.style
            (
                ?AutoColorScale = AutoColorScale,
                ?CAuto          = CAuto         ,
                ?CMax           = CMax          ,
                ?CMid           = CMid          ,
                ?CMin           = CMin          ,
                ?Color          = Color         ,
                ?Colors         = Colors        ,
                ?ColorAxis      = ColorAxis     ,
                ?ColorBar       = ColorBar      ,
                ?Colorscale     = Colorscale    ,
                ?Gradient       = Gradient      ,
                ?Outline        = Outline       ,
                ?Size           = Size          ,
                ?MultiSize      = MultiSize     ,
                ?Opacity        = Opacity       ,
                ?Pattern        = Pattern       ,
                ?MultiOpacity   = MultiOpacity  ,
                ?Symbol         = Symbol        ,
                ?MultiSymbols   = MultiSymbols  ,
                ?OutlierColor   = OutlierColor  ,
                ?Maxdisplayed   = Maxdisplayed  ,
                ?ReverseScale   = ReverseScale  ,
                ?ShowScale      = ShowScale     ,
                ?SizeMin        = SizeMin       ,
                ?SizeMode       = SizeMode      ,
                ?SizeRef        = SizeRef       
            )

    // Applies the styles to Marker()
    static member style
        (   
            [<Optional;DefaultParameterValue(null)>] ?AutoColorScale    : bool,
            [<Optional;DefaultParameterValue(null)>] ?CAuto             : bool,
            [<Optional;DefaultParameterValue(null)>] ?CMax              : float,
            [<Optional;DefaultParameterValue(null)>] ?CMid              : float,
            [<Optional;DefaultParameterValue(null)>] ?CMin              : float,
            [<Optional;DefaultParameterValue(null)>] ?Color             : Color,
            [<Optional;DefaultParameterValue(null)>] ?Colors            : seq<Color>,
            [<Optional;DefaultParameterValue(null)>] ?ColorAxis         : StyleParam.SubPlotId,
            [<Optional;DefaultParameterValue(null)>] ?ColorBar          : ColorBar,
            [<Optional;DefaultParameterValue(null)>] ?Colorscale        : StyleParam.Colorscale,
            [<Optional;DefaultParameterValue(null)>] ?Gradient          : Gradient,
            [<Optional;DefaultParameterValue(null)>] ?Outline           : Line,
            [<Optional;DefaultParameterValue(null)>] ?Size              : int,
            [<Optional;DefaultParameterValue(null)>] ?MultiSize         : seq<int>,
            [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
            [<Optional;DefaultParameterValue(null)>] ?MultiOpacity      : seq<float>,
            [<Optional;DefaultParameterValue(null)>] ?Pattern           : Pattern,
            [<Optional;DefaultParameterValue(null)>] ?Symbol            : StyleParam.MarkerSymbol,
            [<Optional;DefaultParameterValue(null)>] ?MultiSymbols      : seq<StyleParam.MarkerSymbol>,
            [<Optional;DefaultParameterValue(null)>] ?OutlierColor      : Color,
            [<Optional;DefaultParameterValue(null)>] ?Maxdisplayed      : int,
            [<Optional;DefaultParameterValue(null)>] ?ReverseScale      : bool,
            [<Optional;DefaultParameterValue(null)>] ?ShowScale         : bool,
            [<Optional;DefaultParameterValue(null)>] ?SizeMin           : int,
            [<Optional;DefaultParameterValue(null)>] ?SizeMode          : StyleParam.MarkerSizeMode,
            [<Optional;DefaultParameterValue(null)>] ?SizeRef           : int
        ) =
            (fun (marker: Marker) -> 
                
                AutoColorScale              |> DynObj.setValueOpt marker "autocolorscale"
                CAuto                       |> DynObj.setValueOpt marker "cauto"
                CMax                        |> DynObj.setValueOpt marker "cmax"
                CMid                        |> DynObj.setValueOpt marker "cmid"
                CMin                        |> DynObj.setValueOpt marker "cmin"
                Color                       |> DynObj.setValueOpt marker "color"
                Colors                      |> DynObj.setValueOpt marker "colors"
                ColorAxis                   |> DynObj.setValueOptBy marker "coloraxis" StyleParam.SubPlotId.convert
                ColorBar                    |> DynObj.setValueOpt marker "colorbar"
                Colorscale                  |> DynObj.setValueOptBy marker "colorscale" StyleParam.Colorscale.convert
                Gradient                    |> DynObj.setValueOpt marker "gradient"
                Outline                     |> DynObj.setValueOpt marker "line"
                (Size, MultiSize)           |> DynObj.setSingleOrMultiOpt marker "size"
                (Opacity, MultiOpacity)     |> DynObj.setSingleOrMultiOpt marker "opacity"
                Pattern                     |> DynObj.setValueOpt marker "pattern"
                (Symbol, MultiSymbols)      |> DynObj.setSingleOrMultiOptBy marker "symbol" StyleParam.MarkerSymbol.convert
                OutlierColor                |> DynObj.setValueOpt marker "outliercolor"
                Maxdisplayed                |> DynObj.setValueOpt marker "maxdisplayed"
                ReverseScale                |> DynObj.setValueOpt marker "reversescale"
                ShowScale                   |> DynObj.setValueOpt marker "showscale"
                SizeMin                     |> DynObj.setValueOpt marker "sizemin"
                SizeMode                    |> DynObj.setValueOpt marker "sizemode"
                SizeRef                     |> DynObj.setValueOpt marker "sizeref"

                marker
            )



