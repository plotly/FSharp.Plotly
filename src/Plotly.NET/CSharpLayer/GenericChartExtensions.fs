namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open System
open System.IO

open DynamicObj
open GenericChart
open System.Runtime.InteropServices
open System.Runtime.CompilerServices

///Extension methods for providing a Plotly.NET fluent interface pattern for C#
[<Extension>]
module GenericChartExtensions =

    type GenericChart with
        
        [<CompiledName("WithTraceName")>]
        [<Extension>]
        member this.WithTraceName
            (
                [<Optional;DefaultParameterValue(null)>] ?Name,
                [<Optional;DefaultParameterValue(null)>] ?ShowLegend,
                [<Optional;DefaultParameterValue(null)>] ?LegendGroup,
                [<Optional;DefaultParameterValue(null)>] ?Visible
            ) =
                this |> Chart.withTraceName(?Name=Name,?ShowLegend=ShowLegend,?LegendGroup=LegendGroup,?Visible=Visible)

        /// Set the axis anchor id the trace is belonging to
        [<CompiledName("WithAxisAnchor")>]
        [<Extension>]
        member this.WithAxisAnchor
            (
                [<Optional;DefaultParameterValue(null)>] ?X,
                [<Optional;DefaultParameterValue(null)>] ?Y
            ) =
                this |> Chart.withAxisAnchor(?X = X,?Y = Y)

        /// Apply styling to the Marker(s) of the chart as Object.
        [<CompiledName("WithMarker")>]
        [<Extension>]
        member this.WithMarker(marker:Marker) =
            this |> Chart.withMarker marker

        /// Apply styling to the Marker(s) of the chart.
        [<CompiledName("WithMarkerStyle")>]
        [<Extension>]
        member this.WithMarkerStyle
            (
                [<Optional;DefaultParameterValue(null)>] ?AutoColorScale    : bool,
                [<Optional;DefaultParameterValue(null)>] ?CAuto             : bool,
                [<Optional;DefaultParameterValue(null)>] ?CMax              : float,
                [<Optional;DefaultParameterValue(null)>] ?CMid              : float,
                [<Optional;DefaultParameterValue(null)>] ?CMin              : float,
                [<Optional;DefaultParameterValue(null)>] ?Color             : Color,
                [<Optional;DefaultParameterValue(null)>] ?Colors            : seq<Color>,
                [<Optional;DefaultParameterValue(null)>] ?ColorAxis         : StyleParam.SubPlotId,
                [<Optional;DefaultParameterValue(null)>] ?ColorBar          : ColorBar,
                [<Optional;DefaultParameterValue(null)>] ?Colorscale        : StyleParam.Colorscale,
                [<Optional;DefaultParameterValue(null)>] ?Gradient          : Gradient,
                [<Optional;DefaultParameterValue(null)>] ?Outline           : Line,
                [<Optional;DefaultParameterValue(null)>] ?Size              : int,
                [<Optional;DefaultParameterValue(null)>] ?MultiSize        : seq<int>,
                [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
                [<Optional;DefaultParameterValue(null)>] ?MultiOpacity    : seq<float>,
                [<Optional;DefaultParameterValue(null)>] ?Pattern           : Pattern,
                [<Optional;DefaultParameterValue(null)>] ?Symbol            : StyleParam.MarkerSymbol,
                [<Optional;DefaultParameterValue(null)>] ?MultiSymbols      : seq<StyleParam.MarkerSymbol>,
                [<Optional;DefaultParameterValue(null)>] ?OutlierColor      : Color,
                [<Optional;DefaultParameterValue(null)>] ?Maxdisplayed      : int,
                [<Optional;DefaultParameterValue(null)>] ?ReverseScale      : bool,
                [<Optional;DefaultParameterValue(null)>] ?ShowScale         : bool,
                [<Optional;DefaultParameterValue(null)>] ?SizeMin           : int,
                [<Optional;DefaultParameterValue(null)>] ?SizeMode          : StyleParam.MarkerSizeMode,
                [<Optional;DefaultParameterValue(null)>] ?SizeRef           : int
            ) =
                this 
                |> Chart.withMarkerStyle(
                    ?AutoColorScale    = AutoColorScale    ,
                    ?CAuto             = CAuto             ,
                    ?CMax              = CMax              ,
                    ?CMid              = CMid              ,
                    ?CMin              = CMin              ,
                    ?Color             = Color             ,
                    ?Colors            = Colors            ,
                    ?ColorAxis         = ColorAxis         ,
                    ?ColorBar          = ColorBar          ,
                    ?Colorscale        = Colorscale        ,
                    ?Gradient          = Gradient          ,
                    ?Outline           = Outline           ,
                    ?Size              = Size              ,
                    ?MultiSize        = MultiSize        ,
                    ?Opacity           = Opacity           ,
                    ?MultiOpacity    = MultiOpacity    ,
                    ?Pattern           = Pattern           ,
                    ?Symbol            = Symbol            ,
                    ?MultiSymbols      = MultiSymbols      ,
                    ?OutlierColor      = OutlierColor      ,
                    ?Maxdisplayed      = Maxdisplayed      ,
                    ?ReverseScale      = ReverseScale      ,
                    ?ShowScale         = ShowScale         ,
                    ?SizeMin           = SizeMin           ,
                    ?SizeMode          = SizeMode          ,
                    ?SizeRef           = SizeRef           
                )

        /// Apply styling to the Line(s) of the chart as Object.
        [<CompiledName("WithLine")>]
        [<Extension>]
        member this.WithLine(line:Line) =
             this |> Chart.withLine line

        /// Apply styling to the Line(s) of the chart.
        [<CompiledName("WithLineStyle")>]
        [<Extension>]
        member this.WithLineStyle
            (
                [<Optional;DefaultParameterValue(null)>] ?Width,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Shape,
                [<Optional;DefaultParameterValue(null)>] ?Dash,
                [<Optional;DefaultParameterValue(null)>] ?Smoothing,
                [<Optional;DefaultParameterValue(null)>] ?Colorscale
            ) =
                this 
                |> Chart.withLineStyle(
                    ?Width=Width,
                    ?Color=Color,
                    ?Shape=Shape,
                    ?Dash=Dash,
                    ?Smoothing=Smoothing,
                    ?Colorscale=Colorscale
                )

        /// Apply styling to the xError(s) of the chart as Object
        [<CompiledName("WithXError")>]
        [<Extension>]
        member this.WithXError(xError:Error) =
            this |> Chart.withXError xError
            
        /// Apply styling to the xError(s) of the chart as Object
        [<CompiledName("WithXErrorStyle")>]
        [<Extension>]
        member this.WithXErrorStyle
            (
                [<Optional;DefaultParameterValue(null)>] ?Array,
                [<Optional;DefaultParameterValue(null)>] ?Arrayminus,
                [<Optional;DefaultParameterValue(null)>] ?Symmetric,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Thickness,
                [<Optional;DefaultParameterValue(null)>] ?Width
            ) =
                let error = Error.init(?Array=Array,?Arrayminus=Arrayminus,?Symmetric=Symmetric,?Color=Color,?Thickness=Thickness,?Width=Width)
                this |> Chart.withXError error

        /// Apply styling to the yError(s) of the chart as Object
        [<CompiledName("WithYError")>]
        [<Extension>]
        member this.WithYError(yError:Error) =
            this |> mapTrace (TraceStyle.SetErrorY(yError))
            
        /// Apply styling to the yError(s) of the chart as Object
        [<CompiledName("WithYErrorStyle")>]
        [<Extension>]
        member this.WithYErrorStyle
            (
                [<Optional;DefaultParameterValue(null)>] ?Array,
                [<Optional;DefaultParameterValue(null)>] ?Arrayminus,
                [<Optional;DefaultParameterValue(null)>] ?Symmetric,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Thickness,
                [<Optional;DefaultParameterValue(null)>] ?Width
            ) =
                let error = Error.init(?Array=Array,?Arrayminus=Arrayminus,?Symmetric=Symmetric,?Color=Color,?Thickness=Thickness,?Width=Width)
                this |> Chart.withYError error

        /// Apply styling to the zError(s) of the chart as Object
        [<CompiledName("WithZError")>]
        [<Extension>]
        member this.WithZError(zError:Error) =
            this |> mapTrace (TraceStyle.SetErrorZ(zError))
            

        /// Apply styling to the zError(s) of the chart as Object
        [<CompiledName("WithZErrorStyle")>]
        [<Extension>]
        member this.WithZErrorStyle
            (
                [<Optional;DefaultParameterValue(null)>] ?Array,
                [<Optional;DefaultParameterValue(null)>] ?Arrayminus,
                [<Optional;DefaultParameterValue(null)>] ?Symmetric,
                [<Optional;DefaultParameterValue(null)>] ?Color,
                [<Optional;DefaultParameterValue(null)>] ?Thickness,
                [<Optional;DefaultParameterValue(null)>] ?Width
            ) =
                let error = Error.init(?Array=Array,?Arrayminus=Arrayminus,?Symmetric=Symmetric,?Color=Color,?Thickness=Thickness,?Width=Width)
                this |> Chart.withZError error


        // ############################################################
        // ####################### Apply to layout

        // Sets x-Axis of 2d and 3d- Charts
        [<CompiledName("WithXAxis")>]
        [<Extension>]
        member this.WithXAxis(xAxis:LinearAxis,[<Optional;DefaultParameterValue(null)>] ?Id: StyleParam.SubPlotId) =
            this |> Chart.withXAxis(xAxis, ?Id = Id)

        // Sets x-Axis of 2d and 3d- Charts
        [<CompiledName("WithXAxisStyle")>]
        [<Extension>]
        member this.WithXAxisStyle(title,
                [<Optional;DefaultParameterValue(null)>] ?MinMax,
                [<Optional;DefaultParameterValue(null)>] ?ShowGrid,
                [<Optional;DefaultParameterValue(null)>] ?ShowLine,
                [<Optional;DefaultParameterValue(null)>] ?Side,
                [<Optional;DefaultParameterValue(null)>] ?Overlaying,
                [<Optional;DefaultParameterValue(null)>] ?Id,
                [<Optional;DefaultParameterValue(null)>] ?Domain,
                [<Optional;DefaultParameterValue(null)>] ?Position,
                [<Optional;DefaultParameterValue(null)>] ?ZeroLine,
                [<Optional;DefaultParameterValue(null)>] ?Anchor) =
            let range  = if MinMax.IsSome then Some (StyleParam.Range.MinMax (MinMax.Value)) else None
            let domain = if Domain.IsSome then Some (StyleParam.Range.MinMax (Domain.Value)) else None
            let xaxis  = LinearAxis.init(Title=title,?Range=range,?ShowGrid=ShowGrid,?ShowLine=ShowLine,
                                    ?Anchor=Anchor,?Side=Side,?Domain=domain,?Overlaying=Overlaying,?Position=Position,?ZeroLine=ZeroLine)
            this |> Chart.withXAxis(xaxis,?Id=Id)

        /// Sets the range slider for the xAxis
        [<CompiledName("WithXAxisRangeSlider")>]
        [<Extension>]
        member this.WithXAxisRangeSlider(rangeSlider:RangeSlider,
                [<Optional;DefaultParameterValue(null)>] ?Id) =
            let xaxis  = LinearAxis.init(RangeSlider = rangeSlider)
            this |> Chart.withXAxis(xaxis,?Id=Id)

        // Sets y-Axis of 2d and 3d- Charts
        [<CompiledName("WithYAxis")>]
        [<Extension>]
        member this.WithYAxis(yAxis:LinearAxis,[<Optional;DefaultParameterValue(null)>] ?Id: StyleParam.SubPlotId) =
            this |> Chart.withYAxis(yAxis, ?Id = Id)

         // Sets y-Axis of 3d- Charts
        [<CompiledName("WithYAxisStyle")>]
        [<Extension>]
        member this.WithYAxisStyle(title,
                [<Optional;DefaultParameterValue(null)>] ?MinMax,
                [<Optional;DefaultParameterValue(null)>] ?ShowGrid,
                [<Optional;DefaultParameterValue(null)>] ?ShowLine,
                [<Optional;DefaultParameterValue(null)>] ?Side,
                [<Optional;DefaultParameterValue(null)>] ?Overlaying,
                [<Optional;DefaultParameterValue(null)>] ?Id,
                [<Optional;DefaultParameterValue(null)>] ?Domain,
                [<Optional;DefaultParameterValue(null)>] ?Position,
                [<Optional;DefaultParameterValue(null)>] ?ZeroLine,
                [<Optional;DefaultParameterValue(null)>] ?Anchor) =
            let range  = if MinMax.IsSome then Some (StyleParam.Range.MinMax (MinMax.Value)) else None
            let domain = if Domain.IsSome then Some (StyleParam.Range.MinMax (Domain.Value)) else None
            let yaxis  = LinearAxis.init(Title=title,?Range=range,?ShowGrid=ShowGrid,
                                    ?ShowLine=ShowLine,?Anchor=Anchor,?Side=Side,?Domain=domain,?Overlaying=Overlaying,?Position=Position,?ZeroLine=ZeroLine)
            this |> Chart.withYAxis(yaxis,?Id=Id)                


        // Sets z-Axis of 3d- Charts
        [<CompiledName("WithZAxis")>]
        [<Extension>]
        member this.WithZAxis(zAxis:LinearAxis, [<Optional;DefaultParameterValue(null)>] ?Id: StyleParam.SubPlotId) =
            this |> Chart.withZAxis(zAxis, ?Id=Id)
             


        // Sets z-Axis style with ...
        [<CompiledName("WithZAxisStyle")>]
        [<Extension>]
        member this.WithZAxisStyle(title,
                [<Optional;DefaultParameterValue(null)>] ?MinMax,
                [<Optional;DefaultParameterValue(null)>] ?ShowGrid,
                [<Optional;DefaultParameterValue(null)>] ?ShowLine,
                [<Optional;DefaultParameterValue(null)>] ?Domain,
                [<Optional;DefaultParameterValue(null)>] ?Anchor) =
            let range  = if MinMax.IsSome then Some (StyleParam.Range.MinMax (MinMax.Value)) else None
            let domain = if Domain.IsSome then Some (StyleParam.Range.MinMax (Domain.Value)) else None
            let zaxis  = LinearAxis.init(Title=title,?Range=range,?ShowGrid=ShowGrid,?ShowLine=ShowLine,?Anchor=Anchor,?Domain=domain)
            this |> Chart.withZAxis(zaxis)

        [<CompiledName("WithColorBar")>]
        [<Extension>]
        member this.withColorBar(colorbar:ColorBar) =
            this
            |> GenericChart.mapTrace(fun t ->
                colorbar |> DynObj.setValue t "colorbar" 
                t
            )

        [<CompiledName("WithColorbar")>]
        [<Extension>]
        member this.WithColorBarStyle(title,
                [<Optional;DefaultParameterValue(null)>] ?Length,
                [<Optional;DefaultParameterValue(null)>] ?OutlineColor,
                [<Optional;DefaultParameterValue(null)>] ?BorderColor,
                [<Optional;DefaultParameterValue(null)>] ?BGColor) =
            let colorbar = ColorBar.init(Title=title,?Len = Length,?OutlineColor=OutlineColor,?BGColor=BGColor,?BorderColor=BorderColor)
            this |> Chart.withColorBar(colorbar)
        
        // Set the Layout options of a Chart
        [<CompiledName("WithLayout")>]
        [<Extension>]
        member this.WithLayout(layout:Layout) =
            GenericChart.addLayout layout this

        // Set the LayoutGrid options of a Chart
        [<CompiledName("WithLayoutGrid")>]
        [<Extension>]
        member this.WithLayoutGrid(layoutGrid:LayoutGrid) =
            let layout = 
                GenericChart.getLayout this
                |> Layout.SetLayoutGrid layoutGrid 
            GenericChart.setLayout layout this

        // Set the LayoutGrid options of a Chart
        [<CompiledName("WithLegend")>]
        member this.WithLegend(legend:Legend) =
            let layout = 
                GenericChart.getLayout this
                |> Layout.setLegend legend 
            GenericChart.setLayout layout this

        /// Sets a map for the given chart (will only work with traces supporting geo, e.g. choropleth, scattergeo)
        [<CompiledName("WithMap")>]
        [<Extension>]
        member this.WithGeo(geo:Geo,[<Optional;DefaultParameterValue(null)>] ?Id:StyleParam.SubPlotId ) =
            this |> Chart.withGeo(geo, ?Id = Id)
            
        /// Sets a mapbox for the given chart (will only work with traces supporting mapboxes, e.g. choroplethmapbox, scattermapbox)
        [<CompiledName("WithMapbox")>]
        [<Extension>]
        member this.withMapbox(mapBox:Mapbox,[<Optional;DefaultParameterValue(null)>] ?Id: StyleParam.SubPlotId ) =
            this |> Chart.withMapbox(mapBox, ?Id = Id)
            

        /// Sets the map style for the given chart (will only work with traces supporting geo, e.g. choropleth, scattergeo)
        ///
        /// Parameters      :
        ///
        /// FitBounds       : Determines if and how this subplot's view settings are auto-computed to fit trace data
        ///
        /// Resolution      : Sets the resolution of the base layers
        ///
        /// Scope           : Set the scope of the map.
        ///
        /// Projection      : Determines the type of projection used to display the map
        ///
        /// Center          : Sets the (lon,lat) coordinates of the map's center. By default, the map's longitude center lies at the middle of the longitude range for scoped projection and above `projection.rotation.lon` otherwise. For all projection types, the map's latitude center lies at the middle of the latitude range by default.
        ///
        /// Visible         : Wether or not the base layers are visible
        ///
        /// Domain          : The domain of this geo subplot
        ///
        /// ShowCoastLine   : Sets whether or not the coastlines are drawn.
        ///
        /// CoastLineColor  : Sets the coastline color.
        ///
        /// CoastLineWidth  : Sets the coastline stroke width (in px).
        ///
        /// ShowLand        : Sets whether or not land masses are filled in color.
        ///
        /// LandColor       : Sets the land mass color.
        ///
        /// ShowOcean       : Sets whether or not oceans are filled in color.
        ///
        /// OceanColor      : Sets the ocean color
        ///
        /// ShowLakes       : Sets whether or not lakes are drawn.
        ///
        /// LakeColor       : Sets the color of the lakes.
        ///
        /// ShowRivers      : Sets whether or not rivers are drawn.
        ///
        /// RiverColor      : Sets color of the rivers.
        ///
        /// RiverWidth      : Sets the stroke width (in px) of the rivers.
        ///
        /// ShowCountries   : Sets whether or not country boundaries are drawn.
        ///
        /// CountryColor    : Sets line color of the country boundaries.
        ///
        /// CountryWidth    : Sets line width (in px) of the country boundaries.
        ///
        /// ShowSubunits    : Sets whether or not boundaries of subunits within countries (e.g. states, provinces) are drawn.
        ///
        /// SubunitColor    : Sets the color of the subunits boundaries.
        ///
        /// SubunitWidth    : Sets the stroke width (in px) of the subunits boundaries.
        ///
        /// ShowFrame       : Sets whether or not a frame is drawn around the map.
        ///
        /// FrameColor      : Sets the color the frame.
        ///
        /// FrameWidth      : Sets the stroke width (in px) of the frame.
        ///
        /// BgColor         : Set the background color of the map
        ///
        /// LatAxis         : Sets the latitudinal axis for this geo trace
        ///
        /// LonAxis         : Sets the longitudinal axis for this geo trace
        [<CompiledName("WithGeoStyle")>]
        [<Extension>]
        member this.WithGeoStyle([<Optional;DefaultParameterValue(null)>] ?Id : StyleParam.SubPlotId,
            [<Optional;DefaultParameterValue(null)>]?FitBounds       : StyleParam.GeoFitBounds,
            [<Optional;DefaultParameterValue(null)>]?Resolution      : StyleParam.GeoResolution,
            [<Optional;DefaultParameterValue(null)>]?Scope           : StyleParam.GeoScope,
            [<Optional;DefaultParameterValue(null)>]?Projection      : GeoProjection,
            [<Optional;DefaultParameterValue(null)>]?Center          : (float*float),
            [<Optional;DefaultParameterValue(null)>]?Visible         : bool,
            [<Optional;DefaultParameterValue(null)>]?Domain          : Domain,
            [<Optional;DefaultParameterValue(null)>]?ShowCoastLines  : bool,
            [<Optional;DefaultParameterValue(null)>]?CoastLineColor,
            [<Optional;DefaultParameterValue(null)>]?CoastLineWidth  : float,
            [<Optional;DefaultParameterValue(null)>]?ShowLand        : bool,
            [<Optional;DefaultParameterValue(null)>]?LandColor,
            [<Optional;DefaultParameterValue(null)>]?ShowOcean       : bool,
            [<Optional;DefaultParameterValue(null)>]?OceanColor,
            [<Optional;DefaultParameterValue(null)>]?ShowLakes       : bool,
            [<Optional;DefaultParameterValue(null)>]?LakeColor,
            [<Optional;DefaultParameterValue(null)>]?ShowRivers      : bool,
            [<Optional;DefaultParameterValue(null)>]?RiverColor,
            [<Optional;DefaultParameterValue(null)>]?RiverWidth      : float,
            [<Optional;DefaultParameterValue(null)>]?ShowCountries   : bool,
            [<Optional;DefaultParameterValue(null)>]?CountryColor,
            [<Optional;DefaultParameterValue(null)>]?CountryWidth    : float,
            [<Optional;DefaultParameterValue(null)>]?ShowSubunits    : bool,
            [<Optional;DefaultParameterValue(null)>]?SubunitColor,
            [<Optional;DefaultParameterValue(null)>]?SubunitWidth    : float,
            [<Optional;DefaultParameterValue(null)>]?ShowFrame       : bool,
            [<Optional;DefaultParameterValue(null)>]?FrameColor,
            [<Optional;DefaultParameterValue(null)>]?FrameWidth      : float,
            [<Optional;DefaultParameterValue(null)>]?BgColor,
            [<Optional;DefaultParameterValue(null)>]?LatAxis         : LinearAxis,
            [<Optional;DefaultParameterValue(null)>]?LonAxis         : LinearAxis
        ) =
            this 
            |> Chart.withGeoStyle(
                ?FitBounds      = FitBounds     ,
                ?Resolution     = Resolution    ,
                ?Scope          = Scope         ,
                ?Projection     = Projection    ,
                ?Center         = Center        ,
                ?Visible        = Visible       ,
                ?Domain         = Domain        ,
                ?ShowCoastLines = ShowCoastLines,
                ?CoastLineColor = CoastLineColor,
                ?CoastLineWidth = CoastLineWidth,
                ?ShowLand       = ShowLand      ,
                ?LandColor      = LandColor     ,
                ?ShowOcean      = ShowOcean     ,
                ?OceanColor     = OceanColor    ,
                ?ShowLakes      = ShowLakes     ,
                ?LakeColor      = LakeColor     ,
                ?ShowRivers     = ShowRivers    ,
                ?RiverColor     = RiverColor    ,
                ?RiverWidth     = RiverWidth    ,
                ?ShowCountries  = ShowCountries ,
                ?CountryColor   = CountryColor  ,
                ?CountryWidth   = CountryWidth  ,
                ?ShowSubunits   = ShowSubunits  ,
                ?SubunitColor   = SubunitColor  ,
                ?SubunitWidth   = SubunitWidth  ,
                ?ShowFrame      = ShowFrame     ,
                ?FrameColor     = FrameColor    ,
                ?FrameWidth     = FrameWidth    ,
                ?BgColor        = BgColor       ,
                ?LatAxis        = LatAxis       ,
                ?LonAxis        = LonAxis       
            )

        [<CompiledName("WithGeoProjection")>]
        [<Extension>]
        member this.WithMapProjection(projectionType : StyleParam.GeoProjectionType,
             [<Optional;DefaultParameterValue(null)>]?Rotation ,
             [<Optional;DefaultParameterValue(null)>]?Parallels,
             [<Optional;DefaultParameterValue(null)>]?Scale    ,
             [<Optional;DefaultParameterValue(null)>]?Id
            ) =
                this 
                |> Chart.withGeoProjection(
                    projectionType  = projectionType,
                    ?Rotation       = Rotation      ,
                    ?Parallels      = Parallels     ,
                    ?Scale          = Scale        
                )
            

        // Set the LayoutGrid options of a Chart
        [<CompiledName("WithLayoutGridStyle")>]
        [<Extension>]
        member this.WithLayoutGridStyle([<Optional;DefaultParameterValue(null)>]?SubPlots   : (StyleParam.LinearAxisId * StyleParam.LinearAxisId)[] [],
            [<Optional;DefaultParameterValue(null)>]?XAxes      : StyleParam.LinearAxisId [],
            [<Optional;DefaultParameterValue(null)>]?YAxes      : StyleParam.LinearAxisId [],
            [<Optional;DefaultParameterValue(null)>]?Rows       : int,
            [<Optional;DefaultParameterValue(null)>]?Columns    : int,
            [<Optional;DefaultParameterValue(null)>]?RowOrder   : StyleParam.LayoutGridRowOrder,
            [<Optional;DefaultParameterValue(null)>]?Pattern    : StyleParam.LayoutGridPattern,
            [<Optional;DefaultParameterValue(null)>]?XGap       : float,
            [<Optional;DefaultParameterValue(null)>]?YGap       : float,
            [<Optional;DefaultParameterValue(null)>]?Domain     : Domain,
            [<Optional;DefaultParameterValue(null)>]?XSide      : StyleParam.LayoutGridXSide,
            [<Optional;DefaultParameterValue(null)>]?YSide      : StyleParam.LayoutGridYSide
        ) =

                let layout = GenericChart.getLayout this in
                let updatedGrid =   
                    let currentGrid = 
                        match layout.TryGetTypedValue<LayoutGrid> "grid" with
                        | Some grid -> grid
                        | None -> LayoutGrid()
                    currentGrid
                    |> LayoutGrid.style(
                        ?SubPlots    = SubPlots,
                        ?XAxes       = XAxes   ,
                        ?YAxes       = YAxes   ,
                        ?Rows        = Rows    ,
                        ?Columns     = Columns ,
                        ?RowOrder    = RowOrder,
                        ?Pattern     = Pattern ,
                        ?XGap        = XGap    ,
                        ?YGap        = YGap    ,
                        ?Domain      = Domain  ,
                        ?XSide       = XSide   ,
                        ?YSide       = YSide   
                    ) in
                let updatedLayout = layout |> Layout.SetLayoutGrid updatedGrid in
                GenericChart.setLayout updatedLayout this

        [<CompiledName("WithConfig")>]
        [<Extension>]
        member this.WithConfig (config:Config) =
            GenericChart.setConfig config this

        [<CompiledName("WithAnnotation")>]
        [<Extension>]
        member this.WithAnnotation(annotation:Annotation, [<Optional;DefaultParameterValue(true)>]?Append:bool) =
            this |> Chart.withAnnotation(annotation, ?Append = Append)

        [<CompiledName("WithAnnotations")>]
        [<Extension>]
        member this.WithAnnotations(annotations:Annotation seq, [<Optional;DefaultParameterValue(true)>]?Append:bool) =
            this |> Chart.withAnnotations(annotations, ?Append = Append)

        // Set the title of a Chart
        [<CompiledName("WithTitle")>]
        [<Extension>]
        member this.WithTitle(title,[<Optional;DefaultParameterValue(null)>] ?TitleFont) =
            let layout =
                Layout() 
                |> Layout.style(
                    Title=
                        Title.init(
                            Text = title,
                            ?Font = TitleFont
                        )
                )
            GenericChart.addLayout layout this

        // Set showLegend of a Chart
        [<CompiledName("WithLegend")>]
        [<Extension>]
        member this.WithLegend(showlegend) =
            let layout =
                Layout() 
                |> Layout.style(ShowLegend=showlegend)
            GenericChart.addLayout layout this

        // Set the size of a Chart
        [<CompiledName("WithSize")>]
        [<Extension>]
        member this.WithSize(width,height) =
            let layout = 
                GenericChart.getLayout this
                |> Layout.style (Width=width,Height=height)
            GenericChart.setLayout layout this
            
        // Set the margin of a Chart
        [<CompiledName("WithMargin")>]
        [<Extension>]
        member this.WithMargin(margin:Margin) =
            let layout =
                GenericChart.getLayout this 
                |> Layout.style (Margin=margin)
            GenericChart.setLayout layout this

        // Set the margin of a Chart
        [<CompiledName("WithMarginSize")>]
        [<Extension>]
        member this.WithMarginSize
            (
                [<Optional;DefaultParameterValue(null)>] ?Left,
                [<Optional;DefaultParameterValue(null)>] ?Right,
                [<Optional;DefaultParameterValue(null)>] ?Top,
                [<Optional;DefaultParameterValue(null)>] ?Bottom,
                [<Optional;DefaultParameterValue(null)>] ?Pad,
                [<Optional;DefaultParameterValue(null)>] ?Autoexpand
            ) =                       
                let margin = 
                    Margin.init ( ?Left=Left,?Right=Right,?Top=Top,?Bottom=Bottom,?Pad=Pad,?Autoexpand=Autoexpand )
                this |> Chart.withMargin(margin)

        [<CompiledName("WithTemplate")>]
        [<Extension>]
        member this.WithTemplate(template: Template) =
            this
            |> GenericChart.mapLayout (fun l ->
                template |> DynObj.setValue l "template"
                l
            )

        // TODO: Include withLegend & withLegendStyle

            //Specifies the shape type to be drawn. If "line", a line is drawn from (`x0`,`y0`) to (`x1`,`y1`) If "circle", a circle is drawn from 
            //((`x0`+`x1`)/2, (`y0`+`y1`)/2)) with radius (|(`x0`+`x1`)/2 - `x0`|, |(`y0`+`y1`)/2 -`y0`)|) If "rect", a rectangle is drawn linking 
            //(`x0`,`y0`), (`x1`,`y0`), (`x1`,`y1`), (`x0`,`y1`), (`x0`,`y0`)  
        [<CompiledName("WithShape")>]
        [<Extension>]
        member this.WithShape(shape:Shape, [<Optional;DefaultParameterValue(true)>]?Append:bool) =
            this |> Chart.withShape(shape, ?Append = Append)

        [<CompiledName("WithShapes")>]
        [<Extension>]
        member this.WithShapes(shapes:Shape seq, [<Optional;DefaultParameterValue(true)>]?Append:bool) =
            this |> Chart.withShapes(shapes, ?Append = Append)

        // ############################################################
        // ####################### Apply to DisplayOptions
        
        /// Show chart in browser
        [<CompiledName("WithDescription")>]
        [<Extension>]
        member this.WithDescription (description:ChartDescription) = 
            this |> Chart.withDescription description

        /// Adds the given additional script tags on the chart's DisplayOptions. They will be included in the document's <head>
        [<CompiledName("WithAdditionalHeadTags")>]
        [<Extension>]
        member this.WithAdditionalHeadTags (additionalHeadTags:seq<string>) = 
            this |> Chart.withAdditionalHeadTags additionalHeadTags

        /// Sets the given additional script tags on the chart's DisplayOptions. They will be included in the document's <head>
        [<CompiledName("WithHeadTags")>]
        [<Extension>]
        member this.WithHeadTags (headTags:seq<string>) = 
            this |> Chart.withHeadTags headTags
        
        /// Adds the necessary script tags to render tex strings to the chart's DisplayOptions
        [<CompiledName("WithMathTex")>]
        [<Extension>]
        member this.WithMathTex([<Optional;DefaultParameterValue(true)>]?AppendTags:bool) =
            let append = Option.defaultValue true AppendTags
            this |> Chart.withMathTex(append)


        /// Save chart as html single page
        [<CompiledName("SaveHtmlAs")>]
        [<Extension>]
        member this.SaveHtmlAs (pathName:string, [<Optional;DefaultParameterValue(null)>] ?Verbose) =
            Chart.saveHtmlAs pathName this

        /// Show chart in browser
        [<CompiledName("Show")>]
        [<Extension>]
        member this.Show() = this |> Chart.show

        /// Show chart in browser
        [<CompiledName("ShowAsImage")>]
        [<Extension>]
        member this.ShowAsImage (format:StyleParam.ImageFormat) = 
            this |> Chart.showAsImage format

        /// Sets the polar object with the given id on the chart layout
        [<CompiledName("WithPolar")>]
        member this.WithPolar(polar:Polar, [<Optional;DefaultParameterValue(null)>] ?Id) =
            this |> Chart.withPolar(polar,?Id=Id)

        /// Sets the angular axis of the polar object with the given id on the chart layout
        [<CompiledName("WithAngularAxis")>]
        member this.WithAngularAxis(angularAxis:AngularAxis, [<Optional;DefaultParameterValue(null)>] ?Id) =
            this |> Chart.withAngularAxis(angularAxis,?Id=Id)
            
        /// Sets the radial axis of the polar object with the given id on the chart layout
        [<CompiledName("WithRadialAxis")>]
        member this.WithRadialAxis(radialAxis:RadialAxis, [<Optional;DefaultParameterValue(null)>] ?Id) =
            this |> Chart.withRadialAxis(radialAxis,?Id=Id)

        /// Sets the color axis of the color axis with the given id on the chart layout
        [<CompiledName("WithColorAxis")>]
        member this.WithColorAxis(colorAxis:ColorAxis, [<Optional;DefaultParameterValue(null)>] ?Id) =
            this |> Chart.withColorAxis(colorAxis,?Id=Id)

        /// Sets the scene object with the given id on the chart layout
        [<CompiledName("WithScene")>]
        member this.WithScene(scene:Scene, [<Optional;DefaultParameterValue(null)>] ?Id) =
            this |> Chart.withScene(scene,?Id=Id)

        /// Sets the scene object with the given id on the chart layout
        [<CompiledName("WithTernary")>]
        member this.WithTernary(ternary:Ternary, [<Optional;DefaultParameterValue(null)>] ?Id) =
            this |> Chart.withTernary(ternary,?Id=Id)

    
        [<CompiledName("WithLayoutImage")>]
        [<Extension>]
        member this.WithLayoutImage(image:LayoutImage, [<Optional;DefaultParameterValue(true)>]?Append:bool) =
            this |> Chart.withLayoutImage(image, ?Append = Append)

        [<CompiledName("WithLayoutImages")>]
        [<Extension>]
        member this.WithLayoutImages(images:seq<LayoutImage>, [<Optional;DefaultParameterValue(true)>]?Append:bool) =
            this |> Chart.withLayoutImages(images, ?Append = Append)