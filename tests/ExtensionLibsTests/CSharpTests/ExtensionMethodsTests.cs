using System;
using Xunit;
using Plotly.NET.CSharp;
using CSharp.Tests;

namespace Plotly.NET.CSharp.Tests
{
    public class ExtensionMethodsTests
    {
        internal GenericChart chart = Chart.Point<double, double, string>(x: new double[] { 1, 2 }, y: new double[] { 5, 10 }, UseDefaults: false);

        [Fact]
        public void CanUseCSharpExtensionMethod()
        {
            Trace actual =
                chart
                .WithTraceInfo(Name: "Trace Name")
                .GetTraces()
                [0];

            Assert.Equal("Trace Name", actual.GetPropertyValue("name"));
        }

        [Fact]
        public void WithLegendLayout()
        {
            TestUtils.ChartGeneratedContains(
                chart.WithLegendStyle(
                    X: 0.5,
                    Orientation: Plotly.NET.StyleParam.Orientation.Horizontal,
                    XAnchor: Plotly.NET.StyleParam.XAnchorPosition.Center,
                    EntryWidth: 0,
                    EntryWidthMode: Plotly.NET.StyleParam.EntryWidthMode.Pixels
                ),
                "var layout = {\"legend\":{\"entrywidth\":0.0,\"entrywidthmode\":\"pixels\",\"orientation\":\"h\",\"x\":0.5,\"xanchor\":\"center\"}};"
            );
        }
    }
}
