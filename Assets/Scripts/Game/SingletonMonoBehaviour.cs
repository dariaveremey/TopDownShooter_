using UnityEngine;

namespace TDS.Assets.Scripts.Game
{
    public class SingletonMonoBehavior<T> : MonoBehaviour
    {
        public static T Instance { get; private set; }

        protected void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = GetComponent<T>();
            DontDestroyOnLoad(gameObject);
        }
    }
}