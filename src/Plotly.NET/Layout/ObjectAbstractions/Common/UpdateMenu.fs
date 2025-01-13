namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

type UpdateMenuButton() =
    inherit DynamicObj()

    static member init
        (
            ?Args: seq<DynamicObj>,
            ?Args2: seq<DynamicObj>,
            ?Execute: bool,
            ?Label: string,
            ?Method: StyleParam.UpdateMethod,
            ?Name: string,
            ?TemplateItemName: string,
            ?Visible: bool
        ) =
        UpdateMenuButton()
        |> UpdateMenuButton.style (
            ?Args = Args,
            ?Args2 = Args2,
            ?Execute = Execute,
            ?Label = Label,
            ?Method = Method,
            ?Name = Name,
            ?TemplateItemName = TemplateItemName,
            ?Visible = Visible

        )

    static member style
        (
            ?Args: seq<DynamicObj>,
            ?Args2: seq<DynamicObj>,
            ?Execute: bool,
            ?Label: string,
            ?Method: StyleParam.UpdateMethod,
            ?Name: string,
            ?TemplateItemName: string,
            ?Visible: bool
        ) =
        (fun (updateMenuButton: UpdateMenuButton) ->

            updateMenuButton
            |> DynObj.withOptionalProperty "args" Args
            |> DynObj.withOptionalProperty "args2" Args2
            |> DynObj.withOptionalProperty "execute" Execute
            |> DynObj.withOptionalProperty "label" Label
            |> DynObj.withOptionalPropertyBy "method" Method StyleParam.UpdateMethod.convert
            |> DynObj.withOptionalProperty "name" Name
            |> DynObj.withOptionalProperty "templateitemname" TemplateItemName
            |> DynObj.withOptionalProperty "visible" Visible
        )

type UpdateMenu() =
    inherit DynamicObj()

    static member init
        (
            ?Active: int,
            ?BGColor: Color,
            ?BorderColor: Color,
            ?Buttons: seq<UpdateMenuButton>,
            ?Direction: StyleParam.UpdateMenuDirection,
            ?Font: Font,
            ?Name: string,
            ?Pad: Padding,
            ?ShowActive: bool,
            ?TemplateItemName: string,
            ?Type: StyleParam.UpdateMenuType,
            ?Visible: bool,
            ?X: float,
            ?XAnchor: StyleParam.XAnchorPosition,
            ?Y: float,
            ?YAnchor: StyleParam.YAnchorPosition
        ) =
        UpdateMenu()
        |> UpdateMenu.style (
            ?Active = Active,
            ?BGColor = BGColor,
            ?BorderColor = BorderColor,
            ?Buttons = Buttons,
            ?Direction = Direction,
            ?Font = Font,
            ?Name = Name,
            ?Pad = Pad,
            ?ShowActive = ShowActive,
            ?TemplateItemName = TemplateItemName,
            ?Type = Type,
            ?Visible = Visible,
            ?X = X,
            ?XAnchor = XAnchor,
            ?Y = Y,
            ?YAnchor = YAnchor

        )

    static member style
        (
            ?Active: int,
            ?BGColor: Color,
            ?BorderColor: Color,
            ?Buttons: seq<UpdateMenuButton>,
            ?Direction: StyleParam.UpdateMenuDirection,
            ?Font: Font,
            ?Name: string,
            ?Pad: Padding,
            ?ShowActive: bool,
            ?TemplateItemName: string,
            ?Type: StyleParam.UpdateMenuType,
            ?Visible: bool,
            ?X: float,
            ?XAnchor: StyleParam.XAnchorPosition,
            ?Y: float,
            ?YAnchor: StyleParam.YAnchorPosition
        ) =
        (fun (updateMenu: UpdateMenu) ->

            updateMenu
            |> DynObj.withOptionalProperty "active" Active
            |> DynObj.withOptionalProperty "bgcolor" BGColor
            |> DynObj.withOptionalProperty "bordercolor" BorderColor
            |> DynObj.withOptionalProperty "buttons" Buttons
            |> DynObj.withOptionalPropertyBy "direction" Direction StyleParam.UpdateMenuDirection.convert
            |> DynObj.withOptionalProperty "font" Font
            |> DynObj.withOptionalProperty "name" Name
            |> DynObj.withOptionalProperty "pad" Pad
            |> DynObj.withOptionalProperty "showactive" ShowActive
            |> DynObj.withOptionalProperty "templateitemname" TemplateItemName
            |> DynObj.withOptionalPropertyBy "type" Type StyleParam.UpdateMenuType.convert
            |> DynObj.withOptionalProperty "visible" Visible
            |> DynObj.withOptionalProperty "x" X
            |> DynObj.withOptionalPropertyBy "xanchor" XAnchor StyleParam.XAnchorPosition.convert
            |> DynObj.withOptionalProperty "y" Y
            |> DynObj.withOptionalPropertyBy "yanchor" YAnchor StyleParam.YAnchorPosition.convert
        )
