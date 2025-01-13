namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects

open DynamicObj
open System
open System.IO
//open FSharp.Care.Collections

open StyleParam
open System.Runtime.InteropServices
open System.Runtime.CompilerServices

[<AutoOpen>]
module Chart3D =

    [<Extension>]
    type Chart =

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
        [<Extension>]
        static member Scatter3D
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                z: seq<#IConvertible>,
                mode: StyleParam.Mode,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol3D,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol3D>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?Projection: Projection,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (
                    ?Color = MarkerColor,
                    ?Outline = MarkerOutline,
                    ?Symbol3D = MarkerSymbol,
                    ?MultiSymbol3D = MultiMarkerSymbol,
                    ?Colorscale = MarkerColorScale,
                    ?MultiOpacity = MultiOpacity
                )

            let line =
                Line
                |> Option.defaultValue (Plotly.NET.Line.init ())
                |> Plotly.NET.Line.style (
                    ?Color = LineColor,
                    ?Dash = LineDash,
                    ?Colorscale = LineColorScale,
                    ?Width = LineWidth
                )

            let cameraProjection =
                defaultArg CameraProjectionType StyleParam.CameraProjectionType.Perspective

            let camera =
                Camera
                |> Option.defaultValue (LayoutObjects.Camera.init ())
                |> LayoutObjects.Camera.style (Projection = CameraProjection.init (ProjectionType = cameraProjection))

            Trace3D.initScatter3D (
                Trace3DStyle.Scatter3D(
                    X = x,
                    Y = y,
                    Z = z,
                    Mode = mode,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?Projection = Projection,
                    Marker = marker,
                    Line = line
                )
            )

            |> GenericChart.ofTraceObject useDefaults
            |> GenericChart.addLayout (
                Layout.init () |> Layout.setScene (StyleParam.SubPlotId.Scene 1, Scene.init (Camera = camera))
            )


        /// <summary>
        /// Creates a Scatter3D plot.
        ///
        /// In general, Scatter3D Plots plot three-dimensional data on 3 cartesian position scales in the X, Y, and Z dimension.
        ///
        /// Scatter3D charts are the basis of Point3D, Line3D, and Bubble3D Charts, and can be customized as such. We also provide abstractions for those: Chart.Line3D, Chart.Point3D, Chart.Bubble3D
        /// </summary>
        /// <param name="xyz">Sets the x, y, and z coordinates of the plotted data.</param>
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
        [<Extension>]
        static member Scatter3D
            (
                xyz: seq<#IConvertible * #IConvertible * #IConvertible>,
                mode: StyleParam.Mode,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol3D,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol3D>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?Projection: Projection,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let x, y, z = Seq.unzip3 xyz

            Chart.Scatter3D(
                x,
                y,
                z,
                mode,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?CameraProjectionType = CameraProjectionType,
                ?Camera = Camera,
                ?Projection = Projection,
                ?UseDefaults = UseDefaults
            )

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
        [<Extension>]
        static member Point3D
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                z: seq<#IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol3D,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol3D>,
                ?Marker: Marker,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?Projection: Projection,
                ?UseDefaults: bool
            ) =

            // if text position or font is set, then show labels (not only when hovering)
            let changeMode =
                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)

            Chart.Scatter3D(
                x = x,
                y = y,
                z = z,
                mode = changeMode StyleParam.Mode.Markers,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?Projection = Projection,
                ?CameraProjectionType = CameraProjectionType,
                ?Camera = Camera,
                ?UseDefaults = UseDefaults
            )

        /// <summary>
        /// Creates a Point3D plot.
        ///
        /// Point3D Plots plot three-dimensional data on 3 cartesian position scales in the X, Y, and Z dimension as points.
        /// </summary>
        /// <param name="xyz">Sets the x, y, and z coordinates of the plotted data.</param>
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
        [<Extension>]
        static member Point3D
            (
                xyz: seq<#IConvertible * #IConvertible * #IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol3D,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol3D>,
                ?Marker: Marker,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?Projection: Projection,
                ?UseDefaults: bool
            ) =

            let x, y, z = Seq.unzip3 xyz

            Chart.Point3D(
                x,
                y,
                z,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?CameraProjectionType = CameraProjectionType,
                ?Camera = Camera,
                ?Projection = Projection,
                ?UseDefaults = UseDefaults
            )


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
        [<Extension>]
        static member Line3D
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                z: seq<#IConvertible>,
                ?ShowMarkers: bool,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol3D,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol3D>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?Projection: Projection,
                ?UseDefaults: bool
            ) =
            let changeMode =
                let isShowMarker =
                    match ShowMarkers with
                    | Some isShow -> isShow
                    | Option.None -> false

                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)
                >> StyleParam.ModeUtils.showMarker (isShowMarker)

            Chart.Scatter3D(
                x = x,
                y = y,
                z = z,
                mode = changeMode StyleParam.Mode.Lines,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?CameraProjectionType = CameraProjectionType,
                ?Camera = Camera,
                ?Projection = Projection,
                ?UseDefaults = UseDefaults

            )

        /// <summary>
        /// Creates a Line3D plot.
        ///
        /// Line3D Plots plot three-dimensional data on 3 cartesian position scales in the X, Y, and Z dimension as a line connecting the individual datums.
        /// </summary>
        /// <param name="xyz">Sets the x, y, and z coordinates of the plotted data.</param>
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
        [<Extension>]
        static member Line3D
            (
                xyz: seq<#IConvertible * #IConvertible * #IConvertible>,
                ?ShowMarkers: bool,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol3D,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol3D>,
                ?Marker: Marker,
                ?LineColor: Color,
                ?LineColorScale: StyleParam.Colorscale,
                ?LineWidth: float,
                ?LineDash: StyleParam.DrawingStyle,
                ?Line: Line,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?Projection: Projection,
                ?UseDefaults: bool
            ) =

            let x, y, z = Seq.unzip3 xyz

            Chart.Line3D(
                x,
                y,
                z,
                ?ShowMarkers = ShowMarkers,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?LineColor = LineColor,
                ?LineColorScale = LineColorScale,
                ?LineWidth = LineWidth,
                ?LineDash = LineDash,
                ?Line = Line,
                ?CameraProjectionType = CameraProjectionType,
                ?Camera = Camera,
                ?Projection = Projection,
                ?UseDefaults = UseDefaults
            )


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
        [<Extension>]
        static member Bubble3D
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                z: seq<#IConvertible>,
                sizes: seq<int>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol3D,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol3D>,
                ?Marker: Marker,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?Projection: Projection,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let changeMode =
                StyleParam.ModeUtils.showText (TextPosition.IsSome || MultiTextPosition.IsSome)

            let marker =
                Marker
                |> Option.defaultValue (TraceObjects.Marker.init ())
                |> TraceObjects.Marker.style (
                    ?Color = MarkerColor,
                    ?Outline = MarkerOutline,
                    ?Symbol3D = MarkerSymbol,
                    ?MultiSymbol3D = MultiMarkerSymbol,
                    ?Colorscale = MarkerColorScale,
                    ?MultiOpacity = MultiOpacity,
                    MultiSize = sizes
                )

            let cameraProjection =
                defaultArg CameraProjectionType StyleParam.CameraProjectionType.Perspective

            let camera =
                Camera
                |> Option.defaultValue (LayoutObjects.Camera.init ())
                |> LayoutObjects.Camera.style (Projection = CameraProjection.init (ProjectionType = cameraProjection))

            Trace3D.initScatter3D (
                Trace3DStyle.Scatter3D(
                    X = x,
                    Y = y,
                    Z = z,
                    Mode = changeMode StyleParam.Mode.Markers,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?TextPosition = TextPosition,
                    ?MultiTextPosition = MultiTextPosition,
                    ?Projection = Projection,
                    Marker = marker
                )
            )

            |> GenericChart.ofTraceObject useDefaults
            |> GenericChart.addLayout (
                Layout.init () |> Layout.setScene (StyleParam.SubPlotId.Scene 1, Scene.init (Camera = camera))
            )


        /// <summary>
        /// Creates a Bubble3D plot.
        ///
        /// Bubble3D Plots plot three-dimensional data on 3 cartesian position scales in the X, Y, and Z dimension as points, additionally using the points size as a 4th dimension.
        /// </summary>
        /// <param name="xyz">Sets the x, y, and z coordinates of the plotted data.</param>
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
        [<Extension>]
        static member Bubble3D
            (
                xyz,
                sizes,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol3D,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol3D>,
                ?Marker: Marker,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?Projection: Projection,
                ?UseDefaults: bool
            ) =

            let x, y, z = Seq.unzip3 xyz

            Chart.Bubble3D(
                x,
                y,
                z,
                sizes,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?CameraProjectionType = CameraProjectionType,
                ?Camera = Camera,
                ?Projection = Projection,
                ?UseDefaults = UseDefaults

            )

        /// <summary>
        /// Creates a Bubble3D plot.
        ///
        /// Bubble3D Plots plot three-dimensional data on 3 cartesian position scales in the X, Y, and Z dimension as points, additionally using the points size as a 4th dimension.
        /// </summary>
        /// <param name="xyzsizes">Sets the x, y, and z coordinates together with the point size.</param>
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
        [<Extension>]
        static member Bubble3D
            (
                xyzsizes,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?MultiOpacity: seq<float>,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?TextPosition: StyleParam.TextPosition,
                ?MultiTextPosition: seq<StyleParam.TextPosition>,
                ?MarkerColor: Color,
                ?MarkerColorScale: StyleParam.Colorscale,
                ?MarkerOutline: Line,
                ?MarkerSymbol: StyleParam.MarkerSymbol3D,
                ?MultiMarkerSymbol: seq<StyleParam.MarkerSymbol3D>,
                ?Marker: Marker,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?Projection: Projection,
                ?UseDefaults: bool
            ) =

            let x, y, z, sizes =
                xyzsizes |> Seq.map (fun (x, _, _, _) -> x),
                xyzsizes |> Seq.map (fun (_, y, _, _) -> y),
                xyzsizes |> Seq.map (fun (_, _, z, _) -> z),
                xyzsizes |> Seq.map (fun (_, _, _, size) -> size)

            Chart.Bubble3D(
                x,
                y,
                z,
                sizes,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?MultiOpacity = MultiOpacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?TextPosition = TextPosition,
                ?MultiTextPosition = MultiTextPosition,
                ?MarkerColor = MarkerColor,
                ?MarkerColorScale = MarkerColorScale,
                ?MarkerOutline = MarkerOutline,
                ?MarkerSymbol = MarkerSymbol,
                ?MultiMarkerSymbol = MultiMarkerSymbol,
                ?Marker = Marker,
                ?CameraProjectionType = CameraProjectionType,
                ?Camera = Camera,
                ?Projection = Projection,
                ?UseDefaults = UseDefaults

            )

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
        [<Extension>]
        static member Surface
            (
                zData,
                ?X: seq<#IConvertible>,
                ?Y: seq<#IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?Contours: Contours,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let cameraProjection =
                defaultArg CameraProjectionType StyleParam.CameraProjectionType.Perspective

            let camera =
                Camera
                |> Option.defaultValue (LayoutObjects.Camera.init ())
                |> LayoutObjects.Camera.style (Projection = CameraProjection.init (ProjectionType = cameraProjection))

            Trace3D.initSurface (
                Trace3DStyle.Surface(
                    Z = zData,
                    ?X = X,
                    ?Y = Y,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?Contours = Contours,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale
                )
            )

            |> GenericChart.ofTraceObject useDefaults
            |> GenericChart.addLayout (
                Layout.init () |> Layout.setScene (StyleParam.SubPlotId.Scene 1, Scene.init (Camera = camera))
            )

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
        [<Extension>]
        static member Mesh3D
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                z: seq<#IConvertible>,
                ?I: seq<#IConvertible>,
                ?J: seq<#IConvertible>,
                ?K: seq<#IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?Color: Color,
                ?Contour: Contour,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ColorBar: ColorBar,
                ?FlatShading: bool,
                ?TriangulationAlgorithm: StyleParam.TriangulationAlgorithm,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let cameraProjection =
                defaultArg CameraProjectionType StyleParam.CameraProjectionType.Perspective

            let camera =
                Camera
                |> Option.defaultValue (LayoutObjects.Camera.init ())
                |> LayoutObjects.Camera.style (Projection = CameraProjection.init (ProjectionType = cameraProjection))

            Trace3D.initMesh3D (
                Trace3DStyle.Mesh3D(
                    X = x,
                    Y = y,
                    Z = z,
                    ?I = I,
                    ?J = J,
                    ?K = K,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?Color = Color,
                    ?Contour = Contour,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ColorBar = ColorBar,
                    ?FlatShading = FlatShading,
                    ?AlphaHull = TriangulationAlgorithm
                )
            )
            |> GenericChart.ofTraceObject useDefaults
            |> GenericChart.addLayout (
                Layout.init () |> Layout.setScene (StyleParam.SubPlotId.Scene 1, Scene.init (Camera = camera))
            )

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
        /// <param name="xyz">Sets the X, Y, and Z coordinates of the vertices. The nth element of vectors `x`, `y` and `z` jointly represent the X, Y and Z coordinates of the nth vertex.</param>
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
        [<Extension>]
        static member Mesh3D
            (
                xyz: seq<#IConvertible * #IConvertible * #IConvertible>,
                ?I: seq<#IConvertible>,
                ?J: seq<#IConvertible>,
                ?K: seq<#IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?Color: Color,
                ?Contour: Contour,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ColorBar: ColorBar,
                ?FlatShading: bool,
                ?TriangulationAlgorithm: StyleParam.TriangulationAlgorithm,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?UseDefaults: bool
            ) =

            let x, y, z = Seq.unzip3 xyz

            Chart.Mesh3D(
                x,
                y,
                z,
                ?I = I,
                ?J = J,
                ?K = K,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?Color = Color,
                ?Contour = Contour,
                ?ColorScale = ColorScale,
                ?ShowScale = ShowScale,
                ?ColorBar = ColorBar,
                ?FlatShading = FlatShading,
                ?TriangulationAlgorithm = TriangulationAlgorithm,
                ?CameraProjectionType = CameraProjectionType,
                ?Camera = Camera,
                ?UseDefaults = UseDefaults
            )

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
        [<Extension>]
        static member Cone
            (
                x: seq<#IConvertible>,
                y: seq<#IConvertible>,
                z: seq<#IConvertible>,
                u: seq<#IConvertible>,
                v: seq<#IConvertible>,
                w: seq<#IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ColorBar: ColorBar,
                ?SizeMode: StyleParam.ConeSizeMode,
                ?ConeAnchor: StyleParam.ConeAnchor,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let cameraProjection =
                defaultArg CameraProjectionType StyleParam.CameraProjectionType.Perspective

            let camera =
                Camera
                |> Option.defaultValue (LayoutObjects.Camera.init ())
                |> LayoutObjects.Camera.style (Projection = CameraProjection.init (ProjectionType = cameraProjection))

            Trace3D.initCone (
                Trace3DStyle.Cone(
                    X = x,
                    Y = y,
                    Z = z,
                    U = u,
                    V = v,
                    W = w,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ColorBar = ColorBar,
                    ?SizeMode = SizeMode,
                    ?Anchor = ConeAnchor
                )
            )
            |> GenericChart.ofTraceObject useDefaults
            |> GenericChart.addLayout (
                Layout.init () |> Layout.setScene (StyleParam.SubPlotId.Scene 1, Scene.init (Camera = camera))
            )

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
        /// <param name="coneXYZ">Sets the x, y, and z coordinates of the vector field and of the displayed cones.</param>
        /// <param name="coneUVW">Sets the x, y, and z components of the vector field.</param>
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
        [<Extension>]
        static member Cone
            (
                coneXYZ: seq<#IConvertible * #IConvertible * #IConvertible>,
                coneUVW: seq<#IConvertible * #IConvertible * #IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ColorBar: ColorBar,
                ?SizeMode: StyleParam.ConeSizeMode,
                ?ConeAnchor: StyleParam.ConeAnchor,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?UseDefaults: bool
            ) =

            let x, y, z = Seq.unzip3 coneXYZ
            let u, v, w = Seq.unzip3 coneUVW

            Chart.Cone(
                x,
                y,
                z,
                u,
                v,
                w,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?ColorScale = ColorScale,
                ?ShowScale = ShowScale,
                ?ColorBar = ColorBar,
                ?SizeMode = SizeMode,
                ?ConeAnchor = ConeAnchor,
                ?CameraProjectionType = CameraProjectionType,
                ?Camera = Camera,
                ?UseDefaults = UseDefaults
            )

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
        /// <param name="xyzuvw">Sets the x, y, and z coordinates of the vector field and of the displayed cones together with the x, y, and z components of the vector field.</param>
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
        [<Extension>]
        static member Cone
            (
                xyzuvw:
                    seq<#IConvertible * #IConvertible * #IConvertible * #IConvertible * #IConvertible * #IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ColorBar: ColorBar,
                ?SizeMode: StyleParam.ConeSizeMode,
                ?ConeAnchor: StyleParam.ConeAnchor,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?UseDefaults: bool
            ) =

            let x, y, z, u, v, w =
                xyzuvw |> Seq.map (fun (x, _, _, _, _, _) -> x),
                xyzuvw |> Seq.map (fun (_, y, _, _, _, _) -> y),
                xyzuvw |> Seq.map (fun (_, _, z, _, _, _) -> z),
                xyzuvw |> Seq.map (fun (_, _, _, u, _, _) -> u),
                xyzuvw |> Seq.map (fun (_, _, _, _, v, _) -> v),
                xyzuvw |> Seq.map (fun (_, _, _, _, _, w) -> w)

            Chart.Cone(
                x,
                y,
                z,
                u,
                v,
                w,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?ColorScale = ColorScale,
                ?ShowScale = ShowScale,
                ?ColorBar = ColorBar,
                ?SizeMode = SizeMode,
                ?ConeAnchor = ConeAnchor,
                ?CameraProjectionType = CameraProjectionType,
                ?Camera = Camera,
                ?UseDefaults = UseDefaults
            )

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
        [<Extension>]
        static member StreamTube
            (
                x,
                y,
                z,
                u,
                v,
                w,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ColorBar: ColorBar,
                ?MaxDisplayed: int,
                ?TubeStarts: StreamTubeStarts,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let cameraProjection =
                defaultArg CameraProjectionType StyleParam.CameraProjectionType.Perspective

            let camera =
                Camera
                |> Option.defaultValue (LayoutObjects.Camera.init ())
                |> LayoutObjects.Camera.style (Projection = CameraProjection.init (ProjectionType = cameraProjection))

            Trace3D.initStreamTube (
                Trace3DStyle.StreamTube(
                    X = x,
                    Y = y,
                    Z = z,
                    U = u,
                    V = v,
                    W = w,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ColorBar = ColorBar,
                    ?MaxDisplayed = MaxDisplayed,
                    ?Starts = TubeStarts
                )
            )
            |> GenericChart.ofTraceObject useDefaults
            |> GenericChart.addLayout (
                Layout.init () |> Layout.setScene (StyleParam.SubPlotId.Scene 1, Scene.init (Camera = camera))
            )

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
        /// <param name="streamTubeXYZ">Sets the x, y, and z coordinates of the vector field and of the displayed cones.</param>
        /// <param name="streamTubeUVW">Sets the x, y, and z components of the vector field.</param>
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
        [<Extension>]
        static member StreamTube
            (
                streamTubeXYZ: seq<#IConvertible * #IConvertible * #IConvertible>,
                streamTubeUVW: seq<#IConvertible * #IConvertible * #IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ColorBar: ColorBar,
                ?MaxDisplayed: int,
                ?TubeStarts: StreamTubeStarts,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let x, y, z = Seq.unzip3 streamTubeXYZ
            let u, v, w = Seq.unzip3 streamTubeUVW

            Chart.StreamTube(
                x,
                y,
                z,
                u,
                v,
                w,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?ColorScale = ColorScale,
                ?ShowScale = ShowScale,
                ?ColorBar = ColorBar,
                ?MaxDisplayed = MaxDisplayed,
                ?TubeStarts = TubeStarts,
                ?CameraProjectionType = CameraProjectionType,
                ?Camera = Camera,
                ?UseDefaults = UseDefaults

            )

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
        /// <param name="xyzuvw">Sets the x, y, and z coordinates of the vector field and of the displayed cones together with the x, y, and z components of the vector field.</param>
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
        [<Extension>]
        static member StreamTube
            (
                xyzuvw:
                    seq<#IConvertible * #IConvertible * #IConvertible * #IConvertible * #IConvertible * #IConvertible>,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ColorBar: ColorBar,
                ?MaxDisplayed: int,
                ?TubeStarts: StreamTubeStarts,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?UseDefaults: bool
            ) =

            let x, y, z, u, v, w =
                xyzuvw |> Seq.map (fun (x, _, _, _, _, _) -> x),
                xyzuvw |> Seq.map (fun (_, y, _, _, _, _) -> y),
                xyzuvw |> Seq.map (fun (_, _, z, _, _, _) -> z),
                xyzuvw |> Seq.map (fun (_, _, _, u, _, _) -> u),
                xyzuvw |> Seq.map (fun (_, _, _, _, v, _) -> v),
                xyzuvw |> Seq.map (fun (_, _, _, _, _, w) -> w)

            Chart.StreamTube(
                x,
                y,
                z,
                u,
                v,
                w,
                ?Name = Name,
                ?ShowLegend = ShowLegend,
                ?Opacity = Opacity,
                ?Text = Text,
                ?MultiText = MultiText,
                ?ColorScale = ColorScale,
                ?ShowScale = ShowScale,
                ?ColorBar = ColorBar,
                ?MaxDisplayed = MaxDisplayed,
                ?TubeStarts = TubeStarts,
                ?CameraProjectionType = CameraProjectionType,
                ?Camera = Camera,
                ?UseDefaults = UseDefaults

            )

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
        [<Extension>]
        static member Volume
            (
                x,
                y,
                z,
                value,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ColorBar: ColorBar,
                ?IsoMin: float,
                ?IsoMax: float,
                ?Caps: Caps,
                ?Slices: Slices,
                ?Surface: Surface,
                ?OpacityScale: seq<#seq<#IConvertible>>,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let cameraProjection =
                defaultArg CameraProjectionType StyleParam.CameraProjectionType.Perspective

            let camera =
                Camera
                |> Option.defaultValue (LayoutObjects.Camera.init ())
                |> LayoutObjects.Camera.style (Projection = CameraProjection.init (ProjectionType = cameraProjection))

            Trace3D.initVolume (
                Trace3DStyle.Volume(
                    X = x,
                    Y = y,
                    Z = z,
                    Value = value,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ColorBar = ColorBar,
                    ?IsoMin = IsoMin,
                    ?IsoMax = IsoMax,
                    ?Caps = Caps,
                    ?Slices = Slices,
                    ?Surface = Surface,
                    ?OpacityScale = OpacityScale
                )
            )

            |> GenericChart.ofTraceObject useDefaults
            |> GenericChart.addLayout (
                Layout.init () |> Layout.setScene (StyleParam.SubPlotId.Scene 1, Scene.init (Camera = camera))
            )

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
        [<Extension>]
        static member IsoSurface
            (
                x,
                y,
                z,
                value,
                ?Name: string,
                ?ShowLegend: bool,
                ?Opacity: float,
                ?Text: #IConvertible,
                ?MultiText: seq<#IConvertible>,
                ?ColorScale: StyleParam.Colorscale,
                ?ShowScale: bool,
                ?ColorBar: ColorBar,
                ?IsoMin: float,
                ?IsoMax: float,
                ?Caps: Caps,
                ?Slices: Slices,
                ?Surface: Surface,
                ?CameraProjectionType: StyleParam.CameraProjectionType,
                ?Camera: Camera,
                ?UseDefaults: bool
            ) =

            let useDefaults =
                defaultArg UseDefaults true

            let cameraProjection =
                defaultArg CameraProjectionType StyleParam.CameraProjectionType.Perspective

            let camera =
                Camera
                |> Option.defaultValue (LayoutObjects.Camera.init ())
                |> LayoutObjects.Camera.style (Projection = CameraProjection.init (ProjectionType = cameraProjection))

            Trace3D.initIsoSurface (
                Trace3DStyle.IsoSurface(
                    X = x,
                    Y = y,
                    Z = z,
                    Value = value,
                    ?Name = Name,
                    ?ShowLegend = ShowLegend,
                    ?Opacity = Opacity,
                    ?Text = Text,
                    ?MultiText = MultiText,
                    ?ColorScale = ColorScale,
                    ?ShowScale = ShowScale,
                    ?ColorBar = ColorBar,
                    ?IsoMin = IsoMin,
                    ?IsoMax = IsoMax,
                    ?Caps = Caps,
                    ?Slices = Slices,
                    ?Surface = Surface

                )
            )
            |> GenericChart.ofTraceObject useDefaults
            |> GenericChart.addLayout (
                Layout.init () |> Layout.setScene (StyleParam.SubPlotId.Scene 1, Scene.init (Camera = camera))
            )
