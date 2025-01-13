namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

type Selection() =
    inherit DynamicObj()

    /// <summary>
    /// Returns a new Selection object with the given styles
    /// </summary>
    /// <param name="Line">Sets the outline of the selection.</param>
    /// <param name="Name">When used in a template, named items are created in the output figure in addition to any items the figure already has in this array. You can modify these items in the output figure by making your own item with `templateitemname` matching this `name` alongside your modifications (including `visible: false` or `enabled: false` to hide it). Has no effect outside of a template.</param>
    /// <param name="Opacity">Sets the opacity of the selection.</param>
    /// <param name="Path">For `type` "path" - a valid SVG path similar to `shapes.path` in data coordinates. Allowed segments are: M, L and Z.</param>
    /// <param name="TemplateItemName">Used to refer to a named item in this array in the template. Named items from the template will be created even without a matching item in the input figure, but you can modify one by making an item with `templateitemname` matching its `name`, alongside your modifications (including `visible: false` or `enabled: false` to hide it). If there is no template or no matching item, this item will be hidden unless you explicitly show it with `visible: true`.</param>
    /// <param name="SelectionType">Specifies the selection type to be drawn. If "rect", a rectangle is drawn linking (`x0`,`y0`), (`x1`,`y0`), (`x1`,`y1`) and (`x0`,`y1`). If "path", draw a custom SVG path using `path`.</param>
    /// <param name="X0">Sets the selection's starting x position.</param>
    /// <param name="X1">Sets the selection's end x position.</param>
    /// <param name="Xref">Sets the selection's x coordinate axis. If set to a x axis id (e.g. "x" or "x2"), the `x` position refers to a x coordinate. If set to "paper", the `x` position refers to the distance from the left of the plotting area in normalized coordinates where "0" ("1") corresponds to the left (right). If set to a x axis ID followed by "domain" (separated by a space), the position behaves like for "paper", but refers to the distance in fractions of the domain length from the left of the domain of that axis: e.g., "x2 domain" refers to the domain of the second x axis and a x position of 0.5 refers to the point between the left and the right of the domain of the second x axis.</param>
    /// <param name="Y0">Sets the selection's starting y position.</param>
    /// <param name="Y1">Sets the selection's end y position.</param>
    /// <param name="Yref">Sets the selection's x coordinate axis. If set to a y axis id (e.g. "y" or "y2"), the `y` position refers to a y coordinate. If set to "paper", the `y` position refers to the distance from the bottom of the plotting area in normalized coordinates where "0" ("1") corresponds to the bottom (top). If set to a y axis ID followed by "domain" (separated by a space), the position behaves like for "paper", but refers to the distance in fractions of the domain length from the bottom of the domain of that axis: e.g., "y2 domain" refers to the domain of the second y axis and a y position of 0.5 refers to the point between the bottom and the top of the domain of the second y axis.</param>
    static member init
        (
            ?Line: Line,
            ?Name: string,
            ?Opacity: float,
            ?Path: string,
            ?TemplateItemName: string,
            ?SelectionType: StyleParam.SelectionType,
            ?X0: #IConvertible,
            ?X1: #IConvertible,
            ?Xref: string,
            ?Y0: #IConvertible,
            ?Y1: #IConvertible,
            ?Yref: string
        ) =
        Selection()
        |> Selection.style (
            ?Line = Line,
            ?Name = Name,
            ?Opacity = Opacity,
            ?Path = Path,
            ?TemplateItemName = TemplateItemName,
            ?SelectionType = SelectionType,
            ?X0 = X0,
            ?X1 = X1,
            ?Xref = Xref,
            ?Y0 = Y0,
            ?Y1 = Y1,
            ?Yref = Yref
        )

    /// <summary>
    /// Returns a function that applies the given styles to a Selection object
    /// </summary>
    /// <param name="Line">Sets the outline of the selection.</param>
    /// <param name="Name">When used in a template, named items are created in the output figure in addition to any items the figure already has in this array. You can modify these items in the output figure by making your own item with `templateitemname` matching this `name` alongside your modifications (including `visible: false` or `enabled: false` to hide it). Has no effect outside of a template.</param>
    /// <param name="Opacity">Sets the opacity of the selection.</param>
    /// <param name="Path">For `type` "path" - a valid SVG path similar to `shapes.path` in data coordinates. Allowed segments are: M, L and Z.</param>
    /// <param name="TemplateItemName">Used to refer to a named item in this array in the template. Named items from the template will be created even without a matching item in the input figure, but you can modify one by making an item with `templateitemname` matching its `name`, alongside your modifications (including `visible: false` or `enabled: false` to hide it). If there is no template or no matching item, this item will be hidden unless you explicitly show it with `visible: true`.</param>
    /// <param name="SelectionType">Specifies the selection type to be drawn. If "rect", a rectangle is drawn linking (`x0`,`y0`), (`x1`,`y0`), (`x1`,`y1`) and (`x0`,`y1`). If "path", draw a custom SVG path using `path`.</param>
    /// <param name="X0">Sets the selection's starting x position.</param>
    /// <param name="X1">Sets the selection's end x position.</param>
    /// <param name="Xref">Sets the selection's x coordinate axis. If set to a x axis id (e.g. "x" or "x2"), the `x` position refers to a x coordinate. If set to "paper", the `x` position refers to the distance from the left of the plotting area in normalized coordinates where "0" ("1") corresponds to the left (right). If set to a x axis ID followed by "domain" (separated by a space), the position behaves like for "paper", but refers to the distance in fractions of the domain length from the left of the domain of that axis: e.g., "x2 domain" refers to the domain of the second x axis and a x position of 0.5 refers to the point between the left and the right of the domain of the second x axis.</param>
    /// <param name="Y0">Sets the selection's starting y position.</param>
    /// <param name="Y1">Sets the selection's end y position.</param>
    /// <param name="Yref">Sets the selection's x coordinate axis. If set to a y axis id (e.g. "y" or "y2"), the `y` position refers to a y coordinate. If set to "paper", the `y` position refers to the distance from the bottom of the plotting area in normalized coordinates where "0" ("1") corresponds to the bottom (top). If set to a y axis ID followed by "domain" (separated by a space), the position behaves like for "paper", but refers to the distance in fractions of the domain length from the bottom of the domain of that axis: e.g., "y2 domain" refers to the domain of the second y axis and a y position of 0.5 refers to the point between the bottom and the top of the domain of the second y axis.</param>
    static member style
        (
            ?Line: Line,
            ?Name: string,
            ?Opacity: float,
            ?Path: string,
            ?TemplateItemName: string,
            ?SelectionType: StyleParam.SelectionType,
            ?X0: #IConvertible,
            ?X1: #IConvertible,
            ?Xref: string,
            ?Y0: #IConvertible,
            ?Y1: #IConvertible,
            ?Yref: string
        ) =
        (fun (selection: Selection) ->

            selection
            |> DynObj.withOptionalProperty "line" Line
            |> DynObj.withOptionalProperty "name" Name
            |> DynObj.withOptionalProperty "opacity" Opacity
            |> DynObj.withOptionalProperty "path" Path
            |> DynObj.withOptionalProperty "templateitemname" TemplateItemName
            |> DynObj.withOptionalPropertyBy "type" SelectionType StyleParam.SelectionType.convert
            |> DynObj.withOptionalProperty "x0" X0
            |> DynObj.withOptionalProperty "x1" X1
            |> DynObj.withOptionalProperty "xref" Xref
            |> DynObj.withOptionalProperty "y0" Y0
            |> DynObj.withOptionalProperty "y1" Y1
            |> DynObj.withOptionalProperty "yref" Yref
        )
