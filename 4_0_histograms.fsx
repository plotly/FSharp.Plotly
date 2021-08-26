(**
// can't yet format YamlFrontmatter (["title: Histograms"; "category: Distribution Charts"; "categoryindex: 5"; "index: 1"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Histograms

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=4_0_histograms.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/4_0_histograms.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/4_0_histograms.ipynb)

*Summary:* This example shows how to create a one-dimensional histogram of a data samples in F#.

let's first create some data for the purpose of creating example charts:

*)
open Plotly.NET 

let rnd = System.Random()
let x = [for i=0 to 500 do yield rnd.NextDouble() ]
(**
A histogram consisting of rectangles whose area is proportional to the frequency of a variable and whose width is equal to the class interval.
The histogram chart represents the distribution of numerical data and can be created using the `Chart.Histogram` function:.
*)
let histo1 =
    x
    |> Chart.Histogram
    |> Chart.withSize(500.,500.)(* output: 
<div id="8944997e-1be5-490e-85fa-f14950b999e8" style="width: 500px; height: 500px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_8944997e1be5490e85faf14950b999e8 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"histogram","x":[0.07184718878560103,0.8269310737154125,0.09907673955852014,0.49101800866938106,0.48867939295651364,0.38668684725961033,0.7953681935534664,0.9615374882526405,0.48257054038465513,0.8062843036867139,0.4041101166066295,0.1278484212829957,0.2336705211706788,0.7854117107509689,0.9282466764227705,0.46394155475494525,0.28820440465966446,0.9377886480362102,0.866573466857231,0.2817300289318571,0.03256600910451543,0.701850130083901,0.19509010072568903,0.1547688991552074,0.41010889243805265,0.4819117856593392,0.806627878829198,0.451080603269432,0.22283558697571773,0.21368186325471936,0.05641202165578121,0.37409093807176264,0.80722517324948,0.4250029308837852,0.584512301061541,0.7033538421165915,0.863295094977736,0.429929121597637,0.7545210126575645,0.9057822729953482,0.8281179414261681,0.9138765842252767,0.6763355921378059,0.8013191194279674,0.35679574094563526,0.8926168409607451,0.9751297705690981,0.14865135920636885,0.9907840848857463,0.08443746766282127,0.3297774006285599,0.2842307790574761,0.6800098711065994,0.7645076558759938,0.03504041770242174,0.3699970587017001,0.6318409729897235,0.9443078404033127,0.08090911623132839,0.00676760729717445,0.5800589684304125,0.34428759028403444,0.7387019012769227,0.2688886771299358,0.7498722820309327,0.03001917853486686,0.3206232480335158,0.8086675902868936,0.20089940968942802,0.224892834306179,0.6006464597772092,0.8582752830620274,0.18326763537864557,0.9607911938618827,0.45361208750568893,0.11868942487923867,0.025514537946095008,0.3937709812977216,0.7979731582095722,0.5174920514773075,0.5067820150902411,0.6579765196228291,0.46029651838368574,0.13839811931289644,0.8839044626261594,0.7721812425983051,0.6940810669651633,0.0427175173734862,0.3899625131813635,0.2145152423598409,0.07151286912686791,0.9189872545744233,0.3490200053663086,0.7477534053603901,0.32572330456493576,0.48383035114213374,0.175174682948354,0.4074469150078701,0.05144683739703467,0.32677656241076836,0.5719935929272294,0.1664621802822045,0.9477519495169409,0.7658912505795673,0.4837910078856121,0.4715021175665325,0.10096314367883054,0.7192186772447167,0.3108955683703048,0.9163509928231831,0.3444825207556051,0.23806999169200194,0.1463346821937406,0.5634170647540209,0.49998559220693334,0.9220824488075834,0.8839910719003486,0.6003037819640263,0.3849842145037764,0.9776910394326276,0.3359381115697036,0.27790573066002955,0.4187050771055301,0.9863841673295871,0.1533799651793111,0.6816592052027859,0.5092552776957188,0.4355142300182554,0.635067889296947,0.9697817363635551,0.9435147419308847,0.6180676229382249,0.34232414390068694,0.4711965957988038,0.9454984585500781,0.3403198348080366,0.7102245701058882,0.6944052678041185,0.6546071114272843,0.4124023450596269,0.6712180989194746,0.9748623897204466,0.7318219490031814,0.4736115203581804,0.8700327216042358,0.833442877434866,0.7726525723806827,0.7856029406122877,0.2477678131534568,0.40364085575735237,0.599839279241785,0.5748709009843277,0.02246270050409376,0.07375579796440704,0.9908384508410648,0.29408786226719985,0.7477571031766744,0.9613677821873537,0.6125112854002562,0.8021318026828262,0.9622468398708137,0.6654489136605751,0.08415078794776965,0.3411138320067496,0.9728362508922984,0.7264148978173802,0.8957458477913149,0.6751380863949368,0.6179186062039428,0.15966575739889674,0.21185787870169517,0.18958580409623021,0.9456966705367419,0.9725818694441495,0.30647294051315305,0.361075721849257,0.5460837816568481,0.9450935567473497,0.11635144572535132,0.3199370877444451,0.9090066328221031,0.7236523370834311,0.1877464168647986,0.23142703353959462,0.3699424571217701,0.36864384094655694,0.5956049224341311,0.26856834593627993,0.480358144957739,0.6514105962828782,0.5925627316313622,0.7488567879185345,0.08189398240386228,0.8524753087444582,0.4501555051888132,0.005769185258899436,0.8907116017726769,0.39070811699643176,0.500775269465882,0.1436178237868556,0.937697029643551,0.0975144859857459,0.16768433440834485,0.08810205575456007,0.19178297705565717,0.4102534751455549,0.6291742304475858,0.04988083105994427,0.767282857451254,0.6297627289918077,0.7480040806103517,0.8026635464293247,0.8450163364620024,0.29257419765581105,0.893125169860723,0.2385945027873826,0.47770249679577653,0.852723754408175,0.9711713748849795,0.6041924099457415,0.1308099753832491,0.6271775018550351,0.19477994143719782,0.9665080099210646,0.5671030257675345,0.4630010907831607,0.10769182169236793,0.09322136179228377,0.5224263642553363,0.30070375525425364,0.47036412007658,0.15537566466041638,0.4443182872814677,0.9727336219384958,0.3822400581008941,0.8114921468363573,0.5559680026750863,0.09964436111023853,0.039644056483937457,0.9596889819762152,0.7394696104989711,0.5457240913741869,0.501285488485026,0.8505954159659312,0.9034065156725266,0.7898991852020375,0.9038404514565321,0.7893197847480512,0.9593501388837351,0.21156100240143064,0.5280666884631229,0.037987847364501955,0.41953674211145225,0.8965828595201405,0.012807848403606494,0.31051952778851594,0.9027345445485481,0.20117632448728026,0.5209990299870255,0.7287818862724965,0.3025616534531869,0.535952868655302,0.527454466804608,0.46657910219700033,0.15939860891522775,0.5926284159499353,0.358345259147857,0.8722827145235067,0.9103341395549169,0.08163302302436579,0.6826265001122963,0.37805813568553803,0.8130796979242375,0.011482392908764254,0.8647227994467703,0.5850858840090623,0.12589201337000916,0.3441845254712666,0.06310149424853805,0.777203840565497,0.5591606393266286,0.3183720369443167,0.13387122290854864,0.3108653618539057,0.7726370667911308,0.43237627271207807,0.7358389225489641,0.5477354277613272,0.9599257735348893,0.07172053031237821,0.9087576022878092,0.354791678187806,0.5786453311232129,0.31086217021144097,0.6571273285230284,0.20351674184366908,0.018269624569578855,0.034706386288025595,0.6911968070507035,0.3107780997225913,0.4315539260541806,0.03155773693302541,0.8789856451931343,0.8777171158593693,0.5289345022891343,0.1500085527775849,0.2249081494402644,0.408054349202688,0.03186006007337014,0.42772196439454424,0.18462751441850678,0.5585500190772815,0.1380748302387422,0.7437951894215286,0.1696212469458679,0.9841896165088702,0.40208164574675337,0.21658910495070233,0.6939420354058696,0.7270223362031497,0.8567894934009712,0.8106098313865298,0.9123569409886174,0.8386136092425387,0.1728754207365566,0.3278348219244903,0.799412804562325,0.5022175277127966,0.35435506438573594,0.6612060576031012,0.5668162594394834,0.09118562708198355,0.6529877184205631,0.7523233945259468,0.34564991451131644,0.5276029023936032,0.43938639175118244,0.2561541070491793,0.7819308595647714,0.6226285140135458,0.2074681232718137,0.3277845733462761,0.515875367687957,0.532203809140345,0.8870930158938715,0.3502075832105277,0.2167168479490638,0.8348501417016844,0.14124092326557305,0.6729377120141581,0.8014350960969157,0.8016805196188765,0.340764350882156,0.9641744708475538,0.4539886063216201,0.6209440946676508,0.11920079594440795,0.040372035950595526,0.7048416951228127,0.201099680364644,0.35059574821525985,0.7226906217274678,0.05369928481695209,0.37065400247026886,0.8609057049550608,0.09344188733652321,0.9055623006567184,0.38575143571279547,0.3981452749102122,0.6420183445522647,0.5448032247576877,0.14592753869757408,0.434658245385931,0.07131352139232379,0.519554212931336,0.529004920054695,0.2947344636985727,0.3801531318482725,0.9515205933486673,0.8226678375260289,0.1111179739754265,0.9645626628606406,0.3609766044472235,0.6814173523715779,0.8597709615061856,0.7651357398206069,0.7504212761998276,0.6888132475730093,0.2983347882043267,0.7247058198436657,0.4084021064491952,0.3990143558005869,0.5513124119263666,0.5808311792001274,0.27203276579828595,0.48477750154434585,0.274085288529324,0.1452213652176882,0.6712981041852841,0.7936511285573482,0.44464528255380936,0.8309654122362684,0.43670486679147225,0.4992225787133084,0.12813448725647036,0.6555075573993416,0.36702227423294553,0.2694508294898322,0.4446202579162178,0.9249836862669251,0.3262096309690781,0.7390476640961355,0.08885144260192823,0.8821738575967838,0.0899817063892175,0.3860330853546192,0.36171401728024427,0.3722819324453743,0.5108830409640833,0.09576996513445395,0.34302061113669563,0.216749053083709,0.08741664750846878,0.6734394550665466,0.23361623810306947,0.14578886895710083,0.5946151267712075,0.8538270661858036,0.7992807555940378,0.034776711386990136,0.25491963152537106,0.1495130984808845,0.7088550276629882,0.15786946479131908,0.37802255497221954,0.28015256173915815,0.5278577960691684,0.8617540257339151,0.5532828651151075,0.20426340410684393,0.39811346558766136,0.4809704467099954,0.24419298965679156,0.3733511019374016,0.3984961888745875,0.6693544423530597,0.3101629131986587,0.6691385543295828,0.49084947281090985,0.8859996804436667,0.12306348426410159,0.9018033560839497,0.6343383242536049,0.5755281390508302,0.4506305174206526,0.22789622947010035,0.7435487647277996,0.7632654117249257,0.26560634061023886,0.9823456182993695,0.06089243062813414,0.5131952080471419,0.47017007389579435,0.40984354652922766,0.670064054741554,0.17669653248819361,0.03019263643314719,0.9309819778106091,0.5041513026245643,0.8098291446500594,0.8581752892854508,0.4999599915463291,0.8189990673302668,0.30661963685723936,0.6976564995467925,0.8620501644267002,0.9725560634269175,0.7140655455710672,0.274943266191959,0.5642617957500098,0.8356259557584421,0.9254765724416247,0.3629775933748938,0.913281075150371,0.9117132271228885,0.3531162754414213,0.5151747742272796,0.13332688861215808,0.7072389473706665,0.15012632550211918,0.5366037970113585,0.7645923843442427,0.5961476851236763,0.5709372468157379,0.1433709734787098,0.8849182575405194,0.010800372814200992,0.8343494431275639,0.7032870471958477,0.2217996563863939,0.6391618059199126],"marker":{}}];
            var layout = {"width":500.0,"height":500.0};
            var config = {};
            Plotly.newPlot('8944997e-1be5-490e-85fa-f14950b999e8', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_8944997e1be5490e85faf14950b999e8();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_8944997e1be5490e85faf14950b999e8();
            }
</script>
*)

