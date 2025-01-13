namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

/// Hoverlabels that appear while hovering over elements on charts
type Hoverlabel() =
    inherit DynamicObj()

    /// <summary>
    /// Returns a new Hoverlabel object with the given styles
    /// </summary>
    /// <param name="Align">Sets the horizontal alignment of the text content within hover label box. Has an effect only if the hover label text spans more two or more lines</param>
    /// <param name="BgColor">Sets the background color of all hover labels on graph</param>
    /// <param name="BorderColor">Sets the border color of all hover labels on graph.</param>
    /// <param name="Font">Sets the default hover label font used by all traces on the graph.</param>
    /// <param name="GroupTitleFont">Sets the font for group titles in hover (unified modes). Defaults to `hoverlabel.font`.</param>
    /// <param name="Namelength">Sets the default length (in number of characters) of the trace name in the hover labels for all traces. -1 shows the whole name regardless of length. 0-3 shows the first 0-3 characters, and an integer &gt;3 will show the whole name if it is less than that many characters, but if it is longer, will truncate to `namelength - 3` characters and add an ellipsis.</param>
    static member init
        (
            ?Align: StyleParam.Align,
            ?BgColor: Color,
            ?BorderColor: Color,
            ?Font: Font,
            ?GroupTitleFont: Font,
            ?Namelength: int
        ) =
        Hoverlabel()
        |> Hoverlabel.style (
            ?BgColor = BgColor,
            ?BorderColor = BorderColor,
            ?Font = Font,
            ?GroupTitleFont = GroupTitleFont,
            ?Align = Align,
            ?Namelength = Namelength
        )


    /// <summary>
    /// Returns a function that applies the given styles to a Legend object
    /// </summary>
    /// <param name="Align">Sets the horizontal alignment of the text content within hover label box. Has an effect only if the hover label text spans more two or more lines</param>
    /// <param name="BgColor">Sets the background color of all hover labels on graph</param>
    /// <param name="BorderColor">Sets the border color of all hover labels on graph.</param>
    /// <param name="Font">Sets the default hover label font used by all traces on the graph.</param>
    /// <param name="GroupTitleFont">Sets the font for group titles in hover (unified modes). Defaults to `hoverlabel.font`.</param>
    /// <param name="Namelength">Sets the default length (in number of characters) of the trace name in the hover labels for all traces. -1 shows the whole name regardless of length. 0-3 shows the first 0-3 characters, and an integer &gt;3 will show the whole name if it is less than that many characters, but if it is longer, will truncate to `namelength - 3` characters and add an ellipsis.</param>
    static member style
        (
            ?BgColor: Color,
            ?BorderColor: Color,
            ?Font: Font,
            ?GroupTitleFont: Font,
            ?Align: StyleParam.Align,
            ?Namelength: int
        ) =
        (fun (label: Hoverlabel) ->

            label
            |> DynObj.withOptionalProperty "bgcolor" BgColor
            |> DynObj.withOptionalProperty "bordercolor" BorderColor
            |> DynObj.withOptionalProperty "font" Font
            |> DynObj.withOptionalProperty "grouptitlefont" GroupTitleFont
            |> DynObj.withOptionalPropertyBy "align" Align StyleParam.Align.convert
            |> DynObj.withOptionalProperty "namelength" Namelength
        )
