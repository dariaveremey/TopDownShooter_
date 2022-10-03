using TDS.Assets.Infrastructure;
using UnityEngine;

namespace TDS.Assets.Game
{
    public interface IInputService : IService
    {
        Vector2 Axes { get; }
        Vector3 LookDirection { get; }
    }
}