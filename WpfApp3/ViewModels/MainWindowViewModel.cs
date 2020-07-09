using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using WpfApp3.Infrastructure.Commands;
using WpfApp3.ViewModels.Base;

namespace WpfApp3.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
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

        #endregion

        public MainWindowViewModel()
        {
            #region Команды

            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            #endregion
        }
    }
}
