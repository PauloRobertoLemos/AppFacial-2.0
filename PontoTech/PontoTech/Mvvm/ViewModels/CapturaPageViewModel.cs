using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace PontoTech.Mvvm.ViewModels
{
    public class CapturaPageViewModel : INotifyPropertyChanged
    {
        private ImageSource _fotoSelecionada;

        public ImageSource FotoSelecionada
        {
            get => _fotoSelecionada;
            set
            {
                _fotoSelecionada = value;
                OnPropertyChanged(nameof(FotoSelecionada));
            }
        }

        public ICommand CapturarFotoCommand { get; private set; }
        public ICommand SelecionarFotoCommand { get; private set; }

        public CapturaPageViewModel()
        {
            CapturarFotoCommand = new Command(async () => await CapturarFotoAsync());
            SelecionarFotoCommand = new Command(async () => await SelecionarFotoAsync());
        }

        private async Task CapturarFotoAsync()
        {
            try
            {
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await Application.Current.MainPage.DisplayAlert("Sem Câmera", "Não há câmera disponível.", "OK");
                    return;
                }

                var nameFile = "AAf" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg";

                var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    SaveToAlbum = true,
                    Name = nameFile,
                    Directory = "Pictures",
                    CompressionQuality = 75,
                    PhotoSize = PhotoSize.Small,
                    DefaultCamera = CameraDevice.Front
                });

                if (file == null)
                    return;

                await Application.Current.MainPage.DisplayAlert("Localização do arquivo", file.Path, "OK");

                FotoSelecionada = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });

                // Enviar para o servidor

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao capturar foto: {ex.Message}");
            }
        }

        private async Task SelecionarFotoAsync()
        {
            try
            {
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await Application.Current.MainPage.DisplayAlert("Fotos Não Suportadas", "Permissão não ativada para obter fotos.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                {
                    PhotoSize = PhotoSize.Small,
                });

                if (file == null)
                    return;

                FotoSelecionada = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao selecionar foto: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
