using System.Collections;
using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Objects
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyWeapon : MonoBehaviour
    {
        [SerializeField] private float _speed = 0.5f;
        [SerializeField] private float _lifeTime = 3f;
        [SerializeField] private int _playerDamage = 1;

        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.velocity = transform.up * _speed;

            StartCoroutine(LifeTimeTimer());
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag(Tags.Player))
            {
                col.gameObject.GetComponentInParent<PlayerHp>().ApplyDamage(_playerDamage);
            }
        }

        private IEnumerator LifeTimeTimer()
        {
            yield return new WaitForSeconds(_lifeTime);
            Destroy(gameObject);
        }
    }
}