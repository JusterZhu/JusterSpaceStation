using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView.Extensions;
using System.Collections.Generic;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using LiveChartsCore.Measure;

namespace LiveChart2Demo.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ISeries[] Series { get; set; } =
        {
                new LineSeries<double>
                {
                    Values = new double[] { 2, 1, 3, 5, 3, 4, 6 },
                    Fill = null
                }
        };

        public IEnumerable<ISeries> PieChartSeries { get; set; } =
   GaugeGenerator.BuildSolidGauge(
       new GaugeItem(30, series =>
       {
           series.Fill = new SolidColorPaint(SKColors.YellowGreen);
           series.DataLabelsSize = 50;
           series.DataLabelsPaint = new SolidColorPaint(SKColors.Red);
           series.DataLabelsPosition = PolarLabelsPosition.ChartCenter;
           series.InnerRadius = 75;
       }),
       new GaugeItem(GaugeItem.Background, series =>
       {
           series.InnerRadius = 75;
           series.Fill = new SolidColorPaint(new SKColor(100, 181, 246, 90));
       }));
    }
}
