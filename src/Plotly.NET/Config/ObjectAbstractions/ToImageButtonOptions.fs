namespace Plotly.NET.ConfigObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type ToImageButtonOptions() =
    inherit DynamicObj()

    static member init
        (
            ?Format: StyleParam.ImageFormat,
            ?Filename: string,
            ?Width: float,
            ?Height: float,
            ?Scale: float
        ) =
        ToImageButtonOptions()
        |> ToImageButtonOptions.style (
            ?Format = Format,
            ?Filename = Filename,
            ?Width = Width,
            ?Height = Height,
            ?Scale = Scale
        )

    static member style
        (
            ?Format,
            ?Filename,
            ?Width,
            ?Height,
            ?Scale
        ) =
        fun (btnConf: ToImageButtonOptions) ->
            btnConf
            |> DynObj.withOptionalPropertyBy "format"    Format      StyleParam.ImageFormat.toString
            |> DynObj.withOptionalProperty   "filename"  Filename    
            |> DynObj.withOptionalProperty   "width"     Width       
            |> DynObj.withOptionalProperty   "height"    Height      
            |> DynObj.withOptionalProperty   "scale"     Scale       
