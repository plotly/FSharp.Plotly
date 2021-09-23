module Tests.SimpleCharts

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Plotly.NET.GenericChart
open Plotly.NET.StyleParam

open TestUtils.HtmlCodegen

let withLineStyleChart =
    let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    Chart.Line(
        x,y,
        Name="line",
        ShowMarkers=true,
        MarkerSymbol=StyleParam.MarkerSymbol.Square)    
    |> Chart.withLineStyle(Width=2.,Dash=StyleParam.DrawingStyle.Dot)


let chartLineChart =
    [ for x in 1.0 .. 100.0 -> (x, x ** 2.0) ]
    |> Chart.Line

let splineChart =
    let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    Chart.Spline(x, y, Name="spline")   

let textLabelChart =
    let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    let labels  = ["a";"b";"c";"d";"e";"f";"g";"h";"i";"j";]
    Chart.Point(
        x,y,
        Name="points",
        Labels=labels,
        TextPosition=StyleParam.TextPosition.TopRight
    )


[<Tests>]
let ``Line and scatter plots`` =
    testList "SimpleCharts.Line and scatter plots" [
        testCase "With LineStyle data" ( fun () ->
            """var data = [{"type":"scatter","mode":"lines+markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"line":{"width":2.0,"dash":"dot"},"name":"line","marker":{"symbol":"1"}}];"""
            |> chartGeneratedContains withLineStyleChart
        );
        testCase "With LineStyle layout" ( fun () ->
            emptyLayout withLineStyleChart
        );
        testCase "Chart line data" ( fun () ->
            """var data = [{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0,11.0,12.0,13.0,14.0,15.0,16.0,17.0,18.0,19.0,20.0,21.0,22.0,23.0,24.0,25.0,26.0,27.0,28.0,29.0,30.0,31.0,32.0,33.0,34.0,35.0,36.0,37.0,38.0,39.0,40.0,41.0,42.0,43.0,44.0,45.0,46.0,47.0,48.0,49.0,50.0,51.0,52.0,53.0,54.0,55.0,56.0,57.0,58.0,59.0,60.0,61.0,62.0,63.0,64.0,65.0,66.0,67.0,68.0,69.0,70.0,71.0,72.0,73.0,74.0,75.0,76.0,77.0,78.0,79.0,80.0,81.0,82.0,83.0,84.0,85.0,86.0,87.0,88.0,89.0,90.0,91.0,92.0,93.0,94.0,95.0,96.0,97.0,98.0,99.0,100.0],"y":[1.0,4.0,9.0,16.0,25.0,36.0,49.0,64.0,81.0,100.0,121.0,144.0,169.0,196.0,225.0,256.0,289.0,324.0,361.0,400.0,441.0,484.0,529.0,576.0,625.0,676.0,729.0,784.0,841.0,900.0,961.0,1024.0,1089.0,1156.0,1225.0,1296.0,1369.0,1444.0,1521.0,1600.0,1681.0,1764.0,1849.0,1936.0,2025.0,2116.0,2209.0,2304.0,2401.0,2500.0,2601.0,2704.0,2809.0,2916.0,3025.0,3136.0,3249.0,3364.0,3481.0,3600.0,3721.0,3844.0,3969.0,4096.0,4225.0,4356.0,4489.0,4624.0,4761.0,4900.0,5041.0,5184.0,5329.0,5476.0,5625.0,5776.0,5929.0,6084.0,6241.0,6400.0,6561.0,6724.0,6889.0,7056.0,7225.0,7396.0,7569.0,7744.0,7921.0,8100.0,8281.0,8464.0,8649.0,8836.0,9025.0,9216.0,9409.0,9604.0,9801.0,10000.0],"line":{},"marker":{}}];"""
            |> chartGeneratedContains chartLineChart
        );
        testCase "Chart line layout" ( fun () ->
            emptyLayout chartLineChart
        );
        testCase "Spline chart data" ( fun () ->
            """var data = [{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"spline","line":{"shape":"spline"},"marker":{}}];"""
            |> chartGeneratedContains splineChart
        );
        testCase "Spline chart layout" ( fun () ->
            emptyLayout splineChart
        );
        testCase "Text label data" ( fun () ->
            """var data = [{"type":"scatter","mode":"markers+text","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"name":"points","marker":{},"text":["a","b","c","d","e","f","g","h","i","j"],"textposition":"top right"}];"""
            |> chartGeneratedContains textLabelChart
        );
        testCase "Text label layout" ( fun () ->
            emptyLayout textLabelChart
        );
    ]


let columnChart =
    let values = [20; 14; 23;]
    let keys   = ["Product A"; "Product B"; "Product C";]
    Chart.Column(values, keys)

let barChart =
    let values = [20; 14; 23;]
    let keys   = ["Product A"; "Product B"; "Product C";]
    Chart.Bar(values, keys)

let stackedBarChart =
    let values = [20; 14; 23;]
    let keys   = ["Product A"; "Product B"; "Product C";]
    [
        Chart.StackedBar(values, keys, Name="old");
        Chart.StackedBar([8; 21; 13;], keys, Name="new")
    ]
    |> Chart.combine

let stackedColumnChart =
    let values = [20; 14; 23;]
    let keys   = ["Product A"; "Product B"; "Product C";]
    [
        Chart.StackedColumn(values,keys,Name="old");
        Chart.StackedColumn([8; 21; 13;],keys,Name="new")
    ]
    |> Chart.combine

[<Tests>]
let ``Bar and column charts`` =
    testList "SimpleCharts.Bar and column charts" [
        testCase "Column chart data" ( fun () ->
            """var data = [{"type":"bar","x":["Product A","Product B","Product C"],"y":[20,14,23],"orientation":"v","marker":{"pattern":{}}}];"""
            |> chartGeneratedContains columnChart
        );
        testCase "Column chart layout" ( fun () ->
            emptyLayout columnChart
        );
        testCase "Bar chart data" ( fun () ->
            """var data = [{"type":"bar","x":[20,14,23],"y":["Product A","Product B","Product C"],"orientation":"h","marker":{"pattern":{}}}];"""
            |> chartGeneratedContains barChart
        );
        testCase "Bar chart layout" ( fun () ->
            emptyLayout barChart
        );
        testCase "Stacked bar data" ( fun () ->
            """var data = [{"type":"bar","name":"old","x":[20,14,23],"y":["Product A","Product B","Product C"],"orientation":"h","marker":{"pattern":{}}},{"type":"bar","name":"new","x":[8,21,13],"y":["Product A","Product B","Product C"],"orientation":"h","marker":{"pattern":{}}}];"""
            |> chartGeneratedContains stackedBarChart
        );
        testCase "Stacked bar layout" ( fun () ->
            "var layout = {\"barmode\":\"stack\"};"
            |> chartGeneratedContains stackedColumnChart
        );
        testCase "Stacked column data" ( fun () ->
            """var data = [{"type":"bar","name":"old","x":["Product A","Product B","Product C"],"y":[20,14,23],"orientation":"v","marker":{"pattern":{}}},{"type":"bar","name":"new","x":["Product A","Product B","Product C"],"y":[8,21,13],"orientation":"v","marker":{"pattern":{}}}];"""
            |> chartGeneratedContains stackedColumnChart
        );
        testCase "Stacked column layout" ( fun () ->
            "var layout = {\"barmode\":\"stack\"};"
            |> chartGeneratedContains stackedColumnChart
        );
    ]


let simpleAreaChart =
    let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y  = [5.; 2.5; 5.; 7.5; 5.; 2.5; 7.5; 4.5; 5.5; 5.]
    Chart.Area(x,y)

let withSplineChart =
    let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y  = [5.; 2.5; 5.; 7.5; 5.; 2.5; 7.5; 4.5; 5.5; 5.]
    Chart.SplineArea(x,y)

let stackedAreaChart =
    let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y  = [5.; 2.5; 5.; 7.5; 5.; 2.5; 7.5; 4.5; 5.5; 5.]
    [
        Chart.StackedArea(x,y)
        Chart.StackedArea(x,y |> Seq.rev)
    ]
    |> Chart.combine

[<Tests>]
let ``Area charts`` =
    testList "SimpleCharts.Area charts" [
        testCase "Simple area data" ( fun () ->
            """var data = [{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[5.0,2.5,5.0,7.5,5.0,2.5,7.5,4.5,5.5,5.0],"fill":"tozeroy","line":{},"marker":{}}];"""
            |> chartGeneratedContains simpleAreaChart
        );
        testCase "Simple area layout" ( fun () ->
            emptyLayout simpleAreaChart
        );
        testCase "Spline data" ( fun () ->
            """var data = [{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[5.0,2.5,5.0,7.5,5.0,2.5,7.5,4.5,5.5,5.0],"fill":"tozeroy","line":{"shape":"spline"},"marker":{}}];"""
            |> chartGeneratedContains withSplineChart
        );
        testCase "Spline layout" ( fun () ->
            emptyLayout withSplineChart
        );
        testCase "Stacked area data" ( fun () ->
            """var data = [{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[5.0,2.5,5.0,7.5,5.0,2.5,7.5,4.5,5.5,5.0],"line":{},"marker":{},"stackgroup":"static"},{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[5.0,5.5,4.5,7.5,2.5,5.0,7.5,5.0,2.5,5.0],"line":{},"marker":{},"stackgroup":"static"}];"""
            |> chartGeneratedContains stackedAreaChart
        );
        testCase "Stacked area layout" ( fun () ->
            emptyLayout stackedAreaChart
        );
    ]


let rangePlotsChart =
    let rnd = System.Random(5)
    
    let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
    let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]
    
    let yUpper = y |> List.map (fun v -> v + rnd.NextDouble())
    let yLower = y |> List.map (fun v -> v - rnd.NextDouble())
    Chart.Range(
        x,y,yUpper,yLower,
        StyleParam.Mode.Lines_Markers,
        Color=Color.fromString "grey",
        RangeColor=Color.fromString "lightblue")

[<Tests>]
let ``Range plot`` =
    testList "SimpleCharts.Range plot" [
        testCase "Range plot data" ( fun () ->
            """var data = [{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[1.0244410755226578,1.1291130737537114,4.930085632917511,1.4292117752736488,2.5179894182449156,2.3470285278032668,1.5358344954605374,1.4046562835130172,2.6874669190437843,0.7493837949584163],"fillcolor":"lightblue","name":"lower","showlegend":false,"line":{"width":0.0},"marker":{"color":"lightblue"}},{"type":"scatter","mode":"lines","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.338369840913624,1.7844184475412679,5.2629626417825754,2.125375844363764,3.4634618528482792,3.4283738280312965,2.6463105539541276,2.4505998873853123,4.096133255211699,1.1174599459010455],"fill":"tonexty","fillcolor":"lightblue","name":"upper","showlegend":false,"line":{"width":0.0},"marker":{"color":"lightblue"}},{"type":"scatter","mode":"lines+markers","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[2.0,1.5,5.0,1.5,3.0,2.5,2.5,1.5,3.5,1.0],"fillcolor":"grey","line":{"color":"grey"},"marker":{"color":"grey"}}];"""
            |> chartGeneratedContains rangePlotsChart
        );
        testCase "Range plot layout" ( fun () ->
            emptyLayout rangePlotsChart
        );
    ]

let bubbleCharts =
    let x = [2; 4; 6;]
    let y = [4; 1; 6;]
    let size = [19; 26; 55;]
    Chart.Bubble(x, y, size)

[<Tests>]
let ``Bubble charts`` =
    testList "SimpleCharts.Bubble charts" [
        testCase "Bubble data" ( fun () ->
            """var data = [{"type":"scatter","mode":"markers","x":[2,4,6],"y":[4,1,6],"marker":{"size":[19,26,55]}}];"""
            |> chartGeneratedContains bubbleCharts
        );
        testCase "Bubble layout" ( fun () ->
            emptyLayout bubbleCharts
        );
    ]

let pieChart =
    let values = [19; 26; 55;]
    let labels = ["Residential"; "Non-Residential"; "Utility"]
    Chart.Pie(values, labels)

let doughnutChart =
    let values = [19; 26; 55;]
    let labels = ["Residential"; "Non-Residential"; "Utility"]
    Chart.Doughnut(
        values,
        labels,
        Hole=0.3,
        TextLabels=labels
    )

let sunburstChart =
    let values = [19; 26; 55;]
    let labels = ["Residential"; "Non-Residential"; "Utility"]
    Chart.Sunburst(
        ["A";"B";"C";"D";"E"],
        ["";"";"B";"B";""],
        Values=[5.;0.;3.;2.;3.],
        Text=["At";"Bt";"Ct";"Dt";"Et"]
    )

[<Tests>]
let ``Pie and doughnut Charts`` =
    testList "SimpleCharts.Pie and doughnut Charts" [
        testCase "Pie data" ( fun () ->
            "var data = [{\"type\":\"pie\",\"values\":[19,26,55],\"labels\":[\"Residential\",\"Non-Residential\",\"Utility\"],\"marker\":{},\"text\":[\"Residential\",\"Non-Residential\",\"Utility\"]}];"
            |> chartGeneratedContains pieChart
        );
        testCase "Pie layout" ( fun () ->
            emptyLayout pieChart
        );
        testCase "Doughnut data" ( fun () ->
            """var data = [{"type":"pie","values":[19,26,55],"labels":["Residential","Non-Residential","Utility"],"text":["Residential","Non-Residential","Utility"],"hole":0.3,"marker":{}}];"""
            |> chartGeneratedContains doughnutChart
        );
        testCase "Doughnut layout" ( fun () ->
            emptyLayout doughnutChart
        );
        testCase "Sunburst data" ( fun () ->
            "var data = [{\"type\":\"sunburst\",\"labels\":[\"A\",\"B\",\"C\",\"D\",\"E\"],\"parents\":[\"\",\"\",\"B\",\"B\",\"\"],\"values\":[5.0,0.0,3.0,2.0,3.0],\"text\":[\"At\",\"Bt\",\"Ct\",\"Dt\",\"Et\"],\"marker\":{}}];"
            |> chartGeneratedContains sunburstChart
        );
        testCase "Sunburst layout" ( fun () ->
            emptyLayout sunburstChart
        );
    ]


let table1Chart =
    let header = ["<b>RowIndex</b>";"A";"simple";"table"]
    let rows = 
        [
         ["0";"I"     ;"am"     ;"a"]        
         ["1";"little";"example";"!"]       
        ]
    Chart.Table(header, rows)

let tableStyledChart =
    let header = ["<b>RowIndex</b>";"A";"simple";"table"]
    let rows = 
          [
           ["0";"I"     ;"am"     ;"a"]        
           ["1";"little";"example";"!"]       
          ]
    Chart.Table(
        header,
        rows,
        AlignHeader = [HorizontalAlign.Center],
        AlignCells  = [HorizontalAlign.Left; HorizontalAlign.Center; HorizontalAlign.Right],
        ColorHeader = Color.fromString "#45546a",    
        ColorCells  = Color.fromColors [Color.fromString "#deebf7"; Color.fromString "lightgrey"; Color.fromString "#deebf7"; Color.fromString "lightgrey"],
        FontHeader  = Font.init(FontFamily.Courier_New, Size=12., Color=Color.fromString "white"),      
        HeightHeader= 30.,
        LineHeader  = Line.init(2.,Color.fromString "black"),                     
        ColumnWidth = [70; 50; 100; 70],      
        ColumnOrder = [1; 2; 3; 4]                                  
    )

let tableColorDependentChart =
    let header2 = ["Identifier";"T0";"T1";"T2";"T3"]
    let rowvalues = 
        [
         [10001.;0.2;2.0;4.0;5.0]
         [10002.;2.1;2.0;1.8;2.1]
         [10003.;4.5;3.0;2.0;2.5]
         [10004.;0.0;0.1;0.3;0.2]
         [10005.;1.0;1.6;1.8;2.2]
         [10006.;1.0;0.8;1.5;0.7]
         [10007.;2.0;2.0;2.1;1.9]
        ]
        |> Seq.sortBy (fun x -> x.[1])
    
    //map color from value to hex representation
    let mapColor min max value = 
        let proportion = 
            (255. * (value - min) / (max - min))
            |> int
        Color.fromRGB 255 (255 - proportion) proportion
        
    //Assign a color to every cell seperately. Matrix must be transposed for correct orientation.
    let cellcolor = 
         rowvalues
         |> Seq.map (fun row ->
            row 
            |> Seq.mapi (fun index value -> 
                if index = 0 then Color.fromString "white"
                else mapColor 0. 5. value
                )
            )
        |> Seq.transpose
        |> Seq.map Color.fromColors
        |> Color.fromColors

    Chart.Table(header2,rowvalues,ColorCells=cellcolor)

let sequencePresentationTableChart =
    let sequence =
        [
        "ATGAGACGTCGAGACTGATAGACGTCGATAGACGTCGATAGACCG"
        "ATAGACTCGTGATAGACGTCGATAGACGTCGATAGAGTATAGACC"
        "GTGATAGACGTCGAGAAGACGTCGATAGACGTCGATAGACGTCGA"
        "TAGAGATAGACGTCGATAGACCGTATAGAAGACGTCGATAGATAG"
        "ACGTCGATAGACCGTAGACGTCGATAGACGTCGATAGACCGT"
        ]
        |> String.concat ""

    let elementsPerRow = 60

    let headers = 
        [0..elementsPerRow] 
        |> Seq.map (fun x -> 
            if x%10=0 && x <> 0 then "|" 
            else ""
            )

    let cells = 
        sequence
        |> Seq.chunkBySize elementsPerRow
        |> Seq.mapi (fun i x -> Seq.append [string (i * elementsPerRow)] (Seq.map string x))

    let cellcolors =
        cells
        |> Seq.map (fun row -> 
            row 
            |> Seq.map (fun element -> 
                match element with
                //colors taken from DRuMS 
                //(http://biomodel.uah.es/en/model4/dna/atgc.htm)
                | "A" -> Color.fromString "#5050FF" 
                | "T" -> Color.fromString "#E6E600"
                | "G" -> Color.fromString "#00C000"
                | "C" -> Color.fromString "#E00000"
                | "U" -> Color.fromString "#B48100"
                | _   -> Color.fromString "white"
                )
            )
        |> Seq.transpose
        |> Seq.map (fun x -> Seq.append x (seq [Color.fromString "white"]))
        |> Seq.map Color.fromColors
        |> Color.fromColors

    let font = Font.init(FontFamily.Consolas,Size=14.)
    let line = Line.init(0., Color.fromString "white")
    let chartwidth = 50 + 10 * elementsPerRow

    Chart.Table(
        headers,
        cells,
        LineCells   = line,
        LineHeader  = line,
        HeightCells = 20.,
        FontHeader  = font,
        FontCells   = font,
        ColumnWidth = [50;10],
        AlignCells  = [HorizontalAlign.Right;HorizontalAlign.Center],
        ColorCells  = cellcolors
        )
    |> Chart.withSize(Width=chartwidth)
    |> Chart.withTitle "Sequence A"


[<Tests>]
let ``Table charts`` =
    testList "SimpleCharts.Table charts" [
        testCase "First table data" ( fun () ->
            "var data = [{\"type\":\"table\",\"header\":{\"values\":[\"<b>RowIndex</b>\",\"A\",\"simple\",\"table\"]},\"cells\":{\"values\":[[\"0\",\"1\"],[\"I\",\"little\"],[\"am\",\"example\"],[\"a\",\"!\"]]}}];"
            |> chartGeneratedContains table1Chart
        );
        testCase "First table layout" ( fun () ->
            emptyLayout table1Chart
        );
        testCase "Styled table data" ( fun () ->
            "var data = [{\"type\":\"table\",\"header\":{\"values\":[\"<b>RowIndex</b>\",\"A\",\"simple\",\"table\"],\"align\":[\"center\"],\"height\":30.0,\"fill\":{\"color\":\"#45546a\"},\"line\":{\"color\":\"black\",\"width\":2.0},\"font\":{\"family\":\"Courier New\",\"size\":12.0,\"color\":\"white\"}},\"cells\":{\"values\":[[\"0\",\"1\"],[\"I\",\"little\"],[\"am\",\"example\"],[\"a\",\"!\"]],\"align\":[\"left\",\"center\",\"right\"],\"fill\":{\"color\":[\"#deebf7\",\"lightgrey\",\"#deebf7\",\"lightgrey\"]}},\"columnwidth\":[70,50,100,70],\"columnorder\":[1,2,3,4]}];"
            |> chartGeneratedContains tableStyledChart
        );
        testCase "Styled table layout" ( fun () ->
            emptyLayout tableStyledChart
        );
        testCase "Color dependent chart data" ( fun () ->
            """var data = [{"type":"table","header":{"values":["Identifier","T0","T1","T2","T3"]},"cells":{"values":[[10004.0,10001.0,10005.0,10006.0,10007.0,10002.0,10003.0],[0.0,0.2,1.0,1.0,2.0,2.1,4.5],[0.1,2.0,1.6,0.8,2.0,2.0,3.0],[0.3,4.0,1.8,1.5,2.1,1.8,2.0],[0.2,5.0,2.2,0.7,1.9,2.1,2.5]],"fill":{"color":[["white","white","white","white","white","white","white"],["rgba(255, 255, 0, 1.0)","rgba(255, 245, 10, 1.0)","rgba(255, 204, 51, 1.0)","rgba(255, 204, 51, 1.0)","rgba(255, 153, 102, 1.0)","rgba(255, 148, 107, 1.0)","rgba(255, 26, 229, 1.0)"],["rgba(255, 250, 5, 1.0)","rgba(255, 153, 102, 1.0)","rgba(255, 174, 81, 1.0)","rgba(255, 215, 40, 1.0)","rgba(255, 153, 102, 1.0)","rgba(255, 153, 102, 1.0)","rgba(255, 102, 153, 1.0)"],["rgba(255, 240, 15, 1.0)","rgba(255, 51, 204, 1.0)","rgba(255, 164, 91, 1.0)","rgba(255, 179, 76, 1.0)","rgba(255, 148, 107, 1.0)","rgba(255, 164, 91, 1.0)","rgba(255, 153, 102, 1.0)"],["rgba(255, 245, 10, 1.0)","rgba(255, 0, 255, 1.0)","rgba(255, 143, 112, 1.0)","rgba(255, 220, 35, 1.0)","rgba(255, 159, 96, 1.0)","rgba(255, 148, 107, 1.0)","rgba(255, 128, 127, 1.0)"]]}}}];"""
            |> chartGeneratedContains tableColorDependentChart
        );
        testCase "Color dependent chart layout" ( fun () ->
            emptyLayout tableColorDependentChart
        );
        testCase "Sequence presentation table data" ( fun () ->
            "var data = [{\"type\":\"table\",\"header\":{\"values\":[\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"|\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"|\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"|\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"|\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"|\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"|\"],\"line\":{\"color\":\"white\",\"width\":0.0},\"font\":{\"family\":\"Consolas\",\"size\":14.0}},\"cells\":{\"values\":[[\"0\",\"60\",\"120\",\"180\"],[\"A\",\"A\",\"G\",\"A\"],[\"T\",\"C\",\"T\",\"C\"],[\"G\",\"G\",\"C\",\"G\"],[\"A\",\"T\",\"G\",\"T\"],[\"G\",\"C\",\"A\",\"C\"],[\"A\",\"G\",\"T\",\"G\"],[\"C\",\"A\",\"A\",\"A\"],[\"G\",\"T\",\"G\",\"T\"],[\"T\",\"A\",\"A\",\"A\"],[\"C\",\"G\",\"C\",\"G\"],[\"G\",\"A\",\"G\",\"A\"],[\"A\",\"C\",\"T\",\"C\"],[\"G\",\"G\",\"C\",\"C\"],[\"A\",\"T\",\"G\",\"G\"],[\"C\",\"C\",\"A\",\"T\"],[\"T\",\"G\",\"T\",\"A\"],[\"G\",\"A\",\"A\",\"G\"],[\"A\",\"T\",\"G\",\"A\"],[\"T\",\"A\",\"A\",\"C\"],[\"A\",\"G\",\"G\",\"G\"],[\"G\",\"A\",\"A\",\"T\"],[\"A\",\"G\",\"T\",\"C\"],[\"C\",\"T\",\"A\",\"G\"],[\"G\",\"A\",\"G\",\"A\"],[\"T\",\"T\",\"A\",\"T\"],[\"C\",\"A\",\"C\",\"A\"],[\"G\",\"G\",\"G\",\"G\"],[\"A\",\"A\",\"T\",\"A\"],[\"T\",\"C\",\"C\",\"C\"],[\"A\",\"C\",\"G\",\"G\"],[\"G\",\"G\",\"A\",\"T\"],[\"A\",\"T\",\"T\",\"C\"],[\"C\",\"G\",\"A\",\"G\"],[\"G\",\"A\",\"G\",\"A\"],[\"T\",\"T\",\"A\",\"T\"],[\"C\",\"A\",\"C\",\"A\"],[\"G\",\"G\",\"C\",\"G\"],[\"A\",\"A\",\"G\",\"A\"],[\"T\",\"C\",\"T\",\"C\"],[\"A\",\"G\",\"A\",\"C\"],[\"G\",\"T\",\"T\",\"G\"],[\"A\",\"C\",\"A\",\"T\"],[\"C\",\"G\",\"G\"],[\"C\",\"A\",\"A\"],[\"G\",\"G\",\"A\"],[\"A\",\"A\",\"G\"],[\"T\",\"A\",\"A\"],[\"A\",\"G\",\"C\"],[\"G\",\"A\",\"G\"],[\"A\",\"C\",\"T\"],[\"C\",\"G\",\"C\"],[\"T\",\"T\",\"G\"],[\"C\",\"C\",\"A\"],[\"G\",\"G\",\"T\"],[\"T\",\"A\",\"A\"],[\"G\",\"T\",\"G\"],[\"A\",\"A\",\"A\"],[\"T\",\"G\",\"T\"],[\"A\",\"A\",\"A\"],[\"G\",\"C\",\"G\"]],\"align\":[\"right\",\"center\"],\"height\":20.0,\"fill\":{\"color\":[[\"white\",\"white\",\"white\",\"white\",\"white\"],[\"#5050FF\",\"#5050FF\",\"#00C000\",\"#5050FF\",\"white\"],[\"#E6E600\",\"#E00000\",\"#E6E600\",\"#E00000\",\"white\"],[\"#00C000\",\"#00C000\",\"#E00000\",\"#00C000\",\"white\"],[\"#5050FF\",\"#E6E600\",\"#00C000\",\"#E6E600\",\"white\"],[\"#00C000\",\"#E00000\",\"#5050FF\",\"#E00000\",\"white\"],[\"#5050FF\",\"#00C000\",\"#E6E600\",\"#00C000\",\"white\"],[\"#E00000\",\"#5050FF\",\"#5050FF\",\"#5050FF\",\"white\"],[\"#00C000\",\"#E6E600\",\"#00C000\",\"#E6E600\",\"white\"],[\"#E6E600\",\"#5050FF\",\"#5050FF\",\"#5050FF\",\"white\"],[\"#E00000\",\"#00C000\",\"#E00000\",\"#00C000\",\"white\"],[\"#00C000\",\"#5050FF\",\"#00C000\",\"#5050FF\",\"white\"],[\"#5050FF\",\"#E00000\",\"#E6E600\",\"#E00000\",\"white\"],[\"#00C000\",\"#00C000\",\"#E00000\",\"#E00000\",\"white\"],[\"#5050FF\",\"#E6E600\",\"#00C000\",\"#00C000\",\"white\"],[\"#E00000\",\"#E00000\",\"#5050FF\",\"#E6E600\",\"white\"],[\"#E6E600\",\"#00C000\",\"#E6E600\",\"#5050FF\",\"white\"],[\"#00C000\",\"#5050FF\",\"#5050FF\",\"#00C000\",\"white\"],[\"#5050FF\",\"#E6E600\",\"#00C000\",\"#5050FF\",\"white\"],[\"#E6E600\",\"#5050FF\",\"#5050FF\",\"#E00000\",\"white\"],[\"#5050FF\",\"#00C000\",\"#00C000\",\"#00C000\",\"white\"],[\"#00C000\",\"#5050FF\",\"#5050FF\",\"#E6E600\",\"white\"],[\"#5050FF\",\"#00C000\",\"#E6E600\",\"#E00000\",\"white\"],[\"#E00000\",\"#E6E600\",\"#5050FF\",\"#00C000\",\"white\"],[\"#00C000\",\"#5050FF\",\"#00C000\",\"#5050FF\",\"white\"],[\"#E6E600\",\"#E6E600\",\"#5050FF\",\"#E6E600\",\"white\"],[\"#E00000\",\"#5050FF\",\"#E00000\",\"#5050FF\",\"white\"],[\"#00C000\",\"#00C000\",\"#00C000\",\"#00C000\",\"white\"],[\"#5050FF\",\"#5050FF\",\"#E6E600\",\"#5050FF\",\"white\"],[\"#E6E600\",\"#E00000\",\"#E00000\",\"#E00000\",\"white\"],[\"#5050FF\",\"#E00000\",\"#00C000\",\"#00C000\",\"white\"],[\"#00C000\",\"#00C000\",\"#5050FF\",\"#E6E600\",\"white\"],[\"#5050FF\",\"#E6E600\",\"#E6E600\",\"#E00000\",\"white\"],[\"#E00000\",\"#00C000\",\"#5050FF\",\"#00C000\",\"white\"],[\"#00C000\",\"#5050FF\",\"#00C000\",\"#5050FF\",\"white\"],[\"#E6E600\",\"#E6E600\",\"#5050FF\",\"#E6E600\",\"white\"],[\"#E00000\",\"#5050FF\",\"#E00000\",\"#5050FF\",\"white\"],[\"#00C000\",\"#00C000\",\"#E00000\",\"#00C000\",\"white\"],[\"#5050FF\",\"#5050FF\",\"#00C000\",\"#5050FF\",\"white\"],[\"#E6E600\",\"#E00000\",\"#E6E600\",\"#E00000\",\"white\"],[\"#5050FF\",\"#00C000\",\"#5050FF\",\"#E00000\",\"white\"],[\"#00C000\",\"#E6E600\",\"#E6E600\",\"#00C000\",\"white\"],[\"#5050FF\",\"#E00000\",\"#5050FF\",\"#E6E600\",\"white\"],[\"#E00000\",\"#00C000\",\"#00C000\",\"white\"],[\"#E00000\",\"#5050FF\",\"#5050FF\",\"white\"],[\"#00C000\",\"#00C000\",\"#5050FF\",\"white\"],[\"#5050FF\",\"#5050FF\",\"#00C000\",\"white\"],[\"#E6E600\",\"#5050FF\",\"#5050FF\",\"white\"],[\"#5050FF\",\"#00C000\",\"#E00000\",\"white\"],[\"#00C000\",\"#5050FF\",\"#00C000\",\"white\"],[\"#5050FF\",\"#E00000\",\"#E6E600\",\"white\"],[\"#E00000\",\"#00C000\",\"#E00000\",\"white\"],[\"#E6E600\",\"#E6E600\",\"#00C000\",\"white\"],[\"#E00000\",\"#E00000\",\"#5050FF\",\"white\"],[\"#00C000\",\"#00C000\",\"#E6E600\",\"white\"],[\"#E6E600\",\"#5050FF\",\"#5050FF\",\"white\"],[\"#00C000\",\"#E6E600\",\"#00C000\",\"white\"],[\"#5050FF\",\"#5050FF\",\"#5050FF\",\"white\"],[\"#E6E600\",\"#00C000\",\"#E6E600\",\"white\"],[\"#5050FF\",\"#5050FF\",\"#5050FF\",\"white\"],[\"#00C000\",\"#E00000\",\"#00C000\",\"white\"]]},\"line\":{\"color\":\"white\",\"width\":0.0},\"font\":{\"family\":\"Consolas\",\"size\":14.0}},\"columnwidth\":[50,10]}];"
            |> chartGeneratedContains sequencePresentationTableChart
        );
        testCase "Sequence presentation table  layout" ( fun () ->
            "var layout = {\"width\":650,\"title\":{\"text\":\"Sequence A\"}};"
            |> chartGeneratedContains sequencePresentationTableChart
        );
    ]


let heatmap1Chart =
    let matrix =
        [[1.;1.5;0.7;2.7];
        [2.;0.5;1.2;1.4];
        [0.1;2.6;2.4;3.0];]
    
    let rownames = ["p3";"p2";"p1"]
    let colnames = ["Tp0";"Tp30";"Tp60";"Tp160"]
    
    let colorscaleValue = 
        StyleParam.Colorscale.Custom [(0.0,"#3D9970");(1.0,"#001f3f")]
    
    Chart.Heatmap(
        matrix,colnames,rownames,
        Colorscale=colorscaleValue,
        Showscale=true
    )
    |> Chart.withSize(700,500)
    |> Chart.withMarginSize(Left=200.)

let heatmapStyledChart =
    let matrix =
        [[1.;1.5;0.7;2.7];
        [2.;0.5;1.2;1.4];
        [0.1;2.6;2.4;3.0];]
    
    let rownames = ["p3";"p2";"p1"]
    let colnames = ["Tp0";"Tp30";"Tp60";"Tp160"]
    
    let colorscaleValue = 
        StyleParam.Colorscale.Custom [(0.0,"#3D9970");(1.0,"#001f3f")]
    
    Chart.Heatmap(
        matrix,colnames,rownames,
        Colorscale=colorscaleValue,
        Showscale=true
    )
    |> Chart.withSize(700.,500.)
    |> Chart.withMarginSize(Left=200.)
    |> Chart.withColorBarStyle(
        Title.init(
            Text = "Im the Colorbar"
        )
    )


[<Tests>]
let ``Heatmap charts`` =
    testList "SimpleCharts.Heatmap charts" [
        testCase "Heatmap data" ( fun () ->
            "var data = [{\"type\":\"heatmap\",\"z\":[[1.0,1.5,0.7,2.7],[2.0,0.5,1.2,1.4],[0.1,2.6,2.4,3.0]],\"x\":[\"Tp0\",\"Tp30\",\"Tp60\",\"Tp160\"],\"y\":[\"p3\",\"p2\",\"p1\"],\"colorscale\":[[0.0,\"#3D9970\"],[1.0,\"#001f3f\"]],\"showscale\":true}];"
            |> chartGeneratedContains heatmap1Chart
        );
        testCase "Heatmap layout" ( fun () ->
            "var layout = {\"width\":700,\"height\":500,\"margin\":{\"l\":200.0}};"
            |> chartGeneratedContains heatmap1Chart
        );
        testCase "Heatmap styled data" ( fun () ->
            """var data = [{"type":"heatmap","z":[[1.0,1.5,0.7,2.7],[2.0,0.5,1.2,1.4],[0.1,2.6,2.4,3.0]],"x":["Tp0","Tp30","Tp60","Tp160"],"y":["p3","p2","p1"],"colorscale":[[0.0,"#3D9970"],[1.0,"#001f3f"]],"showscale":true,"colorbar":{"title":{"text":"Im the Colorbar"}}}]"""
            |> chartGeneratedContains heatmapStyledChart
        );
        testCase "Heatmap styled layout" ( fun () ->
            "var layout = {\"width\":700,\"height\":500,\"margin\":{\"l\":200.0}};"
            |> chartGeneratedContains heatmapStyledChart
        );
    ]


let colors = [
    [[0  ;0  ;255]; [255;255;0  ]; [0  ;0  ;255]]
    [[255;0  ;0  ]; [255;0  ;255]; [255;0  ;255]]
    [[0  ;255;0  ]; [0  ;255;255]; [255;0  ;0  ]]
]

let imageRawChart = 
    Chart.Image(Z=colors)
    |> Chart.withTitle "Image chart from raw color component arrays"

let imageRawHSLChart = 
    Chart.Image(Z=colors, ColorModel=StyleParam.ColorModel.HSL)
    |> Chart.withTitle "HSL color model"

let argbs = [
    [ColorKeyword.AliceBlue     ; ColorKeyword.CornSilk ; ColorKeyword.LavenderBlush ] |> List.map ARGB.fromKeyword
    [ColorKeyword.DarkGray      ; ColorKeyword.Snow     ; ColorKeyword.MidnightBlue  ] |> List.map ARGB.fromKeyword
    [ColorKeyword.LightSteelBlue; ColorKeyword.DarkKhaki; ColorKeyword.LightAkyBlue  ] |> List.map ARGB.fromKeyword
]

let imageARGBChart = 
    Chart.Image(argbs)
    |> Chart.withTitle "ARGB image chart"

open System.IO

let imageSource = $@"{__SOURCE_DIRECTORY__}../../../../docs/img/logo.png"

let base64String = 
    imageSource
    |> File.ReadAllBytes
    |> System.Convert.ToBase64String

let logoImageChart = 
    Chart.Image(
        Source=($"data:image/jpg;base64,{base64String}")
    )
    |> Chart.withTitle "This is Plotly.NET:"

[<Tests>]
let ``Image charts`` =
    testList "SimpleCharts.Image charts" [
        testCase "Image raw data" ( fun () ->
            """var data = [{"type":"image","z":[[[0,0,255],[255,255,0],[0,0,255]],[[255,0,0],[255,0,255],[255,0,255]],[[0,255,0],[0,255,255],[255,0,0]]]}];"""
            |> chartGeneratedContains imageRawChart
        );
        testCase "Image raw layout" ( fun () ->
            """var layout = {"title":{"text":"Image chart from raw color component arrays"}};"""
            |> chartGeneratedContains imageRawChart
        );        

        testCase "Image raw hsl data" ( fun () ->
            """var data = [{"type":"image","z":[[[0,0,255],[255,255,0],[0,0,255]],[[255,0,0],[255,0,255],[255,0,255]],[[0,255,0],[0,255,255],[255,0,0]]],"colormodel":"hsl"}];"""
            |> chartGeneratedContains imageRawHSLChart
        );
        testCase "Image raw hsl layout" ( fun () ->
            """var layout = {"title":{"text":"HSL color model"}};"""
            |> chartGeneratedContains imageRawHSLChart
        );        

        testCase "Image ARGB data" ( fun () ->
            """var data = [{"type":"image","z":[[[240,248,255,255],[255,248,220,255],[255,240,245,255]],[[169,169,169,255],[255,250,250,255],[25,25,112,255]],[[176,196,222,255],[189,183,107,255],[135,206,250,255]]],"colormodel":"rgba"}];"""
            |> chartGeneratedContains imageARGBChart
        );
        testCase "Image ARGB layout" ( fun () ->
            """var layout = {"title":{"text":"ARGB image chart"}};"""
            |> chartGeneratedContains imageARGBChart
        );        

        testCase "Image base64 data" ( fun () ->
            """var data = [{"type":"image","source":"data:image/jpg;base64,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RAFgOgIKUERA4XBCClBCSAFgSr+4egAA7ElAAYoIKIF//Zf/+rurN4zmL7/76g/btn139Q5geb/etu2nb374+durhwDAnkQUAKYhoABFBJTAj19//5v//ad//I9vfvj5N1dvGY2QApQQUgCYjogCwBQEFKCIgBL48evvf7Nt25//75e//Idt2/4spNxPSAFKCCkATEVEAWB4AgpQREAJPAeUbdt+9XT61SakRIQUoISQAsA0RBQAhiagAEUElMALAeWZkBISUoASQgoAUxBRABiWgAIUEVACbwSUZ0JKSEgBSggpAAxPRAFgSAIKUERACdwQUJ4JKSEhBSghpAAwNBEFgOEIKEARASVwR0B5JqSEhBSghJACwLBEFACGIqAARQSUQBBQngkpISEFKCGkADAkEQWAYQgoQBEBJfBAQHkmpISEFKCEkALAcEQUAIYgoABFBJTADgHlmZASElKAEkIKAEMRUQCoJ6AARQSUwI4B5ZmQEhJSgBJCCgDDEFEAqCagAEUElMABAeWZkBISUoASQgoAQxBRAKgloABFBJTAgQHlmZASElKAEkIKAPVEFAAqCShAEQElcEJAeSakhIQUoISQAkA1EQWAOgIKUERACZwYUJ4JKSEhBSghpABQS0QBoIqAAhQRUAIXBJRnQkpISAFKCCkAVBJRAKghoABFBJTAhQHlmZASElKAEkIKAHVEFAAqCChAEQElUBBQngkpISEFKCGkAFBFRAHgcgIKUERACRQFlGdCSkhIAUoIKQDUEFEAuJSAAhQRUAKFAeWZkBISUoASQgoAFUQUAC4joABFBJRAcUB5JqSEhBSghJACwOVEFAAuIaAARQSUwAAB5ZmQEhJSgBJCCgCXElEAOJ2AAhQRUAIDBZRnQkpISAFKCCkAXEZEAeBUAgpQREAJDBhQngkpISEFKCGkAHAJEQWA0wgoQBEBJTBwQHkmpISEFKCEkALA6UQUAE4hoABFBJTABAHlmZASElKAEkIKAKcSUQA4nIACFBFQAhMFlGdCSkhIAUoIKQCcRkQB4FACClBEQAlMGFCeCSkhIQUoIaQAcAoRBYDDCChAEQElMHFAeSakhIQUoISQAsDhRBQADiGgAEUElMACAeWZkBISUoASQgoAhxJRANidgAIUEVACCwWUZ0JKSEgBSggpABxGRAFgVwIKUERACSwYUJ4JKSEhBSghpABwCBEFgN0IKEARASWwcEB5JqSEhBSghJACwO5EFAB2IaAARQSUgIDygZASElKAEkIKALsSUQB4mIACFBFQAgLKF4SUkJAClBBSANiNiALAQwQUoIiAEhBQXiWkhIQUoISQAsAuRBQAYgIKUERACQgo7xJSQkIKUEJIAeBhIgoAEQEFKCKgBASUmwkpISEFKCGkAPAQEQWAuwkoQBEBJSCg3E1ICQkpQAkhBYCYiALAXQQUoIiAEhBQYkJKSEgBSggpAEREFABuJqAARQSUgIDyMCElJKQAJYQUAO4mogBwEwEFKCKgBASU3QgpISEFKCGkAHAXEQWAdwkoQBEBJSCg7E5ICQkpQAkhBYCbiSgAvElAAYoIKAEB5TBCSkhIAUoIKQDcREQB4FUCClBEQAkIKIcTUkJCClBCSAHgXSIKAC8SUIAiAkpAQDmNkBISUoASQgoAbxJRAPiCgAIUEVACAsrphJSQkAKUEFIAeJWIAsAnBBSgiIASEFAuI6SEhBSghJACwItEFAA+EFCAIgJKQEC5nJASElKAEkIKAF8QUQDYtk1AAaoIKAEBpYaQEhJSgBJCCgCfEFEAEFCAJgJKQECpI6SEhBSghJACwAciCsDiBBSgiIASEFBqCSkhIQUoIaQAsG2biAKwNAEFKCKgBASUekJKSEgBSggpAIgoAKsSUIAiAkpAQBmGkBISUoASQgrA4kQUgAUJKEARASUgoAxHSAkJKUAJIQVgYSIKwGIEFKCIgBIQUIYlpISEFKCEkAKwKBEFYCECClBEQAkIKMMTUkJCClBCSAFYkIgCsAgBBSgioAQElGkIKSEhBSghpAAsRkQBWICAAhQRUAICynSElJCQApQQUgAWIqIATE5AAYoIKAEBZVpCSkhIAUoIKQCLEFEAJiagAEUElICAMj0hJSSkACWEFIAFiCgAkxJQgCICSkBAWYaQEhJSgBJCCsDkRBSACQkoQBEBJSCgLEdICQkpQAkhBWBiIgrAZAQUoIiAEhBQliWkhIQUoISQAjApEQVgIgIKUERACQgoyxNSQkIKUEJIAZiQiAIwCQEFKCKgBAQUnggpISEFKCGkAExGRAGYgIACFBFQAgIKnxFSQkIKUEJIAZiIiAIwOAEFKCKgBAQUXiGkhIQUoISQAjAJEQVgYAIKUERACQgovENICQkpQAkhBWACIgrAoAQUoIiAEhBQuJGQEhJSgBJCCsDgRBSAAQkoQBEBJSCgcCchJSSkACWEFICBiSgAgxFQgCICSkBAISSkhIQUoISQAjAoEQVgIAIKUERACQgoPEhICQkpQAkhBWBAIgrAIAQUoIiAEhBQ2ImQEhJSgBJCCsBgRBSAAQgoQBEBJSCgsDMhJSSkACWEFICBiCgA5QQUoIiAEhBQOIiQEhJSgBJCCsAgRBSAYgIKUERACQgoHExICQkpQAkhBWAAIgpAKQEFKCKgBAQUTiKkhIQUoISQAlBORAEoJKAARQSUgIDCyYSUkJAClBBSAIqJKABlBBSgiIASEFC4iJASElKAEkIKQCkRBaCIgAIUEVACAgoXE1JCQgpQQkgBKCSiAJQQUIAiAkpAQKGEkBISUoASQgpAGREFoICAAhQRUAICCmWElJCQApQQUgCKiCgAFxNQgCICSkBAoZSQEhJSgBJCCkAJEQXgQgIKUERACQgolBNSQkIKUEJIASggogBcREABiggoAQGFQQgpISEFKCGkAFxMRAG4gIACFBFQAgIKgxFSQkIKUEJIAbiQiAJwMgEFKCKgBAQUBiWkhIQUoISQAnAREQXgRAIKUERACQgoDE5ICQkpQAkhBeACIgrASQQUoIiAEhBQmISQEhJSgBJCCsDJRBSAEwgoQBEBJSCgMBkhJSSkACWEFIATiSgABxNQgCICSkBAYVJCSkhIAUoIKQAnEVEADiSgAEUElICAwuSElJCQApQQUgBOIKIAHERAAYoIKAEBhUUIKSEhBSghpAAcTEQBOICAAhQRUAICCosRUkJCClBCSAE4kIgCsDMBBSgioAQEFBYlpISEFKCEkAJwEBEFYEcCClBEQAkIKCxOSAkJKUAJIQXgACIKwE4EFKCIgBIQUGDbNiElJqQAJYQUgJ2JKAA7EFCAIgJKQECBTwgpISEFKCGkAOxIRAF4kIACFBFQAgIKvEhICQkpQAkhBWAnIgrAAwQUoIiAEhBQ4E1CSkhIAUoIKQA7EFEAQgIKUERACQgocBMhJSSkACWEFIAHiSgAAQEFKCKgBAQUuIuQEhJSgBJCCsADRBSAOwkoQBEBJSCgQERICQkpQAkhBSAkogDcQUABiggoAQEFHiKkhIQUoISQAhAQUQBuJKAARQSUgIACuxBSQkIKUEJIAbiTiAJwAwEFKCKgBAQU2JWQEhJSgBJCCsAdRBSAdwgoQBEBJSCgwCGElJCQApQQUgBuJKIAvEFAAYoIKAEBBQ4lpISEFKCEkAJwAxEF4BUCClBEQAkIKHAKISUkpAAlhBSAd4goAC8QUIAiAkpAQIFTCSkhIQUoIaQAvEFEAfiMgAIUEVACAgpcQkgJCSlACSEF4BUiCsBHBBSgiIASEFDgUkJKSEgBSggpAC8QUQCeCChAEQElIKBABSElJKQAJYQUgM+IKACbgAJUEVACAgpUEVJCQgpQQkgB+IiIAixPQAGKCCgBAQUqCSkhIQUoIaQAPBFRgKUJKEARASUgoEA1ISUkpAAlhBSATUQBFiagAEUElICAAkMQUkJCClBCSAGWJ6IASxJQgCICSkBAgaEIKSEhBSghpABLE1GA5QgoQBEBJSCgwJCElJCQApQQUoBliSjAUgQUoIiAEhBQYGhCSkhIAUoIKcCSRBRgGQIKUERACQgoMAUhJSSkACWEFGA5IgqwBAEFKCKgBAQUmIqQEhJSgBJCCrAUEQWYnoACFBFQAgIKTElICQkpQAkhBViGiAJMTUABiggoAQEFpiakhIQUoISQAixBRAGmJaAARQSUgIACSxBSQkIKUEJIAaYnogBTElCAIgJKQECBpQgpISEFKCGkAFMTUYDpCChAEQElIKDAkoSUkJAClBBSgGmJKMBUBBSgiIASEFBgaUJKSEgBSggpwJREFGAaAgpQREAJCCjAJoydhNYAACAASURBVKTEhBSghJACTEdEAaYgoABFBJSAgAJ8REgJCSlACSEFmIqIAgxPQAGKCCgBAQV4gZASElKAEkIKMA0RBRiagAIUEVACAgrwBiElJKQAJYQUYAoiCjAsAQUoIqAEBBTgBkJKSEgBSggpwPBEFGBIAgpQREAJCCjAHYSUkJAClBBSgKGJKMBwBBSgiIASEFCAgJASElKAEkIKMCwRBRiKgAIUEVACAgrwACElJKQAJYQUYEgiCjAMAQUoIqAEBBRgB0JKSEgBSggpwHBEFGAIAgpQREAJCCjAjoSUkJAClBBSgKGIKEA9AQUoIqAEBBTgAEJKSEgBSggpwDBEFKCagAIUEVACAgpwICElJKQAJYQUYAgiClBLQAGKCCgBAQU4gZASElKAEkIKUE9EASoJKEARASUgoAAnElJCQgpQQkgBqokoQB0BBSgioAQEFOACQkpISAFKCClALREFqCKgAEUElICAAlxISAkJKUAJIQWoJKIANQQUoIiAEhBQgAJCSkhIAUoIKUAdEQWoIKAARQSUgIACFBFSQkIKUEJIAaqIKMDlBBSgiIASEFCAQkJKSEgBSggpQA0RBbiUgAIUEVACAgpQTEgJCSlACSEFqCCiAJcRUIAiAkpAQAEGIKSEhBSghJACXE5EAS4hoABFBJSAgAIMREgJCSlACSEFuJSIApxOQAGKCCgBAQUYkJASElKAEkIKcBkRBTiVgAIUEVACAgowMCElJKQAJYQU4BIiCnAaAQUoIqAEBBRgAkJKSEgBSggpwOlEFOAUAgpQREAJCCjARISUkJAClBBSgFOJKMDhBBSgiIASEFCACQkpISEFKCGkAKcRUYBDCShAEQElIKAAExNSQkIKUEJIAU4hogCHEVCAIgJKQEABFiCkhIQUoISQAhxORAEOIaAARQSUgIACLERICQkpQAkhBTiUiALsTkABiggoAQEFWJCQEhJSgBJCCnAYEQXYlYACFBFQAgIKsDAhJSSkACWEFOAQIgqwGwEFKCKgBAQUACElJaQAJYQUYHciCrALAQUoIqAEBBSAD4SUkJAClBBSgF2JKMDDBBSgiIASEFAAviCkhIQUoISQAuxGRAEeIqAARQSUgIAC8CohJSSkACWEFGAXIgoQE1CAIgJKQEABeJeQEhJSgBJCCvAwEQWICChAEQElIKAA3ExICQkpQAkhBXiIiALcTUABiggoAQEF4G5CSkhIAUoIKUBMRAHuIqAARQSUgIACEBNSQkIKUEJIASIiCnAzAQUoIqAEBBSAhwkpISEFKCGkAHcTUYCbCChAEQElIKAA7EZICQkpQAkhBbiLiAK8S0ABiggoAQEFYHdCSkhIAUoIKcDNRBTgTQIKUERACQgoAIcRUkJCClBCSAFuIqIArxJQgCICSkBAATickBISUoASQgrwLhEFeJGAAhQRUAICCsBphJSQkAKUEFKAN4kowBcEFKCIgBIQUABOJ6SEhBSghJACvEpEAT4hoABFBJSAgAJwGSElJKQAJYQU4EUiCvCBgAIUEVACAgrA5YSUkJAClBBSgC+IKMC2bQIKUEVACQgoADWElJCQApQQUoBPiCiAgAI0EVACAgpAHSElJKQAJYQU4AMRBRYnoABFBJSAgAJQS0gJCSlACSEF2LZNRIGlCShAEQElIKAA1BNSQkIKUEJIAUQUWJWAAhQRUAICCsAwhJSQkAKUEFJgcSIKLEhAAYoIKAEBBWA4QkpISAFKCCmwMBEFFiOgAEUElICAAjAsISUkpAAlhBRYlIgCCxFQgCICSkBAARiekBISUoASQgosSESBRQgoQBEBJSCgAExDSAkJKUAJIQUWI6LAAgQUoIiAEhBQAKYjpISEFKCEkAILEVFgcgIKUERACQgoANMSUkJCClBCSIFFiCgwMQEFKCKgBAQUgOkJKSEhBSghpMACRBSYlIACFBFQAgIKwDKElJCQApQQUmByIgpMSEABiggoAQEFYDlCSkhIAUoIKTAxEQUmI6AARQSUgIACsCwhJSSkACWEFJiUiAITEVCAIgJKQEABWJ6QEhJSgBJCCkxIRIFJCChAEQElIKAA8ERICQkpQAkhBSYjosAEBBSgiIASEFAA+IyQEhJSgBJCCkxERIHBCShAEQElIKAA8AohJSSkACWEFJiEiAIDE1CAIgJKQEAB4B1CSkhIAUoIKTABEQUGJaAARQSUgIACwI2ElJCQApQQUmBwIgoMSEABiggoAQEFgDsJKSEhBSghpMDARBQYjIACFBFQAgIKACEhJSSkACWEFBiUiAIDEVCAIgJKQEAB4EFCSkhIAUoIKTAgEQUGIaAARQSUgIACwE6ElJCQApQQUmAwIgoMQEABiggoAQEFgJ0JKSEhBSghpMBARBQoJ6AARQSUgIACwEGElJCQApQQUmAQIgoUE1CAIgJKQEAB4GBCSkhIAUoIKTAAEQVKCShAEQElIKAAcBIhJSSkACWEFCgnokAhAQUoIqAEBBQATiakhIQUoISQAsVEFCgjoABFBJSAgALARYSUkJAClBBSoJSIAkUEFKCIgBIQUAC4mJASElKAEkIKFBJRoISAAhQRUAICCgAlhJSQkAKUEFKgjIgCBQQUoIiAEhBQACgjpISEFKCEkAJFRBS4mIACFBFQAgIKAKWElJCQApQQUqCEiAIXElCAIgJKQEABoJyQEhJSgBJCChQQUeAiAgpQREAJCCgADEJICQkpQAkhBS4mosAFBBSgiIASEFAAGIyQEhJSgBJCClxIRIGTCShAEQElIKAAMCghJSSkACWEFLiIiAInElCAIgJKQEABYHBCSkhIAUoIKXABEQVOIqAARQSUgIACwCSElJCQApQQUuBkIgqcQEABiggoAQEFgMkIKSEhBSghpMCJRBQ4mIACFBFQAgIKAJMSUkJCClBCSIGTiChwIAEFKCKgBAQUACYnpISEFKCEkAInEFHgIP/P3p3H2VXXef5/n3urbu2VykZSSaqCJGQlEUPYIYRAICQEcIFpaVqQ9Ezb2t04v984Ok2PQmv32DpOYzvOqC0t2jYKorbN0iCyhKVFmxBkCQSIJCELS0glVZWq1HbP/FEJQshS9a177vdzvuf1fDzyyEMfj9R9H2+EuudV5xwCCgBDCCgOCCgAgIwgpDgipAAwgpACJIyIAiSAgALAEAKKAwIKACBjCCmOCCkAjCCkAAkiogAlRkABYAgBxQEBBQCQUYQUR4QUAEYQUoCEEFGAEiKgADCEgOKAgAIAyDhCiiNCCgAjCClAAogoQIkQUAAYQkBxQEABAEASIcUZIQWAEYQUoMSIKEAJEFAAGEJAcUBAAQDgHQgpjggpAIwgpAAlREQBRoiAAsAQAooDAgoAAAdFSHFESAFgBCEFKBEiCjACBBQAhhBQHBBQAAA4LEKKI0IKACMIKUAJEFEARwQUAIYQUBwQUAAAGBJCiiNCCgAjCCnACBFRAAcEFACGEFAcEFAAABgWQoojQgoAIwgpwAgQUYBhIqAAMISA4oCAAgCAE0KKI0IKACMIKYAjIgowDAQUAIYQUBwQUAAAGBFCiiNCCgAjCCmAAyIKMEQEFACGEFAcEFAAACgJQoojQgoAIwgpwDARUYAhIKAAMISA4oCAAgBASRFSHBFSABhBSAGGgYgCHAEBBYAhBBQHBBQAABJBSHFESAFgBCEFGCIiCnAYBBQAhhBQHBBQAABIFCHFESEFgBGEFGAIiCjAIRBQABhCQHFAQAEAoCwIKY4IKQCMIKQAR0BEAQ6CgALAEAKKAwIKAABlRUhxREgBYAQhBTgMIgpwAAIKAEMIKA4IKAAAeEFIcURIAWAEIQU4hArfAwBLCCgADCGgOCCgDCpW5rXllKnaOW2sOpob1dnc+NbvPQ1VqnutQw3bO9SwvV3129vVsL1dzWu3aMyLO3xPxz699QVtPuMY7W5pesf719HcoIFCxTveu/rt7WrY1q7WR19W3eudvqdjn1yNVDkhVq5WB/yKFQ9Ixe5IxS797tceqe/VSHGf7+XYL98oVYw78D2MlauR4j6p2PXO93CgPVLf65KKvpd7tT+kLG1bFT3ue0yatK2Kvjr6xliSbvC9BUCm7Q8pi9tWRRt9jwGsiHwPAKwgoAAwhIDiIOsBpbe+oA1LZ+qFC+fopQtmae+ommF/jXHrX9eMO9Zpxu3PatKaLYqKcQJLcSidExr04vLZeuHCOXr57OkaqBrmzzvFsab8arNm3LFOM+94NrVR7Karr1j9mwXzz/K9w0W+USpMjVVojVV51PD/fDwg9W2L1LtZ6n0lUrG79BtxGJFUMU6qah18D/MO/zaJewffu97NUu/WTEexXZIIKQ5G3xhfI0IKAP82SSKkAPsQUQARUACYQkBxkOWAsn3BFD3ymSXacO6M4Z90P4z6Vzs07wdP6NSvrFZNW1fJvi4OEEVav3KOHrtmkbac3CpFpfv2fOwLb+iEv39MC779mPK9AyX7uklLXUTJSTWzYlXPipUfVdov3fe61P10pN7NfGxLUlQl1c6LVTVt8KqTUokHpL6tkbp+E6k/nU1zpAgpjggpAIwgpAD78N04Mo+AAsAQAoqDrAaUtmPG6sHPna91H5qf6OtU7+7WaV9+UCd+499U0Z3dH6lOwpZTp+q+LyzXllOS/Rak6eWdOvv6ezT7x0+l4uqi1ESUSKp6T6zaBbHyDcm+VN/rUte/5wZvFYWSifJS9ZxYtfNjRYVkX6vn5UhdayINdCT7OgYRUhwRUgAYQUgBRERBxhFQABhCQHGQxYDSNa5Oj3zmHK35w5NVrMyX7XUbt+7Wos/fq/k3P6FoINs3/B+pHTOP0gN/uUwvXDinrK/bvHarllx7l45evaGsrztcaYgolc2x6k6MVTG2vK/buznSnscjDewu7+sGJ5Kqp8eqfV+sXF0ZX7coda+P1P1kpOLeMr6uf4QUR4QUAEYQUpB5RBRkFgEFgCEEFAdZDChbT2rVbT/8A3VOSPjH3g9j+j3rdcmVN6uqo8fbhjR7+vIFuvPrH9RAoXwB7ECn3PCQlnz2brMxzHREiaS6hbFqjvN3RU88IHU+GqlnAx/lXEQFqeGsWIUp/t7DYrfUfl9O/W94m+ADIcURIQWAEYQUZFrO9wDABwIKAEMIKA6yGFCe/vAC/ePd/8lrQJGkl86fqZtWf0Jt08r8I/gpF+dzuu+vlutf/v4yrwFFkh775CLdeutH1NNQ5XVH2kSVUuO5fgOKNHgLqoZFseoWxvxI3DDlG6WmFUWvAUWScjXSqAuKqppm//Z6JdQk6d7RN8YLfQ9Jm7ZV0VclfdL3DgCZN1XSg6NvjI/2PQTwgYiCzCGgADCEgOIgawHlrZPv376spA+OH4kdM4/Sd1Z/QhvPmuZ7Sir0NFTp1ls/osc+ucj3lLe8tGwWMWwY8o1S04X+T76/Xc28WI3nxIoqfS9Jh8rmWE0ri8ob+TdHRmMYIcURIQWAEYQUZBYRBZlCQAFgCAHFQRYDyk++d7mpk+/7dY+u1c23r0r8wfZp1z26Vt994ON6adks31PeZcfMo/QPD/2JXpvX7HuKaRVjZOrk+9sVWmI1XVhUxEVFh1X1nlijzk/+4fEuaubFalhMSMGREVIAGEFIQSYRUZAZBBQAhhBQHGQtoEjSA9efr+cvOc73jEOK8znd/s3LtO2EKb6nmFSszOsn379cb8ye4HvKIe1tqtGtP7pSe8bX+55iUq5aajy3aPLk+375Jqlxccwnu0OoGC/Vn2k7UlQdHavuBDtXOZUBIcURIQWAEYQUZA7faiMTCCgADCGgOMhiQHn6wwv0y/9s89nab9dfXaEf3XqlOpobfU8x594vrtDGxdN9zzii9pYm/fjmK7w/q8WaKC81nFNUrs73kiOrnBSr7qRMnYQfklyt1LikqCgFf7Vr5sU8IwVDQkgBYAQhBZlCREHwCCgADCGgOMhiQNl6Uqvu/PoHfM8Yss6JDbrtlo+ov4aHM+y39uqT9PjHTvM9Y8heOe1o3X3DJVJk+Mf1y6zu1FiVR/leMXQ1s2NVz8jUSfjDivJS4zlF5Wp9Lxm6+tNjVYz3vaKsCCmOCCkAjCCkIDOIKAgaAQWAIQQUB1kMKF3j6nTbD//AzEPkh2rbCVP0rzdc4nuGCVtPbNHdf5u+/y2evPJEPbHqJN8zTKieFav62PQFifpTM3cS/pDqT4tVMc73iuF5K/xU+15SVoQUR4QUAEYQUpAJRBQEi4ACwBACioMsBhRJeuQz56hzQoPvGU6euuIEbVvY4nuGX1Gke7+0UsWKdH6b/cD1y7S3qcb3DK+igtL7fIqcVH9y0fcK7yrGS1XT0/ke5mqkmvemc/sIEFIcEVIAGEFIQfDS+ekOOAICCgBDCCgOshpQ2o4ZqzV/eLLvGSNy3xcuyPQtoZ6/eK62ntTqe4azvU01+rf/stj3DK9q58emHyR/JBXjpcLUzJ2Ef4e6hekOSTWzYuXT2dJHgpDiiJACwAhCCoJGREFwCCgADCGgOMhqQJGkBz93voqVKXgC8mFsPvMYvXT+TN8zvChW5vXA9ct8zxixX3/8dLW3ZO7/fpKkXJ1UPSf9AaJuYZzZT3qFlliVE32vGKGcVJvWq6FGhpDiiJACwAhCCoKV0W+tESoCCgBDCCgOshxQtp0wRes+NN/3jJK4/wsXKM5n79vMtR89STunp+whDAcxUFWh1f99qe8ZXtQtiBWlu2NKkvKNyuZD5nP7AlIAqt6Tvme6lAghxREhBYARhBQEKXufbhEsAgoAQwgoDrIcUCTp0U8v8T2hZN6YPUHPXzzX94yyivM5PRLQe/jU5Qu06+gxvmeUVb4hvc/ROJja98ZSxu6sVzU1Vj6gf4PUZu/ZKPsRUhwRUgAYQUhBcIgoCAIBBYAhBBQHWQ8ovfVV2nDuDN8zSur5i+f5nlBWW09qUefEgB5iEEVav3KO7xVlVWgN64R1rlaqHO97RXkVAvskUDk5VlTpe4U3hBRHhBQARhBSEBQiClKPgALAEAKKg6wHFEnasHSGBqoqfM8oqZeWzQzumA5n/crwrrx54cLwjulwQnwYe2hh6HCivFSYEtbxRnmpMDmsYxomQoojQgoAIwgpCAYRBalGQAFgCAHFAQFl0AsXhvcT/731Vdp05jG+Z5RHFGl9gMHhldOOVtfYOt8zyiJXLVUe5XtF6YUYhg6lcmKYV20UWn0v8I6Q4oiQAsAIQgqCQERBahFQABhCQHFAQBlUrMzrpQtm+Z6RiBCvzjiYHTPHq23aWN8zSi7ORcH+3TxQoSXM54fkGxXUM0IOJ7Rbee1XaIn51E5IcUZIAWAEIQWpx7djSCUCCgBDCCgOCCi/s+WUqdo7qsb3jES8uHy27wll8eIF4R5nVt7DQovvBckptGTjapRQjzMqhHmVlANCiiNCCgAjCClINSIKUoeAAsAQAooDAso77QzwCob9OiY1qr8mwPvrHGDn9HG+JyQm5L+fb5drDPMEvDR4NUroogopV+t7RXLyAf/9HCZCiiNCCgAjCClILSIKUoWAAsAQAooDAsq7dTSHfYazc2KD7wmJ6wz4PQz52N4uH/AJ+FyYF7q9Q+jHGHIgckBIcURIAWAEIQWpRERBahBQABhCQHFAQDm40E9Shx6JJKmjOdxQ1DW2TgOFvO8ZiYryUlTle0VycrXhX8UQemQIPRI5IKQ4IqQAMIKQgtQhoiAVCCgADCGgOCCgHFroV2qEfnyS1Dkx7FC0Z0LY72EU+Anq0AODFH4oysJ76ICQ4oiQAsAIQgpShYgC8wgoAAwhoDggoBxe6FdqhH58xcq89oyv8z0jUaG/h6GfoM7VKPhPfcG/h4FHohEgpDgipAAwgpCC1Aj822mkHQEFgCEEFAcElCPraaj2PSFRPY1hH19vbUGKIt8zEhX6e5irDP8EdVThe0GyokrfC5IVFXwvMI2Q4oiQAsAIQgpSgYgCswgoAAwhoDggoAxN3esdvickqv61sI+vun2v8r0Dvmckqi7w97DYHXYEiwekuNf3imQVu30vSFaxy/cC8wgpjggpAIwgpMA8IgpMIqAAMISA4oCAMnQN28M+QV0f+PEpjlW/vd33ikQ1BH58oZ+gDv34pPCPMfTQVyKEFEeEFABGEFJgGhEF5hBQABhCQHFAQBme0E9Qh358UtjHmOsbUM3OsM9QF3skFX2vSE7oV2lIUrEr7MgQeiQqIUKKI0IKACMIKTCLiAJTCCgADCGgOCCgDF/oVzGEfnxS2BGl/tUORcXAnxkShx0aQg8MUtjvn0REGSZCiiNCCgAjCCkwiYgCMwgoAAwhoDggoLgJ+QR8VIxVt2OP7xmJCzkUNbwa+O3Y9gn5JHXIx7ZfsVtSwK0vC+9hiRFSHBFSABhBSIE5RBSYQEABYAgBxQEBxV3z2i2+JySmee1WRQMB3ydpn+YntvqekJjmNa/4nlAW/TvCvVqjf4fvBWUQS/1v+h6RnJD/fiaIkOKIkALACEIKTCGiwDsCCgBDCCgOCCgjM+bFHRq3/nXfMxIx4/ZnfU8oi+l3Px9sLJp5+zrfE8qiZ7PvBQmJpd5XsnECvndzmMc5sEsaCPdit6QRUhwRUgAYQUiBGUQUeEVAAWAIAcUBAaU0ZtwR5onqUI/rQDVtXWp99GXfM0quend3kMd1MH2vRop7fa8ovVCP62B6Ao0oocahMiKkOCKkADCCkAITiCjwhoACwBACigMCSumEeMXG6A1vavzzYV5hczAhXrEx/e7nlesb8D2jPIpS75bwTlb3bvK9oHwG2qSBAB/hE2ocKjNCiiNCCgAjCCnwjogCLwgoAAwhoDggoJTWpDVbVB/YA7xn3LlOigN+0vMBQrzqJsRjOpzeAG/p1ZORW3ntF9pVG8WujDzTpjwIKY4IKQCMIKTAKyIKyo6AAsAQAooDAkrpRcVY837whO8ZJTXv5rCO50hGbW5T68O/9T2jZGrf3KNpP1/ve0ZZ9W6JFPf4XlE6fa9KxU7fK8qr56WwIkrPhkjKTosuB0KKI0IKACMIKfCGiIKyIqAAMISA4oCAkpxTv7Ja1bu7fc8oibm3PqkJT2/3PaPslnzubt8TSuaML96vQmdGHqaxT9wndT0Zzkn4PY9n76Ne/06p57dhvIdxr9T1dBjHYgwhxREhBYARhBR4kb3vrOENAQWAIQQUBwSUZNW0dem0Lz/oe8aI5XsHtPj6n/ue4cXkX23WrJ8943vGiDW9vFMLvv2Y7xle7F0fBfFcjZ6Nkfrf8L3Cj64nIqnoe8XIdT0V1pVRxhBSHBFSABhBSEHZEVFQFgQUAIYQUBwQUMrjxG/8mxq37vY9Y0RO+NYv1bRxp+8Z3iz+3D2KBtJ9Bvfs6+9RvjcjD5Q/QDyw7yR8msVS15qUH8MIDHRI3c+n+/iLe6S969J9DClASHFESAFgBCEFZUVEQeIIKAAMIaA4IKCUT0V3nxZ9/l7fM5xVdfTo9C894HuGV2NffEPv+86/+57hrHntVs3+8VO+Z3jV83Kk/jd9r3C3d32kgXbfK/zq/k2kuM/3CnddayPF2eyY5UZIcURIAWAEIQVlQ0RBoggoAAwhoDggoJTf/Juf0PR70vlA72XX/LNq39zje4Z3i6+7R6N/m76z8JVdfVrxx7cpKmb8Sdax1PlITnG/7yHDN9Au7Un7lTQlUNwrdf4ynf879L4Sae9L6dyeUoQUR4QUAEYQUlAWRBQkhoACwBACigMCih/RQFGXXHmzxq1/3feUYTntKw/quFvW+p5hQk1bly770HdV1ZGuBxpc9Ie3aMLT233PMKF/p9T5cLpOZMd9Uvt9OZ6jsU/PhkjdKXsw+8AuqWN1JGW8Y3pASHFESAFgBCEFiSOiIBEEFACGEFAcEFD8quro0WWXflfVu7p9TxmSY+96Touvu8f3DFPGrX9dl1x5sxSn42zoWZ+/V7N+9ozvGab0bIzUtTYlJ+FjqePBSAO7fA+xZc+aSL2vpOM9jHuk9l/kUn0bspQjpDgipAAwgpCCRBFRUHIEFACGEFAcEFBsGL3hTX3w8u+bf0j5+HWv6ZKP/pBbQB3E9HvW65xr/9X3jCOa/eOndMbf3O97hkldT0bq2Wj/JPyexyP1brG/s+ziwSs7zMelotT+QKSBDt9DMo+Q4oiQAsAIQgoSQ0RBSRFQABhCQHFAQLHl6NUbdMnVP1S+x+bDGcave02/94HvqNDJ/YMO5ZS/e1inf/kB3zMO6di7ntPKj/0oNVfM+ND5sO2rGbqeitT9jN19vsV90u57c2ZDSjwgdTwUqW8776ERhBRHhBQARhBSkAgiCkqGgALAEAKKAwKKTXNue0ofOe+bqn/V1o8oH3vXc7rq7P+jxleMnpm0Io61+Lp7dPHVt5iLYaf9zwd06X/4niq7uH/Q4cT9Uvt9kbqfsnWSOx4YvMqia42tXRYVO6Vdd+TMxbBil7T7rpx6Xra1C4QUV4QUAEYQUlByRBSUBAEFgCEEFAcEFNsmPf6Krj7za2p+YovvKZJ+d/KdK1CG7rhb1pqJYfmefl189S06+3P3cBu2oYoHn6/R8VCkeMD3mLedfP8tJ9+HKu6zFcP6d0i7bs+pf4fvJTgEQoojQgoAIwgpKCkiCkaMgALAEAKKAwJKOjRsa9dHzvum5n9/jbcNVR09nHwfgf0xbMovN3nbMGpTmz5y3jd13C1rvW1Is54NkXb/a04Dnf429L3OyXdnb49hHi/A2vtipN135VTs8rcBQ0JIcURIAWAEIQUlY+PHcJBaBBQAhhBQHBBQ0mnriS26/wvLtfmM95Tl9XJ9A1r4zV/q9C89oNo395TlNYMWRXr+4rl64Ppl2jl9XFlesqatS6f/zf1a+K3HzN1W7EA3XX3F6t8smH+W7x2HE+Wl6lmxat8bK6oqz2sOtEtda9LxoPs0yFVLNfNj1cyOrMjMdwAAIABJREFUy/ajhX2vSnsez6n/jfK8Hkpml6Slbauix30PSZvRN8bXSLrB9w4AmbdJ0uK2VdFG30OQXnwHDmcEFACGEFAcEFBSLor00vkzdf8XLtAbsyck9jJzb31Si6//uZo27kzsNbKqWJnX2qtO1MPXnqs94+sTeY2Kvf066euP6NSvrFb17u5EXqPU0hBR9osKUu28WNVzY0X5ZF6j2C11PRlp7wuRVEzmNbIs3yDVLohVdUxyV9cN7JL2PB6ZeyYLhoWQ4oiQAsAIQgpGhO/i4ISAAsAQAooDAko44nxOz188V89fPE8vLZup3vqR/1j86N++qRl3rNO8H6zVhKe2lWAlDqe3vkpPX75AL1w4RxvPmqZixch/LH7Smi2D7+E/rVHj1t0lWFk+aYoo++XqpOrpsQqtsSpKcXFRUerbHqln8+AtxHzeeiorKsZIVdNiFabGyjeM/OvFfVLvlki9G6WeTZHEHRBDQEhxREgBYAQhBc6IKBg2AgoAQwgoDggo4RqoqtCmM4/R+pVz9eLy2eqY1DikPxcVYzWv3aoZtz+rGXes0/jnX5dizvj5sHdUjTacP0MvrJirDefNUE9j9ZD+XL6nX1MfeXnwPbxznRq2tSe8NDlpjChvl6uVCq2xqlqliolDv0Il7pV6t0bq3TT4e9yb7E4cWr5JqmodDCoVYzXkT83FPVLvK5F6N0t9r0aKBxKdCT8IKY4IKQCMIKTACREFw0JAAWAIAcUBASVb+msq1TmxQR3NjW/93tNYrfrXOlS/vUMN29tVv71ddTv2KBrgPkEW9dZXDb5/zY37fm/QQKFCDdt2q/7VDtVvb1fD9nbVtHUHE77SHlEOFFVJ+VopVxsrVzsYWeKiVOza/ytSsUtcbWJVNPj8lNzb38OawehV7JKK3dFb7yXRJDMIKY4IKQCMIKRg2IgoGDICCgBDCCgOCCgA0iC0iAIgSIQUR4QUAEYQUjAsI7/hMjKBgALAEAKKAwIKAABAyTRJunf0jfFC30PSpm1V9FVJn/S9A0DmTZX04Ogb46N9D0E6EFFwRAQUAIYQUBwQUAAAAEqOkOKIkALACEIKhoyIgsMioAAwhIDigIACAACQGEKKI0IKACMIKRgSIgoOiYACwBACigMCCgAAQOIIKY4IKQCMIKTgiIgoOCgCCgBDCCgOCCgAAABlQ0hxREgBYAQhBYdFRMG7EFAAGEJAcUBAAQAAKDtCiiNCCgAjCCk4JCIK3oGAAsAQAooDAgoAAIA3hBRHhBQARhBScFBEFLyFgALAEAKKAwIKAACAd4QUR4QUAEYQUvAuRBRIIqAAMIWA4oCAAgAAYAYhxREhBYARhBS8AxEFBBQAlhBQHBBQAAAAzCGkOCKkADCCkIK3EFEyjoACwBACigMCCgAAgFmEFEeEFABGEFIgiYiSaQQUAIYQUBwQUAAAAMwjpDgipAAwgpACIkpWEVAAGEJAcUBAAQAASA1CiiNCCgAjCCkZR0TJIAIKAEMIKA4IKAAAAKlDSHFESAFgBCElw4goGUNAAWAIAcUBAQUAACC1CCmOCCkAjCCkZBQRJUMIKAAMIaA4IKAAAACkHiHFESEFgBGElAwiomQEAQWAIQQUBwQUAACAYBBSHBFSABhBSMkYIkoGEFAAGEJAcUBAAQAACA4hxREhBYARhJQMIaIEjoACwBACigMCCgAAQLAIKY4IKQCMIKRkBBElYAQUAIYQUBwQUAAAAIJHSHFESAFgBCElA4gogSKgADCEgOKAgAIAAJAZhBRHhBQARhBSAkdECRABBYAhBBQHBBQAAIDMIaQ4IqQAMIKQEjAiSmAIKAAMIaA4IKAAAABkFiHFESEFgBGElEARUQJCQAFgCAHFAQEFAAAg8wgpjggpAIwgpASIiBIIAgoAQwgoDggoAAAA2IeQ4oiQAsAIQkpgiCgBIKAAMISA4oCAAgAAgAMQUhwRUgAYQUgJCBEl5QgoAAwhoDggoAAAAOAQCCmOCCkAjCCkBIKIkmIEFACGEFAcEFAAAABwBIQUR4QUAEYQUgJAREkpAgoAQwgoDggoAAAAGCJCiiNCCgAjCCkpR0RJIQIKAEMIKA4IKAAAABgmQoojQgoAIwgpKUZESRkCCgBDCCgOCCgAAABwREhxREgBYAQhJaWIKClCQAFgCAHFAQEFAAAAI0RIcURIAWAEISWFiCgpQUABYAgBxQEBBQAAACVCSHFESAFgBCElZYgoKUBAAWAIAcUBAQUAAAAlRkhxREgBYAQhJUWIKMYRUAAYQkBxQEABAABAQggpjggpAIwgpKQEEcUwAgoAQwgoDggoAAAASBghxREhBYARhJQUIKIYRUABYAgBxQEBBQAAAGVCSHFESAFgBCHFOCKKQQQUAIYQUBwQUAAAAFBmhBRHhBQARhBSDCOiGENAAWAIAcUBAQUAAACeEFIcEVIAGEFIMYqIYggBBYAhBBQHBBQAAAB4RkhxREgBYAQhxSAiihEEFACGEFAcEFAAAABgBCHFESEFgBGEFGOIKAYQUAAYQkBxQEABAACAMYQUR4QUAEYQUgwhonhGQAFgCAHFAQEFAAAARhFSHBFSABhBSDGCiOIRAQWAIQQUBwQUAAAAGEdIcURIAWAEIcUAIoonBBQAhhBQHBBQAAAAkBKEFEeEFABGEFI8I6J4QEABYAgBxQEBBQAAAClDSHFESAFgBCHFIyJKmRFQABhCQHFAQAEAAEBKEVIcEVIAGEFI8YSIUkYEFACGEFAcEFAAAACQcoQUR4QUAEYQUjwgopQJAQWAIQQUBwQUAAAABIKQ4oiQAsAIQkqZEVHKgIACwBACigMCCgAAAAJDSHFESAFgBCGljIgoCSOgADCEgOKAgAIAAIBAEVIcEVIAGEFIKRMiSoIIKAAMIaA4IKAAAAAgcIQUR4QUAEYQUsqAiJIQAgoAQwgoDggoAAAAyAhCiiNCCgAjCCkJI6IkgIACwBACigMCCgAAADKGkOKIkALACEJKgogoJUZAAWAIAcUBAQUhK1bmtbepRooi31PgKF9doYr6gu8ZGIGoUoryvldgJEYVpAo+SSNMhBRHhBQARhBSElLhe0BICCgADCGgOCCgIAhRpB0zx+vFC2Zr5/Rx6mxuVEdzgzqbG7VnXJ0URcr3Dqh+e7sa9v2q396u5ie2avrdz6umrcv3ESCKNG5hiyYvnaH6qWNU29yo2kmNqp00SoWmGklSf2evurbvVtf2dnVta1fX1t169aEN2r76JRV7BzwfAKK8VDkpVuVEKVcr5Wrjfb9L0b5PYHGvVOySil2Ril3SQKfUtzVS3xuSYq/zIamhUjqvRVowXppUK02slZrrpAk1UlVeKsbSm3ul7V2Dv17tkl7cLd2zWdrQ7ns9MCL7Q8rStlXR477HpEnbquiro2+MJekG31sAZNr+kLK4bVW00feYUPBjiCVCQAFgCAHFAQEFaRbnc9p6UovWr5yrF1bM0c7p45y+TjRQVOujL2vm7es04451GrW5rcRLcSi5yrwmnjVNrRcdp5YVc1Tb3Oj0dfra92rrz9dr0788o633PK++jp4SL03eTVdfsfo3C+af5XvHcEVVUmFKrKqpUuXk+K1YMlzFvVLv5ki9m6W+bZFimljZTKyVlrdKK6ZKpzdLBcerTV7YJd2xSbpzk/TkDpoYUmuXJEKKg9E3xteIkALAv02SCCklQkQpAQIKAEMIKA4IKEirYmVeaz96kh759BJ1Tmwo+ddvffi3WvLZuzX515tL/rUxqKKuoLnXLNKcPz1ThVE1Jf3axd4Bbbh5jZ78/M/VtT09PxqftoiSb5BqF8Sqek9c8k9Xcb+0d12krqcjxb2l/dr4nXljpM8ulJZMKf0H5M2d0pfWSj98afDqFSBlCCmOCCkAjCCklAgRZYQIKAAMIaA4IKAglaJIz11ynB687nznq06GY9bPntHZn7tbY17ckfhrZUWUz+nYq07S8X+xVDUTSh/A3q6/q0/rvvaQnvnb1epr35voa5VCWiJKrlqqmR+rZnac+JMm4x6p6zeR9j7PlSmlNKVeunaBdOk0KZfwJ+Nnd0rXPS7dtyXZ1wESQEhxREgBYAQhpQSIKCNAQAFgCAHFAQEFabT1xBbd+6WV2npSa1lfNxoo6n3f+Xctvu4enpsyQlPOn6WFX7xQo2YeVdbX3btjj37zV/fq+W/9Uort/ki8+YiSk2qOi1U7P1ZUWd6XHuiUuh6P1PMyH+NGoq5S+vTx0n+cM/h8k3JavU269lfSOu6WiHQhpDgipAAwgpAyQnz37YiAAsAQAooDAgrSaO3VJ+nuv71ExYqEf+z9MEZveFOXXfpdjVv/urcNqRVFet9nz9P8T5/jdcbmf3lGD6/6ofr32Lw/lOWIElVJjWfHqmz2G6H2Phep89eRVPQ6I5Va66Wbl0pzRvvbsHdA+sRD0k9f9rcBcEBIcURIAWAEIWUE/H0CTzECCgBDCCgOCChIm2JFTvd85SLd9bUPeA0oktQ2baxuWv0JvXT+TK870qairqCzf/gR7wFFklovOk4X3P8J1bd6PIucQvkmqWll0XtAkaTq2bFGnRcrqvK9JF1OnSD94iK/AUWSqvPSjWdLf76An2pEqjRJunf0jfFC30PSpm1V9FVJn/S9A0DmTZX04Ogb46N9D0kjIsowEVAAGEJAcUBAQdp0j67VD352tR7/2Gm+p7ylp6FKt/z4Kj12zSIp4hTgkdS3jtYF939CrSvn+p7yljHzmrXikT/TUacd7XtKKhSmxGq6sKh8so+vGZbK5n2b+LfZkFwxQ/rpBdK4at9Lfue/HC/dtESqrfC9BBgyQoojQgoAIwgpjogow0BAAWAIAcUBAQVp09NQpX+894+0cfF031PeLYp0318v14OfO8/3EtPqW0dr+eo/0Zh5zb6nvEv1uDqdf9cfqflsg3+/DClMjdW4tPzPPxmKfKPUtIKQciR/Mk/6uzOkgsFPvyuPlv55WfmfzQKMACHFESEFgBGEFAcGv420iYACwBACigMCCtImzuf0zzd9WG/MnuB7ymE9+qmz9exlx/ueYVJFXUFLbrtKNRMMXb5wgFwhr8X/9AdqmDbW9xSTKsZIDYv8377rcKKC1HhOkVt7HcL5LdJ1xk/1LjxqMPIAKUJIcURIAWAEIWWYiChDQEABYAgBxQEBBWl0/18u00vLZvmeMSS3f+ND2rawxfcMW6JIZ/7DhzX6OHtXoByo0FSjc277qAqNhu5zZECuWmo8t6goBbdayjdKjYtjPt0dYNZo6e8XS7kU3HXw0mnSJ+f7XgEMCyHFESEFgBGElGHg2+wjIKAAMISA4oCAgjR6+vIFeuyTi3zPGLKBqgr96JaPqGNSo+8pZrzvs+eZegbKkYyaeZQW/ePvK8rz8UCSorzUcE5RuTrfS4auclKsupNsXzVTTmOrpR+cK9UbvA3bofzFCdIFrb5XAMNCSHFESAFgBCFliPiUdBgEFACGEFAcEFCQRjtmHqU7v/5B3zOGrXNig37yvd/nQfOSppw/S/M/fY7vGcM2eelMvfcz6dudhNoTYlUe5XvF8NXMjlX1HkKKJH1jkTTV7p30DioXSd86S2qp970EGBZCiiNCCgAjCClDQEQ5BAIKAEMIKA4IKEirB/5ymQYK6XzC8JZTp+r5i9Nz9UUSonxOC794oe8Zzo77/xardtIo3zO8yjcMxoi0ql0YK0rnP0JK5twp0jlTfK9wU1cpXXuC7xXAsBFSHBFSABhBSDkCIspBEFAAGEJAcUBAQVptOXWqXrhwju8ZI/LA9ctUrMzuGdxjrzpJo2am8BKGffI1lTr+v5/ne4ZXtSek+9ki+XqpelZ6I9BI5SLpuhN9rxiZS6dJ88b4XgEMGyHFESEFgBGElMNI8ceDZBBQABhCQHFAQEFqRZF+8VcrfK8YsZ3Tx2ntVSk/g+mooq6g4/9iqe8ZIzb9ihPUNHuC7xleVIxTELfDqn1vrKjge4UfvzddmjPa94qRiSRdn81/jCL9CCmOCCkAjCCkHAIR5W0IKAAMIaA4IKAgzdavnKOtJ4fxROGH//xc9dZn7wzu3GsWqWZCyh7CcBBRPqcT/mq57xle1C1Mf0CRpKhKqp0XxrEMR1Ve+vMFvleUxuLJ0tmTfa8AnBBSHBFSABhBSDkIIso+BBQAhhBQHBBQkHaPXbPI94SS2XNUvZ7+cCBnMocoV5nXnD890/eMkpmybLaa5kz0PaOsKsZKlc3hhIfqOdl7Nsql06RJdb5XlM4n5/teADgjpDgipAAwgpByACKKCCgATCGgOCCgIO06JzRoSyBXoez3wspsPWB+4lnTVBhV43tGSU29+DjfE8qqMDWcgCJJUYVUOSmsYzqSlUf7XlBap02URlf5XgE4I6Q4IqQAMIKQ8jaZjygEFACGEFAcEFAQgheXz5aiyPeMktq46Bj1NFb7nlE2rReFFxxaMhbCqlrDCw6FsNrsYdVVSouafa8orXwkLcvQe4ggEVIcEVIAGEFI2SfTEYWAAsAQAooDAgpC8cKFc3xPKLliZV4bzp/pe0Z5RJFaVoT3Ho49frLqpmTjH6/5Bimf8oeRH0yhNR58SnkGnDtl8JkooVlOREH6EVIcEVIAGEFIUYYjCgEFgCEEFAcEFISit75KL5893feMRKy/MBtXMoxb2KLa5kbfMxLRmpGrUQoBXoUiSblqqXK87xXlsSLQ2LBkslQdYBxC5hBSHBFSABiR+ZCSyYhCQAFgCAHFAQEFIdl8xns0UFXhe0Yifrv0WN8TymLy0hm+JyRm0nnZuJqoMNn3guRUTg4zEB1oyRTfC5JRUzH4bBQgAIQUR4QUAEZkOqRkLqIQUAAYQkBxQEBBaHa3hPtXee+oGvXWh/9U5PqpY3xPSEx9a4D3uDqIXH24oSFX53tB8uorpTEB/6OmtcH3AqBkCCmOCCkAjMhsSMlURCGgADCEgOKAgIIQdQZ6G6j9OgI/PknB3spLkmonhXtsb5er9b0gOfmAj22/iYEfY+jHh8whpDgipAAwIpMhJTMRhYACwBACigMCCkIVemQIPRJJYYeGwqga5Wsqfc9IVFQ5+CtUudpwr7LZrznwyBD68SGTCCmOCCkAjMhcSMlERCGgADCEgOKAgIKQhR4ZQo9EklQT+DGGfKWNJOVqfC9IVshX2ewX+pUaoR8fMouQ4oiQAsCITIWU4CMKAQWAIQQUBwQUhK6jOeyb3XcGfnz56gpVjQ77DGftpFG+JyQq9MgQVUlR3veKZIV+pUbox4dMI6Q4IqQAMCIzISXoiEJAAWAIAcUBAQVZUKwM++zmQKHC94REVTZU+56QuEJj4MeYC/92V2F/6pMaCr4XJKsx8OND5hFSHBFSABiRiZAS7LfTBBQAhhBQHBBQkBX129t9T0hUw7bdvickKop8LyiDwI+x2BX2AcZ9g79CFvY7GP7xASKkOCOkADAi+JASZEQhoAAwhIDigICCLKl/tcP3hESFfnxIv2KX7wXJKnb7XgAAQ0JIcURIAWBE0CEluIhCQAFgCAHFAQEFWdMQ+JUooV9pg/SLe6V4wPeK5IQeiQAEhZDiiJACwIhgQ0pQEYWAAsAQAooDAgqyKPTIEHokQhhCDg2h364MQHAIKY4IKQCMCDKkBBNRCCgADCGgOCCgIKsatoUbGfI9/app415CsC/oiLLH9wIAGDZCiiNCCgAjggspQUQUAgoAQwgoDggoyLLWR1+W4tj3jERMfSTcY0NY+l4N92qNvtd8LwAAJ4QUR4QUAEYEFVJSH1EIKAAMIaA4IKAg6+pe79SUX232PSMRM25/1vcEYEh6N4UZUeJ+qW9bmMcGIBMIKY4IKQCMCCakpDqiEFAAGEJAcUBAAQbNuGOd7wmJmHFnmMeF8PS/GeZtr3q3RIoHfK8AgBEhpDgipAAwIoiQktqIQkABYAgBxQEBBfidmXeEd8XGpDVbgn7eC8LTuzm8KzZ6w7zIDUD2EFIcEVIAGJH6kJLKiEJAAWAIAcUBAQV4pzEv7tDYF97wPaOkQr26BuHqCS04xINXogBAIAgpjggpAIxIdUhJXUQhoAAwhIDigIACHNwJf/+Y7wklU7G3X/P+aY3vGcCw9L0aaWC37xWl0/PbSHGP7xUAUFKEFEeEFABGpDakpCqiEFAAGEJAcUBAAQ5twbcfU9PGnb5nlMRJX39EjVsDOhuNbChKe9YEcuVGUep6IpBjAYB3IqQ4IqQAMCKVISU1EYWAAsAQAooDAgpwePneAS2+/h7fM0aspq1Lp35lte8ZgJPeTZH6Xve9YuS6n4s00Ol7BQAkhpDiiJACwIjUhZRURBQCCgBDCCgOCCjA0My57Sk1r93qe8aInP4396t6d7fvGYCzrn9PxUekQ4p7pa7fcBUKgOARUhwRUgAYkaqQYv4TAgEFgCEEFAcEFGDoomKsJdfe5XuGs1Gb2rTwW+E82wXZ1Pe61Ls5vRGi62mehQIgMwgpjggpAIxITUgxHVEIKAAMIaA4IKAAw3f06g065YaHfM8YtnxPvz7wkZuV7+n3PQUYsc5HIxX3+F4xfH3bI3U/k94ABAAOCCmOCCkAjEhFSDEbUQgoAAwhoDggoADulnz2bk2/+3nfM4Zl5cdu06THX/E9AyiJ4l6p/Rc5xSlqggPtUvsDkVT0vQQAyo6Q4oiQAsAI8yHFZEQhoAAwhIDigIACjEw0UNQlV/1A49an4wnXp33lQc299UnfM4CS6t8pdT6cjqs64j6p/b4ct/ECkGWEFEeEFABGmA4p5iIKAQWAIQQUBwQUoDSqOnp02aXfVfUu2w9pP/au57T4unt8zwAS0bMxUtda+yGl48FIA7t8rwAA7wgpjggpAIwwG1JMRRQCCgBDCCgOCChAaY3e8KauWPYtNb5i8+zo7B8/pfdfebOiYux7CpCYrifthpS4X2q/P1LvFpv7AMADQoojQgoAI0yGFDMRhYACwBACigMCCpCMCU9v19Vn/m+1/NtG31Pe4ay//Lk+cOUPVNnV53sKkLiuJyN1PBCZekZKcY+0+86cejcRUADgAIQUR4QUAEaYCykmIgoBBYAhBBQHBBQgWXVvdOr3L/y23vu9x31PUWVXnz54+fd1xt/cL8VcgYLs6NkYafedORX3+F4i9b0m7fqXnPp3+l4CAGYRUhwRUgAYYSqkeI8oBBQAhhBQHBBQgPLI9/Trwo//WBdc81Nvz0lpXrtVVy75P5r1s2e8vD7gW//OwXjRu9nT1R9FqfvZSLvvzqm4188EAEgRQoojQgoAI8yEFK8RhYACwBACigMCClBmcawF3/6VPjH3SzrlhoeU7ynPvYWaXt6p91/1A3100f/WhKe3l+U1AauKe6X2+wavSul7vXyv2/NypLaf5LTn15FULN/rAkDKEVIcEVIAGGEipHiLKAQUAIYQUBwQUAB/qnd165xr79LH3/s/Nf+f1iR2W63aN/fovE/dro8t+Irm/Og3PEAeeJu+1wefSdJ+X6SB3Qm+zvZIu27PqePBSAMdyb0OAASMkOKIkALACO8hpcLHixJQABhCQHFAQAFsaHxll1b+px/pzL++T+tXztELF87VK6cdrTjnfquhqva9OvZfn9OMO9Zp2s/Xq9DZW8LFQHh6N0fq3RKpcmKsqlap0BorVzeyr9nfJvVuitS7OVL/m6XZCQAZtz+kLG1bFfl/yFyKtK2Kvjr6xliSbvC9BUCm7Q8pi9tWRRvL/eJljygEFACGEFAcEFAAe5o27tTJX3tEJ3/tEXWNrdNLF8zSi8tna+e0sepsblTX2IOf0c31Daj+1Q41vNqh5jWvaObt69T66MvK9Q2U+QiAlCtKfdsi9W2T9FikirGDMaVy4mBQydVKUf7gfzTulYpd0sCeSH1bB6MMV5wAQCIIKY4IKQCM8BZSyhpRCCgADCGgOCCgAPbVvrlH87+/RvO/v+at/26gkNeeCQ3qaG5UT2O16l7rUMP2dtXs7OIWXUAC+t+U+t+MJP3uqrCoMBhTcrWxVIxU7BqMJ3F5Hm0EABhESHFESAFghJeQUrZnohBQABhCQHFAQAHSK987oMZXdmnyrzfrmF+8oAlPb1ftjj0EFKCM4l5pYNe+K1ZelQbaCSgA4AnPSHHEM1IAGFH2Z6SUJaIQUAAYQkBxQEABAAAAEBBCiiNCCgAjyhpSEo8oBBQAhhBQHBBQAAAAAASIkOKIkALAiLKFlEQjCgEFgCEEFAcEFAAAAAABI6Q4IqQAMKIsISWxiEJAAWAIAcUBAQUAAABABhBSHBFSABiReEhJJKIQUAAYQkBxQEABAAAAkCGEFEeEFABGJBpSSh5RCCgADCGgOCCgAAAAAMggQoojQgoAIxILKSWNKAQUAIYQUBwQUAAAAABkGCHFESEFgBGJhJSSRRQCCgBDCCgOCCgAAAAAQEhxRUgBYETJQ0pJIgoBBYAhBBQHBBQAAAAAeAshxREhBYARJQ0pI44oBBQAhhBQHBBQAAAAAOBdCCmOCCkAjChZSBlRRCGgADCEgOKAgAIAAAAAh0RIcURIAWBESUKKc0QhoAAwhIDigIACAAAAAEdESHFESAFgxIhDilNEIaAAMISA4oCAAgAAAABDRkhxREgBYMSIQsqwIwoBBYAhBBQHBBQAAAAAGDZCiiNCCgAjnEPKsCIKAQWAIQQUBwQUAAAAAHBGSHFESAFghFNIGXJEIaAAMISA4oCAAgAAAAAjRkhxREgBYMSwQ8qQIgoBBYAhBBQHBBQAAAAAKBlCiiNCCgAjhhVSjhhRCCgADCGgOCCgAAAAAEDJEVIcEVIAGDHkkHLYiEJAAWAIAcUBAQUAAAAAEkNIcURIAWDEkELKISMKAQWAIQQUBwQUAAAAAEgcIcURIQWAEUcMKQeNKAQUAIYQUBwQUAAAAACgbAgpjggpAIw4bEh5V0QhoAAohaLUAAAgAElEQVQwhIDigIACAAAAAGVHSHFESAFgxCFDyjsiCgEFgCEEFAcEFAAAAADwhpDiiJACwIiDhpS3IgoBBYAhBBQHBBQAAAAA8I6Q4oiQAsCId4WUnERAAWAKAcUBAQUAAAAAzCCkOCKkADDiHSElR0ABYAgBxQEBBQAAAADMIaQ4IqQAMOKtkJKTdJMIKAD8+ykBZfhuqvlUpaRbRUABAAAAAGuaJN06+sa40veQtNkXUn7qeweAzJsq6aacpKskbfK7BQD0/ptqPnWN7xFpc1X3l/skXSZpl+8tAAAAAIB32CXpsrZVUZ/vIWkz+sb4Gknv970DQOZtknRV7qruL2+UtFiEFAD+3UBIGb6rur/8uKSlIqQAAAAAgBW7JC1tWxU97ntI2uwLKDf43gEg8zZJWty2KtqYkyRCCgBDCCkOCCkAAAAAYAYBxREBBYARbwUUScrt/28JKQAMIaQ4IKQAAAAAgHcEFEcEFABGvCOgSG+LKBIhBYAphBQHhBQAAAAA8IaA4oiAAsCIdwUU6YCIIhFSAJhCSHFASAEAAACAsiOgOCKgADDioAFFOkhEkQgpAEwhpDggpAAAAABA2RBQHBFQABhxyIAiHSKiSIQUAKYQUhwQUgAAAAAgcQQURwQUAEYcNqBIh4koEiEFgCmEFAeEFAAAAABIDAHFEQEFgBFHDCjSESKKREgBYAohxQEhBQAAAABKjoDiiIACwIghBRRpCBFFIqQAMIWQ4oCQAgAAAAAlQ0BxREABYMSQA4o0xIgiEVIAmEJIcUBIAQAAAIARI6A4IqAAMGJYAUUaRkSRCCkATCGkOCCkAAAAAIAzAoojAgoAI4YdUKRhRhSJkALAFEKKA0IKAAAAAAwbAcURAQWAEU4BRXKIKBIhBYAphBQHhBQAAAAAGDICiiMCCgAjnAOK5BhRJEIKAFMIKQ4IKQAAAABwRAQURwQUAEaMKKBII4goEiEFgCmEFAeEFAAAAAA4JAKKIwIKACNGHFCkEUYUiZACwBRCigNCCgAAAAC8CwHFEQEFgBElCShSCSKKREgBYAohxQEhBQAAAADeQkBxREABYETJAopUoogiEVIAmEJIcUBIAQAAAAACiisCCgAjShpQpBJGFImQAsAUQooDQgoAAACADCOgOCKgADCi5AFFKnFEkQgpAEwhpDggpAAAAADIIAKKIwIKACMSCShSAhFFIqQAMIWQ4oCQAgAAACBDCCiOCCgAjEgsoEgJRRSJkALAFEKKA0IKAAAAgAwgoDgioAAwItGAIiUYUSRCCgBTCCkOCCkAAAAAAkZAcURAAWBE4gFFSjiiSIQUAKYQUhwQUgAAAAAEiIDiiIACwIiyBBSpDBFFIqQAMIWQ4oCQAgAAACAgBBRHBBQARpQtoEhliigSIQWAKYQUB4QUIL1yhbzqW0dr/MlTNencGRozf5Kqx9dLUeR7GpAZowrSzCbprEnS6ROlaY1STYXvVQCQSQQURwQUAEaUNaBIUlm/bb+q+8sbb6r51GJJD0qaWs7XBoAD3HBTzad0VfeXv+p7SJpc1f3lx2+q+dRSSfdKavK9B8C7FZpq1LJ8tqZcMFuNM45SbXOjqsfWHjSYFHsH1P1ah7q27daOx1/R5tuf1WuPvqx4oOhhORCO48ZIK6YOxpLJ9dLEmkMHk/Ze6dUuaVOndP8W6c7N0pbO8u4FgAwhoDgioAAwouwBRSpzRJEIKQBMIaQ4IKQA9tROGqXWi+aq9aLjNPGMYxRVDO1i41whr7qWJtW1NGn8yVM1+xNnqGdnl7bc9Zw23/6Mtt67XgN7+xNeD6RfLpJOnSAtnyotb5WmNgz9zzYWBn/NaJKWTpH+xynSU29Kd22Sbt8kPdeW3G4AyBgCiiMCCgAjvAQUqYy383o7bu0FwBBu7eWAW3sBNtQcVa9T/u4D+tDz/00n/69L1Lx4+pADyqFUjanVtCtO0Nm3XKkPPPsZzfjoyYryXr5lBFJhyWTpwYul25dLfzx3eAHlUOaPlT6zQHr0/dIPl0qzRo/8awJAxhFQHBFQABjhLaBIniKKREgBYAohxQEhBfCnor6g469dqg888xnN/MNTRhxODqW2uVGnfv2DuujX/1kty+ck8hpAWs0fK/10mXTb+YO370rKeS3Sw5dIXztDaq5N7nUAIGAEFEcEFABGeA0okseIIhFSAJhCSHFASAHK75jfe58+8PSn9d5rl6qivlCW12yaPUFLbrtKy37+MTVOH1eW1wSsaixI3zhLeuDiwYfEl0M+kn5/hrTmUunT7xv8zwCAISGgOCKgADDCe0CRPEcUiZACwBRCigNCClAeUT6nE794oc78hw+rZkIJ7hfkYMIZx2jFQ3+q5iXHenl9wLdpjdIvVkqXTZN8dIzq/GBE+eHSwZgDADgsAoojAgoAI0wEFMlARJEIKQBMIaQ4IKQAySo0Vuucn3xUc/5ske8pKjTVaOk/r9LsPz7d9xSgrBZPlu5dKU0f5XuJdM6UwS3HNPpeAgBmEVAcEVAAGGEmoEhGIopESAFgCiHFASEFSEbDtLFavvpPNHnpTN9T3hJV5HTSVy7WqV//oHKVed9zgMT90RzpR+dJTVW+l/zOsaMGr4op1y3FACBFCCiOCCgAjDAVUCRDEUUipAAwhZDigJAClFZtc6OW/fyPNWrmUb6nHNSMj56s0/7vpb5nAIn6oznS/zjF5nNImqqkW86TTpngewkAmEFAcURAAWCEuYAiGYsoEiEFgCmEFAeEFKA08tUVOvvWK1XbbPt+PdMuX6Dj/v/FvmcAiVg8WfrCyb5XHF4hJ33vHKml3vcSAPCOgOKIgALACJMBRTIYUSRCCgBTCCkOCCnAyJ3+jcs07oQW3zOGZMH1F2jKBbN9zwBKatoo6Ttn27wC5UDjqqWbz5VqK3wvAQBvCCiOCCgAjDAbUCSjEUUipAAwhZDigJACuJv3X5foPZcd73vGkEW5SItuulxNs7mnEMIwqiD94NzB39Ni7hjpm2dJKWg+AFBqBBRHBBQARpgOKJLhiCIRUgCYQkhxQEgBhm/cwhYt+Nz5vmcMW2VDlc76/hWK8qa/vQSG5IunSNNH+V4xfCumSqu4KAxAthBQHBFQABhhPqBIxiOKREgBYAohxQEhBRiehX+9QorS+bPkTbMn6NgrT/Q9AxiR+WOly6b7XuHuv75Pqq/0vQIAyoKA4oiAAsCIVAQUKQURRSKkADCFkOKAkAIMTcuKOZpwxjG+Z4zI8X+xVBV1KboHEnCA609M9y2xxlVL18z3vQIAEkdAcURAAWBEagKKlJKIIhFSAJhCSHFASAEOL8rndMLnl/ueMWI1Exs1988W+Z4BOFkyWTprku8VI/fxudLEWt8rACAxBBRHBBQARqQqoEgpiigSIQWAKYQUB4QU4NCm/8FCjZp1lO8ZJTH3k2epeny97xnAsOQi6bpA7kZXUyH9twW+VwBAIggojggoAIxIXUCRUhZRJEIKAFMIKQ4IKcDBzf746b4nlExlQ5WmX3GC7xnAsJw6QTpujO8VpfMfpvNsFADBIaA4IqAAMCKVAUVKYUSRCCkATCGkOCCkAO9Uf/QYjT6u2feMkmpZeZzvCcCwLJ/qe0FpFXLS0im+VwBAyRBQHBFQABiR2oAipTSiSIQUAKYQUhwQUoDfaV051/eEkht/UqtqjuKWXkiP5a2+F5TeisDCEIDMIqA4IqAAMCLVAUVKcUSRCCkATCGkOCCkAINCjChRLlLLivCOC2E6bow0tcH3itJb2jJ4RQoApBgBxREBBYARqQ8oUsojikRIAWAKIcUBIQVZVzW2TkederTvGYlouYiIgnQI9YqNhkrpjLDuFAggWwgojggoAIwIIqBIAUQUiZACwBRCigNCCrJswunvUZQP4luyd5l45jTfE4AhOX2i7wXJIaIASCkCiiMCCgAjggkoUiARRSKkADCFkOKAkIKsqps8yveExFTUVqrQVON7BnBEk+p8L0hOyMcGIFgEFEcEFABGBBVQpIAiikRIAWAKIcUBIQVZVDsp3IgihX98CENzre8FyQn52AAEiYDiiIACwIjgAooUWESRCCkATCGkOCCkIGtqmht9T0hU7aSwjw/pN6og1VT4XpEcIgqAFCGgOCKgADAiyIAiBRhRJEIKAFMIKQ4IKciS2tAjSuDHh/SbGHhkCP34AASDgOKIgALAiGADihRoRJEIKQBMIaQ4IKQgK2omNviekKjQr7RB+oUeGeorpbpK3ysA4LAIKI4IKACMCDqgSAFHFImQAsAUQooDQgqyoKKu4HtCoiprwz4+pF9twLfy2i8LxwggtQgojggoAIwIPqBIgUcUiZACwBRCigNCCgAAABAkAoojAgoAIzIRUKQMRBSJkALAFEKKA0IKAAAAEBQCiiMCCgAjMhNQpIxEFImQAsAUQooDQgoAAAAQBAKKIwIKACMyFVCkDEUUiZACwBRCigNCCgAAAJBqBBRHBBQARmQuoEgZiygSIQWAKYQUB4QUAAAAIJUIKI4IKACMyGRAkTIYUSRCCgBTCCkOCCkAAABAqhBQHBFQABiR2YAiZTSiSIQUAKYQUhwQUgAAAIBUIKA4IqAAMCLTAUXKcESRCCkATCGkOCCkAAAAAKYRUBwRUAAYkfmAImU8okiEFACmEFIcEFIAAAAAkwgojggoAIwgoOyT+YgiEVIAmEJIcUBIAQAAAEwhoDgioAAwgoDyNkSUfQgpAAwhpDggpAAAAAAmEFAcEVAAGEFAOQAR5W0IKQAMIaQ4IKQAAAAAXhFQHBFQABhBQDkIIsoBCCkADCGkOCCkAAAAAF4QUBwRUAAYQUA5BCLKQRBSABhCSHFASAEAAADKioDiiIACwAgCymEQUQ6BkALAEEKKA0IKAAAAUBYEFEcEFABGEFCOgIhyGIQUAIYQUhwQUgAAAIBEEVAcEVAAGEFAGQIiyhEQUgAYQkhxQEgBAAAAEkFAcURAAWAEAWWIiChDQEgBYAghxQEhBQAAAPh/7N15rGb3Xd/xbxYT7IQEEmiwCwlIBJQ2DWVR1SqVChQiGoREF1ChUDkISguVilSlomUJbQqlNZUIBYJUtZimNKRAFbLY2RzHMUkb4tjOYsdJbMceLzOO97E9iz0zt3/MxBnbs9z7vc/znM/5nddLsu5fvs/n6FzZd857zjkrJaA0CShACAFlB0SUbRJSgCBCSoOQAgAAKyGgNAkoQAgBZYdElB0QUoAgQkqDkAIAALsioDQJKEAIAaVBRNkhIQUIIqQ0CCkAANAioDQJKEAIAaVJRGkQUoAgQkqDkAIAADsioDQJKEAIAWUXRJQmIQUIIqQ0CCkAALAtAkqTgAKEEFB2SUTZBSEFCCKkNAgpAABwRgJKk4AChBBQVkBE2SUhBQgipDQIKQAAcEoCSpOAAoQQUFZERFkBIQUIIqQ0CCkAAPAEAkqTgAKEEFBWSERZESEFCCKkNAgpAABQVQJKm4AChBBQVkxEWSEhBQgipDQIKQAALJyA0iSgACEElDUQUVZMSAGCCCkNQgoAAAsloDQJKEAIAWVNRJQ1EFKAIEJKg5ACAMDCCChNAgoQQkBZIxFlTYQUIIiQ0iCkAACwEAJKk4AChBBQ1kxEWSMhBQgipDQIKQAADE5AaRJQgBACygaIKGsmpABBhJQGIQUAgEEJKE0CChBCQNkQEWUDhBQgiJDSIKQAADAYAaVJQAFCCCgbJKJsiJACBBFSGoQUAAAGIaA0CShACAFlw0SUDRJSgCBCSoOQAgDAzAkoTQIKEEJAmYCIsmFCChBESGkQUgAAmCkBpUlAAUIIKBMRUSYgpABBhJQGIQUAgJkRUJoEFCCEgDIhEWUiQgoQREhpEFIAAJgJAaVJQAFCCCgTE1EmJKQAQYSUBiEFAIBwAkqTgAKEEFACiCgTE1KAIEJKg5ACAEAoAaVJQAFCCCghRJQAQgoQREhpEFIAAAgjoDQJKEAIASWIiBJCSAGCCCkNQgoAACEElCYBBQghoIQRUYIIKUAQIaVBSAEAYGICSpOAAoQQUAKJKGGEFCCIkNIgpAAAMBEBpUlAAUIIKKFElEBCChBESGkQUgAA2DABpUlAAUIIKMFElFBCChBESGkQUgAA2BABpUlAAUIIKOFElGBCChBESGkQUgAAWDMBpUlAAUIIKDMgooQTUoAgQkqDkAIAwJoIKE0CChBCQJkJEWUGhBQgiJDSIKQAALBiAkqTgAKEEFBmRESZCSEFCCKkNAgpAACsiIDSJKAAIQSUmRFRZkRIAYIIKQ1CCgAAuySgNAkoQAgBZYZElJkRUoAgQkqDkAIAQJOA0iSgACEElJkSUWZISAGCCCkNQgoAADskoDQJKEAIAWXGRJSZElKAIEJKg5ACAMA2CShNAgoQQkCZORFlxoQUIIiQ0iCkAABwFgJKk4AChBBQBiCizJyQAgQRUhqEFAAATkNAaRJQgBACyiBElAEIKUAQIaVBSAEA4EkElCYBBQghoAxERBmEkAIEEVIahBQAAE4QUJoEFCCEgDIYEWUgQgoQREhpEFIAABZPQGkSUIAQAsqARJTBCClAECGlQUgBAFgsAaVJQAFCCCiDElEGJKQAQYSUBiEFAGBxBJQmAQUIIaAMTEQZlJACBBFSGoQUAIDFEFCaBBQghIAyOBFlYEIKEERIaRBSAACGJ6A0CShACAFlAUSUwQkpQBAhpUFIAQAYloDSJKAAIQSUhRBRFkBIAYIIKQ1CCgDAcASUJgEFCCGgLIiIshBCChBESGkQUgAAhiGgNAkoQAgBZWFElAURUoAgQkqDkAIAMHsCSpOAAoQQUBZIRFkYIQUIIqQ0CCkAALMloDQJKEAIAWWhRJQFElKAIEJKg5ACADA7AkqTgAKEEFAWTERZKCEFCCKkNAgpAACzIaA0CShACAFl4USUBRNSgCBCSoOQAgAQT0BpElCAEAIKIsrSCSlAECGlQUgBAIgloDQJKEAIAYWqElEoIQWIIqQ0CCkAAHEElCYBBQghoPA4EYWqElKAKEJKg5ACABBDQGkSUIAQAgpPIKLwOCEFCCKkNAgpAACTE1CaBBQghIDCU4goPIGQAgQRUhqEFACAyQgoTQIKEEJA4ZREFJ5CSAGCCCkNQgoAwMYJKE0CChBCQOG0RBROSUgBgggpDUIKAMDGCChNAgoQQkDhjEQUTktIAYIIKQ1CCgDA2gkoTQIKEEJA4axEFM5ISAGCCCkNQgoAwNoIKE0CChBCQGFbRBTOSkgBgggpDUIKAMDKCShNAgoQQkBh20QUtkVIAYIIKQ1CCgDAyggoTQIKEEJAYUdEFLZNSAGCCCkNQgoAwK4JKE0CChBCQGHHRBR2REgBgggpDUIKAECbgNIkoAAhBBRaRBR2TEgBgggpDUIKAMCOCShNAgoQQkChTUShRUgBgggpDUIKAMC2CShNAgoQQkBhV0QU2oQUIIiQ0iCkAACclYDSJKAAIQQUdk1EYVeEFCCIkNIgpAAAnJaA0iSgACEEFFZCRGHXhBQgiJDSIKQAADyFgNIkoAAhBBRWRkRhJYQUIIiQ0iCkAAA8TkBpElCAEAIKKyWisDJCChBESGkQUgAABJQuAQUIIaCwciIKKyWkAEGElAYhBQBYMAGlSUABQggorIWIwsoJKUAQIaVBSAEAFkhAaRJQgBACCmsjorAWQgoQREhpEFIAgAURUJoEFCCEgMJaiSisjZACBBFSGoQUAGABBJQmAQUIIaCwdiIKayWkAEGElAYhBQAYmIDSJKAAIQQUNkJEYe2EFCCIkNIgpAAAAxJQmgQUIISAwsaIKGyEkAIEEVIahBQAYCACSpOAAoQQUNgoEYWNEVKAIEJKg5ACAAxAQGkSUIAQAgobJ6KwUUIKEERIaRBSAIAZE1CaBBQghIDCJEQUNk5IAYIIKQ1CCgAwQwJKk4AChBBQmIyIwiSEFCCIkNIgpAAAMyKgNAkoQAgBhUmJKExGSAGCCCkNQgoAMAMCSpOAAoQQUJiciMKkhBQgiJDSIKQAAMEElCYBBQghoBBBRGFyQgoQREhpEFIAgEACSpOAAoQQUIghohBBSAGCCCkNQgoAEERAaRJQgBACClFEFGIIKUAQIaVBSAEAAggoTQIKEEJAIY6IQhQhBQgipDQIKQDAhASUJgEFCCGgEElEIY6QAgQRUhqEFABgAgJKk4AChBBQiCWiEElIAYIIKQ1CCgCwQQJKk4AChBBQiCaiEEtIAYIIKQ1CyjYd25p6wVptOb7ZG/0YBz+8qqraGvwYRz+Hox/fCggoTQIKEEJAIZ6IQjQhBQgipDQIKWd3+L4DU09Yq0P3PjL1hLU6/MDB4SPD4cHP4X2Hp16wXse2qu4f/BhHP77Rf0Z3SUBpElCAEAIKsyCiEE9IAYIIKQ1Cypkd2Lt/6glrdXDw49s6cqwO3TN2ZBj9Z3Tf2B2z7jlUdXTszld7Bz+Hox/fLggoTQIKEEJAYTZEFGZBSAGCCCkNQsrpjX6BevTjq6o6uPfBqSesz9ZWHdz30NQr1uquA1UjN4YlXIAfPYSNfnxNAkqTgAKEEFCYFRGF2RBSgCBCSoOQcmoH7hz4AnyNf3xVVQfuHDcUHbrnkTr22NGpZ6zVo8eq7j009Yr12Tv2jVJVNX4oWsI53CEBpUlAAUIIKMyOiMKsCClAECGlQUh5qtEfd7WEO1FGPsaRj+1kI/9N/5GP7QtGP8bRj2+HBJQmAQUIIaAwSyIKsyOkAEGElAYh5Yke/MzdU09Ym4f33F/HHh37Loaqsc/h/s+Oe2wnu3HgG6ZuXEAHO3y06raHp16xPks4h9skoDQJKEAIAYXZElGYJSEFCCKkNAgpX3T3n++pw/eO+ayW2y/51NQTNuL2S66fesLa3LaQc/iu26ZesD7v3DP1gs0Y9Rzec6jqqs9PvSKCgNIkoAAhBBRmTURhtoQUIIiQ0iCkHLd19NiwF6r3vO2TU0/YiP033lMP3jDeVc6tI8cWE8LedVvVkWNTr1i9Tz9QdfNC7mJ4x6B/InjXbVVHt6ZeMTkBpUlAAUIIKMyeiMKsCSlAECGlQUg5bs9bx4sNh+8/UPuuvHnqGRsz4jnc94Gb6tEHD049YyMeOFz1wX1Tr1i9ty/oN+QP7jt+HkczahzaAQGlSUABQggoDEFEYfaEFCCIkNIgpFTdedln6sgjj049Y6Vuv/SG2hrxr/afxp63XTf1hJUb8ZjO5JIBH3t1yYJ+Oz5yrOrdt0+9YrUOHKm6/I6pV0xKQGkSUIAQAgrDEFEYgpACBBFSGpYeUo4eOlK3v3Osxybd+n8+PvWEjbrn6tvr4Vvvn3rGymwdOba4iPL2W8Z6pNetD1Vdc8/UKzbrTz839YLVetdtVYePTr1iMgJKk4AChBBQGIqIwjCEFCCIkNKw9JDysV99b20dHeMK7r1X3163XTpWFDqrra362K++Z+oVK/OZ3/twHbjzwalnbNTeA1Vv/MzUK1bnP1079YLNe+eeqmsHCUdHt6ouWuA5PEFAaRJQgBACCsMRURiKkAIEEVIalhxSHvjUXXXj//zo1DNW4qqff0fV1vLehHzTH3y07v/k3qln7NqRhx+ta//9OEFoJ37tmqpHHpt6xe5dd1/Vm2+cesXmbVXVL39k6hWr8abPVt0wzs1tOyGgNAkoQAgBhSGJKAxHSAGCCCkNSw4p177u3XX04Lyv4N7x7htq3xU3TT1jElvHtuqjv3Dp1DN27ZOvv6IO3f3w1DMmcffBqt/65NQrdu+Xr6o6tryOWVVVH9hbddnM341y8EjVf7h66hWTEFCaBBQghIDCsEQUhiSkAEGElIalhpQDdz5Y1//Wn009o23r2FZd9W8umXrGpO549w219/L53gJw8K6H6rrfuGLqGZP6rU9Wff7g1Cv6rrhz/hFht177kXlHpDdcd/zxcgsjoDQJKEAIAYWhiSgMS0gBgggpDUsNKZ/4z5fXw7fcN/WMlht+94P1wPX7pp4xuY/8q7fO9o6iq37u7XXkkUennjGpRx6r+sU/n3pFz8EjVT//4alXTO/6+6v+60xfy3TrQ1Wv//jUKzZOQGkSUIAQAgrDE1EYmpACBBFSGpYYUh7bf6gu+wcX12MPHZ56yo7su+Km+sjPvX3qGRHuv25f/dlP/e+pZ+zYda//QN385mumnhHhj26q+p0ZPtbrZ648HhA4HsKunNkrih5+rOqH31v10DwbbJeA0iSgACEEFBZBRGF4QgoQREhpWGJIeeD6fXXlq99UWzN5Hs1DN99b7/+RN9bWkWNTT4lxyx9/rD7+a5dNPWPb7nj3DfXRn3/H1DOivPYjVe+d0WOxLrq26i2fm3pFjiPHql79vqpbHpp6yfYc26r6J1cs7mXyAkqTgAKEEFBYDBGFRRBSgCBCSsMSQ8ptl1xf1/zyO6eecVaP7T9U7/vBi+vw/ct7gP/ZXPO6d9etf5p/O8ODN3y+rvjH/2s20W5Tjm5V/cT7qz774NRLzu5tt1T92jJfRH5G9x2u+uH3HL/DI93rPlr1zj1Tr9goAaVJQAFCCCgsiojCYggpQBAhpWGJIeUTv355ffbi3JczHD34WF3xY39QD3zqrqmnZNraqj/7iT+su/8898rogb3767If/L16bP+hqadE2v/o8Yvw+4Ib4VWfr/pnH6iSwE7t0w9UvfryqsNHp15yev/j04t7D4qA0iSgACEEFBZHRGFRhBQgiJDSsMSQ8qGf/uO6+pcujbtL4MDe/XXp97yh7njPp6eeEu3II4/Wu773dyPfNXLPVbfV21/xm/XQTfdOPSXazfurvuutVdfcM/WSp/qjm6q+/9KqA0emXpLtsturXvWOvBh2bKvq315V9bMfnHrJRgkoTQIKEEJAYZFEFBZHSAGCCCkNSwwpn/j1y+vyH/r9mJfNf+Hi+71Xz+iFERM6euhIXfnqNweZheAAACAASURBVNXVr720aisjht38h9fUO1/5hjq4b//UU2Zh34HjF+H/5Oaplxx3bKvq311V9VNXZN9hkeSae7Ji2MOPVf2j97oDhe0RUIAQAgqLJaKwSEIKEERIaVhiSLntkuvrku/87Xr4lvsm3XHzm1187/rERZfX+37o9+vIw49ON2Jrq67+pUvryh9/Ux095PaFnTh8tOon31/1uqumfXTWw49V/ehlVb+xrIvvK5ESw259qOqVb696123T7tgwAaVJQAFCCCgs2jOmHgBTecuRDz3wA+e84i1V9Xer6sun3gMs2vf+wDmveOAtRz704amHzMlbjnzozh845xWXVdUPVdWXTr1nEw7d/XDd+Marqo5t1Vd+69fU08/Z3K9y+z97d/3ff/4n9fH/+L7aOnJsY587mv2fvbs+9+Zr6ktf8Oz6ipd9ddXTnraxz77rypvrih/7g7rljz+2sc/suPZbXn7rXee/8Oum3nE6/++uqvfeXvUNz6v62uds7nO36vjjuy58X9XVd2/uc0dzdKvqbbdUXX9/1ctfUPX8Z23usw8eqfovn6j6p1dU3fnI5j43gIDSJKAAIQQUFm9zf2qDUBef+5qvq6r3V9WLp10CUD974cGLXj/1iLm5+NzXfHtVvacWFsTPu+B59Vd/8ZX1DT/6bfW0Z6zv5uJDdz9c1/7Ke+oz//3D4smKPf+b/2J9+6+8qs7/rpes9XMe+NRd9dFfuKRuv/RTa/2cVbn4x3/0io9968v/1tQ7tuN7X1T12m+v+qY1/9fn/XdUvfYjVZ+Y9ka04Tzz6VUXflPVa76l6qvWmOKPblW96bNVv3p13ntZNkBAaRJQgBACCpSIAlUlpABRhJSGpYaUqqovf+kL65v/9XfX1/ydl9Yzn/0lK/u+D++5v25641V13W9+IOZdLKO64Lu/sf7Kv/zOeuHf/PqVBrH7PrG3bnjDB+vGN15VW0fnE8DmFFGqqp7xtKofeUnVT/6lqpc9f3Xf98ixqg/ddfydGZffsbrvy1M955yqn3nZ8fO4yruLDhw5/siui66tuuH+1X3fGRFQmgQUIISAAieIKHCCkAIEEVIalhxSqqqece45dcF3vaRe9P0vq6/9vpfWs17w7B1/j/s/ubf2vPW62vO26+q+j7lqu2nPev559TWvemm96PtfVhf87W+sZ553zo7+/a2jx+rzH7ql9rztutrztk/Ww7fO86rt3CLKyV70nKrve3HVq15c9ddfeDyw7MTBI1Xvu6Pqkj1V79xTdb9+uXEvf8Hx8/d9L6r6y40odu+h4+fuHXuOx6/DR1e/cSYElCYBBQghoMBJRBQ4iZACBBFSGpYeUr7gac94en3VX3tRPfclX1nnnf+8Ou+C59Z55z+3zj3/uXXOl31pHfr8Q3Xgzv11YO/xfw7u3V93f2TP5C+t54uece459cJXfH0958XPr/POf26dd8Hx83feBc+rpz/z6XVw7xfP34E7H6wDdzxYd33wc3X4vvk/K2jOEeVkz39W1d/46qoLnl11/nlVX33eF78+dqxq74Hjj3b6wtc9D1V9aF/VoeVedI/z4i+r+raveuK5O/+8qr9wbtVDj510Dh85/vXG/VVXff7447sWTkBpElCAEAIKPImIAk8ipABBhJQGIQXmbZSIAgsloDQJKEAIAQVOYX1vIYWZuvDgRbdU1XfU8f9xAEzpNy4+9zX/YuoRc3PhwYuuqqrvqeMXcgCAzRBQmgQUIISAAqchosApCClAECGlQUgBgI0SUJoEFCCEgAJnIKLAaQgpQBAhpUFIAYCNEFCaBBQghIACZyGiwBkIKUAQIaVBSAGAtRJQmgQUIISAAtsgosBZCClAECGlQUgBgLUQUJoEFCCEgALbJKLANggpQBAhpUFIAYCVElCaBBQghIACOyCiwDYJKUAQIaVBSAGAlRBQmgQUIISAAjskosAOCClAECGlQUgBgF0RUJoEFCCEgAINIgrskJACBBFSGoQUAGgRUJoEFCCEgAJNIgo0CClAECGlQUgBgB0RUJoEFCCEgAK7IKJAk5ACBBFSGoQUANgWAaVJQAFCCCiwSyIK7IKQAgQRUhqEFAA4IwGlSUABQggosAIiCuySkAIEEVIahBQAOCUBpUlAAUIIKLAiIgqsgJACBBFSGoQUAHgCAaVJQAFCCCiwQiIKrIiQAgQRUhqEFACoKgGlTUABQggosGIiCqyQkAIEEVIahBQAFk5AaRJQgBACCqyBiAIrJqQAQYSUBiEFgIUSUJoEFCCEgAJrIqLAGggpQBAhpUFIAWBhBJQmAQUIIaDAGokosCZCChBESGkQUgBYCAGlSUABQggosGYiCqyRkAIEEVIahBQABiegNAkoQAgBBTZARIE1E1KAIEJKg5ACwKAElCYBBQghoMCGiCiwAUIKEERIaRBSABiMgNIkoAAhBBTYIBEFNkRIAYIIKQ1CCgCDEFCaBBQghIACGyaiwAYJKUAQIaVBSAFg5gSUJgEFCCGgwAREFNgwIQUIIqQ0CCkAzJSA0iSgACEEFJiIiAITEFKAIEJKg5ACwMwIKE0CChBCQIEJiSgwESEFCCKkNAgpAMyEgNIkoAAhBBSYmIgCExJSgCBCSoOQAkA4AaVJQAFCCCgQQESBiQkpQBAhpUFIASCUgNIkoAAhBBQIIaJAACEFCCKkNAgpAIQRUJoEFCCEgAJBRBQIIaQAQYSUBiEFgBACSpOAAoQQUCCMiAJBhBQgiJDSIKQAMDEBpUlAAUIIKBBIRIEwQgoQREhpEFIAmIiA0iSgACEEFAglokAgIQUIIqQ0CCkAbJiA0iSgACEEFAgmokAoIQUIIqQ0CCkAbIiA0iSgACEEFAgnokAwIQUIIqQ0CCkArJmA0iSgACEEFJgBEQXCCSlAECGlQUgBYE0ElCYBBQghoMBMiCgwA0IKEERIaRBSAFgxAaVJQAFCCCgwIyIKzISQAgQRUhqEFABWREBpElCAEAIKzIyIAjMipABBhJQGIQWAXRJQmgQUIISAAjMkosDMCClAECGlQUgBoElAaRJQgBACCsyUiAIzJKQAQYSUBiEFgB0SUJoEFCCEgAIzJqLATAkpQBAhpUFIAWCbBJQmAQUIIaDAzIkoMGNCChBESGkQUgA4CwGlSUABQggoMAARBWZOSAGCCCkNQgoApyGgNAkoQAgBBQYhosAAhBQgiJDSIKQA8CQCSpOAAoQQUGAgIgoMQkgBgggpDUIKACcIKE0CChBCQIHBiCgwECEFCCKkNAgpAIsnoDQJKEAIAQUGJKLAYIQUIIiQ0iCkACyWgNIkoAAhBBQYlIgCAxJSgCBCSoOQArA4AkqTgAKEEFBgYCIKDEpIAYIIKQ1CCsBiCChNAgoQQkCBwYkoMDAhBQgipDQIKQDDE1CaBBQghIACCyCiwOCEFCCIkNIgpAAMS0BpElCAEAIKLISIAgsgpABBhJQGIQVgOAJKk4AChBBQYEFEFFgIIQUIIqQ0CCkAwxBQmgQUIISAAgsjosCCCClAECGlQUgBmD0BpUlAAUIIKLBAIgosjJACBBFSGoQUgNkSUJoEFCCEgAILJaLAAgkpQBAhpUFIAZgdAaVJQAFCCCiwYCIKLJSQAgQRUhqEFIDZEFCaBBQghIACCyeiwIIJKUAQIaVBSAGIJ6A0CShACAEFEFFg6YQUIIiQ0iCkAMQSUJoEFCCEgAJUlYgClJACRBFSGoQUgDgCSpOAAoQQUIDHiShAVQkpQBQhpUFIAYghoDQJKEAIAQV4AhEFeJyQAgQRUhqEFIDJCShNAgoQQkABnkJEAZ5ASAGCCCkNQgrAZASUJgEFCCGgAKckogBPIaQAQYSUBiEFYOMElCYBBQghoACnJaIApySkAEGElAYhBWBjBJQmAQUIIaAAZySiAKclpABBhJQGIQVg7QSUJgEFCCGgAGclogBnJKQAQYSUBiEFYG0ElCYBBQghoADbIqIAZyWkAEGElAYhBWDlBJQmAQUIIaAA2yaiANsipABBhJQGIQVgZQSUJgEFCCGgADsiogDbJqQAQYSUBiEFYNcElCYBBQghoAA7JqIAOyKkAEGElAYhBaBNQGkSUIAQAgrQIqIAOyakAEGElAYhBWDHBJQmAQUIIaAAbSIK0CKkAEGElAYhBWDbBJQmAQUIIaAAuyKiAG1CChBESGkQUgDOSkBpElCAEAIKsGsiCrArQgoQREhpEFIATktAaRJQgBACCrASIgqwa0IKEERIaRBSAJ5CQGkSUIAQAgqwMiIKsBJCChBESGkQUgAeJ6A0CShACAEFWCkRBVgZIQUIIqQ0CCkAAkqXgAKEEFCAlRNRgJUSUoAgQkqDkAIsmIDSJKAAIQQUYC1EFGDlhBQgiJDSIKQACySgNAkoQAgBBVgbEQVYCyEFCCKkNAgpwIIIKE0CChBCQAHWSkQB1kZIAYIIKQ1CCrAAAkqTgAKEEFCAtRNRgLUSUoAgQkqDkAIMTEBpElCAEAIKsBEiCrB2QgoQREhpEFKAAQkoTQIKEEJAATZGRAE2QkgBgggpDUIKMBABpUlAAUIIKMBGiSjAxggpQBAhpUFIAQYgoDQJKEAIAQXYOBEF2CghBQgipDQIKcCMCShNAgoQQkABJiGiABsnpABBhJQGIQWYIQGlSUABQggowGREFGASQgoQREhpEFKAGRFQmgQUIISAAkxKRAEmI6QAQYSUBiEFmAEBpUlAAUIIKMDkRBRgUkIKEERIaRBSgGACSpOAAoQQUIAIIgowOSEFCCKkNAgpQCABpUlAAUIIKEAMEQWIIKQAQYSUBiEFCCKgNAkoQAgBBYgiogAxhBQgiJDSIKQAAQSUJgEFCCGgAHFEFCCKkAIEEVIahBRgQgJKk4AChBBQgEgiChBHSAGCCCkNQgowAQGlSUABQggoQCwRBYgkpABBhJQGIQXYIAGlSUABQggoQDQRBYglpABBhJQGIQXYAAGlSUABQggoQDwRBYgmpABBhJQGIQVYIwGlSUABQggowCyIKEA8IQUIIqQ0CCnAGggoTQIKEEJAAWZDRAFmQUgBgggpDUIKsEICSpOAAoQQUIBZEVGA2RBSgCBCSoOQAqyAgNIkoAAhBBRgdkQUYFaEFCCIkNIgpAC7IKA0CShACAEFmCURBZgdIQUIIqQ0CClAg4DSJKAAIQQUYLZEFGCWhBQgiJDSIKQAOyCgNAkoQAgBBZg1EQWYLSEFCCKkNAgpwDYIKE0CChBCQAFmT0QBZk1IAYIIKQ1CCnAGAkqTgAKEEFCAIYgowOwJKUAQIaVBSAFOQUBpElCAEAIKMAwRBRiCkAIEEVIahBTgJAJKk4AChBBQgKGIKMAwhBQgiJDSIKQAJaC0CShACAEFGI6IAgxFSAGCCCkNQgosmoDSJKAAIQQUYEgiCjAcIQUIIqQ0CCmwSAJKk4AChBBQgGGJKMCQhBQgiJDSIKTAoggoTQIKEEJAAYYmogDDElKAIEJKg5ACiyCgNAkoQAgBBRieiAIMTUgBgggpDUIKDE1AaRJQgBACCrAIIgowPCEFCCKkNAgpMCQBpUlAAUIIKMBiiCjAIggpQBAhpUFIgaEIKE0CChBCQAEWRUQBFkNIAYIIKQ1CCgxBQGkSUIAQAgqwOCIKsChCChBESGkQUmDWBJQmAQUIIaAAiySiAIsjpABBhJQGIQVmSUBpElCAEAIKsFgiCrBIQgoQREhpEFJgVgSUJgEFCCGgAIsmogCLJaQAQYSUBiEFZkFAaRJQgBACCrB4IgqwaEIKEERIaRBSIJqA0iSgACEEFIASUQCEFCCJkNIgpEAkAaVJQAFCCCgAJ4goACWkAFGElAYhBaIIKE0CChBCQAE4iYgCcIKQAgQRUhqEFIggoDQJKEAIAQXgSUQUgJMIKUAQIaVBSIFJCShNAgoQQkABOAURBeBJhBQgiJDSIKTAJASUJgEFCCGgAJyGiAJwCkIKEERIaRBSYKMElCYBBQghoACcgYgCcBpCChBESGkQUmAjBJQmAQUIIaAAnIWIAnAGQgoQREhpEFJgrQSUJgEFCCGgAGyDiAJwFkIKEERIaRBSYC0ElCYBBQghoABsk4gCsA1CChBESGkQUmClBJQmAQUIIaAA7ICIArBNQgoQREhpEFJgJQSUJgEFCCGgAOyQiAKwA0IKEERIaRBSYFcElCYBBQghoAA0iCgAOySkAEGElAYhBVoElCYBBQghoAA0iSgADUIKEERIaRBSYEcElCYBBQghoADsgogC0CSkAEGElAYhBbZFQGkSUIAQAgrALokoALsgpABBhJQGIQXOSEBpElCAEAIKwAqIKAC7JKQAQYSUBiEFTklAaRJQgBACCsCKiCgAKyCkAEGElAYhBZ5AQGkSUIAQAgrACokoACsipABBhJQGIQWqSkBpE1CAEAIKwIqJKAArJKQAQYSUBiGFhRNQmgQUIISAArAGIgrAigkpQBAhpUFIYaEElCYBBQghoACsiYgCsAZCChBESGkQUlgYAaVJQAFCCCgAaySiAKyJkAIEEVIahBQWQkBpElCAEAIKwJqJKABrJKQAQYSUBiGFwQkoTQIKEEJAAdgAEQVgzYQUIIiQ0iCkMCgBpUlAAUIIKAAbIqIAbICQAgQRUhqEFAYjoDQJKEAIAQVgg0QUgA0RUoAgQkqDkMIgBJQmAQUIIaAAbJiIArBBQgoQREhpEFKYOQGlSUABQggoABMQUQA2TEgBgggpDUIKMyWgNAkoQAgBBWAiIgrABIQUIIiQ0iCkMDMCSpOAAoQQUAAmJKIATERIAYIIKQ1CCjMhoDQJKEAIAQVgYiIKwISEFCCIkNIgpBBOQGkSUIAQAgpAABEFYGJCChBESGkQUggloDQJKEAIAQUghIgCEEBIAYIIKQ1CCmEElCYBBQghoAAEEVEAQggpQBAhpUFIIYSA0iSgACEEFIAwIgpAECEFCCKkNAgpTExAaRJQgBACCkAgEQUgjJACBBFSGoQUJiKgNAkoQAgBBSCUiAIQSEgBgggpDUIKGyagNAkoQAgBBSCYiAIQSkgBgggpDUIKGyKgNAkoQAgBBSCciAIQTEgBgggpDUIKayagNAkoQAgBBWAGRBSAcEIKEERIaRBSWBMBpUlAAUIIKAAzIaIAzICQAgQRUhqEFFZMQGkSUIAQAgrAjIgoADMhpABBhJQGIYUVEVCaBBQghIACMDMiCsCMCClAECGlQUhhlwSUJgEFCCGgAMyQiAIwM0IKEERIaRBSaBJQmgQUIISAAjBTIgrADAkpQBAhpUFIYYcElCYBBQghoADMmIgCMFNCChBESGkQUtgmAaVJQAFCCCgAMyeiAMyYkAIEEVIahBTOQkBpElCAEAIKwABEFICZE1KAIEJKg5DCaQgoTQIKEEJAARiEiAIwACEFCCKkNAgpPImA0iSgACEEFICBiCgAgxBSgCBCSoOQwgkCSpOAAoQQUAAGI6IADERIAYIIKQ1CyuIJKE0CChBCQAEYkIgCMBghBQgipDQIKYsloDQJKEAIAQVgUCIKwICEFCCIkNIgpCyOgNIkoAAhBBSAgYkoAIMSUoAgQkqDkLIYAkqTgAKEEFAABieiAAxMSAGCCCkNQsrwBJQmAQUIIaAALICIAjA4IQUIIqQ0CCnDElCaBBQghIACsBAiCsACCClAECGlQUgZjoDSJKAAIQQUgAURUQAWQkgBgggpDULKMASUJgEFCCGgACyMiAKwIEIKEERIaRBSZk9AaRJQgBACCsACiSgACyOkAEGElAYhZbYElCYBBQghoAAslIgCsEBCChBESGkQUmZHQGkSUIAQAgrAgokoAAslpABBhJQGIWU2BJQmAQUIIaAALJyIArBgQgoQREhpEFLiCShNAgoQQkABQEQBWDohBQgipDQIKbEElCYBBQghoABQVSIKACWkAFGElAYhJY6A0iSgACEEFAAeJ6IAUFVCChBFSGkQUmIIKE0CChBCQAHgCUQUAB4npABBhJQGIWVyAkqTgAKEEFAAeAoRBYAnEFKAIEJKg5AyGQGlSUABQggoAJySiALAUwgpQBAhpUFI2TgBpUlAAUIIKACclogCwCkJKUAQIaVBSNkYAaVJQAFCCCgAnJGIAsBpCSlAECGlQUhZOwGlSUABQggoAJyViALAGQkpQBAhpUFIWRsBpUlAAUIIKABsi4gCwFkJKUAQIaVBSFk5AaVJQAFCCCgAbJuIAsC2CClAECGlQUhZGQGlSUABQggoAOyIiALAtgkpQBAhpUFI2TUBpUlAAUIIKADsmIgCwI4IKUAQIaVBSGkTUJoEFCCEgAJAi4gCwI4JKUAQIaVBSNkxAaVJQAFCCCgAtIkoALQIKUAQIaVBSNk2AaVJQAFCCCgA7IqIAkCbkAIEEVIahJSzElCaBBQghIACwK6JKADsipACBBFSGoSU0xJQmgQUIISAAsBKiCgA7JqQAgQRUhqElKcQUJoEFCCEgALAyogoAKyEkAIEEVIahJTHCShNAgoQQkABYKVEFABWRkgBgggpDUKKgNIloAAhBBQAVk5EAWClhBQgiJDSsOCQIqA0CShACAEFgLUQUQBYOSEFCCKkNCwwpAgoTQIKEEJAAWBtRBQA1kJIAYIIKQ0LCikCSpOAAoQQUABYKxEFgLURUoAgQkrDAkKKgNIkoAAhBBQA1k5EAWCthBQgiJDSMHBIEVCaBBQghIACwEaIKACsnZACBBFSGgYMKQJKk4AChBBQANgYEQWAjRBSgCBCSsNAIUVAaRJQgBACCgAbJaIAsDFCChBESGkYIKQIKE0CChBCQAFg40QUADZKSAGCCCkNMw4pAkqTgAKEEFAAmISIAsDGCSlAECGlYYYhRUBpElCAEAIKAJMRUQCYhJACBBFSGmYUUgSUJgEFCCGgADApEQWAyQgpQBAhpWEGIUVAaRJQgBACCgCTE1EAmJSQAgQRUhqCQ4qA0iSgACEEFAAiiCgATE5IAYIIKQ2BIUVAaRJQgBACCgAxRBQAIggpQBAhpSEopAgoTQIKEEJAASCKiAJADCEFCCKkNASEFAGlSUABQggoAMQRUQCIIqQAQYSUhglDioDSJKAAIQQUACKJKADEEVKAIEJKwwQhRUBpElCAEAIKALFEFAAiCSlAECGlYYMhRUBpElCAEAIKANFEFABiCSlAECGlYQMhRUBpElCAEAIKAPFEFACiCSlAECGlYY0hRUBpElCAEAIKALMgogAQT0gBgggpDWsIKQJKk4AChBBQAJgNEQWAWRBSgCBCSsMKQ4qA0iSgACEEFABmRUQBYDaEFCCIkNKwgpAioDQJKEAIAQWA2RFRAJgVIQUIIqQ07CKkCChNAgoQQkABYJZEFABmR0gBgggpDY2QIqA0CShACAEFgNkSUQCYJSEFCCKkNOwgpAgoTQIKEEJAAWDWRBQAZktIAYIIKQ3bCCkCSpOAAoQQUACYPREFgFkTUoAgQkrDGUKKgNIkoAAhBBQAhiCiADB7QgoQREhpOEVIEVCaBBQghIACwDBEFACGIKQAQYSUhi+ElGceOXJfCSgtAgoQQkABYChPm3oAAKzSxee+5uuq6v1V9eJplwDUz1548KLXTz1ibv7h33/3l/zhn7zy0al3zI2AAoQQUAAYjogCwHCEFCCIkMLaCShACAEFgCGJKAAMSUgBgggprI2AAoQQUAAYlogCwLCEFCCIkMLKCShACAEFgKGJKAAMTUgBgggprIyAAoQQUAAYnogCwPCEFCCIkMKuCShACAEFgEUQUQBYBCEFCCKk0CagACEEFAAWQ0QBYDGEFCCIkMKOCShACAEFgEURUQBYFCEFCCKksG0CChBCQAFgcUQUABZHSAGC/MyFBy/6nalHkO0r/tvWT1fVb0+9A1g8AQWARXr61AMAYNMuPHjRLVX1HXX8D4IAU/p7Uw9gFvycAFMTUABYLBEFgEUSUgAAYFsEFAAWTUQBYLGEFAAAOCMBBYDFE1EAWDQhBQAATklAAYASUQBASAEAgCcSUADgBBEFAEpIAQCAEwQUADiJiAIAJwgpAAAsnIACAE8iogDASYQUAAAWSkABgFMQUQDgSYQUAAAWRkABgNMQUQDgFIQUAAAWQkABgDMQUQDgNIQUAAAGJ6AAwFmIKABwBkIKAACDElAAYBtEFAA4CyEFAIDBCCgAsE0iCgBsg5ACAMAgBBQA2AERBQC2SUgBAGDmBBQA2CERBQB2QEgBAGCmBBQAaBBRAGCHhBQAAGZGQAGAJhEFABqEFAAAZkJAAYBdEFEAoElIAQAgnIACALskogDALggpAACEElAAYAVEFADYJSEFAIAwAgoArIiIAgArIKQAABBCQAGAFRJRAGBFhBQAACYmoADAiokoALBCQgoAABMRUABgDUQUAFgxIQUAgA0TUABgTUQUAFgDIQUAgA0RUABgjUQUAFgTIQUAgDUTUABgzUQUAFgjIQUAgDURUABgA0QUAFgzIQUAgBUTUABgQ0QUANgAIQUAgBURUABgg0QUANgQIQUAgF0SUABgw0QUANggIQUAgCYBBQAmIKIAwIYJKQAA7JCAAgATEVEAYAJCCgAA2ySgAMCERBQAmIiQAgDAWQgoADAxEQUAJiSkAABwGgIKAAQQUQBgYkIKAABPIqAAQAgRBQACCCkAAJwgoABAEBEFAEIIKQAAiyegAEAYEQUAgggpAACLJaAAQCARBQDCCCkAAIsjoABAKBEFAAIJKQAAiyGgAEAwEQUAQgkpAADDE1AAIJyIAgDBhBQAgGEJKAAwAyIKAIQTUgAAhiOgAMBMiCgAMANCCgDAMAQUAJgREQUAZkJIAQCYPQEFAGZGRAGAGRFSAABmS0ABgBkSUQBgZoQUAIDZEVAAYKZEFACYISEFAGA2BBQAmDERBQBmSkgBAIgnoADAzIkoADBjQgoAQCwBBQAGIKIAwMwJ9CetvwAAD0RJREFUKQAAcQQUABiEiAIAAxBSAABiCCgAMBARBQAGIaQAAExOQAGAwYgoADAQIQUAYDICCgAMSEQBgMEIKQAAGyegAMCgRBQAGJCQAgCwMQIKAAxMRAGAQQkpAABrJ6AAwOBEFAAYmJACALA2AgoALICIAgCDE1IAAFZOQAGAhRBRAGABhBQAgJURUABgQUQUAFgIIQUAYNcEFABYGBEFABZESAEAaBNQAGCBRBQAWBghBQBgxwQUAFgoEQUAFkhIAQDYNgEFABZMRAGAhRJSAADOSkABgIUTUQBgwYQUAIDTElAAABEFAJZOSAEAeAoBBQCoKhEFACghBQDgJAIKAPA4EQUAqCohBQCgBBQA4ElEFADgcUIKALBgAgoA8BQiCgDwBEIKALBAAgoAcEoiCgDwFEIKALAgAgoAcFoiCgBwSkIKALAAAgoAcEYiCgBwWkIKADAwAQUAOCsRBQA4IyEFABiQgAIAbIuIAgCclZACAAxEQAEAtk1EAQC2RUgBAAYgoAAAOyKiAADbJqQAADMmoAAAOyaiAAA7IqQAADMkoAAALSIKALBjQgoAMCMCCgDQJqIAAC1CCgAwAwIKALArIgoA0CakAADBBBQAYNdEFABgV4QUACCQgAIArISIAgDsmpACAAQRUACAlRFRAICVEFIAgAACCgCwUiIKALAyQgoAMCEBBQBYOREFAFgpIQUAmICAAgCshYgCAKyckAIAbJCAAgCsjYgCAKyFkAIAbICAAgCslYgCAKyNkAIArJGAAgCsnYgCAKyVkAIArIGAAgBshIgCAKydkAIArJCAAgBsjIgCAGyEkAIArICAAgBslIgCAGyMkAIA7IKAAgBsnIgCAGyUkAIANAgoAMAkRBQAYOOEFABgBwQUAGAyIgoAMAkhBQDYBgEFAJiUiAIATEZIAQDOQEABACYnogAAkxJSAIBTEFAAgAgiCgAwOSEFADiJgAIAxBBRAIAIQgoAUAIKABBGRAEAYggpALBoAgoAEEdEAQCiCCkAsEgCCgAQSUQBAOIIKQCwKAIKABBLRAEAIgkpALAIAgoAEE1EAQBiCSkAMDQBBQCIJ6IAANGEFAAYkoACAMyCiAIAxBNSAGAoAgoAMBsiCgAwC0IKAAxBQAEAZkVEAQBmQ0gBgFkTUACA2RFRAIBZEVIAYJYEFABglkQUAGB2hBQAmBUBBQCYLREFAJglIQUAZkFAAQBmTUQBAGZLSAGAaAIKADB7IgoAMGtCCgBEElAAgCGIKADA7AkpABBFQAEAhiGiAABDEFIAIIKAAgAMRUQBAIYhpADApAQUAGA4IgoAMBQhBQAmIaAAAEMSUQCA4QgpALBRAgoAMCwRBQAYkpACABshoAAAQxNRAIBhCSkAsFYCCgAwPBEFABiakAIAayGgAACLIKIAAMMTUgBgpQQUAGAxRBQAYBGEFABYCQEFAFgUEQUAWAwhBQB2RUABABZHRAEAFkVIAYAWAQUAWCQRBQBYHCEFAHZEQAEAFktEAQAWSUgBgG0RUACARRNRAIDFElIA4IwEFABg8UQUAGDRhBQAOCUBBQCgRBQAACEFAJ5IQAEAOEFEAQAoIQUAThBQAABOIqIAAJwgpACwcAIKAMCTiCgAACcRUgBYKAEFAOAURBQAgCcRUgBYGAEFAOA0RBQAgFMQUgBYiP/fnp0bOXZFQRSESIo0luYwgqaNJ6TSMdHT0wD+8pa7ZFpQQmlHQAEAeEFEAQB4QkgBoDgBBQDgDREFAOAFIQWAogQUAIADRBQAgDeEFACKEVAAAA4SUQAADhBSAChCQAEAOEFEAQA4SEgBIDkBBQDgJBEFAOAEIQWApAQUAIALRBQAgJOEFACSEVAAAC4SUQAALhBSAEhCQAEAuEFEAQC4SEgBIDgBBQDgJhEFAOAGIQWAoAQUAIABRBQAgJuEFACCEVAAAAYRUQAABhBSAAhCQAEAGEhEAQAYREgBYDMBBQBgMBEFAGAgIQWATQQUAIAJRBQAgMGEFAAWE1AAACYRUQAAJhBSAFhEQAEAmEhEAQCYREgBYDIBBQBgMhEFAGAiIQWASQQUAIAFRBQAgMmEFAAGE1AAABYRUQAAFhBSABhEQAEAWEhEAQBYREgB4CYBBQBgMREFAGAhIQWAiwQUAIANRBQAgMWEFABOElAAADYRUQAANhBSADhIQAEA2EhEAQDYREgB4A0BBQBgMxEFAGAjIQWAJwQUAIAARBQAgM2EFAC+EFAAAIIQUQAAAhBSAPggoAAABCKiAAAEIaQAtCegAAAEI6IAAAQipAC0JaAAAAQkogAABCOkALQjoAAABCWiAAAEJKQAtCGgAAAEJqIAAAQlpACUJ6AAAAQnogAABCakAJQloAAAJCCiAAAEJ6QAlCOgAAAkIaIAACQgpACUIaAAACQiogAAJCGkAKQnoAAAJCOiAAAkIqQApCWgAAAkJKIAACQjpACkI6AAACQlogAAJCSkAKQhoAAAJCaiAAAkJaQAhCegAAAkJ6IAACQmpACEJaAAABQgogAAJCekAIQjoAAAFCGiAAAUIKQAhCGgAAAUIqIAABQhpABsJ6AAABQjogAAFCKkAGwjoAAAFCSiAAAUI6QALCegAAAUJaIAABQkpAAsI6AAABQmogAAFCWkAEwnoAAAFCeiAAAUJqQATCOgAAA0IKIAABQnpAAMJ6AAADQhogAANCCkAAwjoAAANCKiAAA0IaQA3CagAAA0I6IAADQipABcJqAAADQkogAANCOkAJwmoAAANCWiAAA0JKQAHCagAAA0JqIAADQlpAC8JaAAADQnogAANCakADwloAAAIKIAAHQnpAD8RkABAODxeIgoAAA8hBSATwQUAAB+ElEAAHg8HkIKwENAAQDgCxEFAICfhBSgMQEFAIDfiCgAAPxCSAEaElAAAPiWiAIAwG+EFKARAQUAgKdEFAAAviWkAA0IKAAAvCSiAADwlJACFCagAADwlogCAMBLQgpQkIACAMAhIgoAAG8JKUAhAgoAAIeJKAAAHCKkAAUIKAAAnCKiAABwmJACJCagAABwmogCAMApQgqQkIACAMAlIgoAAKcJKUAiAgoAAJeJKAAAXCKkAAkIKAAA3CKiAABwmZACBCagAABwm4gCAMAtQgoQkIACAMAQIgoAALcJKUAgAgoAAMOIKAAADCGkAAEIKAAADCWiAAAwjJACbCSgAAAwnIgCAMBQQgqwgYACAMAUIgoAAMMJKcBCAgoAANOIKAAATCGkAAsIKAAATCWiAAAwjZACTCSgAAAwnYgCAMBUQgowgYACAMASIgoAANMJKcBAAgoAAMuIKAAALCGkAAMIKAAALCWiAACwjJAC3CCgAACwnIgCAMBSQgpwgYACAMAWIgoAAMsJKcAJAgoAANuIKAAAbCGkAAcIKAAAbCWiAACwjZACvCCgAACwnYgCAMBWQgrwDQEFAIAQRBQAALYTUoBPBBQAAMIQUQAACEFIAR4CCgAAwYgoAACEIaRAawIKAADhiCgAAIQipEBLAgoAACGJKAAAhCOkQCsCCgAAYYkoAACEJKRACwIKAAChiSgAAIQlpEBpAgoAAOGJKAAAhCakQEkCCgAAKYgoAACEJ6RAKQIKAABpiCgAAKQgpEAJAgoAAKmIKAAApCGkQGoCCgAA6YgoAACkIqRASgIKAAApiSgAAKQjpEAqAgoAAGmJKAAApCSkQAoCCgAAqYkoAACkJaRAaAIKAADpiSgAAKQmpEBIAgoAACWIKAAApCekQCgCCgAAZYgoAACUIKRACAIKAACliCgAAJQhpMBWAgoAAOWIKAAAlCKkwBYCCgAAJYkoAACUI6TAUgIKAABliSgAAJQkpMASAgoAAKWJKAAAlCWkwFQCCgAA5YkoAACUJqTAFAIKAAAtiCgAAJQnpMBQAgoAAG2IKAAAtCCkwBACCgAArYgoAAC0IaTALQIKAADtiCgAALQipMAlAgoAAC2JKAAAtCOkwCkCCgAAbYkoAAC0JKTAIQIKAACtiSgAALQlpMBLAgoAAO2JKAAAtCakwLcEFAAAeIgoAAAgpMCvBBQAAPggogAAwENIgQ8CCgAAfCKiAADAByGF5gQUAAD4QkQBAIBPhBSaElAAAOAbIgoAAHwhpNCMgAIAAE+IKAAA8A0hhSYEFAAAeEFEAQCAJ4QUihNQAADgDREFAABeEFIoSkABAIADRBQAAHhDSKEYAQUAAA4SUQAA4AAhhSIEFAAAOEFEAQCAg4QUkhNQAADgJBEFAABOEFJISkABAIALRBQAADhJSCEZAQUAAC4SUQAA4AIhhSQEFAAAuEFEAQCAi4QUghNQAADgJhEFAABuEFIISkABAIABRBQAALhJSCEYAQUAAAYRUQAAYAAhhSAEFAAAGEhEAQCAQYQUNhNQAABgMBEFAAAGElLYREABAIAJRBQAABhMSGExAQUAACYRUQAAYAIhhUUEFAAAmEhEAQCASYQUJhNQAABgMhEFAAAmElKYREABAIAFRBQAAJhMSGEwAQUAABYRUQAAYAEhhUEEFAAAWEhEAQCARYQUbhJQAABgMREFAAAWElK4SEABAIANRBQAAFjsU0j5sXUIWfx4CCgAAAAAAHTy759//7F7A/H99c9/fgIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAGzzP1LgnjewqV7qAAAAAElFTkSuQmCC"}];"""
            |> chartGeneratedContains logoImageChart
        );
        testCase "Image base64 layout" ( fun () ->
            """var layout = {"title":{"text":"This is Plotly.NET:"}};"""
            |> chartGeneratedContains logoImageChart
        );        

       
    ]