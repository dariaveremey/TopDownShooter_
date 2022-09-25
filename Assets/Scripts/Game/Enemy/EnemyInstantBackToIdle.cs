using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyInstantBackToIdle : EnemyBackToIdle
    {
        [SerializeField] private EnemyIdle _enemyIdle;

        public override void Activate()
        {
            base.Activate();

            Deactivate();
            _enemyIdle.Activate();
        }
        /*[Header("Movement")]
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private EnemyDirectMovement _enemyDirectMovement;
        [SerializeField] private EnemyMoveToPlayer _enemyMoveToPlayer;

        [Header("Float")]
        [SerializeField] private float _speed;
        [SerializeField] private float _startWaitTime;
        [SerializeField] private float _minX;
        [SerializeField] private float _maxX;

        private Transform _movePosition;
        private Transform _enemyTransform;
        private Vector3 _startPosition;
        private float _waitTime;

        private void Awake()
        {
            _startPosition = transform.position;
            _enemyIdle.enabled = false;
            _enemyDirectMovement.enabled = false;
            _enemyMoveToPlayer.enabled = false;
            _triggerObserver.OnEntered += OnEntered;
            _triggerObserver.OnExited += OnExited;
        }

        private void Start()
        {
            _waitTime = _startWaitTime;
            //_movePosition.position = new Vector2(Random.Range(_minX, _maxX), _startPosition.y);
        }

        private void OnEntered(Collider2D col)
        {
        }

        private void OnExited(Collider2D col)
        {
            transform.position = _startPosition;
            //Patrol();
            _enemyIdle.Deactivate();
            _enemyDirectMovement.Deactivate();
            _enemyMoveToPlayer.Deactivate();
        }

        private void Patrol()
        {
            transform.position =
                Vector2.MoveTowards(transform.position, _movePosition.position, _speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, _movePosition.position) < 0.2f)
            {
                if (_waitTime <= 0)
                {
                    _movePosition.position = new Vector2(Random.Range(_minX, _maxX), _startPosition.y);
                    _waitTime = _startWaitTime;
                }
                else
                {
                    _waitTime -= Time.deltaTime;
                }
            }
        }*/
    }
}