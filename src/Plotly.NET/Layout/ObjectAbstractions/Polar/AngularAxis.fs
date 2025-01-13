namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices


/// <summary>Angular axes can be used as a scale for the angular coordinates in polar plots.</summary>
type AngularAxis() =
    inherit DynamicObj()

    /// <summary>
    /// Initialize an AngularAxis object that can be used as a angular scale for polar coordinates.
    /// </summary>
    /// <param name="Visible">A single toggle to hide the axis while preserving interaction like dragging. Default is true when a cheater plot is present on the axis, otherwise false</param>
    /// <param name="AxisType">Sets the angular axis type. If "linear", set `thetaunit` to determine the unit in which axis value are shown. If "category, use `period` to set the number of integer coordinates around polar axis.</param>
    /// <param name="AutoTypeNumbers">Using "strict" a numeric string in trace data is not converted to a number. Using "convert types" a numeric string in trace data may be treated as a number during automatic axis `type` detection. Defaults to layout.autotypenumbers.</param>
    /// <param name="CategoryOrder">Specifies the ordering logic for the case of categorical variables. By default, plotly uses "trace", which specifies the order that is present in the data supplied. Set `categoryorder` to "category ascending" or "category descending" if order should be determined by the alphanumerical order of the category names. Set `categoryorder` to "array" to derive the ordering from the attribute `categoryarray`. If a category is not found in the `categoryarray` array, the sorting behavior for that attribute will be identical to the "trace" mode. The unspecified categories will follow the categories in `categoryarray`. Set `categoryorder` to "total ascending" or "total descending" if order should be determined by the numerical order of the values. Similarly, the order can be determined by the min, max, sum, mean or median of all the values.</param>
    /// <param name="CategoryArray">Sets the order in which categories on this axis appear. Only has an effect if `categoryorder` is set to "array". Used with `categoryorder`.</param>
    /// <param name="ThetaUnit">Sets the format unit of the formatted "theta" values. Has an effect only when `angularaxis.type` is "linear".</param>
    /// <param name="Period">Set the angular period. Has an effect only when `angularaxis.type` is "category".</param>
    /// <param name="Direction">Sets the direction corresponding to positive angles.</param>
    /// <param name="Rotation">Sets that start position (in degrees) of the angular axis By default, polar subplots with `direction` set to "counterclockwise" get a `rotation` of "0" which corresponds to due East (like what mathematicians prefer). In turn, polar with `direction` set to "clockwise" get a rotation of "90" which corresponds to due North (like on a compass),</param>
    /// <param name="HoverFormat">Sets the hover text formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-3.x-api-reference/blob/master/Formatting.md#d3_format. And for dates see: https://github.com/d3/d3-time-format#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with TickFormat "%H~%M~%S.%2f" would display "09~15~23.46"</param>
    /// <param name="UIRevision">Controls persistence of user-driven changes in axis `rotation`. Defaults to `polar&lt;N&gt;.uirevision`.</param>
    /// <param name="Color">Sets default for all colors associated with this axis all at once: line, font, tick, and grid colors. Grid color is lightened by blending this with the plot background Individual pieces can override this.</param>
    /// <param name="ShowLine">Determines whether or not a line bounding this axis is drawn.</param>
    /// <param name="LineColor">Sets the axis line color.</param>
    /// <param name="LineWidth">Sets the width (in px) of the axis line.</param>
    /// <param name="ShowGrid">Determines whether or not grid lines are drawn. If "true", the grid lines are drawn at every tick mark.</param>
    /// <param name="GridColor">Sets the color of the grid lines.</param>
    /// <param name="GridDash">Sets the dash style of lines. Set to a dash type string ("solid", "dot", "dash", "longdash", "dashdot", or "longdashdot") or a dash length list in px (eg "5px,10px,2px,2px").</param>
    /// <param name="GridWidth">Sets the width (in px) of the grid lines.</param>
    /// <param name="TickMode">Sets the tick mode for this axis. If "auto", the number of ticks is set via `nticks`. If "linear", the placement of the ticks is determined by a starting position `tick0` and a tick step `dtick` ("linear" is the default value if `tick0` and `dtick` are provided). If "array", the placement of the ticks is set via `TickVals` and the tick text is `TickText`. ("array" is the default value if `TickVals` is provided).</param>
    /// <param name="NTicks">Specifies the maximum number of ticks for the particular axis. The actual number of ticks will be chosen automatically to be less than or equal to `nticks`. Has an effect only if `tickmode` is set to "auto".</param>
    /// <param name="Tick0">Sets the placement of the first tick on this axis. Use with `dtick`. If the axis `type` is "log", then you must take the log of your starting tick (e.g. to set the starting tick to 100, set the `tick0` to 2) except when `dtick`="L&lt;f&gt;" (see `dtick` for more info). If the axis `type` is "date", it should be a date string, like date data. If the axis `type` is "category", it should be a number, using the scale where each category is assigned a serial number from zero in the order it appears.</param>
    /// <param name="DTick">Sets the step in-between ticks on this axis. Use with `tick0`. Must be a positive number, or special strings available to "log" and "date" axes. If the axis `type` is "log", then ticks are set every 10^(n"dtick) where n is the tick number. For example, to set a tick mark at 1, 10, 100, 1000, ... set dtick to 1. To set tick marks at 1, 100, 10000, ... set dtick to 2. To set tick marks at 1, 5, 25, 125, 625, 3125, ... set dtick to log_10(5), or 0.69897000433. "log" has several special values; "L&lt;f&gt;", where `f` is a positive number, gives ticks linearly spaced in value (but not position). For example `tick0` = 0.1, `dtick` = "L0.5" will put ticks at 0.1, 0.6, 1.1, 1.6 etc. To show powers of 10 plus small digits between, use "D1" (all digits) or "D2" (only 2 and 5). `tick0` is ignored for "D1" and "D2". If the axis `type` is "date", then you must convert the time to milliseconds. For example, to set the interval between ticks to one day, set `dtick` to 86400000.0. "date" also has special values "M&lt;n&gt;" gives ticks spaced by a number of months. `n` must be a positive integer. To set ticks on the 15th of every third month, set `tick0` to "2000-01-15" and `dtick` to "M3". To set ticks every 4 years, set `dtick` to "M48"</param>
    /// <param name="TickVals">Sets the values at which ticks on this axis appear. Only has an effect if `tickmode` is set to "array". Used with `TickText`.</param>
    /// <param name="TickText">Sets the text displayed at the ticks position via `TickVals`. Only has an effect if `tickmode` is set to "array". Used with `TickVals`.</param>
    /// <param name="Ticks">Determines whether ticks are drawn or not. If "", this axis' ticks are not drawn. If "outside" ("inside"), this axis' are drawn outside (inside) the axis lines.</param>
    /// <param name="TickLen">Sets the tick length (in px).</param>
    /// <param name="TickWidth">Sets the tick width (in px).</param>
    /// <param name="TickColor">Sets the tick color.</param>
    /// <param name="ShowTickLabels">Determines whether or not the tick labels are drawn.</param>
    /// <param name="ShowTickPrefix">If "all", all tick labels are displayed with a prefix. If "first", only the first tick is displayed with a prefix. If "last", only the last tick is displayed with a suffix. If "none", tick prefixes are hidden.</param>
    /// <param name="TickPrefix">Sets a tick label prefix.</param>
    /// <param name="ShowTickSuffix">Same as `showtickprefix` but for tick suffixes.</param>
    /// <param name="TickSuffix">Sets a tick label suffix.</param>
    /// <param name="ShowExponent">If "all", all exponents are shown besides their significands. If "first", only the exponent of the first tick is shown. If "last", only the exponent of the last tick is shown. If "none", no exponents appear.</param>
    /// <param name="ExponentFormat">Determines a formatting rule for the tick exponents. For example, consider the number 1,000,000,000. If "none", it appears as 1,000,000,000. If "e", 1e+9. If "E", 1E+9. If "power", 1x10^9 (with 9 in a super script). If "SI", 1G. If "B", 1B.</param>
    /// <param name="MinExponent">Hide SI prefix for 10^n if |n| is below this number. This only has an effect when `TickFormat` is "SI" or "B".</param>
    /// <param name="SeparateThousands">If "true", even 4-digit integers are separated</param>
    /// <param name="TickFont">Sets the tick font.</param>
    /// <param name="TickAngle">Sets the angle of the tick labels with respect to the horizontal. For example, a `tickangle` of -90 draws the tick labels vertically.</param>
    /// <param name="TickFormat">Sets the tick label formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-3.x-api-reference/blob/master/Formatting.md#d3_format. And for dates see: https://github.com/d3/d3-time-format#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with TickFormat "%H~%M~%S.%2f" would display "09~15~23.46"</param>
    /// <param name="TickFormatStops">Set rules for customizing TickFormat on different zoom levels</param>
    /// <param name="TickLabelStep">Sets the spacing between tick labels as compared to the spacing between ticks. A value of 1 (default) means each tick gets a label. A value of 2 means shows every 2nd label. A larger value n means only every nth tick is labeled. `tick0` determines which labels are shown. Not implemented for axes with `type` "log" or "multicategory", or when `tickmode` is "array".</param>
    /// <param name="LabelAlias">Replacement text for specific tick or hover labels. For example using {US: 'USA', CA: 'Canada'} changes US to USA and CA to Canada. The labels we would have shown must match the keys exactly, after adding any tickprefix or ticksuffix. labelalias can be used with any axis type, and both keys (if needed) and values (if desired) can include html-like tags or MathJax.</param>
    /// <param name="Layer">Sets the layer on which this axis is displayed. If "above traces", this axis is displayed above all the subplot's traces If "below traces", this axis is displayed below all the subplot's traces, but above the grid lines. Useful when used together with scatter-like traces with `cliponaxis` set to "false" to show markers and/or text nodes above this axis.</param>
    static member init
        (
            ?Visible: bool,
            ?AxisType: StyleParam.AxisType,
            ?AutoTypeNumbers: StyleParam.AutoTypeNumbers,
            ?CategoryOrder: StyleParam.CategoryOrder,
            ?CategoryArray: seq<#IConvertible>,
            ?ThetaUnit: StyleParam.AngularUnit,
            ?Period: float,
            ?Direction: StyleParam.Direction,
            ?Rotation: int,
            ?HoverFormat: string,
            ?UIRevision: #IConvertible,
            ?Color: Color,
            ?ShowLine: bool,
            ?LineColor: Color,
            ?LineWidth: int,
            ?ShowGrid: bool,
            ?GridColor: Color,
            ?GridDash: StyleParam.DrawingStyle,
            ?GridWidth: int,
            ?TickMode: StyleParam.TickMode,
            ?NTicks: int,
            ?Tick0: #IConvertible,
            ?DTick: #IConvertible,
            ?TickVals: seq<#IConvertible>,
            ?TickText: seq<#IConvertible>,
            ?Ticks: StyleParam.TickOptions,
            ?TickLen: int,
            ?TickWidth: int,
            ?TickColor: Color,
            ?ShowTickLabels: bool,
            ?ShowTickPrefix: StyleParam.ShowTickOption,
            ?TickPrefix: string,
            ?ShowTickSuffix: StyleParam.ShowTickOption,
            ?TickSuffix: string,
            ?ShowExponent: StyleParam.ShowExponent,
            ?ExponentFormat: StyleParam.ExponentFormat,
            ?MinExponent: float,
            ?SeparateThousands: bool,
            ?TickFont: Font,
            ?TickAngle: int,
            ?TickFormat: string,
            ?TickFormatStops: seq<TickFormatStop>,
            ?TickLabelStep: int,
            ?LabelAlias: DynamicObj,
            ?Layer: StyleParam.Layer
        ) =
        AngularAxis()
        |> AngularAxis.style (
            ?Visible = Visible,
            ?AxisType = AxisType,
            ?AutoTypeNumbers = AutoTypeNumbers,
            ?CategoryOrder = CategoryOrder,
            ?CategoryArray = CategoryArray,
            ?ThetaUnit = ThetaUnit,
            ?Period = Period,
            ?Direction = Direction,
            ?Rotation = Rotation,
            ?HoverFormat = HoverFormat,
            ?UIRevision = UIRevision,
            ?Color = Color,
            ?ShowLine = ShowLine,
            ?LineColor = LineColor,
            ?LineWidth = LineWidth,
            ?ShowGrid = ShowGrid,
            ?GridColor = GridColor,
            ?GridDash = GridDash,
            ?GridWidth = GridWidth,
            ?TickMode = TickMode,
            ?NTicks = NTicks,
            ?Tick0 = Tick0,
            ?DTick = DTick,
            ?TickVals = TickVals,
            ?TickText = TickText,
            ?Ticks = Ticks,
            ?TickLen = TickLen,
            ?TickWidth = TickWidth,
            ?TickColor = TickColor,
            ?ShowTickLabels = ShowTickLabels,
            ?ShowTickPrefix = ShowTickPrefix,
            ?TickPrefix = TickPrefix,
            ?ShowTickSuffix = ShowTickSuffix,
            ?TickSuffix = TickSuffix,
            ?ShowExponent = ShowExponent,
            ?ExponentFormat = ExponentFormat,
            ?MinExponent = MinExponent,
            ?SeparateThousands = SeparateThousands,
            ?TickFont = TickFont,
            ?TickAngle = TickAngle,
            ?TickFormat = TickFormat,
            ?TickFormatStops = TickFormatStops,
            ?TickLabelStep = TickLabelStep,
            ?LabelAlias = LabelAlias,
            ?Layer = Layer
        )

    /// <summary>
    /// Creates a function that applies the given style parameters to a AngularAxis object
    /// </summary>
    /// <param name="Visible">A single toggle to hide the axis while preserving interaction like dragging. Default is true when a cheater plot is present on the axis, otherwise false</param>
    /// <param name="AxisType">Sets the angular axis type. If "linear", set `thetaunit` to determine the unit in which axis value are shown. If "category, use `period` to set the number of integer coordinates around polar axis.</param>
    /// <param name="AutoTypeNumbers">Using "strict" a numeric string in trace data is not converted to a number. Using "convert types" a numeric string in trace data may be treated as a number during automatic axis `type` detection. Defaults to layout.autotypenumbers.</param>
    /// <param name="CategoryOrder">Specifies the ordering logic for the case of categorical variables. By default, plotly uses "trace", which specifies the order that is present in the data supplied. Set `categoryorder` to "category ascending" or "category descending" if order should be determined by the alphanumerical order of the category names. Set `categoryorder` to "array" to derive the ordering from the attribute `categoryarray`. If a category is not found in the `categoryarray` array, the sorting behavior for that attribute will be identical to the "trace" mode. The unspecified categories will follow the categories in `categoryarray`. Set `categoryorder` to "total ascending" or "total descending" if order should be determined by the numerical order of the values. Similarly, the order can be determined by the min, max, sum, mean or median of all the values.</param>
    /// <param name="CategoryArray">Sets the order in which categories on this axis appear. Only has an effect if `categoryorder` is set to "array". Used with `categoryorder`.</param>
    /// <param name="ThetaUnit">Sets the format unit of the formatted "theta" values. Has an effect only when `angularaxis.type` is "linear".</param>
    /// <param name="Period">Set the angular period. Has an effect only when `angularaxis.type` is "category".</param>
    /// <param name="Direction">Sets the direction corresponding to positive angles.</param>
    /// <param name="Rotation">Sets that start position (in degrees) of the angular axis By default, polar subplots with `direction` set to "counterclockwise" get a `rotation` of "0" which corresponds to due East (like what mathematicians prefer). In turn, polar with `direction` set to "clockwise" get a rotation of "90" which corresponds to due North (like on a compass),</param>
    /// <param name="HoverFormat">Sets the hover text formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-3.x-api-reference/blob/master/Formatting.md#d3_format. And for dates see: https://github.com/d3/d3-time-format#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with TickFormat "%H~%M~%S.%2f" would display "09~15~23.46"</param>
    /// <param name="UIRevision">Controls persistence of user-driven changes in axis `rotation`. Defaults to `polar&lt;N&gt;.uirevision`.</param>
    /// <param name="Color">Sets default for all colors associated with this axis all at once: line, font, tick, and grid colors. Grid color is lightened by blending this with the plot background Individual pieces can override this.</param>
    /// <param name="ShowLine">Determines whether or not a line bounding this axis is drawn.</param>
    /// <param name="LineColor">Sets the axis line color.</param>
    /// <param name="LineWidth">Sets the width (in px) of the axis line.</param>
    /// <param name="ShowGrid">Determines whether or not grid lines are drawn. If "true", the grid lines are drawn at every tick mark.</param>
    /// <param name="GridColor">Sets the color of the grid lines.</param>
    /// <param name="GridDash">Sets the dash style of lines. Set to a dash type string ("solid", "dot", "dash", "longdash", "dashdot", or "longdashdot") or a dash length list in px (eg "5px,10px,2px,2px").</param>
    /// <param name="GridWidth">Sets the width (in px) of the grid lines.</param>
    /// <param name="TickMode">Sets the tick mode for this axis. If "auto", the number of ticks is set via `nticks`. If "linear", the placement of the ticks is determined by a starting position `tick0` and a tick step `dtick` ("linear" is the default value if `tick0` and `dtick` are provided). If "array", the placement of the ticks is set via `TickVals` and the tick text is `TickText`. ("array" is the default value if `TickVals` is provided).</param>
    /// <param name="NTicks">Specifies the maximum number of ticks for the particular axis. The actual number of ticks will be chosen automatically to be less than or equal to `nticks`. Has an effect only if `tickmode` is set to "auto".</param>
    /// <param name="Tick0">Sets the placement of the first tick on this axis. Use with `dtick`. If the axis `type` is "log", then you must take the log of your starting tick (e.g. to set the starting tick to 100, set the `tick0` to 2) except when `dtick`="L&lt;f&gt;" (see `dtick` for more info). If the axis `type` is "date", it should be a date string, like date data. If the axis `type` is "category", it should be a number, using the scale where each category is assigned a serial number from zero in the order it appears.</param>
    /// <param name="DTick">Sets the step in-between ticks on this axis. Use with `tick0`. Must be a positive number, or special strings available to "log" and "date" axes. If the axis `type` is "log", then ticks are set every 10^(n"dtick) where n is the tick number. For example, to set a tick mark at 1, 10, 100, 1000, ... set dtick to 1. To set tick marks at 1, 100, 10000, ... set dtick to 2. To set tick marks at 1, 5, 25, 125, 625, 3125, ... set dtick to log_10(5), or 0.69897000433. "log" has several special values; "L&lt;f&gt;", where `f` is a positive number, gives ticks linearly spaced in value (but not position). For example `tick0` = 0.1, `dtick` = "L0.5" will put ticks at 0.1, 0.6, 1.1, 1.6 etc. To show powers of 10 plus small digits between, use "D1" (all digits) or "D2" (only 2 and 5). `tick0` is ignored for "D1" and "D2". If the axis `type` is "date", then you must convert the time to milliseconds. For example, to set the interval between ticks to one day, set `dtick` to 86400000.0. "date" also has special values "M&lt;n&gt;" gives ticks spaced by a number of months. `n` must be a positive integer. To set ticks on the 15th of every third month, set `tick0` to "2000-01-15" and `dtick` to "M3". To set ticks every 4 years, set `dtick` to "M48"</param>
    /// <param name="TickVals">Sets the values at which ticks on this axis appear. Only has an effect if `tickmode` is set to "array". Used with `TickText`.</param>
    /// <param name="TickText">Sets the text displayed at the ticks position via `TickVals`. Only has an effect if `tickmode` is set to "array". Used with `TickVals`.</param>
    /// <param name="Ticks">Determines whether ticks are drawn or not. If "", this axis' ticks are not drawn. If "outside" ("inside"), this axis' are drawn outside (inside) the axis lines.</param>
    /// <param name="TickLen">Sets the tick length (in px).</param>
    /// <param name="TickWidth">Sets the tick width (in px).</param>
    /// <param name="TickColor">Sets the tick color.</param>
    /// <param name="ShowTickLabels">Determines whether or not the tick labels are drawn.</param>
    /// <param name="ShowTickPrefix">If "all", all tick labels are displayed with a prefix. If "first", only the first tick is displayed with a prefix. If "last", only the last tick is displayed with a suffix. If "none", tick prefixes are hidden.</param>
    /// <param name="TickPrefix">Sets a tick label prefix.</param>
    /// <param name="ShowTickSuffix">Same as `showtickprefix` but for tick suffixes.</param>
    /// <param name="TickSuffix">Sets a tick label suffix.</param>
    /// <param name="ShowExponent">If "all", all exponents are shown besides their significands. If "first", only the exponent of the first tick is shown. If "last", only the exponent of the last tick is shown. If "none", no exponents appear.</param>
    /// <param name="ExponentFormat">Determines a formatting rule for the tick exponents. For example, consider the number 1,000,000,000. If "none", it appears as 1,000,000,000. If "e", 1e+9. If "E", 1E+9. If "power", 1x10^9 (with 9 in a super script). If "SI", 1G. If "B", 1B.</param>
    /// <param name="MinExponent">Hide SI prefix for 10^n if |n| is below this number. This only has an effect when `TickFormat` is "SI" or "B".</param>
    /// <param name="SeparateThousands">If "true", even 4-digit integers are separated</param>
    /// <param name="TickFont">Sets the tick font.</param>
    /// <param name="TickAngle">Sets the angle of the tick labels with respect to the horizontal. For example, a `tickangle` of -90 draws the tick labels vertically.</param>
    /// <param name="TickFormat">Sets the tick label formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-3.x-api-reference/blob/master/Formatting.md#d3_format. And for dates see: https://github.com/d3/d3-time-format#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with TickFormat "%H~%M~%S.%2f" would display "09~15~23.46"</param>
    /// <param name="TickFormatStops">Set rules for customizing TickFormat on different zoom levels</param>
    /// <param name="TickLabelStep">Sets the spacing between tick labels as compared to the spacing between ticks. A value of 1 (default) means each tick gets a label. A value of 2 means shows every 2nd label. A larger value n means only every nth tick is labeled. `tick0` determines which labels are shown. Not implemented for axes with `type` "log" or "multicategory", or when `tickmode` is "array".</param>
    /// <param name="LabelAlias">Replacement text for specific tick or hover labels. For example using {US: 'USA', CA: 'Canada'} changes US to USA and CA to Canada. The labels we would have shown must match the keys exactly, after adding any tickprefix or ticksuffix. labelalias can be used with any axis type, and both keys (if needed) and values (if desired) can include html-like tags or MathJax.</param>
    /// <param name="Layer">Sets the layer on which this axis is displayed. If "above traces", this axis is displayed above all the subplot's traces If "below traces", this axis is displayed below all the subplot's traces, but above the grid lines. Useful when used together with scatter-like traces with `cliponaxis` set to "false" to show markers and/or text nodes above this axis.</param>
    static member style
        (
            ?Visible: bool,
            ?AxisType: StyleParam.AxisType,
            ?AutoTypeNumbers: StyleParam.AutoTypeNumbers,
            ?CategoryOrder: StyleParam.CategoryOrder,
            ?CategoryArray: seq<#IConvertible>,
            ?ThetaUnit: StyleParam.AngularUnit,
            ?Period: float,
            ?Direction: StyleParam.Direction,
            ?Rotation: int,
            ?HoverFormat: string,
            ?UIRevision: #IConvertible,
            ?Color: Color,
            ?ShowLine: bool,
            ?LineColor: Color,
            ?LineWidth: int,
            ?ShowGrid: bool,
            ?GridColor: Color,
            ?GridDash: StyleParam.DrawingStyle,
            ?GridWidth: int,
            ?TickMode: StyleParam.TickMode,
            ?NTicks: int,
            ?Tick0: #IConvertible,
            ?DTick: #IConvertible,
            ?TickVals: seq<#IConvertible>,
            ?TickText: seq<#IConvertible>,
            ?Ticks: StyleParam.TickOptions,
            ?TickLen: int,
            ?TickWidth: int,
            ?TickColor: Color,
            ?ShowTickLabels: bool,
            ?ShowTickPrefix: StyleParam.ShowTickOption,
            ?TickPrefix: string,
            ?ShowTickSuffix: StyleParam.ShowTickOption,
            ?TickSuffix: string,
            ?ShowExponent: StyleParam.ShowExponent,
            ?ExponentFormat: StyleParam.ExponentFormat,
            ?MinExponent: float,
            ?SeparateThousands: bool,
            ?TickFont: Font,
            ?TickAngle: int,
            ?TickFormat: string,
            ?TickFormatStops: seq<TickFormatStop>,
            ?TickLabelStep: int,
            ?LabelAlias: DynamicObj,
            ?Layer: StyleParam.Layer
        ) =
        fun (angularAxis: AngularAxis) ->

            angularAxis
            |> DynObj.withOptionalProperty   "visible"           Visible             
            |> DynObj.withOptionalPropertyBy "type"              AxisType            StyleParam.AxisType.convert
            |> DynObj.withOptionalPropertyBy "autotypenumbers"   AutoTypeNumbers     StyleParam.AutoTypeNumbers.convert
            |> DynObj.withOptionalPropertyBy "categoryorder"     CategoryOrder       StyleParam.CategoryOrder.convert
            |> DynObj.withOptionalProperty   "categoryarray"     CategoryArray       
            |> DynObj.withOptionalProperty   "thetaunit"         ThetaUnit           
            |> DynObj.withOptionalProperty   "period"            Period              
            |> DynObj.withOptionalPropertyBy "direction"         Direction           StyleParam.Direction.convert
            |> DynObj.withOptionalProperty   "rotation"          Rotation            
            |> DynObj.withOptionalProperty   "hoverformat"       HoverFormat         
            |> DynObj.withOptionalProperty   "uirevision"        UIRevision          
            |> DynObj.withOptionalProperty   "color"             Color               
            |> DynObj.withOptionalProperty   "showline"          ShowLine            
            |> DynObj.withOptionalProperty   "linecolor"         LineColor           
            |> DynObj.withOptionalProperty   "linewidth"         LineWidth           
            |> DynObj.withOptionalProperty   "showgrid"          ShowGrid            
            |> DynObj.withOptionalProperty   "gridcolor"         GridColor           
            |> DynObj.withOptionalPropertyBy "griddash"          GridDash            StyleParam.DrawingStyle.convert
            |> DynObj.withOptionalProperty   "gridwidth"         GridWidth           
            |> DynObj.withOptionalPropertyBy "tickmode"          TickMode            StyleParam.TickMode.convert
            |> DynObj.withOptionalProperty   "nticks"            NTicks              
            |> DynObj.withOptionalProperty   "tick0"             Tick0               
            |> DynObj.withOptionalProperty   "dtick"             DTick               
            |> DynObj.withOptionalProperty   "tickvals"          TickVals            
            |> DynObj.withOptionalProperty   "ticktext"          TickText            
            |> DynObj.withOptionalPropertyBy "ticks"             Ticks               StyleParam.TickOptions.convert
            |> DynObj.withOptionalProperty   "ticklen"           TickLen             
            |> DynObj.withOptionalProperty   "tickwidth"         TickWidth           
            |> DynObj.withOptionalProperty   "tickcolor"         TickColor           
            |> DynObj.withOptionalProperty   "showticklabels"    ShowTickLabels      
            |> DynObj.withOptionalPropertyBy "showtickprefix"    ShowTickPrefix      StyleParam.ShowTickOption.convert
            |> DynObj.withOptionalProperty   "tickprefix"        TickPrefix          
            |> DynObj.withOptionalPropertyBy "showticksuffix"    ShowTickSuffix      StyleParam.ShowTickOption.convert
            |> DynObj.withOptionalProperty   "ticksuffix"        TickSuffix          
            |> DynObj.withOptionalPropertyBy "showexponent"      ShowExponent        StyleParam.ShowExponent.convert
            |> DynObj.withOptionalPropertyBy "exponentformat"    ExponentFormat      StyleParam.ExponentFormat.convert
            |> DynObj.withOptionalProperty   "minexponent"       MinExponent         
            |> DynObj.withOptionalProperty   "separatethousands" SeparateThousands   
            |> DynObj.withOptionalProperty   "tickfont"          TickFont            
            |> DynObj.withOptionalProperty   "tickangle"         TickAngle           
            |> DynObj.withOptionalProperty   "tickformat"        TickFormat          
            |> DynObj.withOptionalProperty   "tickformatstops"   TickFormatStops     
            |> DynObj.withOptionalProperty   "ticklabelstep"     TickLabelStep       
            |> DynObj.withOptionalProperty   "labelalias"        LabelAlias          
            |> DynObj.withOptionalPropertyBy "layer"             Layer               StyleParam.Layer.convert
