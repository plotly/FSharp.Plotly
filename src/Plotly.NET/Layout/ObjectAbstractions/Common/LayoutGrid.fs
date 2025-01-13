namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

/// A plot grid that can contain subplots with shared axes.
type LayoutGrid() =
    inherit DynamicObj()

    /// <summary>Initializes a LayoutGrid object</summary>
    /// <param name ="Rows">The number of rows in the grid. If you provide a 2D `subplots` array or a `yaxes` array, its length is used as the default. But it's also possible to have a different length, if you want to leave a row at the end for non-cartesian subplots.</param>
    /// <param name ="Columns">The number of columns in the grid. If you provide a 2D `subplots` array, the length of its longest row is used as the default. If you give an `xaxes` array, its length is used as the default. But it's also possible to have a different length, if you want to leave a row at the end for non-cartesian subplots.</param>
    /// <param name ="SubPlots">Used for freeform grids, where some axes may be shared across subplots but others are not. Each entry should be a cartesian subplot id, like "xy" or "x3y2", or "" to leave that cell empty. You may reuse x axes within the same column, and y axes within the same row. Non-cartesian subplots and traces that support `domain` can place themselves in this grid separately using the `gridcell` attribute.</param>
    /// <param name ="XAxes">Used with `yaxes` when the x and y axes are shared across columns and rows. Each entry should be an y axis id like "y", "y2", etc., or "" to not put a y axis in that row. Entries other than "" must be unique. Ignored if `subplots` is present. If missing but `xaxes` is present, will generate consecutive IDs.</param>
    /// <param name ="YAxes">Used with `yaxes` when the x and y axes are shared across columns and rows. Each entry should be an x axis id like "x", "x2", etc., or "" to not put an x axis in that column. Entries other than "" must be unique. Ignored if `subplots` is present. If missing but `yaxes` is present, will generate consecutive IDs.</param>
    /// <param name ="RowOrder">Is the first row the top or the bottom? Note that columns are always enumerated from left to right.</param>
    /// <param name ="Pattern">If no `subplots`, `xaxes`, or `yaxes` are given but we do have `rows` and `columns`, we can generate defaults using consecutive axis IDs, in two ways: "coupled" gives one x axis per column and one y axis per row. "independent" uses a new xy pair for each cell, left-to-right across each row then iterating rows according to `roworder`.</param>
    /// <param name ="XGap">Horizontal space between grid cells, expressed as a fraction of the total width available to one cell. Defaults to 0.1 for coupled-axes grids and 0.2 for independent grids.</param>
    /// <param name ="YGap">Vertical space between grid cells, expressed as a fraction of the total height available to one cell. Defaults to 0.1 for coupled-axes grids and 0.3 for independent grids.</param>
    /// <param name ="Domain">Sets the domains of this grid subplot (in plot fraction). The first and last cells end exactly at the domain edges, with no grout around the edges.</param>
    /// <param name ="XSide">Sets where the x axis labels and titles go. "bottom" means the very bottom of the grid. "bottom plot" is the lowest plot that each x axis is used in. "top" and "top plot" are similar.</param>
    /// <param name ="YSide">Sets where the y axis labels and titles go. "left" means the very left edge of the grid. "left plot" is the leftmost plot that each y axis is used in. "right" and "right plot" are similar.</param>

    static member init
        (
            ?Rows: int,
            ?Columns: int,
            ?SubPlots: (StyleParam.LinearAxisId * StyleParam.LinearAxisId)[][],
            ?XAxes: StyleParam.LinearAxisId[],
            ?YAxes: StyleParam.LinearAxisId[],
            ?RowOrder: StyleParam.LayoutGridRowOrder,
            ?Pattern: StyleParam.LayoutGridPattern,
            ?XGap: float,
            ?YGap: float,
            ?Domain: Domain,
            ?XSide: StyleParam.LayoutGridXSide,
            ?YSide: StyleParam.LayoutGridYSide
        ) =
        LayoutGrid()
        |> LayoutGrid.style (
            ?SubPlots = SubPlots,
            ?XAxes = XAxes,
            ?YAxes = YAxes,
            ?Rows = Rows,
            ?Columns = Columns,
            ?RowOrder = RowOrder,
            ?Pattern = Pattern,
            ?XGap = XGap,
            ?YGap = YGap,
            ?Domain = Domain,
            ?XSide = XSide,
            ?YSide = YSide

        )

    /// <summary>Returns a function that applies the given styles to a LayoutGrid.</summary>
    /// <param name ="Rows">The number of rows in the grid. If you provide a 2D `subplots` array or a `yaxes` array, its length is used as the default. But it's also possible to have a different length, if you want to leave a row at the end for non-cartesian subplots.</param>
    /// <param name ="Columns">The number of columns in the grid. If you provide a 2D `subplots` array, the length of its longest row is used as the default. If you give an `xaxes` array, its length is used as the default. But it's also possible to have a different length, if you want to leave a row at the end for non-cartesian subplots.</param>
    /// <param name ="SubPlots">Used for freeform grids, where some axes may be shared across subplots but others are not. Each entry should be a cartesian subplot id, like "xy" or "x3y2", or "" to leave that cell empty. You may reuse x axes within the same column, and y axes within the same row. Non-cartesian subplots and traces that support `domain` can place themselves in this grid separately using the `gridcell` attribute.</param>
    /// <param name ="XAxes">Used with `yaxes` when the x and y axes are shared across columns and rows. Each entry should be an y axis id like "y", "y2", etc., or "" to not put a y axis in that row. Entries other than "" must be unique. Ignored if `subplots` is present. If missing but `xaxes` is present, will generate consecutive IDs.</param>
    /// <param name ="YAxes">Used with `yaxes` when the x and y axes are shared across columns and rows. Each entry should be an x axis id like "x", "x2", etc., or "" to not put an x axis in that column. Entries other than "" must be unique. Ignored if `subplots` is present. If missing but `yaxes` is present, will generate consecutive IDs.</param>
    /// <param name ="RowOrder">Is the first row the top or the bottom? Note that columns are always enumerated from left to right.</param>
    /// <param name ="Pattern">If no `subplots`, `xaxes`, or `yaxes` are given but we do have `rows` and `columns`, we can generate defaults using consecutive axis IDs, in two ways: "coupled" gives one x axis per column and one y axis per row. "independent" uses a new xy pair for each cell, left-to-right across each row then iterating rows according to `roworder`.</param>
    /// <param name ="XGap">Horizontal space between grid cells, expressed as a fraction of the total width available to one cell. Defaults to 0.1 for coupled-axes grids and 0.2 for independent grids.</param>
    /// <param name ="YGap">Vertical space between grid cells, expressed as a fraction of the total height available to one cell. Defaults to 0.1 for coupled-axes grids and 0.3 for independent grids.</param>
    /// <param name ="Domain">Sets the domains of this grid subplot (in plot fraction). The first and last cells end exactly at the domain edges, with no grout around the edges.</param>
    /// <param name ="XSide">Sets where the x axis labels and titles go. "bottom" means the very bottom of the grid. "bottom plot" is the lowest plot that each x axis is used in. "top" and "top plot" are similar.</param>
    /// <param name ="YSide">Sets where the y axis labels and titles go. "left" means the very left edge of the grid. "left plot" is the leftmost plot that each y axis is used in. "right" and "right plot" are similar.</param>

    static member style
        (
            ?Rows: int,
            ?Columns: int,
            ?SubPlots: (StyleParam.LinearAxisId * StyleParam.LinearAxisId)[][],
            ?XAxes: StyleParam.LinearAxisId[],
            ?YAxes: StyleParam.LinearAxisId[],
            ?RowOrder: StyleParam.LayoutGridRowOrder,
            ?Pattern: StyleParam.LayoutGridPattern,
            ?XGap: float,
            ?YGap: float,
            ?Domain: Domain,
            ?XSide: StyleParam.LayoutGridXSide,
            ?YSide: StyleParam.LayoutGridYSide
        ) =
        (fun (layoutGrid: LayoutGrid) ->
            layoutGrid
            |> DynObj.withOptionalPropertyBy "subplots" SubPlots (
                Array.map (
                    Array.map (fun (x, y) ->
                        $"{StyleParam.LinearAxisId.toString x}{StyleParam.LinearAxisId.toString y}")
                )
            )
            |> DynObj.withOptionalPropertyBy "xaxes" XAxes (Array.map StyleParam.LinearAxisId.toString)
            |> DynObj.withOptionalPropertyBy "yaxes" YAxes (Array.map StyleParam.LinearAxisId.toString)
            |> DynObj.withOptionalProperty "rows" Rows
            |> DynObj.withOptionalProperty "columns" Columns
            |> DynObj.withOptionalPropertyBy "roworder" RowOrder StyleParam.LayoutGridRowOrder.toString
            |> DynObj.withOptionalPropertyBy "pattern" Pattern StyleParam.LayoutGridPattern.toString
            |> DynObj.withOptionalProperty "xgap" XGap
            |> DynObj.withOptionalProperty "ygap" YGap
            |> DynObj.withOptionalProperty "domain" Domain
            |> DynObj.withOptionalPropertyBy "xside" XSide StyleParam.LayoutGridXSide.toString
            |> DynObj.withOptionalPropertyBy "yside" YSide StyleParam.LayoutGridYSide.toString
        )
