namespace Plotly.NET

open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open System
open System.Runtime.InteropServices

/// Trace type inherits from dynamic object
type Trace (traceTypeName) =
    inherit DynamicObj ()
    //interface ITrace with
        // Implictit ITrace
    member val ``type`` = traceTypeName with get,set

    static member tryGetTypedMember<'T> (propName:string) (trace: Trace) =
        trace.TryGetTypedValue<'T>(propName)

//-------------------------------------------------------------------------------------------------------------------------------------------------
/// Functions provide the styling of the Chart objects
/// These functions are used internally to style traces of Chart objects. Users are usually pointed
/// to the API layer provided by the `Chart` module/object
type TraceStyle() =
    /// Applies the given TraceInfo style parameters to a Trace object.
    static member TraceInfo
        (    
            [<Optional;DefaultParameterValue(null)>] ?Name: string,
            [<Optional;DefaultParameterValue(null)>] ?Visible: StyleParam.Visible,
            [<Optional;DefaultParameterValue(null)>] ?ShowLegend: bool,
            [<Optional;DefaultParameterValue(null)>] ?LegendGroup:string,
            [<Optional;DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional;DefaultParameterValue(null)>] ?Uid: string,
            [<Optional;DefaultParameterValue(null)>] ?Hoverinfo: string
            //?Stream: Stream

        ) =
            (fun (trace:('T :> Trace)) ->  
                Name        |> DynObj.setValueOpt trace "name"
                Visible     |> DynObj.setValueOptBy trace "visible" StyleParam.Visible.toString
                ShowLegend  |> DynObj.setValueOpt trace "showlegend"
                LegendGroup |> DynObj.setValueOpt trace "legendgroup"  
                Opacity     |> DynObj.setValueOpt trace "opacity"
                Uid         |> DynObj.setValueOpt trace "uid"
                Hoverinfo   |> DynObj.setValueOpt trace "hoverinfo"
                // Update
                //Stream: Stream                    
                    
                // out ->
                trace
            ) 

    /// Sets selection of data points on a Trace object.
    static member SetSelection
        (
            [<Optional;DefaultParameterValue(null)>] ?Selectedpoints,
            [<Optional;DefaultParameterValue(null)>] ?Selected,
            [<Optional;DefaultParameterValue(null)>] ?UnSelected
        ) =  
            (fun (trace:('T :> Trace)) ->

                Selectedpoints |> DynObj.setValueOpt trace "Selectedpoints"
                Selected       |> DynObj.setValueOpt trace "Selected"
                UnSelected     |> DynObj.setValueOpt trace "UnSelected"
            
                trace
            )


    /// Sets the given text label styles on a Trace object.
    static member TextLabel
        (    
            [<Optional;DefaultParameterValue(null)>] ?Text   : seq<#IConvertible>,
            [<Optional;DefaultParameterValue(null)>] ?Textposition: StyleParam.TextPosition,
            [<Optional;DefaultParameterValue(null)>] ?Textfont: Font,
            [<Optional;DefaultParameterValue(null)>] ?Textsrc : string,
            [<Optional;DefaultParameterValue(null)>] ?Textpositionsrc : string

        ) =
            (fun (trace:('T :> Trace)) ->
                Text            |> DynObj.setValueOpt trace "text"
                Textposition    |> DynObj.setValueOptBy trace "textposition" StyleParam.TextPosition.toString                  
                Textsrc         |> DynObj.setValueOpt trace "textsrc"
                Textpositionsrc |> DynObj.setValueOpt trace "textpositionsrc"
                Textfont        |> DynObj.setValueOpt trace "textfont"
                    
                // out ->
                trace
            )  


    /// Sets the given line on a Trace object.
    static member SetLine
        (
            line:Line
        ) =  
            (fun (trace:('T :> Trace)) ->

                trace.SetValue("line", line)
                trace
            )


    /// Sets the given Line styles on the line property of a Trace object
    static member Line
        (
            [<Optional;DefaultParameterValue(null)>] ?Width: float,
            [<Optional;DefaultParameterValue(null)>] ?Color: Color,
            [<Optional;DefaultParameterValue(null)>] ?Shape: StyleParam.Shape,
            [<Optional;DefaultParameterValue(null)>] ?Dash: StyleParam.DrawingStyle,
            [<Optional;DefaultParameterValue(null)>] ?Smoothing: float,
            [<Optional;DefaultParameterValue(null)>] ?Colorscale : StyleParam.Colorscale
        ) =
            (fun (trace:('T :> Trace)) ->
                let line =
                    match (trace.TryGetValue "line") with
                    | Some line -> line :?> Line
                    | None -> Line.init()
                    |> Line.style(?Width=Width,?Color=Color,?Shape=Shape,?Dash=Dash,?Smoothing=Smoothing,?Colorscale=Colorscale)
                    
                trace.SetValue("line", line)
                trace
            )    


    /// Sets the given marker on a Trace object.
    static member SetMarker
        (
            marker:Marker
        ) =  
            (fun (trace:('T :> Trace)) ->

                trace.SetValue("marker", marker)
                trace
            )

    /// Sets the given Marker styles on the marker property of a Trace object
    static member Marker
        (   
            [<Optional;DefaultParameterValue(null)>] ?AutoColorScale    : bool,
            [<Optional;DefaultParameterValue(null)>] ?CAuto             : bool,
            [<Optional;DefaultParameterValue(null)>] ?CMax              : float,
            [<Optional;DefaultParameterValue(null)>] ?CMid              : float,
            [<Optional;DefaultParameterValue(null)>] ?CMin              : float,
            [<Optional;DefaultParameterValue(null)>] ?Color             : Color,
            [<Optional;DefaultParameterValue(null)>] ?Colors            : seq<Color>,
            [<Optional;DefaultParameterValue(null)>] ?ColorAxis         : StyleParam.SubPlotId,
            [<Optional;DefaultParameterValue(null)>] ?ColorBar          : ColorBar,
            [<Optional;DefaultParameterValue(null)>] ?Colorscale        : StyleParam.Colorscale,
            [<Optional;DefaultParameterValue(null)>] ?Gradient          : Gradient,
            [<Optional;DefaultParameterValue(null)>] ?Outline           : Line,
            [<Optional;DefaultParameterValue(null)>] ?Size              : int,
            [<Optional;DefaultParameterValue(null)>] ?MultiSize         : seq<int>,
            [<Optional;DefaultParameterValue(null)>] ?Opacity           : float,
            [<Optional;DefaultParameterValue(null)>] ?MultiOpacity      : seq<float>,
            [<Optional;DefaultParameterValue(null)>] ?Pattern           : Pattern,
            [<Optional;DefaultParameterValue(null)>] ?Symbol            : StyleParam.MarkerSymbol,
            [<Optional;DefaultParameterValue(null)>] ?MultiSymbols      : seq<StyleParam.MarkerSymbol>,
            [<Optional;DefaultParameterValue(null)>] ?OutlierColor      : Color,
            [<Optional;DefaultParameterValue(null)>] ?Maxdisplayed      : int,
            [<Optional;DefaultParameterValue(null)>] ?ReverseScale      : bool,
            [<Optional;DefaultParameterValue(null)>] ?ShowScale         : bool,
            [<Optional;DefaultParameterValue(null)>] ?SizeMin           : int,
            [<Optional;DefaultParameterValue(null)>] ?SizeMode          : StyleParam.MarkerSizeMode,
            [<Optional;DefaultParameterValue(null)>] ?SizeRef           : int
        ) =
            (fun (trace:('T :> Trace)) ->
                let marker =
                    trace
                    |> Trace.tryGetTypedMember<Marker> "marker"
                    |> Option.defaultValue (Marker.init())
                    |> Marker.style(
                        ?AutoColorScale    = AutoColorScale,
                        ?CAuto             = CAuto         ,
                        ?CMax              = CMax          ,
                        ?CMid              = CMid          ,
                        ?CMin              = CMin          ,
                        ?Color             = Color         ,
                        ?Colors            = Colors        ,
                        ?ColorAxis         = ColorAxis     ,
                        ?ColorBar          = ColorBar      ,
                        ?Colorscale        = Colorscale    ,
                        ?Gradient          = Gradient      ,
                        ?Outline           = Outline       ,
                        ?Size              = Size          ,
                        ?MultiSize         = MultiSize     ,
                        ?Opacity           = Opacity       ,
                        ?MultiOpacity      = MultiOpacity  ,
                        ?Pattern           = Pattern       ,
                        ?Symbol            = Symbol        ,
                        ?MultiSymbols      = MultiSymbols  ,
                        ?OutlierColor      = OutlierColor  ,
                        ?Maxdisplayed      = Maxdisplayed  ,
                        ?ReverseScale      = ReverseScale  ,
                        ?ShowScale         = ShowScale     ,
                        ?SizeMin           = SizeMin       ,
                        ?SizeMode          = SizeMode      ,
                        ?SizeRef           = SizeRef       
                    )

                trace.SetValue("marker", marker)
                trace                   

            )




    /// Sets the given domain on a Trace object.
    static member SetDomain
        (
            domain:Domain
        ) =  
            (fun (trace:('T :> Trace)) ->

                trace.SetValue("domain", domain)
                trace
            )
        
    /// Sets the given Domain styles on the domain property of a Trace object
    static member Domain
        (
            [<Optional;DefaultParameterValue(null)>] ?X     : StyleParam.Range,
            [<Optional;DefaultParameterValue(null)>] ?Y     : StyleParam.Range,
            [<Optional;DefaultParameterValue(null)>] ?Row   : int,
            [<Optional;DefaultParameterValue(null)>] ?Column: int
        ) =
                (fun (trace:('T :> Trace)) ->
                    let domain =
                        match (trace.TryGetValue "domain") with
                        | Some m -> m :?> Domain
                        | None -> Domain ()
     
                        |> Domain.style(?X=X,?Y=Y,?Row=Row,?Column=Column)

                    trace.SetValue("domain", domain)
                    trace
                )

    // Sets the X-Error an a Trace object.
    static member SetErrorX
        (
            error:Error
        ) =  
            (fun (trace:('T :> Trace)) ->

                trace.SetValue("error_x", error)
                trace
            )

    // Sets Y-Error() to TraceObjects
    static member SetErrorY
        (
            error:Error
        ) =  
            (fun (trace:('T :> Trace)) ->

                trace.SetValue("error_y", error)
                trace
            )

    // Sets Z-Error() to TraceObjects
    static member SetErrorZ
        (
            error:Error
        ) =  
            (fun (trace:('T :> Trace)) ->

                trace.SetValue("error_z", error)
                trace
            )

    // Sets Stackgroup() to TraceObjects
    static member SetStackGroup
        (
            stackgroup: string
        ) =  
            (fun (trace:('T :> Trace)) ->

                trace.SetValue("stackgroup", stackgroup)
                trace
            )