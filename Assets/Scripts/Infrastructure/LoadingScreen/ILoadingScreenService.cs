using TDS.Assets.Infrastructure.ServicesContainer;

namespace TDS.Assets.Infrastructure.LoadingScreen
{
    
    public interface ILoadingScreenService:IService
    {
        void HideScreen();
        void ShowScreen();
    }
}