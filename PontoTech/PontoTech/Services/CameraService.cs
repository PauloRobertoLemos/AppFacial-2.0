using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace PontoTech.Services
{
    public class CameraService
    {
        public async Task<Xamarin.Essentials.FileResult> CapturePhotoAsync()
        {
            try
            {
                var photo = await Xamarin.Essentials.MediaPicker.CapturePhotoAsync(new Xamarin.Essentials.MediaPickerOptions
                {
                    Title = "Tire uma foto"
                });

                return photo;
            }
            catch (Exception ex)
            {
                // Lidar com exceções ao tentar capturar uma foto
                Console.WriteLine($"Erro ao capturar foto: {ex.Message}");
                return null;
            }
        }
    }
}
