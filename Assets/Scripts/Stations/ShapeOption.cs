using UnityEngine;
using UnityEngine.UI;

public class ShapesOption : MonoBehaviour, IClickable
{
    protected bool wasClicked = false;

    private Image taskIndicator;

    [SerializeField] private BaseStation shapeStation;
    [SerializeField] private Transform placeItem;
    [SerializeField] private ShapeSO shapeSO;

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
    }

    public void TryActivate()
    {
        if (wasClicked && shapeStation.PlayerNear)
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
        if (shapeStation.IsItemOnStation)
        {
            Dough dough = shapeStation.GetComponentInChildren<Dough>();

            if (dough != null)
            {
                dough.SetCake(shapeSO, placeItem);

                shapeStation.SetNewCake();

                Cake cake = shapeStation.GetComponentInChildren<Cake>();
                cake.SetShape(shapeSO);
            }
        }
    }
}
