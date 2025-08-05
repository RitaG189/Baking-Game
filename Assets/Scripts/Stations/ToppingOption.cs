using UnityEngine;
using UnityEngine.UI;

public class ToppingOption : MonoBehaviour, IClickable
{
    protected bool wasClicked = false;

    private Image taskIndicator;

    [SerializeField] private ToppingStation toppingStation;
    [SerializeField] private ToppingSO toppingSO;

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
        if (wasClicked && toppingStation.PlayerNear)
        {
            SetTaskIndicatorActive(false);
            Interact();
            wasClicked = false;
        }
    }

    private void SetTaskIndicatorActive(bool isActive)
    {
        if (taskIndicator == null)
            taskIndicator = gameObject.GetComponentInChildren<Image>();

        taskIndicator.enabled = isActive;
    }

    private void Interact()
    {
        if (toppingStation.IsCakeOnStation)
        {
            print(toppingSO.toppingName);
        }
    }
}
