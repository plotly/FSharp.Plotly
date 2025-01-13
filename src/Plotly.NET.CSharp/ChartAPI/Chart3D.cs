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
        /// Creates a Scatter3D plot.
        ///
        /// In general, Scatter3D Plots plot three-dimensional data on 3 cartesian position scales in the X, Y, and Z dimension.
        ///
        /// Scatter3D charts are the basis of Point3D, Line3D, and Bubble3D Charts, and can be customized as such. We also provide abstractions for those: Chart.Line3D, Chart.Point3D, Chart.Bubble3D
        /// </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="z">Sets the z coordinates of the plotted data.</param>
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
        /// <param name="CameraProjectionType">Sets the camera projection type of this trace.</param>
        /// <param name="Camera">Sets the camera of this trace.</param>
        /// <param name="Projection">Sets the projection of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Scatter3D<XType, YType, ZType, TextType>(
            IEnumerable<XType> x,
            IEnumerable<YType> y,
            IEnumerable<ZType> z,
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
            Optional<StyleParam.MarkerSymbol3D> MarkerSymbol = default,
            Optional<IEnumerable<StyleParam.MarkerSymbol3D>> MultiMarkerSymbol = default,
            Optional<Marker> Marker = default,
            Optional<Color> LineColor = default,
            Optional<StyleParam.Colorscale> LineColorScale = default,
            Optional<double> LineWidth = default,
            Optional<StyleParam.DrawingStyle> LineDash = default,
            Optional<Line> Line = default,
            Optional<StyleParam.CameraProjectionType> CameraProjectionType = default ,
            Optional<Camera> Camera = default,
            Optional<Projection> Projection = default,
            Optional<bool> UseDefaults = default
        )
            where XType: IConvertible
            where YType: IConvertible
            where ZType : IConvertible
            where TextType : IConvertible
            
            => Plotly.NET.Chart3D.Chart.Scatter3D<XType, YType, ZType, TextType>(
                x: x,
                y: y,
                z: z,
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
                Projection: Projection.ToOption(),
                CameraProjectionType: CameraProjectionType.ToOption(),
                Camera: Camera.ToOption(),
                UseDefaults: UseDefaults.ToOption()
            );

        /// <summary>
        /// Creates a Point3D plot.
        ///
        /// Point3D Plots plot three-dimensional data on 3 cartesian position scales in the X, Y, and Z dimension as points.
        /// </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="z">Sets the z coordinates of the plotted data.</param>
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
        /// <param name="CameraProjectionType">Sets the camera projection type of this trace.</param>
        /// <param name="Camera">Sets the camera of this trace.</param>
        /// <param name="Projection">Sets the projection of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Point3D<XType, YType, ZType, TextType>(
            IEnumerable<XType> x,
            IEnumerable<YType> y,
            IEnumerable<ZType> z,
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
            Optional<StyleParam.MarkerSymbol3D> MarkerSymbol = default,
            Optional<IEnumerable<StyleParam.MarkerSymbol3D>> MultiMarkerSymbol = default,
            Optional<Marker> Marker = default,
            Optional<StyleParam.CameraProjectionType> CameraProjectionType = default,
            Optional<Camera> Camera = default,
            Optional<Projection> Projection = default,
            Optional<bool> UseDefaults = default
        )
            where XType : IConvertible
            where YType : IConvertible
            where ZType : IConvertible
            where TextType : IConvertible

            => Plotly.NET.Chart3D.Chart.Point3D<XType, YType, ZType, TextType>(
                x: x,
                y: y,
                z: z,
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
                CameraProjectionType: CameraProjectionType.ToOption(),
                Camera: Camera.ToOption(),
                Projection: Projection.ToOption(),
                UseDefaults: UseDefaults.ToOption()
            );

        /// <summary>
        /// Creates a Line3D plot.
        ///
        /// Line3D Plots plot three-dimensional data on 3 cartesian position scales in the X, Y, and Z dimension as a line connecting the individual datums.
        /// </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="z">Sets the z coordinates of the plotted data.</param>
        /// <param name="ShowMarkers">Whether to show markers for the datums additionally to the line</param>
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
        /// <param name="CameraProjectionType">Sets the camera projection type of this trace.</param>
        /// <param name="Camera">Sets the camera of this trace.</param>
        /// <param name="Projection">Sets the projection of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Line3D<XType, YType, ZType, TextType>(
            IEnumerable<XType> x,
            IEnumerable<YType> y,
            IEnumerable<ZType> z,
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
            Optional<StyleParam.MarkerSymbol3D> MarkerSymbol = default,
            Optional<IEnumerable<StyleParam.MarkerSymbol3D>> MultiMarkerSymbol = default,
            Optional<Marker> Marker = default,
            Optional<Color> LineColor = default,
            Optional<StyleParam.Colorscale> LineColorScale = default,
            Optional<double> LineWidth = default,
            Optional<StyleParam.DrawingStyle> LineDash = default,
            Optional<Line> Line = default,
            Optional<StyleParam.CameraProjectionType> CameraProjectionType = default,
            Optional<Camera> Camera = default,
            Optional<Projection> Projection = default,
            Optional<bool> UseDefaults = default
        )
            where XType : IConvertible
            where YType : IConvertible
            where ZType : IConvertible
            where TextType : IConvertible

            => Plotly.NET.Chart3D.Chart.Line3D<XType, YType, ZType, TextType>(
                x: x,
                y: y,
                z: z,
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
                CameraProjectionType: CameraProjectionType.ToOption(),
                Camera: Camera.ToOption(),
                Projection: Projection.ToOption(),
                UseDefaults: UseDefaults.ToOption()
            );

        /// <summary>
        /// Creates a Bubble3D plot.
        ///
        /// Bubble3D Plots plot three-dimensional data on 3 cartesian position scales in the X, Y, and Z dimension as points, additionally using the points size as a 4th dimension.
        /// </summary>
        /// <param name="x">Sets the x coordinates of the plotted data.</param>
        /// <param name="y">Sets the y coordinates of the plotted data.</param>
        /// <param name="z">Sets the z coordinates of the plotted data.</param>
        /// <param name="sizes">Sets the size of the points</param>
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
        /// <param name="CameraProjectionType">Sets the camera projection type of this trace.</param>
        /// <param name="Camera">Sets the camera of this trace.</param>
        /// <param name="Projection">Sets the projection of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Bubble3D<XType, YType, ZType, TextType>(
            IEnumerable<XType> x,
            IEnumerable<YType> y,
            IEnumerable<ZType> z,
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
            Optional<StyleParam.MarkerSymbol3D> MarkerSymbol = default,
            Optional<IEnumerable<StyleParam.MarkerSymbol3D>> MultiMarkerSymbol = default,
            Optional<Marker> Marker = default,
            Optional<StyleParam.CameraProjectionType> CameraProjectionType = default,
            Optional<Camera> Camera = default,
            Optional<Projection> Projection = default,
            Optional<bool> UseDefaults = default
        )
            where XType : IConvertible
            where YType : IConvertible
            where ZType : IConvertible
            where TextType : IConvertible

            => Plotly.NET.Chart3D.Chart.Bubble3D<XType, YType, ZType, TextType>(
                x: x,
                y: y,
                z: z,
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
                CameraProjectionType: CameraProjectionType.ToOption(),
                Camera: Camera.ToOption(),
                Projection: Projection.ToOption(),
                UseDefaults: UseDefaults.ToOption()
            );

        /// <summary>
        /// Creates a surface plot.
        ///
        /// Surface plots plot a z value as a function of x and y, creating a three-dimensional surface.
        ///
        /// The data the describes the coordinates of the surface is set in `z`. Data in `z` should be a 2D array.
        /// Coordinates in `x` and `y` can either be 1D arrays or 2D arrays (e.g. to graph parametric surfaces). If not provided in `x` and `y`, the x and y coordinates are assumed to be linear starting at 0 with a unit step.
        /// The color scale corresponds to the `z` values by default. For custom color scales, use `surfacecolor` which should be a 2D array, where its bounds can be controlled using `cmin` and `cmax`.
        /// </summary>
        /// <param name="zData">Two-dimensional data array representing the surface's z values</param>
        /// <param name="X">Sets the x coordinates.</param>
        /// <param name="Y">Sets the y coordinates.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="Contours">Sets the contours on the surface</param>
        /// <param name="ColorScale">Sets the colorscale of the surface</param>
        /// <param name="ShowScale">Whether or not to show the colorbar/colorscale</param>
        /// <param name="CameraProjectionType">Sets the camera projection type of this trace.</param>
        /// <param name="Camera">Sets the camera of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Surface<ZType, XType, YType, TextType>(
            IEnumerable<IEnumerable<ZType>> zData, 
            Optional<IEnumerable<XType>> X = default, 
            Optional<IEnumerable<YType>> Y = default, 
            Optional<string> Name = default, 
            Optional<bool> ShowLegend = default, 
            Optional<double> Opacity = default, 
            Optional<TextType> Text = default, 
            Optional<IEnumerable<TextType>> MultiText = default, 
            Optional<Contours> Contours = default, 
            Optional<StyleParam.Colorscale> ColorScale = default,
            Optional<StyleParam.CameraProjectionType> CameraProjectionType = default,
            Optional<Camera> Camera = default,
            Optional<bool> ShowScale = default, 

            Optional<bool> UseDefaults = default
        )
            where ZType : IConvertible
            where XType : IConvertible
            where YType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.Chart3D.Chart.Surface<IEnumerable<ZType>, ZType, XType, YType, TextType>(
                    zData: zData,
                    X: X.ToOption(),
                    Y: Y.ToOption(),
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    Contours: Contours.ToOption(),
                    ColorScale: ColorScale.ToOption(),
                    ShowScale: ShowScale.ToOption(),
                    CameraProjectionType: CameraProjectionType.ToOption(),
                    Camera: Camera.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Visualizes a 3D mesh.
        ///
        /// Draws sets of triangles with coordinates given by three 1-dimensional arrays in `x`, `y`, `z` and
        ///
        /// (1) a sets of `i`, `j`, `k` indices or
        ///
        /// (2) Delaunay triangulation or
        ///
        /// (3) the Alpha-shape algorithm or
        ///
        /// (4) the Convex-hull algorithm
        /// </summary>
        /// <param name="x">Sets the X coordinates of the vertices. The nth element of vectors `x`, `y` and `z` jointly represent the X, Y and Z coordinates of the nth vertex.</param>
        /// <param name="y">Sets the Y coordinates of the vertices. The nth element of vectors `x`, `y` and `z` jointly represent the X, Y and Z coordinates of the nth vertex.</param>
        /// <param name="z">Sets the Z coordinates of the vertices. The nth element of vectors `x`, `y` and `z` jointly represent the X, Y and Z coordinates of the nth vertex.</param>
        /// <param name="I">A vector of vertex indices, i.e. integer values between 0 and the length of the vertex vectors, representing the "first" vertex of a triangle. For example, `{i[m], j[m], k[m]}` together represent face m (triangle m) in the mesh, where `i[m] = n` points to the triplet `{x[n], y[n], z[n]}` in the vertex arrays. Therefore, each element in `i` represents a point in space, which is the first vertex of a triangle.</param>
        /// <param name="J">A vector of vertex indices, i.e. integer values between 0 and the length of the vertex vectors, representing the "second" vertex of a triangle. For example, `{i[m], j[m], k[m]}` together represent face m (triangle m) in the mesh, where `j[m] = n` points to the triplet `{x[n], y[n], z[n]}` in the vertex arrays. Therefore, each element in `j` represents a point in space, which is the second vertex of a triangle.</param>
        /// <param name="K">A vector of vertex indices, i.e. integer values between 0 and the length of the vertex vectors, representing the "third" vertex of a triangle. For example, `{i[m], j[m], k[m]}` together represent face m (triangle m) in the mesh, where `k[m] = n` points to the triplet `{x[n], y[n], z[n]}` in the vertex arrays. Therefore, each element in `k` represents a point in space, which is the third vertex of a triangle.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="Color">Sets the color of the whole mesh</param>
        /// <param name="Contour">Sets the style and visibility of contours</param>
        /// <param name="ColorScale">Sets the colorscale</param>
        /// <param name="ShowScale">Whether or not to show the colorbar/colorscale</param>
        /// <param name="ColorBar">Sets the colorbar</param>
        /// <param name="FlatShading">Determines whether or not normal smoothing is applied to the meshes, creating meshes with an angular, low-poly look via flat reflections.</param>
        /// <param name="TriangulationAlgorithm">Determines how the mesh surface triangles are derived from the set of vertices (points) represented by the `x`, `y` and `z` arrays, if the `i`, `j`, `k` arrays are not supplied.</param>
        /// <param name="CameraProjectionType">Sets the camera projection type of this trace.</param>
        /// <param name="Camera">Sets the camera of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Mesh3D<XType, YType, ZType, IType, JType, KType, TextType>(
            IEnumerable<XType> x, 
            IEnumerable<YType> y, 
            IEnumerable<ZType> z, 
            Optional<IEnumerable<IType>> I = default, 
            Optional<IEnumerable<JType>> J = default, 
            Optional<IEnumerable<KType>> K = default, 
            Optional<string> Name = default, 
            Optional<bool> ShowLegend = default, 
            Optional<double> Opacity = default, 
            Optional<TextType> Text = default, 
            Optional<IEnumerable<TextType>> MultiText = default, 
            Optional<Color> Color = default, 
            Optional<Contour> Contour = default, 
            Optional<StyleParam.Colorscale> ColorScale = default, 
            Optional<bool> ShowScale = default, 
            Optional<ColorBar> ColorBar = default, 
            Optional<bool> FlatShading = default,
            Optional<StyleParam.TriangulationAlgorithm> TriangulationAlgorithm = default,
            Optional<StyleParam.CameraProjectionType> CameraProjectionType = default,
            Optional<Camera> Camera = default,
            Optional<bool> UseDefaults = default
        )
            where XType : IConvertible
            where YType : IConvertible
            where ZType : IConvertible
            where IType : IConvertible
            where JType : IConvertible
            where KType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.Chart3D.Chart.Mesh3D<XType, YType, ZType, IType, JType, KType, TextType>(
                    x: x,
                    y: y,
                    z: z,
                    I: I.ToOption(),
                    J: J.ToOption(),
                    K: K.ToOption(),
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    Color: Color.ToOption(),
                    Contour: Contour.ToOption(),
                    ColorScale: ColorScale.ToOption(),
                    ShowScale: ShowScale.ToOption(),
                    ColorBar: ColorBar.ToOption(),
                    FlatShading: FlatShading.ToOption(),
                    TriangulationAlgorithm: TriangulationAlgorithm.ToOption(),
                    CameraProjectionType: CameraProjectionType.ToOption(),
                    Camera: Camera.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Creates a cone plot, typically used to visualize vector fields.
        ///
        /// Specify a vector field using 6 1D arrays:
        ///
        /// 3 position arrays `x`, `y` and `z` and
        ///
        /// 3 vector component arrays `u`, `v`, `w`.
        ///
        /// The cones are drawn exactly at the positions given by `x`, `y` and `z`.
        /// </summary>
        /// <param name="x">Sets the x coordinates of the vector field and of the displayed cones.</param>
        /// <param name="y">Sets the y coordinates of the vector field and of the displayed cones.</param>
        /// <param name="z">Sets the z coordinates of the vector field and of the displayed cones.</param>
        /// <param name="u">Sets the x components of the vector field.</param>
        /// <param name="v">Sets the y components of the vector field.</param>
        /// <param name="w">Sets the z components of the vector field.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorScale">Sets the colorscale</param>
        /// <param name="ShowScale">Whether or not to show the colorbar/colorscale</param>
        /// <param name="ColorBar">Sets the colorbar</param>
        /// <param name="SizeMode">Determines whether `sizeref` is set as a "scaled" (i.e unitless) scalar (normalized by the max u/v/w norm in the vector field) or as "absolute" value (in the same units as the vector field).</param>
        /// <param name="ConeAnchor">Sets the cones' anchor with respect to their x/y/z positions. Note that "cm" denote the cone's center of mass which corresponds to 1/4 from the tail to tip.</param>
        /// <param name="CameraProjectionType">Sets the camera projection type of this trace.</param>
        /// <param name="Camera">Sets the camera of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Cone<XType, YType, ZType, UType, VType, WType, TextType>(
            IEnumerable<XType> x, 
            IEnumerable<YType> y, 
            IEnumerable<ZType> z, 
            IEnumerable<UType> u, 
            IEnumerable<VType> v, 
            IEnumerable<WType> w, 
            Optional<string> Name = default, 
            Optional<bool> ShowLegend = default, 
            Optional<double> Opacity = default, 
            Optional<TextType> Text = default, 
            Optional<IEnumerable<TextType>> MultiText = default, 
            Optional<StyleParam.Colorscale> ColorScale = default, 
            Optional<bool> ShowScale = default, 
            Optional<ColorBar> ColorBar = default, 
            Optional<StyleParam.ConeSizeMode> SizeMode = default, 
            Optional<StyleParam.ConeAnchor> ConeAnchor = default,
            Optional<StyleParam.CameraProjectionType> CameraProjectionType = default,
            Optional<Camera> Camera = default,
            Optional<bool> UseDefaults = default
        )
            where XType : IConvertible
            where YType : IConvertible
            where ZType : IConvertible
            where UType : IConvertible
            where VType : IConvertible
            where WType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.Chart3D.Chart.Cone<XType, YType, ZType, UType, VType, WType, TextType>(
                    x: x,
                    y: y,
                    z: z,
                    u: u,
                    v: v,
                    w: w,
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    ColorScale: ColorScale.ToOption(),
                    ShowScale: ShowScale.ToOption(),
                    ColorBar: ColorBar.ToOption(),
                    SizeMode: SizeMode.ToOption(),
                    ConeAnchor: ConeAnchor.ToOption(),
                    CameraProjectionType: CameraProjectionType.ToOption(),
                    Camera: Camera.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Creates a streamtube plot, typically used to visualize flow in a vector field.
        ///
        /// Specify a vector field using 6 1D arrays of equal length:
        ///
        /// 3 position arrays `x`, `y` and `z` and
        ///
        /// 3 vector component arrays `u`, `v`, and `w`.
        ///
        /// By default, the tubes' starting positions will be cut from the vector field's x-z plane at its minimum y value.
        /// To specify your own starting position, use `TubeStarts`.
        /// The color is encoded by the norm of (u, v, w), and the local radius by the divergence of (u, v, w).
        /// </summary>
        /// <param name="x">Sets the x coordinates of the vector field and of the displayed cones.</param>
        /// <param name="y">Sets the y coordinates of the vector field and of the displayed cones.</param>
        /// <param name="z">Sets the z coordinates of the vector field and of the displayed cones.</param>
        /// <param name="u">Sets the x components of the vector field.</param>
        /// <param name="v">Sets the y components of the vector field.</param>
        /// <param name="w">Sets the z components of the vector field.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorScale">Sets the colorscale</param>
        /// <param name="ShowScale">Whether or not to show the colorbar/colorscale</param>
        /// <param name="ColorBar">Sets the colorbar</param>
        /// <param name="MaxDisplayed">The maximum number of displayed segments in a streamtube.</param>
        /// <param name="TubeStarts">Use this object to specify custom tube start positions</param>
        /// <param name="CameraProjectionType">Sets the camera projection type of this trace.</param>
        /// <param name="Camera">Sets the camera of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart StreamTube<XType, YType, ZType, UType, VType, WType, TextType>(
            IEnumerable<XType> x,
            IEnumerable<YType> y,
            IEnumerable<ZType> z,
            IEnumerable<UType> u,
            IEnumerable<VType> v,
            IEnumerable<WType> w,
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default,
            Optional<double> Opacity = default,
            Optional<TextType> Text = default,
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<StyleParam.Colorscale> ColorScale = default, 
            Optional<bool> ShowScale = default,
            Optional<ColorBar> ColorBar = default, 
            Optional<int> MaxDisplayed = default, 
            Optional<StreamTubeStarts> TubeStarts = default,
            Optional<StyleParam.CameraProjectionType> CameraProjectionType = default,
            Optional<Camera> Camera = default,
            Optional<bool> UseDefaults = default
        )
            where XType : IConvertible
            where YType : IConvertible
            where ZType : IConvertible
            where UType : IConvertible
            where VType : IConvertible
            where WType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.Chart3D.Chart.StreamTube<XType, YType, ZType, UType, VType, WType, TextType>(
                    x: x,
                    y: y,
                    z: z,
                    u: u,
                    v: v,
                    w: w,
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    ColorScale: ColorScale.ToOption(),
                    ShowScale: ShowScale.ToOption(),
                    ColorBar: ColorBar.ToOption(),
                    MaxDisplayed: MaxDisplayed.ToOption(),
                    TubeStarts: TubeStarts.ToOption(),
                    CameraProjectionType: CameraProjectionType.ToOption(),
                    Camera: Camera.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Creates a volume plot to visualize the volume of a 3D shape.
        ///
        /// Draws volume trace between iso-min and iso-max values with coordinates given by four 1-dimensional arrays containing the `value`, `x`, `y` and `z` of every vertex of a uniform or non-uniform 3-D grid.
        /// Horizontal or vertical slices, caps as well as spaceframe between iso-min and iso-max values could also be drawn using this trace.
        ///
        /// This plot is very similar to the `IsoSurface` plot. However, whereas isosurface plots show all surfaces with the same opacity, tweaking the opacityscale parameter of Volume plots results in a depth effect and better volume rendering.
        /// </summary>
        /// <param name="x">Sets the X coordinates of the vertices on X axis.</param>
        /// <param name="y">Sets the Y coordinates of the vertices on Y axis.</param>
        /// <param name="z">Sets the Z coordinates of the vertices on Z axis.</param>
        /// <param name="value">Sets the 4th dimension (value) of the vertices.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorScale">Sets the colorscale</param>
        /// <param name="ShowScale">Whether or not to show the colorbar/colorscale</param>
        /// <param name="ColorBar">Sets the colorbar</param>
        /// <param name="IsoMin">Sets the minimum boundary for iso-surface plot.</param>
        /// <param name="IsoMax">Sets the maximum boundary for iso-surface plot.</param>
        /// <param name="Caps">Sets the caps (color-coded surfaces on the sides of the visualization domain)</param>
        /// <param name="Slices">Adds Slices through the volume</param>
        /// <param name="Surface">Sets the surface.</param>
        /// <param name="OpacityScale">Sets the opacityscale. The opacityscale must be an array containing arrays mapping a normalized value to an opacity value. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 1], [0.5, 0.2], [1, 1]]` means that higher/lower values would have higher opacity values and those in the middle would be more transparent Alternatively, `opacityscale` may be a palette name string of the following list: 'min', 'max', 'extremes' and 'uniform'. The default is 'uniform'.</param>
        /// <param name="CameraProjectionType">Sets the camera projection type of this trace.</param>
        /// <param name="Camera">Sets the camera of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart Volume<XType, YType, ZType, ValueType, TextType, OpacityScaleType>(
            IEnumerable<XType> x, 
            IEnumerable<YType> y, 
            IEnumerable<ZType> z, 
            IEnumerable<ValueType> value, 
            Optional<string> Name = default, 
            Optional<bool> ShowLegend = default, 
            Optional<double> Opacity = default, 
            Optional<TextType> Text = default, 
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<StyleParam.Colorscale> ColorScale = default, 
            Optional<bool> ShowScale = default, 
            Optional<ColorBar> ColorBar = default, 
            Optional<double> IsoMin = default, 
            Optional<double> IsoMax = default, 
            Optional<Caps> Caps = default, 
            Optional<Slices> Slices = default, 
            Optional<Surface> Surface = default, 
            Optional<IEnumerable<IEnumerable<OpacityScaleType>>> OpacityScale = default,
            Optional<StyleParam.CameraProjectionType> CameraProjectionType = default,
            Optional<Camera> Camera = default,
            Optional<bool> UseDefaults = default
        )
            where XType : IConvertible
            where YType : IConvertible
            where ZType : IConvertible
            where ValueType : IConvertible
            where TextType : IConvertible
            where OpacityScaleType : IConvertible
            =>
                Plotly.NET.Chart3D.Chart.Volume<XType, YType, ZType, ValueType, TextType, IEnumerable<OpacityScaleType>, OpacityScaleType>(
                    x: x,
                    y: y,
                    z: z,
                    value: value,
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    ColorScale: ColorScale.ToOption(),
                    ShowScale: ShowScale.ToOption(),
                    ColorBar: ColorBar.ToOption(),
                    IsoMin: IsoMin.ToOption(),
                    IsoMax: IsoMax.ToOption(),
                    Caps: Caps.ToOption(),
                    Slices: Slices.ToOption(),
                    Surface: Surface.ToOption(),
                    OpacityScale: OpacityScale.ToOption(),
                    CameraProjectionType: CameraProjectionType.ToOption(),
                    Camera: Camera.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );

        /// <summary>
        /// Creates a isosurface plot to visualize the volume of a 3D shape.
        ///
        /// An isosurface is a surface that represents points of a constant value (e.g. pressure, temperature, velocity, density) within a volume of space.
        ///
        /// Draws isosurfaces between iso-min and iso-max values with coordinates given by four 1-dimensional arrays containing the `value`, `x`, `y` and `z` of every vertex of a uniform or non-uniform 3-D grid.
        /// Horizontal or vertical slices, caps as well as spaceframe between iso-min and iso-max values could also be drawn using this trace.
        ///
        /// This plot is very similar to the `Volume` plot. However it shows all surfaces with the same opacity.
        /// </summary>
        /// <param name="x">Sets the X coordinates of the vertices on X axis.</param>
        /// <param name="y">Sets the Y coordinates of the vertices on Y axis.</param>
        /// <param name="z">Sets the Z coordinates of the vertices on Z axis.</param>
        /// <param name="value">Sets the 4th dimension (value) of the vertices.</param>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="Opacity">Sets the opactity of the trace</param>
        /// <param name="Text">Sets a text associated with each datum</param>
        /// <param name="MultiText">Sets individual text for each datum</param>
        /// <param name="ColorScale">Sets the colorscale</param>
        /// <param name="ShowScale">Whether or not to show the colorbar/colorscale</param>
        /// <param name="ColorBar">Sets the colorbar</param>
        /// <param name="IsoMin">Sets the minimum boundary for iso-surface plot.</param>
        /// <param name="IsoMax">Sets the maximum boundary for iso-surface plot.</param>
        /// <param name="Caps">Sets the caps (color-coded surfaces on the sides of the visualization domain)</param>
        /// <param name="Slices">Adds Slices through the volume</param>
        /// <param name="Surface">Sets the surface.</param>
        /// <param name="CameraProjectionType">Sets the camera projection type of this trace.</param>
        /// <param name="Camera">Sets the camera of this trace.</param>
        /// <param name="UseDefaults">If set to false, ignore the global default settings set in `Defaults`</param>
        public static GenericChart IsoSurface<XType, YType, ZType, ValueType, TextType>(
            IEnumerable<XType> x,
            IEnumerable<YType> y, 
            IEnumerable<ZType> z,
            IEnumerable<ValueType> value, 
            Optional<string> Name = default,
            Optional<bool> ShowLegend = default, 
            Optional<double> Opacity = default,
            Optional<TextType> Text = default, 
            Optional<IEnumerable<TextType>> MultiText = default,
            Optional<StyleParam.Colorscale> ColorScale = default, 
            Optional<bool> ShowScale = default,
            Optional<ColorBar> ColorBar = default, 
            Optional<double> IsoMin = default,
            Optional<double> IsoMax = default, 
            Optional<Caps> Caps = default,
            Optional<Slices> Slices = default, 
            Optional<Surface> Surface = default,
            Optional<StyleParam.CameraProjectionType> CameraProjectionType = default,
            Optional<Camera> Camera = default,
            Optional<bool> UseDefaults = default
        )
            where XType : IConvertible
            where YType : IConvertible
            where ZType : IConvertible
            where ValueType : IConvertible
            where TextType : IConvertible
            =>
                Plotly.NET.Chart3D.Chart.IsoSurface<XType, YType, ZType, ValueType, TextType>(
                    x: x,
                    y: y,
                    z: z,
                    value: value,
                    Name: Name.ToOption(),
                    ShowLegend: ShowLegend.ToOption(),
                    Opacity: Opacity.ToOption(),
                    Text: Text.ToOption(),
                    MultiText: MultiText.ToOption(),
                    ColorScale: ColorScale.ToOption(),
                    ShowScale: ShowScale.ToOption(),
                    ColorBar: ColorBar.ToOption(),
                    IsoMin: IsoMin.ToOption(),
                    IsoMax: IsoMax.ToOption(),
                    Caps: Caps.ToOption(),
                    Slices: Slices.ToOption(),
                    Surface: Surface.ToOption(),
                    CameraProjectionType: CameraProjectionType.ToOption(),
                    Camera: Camera.ToOption(),
                    UseDefaults: UseDefaults.ToOption()
                );
    }
}
