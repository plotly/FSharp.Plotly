namespace Plotly.NET

open System.Runtime.InteropServices
open DynamicObj
open System

/// The line object determines the style of the line in various aspect of plots such as a line connecting datums, outline of layout objects, etc..
type Line() =
    inherit DynamicObj()

    /// <summary>
    /// Returns a new Line object with the given styling.
    /// </summary>
    /// <param name="BackOff">Sets the line back off from the end point of the nth line segment (in px). This option is useful e.g. to avoid overlap with arrowhead markers. With "auto" the lines would trim before markers if `marker.angleref` is set to "previous".</param>
    /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `line.colorscale`. Has an effect only if in `line.color`is set to a numerical array. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
    /// <param name="CAuto">Determines whether or not the color domain is computed with respect to the input data (here in `line.color`) or the bounds set in `line.cmin` and `line.cmax` Has an effect only if in `line.color`is set to a numerical array. Defaults to `false` when `line.cmin` and `line.cmax` are set by the user.</param>
    /// <param name="CMax">Sets the upper bound of the color domain. Has an effect only if in `line.color`is set to a numerical array. Value should have the same units as in `line.color` and if set, `line.cmin` must be set as well.</param>
    /// <param name="CMid">Sets the mid-point of the color domain by scaling `line.cmin` and/or `line.cmax` to be equidistant to this point. Has an effect only if in `line.color`is set to a numerical array. Value should have the same units as in `line.color`. Has no effect when `line.cauto` is `false`.</param>
    /// <param name="CMin">Sets the lower bound of the color domain. Has an effect only if in `line.color`is set to a numerical array. Value should have the same units as in `line.color` and if set, `line.cmax` must be set as well.</param>
    /// <param name="Color">Sets the line color.</param>
    /// <param name="ColorAxis">Sets a reference to a shared color axis. References to these shared color axes are "coloraxis", "coloraxis2", "coloraxis3", etc. Settings for these shared color axes are set in the layout, under `layout.coloraxis`, `layout.coloraxis2`, etc. Note that multiple color scales can be linked to the same color axis.</param>
    /// <param name="Colorscale">Sets the line colorscale</param>
    /// <param name="ReverseScale">Reverses the color mapping if true.</param>
    /// <param name="ShowScale">Whether or not to show the color bar</param>
    /// <param name="ColorBar">Sets the colorbar.</param>
    /// <param name="Dash">Sets the dash style of lines. Set to a dash type string ("solid", "dot", "dash", "longdash", "dashdot", or "longdashdot") or a dash length list in px (eg "5px,10px,2px,2px").</param>
    /// <param name="Shape">Determines the line shape. With "spline" the lines are drawn using spline interpolation. The other available values correspond to step-wise line shapes.</param>
    /// <param name="Simplify">Simplifies lines by removing nearly-collinear points. When transitioning lines, it may be desirable to disable this so that the number of points along the resulting SVG path is unaffected.</param>
    /// <param name="Smoothing">Has an effect only if `shape` is set to "spline" Sets the amount of smoothing. "0" corresponds to no smoothing (equivalent to a "linear" shape).</param>
    /// <param name="Width">Sets the line width (in px).</param>
    /// <param name="MultiWidth">Sets the individual line width (in px).</param>
    /// <param name="OutlierColor">Sets the color of the outline of outliers</param>
    /// <param name="OutlierWidth">Sets the width of the outline of outliers</param>
    static member init
        (
            ?BackOff: StyleParam.BackOff,
            ?AutoColorScale: bool,
            ?CAuto: bool,
            ?CMax: float,
            ?CMid: float,
            ?CMin: float,
            ?Color: Color,
            ?ColorAxis: StyleParam.SubPlotId,
            ?Colorscale: StyleParam.Colorscale,
            ?ReverseScale: bool,
            ?ShowScale: bool,
            ?ColorBar: ColorBar,
            ?Dash: StyleParam.DrawingStyle,
            ?Shape: StyleParam.Shape,
            ?Simplify: bool,
            ?Smoothing: float,
            ?Width: float,
            ?MultiWidth: seq<float>,
            ?OutlierColor: Color,
            ?OutlierWidth: float
        ) =
        Line()
        |> Line.style (
            ?BackOff = BackOff,
            ?AutoColorScale = AutoColorScale,
            ?CAuto = CAuto,
            ?CMax = CMax,
            ?CMid = CMid,
            ?CMin = CMin,
            ?Color = Color,
            ?ColorAxis = ColorAxis,
            ?Colorscale = Colorscale,
            ?ReverseScale = ReverseScale,
            ?ShowScale = ShowScale,
            ?ColorBar = ColorBar,
            ?Dash = Dash,
            ?Shape = Shape,
            ?Simplify = Simplify,
            ?Smoothing = Smoothing,
            ?Width = Width,
            ?MultiWidth = MultiWidth,
            ?OutlierColor = OutlierColor,
            ?OutlierWidth = OutlierWidth
        )

    /// <summary>
    /// Returns a function that applies the given styles to a Line object.
    /// </summary>
    /// <param name="BackOff">Sets the line back off from the end point of the nth line segment (in px). This option is useful e.g. to avoid overlap with arrowhead markers. With "auto" the lines would trim before markers if `marker.angleref` is set to "previous".</param>
    /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `line.colorscale`. Has an effect only if in `line.color`is set to a numerical array. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
    /// <param name="CAuto">Determines whether or not the color domain is computed with respect to the input data (here in `line.color`) or the bounds set in `line.cmin` and `line.cmax` Has an effect only if in `line.color`is set to a numerical array. Defaults to `false` when `line.cmin` and `line.cmax` are set by the user.</param>
    /// <param name="CMax">Sets the upper bound of the color domain. Has an effect only if in `line.color`is set to a numerical array. Value should have the same units as in `line.color` and if set, `line.cmin` must be set as well.</param>
    /// <param name="CMid">Sets the mid-point of the color domain by scaling `line.cmin` and/or `line.cmax` to be equidistant to this point. Has an effect only if in `line.color`is set to a numerical array. Value should have the same units as in `line.color`. Has no effect when `line.cauto` is `false`.</param>
    /// <param name="CMin">Sets the lower bound of the color domain. Has an effect only if in `line.color`is set to a numerical array. Value should have the same units as in `line.color` and if set, `line.cmax` must be set as well.</param>
    /// <param name="Color">Sets the line color.</param>
    /// <param name="ColorAxis">Sets a reference to a shared color axis. References to these shared color axes are "coloraxis", "coloraxis2", "coloraxis3", etc. Settings for these shared color axes are set in the layout, under `layout.coloraxis`, `layout.coloraxis2`, etc. Note that multiple color scales can be linked to the same color axis.</param>
    /// <param name="Colorscale">Sets the line colorscale</param>
    /// <param name="ReverseScale">Reverses the color mapping if true.</param>
    /// <param name="ShowScale">Whether or not to show the color bar</param>
    /// <param name="ColorBar">Sets the colorbar.</param>
    /// <param name="Dash">Sets the dash style of lines. Set to a dash type string ("solid", "dot", "dash", "longdash", "dashdot", or "longdashdot") or a dash length list in px (eg "5px,10px,2px,2px").</param>
    /// <param name="Shape">Determines the line shape. With "spline" the lines are drawn using spline interpolation. The other available values correspond to step-wise line shapes.</param>
    /// <param name="Simplify">Simplifies lines by removing nearly-collinear points. When transitioning lines, it may be desirable to disable this so that the number of points along the resulting SVG path is unaffected.</param>
    /// <param name="Smoothing">Has an effect only if `shape` is set to "spline" Sets the amount of smoothing. "0" corresponds to no smoothing (equivalent to a "linear" shape).</param>
    /// <param name="Width">Sets the line width (in px).</param>
    /// <param name="MultiWidth">Sets the individual line width (in px).</param>
    /// <param name="OutlierColor">Sets the color of the outline of outliers</param>
    /// <param name="OutlierWidth">Sets the width of the outline of outliers</param>
    static member style
        (
            ?BackOff: StyleParam.BackOff,
            ?AutoColorScale: bool,
            ?CAuto: bool,
            ?CMax: float,
            ?CMid: float,
            ?CMin: float,
            ?Color: Color,
            ?ColorAxis: StyleParam.SubPlotId,
            ?Colorscale: StyleParam.Colorscale,
            ?ReverseScale: bool,
            ?ShowScale: bool,
            ?ColorBar: ColorBar,
            ?Dash: StyleParam.DrawingStyle,
            ?Shape: StyleParam.Shape,
            ?Simplify: bool,
            ?Smoothing: float,
            ?Width: float,
            ?MultiWidth: seq<float>,
            ?OutlierColor: Color,
            ?OutlierWidth: float
        ) =
        (fun (line: Line) ->
            line
            |> DynObj.withOptionalPropertyBy            "backoff"        BackOff              StyleParam.BackOff.convert
            |> DynObj.withOptionalProperty              "color"          Color              
            |> DynObj.withOptionalSingleOrMultiProperty "width"          (Width, MultiWidth)
            |> DynObj.withOptionalPropertyBy            "shape"          Shape                StyleParam.Shape.convert
            |> DynObj.withOptionalProperty              "smoothing"      Smoothing          
            |> DynObj.withOptionalPropertyBy            "dash"           Dash                 StyleParam.DrawingStyle.convert
            |> DynObj.withOptionalProperty              "outliercolor"   OutlierColor       
            |> DynObj.withOptionalProperty              "outlierwidth"   OutlierWidth       
            |> DynObj.withOptionalProperty              "autocolorscale" AutoColorScale     
            |> DynObj.withOptionalProperty              "cauto"          CAuto              
            |> DynObj.withOptionalProperty              "cmax"           CMax               
            |> DynObj.withOptionalProperty              "cmid"           CMid               
            |> DynObj.withOptionalProperty              "cmin"           CMin               
            |> DynObj.withOptionalProperty              "color"          Color              
            |> DynObj.withOptionalPropertyBy            "coloraxis"      ColorAxis            StyleParam.SubPlotId.convert
            |> DynObj.withOptionalPropertyBy            "colorscale"     Colorscale           StyleParam.Colorscale.convert
            |> DynObj.withOptionalProperty              "reversescale"   ReverseScale       
            |> DynObj.withOptionalProperty              "showscale"      ShowScale          
            |> DynObj.withOptionalProperty              "colorbar"       ColorBar           
            |> DynObj.withOptionalProperty              "simplify"       Simplify           

        )
