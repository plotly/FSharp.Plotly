namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

/// Error type inherits from dynamic object
type Error () =
    inherit DynamicObj ()
    
    /// <summary>Init Error type</summary>
    /// <param name ="Visible">Determines whether or not this set of error bars is visible.</param>
    /// <param name ="Type">Determines the rule used to generate the error bars. If "constant`, the bar lengths are of a constant value. Set this constant in `value`. If "percent", the bar lengths correspond to a percentage of underlying data. Set this percentage in `value`. If "sqrt", the bar lengths correspond to the square of the underlying data. If "data", the bar lengths are set with data set `array`.</param>
    /// <param name ="Symmetric">Determines whether or not the error bars have the same length in both direction (top/bottom for vertical bars, left/right for horizontal bars.</param>
    /// <param name ="Array">Sets the data corresponding the length of each error bar. Values are plotted relative to the underlying data.</param>
    /// <param name ="Arrayminus">Sets the data corresponding the length of each error bar in the bottom (left) direction for vertical (horizontal) bars Values are plotted relative to the underlying data.</param>
    /// <param name ="Value">Sets the value of either the percentage (if `type` is set to "percent") or the constant (if `type` is set to "constant") corresponding to the lengths of the error bars.</param>
    /// <param name ="Valueminus">Sets the value of either the percentage (if `type` is set to "percent") or the constant (if `type` is set to "constant") corresponding to the lengths of the error bars in the bottom (left) direction for vertical (horizontal) bars</param>
    /// <param name ="Traceref"></param>
    /// <param name ="Tracerefminus"></param>
    /// <param name ="Copy_ystyle"></param>
    /// <param name ="Color">Sets the stoke color of the error bars.</param>
    /// <param name ="Thickness">Sets the thickness (in px) of the error bars.</param>
    /// <param name ="Width">Sets the width (in px) of the cross-bar at both ends of the error bars.</param>
    static member init
        (   
            [<Optional;DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional;DefaultParameterValue(null)>] ?Type: StyleParam.ErrorType,
            [<Optional;DefaultParameterValue(null)>] ?Symmetric: bool,
            [<Optional;DefaultParameterValue(null)>] ?Array: seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Arrayminus: seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Value: float,
            [<Optional;DefaultParameterValue(null)>] ?Valueminus: float,
            [<Optional;DefaultParameterValue(null)>] ?Traceref: int,
            [<Optional;DefaultParameterValue(null)>] ?Tracerefminus: int,
            [<Optional;DefaultParameterValue(null)>] ?Copy_ystyle: bool,
            [<Optional;DefaultParameterValue(null)>] ?Color: Color,
            [<Optional;DefaultParameterValue(null)>] ?Thickness: float,
            [<Optional;DefaultParameterValue(null)>] ?Width: float
        ) =
            Error() 
            |> Error.style
                (   
                   ?Symmetric     =  Symmetric     ,
                   ?Array         =  Array         ,
                   ?Arrayminus    =  Arrayminus    ,
                   ?Value         =  Value         ,
                   ?Valueminus    =  Valueminus    ,
                   ?Traceref      =  Traceref      ,
                   ?Tracerefminus =  Tracerefminus ,
                   ?Copy_ystyle   =  Copy_ystyle   ,
                   ?Color         =  Color         ,
                   ?Thickness     =  Thickness     ,
                   ?Width         =  Width         
                )

    /// <summary>Creates a function that applies the given style parameters to an Error object</summary>
    /// <param name ="Visible">Determines whether or not this set of error bars is visible.</param>
    /// <param name ="Type">Determines the rule used to generate the error bars. If "constant`, the bar lengths are of a constant value. Set this constant in `value`. If "percent", the bar lengths correspond to a percentage of underlying data. Set this percentage in `value`. If "sqrt", the bar lengths correspond to the square of the underlying data. If "data", the bar lengths are set with data set `array`.</param>
    /// <param name ="Symmetric">Determines whether or not the error bars have the same length in both direction (top/bottom for vertical bars, left/right for horizontal bars.</param>
    /// <param name ="Array">Sets the data corresponding the length of each error bar. Values are plotted relative to the underlying data.</param>
    /// <param name ="Arrayminus">Sets the data corresponding the length of each error bar in the bottom (left) direction for vertical (horizontal) bars Values are plotted relative to the underlying data.</param>
    /// <param name ="Value">Sets the value of either the percentage (if `type` is set to "percent") or the constant (if `type` is set to "constant") corresponding to the lengths of the error bars.</param>
    /// <param name ="Valueminus">Sets the value of either the percentage (if `type` is set to "percent") or the constant (if `type` is set to "constant") corresponding to the lengths of the error bars in the bottom (left) direction for vertical (horizontal) bars</param>
    /// <param name ="Traceref"></param>
    /// <param name ="Tracerefminus"></param>
    /// <param name ="Copy_ystyle"></param>
    /// <param name ="Color">Sets the stoke color of the error bars.</param>
    /// <param name ="Thickness">Sets the thickness (in px) of the error bars.</param>
    /// <param name ="Width">Sets the width (in px) of the cross-bar at both ends of the error bars.</param>
    static member style
        (   
            [<Optional;DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional;DefaultParameterValue(null)>] ?Type: StyleParam.ErrorType,
            [<Optional;DefaultParameterValue(null)>] ?Symmetric: bool,
            [<Optional;DefaultParameterValue(null)>] ?Array: seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Arrayminus: seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Value: float,
            [<Optional;DefaultParameterValue(null)>] ?Valueminus: float,
            [<Optional;DefaultParameterValue(null)>] ?Traceref: int,
            [<Optional;DefaultParameterValue(null)>] ?Tracerefminus: int,
            [<Optional;DefaultParameterValue(null)>] ?Copy_ystyle: bool,
            [<Optional;DefaultParameterValue(null)>] ?Color: Color,
            [<Optional;DefaultParameterValue(null)>] ?Thickness: float,
            [<Optional;DefaultParameterValue(null)>] ?Width: float

        ) =
            (fun (error:Error) -> 
                Visible         |> DynObj.setValueOpt error "visible"
                Type            |> DynObj.setValueOptBy error "type" StyleParam.ErrorType.convert
                Symmetric       |> DynObj.setValueOpt error "symmetric"
                Array           |> DynObj.setValueOpt error "array"
                Arrayminus      |> DynObj.setValueOpt error "arrayminus"
                Value           |> DynObj.setValueOpt error "value"
                Valueminus      |> DynObj.setValueOpt error "valueminus"
                Traceref        |> DynObj.setValueOpt error "traceref"
                Tracerefminus   |> DynObj.setValueOpt error "tracerefminus"
                Copy_ystyle     |> DynObj.setValueOpt error "copy_ystyle"
                Color           |> DynObj.setValueOpt error "color"
                Thickness       |> DynObj.setValueOpt error "thickness"
                Width           |> DynObj.setValueOpt error "width"

                // out ->
                error
            )
    
 
            