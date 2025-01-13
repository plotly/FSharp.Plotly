using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plotly.NET;
using Plotly.NET.LayoutObjects;
using Plotly.NET.TraceObjects;
using System.Runtime.InteropServices;

namespace Plotly.NET.CSharp
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Chart
    {
        /// <summary>
        /// Create a combined chart with the given charts merged
        /// </summary>
        /// <param name="gCharts">the charts to combine</param>
        /// <returns></returns>
        public static GenericChart Combine(IEnumerable<GenericChart> gCharts) => Plotly.NET.Chart.combine(gCharts);

        /// <summary>
        /// Creates a chart that is completely invisible when rendered. The Chart object however is NOT empty! Combining this chart with other charts will have unforseen consequences (it has for example invisible axes that can override other axes if used in Chart.Combine)
        /// </summary>
        /// <returns></returns>
        public static GenericChart Invisible()  => Plotly.NET.Chart.Invisible();

        /// <summary>
        /// Creates a subplot grid with the given dimensions (nRows x nCols) for the input charts.
        /// </summary>
        /// <param name ="gCharts">The charts to display on the grid.</param>
        /// <param name ="nRows">The number of rows in the grid. If you provide a 2D `subplots` array or a `yaxes` array, its length is used as the default. But it's also possible to have a different length, if you want to leave a row at the end for non-cartesian subplots.</param>
        /// <param name ="nCols">The number of columns in the grid. If you provide a 2D `subplots` array, the length of its longest row is used as the default. If you give an `xaxes` array, its length is used as the default. But it's also possible to have a different length, if you want to leave a row at the end for non-cartesian subplots.</param>
        /// <param name ="SubPlotTitles">A collection of titles for the individual subplots.</param>
        /// <param name ="SubPlotTitleFont">The font of the subplot titles</param>
        /// <param name ="SubPlotTitleOffset">A vertical offset applied to each subplot title, moving it upwards if positive and vice versa</param>
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
        public static GenericChart Grid(
            IEnumerable<GenericChart> gCharts,
            int nRows,
            int nCols,
            Optional<IEnumerable<string>> SubPlotTitles = default,
            Optional<Font> SubPlotTitleFont = default,
            Optional<double> SubPlotTitleOffset = default,
            Optional<Tuple<StyleParam.LinearAxisId, StyleParam.LinearAxisId>[][]> SubPlots = default,
            Optional<StyleParam.LinearAxisId[]> XAxes = default,
            Optional<StyleParam.LinearAxisId[]> YAxes = default,
            Optional<StyleParam.LayoutGridRowOrder> RowOrder = default,
            Optional<StyleParam.LayoutGridPattern> Pattern = default,
            Optional<double> XGap = default,
            Optional<double> YGap = default,
            Optional<Domain> Domain = default,
            Optional<StyleParam.LayoutGridXSide> XSide = default,
            Optional<StyleParam.LayoutGridYSide> YSide = default
        ) =>
            Plotly.NET.Chart.Grid<IEnumerable<string>,IEnumerable<GenericChart>>(
                nRows: nRows,
                nCols: nCols,
                SubPlotTitles: SubPlotTitles.ToOption(),
                SubPlotTitleFont: SubPlotTitleFont.ToOption(),
                SubPlotTitleOffset: SubPlotTitleOffset.ToOption(),
                SubPlots: SubPlots.ToOption(),
                XAxes: XAxes.ToOption(),
                YAxes: YAxes.ToOption(),
                RowOrder: RowOrder.ToOption(),
                Pattern: Pattern.ToOption(),
                XGap: XGap.ToOption(),
                YGap: YGap.ToOption(),
                Domain: Domain.ToOption(),
                XSide: XSide.ToOption(),
                YSide: YSide.ToOption()
            ).Invoke(gCharts);
        
        ///<summary>
        /// Creates a chart stack (a subplot grid with one column) from the input charts.
        /// </summary>
        /// <param name ="gCharts">The charts to display.</param>
        /// <param name ="SubPlotTitles">A collection of titles for the individual subplots.</param>
        /// <param name ="SubPlotTitleFont">The font of the subplot titles</param>
        /// <param name ="SubPlotTitleOffset">A vertical offset applied to each subplot title, moving it upwards if positive and vice versa</param>
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
        public static GenericChart SingleStack(
            IEnumerable<GenericChart> gCharts,
            Optional<IEnumerable<string>> SubPlotTitles = default,
            Optional<Font> SubPlotTitleFont = default,
            Optional<double> SubPlotTitleOffset = default,
            Optional<Tuple<StyleParam.LinearAxisId, StyleParam.LinearAxisId>[][]> SubPlots = default,
            Optional<StyleParam.LinearAxisId[]> XAxes = default,
            Optional<StyleParam.LinearAxisId[]> YAxes = default,
            Optional<StyleParam.LayoutGridRowOrder> RowOrder = default,
            Optional<StyleParam.LayoutGridPattern> Pattern = default,
            Optional<double> XGap = default,
            Optional<double> YGap = default,
            Optional<Domain> Domain = default,
            Optional<StyleParam.LayoutGridXSide> XSide = default,
            Optional<StyleParam.LayoutGridYSide> YSide = default
        ) =>
            Plotly.NET.Chart.SingleStack<IEnumerable<string>, IEnumerable<GenericChart>>(
                SubPlotTitles: SubPlotTitles.ToOption(),
                SubPlotTitleFont: SubPlotTitleFont.ToOption(),
                SubPlotTitleOffset: SubPlotTitleOffset.ToOption(),
                SubPlots: SubPlots.ToOption(),
                XAxes: XAxes.ToOption(),
                YAxes: YAxes.ToOption(),
                RowOrder: RowOrder.ToOption(),
                Pattern: Pattern.ToOption(),
                XGap: XGap.ToOption(),
                YGap: YGap.ToOption(),
                Domain: Domain.ToOption(),
                XSide: XSide.ToOption(),
                YSide: YSide.ToOption()
            ).Invoke(gCharts);
    }
}
