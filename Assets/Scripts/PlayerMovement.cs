using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private UnitStats playerStats;
    private float speed = 2f;

    [SerializeField] private InputActionsSO inputAction;
    private Rigidbody2D rb;
    private Vector2 inputVector;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = playerStats.Speed;
    }

    private void OnEnable() => inputAction.OnMoveEvent += Move;

    private void OnDisable() => inputAction.OnMoveEvent -= Move;

    private void FixedUpdate() => rb.velocity = inputVector * speed;

    private void Move(Vector2 movement) => inputVector = movement;
}
