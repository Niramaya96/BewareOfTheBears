using UnityEngine;

public class NewCharacterInput : MonoBehaviour
{
    private OverlapAttack _overlapAttack;
    private GameInput _gameInput;
    private IMovable _movable;
    private Vector3 _direction;

    private void Awake()
    {
        _gameInput = new GameInput();
        _gameInput.Enable();

        _movable = GetComponent<IMovable>();
        _overlapAttack = GetComponent<OverlapAttack>();
    }

    private void Update()
    {
        ReadMovement();
    }

    private void OnEnable()
    {
        _gameInput.Gameplay.Attack.performed += OnAttackPerformed;
    }
    private void OnDisable()
    {
        _gameInput.Gameplay.Attack.performed -= OnAttackPerformed;
    }
    private void OnAttackPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _overlapAttack.PerformAttack();
    }
    private void ReadMovement()
    {
        var readDirection = _gameInput.Gameplay.Movement.ReadValue<Vector2>();
        _direction = new Vector3(readDirection.x, 0, readDirection.y);
        _movable.Move(_direction);
    }
}
