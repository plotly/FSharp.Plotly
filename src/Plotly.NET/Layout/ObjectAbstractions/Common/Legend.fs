namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

/// Legend
type Legend() =
    inherit DynamicObj()

    /// <summary>
    /// Returns a new Legend object with the given styles
    /// </summary>
    /// <param name="BGColor">Sets the legend background color. Defaults to `layout.paper_bgcolor`.</param>
    /// <param name="BorderColor">Sets the color of the border enclosing the legend.</param>
    /// <param name="BorderWidth">Sets the width (in px) of the border enclosing the legend.</param>
    /// <param name="EntryWidth">Sets the width (in px or fraction) of the legend. Use 0 to size the entry based on the text width, when `entrywidthmode` is set to "pixels".</param>
    /// <param name="EntryWidthMode">Determines what entrywidth means.</param>
    /// <param name="Font">Sets the font used to text the legend items.</param>
    /// <param name="GroupClick">Determines the behavior on legend group item click. "toggleitem" toggles the visibility of the individual item clicked on the graph. "togglegroup" toggles the visibility of all items in the same legendgroup as the item clicked on the graph.</param>
    /// <param name="GroupTitleFont">Sets the font for group titles in legend. Defaults to `legend.font` with its size increased about 10%.</param>
    /// <param name="ItemClick">Determines the behavior on legend item click. "toggle" toggles the visibility of the item clicked on the graph. "toggleothers" makes the clicked item the sole visible item on the graph. "false" disables legend item click interactions.</param>
    /// <param name="ItemDoubleClick">Determines the behavior on legend item double-click. "toggle" toggles the visibility of the item clicked on the graph. "toggleothers" makes the clicked item the sole visible item on the graph. "false" disables legend item double-click interactions.</param>
    /// <param name="ItemSizing">Determines if the legend items symbols scale with their corresponding "trace" attributes or remain "constant" independent of the symbol size on the graph.</param>
    /// <param name="ItemWidth">Sets the width (in px) of the legend item symbols (the part other than the title.text).</param>
    /// <param name="Orientation">Sets the orientation of the legend.</param>
    /// <param name="Title">Sets the title of the legend.</param>
    /// <param name="TraceGroupGap">Sets the amount of vertical space (in px) between legend groups.</param>
    /// <param name="TraceOrder">Determines the order at which the legend items are displayed. If "normal", the items are displayed top-to-bottom in the same order as the input data. If "reversed", the items are displayed in the opposite order as "normal". If "grouped", the items are displayed in groups (when a trace `legendgroup` is provided). if "grouped+reversed", the items are displayed in the opposite order as "grouped".</param>
    /// <param name="UIRevision">Controls persistence of legend-driven changes in trace and pie label visibility. Defaults to `layout.uirevision`.</param>
    /// <param name="VerticalAlign">Sets the vertical alignment of the symbols with respect to their associated text.</param>
    /// <param name="Visible">Determines whether or not this legend is visible.</param>
    /// <param name="X">Sets the x position (in normalized coordinates) of the legend. Defaults to "1.02" for vertical legends and defaults to "0" for horizontal legends.</param>
    /// <param name="XAnchor">Sets the legend's horizontal position anchor. This anchor binds the `x` position to the "left", "center" or "right" of the legend. Value "auto" anchors legends to the right for `x` values greater than or equal to 2/3, anchors legends to the left for `x` values less than or equal to 1/3 and anchors legends with respect to their center otherwise.</param>
    /// <param name="XRef">Sets the container `x` refers to. "container" spans the entire `width` of the plot. "paper" refers to the width of the plotting area only.</param>
    /// <param name="Y">Sets the y position (in normalized coordinates) of the legend. Defaults to "1" for vertical legends, defaults to "-0.1" for horizontal legends on graphs w/o range sliders and defaults to "1.1" for horizontal legends on graph with one or multiple range sliders.</param>
    /// <param name="YAnchor">Sets the legend's vertical position anchor This anchor binds the `y` position to the "top", "middle" or "bottom" of the legend. Value "auto" anchors legends at their bottom for `y` values less than or equal to 1/3, anchors legends to at their top for `y` values greater than or equal to 2/3 and anchors legends with respect to their middle otherwise.</param>
    /// <param name="YRef">Sets the container `y` refers to. "container" spans the entire `height` of the plot. "paper" refers to the height of the plotting area only.</param>
    static member init
        (
            ?BGColor: Color,
            ?BorderColor: Color,
            ?BorderWidth: float,
            ?EntryWidth: float,
            ?EntryWidthMode: StyleParam.EntryWidthMode,
            ?Font: Font,
            ?GroupClick: StyleParam.TraceGroupClickOptions,
            ?GroupTitleFont: Font,
            ?ItemClick: StyleParam.TraceItemClickOptions,
            ?ItemDoubleClick: StyleParam.TraceItemClickOptions,
            ?ItemSizing: StyleParam.TraceItemSizing,
            ?ItemWidth: int,
            ?Orientation: StyleParam.Orientation,
            ?Title: Title,
            ?TraceGroupGap: float,
            ?TraceOrder: StyleParam.TraceOrder,
            ?UIRevision: string,
            ?VerticalAlign: StyleParam.VerticalAlign,
            ?Visible: bool,
            ?X: float,
            ?XAnchor: StyleParam.XAnchorPosition,
            ?XRef: string,
            ?Y: float,
            ?YAnchor: StyleParam.YAnchorPosition,
            ?YRef: string
        ) =
        Legend()
        |> Legend.style (
            ?BGColor = BGColor,
            ?BorderColor = BorderColor,
            ?BorderWidth = BorderWidth,
            ?EntryWidth = EntryWidth,
            ?EntryWidthMode = EntryWidthMode,
            ?Font = Font,
            ?GroupClick = GroupClick,
            ?GroupTitleFont = GroupTitleFont,
            ?ItemClick = ItemClick,
            ?ItemDoubleClick = ItemDoubleClick,
            ?ItemSizing = ItemSizing,
            ?ItemWidth = ItemWidth,
            ?Orientation = Orientation,
            ?Title = Title,
            ?TraceGroupGap = TraceGroupGap,
            ?TraceOrder = TraceOrder,
            ?UIRevision = UIRevision,
            ?VerticalAlign = VerticalAlign,
            ?Visible = Visible,
            ?X = X,
            ?XAnchor = XAnchor,
            ?XRef = XRef,
            ?Y = Y,
            ?YAnchor = YAnchor,
            ?YRef = YRef
        )

    /// <summary>
    /// Returns a function that applies the given styles to a Legend object
    /// </summary>
    /// <param name="BGColor">Sets the legend background color. Defaults to `layout.paper_bgcolor`.</param>
    /// <param name="BorderColor">Sets the color of the border enclosing the legend.</param>
    /// <param name="BorderWidth">Sets the width (in px) of the border enclosing the legend.</param>
    /// <param name="EntryWidth">Sets the width (in px or fraction) of the legend. Use 0 to size the entry based on the text width, when `entrywidthmode` is set to "pixels".</param>
    /// <param name="EntryWidthMode">Determines what entrywidth means.</param>
    /// <param name="Font">Sets the font used to text the legend items.</param>
    /// <param name="GroupClick">Determines the behavior on legend group item click. "toggleitem" toggles the visibility of the individual item clicked on the graph. "togglegroup" toggles the visibility of all items in the same legendgroup as the item clicked on the graph.</param>
    /// <param name="GroupTitleFont">Sets the font for group titles in legend. Defaults to `legend.font` with its size increased about 10%.</param>
    /// <param name="ItemClick">Determines the behavior on legend item click. "toggle" toggles the visibility of the item clicked on the graph. "toggleothers" makes the clicked item the sole visible item on the graph. "false" disables legend item click interactions.</param>
    /// <param name="ItemDoubleClick">Determines the behavior on legend item double-click. "toggle" toggles the visibility of the item clicked on the graph. "toggleothers" makes the clicked item the sole visible item on the graph. "false" disables legend item double-click interactions.</param>
    /// <param name="ItemSizing">Determines if the legend items symbols scale with their corresponding "trace" attributes or remain "constant" independent of the symbol size on the graph.</param>
    /// <param name="ItemWidth">Sets the width (in px) of the legend item symbols (the part other than the title.text).</param>
    /// <param name="Orientation">Sets the orientation of the legend.</param>
    /// <param name="Title">Sets the title of the legend.</param>
    /// <param name="TraceGroupGap">Sets the amount of vertical space (in px) between legend groups.</param>
    /// <param name="TraceOrder">Determines the order at which the legend items are displayed. If "normal", the items are displayed top-to-bottom in the same order as the input data. If "reversed", the items are displayed in the opposite order as "normal". If "grouped", the items are displayed in groups (when a trace `legendgroup` is provided). if "grouped+reversed", the items are displayed in the opposite order as "grouped".</param>
    /// <param name="UIRevision">Controls persistence of legend-driven changes in trace and pie label visibility. Defaults to `layout.uirevision`.</param>
    /// <param name="VerticalAlign">Sets the vertical alignment of the symbols with respect to their associated text.</param>
    /// <param name="Visible">Determines whether or not this legend is visible.</param>
    /// <param name="X">Sets the x position (in normalized coordinates) of the legend. Defaults to "1.02" for vertical legends and defaults to "0" for horizontal legends.</param>
    /// <param name="XAnchor">Sets the legend's horizontal position anchor. This anchor binds the `x` position to the "left", "center" or "right" of the legend. Value "auto" anchors legends to the right for `x` values greater than or equal to 2/3, anchors legends to the left for `x` values less than or equal to 1/3 and anchors legends with respect to their center otherwise.</param>
    /// <param name="XRef">Sets the container `x` refers to. "container" spans the entire `width` of the plot. "paper" refers to the width of the plotting area only.</param>
    /// <param name="Y">Sets the y position (in normalized coordinates) of the legend. Defaults to "1" for vertical legends, defaults to "-0.1" for horizontal legends on graphs w/o range sliders and defaults to "1.1" for horizontal legends on graph with one or multiple range sliders.</param>
    /// <param name="YAnchor">Sets the legend's vertical position anchor This anchor binds the `y` position to the "top", "middle" or "bottom" of the legend. Value "auto" anchors legends at their bottom for `y` values less than or equal to 1/3, anchors legends to at their top for `y` values greater than or equal to 2/3 and anchors legends with respect to their middle otherwise.</param>
    /// <param name="YRef">Sets the container `y` refers to. "container" spans the entire `height` of the plot. "paper" refers to the height of the plotting area only.</param>
    static member style
        (
            ?BGColor: Color,
            ?BorderColor: Color,
            ?BorderWidth: float,
            ?EntryWidth: float,
            ?EntryWidthMode: StyleParam.EntryWidthMode,
            ?Font: Font,
            ?GroupClick: StyleParam.TraceGroupClickOptions,
            ?GroupTitleFont: Font,
            ?ItemClick: StyleParam.TraceItemClickOptions,
            ?ItemDoubleClick: StyleParam.TraceItemClickOptions,
            ?ItemSizing: StyleParam.TraceItemSizing,
            ?ItemWidth: int,
            ?Orientation: StyleParam.Orientation,
            ?Title: Title,
            ?TraceGroupGap: float,
            ?TraceOrder: StyleParam.TraceOrder,
            ?UIRevision: string,
            ?VerticalAlign: StyleParam.VerticalAlign,
            ?Visible: bool,
            ?X: float,
            ?XAnchor: StyleParam.XAnchorPosition,
            ?XRef: string,
            ?Y: float,
            ?YAnchor: StyleParam.YAnchorPosition,
            ?YRef: string
        ) =
        (fun (legend: Legend) ->
            
            legend
            |> DynObj.withOptionalProperty "bgcolor" BGColor
            |> DynObj.withOptionalProperty "bordercolor" BorderColor
            |> DynObj.withOptionalProperty "borderwidth" BorderWidth
            |> DynObj.withOptionalProperty "entrywidth" EntryWidth
            |> DynObj.withOptionalPropertyBy "entrywidthmode" EntryWidthMode StyleParam.EntryWidthMode.convert
            |> DynObj.withOptionalProperty "font" Font
            |> DynObj.withOptionalPropertyBy "groupclick" GroupClick StyleParam.TraceGroupClickOptions.convert
            |> DynObj.withOptionalProperty "grouptitlefont" GroupTitleFont
            |> DynObj.withOptionalPropertyBy "itemclick" ItemClick StyleParam.TraceItemClickOptions.convert
            |> DynObj.withOptionalPropertyBy "itemdoubleclick" ItemDoubleClick StyleParam.TraceItemClickOptions.convert
            |> DynObj.withOptionalPropertyBy "itemsizing" ItemSizing StyleParam.TraceItemSizing.convert
            |> DynObj.withOptionalProperty "itemwidth" ItemWidth
            |> DynObj.withOptionalPropertyBy "orientation" Orientation StyleParam.Orientation.convert
            |> DynObj.withOptionalProperty "title" Title
            |> DynObj.withOptionalProperty "tracegroupgap" TraceGroupGap
            |> DynObj.withOptionalPropertyBy "traceorder" TraceOrder StyleParam.TraceOrder.convert
            |> DynObj.withOptionalProperty "uirevision" UIRevision
            |> DynObj.withOptionalPropertyBy "valign" VerticalAlign StyleParam.VerticalAlign.convert
            |> DynObj.withOptionalProperty "visible" Visible
            |> DynObj.withOptionalProperty "x" X
            |> DynObj.withOptionalPropertyBy "xanchor" XAnchor StyleParam.XAnchorPosition.convert
            |> DynObj.withOptionalProperty "xref" XRef
            |> DynObj.withOptionalProperty "y" Y
            |> DynObj.withOptionalPropertyBy "yanchor" YAnchor StyleParam.YAnchorPosition.convert
            |> DynObj.withOptionalProperty "yref" YRef
        )
