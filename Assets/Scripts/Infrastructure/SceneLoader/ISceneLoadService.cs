using System;

namespace TDS.Assets.Infrastructure
{
    public interface ISceneLoadService: IService
    {
        void Load(string sceneName, Action completeCallback);
    }
}