namespace Plotly.NET

open Plotly.NET.LayoutObjects

open DynamicObj
open System.Runtime.InteropServices


type Template() =
    inherit DynamicObj()

    static member init(layoutTemplate: Layout, ?TraceTemplates: seq<#Trace>) =
        Template() |> Template.style (layoutTemplate, ?TraceTemplates = TraceTemplates)

    static member style
        (
            layoutTemplate: Layout,
            ?TraceTemplates: seq<#Trace>
        ) =
        fun (template: Template) ->

            let traceTemplates =
                TraceTemplates
                |> Option.map (fun traceTemplates ->
                    traceTemplates
                    |> Seq.groupBy (fun t -> t.``type``)
                    |> (fun groupedTemplates ->
                        groupedTemplates
                        |> Seq.map (fun (id, templates) ->
                            id,
                            templates
                            |> Seq.map (fun t ->
                                let tmp = DynamicObj()
                                t.CopyDynamicPropertiesTo(tmp)
                                tmp)

                        )))
                |> fun traceTemplates ->
                    let tmp = DynamicObj()

                    traceTemplates
                    |> Option.iter (Seq.iter (fun (id, traceTemplate) ->  tmp |> DynObj.setProperty id traceTemplate))

                    tmp

            template
            |> DynObj.withProperty "layout" layoutTemplate 
            |> DynObj.withProperty "data"   traceTemplates 

    static member mapLayoutTemplate (styleF: Layout -> Layout) (template: Template) =
        let l = template.TryGetTypedPropertyValue<Layout>("layout") 
        template
        |> DynObj.withOptionalPropertyBy "layout" l (styleF)

    static member mapTraceTemplates (styleF: #Trace[] -> #Trace[]) (template: Template) =
        let l = template.TryGetTypedPropertyValue<#Trace[]>("data") 
        template
        |> DynObj.withOptionalPropertyBy "data" l (styleF)

    static member withColorWay (colorway: Color) (template: Template) =
        template
        |> Template.mapLayoutTemplate (fun l ->
            l |> DynObj.withProperty "colorway" colorway
        )
