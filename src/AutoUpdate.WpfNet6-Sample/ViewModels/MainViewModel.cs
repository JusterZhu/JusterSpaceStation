﻿using GeneralUpdate.Core;
using GeneralUpdate.Core.Strategys;
using GeneralUpdate.Core.Update;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoUpdate.WpfNet6_Sample.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private string _tips1, _tips2, _tips3, _tips4, _tips5, _tips6;
        private double _progressVal, _progressMin,_progressMax;

        public MainViewModel() { }

        public MainViewModel(string args) 
        {
            var bootStrap = new GeneralUpdateBootstrap();
            bootStrap.MutiAllDownloadCompleted += OnMutiAllDownloadCompleted;
            bootStrap.MutiDownloadCompleted += OnMutiDownloadCompleted;
            bootStrap.MutiDownloadError += OnMutiDownloadError;
            bootStrap.MutiDownloadProgressChanged += OnMutiDownloadProgressChanged;
            bootStrap.MutiDownloadStatistics += OnMutiDownloadStatistics;
            bootStrap.Exception += OnException;
            bootStrap.Option(UpdateOption.DownloadTimeOut, 30).
            Strategy<DefaultStrategy>().
            RemoteAddressBase64(args);
            bootStrap.LaunchAsync();
        }

        public string Tips1 { get => _tips1; set => SetProperty(ref _tips1, value); }
        public string Tips2 { get => _tips2; set => SetProperty(ref _tips2, value); }
        public string Tips3 { get => _tips3; set => SetProperty(ref _tips3, value); }
        public string Tips4 { get => _tips4; set => SetProperty(ref _tips4, value); }
        public string Tips5 { get => _tips5; set => SetProperty(ref _tips5, value); }
        public string Tips6 { get => _tips6; set => SetProperty(ref _tips6, value); }
        public double ProgressVal { get => _progressVal; set => SetProperty(ref _progressVal, value); }
        public double ProgressMin { get => _progressMin; set => SetProperty(ref _progressMin, value); }
        public double ProgressMax { get => _progressMax; set => SetProperty(ref _progressMax, value); }

        private void OnMutiDownloadStatistics(object sender, GeneralUpdate.Core.Update.MutiDownloadStatisticsEventArgs e)
        {
            Tips1 = $"{ e.Speed }{ e.Remaining }";
        }

        private void OnMutiDownloadProgressChanged(object sender, GeneralUpdate.Core.Update.MutiDownloadProgressChangedEventArgs e)
        {
            ProgressMin = 0;
            ProgressVal = e.ProgressValue;
            ProgressMax = e.TotalBytesToReceive;
            Tips2 = $"{ e.ProgressValue }{ e.TotalBytesToReceive }";
        }

        private void OnMutiDownloadCompleted(object sender, GeneralUpdate.Core.Update.MutiDownloadCompletedEventArgs e)
        {
            Tips3 = $"{ e.Version.Name } download completed.";
        }

        private void OnMutiAllDownloadCompleted(object sender, GeneralUpdate.Core.Update.MutiAllDownloadCompletedEventArgs e)
        {
            if (e.IsAllDownloadCompleted)
            {
                Tips4 = "AllDownloadCompleted";
            }
            else
            {
                //foreach (var version in e.FailedVersions)
                //{
                //    Debug.Write($"{ version.Item1.Name }");
                //}
            }
        }

        private void OnMutiDownloadError(object sender, GeneralUpdate.Core.Update.MutiDownloadErrorEventArgs e)
        {
            Tips5 = $"{ e.Version.Name },{ e.Exception.Message }.";
        }

        private void OnException(object sender, GeneralUpdate.Core.Update.ExceptionEventArgs e)
        {
            Tips6 = $"{ e.Exception.Message }";
        }
    }
}
