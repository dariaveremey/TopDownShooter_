using UnityEngine;

namespace TDS.Game
{
    public class ChangeLevel:MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag(Tags.Player))
            {
                SceneLoader.Instance.LoadNextLevel();

            }
        }
    }
}