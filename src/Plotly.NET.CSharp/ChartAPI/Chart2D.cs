using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plotly.NET;
using Plotly.NET.LayoutObjects;
using Plotly.NET.TraceObjects;
using System.Runtime.InteropServices;
using static Plotly.NET.StyleParam;

namespace Plotly.NET.CSharp
{
    public static partial class Chart
    {
        /// <summary>
        /// Creates a Scatter plot.
        ///
        /// Scatter charts are the basis of Point, Line, and Bubble Charts, and can be customized as such. We also provide abstractions for those: Chart.Line, Chart.Point, Chart.Bubble
        /// </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="mode">Determines the drawing mode for this scatter trace.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="Fill">Sets the area to fill with a solid color. Defaults to "none" unless this trace is stacked, then it gets "tonexty" ("tonextx") if `orientation` is "v" ("h") Use with `FillColor` if not "none". "tozerox" and "tozeroy" fill to x=0 and y=0 respectively. "tonextx" and "tonexty" fill between the endpoints of this trace and the endpoints of the trace before it, connecting those endpoints with straight lines (to make a stacked area graph); if there is no trace before it, they behave like "tozerox" and "tozeroy". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape. "tonext" fills the space between two traces if one completely encloses the other (eg consecutive contour lines), and behaves like "toself" if there is no trace before it. "tonext" should not be used if one trace does not enclose the other. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order.</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="FillPattern">Sets the pattern within the marker.</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Scatter<XType,YType,TextType>(
            IEnumerable<XType> x,
            IEnumerable<YType> y,
            StyleParam.Mode mode,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<IEnumerable<double>> MultiOpacity = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<StyleParam.TextPosition> TextPosition = default,
            Optional<IEnumerable<StyleParam.TextPosition>> MultiTextPosition = default,
            Optional<Color> MarkerColor = default,
            Optional<StyleParam.Colorscale> MarkerColorScale = default,
            Optional<Line> MarkerOutline = default,
            Optional<StyleParam.MarkerSymbol> MarkerSymbol = default,
            Optional<IEnumerable<StyleParam.MarkerSymbol>> MultiMarkerSymbol = default,
            Optional<Marker> Marker = default,
            Optional<Color> LineColor = default,
            Optional<StyleParam.Colorscale> LineColorScale = default,
            Optional<double> LineWidth = default,
            Optional<StyleParam.DrawingStyle> LineDash = default,
            Optional<Line> Line = default,
            Optional<string> AlignmentGroup = default,
            Optional<string> OffsetGroup = default,
            Optional<string> StackGroup = default,
            Optional<StyleParam.Orientation> Orientation = default,
            Optional<StyleParam.GroupNorm> GroupNorm = default,
            Optional<StyleParam.Fill> Fill = default,
            Optional<Color> FillColor = default,
            Optional<Pattern> FillPattern = default,
            Optional<bool> UseWebGL = default,
            Optional<bool> UseDefaults = default
        )
            where XType : IConvertible
            where YType : IConvertible
            where TextType : IConvertible
        =>
            Plotly.NET.Chart2D.Chart.Scatter(
                x: x, 
                y: y, 
                mode: mode,
                Name: Name.ToOption(),
                ShowLegend: ShowLegend.ToOption(),
                Opacity: Opacity.ToOption(),
                MultiOpacity: MultiOpacity.ToOption(),
                Text: Text.ToOption(),
                MultiText: MultiText.ToOption(),
                TextPosition: TextPosition.ToOption(),
                MultiTextPosition: MultiTextPosition.ToOption(),
                MarkerColor: MarkerColor.ToOption(),
                MarkerColorScale: MarkerColorScale.ToOption(),
                MarkerOutline: MarkerOutline.ToOption(),
                MarkerSymbol: MarkerSymbol.ToOption(),
                MultiMarkerSymbol: MultiMarkerSymbol.ToOption(),
                Marker: Marker.ToOption(),
                LineColor: LineColor.ToOption(),
                LineColorScale: LineColorScale.ToOption(),
                LineWidth: LineWidth.ToOption(),
                LineDash: LineDash.ToOption(),
                Line: Line.ToOption(),
                AlignmentGroup: AlignmentGroup.ToOption(),
                OffsetGroup: OffsetGroup.ToOption(),
                StackGroup: StackGroup.ToOption(),
                Orientation: Orientation.ToOption(),
                GroupNorm: GroupNorm.ToOption(),
                Fill: Fill.ToOption(),
                FillColor: FillColor.ToOption(),
                FillPattern: FillPattern.ToOption(),
                UseWebGL: UseWebGL.ToOption(),
                UseDefaults: UseDefaults.ToOption()
            );

        /// <summary>
        /// Creates a Point chart, which uses Points in a 2D space to visualize data.
        /// </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Point<XType, YType, TextType>(
            IEnumerable<XType> x,
            IEnumerable<YType> y,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<IEnumerable<double>> MultiOpacity = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<StyleParam.TextPosition> TextPosition = default,
            Optional<IEnumerable<StyleParam.TextPosition>> MultiTextPosition = default,
            Optional<Color> MarkerColor = default,
            Optional<StyleParam.Colorscale> MarkerColorScale = default,
            Optional<Line> MarkerOutline = default,
            Optional<StyleParam.MarkerSymbol> MarkerSymbol = default,
            Optional<IEnumerable<StyleParam.MarkerSymbol>> MultiMarkerSymbol = default,
            Optional<Marker> Marker = default,
            Optional<string> AlignmentGroup = default,
            Optional<string> OffsetGroup = default,
            Optional<string> StackGroup = default,
            Optional<StyleParam.Orientation> Orientation = default,
            Optional<StyleParam.GroupNorm> GroupNorm = default,
            Optional<bool> UseWebGL = default,
            Optional<bool> UseDefaults = default
        )
            where XType : IConvertible
            where YType : IConvertible
            where TextType : IConvertible
        =>
            Plotly.NET.Chart2D.Chart.Point(
                x: x,
                y: y,
                Name: Name.ToOption(),
                ShowLegend: ShowLegend.ToOption(),
                Opacity: Opacity.ToOption(),
                MultiOpacity: MultiOpacity.ToOption(),
                Text: Text.ToOption(),
                MultiText: MultiText.ToOption(),
                TextPosition: TextPosition.ToOption(),
                MultiTextPosition: MultiTextPosition.ToOption(),
                MarkerColor: MarkerColor.ToOption(),
                MarkerColorScale: MarkerColorScale.ToOption(),
                MarkerOutline: MarkerOutline.ToOption(),
                MarkerSymbol: MarkerSymbol.ToOption(),
                MultiMarkerSymbol: MultiMarkerSymbol.ToOption(),
                Marker: Marker.ToOption(),
                AlignmentGroup: AlignmentGroup.ToOption(),
                OffsetGroup: OffsetGroup.ToOption(),
                StackGroup: StackGroup.ToOption(),
                Orientation: Orientation.ToOption(),
                GroupNorm: GroupNorm.ToOption(),
                UseWebGL: UseWebGL.ToOption(),
                UseDefaults: UseDefaults.ToOption()
            );

        /// <summary> Creates a Line chart, which uses a Line plotted between the given datums in a 2D space to visualize typically an evolution of Y depending on X.</summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="ShowMarkers">Whether to show markers for the individual data points</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="Fill">Sets the area to fill with a solid color. Defaults to "none" unless this trace is stacked, then it gets "tonexty" ("tonextx") if `orientation` is "v" ("h") Use with `FillColor` if not "none". "tozerox" and "tozeroy" fill to x=0 and y=0 respectively. "tonextx" and "tonexty" fill between the endpoints of this trace and the endpoints of the trace before it, connecting those endpoints with straight lines (to make a stacked area graph); if there is no trace before it, they behave like "tozerox" and "tozeroy". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape. "tonext" fills the space between two traces if one completely encloses the other (eg consecutive contour lines), and behaves like "toself" if there is no trace before it. "tonext" should not be used if one trace does not enclose the other. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order.</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="FillPattern">Sets the pattern within the marker.</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Line<XType, YType, TextType>(
            IEnumerable<XType> x,
            IEnumerable<YType> y,
            Optional<bool> ShowMarkers = default,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<IEnumerable<double>> MultiOpacity = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<StyleParam.TextPosition> TextPosition = default,
            Optional<IEnumerable<StyleParam.TextPosition>> MultiTextPosition = default,
            Optional<Color> MarkerColor = default,
            Optional<StyleParam.Colorscale> MarkerColorScale = default,
            Optional<Line> MarkerOutline = default,
            Optional<StyleParam.MarkerSymbol> MarkerSymbol = default,
            Optional<IEnumerable<StyleParam.MarkerSymbol>> MultiMarkerSymbol = default,
            Optional<Marker> Marker = default,
            Optional<Color> LineColor = default,
            Optional<StyleParam.Colorscale> LineColorScale = default,
            Optional<double> LineWidth = default,
            Optional<StyleParam.DrawingStyle> LineDash = default,
            Optional<Line> Line = default,
            Optional<string> AlignmentGroup = default,
            Optional<string> OffsetGroup = default,
            Optional<string> StackGroup = default,
            Optional<StyleParam.Orientation> Orientation = default,
            Optional<StyleParam.GroupNorm> GroupNorm = default,
            Optional<StyleParam.Fill> Fill = default,
            Optional<Color> FillColor = default,
            Optional<Pattern> FillPattern = default,
            Optional<bool> UseWebGL = default,
            Optional<bool> UseDefaults = default
        )
            where XType : IConvertible
            where YType : IConvertible
            where TextType : IConvertible
        =>
            Plotly.NET.Chart2D.Chart.Line(
                x: x,
                y: y,
                ShowMarkers: ShowMarkers.ToOption(),
                Name: Name.ToOption(),
                ShowLegend: ShowLegend.ToOption(),
                Opacity: Opacity.ToOption(),
                MultiOpacity: MultiOpacity.ToOption(),
                Text: Text.ToOption(),
                MultiText: MultiText.ToOption(),
                TextPosition: TextPosition.ToOption(),
                MultiTextPosition: MultiTextPosition.ToOption(),
                MarkerColor: MarkerColor.ToOption(),
                MarkerColorScale: MarkerColorScale.ToOption(),
                MarkerOutline: MarkerOutline.ToOption(),
                MarkerSymbol: MarkerSymbol.ToOption(),
                MultiMarkerSymbol: MultiMarkerSymbol.ToOption(),
                Marker: Marker.ToOption(),
                LineColor: LineColor.ToOption(),
                LineColorScale: LineColorScale.ToOption(),
                LineWidth: LineWidth.ToOption(),
                LineDash: LineDash.ToOption(),
                Line: Line.ToOption(),
                AlignmentGroup: AlignmentGroup.ToOption(),
                OffsetGroup: OffsetGroup.ToOption(),
                StackGroup: StackGroup.ToOption(),
                Orientation: Orientation.ToOption(),
                GroupNorm: GroupNorm.ToOption(),
                Fill: Fill.ToOption(),
                FillColor: FillColor.ToOption(),
                FillPattern: FillPattern.ToOption(),
                UseWebGL: UseWebGL.ToOption(),
                UseDefaults: UseDefaults.ToOption()
            );

        /// <summary>Creates a Spline chart. A spline chart is a line chart in which data points are connected by smoothed curves: this modification is aimed to improve the design of a chart.
        /// Very similar to Line Plots, spline charts are typically used to visualize an evolution of Y depending on X. </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="ShowMarkers">Whether to show markers for the individual data points</param>
        /// <param name="Smoothing">Sets the amount of smoothing. "0" corresponds to no smoothing (equivalent to a "linear" shape).  Use values between 0. and 1.3</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="Fill">Sets the area to fill with a solid color. Defaults to "none" unless this trace is stacked, then it gets "tonexty" ("tonextx") if `orientation` is "v" ("h") Use with `FillColor` if not "none". "tozerox" and "tozeroy" fill to x=0 and y=0 respectively. "tonextx" and "tonexty" fill between the endpoints of this trace and the endpoints of the trace before it, connecting those endpoints with straight lines (to make a stacked area graph); if there is no trace before it, they behave like "tozerox" and "tozeroy". "toself" connects the endpoints of the trace (or each segment of the trace if it has gaps) into a closed shape. "tonext" fills the space between two traces if one completely encloses the other (eg consecutive contour lines), and behaves like "toself" if there is no trace before it. "tonext" should not be used if one trace does not enclose the other. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order.</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="FillPattern">Sets the pattern within the marker.</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Spline<XType, YType, TextType>(
            IEnumerable<XType> x,
            IEnumerable<YType> y,
            Optional<bool> ShowMarkers = default,
            Optional<double> Smoothing = default,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<IEnumerable<double>> MultiOpacity = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<StyleParam.TextPosition> TextPosition = default,
            Optional<IEnumerable<StyleParam.TextPosition>> MultiTextPosition = default,
            Optional<Color> MarkerColor = default,
            Optional<StyleParam.Colorscale> MarkerColorScale = default,
            Optional<Line> MarkerOutline = default,
            Optional<StyleParam.MarkerSymbol> MarkerSymbol = default,
            Optional<IEnumerable<StyleParam.MarkerSymbol>> MultiMarkerSymbol = default,
            Optional<Marker> Marker = default,
            Optional<Color> LineColor = default,
            Optional<StyleParam.Colorscale> LineColorScale = default,
            Optional<double> LineWidth = default,
            Optional<StyleParam.DrawingStyle> LineDash = default,
            Optional<Line> Line = default,
            Optional<string> AlignmentGroup = default,
            Optional<string> OffsetGroup = default,
            Optional<string> StackGroup = default,
            Optional<StyleParam.Orientation> Orientation = default,
            Optional<StyleParam.GroupNorm> GroupNorm = default,
            Optional<StyleParam.Fill> Fill = default,
            Optional<Color> FillColor = default,
            Optional<Pattern> FillPattern = default,
            Optional<bool> UseWebGL = default,
            Optional<bool> UseDefaults = default
        )
            where XType : IConvertible
            where YType : IConvertible
            where TextType : IConvertible
        =>
            Plotly.NET.Chart2D.Chart.Spline(
                x: x,
                y: y,
                ShowMarkers: ShowMarkers.ToOption(),
                Smoothing: Smoothing.ToOption(),
                Name: Name.ToOption(),
                ShowLegend: ShowLegend.ToOption(),
                Opacity: Opacity.ToOption(),
                MultiOpacity: MultiOpacity.ToOption(),
                Text: Text.ToOption(),
                MultiText: MultiText.ToOption(),
                TextPosition: TextPosition.ToOption(),
                MultiTextPosition: MultiTextPosition.ToOption(),
                MarkerColor: MarkerColor.ToOption(),
                MarkerColorScale: MarkerColorScale.ToOption(),
                MarkerOutline: MarkerOutline.ToOption(),
                MarkerSymbol: MarkerSymbol.ToOption(),
                MultiMarkerSymbol: MultiMarkerSymbol.ToOption(),
                Marker: Marker.ToOption(),
                LineColor: LineColor.ToOption(),
                LineColorScale: LineColorScale.ToOption(),
                LineWidth: LineWidth.ToOption(),
                LineDash: LineDash.ToOption(),
                Line: Line.ToOption(),
                AlignmentGroup: AlignmentGroup.ToOption(),
                OffsetGroup: OffsetGroup.ToOption(),
                StackGroup: StackGroup.ToOption(),
                Orientation: Orientation.ToOption(),
                GroupNorm: GroupNorm.ToOption(),
                Fill: Fill.ToOption(),
                FillColor: FillColor.ToOption(),
                FillPattern: FillPattern.ToOption(),
                UseWebGL: UseWebGL.ToOption(),
                UseDefaults: UseDefaults.ToOption()
            );

        /// <summary>Creates a bubble chart. A bubble chart is a variation of the Point chart, where the data points get an additional scale by being rendered as bubbles of different sizes.</summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="sizes">Sets the bubble size of the plotted data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Bubble<XType, YType, TextType>(
            IEnumerable<XType> x,
            IEnumerable<YType> y,
            IEnumerable<int> sizes,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<IEnumerable<double>> MultiOpacity = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<StyleParam.TextPosition> TextPosition = default,
            Optional<IEnumerable<StyleParam.TextPosition>> MultiTextPosition = default,
            Optional<Color> MarkerColor = default,
            Optional<StyleParam.Colorscale> MarkerColorScale = default,
            Optional<Line> MarkerOutline = default,
            Optional<StyleParam.MarkerSymbol> MarkerSymbol = default,
            Optional<IEnumerable<StyleParam.MarkerSymbol>> MultiMarkerSymbol = default,
            Optional<Marker> Marker = default,
            Optional<Color> LineColor = default,
            Optional<StyleParam.Colorscale> LineColorScale = default,
            Optional<double> LineWidth = default,
            Optional<StyleParam.DrawingStyle> LineDash = default,
            Optional<Line> Line = default,
            Optional<string> AlignmentGroup = default,
            Optional<string> OffsetGroup = default,
            Optional<string> StackGroup = default,
            Optional<StyleParam.Orientation> Orientation = default,
            Optional<StyleParam.GroupNorm> GroupNorm = default,
            Optional<bool> UseWebGL = default,
            Optional<bool> UseDefaults = default
        )
            where XType : IConvertible
            where YType : IConvertible
            where TextType : IConvertible
        =>
            Plotly.NET.Chart2D.Chart.Bubble<XType, YType, TextType>(
                x: x,
                y: y,
                sizes: sizes,
                Name: Name.ToOption(),
                ShowLegend: ShowLegend.ToOption(),
                Opacity: Opacity.ToOption(),
                MultiOpacity: MultiOpacity.ToOption(),
                Text: Text.ToOption(),
                MultiText: MultiText.ToOption(),
                TextPosition: TextPosition.ToOption(),
                MultiTextPosition: MultiTextPosition.ToOption(),
                MarkerColor: MarkerColor.ToOption(),
                MarkerColorScale: MarkerColorScale.ToOption(),
                MarkerOutline: MarkerOutline.ToOption(),
                MarkerSymbol: MarkerSymbol.ToOption(),
                MultiMarkerSymbol: MultiMarkerSymbol.ToOption(),
                Marker: Marker.ToOption(),
                LineColor: LineColor.ToOption(),
                LineColorScale: LineColorScale.ToOption(),
                LineWidth: LineWidth.ToOption(),
                LineDash: LineDash.ToOption(),
                Line: Line.ToOption(),
                AlignmentGroup: AlignmentGroup.ToOption(),
                OffsetGroup: OffsetGroup.ToOption(),
                StackGroup: StackGroup.ToOption(),
                Orientation: Orientation.ToOption(),
                GroupNorm: GroupNorm.ToOption(),
                UseWebGL: UseWebGL.ToOption(),
                UseDefaults: UseDefaults.ToOption()
            );

        /// <summary>
        /// Displays a range of data by plotting three Y values per data point (upper, mid, lower).
        ///
        /// The mid Y value usually resembles some kind of central tendency and the upper/lower Y values some kind of spread.
        /// </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data for the mid Y value.</param>
        /// <param name="upper">Sets the y coordinates of the plotted data for the upper Y value.</param>
        /// <param name="lower">Sets the y coordinates of the plotted data for the lower Y value.</param>
        /// <param name="mode">Determines the drawing mode for this scatter trace.</param>
        /// <param name="Name">Sets the trace name of the mid Y values. The trace name appear as the legend item and on hover</param>
        /// <param name="GroupName">Sets the name of the legendgroup for the three traces of this plot.</param>
        /// <param name="ShowMarkers">Determines whether or not an To show markers for each datum.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Text">Sets a text associated with each datum for the mid Y values.</param>
        /// <param name="MultiText">Sets individual text for each datum for the mid Y values.</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker for the mid Y values.</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker for the mid Y values.</param>
        /// <param name="MarkerOutline">Sets the outline of the marker for the mid Y values.</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum for the mid Y values.</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum for the mid Y values.</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments) for the mid Y values.</param>
        /// <param name="LineColor">Sets the color of the line for the mid Y values.</param>
        /// <param name="LineColorScale">Sets the colorscale of the line for the mid Y values.</param>
        /// <param name="LineWidth">Sets the width of the line for the mid Y values.</param>
        /// <param name="LineDash">sets the drawing style of the line for the mid Y values.</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments) for the mid Y values.</param>
        /// <param name="RangeColor">Sets the color of the range between upper and lower Y values.</param>
        /// <param name="RangePattern">Sets the pattern of the range between upper and lower Y values.</param>
        /// <param name="UpperText">Sets a text associated with each datum for the upper Y values.</param>
        /// <param name="MultiUpperText">Sets individual text for each datum for the upper Y values.</param>
        /// <param name="LowerText">Sets a text associated with each datum for the lower Y values.</param>
        /// <param name="MultiLowerText">Sets individual text for each datum for the lower Y values.</param>
        /// <param name="TextFont">Sets the text font for all Text items</param>
        /// <param name="LowerName">Sets the name of the lower Y value trace.</param>
        /// <param name="LowerLine">Sets the line for the lower Y values.</param>
        /// <param name="LowerMarker">Sets the marker for the lower Y values.</param>
        /// <param name="UpperName">Sets the name of the uper Y value trace.</param>
        /// <param name="UpperLine">Sets the line for the upper Y values.</param>
        /// <param name="UpperMarker">Sets the marker for the upper Y values.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Range<XType, YType, TextType>(
            IEnumerable<XType> x, 
            IEnumerable<YType> y, 
            IEnumerable<YType> upper, 
            IEnumerable<YType> lower, 
            StyleParam.Mode mode, 
            Optional<string> Name = default, 
            Optional<string> GroupName = default, 
            Optional<bool> ShowMarkers = default, 
            Optional<bool> ShowLegend = default, 
            Optional<TextType> Text = default, 
            Optional<IEnumerable<TextType>> MultiText = default, 
            Optional<StyleParam.TextPosition> TextPosition = default, 
            Optional<IEnumerable<StyleParam.TextPosition>> MultiTextPosition = default, 
            Optional<Color> MarkerColor = default, 
            Optional<StyleParam.Colorscale> MarkerColorScale = default, 
            Optional<Line> MarkerOutline = default, 
            Optional<StyleParam.MarkerSymbol> MarkerSymbol = default,
            Optional<IEnumerable<StyleParam.MarkerSymbol>> MultiMarkerSymbol = default, 
            Optional<Marker> Marker = default,
            Optional<Marker> UpperMarker = default, 
            Optional<Marker> LowerMarker = default, 
            Optional<Color> LineColor = default, 
            Optional<StyleParam.Colorscale> LineColorScale = default,
            Optional<double> LineWidth = default,
            Optional<StyleParam.DrawingStyle> LineDash = default, 
            Optional<Line> Line = default,
            Optional<Line> UpperLine = default, 
            Optional<Line> LowerLine = default, 
            Optional<Color> RangeColor = default,
            Optional<Pattern> RangePattern = default,
            Optional<TextType> UpperText = default, 
            Optional<IEnumerable<TextType>> MultiUpperText = default, 
            Optional<TextType> LowerText = default, 
            Optional<IEnumerable<TextType>> MultiLowerText = default, 
            Optional<Font> TextFont = default, 
            Optional<string> LowerName = default, 
            Optional<string> UpperName = default, 
            Optional<bool> UseDefaults = default
        )
            where XType : IConvertible
            where YType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.Chart2D.Chart.Range<XType, YType, YType, YType, TextType, TextType, TextType>(
                    x: x,
                    y: y,
                    upper: upper,
                    lower: lower,
                    mode: mode,
                    Name: Name.ToOption(),
                    GroupName: GroupName.ToOption(),
                    ShowMarkers: ShowMarkers.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    TextPosition: TextPosition.ToOption(),
                    MultiTextPosition: MultiTextPosition.ToOption(),
                    MarkerColor: MarkerColor.ToOption(),
                    MarkerColorScale: MarkerColorScale.ToOption(),
                    MarkerOutline: MarkerOutline.ToOption(),
                    MarkerSymbol: MarkerSymbol.ToOption(),
                    MultiMarkerSymbol: MultiMarkerSymbol.ToOption(),
                    Marker: Marker.ToOption(),
                    UpperMarker: UpperMarker.ToOption(),
                    LowerMarker: LowerMarker.ToOption(),
                    LineColor: LineColor.ToOption(),
                    LineColorScale: LineColorScale.ToOption(),
                    LineWidth: LineWidth.ToOption(),
                    LineDash: LineDash.ToOption(),
                    Line: Line.ToOption(),
                    UpperLine: UpperLine.ToOption(),
                    LowerLine: LowerLine.ToOption(),
                    RangeColor: RangeColor.ToOption(),
                    RangePattern: RangePattern.ToOption(),
                    UpperText: UpperText.ToOption(),
                    MultiUpperText: MultiUpperText.ToOption(),
                    LowerText: LowerText.ToOption(),
                    MultiLowerText: MultiLowerText.ToOption(),
                    TextFont: TextFont.ToOption(),
                    LowerName: LowerName.ToOption(),
                    UpperName: UpperName.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );
        
        /// <summary> Creates a Pareto chart. </summary>
        /// <param name="keysValues">Sets the (key,value) pairs that are plotted as the size and key of each bar.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="Label">Sets the y axis label.</param>
        /// <param name="ShowGrid">Determines whether or not grid lines are drawn. If "true", the grid lines are drawn for the pareto distribution figure; defaults to true.</param>
        public static GenericChart Pareto<TLabel>(
            IEnumerable<(TLabel,double)> keysValues
            , Optional<string> Name
            , Optional<string> Label
            , Optional<bool> ShowGrid
            ) 
            where TLabel : IConvertible
            =>
                Chart2D.Chart.Pareto(
                    keysValues.Select(t => t.ToTuple())
                    , Name: Name.ToOption()
                    , Label: Label.ToOption()
                    , ShowGrid: ShowGrid.ToOption()
                );
        /// <summary> Creates a Pareto chart. </summary>
        /// <param name="labels">Sets the labels that are matching the <see paramref="values"/>.</param>
        /// <param name="values">Sets the values that are plotted as the size of each bar.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="Label">Sets the y axis label.</param>
        /// <param name="ShowGrid">Determines whether or not grid lines are drawn. If "true", the grid lines are drawn for the pareto distribution figure; defaults to true.</param>
        public static GenericChart Pareto<TLabel>(
            IEnumerable<TLabel> labels
            , IEnumerable<double> values
            , Optional<string> Name
            , Optional<string> Label
            , Optional<bool> ShowGrid
            ) 
            where TLabel : IConvertible
            =>
                Chart2D.Chart.Pareto(
                    labels
                    , values
                    , Name: Name.ToOption()
                    , Label: Label.ToOption()
                    , ShowGrid: ShowGrid.ToOption()
                );

        /// <summary> Creates an Area chart, which uses a Line plotted between the given datums in a 2D space, additionally colouring the area between the line and the Y Axis.</summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="ShowMarkers">Whether to show markers for the individual data points</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="FillPatternShape">Sets a pattern shape for the area fill</param>
        /// <param name="FillPattern">Sets the pattern within the area. (use this for more finegrained control than the other fillpattern-associated arguments).</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Area<XType, YType, TextType>(
            IEnumerable<XType> x, 
            IEnumerable<YType> y, 
            Optional<bool> ShowMarkers = default, 
            Optional<string> Name = default, 
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<IEnumerable<double>> MultiOpacity = default,
            Optional<TextType> Text = default, 
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<StyleParam.TextPosition> TextPosition = default, 
            Optional<IEnumerable<StyleParam.TextPosition>> MultiTextPosition = default, 
            Optional<Color> MarkerColor = default, 
            Optional<StyleParam.Colorscale> MarkerColorScale = default,
            Optional<Line> MarkerOutline = default, 
            Optional<StyleParam.MarkerSymbol> MarkerSymbol = default, 
            Optional<IEnumerable<StyleParam.MarkerSymbol>> MultiMarkerSymbol = default, 
            Optional<Marker> Marker = default, 
            Optional<Color> LineColor = default, 
            Optional<StyleParam.Colorscale> LineColorScale = default, 
            Optional<double> LineWidth = default, 
            Optional<StyleParam.DrawingStyle> LineDash = default, 
            Optional<Line> Line = default,
            Optional<string> AlignmentGroup = default,
            Optional<string> OffsetGroup = default,
            Optional<string> StackGroup = default, 
            Optional<StyleParam.Orientation> Orientation = default,
            Optional<StyleParam.GroupNorm> GroupNorm = default, 
            Optional<Color> FillColor = default,
            Optional<StyleParam.PatternShape> FillPatternShape = default,
            Optional<Pattern> FillPattern = default,
            Optional<bool> UseWebGL = default, 
            Optional<bool> UseDefaults = default
        )
            where XType : IConvertible
            where YType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.Chart2D.Chart.Area<XType, YType, TextType>(
                    x: x,
                    y: y,
                    ShowMarkers: ShowMarkers.ToOption(),
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    MultiOpacity: MultiOpacity.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    TextPosition: TextPosition.ToOption(),
                    MultiTextPosition: MultiTextPosition.ToOption(),
                    MarkerColor: MarkerColor.ToOption(),
                    MarkerColorScale: MarkerColorScale.ToOption(),
                    MarkerOutline: MarkerOutline.ToOption(),
                    MarkerSymbol: MarkerSymbol.ToOption(),
                    MultiMarkerSymbol: MultiMarkerSymbol.ToOption(),
                    Marker: Marker.ToOption(),
                    LineColor: LineColor.ToOption(),
                    LineColorScale: LineColorScale.ToOption(),
                    LineWidth: LineWidth.ToOption(),
                    LineDash: LineDash.ToOption(),
                    Line: Line.ToOption(),
                    AlignmentGroup: AlignmentGroup.ToOption(),
                    OffsetGroup: OffsetGroup.ToOption(),
                    StackGroup: StackGroup.ToOption(),
                    Orientation: Orientation.ToOption(),
                    GroupNorm: GroupNorm.ToOption(),
                    FillColor: FillColor.ToOption(),
                    FillPatternShape: FillPatternShape.ToOption(),
                    FillPattern: FillPattern.ToOption(),
                    UseWebGL: UseWebGL.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>Creates a Spline area chart, which uses a smoothed Line plotted between the given datums in a 2D space, additionally colouring the area between the line and the Y Axis.</summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="ShowMarkers">Whether to show markers for the individual data points</param>
        /// <param name="Smoothing">Sets the amount of smoothing. "0" corresponds to no smoothing (equivalent to a "linear" shape).  Use values between 0. and 1.3</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="StackGroup">Set several traces (on the same subplot) to the same stackgroup in order to add their y values (or their x values if `Orientation` is Horizontal). Stacking also turns `fill` on by default and sets the default `mode` to "lines" irrespective of point count. ou can only stack on a numeric (linear or log) axis. Traces in a `stackgroup` will only fill to (or be filled to) other traces in the same group. With multiple `stackgroup`s or some traces stacked and some not, if fill-linked traces are not already consecutive, the later ones will be pushed down in the drawing order</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="FillColor">ets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="FillPatternShape">Sets a pattern shape for the area fill</param>
        /// <param name="FillPattern">Sets the pattern within the area. (use this for more finegrained control than the other fillpattern-associated arguments).</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart SplineArea<XType, YType, TextType>(
            IEnumerable<XType> x,
            IEnumerable<YType> y,
            Optional<bool> ShowMarkers = default,
            Optional<double> Smoothing = default,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<IEnumerable<double>> MultiOpacity = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<StyleParam.TextPosition> TextPosition = default,
            Optional<IEnumerable<StyleParam.TextPosition>> MultiTextPosition = default,
            Optional<Color> MarkerColor = default,
            Optional<StyleParam.Colorscale> MarkerColorScale = default,
            Optional<Line> MarkerOutline = default,
            Optional<StyleParam.MarkerSymbol> MarkerSymbol = default,
            Optional<IEnumerable<StyleParam.MarkerSymbol>> MultiMarkerSymbol = default,
            Optional<Marker> Marker = default,
            Optional<Color> LineColor = default,
            Optional<StyleParam.Colorscale> LineColorScale = default,
            Optional<double> LineWidth = default,
            Optional<StyleParam.DrawingStyle> LineDash = default,
            Optional<Line> Line = default,
            Optional<string> AlignmentGroup = default,
            Optional<string> OffsetGroup = default,
            Optional<string> StackGroup = default,
            Optional<StyleParam.Orientation> Orientation = default,
            Optional<StyleParam.GroupNorm> GroupNorm = default,
            Optional<Color> FillColor = default,
            Optional<StyleParam.PatternShape> FillPatternShape = default,
            Optional<Pattern> FillPattern = default,
            Optional<bool> UseWebGL = default,
            Optional<bool> UseDefaults = default
        )
            where XType : IConvertible
            where YType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.Chart2D.Chart.SplineArea<XType, YType, TextType>(
                    x: x,
                    y: y,
                    ShowMarkers: ShowMarkers.ToOption(),
                    Smoothing: Smoothing.ToOption(),
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    MultiOpacity: MultiOpacity.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    TextPosition: TextPosition.ToOption(),
                    MultiTextPosition: MultiTextPosition.ToOption(),
                    MarkerColor: MarkerColor.ToOption(),
                    MarkerColorScale: MarkerColorScale.ToOption(),
                    MarkerOutline: MarkerOutline.ToOption(),
                    MarkerSymbol: MarkerSymbol.ToOption(),
                    MultiMarkerSymbol: MultiMarkerSymbol.ToOption(),
                    Marker: Marker.ToOption(),
                    LineColor: LineColor.ToOption(),
                    LineColorScale: LineColorScale.ToOption(),
                    LineWidth: LineWidth.ToOption(),
                    LineDash: LineDash.ToOption(),
                    Line: Line.ToOption(),
                    AlignmentGroup: AlignmentGroup.ToOption(),
                    OffsetGroup: OffsetGroup.ToOption(),
                    StackGroup: StackGroup.ToOption(),
                    Orientation: Orientation.ToOption(),
                    GroupNorm: GroupNorm.ToOption(),
                    FillColor: FillColor.ToOption(),
                    FillPatternShape: FillPatternShape.ToOption(),
                    FillPattern: FillPattern.ToOption(),
                    UseWebGL: UseWebGL.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary> Creates a stacked Area chart, which uses a Line plotted between the given datums in a 2D space, additionally colouring the area between the line and the Y Axis. Multiple Charts of this type are stacked on top of each others y dimensions</summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="ShowMarkers">Whether to show markers for the individual data points</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="MarkerColor">Sets the color of the marker</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the marker symbol for each datum</param>
        /// <param name="MultiMarkerSymbol">Sets the marker symbol for each individual datum</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="LineColor">Sets the color of the line</param>
        /// <param name="LineColorScale">Sets the colorscale of the line</param>
        /// <param name="LineWidth">Sets the width of the line</param>
        /// <param name="LineDash">sets the drawing style of the line</param>
        /// <param name="Line">Sets the line (use this for more finegrained control than the other line-associated arguments)</param>
        /// <param name="Orientation">Sets the stacking direction. Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used.</param>
        /// <param name="GroupNorm">Sets the normalization for the sum of this `stackgroup. Only relevant when `stackgroup` is used, and only the first `groupnorm` found in the `stackgroup` will be used</param>
        /// <param name="FillColor">ets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="FillPatternShape">Sets a pattern shape for the area fill</param>
        /// <param name="FillPattern">Sets the pattern within the area. (use this for more finegrained control than the other fillpattern-associated arguments).</param>
        /// <param name="UseWebGL">If true, plotly.js will use the WebGL engine to render this chart. use this when you want to render many objects at once.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart StackedArea<XType, YType, TextType>(
            IEnumerable<XType> x,
            IEnumerable<YType> y,
            Optional<bool> ShowMarkers = default,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<IEnumerable<double>> MultiOpacity = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<StyleParam.TextPosition> TextPosition = default,
            Optional<IEnumerable<StyleParam.TextPosition>> MultiTextPosition = default,
            Optional<Color> MarkerColor = default,
            Optional<StyleParam.Colorscale> MarkerColorScale = default,
            Optional<Line> MarkerOutline = default,
            Optional<StyleParam.MarkerSymbol> MarkerSymbol = default,
            Optional<IEnumerable<StyleParam.MarkerSymbol>> MultiMarkerSymbol = default,
            Optional<Marker> Marker = default,
            Optional<Color> LineColor = default,
            Optional<StyleParam.Colorscale> LineColorScale = default,
            Optional<double> LineWidth = default,
            Optional<StyleParam.DrawingStyle> LineDash = default,
            Optional<Line> Line = default,
            Optional<StyleParam.Orientation> Orientation = default,
            Optional<StyleParam.GroupNorm> GroupNorm = default,
            Optional<Color> FillColor = default,
            Optional<StyleParam.PatternShape> FillPatternShape = default,
            Optional<Pattern> FillPattern = default,
            Optional<bool> UseWebGL = default,
            Optional<bool> UseDefaults = default
        )
            where XType : IConvertible
            where YType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.Chart2D.Chart.StackedArea<XType, YType, TextType>(
                    x: x,
                    y: y,
                    ShowMarkers: ShowMarkers.ToOption(),
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    MultiOpacity: MultiOpacity.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    TextPosition: TextPosition.ToOption(),
                    MultiTextPosition: MultiTextPosition.ToOption(),
                    MarkerColor: MarkerColor.ToOption(),
                    MarkerColorScale: MarkerColorScale.ToOption(),
                    MarkerOutline: MarkerOutline.ToOption(),
                    MarkerSymbol: MarkerSymbol.ToOption(),
                    MultiMarkerSymbol: MultiMarkerSymbol.ToOption(),
                    Marker: Marker.ToOption(),
                    LineColor: LineColor.ToOption(),
                    LineColorScale: LineColorScale.ToOption(),
                    LineWidth: LineWidth.ToOption(),
                    LineDash: LineDash.ToOption(),
                    Line: Line.ToOption(),
                    Orientation: Orientation.ToOption(),
                    GroupNorm: GroupNorm.ToOption(),
                    FillColor: FillColor.ToOption(),
                    FillPatternShape: FillPatternShape.ToOption(),
                    FillPattern: FillPattern.ToOption(),
                    UseWebGL: UseWebGL.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Creates a Funnel chart.
        ///
        /// Funnel charts visualize stages in a process using length-encoded bars. This trace can be used to show data in either a part-to-whole representation wherein each item appears in a single stage, or in a "drop-off" representation wherein each item appears in each stage it traversed. See also the "funnelarea" trace type for a different approach to visualizing funnel data.
        /// </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="Width">Sets the bar width (in position axis units).</param>
        /// <param name="Offset">Shifts the position where the bar is drawn (in position axis units). In "group" barmode, traces that set "offset" will be excluded and drawn in "overlay" mode instead.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="Orientation">Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used - including if `visible` is "legendonly" but not if it is `false`. Sets the stacking direction. With "v" ("h"), the y (x) values of subsequent traces are added. Also affects the default value of `fill`.</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="MarkerColor">Sets the color of the bars.</param>
        /// <param name="MarkerOutline">Sets the color of the bar outline.</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="TextInfo">Determines which trace information appear on the graph. In the case of having multiple funnels, percentages and totals are computed separately (per trace).</param>
        /// <param name="ConnectorLineColor">Sets the line color of the funnel connector</param>
        /// <param name="ConnectorLineStyle">Sets the line style of the funnel connector</param>
        /// <param name="ConnectorFillColor">Sets the fill color of the funnel connector</param>
        /// <param name="ConnectorLine">Sets the line of the funnel connector (use this for more finegrained control than the other connector line associated arguments).</param>
        /// <param name="Connector">Sets the funnel connector (use this for more finegrained control than the other connector-associated arguments).</param>
        /// <param name="InsideTextFont">Sets the font used for `text` lying inside the bar.</param>
        /// <param name="OutsideTextFont">Sets the font used for `text` lying outside the bar.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Funnel<XType, YType, TextType>(
            IEnumerable<XType> x,
            IEnumerable<YType> y,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<double> Width = default,
            Optional<double> Offset = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<StyleParam.TextPosition> TextPosition = default,
            Optional<IEnumerable<StyleParam.TextPosition>> MultiTextPosition = default,
            Optional<StyleParam.Orientation> Orientation = default,
            Optional<string> AlignmentGroup = default,
            Optional<string> OffsetGroup = default,
            Optional<Color> MarkerColor = default,
            Optional<Line> MarkerOutline = default,
            Optional<Marker> Marker = default,
            Optional<StyleParam.TextInfo> TextInfo = default,
            Optional<Color> ConnectorLineColor = default,
            Optional<StyleParam.DrawingStyle> ConnectorLineStyle = default,
            Optional<Color> ConnectorFillColor = default,
            Optional<Line> ConnectorLine = default,
            Optional<FunnelConnector> Connector = default,
            Optional<Font> InsideTextFont = default,
            Optional<Font> OutsideTextFont = default,
            Optional<bool> UseDefaults = default
        )
            where XType : IConvertible
            where YType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.Chart2D.Chart.Funnel<XType, YType, TextType>(
                    x: x,
                    y: y,
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    Width: Width.ToOption(),
                    Offset: Offset.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    TextPosition: TextPosition.ToOption(),
                    MultiTextPosition: MultiTextPosition.ToOption(),
                    Orientation: Orientation.ToOption(),
                    AlignmentGroup: AlignmentGroup.ToOption(),
                    OffsetGroup: OffsetGroup.ToOption(),
                    MarkerColor: MarkerColor.ToOption(),
                    MarkerOutline: MarkerOutline.ToOption(),
                    Marker: Marker.ToOption(),
                    TextInfo: TextInfo.ToOption(),
                    ConnectorLineColor: ConnectorLineColor.ToOption(),
                    ConnectorLineStyle: ConnectorLineStyle.ToOption(),
                    ConnectorFillColor: ConnectorFillColor.ToOption(),
                    ConnectorLine: ConnectorLine.ToOption(),
                    Connector: Connector.ToOption(),
                    InsideTextFont: InsideTextFont.ToOption(),
                    OutsideTextFont: OutsideTextFont.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Creates a stacked Funnel chart, a variation of the funnel chart where multiple funnel bars of each stage are stacked on top of each other.
        /// To create this type of chart, combine multiple of these charts via `Chart.combine`.
        ///
        /// Funnel charts visualize stages in a process using length-encoded bars. This trace can be used to show data in either a part-to-whole representation wherein each item appears in a single stage, or in a "drop-off" representation wherein each item appears in each stage it traversed. See also the "funnelarea" trace type for a different approach to visualizing funnel data.
        /// </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="Width">Sets the bar width (in position axis units).</param>
        /// <param name="Offset">Shifts the position where the bar is drawn (in position axis units). In "group" barmode, traces that set "offset" will be excluded and drawn in "overlay" mode instead.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="Orientation">Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used - including if `visible` is "legendonly" but not if it is `false`. Sets the stacking direction. With "v" ("h"), the y (x) values of subsequent traces are added. Also affects the default value of `fill`.</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="MarkerColor">Sets the color of the bars.</param>
        /// <param name="MarkerOutline">Sets the color of the bar outline.</param>
        /// <param name="Marker">Sets the marker (use this for more finegrained control than the other marker-associated arguments)</param>
        /// <param name="TextInfo">Determines which trace information appear on the graph. In the case of having multiple funnels, percentages and totals are computed separately (per trace).</param>
        /// <param name="ConnectorLineColor">Sets the line color of the funnel connector</param>
        /// <param name="ConnectorLineStyle">Sets the line style of the funnel connector</param>
        /// <param name="ConnectorFillColor">Sets the fill color of the funnel connector</param>
        /// <param name="ConnectorLine">Sets the line of the funnel connector (use this for more finegrained control than the other connector line associated arguments).</param>
        /// <param name="Connector">Sets the funnel connector (use this for more finegrained control than the other connector-associated arguments).</param>
        /// <param name="InsideTextFont">Sets the font used for `text` lying inside the bar.</param>
        /// <param name="OutsideTextFont">Sets the font used for `text` lying outside the bar.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart StackedFunnel<XType, YType, TextType>(
            IEnumerable<XType> x,
            IEnumerable<YType> y,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<double> Width = default,
            Optional<double> Offset = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<StyleParam.TextPosition> TextPosition = default,
            Optional<IEnumerable<StyleParam.TextPosition>> MultiTextPosition = default,
            Optional<StyleParam.Orientation> Orientation = default,
            Optional<string> AlignmentGroup = default,
            Optional<string> OffsetGroup = default,
            Optional<Color> MarkerColor = default,
            Optional<Line> MarkerOutline = default,
            Optional<Marker> Marker = default,
            Optional<StyleParam.TextInfo> TextInfo = default,
            Optional<Color> ConnectorLineColor = default,
            Optional<StyleParam.DrawingStyle> ConnectorLineStyle = default,
            Optional<Color> ConnectorFillColor = default,
            Optional<Line> ConnectorLine = default,
            Optional<FunnelConnector> Connector = default,
            Optional<Font> InsideTextFont = default,
            Optional<Font> OutsideTextFont = default,
            Optional<bool> UseDefaults = default
        )
            where XType : IConvertible
            where YType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.Chart2D.Chart.StackedFunnel<XType, YType, TextType>(
                    x: x,
                    y: y,
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    Width: Width.ToOption(),
                    Offset: Offset.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    TextPosition: TextPosition.ToOption(),
                    MultiTextPosition: MultiTextPosition.ToOption(),
                    Orientation: Orientation.ToOption(),
                    AlignmentGroup: AlignmentGroup.ToOption(),
                    OffsetGroup: OffsetGroup.ToOption(),
                    MarkerColor: MarkerColor.ToOption(),
                    MarkerOutline: MarkerOutline.ToOption(),
                    Marker: Marker.ToOption(),
                    TextInfo: TextInfo.ToOption(),
                    ConnectorLineColor: ConnectorLineColor.ToOption(),
                    ConnectorLineStyle: ConnectorLineStyle.ToOption(),
                    ConnectorFillColor: ConnectorFillColor.ToOption(),
                    ConnectorLine: ConnectorLine.ToOption(),
                    Connector: Connector.ToOption(),
                    InsideTextFont: InsideTextFont.ToOption(),
                    OutsideTextFont: OutsideTextFont.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Creates a waterfall chart.
        ///
        /// Waterfall charts are special bar charts that help visualizing the cumulative effect of sequentially introduced positive or negative values
        /// </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="IncreasingColor">Sets the color of increasing values</param>
        /// <param name="Increasing">Sets the style options of increasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="DecreasingColor">Sets the color of decreasing values</param>
        /// <param name="Decreasing">Sets the style options of decreasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="TotalsColor">Sets the color of total values</param>
        /// <param name="Totals">Sets the style options of total values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units).</param>
        /// <param name="MultiWidth">Sets the individual bar width of each datum (in position axis units).</param>
        /// <param name="Opacity">Sets the opacity of the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="TextFont">Sets the font used for `text`.</param>
        /// <param name="Connector">Sets the waterfall connector of this trace</param>
        /// <param name="Measure">An array containing types of measures. By default the values are considered as 'relative'. However; it is possible to use 'total' to compute the sums. Also 'absolute' could be applied to reset the computed total or to declare an initial value where needed.</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="Orientation">Only relevant when `stackgroup` is used, and only the first `orientation` found in the `stackgroup` will be used - including if `visible` is "legendonly" but not if it is `false`. Sets the stacking direction. With "v" ("h"), the y (x) values of subsequent traces are added. Also affects the default value of `fill`.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Waterfall<XType, YType, TextType>(
            IEnumerable<XType> x,
            IEnumerable<YType> y,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<Color> IncreasingColor = default,
            Optional<FinanceMarker> Increasing = default,
            Optional<Color> DecreasingColor = default,
            Optional<FinanceMarker> Decreasing = default,
            Optional<Color> TotalsColor = default,
            Optional<FinanceMarker> Totals = default,
            Optional<double> Base = default,
            Optional<double> Width = default,
            Optional<IEnumerable<double>> MultiWidth = default,
            Optional<double> Opacity = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<StyleParam.TextPosition> TextPosition = default,
            Optional<IEnumerable<StyleParam.TextPosition>> MultiTextPosition = default,
            Optional<Font> TextFont = default,
            Optional<WaterfallConnector> Connector = default,
            Optional<IEnumerable<StyleParam.WaterfallMeasure>> Measure = default,
            Optional<string> AlignmentGroup = default,
            Optional<string> OffsetGroup = default,
            Optional<StyleParam.Orientation> Orientation = default,
            Optional<bool> UseDefaults = default
        )
            where XType : IConvertible
            where YType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.Chart2D.Chart.Waterfall<XType, YType, TextType>(
                    x: x,
                    y: y,
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    IncreasingColor: IncreasingColor.ToOption(),
                    Increasing: Increasing.ToOption(),
                    DecreasingColor: DecreasingColor.ToOption(),
                    Decreasing: Decreasing.ToOption(),
                    TotalsColor: TotalsColor.ToOption(),
                    Totals: Totals.ToOption(),
                    Base: Base.ToOption(),
                    Width: Width.ToOption(),
                    MultiWidth: MultiWidth.ToOption(),
                    Opacity: Opacity.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    TextPosition: TextPosition.ToOption(),
                    MultiTextPosition: MultiTextPosition.ToOption(),
                    TextFont: TextFont.ToOption(),
                    Connector: Connector.ToOption(),
                    Measure: Measure.ToOption(),
                    AlignmentGroup: AlignmentGroup.ToOption(),
                    OffsetGroup: OffsetGroup.ToOption(),
                    Orientation: Orientation.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Creates a bar chart, with bars plotted horizontally
        ///
        /// A bar chart is a chart that presents categorical data with rectangular bars with heights or lengths proportional to the values that they represent.
        /// </summary>
        /// <param name="values">Sets the values that are plotted as the size of each bar.</param>
        /// <param name="Keys">Sets the keys associated with each bar.</param>
        /// <param name="MultiKeys">Sets the keys associated with each bar. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="MultiOpacity">Sets the Opacity of each individual bar.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="MarkerColor">Sets the color of the bars</param>
        /// <param name="MarkerColorScale">Sets the colorscale for the bars. To have an effect, `MarkerColor` must map to color scale values.</param>
        /// <param name="MarkerOutline">Sets the color of the bar outlines</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all bars</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each bar</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the bars (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units) of all bars.</param>
        /// <param name="MultiWidth">Sets the individual bar width (in position axis units) for each bar.</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Bar<ValuesType, KeysType, TextType>(
            IEnumerable<ValuesType> values,
            Optional<IEnumerable<KeysType>> Keys = default, 
            Optional<IEnumerable<IEnumerable<KeysType>>> MultiKeys = default,
            Optional<string> Name = default, 
            Optional<bool> ShowLegend = default, 
            Optional<double> Opacity = default, 
            Optional<IEnumerable<double>> MultiOpacity = default, 
            Optional<TextType> Text = default, 
            Optional<IEnumerable<TextType>> MultiText = default, 
            Optional<Color> MarkerColor = default, 
            Optional<StyleParam.Colorscale> MarkerColorScale = default, 
            Optional<Line> MarkerOutline = default, 
            Optional<StyleParam.PatternShape> MarkerPatternShape = default, 
            Optional<IEnumerable<StyleParam.PatternShape>> MultiMarkerPatternShape = default, 
            Optional<Pattern> MarkerPattern = default, 
            Optional<Marker> Marker = default,
            Optional<StyleParam.TextPosition> TextPosition = default, 
            Optional<IEnumerable<StyleParam.TextPosition>> MultiTextPosition = default,
            Optional<IEnumerable<ValuesType>> MultiWidth = default, 
            Optional<bool> UseDefaults = default,
            Optional<ValuesType> Base = default,
            Optional<ValuesType> Width = default
        )
            where ValuesType : IConvertible
            where KeysType : IConvertible
            where TextType: IConvertible
            =>
                Plotly.NET.Chart2D.Chart.Bar<ValuesType, KeysType, TextType, ValuesType, ValuesType>(
                    values: values,
                    Keys: Keys.ToOption(),
                    MultiKeys: MultiKeys.ToOption(),
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    MultiOpacity: MultiOpacity.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    MarkerColor: MarkerColor.ToOption(),
                    MarkerColorScale: MarkerColorScale.ToOption(),
                    MarkerOutline: MarkerOutline.ToOption(),
                    MarkerPatternShape: MarkerPatternShape.ToOption(),
                    MultiMarkerPatternShape: MultiMarkerPatternShape.ToOption(),
                    MarkerPattern: MarkerPattern.ToOption(),
                    Marker: Marker.ToOption(),
                    Base: Base.ToOption(),
                    Width: Width.ToOption(),
                    MultiWidth: MultiWidth.ToOption(),
                    TextPosition: TextPosition.ToOption(),
                    MultiTextPosition: MultiTextPosition.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Creates a stacked bar chart, with bars plotted horizontally. Values with the same key are stacked on top of each other in the X dimension.
        /// To create this type of chart, combine multiple of these charts via `Chart.combine`.
        ///
        /// A bar chart is a chart that presents categorical data with rectangular bars with heights or lengths proportional to the values that they represent.
        /// </summary>
        /// <param name="values">Sets the values that are plotted as the size of each bar.</param>
        /// <param name="Keys">Sets the keys associated with each bar.</param>
        /// <param name="MultiKeys">Sets the keys associated with each bar. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="MultiOpacity">Sets the Opacity of each individual bar.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="MarkerColor">Sets the color of the bars</param>
        /// <param name="MarkerColorScale">Sets the colorscale for the bars. To have an effect, `MarkerColor` must map to color scale values.</param>
        /// <param name="MarkerOutline">Sets the color of the bar outlines</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all bars</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each bar</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the bars (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units) of all bars.</param>
        /// <param name="MultiWidth">Sets the individual bar width (in position axis units) for each bar.</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart StackedBar<ValuesType, KeysType, TextType>(
            IEnumerable<ValuesType> values,
            Optional<IEnumerable<KeysType>> Keys = default,
            Optional<IEnumerable<IEnumerable<KeysType>>> MultiKeys = default,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<IEnumerable<double>> MultiOpacity = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<Color> MarkerColor = default,
            Optional<StyleParam.Colorscale> MarkerColorScale = default,
            Optional<Line> MarkerOutline = default,
            Optional<StyleParam.PatternShape> MarkerPatternShape = default,
            Optional<IEnumerable<StyleParam.PatternShape>> MultiMarkerPatternShape = default,
            Optional<Pattern> MarkerPattern = default,
            Optional<Marker> Marker = default,
            Optional<StyleParam.TextPosition> TextPosition = default,
            Optional<IEnumerable<StyleParam.TextPosition>> MultiTextPosition = default,
            Optional<IEnumerable<ValuesType>> MultiWidth = default,
            Optional<bool> UseDefaults = default,
            Optional<ValuesType> Base = default,
            Optional<ValuesType> Width = default
        )
            where ValuesType : IConvertible
            where KeysType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.Chart2D.Chart.StackedBar<ValuesType, KeysType, TextType, ValuesType, ValuesType>(
                    values: values,
                    Keys: Keys.ToOption(),
                    MultiKeys: MultiKeys.ToOption(),
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    MultiOpacity: MultiOpacity.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    MarkerColor: MarkerColor.ToOption(),
                    MarkerColorScale: MarkerColorScale.ToOption(),
                    MarkerOutline: MarkerOutline.ToOption(),
                    MarkerPatternShape: MarkerPatternShape.ToOption(),
                    MultiMarkerPatternShape: MultiMarkerPatternShape.ToOption(),
                    MarkerPattern: MarkerPattern.ToOption(),
                    Marker: Marker.ToOption(),
                    Base: Base.ToOption(),
                    Width: Width.ToOption(),
                    MultiWidth: MultiWidth.ToOption(),
                    TextPosition: TextPosition.ToOption(),
                    MultiTextPosition: MultiTextPosition.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Creates a column chart, with bars plotted vertically
        ///
        /// A column chart is a chart that presents categorical data with rectangular bars with heights or lengths proportional to the values that they represent.
        /// </summary>
        /// <param name="values">Sets the values that are plotted as the size of each bar.</param>
        /// <param name="Keys">Sets the keys associated with each bar.</param>
        /// <param name="MultiKeys">Sets the keys associated with each bar. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="MultiOpacity">Sets the Opacity of each individual bar.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="MarkerColor">Sets the color of the bars</param>
        /// <param name="MarkerColorScale">Sets the colorscale for the bars. To have an effect, `MarkerColor` must map to color scale values.</param>
        /// <param name="MarkerOutline">Sets the color of the bar outlines</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all bars</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each bar</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the bars (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units) of all bars.</param>
        /// <param name="MultiWidth">Sets the individual bar width (in position axis units) for each bar.</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Column<ValuesType, KeysType, TextType>(
            IEnumerable<ValuesType> values,
            Optional<IEnumerable<KeysType>> Keys = default,
            Optional<IEnumerable<IEnumerable<KeysType>>> MultiKeys = default,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<IEnumerable<double>> MultiOpacity = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<Color> MarkerColor = default,
            Optional<StyleParam.Colorscale> MarkerColorScale = default,
            Optional<Line> MarkerOutline = default,
            Optional<StyleParam.PatternShape> MarkerPatternShape = default,
            Optional<IEnumerable<StyleParam.PatternShape>> MultiMarkerPatternShape = default,
            Optional<Pattern> MarkerPattern = default,
            Optional<Marker> Marker = default,
            Optional<StyleParam.TextPosition> TextPosition = default,
            Optional<IEnumerable<StyleParam.TextPosition>> MultiTextPosition = default,
            Optional<IEnumerable<ValuesType>> MultiWidth = default,
            Optional<bool> UseDefaults = default,
            Optional<ValuesType> Base = default,
            Optional<ValuesType> Width = default
        )
            where ValuesType : IConvertible
            where KeysType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.Chart2D.Chart.Column<ValuesType, KeysType, TextType, ValuesType, ValuesType>(
                    values: values,
                    Keys: Keys.ToOption(),
                    MultiKeys: MultiKeys.ToOption(),
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    MultiOpacity: MultiOpacity.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    MarkerColor: MarkerColor.ToOption(),
                    MarkerColorScale: MarkerColorScale.ToOption(),
                    MarkerOutline: MarkerOutline.ToOption(),
                    MarkerPatternShape: MarkerPatternShape.ToOption(),
                    MultiMarkerPatternShape: MultiMarkerPatternShape.ToOption(),
                    MarkerPattern: MarkerPattern.ToOption(),
                    Marker: Marker.ToOption(),
                    Base: Base.ToOption(),
                    Width: Width.ToOption(),
                    MultiWidth: MultiWidth.ToOption(),
                    TextPosition: TextPosition.ToOption(),
                    MultiTextPosition: MultiTextPosition.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Creates a stacked column chart, with bars plotted vertically. Values with the same key are stacked on top of each other in the Y dimension.
        /// To create this type of chart, combine multiple of these charts via `Chart.combine`.
        ///
        /// A bar chart is a chart that presents categorical data with rectangular bars with heights or lengths proportional to the values that they represent.
        /// </summary>
        /// <param name="values">Sets the values that are plotted as the size of each bar.</param>
        /// <param name="Keys">Sets the keys associated with each bar.</param>
        /// <param name="MultiKeys">Sets the keys associated with each bar. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="MultiOpacity">Sets the Opacity of each individual bar.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="MarkerColor">Sets the color of the bars</param>
        /// <param name="MarkerColorScale">Sets the colorscale for the bars. To have an effect, `MarkerColor` must map to color scale values.</param>
        /// <param name="MarkerOutline">Sets the color of the bar outlines</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all bars</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each bar</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the bars (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="Base">Sets where the bar base is drawn (in position axis units).</param>
        /// <param name="Width">Sets the bar width (in position axis units) of all bars.</param>
        /// <param name="MultiWidth">Sets the individual bar width (in position axis units) for each bar.</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="MultiTextPosition">Sets the position of text associated with individual datum</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart StackedColumn<ValuesType, KeysType, TextType>(
            IEnumerable<ValuesType> values,
            Optional<IEnumerable<KeysType>> Keys = default, 
            Optional<IEnumerable<IEnumerable<KeysType>>> MultiKeys = default,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<IEnumerable<double>> MultiOpacity = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<Color> MarkerColor = default,
            Optional<StyleParam.Colorscale> MarkerColorScale = default,
            Optional<Line> MarkerOutline = default,
            Optional<StyleParam.PatternShape> MarkerPatternShape = default,
            Optional<IEnumerable<StyleParam.PatternShape>> MultiMarkerPatternShape = default,
            Optional<Pattern> MarkerPattern = default,
            Optional<Marker> Marker = default,
            Optional<StyleParam.TextPosition> TextPosition = default,
            Optional<IEnumerable<StyleParam.TextPosition>> MultiTextPosition = default,
            Optional<IEnumerable<ValuesType>> MultiWidth = default,
            Optional<bool> UseDefaults = default,
            Optional<ValuesType> Base = default,
            Optional<ValuesType> Width = default
        )
            where ValuesType : IConvertible
            where KeysType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.Chart2D.Chart.StackedColumn<ValuesType, KeysType, TextType, ValuesType, ValuesType>(
                    values: values,
                    Keys: Keys.ToOption(),
                    MultiKeys: MultiKeys.ToOption(),
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    MultiOpacity: MultiOpacity.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    MarkerColor: MarkerColor.ToOption(),
                    MarkerColorScale: MarkerColorScale.ToOption(),
                    MarkerOutline: MarkerOutline.ToOption(),
                    MarkerPatternShape: MarkerPatternShape.ToOption(),
                    MultiMarkerPatternShape: MultiMarkerPatternShape.ToOption(),
                    MarkerPattern: MarkerPattern.ToOption(),
                    Marker: Marker.ToOption(),
                    Base: Base.ToOption(),
                    Width: Width.ToOption(),
                    MultiWidth: MultiWidth.ToOption(),
                    TextPosition: TextPosition.ToOption(),
                    MultiTextPosition: MultiTextPosition.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Visualizes the distribution of the input data as a histogram.
        ///
        /// A histogram is an approximate representation of the distribution of numerical data. To construct a histogram, the first step is to "bin"  the range of values - that is, divide the entire range of values into a series of intervals - and then count how many values fall into each interval.
        /// The bins are usually specified as consecutive, non-overlapping intervals of a variable.
        ///
        /// The sample data from which statistics are computed is set in `x` for vertically spanning histograms and in `y` for horizontally spanning histograms. Binning options are set `xbins` and `ybins` respectively if no aggregation data is provided.
        /// </summary>
        /// <param name="X">Sets the sample data to be binned on the x axis.</param>
        /// <param name="MultiX">Sets the sample data to be binned on the x axis. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Y">Sets the sample data to be binned on the y axis.</param>
        /// <param name="MultiY">Sets the sample data to be binned on the y axis. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Orientation">Sets the orientation of the bars. With "v" ("h"), the value of the each bar spans along the vertical (horizontal).</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="TextPosition">Sets the position of text associated with each datum</param>
        /// <param name="HistFunc">Specifies the binning function used for this histogram trace. If "count", the histogram values are computed by counting the number of values lying inside each bin. If "sum", "avg", "min", "max", the histogram values are computed using the sum, the average, the minimum or the maximum of the values lying inside each bin respectively.</param>
        /// <param name="HistNorm">Specifies the type of normalization used for this histogram trace. If "", the span of each bar corresponds to the number of occurrences (i.e. the number of data points lying inside the bins). If "percent" / "probability", the span of each bar corresponds to the percentage / fraction of occurrences with respect to the total number of sample points (here, the sum of all bin HEIGHTS equals 100% / 1). If "density", the span of each bar corresponds to the number of occurrences in a bin divided by the size of the bin interval (here, the sum of all bin AREAS equals the total number of sample points). If "probability density", the area of each bar corresponds to the probability that an event will fall into the corresponding bin (here, the sum of all bin AREAS equals 1).</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="NBinsX">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `xbins.size` is provided.</param>
        /// <param name="NBinsY">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `ybins.size` is provided.</param>
        /// <param name="BinGroup">Set a group of histogram traces which will have compatible bin settings. Note that traces on the same subplot and with the same "orientation" under `barmode` "stack", "relative" and "group" are forced into the same bingroup, Using `bingroup`, traces under `barmode` "overlay" and on different axes (of the same axis type) can have compatible bin settings. Note that histogram and histogram2d" trace can share the same `bingroup`</param>
        /// <param name="XBins">Sets the binning across the x dimension</param>
        /// <param name="YBins">Sets the binning across the y dimension</param>
        /// <param name="MarkerColor">Sets the color of the bars</param>
        /// <param name="MarkerColorScale">Sets the colorscale for the bars. To have an effect, `MarkerColor` must map to color scale values.</param>
        /// <param name="MarkerOutline">Sets the color of the bar outlines</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all bars</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each bar</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker of this trace.</param>
        /// <param name="Line">Sets the outline of the histogram's bars.</param>
        /// <param name="XError">Sets the x error of this trace.</param>
        /// <param name="YError">Sets the y error of this trace.</param>
        /// <param name="Cumulative">Sets whether and how the cumulative distribution is displayed</param>
        /// <param name="HoverLabel">Sets the style of the hoverlabels of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Histogram<XType, YType, TextType>(
            Optional<IEnumerable<XType>> X = default,
            Optional<IEnumerable<IEnumerable<XType>>> MultiX = default,
            Optional<IEnumerable<YType>> Y = default,
            Optional<IEnumerable<IEnumerable<YType>>> MultiY = default,
            Optional<StyleParam.Orientation> Orientation = default,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<StyleParam.TextPosition> TextPosition = default,
            Optional<StyleParam.HistFunc> HistFunc = default,
            Optional<StyleParam.HistNorm> HistNorm = default,
            Optional<string> AlignmentGroup = default,
            Optional<string> OffsetGroup = default,
            Optional<int> NBinsX = default,
            Optional<int> NBinsY = default,
            Optional<string> BinGroup = default,
            Optional<Bins> XBins = default,
            Optional<Bins> YBins = default,
            Optional<Color> MarkerColor = default,
            Optional<StyleParam.Colorscale> MarkerColorScale = default,
            Optional<Line> MarkerOutline = default,
            Optional<StyleParam.PatternShape> MarkerPatternShape = default,
            Optional<IEnumerable<PatternShape>> MultiMarkerPatternShape = default,
            Optional<Pattern> MarkerPattern = default,
            Optional<Marker> Marker = default,
            Optional<Line> Line = default,
            Optional<Error> XError = default,
            Optional<Error> YError = default,
            Optional<Cumulative> Cumulative = default,
            Optional<Hoverlabel> HoverLabel = default,
            Optional<bool> UseDefaults = default
        )
            where XType : IConvertible
            where YType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.Chart2D.Chart.Histogram<XType, YType, TextType>(
                    X: X.ToOption(),
                    MultiX: MultiX.ToOption(),
                    Y: Y.ToOption(),
                    MultiY: MultiY.ToOption(),
                    Orientation: Orientation.ToOption(),
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    TextPosition: TextPosition.ToOption(),
                    HistFunc: HistFunc.ToOption(),
                    HistNorm: HistNorm.ToOption(),
                    AlignmentGroup: AlignmentGroup.ToOption(),
                    OffsetGroup: OffsetGroup.ToOption(),
                    NBinsX: NBinsX.ToOption(),
                    NBinsY: NBinsY.ToOption(),
                    BinGroup: BinGroup.ToOption(),
                    XBins: XBins.ToOption(),
                    YBins: YBins.ToOption(),
                    MarkerColor: MarkerColor.ToOption(),
                    MarkerColorScale: MarkerColorScale.ToOption(),
                    MarkerOutline: MarkerOutline.ToOption(),
                    MarkerPatternShape: MarkerPatternShape.ToOption(),
                    MultiMarkerPatternShape: MultiMarkerPatternShape.ToOption(),
                    MarkerPattern: MarkerPattern.ToOption(),
                    Marker: Marker.ToOption(),
                    Line: Line.ToOption(),
                    XError: XError.ToOption(),
                    YError: YError.ToOption(),
                    Cumulative: Cumulative.ToOption(),
                    HoverLabel: HoverLabel.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Visualizes the distribution of the 2-dimensional input data as 2D Histogram.
        ///
        ///The sample data from which statistics are computed is set in `x` and `y` (where `x` and `y` represent marginal distributions, binning is set in `xbins` and `ybins` in this case) or `z` (where `z` represent the 2D distribution and binning set, binning is set by `x` and `y` in this case). The resulting distribution is visualized as a heatmap.
        /// </summary>
        /// <param name="x">Sets the sample data to be binned on the x axis.</param>
        /// <param name="y">Sets the sample data to be binned on the y axis.</param>
        /// <param name="Z">Sets the aggregation data.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity of the trace.</param>
        /// <param name="XGap">Sets the horizontal gap (in pixels) between bricks.</param>
        /// <param name="YGap">Sets the vertical gap (in pixels) between bricks.</param>
        /// <param name="HistFunc">Specifies the binning function used for this histogram trace. If "count", the histogram values are computed by counting the number of values lying inside each bin. If "sum", "avg", "min", "max", the histogram values are computed using the sum, the average, the minimum or the maximum of the values lying inside each bin respectively.</param>
        /// <param name="HistNorm">Specifies the type of normalization used for this histogram trace. If "", the span of each bar corresponds to the number of occurrences (i.e. the number of data points lying inside the bins). If "percent" / "probability", the span of each bar corresponds to the percentage / fraction of occurrences with respect to the total number of sample points (here, the sum of all bin HEIGHTS equals 100% / 1). If "density", the span of each bar corresponds to the number of occurrences in a bin divided by the size of the bin interval (here, the sum of all bin AREAS equals the total number of sample points). If "probability density", the area of each bar corresponds to the probability that an event will fall into the corresponding bin (here, the sum of all bin AREAS equals 1).</param>
        /// <param name="NBinsX">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `xbins.size` is provided.</param>
        /// <param name="NBinsY">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `ybins.size` is provided.</param>
        /// <param name="XBins">Sets the binning across the x dimension</param>
        /// <param name="YBins">Sets the binning across the y dimension</param>
        /// <param name="ColorBar">Sets the styles of the colorbar for this trace.</param>
        /// <param name="ColorScale">Sets the colorscale for this trace.</param>
        /// <param name="ShowScale">Whether or not to show the colorscale/colorbar</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
        /// <param name="ZSmooth">Picks a smoothing algorithm use to smooth `z` data.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Histogram2D<XType, YType, ZType>(
            IEnumerable<XType> x,
            IEnumerable<YType> y,
            Optional<IEnumerable<IEnumerable<ZType>>> Z = default,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<int> XGap = default,
            Optional<int> YGap = default,
            Optional<StyleParam.HistFunc> HistFunc = default,
            Optional<StyleParam.HistNorm> HistNorm = default,
            Optional<int> NBinsX = default,
            Optional<int> NBinsY = default,
            Optional<Bins> XBins = default,
            Optional<Bins> YBins = default,
            Optional<ColorBar> ColorBar = default,
            Optional<StyleParam.Colorscale> ColorScale = default,
            Optional<bool> ShowScale = default,
            Optional<bool> ReverseScale = default,
            Optional<StyleParam.SmoothAlg> ZSmooth = default,
            Optional<bool> UseDefaults = default
        )
            where XType : IConvertible
            where YType : IConvertible
            where ZType : IConvertible
            =>
                Plotly.NET.Chart2D.Chart.Histogram2D<XType, YType, IEnumerable<ZType>, ZType>(
                    x: x,
                    y: y,
                    Z: Z.ToOption(),
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    XGap: XGap.ToOption(),
                    YGap: YGap.ToOption(),
                    HistFunc: HistFunc.ToOption(),
                    HistNorm: HistNorm.ToOption(),
                    NBinsX: NBinsX.ToOption(),
                    NBinsY: NBinsY.ToOption(),
                    XBins: XBins.ToOption(),
                    YBins: YBins.ToOption(),
                    ColorBar: ColorBar.ToOption(),
                    ColorScale: ColorScale.ToOption(),
                    ShowScale: ShowScale.ToOption(),
                    ReverseScale: ReverseScale.ToOption(),
                    ZSmooth: ZSmooth.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Visualizes the distribution of the input data as a box plot.
        ///
        /// A box plot is a method for graphically demonstrating the locality, spread and skewness groups of numerical data through their quartiles.
        /// The default style is based on the five number summary: minimum, first quartile, median, third quartile, and maximum.
        ///
        /// The sample data from which statistics are computed is set in `x` for vertically spanning boxes and in `y` for horizontally spanning boxes.
        /// </summary>
        /// <param name="X">Sets the x sample data or coordinates</param>
        /// <param name="MultiX">Sets the x sample data or coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Y">Sets the y sample data or coordinates</param>
        /// <param name="MultiY">Sets the y sample data or coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="MarkerColor">Sets the marker color.</param>
        /// <param name="Marker">Sets the marker for the box (use this for more finegrained control than the other marker-associated arguments).</param>// <param name="Opacity">Sets the opacity of this trace.</param>
        /// <param name="WhiskerWidth">Sets the width of the whiskers relative to the box' width. For example, with 1, the whiskers are as wide as the box(es).</param>
        /// <param name="BoxPoints">If "outliers", only the sample points lying outside the whiskers are shown If "suspectedoutliers", the outlier points are shown and points either less than 4"Q1-3"Q3 or greater than 4"Q3-3"Q1 are highlighted (see `outliercolor`) If "all", all sample points are shown If "false", only the box(es) are shown with no sample points Defaults to "suspectedoutliers" when `marker.outliercolor` or `marker.line.outliercolor` is set. Defaults to "all" under the q1/median/q3 signature. Otherwise defaults to "outliers".</param>
        /// <param name="BoxMean">If "true", the mean of the box(es)' underlying distribution is drawn as a dashed line inside the box(es). If "sd" the standard deviation is also drawn. Defaults to "true" when `mean` is set. Defaults to "sd" when `sd` is set Otherwise defaults to "false".</param>
        /// <param name="Jitter">Sets the amount of jitter in the sample points drawn. If "0", the sample points align along the distribution axis. If "1", the sample points are drawn in a random jitter of width equal to the width of the box(es).</param>
        /// <param name="PointPos">Sets the position of the sample points in relation to the box(es). If "0", the sample points are places over the center of the box(es). Positive (negative) values correspond to positions to the right (left) for vertical boxes and above (below) for horizontal boxes</param>
        /// <param name="Orientation">Sets the orientation of the box(es). If "v" ("h"), the distribution is visualized along the vertical (horizontal).</param>
        /// <param name="OutlineColor">Sets the color of the box outline</param>
        /// <param name="OutlineWidth">Sets the width of the box outline</param>
        /// <param name="Outline">Sets the box outline (use this for more finegrained control than the other outline-associated arguments).</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="Notched">Determines whether or not notches are drawn. Notches displays a confidence interval around the median. We compute the confidence interval as median +/- 1.57 " IQR / sqrt(N), where IQR is the interquartile range and N is the sample size. If two boxes' notches do not overlap there is 95% confidence their medians differ. See https://sites.google.com/site/davidsstatistics/home/notched-box-plots for more info. Defaults to "false" unless `notchwidth` or `notchspan` is set.</param>
        /// <param name="NotchWidth">Sets the width of the notches relative to the box' width. For example, with 0, the notches are as wide as the box(es).</param>
        /// <param name="QuartileMethod">Sets the method used to compute the sample's Q1 and Q3 quartiles. The "linear" method uses the 25th percentile for Q1 and 75th percentile for Q3 as computed using method #10 (listed on http://www.amstat.org/publications/jse/v14n3/langford.html). The "exclusive" method uses the median to divide the ordered dataset into two halves if the sample is odd, it does not include the median in either half - Q1 is then the median of the lower half and Q3 the median of the upper half. The "inclusive" method also uses the median to divide the ordered dataset into two halves but if the sample is odd, it includes the median in both halves - Q1 is then the median of the lower half and Q3 the median of the upper half.</param>
        /// <param name="SizeMode">Sets the upper and lower bound for the boxes quartiles means box is drawn between Q1 and Q3 SD means the box is drawn between Mean +- Standard Deviation Argument sdmultiple (default 1) to scale the box size So it could be drawn 1-stddev, 3-stddev etc</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart BoxPlot<XType, YType, TextType>(
            Optional<IEnumerable<XType>> X = default,
            Optional<IEnumerable<IEnumerable<XType>>> MultiX = default,
            Optional<IEnumerable<YType>> Y = default,
            Optional<IEnumerable<IEnumerable<YType>>> MultiY = default,
            Optional<string> Name = default, 
            Optional<bool> ShowLegend = default, 
            Optional<TextType> Text = default, 
            Optional<IEnumerable<TextType>> MultiText = default, 
            Optional<Color> FillColor = default, 
            Optional<Color> MarkerColor = default, 
            Optional<Marker> Marker = default, 
            Optional<double> Opacity = default, 
            Optional<double> WhiskerWidth = default, 
            Optional<StyleParam.BoxPoints> BoxPoints = default, 
            Optional<StyleParam.BoxMean> BoxMean = default, 
            Optional<double> Jitter = default, 
            Optional<double> PointPos = default, 
            Optional<StyleParam.Orientation> Orientation = default, 
            Optional<Color> OutlineColor = default, 
            Optional<double> OutlineWidth = default, 
            Optional<Line> Outline = default, 
            Optional<string> AlignmentGroup = default, 
            Optional<string> OffsetGroup = default, 
            Optional<bool> Notched = default, 
            Optional<double> NotchWidth = default, 
            Optional<StyleParam.QuartileMethod> QuartileMethod = default,
            Optional<StyleParam.BoxSizeMode> SizeMode = default,
            Optional<bool> UseDefaults = default
        )
            where XType : IConvertible
            where YType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.Chart2D.Chart.BoxPlot<XType, YType, TextType>(
                    X: X.ToOption(),
                    MultiX: MultiX.ToOption(),
                    Y: Y.ToOption(),
                    MultiY: MultiY.ToOption(),
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    FillColor: FillColor.ToOption(),
                    MarkerColor: MarkerColor.ToOption(),
                    Marker: Marker.ToOption(),
                    Opacity: Opacity.ToOption(),
                    WhiskerWidth: WhiskerWidth.ToOption(),
                    BoxPoints: BoxPoints.ToOption(),
                    BoxMean: BoxMean.ToOption(),
                    Jitter: Jitter.ToOption(),
                    PointPos: PointPos.ToOption(),
                    Orientation: Orientation.ToOption(),
                    OutlineColor: OutlineColor.ToOption(),
                    OutlineWidth: OutlineWidth.ToOption(),
                    Outline: Outline.ToOption(),
                    AlignmentGroup: AlignmentGroup.ToOption(),
                    OffsetGroup: OffsetGroup.ToOption(),
                    Notched: Notched.ToOption(),
                    NotchWidth: NotchWidth.ToOption(),
                    QuartileMethod: QuartileMethod.ToOption(),
                    SizeMode: SizeMode.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Visualizes the distribution of the input data as a violin plot.
        ///
        /// A violin plot is a method of plotting numeric data. It is similar to a box plot, except that they also show the probability density of the data at different values, usually smoothed by a kernel density estimator.
        ///
        /// In vertical (horizontal) violin plots, statistics are computed using `y` (`x`) values. By supplying an `x` (`y`) array, one violin per distinct x (y) value is drawn If no `x` (`y`) array is provided, a single violin is drawn. That violin position is then positioned with with `name` or with `x0` (`y0`) if provided.
        /// </summary>
        /// <param name="X">Sets the x sample data or coordinates</param>
        /// <param name="MultiX">Sets the x sample data or coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Y">Sets the y sample data or coordinates</param>
        /// <param name="MultiY">Sets the y sample data or coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="FillColor">Sets the fill color. Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Points">If "outliers", only the sample points lying outside the whiskers are shown If "suspectedoutliers", the outlier points are shown and points either less than 4"Q1-3"Q3 or greater than 4"Q3-3"Q1 are highlighted (see `outliercolor`) If "all", all sample points are shown If "false", only the violins are shown with no sample points. Defaults to "suspectedoutliers" when `marker.outliercolor` or `marker.line.outliercolor` is set, otherwise defaults to "outliers".</param>
        /// <param name="Jitter">Sets the amount of jitter in the sample points drawn. If "0", the sample points align along the distribution axis. If "1", the sample points are drawn in a random jitter of width equal to the width of the box(es).</param>
        /// <param name="PointPos">Sets the position of the sample points in relation to the box(es). If "0", the sample points are places over the center of the box(es). Positive (negative) values correspond to positions to the right (left) for vertical boxes and above (below) for horizontal boxes</param>
        /// <param name="Orientation">Sets the orientation of the violin(s). If "v" ("h"), the distribution is visualized along the vertical (horizontal).</param>
        /// <param name="Width">Sets the width of the violin in data coordinates. If "0" (default value) the width is automatically selected based on the positions of other violin traces in the same subplot.</param>
        /// <param name="MarkerColor">Sets the marker color.</param>
        /// <param name="Marker">Sets the marker for the violin (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="OutlineColor">Sets the color of the box outline</param>
        /// <param name="OutlineWidth">Sets the width of the box outline</param>
        /// <param name="Outline">Sets the box outline (use this for more finegrained control than the other outline-associated arguments).</param>
        /// <param name="AlignmentGroup">Set several traces linked to the same position axis or matching axes to the same alignmentgroup. This controls whether bars compute their positional range dependently or independently.</param>
        /// <param name="OffsetGroup">Set several traces linked to the same position axis or matching axes to the same offsetgroup where bars of the same position coordinate will line up.</param>
        /// <param name="ShowBox">Whether and how to draw a miniature box plot</param>
        /// <param name="BoxWidth">Sets the width of the miniature box plot</param>
        /// <param name="BoxFillColor">Sets the fill color of the miniature box plot</param>
        /// <param name="Box">Sets the styles of the miniature box plot (use this for more finegrained control than the other box-associated arguments)</param>
        /// <param name="BandWidth">Sets the bandwidth used to compute the kernel density estimate. By default, the bandwidth is determined by Silverman's rule of thumb.</param>
        /// <param name="MeanLine">Whether and how to draw the meanline</param>
        /// <param name="ScaleGroup">If there are multiple violins that should be sized according to to some metric (see `scalemode`), link them by providing a non-empty group id here shared by every trace in the same group. If a violin's `width` is undefined, `scalegroup` will default to the trace's name. In this case, violins with the same names will be linked together</param>
        /// <param name="ScaleMode">Sets the metric by which the width of each violin is determined."width" means each violin has the same (max) width"count" means the violins are scaled by the number of sample points makingup each violin.</param>
        /// <param name="Side">Determines on which side of the position value the density function making up one half of a violin is plotted. Useful when comparing two violin traces under "overlay" mode, where one trace has `side` set to "positive" and the other to "negative".</param>
        /// <param name="Span">Sets the span in data space for which the density function will be computed. Has an effect only when `spanmode` is set to "manual".</param>
        /// <param name="SpanMode">Sets the method by which the span in data space where the density function will be computed. "soft" means the span goes from the sample's minimum value minus two bandwidths to the sample's maximum value plus two bandwidths. "hard" means the span goes from the sample's minimum to its maximum value. For custom span settings, use mode "manual" and fill in the `span` attribute.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Violin<XType, YType, TextType>(
            Optional<IEnumerable<XType>> X = default,
            Optional<IEnumerable<IEnumerable<XType>>> MultiX = default,
            Optional<IEnumerable<YType>> Y = default,
            Optional<IEnumerable<IEnumerable<YType>>> MultiY = default,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<Color> FillColor = default,
            Optional<double> Opacity = default,
            Optional<StyleParam.BoxPoints> Points = default,
            Optional<double> Jitter = default,
            Optional<double> PointPos = default,
            Optional<StyleParam.Orientation> Orientation = default,
            Optional<double> Width = default,
            Optional<Color> MarkerColor = default,
            Optional<Marker> Marker = default,
            Optional<Color> OutlineColor = default,
            Optional<double> OutlineWidth = default,
            Optional<Line> Outline = default,
            Optional<string> AlignmentGroup = default,
            Optional<string> OffsetGroup = default,
            Optional<bool> ShowBox = default,
            Optional<double> BoxWidth = default,
            Optional<Color> BoxFillColor = default,
            Optional<Box> Box = default,
            Optional<double> BandWidth = default,
            Optional<MeanLine> MeanLine = default,
            Optional<string> ScaleGroup = default,
            Optional<StyleParam.ScaleMode> ScaleMode = default,
            Optional<StyleParam.ViolinSide> Side = default,
            Optional<StyleParam.Range> Span = default,
            Optional<StyleParam.SpanMode> SpanMode = default,
            Optional<bool> UseDefaults = default
        )
            where XType : IConvertible
            where YType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.Chart2D.Chart.Violin<XType, YType, TextType>(
                    X: X.ToOption(),
                    MultiX: MultiX.ToOption(),
                    Y: Y.ToOption(),
                    MultiY: MultiY.ToOption(),
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    FillColor: FillColor.ToOption(),
                    Opacity: Opacity.ToOption(),
                    Points: Points.ToOption(),
                    Jitter: Jitter.ToOption(),
                    PointPos: PointPos.ToOption(),
                    Orientation: Orientation.ToOption(),
                    Width: Width.ToOption(),
                    MarkerColor: MarkerColor.ToOption(),
                    Marker: Marker.ToOption(),
                    OutlineColor: OutlineColor.ToOption(),
                    OutlineWidth: OutlineWidth.ToOption(),
                    Outline: Outline.ToOption(),
                    AlignmentGroup: AlignmentGroup.ToOption(),
                    OffsetGroup: OffsetGroup.ToOption(),
                    ShowBox: ShowBox.ToOption(),
                    BoxWidth: BoxWidth.ToOption(),
                    BoxFillColor: BoxFillColor.ToOption(),
                    Box: Box.ToOption(),
                    BandWidth: BandWidth.ToOption(),
                    MeanLine: MeanLine.ToOption(),
                    ScaleGroup: ScaleGroup.ToOption(),
                    ScaleMode: ScaleMode.ToOption(),
                    Side: Side.ToOption(),
                    Span: Span.ToOption(),
                    SpanMode: SpanMode.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Computes a 2D histogram contour plot, also known as a density contour plot, which is a 2-dimensional generalization of a histogram which resembles a contour plot but is computed by grouping a set of points specified by their x and y coordinates into bins, and applying an aggregation function such as count or sum (if z is provided) to compute the value to be used to compute contours.
        ///
        /// The sample data from which statistics are computed is set in `x` and `y` (where `x` and `y` represent marginal distributions, binning is set in `xbins` and `ybins` in this case) or `z` (where `z` represent the 2D distribution and binning set, binning is set by `x` and `y` in this case). The resulting distribution is visualized as a contour plot.
        /// </summary>
        /// <param name="X">Sets the sample data to be binned on the x axis.</param>
        /// <param name="MultiX">Sets the sample data to be binned on the x axis. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Y">Sets the sample data to be binned on the y axis.</param>
        /// <param name="MultiY">Sets the sample data to be binned on the y axis. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Z">Sets the aggregation data.</param>
        /// <param name="HistFunc">Specifies the binning function used for this histogram trace. If "count", the histogram values are computed by counting the number of values lying inside each bin. If "sum", "avg", "min", "max", the histogram values are computed using the sum, the average, the minimum or the maximum of the values lying inside each bin respectively.</param>
        /// <param name="HistNorm">Specifies the type of normalization used for this histogram trace. If "", the span of each bar corresponds to the number of occurrences (i.e. the number of data points lying inside the bins). If "percent" / "probability", the span of each bar corresponds to the percentage / fraction of occurrences with respect to the total number of sample points (here, the sum of all bin HEIGHTS equals 100% / 1). If "density", the span of each bar corresponds to the number of occurrences in a bin divided by the size of the bin interval (here, the sum of all bin AREAS equals the total number of sample points). If "probability density", the area of each bar corresponds to the probability that an event will fall into the corresponding bin (here, the sum of all bin AREAS equals 1).</param>
        /// <param name="NBinsX">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `xbins.size` is provided.</param>
        /// <param name="NBinsY">Specifies the maximum number of desired bins. This value will be used in an algorithm that will decide the optimal bin size such that the histogram best visualizes the distribution of the data. Ignored if `ybins.size` is provided.</param>
        /// <param name="BinGroup">Set the `xbingroup` and `ybingroup` default prefix For example, setting a `bingroup` of "1" on two histogram2d traces will make them their x-bins and y-bins match separately.</param>
        /// <param name="XBinGroup">Set a group of histogram traces which will have compatible x-bin settings. Using `xbingroup`, histogram2d and histogram2dcontour traces (on axes of the same axis type) can have compatible x-bin settings. Note that the same `xbingroup` value can be used to set (1D) histogram `bingroup`</param>
        /// <param name="XBins">Sets the binning across the x dimension</param>
        /// <param name="YBinGroup">Set a group of histogram traces which will have compatible y-bin settings. Using `ybingroup`, histogram2d and histogram2dcontour traces (on axes of the same axis type) can have compatible y-bin settings. Note that the same `ybingroup` value can be used to set (1D) histogram `bingroup`</param>
        /// <param name="YBins">Sets the binning across the y dimension</param>
        /// <param name="Marker">Sets the marker of this trace.</param>
        /// <param name="ContourLinesDash">Sets the contour line dash style</param>
        /// <param name="ContourLinesColor">Sets the contour line color</param>
        /// <param name="ContourLinesSmoothing">Sets the amount of smoothing for the contour lines, where "0" corresponds to no smoothing.</param>
        /// <param name="ContourLinesWidth">Sets the width of the contour lines</param>
        /// <param name="ContourLines">Sets the contour lines (use this for more finegrained control than the other contourline-associated arguments).</param>
        /// <param name="ShowContourLines">Wether or not to show the contour line</param>
        /// <param name="ContoursColoring">Determines the coloring method showing the contour values. If "fill", coloring is done evenly between each contour level If "heatmap", a heatmap gradient coloring is applied between each contour level. If "lines", coloring is done on the contour lines. If "none", no coloring is applied on this trace.</param>
        /// <param name="ContoursOperation">Sets the constraint operation. "=" keeps regions equal to `value` "&lt;" and "&lt;=" keep regions less than `value` "&gt;" and "&gt;=" keep regions greater than `value` "[]", "()", "[)", and "(]" keep regions inside `value[0]` to `value[1]` "][", ")(", "](", ")[" keep regions outside `value[0]` to value[1]` Open vs. closed intervals make no difference to constraint display, but all versions are allowed for consistency with filter transforms.</param>
        /// <param name="ContoursType">If `levels`, the data is represented as a contour plot with multiple levels displayed. If `constraint`, the data is represented as constraints with the invalid region shaded as specified by the `operation` and `value` parameters.</param>
        /// <param name="ShowContoursLabels">Determines whether to label the contour lines with their values.</param>
        /// <param name="ContourLabelFont">Sets the font used for labeling the contour levels. The default color comes from the lines, if shown. The default family and size come from `layout.font`.</param>
        /// <param name="ContoursStart">Sets the starting contour level value. Must be less than `contours.end`</param>
        /// <param name="ContoursEnd">Sets the end contour level value. Must be more than `contours.start`</param>
        /// <param name="Contours">Sets the styles of the contours (use this for more finegrained control than the other contour-associated arguments).</param>
        /// <param name="ColorBar">Sets the styles of the colorbar for this trace.</param>
        /// <param name="ColorScale">Sets the colorscale for this trace.</param>
        /// <param name="ShowScale">Whether or not to show the colorscale/colorbar</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
        /// <param name="NContours">Sets the maximum number of contour levels. The actual number of contours will be chosen automatically to be less than or equal to the value of `ncontours`. Has an effect only if `autocontour` is "true" or if `contours.size` is missing.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Histogram2DContour<XType, YType, ZType>(
            Optional<IEnumerable<XType>> X,
            Optional<IEnumerable<IEnumerable<XType>>> MultiX,
            Optional<IEnumerable<YType>> Y,
            Optional<IEnumerable<IEnumerable<YType>>> MultiY,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<IEnumerable<IEnumerable<ZType>>> Z = default,
            Optional<StyleParam.HistFunc> HistFunc = default,
            Optional<StyleParam.HistNorm> HistNorm = default,
            Optional<int> NBinsX = default,
            Optional<int> NBinsY = default,
            Optional<string> BinGroup = default,
            Optional<string> XBinGroup = default,
            Optional<Bins> XBins = default,
            Optional<string> YBinGroup = default,
            Optional<Bins> YBins = default,
            Optional<Marker> Marker = default,
            Optional<StyleParam.DrawingStyle> ContourLinesDash = default,
            Optional<Color> ContourLinesColor = default,
            Optional<double> ContourLinesSmoothing = default,
            Optional<double> ContourLinesWidth = default,
            Optional<Line> ContourLines = default,
            Optional<bool> ShowContourLines = default,
            Optional<StyleParam.ContourColoring> ContoursColoring = default,
            Optional<StyleParam.ConstraintOperation> ContoursOperation = default,
            Optional<StyleParam.ContourType> ContoursType = default,
            Optional<bool> ShowContoursLabels = default,
            Optional<Font> ContourLabelFont = default,
            Optional<double> ContoursStart = default,
            Optional<double> ContoursEnd = default,
            Optional<Contours> Contours = default,
            Optional<ColorBar> ColorBar = default,
            Optional<StyleParam.Colorscale> ColorScale = default,
            Optional<bool> ShowScale = default,
            Optional<bool> ReverseScale = default,
            Optional<int> NContours = default,
            Optional<bool> UseDefaults = default
        )
            where XType : IConvertible
            where YType : IConvertible
            where ZType : IConvertible
            =>
                Plotly.NET.Chart2D.Chart.Histogram2DContour<XType, YType, IEnumerable<ZType>, ZType>(
                    X: X.ToOption(),
                    MultiX: MultiX.ToOption(),
                    Y: Y.ToOption(),
                    MultiY: MultiY.ToOption(),
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    Z: Z.ToOption(),
                    HistFunc: HistFunc.ToOption(),
                    HistNorm: HistNorm.ToOption(),
                    NBinsX: NBinsX.ToOption(),
                    NBinsY: NBinsY.ToOption(),
                    BinGroup: BinGroup.ToOption(),
                    XBinGroup: XBinGroup.ToOption(),
                    XBins: XBins.ToOption(),
                    YBinGroup: YBinGroup.ToOption(),
                    YBins: YBins.ToOption(),
                    Marker: Marker.ToOption(),
                    ContourLinesDash: ContourLinesDash.ToOption(),
                    ContourLinesColor: ContourLinesColor.ToOption(),
                    ContourLinesSmoothing: ContourLinesSmoothing.ToOption(),
                    ContourLinesWidth: ContourLinesWidth.ToOption(),
                    ContourLines: ContourLines.ToOption(),
                    ShowContourLines: ShowContourLines.ToOption(),
                    ContoursColoring: ContoursColoring.ToOption(),
                    ContoursOperation: ContoursOperation.ToOption(),
                    ContoursType: ContoursType.ToOption(),
                    ShowContoursLabels: ShowContoursLabels.ToOption(),
                    ContoursLabelFont: ContourLabelFont.ToOption(),
                    ContoursStart: ContoursStart.ToOption(),
                    ContoursEnd: ContoursEnd.ToOption(),
                    Contours: Contours.ToOption(),
                    ColorBar: ColorBar.ToOption(),
                    ColorScale: ColorScale.ToOption(),
                    ShowScale: ShowScale.ToOption(),
                    ReverseScale: ReverseScale.ToOption(),
                    NContours: NContours.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Creates a heatmap.
        ///
        /// A heatmap is a data visualization technique that shows magnitude of a phenomenon as color in two dimensions.
        /// </summary>
        /// <param name="zData">Sets the 2-dimensional z data, which will be visualized with the color scale.</param>
        /// <param name="X">Sets the x coordinates</param>
        /// <param name="MultiX">Sets the x coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Y">Sets the y coordinates</param>
        /// <param name="MultiY">Sets the y coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="XGap">Sets the horizontal gap (in pixels) between bricks.</param>
        /// <param name="YGap">Sets the vertical gap (in pixels) between bricks.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorBar">Sets the styles of the colorbar for this trace.</param>
        /// <param name="ColorScale">Sets the colorscale for this trace.</param>
        /// <param name="ShowScale">Whether or not to show the colorscale/colorbar</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
        /// <param name="ZSmooth">Picks a smoothing algorithm use to smooth `z` data.</param>
        /// <param name="Transpose">Transposes the z data.</param>
        /// <param name="UseWebGL">Whether or not to use WebGL to render this trace</param>
        /// <param name="ReverseYAxis">Whether or not to reverse the y axis. If true, (0,0) will lie on the top left and increase downwards.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Heatmap<ZType, XType, YType, TextType>(
            IEnumerable<IEnumerable<ZType>> zData, 
            Optional<IEnumerable<XType>> X = default,
            Optional<IEnumerable<IEnumerable<XType>>> MultiX = default,
            Optional<IEnumerable<YType>> Y = default,
            Optional<IEnumerable<IEnumerable<YType>>> MultiY = default,
            Optional<string> Name = default, 
            Optional<bool> ShowLegend = default, 
            Optional<double> Opacity = default, 
            Optional<int> XGap = default, 
            Optional<int> YGap = default, 
            Optional<TextType> Text = default, 
            Optional<IEnumerable<TextType>> MultiText = default, 
            Optional<ColorBar> ColorBar = default, 
            Optional<StyleParam.Colorscale> ColorScale = default, 
            Optional<bool> ShowScale = default, 
            Optional<bool> ReverseScale = default, 
            Optional<StyleParam.SmoothAlg> ZSmooth = default, 
            Optional<bool> Transpose = default, 
            Optional<bool> UseWebGL = default, 
            Optional<bool> ReverseYAxis = default, 
            Optional<bool> UseDefaults = default
        )
            where ZType : IConvertible
            where XType : IConvertible
            where YType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.Chart2D.Chart.Heatmap<IEnumerable<ZType>, ZType, XType, YType, TextType>(
                    zData: zData,
                    X: X.ToOption(),
                    MultiX: MultiX.ToOption(),
                    Y: Y.ToOption(),
                    MultiY: MultiY.ToOption(),
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    XGap: XGap.ToOption(),
                    YGap: YGap.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    ColorBar: ColorBar.ToOption(),
                    ColorScale: ColorScale.ToOption(),
                    ShowScale: ShowScale.ToOption(),
                    ReverseScale: ReverseScale.ToOption(),
                    ZSmooth: ZSmooth.ToOption(),
                    Transpose: Transpose.ToOption(),
                    UseWebGL: UseWebGL.ToOption(),
                    ReverseYAxis: ReverseYAxis.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Creates a annotated heatmap.
        ///
        /// A heatmap is a data visualization technique that shows magnitude of a phenomenon as color in two dimensions.
        ///
        /// The annotated heatmap additionally contains annotation text on each datum.
        /// </summary>
        /// <param name="zData">Sets the 2-dimensional z data, which will be visualized with the color scale.</param>
        /// <param name="annotationText">Sets the text to display as annotation for each datum.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="X">Sets the x coordinates.</param>
        /// <param name="MultiX">Sets the x coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="XGap">Sets the horizontal gap (in pixels) between bricks.</param>
        /// <param name="Y">Sets the y coordinates.</param>
        /// <param name="MultiY">Sets the y coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="YGap">Sets the vertical gap (in pixels) between bricks.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorBar">Sets the styles of the colorbar for this trace.</param>
        /// <param name="ColorScale">Sets the colorscale for this trace.</param>
        /// <param name="ShowScale">Whether or not to show the colorscale/colorbar</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
        /// <param name="ZSmooth">Picks a smoothing algorithm use to smooth `z` data.</param>
        /// <param name="Transpose">Transposes the z data.</param>
        /// <param name="UseWebGL">Whether or not to use WebGL to render this trace</param>
        /// <param name="ReverseYAxis">Whether or not to reverse the y axis. If true, (0,0) will lie on the top left and increase downwards.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart AnnotatedHeatmap<ZType, XType, YType, TextType>(
            IEnumerable<IEnumerable<ZType>> zData,
            IEnumerable<IEnumerable<string>> annotationText,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<IEnumerable<XType>> X = default,
            Optional<IEnumerable<IEnumerable<XType>>> MultiX = default,
            Optional<int> XGap = default,
            Optional<IEnumerable<YType>> Y = default,
            Optional<IEnumerable<IEnumerable<YType>>> MultiY = default,
            Optional<int> YGap = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<ColorBar> ColorBar = default,
            Optional<StyleParam.Colorscale> ColorScale = default,
            Optional<bool> ShowScale = default,
            Optional<bool> ReverseScale = default,
            Optional<StyleParam.SmoothAlg> ZSmooth = default,
            Optional<bool> Transpose = default,
            Optional<bool> UseWebGL = default,
            Optional<bool> ReverseYAxis = default,
            Optional<bool> UseDefaults = default
        )
            where ZType : IConvertible
            where XType : IConvertible
            where YType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.Chart2D.Chart.AnnotatedHeatmap<IEnumerable<ZType>, ZType, IEnumerable<string>, XType, YType, TextType>(
                    zData: zData,
                    annotationText: annotationText,
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    X: X.ToOption(),
                    MultiX: MultiX.ToOption(),
                    XGap: XGap.ToOption(),
                    Y: Y.ToOption(),
                    MultiY: MultiY.ToOption(),
                    YGap: YGap.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    ColorBar: ColorBar.ToOption(),
                    ColorScale: ColorScale.ToOption(),
                    ShowScale: ShowScale.ToOption(),
                    ReverseScale: ReverseScale.ToOption(),
                    ZSmooth: ZSmooth.ToOption(),
                    Transpose: Transpose.ToOption(),
                    UseWebGL: UseWebGL.ToOption(),
                    ReverseYAxis: ReverseYAxis.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Display an image, i.e. data on a 2D regular raster. By default, when an image is displayed in a subplot, its y axis will be reversed (ie. `autorange: 'reversed'`), constrained to the domain (ie. `constrain: 'domain'`) and it will have the same scale as its x axis (ie. `scaleanchor: 'x,`) in order for pixels to be rendered as squares.
        /// </summary>
        /// <param name="Z">A 2-dimensional array in which each element is an array of 3 or 4 numbers representing a color.</param>
        /// <param name="Source">Specifies the data URI of the image to be visualized. The URI consists of "data:image/[&lt;media subtype&gt;][;base64],&lt;data&gt;"</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
        /// <param name="ColorModel">Color model used to map the numerical color components described in `z` into colors. If `source` is specified, this attribute will be set to `rgba256` otherwise it defaults to `rgb`.</param>
        /// <param name="ZMax">Sets the upper bound of the color domain. Value should have the same units as in `z` and if set, `zmin` must be set as well.</param>
        /// <param name="ZMin">Sets the lower bound of the color domain. Value should have the same units as in `z` and if set, `zmax` must be set as well.</param>
        /// <param name="ZSmooth">Picks a smoothing algorithm use to smooth `z` data.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Image<IdType>(
            Optional<IEnumerable<IEnumerable<IEnumerable<int>>>> Z = default, 
            Optional<string> Source = default, 
            Optional<string> Name = default, 
            Optional<bool> ShowLegend = default, 
            Optional<double> Opacity = default, 
            Optional<IEnumerable<IdType>> Ids = default, 
            Optional<StyleParam.ColorModel> ColorModel = default, 
            Optional<StyleParam.ColorComponentBound> ZMax = default, 
            Optional<StyleParam.ColorComponentBound> ZMin = default, 
            Optional<StyleParam.SmoothAlg> ZSmooth = default, 
            Optional<bool> UseDefaults = default
        )
            where IdType : IConvertible
            =>
                Plotly.NET.Chart2D.Chart.Image<IEnumerable<IEnumerable<int>>, IEnumerable<int>, IdType>(
                    Z: Z.ToOption(),
                    Source: Source.ToOption(),
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    Ids: Ids.ToOption(),
                    ColorModel: ColorModel.ToOption(),
                    ZMax: ZMax.ToOption(),
                    ZMin: ZMin.ToOption(),
                    ZSmooth: ZSmooth.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Creates a 2D contour plot, which shows the contour lines of a 2D numerical array z, i.e. interpolated lines of isovalues of z.
        ///
        /// A contour line (also isoline, isopleth, or isarithm) of a function of two variables is a curve along which the function has a constant value, so that the curve joins points of equal value
        ///
        /// The data from which contour lines are computed is set in `z`. Data in `z` must be a 2D array of numbers. Say that `z` has N rows and M columns, then by default, these N rows correspond to N y coordinates (set in `y` or auto-generated) and the M columns correspond to M x coordinates (set in `x` or auto-generated). By setting `transpose` to "true", the above behavior is flipped.
        /// </summary>
        /// <param name="zData">Sets the z data which is used for computing the contour lines.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="X">Sets the x coordinates.</param>
        /// <param name="MultiX">Sets the x coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Y">Sets the y coordinates.</param>
        /// <param name="MultiY">Sets the y coordinates. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorBar">Sets the styles of the colorbar for this trace.</param>
        /// <param name="ColorScale">Sets the colorscale for this trace.</param>
        /// <param name="ShowScale">Whether or not to show the colorscale/colorbar</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `zmin` will correspond to the last color in the array and `zmax` will correspond to the first color.</param>
        /// <param name="Transpose">Transposes the z data.</param>
        /// <param name="ContourLinesDash">Sets the contour line dash style</param>
        /// <param name="ContourLinesColor">Sets the contour line color</param>
        /// <param name="ContourLinesSmoothing">Sets the amount of smoothing for the contour lines, where "0" corresponds to no smoothing.</param>
        /// <param name="ContourLinesWidth">Sets the width of the contour lines</param>
        /// <param name="ContourLines">Sets the contour lines (use this for more finegrained control than the other contourline-associated arguments).</param>
        /// <param name="ShowContourLines">Wether or not to show the contour line</param>
        /// <param name="ContoursColoring">Determines the coloring method showing the contour values. If "fill", coloring is done evenly between each contour level If "heatmap", a heatmap gradient coloring is applied between each contour level. If "lines", coloring is done on the contour lines. If "none", no coloring is applied on this trace.</param>
        /// <param name="ContoursOperation">Sets the constraint operation. "=" keeps regions equal to `value` "&lt;" and "&lt;=" keep regions less than `value` "&gt;" and "&gt;=" keep regions greater than `value` "[]", "()", "[)", and "(]" keep regions inside `value[0]` to `value[1]` "][", ")(", "](", ")[" keep regions outside `value[0]` to value[1]` Open vs. closed intervals make no difference to constraint display, but all versions are allowed for consistency with filter transforms.</param>
        /// <param name="ContoursType">If `levels`, the data is represented as a contour plot with multiple levels displayed. If `constraint`, the data is represented as constraints with the invalid region shaded as specified by the `operation` and `value` parameters.</param>
        /// <param name="ShowContoursLabels">Determines whether to label the contour lines with their values.</param>
        /// <param name="ContourLabelFont">Sets the font used for labeling the contour levels. The default color comes from the lines, if shown. The default family and size come from `layout.font`.</param>
        /// <param name="ContoursStart">Sets the starting contour level value. Must be less than `contours.end`</param>
        /// <param name="ContoursEnd">Sets the end contour level value. Must be more than `contours.start`</param>
        /// <param name="Contours">Sets the styles of the contours (use this for more finegrained control than the other contour-associated arguments).</param>
        /// <param name="FillColor">Sets the fill color if `contours.type` is "constraint". Defaults to a half-transparent variant of the line color, marker color, or marker line color, whichever is available.</param>
        /// <param name="NContours">Sets the maximum number of contour levels. The actual number of contours will be chosen automatically to be less than or equal to the value of `ncontours`. Has an effect only if `autocontour` is "true" or if `contours.size` is missing.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Contour<ZType, XType, YType, TextType>(
            IEnumerable<IEnumerable<ZType>> zData, 
            Optional<string> Name = default, 
            Optional<bool> ShowLegend = default, 
            Optional<double> Opacity = default, 
            Optional<IEnumerable<XType>> X = default,
            Optional<IEnumerable<IEnumerable<XType>>> MultiX = default,
            Optional<IEnumerable<YType>> Y = default,
            Optional<IEnumerable<IEnumerable<YType>>> MultiY = default,
            Optional<TextType> Text = default, 
            Optional<IEnumerable<TextType>> MultiText = default, 
            Optional<ColorBar> ColorBar = default, 
            Optional<StyleParam.Colorscale> ColorScale = default, 
            Optional<bool> ShowScale = default, 
            Optional<bool> ReverseScale = default, 
            Optional<bool> Transpose = default,
            Optional<StyleParam.DrawingStyle> ContourLinesDash = default,
            Optional<Color> ContourLinesColor = default,
            Optional<double> ContourLinesSmoothing = default,
            Optional<double> ContourLinesWidth = default,
            Optional<Line> ContourLines = default,
            Optional<bool> ShowContourLines = default,
            Optional<StyleParam.ContourColoring> ContoursColoring = default,
            Optional<StyleParam.ConstraintOperation> ContoursOperation = default,
            Optional<StyleParam.ContourType> ContoursType = default,
            Optional<bool> ShowContoursLabels = default,
            Optional<Font> ContourLabelFont = default,
            Optional<double> ContoursStart = default,
            Optional<double> ContoursEnd = default,
            Optional<Contours> Contours = default,
            Optional<Color> FillColor = default, 
            Optional<int> NContours = default, 
            Optional<bool> UseDefaults = default
        )
            where ZType : IConvertible
            where XType : IConvertible
            where YType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.Chart2D.Chart.Contour<IEnumerable<ZType>, ZType, XType, YType, TextType>(
                    zData: zData,
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    X: X.ToOption(),
                    MultiX: MultiX.ToOption(),
                    Y: Y.ToOption(),
                    MultiY: MultiY.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    ColorBar: ColorBar.ToOption(),
                    ColorScale: ColorScale.ToOption(),
                    ShowScale: ShowScale.ToOption(),
                    ReverseScale: ReverseScale.ToOption(),
                    Transpose: Transpose.ToOption(),
                    ContourLinesDash: ContourLinesDash.ToOption(),
                    ContourLinesColor: ContourLinesColor.ToOption(),
                    ContourLinesSmoothing: ContourLinesSmoothing.ToOption(),
                    ContourLinesWidth: ContourLinesWidth.ToOption(),
                    ContourLines: ContourLines.ToOption(),
                    ShowContourLines: ShowContourLines.ToOption(),
                    ContoursColoring: ContoursColoring.ToOption(),
                    ContoursOperation: ContoursOperation.ToOption(),
                    ContoursType: ContoursType.ToOption(),
                    ShowContoursLabels: ShowContoursLabels.ToOption(),
                    ContoursLabelFont: ContourLabelFont.ToOption(),
                    ContoursStart: ContoursStart.ToOption(),
                    ContoursEnd: ContoursEnd.ToOption(),
                    Contours: Contours.ToOption(),
                    FillColor: FillColor.ToOption(),
                    NContours: NContours.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );


        /// <summary>
        /// Creates an OHLC chart.
        ///
        /// The ohlc (short for Open-High-Low-Close) is a style of financial chart describing open, high, low and close for a given `x` coordinate (most likely time). The tip of the lines represent the `low` and `high` values and the horizontal segments represent the `open` and `close` values. Sample points where the close value is higher (lower) then the open value are called increasing (decreasing). By default, increasing items are drawn in green whereas decreasing are drawn in red.
        /// </summary>
        /// <param name="open">Sets the open values.</param>
        /// <param name="high">Sets the high values.</param>
        /// <param name="low">Sets the low values.</param>
        /// <param name="close">Sets the close values.</param>
        /// <param name="X">Sets the x coordinates. If absent, linear coordinate will be generated.</param>
        /// <param name="MultiX">Sets the x coordinates. If absent, linear coordinate will be generated. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="Line">Sets the line of this trace.</param>
        /// <param name="IncreasingColor">Sets the color of increasing values</param>
        /// <param name="Increasing">Sets the style options of increasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="DecreasingColor">Sets the color of decreasing values</param>
        /// <param name="Decreasing">Sets the style options of decreasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="TickWidth">Sets the width of the open/close tick marks relative to the "x" minimal interval.</param>
        /// <param name="ShowXAxisRangeSlider">Whether or not to show a rangeslider for the xaxis</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart OHLC<OHLCType, XType, TextType>(
            IEnumerable<OHLCType> open,
            IEnumerable<OHLCType> high,
            IEnumerable<OHLCType> low,
            IEnumerable<OHLCType> close,
            Optional<IEnumerable<XType>> X,
            Optional<IEnumerable<IEnumerable<XType>>> MultiX,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<Line> Line = default,
            Optional<Color> IncreasingColor = default,
            Optional<FinanceMarker> Increasing = default,
            Optional<Color> DecreasingColor = default,
            Optional<FinanceMarker> Decreasing = default,
            Optional<double> TickWidth = default,
            Optional<bool> ShowXAxisRangeSlider = default,
            Optional<bool> UseDefaults = default
        )
            where OHLCType : IConvertible
            where XType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.Chart2D.Chart.OHLC<OHLCType, OHLCType, OHLCType, OHLCType, XType, TextType>(
                    open: open,
                    high: high,
                    low: low,
                    close: close,
                    X: X.ToOption(),
                    MultiX: MultiX.ToOption(),
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    Line: Line.ToOption(),
                    IncreasingColor: IncreasingColor.ToOption(),
                    Increasing: Increasing.ToOption(),
                    DecreasingColor: DecreasingColor.ToOption(),
                    Decreasing: Decreasing.ToOption(),
                    TickWidth: TickWidth.ToOption(),
                    ShowXAxisRangeSlider: ShowXAxisRangeSlider.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Creates a candlestick chart.
        ///
        /// The candlestick is a style of financial chart describing open, high, low and close for a given `x` coordinate (most likely time). The boxes represent the spread between the `open` and `close` values and the lines represent the spread between the `low` and `high` values Sample points where the close value is higher (lower) then the open value are called increasing (decreasing). By default, increasing candles are drawn in green whereas decreasing are drawn in red.
        /// </summary>
        /// <param name="open">Sets the open values.</param>
        /// <param name="high">Sets the high values.</param>
        /// <param name="low">Sets the low values.</param>
        /// <param name="close">Sets the close values.</param>
        /// <param name="X">Sets the x coordinates. If absent, linear coordinate will be generated.</param>
        /// <param name="MultiX">Sets the x coordinates. If absent, linear coordinate will be generated. Use two inner arrays here to plot multicategorial data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="Line">Sets the line of this trace.</param>
        /// <param name="IncreasingColor">Sets the color of increasing values</param>
        /// <param name="Increasing">Sets the style options of increasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="DecreasingColor">Sets the color of decreasing values</param>
        /// <param name="Decreasing">Sets the style options of decreasing values (use this for more finegrained control than the other increasing-associated arguments).</param>
        /// <param name="WhiskerWidth">Sets the width of the whiskers relative to the box' width. For example, with 1, the whiskers are as wide as the box(es).</param>
        /// <param name="ShowXAxisRangeSlider">Whether or not to show a rangeslider for the xaxis</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Candlestick<OHLCType, XType, TextType>(
            IEnumerable<OHLCType> open,
            IEnumerable<OHLCType> high,
            IEnumerable<OHLCType> low,
            IEnumerable<OHLCType> close,
            Optional<IEnumerable<XType>> X,
            Optional<IEnumerable<IEnumerable<XType>>> MultiX,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<Line> Line = default,
            Optional<Color> IncreasingColor = default,
            Optional<FinanceMarker> Increasing = default,
            Optional<Color> DecreasingColor = default,
            Optional<FinanceMarker> Decreasing = default,
            Optional<double> WhiskerWidth = default,
            Optional<bool> ShowXAxisRangeSlider = default,
            Optional<bool> UseDefaults = default
        )
            where OHLCType : IConvertible
            where XType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.Chart2D.Chart.Candlestick<OHLCType, OHLCType, OHLCType, OHLCType, XType, TextType>(
                    open: open,
                    high: high,
                    low: low,
                    close: close,
                    X: X.ToOption(),
                    MultiX: MultiX.ToOption(),
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    Line: Line.ToOption(),
                    IncreasingColor: IncreasingColor.ToOption(),
                    Increasing: Increasing.ToOption(),
                    DecreasingColor: DecreasingColor.ToOption(),
                    Decreasing: Decreasing.ToOption(),
                    WhiskerWidth: WhiskerWidth.ToOption(),
                    ShowXAxisRangeSlider: ShowXAxisRangeSlider.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Creates a scatter plot matrix (SPLOM) from multiple input dimensions.
        ///
        /// Each splom `dimensions` items correspond to a generated axis. Values for each of those dimensions are set in `dimensions[i].values`. Splom traces support all `scattergl` marker style attributes. Specify `layout.grid` attributes and/or layout x-axis and y-axis attributes for more control over the axis positioning and style.
        /// </summary>
        /// <param name="dimensions">Sets the dimensions of the scatter plot matrix, where each item corresponds to a generated axis.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the Opacity otf the trace.</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="MarkerColor">Sets the color of the marker.</param>
        /// <param name="MarkerColorScale">Sets the colorscale of the marker. Use `Color.fromColorScaleValues` to map marker colors to a colorscale.</param>
        /// <param name="MarkerOutline">Sets the outline of the marker</param>
        /// <param name="MarkerSymbol">Sets the symbol of all marker</param>
        /// <param name="MultiMarkerSymbol">Sets the symbol of each individual marker</param>
        /// <param name="Marker">Sets the markers (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="ShowDiagonal">Whether or not to show the matrix diagional</param>
        /// <param name="Diagonal">Sets the styles applied to the scatter plot matrix diagonal</param>
        /// <param name="ShowLowerHalf">Determines whether or not subplots on the lower half from the diagonal are displayed.</param>
        /// <param name="ShowUpperHalf">Determines whether or not subplots on the upper half from the diagonal are displayed.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Splom<TextType>(
            IEnumerable<Dimension> dimensions, 
            Optional<string> Name = default, 
            Optional<bool> ShowLegend = default, 
            Optional<double> Opacity = default, 
            Optional<TextType> Text = default, 
            Optional<IEnumerable<TextType>> MultiText = default, 
            Optional<Color> MarkerColor = default, 
            Optional<StyleParam.Colorscale> MarkerColorScale = default, 
            Optional<Line> MarkerOutline = default, 
            Optional<StyleParam.MarkerSymbol> MarkerSymbol = default, 
            Optional<IEnumerable<StyleParam.MarkerSymbol>> MultiMarkerSymbol = default, 
            Optional<Marker> Marker = default, 
            Optional<bool> ShowDiagonal = default, 
            Optional<SplomDiagonal> Diagonal = default, 
            Optional<bool> ShowLowerHalf = default, 
            Optional<bool> ShowUpperHalf = default, 
            Optional<bool> UseDefaults = default
        )
            where TextType : IConvertible
            =>
                Plotly.NET.Chart2D.Chart.Splom<TextType>(
                    dimensions: dimensions,
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    MarkerColor: MarkerColor.ToOption(),
                    MarkerColorScale: MarkerColorScale.ToOption(),
                    MarkerOutline: MarkerOutline.ToOption(),
                    MarkerSymbol: MarkerSymbol.ToOption(),
                    MultiMarkerSymbol: MultiMarkerSymbol.ToOption(),
                    Marker: Marker.ToOption(),
                    ShowDiagonal: ShowDiagonal.ToOption(),
                    Diagonal: Diagonal.ToOption(),
                    ShowLowerHalf: ShowLowerHalf.ToOption(),
                    ShowUpperHalf: ShowUpperHalf.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Creates a point density plot - a combination of a Scatter plot and Histogram2DContour.
        ///
        /// Additionally to plotting the (x,y) data as points on a 2D plane, a density contour plot is computed by grouping a set of points specified by their x and y coordinates into bins, and applying a count aggregation function to compute the value to be used to compute contours.
        /// The sample data from which statistics are computed is set in `x` and `y` (where `x` and `y` represent marginal distributions, binning is set in `xbins` and `ybins` in this case). The resulting distribution is visualized as a contour plot.
        ///
        /// </summary>
        /// <param name="x">Sets the x coordinates of the plotted data as well as the sample data to be binned on the x axis.</param>
        /// <param name="y">Sets the y coordinates of the plotted data as well as the sample data to be binned on the y axis.</param>
        /// <param name="PointOpacity">Sets the opacity of the point trace.</param>
        /// <param name="PointMarkerColor">Sets the marker color of the point trace.</param>
        /// <param name="PointMarkerSymbol">Sets the marker symbol of the point trace.</param>
        /// <param name="PointMarkerSize">Sets the marker size of the point trace.</param>
        /// <param name="ContourLinesDash">Sets the contour line dash style</param>
        /// <param name="ContourLinesColor">Sets the contour line color</param>
        /// <param name="ContourLinesSmoothing">Sets the amount of smoothing for the contour lines, where "0" corresponds to no smoothing.</param>
        /// <param name="ContourLinesWidth">Sets the width of the contour lines</param>
        /// <param name="ContourLines">Sets the contour lines (use this for more finegrained control than the other contourline-associated arguments).</param>
        /// <param name="ShowContourLines">Wether or not to show the contour line</param>
        /// <param name="ContoursColoring">Determines the coloring method showing the contour values. If "fill", coloring is done evenly between each contour level If "heatmap", a heatmap gradient coloring is applied between each contour level. If "lines", coloring is done on the contour lines. If "none", no coloring is applied on this trace.</param>
        /// <param name="ContoursOperation">Sets the constraint operation. "=" keeps regions equal to `value` "&lt;" and "&lt;=" keep regions less than `value` "&gt;" and "&gt;=" keep regions greater than `value` "[]", "()", "[)", and "(]" keep regions inside `value[0]` to `value[1]` "][", ")(", "](", ")[" keep regions outside `value[0]` to value[1]` Open vs. closed intervals make no difference to constraint display, but all versions are allowed for consistency with filter transforms.</param>
        /// <param name="ContoursType">If `levels`, the data is represented as a contour plot with multiple levels displayed. If `constraint`, the data is represented as constraints with the invalid region shaded as specified by the `operation` and `value` parameters.</param>
        /// <param name="ShowContoursLabels">Determines whether to label the contour lines with their values.</param>
        /// <param name="ContourLabelFont">Sets the font used for labeling the contour levels. The default color comes from the lines, if shown. The default family and size come from `layout.font`.</param>
        /// <param name="ContoursStart">Sets the starting contour level value. Must be less than `contours.end`</param>
        /// <param name="ContoursEnd">Sets the end contour level value. Must be more than `contours.start`</param>
        /// <param name="Contours">Sets the styles of the contours (use this for more finegrained control than the other contour-associated arguments).</param>
        /// <param name="NContours">Sets the maximum number of contour levels. The actual number of contours will be chosen automatically to be less than or equal to the value of `ncontours`. Has an effect only if `autocontour` is "true" or if `contours.size` is missing.</param>
        /// <param name="HistNorm">Specifies the type of normalization used for this histogram trace. If "", the span of each bar corresponds to the number of occurrences (i.e. the number of data points lying inside the bins). If "percent" / "probability", the span of each bar corresponds to the percentage / fraction of occurrences with respect to the total number of sample points (here, the sum of all bin HEIGHTS equals 100% / 1). If "density", the span of each bar corresponds to the number of occurrences in a bin divided by the size of the bin interval (here, the sum of all bin AREAS equals the total number of sample points). If "probability density", the area of each bar corresponds to the probability that an event will fall into the corresponding bin (here, the sum of all bin AREAS equals 1).</param>
        /// <param name="ContourOpacity">Sets the opacity of the histogram2dcontour trace.</param>
        /// <param name="ColorBar">Sets the color bar.</param>
        /// <param name="ColorScale">Sets the colorscale of the histogram2dcontour trace.</param>
        /// <param name="ShowScale">whether or not to show the colorbar</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart PointDensity<XType, YType>(
            IEnumerable<XType> x,
            IEnumerable<YType> y, 
            Optional<double> PointOpacity = default, 
            Optional<Color> PointMarkerColor = default, 
            Optional<StyleParam.MarkerSymbol> PointMarkerSymbol = default, 
            Optional<int> PointMarkerSize = default,
            Optional<StyleParam.DrawingStyle> ContourLinesDash = default,
            Optional<Color> ContourLinesColor = default,
            Optional<double> ContourLinesSmoothing = default,
            Optional<double> ContourLinesWidth = default,
            Optional<Line> ContourLines = default,
            Optional<bool> ShowContourLines = default,
            Optional<StyleParam.ContourColoring> ContoursColoring = default,
            Optional<StyleParam.ConstraintOperation> ContoursOperation = default,
            Optional<StyleParam.ContourType> ContoursType = default,
            Optional<bool> ShowContoursLabels = default,
            Optional<Font> ContourLabelFont = default,
            Optional<double> ContoursStart = default,
            Optional<double> ContoursEnd = default,
            Optional<Contours> Contours = default,
            Optional<int> NContours = default,
            Optional<StyleParam.HistNorm> HistNorm = default,
            Optional<double> ContourOpacity = default,
            Optional<ColorBar> ColorBar = default, 
            Optional<StyleParam.Colorscale> ColorScale = default, 
            Optional<bool> ShowScale = default, 
            Optional<bool> UseDefaults = default
        )
            where XType : IConvertible
            where YType : IConvertible
            =>
                Plotly.NET.Chart2D.Chart.PointDensity<XType, YType>(
                    x: x,
                    y: y,
                    PointOpacity: PointOpacity.ToOption(),
                    PointMarkerColor: PointMarkerColor.ToOption(),
                    PointMarkerSymbol: PointMarkerSymbol.ToOption(),
                    PointMarkerSize: PointMarkerSize.ToOption(),
                    ContourLinesDash: ContourLinesDash.ToOption(),
                    ContourLinesColor: ContourLinesColor.ToOption(),
                    ContourLinesSmoothing: ContourLinesSmoothing.ToOption(),
                    ContourLinesWidth: ContourLinesWidth.ToOption(),
                    ContourLines: ContourLines.ToOption(),
                    ShowContourLines: ShowContourLines.ToOption(),
                    ContoursColoring: ContoursColoring.ToOption(),
                    ContoursOperation: ContoursOperation.ToOption(),
                    ContoursType: ContoursType.ToOption(),
                    ShowContoursLabels: ShowContoursLabels.ToOption(),
                    ContoursLabelFont: ContourLabelFont.ToOption(),
                    ContoursStart: ContoursStart.ToOption(),
                    ContoursEnd: ContoursEnd.ToOption(),
                    Contours: Contours.ToOption(),
                    NContours: NContours.ToOption(),
                    HistNorm: HistNorm.ToOption(),
                    ContourOpacity: ContourOpacity.ToOption(),
                    ColorBar: ColorBar.ToOption(),
                    ColorScale: ColorScale.ToOption(),
                    ShowScale: ShowScale.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

    };

}
