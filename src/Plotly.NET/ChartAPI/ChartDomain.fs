namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open DynamicObj
open System
open System.IO

open GenericChart
open StyleParam
open System.Runtime.InteropServices
open System.Runtime.CompilerServices

[<AutoOpen>]
module ChartDomain =

    [<Extension>]
    type Chart =

        /// Shows how proportions of data, shown as pie-shaped pieces, contribute to the data.
        [<Extension>]
        static member Pie
            (
                values        : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?Labels        : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?Name          : string,
                [<Optional;DefaultParameterValue(null)>] ?TextLabels    : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition  : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?Direction     : StyleParam.Direction,
                [<Optional;DefaultParameterValue(null)>] ?Pull          : float,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend    : bool,
                [<Optional;DefaultParameterValue(null)>] ?SectionColors : seq<Color>,
                [<Optional;DefaultParameterValue(null)>] ?Opacity       : float,
                [<Optional;DefaultParameterValue(null)>] ?Sort          : bool
            ) =         
                TraceDomain.initPie(
                    TraceDomainStyle.Pie(
                        Values          = values,
                        ?Labels         = Labels,
                        ?Name           = Name,
                        ?Text           = TextLabels,
                        ?TextPosition   = TextPosition,
                        ?Direction      = Direction,
                        ?Pull           = Pull,
                        ?ShowLegend     = ShowLegend,
                        ?Opacity        = Opacity,
                        ?Sort           = Sort
                    )
                )
                |> TraceStyle.Marker(?Colors=SectionColors)
                |> TraceStyle.TextLabel(?Text=(if TextLabels.IsSome then TextLabels else Labels),?Textposition=TextPosition)
                |> GenericChart.ofTraceObject 

        /// Shows how proportions of data, shown as pie-shaped pieces, contribute to the data.
        [<Extension>]
        static member Pie
            (
                valuesLabels:seq<#IConvertible*#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?Name          : string,
                [<Optional;DefaultParameterValue(null)>] ?TextLabels    : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition  : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?Direction     : StyleParam.Direction,
                [<Optional;DefaultParameterValue(null)>] ?Pull          : float,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend    : bool,
                [<Optional;DefaultParameterValue(null)>] ?SectionColors : seq<Color>,
                [<Optional;DefaultParameterValue(null)>] ?Opacity       : float,
                [<Optional;DefaultParameterValue(null)>] ?Sort          : bool
            ) = 
                let values,labels = Seq.unzip valuesLabels 
                Chart.Pie(
                    values,
                    Labels = labels,
                    ?Name          = Name         ,
                    ?TextLabels    = TextLabels   ,
                    ?TextPosition  = TextPosition ,
                    ?Direction     = Direction    ,
                    ?Pull          = Pull         ,
                    ?ShowLegend    = ShowLegend   ,
                    ?SectionColors = SectionColors,
                    ?Opacity       = Opacity      ,
                    ?Sort           = Sort
                )


        /// Shows how proportions of data, shown as pie-shaped pieces, contribute to the data as a whole.
        [<Extension>]
        static member Doughnut
            (
               values        : seq<#IConvertible>,
               [<Optional;DefaultParameterValue(null)>] ?Labels        : seq<#IConvertible>,
               [<Optional;DefaultParameterValue(null)>] ?Hole          : float,
               [<Optional;DefaultParameterValue(null)>] ?Name          : string,
               [<Optional;DefaultParameterValue(null)>] ?TextLabels    : seq<#IConvertible>,
               [<Optional;DefaultParameterValue(null)>] ?TextPosition  : StyleParam.TextPosition,
               [<Optional;DefaultParameterValue(null)>] ?Direction     : StyleParam.Direction,
               [<Optional;DefaultParameterValue(null)>] ?Pull          : float,
               [<Optional;DefaultParameterValue(null)>] ?ShowLegend    : bool,
               [<Optional;DefaultParameterValue(null)>] ?SectionColors : seq<Color>,
               [<Optional;DefaultParameterValue(null)>] ?Opacity       : float,
               [<Optional;DefaultParameterValue(null)>] ?Sort          : bool
            ) =         
                let hole' = Option.defaultValue 0.4 Hole
                TraceDomain.initPie(
                    TraceDomainStyle.Pie(
                        Values          = values,
                        ?Labels         = Labels,
                        ?Name           = Name,
                        ?Text           = TextLabels,
                        ?TextPosition   = TextPosition,
                        ?Direction      = Direction,
                        ?Pull           = Pull,
                        ?ShowLegend     = ShowLegend,
                        ?Opacity        = Opacity,
                        Hole            = hole',
                        ?Sort           = Sort
                    )
                )
                |> TraceStyle.Marker(?Colors=SectionColors)
                |> TraceStyle.TextLabel(?Text=(if TextLabels.IsSome then TextLabels else Labels),?Textposition=TextPosition)
                |> GenericChart.ofTraceObject 


        /// Shows how proportions of data, shown as pie-shaped pieces, contribute to the data as a whole.
        [<Extension>]
        static member Doughnut
            (
                valuesLabels:seq<#IConvertible*#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?Hole          : float,
                [<Optional;DefaultParameterValue(null)>] ?Name          : string,
                [<Optional;DefaultParameterValue(null)>] ?TextLabels    : seq<#IConvertible>,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition  : StyleParam.TextPosition,
                [<Optional;DefaultParameterValue(null)>] ?Direction     : StyleParam.Direction,
                [<Optional;DefaultParameterValue(null)>] ?Pull          : float,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend    : bool,
                [<Optional;DefaultParameterValue(null)>] ?SectionColors : seq<Color>,
                [<Optional;DefaultParameterValue(null)>] ?Opacity       : float,
                [<Optional;DefaultParameterValue(null)>] ?Sort          : bool
            ) = 
                let values,labels = Seq.unzip valuesLabels 
                Chart.Doughnut(
                    values,
                    Labels = labels,
                    ?Name          = Name         ,
                    ?TextLabels    = TextLabels   ,
                    ?TextPosition  = TextPosition ,
                    ?Direction     = Direction    ,
                    ?Pull          = Pull         ,
                    ?ShowLegend    = ShowLegend   ,
                    ?SectionColors = SectionColors,
                    ?Opacity       = Opacity      ,
                    ?Hole          = Hole          ,
                    ?Sort          = Sort
                )

            
        
        /// Creates a FunnelArea chart.
        /// FunnelArea charts visualize stages in a process using area-encoded trapezoids. This trace can be used to show data in a part-to-whole representation similar to a "pie" trace, wherein each item appears in a single stage. See also the "funnel" trace type for a different approach to visualizing funnel data.
        ///
        /// Parameters:
        /// 
        /// Values        : Sets the values of the sectors. If omitted, we count occurrences of each label.
        ///
        /// Labels        : Sets the sector labels. If `labels` entries are duplicated, we sum associated `values` or simply count occurrences if `values` is not provided. For other array attributes (including color) we use the first non-empty entry among all occurrences of the label.
        ///
        /// dLabel        : Sets the label step. See `label0` for more info.
        ///
        /// Label0        : Alternate to `labels`. Builds a numeric set of labels. Use with `dlabel` where `label0` is the starting label and `dlabel` the step.
        ///
        /// Name          : Sets the trace name. The trace name appear as the legend item and on hover.
        ///
        /// ShowLegend    : Determines whether or not an item corresponding to this trace is shown in the legend.
        ///
        /// Opacity       : Sets the opacity of the trace.
        ///
        /// Color         : Sets Marker Color
        ///
        /// Line          : Line type
        ///
        /// Text          : Sets text elements associated with each sector. If trace `textinfo` contains a "text" flag, these elements will be seen on the chart. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.
        ///
        /// TextPosition  : Specifies the location of the `textinfo`.
        ///
        /// X             : Sets the horizontal domain of this funnelarea trace (in plot fraction).
        ///
        /// Y             : Sets the vertical domain of this funnelarea trace (in plot fraction).
        ///
        /// Row           : If there is a layout grid, use the domain for this row in the grid for this funnelarea trace .
        ///
        /// Column        : If there is a layout grid, use the domain for this column in the grid for this funnelarea trace .
        ///
        /// Aspectratio   : Sets the ratio between height and width
        ///
        /// Baseratio     : Sets the ratio between bottom length and maximum top length.
        ///
        /// Insidetextfont: Sets the font used for `textinfo` lying inside the sector.
        ///
        /// Scalegroup    : If there are multiple funnelareas that should be sized according to their totals, link them by providing a non-empty group id here shared by every trace in the same group.
        [<Extension>]
        static member FunnelArea 
            (
                [<Optional;DefaultParameterValue(null)>] ?Values        ,
                [<Optional;DefaultParameterValue(null)>] ?Labels        ,
                [<Optional;DefaultParameterValue(null)>] ?dLabel        ,
                [<Optional;DefaultParameterValue(null)>] ?Label0        ,
                [<Optional;DefaultParameterValue(null)>] ?Name          ,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend    ,
                [<Optional;DefaultParameterValue(null)>] ?Opacity       ,
                [<Optional;DefaultParameterValue(null)>] ?Color         ,
                [<Optional;DefaultParameterValue(null)>] ?Line          ,
                [<Optional;DefaultParameterValue(null)>] ?Text          ,
                [<Optional;DefaultParameterValue(null)>] ?TextPosition  ,
                [<Optional;DefaultParameterValue(null)>] ?X             ,
                [<Optional;DefaultParameterValue(null)>] ?Y             ,
                [<Optional;DefaultParameterValue(null)>] ?Row           ,
                [<Optional;DefaultParameterValue(null)>] ?Column        ,
                [<Optional;DefaultParameterValue(null)>] ?Aspectratio   ,
                [<Optional;DefaultParameterValue(null)>] ?Baseratio     ,
                [<Optional;DefaultParameterValue(null)>] ?Insidetextfont,
                [<Optional;DefaultParameterValue(null)>] ?Scalegroup
            ) = 

            TraceDomain.initFunnelArea(
                TraceDomainStyle.FunnelArea(
                    ?Values         = Values        ,
                    ?Labels         = Labels        ,
                    ?dLabel         = dLabel        ,
                    ?Label0         = Label0        ,
                    ?Aspectratio    = Aspectratio   ,
                    ?Baseratio      = Baseratio     ,
                    ?Insidetextfont = Insidetextfont,
                    ?Scalegroup     = Scalegroup
                )
            )
            |> TraceStyle.TraceInfo(?Name=Name,?ShowLegend=ShowLegend,?Opacity=Opacity)
            |> TraceStyle.Marker(?Color=Color,?Outline=Line)
            |> TraceStyle.Domain(?X=X,?Y=Y,?Row=Row,?Column=Column)
            |> TraceStyle.TextLabel(?Text=Text,?Textposition=TextPosition)
            |> GenericChart.ofTraceObject


        /// Creates a sunburst chart. Visualize hierarchical data spanning outward radially from root to leaves.
        /// Applies the styles of sundburst plot to TraceObjects 
        ///
        /// Parameters:
        ///
        /// labels: Sets the labels of each of the sectors.
        ///
        /// parents: Sets the parent sectors for each of the sectors. Empty string items '' are understood to reference the root node in the hierarchy. If `ids` is filled, `parents` items are understood to be "ids" themselves. When `ids` is not set, plotly attempts to find matching items in `labels`, but beware they must be unique.
        ///
        /// Ids: Assigns id labels to each datum. These ids for object constancy of data points during animation.
        ///
        /// Values: Sets the values associated with each of the sectors. Use with `branchvalues` to determine how the values are summed.
        ///
        /// Text: Sets text elements associated with each sector. If trace `textinfo` contains a "text" flag, these elements will be seen on the chart. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.
        ///
        /// Branchvalues: Determines how the items in `values` are summed. When set to "total", items in `values` are taken to be value of all its descendants. When set to "remainder", items in `values` corresponding to the root and the branches sectors are taken to be the extra part not part of the sum of the values at their leaves.
        ///
        /// Level: Sets the level from which this trace hierarchy is rendered. Set `level` to `''` to start from the root node in the hierarchy. Must be an "id" if `ids` is filled in, otherwise plotly attempts to find a matching item in `labels`.
        ///
        /// Maxdepth: Sets the number of rendered sectors from any given `level`. Set `maxdepth` to "-1" to render all the levels in the hierarchy.
        ///
        /// ColorBar: Sets the ColorBar for the chart
        ///
        ///Colors: Sets the color of each sector of this trace. If not specified, the default trace color set is used to pick the sector colors.
        [<Extension>]
        static member Sunburst(labels,parents,
            [<Optional;DefaultParameterValue(null)>]?Ids,
            [<Optional;DefaultParameterValue(null)>]?Values,
            [<Optional;DefaultParameterValue(null)>]?Text,
            [<Optional;DefaultParameterValue(null)>]?Branchvalues,
            [<Optional;DefaultParameterValue(null)>]?Level,
            [<Optional;DefaultParameterValue(null)>]?Maxdepth,
            [<Optional;DefaultParameterValue(null)>]?Color,
            [<Optional;DefaultParameterValue(null)>]?ColorBar:ColorBar
            ) =
            TraceDomain.initSunburst(
                TraceDomainStyle.Sunburst(
                    labels          = labels,
                    parents         = parents,
                    ?Ids            = Ids,
                    ?Values         = Values,
                    ?Text           = Text,
                    ?Branchvalues   = Branchvalues,
                    ?Level          = Level,
                    ?Maxdepth       = Maxdepth
                )
            )
            |> TraceStyle.Marker(?Color=Color,?ColorBar=ColorBar)
            |> GenericChart.ofTraceObject


        /// Creates a treemap chart. Treemap charts visualize hierarchical data using nested rectangles. Same as Sunburst the hierarchy is defined by labels and parents attributes. Click on one sector to zoom in/out, which also displays a pathbar in the upper-left corner of your treemap. To zoom out you can use the path bar as well.
        ///
        /// Parameters:
        ///
        /// labels: Sets the labels of each of the sectors.
        ///
        /// parents: Sets the parent sectors for each of the sectors. Empty string items '' are understood to reference the root node in the hierarchy. If `ids` is filled, `parents` items are understood to be "ids" themselves. When `ids` is not set, plotly attempts to find matching items in `labels`, but beware they must be unique.
        ///
        /// Ids: Assigns id labels to each datum. These ids for object constancy of data points during animation.
        ///
        /// Values: Sets the values associated with each of the sectors. Use with `branchvalues` to determine how the values are summed.
        ///
        /// Text: Sets text elements associated with each sector. If trace `textinfo` contains a "text" flag, these elements will be seen on the chart. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.
        ///
        /// Branchvalues: Determines how the items in `values` are summed. When set to "total", items in `values` are taken to be value of all its descendants. When set to "remainder", items in `values` corresponding to the root and the branches sectors are taken to be the extra part not part of the sum of the values at their leaves.
        ///
        /// Level: Sets the level from which this trace hierarchy is rendered. Set `level` to `''` to start from the root node in the hierarchy. Must be an "id" if `ids` is filled in, otherwise plotly attempts to find a matching item in `labels`.
        ///
        /// Maxdepth: Sets the number of rendered sectors from any given `level`. Set `maxdepth` to "-1" to render all the levels in the hierarchy.
        ///
        /// ColorBar: Sets the ColorBar for the chart
        ///
        ///Colors: Sets the color of each sector of this trace. If not specified, the default trace color set is used to pick the sector colors.
        [<Extension>]
        static member Treemap(labels,parents,
            [<Optional;DefaultParameterValue(null)>]?Ids,
            [<Optional;DefaultParameterValue(null)>]?Values,
            [<Optional;DefaultParameterValue(null)>]?Text,
            [<Optional;DefaultParameterValue(null)>]?Branchvalues,
            [<Optional;DefaultParameterValue(null)>]?Tiling,
            [<Optional;DefaultParameterValue(null)>]?PathBar,
            [<Optional;DefaultParameterValue(null)>]?Level,
            [<Optional;DefaultParameterValue(null)>]?Maxdepth,
            [<Optional;DefaultParameterValue(null)>]?Color,
            [<Optional;DefaultParameterValue(null)>]?ColorBar:ColorBar
            ) =
            TraceDomain.initTreemap(
                TraceDomainStyle.Treemap(
                    labels          = labels,
                    parents         = parents,
                    ?Ids            = Ids,
                    ?Values         = Values,
                    ?Text           = Text,
                    ?Branchvalues   = Branchvalues,
                    ?Tiling         = Tiling,
                    ?PathBar        = PathBar,
                    ?Level          = Level,
                    ?Maxdepth       = Maxdepth
                )
            )
            |> TraceStyle.Marker(?Color=Color,?ColorBar=ColorBar)
            |> GenericChart.ofTraceObject


        /// Computes the parallel coordinates plot
        [<Extension>]
        static member ParallelCoord
            (
                dims:seq<'key*#seq<'values>>,
                [<Optional;DefaultParameterValue(null)>] ?Range,
                [<Optional;DefaultParameterValue(null)>] ?Constraintrange,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?Width,
                [<Optional;DefaultParameterValue(null)>] ?Dash,
                [<Optional;DefaultParameterValue(null)>] ?Domain,
                [<Optional;DefaultParameterValue(null)>] ?Labelfont,
                [<Optional;DefaultParameterValue(null)>] ?Tickfont,
                [<Optional;DefaultParameterValue(null)>] ?Rangefont
            ) =

                let dims' = 
                    dims 
                    |> Seq.map (fun (k,vals) -> 
                        Dimensions.init(vals)
                        |> Dimensions.style(vals,?Range=Range,?Constraintrange=Constraintrange,Label=k)
                    )
                TraceDomain.initParallelCoord(
                    TraceDomainStyle.ParallelCoord(
                        Dimensions=dims',
                        ?Domain=Domain,
                        ?Labelfont=Labelfont,
                        ?Tickfont=Tickfont,
                        ?Rangefont=Rangefont
                    )             
                )
                |> TraceStyle.Line(?Width=Width,?Color=Color,?Dash=Dash,?Colorscale=Colorscale)
                |> GenericChart.ofTraceObject


        /// Computes the parallel coordinates plot
        [<Extension>]
        static member ParallelCoord
            (
                dims:seq<Dimensions>,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?Width,
                [<Optional;DefaultParameterValue(null)>] ?Dash,
                [<Optional;DefaultParameterValue(null)>] ?Domain,
                [<Optional;DefaultParameterValue(null)>] ?Labelfont,
                [<Optional;DefaultParameterValue(null)>] ?Tickfont,
                [<Optional;DefaultParameterValue(null)>] ?Rangefont
            ) =

                TraceDomain.initParallelCoord (
                    TraceDomainStyle.ParallelCoord (
                        Dimensions=dims,
                        ?Domain=Domain,
                        ?Labelfont=Labelfont,
                        ?Tickfont=Tickfont,
                        ?Rangefont=Rangefont
                    )             
                )
                |> TraceStyle.Line(?Width=Width,?Color=Color,?Dash=Dash,?Colorscale=Colorscale)
                |> GenericChart.ofTraceObject

        ///Parallel categories diagram for multidimensional categorical data.
        [<Extension>]
        static member ParallelCategories
            (
                dims:seq<'key*#seq<'values>>,
                [<Optional;DefaultParameterValue(null)>] ?Range,
                [<Optional;DefaultParameterValue(null)>] ?Constraintrange,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?Width,
                [<Optional;DefaultParameterValue(null)>] ?Dash,
                [<Optional;DefaultParameterValue(null)>] ?Domain,
                [<Optional;DefaultParameterValue(null)>] ?Labelfont,
                [<Optional;DefaultParameterValue(null)>] ?Tickfont,
                [<Optional;DefaultParameterValue(null)>] ?Rangefont
            ) =
                let dims' = 
                    dims 
                    |> Seq.map (fun (k,vals) -> 
                        Dimensions.init(vals)
                        |> Dimensions.style(vals,?Range=Range,?Constraintrange=Constraintrange,Label=k)
                    )
                TraceDomain.initParallelCategories (
                    TraceDomainStyle.ParallelCategories(
                        Dimensions=dims',
                        ?Domain=Domain,
                        ?Labelfont=Labelfont,
                        ?Tickfont=Tickfont,
                        ?Rangefont=Rangefont
                    )
                )
                |> TraceStyle.Line(?Width=Width,?Color=Color,?Dash=Dash,?Colorscale=Colorscale)
                |> GenericChart.ofTraceObject

        ///
        [<Extension>]
        static member ParallelCategories
            (
                dims:seq<Dimensions>,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?Width,
                [<Optional;DefaultParameterValue(null)>] ?Dash,
                [<Optional;DefaultParameterValue(null)>] ?Domain,
                [<Optional;DefaultParameterValue(null)>] ?Labelfont,
                [<Optional;DefaultParameterValue(null)>] ?Tickfont,
                [<Optional;DefaultParameterValue(null)>] ?Rangefont
            ) =
                TraceDomain.initParallelCategories(
                    TraceDomainStyle.ParallelCategories(
                        Dimensions=dims,
                        ?Domain=Domain,
                        ?Color=Color,
                        ?Labelfont=Labelfont,
                        ?Tickfont=Tickfont,
                        ?Rangefont=Rangefont
                    )             
                )
                |> TraceStyle.Line(?Width=Width,?Dash=Dash,?Colorscale=Colorscale)
                |> GenericChart.ofTraceObject


        /// creates table out of header sequence and row sequences
        [<Extension>]
        static member Table
            (
                headerValues, cellValues, 
                [<Optional;DefaultParameterValue(null)>] ?AlignHeader, 
                [<Optional;DefaultParameterValue(null)>] ?AlignCells,
                [<Optional;DefaultParameterValue(null)>] ?ColumnWidth, 
                [<Optional;DefaultParameterValue(null)>] ?ColumnOrder, 
                [<Optional;DefaultParameterValue(null)>] ?ColorHeader, 
                [<Optional;DefaultParameterValue(null)>] ?ColorCells, 
                [<Optional;DefaultParameterValue(null)>] ?FontHeader, 
                [<Optional;DefaultParameterValue(null)>] ?FontCells, 
                [<Optional;DefaultParameterValue(null)>] ?HeightHeader, 
                [<Optional;DefaultParameterValue(null)>] ?HeightCells, 
                [<Optional;DefaultParameterValue(null)>] ?LineHeader, 
                [<Optional;DefaultParameterValue(null)>] ?LineCells
            ) = 

                TraceDomain.initTable (

                    let CellFilling =
                        match ColorCells with 
                        | Some color  -> Some (CellColor.init (?Color=ColorCells))
                        | Option.None -> Option.None

                    let HeaderFilling =
                        match ColorHeader with 
                        | Some color   -> Some (CellColor.init (?Color=ColorHeader))
                        | Option.None  -> Option.None
                              
                    TraceDomainStyle.Table (
                        header = TableHeader.init (headerValues|> Seq.map seq, ?Align=AlignHeader, ?Fill=HeaderFilling, ?Font=FontHeader, ?Height=HeightHeader, ?Line=LineHeader),
                        cells  = TableCells.init(cellValues |> Seq.transpose, ?Align=AlignCells, ?Fill=CellFilling, ?Font=FontCells, ?Height=HeightCells, ?Line=LineCells),  
                        ?ColumnWidth = ColumnWidth,
                        ?ColumnOrder = ColumnOrder
                        )
                    )
                |> GenericChart.ofTraceObject 
