using System;
using TDS.Assets.Infrastructure.ServicesContainer;

namespace TDS.Assets.Infrastructure.SceneLoader
{
    public interface ISceneLoadService: IService
    {
        void Load(string sceneName, Action completeCallback);
    }
}