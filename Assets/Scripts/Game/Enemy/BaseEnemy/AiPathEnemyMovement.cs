using Pathfinding;
using UnityEngine;

namespace TDS.Assets.Game
{
    [RequireComponent(typeof(AIDestinationSetter))]
    [RequireComponent(typeof(Seeker))]
    public class AiPathEnemyMovement : EnemyMovement
    {
        [Header(nameof(AiPathEnemyMovement))]
        [SerializeField] private AIDestinationSetter _destinationSetter;
        [SerializeField] private AIBase _aiPath;
        [SerializeField] private Transform _target;
        private IInputService _inputService;

        private void Start()
        {
            _aiPath.maxSpeed = Spead;
        }

        private void Update()
        {
            if (_destinationSetter.target != null)
            {
                SetAnimationSpeed(_aiPath.velocity.magnitude);
            }
        }
        private void Rotate()
        {
            Vector3 difference = _target.position - transform.position;
            transform.up = difference;
        }
        public override void SetTarget(Transform target)
        {
            _destinationSetter.target = target;
            Rotate();
            _aiPath.canMove = target != null;

            if (target == null)
            {
                SetAnimationSpeed(0);
            }
        }
    }
}