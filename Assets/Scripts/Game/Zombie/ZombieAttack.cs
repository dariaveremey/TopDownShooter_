using System.Collections;
using TDS.Assets.Scripts.Game.Player;
using TDS.Assets.Scripts.Game.Zombie;
using UnityEngine;

namespace TDS.Assets.Scripts.Zombie
{
    public class ZombieAttack : MonoBehaviour
    {
        [SerializeField] private Transform _weaponSpawnPointTransform;
        [SerializeField] private GameObject _weaponPrefab;
        [SerializeField] private ZombieAnimation _zombieAnimation;
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private float _timeBetweenSeries = 2f;
        [SerializeField] private float _timeBetweenBullets = 1f;
        [SerializeField] private int _weaponAmount = 5;

        private void Start()
        {
            InvokeRepeating("Shoot", 0f, _timeBetweenSeries);
        }

        private void Shoot()
        {
            if (Statistics.Instance.LifeNumberZombie <= 0)
            {
                return;
            }

            StartCoroutine(ShootCoroutine());
            _zombieAnimation.ZombieShoot();
        }

        private IEnumerator ShootCoroutine()
        {
            int i = 0;
            while (i < _weaponAmount)
            {
                GameObject weapon = Instantiate(_weaponPrefab, _weaponSpawnPointTransform.transform);
                Destroy(weapon, 3f);
                yield return new WaitForSeconds(_timeBetweenBullets);
                i++;
            }
        }
    }
}