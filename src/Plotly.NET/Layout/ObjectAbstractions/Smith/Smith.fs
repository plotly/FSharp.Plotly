namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

/// The smith subplot is used by TraceSmith traces.
type Smith() =
    inherit DynamicObj()

    /// <summary>
    /// Initialize a Smith object that contains layout options concerned with smith plots.
    /// </summary>
    /// <param name="BGColor">Set the background color of the subplot</param>
    /// <param name="Domain">Sets the domain of this smith subplot</param>
    /// <param name="ImaginaryAxis">Sets the imaginary axis of this smith subplot</param>
    /// <param name="RealAxis">Sets the real axis of this smith subplot</param>
    static member init
        (
            ?BGColor: Color,
            ?Domain: Domain,
            ?ImaginaryAxis: ImaginaryAxis,
            ?RealAxis: RealAxis
        ) =
        Smith()
        |> Smith.style (
            ?BGColor = BGColor,
            ?Domain = Domain,
            ?ImaginaryAxis = ImaginaryAxis,
            ?RealAxis = RealAxis

        )

    /// <summary>
    /// Create a function that applies the given style parameters to a Smith object
    /// </summary>
    /// <param name="BGColor">Set the background color of the subplot</param>
    /// <param name="Domain">Sets the domain of this smith subplot</param>
    /// <param name="ImaginaryAxis">Sets the imaginary axis of this smith subplot</param>
    /// <param name="RealAxis">Sets the real axis of this smith subplot</param>
    static member style
        (
            ?BGColor: Color,
            ?Domain: Domain,
            ?ImaginaryAxis: ImaginaryAxis,
            ?RealAxis: RealAxis
        ) =
        fun (smith: Smith) ->
            smith
            |> DynObj.withOptionalProperty "bgcolor"       BGColor         
            |> DynObj.withOptionalProperty "domain"        Domain          
            |> DynObj.withOptionalProperty "imaginaryaxis" ImaginaryAxis   
            |> DynObj.withOptionalProperty "realaxis"      RealAxis        

    /// <summary>
    /// Returns Some(dynamic member value) of the object's underlying DynamicObj when a dynamic member with the given name exists, and None otherwise.
    /// </summary>
    /// <param name="propName">The name of the dynamic member to get the value of</param>
    /// <param name="smith">The object to get the dynamic member value from</param>
    static member tryGetTypedMember<'T> (propName: string) (smith: Smith) = smith.TryGetTypedPropertyValue<'T>(propName)

    /// <summary>
    /// Returns the ImaginaryAxis object of the given smith object.
    ///
    /// If there is no ImaginaryAxis set, returns an empty ImaginaryAxis object.
    /// </summary>
    /// <param name="smith">The smith object to get the ImaginaryAxis from</param>
    static member getImaginaryAxis(smith: Smith) =
        smith |> Smith.tryGetTypedMember<ImaginaryAxis> "imaginaryaxis" |> Option.defaultValue (ImaginaryAxis.init ())

    /// <summary>
    /// Returns a function that sets the ImaginaryAxis object of the given smith object.
    /// </summary>
    /// <param name="imaginaryAxis">The new ImaginaryAxis object</param>
    static member setImaginaryAxis(imaginaryAxis: ImaginaryAxis) =
        (fun (smith: Smith) ->
            smith.SetProperty("imaginaryaxis", imaginaryAxis)
            smith)

    /// <summary>
    /// Returns the RealAxis object of the given smith object.
    ///
    /// If there is no RealAxis set, returns an empty RealAxis object.
    /// </summary>
    /// <param name="smith">The smith object to get the RealAxis from</param>
    static member getRealAxis(smith: Smith) =
        smith |> Smith.tryGetTypedMember<RealAxis> "realaxis" |> Option.defaultValue (RealAxis.init ())

    /// <summary>
    /// Returns a function that sets the RealAxis object of the given smith object.
    /// </summary>
    /// <param name="realAxis">The new RealAxis object</param>
    static member setRealAxis(realAxis: RealAxis) =
        (fun (smith: Smith) ->
            smith.SetProperty("realaxis", realAxis)
            smith)
