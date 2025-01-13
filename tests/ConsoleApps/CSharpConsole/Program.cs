using System;
using Plotly.NET.CSharp;
using static Plotly.NET.StyleParam;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Chart.Grid(
            //    nRows: 10,
            //    nCols: 7,
            //    gCharts:
            //        new Plotly.NET.GenericChart[]
            //        {
            //            //2D basic traces

            //            //simple scatter derived
            //            Chart.Combine(
            //                new Plotly.NET.GenericChart []
            //                {
            //                    Chart.Scatter<int, int, int>(
            //                        x: new int [] { 1, 2, 3 },
            //                        y: new int [] { 5, 3, 4 },
            //                        mode: Mode.Markers,
            //                        Name: "scatter",
            //                        MultiText: new int [] { 3, 4 }
            //                    ),
            //                    Chart.Point<int,int,string>(
            //                        x: new int [] { 1, 2, 3 },
            //                        y: new int [] { 6, 4, 5 },
            //                        Name: "point",
            //                        Text: "hi"
            //                    ),
            //                    Chart.Line<int,int,string>(
            //                        x: new int [] { 1, 2, 3 },
            //                        y: new int [] { 7, 5, 6 },
            //                        Name: "line"
            //                    ),
            //                    Chart.Spline<int,int,string>(
            //                        x: new int [] { 1, 2, 3},
            //                        y: new int [] { 8, 6, 7 },
            //                        Name: "spline"
            //                    ),
            //                    Chart.Bubble<int,int,string>(
            //                        x: new int [] { 1, 2, 3 },
            //                        y: new int [] { 9, 7, 8 },
            //                        sizes: new int [] { 10, 20, 30 },
            //                        Name: "bubble"
            //                    )
            //                }
            //            ).WithTraceInfo(
            //                LegendGroup: "simple-scatter-derived",
            //                LegendGroupTitle: Plotly.NET.Title.init("simple scatter-derived traces", Font: Plotly.NET.Font.init(Size: 20))
            //            ),

            //            //extended scatter derived
            //            Chart.Combine(
            //                new Plotly.NET.GenericChart []
            //                {
            //                    Chart.Range<int, int, string>(
            //                        x: new int [] { 1, 2, 3 },
            //                        y: new int [] { 5, 3, 4 },
            //                        upper: new int [] { 6, 4, 5 },
            //                        lower: new int [] { 4, 2, 3 },
            //                        mode: Mode.Lines,
            //                        Name: "range"
            //                    ),
            //                    Chart.Area<int,int,string>(
            //                        x: new int [] { 1, 2},
            //                        y: new int [] { 3, 1},
            //                        Name: "area"
            //                    ),
            //                    Chart.SplineArea<int,int,string>(
            //                        x: new int [] { 3, 4, 5},
            //                        y: new int [] { 3, 1, 4},
            //                        Name: "splinearea"
            //                    ),
            //                    Chart.StackedArea<int,int,string>(
            //                        x: new int [] { 6, 7},
            //                        y: new int [] { 3, 1},
            //                        Name: "stacked area 1"
            //                    ),
            //                    Chart.StackedArea<int,int,string>(
            //                        x: new int [] { 6, 7},
            //                        y: new int [] { 3, 2},
            //                        Name: "stacked area 2"
            //                    )
            //                }
            //            ).WithTraceInfo(
            //                LegendGroup: "extended-scatter-derived",
            //                LegendGroupTitle: Plotly.NET.Title.init("extended scatter-derived traces", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.Combine(
            //                new Plotly.NET.GenericChart []
            //                {
            //                    Chart.Bar<int,string,string>(
            //                        values: new int [] { 1,2 },
            //                        Keys: new string [] { "first", "second"},
            //                        Name: "bar"
            //                    ),
            //                    Chart.StackedBar<int,string,string>(
            //                        values: new int [] { 1,2 },
            //                        Keys: new string [] { "third", "4th"},
            //                        Name: "stacked bar 1"
            //                    ),
            //                    Chart.StackedBar<int,string,string>(
            //                        values: new int [] { 1,2 },
            //                        Keys: new string [] { "third", "4th"},
            //                        Name: "stacked bar 2"
            //                    ),
            //                }
            //            ).WithTraceInfo(
            //                LegendGroup: "bar-and-derived-traces",
            //                LegendGroupTitle: Plotly.NET.Title.init("bar and derived traces", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.Combine(
            //                new Plotly.NET.GenericChart []
            //                {
            //                    Chart.Column<int,string,string>(
            //                        values: new int [] { 3,4 },
            //                        Keys: new string [] { "first", "second"},
            //                        Name: "column"
            //                    ),
            //                    Chart.StackedColumn<int,string,string>(
            //                        values: new int [] { 1,2 },
            //                        Keys: new string [] { "third", "4th"},
            //                        Name: "stacked column 1"
            //                    ),
            //                    Chart.StackedColumn<int,string,string>(
            //                        values: new int [] { 1,2 },
            //                        Keys: new string [] { "third", "4th"},
            //                        Name: "stacked column 2"
            //                    ),
            //                }
            //            ).WithTraceInfo(
            //                LegendGroup: "bar-and-derived-traces",
            //                LegendGroupTitle: Plotly.NET.Title.init("bar and derived traces", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.Heatmap<int, int, int, string>(
            //                zData: new int [] []
            //                {
            //                    new int [] { 1,2,3},
            //                    new int [] { 2,1,2},
            //                    new int [] { 3,2,1}
            //                },
            //                ShowScale: false,
            //                Name: "heatmap",
            //                ShowLegend: true
            //            ).WithTraceInfo(
            //                LegendGroup: "other-simple-2D",
            //                LegendGroupTitle: Plotly.NET.Title.init("other simple 2D traces", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.Image<string>(
            //                Source: @"data:image/gif;base64,R0lGODdhEAAQAMwAAPj7+FmhUYjNfGuxYYDJdYTIeanOpT+DOTuANXi/bGOrWj6CONzv2sPjv2CmV1unU4zPgI/Sg6DJnJ3ImTh8Mtbs00aNP1CZSGy0YqLEn47RgXW8amasW7XWsmmvX2iuXiwAAAAAEAAQAAAFVyAgjmRpnihqGCkpDQPbGkNUOFk6DZqgHCNGg2T4QAQBoIiRSAwBE4VA4FACKgkB5NGReASFZEmxsQ0whPDi9BiACYQAInXhwOUtgCUQoORFCGt/g4QAIQA7"
            //            ).WithTraceInfo(
            //                LegendGroup: "other-simple-2D",
            //                LegendGroupTitle: Plotly.NET.Title.init("other simple 2D traces", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.Invisible(),

            //            //2D distributions
            //            Chart.Histogram<int,int,int>(
            //                X: new int [] { 1,2,2,2,3,4,5,5 },
            //                MultiText: new int [] { 1,2,3,4,5,6,7},
            //                Name: "histogram"
            //            ).WithTraceInfo(
            //                LegendGroup: "scientific",
            //                LegendGroupTitle: Plotly.NET.Title.init("scientific/2D distributions", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.Histogram2D<int,int,int>(
            //               x: new int [] { 1,2,2,2,3,4,5,5 },
            //               y: new int [] { 1,2,2,2,3,4,5,5 },
            //               ShowScale: false,
            //               ShowLegend: true,
            //               Name: "histogram2D"
            //            ).WithTraceInfo(
            //                LegendGroup: "scientific",
            //                LegendGroupTitle: Plotly.NET.Title.init("scientific/2D distributions", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.Combine(
            //                new Plotly.NET.GenericChart []
            //                {
            //                    Chart.BoxPlot<int,int,string>(
            //                        X: new int [] { 1,2,2,2,3,4,5,5 },
            //                        Name: "Boxplot"
            //                    ),
            //                    Chart.Violin<int,int,string>(
            //                        X: new int [] { 1,2,2,2,3,4,5,5 },
            //                        Name: "Violin"
            //                    ),
            //                }
            //            ).WithTraceInfo(
            //                LegendGroup: "scientific",
            //                LegendGroupTitle: Plotly.NET.Title.init("scientific/2D distributions", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.Contour<int,int,int,string>(
            //                zData: new int [] []
            //                {
            //                    new int [] { 1,2,3},
            //                    new int [] { 2,1,2},
            //                    new int [] { 3,2,1}
            //                },
            //               ShowScale: false,
            //               ShowLegend: true,
            //               Name: "contour"
            //            ).WithTraceInfo(
            //                LegendGroup: "scientific",
            //                LegendGroupTitle: Plotly.NET.Title.init("scientific/2D distributions", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.Histogram2DContour<int,int,int>(
            //               x: new int [] { 1,2,2,2,3,4,5,5 },
            //               y: new int [] { 1,2,2,2,3,4,5,5 },
            //               ShowScale: false,
            //               ShowLegend: true,
            //               Name: "histogram2Dcontour"
            //            ).WithTraceInfo(
            //                LegendGroup: "scientific",
            //                LegendGroupTitle: Plotly.NET.Title.init("scientific/2D distributions", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.PointDensity<int,int>(
            //               x: new int [] { 1,2,2,2,3,4,5,5 },
            //               y: new int [] { 1,2,2,2,3,4,5,5 },
            //               ShowScale: false
            //            ).WithTraceInfo(
            //                LegendGroup: "scientific",
            //                LegendGroupTitle: Plotly.NET.Title.init("scientific/2D distributions", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.Invisible(),

            //            //2D Finance traces
            //            Chart.OHLC<double,DateTime,string>(
            //                open: new double [] {1.2, 2.7},
            //                high: new double [] {1.8, 8.5},
            //                low: new double []  {0.5, 0.1},
            //                close: new double [] {1.1, 2.9},
            //                x: new DateTime [] {DateTime.Parse("07/07/2021"), DateTime.Parse("07/07/2022") },
            //                Name: "ohlc"
            //            ).WithXAxisRangeSlider(
            //                rangeSlider: Plotly.NET.LayoutObjects.RangeSlider.init(
            //                Visible: false
            //            )).WithTraceInfo(
            //                LegendGroup: "finance",
            //                LegendGroupTitle: Plotly.NET.Title.init("finance charts", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.Candlestick<double,DateTime,string>(
            //                open: new double [] {1.2, 2.7},
            //                high: new double [] {1.8, 8.5},
            //                low: new double []  {0.5, 0.1},
            //                close: new double [] {1.1, 2.9},
            //                x: new DateTime [] {DateTime.Parse("07/07/2021"), DateTime.Parse("07/07/2022") },
            //                Name: "candlestick"
            //            ).WithXAxisRangeSlider(
            //                rangeSlider: Plotly.NET.LayoutObjects.RangeSlider.init(
            //                    Visible: false
            //            )).WithTraceInfo(
            //                LegendGroup: "finance",
            //                LegendGroupTitle: Plotly.NET.Title.init("finance charts", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.Waterfall<string, int, string>(
            //                x: new string [] {"A", "B", "Net", "Purch", "Other", "Profit"},
            //                y: new int [] {60, 80, 0, -40, -20, 0},
            //                Measure: new Plotly.NET.StyleParam.WaterfallMeasure [] {
            //                    Plotly.NET.StyleParam.WaterfallMeasure.Relative,
            //                    Plotly.NET.StyleParam.WaterfallMeasure.Relative,
            //                    Plotly.NET.StyleParam.WaterfallMeasure.Total,
            //                    Plotly.NET.StyleParam.WaterfallMeasure.Relative,
            //                    Plotly.NET.StyleParam.WaterfallMeasure.Relative,
            //                    Plotly.NET.StyleParam.WaterfallMeasure.Total
            //                },
            //                Name: "waterfall"
            //            ).WithTraceInfo(
            //                LegendGroup: "finance",
            //                LegendGroupTitle: Plotly.NET.Title.init("finance charts", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.Funnel<double, string, string>(
            //                x: new double [] { 1200, 909.4, 600.6, 300, 80 },
            //                y: new string[] { "A", "B", "C", "D", "E"},
            //                Name: "funnel"
            //            ).WithTraceInfo(
            //                LegendGroup: "finance",
            //                LegendGroupTitle: Plotly.NET.Title.init("finance charts", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.Combine(
            //                new Plotly.NET.GenericChart []
            //                {
            //                    Chart.StackedFunnel<double, string, string>(
            //                        x: new double [] { 1200, 909.4},
            //                        y: new string[] { "A", "B"},
            //                        Name: "stackedfunnel 1"
            //                    ),
            //                    Chart.StackedFunnel<double, string, string>(
            //                        x: new double [] { 1200, 100.4,},
            //                        y: new string[] { "A", "B"},
            //                        Name: "stackedfunnel 2"
            //                    ),
            //                }
            //            ).WithTraceInfo(
            //                LegendGroup: "finance",
            //                LegendGroupTitle: Plotly.NET.Title.init("finance charts", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.FunnelArea<int, string, string>(
            //                values: new int [] { 5, 4},
            //                MultiText: new string[] { "A", "B"},
            //                Name: "funnelarea"
            //            ).WithTraceInfo(
            //                LegendGroup: "finance",
            //                LegendGroupTitle: Plotly.NET.Title.init("finance charts", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.Indicator<double>(
            //                value: 200,
            //                mode: Plotly.NET.StyleParam.IndicatorMode.NumberDeltaGauge,
            //                DeltaReference: 160,
            //                Name: "indicator"
            //            ).WithTraceInfo(
            //                LegendGroup: "finance",
            //                LegendGroupTitle: Plotly.NET.Title.init("finance charts", Font: Plotly.NET.Font.init(Size: 20))
            //            ),

            //            //3D traces
            //            Chart.Combine(
            //                new Plotly.NET.GenericChart []
            //                {
            //                    Chart.Scatter3D<int,int,int,string>(
            //                        x: new int[] { 1, 2 },
            //                        y: new int [] { 13, 14 },
            //                        z: new int [] { 14, 15 },
            //                        mode: Mode.Markers,
            //                        Name: "scatter3D"
            //                    ),
            //                    Chart.Point3D<int,int,int,string>(
            //                        x: new int[] { 3, 4 },
            //                        y: new int [] { 13, 14 },
            //                        z: new int [] { 14, 15 },
            //                        Name: "point3D"
            //                    ),
            //                    Chart.Line3D<int,int,int,string>(
            //                        x: new int[] { 5, 6 },
            //                        y: new int [] { 13, 14 },
            //                        z: new int [] { 14, 15 },
            //                        Name: "line3D"
            //                    ),
            //                    Chart.Bubble3D<int,int,int,string>(
            //                        x: new int[] { 7, 8 },
            //                        y: new int [] { 13, 14 },
            //                        z: new int [] { 14, 15 },
            //                        sizes: new int [] {30, 40},
            //                        Name: "bubble3D"
            //                    ),
            //                }
            //            ).WithTraceInfo(
            //                LegendGroup: "3D-scatter-derived",
            //                LegendGroupTitle: Plotly.NET.Title.init("3D scatter-derived traces", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.Surface<int,int,int,string>(
            //                zData: new int [] []
            //                {
            //                    new int [] { 1, 2, 1 },
            //                    new int [] { 1, 5, 1 },
            //                    new int [] { 1, 2, 1 }
            //                },
            //                ShowScale: false,
            //                Name: "surface",
            //                ShowLegend: true
            //            ).WithTraceInfo(
            //                LegendGroup: "3D-other",
            //                LegendGroupTitle: Plotly.NET.Title.init("other 3D charts", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.Mesh3D<int,int,int,int,int,int,string>(
            //                x: new int [] { 0, 1, 2, 0 },
            //                y: new int [] { 0, 0, 1, 2 },
            //                z: new int [] { 0, 2, 0, 1 },
            //                ShowScale: false,
            //                Name: "mesh3D",
            //                ShowLegend: true
            //            ),
            //            Chart.Cone<int,int,int,int,int,int,string>(
            //                x: new int [] { 0, 1, 2, 0 },
            //                y: new int [] { 0, 0, 1, 2 },
            //                z: new int [] { 0, 2, 0, 1 },
            //                u: new int [] { 0, 1, 2, 0 },
            //                v: new int [] { 0, 0, 1, 2 },
            //                w: new int [] { 0, 2, 0, 1 },
            //                ShowScale: false,
            //                Name: "cone",
            //                ShowLegend: true
            //            ),
            //            Chart.StreamTube<int,int,int,int,int,int,string>(
            //                x: new int [] { 0, 0, 0 },
            //                y: new int [] { 0, 1, 2},
            //                z: new int [] { 0, 0, 0},
            //                u: new int [] { 0, 0, 0},
            //                v: new int [] { 1, 1, 1},
            //                w: new int [] { 0, 0, 0},
            //                ShowScale: false,
            //                Name: "streamtube",
            //                ShowLegend: true
            //            ),
            //            Chart.Volume<double,double,double,double,string,double>(
            //                x: new double [] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1.5, 1.5, 1.5, 1.5, 1.5, 1.5, 1.5, 1.5, 1.5, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
            //                y: new double [] { 1, 1, 1, 1.5, 1.5, 1.5, 2, 2, 2, 1, 1, 1, 1.5, 1.5, 1.5, 2, 2, 2, 1, 1, 1, 1.5, 1.5, 1.5, 2, 2, 2 },
            //                z: new double [] { 1, 1.5, 2, 1, 1.5, 2, 1, 1.5, 2, 1, 1.5, 2, 1, 1.5, 2, 1, 1.5, 2, 1, 1.5, 2, 1, 1.5, 2, 1, 1.5, 2},
            //                value: new double [] { 0.8414709848, 0.6649966577, 0.4546487134, 0.6649966577, 0.3458103097,04704000269, 0.4546487134, 04704000269, -0.1892006238, 0.6649966577, 0.3458103097, 04704000269, 0.3458103097, -06853149997, -0.217228915,04704000269, -0.217228915, -0465692497, 0.4546487134, 04704000269,-0.1892006238, 04704000269, -0.217228915, -0465692497, -0.1892006238,-0465692497, 0.1236697808},
            //                ShowScale: false,
            //                Name: "volume",
            //                ShowLegend: true
            //            ),
            //            Chart.IsoSurface<double,double,double,double,string>(
            //                x: new double [] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1.5, 1.5, 1.5, 1.5, 1.5, 1.5, 1.5, 1.5, 1.5, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
            //                y: new double [] { 1, 1, 1, 1.5, 1.5, 1.5, 2, 2, 2, 1, 1, 1, 1.5, 1.5, 1.5, 2, 2, 2, 1, 1, 1, 1.5, 1.5, 1.5, 2, 2, 2 },
            //                z: new double [] { 1, 1.5, 2, 1, 1.5, 2, 1, 1.5, 2, 1, 1.5, 2, 1, 1.5, 2, 1, 1.5, 2, 1, 1.5, 2, 1, 1.5, 2, 1, 1.5, 2},
            //                value: new double [] { 0.8414709848, 0.6649966577, 0.4546487134, 0.6649966577, 0.3458103097,04704000269, 0.4546487134, 04704000269, -0.1892006238, 0.6649966577, 0.3458103097, 04704000269, 0.3458103097, -06853149997, -0.217228915,04704000269, -0.217228915, -0465692497, 0.4546487134, 04704000269,-0.1892006238, 04704000269, -0.217228915, -0465692497, -0.1892006238,-0465692497, 0.1236697808},
            //                ShowScale: false,
            //                Name: "isosurface",
            //                ShowLegend: true
            //            ),

            //            //polar traces
            //            Chart.ScatterPolar<int,int,string>(
            //                theta: new int [] { 0, 90, 180, 270 },
            //                r: new int [] { 10, 20, 15, 20 },
            //                mode: Mode.Markers,
            //                Name: "scatterpolar"
            //            ),
            //            Chart.PointPolar<int,int,string>(
            //                theta: new int [] { 0, 90, 180, 270 },
            //                r: new int [] { 10, 20, 15, 20 },
            //                Name: "pointpolar"
            //            ),
            //            Chart.LinePolar<int,int,string>(
            //                theta: new int [] { 0, 90, 180, 270 },
            //                r: new int [] { 10, 20, 15, 20 },
            //                Name: "linepolar"
            //            ),
            //            Chart.SplinePolar<int,int,string>(
            //                theta: new int [] { 0, 90, 180, 270 },
            //                r: new int [] { 10, 20, 15, 20 },
            //                Name: "splinepolar"
            //            ),
            //            Chart.BubblePolar<int,int,string>(
            //                theta: new int [] { 0, 90, 180, 270 },
            //                r: new int [] { 10, 20, 15, 20 },
            //                sizes: new int [] { 10, 30, 15, 40 },
            //                Name: "bubblepolar"
            //            ),
            //            Chart.BarPolar<int,int,string>(
            //                theta: new int [] { 0, 90, 180, 270 },
            //                r: new int [] { 10, 20, 15, 20 },
            //                Name: "barpolar"
            //            ),
            //            Chart.Invisible(),

            //            //geo/mapbox traces
            //            Chart.Combine(
            //                new Plotly.NET.GenericChart []
            //                {
            //                    Chart.ScatterGeo<int,int,string>(
            //                        longitudes: new int [] { 1, 20 },
            //                        latitudes: new int [] { 1, 40 },
            //                        mode: Mode.Markers,
            //                        Name: "scattergeo"
            //                    ),
            //                    Chart.PointGeo<int,int,string>(
            //                        longitudes: new int [] { 40, 50 },
            //                        latitudes: new int [] { 60, 70 },
            //                        Name: "pointgeo"
            //                    ),
            //                    Chart.LineGeo<int,int,string>(
            //                        longitudes: new int [] { 10,  -100},
            //                        latitudes: new int [] { 50, 50 },
            //                        Name: "linegeo"
            //                    ),
            //                    Chart.BubbleGeo<int,int,string>(
            //                        longitudes: new int [] { 80,  -80},
            //                        latitudes: new int [] { 20, -20 },
            //                        sizes: new int [] { 10, 20 },
            //                        Name: "bubblegeo"
            //                    ),
            //                }
            //            ).WithTraceInfo(
            //                LegendGroup: "scattergeo-derived",
            //                LegendGroupTitle: Plotly.NET.Title.init("scattergeo derived traces", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.ChoroplethMap<int, string>(
            //                locations: new string [] {"USA", "Germany", "Australia"},
            //                z: new int [] {1, 2, 3},
            //                LocationMode: LocationFormat.CountryNames,
            //                ShowScale: false,
            //                ShowLegend: true,
            //                Name: "choropleth"
            //            ).WithTraceInfo(
            //                LegendGroup: "other-geo",
            //                LegendGroupTitle: Plotly.NET.Title.init("other geo charts", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.Combine(
            //                new Plotly.NET.GenericChart []
            //                {
            //                    Chart.ScatterMapbox<int,int,string>(
            //                        longitudes: new int [] { 1, 2 },
            //                        latitudes: new int [] { 1, 2 },
            //                        mode: Mode.Markers,
            //                        Name: "scattermapbox"
            //                    ),
            //                    Chart.PointMapbox<int,int,string>(
            //                        longitudes: new int [] { 10, 11 },
            //                        latitudes: new int [] { 10, 11 },
            //                        Name: "pointmapbox"
            //                    ),
            //                    Chart.LineMapbox<int,int,string>(
            //                        longitudes: new int [] { -1, 11},
            //                        latitudes: new int [] { 11, 1 },
            //                        Name: "linemapbox"
            //                    ),
            //                    Chart.BubbleMapbox<int,int,string>(
            //                        longitudes: new int [] { 22, -11},
            //                        latitudes: new int [] { 5, 5 },
            //                        sizes: new int [] { 10, 20 },
            //                        Name: "bubblemapbox"
            //                    ),
            //                }
            //            ).WithMapboxStyle(
            //                Style: MapboxStyle.OpenStreetMap,
            //                Id: 38
            //            ).WithTraceInfo(
            //                LegendGroup: "scattermapbox-derived",
            //                LegendGroupTitle: Plotly.NET.Title.init("scattermapbox derived traces", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.DensityMapbox<int,int,int,string>(
            //                longitudes: new int [] { 1,2,2,2,3,4,5,5 },
            //                latitudes:  new int [] { 1,2,2,2,3,4,5,5 },
            //                ShowScale: false
            //            ).WithMapboxStyle(
            //                Style: MapboxStyle.OpenStreetMap,
            //                Id: 39
            //            ).WithTraceInfo(
            //                LegendGroup: "other-mapbox",
            //                LegendGroupTitle: Plotly.NET.Title.init("other mapbox charts", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.Invisible(),
            //            Chart.Invisible(),
            //            Chart.Invisible(),

            //            //ternary traces
            //            Chart.ScatterTernary<int,int,int,IConvertible,string>(
            //                A: new int [] { 1, 2 },
            //                B: new int [] { 3, 4 },
            //                C: new int [] { 10, 2 },
            //                Name: "scatterternary"
            //            ).WithTraceInfo(
            //                LegendGroup: "scatterternary-derived",
            //                LegendGroupTitle: Plotly.NET.Title.init("scatterternary derived traces", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.PointTernary<int,int,int,int,string>(
            //                A: new int [] { 1, 2 },
            //                B: new int [] { 3, 4 },
            //                C: new int [] { 10, 2 },
            //                Name: "pointternary"
            //            ).WithTraceInfo(
            //                LegendGroup: "scatterternary-derived",
            //                LegendGroupTitle: Plotly.NET.Title.init("scatterternary derived traces", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.LineTernary<int,int,int,int,string>(
            //                A: new int [] { 1, 2 },
            //                B: new int [] { 3, 4 },
            //                C: new int [] { 10, 2 },
            //                Name: "lineternary"
            //            ).WithTraceInfo(
            //                LegendGroup: "scatterternary-derived",
            //                LegendGroupTitle: Plotly.NET.Title.init("scatterternary derived traces", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.BubbleTernary<int,int,int,int,string>(
            //                sizes: new int [] {30, 40},
            //                A: new int [] { 1, 2 },
            //                B: new int [] { 3, 4 },
            //                C: new int [] { 10, 2 },
            //                Name: "bubbleternary"
            //            ).WithTraceInfo(
            //                LegendGroup: "scatterternary-derived",
            //                LegendGroupTitle: Plotly.NET.Title.init("scatterternary derived traces", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.Invisible(),
            //            Chart.Invisible(),
            //            Chart.Invisible(),

            //            //carpet traces
            //            Chart.Carpet<double,double,double,double,double,double>(
            //                carpetId: "carpet1",
            //                A: new double [] {4.0, 4.0, 4.0, 4.5, 4.5, 4.5, 5.0, 5.0, 5.0, 6.0, 6.0, 6.0},
            //                B: new double [] {1.0, 2.0, 3.0, 1.0, 2.0, 3.0, 1.0, 2.0, 3.0, 1.0, 2.0, 3.0},
            //                Y: new double [] {2.0, 3.5, 4.0, 3.0, 4.5, 5.0, 5.5, 6.5, 7.5, 8.0, 8.5, 10.0},
            //                Name:"carpet",
            //                ShowLegend: true
            //            ),
            //            Chart.Combine(
            //                new Plotly.NET.GenericChart []
            //                {
            //                    Chart.Carpet<double,double,double,double,double,double>(
            //                        carpetId: "carpet2",
            //                        A: new double [] {4.0, 4.0, 4.0, 4.5, 4.5, 4.5, 5.0, 5.0, 5.0, 6.0, 6.0, 6.0},
            //                        B: new double [] {1.0, 2.0, 3.0, 1.0, 2.0, 3.0, 1.0, 2.0, 3.0, 1.0, 2.0, 3.0},
            //                        Y: new double [] {2.0, 3.5, 4.0, 3.0, 4.5, 5.0, 5.5, 6.5, 7.5, 8.0, 8.5, 10.0}
            //                    ),
            //                    Chart.ScatterCarpet<int, int, string>(
            //                        a: new int [] {4,5,5,6},
            //                        b: new int [] {1,1,2,3},
            //                        carpetAnchorId: "carpet2",
            //                        mode: Mode.Markers,
            //                        Name: "scattercarpet"
            //                    )
            //                }
            //            ).WithTraceInfo(
            //                LegendGroup: "scattercarpet-derived",
            //                LegendGroupTitle: Plotly.NET.Title.init("scattercarpet derived traces", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.Combine(
            //                new Plotly.NET.GenericChart []
            //                {
            //                    Chart.Carpet<double,double,double,double,double,double>(
            //                        carpetId: "carpet3",
            //                        A: new double [] {4.0, 4.0, 4.0, 4.5, 4.5, 4.5, 5.0, 5.0, 5.0, 6.0, 6.0, 6.0},
            //                        B: new double [] {1.0, 2.0, 3.0, 1.0, 2.0, 3.0, 1.0, 2.0, 3.0, 1.0, 2.0, 3.0},
            //                        Y: new double [] {2.0, 3.5, 4.0, 3.0, 4.5, 5.0, 5.5, 6.5, 7.5, 8.0, 8.5, 10.0}
            //                    ),
            //                    Chart.PointCarpet<int, int, string>(
            //                        a: new int [] {4,5,5,6},
            //                        b: new int [] {1,1,2,3},
            //                        carpetAnchorId: "carpet3",
            //                        Name: "pointcarpet"
            //                    )
            //                }
            //            ).WithTraceInfo(
            //                LegendGroup: "scattercarpet-derived",
            //                LegendGroupTitle: Plotly.NET.Title.init("scattercarpet derived traces", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.Combine(
            //                new Plotly.NET.GenericChart []
            //                {
            //                    Chart.Carpet<double,double,double,double,double,double>(
            //                        carpetId: "carpet4",
            //                        A: new double [] {4.0, 4.0, 4.0, 4.5, 4.5, 4.5, 5.0, 5.0, 5.0, 6.0, 6.0, 6.0},
            //                        B: new double [] {1.0, 2.0, 3.0, 1.0, 2.0, 3.0, 1.0, 2.0, 3.0, 1.0, 2.0, 3.0},
            //                        Y: new double [] {2.0, 3.5, 4.0, 3.0, 4.5, 5.0, 5.5, 6.5, 7.5, 8.0, 8.5, 10.0}
            //                    ),
            //                    Chart.LineCarpet<int, int, string>(
            //                        a: new int [] {4,5,5,6},
            //                        b: new int [] {1,1,2,3},
            //                        carpetAnchorId: "carpet4",
            //                        Name: "linecarpet"
            //                    )
            //                }
            //            ).WithTraceInfo(
            //                LegendGroup: "scattercarpet-derived",
            //                LegendGroupTitle: Plotly.NET.Title.init("scattercarpet derived traces", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.Combine(
            //                new Plotly.NET.GenericChart []
            //                {
            //                    Chart.Carpet<double,double,double,double,double,double>(
            //                        carpetId: "carpet5",
            //                        A: new double [] {4.0, 4.0, 4.0, 4.5, 4.5, 4.5, 5.0, 5.0, 5.0, 6.0, 6.0, 6.0},
            //                        B: new double [] {1.0, 2.0, 3.0, 1.0, 2.0, 3.0, 1.0, 2.0, 3.0, 1.0, 2.0, 3.0},
            //                        Y: new double [] {2.0, 3.5, 4.0, 3.0, 4.5, 5.0, 5.5, 6.5, 7.5, 8.0, 8.5, 10.0}
            //                    ),
            //                    Chart.SplineCarpet<int, int, string>(
            //                        a: new int [] {4,5,5,6},
            //                        b: new int [] {1,1,2,3},
            //                        carpetAnchorId: "carpet5",
            //                        Name: "splinecarpet"
            //                    )
            //                }
            //            ).WithTraceInfo(
            //                LegendGroup: "scattercarpet-derived",
            //                LegendGroupTitle: Plotly.NET.Title.init("scattercarpet derived traces", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.Combine(
            //                new Plotly.NET.GenericChart []
            //                {
            //                    Chart.Carpet<double,double,double,double,double,double>(
            //                        carpetId: "carpet6",
            //                        A: new double [] {4.0, 4.0, 4.0, 4.5, 4.5, 4.5, 5.0, 5.0, 5.0, 6.0, 6.0, 6.0},
            //                        B: new double [] {1.0, 2.0, 3.0, 1.0, 2.0, 3.0, 1.0, 2.0, 3.0, 1.0, 2.0, 3.0},
            //                        Y: new double [] {2.0, 3.5, 4.0, 3.0, 4.5, 5.0, 5.5, 6.5, 7.5, 8.0, 8.5, 10.0}
            //                    ),
            //                    Chart.BubbleCarpet<int, int, string>(
            //                        sizes: new int [] {10, 20, 30, 40},
            //                        a: new int [] {4,5,5,6},
            //                        b: new int [] {1,1,2,3},
            //                        carpetAnchorId: "carpet6",
            //                        Name: "bubblecarpet"
            //                    )
            //                }
            //            ).WithTraceInfo(
            //                LegendGroup: "scattercarpet-derived",
            //                LegendGroupTitle: Plotly.NET.Title.init("scattercarpet derived traces", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.Combine(
            //                new Plotly.NET.GenericChart []
            //                {
            //                    Chart.Carpet<double,double,double,double,double,double>(
            //                        carpetId: "carpet7",
            //                        A: new double [] { 0.0, 1.0, 2.0, 3.0, 0.0, 1.0, 2.0, 3.0, 0.0, 1.0, 2.0, 3.0},
            //                        B: new double[] { 4.0, 4.0, 4.0, 4.0, 5.0, 5.0, 5.0, 5.0, 6.0, 6.0, 6.0, 6.0},
            //                        X: new double[] { 2.0, 3.0, 4.0, 5.0, 2.2, 3.1, 4.1, 5.1, 1.5, 2.5, 3.5, 4.5},
            //                        Y: new double [] { 1.0, 1.4, 1.6, 1.75, 2.0, 2.5, 2.7, 2.75, 3.0, 3.5, 3.7, 3.75}
            //                    ),
            //                    Chart.ContourCarpet<double,int,int,string>(
            //                        z: new double [] { 1.0, 1.96, 2.56, 3.0625, 4.0, 5.0625, 1.0, 7.5625, 9.0, 12.25, 15.21, 14.0625 },
            //                        carpetAnchorId: "carpet7",
            //                        A: new int [] { 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3},
            //                        B: new int[] { 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6},
            //                        ShowScale: false,
            //                        ShowLegend: true,
            //                        Name: "contourcarpet"
            //                    )
            //                }
            //            ).WithTraceInfo(
            //                LegendGroup: "carpet-other",
            //                LegendGroupTitle: Plotly.NET.Title.init("other carpet traces", Font: Plotly.NET.Font.init(Size: 20))
            //            ),

            //            //domain traces
            //            Chart.Pie<double,string,string>(
            //                values: new double [] {69, 420},
            //                Labels: new string [] {"A", "B"},
            //                Name: "pie"
            //            ),
            //            Chart.Sunburst<string, string, int, string, string>(
            //                Values: new int [] {19, 26, 55},
            //                labels: new string [] {"A", "B", "C"},
            //                parents: new string [] {"", "", "B"},
            //                Name: "sunburst"
            //            ),
            //            Chart.Treemap<string, string, int, string, string>(
            //                Values: new int [] {19, 26, 55},
            //                labels: new string [] {"A", "B", "C"},
            //                parents: new string [] {"", "", "B"},
            //                Name: "treemap"
            //            ),
            //            Chart.ParallelCoord(
            //                dimensions: new Plotly.NET.TraceObjects.Dimension [] {
            //                    Plotly.NET.TraceObjects.Dimension.initParallel<string, string, int, int>(Label: "A", Values: new int [] {1, 4, 3}),
            //                    Plotly.NET.TraceObjects.Dimension.initParallel<string, string, int, int>(Label: "B", Values: new int [] {3, 1, 2})
            //                },
            //                Name: "parcoords"
            //            ),
            //            Chart.ParallelCategories(
            //                dimensions: new Plotly.NET.TraceObjects.Dimension [] {
            //                    Plotly.NET.TraceObjects.Dimension.initParallel<string, string, int, int>(Label: "A", Values: new int [] {1, 1, 2}),
            //                    Plotly.NET.TraceObjects.Dimension.initParallel<string, string, int, int>(Label: "B", Values: new int [] {3, 3, 3})
            //                },
            //                Name: "parcats"
            //            ),
            //            Chart.Sankey<string>(
            //                nodes: Plotly.NET.TraceObjects.SankeyNodes.init<string, int [], string, string>(
            //                    Label: new string [] {"A", "B", "C", "D"}
            //                ),
            //                links: Plotly.NET.TraceObjects.SankeyLinks.init<string, int>(
            //                    Source: new int [] {0, 1, 1 },
            //                    Target: new int [] {2, 2, 3 },
            //                    Value: new int [] {1, 2, 5}
            //                )
            //            ),
            //            Chart.Icicle<string, string, int, string, string>(
            //                Values: new int [] {19, 26, 55},
            //                labels: new string [] {"A", "B", "C"},
            //                parents: new string [] {"", "", "B"},
            //                Name: "icicle"
            //            ),

            //            //smith traces
            //            Chart.ScatterSmith<double,double,string>(
            //                real: new double [] {1,2,3,4},
            //                imag: new double [] {1,2,3,4},
            //                mode: Mode.Markers,
            //                Name: "scattersmith"
            //            ).WithTraceInfo(
            //                LegendGroup: "scattersmith-derived",
            //                LegendGroupTitle: Plotly.NET.Title.init("scattersmith derived traces", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.PointSmith<double,double,string>(
            //                real: new double [] {1,2,3,4},
            //                imag: new double [] {1,2,3,4},
            //                Name: "pointsmith"
            //            ).WithTraceInfo(
            //                LegendGroup: "scattersmith-derived",
            //                LegendGroupTitle: Plotly.NET.Title.init("scattersmith derived traces", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.LineSmith<double,double,string>(
            //                real: new double [] {1,2,3,4},
            //                imag: new double [] {1,2,3,4},
            //                Name: "linesmith"
            //            ).WithTraceInfo(
            //                LegendGroup: "scattersmith-derived",
            //                LegendGroupTitle: Plotly.NET.Title.init("scattersmith derived traces", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.BubbleSmith<double,double,string>(
            //                sizes: new int [] {10, 20, 30, 40},
            //                real: new double [] {1,2,3,4},
            //                imag: new double [] {1,2,3,4},
            //                Name: "bubblesmith"
            //            ).WithTraceInfo(
            //                LegendGroup: "scattersmith-derived",
            //                LegendGroupTitle: Plotly.NET.Title.init("scattersmith derived traces", Font: Plotly.NET.Font.init(Size: 20))
            //            ),
            //            Chart.Invisible(),
            //            Chart.Invisible(),
            //            Chart.Invisible()
            //        }
            //)
            //.WithSize(1600, 2200)
            //.Show();
        }
    }
}
