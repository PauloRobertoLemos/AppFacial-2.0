using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PontoTech.Mvvm.ViewModels
{
    internal class CapturaPageViewModel
    {
       public ICommand BtnCapturarCommand => new Command(() => { App.Current.MainPage.DisplayAlert("e", "e", "e"); });

        private void ConverterImgParaCodigo()
        {

        }

        private void CompararCodigos()
        {

        }
    }
}
