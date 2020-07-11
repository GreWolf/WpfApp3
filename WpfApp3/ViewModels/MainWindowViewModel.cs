using OxyPlot;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using WpfApp3.Infrastructure.Commands;
using WpfApp3.ViewModels.Base;
using DataPoint = WpfApp3.Models.DataPoint;

namespace WpfApp3.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {

        #region

        private int _SelectedPageIndex;

        public int SelectedPageIndex
        {
            get => _SelectedPageIndex;
            set => Set(ref _SelectedPageIndex, value);
        }

        #endregion

        #region TestDataPoints
        private IEnumerable<DataPoint> _TestDataPoints;
        public IEnumerable<DataPoint> TestDataPoints
        { 
            get => _TestDataPoints;
            set => Set(ref _TestDataPoints, value);
        }
        #endregion

        #region Title - Заголовок окна
        private string _Title = "Заголово окна";

        /// <summary>Заголовок окна</summary>

        public string Title
        {
            get => _Title;
            //set
            //{
            //    //if (Equals(_Title, value)) return;
            //    //_Title = value;
            //    //OnProperyChanged();

            //    Set(ref _Title, value);

            //}

            set => Set(ref _Title, value);
        }
        #endregion

        #region Статус Status - программы
        /// <summary>Заголовок окна</summary>
        private string _Status = "Готов!";

        /// <summary>Заголовок окна</summary>

        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }
        #endregion

        #region Команды

        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        private bool CanCloseApplicationCommandExecute(object p) => true;
        #endregion

        #region ChangeTabIndexCommnad

        public ICommand ChangeTabIndexCommand { get;}

        private bool CanChangeTabIndexCommandExecute(object p) => _SelectedPageIndex >= 0;
        private void OnChangeTabIndexCommandExecute(object p)
        {
            if (p is null) return;
            SelectedPageIndex += Convert.ToInt32(p);
        }
        #endregion

        #endregion

        public MainWindowViewModel()
        {
            #region Команды

            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            ChangeTabIndexCommand = new LambdaCommand(OnChangeTabIndexCommandExecute, CanChangeTabIndexCommandExecute);

            #endregion

            var data_points = new List<DataPoint>((int)(360 / 0.1));

            const double to_rad = Math.PI / 180;

            for(var x = 0d; x <= 360; x += 0.1)
            {
                var y = Math.Sin(x * to_rad);
                data_points.Add(new DataPoint { XValue = x, YValue = y });
            }

            TestDataPoints = data_points;

        }
    }
}
