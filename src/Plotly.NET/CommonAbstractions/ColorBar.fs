namespace Plotly.NET

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

/// The ColorBar object to be used with ColorAxes.
type ColorBar() =
    inherit DynamicObj()

    /// <summary>
    /// Initializes a ColorBar object.
    /// </summary>
    /// <param name="BGColor">Sets the color of padded area.</param>
    /// <param name="BorderColor">Sets the axis line color.</param>
    /// <param name="BorderWidth">Sets the width (in px) or the border enclosing this color bar.</param>
    /// <param name="DTick">Sets the step in-between ticks on this axis. Use with `tick0`. Must be a positive number, or special strings available to "log" and "date" axes. If the axis `type` is "log", then ticks are set every 10^(n"dtick) where n is the tick number. For example, to set a tick mark at 1, 10, 100, 1000, ... set dtick to 1. To set tick marks at 1, 100, 10000, ... set dtick to 2. To set tick marks at 1, 5, 25, 125, 625, 3125, ... set dtick to log_10(5), or 0.69897000433. "log" has several special values; "L&lt;f&gt;", where `f` is a positive number, gives ticks linearly spaced in value (but not position). For example `tick0` = 0.1, `dtick` = "L0.5" will put ticks at 0.1, 0.6, 1.1, 1.6 etc. To show powers of 10 plus small digits between, use "D1" (all digits) or "D2" (only 2 and 5). `tick0` is ignored for "D1" and "D2". If the axis `type` is "date", then you must convert the time to milliseconds. For example, to set the interval between ticks to one day, set `dtick` to 86400000.0. "date" also has special values "M&lt;n&gt;" gives ticks spaced by a number of months. `n` must be a positive integer. To set ticks on the 15th of every third month, set `tick0` to "2000-01-15" and `dtick` to "M3". To set ticks every 4 years, set `dtick` to "M48"</param>
    /// <param name="ExponentFormat">Determines a formatting rule for the tick exponents. For example, consider the number 1,000,000,000. If "none", it appears as 1,000,000,000. If "e", 1e+9. If "E", 1E+9. If "power", 1x10^9 (with 9 in a super script). If "SI", 1G. If "B", 1B.</param>
    /// <param name="LabelAlias">Replacement text for specific tick or hover labels. For example using {US: 'USA', CA: 'Canada'} changes US to USA and CA to Canada. The labels we would have shown must match the keys exactly, after adding any tickprefix or ticksuffix. labelalias can be used with any axis type, and both keys (if needed) and values (if desired) can include html-like tags or MathJax.</param>
    /// <param name="Len">Sets the length of the color bar This measure excludes the padding of both ends. That is, the color bar length is this length minus the padding on both ends.</param>
    /// <param name="LenMode">Determines whether this color bar's length (i.e. the measure in the color variation direction) is set in units of plot "fraction" or in "pixels. Use `len` to set the value.</param>
    /// <param name="MinExponent">Hide SI prefix for 10^n if |n| is below this number. This only has an effect when `tickformat` is "SI" or "B".</param>
    /// <param name="NTicks">Specifies the maximum number of ticks for the particular axis. The actual number of ticks will be chosen automatically to be less than or equal to `nticks`. Has an effect only if `tickmode` is set to "auto".</param>
    /// <param name="Orientation">Sets the orientation of the colorbar.</param>
    /// <param name="OutlineColor">Sets the axis line color.</param>
    /// <param name="OutlineWidth">Sets the width (in px) of the axis line.</param>
    /// <param name="SeparateThousands">If "true", even 4-digit integers are separated</param>
    /// <param name="ShowExponent">If "all", all exponents are shown besides their significands. If "first", only the exponent of the first tick is shown. If "last", only the exponent of the last tick is shown. If "none", no exponents appear.</param>
    /// <param name="ShowTickLabels">Determines whether or not the tick labels are drawn.</param>
    /// <param name="ShowTickPrefix">If "all", all tick labels are displayed with a prefix. If "first", only the first tick is displayed with a prefix. If "last", only the last tick is displayed with a suffix. If "none", tick prefixes are hidden.</param>
    /// <param name="ShowTickSuffix">Same as `showtickprefix` but for tick suffixes.</param>
    /// <param name="Thickness">Sets the thickness of the color bar This measure excludes the size of the padding, ticks and labels.</param>
    /// <param name="ThicknessMode">Determines whether this color bar's thickness (i.e. the measure in the constant color direction) is set in units of plot "fraction" or in "pixels". Use `thickness` to set the value.</param>
    /// <param name="Tick0">Sets the placement of the first tick on this axis. Use with `dtick`. If the axis `type` is "log", then you must take the log of your starting tick (e.g. to set the starting tick to 100, set the `tick0` to 2) except when `dtick`="L&gt;f&lt;" (see `dtick` for more info). If the axis `type` is "date", it should be a date string, like date data. If the axis `type` is "category", it should be a number, using the scale where each category is assigned a serial number from zero in the order it appears.</param>
    /// <param name="TickAngle">Sets the angle of the tick labels with respect to the horizontal. For example, a `tickangle` of -90 draws the tick labels vertically.</param>
    /// <param name="TickColor">Sets the tick color.</param>
    /// <param name="TickFont">Sets the color bar's tick label font</param>
    /// <param name="TickFormat">Sets the tick label formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"</param>
    /// <param name="TickFormatStops">Set rules for customizing TickFormat on different zoom levels</param>
    /// <param name="TickLabelOverflow">Determines how we handle tick labels that would overflow either the graph div or the domain of the axis. The default value for inside tick labels is "hide past domain". In other cases the default is "hide past div".</param>
    /// <param name="TickLabelPosition">Determines where tick labels are drawn.</param>
    /// <param name="TickLabelStep">Sets the spacing between tick labels as compared to the spacing between ticks. A value of 1 (default) means each tick gets a label. A value of 2 means shows every 2nd label. A larger value n means only every nth tick is labeled. `tick0` determines which labels are shown. Not implemented for axes with `type` "log" or "multicategory", or when `tickmode` is "array".</param>    /// <param name="TickLen">Sets the tick length (in px).</param>
    /// <param name="TickMode">Sets the tick mode for this axis. If "auto", the number of ticks is set via `nticks`. If "linear", the placement of the ticks is determined by a starting position `tick0` and a tick step `dtick` ("linear" is the default value if `tick0` and `dtick` are provided). If "array", the placement of the ticks is set via `tickvals` and the tick text is `ticktext`. ("array" is the default value if `tickvals` is provided).</param>
    /// <param name="TickPrefix">Sets a tick label prefix.</param>
    /// <param name="Ticks">Determines whether ticks are drawn or not. If "", this axis' ticks are not drawn. If "outside" ("inside"), this axis' are drawn outside (inside) the axis lines.</param>
    /// <param name="TickSuffix">Sets a tick label suffix.</param>
    /// <param name="TickText">Sets the text displayed at the ticks position via `tickvals`. Only has an effect if `tickmode` is set to "array". Used with `tickvals`.</param>
    /// <param name="TickVals">Sets the values at which ticks on this axis appear. Only has an effect if `tickmode` is set to "array". Used with `ticktext`.</param>
    /// <param name="TickWidth">Sets the tick width (in px).</param>
    /// <param name="Title">Sets the ColorBar title.</param>
    /// <param name="X">Sets the x position of the color bar (in plot fraction).</param>
    /// <param name="XAnchor">Sets this color bar's horizontal position anchor. This anchor binds the `x` position to the "left", "center" or "right" of the color bar.</param>
    /// <param name="XPad">Sets the amount of padding (in px) along the x direction.</param>
    /// <param name="XRef">Sets the container `x` refers to. "container" spans the entire `width` of the plot. "paper" refers to the width of the plotting area only.</param>
    /// <param name="Y">Sets the y position of the color bar (in plot fraction).</param>
    /// <param name="YAnchor">Sets this color bar's vertical position anchor This anchor binds the `y` position to the "top", "middle" or "bottom" of the color bar.</param>
    /// <param name="YPad">Sets the amount of padding (in px) along the y direction.</param>
    /// <param name="YRef">Sets the container `y` refers to. "container" spans the entire `height` of the plot. "paper" refers to the height of the plotting area only.</param>
    static member init
        (
            ?BGColor: Color,
            ?BorderColor: Color,
            ?BorderWidth: float,
            ?DTick: IConvertible,
            ?ExponentFormat: StyleParam.ExponentFormat,
            ?LabelAlias: DynamicObj,
            ?Len: float,
            ?LenMode: StyleParam.UnitMode,
            ?MinExponent: float,
            ?NTicks: int,
            ?Orientation: StyleParam.Orientation,
            ?OutlineColor: Color,
            ?OutlineWidth: float,
            ?SeparateThousands: bool,
            ?ShowExponent: StyleParam.ShowExponent,
            ?ShowTickLabels: bool,
            ?ShowTickPrefix: StyleParam.ShowTickOption,
            ?ShowTickSuffix: StyleParam.ShowTickOption,
            ?Thickness: float,
            ?ThicknessMode: StyleParam.UnitMode,
            ?Tick0: IConvertible,
            ?TickAngle: int,
            ?TickColor: Color,
            ?TickFont: Font,
            ?TickFormat: string,
            ?TickFormatStops: seq<TickFormatStop>,
            ?TickLabelOverflow: StyleParam.TickLabelOverflow,
            ?TickLabelPosition: StyleParam.TickLabelPosition,
            ?TickLabelStep: int,
            ?TickLen: float,
            ?TickMode: StyleParam.TickMode,
            ?TickPrefix: string,
            ?Ticks: StyleParam.TickOptions,
            ?TickSuffix: string,
            ?TickText: seq<#IConvertible>,
            ?TickVals: seq<#IConvertible>,
            ?TickWidth: float,
            ?Title: Title,
            ?X: float,
            ?XAnchor: StyleParam.HorizontalAlign,
            ?XPad: float,
            ?XRef: string,
            ?Y: float,
            ?YAnchor: StyleParam.VerticalAlign,
            ?YPad: float,
            ?YRef: string
        ) =
        ColorBar()
        |> ColorBar.style (
            ?BGColor = BGColor,
            ?BorderColor = BorderColor,
            ?BorderWidth = BorderWidth,
            ?DTick = DTick,
            ?ExponentFormat = ExponentFormat,
            ?LabelAlias = LabelAlias,
            ?Len = Len,
            ?LenMode = LenMode,
            ?MinExponent = MinExponent,
            ?NTicks = NTicks,
            ?Orientation = Orientation,
            ?OutlineColor = OutlineColor,
            ?OutlineWidth = OutlineWidth,
            ?SeparateThousands = SeparateThousands,
            ?ShowExponent = ShowExponent,
            ?ShowTickLabels = ShowTickLabels,
            ?ShowTickPrefix = ShowTickPrefix,
            ?ShowTickSuffix = ShowTickSuffix,
            ?Thickness = Thickness,
            ?ThicknessMode = ThicknessMode,
            ?Tick0 = Tick0,
            ?TickAngle = TickAngle,
            ?TickColor = TickColor,
            ?TickFont = TickFont,
            ?TickFormat = TickFormat,
            ?TickFormatStops = TickFormatStops,
            ?TickLabelOverflow = TickLabelOverflow,
            ?TickLabelPosition = TickLabelPosition,
            ?TickLabelStep = TickLabelStep,
            ?TickLen = TickLen,
            ?TickMode = TickMode,
            ?TickPrefix = TickPrefix,
            ?Ticks = Ticks,
            ?TickSuffix = TickSuffix,
            ?TickText = TickText,
            ?TickVals = TickVals,
            ?TickWidth = TickWidth,
            ?Title = Title,
            ?X = X,
            ?XAnchor = XAnchor,
            ?XPad = XPad,
            ?XRef = XRef,
            ?Y = Y,
            ?YAnchor = YAnchor,
            ?YPad = YPad,
            ?YRef = YRef
        )


    /// <summary>
    /// Create a function that applies the given style parameters to a ColorBar object
    /// </summary>
    /// <param name="BGColor">Sets the color of padded area.</param>
    /// <param name="BorderColor">Sets the axis line color.</param>
    /// <param name="BorderWidth">Sets the width (in px) or the border enclosing this color bar.</param>
    /// <param name="DTick">Sets the step in-between ticks on this axis. Use with `tick0`. Must be a positive number, or special strings available to "log" and "date" axes. If the axis `type` is "log", then ticks are set every 10^(n"dtick) where n is the tick number. For example, to set a tick mark at 1, 10, 100, 1000, ... set dtick to 1. To set tick marks at 1, 100, 10000, ... set dtick to 2. To set tick marks at 1, 5, 25, 125, 625, 3125, ... set dtick to log_10(5), or 0.69897000433. "log" has several special values; "L&lt;f&gt;", where `f` is a positive number, gives ticks linearly spaced in value (but not position). For example `tick0` = 0.1, `dtick` = "L0.5" will put ticks at 0.1, 0.6, 1.1, 1.6 etc. To show powers of 10 plus small digits between, use "D1" (all digits) or "D2" (only 2 and 5). `tick0` is ignored for "D1" and "D2". If the axis `type` is "date", then you must convert the time to milliseconds. For example, to set the interval between ticks to one day, set `dtick` to 86400000.0. "date" also has special values "M&lt;n&gt;" gives ticks spaced by a number of months. `n` must be a positive integer. To set ticks on the 15th of every third month, set `tick0` to "2000-01-15" and `dtick` to "M3". To set ticks every 4 years, set `dtick` to "M48"</param>
    /// <param name="ExponentFormat">Determines a formatting rule for the tick exponents. For example, consider the number 1,000,000,000. If "none", it appears as 1,000,000,000. If "e", 1e+9. If "E", 1E+9. If "power", 1x10^9 (with 9 in a super script). If "SI", 1G. If "B", 1B.</param>
    /// <param name="LabelAlias">Replacement text for specific tick or hover labels. For example using {US: 'USA', CA: 'Canada'} changes US to USA and CA to Canada. The labels we would have shown must match the keys exactly, after adding any tickprefix or ticksuffix. labelalias can be used with any axis type, and both keys (if needed) and values (if desired) can include html-like tags or MathJax.</param>
    /// <param name="Len">Sets the length of the color bar This measure excludes the padding of both ends. That is, the color bar length is this length minus the padding on both ends.</param>
    /// <param name="LenMode">Determines whether this color bar's length (i.e. the measure in the color variation direction) is set in units of plot "fraction" or in "pixels. Use `len` to set the value.</param>
    /// <param name="MinExponent">Hide SI prefix for 10^n if |n| is below this number. This only has an effect when `tickformat` is "SI" or "B".</param>
    /// <param name="NTicks">Specifies the maximum number of ticks for the particular axis. The actual number of ticks will be chosen automatically to be less than or equal to `nticks`. Has an effect only if `tickmode` is set to "auto".</param>
    /// <param name="Orientation">Sets the orientation of the colorbar.</param>
    /// <param name="OutlineColor">Sets the axis line color.</param>
    /// <param name="OutlineWidth">Sets the width (in px) of the axis line.</param>
    /// <param name="SeparateThousands">If "true", even 4-digit integers are separated</param>
    /// <param name="ShowExponent">If "all", all exponents are shown besides their significands. If "first", only the exponent of the first tick is shown. If "last", only the exponent of the last tick is shown. If "none", no exponents appear.</param>
    /// <param name="ShowTickLabels">Determines whether or not the tick labels are drawn.</param>
    /// <param name="ShowTickPrefix">If "all", all tick labels are displayed with a prefix. If "first", only the first tick is displayed with a prefix. If "last", only the last tick is displayed with a suffix. If "none", tick prefixes are hidden.</param>
    /// <param name="ShowTickSuffix">Same as `showtickprefix` but for tick suffixes.</param>
    /// <param name="Thickness">Sets the thickness of the color bar This measure excludes the size of the padding, ticks and labels.</param>
    /// <param name="ThicknessMode">Determines whether this color bar's thickness (i.e. the measure in the constant color direction) is set in units of plot "fraction" or in "pixels". Use `thickness` to set the value.</param>
    /// <param name="Tick0">Sets the placement of the first tick on this axis. Use with `dtick`. If the axis `type` is "log", then you must take the log of your starting tick (e.g. to set the starting tick to 100, set the `tick0` to 2) except when `dtick`="L&gt;f&lt;" (see `dtick` for more info). If the axis `type` is "date", it should be a date string, like date data. If the axis `type` is "category", it should be a number, using the scale where each category is assigned a serial number from zero in the order it appears.</param>
    /// <param name="TickAngle">Sets the angle of the tick labels with respect to the horizontal. For example, a `tickangle` of -90 draws the tick labels vertically.</param>
    /// <param name="TickColor">Sets the tick color.</param>
    /// <param name="TickFont">Sets the color bar's tick label font</param>
    /// <param name="TickFormat">Sets the tick label formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"</param>
    /// <param name="TickFormatStops">Set rules for customizing TickFormat on different zoom levels</param>
    /// <param name="TickLabelOverflow">Determines how we handle tick labels that would overflow either the graph div or the domain of the axis. The default value for inside tick labels is "hide past domain". In other cases the default is "hide past div".</param>
    /// <param name="TickLabelPosition">Determines where tick labels are drawn relative to the ticks. Left and right options are used when `orientation` is *h*, top and bottom when `orientation` is *v*.</param>
    /// <param name="TickLabelStep">Sets the spacing between tick labels as compared to the spacing between ticks. A value of 1 (default) means each tick gets a label. A value of 2 means shows every 2nd label. A larger value n means only every nth tick is labeled. `tick0` determines which labels are shown. Not implemented for axes with `type` "log" or "multicategory", or when `tickmode` is "array".</param>/// <param name="TickLen">Sets the tick length (in px).</param>
    /// <param name="TickMode">Sets the tick mode for this axis. If "auto", the number of ticks is set via `nticks`. If "linear", the placement of the ticks is determined by a starting position `tick0` and a tick step `dtick` ("linear" is the default value if `tick0` and `dtick` are provided). If "array", the placement of the ticks is set via `tickvals` and the tick text is `ticktext`. ("array" is the default value if `tickvals` is provided).</param>
    /// <param name="TickPrefix">Sets a tick label prefix.</param>
    /// <param name="Ticks">Determines whether ticks are drawn or not. If "", this axis' ticks are not drawn. If "outside" ("inside"), this axis' are drawn outside (inside) the axis lines.</param>
    /// <param name="TickSuffix">Sets a tick label suffix.</param>
    /// <param name="TickText">Sets the text displayed at the ticks position via `tickvals`. Only has an effect if `tickmode` is set to "array". Used with `tickvals`.</param>
    /// <param name="TickVals">Sets the values at which ticks on this axis appear. Only has an effect if `tickmode` is set to "array". Used with `ticktext`.</param>
    /// <param name="TickWidth">Sets the tick width (in px).</param>
    /// <param name="Title">Sets the ColorBar title.</param>
    /// <param name="X">Sets the x position of the color bar (in plot fraction). Defaults to 1.02 when `orientation` is *v* and 0.5 when `orientation` is *h*.</param>
    /// <param name="XAnchor">'Sets this color bar's horizontal position anchor. This anchor binds the `x` position to the *left*, *center*, or *right* of the color bar. Defaults to *left* when `orientation` is *v* and *center* when `orientation` is *h*.</param>
    /// <param name="XPad">Sets the amount of padding (in px) along the x direction.</param>
    /// <param name="XRef">Sets the container `x` refers to. "container" spans the entire `width` of the plot. "paper" refers to the width of the plotting area only.</param>
    /// <param name="Y">Sets the y position of the color bar (in plot fraction).Defaults to 0.5 when `orientation` is *v* and 1.02 when `orientation` is *h*.'</param>
    /// <param name="YAnchor">'Sets this color bar\'s vertical position anchor. This anchor binds the `y` position to the *top*, *middle* or *bottom* of the color bar.Defaults to *middle* when `orientation` is *v* and *bottom* when `orientation` is *h*.'</param>
    /// <param name="YPad">Sets the amount of padding (in px) along the y direction.</param>
    /// <param name="YRef">Sets the container `y` refers to. "container" spans the entire `height` of the plot. "paper" refers to the height of the plotting area only.</param>
    static member style
        (
            ?BGColor: Color,
            ?BorderColor: Color,
            ?BorderWidth: float,
            ?DTick: IConvertible,
            ?ExponentFormat: StyleParam.ExponentFormat,
            ?LabelAlias: DynamicObj,
            ?Len: float,
            ?LenMode: StyleParam.UnitMode,
            ?MinExponent: float,
            ?NTicks: int,
            ?Orientation: StyleParam.Orientation,
            ?OutlineColor: Color,
            ?OutlineWidth: float,
            ?SeparateThousands: bool,
            ?ShowExponent: StyleParam.ShowExponent,
            ?ShowTickLabels: bool,
            ?ShowTickPrefix: StyleParam.ShowTickOption,
            ?ShowTickSuffix: StyleParam.ShowTickOption,
            ?Thickness: float,
            ?ThicknessMode: StyleParam.UnitMode,
            ?Tick0: IConvertible,
            ?TickAngle: int,
            ?TickColor: Color,
            ?TickFont: Font,
            ?TickFormat: string,
            ?TickFormatStops: seq<TickFormatStop>,
            ?TickLabelOverflow: StyleParam.TickLabelOverflow,
            ?TickLabelPosition: StyleParam.TickLabelPosition,
            ?TickLabelStep: int,
            ?TickLen: float,
            ?TickMode: StyleParam.TickMode,
            ?TickPrefix: string,
            ?Ticks: StyleParam.TickOptions,
            ?TickSuffix: string,
            ?TickText: seq<#IConvertible>,
            ?TickVals: seq<#IConvertible>,
            ?TickWidth: float,
            ?Title: Title,
            ?X: float,
            ?XAnchor: StyleParam.HorizontalAlign,
            ?XPad: float,
            ?XRef: string,
            ?Y: float,
            ?YAnchor: StyleParam.VerticalAlign,
            ?YPad: float,
            ?YRef: string
        ) =

        (fun (colorBar: ColorBar) ->
            colorBar
            |> DynObj.withOptionalProperty   "bgcolor"            BGColor          
            |> DynObj.withOptionalProperty   "bordercolor"        BorderColor      
            |> DynObj.withOptionalProperty   "borderwidth"        BorderWidth      
            |> DynObj.withOptionalProperty   "dtick"              DTick            
            |> DynObj.withOptionalPropertyBy "exponentformat"     ExponentFormat     StyleParam.ExponentFormat.convert
            |> DynObj.withOptionalProperty   "labelalias"         LabelAlias       
            |> DynObj.withOptionalProperty   "len"                Len              
            |> DynObj.withOptionalPropertyBy "lenmode"            LenMode            StyleParam.UnitMode.convert
            |> DynObj.withOptionalProperty   "min3xponent"        MinExponent      
            |> DynObj.withOptionalProperty   "nticks"             NTicks           
            |> DynObj.withOptionalPropertyBy "orientation"        Orientation        StyleParam.Orientation.convert
            |> DynObj.withOptionalProperty   "outlinecolor"       OutlineColor     
            |> DynObj.withOptionalProperty   "outlinewidth"       OutlineWidth     
            |> DynObj.withOptionalProperty   "separatethousands"  SeparateThousands
            |> DynObj.withOptionalPropertyBy "showexponent"       ShowExponent       StyleParam.ShowExponent.convert
            |> DynObj.withOptionalProperty   "showticklabels"     ShowTickLabels   
            |> DynObj.withOptionalPropertyBy "showtickprefix"     ShowTickPrefix     StyleParam.ShowTickOption.convert
            |> DynObj.withOptionalPropertyBy "showticksuffix"     ShowTickSuffix     StyleParam.ShowTickOption.convert
            |> DynObj.withOptionalProperty   "thickness"          Thickness        
            |> DynObj.withOptionalPropertyBy "thicknessmode"      ThicknessMode      StyleParam.UnitMode.convert
            |> DynObj.withOptionalProperty   "tick0"              Tick0            
            |> DynObj.withOptionalProperty   "tickangle"          TickAngle        
            |> DynObj.withOptionalProperty   "tickcolor"          TickColor        
            |> DynObj.withOptionalProperty   "tickfont"           TickFont         
            |> DynObj.withOptionalProperty   "tickformat"         TickFormat       
            |> DynObj.withOptionalProperty   "tickformatstops"    TickFormatStops  
            |> DynObj.withOptionalPropertyBy "ticklabeloverflow"  TickLabelOverflow  StyleParam.TickLabelOverflow.convert
            |> DynObj.withOptionalPropertyBy "ticklabelposition"  TickLabelPosition  StyleParam.TickLabelPosition.convert
            |> DynObj.withOptionalProperty   "ticklabelstep"      TickLabelStep    
            |> DynObj.withOptionalProperty   "ticklen"            TickLen          
            |> DynObj.withOptionalPropertyBy "tickmode"           TickMode           StyleParam.TickMode.convert
            |> DynObj.withOptionalProperty   "tickprefix"         TickPrefix       
            |> DynObj.withOptionalPropertyBy "ticks"              Ticks              StyleParam.TickOptions.convert
            |> DynObj.withOptionalProperty   "ticksuffix"         TickSuffix       
            |> DynObj.withOptionalProperty   "ticktext"           TickText         
            |> DynObj.withOptionalProperty   "tickvals"           TickVals         
            |> DynObj.withOptionalProperty   "tickwidth"          TickWidth        
            |> DynObj.withOptionalProperty   "title"              Title            
            |> DynObj.withOptionalProperty   "x"                  X                
            |> DynObj.withOptionalPropertyBy "xanchor"            XAnchor            StyleParam.HorizontalAlign.convert
            |> DynObj.withOptionalProperty   "xpad"               XPad             
            |> DynObj.withOptionalProperty   "xref"               XRef             
            |> DynObj.withOptionalProperty   "y"                  Y                
            |> DynObj.withOptionalPropertyBy "yanchor"            YAnchor            StyleParam.VerticalAlign.convert
            |> DynObj.withOptionalProperty   "ypad"               YPad             
            |> DynObj.withOptionalProperty   "yref"               YRef             

        )
