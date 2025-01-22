module Tests.Interactive.Formatting

open Expecto

open System
open System.IO

open Microsoft.DotNet.Interactive
open Microsoft.DotNet.Interactive.Formatting

module ConventionBased =

    [<AttributeUsage(AttributeTargets.Class)>]
    type internal TypeFormatterSourceAttribute(formatterSourceType: Type) =
        inherit Attribute()
        let mutable preferredMimeTypes : string[] = [||] 
        member this.TypeFormatterSourceType = formatterSourceType
        member this.PreferredMimeTypes
            with get() = preferredMimeTypes 
            and set(v) = preferredMimeTypes <- v
            
    [<TypeFormatterSourceAttribute(typeof<CustomFormatterSource>)>]
    type TypeWithCustomFormatter() = class end

    and CustomFormatter() =
        let mutable mimeType = "text/html"
        member this.MimeType
            with get() = mimeType
            and set(v) = mimeType <- v
        member this.Format(instance:obj, writer:TextWriter) = 
            match instance with
            | :? TypeWithCustomFormatter as c -> 
                writer.Write("Formatting successfull!")
                true
            | _ -> false

    and CustomFormatterSource =
            member this.CreateTypeFormatters() : seq<obj> =
                seq {
                    yield CustomFormatter()
                }

[<Tests>]
let ``Convention-based Formatting`` =
    testList "Convention-based Formatting" [
        testCase "Convention based formatter sources can provide lazy registration of custom formatters" <| fun _ ->
            let o = ConventionBased.TypeWithCustomFormatter()
            let formatted = o.ToDisplayString()
            Expect.equal formatted "Formatting successfull!" "Formatting failed"

    ]