using UnityEngine;
using UnityEngine.UI;

public abstract class InteractableStation : MonoBehaviour, IClickable
{
    public bool PlayerNear { get; private set; } = false;
    protected bool wasClicked = false;

    private Image taskIndicator;


    public void OnClick()
    {
        wasClicked = true;

        SetTaskIndicatorActive(true);

        TryActivate();
    }

    public void CancelClick()
    {
        wasClicked = false;
        SetTaskIndicatorActive(false);
        Debug.Log("Click cancelled");
    }

    public void TryActivate()
    {
        if (wasClicked && PlayerNear)
        {
            SetTaskIndicatorActive(false);
            Interact();
            wasClicked = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerNear = true;
        TryActivate();
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerNear = false;
    }

    private void SetTaskIndicatorActive(bool isActive)
    {
        if(taskIndicator == null)
            taskIndicator = gameObject.GetComponentInChildren<Image>();

        taskIndicator.enabled = isActive;
    }

    // Método que cada estação vai implementar
    protected abstract void Interact();
}
