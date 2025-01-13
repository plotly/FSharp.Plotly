namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open DynamicObj
open System
open System.IO

open StyleParam
open System.Runtime.InteropServices
open System.Runtime.CompilerServices

[<AutoOpen>]
module ChartDomain =

    [<Extension>]
    type Chart =

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
        [<Extension>]
        static member Pie
            (
                values: seq<#IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Labels: seq<#IConvertible>,
                ?Pull: float,
                ?MultiPull: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?SectionColors: seq<Color>,
                ?SectionOutlineColor: Color,
                ?SectionOutlineWidth: float,
                ?SectionOutlineMultiWidth: seq<float>,
                ?SectionOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?TextInfo: StyleParam.TextInfo,
                ?Direction: StyleParam.Direction,
                ?Hole: float,
                ?Rotation: float,
                ?Sort: bool,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let outline =
                SectionOutline
                |> Option.defaultValue (Line.init ())
                |> Line.style (
                    ?Color = SectionOutlineColor,
                    ?Width = SectionOutlineWidth,
                    ?MultiWidth = SectionOutlineMultiWidth
                )

            let pattern =
                MarkerPattern
                |> Option.defaultValue (TraceObjects.Pattern.init ())
                |> TraceObjects.Pattern.style (?Shape = MarkerPatternShape, ?MultiShape = MultiMarkerPatternShape)

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (?Colors = SectionColors, ?MultiOpacity = MultiOpacity, Outline = outline, Pattern = pattern)


            TraceDomain.initPie (
                TraceDomainStyle.Pie(
                    Values = values,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Labels = Labels,
                    ?Pull = Pull,
                    ?MultiPull = MultiPull,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    Marker = marker,
                    ?TextInfo = TextInfo,
                    ?Direction = Direction,
                    ?Hole = Hole,
                    ?Rotation = Rotation,
                    ?Sort = Sort

                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a pie chart.
        ///
        /// A pie chart (or a circle chart) is a circular statistical graphic, which is divided into slices to illustrate numerical proportion.
        /// In a pie chart, the arc length of each slice (and consequently its central angle and area), is proportional to the quantity it represents.
        /// </summary>
        /// <param name="valuesLabels">Sets the values and labels of the sectors. If label entries are duplicated, the associated values are summed.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
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
        /// <param name="Hole">Sets the fraction of the radius to cut out of the pie. Use this to make a donut chart.</param>
        /// <param name="Rotation">Instead of the first slice starting at 12 o'clock, rotate to some other angle.</param>
        /// <param name="Sort">Determines whether or not the sectors are reordered from largest to smallest.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Pie
            (
                valuesLabels: seq<#IConvertible * #IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Pull: float,
                ?MultiPull: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?SectionColors: seq<Color>,
                ?SectionOutlineColor: Color,
                ?SectionOutlineWidth: float,
                ?SectionOutlineMultiWidth: seq<float>,
                ?SectionOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?TextInfo: StyleParam.TextInfo,
                ?Direction: StyleParam.Direction,
                ?Hole: float,
                ?Rotation: float,
                ?Sort: bool,
                ?UseDefaults: bool
            ) =

            let values, labels = Seq.unzip valuesLabels

            Chart.Pie(
                values,
                Labels = labels,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Pull = Pull,
                ?MultiPull = MultiPull,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?SectionColors = SectionColors,
                ?SectionOutlineColor = SectionOutlineColor,
                ?SectionOutlineWidth = SectionOutlineWidth,
                ?SectionOutlineMultiWidth = SectionOutlineMultiWidth,
                ?SectionOutline = SectionOutline,
                ?MarkerPatternShape = MarkerPatternShape, 
                ?MultiMarkerPatternShape = MultiMarkerPatternShape,
                ?MarkerPattern = MarkerPattern,
                ?Marker = Marker,
                ?TextInfo = TextInfo,
                ?Direction = Direction,
                ?Hole = Hole,
                ?Rotation = Rotation,
                ?Sort = Sort,
                ?UseDefaults = UseDefaults
            )


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
        [<Extension>]
        static member Doughnut
            (
                values: seq<#IConvertible>,
                ?Name: string,
                ?Hole: float,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Labels: seq<#IConvertible>,
                ?Pull: float,
                ?MultiPull: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?SectionColors: seq<Color>,
                ?SectionOutlineColor: Color,
                ?SectionOutlineWidth: float,
                ?SectionOutlineMultiWidth: seq<float>,
                ?SectionOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?TextInfo: StyleParam.TextInfo,
                ?Direction: StyleParam.Direction,
                ?Rotation: float,
                ?Sort: bool,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let hole = Option.defaultValue 0.4 Hole

            Chart.Pie(
                values,
                Hole = hole,
                ?Labels = Labels,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?MultiPull = MultiPull,
                ?Pull = Pull,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?SectionColors = SectionColors,
                ?SectionOutlineColor = SectionOutlineColor,
                ?SectionOutlineWidth = SectionOutlineWidth,
                ?SectionOutlineMultiWidth = SectionOutlineMultiWidth,
                ?SectionOutline = SectionOutline,
                ?MarkerPatternShape = MarkerPatternShape, 
                ?MultiMarkerPatternShape = MultiMarkerPatternShape,
                ?MarkerPattern = MarkerPattern,
                ?Marker = Marker,
                ?TextInfo = TextInfo,
                ?Direction = Direction,
                ?Rotation = Rotation,
                ?Sort = Sort,
                ?UseDefaults = UseDefaults
            )


        /// <summary>
        /// Creates a doughnut chart.
        ///
        /// A doughnut chart is a variation of the pie chart that has a fraction cut from the center of the slices.
        /// </summary>
        /// <param name="valuesLabels">Sets the values and labels of the sectors. If label entries are duplicated, the associated values are summed.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="Hole">Sets the fraction of the radius to cut out of the pie. Use this to make a donut chart.</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
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
        [<Extension>]
        static member Doughnut
            (
                valuesLabels: seq<#IConvertible * #IConvertible>,
                ?Hole: float,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Pull: float,
                ?MultiPull: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?SectionColors: seq<Color>,
                ?SectionOutlineColor: Color,
                ?SectionOutlineWidth: float,
                ?SectionOutlineMultiWidth: seq<float>,
                ?SectionOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?TextInfo: StyleParam.TextInfo,
                ?Direction: StyleParam.Direction,
                ?Rotation: float,
                ?Sort: bool,
                ?UseDefaults: bool
            ) =
            let values, labels = Seq.unzip valuesLabels

            Chart.Doughnut(
                values,
                Labels = labels,
                ?Hole = Hole,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Pull = Pull,
                ?MultiPull = MultiPull,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?SectionColors = SectionColors,
                ?SectionOutlineColor = SectionOutlineColor,
                ?SectionOutlineWidth = SectionOutlineWidth,
                ?SectionOutlineMultiWidth = SectionOutlineMultiWidth,
                ?SectionOutline = SectionOutline,
                ?MarkerPatternShape = MarkerPatternShape, 
                ?MultiMarkerPatternShape = MultiMarkerPatternShape,
                ?MarkerPattern = MarkerPattern,
                ?Marker = Marker,
                ?TextInfo = TextInfo,
                ?Direction = Direction,
                ?Rotation = Rotation,
                ?Sort = Sort,
                ?UseDefaults = UseDefaults
            )



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
        [<Extension>]
        static member FunnelArea
            (
                values: seq<#IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Labels: seq<#IConvertible>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?SectionColors: seq<Color>,
                ?SectionOutlineColor: Color,
                ?SectionOutlineWidth: float,
                ?SectionOutlineMultiWidth: seq<float>,
                ?SectionOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?TextInfo: StyleParam.TextInfo,
                ?AspectRatio: float,
                ?BaseRatio: float,
                ?UseDefaults: bool
            ) =


            let useDefaults =
                defaultArg UseDefaults true

            let outline =
                SectionOutline
                |> Option.defaultValue (Line.init ())
                |> Line.style (
                    ?Color = SectionOutlineColor,
                    ?Width = SectionOutlineWidth,
                    ?MultiWidth = SectionOutlineMultiWidth
                )

            let pattern =
                MarkerPattern
                |> Option.defaultValue (TraceObjects.Pattern.init ())
                |> TraceObjects.Pattern.style (?Shape = MarkerPatternShape, ?MultiShape = MultiMarkerPatternShape)

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (?Colors = SectionColors, ?MultiOpacity = MultiOpacity, Outline = outline, Pattern = pattern)


            TraceDomain.initFunnelArea (
                TraceDomainStyle.FunnelArea(
                    Values = values,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Labels = Labels,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    Marker = marker,
                    ?TextInfo = TextInfo,
                    ?AspectRatio = AspectRatio,
                    ?BaseRatio = BaseRatio
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a FunnelArea chart.
        ///
        /// FunnelArea charts visualize stages in a process using area-encoded trapezoids, which can be used to show data in a part-to-whole representation similar to a piechart,
        /// wherein each item appears in a single stage. See also the "funnel" chart for a different approach to visualizing funnel data.
        /// </summary>
        /// <param name="valuesLabels">Sets the values and labels of the sectors. If label entries are duplicated, the associated values are summed.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="MultiOpacity">Sets the opactity of individual datum markers</param>
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
        [<Extension>]
        static member FunnelArea
            (
                valuesLabels: seq<#IConvertible * #IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?SectionColors: seq<Color>,
                ?SectionOutlineColor: Color,
                ?SectionOutlineWidth: float,
                ?SectionOutlineMultiWidth: seq<float>,
                ?SectionOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?TextInfo: StyleParam.TextInfo,
                ?AspectRatio: float,
                ?BaseRatio: float,
                ?UseDefaults: bool
            ) =
            let values, labels = Seq.unzip valuesLabels

            Chart.FunnelArea(
                values,
                Labels = labels,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?SectionColors = SectionColors,
                ?SectionOutlineColor = SectionOutlineColor,
                ?SectionOutlineWidth = SectionOutlineWidth,
                ?SectionOutlineMultiWidth = SectionOutlineMultiWidth,
                ?SectionOutline = SectionOutline,
                ?MarkerPatternShape = MarkerPatternShape, 
                ?MultiMarkerPatternShape = MultiMarkerPatternShape,
                ?MarkerPattern = MarkerPattern,
                ?Marker = Marker,
                ?TextInfo = TextInfo,
                ?AspectRatio = AspectRatio,
                ?BaseRatio = BaseRatio,
                ?UseDefaults = UseDefaults
            )


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
        [<Extension>]
        static member Sunburst
            (
                labels: seq<#IConvertible>,
                parents: seq<#IConvertible>,
                ?Values: seq<#IConvertible>,
                ?Ids: seq<#IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?SectionColors: seq<Color>,
                ?SectionColorScale: StyleParam.Colorscale,
                ?ShowSectionColorScale: bool,
                ?ReverseSectionColorScale: bool,
                ?SectionOutlineColor: Color,
                ?SectionOutlineWidth: float,
                ?SectionOutlineMultiWidth: seq<float>,
                ?SectionOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?TextInfo: StyleParam.TextInfo,
                ?BranchValues: StyleParam.BranchValues,
                ?Count: string,
                ?Root: SunburstRoot,
                ?Leaf: SunburstLeaf,
                ?Level: string,
                ?MaxDepth: int,
                ?Rotation: int,
                ?Sort: bool,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let outline =
                SectionOutline
                |> Option.defaultValue (Line.init ())
                |> Line.style (
                    ?Color = SectionOutlineColor,
                    ?Width = SectionOutlineWidth,
                    ?MultiWidth = SectionOutlineMultiWidth
                )

            let pattern =
                MarkerPattern
                |> Option.defaultValue (TraceObjects.Pattern.init ())
                |> TraceObjects.Pattern.style (?Shape = MarkerPatternShape, ?MultiShape = MultiMarkerPatternShape)

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (
                    ?MultiOpacity = MultiOpacity,
                    ?Colors = SectionColors,
                    ?Colorscale = SectionColorScale,
                    ?ShowScale = ShowSectionColorScale,
                    ?ReverseScale = ReverseSectionColorScale,
                    Outline = outline,
                    Pattern = pattern
                )

            TraceDomain.initSunburst (
                TraceDomainStyle.Sunburst(
                    Labels = labels,
                    Parents = parents,
                    Marker = marker,
                    ?Values = Values,
                    ?Ids = Ids,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextInfo = TextInfo,
                    ?Rotation = Rotation,
                    ?Sort = Sort,
                    ?BranchValues = BranchValues,
                    ?Count = Count,
                    ?Root = Root,
                    ?Leaf = Leaf,
                    ?Level = Level,
                    ?MaxDepth = MaxDepth

                )
            )
            |> GenericChart.ofTraceObject useDefaults



        /// <summary>
        /// Creates a sunburst chart, which visualizes hierarchical data spanning outward radially from root to leaves.
        ///
        /// The hierarchy is defined by labels and parents attributes. The root starts from the center and children are added to the outer rings.
        /// </summary>
        /// <param name="labelsparents">Sets the labels of each of the sectors and their respective parent sector.</param>
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
        [<Extension>]
        static member Sunburst
            (
                labelsparents: seq<#IConvertible * #IConvertible>,
                ?Values: seq<#IConvertible>,
                ?Ids: seq<#IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?SectionColors: seq<Color>,
                ?SectionColorScale: StyleParam.Colorscale,
                ?ShowSectionColorScale: bool,
                ?ReverseSectionColorScale: bool,
                ?SectionOutlineColor: Color,
                ?SectionOutlineWidth: float,
                ?SectionOutlineMultiWidth: seq<float>,
                ?SectionOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?TextInfo: StyleParam.TextInfo,
                ?BranchValues: StyleParam.BranchValues,
                ?Count: string,
                ?Root: SunburstRoot,
                ?Leaf: SunburstLeaf,
                ?Level: string,
                ?MaxDepth: int,
                ?Rotation: int,
                ?Sort: bool,
                ?UseDefaults: bool
            ) =

            let labels, parents =
                Seq.unzip labelsparents

            Chart.Sunburst(
                labels,
                parents,
                ?Values = Values,
                ?Ids = Ids,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?SectionColors = SectionColors,
                ?SectionColorScale = SectionColorScale,
                ?ShowSectionColorScale = ShowSectionColorScale,
                ?ReverseSectionColorScale = ReverseSectionColorScale,
                ?SectionOutlineColor = SectionOutlineColor,
                ?SectionOutlineWidth = SectionOutlineWidth,
                ?SectionOutlineMultiWidth = SectionOutlineMultiWidth,
                ?SectionOutline = SectionOutline,
                ?MarkerPatternShape = MarkerPatternShape, 
                ?MultiMarkerPatternShape = MultiMarkerPatternShape,
                ?MarkerPattern = MarkerPattern,
                ?Marker = Marker,
                ?TextInfo = TextInfo,
                ?BranchValues = BranchValues,
                ?Count = Count,
                ?Root = Root,
                ?Leaf = Leaf,
                ?Level = Level,
                ?MaxDepth = MaxDepth,
                ?Rotation = Rotation,
                ?Sort = Sort,
                ?UseDefaults = UseDefaults
            )


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
        [<Extension>]
        static member Treemap
            (
                labels: seq<#IConvertible>,
                parents: seq<#IConvertible>,
                ?Values: seq<#IConvertible>,
                ?Ids: seq<#IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?SectionColors: seq<Color>,
                ?SectionColorScale: StyleParam.Colorscale,
                ?ShowSectionColorScale: bool,
                ?ReverseSectionColorScale: bool,
                ?SectionOutlineColor: Color,
                ?SectionOutlineWidth: float,
                ?SectionOutlineMultiWidth: seq<float>,
                ?SectionOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?TextInfo: StyleParam.TextInfo,
                ?BranchValues: StyleParam.BranchValues,
                ?Count: string,
                ?Tiling: TreemapTiling,
                ?PathBar: Pathbar,
                ?Root: TreemapRoot,
                ?Level: string,
                ?MaxDepth: int,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let outline =
                SectionOutline
                |> Option.defaultValue (Line.init ())
                |> Line.style (
                    ?Color = SectionOutlineColor,
                    ?Width = SectionOutlineWidth,
                    ?MultiWidth = SectionOutlineMultiWidth
                )

            let pattern =
                MarkerPattern
                |> Option.defaultValue (TraceObjects.Pattern.init ())
                |> TraceObjects.Pattern.style (?Shape = MarkerPatternShape, ?MultiShape = MultiMarkerPatternShape)

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (
                    ?MultiOpacity = MultiOpacity,
                    ?Colors = SectionColors,
                    ?Colorscale = SectionColorScale,
                    ?ShowScale = ShowSectionColorScale,
                    ?ReverseScale = ReverseSectionColorScale,
                    Outline = outline,
                    Pattern = pattern
                )

            TraceDomain.initTreemap (
                TraceDomainStyle.Treemap(
                    Labels = labels,
                    Parents = parents,
                    Marker = marker,
                    ?Values = Values,
                    ?Ids = Ids,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?TextInfo = TextInfo,
                    ?BranchValues = BranchValues,
                    ?Count = Count,
                    ?Tiling = Tiling,
                    ?PathBar = PathBar,
                    ?Root = Root,
                    ?Level = Level,
                    ?MaxDepth = MaxDepth
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a treemap chart.
        /// Treemap charts visualize hierarchical data using nested rectangles.
        ///
        /// Same as Sunburst the hierarchy is defined by labels and parents attributes.
        /// Click on one sector to zoom in/out, which also displays a pathbar in the upper-left corner of your treemap. To zoom out you can use the path bar as well.
        /// </summary>
        /// <param name="labelsparents">Sets the labels of each of the sectors and their respective parent sector.</param>
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
        [<Extension>]
        static member Treemap
            (
                labelsparents: seq<#IConvertible * #IConvertible>,
                ?Values: seq<#IConvertible>,
                ?Ids: seq<#IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?SectionColors: seq<Color>,
                ?SectionColorScale: StyleParam.Colorscale,
                ?ShowSectionColorScale: bool,
                ?ReverseSectionColorScale: bool,
                ?SectionOutlineColor: Color,
                ?SectionOutlineWidth: float,
                ?SectionOutlineMultiWidth: seq<float>,
                ?SectionOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?TextInfo: StyleParam.TextInfo,
                ?BranchValues: StyleParam.BranchValues,
                ?Count: string,
                ?Tiling: TreemapTiling,
                ?PathBar: Pathbar,
                ?Root: TreemapRoot,
                ?Level: string,
                ?MaxDepth: int,
                ?UseDefaults: bool
            ) =

            let labels, parents =
                Seq.unzip labelsparents

            Chart.Treemap(
                labels,
                parents,
                ?Values = Values,
                ?Ids = Ids,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?SectionColors = SectionColors,
                ?SectionColorScale = SectionColorScale,
                ?ShowSectionColorScale = ShowSectionColorScale,
                ?ReverseSectionColorScale = ReverseSectionColorScale,
                ?SectionOutlineColor = SectionOutlineColor,
                ?SectionOutlineWidth = SectionOutlineWidth,
                ?SectionOutlineMultiWidth = SectionOutlineMultiWidth,
                ?SectionOutline = SectionOutline,
                ?MarkerPatternShape = MarkerPatternShape, 
                ?MultiMarkerPatternShape = MultiMarkerPatternShape,
                ?MarkerPattern = MarkerPattern,
                ?Marker = Marker,
                ?TextInfo = TextInfo,
                ?BranchValues = BranchValues,
                ?Count = Count,
                ?Tiling = Tiling,
                ?PathBar = PathBar,
                ?Root = Root,
                ?Level = Level,
                ?MaxDepth = MaxDepth,
                ?UseDefaults = UseDefaults
            )


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
        [<Extension>]
        static member ParallelCoord
            (
                dimensions: seq<Dimension>,
                ?Name: string,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?ShowLineColorScale: bool,
                ?ReverseLineColorScale: bool,
                ?Line: Line,
                ?LabelAngle: int,
                ?LabelFont: Font,
                ?LabelSide: StyleParam.Side,
                ?RangeFont: Font,
                ?TickFont: Font,
                ?UseDefaults: bool
            ) =
            let useDefaults =
                defaultArg UseDefaults true

            let line =
                Line
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    ?Color = LineColor,
                    ?Colorscale = LineColorScale,
                    ?ShowScale = ShowLineColorScale,
                    ?ReverseScale = ReverseLineColorScale
                )

            TraceDomain.initParallelCoord (
                TraceDomainStyle.ParallelCoord(
                    Dimensions = dimensions,
                    Line = line,
                    ?Name = Name,
                    ?LabelAngle = LabelAngle,
                    ?LabelFont = LabelFont,
                    ?LabelSide = LabelSide,
                    ?RangeFont = RangeFont,
                    ?TickFont = TickFont
                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a parallel coordinates plot.
        ///
        /// Parallel coordinates are a common way of visualizing and analyzing high-dimensional datasets.
        ///
        /// To show a set of points in an n-dimensional space, a backdrop is drawn consisting of n parallel lines, typically vertical and equally spaced. A point in n-dimensional space is represented as a polyline with vertices on the parallel axes; the position of the vertex on the i-th axis corresponds to the i-th coordinate of the point.
        ///
        /// This visualization is closely related to time series visualization, except that it is applied to data where the axes do not correspond to points in time, and therefore do not have a natural order. Therefore, different axis arrangements may be of interest.
        /// </summary>
        /// <param name="keyValues">Sets the values for each dimension of the plot, together with the name of the respective dimension</param>
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
        [<Extension>]
        static member ParallelCoord
            (
                keyValues: seq<string * #seq<#IConvertible>>,
                ?Name: string,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?ShowLineColorScale: bool,
                ?ReverseLineColorScale: bool,
                ?Line: Line,
                ?LabelAngle: int,
                ?LabelFont: Font,
                ?LabelSide: StyleParam.Side,
                ?RangeFont: Font,
                ?TickFont: Font,
                ?UseDefaults: bool
            ) =

            let dims =
                keyValues |> Seq.map (fun (key, vals) -> Dimension.initParallel (Label = key, Values = vals))

            Chart.ParallelCoord(
                dimensions = dims,
                ?Name = Name,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?ShowLineColorScale = ShowLineColorScale,
                ?ReverseLineColorScale = ReverseLineColorScale,
                ?Line = Line,
                ?LabelAngle = LabelAngle,
                ?LabelFont = LabelFont,
                ?LabelSide = LabelSide,
                ?RangeFont = RangeFont,
                ?TickFont = TickFont,
                ?UseDefaults = UseDefaults
            )

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
        [<Extension>]
        static member ParallelCategories
            (
                dimensions: seq<Dimension>,
                ?Name: string,
                ?Counts: int,
                ?LineColor: Color,
                ?LineShape: StyleParam.Shape,
                ?LineColorScale: StyleParam.Colorscale,
                ?ShowLineColorScale: bool,
                ?ReverseLineColorScale: bool,
                ?Line: Line,
                ?Arrangement: StyleParam.CategoryArrangement,
                ?BundleColors: bool,
                ?SortPaths: StyleParam.SortAlgorithm,
                ?LabelFont: Font,
                ?TickFont: Font,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let line =
                Line
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    ?Color = LineColor,
                    ?Shape = LineShape,
                    ?Colorscale = LineColorScale,
                    ?ShowScale = ShowLineColorScale,
                    ?ReverseScale = ReverseLineColorScale
                )

            TraceDomain.initParallelCategories (
                TraceDomainStyle.ParallelCategories(
                    Dimensions = dimensions,
                    Line = line,
                    ?Name = Name,
                    ?Counts = Counts,
                    ?Arrangement = Arrangement,
                    ?BundleColors = BundleColors,
                    ?SortPaths = SortPaths,
                    ?LabelFont = LabelFont,
                    ?TickFont = TickFont
                )
            )

            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a parallel categories plot.
        ///
        /// The parallel categories diagram (also known as parallel sets or alluvial diagram) is a visualization of
        /// multi-dimensional categorical data sets. Each variable in the data set is represented by a column of rectangles,
        /// where each rectangle corresponds to a discrete value taken on by that variable.
        /// The relative heights of the rectangles reflect the relative frequency of occurrence of the corresponding value.
        /// </summary>
        /// <param name="keyValues">Sets the values for each dimension of the plot, together with the name of the respective dimension</param>
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
        [<Extension>]
        static member ParallelCategories
            (
                keyValues: seq<string * #seq<#IConvertible>>,
                ?Name: string,
                ?Counts: int,
                ?LineColor: Color,
                ?LineShape: StyleParam.Shape,
                ?LineColorScale: StyleParam.Colorscale,
                ?ShowLineColorScale: bool,
                ?ReverseLineColorScale: bool,
                ?Line: Line,
                ?Arrangement: StyleParam.CategoryArrangement,
                ?BundleColors: bool,
                ?SortPaths: StyleParam.SortAlgorithm,
                ?LabelFont: Font,
                ?TickFont: Font,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let dims =
                keyValues |> Seq.map (fun (key, vals) -> Dimension.initParallel (Label = key, Values = vals))

            let line =
                Line
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    ?Color = LineColor,
                    ?Shape = LineShape,
                    ?Colorscale = LineColorScale,
                    ?ShowScale = ShowLineColorScale,
                    ?ReverseScale = ReverseLineColorScale
                )

            TraceDomain.initParallelCategories (
                TraceDomainStyle.ParallelCategories(
                    Dimensions = dims,
                    Line = line,
                    ?Name = Name,
                    ?Counts = Counts,
                    ?Arrangement = Arrangement,
                    ?BundleColors = BundleColors,
                    ?SortPaths = SortPaths,
                    ?LabelFont = LabelFont,
                    ?TickFont = TickFont
                )
            )
            |> GenericChart.ofTraceObject useDefaults

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
        [<Extension>]
        static member Sankey
            (
                nodes: SankeyNodes,
                links: SankeyLinks,
                ?Name: string,
                ?Ids: seq<#IConvertible>,
                ?Orientation: StyleParam.Orientation,
                ?TextFont: Font,
                ?Arrangement: StyleParam.CategoryArrangement,
                ?ValueFormat: string,
                ?ValueSuffix: string,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            TraceDomain.initSankey (
                TraceDomainStyle.Sankey(
                    Node = nodes,
                    Link = links,
                    ?Name = Name,
                    ?Ids = Ids,
                    ?Orientation = Orientation,
                    ?TextFont = TextFont,
                    ?Arrangement = Arrangement,
                    ?ValueFormat = ValueFormat,
                    ?ValueSuffix = ValueSuffix

                )
            )
            |> GenericChart.ofTraceObject useDefaults

        /// <summary>
        /// Creates a sankey diagram.
        ///
        /// A Sankey diagram is a flow diagram, in which the width of arrows is proportional to the flow quantity.
        ///
        /// Sankey diagrams visualize the contributions to a flow by defining source to represent the source node, target for the target node, value to set the flow volume, and label that shows the node name.        /// </summary>
        /// <param name="nodeLabels">Sets the labels of the nodes in the sankey diagram</param>
        /// <param name="linkedNodeIds">(source, target) tuples which indicate connected nodes. These values map to the index in `nodeLabels`</param>
        /// <param name="linkValues">The values for the links in the sankey diagram.</param>
        /// <param name="NodeColor">Sets the color of the nodes in the sankey diagram.</param>
        /// <param name="NodeOutlineColor">Sets the color of the node outlines in the sankey diagram.</param>
        /// <param name="NodeOutlineWidth">Sets the outline width of the nodes in the sankey diagram.</param>
        /// <param name="NodeThickness">Sets the thickness of the nodes in the sankey diagram.</param>
        /// <param name="NodeGroups">Sets groups of nodes. Each group is defined by an array with the indices of the nodes it contains. Multiple groups can be specified.</param>
        /// <param name="LinkColor">Sets the color of the links in the sankey diagram.</param>
        /// <param name="LinkColorScales">Sets the colorscale of the links in the sankey diagram.</param>
        /// <param name="LinkOutlineColor">Sets the outline color of the links in the sankey diagram.</param>
        /// <param name="LinkOutlineWidth">Sets the outline width of the links in the sankey diagram.</param>
        /// <param name="LinkLabels">Sets the labels of the links in the sankey diagram.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="Ids">Assigns id labels to each datum.</param>
        /// <param name="Orientation">Sets the orientation of the Sankey diagram.</param>
        /// <param name="TextFont">Sets the text font of this trace.</param>
        /// <param name="Arrangement">If value is `snap` (the default), the node arrangement is assisted by automatic snapping of elements to preserve space between nodes specified via `nodepad`. If value is `perpendicular`, the nodes can only move along a line perpendicular to the flow. If value is `freeform`, the nodes can freely move on the plane. If value is `fixed`, the nodes are stationary.</param>
        /// <param name="ValueFormat">Sets the value formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.</param>
        /// <param name="ValueSuffix">Adds a unit to follow the value in the hover tooltip. Add a space if a separation is necessary from the value.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Sankey
            (
                nodeLabels: seq<string>,
                linkedNodeIds: seq<int * int>,
                linkValues: seq<#IConvertible>,
                ?NodeColor: Color,
                ?NodeOutlineColor: Color,
                ?NodeOutlineWidth: float,
                ?NodeThickness: int,
                ?NodeGroups: seq<#seq<int>>,
                ?LinkColor: Color,
                ?LinkColorScales: seq<StyleParam.Colorscale>,
                ?LinkOutlineColor: Color,
                ?LinkOutlineWidth: float,
                ?LinkLabels: seq<string>,
                ?Name: string,
                ?Ids: seq<#IConvertible>,
                ?Orientation: StyleParam.Orientation,
                ?TextFont: Font,
                ?Arrangement: StyleParam.CategoryArrangement,
                ?ValueFormat: string,
                ?ValueSuffix: string,
                ?UseDefaults: bool
            ) =

            let nodeOutline =
                Line.init (?Color = NodeOutlineColor, ?Width = NodeOutlineWidth)

            let nodes =
                SankeyNodes.init (
                    Label = nodeLabels,
                    Line = nodeOutline,
                    ?Color = NodeColor,
                    ?Thickness = NodeThickness,
                    ?Groups = NodeGroups
                )

            let linkOutline =
                Line.init (?Color = LinkOutlineColor, ?Width = LinkOutlineWidth)

            let sources, targets =
                Seq.unzip linkedNodeIds

            let colorScales =
                LinkColorScales
                |> Option.map (fun c -> c |> Seq.map (fun cs -> SankeyLinkColorscale.init (ColorScale = cs)))

            let links =
                SankeyLinks.init (
                    Source = sources,
                    Target = targets,
                    Line = linkOutline,
                    Value = linkValues,
                    ?ColorScales = colorScales,
                    ?Color = LinkColor,
                    ?Label = LinkLabels
                )

            Chart.Sankey(
                nodes,
                links,
                ?Name = Name,
                ?Ids = Ids,
                ?Orientation = Orientation,
                ?TextFont = TextFont,
                ?Arrangement = Arrangement,
                ?ValueFormat = ValueFormat,
                ?ValueSuffix = ValueSuffix,
                ?UseDefaults = UseDefaults
            )

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
        [<Extension>]
        static member Table
            (
                header: TableHeader,
                cells: TableCells,
                ?Name: string,
                ?ColumnOrder: seq<int>,
                ?ColumnWidth: float,
                ?MultiColumnWidth: seq<float>,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            TraceDomain.initTable (
                TraceDomainStyle.Table(
                    Header = header,
                    Cells = cells,
                    ?Name = Name,
                    ?ColumnOrder = ColumnOrder,
                    ?ColumnWidth = ColumnWidth,
                    ?MultiColumnWidth = MultiColumnWidth

                )
            )
            |> GenericChart.ofTraceObject useDefaults


        /// <summary>
        /// Creates a table.
        ///
        /// The data are arranged in a grid of rows and columns. Most styling can be specified for columns, rows or individual cells. Table is using a row-major order by default, ie. the grid is represented as a vector of row vectors.
        /// </summary>
        /// <param name="headerValues">Sets the values contained in the table header.</param>
        /// <param name="cellsValues">Sets the values contained in the table cells.</param>
        /// <param name="TransposeCells">Whether or not to transpose the cells (i.e. switch from row to column major)</param>
        /// <param name="HeaderAlign">Sets the alignment of the table header.</param>
        /// <param name="HeaderMultiAlign">Sets the alignment of the individual cells in the table header.</param>
        /// <param name="HeaderFillColor">Sets the fill color of the table header.</param>
        /// <param name="HeaderHeight">Sets the height of the table header.</param>
        /// <param name="HeaderOutlineColor">Sets the outline color of the table header cells.</param>
        /// <param name="HeaderOutlineWidth">Sets the outline width of the table header cells.</param>
        /// <param name="HeaderOutlineMultiWidth">Sets the outline width of the individual table header cells.</param>
        /// <param name="HeaderOutline">Sets the outline of the table header cells. (use this for more finegrained control than the other line-associated arguments).</param>
        /// <param name="CellsAlign">Sets the alignment of the table cells.</param>
        /// <param name="CellsMultiAlign">Sets the alignment of the individual table cells.</param>
        /// <param name="CellsFillColor">Sets the fill color of the table cells.</param>
        /// <param name="CellsHeight">Sets the height color of the table cells.</param>
        /// <param name="CellsOutlineColor">Sets the outline color color of the table cells.</param>
        /// <param name="CellsOutlineWidth">Sets the outline width of the table cells.</param>
        /// <param name="CellsOutlineMultiWidth">Sets the outline width of the individual table cells.</param>
        /// <param name="CellsOutline">Sets the outline of the table cells. (use this for more finegrained control than the other line-associated arguments).</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="ColumnOrder">Specifies the rendered order of the data columns; for example, a value `2` at position `0` means that column index `0` in the data will be rendered as the third column, as columns have an index base of zero.</param>
        /// <param name="ColumnWidth">The width of columns expressed as a ratio. Columns fill the available width in proportion of their specified column widths.</param>
        /// <param name="MultiColumnWidth">The width of columns expressed as a ratio. Columns fill the available width in proportion of their specified column widths.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        [<Extension>]
        static member Table
            (
                headerValues: seq<#seq<#IConvertible>>,
                cellsValues: seq<#seq<#IConvertible>>,
                ?TransposeCells: bool,
                ?HeaderAlign: StyleParam.HorizontalAlign,
                ?HeaderMultiAlign: seq<StyleParam.HorizontalAlign>,
                ?HeaderFillColor: Color,
                ?HeaderHeight: int,
                ?HeaderOutlineColor: Color,
                ?HeaderOutlineWidth: float,
                ?HeaderOutlineMultiWidth: seq<float>,
                ?HeaderOutline: Line,
                ?CellsAlign: StyleParam.HorizontalAlign,
                ?CellsMultiAlign: seq<StyleParam.HorizontalAlign>,
                ?CellsFillColor: Color,
                ?CellsHeight: int,
                ?CellsOutlineColor: Color,
                ?CellsOutlineWidth: float,
                ?CellsOutlineMultiWidth: seq<float>,
                ?CellsOutline: Line,
                ?Name: string,
                ?ColumnOrder: seq<int>,
                ?ColumnWidth: float,
                ?MultiColumnWidth: seq<float>,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let transpose =
                defaultArg TransposeCells true

            let cellsValues =
                if transpose then
                    cellsValues |> Seq.map Seq.cast<IConvertible> |> Seq.transpose
                else
                    cellsValues |> Seq.map Seq.cast<IConvertible>

            let headerFill =
                TableFill.init (?Color = HeaderFillColor)

            let headerOutline =
                HeaderOutline
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    ?Color = HeaderOutlineColor,
                    ?Width = HeaderOutlineWidth,
                    ?MultiWidth = HeaderOutlineMultiWidth
                )

            let header =
                TableHeader.init (
                    Values = headerValues,
                    Fill = headerFill,
                    Line = headerOutline,
                    ?Align = HeaderAlign,
                    ?MultiAlign = HeaderMultiAlign,
                    ?Height = HeaderHeight
                )

            let cellsFill =
                TableFill.init (?Color = CellsFillColor)

            let cellsOutline =
                CellsOutline
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    ?Color = CellsOutlineColor,
                    ?Width = CellsOutlineWidth,
                    ?MultiWidth = CellsOutlineMultiWidth
                )

            let cells =
                TableCells.init (
                    Values = cellsValues,
                    Fill = cellsFill,
                    Line = cellsOutline,
                    ?Align = CellsAlign,
                    ?MultiAlign = CellsMultiAlign,
                    ?Height = CellsHeight
                )

            Chart.Table(
                header,
                cells,
                ?Name = Name,
                ?ColumnOrder = ColumnOrder,
                ?ColumnWidth = ColumnWidth,
                ?MultiColumnWidth = MultiColumnWidth,
                ?UseDefaults = UseDefaults

            )

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
        [<Extension>]
        static member Indicator
            (
                value: IConvertible,
                mode: StyleParam.IndicatorMode,
                ?Range: StyleParam.Range,
                ?Name: string,
                ?Title: string,
                ?Domain: Domain,
                ?Align: StyleParam.IndicatorAlignment,
                ?DeltaReference: #IConvertible,
                ?Delta: IndicatorDelta,
                ?Number: IndicatorNumber,
                ?GaugeShape: StyleParam.IndicatorGaugeShape,
                ?Gauge: IndicatorGauge,
                ?ShowGaugeAxis: bool,
                ?GaugeAxis: LinearAxis,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let axis =
                GaugeAxis
                |> Option.defaultValue (LinearAxis.init ())
                |> LinearAxis.style (?Range = Range, ?Visible = ShowGaugeAxis)

            let gauge =
                Gauge
                |> Option.defaultValue (IndicatorGauge.init ())
                |> IndicatorGauge.style (Axis = axis, ?Shape = GaugeShape)

            let delta =
                Delta
                |> Option.defaultValue (IndicatorDelta.init ())
                |> IndicatorDelta.style (?Reference = DeltaReference)

            TraceDomain.initIndicator (
                TraceDomainStyle.Indicator(
                    ?Name = Name,
                    ?Title = Title,
                    Mode = mode,
                    Value = value,
                    ?Domain = Domain,
                    ?Align = Align,
                    Delta = delta,
                    ?Number = Number,
                    Gauge = gauge
                )
            )
            |> GenericChart.ofTraceObject useDefaults

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
        [<Extension>]
        static member Icicle
            (
                labels: seq<#IConvertible>,
                parents: seq<#IConvertible>,
                ?Values: seq<#IConvertible>,
                ?Ids: seq<#IConvertible>,
                ?Name: string,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?SectionColors: seq<Color>,
                ?SectionColorScale: StyleParam.Colorscale,
                ?ShowSectionColorScale: bool,
                ?ReverseSectionColorScale: bool,
                ?SectionOutlineColor: Color,
                ?SectionOutlineWidth: float,
                ?SectionOutlineMultiWidth: seq<float>,
                ?SectionOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?BranchValues: StyleParam.BranchValues,
                ?Count: StyleParam.IcicleCount,
                ?TilingOrientation: StyleParam.Orientation,
                ?TilingFlip: StyleParam.TilingFlip,
                ?Tiling: IcicleTiling,
                ?PathBarEdgeShape: StyleParam.PathbarEdgeShape,
                ?PathBar: Pathbar,
                ?TextInfo: StyleParam.TextInfo,
                ?Root: IcicleRoot,
                ?Level: string,
                ?MaxDepth: int,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let outline =
                SectionOutline
                |> Option.defaultValue (Line.init ())
                |> Line.style (
                    ?Color = SectionOutlineColor,
                    ?Width = SectionOutlineWidth,
                    ?MultiWidth = SectionOutlineMultiWidth
                )

            let pattern =
                MarkerPattern
                |> Option.defaultValue (TraceObjects.Pattern.init ())
                |> TraceObjects.Pattern.style (?Shape = MarkerPatternShape, ?MultiShape = MultiMarkerPatternShape)

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (
                    ?MultiOpacity = MultiOpacity,
                    ?Colors = SectionColors,
                    ?Colorscale = SectionColorScale,
                    ?ShowScale = ShowSectionColorScale,
                    ?ReverseScale = ReverseSectionColorScale,
                    Outline = outline,
                    Pattern = pattern
                )

            let tiling =
                Tiling
                |> Option.defaultValue (IcicleTiling.init ())
                |> IcicleTiling.style (?Orientation = TilingOrientation, ?Flip = TilingFlip)

            let pathbar =
                PathBar |> Option.defaultValue (Pathbar.init ()) |> Pathbar.style (?EdgeShape = PathBarEdgeShape)

            TraceDomain.initIcicle (
                TraceDomainStyle.Icicle(
                    Labels = labels,
                    Parents = parents,
                    Marker = marker,
                    PathBar = pathbar,
                    Tiling = tiling,
                    ?Values = Values,
                    ?Ids = Ids,
                    ?Name = Name,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?BranchValues = BranchValues,
                    ?Count = Count,
                    ?TextInfo = TextInfo,
                    ?Root = Root,
                    ?Level = Level,
                    ?MaxDepth = MaxDepth
                )
            )
            |> GenericChart.ofTraceObject useDefaults


        /// <summary>
        /// Creates an icicle chart.
        ///
        /// Icicle charts visualize hierarchal data from leaves (and/or outer branches) towards root with rectangles.
        /// The icicle sectors are determined by the entries in "labels" or "ids" and in "parents".
        /// </summary>
        /// <param name="labelsparents">Sets the labels of each of the sectors and their respective parent sector.</param>
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
        [<Extension>]
        static member Icicle
            (
                labelsparents: seq<#IConvertible * #IConvertible>,
                ?Values: seq<#IConvertible>,
                ?Ids: seq<#IConvertible>,
                ?Name: string,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?SectionColors: seq<Color>,
                ?SectionColorScale: StyleParam.Colorscale,
                ?ShowSectionColorScale: bool,
                ?ReverseSectionColorScale: bool,
                ?SectionOutlineColor: Color,
                ?SectionOutlineWidth: float,
                ?SectionOutlineMultiWidth: seq<float>,
                ?SectionOutline: Line,
                ?MarkerPatternShape: StyleParam.PatternShape,
                ?MultiMarkerPatternShape: seq<StyleParam.PatternShape>,
                ?MarkerPattern: Pattern,
                ?Marker: Marker,
                ?BranchValues: StyleParam.BranchValues,
                ?Count: StyleParam.IcicleCount,
                ?TilingOrientation: StyleParam.Orientation,
                ?TilingFlip: StyleParam.TilingFlip,
                ?Tiling: IcicleTiling,
                ?PathBarEdgeShape: StyleParam.PathbarEdgeShape,
                ?PathBar: Pathbar,
                ?TextInfo: StyleParam.TextInfo,
                ?Root: IcicleRoot,
                ?Level: string,
                ?MaxDepth: int,
                ?UseDefaults: bool
            ) =

            let labels, parents =
                Seq.unzip labelsparents

            Chart.Icicle(
                labels,
                parents,
                ?Values = Values,
                ?Ids = Ids,
                ?Name = Name,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?SectionColors = SectionColors,
                ?SectionColorScale = SectionColorScale,
                ?ShowSectionColorScale = ShowSectionColorScale,
                ?ReverseSectionColorScale = ReverseSectionColorScale,
                ?SectionOutlineColor = SectionOutlineColor,
                ?SectionOutlineWidth = SectionOutlineWidth,
                ?SectionOutlineMultiWidth = SectionOutlineMultiWidth,
                ?SectionOutline = SectionOutline,
                ?MarkerPatternShape = MarkerPatternShape, 
                ?MultiMarkerPatternShape = MultiMarkerPatternShape,
                ?MarkerPattern = MarkerPattern,
                ?Marker = Marker,
                ?BranchValues = BranchValues,
                ?Count = Count,
                ?TilingOrientation = TilingOrientation,
                ?TilingFlip = TilingFlip,
                ?Tiling = Tiling,
                ?PathBarEdgeShape = PathBarEdgeShape,
                ?PathBar = PathBar,
                ?TextInfo = TextInfo,
                ?Root = Root,
                ?Level = Level,
                ?MaxDepth = MaxDepth,
                ?UseDefaults = UseDefaults

            )
