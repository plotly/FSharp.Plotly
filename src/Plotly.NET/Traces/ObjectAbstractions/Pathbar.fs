namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type Pathbar() =
    inherit DynamicObj()

    ///Initializes pathbar object (used in Chart.Treemap)
    ///
    ///Parameters:
    ///
    ///Visible  : Determines if the path bar is drawn i.e. outside the trace `domain` and with one pixel gap.
    ///
    ///Side     : Determines on which side of the the treemap the `pathbar` should be presented.
    ///
    ///EdgeShape: Determines which shape is used for edges between `pathbar` labels.
    ///
    ///Thickness: Sets the thickness of `pathbar` (in px). If not specified the `pathbar.textfont.size` is used with 3 pixles extra padding on each side.
    ///
    ///Textfont : Sets the font used inside `pathbar`.
    static member init
        (
            ?Visible: bool,
            ?Side: StyleParam.Side,
            ?EdgeShape: StyleParam.PathbarEdgeShape,
            ?Thickness: float,
            ?Textfont: Font
        ) =

        Pathbar()
        |> Pathbar.style (
            ?Visible = Visible,
            ?Side = Side,
            ?EdgeShape = EdgeShape,
            ?Thickness = Thickness,
            ?Textfont = Textfont
        )

    ///Applies the given styles to the given pathbar object
    ///
    ///Parameters:
    ///
    ///Visible  : Determines if the path bar is drawn i.e. outside the trace `domain` and with one pixel gap.
    ///
    ///Side     : Determines on which side of the the treemap the `pathbar` should be presented.
    ///
    ///EdgeShape: Determines which shape is used for edges between `pathbar` labels.
    ///
    ///Thickness: Sets the thickness of `pathbar` (in px). If not specified the `pathbar.textfont.size` is used with 3 pixles extra padding on each side.
    ///
    ///Textfont : Sets the font used inside `pathbar`.
    static member style
        (
            ?Visible: bool,
            ?Side: StyleParam.Side,
            ?EdgeShape: StyleParam.PathbarEdgeShape,
            ?Thickness: float,
            ?Textfont: Font
        ) =
        fun (pathbar: Pathbar) ->

            pathbar
            |> DynObj.withOptionalProperty "visible" Visible
            |> DynObj.withOptionalPropertyBy "side" Side StyleParam.Side.convert
            |> DynObj.withOptionalPropertyBy "edgeshape" EdgeShape StyleParam.PathbarEdgeShape.convert
            |> DynObj.withOptionalProperty "thickness" Thickness
            |> DynObj.withOptionalProperty "textfont" Textfont
