using TDS.Game.Enemy;
using UnityEngine;

namespace TDS.Assets.Game
{
    public class EnemyFollowAgro : EnemyFollow
    {
        [SerializeField] private EnemyFollow _enemyFollow;
        [SerializeField] private EnemyIdle _enemyIdle;
        [SerializeField] private EnemyBackToIdle _enemyBackToIdle;
        [SerializeField] private TriggerObserver _triggerObserver;

        [Header("Obstacles")]
        [SerializeField] private LayerMask _layer;

        private bool _isInAgro;
        private Transform _cashedTransform;

        private void Awake()
        {
            _cashedTransform = transform;
        }

        private void Start()
        {
            _triggerObserver.OnStayed += OnStayed;
            _triggerObserver.OnExited += OnExited;
        }

        private void OnStayed(Collider2D other)
        {
            if (_isInAgro)
                return;

            Vector3 currentPosition = _cashedTransform.position;
            Vector3 direction = other.ClosestPoint(currentPosition) - (Vector2) currentPosition;
            RaycastHit2D hit2D = Physics2D.Raycast(currentPosition, direction, direction.magnitude, _layer);

            Debug.DrawRay(currentPosition, direction);

            if (hit2D.collider == null)
            {
                EnterFollow();
            }
        }

        private void EnterFollow()
        {
            _isInAgro = true;
            if (_enemyIdle.IsActive)
            {
                _enemyIdle.Deactivate();
            }
            else
            {
                _enemyBackToIdle.Deactivate();
            }

            _enemyFollow.Activate();
        }

        private void OnExited(Collider2D other)
        {
            _enemyFollow.Deactivate();
            _enemyBackToIdle.Activate();
            _isInAgro = false;
        }
    }
}