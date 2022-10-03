using UnityEngine;

namespace TDS.Assets.Game
{
    public abstract class EnemyIdle : EnemyBehaviour
    {
        [SerializeField] private EnemyIdle _idle;

        private void OnEnabled()
        {
            _idle.enabled = true;
        }
    }
}