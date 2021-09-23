namespace Plotly.NET

open System.Runtime.InteropServices
open DynamicObj
open System

/// Line type inherits from dynamic object
type Line () =
    inherit DynamicObj ()

    /// Initialized Line object
    static member init
        (
            [<Optional;DefaultParameterValue(null)>] ?Width,
            [<Optional;DefaultParameterValue(null)>] ?Color,
            [<Optional;DefaultParameterValue(null)>] ?Shape,
            [<Optional;DefaultParameterValue(null)>] ?Dash,
            [<Optional;DefaultParameterValue(null)>] ?Smoothing,
            [<Optional;DefaultParameterValue(null)>] ?Colorscale,
            [<Optional;DefaultParameterValue(null)>] ?OutlierColor,
            [<Optional;DefaultParameterValue(null)>] ?OutlierWidth

        ) =
            Line () 
            |> Line.style
                (
                    ?Color      = Color     ,
                    ?Width      = Width     ,
                    ?Shape      = Shape     ,
                    ?Smoothing  = Smoothing ,
                    ?Dash       = Dash      ,
                    ?Colorscale = Colorscale,
                    ?OutlierColor = OutlierColor,
                    ?OutlierWidth = OutlierWidth
                )


    // Applies the styles to Line()
    static member style
        (
            [<Optional;DefaultParameterValue(null)>] ?Color             : Color,
            [<Optional;DefaultParameterValue(null)>] ?Width             : float,
            [<Optional;DefaultParameterValue(null)>] ?MultiWidths       : seq<float>,
            [<Optional;DefaultParameterValue(null)>] ?Shape             : StyleParam.Shape,
            [<Optional;DefaultParameterValue(null)>] ?Dash              : StyleParam.DrawingStyle,
            [<Optional;DefaultParameterValue(null)>] ?Smoothing         : float,
            [<Optional;DefaultParameterValue(null)>] ?OutlierColor      : Color,
            [<Optional;DefaultParameterValue(null)>] ?OutlierWidth      : float,
            [<Optional;DefaultParameterValue(null)>] ?AutoColorScale    : bool,
            [<Optional;DefaultParameterValue(null)>] ?CAuto             : bool,
            [<Optional;DefaultParameterValue(null)>] ?CMax              : float,
            [<Optional;DefaultParameterValue(null)>] ?CMid              : float,
            [<Optional;DefaultParameterValue(null)>] ?CMin              : float,
            [<Optional;DefaultParameterValue(null)>] ?ColorAxis         : StyleParam.SubPlotId,
            [<Optional;DefaultParameterValue(null)>] ?Colorscale        : StyleParam.Colorscale,
            [<Optional;DefaultParameterValue(null)>] ?ReverseScale      : bool

        ) =
            (fun (line:Line) -> 
                Color               |> DynObj.setValueOpt   line "color"
                (Width,MultiWidths) |> DynObj.setSingleOrMultiOpt line "width"
                Shape               |> DynObj.setValueOptBy line "shape" StyleParam.Shape.convert
                Smoothing           |> DynObj.setValueOpt   line "smoothing"
                Dash                |> DynObj.setValueOptBy line "dash" StyleParam.DrawingStyle.convert
                OutlierColor        |> DynObj.setValueOpt   line "outliercolor"
                OutlierWidth        |> DynObj.setValueOpt   line "outlierwidth"
                AutoColorScale      |> DynObj.setValueOpt line "autocolorscale"
                CAuto               |> DynObj.setValueOpt line "cauto"
                CMax                |> DynObj.setValueOpt line "cmax"
                CMid                |> DynObj.setValueOpt line "cmid"
                CMin                |> DynObj.setValueOpt line "cmin"
                Color               |> DynObj.setValueOpt line "color"
                ColorAxis           |> DynObj.setValueOptBy line "coloraxis" StyleParam.SubPlotId.convert
                Colorscale          |> DynObj.setValueOptBy line "colorscale" StyleParam.Colorscale.convert
                ReverseScale        |> DynObj.setValueOpt line "reversescale"

                // out -> 
                line
            )



               