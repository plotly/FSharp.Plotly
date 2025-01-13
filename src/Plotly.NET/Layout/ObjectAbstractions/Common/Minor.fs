namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

///<summary>The Minor object holds various parameters to style minor ticks on cartesian axes</summary>
type Minor() =
    inherit DynamicObj()

    /// <summary>
    /// Initialize a Minor object that holds various parameters to style minor ticks on cartesian axes.
    /// </summary>
    /// <param name="DTick">Sets the step in-between ticks on this axis. Use with `tick0`. Must be a positive number, or special strings available to "log" and "date" axes. If the axis `type` is "log", then ticks are set every 10^(n"dtick) where n is the tick number. For example, to set a tick mark at 1, 10, 100, 1000, ... set dtick to 1. To set tick marks at 1, 100, 10000, ... set dtick to 2. To set tick marks at 1, 5, 25, 125, 625, 3125, ... set dtick to log_10(5), or 0.69897000433. "log" has several special values; "L&lt;f&gt;", where `f` is a positive number, gives ticks linearly spaced in value (but not position). For example `tick0` = 0.1, `dtick` = "L0.5" will put ticks at 0.1, 0.6, 1.1, 1.6 etc. To show powers of 10 plus small digits between, use "D1" (all digits) or "D2" (only 2 and 5). `tick0` is ignored for "D1" and "D2". If the axis `type` is "date", then you must convert the time to milliseconds. For example, to set the interval between ticks to one day, set `dtick` to 86400000.0. "date" also has special values "M&lt;n&gt;" gives ticks spaced by a number of months. `n` must be a positive integer. To set ticks on the 15th of every third month, set `tick0` to "2000-01-15" and `dtick` to "M3". To set ticks every 4 years, set `dtick` to "M48"</param>>
    /// <param name="GridColor">Sets the color of the grid lines.</param>
    /// <param name="GridDash">Sets the dash style of lines. Set to a dash type string ("solid", "dot", "dash", "longdash", "dashdot", or "longdashdot") or a dash length list in px (eg "5px,10px,2px,2px").</param>
    /// <param name="GridWidth">Sets the width (in px) of the grid lines.</param>
    /// <param name="NTicks">Specifies the maximum number of ticks for the particular axis. The actual number of ticks will be chosen automatically to be less than or equal to `nticks`. Has an effect only if `tickmode` is set to "auto".</param>
    /// <param name="ShowGrid">Determines whether or not grid lines are drawn. If "true", the grid lines are drawn at every tick mark.</param>
    /// <param name="Tick0">Sets the placement of the first tick on this axis. Use with `dtick`. If the axis `type` is "log", then you must take the log of your starting tick (e.g. to set the starting tick to 100, set the `tick0` to 2) except when `dtick`="L&lt;f&gt;" (see `dtick` for more info). If the axis `type` is "date", it should be a date string, like date data. If the axis `type` is "category", it should be a number, using the scale where each category is assigned a serial number from zero in the order it appears.</param>>
    /// <param name="TickColor">Sets the tick color.</param>
    /// <param name="TickLen">Sets the tick length (in px).</param>
    /// <param name="TickMode">Sets the tick mode for this axis. If "auto", the number of ticks is set via `nticks`. If "linear", the placement of the ticks is determined by a starting position `tick0` and a tick step `dtick` ("linear" is the default value if `tick0` and `dtick` are provided). If "array", the placement of the ticks is set via `tickvals` and the tick text is `ticktext`. ("array" is the default value if `tickvals` is provided).</param>
    /// <param name="Ticks">Determines whether ticks are drawn or not. If "", this axis' ticks are not drawn. If "outside" ("inside"), this axis' are drawn outside (inside) the axis lines.</param>
    /// <param name="TickVals">Sets the values at which ticks on this axis appear. Only has an effect if `tickmode` is set to "array". Used with `ticktext`.</param>
    /// <param name="TickWidth">Sets the tick width (in px).</param>
    static member init
        (
            ?DTick: #IConvertible,
            ?GridColor: Color,
            ?GridDash: StyleParam.DrawingStyle,
            ?GridWidth: float,
            ?NTicks: int,
            ?ShowGrid: bool,
            ?Tick0: #IConvertible,
            ?TickColor: Color,
            ?TickLen: int,
            ?TickMode: StyleParam.TickMode,
            ?Ticks: StyleParam.TickOptions,
            ?TickVals: seq<#IConvertible>,
            ?TickWidth: int
        ) =
        Minor()
        |> Minor.style (
            ?DTick = DTick,
            ?GridColor = GridColor,
            ?GridDash = GridDash,
            ?GridWidth = GridWidth,
            ?NTicks = NTicks,
            ?ShowGrid = ShowGrid,
            ?Tick0 = Tick0,
            ?TickColor = TickColor,
            ?TickLen = TickLen,
            ?TickMode = TickMode,
            ?Ticks = Ticks,
            ?TickVals = TickVals,
            ?TickWidth = TickWidth
        )

    /// <summary>
    /// Creates a function that applies the given style parameters to a Minor object
    /// </summary>
    /// <param name="DTick">Sets the step in-between ticks on this axis. Use with `tick0`. Must be a positive number, or special strings available to "log" and "date" axes. If the axis `type` is "log", then ticks are set every 10^(n"dtick) where n is the tick number. For example, to set a tick mark at 1, 10, 100, 1000, ... set dtick to 1. To set tick marks at 1, 100, 10000, ... set dtick to 2. To set tick marks at 1, 5, 25, 125, 625, 3125, ... set dtick to log_10(5), or 0.69897000433. "log" has several special values; "L&lt;f&gt;", where `f` is a positive number, gives ticks linearly spaced in value (but not position). For example `tick0` = 0.1, `dtick` = "L0.5" will put ticks at 0.1, 0.6, 1.1, 1.6 etc. To show powers of 10 plus small digits between, use "D1" (all digits) or "D2" (only 2 and 5). `tick0` is ignored for "D1" and "D2". If the axis `type` is "date", then you must convert the time to milliseconds. For example, to set the interval between ticks to one day, set `dtick` to 86400000.0. "date" also has special values "M&lt;n&gt;" gives ticks spaced by a number of months. `n` must be a positive integer. To set ticks on the 15th of every third month, set `tick0` to "2000-01-15" and `dtick` to "M3". To set ticks every 4 years, set `dtick` to "M48"</param>>
    /// <param name="GridColor">Sets the color of the grid lines.</param>
    /// <param name="GridDash">Sets the dash style of lines. Set to a dash type string ("solid", "dot", "dash", "longdash", "dashdot", or "longdashdot") or a dash length list in px (eg "5px,10px,2px,2px").</param>
    /// <param name="GridWidth">Sets the width (in px) of the grid lines.</param>
    /// <param name="NTicks">Specifies the maximum number of ticks for the particular axis. The actual number of ticks will be chosen automatically to be less than or equal to `nticks`. Has an effect only if `tickmode` is set to "auto".</param>
    /// <param name="ShowGrid">Determines whether or not grid lines are drawn. If "true", the grid lines are drawn at every tick mark.</param>
    /// <param name="Tick0">Sets the placement of the first tick on this axis. Use with `dtick`. If the axis `type` is "log", then you must take the log of your starting tick (e.g. to set the starting tick to 100, set the `tick0` to 2) except when `dtick`="L&lt;f&gt;" (see `dtick` for more info). If the axis `type` is "date", it should be a date string, like date data. If the axis `type` is "category", it should be a number, using the scale where each category is assigned a serial number from zero in the order it appears.</param>>
    /// <param name="TickColor">Sets the tick color.</param>
    /// <param name="TickLen">Sets the tick length (in px).</param>
    /// <param name="TickMode">Sets the tick mode for this axis. If "auto", the number of ticks is set via `nticks`. If "linear", the placement of the ticks is determined by a starting position `tick0` and a tick step `dtick` ("linear" is the default value if `tick0` and `dtick` are provided). If "array", the placement of the ticks is set via `tickvals` and the tick text is `ticktext`. ("array" is the default value if `tickvals` is provided).</param>
    /// <param name="Ticks">Determines whether ticks are drawn or not. If "", this axis' ticks are not drawn. If "outside" ("inside"), this axis' are drawn outside (inside) the axis lines.</param>
    /// <param name="TickVals">Sets the values at which ticks on this axis appear. Only has an effect if `tickmode` is set to "array". Used with `ticktext`.</param>
    /// <param name="TickWidth">Sets the tick width (in px).</param>
    static member style
        (
            ?DTick: #IConvertible,
            ?GridColor: Color,
            ?GridDash: StyleParam.DrawingStyle,
            ?GridWidth: float,
            ?NTicks: int,
            ?ShowGrid: bool,
            ?Tick0: #IConvertible,
            ?TickColor: Color,
            ?TickLen: int,
            ?TickMode: StyleParam.TickMode,
            ?Ticks: StyleParam.TickOptions,
            ?TickVals: seq<#IConvertible>,
            ?TickWidth: int
        ) =
        (fun (minor: Minor) ->

            minor
            |> DynObj.withOptionalProperty "dtick" DTick
            |> DynObj.withOptionalProperty "gridcolor" GridColor
            |> DynObj.withOptionalPropertyBy "griddash" GridDash StyleParam.DrawingStyle.convert
            |> DynObj.withOptionalProperty "gridwidth" GridWidth
            |> DynObj.withOptionalProperty "nticks" NTicks
            |> DynObj.withOptionalProperty "showgrid" ShowGrid
            |> DynObj.withOptionalProperty "tick0" Tick0
            |> DynObj.withOptionalProperty "tickcolor" TickColor
            |> DynObj.withOptionalProperty "ticklen" TickLen
            |> DynObj.withOptionalPropertyBy "tickmode" TickMode StyleParam.TickMode.convert
            |> DynObj.withOptionalPropertyBy "ticks" Ticks StyleParam.TickOptions.convert
            |> DynObj.withOptionalProperty "tickvals" TickVals
            |> DynObj.withOptionalProperty "tickwidth" TickWidth
        )
