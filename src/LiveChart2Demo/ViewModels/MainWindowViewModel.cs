﻿using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;

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
    }
}
