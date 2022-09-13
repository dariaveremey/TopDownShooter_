using UnityEngine;

namespace TDS.Game.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerAnimation _playerAnimation;
        [SerializeField] private PlayerHp _playerHp;
        [SerializeField] private float _speed = 4f;
        private Transform _cachedTransform;
        private Camera _mainCamera;
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _cachedTransform = transform;
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if (_playerHp.CurrentHp <= 0)
            {
                return;
            }

            Move();
            Rotate();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (!col.gameObject.CompareTag(Tags.Bonuses))
            {
                return;
            }

            Destroy(col.gameObject);
        }

        private void Move()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector2 direction = new Vector2(horizontal, vertical);
            Vector3 moveDelta = direction * (_speed);
            _rb.velocity = moveDelta;

            _playerAnimation.SetSpeed(direction.magnitude);
        }

        private void Rotate()
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPoint = _mainCamera.ScreenToWorldPoint(mousePosition);
            worldPoint.z = 0f;

            Vector3 direction = worldPoint - _cachedTransform.position;
            _cachedTransform.up = direction;
        }
    }
}