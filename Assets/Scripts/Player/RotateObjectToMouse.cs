using UnityEngine;
using UnityEngine.InputSystem;

public class RotateObjectToMouse : MonoBehaviour
{
    private Camera cam;

    [SerializeField] private float defaultAngle;
    private Vector2 mousePosition;

    [SerializeField] private InputActionsSO inputActions;

    private void OnEnable() => inputActions.OnLookEvent += OnAim;

    private void OnDisable() => inputActions.OnLookEvent -= OnAim;

    private void Start() => cam = Camera.main;

    private void Update() => RotateObject(mousePosition);

    private void OnAim(Vector2 look) => mousePosition = look;

    private void RotateObject(Vector2 inputVector)
    {
        var dirToMouse = cam.ScreenToWorldPoint(inputVector) - transform.position;
        dirToMouse.Normalize();

        var rotation = Mathf.Atan2(dirToMouse.y, dirToMouse.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation - defaultAngle);
    }
}
