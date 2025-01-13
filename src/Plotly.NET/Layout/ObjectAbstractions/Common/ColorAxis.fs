namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

type ColorAxis() =
    inherit DynamicObj()

    /// <summary>
    /// Initializes a ColorAxis object
    /// </summary>
    /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `colorscale`. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
    /// <param name="CAuto">Determines whether or not the color domain is computed with respect to the input data (here corresponding trace color array(s)) or the bounds set in `cmin` and `cmax` Defaults to `false` when `cmin` and `cmax` are set by the user.</param>
    /// <param name="CMin">Sets the lower bound of the color domain. Value should have the same units as corresponding trace color array(s) and if set, `cmax` must be set as well.</param>
    /// <param name="CMid">Sets the mid-point of the color domain by scaling `cmin` and/or `cmax` to be equidistant to this point. Value should have the same units as corresponding trace color array(s). Has no effect when `cauto` is `false`.</param>
    /// <param name="CMax">Sets the upper bound of the color domain. Value should have the same units as corresponding trace color array(s) and if set, `cmin` must be set as well.</param>
    /// <param name="ColorBar">Sets the colorbar associated with this color axis.</param>
    /// <param name="ColorScale">Sets the colorscale. The colorscale must be an array containing arrays mapping a normalized value to an rgb, rgba, hex, hsl, hsv, or named color string. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 'rgb(0,0,255)'], [1, 'rgb(255,0,0)']]`. To control the bounds of the colorscale in color space, use`cmin` and `cmax`. Alternatively, `colorscale` may be a palette name string of the following list: Blackbody,Bluered,Blues,Cividis,Earth,Electric,Greens,Greys,Hot,Jet,Picnic,Portland,Rainbow,RdBu,Reds,Viridis,YlGnBu,YlOrRd.</param>
    /// <param name="ShowScale">Reverses the color mapping if true. If true, `cmin` will correspond to the last color in the array and `cmax` will correspond to the first color.</param>
    /// <param name="ReverseScale">Determines whether or not a colorbar is displayed for this trace.</param>
    static member init
        (
            ?AutoColorScale: bool,
            ?CAuto: float,
            ?CMin: float,
            ?CMid: float,
            ?CMax: float,
            ?ColorBar: ColorBar,
            ?ColorScale: StyleParam.Colorscale,
            ?ShowScale: bool,
            ?ReverseScale: bool
        ) =

        ColorAxis()
        |> ColorAxis.style (
            ?AutoColorScale = AutoColorScale,
            ?CAuto = CAuto,
            ?CMin = CMin,
            ?CMid = CMid,
            ?CMax = CMax,
            ?ColorBar = ColorBar,
            ?ColorScale = ColorScale,
            ?ShowScale = ShowScale,
            ?ReverseScale = ReverseScale
        )

    /// <summary>
    /// Creates a function that applies the given style parameters to a ColorAxis object
    /// </summary>
    /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `colorscale`. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
    /// <param name="CAuto">Determines whether or not the color domain is computed with respect to the input data (here corresponding trace color array(s)) or the bounds set in `cmin` and `cmax` Defaults to `false` when `cmin` and `cmax` are set by the user.</param>
    /// <param name="CMin">Sets the lower bound of the color domain. Value should have the same units as corresponding trace color array(s) and if set, `cmax` must be set as well.</param>
    /// <param name="CMid">Sets the mid-point of the color domain by scaling `cmin` and/or `cmax` to be equidistant to this point. Value should have the same units as corresponding trace color array(s). Has no effect when `cauto` is `false`.</param>
    /// <param name="CMax">Sets the upper bound of the color domain. Value should have the same units as corresponding trace color array(s) and if set, `cmin` must be set as well.</param>
    /// <param name="ColorBar">Sets the colorbar associated with this color axis.</param>
    /// <param name="ColorScale">Sets the colorscale. The colorscale must be an array containing arrays mapping a normalized value to an rgb, rgba, hex, hsl, hsv, or named color string. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 'rgb(0,0,255)'], [1, 'rgb(255,0,0)']]`. To control the bounds of the colorscale in color space, use`cmin` and `cmax`. Alternatively, `colorscale` may be a palette name string of the following list: Blackbody,Bluered,Blues,Cividis,Earth,Electric,Greens,Greys,Hot,Jet,Picnic,Portland,Rainbow,RdBu,Reds,Viridis,YlGnBu,YlOrRd.</param>
    /// <param name="ShowScale">Reverses the color mapping if true. If true, `cmin` will correspond to the last color in the array and `cmax` will correspond to the first color.</param>
    /// <param name="ReverseScale">Determines whether or not a colorbar is displayed for this trace.</param>
    static member style
        (
            ?AutoColorScale: bool,
            ?CAuto: float,
            ?CMin: float,
            ?CMid: float,
            ?CMax: float,
            ?ColorBar: ColorBar,
            ?ColorScale: StyleParam.Colorscale,
            ?ShowScale: bool,
            ?ReverseScale: bool
        ) =
        fun (ca: ColorAxis) ->

            ca
            |> DynObj.withOptionalProperty "autocolorscale" AutoColorScale
            |> DynObj.withOptionalProperty "cauto" CAuto
            |> DynObj.withOptionalProperty "cmin" CMin
            |> DynObj.withOptionalProperty "cmid" CMid
            |> DynObj.withOptionalProperty "cmax" CMax
            |> DynObj.withOptionalProperty "colorbar" ColorBar
            |> DynObj.withOptionalPropertyBy "colorscale" ColorScale StyleParam.Colorscale.convert
            |> DynObj.withOptionalProperty "showscale" ShowScale
            |> DynObj.withOptionalProperty "reversescale" ReverseScale

