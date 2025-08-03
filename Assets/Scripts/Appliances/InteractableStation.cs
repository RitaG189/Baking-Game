using UnityEngine;
using UnityEngine.UI;

public abstract class InteractableStation : MonoBehaviour, IClickable
{
    protected bool playerNear = false;
    protected bool wasClicked = false;

    private Image taskIndicator;


    public void OnClick()
    {
        wasClicked = true;

        taskIndicator = gameObject.GetComponentInChildren<Image>();
        taskIndicator.enabled = true;

        TryActivate();
    }

    public void CancelClick()
    {
        wasClicked = false;
        taskIndicator.enabled = false;
        Debug.Log("Click cancelled");
    }

    public void TryActivate()
    {
        if (wasClicked && playerNear)
        {
            taskIndicator.enabled = false;
            Interact();
            wasClicked = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        playerNear = true;
        TryActivate();
    }

    void OnTriggerExit(Collider other)
    {
        playerNear = false;
    }

    // Método que cada estação vai implementar
    protected abstract void Interact();
}
