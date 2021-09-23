namespace Plotly.NET


// https://plot.ly/javascript/reference/
// https://plot.ly/javascript-graphing-library/reference/

//[<RequireQualifiedAccess>]
module StyleParam =
    open System.Text.RegularExpressions


//--------------------------
// #A#
//--------------------------
    
    [<RequireQualifiedAccess>]
    type ArrowSide =
        | Start | End | StartEnd | None 

        static member toString = function
            | Start     -> "start"
            | End       -> "end"
            | StartEnd  -> "startend"
            | None      -> "none"
        static member convert = ArrowSide.toString >> box
        override this.ToString() = this |> ArrowSide.toString
        member this.Convert() = this |> ArrowSide.convert
    
    [<RequireQualifiedAccess>]
    type AnnotationAlignment =
        | Left | Center | Right 

        static member toString = function
            | Left  -> "left" 
            | Center-> "center" 
            | Right -> "right" 
        static member convert = AnnotationAlignment.toString >> box
        override this.ToString() = this |> AnnotationAlignment.toString
        member this.Convert() = this |> AnnotationAlignment.convert
    
    [<RequireQualifiedAccess>]
    type AspectMode =
        | Auto | Cube | Data | Manual

        static member toString = function
            | Auto  -> "auto" 
            | Cube  -> "cube" 
            | Data  -> "data" 
            | Manual-> "manual"
        static member convert = AspectMode.toString >> box
        override this.ToString() = this |> AspectMode.toString
        member this.Convert() = this |> AspectMode.convert
    
    /// Sets the horizontal alignment of the text content within hover label box. Has an effect only if the hover label text spans more two or more lines
    [<RequireQualifiedAccess>]
    type Align =
        | Auto | Left | Right

        static member toString = function
            | Auto     -> "auto"            
            | Left     -> "left"            
            | Right    -> "right"

        static member convert = Align.toString >> box
        override this.ToString() = this |> Align.toString
        member this.Convert() = this |> Align.convert

    /// Determines whether or not the range of this axis is computed in relation to the input data. See `rangemode` for more info. If `range` is provided, then `autorange` is set to "false".
    [<RequireQualifiedAccess>]
    type AutoRange =
        | True | False | Reversed
    
        static member toString = function
            | True     -> "true"            
            | False    -> "false"            
            | Reversed -> "reversed"

        static member convert = AutoRange.toString >> box
        override this.ToString() = this |> AutoRange.toString
        member this.Convert() = this |> AutoRange.convert

    /// Sets the axis type. By default (Auto), plotly attempts to determined the axis type by looking into the data of the traces that referenced the axis in question.
    [<RequireQualifiedAccess>]
    type AxisType =
        | Auto | Linear | Log | Date | Category | MultiCategory
    
        static member toString = function
            | Auto          -> "-"            
            | Linear        -> "linear"            
            | Log           -> "log"
            | Date          -> "date"
            | Category      -> "category"
            | MultiCategory -> "multicategory"

        static member convert = AxisType.toString >> box
        override this.ToString() = this |> AxisType.toString
        member this.Convert() = this |> AxisType.convert

    [<RequireQualifiedAccess>]
    type ArrowHead =
    |TriangleShort |TriangleTall |Barbed |SimpleShort |SimpleTall |Cirle |Square |LineOnly
        static member toEnum = function
            |TriangleShort -> 1
            |TriangleTall  -> 2
            |Barbed        -> 3
            |SimpleShort   -> 4
            |SimpleTall    -> 5
            |Cirle         -> 6
            |Square        -> 7
            |LineOnly      -> 8

        static member convert = ArrowHead.toEnum >> box
        override this.ToString() = this |> ArrowHead.toEnum |> string
        member this.Convert() = this |> ArrowHead.convert

    [<RequireQualifiedAccess>]
    type LinearAxisId = 
        | X of int | Y of int
    
        static member toString = function
            | X id  -> if id < 2 then "x" else sprintf "x%i" id
            | Y id  -> if id < 2 then "y" else sprintf "y%i" id

        static member convert = LinearAxisId.toString >> box
        override this.ToString() = this |> LinearAxisId.toString
        member this.Convert() = this |> LinearAxisId.convert

    // to-do merge with axis anchor id
    [<RequireQualifiedAccess>]
    type SubPlotId = 
        | XAxis     of int 
        | YAxis     of int 
        | ColorAxis of int
        | Geo       of int
        | Mapbox    of int
        | Polar     of int
        | Ternary   of int
        | Scene     of int
    
        static member toString = function
            | XAxis     id  -> if id < 2 then "xaxis" else sprintf "xaxis%i" id
            | YAxis     id  -> if id < 2 then "yaxis" else sprintf "yaxis%i" id
            | ColorAxis id  -> if id < 2 then "coloraxis" else sprintf "coloraxis%i" id
            | Geo       id  -> if id < 2 then "geo" else sprintf "geo%i" id
            | Mapbox    id  -> if id < 2 then "mapbox" else sprintf "mapbox%i" id
            | Polar     id  -> if id < 2 then "polar" else sprintf "polar%i" id
            | Ternary   id  -> if id < 2 then "ternary" else sprintf "ternary%i" id
            | Scene     id  -> if id < 2 then "scene" else sprintf "scene%i" id

        static member convert = SubPlotId.toString >> box 
        override this.ToString() = this |> SubPlotId.toString
        member this.Convert() = this |> SubPlotId.convert

    [<RequireQualifiedAccess>]
    /// Editable parts of a chart that can be set via Chart config.
    type AnnotationEditOptions =
    ///Determines if the main anchor of the annotation is editable.The main anchor corresponds to the',
    ///text (if no arrow) or the arrow (which drags the whole thing leaving the arrow length & direction unchanged).
    |AnnotationPosition
    ///Has only an effect for annotations with arrows. Enables changing the length and direction of the arrow.
    |AnnotationTail
    ///Enables editing annotation text.
    |AnnotationText
    ///Enables editing axis title text.
    |AxisTitleText
    ///Enables moving colorbars.
    |ColorbarPosition
    ///Enables editing colorbar title text.
    |ColorbarTitleText
    ///Enables moving the legend.
    |LegendPosition
    ///Enables editing the trace name fields from the legend
    |LegendText
    ///Enables moving shapes.
    |ShapePosition
        
        static member toString aeo =
            match aeo with
            |AnnotationPosition ->  "annotationPosition" 
            |AnnotationTail     ->  "annotationTail"     
            |AnnotationText     ->  "annotationText"     
            |AxisTitleText      ->  "axisTitleText"      
            |ColorbarPosition   ->  "colorbarPosition"   
            |ColorbarTitleText  ->  "colorbarTitleText"  
            |LegendPosition     ->  "legendPosition"     
            |LegendText         ->  "legendText"         
            |ShapePosition      ->  "shapePosition"      

        static member convert = AnnotationEditOptions.toString >> box 
        override this.ToString() = this |> AnnotationEditOptions.toString
        member this.Convert() = this |> AnnotationEditOptions.convert

    [<RequireQualifiedAccess>]
    type AutoTypeNumbers =
    | ConvertTypes | Strict
        
        static member toString = function
            | ConvertTypes  -> "convert types" 
            | Strict        -> "strict"

        static member convert = AutoTypeNumbers.toString >> box 
        override this.ToString() = this |> AutoTypeNumbers.toString
        member this.Convert() = this |> AutoTypeNumbers.convert

    [<RequireQualifiedAccess>]
    type AngularUnit =
        | Radians
        | Degrees
        | Gradians

        static member toString = function
            | Radians   -> "radians"
            | Degrees   -> "degrees"
            | Gradians  -> "gradians"

        static member convert = AngularUnit.toString >> box
        override this.ToString() = this |> AngularUnit.toString
        member this.Convert() = this |> AngularUnit.convert

//--------------------------
// #B#
//--------------------------

    [<RequireQualifiedAccess>]
    type Boxpoints =
        | Outliers
        | All
        | Suspectedoutliers
        | False    

        static member toString = function
            | Outliers          -> "outliers"
            | All               -> "all"
            | Suspectedoutliers -> "suspectedoutliers"
            | False             -> "false"

        static member convert = Boxpoints.toString >> box
        override this.ToString() = this |> Boxpoints.toString
        member this.Convert() = this |> Boxpoints.convert



    [<RequireQualifiedAccess>]
    type BoxMean =
        | True
        | False
        | SD 
         
        static member toString = function
            | True  -> "true"
            | False -> "false"
            | SD    -> "SD"

        static member convert = BoxMean.toString >> box
        override this.ToString() = this |> BoxMean.toString
        member this.Convert() = this |> BoxMean.convert

    /// For bar and histogram plots only. This sets how multiple bar objects are plotted together. In other words, this defines how bars at the same location
    /// appear on the plot. If set to 'stack' the bars are stacked on top of one another. If set to 'group', the bars are plotted next to one another, centered 
    /// around the shared location. If set to 'overlay', the bars are simply plotted over one another, you may need to set the opacity to see this.
    [<RequireQualifiedAccess>]
    type BarMode =
        | Stack | Group | Overlay | Relative 
    
        static member toString = function
            | Stack   -> "stack"
            | Group   -> "group"
            | Overlay -> "overlay"
            | Relative-> "relative"

        static member convert = BarMode.toString >> box    
        override this.ToString() = this |> BarMode.toString
        member this.Convert() = this |> BarMode.convert

    [<RequireQualifiedAccess>]
    type BoxMode =
        | Group | Overlay 
    
        static member toString = function
            | Group   -> "group"
            | Overlay -> "overlay"

        static member convert = BoxMode.toString >> box    
        override this.ToString() = this |> BoxMode.toString
        member this.Convert() = this |> BoxMode.convert
        
    [<RequireQualifiedAccess>]
    type BarNorm =
        | NoNorm | Fraction | Percent 
    
        static member toString = function
            | NoNorm    -> ""
            | Fraction  -> "fraction"
            | Percent   -> "percent"

        static member convert = BarNorm.toString >> box
        override this.ToString() = this |> BarNorm.toString
        member this.Convert() = this |> BarNorm.convert

    [<RequireQualifiedAccess>]
    type BranchValues =
        | Remainder 
        | Total
    
        static member toString = function
            | Remainder -> "remainder"            
            | Total     -> "total"            

        static member convert = BranchValues.toString >> box
        override this.ToString() = this |> BranchValues.toString
        member this.Convert() = this |> BranchValues.convert

//--------------------------
// #C#
//--------------------------
    
        
    [<RequireQualifiedAccess>]
    type ColorModel =
        | RGB      
        | RGBA     
        | RGBA256  
        | HSL      
        | HSLA     
        
        static member toString = function
            | RGB       -> "rgb" 
            | RGBA      -> "rgba" 
            | RGBA256   -> "rgba256" 
            | HSL       -> "hsl" 
            | HSLA      -> "hsla"

        static member convert = ColorModel.toString >> box
        override this.ToString() = this |> ColorModel.toString
        member this.Convert() = this |> ColorModel.convert

    [<RequireQualifiedAccess>]
    type ColorComponentBound =
        | RGB      of R:int * G:int * B:int
        | RGBA     of R:int * G:int * B:int * A:int
        | RGBA256  of int*int*int*int
        | HSL      of H:int * S:int * L:int
        | HSLA     of H:int * S:int * L:int * A:int

        static member convert = function
            | RGB       (r,g,b)     -> [r;g;b]   |> box
            | RGBA      (r,g,b,a)   -> [r;g;b;a] |> box
            | RGBA256   (i,d,k,m)   -> [i;d;k;m] |> box
            | HSL       (h,s,l)     -> [h;s;l]   |> box
            | HSLA      (h,s,l,a)   -> [h;s;l;a] |> box

        member this.Convert() = this |> ColorComponentBound.convert


    [<RequireQualifiedAccess>]
    type ClickToShow =
        | False | OnOff | OnOut
    
        static member toString = function
            | False -> "false"
            | OnOff -> "onoff"
            | OnOut -> "onout"

        static member convert = ClickToShow.toString >> box
        override this.ToString() = this |> ClickToShow.toString
        member this.Convert() = this |> ClickToShow.convert

    [<RequireQualifiedAccess>]
    type ConstrainText =
        | Inside      
        | Outside     
        | Both
        | None
    
        static member toString = function
            | Inside    -> "inside"
            | Outside   -> "outside"
            | Both      -> "both"
            | None      -> "none"

        static member convert = ConstrainText.toString >> box
        override this.ToString() = this |> ConstrainText.toString
        member this.Convert() = this |> ConstrainText.convert

    [<RequireQualifiedAccess>]
    type ClickMode =
        | Event      
        | Select     
        | EventSelect
        | NoClickMode
    
        static member toString = function
            | Event         -> "event"
            | Select        -> "select"
            | EventSelect   -> "event+select"
            | NoClickMode   -> "none"

        static member convert = ClickMode.toString >> box
        override this.ToString() = this |> ClickMode.toString
        member this.Convert() = this |> ClickMode.convert

    /// Sets the calendar system to use with `x y z` date data. Default: "gregorian"
    [<RequireQualifiedAccess>]
    type Calendar = 
        | Gregorian | Chinese | Coptic | Discworld | Ethiopian | Hebrew | Islamic | Julian    
        | Mayan | Nanakshahi | Nepali | Persian | Jalali | Taiwan | Thai | Ummalqura 
    
        static member toString = function
            | Gregorian  -> "gregorian" 
            | Chinese    -> "chinese" 
            | Coptic     -> "coptic" 
            | Discworld  -> "discworld" 
            | Ethiopian  -> "ethiopian" 
            | Hebrew     -> "hebrew" 
            | Islamic    -> "islamic" 
            | Julian     -> "julian" 
            | Mayan      -> "mayan" 
            | Nanakshahi -> "nanakshahi"
            | Nepali     -> "nepali" 
            | Persian    -> "persian" 
            | Jalali     -> "jalali" 
            | Taiwan     -> "taiwan" 
            | Thai       -> "thai" 
            | Ummalqura  -> "ummalqura"

        static member convert = Calendar.toString >> box
        override this.ToString() = this |> Calendar.toString
        member this.Convert() = this |> Calendar.convert

    /// Only applies if cumulative is enabled. If "increasing" (default) we sum all prior bins, so the result increases from left to right.
    /// If "decreasing" we sum later bins so the result decreases from left to right.  default: "increasing"
    [<RequireQualifiedAccess>]
    type CumulativeDirection =
        | Increasing | Decreasing 
    
        static member toString = function
            | Increasing  -> "increasing"
            | Decreasing  -> "decreasing"

        static member convert = CumulativeDirection.toString >> box
        override this.ToString() = this |> CumulativeDirection.toString
        member this.Convert() = this |> CumulativeDirection.convert

    /// Only applies if cumulative is enabled. Sets whether the current bin is included, excluded, or has half of its value included in 
    /// the current cumulative value. "include" is the default for compatibility with various other tools, however it introduces
    /// a half-bin bias to the results. "exclude" makes the opposite half-bin bias, and "half" removes it.
    [<RequireQualifiedAccess>]
    type Currentbin =
        | Include | Exclude | Half 
    
        static member toString = function
            | Include -> "Include"
            | Exclude -> "Exclude"
            | Half    -> "Half"

        static member convert = Currentbin.toString >> box
                override this.ToString() = this |> Currentbin.toString
        member this.Convert() = this |> Currentbin.convert

    /// The colorscale must be a collection containing a mapping of a normalized value (between 0.0 and 1.0) to it's color. At minimum, a mapping for the lowest (0.0) and highest (1.0) values are required. 
    [<RequireQualifiedAccess>]
    type Colorscale =
        | Custom of seq<float*string> 
        | RdBu | Earth | Blackbody | YIOrRd | YIGnBu | Bluered
        | Portland | Electric | Jet | Hot | Greys | Greens | Picnic 
        | Rainbow | Viridis | Cividis
        static member convert = function
            | Custom (cScale) -> cScale
                                 |> Seq.map (fun (v,color) -> [|box v;box color|])
                                 |> Array.ofSeq |> box
            | RdBu            -> box "RdBu"     
            | Earth           -> box "Earth"    
            | Blackbody       -> box "Blackbody"
            | YIOrRd          -> box "YIOrRd"   
            | YIGnBu          -> box "YIGnBu"   
            | Bluered         -> box "Bluered"  
            | Portland        -> box "Portland"
            | Electric        -> box "Electric" 
            | Jet             -> box "Jet"      
            | Hot             -> box "Hot"      
            | Greys           -> box "Greys"    
            | Greens          -> box "Greens"   
            | Picnic          -> box "Picnic"  
            | Rainbow         -> box "Rainbow"
            | Viridis         -> box "Viridis"
            | Cividis         -> box "Cividis"

        member this.Convert() = this |> Colorscale.convert

    /// Specifies the ordering logic for the case of categorical variables. By default, plotly uses "trace", which specifies the order that is present in the data supplied. 
    /// Set `categoryorder` to "category ascending" or "category descending" if order should be determined by the alphanumerical order of the category names. 
    /// Set `categoryorder` to "array" to derive the ordering from the attribute `categoryarray`. If a category is not found in the `categoryarray` array, the sorting behavior for that attribute will be identical to the "trace" mode. 
    /// The unspecified categories will follow the categories in `categoryarray`. Set `categoryorder` to "total ascending" or "total descending" if order should be determined by the numerical order of the values. 
    /// Similarly, the order can be determined by the min, max, sum, mean or median of all the values.
    [<RequireQualifiedAccess>]
    type CategoryOrder =
        | Trace
        | CategoryAscending
        | CategoryDescending
        | Array
        | TotalAscending
        | TotalDescending
        | MinAscending
        | MinDescending
        | MaxAscending
        | MaxDescending
        | SumAscending
        | SumDescending
        | MeanAscending
        | MeanDescending
        | MedianAscending
        | MedianDescending
    
        static member toString = function
            | Trace -> "trace" 
            | CategoryAscending -> "category ascending" 
            | CategoryDescending -> "category descending" 
            | Array -> "array" 
            | TotalAscending -> "total ascending" 
            | TotalDescending -> "total descending" 
            | MinAscending -> "min ascending" 
            | MinDescending -> "min descending" 
            | MaxAscending -> "max ascending" 
            | MaxDescending -> "max descending" 
            | SumAscending -> "sum ascending" 
            | SumDescending -> "sum descending" 
            | MeanAscending -> "mean ascending" 
            | MeanDescending -> "mean descending" 
            | MedianAscending -> "median ascending" 
            | MedianDescending -> "median descending"

        static member convert = CategoryOrder.toString >> box
        override this.ToString() = this |> CategoryOrder.toString
        member this.Convert() = this |> CategoryOrder.convert

    ///The shape of connector lines in Waterfall charts.
    [<RequireQualifiedAccess>]
    type ConnectorMode =
        | Spanning | Between

        static member toString = function
            | Spanning  -> "spanning"
            | Between   -> "between"

        static member convert = ConnectorMode.toString >> box
        override this.ToString() = this |> ConnectorMode.toString
        member this.Convert() = this |> ConnectorMode.convert

    /// If the axis needs to be compressed (either due to its own `scaleanchor` and `scaleratio` or those of the other axis), determines how that happens: by increasing the "range", or by decreasing the "domain". Default is "domain" for axes containing image traces, "range" otherwise.
    [<RequireQualifiedAccess>]
    type AxisConstraint =
        | Range | Domain  
    
        static member toString = function
            | Range     -> "range"
            | Domain    -> "domain"

        static member convert = AxisConstraint.toString >> box
        override this.ToString() = this |> AxisConstraint.toString
        member this.Convert() = this |> AxisConstraint.convert

    [<RequireQualifiedAccess>]
    type AxisConstraintDirection =
        | Left | Center | Right | Top | Middle | Bottom
    
        static member toString = function
            | Left      -> "left" 
            | Center    -> "center" 
            | Right     -> "right" 
            | Top       -> "top" 
            | Middle    -> "middle" 
            | Bottom    -> "bottom"

        static member convert = AxisConstraintDirection.toString >> box
        override this.ToString() = this |> AxisConstraintDirection.toString
        member this.Convert() = this |> AxisConstraintDirection.convert

    [<RequireQualifiedAccess>]
    type CategoryTickAnchor =
        | Labels | Boundaries  
    
        static member toString = function
            | Labels    -> "labels"
            | Boundaries-> "boundaries"

        static member convert = CategoryTickAnchor.toString >> box
        override this.ToString() = this |> CategoryTickAnchor.toString
        member this.Convert() = this |> CategoryTickAnchor.convert
        
    /// Sets the cones' anchor with respect to their x/y/z positions. Note that "cm" denote the cone's center of mass which corresponds to 1/4 from the tail to tip.
    [<RequireQualifiedAccess>]
    type ConeAnchor =
        | Tip         
        | Tail        
        | CenterOfMass
        | Center      
    
        static member toString = function
            | Tip           -> "tip" 
            | Tail          -> "tail" 
            | CenterOfMass  -> "cm" 
            | Center        -> "center"

        static member convert = ConeAnchor.toString >> box
        override this.ToString() = this |> ConeAnchor.toString
        member this.Convert() = this |> ConeAnchor.convert

           
    /// Sets the cones' anchor with respect to their x/y/z positions. Note that "cm" denote the cone's center of mass which corresponds to 1/4 from the tail to tip.
    [<RequireQualifiedAccess>]
    type ConeSizeMode =
        | Scaled  
        | Absolute
 
        static member toString = function
            | Scaled   -> "scaled"
            | Absolute -> "absolute"

        static member convert = ConeSizeMode.toString >> box
        override this.ToString() = this |> ConeSizeMode.toString
        member this.Convert() = this |> ConeSizeMode.convert
    
        
//--------------------------
// #D#
//--------------------------

    /// Sets this figure's behavior when a user preforms a mouse 'drag' in the plot area. When set to 'zoom', a portion of the plot will be highlighted,
    /// when the viewer exits the drag, this highlighted section will be zoomed in on. When set to 'pan', data in the plot will move along with the viewers
    /// dragging motions. A user can always depress the 'shift' key to access the whatever functionality has not been set as the default. In 3D plots, the 
    /// default drag mode is 'rotate' which rotates the scene.
    [<RequireQualifiedAccess>]
    type DragMode =
        | Zoom          
        | Pan           
        | Select        
        | Lasso         
        | DrawClosedPath
        | DrawOpenPath  
        | DrawLine      
        | DrawRect      
        | DrawCircle    
        | Orbit         
        | TurnTable     
        | False         

        static member toString = function
            | Zoom              -> "zoom" 
            | Pan               -> "pan" 
            | Select            -> "select" 
            | Lasso             -> "lasso" 
            | DrawClosedPath    -> "drawclosedpath" 
            | DrawOpenPath      -> "drawopenpath" 
            | DrawLine          -> "drawline" 
            | DrawRect          -> "drawrect" 
            | DrawCircle        -> "drawcircle" 
            | Orbit             -> "orbit" 
            | TurnTable         -> "turntable" 
            | False             -> "False"

        static member convert = DragMode.toString >> box
        override this.ToString() = this |> DragMode.toString
        member this.Convert() = this |> DragMode.convert

    /// Sets the Delaunay axis, which is the axis that is perpendicular to the surface of the Delaunay triangulation.
    /// It has an effect if `i`, `j`, `k` are not provided and `alphahull` is set to indicate Delaunay triangulation. 
    /// Default is "z"
    [<RequireQualifiedAccess>]
    type Delaunayaxis = 
    | X | Y | Z

        static member toString = function
            | X   -> "x"
            | Y   -> "y"
            | Z   -> "z"

        static member convert = Delaunayaxis.toString >> box
        override this.ToString() = this |> Delaunayaxis.toString
        member this.Convert() = this |> Delaunayaxis.convert

    /// Specifies the direction at which succeeding sectors follow one another.
    [<RequireQualifiedAccess>]
    type Direction =
        | Clockwise | CounterClockwise 
    
        static member toString = function
            | Clockwise        -> "clockwise"
            | CounterClockwise -> "counterclockwise"

        static member convert = Direction.toString >> box
        override this.ToString() = this |> Direction.toString
        member this.Convert() = this |> Direction.convert

    /// Dash: Sets the drawing style of the lines segments in this trace.
    /// Sets the style of the lines. Set to a dash string type or a dash length in px.
    [<RequireQualifiedAccess>]
    type DrawingStyle = 
        | Solid 
        | Dash   
        | Dot 
        | DashDot
        | User of int
        static member toString = function
            | Solid   -> "solid"             
            | Dash    -> "dash"            
            | Dot     -> "dot"    
            | DashDot -> "dashdot"       
            | User px -> px.ToString()           

        static member convert = DrawingStyle.toString >> box
        override this.ToString() = this |> DrawingStyle.toString
        member this.Convert() = this |> DrawingStyle.convert

//--------------------------
// #E#
//--------------------------

    [<RequireQualifiedAccess>]
    type ErrorType =
        | Percent | Constant| Sqrt | Data    
    
        static member toString = function
            | Percent   -> "percent" 
            | Constant  -> "constant" 
            | Sqrt      -> "sqrt" 
            | Data      -> "data" 

    
        static member convert = ErrorType.toString >> box
        override this.ToString() = this |> ErrorType.toString
        member this.Convert() = this |> ErrorType.convert


    /// Determines a formatting rule for the tick exponents. For example, consider the number 1,000,000,000. If "none", it appears as 1,000,000,000. If "e", 1e+9. If "E", 1E+9. 
    /// If "power", 1x10^9 (with 9 in a super script). If "SI", 1G. If "B", 1B.
    [<RequireQualifiedAccess>]
    type ExponentFormat =
        | B | SI | Power | Ecapital | E | None
    
        static member toString = function
            | B        -> "B"
            | SI       -> "SI"
            | Power    -> "power"
            | Ecapital -> "E"
            | E        -> "e"
            | None     -> "none"
        
    
        static member convert = ExponentFormat.toString >> box
        override this.ToString() = this |> ExponentFormat.toString
        member this.Convert() = this |> ExponentFormat.convert

//--------------------------
// #F#
//--------------------------

    [<RequireQualifiedAccess>]
    type FunnelMode =
        | Stack | Group | Overlay 
    
        static member toString = function
            | Stack     -> "stack"
            | Group     -> "group"
            | Overlay   -> "overlay"

        static member convert = FunnelMode.toString >> box    
        override this.ToString() = this |> FunnelMode.toString
        member this.Convert() = this |> FunnelMode.convert

    /// Names of installed font families
    [<RequireQualifiedAccess>]
    type FontFamily =
        | Arial
        | Balto
        | Courier_New
        | Consolas
        | Droid_Sans
        | Droid_Serif
        | Droid_Sans_Mono
        | Gravitas_One
        | Old_Standard_TT
        | Open_Sans
        | Overpass
        | PT_Sans_Narrow
        | Raleway
        | Times_New_Roman
        | Custom of string

        static member toString = function
            | Arial           -> "Arial"
            | Balto           -> "Balto"
            | Courier_New     -> "Courier New"
            | Consolas        -> "Consolas"
            | Droid_Sans      -> "Droid Sans"     
            | Droid_Serif     -> "Droid Serif"    
            | Droid_Sans_Mono -> "Droid Sans Mono"
            | Gravitas_One    -> "Gravitas One"   
            | Old_Standard_TT -> "Old Standard TT"
            | Open_Sans       -> "Open Sans"      
            | Overpass        -> "Overpass"       
            | PT_Sans_Narrow  -> "PT Sans Narrow" 
            | Raleway         -> "Raleway"        
            | Times_New_Roman -> "Times New Roman"
            | Custom name     -> name

        static member convert = FontFamily.toString >> box
        override this.ToString() = this |> FontFamily.toString
        member this.Convert() = this |> FontFamily.convert

    /// Sets the area to fill with a solid color. (default: "none" )
    [<RequireQualifiedAccess>]
    type Fill =
        | None | ToZero_y | ToZero_x | ToNext_y | ToNext_x | ToSelf | ToNext
    
        static member toString = function
            | None      -> "none"
            | ToZero_y  -> "tozeroy"
            | ToZero_x  -> "tozerox"
            | ToNext_y  -> "tonexty"
            | ToNext_x  -> "tonextx"
            | ToSelf    -> "toself"
            | ToNext    -> "tonext"
    
        static member convert = Fill.toString >> box
        override this.ToString() = this |> Fill.toString
        member this.Convert() = this |> Fill.convert

//--------------------------
// #G#
//--------------------------

    [<RequireQualifiedAccess>]
    type GradientType =
           | Radial | Horizontal | Vertical | None
       
           static member toString = function
               | Radial     -> "radial"
               | Horizontal -> "horizontal"
               | Vertical   -> "vertical"
               | None       -> "none"

           static member convert = GradientType.toString >> box
           override this.ToString() = this |> GradientType.toString
           member this.Convert() = this |> GradientType.convert
           

    [<RequireQualifiedAccess>]
    type GroupNorm =
           | None | Fraction | Percent
       
           static member toString = function
               | None               -> ""
               | Fraction           -> "fraction"
               | Percent            -> "percent"

           static member convert = GroupNorm.toString >> box
           override this.ToString() = this |> GroupNorm.toString
           member this.Convert() = this |> GroupNorm.convert

    ///Used for the Layout.geo field. Determines if this subplot's view settings are auto-computed to fit trace data. On scoped maps, setting `fitbounds` leads to `center.lon` and `center.lat` getting auto-filled. On maps with a non-clipped projection, setting `fitbounds` leads to `center.lon`, `center.lat`, and `projection.rotation.lon` getting auto-filled. On maps with a clipped projection, setting `fitbounds` leads to `center.lon`, `center.lat`, `projection.rotation.lon`, `projection.rotation.lat`, `lonaxis.range` and `lonaxis.range` getting auto-filled. If "locations", only the trace's visible locations are considered in the `fitbounds` computations. If "geojson", the entire trace input `geojson` (if provided) is considered in the `fitbounds` computations, Defaults to "false".
    [<RequireQualifiedAccess>]
    type GeoFitBounds =
           | False | Locations | GeoJson
       
           static member toString = function
               | False          -> "false"
               | Locations      -> "locations"
               | GeoJson        -> "geojson"

           static member convert = GeoFitBounds.toString >> box
           override this.ToString() = this |> GeoFitBounds.toString
           member this.Convert() = this |> GeoFitBounds.convert

    ///Used for the Layout.geo field. Sets the resolution of the base layers. The values have units of km/mm e.g. 110 corresponds to a scale ratio of 1:110,000,000.
    [<RequireQualifiedAccess>]
    type GeoResolution =
           | R110 | R50 

           static member toString = function
               | R110   -> "110"
               | R50    -> "50"

           static member convert = GeoResolution.toString >> box
           override this.ToString() = this |> GeoResolution.toString
           member this.Convert() = this |> GeoResolution.convert

    [<RequireQualifiedAccess>]
    type GeoScope =
            | World | Usa | Europe | Asia | Africa | NorthAmerica | SouthAmerica

            static member toString = function
                | World           -> "world"
                | Usa             -> "usa"
                | Europe          -> "europe"
                | Asia            -> "asia"
                | Africa          -> "africa"
                | NorthAmerica    -> "north america"
                | SouthAmerica    -> "south america"

            static member convert = GeoScope.toString >> box
            override this.ToString() = this |> GeoScope.toString
            member this.Convert() = this |> GeoScope.convert

    [<RequireQualifiedAccess>]
    type GeoProjectionType =
            | EquiRectangular         
            | Mercator            
            | Orthographic        
            | NaturalEarth           
            | Kavrayskiy7         
            | Miller 
            | Robinson                
            | Eckert4             
            | AzimuthalEqualArea
            | AzimuthalEquidistant   
            | ConicEqualArea    
            | ConicConformal         
            | ConicEquidistant       
            | Gnomonic            
            | Stereographic
            | Mollweide               
            | Hammer              
            | TransverseMercator     
            | AlbersUSA              
            | WinkelTripel       
            | Aitoff      
            | Sinusoidal

            static member toString = function
                | EquiRectangular       -> "equirectangular" 
                | Mercator              -> "mercator" 
                | Orthographic          -> "orthographic" 
                | NaturalEarth          -> "natural earth" 
                | Kavrayskiy7           -> "kavrayskiy7" 
                | Miller                -> "miller" 
                | Robinson              -> "robinson" 
                | Eckert4               -> "eckert4"
                | AzimuthalEqualArea    -> "azimuthal equal area" 
                | AzimuthalEquidistant  -> "azimuthal equidistant" 
                | ConicEqualArea        -> "conic equal area" 
                | ConicConformal        -> "conic conformal" 
                | ConicEquidistant      -> "conic equidistant" 
                | Gnomonic              -> "gnomonic" 
                | Stereographic         -> "stereographic" 
                | Mollweide             -> "mollweide" 
                | Hammer                -> "hammer" 
                | TransverseMercator    -> "transverse mercator" 
                | AlbersUSA             -> "albers usa" 
                | WinkelTripel          -> "winkel tripel" 
                | Aitoff                -> "aitoff" 
                | Sinusoidal            -> "sinusoidal"

            static member convert = GeoProjectionType.toString >> box
            override this.ToString() = this |> GeoProjectionType.toString
            member this.Convert() = this |> GeoProjectionType.convert

//--------------------------
// #H#
//--------------------------

    type HoverInfo =
        | X             
        | XY            
        | XYZ           
        | XYZText       
        | Y             
        | YZ            
        | YZText        
        | YZTextNames   
        | Z             
        | ZText         
        | ZTextName     
        | Text          
        | TextName      
        | Name          
        | All           
    
        static member toString = function
            | X             -> "x" 
            | XY            -> "x+y" 
            | XYZ           -> "x+y+z" 
            | XYZText       -> "x+y+z+text" 
            | Y             -> "y" 
            | YZ            -> "y+z" 
            | YZText        -> "y+z+text" 
            | YZTextNames   -> "y+z+text+name"
            | Z             -> "z" 
            | ZText         -> "z+text" 
            | ZTextName     -> "z+text+name"
            | Text          -> "text" 
            | TextName      -> "text+name"
            | Name          -> "name" 
            | All           -> "all"

        static member convert = HoverInfo.toString >> box
        override this.ToString() = this |> HoverInfo.toString
        member this.Convert() = this |> HoverInfo.convert

    [<RequireQualifiedAccess>]
    type HoverOn =
        | Points | Fills | PointsFills
        static member toString = function
            | Points        -> "points"
            | Fills         -> "fills"
            | PointsFills   -> "points+fills"

        static member convert = HoverOn.toString >> box
        override this.ToString() = this |> HoverOn.toString
        member this.Convert() = this |> HoverOn.convert

    /// Sets the type of normalization for this histogram trace. By default ('histnorm' set to '') the height of each bar 
    /// displays the frequency of occurrence, i.e., the number of times this value was found in the corresponding bin.
    /// If set to 'percent', the height of each bar displays the percentage of total occurrences found within the corresponding bin. 
    /// If set to 'probability', the height of each bar displays the probability that an event will fall into the corresponding bin. 
    /// If set to 'density', the height of each bar is equal to the number of occurrences in a bin divided by the size of the bin 
    /// interval such that summing the area of all bins will yield the total number of occurrences. If set to 'probability density', 
    /// the height of each bar is equal to the number of probability that an event will fall into the corresponding bin divided by 
    /// the size of the bin interval such that summing the area of all bins will yield 1.
    /// default: None  
    [<RequireQualifiedAccess>]
    type HistNorm =
        | None | Percent | Probability | Density | ProbabilityDensity 
    
        static member toString = function
            | None               -> ""
            | Percent            -> "percent"
            | Probability        -> "probability"
            | Density            -> "density"
            | ProbabilityDensity -> "probability density"

        static member convert = HistNorm.toString >> box
        override this.ToString() = this |> HistNorm.toString
        member this.Convert() = this |> HistNorm.convert


    /// Sets the binning function used for this histogram trace. The default value is 'count' where the histogram values are computed 
    /// by counting the number of values lying inside each bin. With 'histfunc' set to 'sum', 'avg', 'min' or 'max', the histogram values 
    /// are computed using the sum, the average, the minimum or the 'maximum' of the values lying inside each bin respectively.
    /// default: Count    
    [<RequireQualifiedAccess>]
    type HistFunc =
        | Count | Sum | Avg | Min | Max 
    
        static member toString = function
            | Count -> "count"
            | Sum   -> "sum"
            | Avg   -> "avg"
            | Min   -> "min"
            | Max   -> "max"

        static member convert = HistFunc.toString >> box
        override this.ToString() = this |> HistFunc.toString
        member this.Convert() = this |> HistFunc.convert


    /// Sets this figure's behavior when a user hovers over it. When set to 'x', all data sharing the same 'x' coordinate will be shown on screen
    /// with corresponding trace labels. When set to 'y' all data sharing the same 'y' coordinates will be shown on the screen with corresponding
    /// trace labels. When set to 'closest', information about the data point closest to where the viewer is hovering will appear.
    [<RequireQualifiedAccess>]
    type HoverMode =
        | Closest | X | Y | False

        static member toString = function
            | Closest -> "closest"
            | X       -> "x"
            | Y       -> "y"
            | False   -> "false"

        static member convert = HoverMode.toString >> box
        override this.ToString() = this |> HoverMode.toString
        member this.Convert() = this |> HoverMode.convert

    [<RequireQualifiedAccess>]
    type HorizontalAlign = 
        |Left |Center |Right
        static member toString = function
            | Left  -> "left"             
            | Center-> "center"            
            | Right -> "right"    

        static member convert = HorizontalAlign.toString >> box
        override this.ToString() = this |> HorizontalAlign.toString
        member this.Convert() = this |> HorizontalAlign.convert

//--------------------------
// #I#
//--------------------------

    [<RequireQualifiedAccess>]
    type InsideTextAnchor =
        | End | Middle | Start
        static member toString = function
            | End       -> "end"             
            | Middle    -> "middle"            
            | Start     -> "start"    

        static member convert = InsideTextAnchor.toString >> box
        override this.ToString() = this |> InsideTextAnchor.toString
        member this.Convert() = this |> InsideTextAnchor.convert
        
    [<RequireQualifiedAccess>]
    type InsideTextOrientation =
        | Horizontal | Radial | Tangential | Auto
        static member toString = function
            | Horizontal   -> "horizontal"             
            | Radial       -> "radial"            
            | Tangential   -> "tangential"    
            | Auto         -> "auto"    

        static member convert = InsideTextOrientation.toString >> box
        override this.ToString() = this |> InsideTextOrientation.toString
        member this.Convert() = this |> InsideTextOrientation.convert
        
    [<RequireQualifiedAccess>]
    type ImageFormat =
        | SVG  | PNG | JPEG
        static member toString = function
            | SVG  -> "svg"             
            | PNG  -> "png"            
            | JPEG -> "jpeg"    

        static member convert = ImageFormat.toString >> box
        override this.ToString() = this |> ImageFormat.toString
        member this.Convert() = this |> ImageFormat.convert
        
    [<RequireQualifiedAccess>]
    type IntensityMode =
        | Vertex  | Cell 
        static member toString = function
            | Vertex  -> "vertex"             
            | Cell  -> "cell"            


        static member convert = IntensityMode.toString >> box
        override this.ToString() = this |> IntensityMode.toString
        member this.Convert() = this |> IntensityMode.convert


//--------------------------
// #J#

    [<RequireQualifiedAccess>]
    type Jitterpoints = Boxpoints

//--------------------------
// #K#
//--------------------------

//--------------------------
// #L#
//--------------------------

    
    /// Specifies whether shapes are drawn below or above traces. Default is Above
    [<RequireQualifiedAccess>]
    type LayoutImageSizing =
        | Fill 
        | Contain 
        | Stretch

        static member toString = function
            |  Fill     -> "fill"
            |  Contain  -> "contain"
            |  Stretch  -> "stretch"

        static member convert = LayoutImageSizing.toString >> box
        override this.ToString() = this |> LayoutImageSizing.toString
        member this.Convert() = this |> LayoutImageSizing.convert
            
    /// Specifies whether shapes are drawn below or above traces. Default is Above
    [<RequireQualifiedAccess>]
    type Layer =
        | Below 
        | Above 
        | AboveTraces 
        | BelowTraces
    
        static member toString = function
            | Below         -> "below"
            | Above         -> "above"
            | AboveTraces   -> "above traces"
            | BelowTraces   -> "below traces"

        static member convert = Layer.toString >> box
        override this.ToString() = this |> Layer.toString
        member this.Convert() = this |> Layer.convert

    /// Determines the set of locations used to match entries in `locations` to regions on the map. Default: ISO-3
    [<RequireQualifiedAccess>]
    type LocationFormat = 
        | CountryNames 
        | ISO_3
        | USA_states
        | GeoJson_Id
    
        static member toString = function
            | CountryNames  -> "country names"
            | ISO_3         -> "ISO-3" 
            | USA_states    -> "USA-states"
            | GeoJson_Id    -> "geojson-id"
    
        static member convert = LocationFormat.toString >> box 
        override this.ToString() = this |> LocationFormat.toString
        member this.Convert() = this |> LocationFormat.convert

    
    /// Determines wether the rows of a LayoutGrid are enumerated from the top or the bottom.
    [<RequireQualifiedAccess>]
    type LayoutGridRowOrder =
        |TopToBottom
        |BottomToTop

        static member toString = function
            |TopToBottom -> "top to bottom"
            |BottomToTop -> "bottom to top"       

        static member convert = LayoutGridRowOrder.toString >> box
        override this.ToString() = this |> LayoutGridRowOrder.toString
        member this.Convert() = this |> LayoutGridRowOrder.convert

    /// Pattern to use for autogenerating Axis Ids when not specifically specifying subplot axes IDs in LayoutGrids
    [<RequireQualifiedAccess>]
    type LayoutGridPattern =
        /// Uses a new xy pair for each cell, left-to-right across each row then iterating rows according to `roworder`
        | Independent
        /// Gives one x axis per column and one y axis per row
        | Coupled
        
        static member toString = function
            | Independent -> "independent"
            | Coupled     -> "coupled"  
            
        static member convert = LayoutGridPattern.toString >> box
        override this.ToString() = this |> LayoutGridPattern.toString
        member this.Convert() = this |> LayoutGridPattern.convert


    /// Sets where the x axis labels and titles go on a layout grid.
    [<RequireQualifiedAccess>]
    type LayoutGridXSide =
        | Bottom
        | BottomPlot
        | Top
        | TopPlot

        static member toString = function
            | Bottom     -> "bottom"
            | BottomPlot -> "bottom plot"
            | Top        -> "top"
            | TopPlot    -> "top plot"

        static member convert = LayoutGridXSide.toString >> box
        override this.ToString() = this |> LayoutGridXSide.toString
        member this.Convert() = this |> LayoutGridXSide.convert

    /// Sets where the y axis labels and titles go on a layout grid.
    [<RequireQualifiedAccess>]
    type LayoutGridYSide =
        | Left
        | LeftPlot
        | Right
        | RightPlot

        static member toString = function
            | Left      -> "left"
            | LeftPlot  -> "left plot"
            | Right     -> "right"
            | RightPlot -> "right plot"

        static member convert = LayoutGridYSide.toString >> box
        override this.ToString() = this |> LayoutGridYSide.toString
        member this.Convert() = this |> LayoutGridYSide.convert

    [<RequireQualifiedAccess>]
    type XAnchorPosition =
        | Auto
        | Left
        | Center
        | Right

        static member toString = function
            | Auto      -> "auto"
            | Left      -> "left"
            | Center    -> "center"
            | Right     -> "right"

        static member convert = XAnchorPosition.toString >> box
        override this.ToString() = this |> XAnchorPosition.toString
        member this.Convert() = this |> XAnchorPosition.convert

    [<RequireQualifiedAccess>]
    type YAnchorPosition =
        | Auto
        | Top
        | Middle
        | Bottom

        static member toString = function
            | Auto      -> "auto"
            | Top       -> "top"
            | Middle    -> "middle"
            | Bottom    -> "bottom"

        static member convert = YAnchorPosition.toString >> box
        override this.ToString() = this |> YAnchorPosition.toString
        member this.Convert() = this |> YAnchorPosition.convert

//--------------------------
// #M#
//--------------------------
    
    [<RequireQualifiedAccess>]
    type ModeBarButton = 

        | ToImage              
        | SendDataToCloud      
        | EditInChartStudio    
        | Zoom2d               
        | Pan2d                
        | Select2d             
        | Lasso2d              
        | DrawClosedPath       
        | DrawOpenPath         
        | DrawLine             
        | DrawRect             
        | DrawCircle           
        | EraseShape           
        | ZoomIn2d             
        | ZoomOut2d            
        | AutoScale2d          
        | ResetScale2d         
        | HoverClosestCartesian
        | HoverCompareCartesian
        | Zoom3d               
        | Pan3d                
        | OrbitRotation        
        | TableRotation        
        | ResetCameraDefault3d 
        | ResetCameraLastSave3d
        | HoverClosest3d       
        | ZoomInGeo            
        | ZoomOutGeo           
        | ResetGeo             
        | HoverClosestGeo      
        | HoverClosestGl2d     
        | HoverClosestPie      
        | ResetSankeyGroup     
        | ToggleHover          
        | ResetViews           
        | ToggleSpikelines     
        | ResetViewMapbox      
        | ZoomInMapbox         
        | ZoomOutMapbox        
    
        static member toString = function

            | ToImage                 -> "toImage"
            | SendDataToCloud         -> "sendDataToCloud"
            | EditInChartStudio       -> "editInChartStudio"
            | Zoom2d                  -> "zoom2d"
            | Pan2d                   -> "pan2d"
            | Select2d                -> "select2d"
            | Lasso2d                 -> "lasso2d"
            | DrawClosedPath          -> "drawclosedpath"
            | DrawOpenPath            -> "drawopenpath"
            | DrawLine                -> "drawline"
            | DrawRect                -> "drawrect"
            | DrawCircle              -> "drawcircle"
            | EraseShape              -> "eraseshape"
            | ZoomIn2d                -> "zoomIn2d"
            | ZoomOut2d               -> "zoomOut2d"
            | AutoScale2d             -> "autoScale2d"
            | ResetScale2d            -> "resetScale2d"
            | HoverClosestCartesian   -> "hoverClosestCartesian"
            | HoverCompareCartesian   -> "hoverCompareCartesian"
            | Zoom3d                  -> "zoom3d"
            | Pan3d                   -> "pan3d"
            | OrbitRotation           -> "orbitRotation"
            | TableRotation           -> "tableRotation"
            | ResetCameraDefault3d    -> "resetCameraDefault3d"
            | ResetCameraLastSave3d   -> "resetCameraLastSave3d"
            | HoverClosest3d          -> "hoverClosest3d"
            | ZoomInGeo               -> "zoomInGeo"
            | ZoomOutGeo              -> "zoomOutGeo"
            | ResetGeo                -> "resetGeo"
            | HoverClosestGeo         -> "hoverClosestGeo"
            | HoverClosestGl2d        -> "hoverClosestGl2d"
            | HoverClosestPie         -> "hoverClosestPie"
            | ResetSankeyGroup        -> "resetSankeyGroup"
            | ToggleHover             -> "toggleHover"
            | ResetViews              -> "resetViews"
            | ToggleSpikelines        -> "toggleSpikelines"
            | ResetViewMapbox         -> "resetViewMapbox"
            | ZoomInMapbox            -> "zoomInMapbox"
            | ZoomOutMapbox           -> "zoomOutMapbox"


        static member convert = ModeBarButton.toString >> box
        override this.ToString() = this |> ModeBarButton.toString
        member this.Convert() = this |> ModeBarButton.convert

    /// Determines if the axis lines or/and ticks are mirrored to the opposite side of the plotting area. If "true", the axis lines are mirrored. 
    /// If "ticks", the axis lines and ticks are mirrored. If "false", mirroring is disable. If "all", axis lines are mirrored on all shared-axes subplots. If "allticks", axis lines and ticks are mirrored on all shared-axes subplots.
    [<RequireQualifiedAccess>]
    type Mirror =
        | True | Ticks | False | All | AllTicks 
    
        static member toString = function
            | True     -> "true"
            | Ticks    -> "ticks"
            | False    -> "false"
            | All      -> "all"
            | AllTicks -> "allticks"

        static member convert = Mirror.toString >> box
        override this.ToString() = this |> Mirror.toString
        member this.Convert() = this |> Mirror.convert

    // | "lines", "markers", "text" joined with a "+" OR "none".
    [<RequireQualifiedAccess>]
    type Mode = 
        | None 
        | Lines   | Lines_Markers | Lines_Text | Lines_Markers_Text
        | Markers | Markers_Text
        | Text
        static member toString = function
            | None               -> "none"             
            | Lines              -> "lines"            
            | Lines_Markers      -> "lines+markers"    
            | Lines_Text         -> "lines+text"       
            | Lines_Markers_Text -> "lines+markers+text"
            | Markers            -> "markers"          
            | Markers_Text       -> "markers+text"
            | Text               -> "text"             

        static member convert = Mode.toString >> box
        override this.ToString() = this |> Mode.toString
        member this.Convert() = this |> Mode.convert

    /// Functions to manipulate StyleParam Mode
    [<RequireQualifiedAccess>]
    module ModeUtils=
    
        /// Takes the current mode and adds the Text flag
        let showText isShow (cmode:Mode) =
            if isShow then 
                match cmode with
                | Mode.None          -> Mode.Text
                | Mode.Lines         -> Mode.Lines_Text
                | Mode.Lines_Markers -> Mode.Lines_Markers_Text
                | Mode.Markers       -> Mode.Markers_Text
                | _             -> cmode
            else
                cmode
        /// Takes the current mode and adds the Markers flag
        let showMarker isShow (cmode:Mode) =
            if isShow then 
                match cmode with
                | Mode.None          -> Mode.Markers
                | Mode.Lines         -> Mode.Lines_Markers
                | Mode.Lines_Text    -> Mode.Lines_Markers_Text            
                | Mode.Text          -> Mode.Markers_Text
                | _             -> cmode
            else
                cmode
                    
        /// Takes the current mode and adds the Lines flag
        let showLines isShow (cmode:Mode) =
            if isShow then 
                match cmode with
                | Mode.None          -> Mode.Lines
                | Mode.Markers       -> Mode.Lines_Markers
                | Mode.Markers_Text  -> Mode.Lines_Markers_Text
                | Mode.Text          -> Mode.Lines_Text
                | _             -> cmode
            else
                cmode

    /// Defines the map layers that are rendered by default below the trace layers defined in `data`, which are themselves by default rendered below the layers defined in `layout.mapbox.layers`. 
    /// These layers can be defined either explicitly as a Mapbox Style object which can contain multiple layer definitions that load data from any public or private Tile Map Service (TMS or XYZ) or Web Map Service (WMS) or implicitly by using one of the built-in style objects which use WMSes which do not require any access tokens, 
    /// or by using a default Mapbox style or custom Mapbox style URL, both of which require a Mapbox access token Note that Mapbox access token can be set in the `accesstoken` attribute or in the `mapboxAccessToken` config option. 
    /// Mapbox Style objects are of the form described in the Mapbox GL JS documentation available at https://docs.mapbox.com/mapbox-gl-js/style-spec The built-in plotly.js styles objects are: open-street-map, white-bg, carto-positron, carto-darkmatter, stamen-terrain, stamen-toner, stamen-watercolor 
    /// The built-in Mapbox styles are: basic, streets, outdoors, light, dark, satellite, satellite-streets Mapbox style URLs are of the form: mapbox://mapbox.mapbox-<name>-<version>
    [<RequireQualifiedAccess>]
    type MapboxStyle =
        // plotly presets
        | OpenStreetMap
        | WhiteBG
        | CartoPositron
        | CartoDarkmatter
        | StamenTerrain
        | StamenToner
        | StamenWatercolor
        
        // Mapbox presets
        | MapboxBasic
        | MapboxStreets
        | MapboxOutdoors
        | MapboxLight
        | MapboxDark
        | MapboxSatellite
        | MapboxSatelliteStreets

        //Custom
        | Custom of string

        static member toString = function

            | OpenStreetMap -> "open-street-map"
            | WhiteBG -> "white-bg"
            | CartoPositron -> "carto-positron"
            | CartoDarkmatter -> "carto-darkmatter"
            | StamenTerrain -> "stamen-terrain"
            | StamenToner -> "stamen-toner"
            | StamenWatercolor -> "stamen-watercolor"
            
            | MapboxBasic -> "basic"
            | MapboxStreets -> "streets"
            | MapboxOutdoors -> "outdoors"
            | MapboxLight -> "light"
            | MapboxDark -> "dark"
            | MapboxSatellite -> "satellite"
            | MapboxSatelliteStreets -> "satellite-streets"

            | Custom s -> s

        static member convert = MapboxStyle.toString >> box
        override this.ToString() = this |> MapboxStyle.toString
        member this.Convert() = this |> MapboxStyle.convert
    
    [<RequireQualifiedAccess>]
    type MapboxLayerSourceType =
        | GeoJson
        | Vector
        | Raster
        | Image

        static member toString = function
            | GeoJson -> "geojson"
            | Vector  -> "vector"
            | Raster  -> "raster"
            | Image   -> "image"

        static member convert = MapboxLayerSourceType.toString >> box
        override this.ToString() = this |> MapboxLayerSourceType.toString
        member this.Convert() = this |> MapboxLayerSourceType.convert

    [<RequireQualifiedAccess>]
    type MapboxLayerType =
        | Circle
        | Line
        | Fill
        | Symbol
        | Raster

        static member toString = function
            | Circle -> "circle"
            | Line -> "line"
            | Fill -> "fill"
            | Symbol -> "symbol"
            | Raster -> "raster"

        static member convert = MapboxLayerType.toString >> box
        override this.ToString() = this |> MapboxLayerType.toString
        member this.Convert() = this |> MapboxLayerType.convert


    [<RequireQualifiedAccess>]
    type MapboxLayerSymbolPlacement =
        | Point
        | Line
        | LineCenter

        static member toString = function
            | Point -> "point"
            | Line -> "line"
            | LineCenter -> "line-center"

        static member convert = MapboxLayerSymbolPlacement.toString >> box
        override this.ToString() = this |> MapboxLayerSymbolPlacement.toString
        member this.Convert() = this |> MapboxLayerSymbolPlacement.convert

    
    [<RequireQualifiedAccess>]
    type MarkerSizeMode =
        | Diameter | Area
    
        static member toString = function
            | Diameter  -> "diameter"
            | Area      -> "area"
      
        static member convert = MarkerSizeMode.toString >> box
        override this.ToString() = this |> MarkerSizeMode.toString
        member this.Convert() = this |> MarkerSizeMode.convert

//--------------------------
// #N#
//--------------------------

//--------------------------
// #O#
//--------------------------

    [<RequireQualifiedAccess>]
    type Orientation =
        | Horizontal
        | Vertical

        static member toString = function
            | Horizontal -> "h"
            | Vertical   -> "v"

        static member convert = Orientation.toString >> box
        override this.ToString() = this |> Orientation.toString
        member this.Convert() = this |> Orientation.convert

//--------------------------
// #P#
//--------------------------

    
    [<RequireQualifiedAccess>]
    type PatternFillMode =
        | Replace | Overlay 
    
        static member toString = function
            | Replace   -> "replace"
            | Overlay   -> "overlay"

        static member convert = PatternFillMode.toString >> box    
        override this.ToString() = this |> PatternFillMode.toString
        member this.Convert() = this |> PatternFillMode.convert
        
    
    [<RequireQualifiedAccess>]
    type PatternShape =
        | None 
        | DiagonalDescending 
        | DiagonalAscending
        | DiagonalChecked
        | HorizontalLines
        | VerticalLines
        | Checked
        | Dots
    
        static member toString = function
            | None                  -> "" 
            | DiagonalDescending    -> "/" 
            | DiagonalAscending     -> """\"""
            | DiagonalChecked       -> "x" 
            | HorizontalLines       -> "-" 
            | VerticalLines         -> "|" 
            | Checked               -> "+" 
            | Dots                  -> "."

        static member convert = PatternShape.toString >> box    
        override this.ToString() = this |> PatternShape.toString
        member this.Convert() = this |> PatternShape.convert
        

    [<RequireQualifiedAccess>]
    type PeriodAlignment =
        | Start | Middle | End
        
        static member toString = function
            | Start -> "start"            
            | Middle-> "middle"            
            | End   -> "end"            

        static member convert = PeriodAlignment.toString >> box
        override this.ToString() = this |> PeriodAlignment.toString
        member this.Convert() = this |> PeriodAlignment.convert

    /// Sets the method used to compute the sample's Q1 and Q3 quartiles
    [<RequireQualifiedAccess>]
    type PolarGridShape =
        | Circular | Linear
        
        static member toString = function
            | Circular  -> "circular"            
            | Linear    -> "linear"            

        static member convert = PolarGridShape.toString >> box
        override this.ToString() = this |> PolarGridShape.toString
        member this.Convert() = this |> PolarGridShape.convert

//--------------------------
// #Q#
//--------------------------

    /// Sets the method used to compute the sample's Q1 and Q3 quartiles
    [<RequireQualifiedAccess>]
    type QuartileMethod =
        | Linear | Exclusive | Inclusive

        static member toString = function
            | Linear          -> "linear"            
            | Exclusive -> "exclusive"            
            | Inclusive       -> "inclusive"

        static member convert = QuartileMethod.toString >> box
        override this.ToString() = this |> QuartileMethod.toString
        member this.Convert() = this |> QuartileMethod.convert


//--------------------------
// #R#
//--------------------------

    /// If "normal", the range is computed in relation to the extrema of the input data. If "tozero"`, the range extends to 0, regardless of the input data If "nonnegative", the range is non-negative, regardless of the input data.
    [<RequireQualifiedAccess>]
    type RangeMode =
        | Normal | ToZero | NonNegative
    
        static member toString = function
            | Normal      -> "normal"            
            | ToZero      -> "tozero"            
            | NonNegative -> "nonnegative"

        static member convert = RangeMode.toString >> box
        override this.ToString() = this |> RangeMode.toString
        member this.Convert() = this |> RangeMode.convert


    /// Defines a Range between min and max value 
    [<RequireQualifiedAccess>]
    type Range =
        | MinMax of float * float
        | Values of array<float>
    
        static member convert = function
            | MinMax (min,max)   -> box [|min;max|]
            | Values  arr   -> box arr

        member this.Convert() = this |> Range.convert

    /// Determines a pattern on the time line that generates breaks.
    [<RequireQualifiedAccess>]
    type RangebreakPattern =
        | DayOfWeek
        | Hour
        | NoPattern
    
        static member toString = function
            | DayOfWeek -> "day of week"
            | Hour      -> "hour"
            | NoPattern -> ""

        static member convert = RangebreakPattern.toString >> box
        override this.ToString() = this |> RangebreakPattern.toString
        member this.Convert() = this |> RangebreakPattern.convert
    

//--------------------------
// #S#
//--------------------------

    [<RequireQualifiedAccess>]
    type StackGaps =
        | InferZero | Interpolate      
    
        static member toString = function
            | InferZero     -> "infer zero" 
            | Interpolate   -> "interpolate" 


        static member convert = StackGaps.toString >> box
        override this.ToString() = this |> StackGaps.toString
        member this.Convert() = this |> StackGaps.convert
        
    [<RequireQualifiedAccess>]
    type SelectDirection =
        | Horizontal    
        | Vertical      
        | Diagonal      
        | Any           
    
        static member toString = function
            | Horizontal    -> "h" 
            | Vertical      -> "v" 
            | Diagonal      -> "d" 
            | Any           -> "any"

        static member convert = SelectDirection.toString >> box
        override this.ToString() = this |> SelectDirection.toString
        member this.Convert() = this |> SelectDirection.convert

    /// Specifies the shape type to be drawn. If "line", a line is drawn from (`x0`,`y0`) to (`x1`,`y1`) If "circle", a circle is drawn from ((`x0`+`x1`)/2, (`y0`+`y1`)/2))
    /// with radius (|(`x0`+`x1`)/2 - `x0`|, |(`y0`+`y1`)/2 -`y0`)|) If "rect", a rectangle is drawn linking (`x0`,`y0`), (`x1`,`y0`), (`x1`,`y1`), (`x0`,`y1`), (`x0`,`y0`)
    /// If "path", draw a custom SVG path using `path`.          
    [<RequireQualifiedAccess>]
    type ShapeType =
        | Circle | Rectangle | SvgPath | Line 
    
        static member toString = function
            | Circle    -> "circle"
            | Rectangle -> "rect"
            | SvgPath   -> "path"
            | Line      -> "line"

        static member convert = ShapeType.toString >> box
        override this.ToString() = this |> ShapeType.toString
        member this.Convert() = this |> ShapeType.convert

    [<RequireQualifiedAccess>]
    type SymbolStyle =
        | Open
        | Dot
        | OpenDot

        static member toString = function
            | Open    -> "open"             
            | Dot     -> "dot"            
            | OpenDot -> "open-dot"     

        static member toModifier = function
            | Open    -> 100
            | Dot     -> 200
            | OpenDot -> 300

        static member convert = SymbolStyle.toString >> box
        override this.ToString() = this |> SymbolStyle.toString
        member this.Convert() = this |> SymbolStyle.convert

    [<RequireQualifiedAccess>]
    type MarkerSymbol =
        | Modified of MarkerSymbol * SymbolStyle
        | Circle           
        | Square           
        | Diamond          
        | Cross            
        | X                
        | TriangleUp       
        | TriangleDown     
        | TriangleLeft     
        | TriangleRight    
        | TriangleNE       
        | TriangleSE       
        | TriangleSW       
        | TriangleNW       
        | Pentagon         
        | Hexagon          
        | Hexagon2         
        | Octagon          
        | Star             
        | Hexagram         
        | StarTriangleUp   
        | StarTriangleDown 
        | StarSquare       
        | StarDiamond      
        | DiamondTall      
        | DiamondWide      
        | Hourglass        
        | Bowtie           
        | CircleCross      
        | CircleX          
        | SquareCross      
        | SquareX          
        | DiamondCross     
        | DiamondX         
        | CrossThin        
        | XThin            
        | Asterisk         
        | Hash             
        | YUp              
        | YDown            
        | YLeft            
        | YRight           
        | LineEW           
        | LineNS           
        | LineNE           
        | LineNW           
        | ArrowUp          
        | ArrowDown        
        | ArrowLeft        
        | ArrowRight       
        | ArrowBarUp       
        | ArrowBarDown     
        | ArrowBarLeft     
        | ArrowBarRight    
        
        static member toInteger = function
            | Modified (symbol, modifier)   -> (symbol |> MarkerSymbol.toInteger) + SymbolStyle.toModifier modifier
            | Circle                        -> 0
            | Square                        -> 1
            | Diamond                       -> 2
            | Cross                         -> 3
            | X                             -> 4 
            | TriangleUp                    -> 5
            | TriangleDown                  -> 6
            | TriangleLeft                  -> 7
            | TriangleRight                 -> 8
            | TriangleNE                    -> 9
            | TriangleSE                    -> 10
            | TriangleSW                    -> 11
            | TriangleNW                    -> 12
            | Pentagon                      -> 13
            | Hexagon                       -> 14
            | Hexagon2                      -> 15
            | Octagon                       -> 16
            | Star                          -> 17
            | Hexagram                      -> 18
            | StarTriangleUp                -> 19
            | StarTriangleDown              -> 20
            | StarSquare                    -> 21
            | StarDiamond                   -> 22
            | DiamondTall                   -> 23
            | DiamondWide                   -> 24
            | Hourglass                     -> 25
            | Bowtie                        -> 26
            | CircleCross                   -> 27
            | CircleX                       -> 28
            | SquareCross                   -> 29
            | SquareX                       -> 30
            | DiamondCross                  -> 31
            | DiamondX                      -> 32
            | CrossThin                     -> 33
            | XThin                         -> 34
            | Asterisk                      -> 35
            | Hash                          -> 36
            | YUp                           -> 37
            | YDown                         -> 38
            | YLeft                         -> 39
            | YRight                        -> 40
            | LineEW                        -> 41
            | LineNS                        -> 42
            | LineNE                        -> 43
            | LineNW                        -> 44
            | ArrowUp                       -> 45
            | ArrowDown                     -> 46
            | ArrowLeft                     -> 47
            | ArrowRight                    -> 48
            | ArrowBarUp                    -> 49
            | ArrowBarDown                  -> 50
            | ArrowBarLeft                  -> 51
            | ArrowBarRight                 -> 52

        static member convert = MarkerSymbol.toInteger >> string >> box
        override this.ToString() = this |> MarkerSymbol.toInteger |> string
        member this.Convert() = this |> MarkerSymbol.toInteger |> string |> box

    /// Determines the line shape. With "spline" the lines are drawn using spline interpolation. The other available values correspond to step-wise line shapes.
    [<RequireQualifiedAccess>]
    type Shape =
        | Linear | Spline | Hv | Vh | Hvh | Vhv
    
        static member toString = function
            | Linear -> "linear"
            | Spline -> "spline"
            | Hv     -> "hv"
            | Vh     -> "vh"
            | Hvh    -> "hvh"
            | Vhv    -> "vhv"
    
        static member convert  = Shape.toString >> box
        override this.ToString() = this |> Shape.toString
        member this.Convert() = this |> Shape.convert


    /// If "all", all tick labels are displayed with a prefix. If "first", only the first tick is displayed with a prefix. If "last", only the last tick is displayed with a suffix. If "none", tick prefixes are hidden.
    [<RequireQualifiedAccess>]
    type ShowTickOption =
        | All | First | Last | None
        
        static member toString = function
            | All   -> "all"
            | First -> "first"
            | Last  -> "last"
            | None  -> "none"
            
        static member convert = ShowTickOption.toString >> box
        override this.ToString() = this |> ShowTickOption.toString
        member this.Convert() = this |> ShowTickOption.convert


    /// If "all", all exponents are shown besides their significands. If "first", only the exponent of the first tick is shown. If "last", only the exponent of the last tick is shown. If "none", no exponents appear.
    [<RequireQualifiedAccess>]
    type ShowExponent =
        | All | First | Last | None
        
        static member toString = function
            | All   -> "all"
            | First -> "first"
            | Last  -> "last"
            | None  -> "none"
            
        static member convert = ShowExponent.toString >> box
        override this.ToString() = this |> ShowExponent.toString
        member this.Convert() = this |> ShowExponent.convert


    [<RequireQualifiedAccess>]
    type Side =
        | Top | Bottom | Left | Right 
    
        static member toString = function
            | Top    -> "top"
            | Bottom -> "bottom"
            | Left   -> "left"
            | Right  -> "right"            
   
        static member convert = Side.toString >> box
        override this.ToString() = this |> Side.toString
        member this.Convert() = this |> Side.convert

    /// Choose between algorithms ('best' or 'fast') to smooth data linked to 'z'. The default value is false corresponding to no smoothing.
    [<RequireQualifiedAccess>]
    type SmoothAlg =
        | False | Best | Fast
            
        static member toString = function
            | False -> "false"
            | Best  -> "best"
            | Fast  -> "fast"

        static member convert = SmoothAlg.toString >> box
        override this.ToString() = this |> SmoothAlg.toString
        member this.Convert() = this |> SmoothAlg.convert

    /// Determines the drawing mode for the spike line
    [<RequireQualifiedAccess>]
    type SpikeMode =
        | Axis 
        | Across
        | AxisAcross
        | Marker
        | AxisMarker
        | AxisAcrossMarker

        static member toString = function
            | Axis              -> "toaxis" 
            | Across            -> "across"
            | AxisAcross        -> "toaxis+across"
            | Marker            -> "marker"
            | AxisMarker        -> "toaxis+marker"
            | AxisAcrossMarker  -> "toaxis+across+marker"
      
        static member convert = SpikeMode.toString >> box
        override this.ToString() = this |> SpikeMode.toString
        member this.Convert() = this |> SpikeMode.convert
        
    /// Determines whether spikelines are stuck to the cursor or to the closest datapoints.
    [<RequireQualifiedAccess>]
    type SpikeSnap =
        | Data       
        | Cursor     
        | HoveredData

        static member toString = function
            | Data          -> "data" 
            | Cursor        -> "cursor" 
            | HoveredData   -> "hovered data"
      
        static member convert = SpikeSnap.toString >> box        
        override this.ToString() = this |> SpikeSnap.toString
        member this.Convert() = this |> SpikeSnap.convert

    /// Determines whether spikelines are stuck to the cursor or to the closest datapoints.
    [<RequireQualifiedAccess>]
    type TimeStepMode =
        | Backward | ToDate

        static member toString = function
            | Backward  -> "backward" 
            | ToDate    -> "todate"
      
        static member convert = TimeStepMode.toString >> box
        override this.ToString() = this |> TimeStepMode.toString
        member this.Convert() = this |> TimeStepMode.convert

    /// Sets the surface pattern of the iso-surface 3-D sections. The default pattern of the surface is `all` meaning that the rest of surface elements would be shaded. The check options (either 1 or 2) could be used to draw half of the squares on the surface. Using various combinations of capital `A`, `B`, `C`, `D` and `E` may also be used to reduce the number of triangles on the iso-surfaces and creating other patterns of interest.
    [<RequireQualifiedAccess>]
    type SurfacePattern =
        | A | B | C | D | E 
        | AB | AC | AD | AE
        | BC | BD | BE
        | CD | CE
        | ABC | ABD | ABE
        | BCD | BDE 
        | ABCD | BCDE
        | Odd
        | Even
        | All

        static member toString = function
            | A     -> "A"
            | B     -> "B"
            | C     -> "C"
            | D     -> "D"
            | E     -> "E"
            | AB    -> "A+B"
            | AC    -> "A+C"
            | AD    -> "A+D"
            | AE    -> "A+E"
            | BC    -> "B+C"
            | BD    -> "B+D"
            | BE    -> "B+E"
            | CD    -> "C+D"
            | CE    -> "C+E"
            | ABC   -> "A+B+C"
            | ABD   -> "A+B+D"
            | ABE   -> "A+B+E"
            | BCD   -> "B+C+D"
            | BDE   -> "B+D+E"
            | ABCD  -> "A+B+C+D"
            | BCDE  -> "B+C+D+E"
            | Odd   -> "odd"
            | Even  -> "even"
            | All   -> "all"

        static member convert = SurfacePattern.toString >> box
        override this.ToString() = this |> SurfacePattern.toString
        member this.Convert() = this |> SurfacePattern.convert

    [<RequireQualifiedAccess>]
    type SurfaceAxis =
        | NoSurfaceAxis 
        | X 
        | Y 
        | Z

        static member toString = function
            | NoSurfaceAxis -> "-1" 
            | X             -> "0" 
            | Y             -> "1" 
            | Z             -> "2" 
      
        static member convert = SurfaceAxis.toString >> box        
        override this.ToString() = this |> SurfaceAxis.toString
        member this.Convert() = this |> SurfaceAxis.convert


//--------------------------
// #T#
//--------------------------
    
    [<RequireQualifiedAccess>]
    type TransitionEasing =
        | Linear        
        | Quad          
        | Cubic         
        | Sin           
        | Exp           
        | Circle        
        | Elastic       
        | Back          
        | Bounce        
        | LinearIn      
        | QuadIn        
        | CubicIn       
        | SinIn         
        | ExpIn         
        | CircleIn      
        | ElasticIn     
        | BackIn        
        | BounceIn      
        | LinearOut     
        | QuadOut       
        | CubicOut      
        | SinOut        
        | ExpOut        
        | CircleOut     
        | ElasticOut    
        | BackOut       
        | BounceOut     
        | LinearInOut   
        | QuadInOut     
        | CubicInOut    
        | SinInOut      
        | ExpInOut      
        | CircleInOut   
        | ElasticInOut  
        | BackInOut     
        | BounceInOut   
    
        static member toString = function
            | Linear          -> "linear" 
            | Quad            -> "quad" 
            | Cubic           -> "cubic" 
            | Sin             -> "sin" 
            | Exp             -> "exp" 
            | Circle          -> "circle" 
            | Elastic         -> "elastic" 
            | Back            -> "back" 
            | Bounce          -> "bounce" 
            | LinearIn       -> "linear-in" 
            | QuadIn         -> "quad-in" 
            | CubicIn        -> "cubic-in" 
            | SinIn          -> "sin-in" 
            | ExpIn          -> "exp-in" 
            | CircleIn       -> "circle-in" 
            | ElasticIn      -> "elastic-in" 
            | BackIn         -> "back-in" 
            | BounceIn       -> "bounce-in" 
            | LinearOut      -> "linear-out" 
            | QuadOut        -> "quad-out" 
            | CubicOut       -> "cubic-out" 
            | SinOut         -> "sin-out" 
            | ExpOut         -> "exp-out" 
            | CircleOut      -> "circle-out" 
            | ElasticOut     -> "elastic-out" 
            | BackOut        -> "back-out" 
            | BounceOut      -> "bounce-out" 
            | LinearInOut   -> "linear-in-out" 
            | QuadInOut     -> "quad-in-out" 
            | CubicInOut    -> "cubic-in-out" 
            | SinInOut      -> "sin-in-out" 
            | ExpInOut      -> "exp-in-out" 
            | CircleInOut   -> "circle-in-out" 
            | ElasticInOut  -> "elastic-in-out" 
            | BackInOut     -> "back-in-out" 
            | BounceInOut   -> "bounce-in-out"

        static member convert = TransitionEasing.toString >> box
        override this.ToString() = this |> TransitionEasing.toString
        member this.Convert() = this |> TransitionEasing.convert
        
    [<RequireQualifiedAccess>]
    type TransitionOrdering =
        | LayoutFirst
        | TracesFirst

        static member toString = function
            | LayoutFirst -> "layout first"
            | TracesFirst -> "traces first"

        static member convert = TransitionOrdering.toString >> box
        override this.ToString() = this |> TransitionOrdering.toString
        member this.Convert() = this |> TransitionOrdering.convert

    /// Sets the positions of the `text` elements. Note that not all options work for every type of trace, e.g. Pie Charts only support "inside" | "outside" | "auto" | "none"
    ///
    /// - Cartesian plots: Sets the positions of the `text` elements with respects to the (x,y) coordinates.
    ///
    /// - Pie Charts and derivatives: Specifies the location of the text with respects to the sector.

    [<RequireQualifiedAccess>]
    type TextPosition =
        | TopLeft | TopCenter | TopRight | MiddleLeft | MiddleCenter | MiddleRight | BottomLeft | BottomCenter | BottomRight
        | Auto | Inside | Outside | None

        static member toString = function
            | TopLeft       -> "top left" 
            | TopCenter     -> "top center"
            | TopRight      -> "top right"
            | MiddleLeft    -> "middle left"
            | MiddleCenter  -> "middle center"
            | MiddleRight   -> "middle right"
            | BottomLeft    -> "bottom left"
            | BottomCenter  -> "bottom center"
            | BottomRight   -> "bottom right"        
            | Auto          -> "auto"
            | Inside        -> "inside"
            | Outside       -> "outside"            
            | None          -> "none"            

        static member convert = TextPosition.toString >> box
        override this.ToString() = this |> TextPosition.toString
        member this.Convert() = this |> TextPosition.convert

    /// Determines which trace information appear on the graph and  on hove (HoverInfo)
    //Any combination of "label", "text", "value", "percent" joined with a "+" OR "none". 
    //examples: "label", "text", "label+text", "label+text+value", "none"
    [<RequireQualifiedAccess>]
    type TextInfo =
        | All | None | Label | Text | Value | Percent
    
        static member toString = function
            | All     -> "all"
            | None    -> "none"
            | Label   -> "label"                        
            | Text    -> "text"                          
            | Value   -> "value"            
            | Percent -> "percent"

        static member convert = TextInfo.toString >> box
        override this.ToString() = this |> TextInfo.toString
        member this.Convert() = this |> TextInfo.convert

        static member toConcatString (o:seq<TextInfo>) =
            o |> Seq.map TextInfo.toString |> String.concat "+"

    /// Sets the tick mode for this axis. If "auto", the number of ticks is set via `nticks`. If "linear", the placement of the ticks is determined by a starting position `tick0` and a tick step `dtick` ("linear" is the default value if `tick0` and `dtick` are provided). 
    /// If "array", the placement of the ticks is set via `tickvals` and the tick text is `ticktext`. ("array" is the default value if `tickvals` is provided).
    [<RequireQualifiedAccess>]
    type TickMode =
        | Auto | Linear | Array
    
        static member toString = function
            | Auto   -> "auto"            
            | Linear -> "linear"            
            | Array  -> "array"

        static member convert = TickMode.toString >> box
        override this.ToString() = this |> TickMode.toString
        member this.Convert() = this |> TickMode.convert

    /// Determines whether ticks are drawn or not. If "", this axis' ticks are not drawn. If "outside" ("inside"), this axis' are drawn outside (inside) the axis lines.
    [<RequireQualifiedAccess>]
    type TickOptions =
        | Outside | Inside | Empty
    
        static member toString = function
            | Outside   -> "outside"            
            | Inside    -> "inside"            
            | Empty    -> ""

        static member convert = TickOptions.toString >> box
        override this.ToString() = this |> TickOptions.toString
        member this.Convert() = this |> TickOptions.convert

    [<RequireQualifiedAccess>]
    type UnitMode = 
        | Fraction | Pixels 
        static member toString = function
            | Fraction  -> "fraction"             
            | Pixels    -> "pixels"              

        static member convert = UnitMode.toString >> box
        override this.ToString() = this |> UnitMode.toString
        member this.Convert() = this |> UnitMode.convert

    [<RequireQualifiedAccess>]
    type TreemapEdgeShape =
        | ArrowRight | ArrowLeft | Straight | Slash | BackSlash 

        static member toString = function
             | ArrowRight-> ">"
             | ArrowLeft -> "<"
             | Straight  -> "|"
             | Slash     -> "/"
             | BackSlash -> """\"""

        static member convert = TreemapEdgeShape.toString >> box
        override this.ToString() = this |> TreemapEdgeShape.toString
        member this.Convert() = this |> TreemapEdgeShape.convert

    [<RequireQualifiedAccess>]
    type TreemapTilingPacking =
        | Squarify | Binary | Dice | Slice | SliceDice

        static member toString = function
            | Squarify  -> "squarify"
            | Binary    -> "binary"
            | Dice      -> "dice"
            | Slice     -> "slice"
            | SliceDice -> "slice-dice"

        static member convert = TreemapTilingPacking.toString >> box
        override this.ToString() = this |> TreemapTilingPacking.toString
        member this.Convert() = this |> TreemapTilingPacking.convert

    [<RequireQualifiedAccess>]
    type TraceOrder =
        | Normal
        | Reversed
        | Grouped
        | ReversedGrouped

        static member toString = function
            | Normal            -> "normal"
            | Reversed          -> "reversed"
            | Grouped           -> "grouped"
            | ReversedGrouped   -> "grouped+reversed"
    
        static member convert = TraceOrder.toString >> box
        override this.ToString() = this |> TraceOrder.toString
        member this.Convert() = this |> TraceOrder.convert

    [<RequireQualifiedAccess>]
    type TraceItemSizing =
        | Trace
        | Constant

        static member toString = function
            | Trace            -> "trace"
            | Constant          -> "constant"

        static member convert = TraceItemSizing.toString >> box    
        override this.ToString() = this |> TraceItemSizing.toString
        member this.Convert() = this |> TraceItemSizing.convert
        
    [<RequireQualifiedAccess>]
    type TraceItemClickOptions =
        | Toggle
        | ToggleOthers
        | False

        static member toString = function
            | Toggle            -> "toggle"
            | ToggleOthers      -> "toggleothers"
            | False             -> "False"

        static member convert = TraceItemClickOptions.toString >> box
        override this.ToString() = this |> TraceItemClickOptions.toString
        member this.Convert() = this |> TraceItemClickOptions.convert

    [<RequireQualifiedAccess>]
    type TickLabelMode =
        | Instant
        | Period

        static member toString = function
            | Instant   -> "instant"
            | Period    -> "period"

        static member convert = TickLabelMode.toString >> box
        override this.ToString() = this |> TickLabelMode.toString
        member this.Convert() = this |> TickLabelMode.convert

    [<RequireQualifiedAccess>]
    type TickLabelPosition =
        | Outside
        | Inside
        | OutsideTop
        | InsideTop
        | OutsideLeft
        | InsideLeft
        | OutsideRight
        | InsideRight
        | OutsideBottom
        | InsideBottom

        static member toString = function
            | Outside       -> "outside" 
            | Inside        -> "inside" 
            | OutsideTop    -> "outside top" 
            | InsideTop     -> "inside top" 
            | OutsideLeft   -> "outside left" 
            | InsideLeft    -> "inside left" 
            | OutsideRight  -> "outside right" 
            | InsideRight   -> "inside right" 
            | OutsideBottom -> "outside bottom" 
            | InsideBottom  -> "inside bottom"

        static member convert = TickLabelPosition.toString >> box
        override this.ToString() = this |> TickLabelPosition.toString
        member this.Convert() = this |> TickLabelPosition.convert

    [<RequireQualifiedAccess>]
    type TickLabelOverflow =
        | Allow         
        | HidePastDiv   
        | HidePastDomain

        static member toString = function
            | Allow         -> "allow" 
            | HidePastDiv   -> "hide past div" 
            | HidePastDomain-> "hide past domain" 


        static member convert = TickLabelOverflow.toString >> box
        override this.ToString() = this |> TickLabelOverflow.toString
        member this.Convert() = this |> TickLabelOverflow.convert

    [<RequireQualifiedAccess>]
    type TimeStep =
        | Month 
        | Year  
        | Day   
        | Hour  
        | Minute
        | Second
        | All   

        static member toString = function
            | Month   -> "month" 
            | Year    -> "year"  
            | Day     -> "day"   
            | Hour    -> "hour"  
            | Minute  -> "minute"
            | Second  -> "second"
            | All     -> "all"   


        static member convert = TimeStep.toString >> box
        override this.ToString() = this |> TimeStep.toString
        member this.Convert() = this |> TimeStep.convert


//--------------------------
// #U#
//--------------------------
    [<RequireQualifiedAccess>]
    type UniformTextMode =
        | Hide | False | Show
        
            static member toString = function
                | Hide  -> "hide"
                | False -> "false"
                | Show  -> "show"

            static member convert = UniformTextMode.toString >> box
            override this.ToString() = this |> UniformTextMode.toString
            member this.Convert() = this |> UniformTextMode.convert

//--------------------------
// #V#
//--------------------------

    [<RequireQualifiedAccess>]
    type ViolinMode =
        | Group | Overlay 
    
        static member toString = function
            | Group   -> "group"
            | Overlay -> "overlay"

        static member convert = ViolinMode.toString >> box    
        override this.ToString() = this |> ViolinMode.toString
        member this.Convert() = this |> ViolinMode.convert

    /// Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).
    [<RequireQualifiedAccess>]
    type Visible =
        | True | False | LegendOnly
    
        static member toString = function
            | True       -> "true"            
            | False      -> "false"            
            | LegendOnly -> "legendonly"

        static member convert = Visible.toString >> box
        override this.ToString() = this |> Visible.toString
        member this.Convert() = this |> Visible.convert

    [<RequireQualifiedAccess>]
    type VerticalAlign = 
        |Top |Middle |Bottom
        static member toString = function
            | Top       -> "top"             
            | Middle    -> "middle"            
            | Bottom    -> "bottom"    

        static member convert = VerticalAlign.toString >> box
        override this.ToString() = this |> VerticalAlign.toString
        member this.Convert() = this |> VerticalAlign.convert

//--------------------------
// #W#
//--------------------------

    [<RequireQualifiedAccess>]
    type WaterfallMode =
        | Group | Overlay 
    
        static member toString = function
            | Group   -> "group"
            | Overlay -> "overlay"

        static member convert = WaterfallMode.toString >> box    
        override this.ToString() = this |> WaterfallMode.toString
        member this.Convert() = this |> WaterfallMode.convert

    ///How to compute differences between bars in Waterfall Charts
    [<RequireQualifiedAccess>]
    type WaterfallMeasure =
        |Relative | Total
        static member toString = function
            | Relative  -> "relative"
            | Total     -> "total"

        static member convert = WaterfallMeasure.toString >> box
        override this.ToString() = this |> WaterfallMeasure.toString
        member this.Convert() = this |> WaterfallMeasure.convert

//--------------------------
// #X#
//--------------------------

//--------------------------
// #Y#
//--------------------------


//--------------------------
// #Z#
//--------------------------



//Symbol
//enumerated: 
//| Base number | Symbol name               | +100  | -open modification        | +200  | -dot modification         | +300  | -open-dot modification
//|=============|===========================|=======|===========================|=======|===========================|=======|============================
//| "0"         | "circle"                  | "100" | "circle-open"             | "200" | "circle-dot"              | "300" | "circle-open-dot" 
//| "1"         | "square"                  | "101" | "square-open"             | "201" | "square-dot"              | "301" | "square-open-dot" 
//| "2"         | "diamond"                 | "102" | "diamond-open"            | "202" | "diamond-dot"             | "302" | "diamond-open-dot" 
//| "3"         | "cross"                   | "103" | "cross-open"              | "203" | "cross-dot"               | "303" | "cross-open-dot" 
//| "4"         | "x"                       | "104" | "x-open"                  | "204" | "x-dot"                   | "304" | "x-open-dot" 
//| "5"         | "triangle-up"             | "105" | "triangle-up-open"        | "205" | "triangle-up-dot"         | "305" | "triangle-up-open-dot" 
//| "6"         | "triangle-down"           | "106" | "triangle-down-open"      | "206" | "triangle-down-dot"       | "306" | "triangle-down-open-dot" 
//| "7"         | "triangle-left"           | "107" | "triangle-left-open"      | "207" | "triangle-left-dot"       | "307" | "triangle-left-open-dot" 
//| "8"         | "triangle-right"          | "108" | "triangle-right-open"     | "208" | "triangle-right-dot"      | "308" | "triangle-right-open-dot" 
//| "9"         | "triangle-ne"             | "109" | "triangle-ne-open"        | "209" | "triangle-ne-dot"         | "309" | "triangle-ne-open-dot" 
//| "10"        | "triangle-se"             | "110" | "triangle-se-open"        | "210" | "triangle-se-dot"         | "310" | "triangle-se-open-dot" 
//| "11"        | "triangle-sw"             | "111" | "triangle-sw-open"        | "211" | "triangle-sw-dot"         | "311" | "triangle-sw-open-dot" 
//| "12"        | "triangle-nw"             | "112" | "triangle-nw-open"        | "212" | "triangle-nw-dot"         | "312" | "triangle-nw-open-dot" 
//| "13"        | "pentagon"                | "113" | "pentagon-open"           | "213" | "pentagon-dot"            | "313" | "pentagon-open-dot" 
//| "14"        | "hexagon"                 | "114" | "hexagon-open"            | "214" | "hexagon-dot"             | "314" | "hexagon-open-dot" 
//| "15"        | "hexagon2"                | "115" | "hexagon2-open"           | "215" | "hexagon2-dot"            | "315" | "hexagon2-open-dot" 
//| "16"        | "octagon"                 | "116" | "octagon-open"            | "216" | "octagon-dot"             | "316" | "octagon-open-dot" 
//| "17"        | "star"                    | "117" | "star-open"               | "217" | "star-dot"                | "317" | "star-open-dot"
//| "18"        | "hexagram"                | "118" | "hexagram-open"           | "218" | "hexagram-dot"            | "318" | "hexagram-open-dot" 
//| "19"        | "star-triangle-up"        | "119" | "star-triangle-up-open"   | "219" | "star-triangle-up-dot"    | "319" | "star-triangle-up-open-dot" 
//| "20"        | "star-triangle-down"      | "120" | "star-triangle-down-open" | "220" | "star-triangle-down-dot"  | "320" | "star-triangle-down-open-dot" 
//| "21"        | "star-square"             | "121" | "star-square-open"        | "221" | "star-square-dot"         | "321" | "star-square-open-dot" 
//| "22"        | "star-diamond"            | "122" | "star-diamond-open"       | "222" | "star-diamond-dot"        | "322" | "star-diamond-open-dot" 
//| "23"        | "diamond-tall"            | "123" | "diamond-tall-open"       | "223" | "diamond-tall-dot"        | "323" | "diamond-tall-open-dot" 
//| "24"        | "diamond-wide"            | "124" | "diamond-wide-open"       | "224" | "diamond-wide-dot"        | "324" | "diamond-wide-open-dot" 
//| "25"        | "hourglass"               | "125" | "hourglass-open"          |                                   |
//| "26"        | "bowtie"                  | "126" | "bowtie-open"             |                                   |
//| "27"        | "circle-cross"            | "127" | "circle-cross-open"       |                                   |
//| "28"        | "circle-x"                | "128" | "circle-x-open"           |                                   |
//| "29"        | "square-cross"            | "129" | "square-cross-open"       |                                   |
//| "30"        | "square-x"                | "130" | "square-x-open"           |                                   |
//| "31"        | "diamond-cross"           | "131" | "diamond-cross-open"      |                                   |
//| "32"        | "diamond-x"               | "132" | "diamond-x-open"          |                                   |
//| "33"        | "cross-thin"              | "133" | "cross-thin-open"         |                                   |
//| "34"        | "x-thin"                  | "134" | "x-thin-open"             |                                   |
//| "35"        | "asterisk"                | "135" | "asterisk-open"           |                                   |
//| "36"        | "hash"                    | "136" | "hash-open"               | "236" | "hash-dot"                | "336" | "hash-open-dot" 
//| "37"        | "y-up"                    | "137" | "y-up-open"               |
//| "38"        | "y-down"                  | "138" | "y-down-open"             |
//| "39"        | "y-left"                  | "139" | "y-left-open"             |
//| "40"        | "y-right"                 | "140" | "y-right-open"            |
//| "41"        | "line-ew"                 | "141" | "line-ew-open"            |
//| "42"        | "line-ns"                 | "142" | "line-ns-open"            |
//| "43"        | "line-ne"                 | "143" | "line-ne-open"            |
//| "44"        | "line-nw"                 | "144" | "line-nw-open"            |


    // hoverinfo (flaglist string) 
    //Any combination of "x", "y", "z", "text", "name" joined with a "+" OR "all" or "none" or "skip". 
    //examples: "x", "y", "x+y", "x+y+z", "all" 
    //default: "all" 
    //Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.




