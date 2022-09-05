using UnityEngine.SceneManagement;

namespace TDS.Game

{
    public class SceneLoader : SingletonMonoBehavior<SceneLoader>
    {
        public void LoadStartSceneScene()
        {
            SceneManager.LoadScene(Scenes.StartScene);
        }
    }
}