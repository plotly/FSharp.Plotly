namespace Plotly.NET

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

type AutoRangeOptions() =
    inherit DynamicObj()

    /// <summary>
    /// Returns a new AutoRangeOptions object with the given styling.
    /// </summary>
    /// <param name="ClipMax">Clip autorange maximum if it goes beyond this value. Has no effect when `autorangeoptions.maxallowed` is provided.</param>
    /// <param name="ClipMin">Clip autorange minimum if it goes beyond this value. Has no effect when `autorangeoptions.minallowed` is provided.</param>
    /// <param name="Include">Ensure this value is included in autorange.</param>
    /// <param name="MaxAllowed">Use this value exactly as autorange maximum.</param>
    /// <param name="MinAllowed">Use this value exactly as autorange minimum.</param>
    static member init
        (
            ?ClipMax: #IConvertible,
            ?ClipMin: #IConvertible,
            ?Include: #IConvertible,
            ?MaxAllowed: #IConvertible,
            ?MinAllowed: #IConvertible
        ) =
        AutoRangeOptions()
        |> AutoRangeOptions.style (
            ?ClipMax = ClipMax,
            ?ClipMin = ClipMin,
            ?Include = Include,
            ?MaxAllowed = MaxAllowed,
            ?MinAllowed = MinAllowed
        )

    /// <summary>
    /// Returns a function that applies the given styles to a AutoRangeOptions object.
    /// </summary>
    /// <param name="ClipMax">Clip autorange maximum if it goes beyond this value. Has no effect when `autorangeoptions.maxallowed` is provided.</param>
    /// <param name="ClipMin">Clip autorange minimum if it goes beyond this value. Has no effect when `autorangeoptions.minallowed` is provided.</param>
    /// <param name="Include">Ensure this value is included in autorange.</param>
    /// <param name="MaxAllowed">Use this value exactly as autorange maximum.</param>
    /// <param name="MinAllowed">Use this value exactly as autorange minimum.</param>
    static member style
        (
            ?ClipMax: #IConvertible,
            ?ClipMin: #IConvertible,
            ?Include: #IConvertible,
            ?MaxAllowed: #IConvertible,
            ?MinAllowed: #IConvertible

        ) =
        (fun (autoRangeOptions: AutoRangeOptions) ->

            autoRangeOptions
            |> DynObj.withOptionalProperty "clipmax" ClipMax
            |> DynObj.withOptionalProperty "clipmin" ClipMin
            |> DynObj.withOptionalProperty "include" Include
            |> DynObj.withOptionalProperty "maxallowed" MaxAllowed
            |> DynObj.withOptionalProperty "minallowed" MinAllowed
        )