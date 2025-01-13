namespace Plotly.NET

open System.Runtime.InteropServices

open DynamicObj

type Title() =
    inherit DynamicObj()

    /// <summary>
    /// Returns a new Title object with the given styling. Note that this is a multi-purpose object that can be used as plot or different axis titles, with some attributes being only used in some layouts Note that this is a multi-purpose object that can be used as plot or different axis titles, with some attributes being only used in some layouts
    /// </summary>
    /// <param name="Text">For all titles: Sets the plot's title. Note that before the existence of `title.text`, the title's contents used to be defined as the `title` attribute itself. This behavior has been deprecated.</param>
    /// <param name="Font">For all titles: Sets the title font. Note that the title's font used to be customized by the now deprecated `titlefont` attribute.</param>
    /// <param name="AutoMargin">For plot titles: Determines whether the title can automatically push the figure margins. If `yref='paper'` then the margin will expand to ensure that the title doesn’t overlap with the edges of the container. If `yref='container'` then the margins will ensure that the title doesn’t overlap with the plot area, tick labels, and axis titles. If `automargin=true` and the margins need to be expanded, then y will be set to a default 1 and yanchor will be set to an appropriate default to ensure that minimal margin space is needed. Note that when `yref='paper'`, only 1 or 0 are allowed y values. Invalid values will be reset to the default 1.</param>
    /// <param name="Pad">For plot titles: Sets the padding of the title. Each padding value only applies when the corresponding `xanchor`/`yanchor` value is set accordingly. E.g. for left padding to take effect, `xanchor` must be set to "left". The same rule applies if `xanchor`/`yanchor` is determined automatically. Padding is muted if the respective anchor value is "middle"/"center".</param>
    /// <param name="X">For plot titles: Sets the x position with respect to `xref` in normalized coordinates from "0" (left) to "1" (right).</param>
    /// <param name="XAnchor">For plot titles: Sets the title's horizontal alignment with respect to its x position. "left" means that the title starts at x, "right" means that the title ends at x and "center" means that the title's center is at x. "auto" divides `xref` by three and calculates the `xanchor` value automatically based on the value of `x`.</param>
    /// <param name="XRef">For plot titles: Sets the container `x` refers to. "container" spans the entire `width` of the plot. "paper" refers to the width of the plotting area only.</param>
    /// <param name="Y">For plot titles: Sets the y position with respect to `yref` in normalized coordinates from "0" (bottom) to "1" (top). "auto" places the baseline of the title onto the vertical center of the top margin.</param>
    /// <param name="YAnchor">For plot titles: Sets the title's vertical alignment with respect to its y position. "top" means that the title's cap line is at y, "bottom" means that the title's baseline is at y and "middle" means that the title's midline is at y. "auto" divides `yref` by three and calculates the `yanchor` value automatically based on the value of `y`.</param>
    /// <param name="YRef">For plot titles: Sets the container `y` refers to. "container" spans the entire `height` of the plot. "paper" refers to the height of the plotting area only.</param>
    /// <param name="Standoff">For axis titles: Sets the standoff distance (in px) between the axis labels and the title text The default value is a function of the axis tick labels, the title `font.size` and the axis `linewidth`. Note that the axis title position is always constrained within the margins, so the actual standoff distance is always less than the set or default value. By setting `standoff` and turning on `automargin`, plotly.js will push the margins to fit the axis title at given standoff distance.</param>
    /// <param name="Side">For colorbar titles: Determines the location of color bar's title with respect to the color bar. Defaults to "top" when `orientation` if "v" and defaults to "right" when `orientation` if "h". Note that the title's location used to be set by the now deprecated `titleside` attribute.</param>
    static member init
        (
            ?Text: string,
            ?Font: Font,
            ?AutoMargin: bool,
            ?Pad: Padding,
            ?X: float,
            ?XAnchor: StyleParam.XAnchorPosition,
            ?XRef: string,
            ?Y: float,
            ?YAnchor: StyleParam.YAnchorPosition,
            ?YRef: string,
            // For axis titles
            ?Standoff: int,
            // For colorbar titles
            ?Side: StyleParam.Side
        ) =
        Title() 
        |> Title.style (
            ?Text = Text, 
            ?Font = Font, 
            ?AutoMargin = AutoMargin,
            ?Pad = Pad,
            ?X = X,
            ?XAnchor = XAnchor,
            ?XRef = XRef,
            ?Y = Y,
            ?YAnchor = YAnchor,
            ?YRef = YRef,
            ?Standoff = Standoff, 
            ?Side = Side 
        )

    /// <summary>
    /// Returns a function that applies the given styles to a Title object. Note that this is a multi-purpose object that can be used as plot or different axis titles, with some attributes being only used in some layouts
    /// </summary>
    /// <param name="Text">For all titles: Sets the plot's title. Note that before the existence of `title.text`, the title's contents used to be defined as the `title` attribute itself. This behavior has been deprecated.</param>
    /// <param name="Font">For all titles: Sets the title font. Note that the title's font used to be customized by the now deprecated `titlefont` attribute.</param>
    /// <param name="AutoMargin">For plot titles: Determines whether the title can automatically push the figure margins. If `yref='paper'` then the margin will expand to ensure that the title doesn’t overlap with the edges of the container. If `yref='container'` then the margins will ensure that the title doesn’t overlap with the plot area, tick labels, and axis titles. If `automargin=true` and the margins need to be expanded, then y will be set to a default 1 and yanchor will be set to an appropriate default to ensure that minimal margin space is needed. Note that when `yref='paper'`, only 1 or 0 are allowed y values. Invalid values will be reset to the default 1.</param>
    /// <param name="Pad">For plot titles: Sets the padding of the title. Each padding value only applies when the corresponding `xanchor`/`yanchor` value is set accordingly. E.g. for left padding to take effect, `xanchor` must be set to "left". The same rule applies if `xanchor`/`yanchor` is determined automatically. Padding is muted if the respective anchor value is "middle"/"center".</param>
    /// <param name="X">For plot titles: Sets the x position with respect to `xref` in normalized coordinates from "0" (left) to "1" (right).</param>
    /// <param name="XAnchor">For plot titles: Sets the title's horizontal alignment with respect to its x position. "left" means that the title starts at x, "right" means that the title ends at x and "center" means that the title's center is at x. "auto" divides `xref` by three and calculates the `xanchor` value automatically based on the value of `x`.</param>
    /// <param name="XRef">For plot titles: Sets the container `x` refers to. "container" spans the entire `width` of the plot. "paper" refers to the width of the plotting area only.</param>
    /// <param name="Y">For plot titles: Sets the y position with respect to `yref` in normalized coordinates from "0" (bottom) to "1" (top). "auto" places the baseline of the title onto the vertical center of the top margin.</param>
    /// <param name="YAnchor">For plot titles: Sets the title's vertical alignment with respect to its y position. "top" means that the title's cap line is at y, "bottom" means that the title's baseline is at y and "middle" means that the title's midline is at y. "auto" divides `yref` by three and calculates the `yanchor` value automatically based on the value of `y`.</param>
    /// <param name="YRef">For plot titles: Sets the container `y` refers to. "container" spans the entire `height` of the plot. "paper" refers to the height of the plotting area only.</param>
    /// <param name="Standoff">For axis titles: Sets the standoff distance (in px) between the axis labels and the title text The default value is a function of the axis tick labels, the title `font.size` and the axis `linewidth`. Note that the axis title position is always constrained within the margins, so the actual standoff distance is always less than the set or default value. By setting `standoff` and turning on `automargin`, plotly.js will push the margins to fit the axis title at given standoff distance.</param>
    /// <param name="Side">For colorbar titles: Determines the location of color bar's title with respect to the color bar. Defaults to "top" when `orientation` if "v" and defaults to "right" when `orientation` if "h". Note that the title's location used to be set by the now deprecated `titleside` attribute.</param>
    static member style
        (
            ?Text: string,
            ?Font: Font,
            ?AutoMargin: bool,
            ?Pad: Padding,
            ?X: float,
            ?XAnchor: StyleParam.XAnchorPosition,
            ?XRef: string,
            ?Y: float,
            ?YAnchor: StyleParam.YAnchorPosition,
            ?YRef: string,
            // For axis titles
            ?Standoff: int,
            // For colorbar titles
            ?Side: StyleParam.Side
        ) =
        (fun (title: Title) ->  
            title
            |> DynObj.withOptionalProperty "text" Text
            |> DynObj.withOptionalProperty "font" Font
            |> DynObj.withOptionalProperty "automargin" AutoMargin
            |> DynObj.withOptionalProperty "pad" Pad
            |> DynObj.withOptionalProperty "x" X
            |> DynObj.withOptionalPropertyBy "xanchor" XAnchor StyleParam.XAnchorPosition.convert
            |> DynObj.withOptionalProperty "xref" XRef
            |> DynObj.withOptionalProperty "y" Y
            |> DynObj.withOptionalPropertyBy "yanchor" YAnchor StyleParam.YAnchorPosition.convert
            |> DynObj.withOptionalProperty "yref" YRef
            |> DynObj.withOptionalProperty "standoff" Standoff
            |> DynObj.withOptionalPropertyBy "side" Side StyleParam.Side.convert
        )
