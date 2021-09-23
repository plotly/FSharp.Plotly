namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type Gradient () =
    inherit DynamicObj () 

    static member init 
        (
            [<Optional;DefaultParameterValue(null)>] ?Color     : Color,
            [<Optional;DefaultParameterValue(null)>] ?Type      : StyleParam.GradientType,
            [<Optional;DefaultParameterValue(null)>] ?MultiTypes: seq<StyleParam.GradientType>
        ) =
            Gradient()
            |> Gradient.style
                (
                    ?Color      = Color,
                    ?Type       = Type,
                    ?MultiTypes = MultiTypes
                )

    static member style
        (
            [<Optional;DefaultParameterValue(null)>] ?Color     : Color,
            [<Optional;DefaultParameterValue(null)>] ?Type      : StyleParam.GradientType,
            [<Optional;DefaultParameterValue(null)>] ?MultiTypes: seq<StyleParam.GradientType>
        ) =

            fun (gradient: Gradient) ->
                
                (Type,MultiTypes)   |> DynObj.setSingleOrMultiOpt gradient "type"

                Color               |> DynObj.setValueOpt gradient "color"
               
                gradient
