namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

/// Hoverlabel type inherits from dynamic object
type Hoverlabel() =
    inherit DynamicObj()

    /// Initialized Line object
    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?BgColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?BorderColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?Font: Font,
            [<Optional; DefaultParameterValue(null)>] ?Align: StyleParam.Align,
            [<Optional; DefaultParameterValue(null)>] ?Namelength: int
        ) =
        Hoverlabel()
        |> Hoverlabel.style (
            ?BgColor = BgColor,
            ?BorderColor = BorderColor,
            ?Font = Font,
            ?Align = Align,
            ?Namelength = Namelength
        )


    // Applies the styles to Line()
    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?BgColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?BorderColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?Font: Font,
            [<Optional; DefaultParameterValue(null)>] ?Align: StyleParam.Align,
            [<Optional; DefaultParameterValue(null)>] ?Namelength: int
        ) =
        (fun (label: Hoverlabel) ->
            ++? ("bgcolor", BgColor )
            ++? ("bordercolor", BorderColor )
            ++? ("font", Font )
            Align |> DynObj.setValueOptBy label "align" StyleParam.Align.convert
            ++? ("namelength", Namelength )

            // out ->
            label)
