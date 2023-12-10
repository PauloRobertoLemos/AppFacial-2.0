using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace PontoTech.Mvvm.ViewModels
{
    public class CapturaPageViewModel : INotifyPropertyChanged
    {
        public ICommand BtnCapturarCommand { get; private set; }
        


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

                        using (Stream sourceStream = await photo.OpenReadAsync())
                        {
                            using (FileStream localFileStream = File.OpenWrite(localFilePath))
                            {
                                await sourceStream.CopyToAsync(localFileStream);
                            }
                        }

                    }
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
