using UnityEngine;

public interface IClickable
{
    void OnClick();
    void TryActivate();    
    void CancelClick();
}
