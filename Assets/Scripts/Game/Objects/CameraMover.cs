using UnityEngine;

namespace TDS.Assets.Game
{
    public class CameraMover : MonoBehaviour
    {
        [SerializeField] private Transform _follow;
        private Transform _cachedTransform;

        private void Awake()
        {
            _cachedTransform = transform;
        }

        private void LateUpdate()
        {
            Vector3 followPosition = _follow.position;
            followPosition.z = _cachedTransform.position.z;

            _cachedTransform.position = followPosition;
        }
    }
}