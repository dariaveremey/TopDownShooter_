namespace TDS.Assets.Infrastructure
{
    public interface ILoadingScreenService:IService
    {
        void HideScreen();
        void ShowScreen();
    }
}