using UnityEngine;

namespace TDS.Assets.Game
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyDirectMovement : EnemyMovement
    {
        [SerializeField] private Transform _target;

        private Transform _cachedTransform;
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _cachedTransform = transform;
        }

        private void OnDisable()
        {
            SetVelocity(Vector2.zero);
        }

        private void FixedUpdate()
        {
            if (!IsTargetValid())
                return;

            MoveToTarget();
            RotateToTarget();
        }

        public override void SetTarget(Transform target)
        {
            _target = target;

            if (_target == null)
                SetVelocity(Vector2.zero);
        }

        private bool IsTargetValid() =>
            _target != null;

        private void MoveToTarget()
        {
            Vector3 direction = (_target.position - _cachedTransform.position).normalized;
            SetVelocity(direction * Spead);
        }

        private void RotateToTarget()
        {
            Vector3 direction = _target.position - _cachedTransform.position;
            _cachedTransform.up = direction;
        }

        private void SetVelocity(Vector2 velocity)
        {
            _rb.velocity = velocity;
            SetAnimationSpeed(velocity.magnitude);
        }
    }
}