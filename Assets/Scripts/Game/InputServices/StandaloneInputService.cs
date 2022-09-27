using TDS.Game.InputServices;
using UnityEngine;

public class StandaloneInputService : IInputService
{
    private readonly Camera _mainCamera;
    private readonly Transform _playerMovementTransform;

    public Vector2 Axes => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    public Vector3 LookDirection => GetLookDirection();

    public StandaloneInputService(Camera camera, Transform playerMovementTransform)
    {
        _mainCamera = camera;
        _playerMovementTransform = playerMovementTransform;
    }
    
    private Vector3 GetLookDirection()
    {
    }

}