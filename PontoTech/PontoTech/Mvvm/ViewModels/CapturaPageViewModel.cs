using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Essentials;

namespace PontoTech.Mvvm.ViewModels
{
    public class CapturaPageViewModel
    {
        public ICommand BtnCapturarCommand { get; private set; }
        public ImageSource CapturedImageSource { get; set; } // Propriedade para a imagem capturada

        public CapturaPageViewModel()
        {
            BtnCapturarCommand = new Command(async () => await CapturarFoto());
        }

        public async Task CapturarFoto()
        {
            try
            {
                var photo = await Xamarin.Essentials.MediaPicker.CapturePhotoAsync(new Xamarin.Essentials.MediaPickerOptions
                {
                    Title = "Tire uma foto"
                });

                // Exibir a foto capturada na UI
                CapturedImageSource = ImageSource.FromStream(() => photo.OpenReadAsync().Result);

                // Notificar a UI sobre a alteração na propriedade da imagem capturada
                OnPropertyChanged(nameof(CapturedImageSource));
            }
            catch (Exception ex)
            {
                // Lidar com exceções ao capturar uma foto
                Console.WriteLine($"Erro ao capturar foto: {ex.Message}");
            }
        }

        // Implemente OnPropertyChanged para notificar a UI sobre alterações nas propriedades
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
