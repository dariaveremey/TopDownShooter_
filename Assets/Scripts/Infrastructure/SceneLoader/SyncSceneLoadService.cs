using System;
using System.Collections;
using UnityEngine.SceneManagement;

namespace TDS.Assets.Infrastructure
{
    public class SyncSceneLoadService : ISceneLoadService
    {
        private ISceneLoadService _sceneLoadServiceImplementation;
        private readonly ICoroutineRunner _coroutineRunner;

        public SyncSceneLoadService(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }
        
        public void Load(string sceneName, Action completeCallback)
        {
            SceneManager.LoadScene(sceneName);
            _coroutineRunner.StartCoroutine(WaitFrames(1, completeCallback));

        }
        private IEnumerator WaitFrames(int count, Action completeCallback)
        {
            yield return null;
            completeCallback?.Invoke();
        }
    }
}