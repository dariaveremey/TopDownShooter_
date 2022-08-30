using TDS.Assets.Scripts.Game.Player;
using UnityEngine;

namespace TDS.Assets.Scripts.Game.Zombie
{
    public class ZombieMovement : MonoBehaviour

    {
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private float _speed = 5f;
        [SerializeField] private int _rotationOffset = -90;

        private float _rotZ;

        private void Update()
        {
            if (Statistics.Instance.LifeNumberZombie <= 0)
            {
                return;
            }

            Move();
        }

        private void Move()
        {
            Vector3 difference = _playerTransform.position - transform.position;
            _rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            Quaternion rotation = Quaternion.AngleAxis(_rotZ + _rotationOffset, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * _speed);
        }
    }
}