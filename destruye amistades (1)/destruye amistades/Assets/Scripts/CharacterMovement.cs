using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    public InputActionAsset inputActionAsset; // Arrastra aquí el Input Action en el inspector
    private InputAction moveAction;
    private Vector2 movementInput;

    private void OnEnable()
    {
        var playerActionMap = inputActionAsset.FindActionMap("Player");
        moveAction = playerActionMap.FindAction("Move");
        moveAction.Enable();

        moveAction.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        moveAction.canceled += ctx => movementInput = Vector2.zero;
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    private void Update()
    {
        Vector3 move = new Vector3(movementInput.x, movementInput.y, 0);
        transform.position += move * Time.deltaTime * 5f; // Cambia la velocidad según necesites
    }
}

