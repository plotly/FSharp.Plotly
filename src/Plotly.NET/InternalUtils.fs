[<AutoOpen>]
module internal InternalUtils

    open DynamicObj
    
    [<AutoOpen>]
    module DynObj =

        let setSingleOrMultiOpt (dyn:#DynamicObj) (propName:string) (single:'A option, multi:seq<'A> option) =
            if multi.IsSome then
                multi |> DynObj.setValueOpt dyn propName
            else
                single |> DynObj.setValueOpt dyn propName

        let setSingleOrMultiOptBy (dyn:#DynamicObj) (propName:string) (f:'A -> 'B) (single:'A option, multi:seq<'A> option) =
            if multi.IsSome then
                multi |> DynObj.setValueOptBy dyn propName (Seq.map f)
            else
                single |> DynObj.setValueOptBy dyn propName f
