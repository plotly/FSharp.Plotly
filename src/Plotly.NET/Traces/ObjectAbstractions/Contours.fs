namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type ContourProject () =
    inherit DynamicObj () 

    static member init 
        (
            [<Optional;DefaultParameterValue(null)>] ?X: bool,
            [<Optional;DefaultParameterValue(null)>] ?Y: bool,
            [<Optional;DefaultParameterValue(null)>] ?Z: bool
        ) =
            ContourProject()
            |> ContourProject.style
                (
                    ?X   = X,
                    ?Y   = Y,
                    ?Z   = Z
                )

    static member style
        (
           [<Optional;DefaultParameterValue(null)>] ?X: bool,
           [<Optional;DefaultParameterValue(null)>] ?Y: bool,
           [<Optional;DefaultParameterValue(null)>] ?Z: bool
        ) =

            fun (contourProject: ContourProject) ->
                
                X   |> DynObj.setValueOpt contourProject "x"
                Y   |> DynObj.setValueOpt contourProject "y"
                Z   |> DynObj.setValueOpt contourProject "z"

                contourProject

/// Contour object inherits from dynamic object
type Contour () =
    inherit DynamicObj ()

    /// Initialized a Contour object
    //[<CompiledName("init")>]
    static member init 
        (
            [<Optional;DefaultParameterValue(null)>] ?Color          : Color,
            [<Optional;DefaultParameterValue(null)>] ?End            : float,
            [<Optional;DefaultParameterValue(null)>] ?Highlight      : bool,
            [<Optional;DefaultParameterValue(null)>] ?HighlightColor : Color ,
            [<Optional;DefaultParameterValue(null)>] ?HighlightWidth : float,
            [<Optional;DefaultParameterValue(null)>] ?Project        : ContourProject,
            [<Optional;DefaultParameterValue(null)>] ?Show           : bool,
            [<Optional;DefaultParameterValue(null)>] ?Size           : float,
            [<Optional;DefaultParameterValue(null)>] ?Start          : float,
            [<Optional;DefaultParameterValue(null)>] ?UseColorMap    : bool,
            [<Optional;DefaultParameterValue(null)>] ?Width          : float
        ) =
            Contour ()
            |> Contour.style
                (
                    ?Color          = Color         ,
                    ?End            = End           ,
                    ?Highlight      = Highlight     ,
                    ?HighlightColor = HighlightColor,
                    ?HighlightWidth = HighlightWidth,
                    ?Project        = Project       ,
                    ?Show           = Show          ,
                    ?Size           = Size          ,
                    ?Start          = Start         ,
                    ?UseColorMap    = UseColorMap   ,
                    ?Width          = Width         
                )


    // Applies the styles to Contours()
    //[<CompiledName("style")>]
    static member style
        (
            [<Optional;DefaultParameterValue(null)>] ?Color          : Color,
            [<Optional;DefaultParameterValue(null)>] ?End            : float,
            [<Optional;DefaultParameterValue(null)>] ?Highlight      : bool,
            [<Optional;DefaultParameterValue(null)>] ?HighlightColor : Color ,
            [<Optional;DefaultParameterValue(null)>] ?HighlightWidth : float,
            [<Optional;DefaultParameterValue(null)>] ?Project        : ContourProject,
            [<Optional;DefaultParameterValue(null)>] ?Show           : bool,
            [<Optional;DefaultParameterValue(null)>] ?Size           : float,
            [<Optional;DefaultParameterValue(null)>] ?Start          : float,
            [<Optional;DefaultParameterValue(null)>] ?UseColorMap    : bool,
            [<Optional;DefaultParameterValue(null)>] ?Width          : float
        ) =
            
            (fun (contour:Contour) -> 
                Color            |> DynObj.setValueOpt contour "color"
                End              |> DynObj.setValueOpt contour "end"
                Highlight        |> DynObj.setValueOpt contour "highlight"
                HighlightColor   |> DynObj.setValueOpt contour "highlightcolor"
                HighlightWidth   |> DynObj.setValueOpt contour "highlightwidth"
                Project          |> DynObj.setValueOpt contour "project"
                Show             |> DynObj.setValueOpt contour "show"
                Size             |> DynObj.setValueOpt contour "size"
                Start            |> DynObj.setValueOpt contour "start"
                UseColorMap      |> DynObj.setValueOpt contour "usecolormap"
                Width            |> DynObj.setValueOpt contour "width"
               

                contour
            )

/// Contours type inherits from dynamic object
type Contours () =
    inherit DynamicObj ()

    static member init
        (
            [<Optional;DefaultParameterValue(null)>] ?Coloring      : StyleParam.ContourColoring,
            [<Optional;DefaultParameterValue(null)>] ?End           : float,
            [<Optional;DefaultParameterValue(null)>] ?LabelFont     : Font,
            [<Optional;DefaultParameterValue(null)>] ?LabelFormat   : string,
            [<Optional;DefaultParameterValue(null)>] ?Operation     : StyleParam.ConstraintOperation,
            [<Optional;DefaultParameterValue(null)>] ?ShowLabels    : bool,
            [<Optional;DefaultParameterValue(null)>] ?ShowLines     : bool,
            [<Optional;DefaultParameterValue(null)>] ?Size          : float,
            [<Optional;DefaultParameterValue(null)>] ?Start         : float,
            [<Optional;DefaultParameterValue(null)>] ?Type          : StyleParam.ContourType,
            [<Optional;DefaultParameterValue(null)>] ?Value         : #IConvertible
        ) =
            Contours () 
            |> Contours.style
                (
                   ?Coloring    = Coloring   ,
                   ?End         = End        ,
                   ?LabelFont   = LabelFont  ,
                   ?LabelFormat = LabelFormat,
                   ?Operation   = Operation  ,
                   ?ShowLabels  = ShowLabels ,
                   ?ShowLines   = ShowLines  ,
                   ?Size        = Size       ,
                   ?Start       = Start      ,
                   ?Type        = Type       ,
                   ?Value       = Value      
                   
                )


    /// Initialized Contours object
    //[<CompiledName("init")>]
    static member initSurface 
        (
            [<Optional;DefaultParameterValue(null)>] ?X : Contour,
            [<Optional;DefaultParameterValue(null)>] ?Y : Contour,
            [<Optional;DefaultParameterValue(null)>] ?Z : Contour
        ) =
            Contours () 
            |> Contours.style
                (
                    ?X =  X,
                    ?Y =  Y,
                    ?Z =  Z
                )

    // Applies the styles to Contours()
    //[<CompiledName("style")>]
    static member style
        (
            [<Optional;DefaultParameterValue(null)>] ?X             : Contour,
            [<Optional;DefaultParameterValue(null)>] ?Y             : Contour,
            [<Optional;DefaultParameterValue(null)>] ?Z             : Contour,
            [<Optional;DefaultParameterValue(null)>] ?Coloring      : StyleParam.ContourColoring,
            [<Optional;DefaultParameterValue(null)>] ?End           : float,
            [<Optional;DefaultParameterValue(null)>] ?LabelFont     : Font,
            [<Optional;DefaultParameterValue(null)>] ?LabelFormat   : string,
            [<Optional;DefaultParameterValue(null)>] ?Operation     : StyleParam.ConstraintOperation,
            [<Optional;DefaultParameterValue(null)>] ?ShowLabels    : bool,
            [<Optional;DefaultParameterValue(null)>] ?ShowLines     : bool,
            [<Optional;DefaultParameterValue(null)>] ?Size          : float,
            [<Optional;DefaultParameterValue(null)>] ?Start         : float,
            [<Optional;DefaultParameterValue(null)>] ?Type          : StyleParam.ContourType,
            [<Optional;DefaultParameterValue(null)>] ?Value         : #IConvertible
        ) =
            
            (fun (contours:Contours) -> 
                X           |> DynObj.setValueOpt contours "x"
                Y           |> DynObj.setValueOpt contours "y"
                Z           |> DynObj.setValueOpt contours "z"
                Coloring    |> DynObj.setValueOptBy contours "coloring" StyleParam.ContourColoring.convert
                End         |> DynObj.setValueOpt contours "end"
                LabelFont   |> DynObj.setValueOpt contours "labelfont"                
                LabelFormat |> DynObj.setValueOpt contours "labelformat"
                Operation   |> DynObj.setValueOptBy contours "operation"  StyleParam.ConstraintOperation.convert
                ShowLabels  |> DynObj.setValueOpt contours "showlabels"
                ShowLines   |> DynObj.setValueOpt contours "showlines"
                Size        |> DynObj.setValueOpt contours "size"
                Start       |> DynObj.setValueOpt contours "start"
                Type        |> DynObj.setValueOptBy contours "type" StyleParam.ContourType.convert
                Value       |> DynObj.setValueOpt contours "value"

            
                contours
            )


    // Initialized x-y-z-Contours with the same properties    
    static member initXyz
        (
            [<Optional;DefaultParameterValue(null)>] ?Color          : Color,
            [<Optional;DefaultParameterValue(null)>] ?End            : float,
            [<Optional;DefaultParameterValue(null)>] ?Highlight      : bool,
            [<Optional;DefaultParameterValue(null)>] ?HighlightColor : Color ,
            [<Optional;DefaultParameterValue(null)>] ?HighlightWidth : float,
            [<Optional;DefaultParameterValue(null)>] ?Project        : ContourProject,
            [<Optional;DefaultParameterValue(null)>] ?Show           : bool,
            [<Optional;DefaultParameterValue(null)>] ?Size           : float,
            [<Optional;DefaultParameterValue(null)>] ?Start          : float,
            [<Optional;DefaultParameterValue(null)>] ?UseColorMap    : bool,
            [<Optional;DefaultParameterValue(null)>] ?Width          : float
                
        ) =
            Contours () 
            |> Contours.styleXyz
                (
                    ?Color          = Color         ,
                    ?End            = End           ,
                    ?Highlight      = Highlight     ,
                    ?HighlightColor = HighlightColor,
                    ?HighlightWidth = HighlightWidth,
                    ?Project        = Project       ,
                    ?Show           = Show          ,
                    ?Size           = Size          ,
                    ?Start          = Start         ,
                    ?UseColorMap    = UseColorMap   ,
                    ?Width          = Width         
                )

    // Applies the styles to Contours()
    //[<CompiledName("styleXyz")>]
    static member styleXyz
        (
            [<Optional;DefaultParameterValue(null)>] ?Color          : Color,
            [<Optional;DefaultParameterValue(null)>] ?End            : float,
            [<Optional;DefaultParameterValue(null)>] ?Highlight      : bool,
            [<Optional;DefaultParameterValue(null)>] ?HighlightColor : Color ,
            [<Optional;DefaultParameterValue(null)>] ?HighlightWidth : float,
            [<Optional;DefaultParameterValue(null)>] ?Project        : ContourProject,
            [<Optional;DefaultParameterValue(null)>] ?Show           : bool,
            [<Optional;DefaultParameterValue(null)>] ?Size           : float,
            [<Optional;DefaultParameterValue(null)>] ?Start          : float,
            [<Optional;DefaultParameterValue(null)>] ?UseColorMap    : bool,
            [<Optional;DefaultParameterValue(null)>] ?Width          : float
                
        ) =
            
            (fun (contours: Contours) -> 
                let xyzContour =
                    Contour.init (
                        ?Show=Show,
                        ?Color=Color,
                        ?UseColorMap=UseColorMap, 
                        ?Width=Width, 
                        ?Highlight=Highlight, 
                        ?HighlightColor=HighlightColor, 
                        ?HighlightWidth=HighlightWidth, 
                        ?Project = Project
                    ) 
                contours 
                |> Contours.style(X=xyzContour,Y=xyzContour,Z=xyzContour)
            )



