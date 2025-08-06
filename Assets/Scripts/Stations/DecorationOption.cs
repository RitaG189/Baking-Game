using UnityEngine;
using UnityEngine.UI;

public class DecorationOption : MonoBehaviour, IClickable
{
    protected bool wasClicked = false;

    private Image taskIndicator;

    [SerializeField] private BaseStation decorationStation;
    [SerializeField] private DecorationSO decorationSO;

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
        if (wasClicked && decorationStation.PlayerNear)
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
        if (decorationStation.IsItemOnStation)
        {
            Cake cake = decorationStation.GetComponentInChildren<Cake>();

            if (cake.Decoration == null && cake.IsCooked && cake.IsOnBox == false)
            {
                cake.RemoveShape();
                cake.SetDecoration(decorationSO);
            }
        }
    }
}
