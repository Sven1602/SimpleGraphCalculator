using OxyPlot;
using System.Windows.Input;
using LibrarySimpleGraphCalculator;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows;
using SimpleGraphCalculator;
using System.Linq;
using System;

namespace CsvImportReview
{
    public class MainViewModel : ViewModelBase
    {
        private double xValue;
        private double rad;
        private double incrementRad;
        private double functionValue;
        private string currentFunctionName;
        private BaseFunction currentFunctionObject;
        private string currentUnit;
        private int minXValue;
        private int maxXValue;

        private ICalcManager calcManager;
        private IChartManager chartManager;
        private IDataManager dataManager;

        private bool updateChart;
        private const string FilePath = "StoreData.xml";
        private const string ExportChartFilePath = "ExportChartVectorFormat.svg";

        public MainViewModel()
        {
            FunctionNames = new ObservableCollection<string>();
          
            CalcCommand = new RelayCommand(Calculate);

            calcManager = new CalcManager();
            chartManager = new OxyPlotChartManager();
            dataManager = new DataManager();

            StoreData storeDatas = this.LoadDatas(FilePath);

            if(storeDatas != null)
            {   
                XValue = storeDatas.XValue;
                CurrentFunctionName = storeDatas.Name;
                FunctionValue = storeDatas.FunctionValue;
                MinXValue = storeDatas.MinXValue;
                MaxXValue = storeDatas.MaxXValue;
                IncrementRad = storeDatas.IncrementRad;
                CurrentUnit = storeDatas.CurrentUnit;
            }
            else
            { // Default Values
                CurrentFunctionName = FunctionNames.First();
                XValue = 90;
                MinXValue = -10;
                MaxXValue = 10;
                IncrementRad = 0.1;
                CurrentUnit = Units[(short)EnumParameter.Deg];
            }
          

            /*
            this.ChartModel = new PlotModel { Title = "Functions", IsLegendVisible = true };
            this.ChartModel.Legends.Add(new Legend
            {
                LegendBackground = OxyColor.FromAColor(220, OxyColors.White),
                LegendBorder = OxyColors.Black,
                LegendBorderThickness = 1.0,
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomLeft,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendLineSpacing = 8,
                LegendMaxWidth = 1000,
                LegendFontSize = 12
            });
            */
            //this.ChartModel.Series.Add(new FunctionSeries(Calculator.Cos, -10, 10, 0.1, "cos(x)"));

            //this.ChartModel.Series.Add(new FunctionSeries(Calculator.Cos, -10, 10, 0.1, "cos(x)"));
            //this.ChartModel.Series.Add(new FunctionSeries(Calculator.Sinc, -10, 10, 0.1, "Sinc(x)"));
            updateChart = true;
            UpdateChart();
        }

        ~MainViewModel()
        {
        }

        public PlotModel ChartModel { get; private set; }

        public ObservableCollection<string> Units
        {
            get => new ObservableCollection<string>(new List<string>{EnumParameter.Deg.ToString(), EnumParameter.Rad.ToString() });
            private set
            {
            }
        }

        public string CurrentUnit
        {
            get => currentUnit;
            set
            {
                if (value != null)
                {
                    currentUnit = value;
                    OnPropertyChanged(nameof(CurrentUnit));
                }
            }
        }

        public ObservableCollection<string> FunctionNames
        {
            get => new ObservableCollection<string>(this.GetAvailableFunctions().Select(x => x.Item2));
            private set
            {
            }
        }

        
        public IChartManager ChartManager
        {
            get => chartManager;
            private set
            {
            }
        }

        public string CurrentFunctionName
        {
            get => currentFunctionName;
            set
            {
                if (value != null)
                {
                    currentFunctionName = value;

                    if(currentFunctionName != null)
                    {
                        currentFunctionObject = this.GetAvailableFunctions().Select(x => x.Item1).FirstOrDefault(x => x.Name == currentFunctionName);
                    }
                    UpdateChart();
                    OnPropertyChanged(nameof(CurrentFunctionName));
                }
            }
        }

        public ICommand CalcCommand { get; }

        public double XValue
        {
            get => xValue;
            set
            {
                xValue = value;
                OnPropertyChanged(nameof(XValue));
            }
        }

        public double FunctionValue
        {
            get => functionValue;
            set
            {
                functionValue = value;
                OnPropertyChanged(nameof(FunctionValue));
            }
        }

        public double Rad
        {
            get => rad;
            set
            {
                rad = value;
                OnPropertyChanged(nameof(Rad));
            }
        }

        public double IncrementRad
        {
            get => incrementRad;
            set
            {
                incrementRad = value;
                UpdateChart();
                OnPropertyChanged(nameof(IncrementRad));
            }
        }

        public int MinXValue
        {
            get => minXValue;
            set
            {
                minXValue = value;
                UpdateChart();
                OnPropertyChanged(nameof(MinXValue));
            }
        }

        public int MaxXValue
        {
            get => maxXValue;
            set
            {
                maxXValue = value;
                UpdateChart();
                OnPropertyChanged(nameof(MaxXValue));
            }
        }

        private List<Tuple<BaseFunction, string>> GetAvailableFunctions()
        {
            BaseFunction sin = new Sin();
            BaseFunction cos = new Cos();
            BaseFunction sinc = new Sinc();
            var list = new List<Tuple<BaseFunction, string>>
            {
                Tuple.Create(sin, sin.Name),
                Tuple.Create(cos, cos.Name),
                Tuple.Create(sinc, sinc.Name),
            };

            return list;
        }

        private void Calculate(object parameter)
        {
            if(CurrentFunctionName != null) {

                if (CurrentUnit == EnumParameter.Deg.ToString()) //Deg
                {
                    FunctionValue = calcManager.CalculateWithDegree(currentFunctionObject, xValue);
                }
                else //Rad
                {
                    FunctionValue = calcManager.CalculateWithRad(currentFunctionObject, xValue);
                }
                UpdateChart();
                SaveDatas();
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie eine Funktion aus!");
            } 
        }

        private void UpdateChart()
        {
            if (updateChart)
            {
                if (CurrentUnit == EnumParameter.Deg.ToString()) //Deg
                {
                    Rad = Calculator.Radians(xValue);
                }
                else //Rad
                {
                }

                if (currentFunctionName != null)
                {
                    ChartData chartData = new ChartData
                    {
                        Name = CurrentFunctionName,
                        Function = currentFunctionObject.Calc,
                        MinXValue = MinXValue,
                        MaxXValue = MaxXValue,
                        RadIncrement = IncrementRad
                    };

                    //this.ChartModel.Series.Clear();
                    //this.ChartModel.Series.Add(new FunctionSeries(Calculator.Sinc, -10, 10, 0.1, "Sinc(x)"));
                    //this.ChartModel.InvalidatePlot(true);

                    //this.ChartModel.Series.Add(new FunctionSeries(chartData.Function, chartData.MinXValue, chartData.MaxXValue, chartData.RadIncrement));
                    chartManager.UpdateChart(CurrentFunctionName, chartData);
                    SaveDatas();
                }
            } 
        }

        private void SaveDatas()
        {
            StoreData storeData = new StoreData
            {
                Name = CurrentFunctionName,
                XValue = XValue,
                FunctionValue = FunctionValue,
                CurrentUnit = CurrentUnit,
                MinXValue = MinXValue,
                MaxXValue = MaxXValue,
                IncrementRad = IncrementRad
            };

            this.dataManager.Save(FilePath, storeData);
            this.chartManager.exportChartToSvg(ExportChartFilePath, 600, 600);
        }

        private StoreData LoadDatas(string filePath)
        {
            return this.dataManager.Load(filePath);
        }
    }
}
