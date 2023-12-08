using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace PontoTech.Mvvm.ViewModels
{
    public class CapturaPageViewModel
    {
        public ICommand BtnCapturarCommand { get; private set; }

        public CapturaPageViewModel()
        {
            BtnCapturarCommand = new Command(async () => await CapturarFotoAsync());
        }

        private async Task CapturarFotoAsync()
        {
            try
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    // Lidar com a situação em que a câmera não está disponível
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = "sample.jpg"
                });

                if (file != null)
                {
                    // Salvar o arquivo no armazenamento local
                    string localFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), file.Path);

                    using (var sourceStream = file.GetStream())
                    {
                        using (var destinationStream = File.OpenWrite(localFilePath))
                        {
                            await sourceStream.CopyToAsync(destinationStream);
                        }
                    }

                    // Aqui você pode realizar outras operações com a foto capturada, se necessário
                }
            }
            catch (Exception ex)
            {
                // Lidar com a exceção
                Console.WriteLine($"Erro ao capturar foto: {ex.Message}");
                // Aqui você pode tratar a exceção de acordo com o fluxo da sua aplicação
                // Por exemplo, exibir uma mensagem de erro para o usuário
            }
        }
    }
}
