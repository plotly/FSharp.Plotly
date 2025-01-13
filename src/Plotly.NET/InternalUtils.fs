[<AutoOpen>]
module internal InternalUtils

open DynamicObj
open System.Runtime.InteropServices
open System.IO
open System.Reflection
open System

let combineOptSeqs (first: seq<'A> option) (second: seq<'A> option) =
    match first, second with
    | Some f, Some s -> Some(Seq.append f s)
    | Some f, None -> Some f
    | None, Some s -> Some s
    | _ -> None

let combineOptLists (first: List<'A> option) (second: List<'A> option) =
    match first, second with
    | Some f, Some s -> Some(List.append f s)
    | Some f, None -> Some f
    | None, Some s -> Some s
    | _ -> None

let getFullPlotlyJS () =
    let assembly =
        Assembly.GetExecutingAssembly()

    use str =
        assembly.GetManifestResourceStream($"Plotly.NET.plotly-{Globals.PLOTLYJS_VERSION}.min.js")

    use r = new StreamReader(str)
    r.ReadToEnd()

[<AutoOpen>]
module DynObj =

    let setOptionalSingleOrMultiProperty (propName: string) (single: 'A option, multi: seq<'A> option) (dyn: #DynamicObj) =
        if multi.IsSome then
            dyn |> DynObj.setOptionalProperty propName multi
        else
            dyn |> DynObj.setOptionalProperty propName single

    let inline withOptionalSingleOrMultiProperty (propName: string) (single: 'A option, multi: seq<'A> option) (dyn: #DynamicObj) =
        dyn |> setOptionalSingleOrMultiProperty propName (single,multi)
        dyn

    let setOptionalSingleOrMultiPropertyBy
        (propName: string)
        (single: 'A option, multi: seq<'A> option)
        (f: 'A -> 'B)
        (dyn: #DynamicObj)
        =
        if multi.IsSome then
            dyn |> DynObj.setOptionalPropertyBy propName multi (Seq.map f)
        else
            dyn |> DynObj.setOptionalPropertyBy propName single f

    let inline withOptionalSingleOrMultiPropertyBy
        (propName: string)
        (single: 'A option, multi: seq<'A> option)
        (f: 'A -> 'B)
        (dyn: #DynamicObj)
        =
        dyn |> setOptionalSingleOrMultiPropertyBy propName (single,multi) f
        dyn

    let setOptionalSingleOrAnyProperty (propName: string) (single: 'A option, any: 'B option) (dyn: #DynamicObj)  =
        if any.IsSome then
            dyn |> DynObj.setOptionalProperty propName any
        else
            dyn |> DynObj.setOptionalProperty propName single

    let inline withOptionalSingleOrAnyProperty (propName: string) (single: 'A option, any: 'B option) (dyn: #DynamicObj) =
        dyn |> setOptionalSingleOrAnyProperty propName (single, any)
        dyn

    let setOptionalSingleOrAnyPropertyBy
        (propName: string)
        (single: 'A option, any: 'B option)
        (singleF: 'A -> 'C)
        (anyF: 'B -> 'D)
        (dyn: #DynamicObj)
        =
        if any.IsSome then
            dyn |> DynObj.setOptionalPropertyBy propName any (Seq.map anyF)
        else
            dyn |> DynObj.setOptionalPropertyBy propName single singleF

    let inline withOptionalSingleOrAnyPropertyBy
        (propName: string)
        (single: 'A option, any: 'B option)
        (singleF: 'A -> 'C)
        (anyF: 'B -> 'D)
        (dyn: #DynamicObj)
        =
        dyn |> setOptionalSingleOrAnyPropertyBy propName (single, any) singleF anyF
        dyn

// Copied from FSharp.Care.Collections to remove dependencies
[<AutoOpen>]
module internal Seq =

    /// Splits a sequence of pairs into two sequences
    let unzip (input: seq<_>) =
        let (lstA, lstB) =
            Seq.foldBack (fun (a, b) (accA, accB) -> a :: accA, b :: accB) input ([], [])

        (Seq.ofList lstA, Seq.ofList lstB)

    /// Splits a sequence of triples into three sequences
    let unzip3 (input: seq<_>) =
        let (lstA, lstB, lstC) =
            Seq.foldBack (fun (a, b, c) (accA, accB, accC) -> a :: accA, b :: accB, c :: accC) input ([], [], [])

        (Seq.ofList lstA, Seq.ofList lstB, Seq.ofList lstC)

[<AutoOpen>]
module internal ChartIO =

    ///Choose process to open plots with depending on OS. Thanks to @zyzhu for hinting at a solution (https://github.com/plotly/Plotly.NET/issues/31)
    let openOsSpecificFile path =
        if RuntimeInformation.IsOSPlatform(OSPlatform.Windows) then
            let psi =
                new System.Diagnostics.ProcessStartInfo(FileName = path, UseShellExecute = true)

            System.Diagnostics.Process.Start(psi) |> ignore
        elif RuntimeInformation.IsOSPlatform(OSPlatform.Linux) then
            System.Diagnostics.Process.Start("xdg-open", path) |> ignore
        elif RuntimeInformation.IsOSPlatform(OSPlatform.OSX) then
            System.Diagnostics.Process.Start("open", path) |> ignore
        else
            invalidOp "Not supported OS platform"

[<AttributeUsage(AttributeTargets.Class)>]
type internal TypeFormatterSourceAttribute(formatterSourceType: Type) =
    inherit Attribute()
    let mutable preferredMimeTypes : string[] = [||] 
    member this.TypeFormatterSourceType = formatterSourceType
    member this.PreferredMimeTypes
        with get() = preferredMimeTypes 
        and set(v) = preferredMimeTypes <- v
            