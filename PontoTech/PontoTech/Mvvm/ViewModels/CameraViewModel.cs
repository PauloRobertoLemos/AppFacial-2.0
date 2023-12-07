using System.Threading.Tasks;
using PontoTech.Services; // Certifique-se de ajustar o namespace conforme a estrutura do seu projeto

namespace PontoTech.ViewModels
{
    public class CameraViewModel : View // Supondo que esteja utilizando a classe View de seu framework
    {
        private readonly CameraService cameraService;

        public CameraViewModel(CameraService cameraService)
        {
            this.cameraService = cameraService;
        }

        public async Task CapturePhoto()
        {
            var photo = await cameraService.CapturePhotoAsync();

            // Aqui você pode processar a foto capturada, exibir na UI, salvar, etc.
            // Certifique-se de lidar com o objeto MediaFile retornado conforme necessário
        }
    }
}
