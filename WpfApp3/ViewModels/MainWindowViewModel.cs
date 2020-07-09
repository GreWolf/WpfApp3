using System;
using System.Collections.Generic;
using System.Text;
using WpfApp3.ViewModels.Base;

namespace WpfApp3.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Заголовок окна
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
    }
}
