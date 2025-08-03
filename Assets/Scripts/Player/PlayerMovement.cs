using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInputHandler inputHandler;
    private Vector3 destination;
    
    [SerializeField] private InteractionManager interactionManager;

    void Awake()
    {
        inputHandler = GetComponent<PlayerInputHandler>();
        inputHandler.OnClickPerformedEvent += Click;
    }

    private void Click()
    {
        Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();

        Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            destination = hitInfo.point;
            GetComponent<NavMeshAgent>().SetDestination(destination);

            interactionManager.HandleClick(hitInfo);
        }
    }

    private void OnDestroy()
    {
        if (inputHandler != null)
            inputHandler.OnClickPerformedEvent -= Click;
    }
}
