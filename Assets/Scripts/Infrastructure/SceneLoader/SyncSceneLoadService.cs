using System;
using UnityEngine.SceneManagement;

namespace TDS.Assets.Infrastructure.SceneLoader
{
    public class SyncSceneLoadService : ISceneLoadService
    {
        private ISceneLoadService _sceneLoadServiceImplementation;
        
        public void Load(string sceneName, Action completeCallback)
        {
            SceneManager.LoadScene(sceneName);
            completeCallback?.Invoke();
        }
    }
}