using AppProjekt.Models;
using Microcharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppProjekt.ViewModels
{
    public class HumidityViewModel : BaseViewModel
    {
        public ObservableCollection<feeds> feeds { get; set; } = new ObservableCollection<feeds>();

        #region Commands
        public Command GetAllMeasurements { get; }

        private Command updateChart;
        public ICommand UpdateChart => updateChart ??= new Command(
            execute: (args) =>
            {
                GenerateHumChart(Convert.ToInt32(args));
            });
        #endregion

        #region Charts
        private Chart humidityChart;

        public Chart HumidityChart
        {
            get => humidityChart;
            set => SetProperty(ref humidityChart, value);
        }
        #endregion

        #region Constructor
        public HumidityViewModel()
        {
            GetAllMeasurements = new Command(async () => await GetMeasurements());
        }
        #endregion

        #region Methods
        public async Task GetMeasurements()
        {
            IsBusy = true;

            try
            {
                feeds.Clear();

                Measurement measurements = await _service.GetMeasurementsAsync();

                foreach (var item in measurements.Feeds)
                {
                    feeds.Add(item);
                }

                GenerateHumChart();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        private void GenerateHumChart(int number = 0)
        {
            if (number == 0) number = 50;

            List<ChartEntry> entries = new List<ChartEntry>();
            DateTime latestentry = feeds.Last().created_at;
            var todaysfeeds = feeds.Where(x => x.created_at.Date == latestentry.Date);

            List<feeds> items = todaysfeeds.Where((x, i) => i % number == 0).ToList();     // Humidity opdateres per 10 sek. det er 360 gange i timen

            //List<feeds> items = feeds.Skip(Math.Max(0, feeds.Count() - 15)).ToList();

            foreach (var item in items)
            {
                entries.Add(new ChartEntry((float)Convert.ToDecimal(item.field2))
                {
                    Color = SkiaSharp.SKColor.Parse("#ff3c00"),
                    Label = item.created_at.ToShortTimeString().Replace("AM", "").Replace("PM", ""),
                    ValueLabel = item.field2
                });
            }

            HumidityChart = new LineChart()
            {
                Entries = entries,
                LabelTextSize = 24,
                LineSize = 10
            };
        }
        #endregion
    }
}
