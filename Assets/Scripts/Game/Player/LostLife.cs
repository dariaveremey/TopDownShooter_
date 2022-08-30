using System.Collections;
using TDS.Assets.Scripts.Game.Objects;
using UnityEngine;

namespace TDS.Assets.Scripts.Game.Player
{
    public class LostLife : MonoBehaviour
    {
        [SerializeField] private PlayerAnimation _playerAnimation;
        [SerializeField] private float _reloadScene = 5f;

        private void Update()
        {
            if (Statistics.Instance.LifeNumber <= 0)
            {
                PlayerDeath();
                StartCoroutine(LifeEndTimer());
            }
        }

        private void OnCollisionEnter2D(Collision2D col)

        {
            if (col.gameObject.CompareTag(Tags.Bullet))
            {
                Statistics.Instance.IncrementLife(-1);
                Bullet component = col.gameObject.GetComponent<Bullet>();
                Destroy(col.gameObject);
            }
        }

        private void PlayerDeath()
        {
            _playerAnimation.Death();
        }

        private IEnumerator LifeEndTimer()
        {
            yield return new WaitForSeconds(_reloadScene);
            SceneLoader.Instance.LoadStartSceneScene();
            Statistics.Instance.IncrementLife(5);
        }
    }
}