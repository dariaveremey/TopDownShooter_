using UnityEngine.SceneManagement;

namespace TDS.Game

{
    public class SceneLoader : SingletonMonoBehavior<SceneLoader>
    {
        public void LoadStartSceneScene()
        {
            SceneManager.LoadScene(Scenes.Level1);
        }

        public void LoadNextLevel()
        {
            SceneManager.LoadScene(Scenes.Level2);
        }
    }
}