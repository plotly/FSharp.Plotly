﻿module Tests.Charts3D

open Expecto
open Plotly.NET
open TestUtils
open Plotly.NET.GenericChart
open System

let scatterChart =
    let x = [19; 26; 55;]
    let y = [19; 26; 55;]
    let z = [19; 26; 55;]

    Chart.Scatter3d(x,y,z,StyleParam.Mode.Markers)
    |> Chart.withXAxisStyle("my x-axis")
    |> Chart.withYAxisStyle("my y-axis")
    |> Chart.withZAxisStyle("my z-axis")
    |> Chart.withSize(800.,800.)

[<Tests>]
let ``3D Scatter charts`` =
    testList "Charts3D.3D Scatter charts" [
        testCase "3D Scatter charts data" ( fun () ->
            "var data = [{\"type\":\"scatter3d\",\"x\":[19,26,55],\"y\":[19,26,55],\"z\":[19,26,55],\"mode\":\"markers\",\"line\":{},\"marker\":{}}];"
            |> chartGeneratedContains scatterChart
        );
        testCase "3D Scatter charts layout" ( fun () ->
            "var layout = {\"scene\":{\"xaxis\":{\"title\":\"my x-axis\"},\"yaxis\":{\"title\":\"my y-axis\"},\"zaxis\":{\"title\":\"my z-axis\"}},\"width\":800.0,\"height\":800.0};"
            |> chartGeneratedContains scatterChart
        );
    ]

let lineChart =
    let c = [0. .. 0.5 .. 15.]
    
    let x, y, z =  
        c
        |> List.map (fun i ->
            let i' = float i 
            let r = 10. * Math.Cos (i' / 10.)
            (r * Math.Cos i', r * Math.Sin i', i')
        )
        |> List.unzip3

    Chart.Scatter3d(x, y, z, StyleParam.Mode.Lines_Markers)
    |> Chart.withXAxisStyle("x-axis")
    |> Chart.withYAxisStyle("y-axis")
    |> Chart.withZAxisStyle("z-axis")
    |> Chart.withSize(800., 800.)


[<Tests>]
let ``Line charts`` =
    testList "Charts3D.Line charts" [
        testCase "Line data" ( fun () ->
            [
                "var data = [{\"type\":\"scatter3d\",\"x\":[10.0,8.764858122060915,5.3760304484812105,0.699428991431538,"
                ",0.4599954209124893],\"z\":[0.0,0.5,1.0,1.5,2.0,2.5,3.0,3.5,4.0,4.5,5.0,5.5,6.0,6.5,7.0,7.5,8.0,8.5,9.0,9.5,10.0,10.5,11.0,11.5,12.0,12.5,13.0,13.5,14.0,14.5,15.0],\"mode\":\"lines+markers\",\"line\":{},\"marker\":{}}];"
            ]
            |> chartGeneratedContainsList lineChart
        );
        testCase "Line layout" ( fun () ->
            "var layout = {\"scene\":{\"xaxis\":{\"title\":\"x-axis\"},\"yaxis\":{\"title\":\"y-axis\"},\"zaxis\":{\"title\":\"z-axis\"}},\"width\":800.0,\"height\":800.0};"
            |> chartGeneratedContains lineChart
        );
    ]

let firstSurfaceChart =
    //---------------------- Generate linearly spaced vector ----------------------
    let linspace (min,max,n) = 
        if n <= 2 then failwithf "n needs to be larger then 2"
        let bw = float (max - min) / (float n - 1.)
        Array.init n (fun i -> min + (bw * float i))
    
    //---------------------- Create example data ----------------------
    let size = 100
    let x = linspace(-2. * Math.PI, 2. * Math.PI, size)
    let y = linspace(-2. * Math.PI, 2. * Math.PI, size)
    
    let f x y = - (5. * x / (x**2. + y**2. + 1.) )
    
    let z = 
        Array.init size (fun i -> 
            Array.init size (fun j -> f x.[j] y.[i] )
                        )
    
    z
    |> Chart.Surface


let secondSurfaceChart =
    let x' = [0.;2.5]
    let y' = [0.;2.5]
    let z' = [
        [1.;1.;]; // row wise (length x)
        [1.;2.;];
        ] // column (length y)
    
    Chart.Surface(z', x', y', Opacity=0.5, Contours=Contours.initXyz(Show=true))

[<Tests>]
let ``Surface charts`` =
    testList "Charts3D.Surface charts" [
        testCase "First surface data" ( fun () ->
            // the data generated by this chart generates a
            // line of code which is 200 Kb long, unreasonably
            // huge for a test.
            [
                "var data = [{\"type\":\"surface\",\"z\":[[0.3929110807586562,0.39272903726671055,0.3923748718856843,0.3918384347714509,0.39110921172503726,0.39017633288191317,0.38902858492457726"
                "-0.3755066766683234,-0.38085145315419006,-0.38575670319102695,-0.3902383753762268,-0.3943127362115111,-0.3979962450330162,-0.4013054412792835"
                "-0.3901763328819132,-0.39110921172503726,-0.39183843477145097,-0.3923748718856844,-0.39272903726671055,-0.3929110807586562]]}];"
            ]
            |> chartGeneratedContainsList firstSurfaceChart
        );
        testCase "First surface layout" ( fun () ->
            emptyLayout firstSurfaceChart
        );
        testCase "Second surface data" ( fun () ->
            "var data = [{\"type\":\"surface\",\"z\":[[1.0,1.0],[1.0,2.0]],\"x\":[0.0,2.5],\"y\":[0.0,2.5],\"contours\":{\"x\":{\"show\":true},\"y\":{\"show\":true},\"z\":{\"show\":true}},\"opacity\":0.5}];"
            |> chartGeneratedContains secondSurfaceChart
        );
        testCase "Second surface layout" ( fun () ->
            emptyLayout secondSurfaceChart
        );
    ]


let meshChart =
    let linspace (min,max,n) = 
        if n <= 2 then failwithf "n needs to be larger then 2"
        let bw = float (max - min) / (float n - 1.)
        Array.init n (fun i -> min + (bw * float i))
        //[|min ..bw ..max|]
    
    //---------------------- Create example data ----------------------
    let size = 100
    let x = linspace(-2. * Math.PI, 2. * Math.PI, size)
    let y = linspace(-2. * Math.PI, 2. * Math.PI, size)
    
    let f x y = - (5. * x / (x**2. + y**2. + 1.) )
    
    let z = 
        Array.init size (fun i -> 
            Array.init size (fun j -> 
                f x.[j] y.[i] 
            )
        )
    
    let rnd = System.Random(5)
    let a = Array.init 50 (fun _ -> rnd.NextDouble())
    let b = Array.init 50 (fun _ -> rnd.NextDouble())
    let c = Array.init 50 (fun _ -> rnd.NextDouble())
    
    Trace3d.initMesh3d 
        (fun mesh3d ->
            mesh3d?x <- a
            mesh3d?y <- b
            mesh3d?z <- c
            mesh3d?flatshading <- true
            mesh3d?contour <- Contours.initXyz(Show=true)
            mesh3d
            )
    |> GenericChart.ofTraceObject

[<Tests>]
let ``Mesh charts`` =
    testList "Charts3D.Mesh charts" [
        testCase "Mesh data" ( fun () ->
            "var data = [{\"type\":\"mesh3d\",\"x\":[0.33836984091362443,0.2844184475412678,0.2629626417825756,0.6253758443637638,0.46346185284827923,0.9283738280312968,0.1463105539541275,0.9505998873853124,0.5961332552116985,0.11745994590104555,0.975558924477342,0.37088692624628866,0.0699143670824889,0.07078822472635109,0.48201058175508427,0.15297147219673332,0.9641655045394625,0.09534371648698287,0.8125330809562156,0.2506162050415837,0.48126059979259067,0.07473527084790882,0.8369272271343168,0.7793545950107996,0.18997055114711195,0.7421991949631829,0.2328434778530353,0.7856600809775572,0.9278804142623583,0.10790790343094053,0.03301328235911824,0.770361295794305,0.30779169793603556,0.11389689665003536,0.388590590743623,0.9796536713743832,0.17214082375734152,0.7884985966554371,0.1994013894346549,0.7964705586416976,0.3436089406458703,0.10509170037931376,0.9796912223006092,0.8392714871276503,0.5432778380547081,0.1979652751227679,0.038267011306372944,0.5355382620056803,0.6352935864754456,0.8821615948724382],\"y\":[0.9909701128448221,0.9722291035448336,0.2536179266188377,0.5066026125599642,0.19606175189654423,0.2636345700657156,0.447491220406951,0.48360804677177593,0.4354052932166519,0.7212626578850964,0.6955303501782615,0.3606504729765702,0.022719473122954123,0.48822535178075793,0.08444666354192731,0.20519762868303695,0.06309522831025312,0.9560174704324536,0.682197633982728,0.5023569103807011,0.9808306484393918,0.17566690788402545,0.8959423270523279,0.016062522314518,0.9070072643957134,0.37616889941327686,0.0950440485472996,0.9976557400066665,0.2360767569560915,0.9920052760243441,0.70393218365681,0.6973052158473549,0.15036649450211156,0.04571881938992013,0.11693779058611849,0.060784178814284585,0.5167433691754674,0.8011890853760714,0.9178351447534912,0.1249560206779074,0.5321624509674322,0.6885327769855656,0.35309330343878514,0.47813873154955855,0.10094020846343608,0.9829584676693001,0.08237222725635963,0.4914658705198513,0.754824823585723,0.33808020937167116],\"z\":[0.1348700468125148,0.0822495408739194,0.8533406280229523,0.13293667609474466,0.9013309464330463,0.8153032049607966,0.07628677649250569,0.2375554043043197,0.5995953481642508,0.8198928524832674,0.16859052151841603,0.44983548040028454,0.24753128981568445,0.44340001719230787,0.017330474228286406,0.9982251343309065,0.21028397847445868,0.977000653733034,0.37128756119463946,0.023662484727642725,0.6884542595075696,0.2619061429341818,0.03818232567896243,0.5572416133048207,0.9701944594132688,0.29229787145382624,0.8225736044452403,0.4178035955027694,0.9151223138510819,0.9240487967264135,0.29379667215691724,0.6035781780274483,0.24283091642094354,0.8979965475844204,0.8571352292118293,0.6216826427828905,0.8439645878244026,0.0174298184073669,0.1443878729568738,0.30163458562532186,0.9844974023217788,0.2791879648711476,0.20159373721182056,0.09794229227022375,0.9563654991594914,0.0823269705671477,0.44100148716988113,0.9096932862464773,0.4608082573212722,0.10271507413252959],\"flatshading\":true,\"contour\":{\"x\":{\"show\":true},\"y\":{\"show\":true},\"z\":{\"show\":true}}}];"
            |> chartGeneratedContains meshChart
        );
        testCase "Mesh layout" ( fun () ->
            emptyLayout meshChart
        );
    ]