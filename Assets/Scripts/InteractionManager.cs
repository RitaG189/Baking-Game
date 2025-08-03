using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    private IClickable currentTarget;

    public void HandleClick(RaycastHit hit)
        {
            if (hit.collider.TryGetComponent<IClickable>(out var newTarget))
            {
                // Cancela o anterior
                if (currentTarget != null && currentTarget != newTarget)
                    currentTarget.CancelClick();

                currentTarget = newTarget;
                currentTarget.OnClick();
            }
            else
            {
                // Clicou fora de objetos interativos — limpa o atual
                currentTarget?.CancelClick();
                currentTarget = null;
            }
        }
}
