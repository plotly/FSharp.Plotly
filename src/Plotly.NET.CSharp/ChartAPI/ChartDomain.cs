using Microsoft.FSharp.Core;
using Plotly.NET;
using Plotly.NET.LayoutObjects;
using Plotly.NET.TraceObjects;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace Plotly.NET.CSharp
{
    public static partial class Chart
    {
        /// <summary>
        /// Creates a pie chart.
        ///
        /// A pie chart (or a circle chart) is a circular statistical graphic, which is divided into slices to illustrate numerical proportion.
        /// In a pie chart, the arc length of each slice (and consequently its central angle and area), is proportional to the quantity it represents.
        /// </summary>
        /// <param name="values">Sets the values of the sectors</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Labels">Sets the sector labels. If `labels` entries are duplicated, the associated `values` are summed.</param>
        /// <param name="Pull">Sets the fraction of larger radius to pull the sectors out from the center. This can be a constant to pull all slices apart from each other equally or an array to highlight one or more slices.</param>
        /// <param name="MultiPull">Sets the fraction of larger radius to pull the sectors out from the center. This can be a constant to pull all slices apart from each other equally or an array to highlight one or more slices.</param>
        /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="TextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="MultiTextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="SectionColors">Sets the colors associated with each section.</param>
        /// <param name="SectionOutlineColor">Sets the color of the section outline.</param>
        /// <param name="SectionOutlineWidth">Sets the width of the section outline.</param>
        /// <param name="SectionOutlineMultiWidth">Sets the width of each individual section outline.</param>
        /// <param name="SectionOutline">Sets the section outline (use this for more finegrained control than the other section outline-associated arguments).</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all sections</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each bar</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the sections (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="TextInfo">Determines which trace information appear on the graph.</param>
        /// <param name="Direction">Specifies the direction at which succeeding sectors follow one another.</param>
        /// <param name="Hole">Sets the fraction of the radius to cut out of the pie. Use this to make a donut chart.</param>
        /// <param name="Rotation">Instead of the first slice starting at 12 o'clock, rotate to some other angle.</param>
        /// <param name="Sort">Determines whether or not the sectors are reordered from largest to smallest.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Pie<ValuesType, LabelsType, TextType>(
            IEnumerable<ValuesType> values,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<IEnumerable<double>> MultiOpacity = default,
            Optional<IEnumerable<LabelsType>> Labels = default,
            Optional<double> Pull = default,
            Optional<IEnumerable<double>> MultiPull = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<StyleParam.TextPosition> TextPosition = default,
            Optional<IEnumerable<StyleParam.TextPosition>> MultiTextPosition = default,
            Optional<IEnumerable<Color>> SectionColors = default,
            Optional<Color> SectionOutlineColor = default,
            Optional<double> SectionOutlineWidth = default,
            Optional<IEnumerable<double>> SectionOutlineMultiWidth = default,
            Optional<Line> SectionOutline = default,
            Optional<StyleParam.PatternShape> MarkerPatternShape = default,
            Optional<IEnumerable<StyleParam.PatternShape>> MultiMarkerPatternShape = default,
            Optional<Pattern> MarkerPattern = default,
            Optional<Marker> Marker = default,
            Optional<StyleParam.TextInfo> TextInfo = default,
            Optional<StyleParam.Direction> Direction = default,
            Optional<double> Hole = default,
            Optional<double> Rotation = default,
            Optional<bool> Sort = default,
            Optional<bool> UseDefaults = default
        )
            where ValuesType : IConvertible
            where LabelsType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.ChartDomain.Chart.Pie<ValuesType, LabelsType, TextType>(
                    values: values,
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    MultiOpacity: MultiOpacity.ToOption(),
                    Labels: Labels.ToOption(),
                    Pull: Pull.ToOption(),
                    MultiPull: MultiPull.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    TextPosition: TextPosition.ToOption(),
                    MultiTextPosition: MultiTextPosition.ToOption(),
                    SectionColors: SectionColors.ToOption(),
                    SectionOutlineColor: SectionOutlineColor.ToOption(),
                    SectionOutlineWidth: SectionOutlineWidth.ToOption(),
                    SectionOutlineMultiWidth: SectionOutlineMultiWidth.ToOption(),
                    SectionOutline: SectionOutline.ToOption(),
                    MarkerPatternShape: MarkerPatternShape.ToOption(),
                    MultiMarkerPatternShape: MultiMarkerPatternShape.ToOption(),
                    MarkerPattern: MarkerPattern.ToOption(),
                    Marker: Marker.ToOption(),
                    TextInfo: TextInfo.ToOption(),
                    Direction: Direction.ToOption(),
                    Hole: Hole.ToOption(),
                    Rotation: Rotation.ToOption(),
                    Sort: Sort.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Creates a doughnut chart.
        ///
        /// A doughnut chart is a variation of the pie chart that has a fraction cut from the center of the slices.
        /// </summary>
        /// <param name="values">Sets the values of the sectors</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="Hole">Sets the fraction of the radius to cut out of the pie. Use this to make a donut chart.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Labels">Sets the sector labels. If `labels` entries are duplicated, the associated `values` are summed.</param>
        /// <param name="Pull">Sets the fraction of larger radius to pull the sectors out from the center. This can be a constant to pull all slices apart from each other equally or an array to highlight one or more slices.</param>
        /// <param name="MultiPull">Sets the fraction of larger radius to pull the sectors out from the center. This can be a constant to pull all slices apart from each other equally or an array to highlight one or more slices.</param>
        /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="TextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="MultiTextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="SectionColors">Sets the colors associated with each section.</param>
        /// <param name="SectionOutlineColor">Sets the color of the section outline.</param>
        /// <param name="SectionOutlineWidth">Sets the width of the section outline.</param>
        /// <param name="SectionOutlineMultiWidth">Sets the width of each individual section outline.</param>
        /// <param name="SectionOutline">Sets the section outline (use this for more finegrained control than the other section outline-associated arguments).</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all sections</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each section</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the sections (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="TextInfo">Determines which trace information appear on the graph.</param>
        /// <param name="Direction">Specifies the direction at which succeeding sectors follow one another.</param>
        /// <param name="Rotation">Instead of the first slice starting at 12 o'clock, rotate to some other angle.</param>
        /// <param name="Sort">Determines whether or not the sectors are reordered from largest to smallest.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Doughnut<ValuesType, LabelsType, TextType>(
            IEnumerable<ValuesType> values,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<IEnumerable<double>> MultiOpacity = default,
            Optional<IEnumerable<LabelsType>> Labels = default,
            Optional<double> Pull = default,
            Optional<IEnumerable<double>> MultiPull = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<StyleParam.TextPosition> TextPosition = default,
            Optional<IEnumerable<StyleParam.TextPosition>> MultiTextPosition = default,
            Optional<IEnumerable<Color>> SectionColors = default,
            Optional<Color> SectionOutlineColor = default,
            Optional<double> SectionOutlineWidth = default,
            Optional<IEnumerable<double>> SectionOutlineMultiWidth = default,
            Optional<Line> SectionOutline = default,
            Optional<StyleParam.PatternShape> MarkerPatternShape = default,
            Optional<IEnumerable<StyleParam.PatternShape>> MultiMarkerPatternShape = default,
            Optional<Pattern> MarkerPattern = default, 
            Optional<Marker> Marker = default,
            Optional<StyleParam.TextInfo> TextInfo = default,
            Optional<StyleParam.Direction> Direction = default,
            Optional<double> Hole = default,
            Optional<double> Rotation = default,
            Optional<bool> Sort = default,
            Optional<bool> UseDefaults = default
        )
            where ValuesType : IConvertible
            where LabelsType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.ChartDomain.Chart.Doughnut<ValuesType, LabelsType, TextType>(
                    values: values,
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    MultiOpacity: MultiOpacity.ToOption(),
                    Labels: Labels.ToOption(),
                    Pull: Pull.ToOption(),
                    MultiPull: MultiPull.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    TextPosition: TextPosition.ToOption(),
                    MultiTextPosition: MultiTextPosition.ToOption(),
                    SectionColors: SectionColors.ToOption(),
                    SectionOutlineColor: SectionOutlineColor.ToOption(),
                    SectionOutlineWidth: SectionOutlineWidth.ToOption(),
                    SectionOutlineMultiWidth: SectionOutlineMultiWidth.ToOption(),
                    SectionOutline: SectionOutline.ToOption(),
                    MarkerPatternShape: MarkerPatternShape.ToOption(),
                    MultiMarkerPatternShape: MultiMarkerPatternShape.ToOption(),
                    MarkerPattern: MarkerPattern.ToOption(),
                    Marker: Marker.ToOption(),
                    TextInfo: TextInfo.ToOption(),
                    Direction: Direction.ToOption(),
                    Hole: Hole.ToOption(),
                    Rotation: Rotation.ToOption(),
                    Sort: Sort.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Creates a FunnelArea chart.
        ///
        /// FunnelArea charts visualize stages in a process using area-encoded trapezoids, which can be used to show data in a part-to-whole representation similar to a piechart,
        /// wherein each item appears in a single stage. See also the "funnel" chart for a different approach to visualizing funnel data.
        /// </summary>
        /// <param name="values">Sets the values of the sectors</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Labels">Sets the sector labels. If `labels` entries are duplicated, the associated `values` are summed.</param>
        /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="TextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="MultiTextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="SectionColors">Sets the colors associated with each section.</param>
        /// <param name="SectionOutlineColor">Sets the color of the section outline.</param>
        /// <param name="SectionOutlineWidth">Sets the width of the section outline.</param>
        /// <param name="SectionOutlineMultiWidth">Sets the width of each individual section outline.</param>
        /// <param name="SectionOutline">Sets the section outline (use this for more finegrained control than the other section outline-associated arguments).</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all sections</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each section</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the sections (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="TextInfo">Determines which trace information appear on the graph.</param>
        /// <param name="AspectRatio"></param>
        /// <param name="BaseRatio"></param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart FunnelArea<ValuesType, LabelsType, TextType>(
            IEnumerable<ValuesType> values, 
            Optional<string> Name = default, 
            Optional<bool> ShowLegend = default, 
            Optional<double> Opacity = default,
            Optional<IEnumerable<double>> MultiOpacity = default, 
            Optional<IEnumerable<LabelsType>> Labels = default, 
            Optional<TextType> Text = default, 
            Optional<IEnumerable<TextType>> MultiText = default, 
            Optional<StyleParam.TextPosition> TextPosition = default,
            Optional<IEnumerable<StyleParam.TextPosition>> MultiTextPosition = default,
            Optional<IEnumerable<Color>> SectionColors = default, 
            Optional<Color> SectionOutlineColor = default, 
            Optional<double> SectionOutlineWidth = default, 
            Optional<IEnumerable<double>> SectionOutlineMultiWidth = default, 
            Optional<Line> SectionOutline = default,
            Optional<StyleParam.PatternShape> MarkerPatternShape = default,
            Optional<IEnumerable<StyleParam.PatternShape>> MultiMarkerPatternShape = default,
            Optional<Pattern> MarkerPattern = default, 
            Optional<Marker> Marker = default, 
            Optional<StyleParam.TextInfo> TextInfo = default, 
            Optional<double> AspectRatio = default, 
            Optional<double> BaseRatio = default, 
            Optional<bool> UseDefaults = default
        )
            where ValuesType : IConvertible
            where LabelsType : IConvertible
            where TextType   : IConvertible
            =>
                Plotly.NET.ChartDomain.Chart.FunnelArea<ValuesType, LabelsType, TextType>(
                    values: values,
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    MultiOpacity: MultiOpacity.ToOption(),
                    Labels: Labels.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    TextPosition: TextPosition.ToOption(),
                    MultiTextPosition: MultiTextPosition.ToOption(),
                    SectionColors: SectionColors.ToOption(),
                    SectionOutlineColor: SectionOutlineColor.ToOption(),
                    SectionOutlineWidth: SectionOutlineWidth.ToOption(),
                    SectionOutlineMultiWidth: SectionOutlineMultiWidth.ToOption(),
                    SectionOutline: SectionOutline.ToOption(),
                    MarkerPatternShape: MarkerPatternShape.ToOption(),
                    MultiMarkerPatternShape: MultiMarkerPatternShape.ToOption(),
                    MarkerPattern: MarkerPattern.ToOption(),
                    Marker: Marker.ToOption(),
                    TextInfo: TextInfo.ToOption(),
                    AspectRatio: AspectRatio.ToOption(),
                    BaseRatio: BaseRatio.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Creates a sunburst chart, which visualizes hierarchical data spanning outward radially from root to leaves.
        ///
        /// The hierarchy is defined by labels and parents attributes. The root starts from the center and children are added to the outer rings.
        /// </summary>
        /// <param name="labels">Sets the labels of each of the sectors.</param>
        /// <param name="parents">Sets the parent sectors for each of the sectors. Empty string items '' are understood to reference the root node in the hierarchy. If `ids` is filled, `parents` items are understood to be "ids" themselves. When `ids` is not set, plotly attempts to find matching items in `labels`, but beware they must be unique.</param>
        /// <param name="Values">Sets the values associated with each of the sectors.</param>
        /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="SectionColors">Sets the colors associated with each section.</param>
        /// <param name="SectionColorScale">Sets the colorscale for the section values</param>
        /// <param name="ShowSectionColorScale">Whether or not to show the section colorbar</param>
        /// <param name="ReverseSectionColorScale">Whether or not to show the section colorscale</param>
        /// <param name="SectionOutlineColor">Sets the color of the section outline.</param>
        /// <param name="SectionOutlineWidth">Sets the width of the section outline.</param>
        /// <param name="SectionOutlineMultiWidth">Sets the width of each individual section outline.</param>
        /// <param name="SectionOutline">Sets the section outline (use this for more finegrained control than the other section outline-associated arguments).</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all sections</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each section</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the sections (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="TextInfo">Determines which trace information appear on the graph.</param>
        /// <param name="BranchValues">Determines how the items in `values` are summed. When set to "total", items in `values` are taken to be value of all its descendants. When set to "remainder", items in `values` corresponding to the root and the branches sectors are taken to be the extra part not part of the sum of the values at their leaves.</param>
        /// <param name="Count">Determines default for `values` when it is not provided, by inferring a 1 for each of the "leaves" and/or "branches", otherwise 0.</param>
        /// <param name="Root">Sets the styles for the root of this trace.</param>
        /// <param name="Leaf">Sets the styles for the leaves of this trace.</param>
        /// <param name="Level">Sets the level from which this trace hierarchy is rendered. Set `level` to `''` to start from the root node in the hierarchy. Must be an "id" if `ids` is filled in, otherwise plotly attempts to find a matching item in `labels`.</param>
        /// <param name="MaxDepth">Sets the number of rendered sectors from any given `level`. Set `maxdepth` to "-1" to render all the levels in the hierarchy.</param>
        /// <param name="Rotation">Rotates the whole diagram counterclockwise by some angle. By default the first slice starts at 3 o'clock.</param>
        /// <param name="Sort">Determines whether or not the sectors are reordered from largest to smallest.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Sunburst<LabelsType, ParentsType, ValuesType, IdsType, TextType>(
            IEnumerable<LabelsType> labels,
            IEnumerable<ParentsType> parents,
            Optional<IEnumerable<ValuesType>> Values = default,
            Optional<IEnumerable<IdsType>> Ids = default,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<IEnumerable<double>> MultiOpacity = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<IEnumerable<Color>> SectionColors = default,
            Optional<StyleParam.Colorscale> SectionColorScale = default,
            Optional<bool> ShowSectionColorScale = default,
            Optional<bool> ReverseSectionColorScale = default,
            Optional<Color> SectionOutlineColor = default,
            Optional<double> SectionOutlineWidth = default,
            Optional<IEnumerable<double>> SectionOutlineMultiWidth = default,
            Optional<Line> SectionOutline = default,
            Optional<StyleParam.PatternShape> MarkerPatternShape = default,
            Optional<IEnumerable<StyleParam.PatternShape>> MultiMarkerPatternShape = default,
            Optional<Pattern> MarkerPattern = default, 
            Optional<Marker> Marker = default,
            Optional<StyleParam.TextInfo> TextInfo = default,
            Optional<StyleParam.BranchValues> BranchValues = default,
            Optional<string> Count = default,
            Optional<SunburstRoot> Root = default,
            Optional<SunburstLeaf> Leaf = default,
            Optional<string> Level = default,
            Optional<int> MaxDepth = default,
            Optional<int> Rotation = default,
            Optional<bool> Sort = default,
            Optional<bool> UseDefaults = default
        )
            where LabelsType : IConvertible
            where ParentsType : IConvertible
            where ValuesType : IConvertible
            where IdsType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.ChartDomain.Chart.Sunburst<LabelsType, ParentsType, ValuesType, IdsType, TextType>(
                    labels: labels,
                    parents: parents,
                    Values: Values.ToOption(),
                    Ids: Ids.ToOption(),
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    MultiOpacity: MultiOpacity.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    SectionColors: SectionColors.ToOption(),
                    SectionColorScale: SectionColorScale.ToOption(),
                    ShowSectionColorScale: ShowSectionColorScale.ToOption(),
                    ReverseSectionColorScale: ReverseSectionColorScale.ToOption(),
                    SectionOutlineColor: SectionOutlineColor.ToOption(),
                    SectionOutlineWidth: SectionOutlineWidth.ToOption(),
                    SectionOutlineMultiWidth: SectionOutlineMultiWidth.ToOption(),
                    SectionOutline: SectionOutline.ToOption(),
                    MarkerPatternShape: MarkerPatternShape.ToOption(),
                    MultiMarkerPatternShape: MultiMarkerPatternShape.ToOption(),
                    MarkerPattern: MarkerPattern.ToOption(),
                    Marker: Marker.ToOption(),
                    TextInfo: TextInfo.ToOption(),
                    BranchValues: BranchValues.ToOption(),
                    Count: Count.ToOption(),
                    Root: Root.ToOption(),
                    Leaf: Leaf.ToOption(),
                    Level: Level.ToOption(),
                    MaxDepth: MaxDepth.ToOption(),
                    Rotation: Rotation.ToOption(),
                    Sort: Sort.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Creates a treemap chart.
        /// Treemap charts visualize hierarchical data using nested rectangles.
        ///
        /// Same as Sunburst the hierarchy is defined by labels and parents attributes.
        /// Click on one sector to zoom in/out, which also displays a pathbar in the upper-left corner of your treemap. To zoom out you can use the path bar as well.
        /// </summary>
        /// <param name="labels">Sets the labels of each of the sectors.</param>
        /// <param name="parents">Sets the parent sectors for each of the sectors. Empty string items '' are understood to reference the root node in the hierarchy. If `ids` is filled, `parents` items are understood to be "ids" themselves. When `ids` is not set, plotly attempts to find matching items in `labels`, but beware they must be unique.</param>
        /// <param name="Values">Sets the values associated with each of the sectors.</param>
        /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="TextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="MultiTextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="SectionColors">Sets the colors associated with each section.</param>
        /// <param name="SectionColorScale">Sets the colorscale for the section values</param>
        /// <param name="ShowSectionColorScale">Whether or not to show the section colorbar</param>
        /// <param name="ReverseSectionColorScale">Whether or not to show the section colorscale</param>
        /// <param name="SectionOutlineColor">Sets the color of the section outline.</param>
        /// <param name="SectionOutlineWidth">Sets the width of the section outline.</param>
        /// <param name="SectionOutlineMultiWidth">Sets the width of each individual section outline.</param>
        /// <param name="SectionOutline">Sets the section outline (use this for more finegrained control than the other section outline-associated arguments).</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all sections</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each section</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the sections (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="TextInfo">Determines which trace information appear on the graph.</param>
        /// <param name="BranchValues">Determines how the items in `values` are summed. When set to "total", items in `values` are taken to be value of all its descendants. When set to "remainder", items in `values` corresponding to the root and the branches sectors are taken to be the extra part not part of the sum of the values at their leaves.</param>
        /// <param name="Count">Determines default for `values` when it is not provided, by inferring a 1 for each of the "leaves" and/or "branches", otherwise 0.</param>
        /// <param name="Tiling">Sets the tiling for this trace.</param>
        /// <param name="PathBar">Sets the path bar for this trace.</param>
        /// <param name="Root">Sets the styles for the root of this trace.</param>
        /// <param name="Level">Sets the level from which this trace hierarchy is rendered. Set `level` to `''` to start from the root node in the hierarchy. Must be an "id" if `ids` is filled in, otherwise plotly attempts to find a matching item in `labels`.</param>
        /// <param name="MaxDepth">Sets the number of rendered sectors from any given `level`. Set `maxdepth` to "-1" to render all the levels in the hierarchy.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Treemap<LabelsType, ParentsType, ValuesType, IdsType, TextType>(
            IEnumerable<LabelsType> labels,
            IEnumerable<ParentsType> parents,
            Optional<IEnumerable<ValuesType>> Values = default,
            Optional<IEnumerable<IdsType>> Ids = default,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<IEnumerable<double>> MultiOpacity = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<StyleParam.TextPosition> TextPosition = default,
            Optional<IEnumerable<StyleParam.TextPosition>> MultiTextPosition = default,
            Optional<IEnumerable<Color>> SectionColors = default,
            Optional<StyleParam.Colorscale> SectionColorScale = default,
            Optional<bool> ShowSectionColorScale = default,
            Optional<bool> ReverseSectionColorScale = default,
            Optional<Color> SectionOutlineColor = default,
            Optional<double> SectionOutlineWidth = default,
            Optional<IEnumerable<double>> SectionOutlineMultiWidth = default,
            Optional<Line> SectionOutline = default,
            Optional<StyleParam.PatternShape> MarkerPatternShape = default,
            Optional<IEnumerable<StyleParam.PatternShape>> MultiMarkerPatternShape = default,
            Optional<Pattern> MarkerPattern = default, 
            Optional<Marker> Marker = default,
            Optional<StyleParam.TextInfo> TextInfo = default,
            Optional<StyleParam.BranchValues> BranchValues = default,
            Optional<string> Count = default,
            Optional<TreemapTiling> Tiling = default,
            Optional<Pathbar> PathBar = default,
            Optional<TreemapRoot> Root = default,
            Optional<string> Level = default,
            Optional<int> MaxDepth = default,
            Optional<bool> UseDefaults = default
        )
            where LabelsType : IConvertible
            where ParentsType : IConvertible
            where ValuesType : IConvertible
            where IdsType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.ChartDomain.Chart.Treemap<LabelsType, ParentsType, ValuesType, IdsType, TextType>(
                    labels: labels,
                    parents: parents,
                    Values: Values.ToOption(),
                    Ids: Ids.ToOption(),
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    MultiOpacity: MultiOpacity.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    TextPosition: TextPosition.ToOption(),
                    MultiTextPosition: MultiTextPosition.ToOption(),
                    SectionColors: SectionColors.ToOption(),
                    SectionColorScale: SectionColorScale.ToOption(),
                    ShowSectionColorScale: ShowSectionColorScale.ToOption(),
                    ReverseSectionColorScale: ReverseSectionColorScale.ToOption(),
                    SectionOutlineColor: SectionOutlineColor.ToOption(),
                    SectionOutlineWidth: SectionOutlineWidth.ToOption(),
                    SectionOutlineMultiWidth: SectionOutlineMultiWidth.ToOption(),
                    SectionOutline: SectionOutline.ToOption(),
                    MarkerPatternShape: MarkerPatternShape.ToOption(),
                    MultiMarkerPatternShape: MultiMarkerPatternShape.ToOption(),
                    MarkerPattern: MarkerPattern.ToOption(),
                    Marker: Marker.ToOption(),
                    TextInfo: TextInfo.ToOption(),
                    BranchValues: BranchValues.ToOption(),
                    Count: Count.ToOption(),
                    Tiling: Tiling.ToOption(),
                    PathBar: PathBar.ToOption(),
                    Root: Root.ToOption(),
                    Level: Level.ToOption(),
                    MaxDepth: MaxDepth.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Creates a parallel coordinates plot.
        ///
        /// Parallel coordinates are a common way of visualizing and analyzing high-dimensional datasets.
        ///
        /// To show a set of points in an n-dimensional space, a backdrop is drawn consisting of n parallel lines, typically vertical and equally spaced. A point in n-dimensional space is represented as a polyline with vertices on the parallel axes; the position of the vertex on the i-th axis corresponds to the i-th coordinate of the point.
        ///
        /// This visualization is closely related to time series visualization, except that it is applied to data where the axes do not correspond to points in time, and therefore do not have a natural order. Therefore, different axis arrangements may be of interest.
        /// </summary>
        /// <param name="dimensions">the dimensions of the plot, containing both dimension backdrop information and the associated data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="LineColor">Sets the color of the lines that are connecting the datums on the dimensions</param>
        /// <param name="LineColorScale">Sets the colorscale of the lines that are connecting the datums on the dimensions</param>
        /// <param name="ShowLineColorScale">Whether or not to show the colorbar of the lines that are connecting the datums on the dimensions</param>
        /// <param name="ReverseLineColorScale">Whether or not to reverse the colorscale of the lines that are connecting the datums on the dimensions</param>
        /// <param name="Line">Sets the lines that are connecting the datums on the dimensions (use this for more finegrained control than the other line-associated arguments).</param>
        /// <param name="LabelAngle">Sets the angle of the labels with respect to the horizontal. For example, a `tickangle` of -90 draws the labels vertically. Tilted labels with "labelangle" may be positioned better inside margins when `labelposition` is set to "bottom".</param>
        /// <param name="LabelFont">Sets the label font of this trace.</param>
        /// <param name="LabelSide">Specifies the location of the `label`. "top" positions labels above, next to the title "bottom" positions labels below the graph Tilted labels with "labelangle" may be positioned better inside margins when `labelposition` is set to "bottom".</param>
        /// <param name="RangeFont">Sets the range font of this trace.</param>
        /// <param name="TickFont">Sets the tick font of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart ParallelCoord(
            IEnumerable<Dimension> dimensions,
            Optional<string> Name = default,
            Optional<Color> LineColor = default,
            Optional<StyleParam.Colorscale> LineColorScale = default,
            Optional<bool> ShowLineColorScale = default,
            Optional<bool> ReverseLineColorScale = default,
            Optional<Line> Line = default,
            Optional<int> LabelAngle = default,
            Optional<Font> LabelFont = default,
            Optional<StyleParam.Side> LabelSide = default,
            Optional<Font> RangeFont = default,
            Optional<Font> TickFont = default,
            Optional<bool> UseDefaults = default
        )
            =>
                Plotly.NET.ChartDomain.Chart.ParallelCoord(
                    dimensions: dimensions,
                    Name: Name.ToOption(),
                    LineColor: LineColor.ToOption(),
                    LineColorScale: LineColorScale.ToOption(),
                    ShowLineColorScale: ShowLineColorScale.ToOption(),
                    ReverseLineColorScale: ReverseLineColorScale.ToOption(),
                    Line: Line.ToOption(),
                    LabelAngle: LabelAngle.ToOption(),
                    LabelFont: LabelFont.ToOption(),
                    LabelSide: LabelSide.ToOption(),
                    RangeFont: RangeFont.ToOption(),
                    TickFont: TickFont.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Creates a parallel categories plot.
        ///
        /// The parallel categories diagram (also known as parallel sets or alluvial diagram) is a visualization of
        /// multi-dimensional categorical data sets. Each variable in the data set is represented by a column of rectangles,
        /// where each rectangle corresponds to a discrete value taken on by that variable.
        /// The relative heights of the rectangles reflect the relative frequency of occurrence of the corresponding value.
        /// </summary>
        /// <param name="dimensions">the dimensions of the plot, containing both dimension backdrop information and the associated data</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="Counts">The number of observations represented by each state. Defaults to 1 so that each state represents one observation</param>
        /// <param name="LineColor">Sets the color of the lines that are connecting the datums on the dimensions</param>
        /// <param name="LineShape">Sets the shape of the lines that are connecting the datums on the dimensions</param>
        /// <param name="LineColorScale">Sets the colorscale of the lines that are connecting the datums on the dimensions</param>
        /// <param name="ShowLineColorScale">Whether or not to show the colorbar of the lines that are connecting the datums on the dimensions</param>
        /// <param name="ReverseLineColorScale">Whether or not to reverse the colorscale of the lines that are connecting the datums on the dimensions</param>
        /// <param name="Line">Sets the lines that are connecting the datums on the dimensions (use this for more finegrained control than the other line-associated arguments).</param>
        /// <param name="Arrangement">Sets the drag interaction mode for categories and dimensions. If `perpendicular`, the categories can only move along a line perpendicular to the paths. If `freeform`, the categories can freely move on the plane. If `fixed`, the categories and dimensions are stationary.</param>
        /// <param name="BundleColors">Sort paths so that like colors are bundled together within each category.</param>
        /// <param name="SortPaths">Sets the path sorting algorithm. If `forward`, sort paths based on dimension categories from left to right. If `backward`, sort paths based on dimensions categories from right to left.</param>
        /// <param name="LabelFont">Sets the label font of this trace.</param>
        /// <param name="TickFont">Sets the tick font of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart ParallelCategories(
            IEnumerable<Dimension> dimensions, 
            Optional<string> Name = default, 
            Optional<int> Counts = default, 
            Optional<Color> LineColor = default, 
            Optional<StyleParam.Shape> LineShape = default, 
            Optional<StyleParam.Colorscale> LineColorScale = default, 
            Optional<bool> ShowLineColorScale = default, 
            Optional<bool> ReverseLineColorScale = default, 
            Optional<Line> Line = default, 
            Optional<StyleParam.CategoryArrangement> Arrangement = default, 
            Optional<bool> BundleColors = default, 
            Optional<StyleParam.SortAlgorithm> SortPaths = default, 
            Optional<Font> LabelFont = default, 
            Optional<Font> TickFont = default, 
            Optional<bool> UseDefaults = default
        )
            =>
                Plotly.NET.ChartDomain.Chart.ParallelCategories(
                    dimensions: dimensions,
                    Name: Name.ToOption(),
                    Counts: Counts.ToOption(),
                    LineColor: LineColor.ToOption(),
                    LineShape: LineShape.ToOption(),
                    LineColorScale: LineColorScale.ToOption(),
                    ShowLineColorScale: ShowLineColorScale.ToOption(),
                    ReverseLineColorScale: ReverseLineColorScale.ToOption(),
                    Line: Line.ToOption(),
                    Arrangement: Arrangement.ToOption(),
                    BundleColors: BundleColors.ToOption(),
                    SortPaths: SortPaths.ToOption(),
                    LabelFont: LabelFont.ToOption(),
                    TickFont: TickFont.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Creates a sankey diagram.
        ///
        /// A Sankey diagram is a flow diagram, in which the width of arrows is proportional to the flow quantity.
        ///
        /// Sankey diagrams visualize the contributions to a flow by defining source to represent the source node, target for the target node, value to set the flow volume, and label that shows the node name.
        /// </summary>
        /// <param name="nodes">Sets the nodes of the Sankey plot.</param>
        /// <param name="links">Sets the links between nodes of the Sankey plot.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="Ids">Assigns id labels to each datum.</param>
        /// <param name="Orientation">Sets the orientation of the Sankey diagram.</param>
        /// <param name="TextFont">Sets the text font of this trace.</param>
        /// <param name="Arrangement">If value is `snap` (the default), the node arrangement is assisted by automatic snapping of elements to preserve space between nodes specified via `nodepad`. If value is `perpendicular`, the nodes can only move along a line perpendicular to the flow. If value is `freeform`, the nodes can freely move on the plane. If value is `fixed`, the nodes are stationary.</param>
        /// <param name="ValueFormat">Sets the value formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.</param>
        /// <param name="ValueSuffix">Adds a unit to follow the value in the hover tooltip. Add a space if a separation is necessary from the value.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Sankey<IdsType>(
            SankeyNodes nodes,
            SankeyLinks links,
            Optional<string> Name = default,
            Optional<IEnumerable<IdsType>> Ids = default,
            Optional<StyleParam.Orientation> Orientation = default,
            Optional<Font> TextFont = default,
            Optional<StyleParam.CategoryArrangement> Arrangement = default,
            Optional<string> ValueFormat = default,
            Optional<string> ValueSuffix = default,
            Optional<bool> UseDefaults = default
        )
            where IdsType : IConvertible
            =>
                Plotly.NET.ChartDomain.Chart.Sankey<IdsType>(
                    nodes: nodes,
                    links: links,
                    Name: Name.ToOption(),
                    Ids: Ids.ToOption(),
                    Orientation: Orientation.ToOption(),
                    TextFont: TextFont.ToOption(),
                    Arrangement: Arrangement.ToOption(),
                    ValueFormat: ValueFormat.ToOption(),
                    ValueSuffix: ValueSuffix.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Creates a table.
        ///
        /// The data are arranged in a grid of rows and columns. Most styling can be specified for columns, rows or individual cells. Table is using a row-major order by default, ie. the grid is represented as a vector of row vectors.
        /// </summary>
        /// <param name="header">Sets the header of the table</param>
        /// <param name="cells">Sets the cells of the table</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ColumnOrder">Specifies the rendered order of the data columns; for example, a value `2` at position `0` means that column index `0` in the data will be rendered as the third column, as columns have an index base of zero.</param>
        /// <param name="ColumnWidth">The width of columns expressed as a ratio. Columns fill the available width in proportion of their specified column widths.</param>
        /// <param name="MultiColumnWidth">The width of columns expressed as a ratio. Columns fill the available width in proportion of their specified column widths.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Table(
            TableCells header, 
            TableCells cells, 
            Optional<string> Name = default, 
            Optional<IEnumerable<int>> ColumnOrder = default, 
            Optional<double> ColumnWidth = default, 
            Optional<IEnumerable<double>> MultiColumnWidth = default, 
            Optional<bool> UseDefaults = default
        )
            =>
                Plotly.NET.ChartDomain.Chart.Table(
                   header: header,
                   cells: cells,
                   Name: Name.ToOption(),
                   ColumnOrder: ColumnOrder.ToOption(),
                   ColumnWidth: ColumnWidth.ToOption(),
                   MultiColumnWidth: MultiColumnWidth.ToOption(),
                   UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Creates an Indicator chart.
        ///
        /// An indicator is used to visualize a single `value` along with some contextual information such as `steps` or a `threshold`, using a combination of three visual elements: a number, a delta, and/or a gauge.
        /// Deltas are taken with respect to a `reference`.
        /// Gauges can be either angular or bullet (aka linear) gauges.
        /// </summary>
        /// <param name="value">Sets the number to be displayed.</param>
        /// <param name="mode">Determines how the value is displayed on the graph. `number` displays the value numerically in text. `delta` displays the difference to a reference value in text. Finally, `gauge` displays the value graphically on an axis.</param>
        /// <param name="Range">Sets the Range of the Gauge axis</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="Title">Sets the title of this trace.</param>
        /// <param name="Domain">Sets the domain of this trace.</param>
        /// <param name="Align">Sets the horizontal alignment of the `text` within the box. Note that this attribute has no effect if an angular gauge is displayed: in this case, it is always centered</param>
        /// <param name="DeltaReference"></param>
        /// <param name="Delta">Sets how the delta to the delta reference is displayed</param>
        /// <param name="Number">Sets the styles of the displayed number</param>
        /// <param name="GaugeShape">Sets the shape of the gauge</param>
        /// <param name="Gauge">Sets the styles of the gauge</param>
        /// <param name="ShowGaugeAxis">Whether or not to show the gauge axis</param>
        /// <param name="GaugeAxis">Sets the gauge axis</param>
        /// <param name="UseDefaults"></param>
        public static GenericChart Indicator<ValueType>(
            ValueType value,
            StyleParam.IndicatorMode mode,
            Optional<StyleParam.Range> Range = default,
            Optional<string> Name = default,
            Optional<string> Title = default,
            Optional<Domain> Domain = default,
            Optional<StyleParam.IndicatorAlignment> Align = default,
            Optional<ValueType> DeltaReference = default,
            Optional<IndicatorDelta> Delta = default,
            Optional<IndicatorNumber> Number = default,
            Optional<StyleParam.IndicatorGaugeShape> GaugeShape = default,
            Optional<IndicatorGauge> Gauge = default,
            Optional<bool> ShowGaugeAxis = default,
            Optional<LinearAxis> GaugeAxis = default,
            Optional<bool> UseDefaults = default
        )
            where ValueType : IConvertible
            =>
                Plotly.NET.ChartDomain.Chart.Indicator<ValueType>(
                    value: value,
                    mode: mode,
                    Range: Range.ToOption(),
                    Name: Name.ToOption(),
                    Title: Title.ToOption(),
                    Domain: Domain.ToOption(),
                    Align: Align.ToOption(),
                    DeltaReference: DeltaReference.ToOption(),
                    Delta: Delta.ToOption(),
                    Number: Number.ToOption(),
                    GaugeShape: GaugeShape.ToOption(),
                    Gauge: Gauge.ToOption(),
                    ShowGaugeAxis: ShowGaugeAxis.ToOption(),
                    GaugeAxis: GaugeAxis.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Creates an icicle chart.
        ///
        /// Icicle charts visualize hierarchal data from leaves (and/or outer branches) towards root with rectangles.
        /// The icicle sectors are determined by the entries in "labels" or "ids" and in "parents".
        /// </summary>
        /// <param name="labels">Sets the labels of each of the sectors.</param>
        /// <param name="parents">Sets the parent sectors for each of the sectors. Empty string items '' are understood to reference the root node in the hierarchy. If `ids` is filled, `parents` items are understood to be "ids" themselves. When `ids` is not set, plotly attempts to find matching items in `labels`, but beware they must be unique.</param>
        /// <param name="Values">Sets the values associated with each of the sectors.</param>
        /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
        /// <param name="Text">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="MultiText">Sets text elements associated with each (x,y) pair. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="TextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="MultiTextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="SectionColors">Sets the colors associated with each section.</param>
        /// <param name="SectionColorScale">Sets the colorscale for the section values</param>
        /// <param name="ShowSectionColorScale">Whether or not to show the section colorbar</param>
        /// <param name="ReverseSectionColorScale">Whether or not to show the section colorscale</param>
        /// <param name="SectionOutlineColor">Sets the color of the section outline.</param>
        /// <param name="SectionOutlineWidth">Sets the width of the section outline.</param>
        /// <param name="SectionOutlineMultiWidth">Sets the width of each individual section outline.</param>
        /// <param name="SectionOutline">Sets the section outline (use this for more finegrained control than the other section outline-associated arguments).</param>
        /// <param name="MarkerPatternShape">Sets a pattern shape for all sections</param>
        /// <param name="MultiMarkerPatternShape">Sets an individual pattern shape for each section</param>
        /// <param name="MarkerPattern">Sets the marker pattern (use this for more finegrained control than the other pattern-associated arguments).</param>
        /// <param name="Marker">Sets the marker for the sections (use this for more finegrained control than the other marker-associated arguments).</param>
        /// <param name="BranchValues">Determines how the items in `values` are summed. When set to "total", items in `values` are taken to be value of all its descendants. When set to "remainder", items in `values` corresponding to the root and the branches sectors are taken to be the extra part not part of the sum of the values at their leaves.</param>
        /// <param name="Count">Determines default for `values` when it is not provided, by inferring a 1 for each of the "leaves" and/or "branches", otherwise 0.</param>
        /// <param name="TilingOrientation">Sets the orientation of the tiling.</param>
        /// <param name="TilingFlip">Sets the flip of the tiling: Determines if the positions obtained from solver are flipped on each axis.</param>
        /// <param name="Tiling">Sets the styles for the icicle tiling</param>
        /// <param name="PathBarEdgeShape">Sets the edge shape of the pathbar.</param>
        /// <param name="PathBar">Sets the pathbar</param>
        /// <param name="TextInfo">Determines which trace information appear on the graph.</param>
        /// <param name="Root">Sets the styles for the root of this trace.</param>
        /// <param name="Level">Sets the level from which this trace hierarchy is rendered. Set `level` to `''` to start from the root node in the hierarchy. Must be an "id" if `ids` is filled in, otherwise plotly attempts to find a matching item in `labels`.</param>
        /// <param name="MaxDepth">Sets the number of rendered sectors from any given `level`. Set `maxdepth` to "-1" to render all the levels in the hierarchy.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Icicle<LabelsType, ParentsType, ValuesType, IdsType, TextType>(
            IEnumerable<LabelsType> labels,
            IEnumerable<ParentsType> parents,
            Optional<IEnumerable<ValuesType>> Values = default,
            Optional<IEnumerable<IdsType>> Ids = default,
            Optional<string> Name = default,
            Optional<double> Opacity = default,
            Optional<IEnumerable<double>> MultiOpacity = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<StyleParam.TextPosition> TextPosition = default,
            Optional<IEnumerable<StyleParam.TextPosition>> MultiTextPosition = default,
            Optional<IEnumerable<Color>> SectionColors = default,
            Optional<StyleParam.Colorscale> SectionColorScale = default,
            Optional<bool> ShowSectionColorScale = default,
            Optional<bool> ReverseSectionColorScale = default,
            Optional<Color> SectionOutlineColor = default,
            Optional<double> SectionOutlineWidth = default,
            Optional<IEnumerable<double>> SectionOutlineMultiWidth = default,
            Optional<Line> SectionOutline = default,
            Optional<StyleParam.PatternShape> MarkerPatternShape = default,
            Optional<IEnumerable<StyleParam.PatternShape>> MultiMarkerPatternShape = default,
            Optional<Pattern> MarkerPattern = default, 
            Optional<Marker> Marker = default,
            Optional<StyleParam.TextInfo> TextInfo = default,
            Optional<StyleParam.BranchValues> BranchValues = default,
            Optional<StyleParam.IcicleCount> Count = default,
            Optional<StyleParam.Orientation> TilingOrientation = default,
            Optional<StyleParam.TilingFlip> TilingFlip = default,
            Optional<IcicleTiling> Tiling = default,
            Optional<StyleParam.PathbarEdgeShape> PathBarEdgeShape = default,
            Optional<Pathbar> PathBar = default,
            Optional<IcicleRoot> Root = default,
            Optional<string> Level = default,
            Optional<int> MaxDepth = default,
            Optional<bool> UseDefaults = default
        )
            where LabelsType : IConvertible
            where ParentsType : IConvertible
            where ValuesType : IConvertible
            where IdsType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.ChartDomain.Chart.Icicle<LabelsType, ParentsType, ValuesType, IdsType, TextType>(
                    labels: labels,
                    parents: parents,
                    Values: Values.ToOption(),
                    Ids: Ids.ToOption(),
                    Name: Name.ToOption(),
                    Opacity: Opacity.ToOption(),
                    MultiOpacity: MultiOpacity.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    TextPosition: TextPosition.ToOption(),
                    MultiTextPosition: MultiTextPosition.ToOption(),
                    SectionColors: SectionColors.ToOption(),
                    SectionColorScale: SectionColorScale.ToOption(),
                    ShowSectionColorScale: ShowSectionColorScale.ToOption(),
                    ReverseSectionColorScale: ReverseSectionColorScale.ToOption(),
                    SectionOutlineColor: SectionOutlineColor.ToOption(),
                    SectionOutlineWidth: SectionOutlineWidth.ToOption(),
                    SectionOutlineMultiWidth: SectionOutlineMultiWidth.ToOption(),
                    SectionOutline: SectionOutline.ToOption(),
                    MarkerPatternShape: MarkerPatternShape.ToOption(),
                    MultiMarkerPatternShape: MultiMarkerPatternShape.ToOption(),
                    MarkerPattern: MarkerPattern.ToOption(),
                    Marker: Marker.ToOption(),
                    TextInfo: TextInfo.ToOption(),
                    BranchValues: BranchValues.ToOption(),
                    Count: Count.ToOption(),
                    TilingOrientation: TilingOrientation.ToOption(),
                    TilingFlip: TilingFlip.ToOption(),
                    Tiling: Tiling.ToOption(),
                    PathBarEdgeShape: PathBarEdgeShape.ToOption(),
                    PathBar: PathBar.ToOption(),
                    Root: Root.ToOption(),
                    Level: Level.ToOption(),
                    MaxDepth: MaxDepth.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );
    }
}
