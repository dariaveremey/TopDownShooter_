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
        private IInputService _inputService;

        private void Start()
        {
            _aiPath.maxSpeed = Spead;
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            
            if (_destinationSetter.target != null)
            {
                SetAnimationSpeed(_aiPath.velocity.magnitude);
            }
        }
        public override void SetTarget(Transform target)
        {
            _destinationSetter.target = target;
            _aiPath.canMove = target != null;

            if (target == null)
            {
                SetAnimationSpeed(0);
            }
        }
    }
}