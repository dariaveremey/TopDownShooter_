using TDS.Game.Enemy;
using UnityEditor;

namespace TDS.Assets.Scripts.Game
{
    [CustomEditor(typeof(PathPatrol))]
    public class PatrolPathEditor:Editor
    {
        [DrawGizmo(GizmoType.Selected | GizmoType.Active)]
        private static void DrawGizmoForMyScript(PathPatrol path, GizmoType gizmoType)
        {
            path.CurrentPoint();
        }
    }
}