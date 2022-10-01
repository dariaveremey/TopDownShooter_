using System.Collections;
using Lean.Pool;
using TDS.Game.Enemy;
using UnityEngine;

namespace TDS.Game.Objects
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed = 0.5f;
        [SerializeField] private float _lifeTime = 3f;
        [SerializeField] private int _enemyDamage = 1;

        private Rigidbody2D _rb;
        private IEnumerator _lifeTimeRoutine;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            _rb.velocity = transform.up * _speed;
            _lifeTimeRoutine = LifeTimeTimer();
            StartCoroutine(_lifeTimeRoutine);
        }

        private void OnDisable()
        {
            if (_lifeTimeRoutine != null)
            {
                StopCoroutine(_lifeTimeRoutine);
                _lifeTimeRoutine = null;
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag(Tags.Enemy))
            {
                col.gameObject.GetComponentInParent<EnemyHp>().ApplyDamage(_enemyDamage);
                DeSpawn();
            }
        }

        private IEnumerator LifeTimeTimer()
        {
            yield return new WaitForSeconds(_lifeTime);
            DeSpawn();
        }

        private void DeSpawn()
        {
            LeanPool.Despawn(gameObject);
        }
    }
}