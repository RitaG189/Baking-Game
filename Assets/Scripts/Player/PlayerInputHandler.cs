using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private InputSystem_Actions inputActions;

    public event Action OnClickPerformedEvent;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Click.performed += Click;
    }

    private void OnDisable()
    {
        inputActions.Player.Click.performed -= Click;
        inputActions.Disable();
    }

    private void Click(InputAction.CallbackContext context)
    {
        OnClickPerformedEvent?.Invoke();
    }
}
