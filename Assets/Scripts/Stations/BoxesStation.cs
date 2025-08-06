using UnityEngine;

public class BoxesStation : InteractableStation
{
    [SerializeField] GameObject boxPrefab;
    protected override void Interact()
    {
        if (PlayerNear)
        {
            var cake = PlayerManager.Instance.GetItemOnHands()?.GetComponent<Cake>();

            if (cake != null)
            {
                cake.IsOnBox = true;

                Instantiate(boxPrefab, cake.transform);   
            }
        }
    }
}
