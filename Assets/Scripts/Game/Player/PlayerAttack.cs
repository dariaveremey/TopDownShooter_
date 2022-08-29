using UnityEngine;

namespace TDS.Assets.Scripts.Game.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private PlayerAnimation _playerAnimation;
        
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnPointTransform;
        [SerializeField] private float _fireDelay = 0.3f;
        

        private Transform _cachedTransform;
        private float _timer;

        private void Awake()
        {
            _cachedTransform = transform;
        }

        private void Update()
        {
            TickTimer();
            if (CanAttack())
            {
                Attack();
            }
        }

        private bool CanAttack()
        {
            return Input.GetButton("Fire1") && _timer <= 0;
        }

        private void Attack()
        {
            if (Statistics.Instance.LifeNumber <= 0)
            {
                return;
            }
            
            _playerAnimation.PlayShoot();
            Instantiate(_bulletPrefab, _bulletSpawnPointTransform.position, _cachedTransform.rotation);
            _timer = _fireDelay;
        }

        private void TickTimer()
        {
            _timer -= Time.deltaTime;
        }
    }
}