using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
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

        public async Task CapturarFotoAsync()
        {
            try
            {
                if (MediaPicker.Default.IsCaptureSupported)
                {
                    FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                    if (photo != null)
                    {
                        // Salvar o arquivo no armazenamento local
                        string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                        using (Stream sourceStream = await photo.OpenReadAsync())
                        {
                            using (FileStream localFileStream = File.OpenWrite(localFilePath))
                            {
                                await sourceStream.CopyToAsync(localFileStream);
                            }
                        }
                    }
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
