using UnityEngine.SceneManagement;


namespace TDS.Assets.Scripts.Game

{
    public class SceneLoader : SingletonMonoBehavior<SceneLoader>
    {
        public void LoadStartSceneScene()
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}