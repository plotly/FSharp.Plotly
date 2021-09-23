namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type Pattern () =
    inherit DynamicObj () 

    /// <summary>
    /// 
    /// </summary>
    /// <param name="BGColor">When there is no colorscale sets the color of background pattern fill. Defaults to a `marker.color` background when `fillmode` is "overlay". Otherwise, defaults to a transparent background. </param>
    /// <param name="FGColor">When there is no colorscale sets the color of foreground pattern fill. Defaults to a `marker.color` background when `fillmode` is "replace". Otherwise, defaults to dark grey or white to increase contrast with the `bgcolor`.</param>
    /// <param name="FGOpacity">Sets the opacity of the foreground pattern fill. Defaults to a 0.5 when `fillmode` is "overlay". Otherwise, defaults to 1.</param>
    /// <param name="FillMode">Determines whether `marker.color` should be used as a default to `bgcolor` or a `fgcolor`.</param>
    /// <param name="Shape">Sets the shape of the pattern fill. By default, no pattern is used for filling the area.</param>
    /// <param name="MultiShape">Sets the shape of the pattern fill. By default, no pattern is used for filling the area.</param>
    /// <param name="Size">Sets the size of unit squares of the pattern fill in pixels, which corresponds to the interval of repetition of the pattern.</param>
    /// <param name="MultiSize">Sets the size of unit squares of the pattern fill in pixels, which corresponds to the interval of repetition of the pattern.</param>
    /// <param name="Solidity">Sets the solidity of the pattern fill. Solidity is roughly the fraction of the area filled by the pattern. Solidity of 0 shows only the background color without pattern and solidty of 1 shows only the foreground color without pattern.</param>
    static member init 
        (
            ?BGColor    : Color,
            ?FGColor    : Color,
            ?FGOpacity  : float,
            ?FillMode   : StyleParam.PatternFillMode,
            ?Shape      : StyleParam.PatternShape,
            ?MultiShape : seq<StyleParam.PatternShape>,
            ?Size       : int,
            ?MultiSize : seq<int>,
            ?Solidity   : float
        ) =
            Pattern()
            |> Pattern.style
                (
                   ?BGColor     = BGColor    ,
                   ?FGColor     = FGColor    ,
                   ?FGOpacity   = FGOpacity  ,
                   ?FillMode    = FillMode   ,
                   ?Shape       = Shape      ,
                   ?MultiShape  = MultiShape ,
                   ?Size        = Size       ,
                   ?MultiSize  = MultiSize ,
                   ?Solidity    = Solidity   
                )

    static member style
        (
            ?BGColor    : Color,
            ?FGColor    : Color,
            ?FGOpacity  : float,
            ?FillMode   : StyleParam.PatternFillMode,
            ?Shape      : StyleParam.PatternShape,
            ?MultiShape : seq<StyleParam.PatternShape>,
            ?Size       : int,
            ?MultiSize  : seq<int>,
            ?Solidity   : float
        ) =

            fun (pattern: Pattern) ->
               
                BGColor             |> DynObj.setValueOpt pattern "bgcolor"
                FGColor             |> DynObj.setValueOpt pattern "fgcolor"
                FGOpacity           |> DynObj.setValueOpt pattern "fgopacity"
                FillMode            |> DynObj.setValueOptBy pattern "fillmode"  StyleParam.PatternFillMode.convert
                (Shape, MultiShape) |> DynObj.setSingleOrMultiOptBy pattern "shape" StyleParam.PatternShape.convert
                (Size, MultiSize)   |> DynObj.setSingleOrMultiOpt pattern "size"
                Solidity            |> DynObj.setValueOpt pattern "solidity"
               
                pattern
