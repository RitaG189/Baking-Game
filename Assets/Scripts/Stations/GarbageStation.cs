using UnityEngine;

public class GarbageStation : InteractableStation
{
    [SerializeField] private GameObject playerHand;

    protected override void Interact()
    {
        if (PlayerNear)
        {
            // finds gameobject with name "cake" on player's hand
            GameObject cake = PlayerManager.Instance.GetItemOnHands();

            if (cake != null)
                ThrowAway(cake);
            else
                print("No cake on hand");
        }
    }

    private void ThrowAway(GameObject cake)
    {
        Destroy(cake);
        print("Cake Destroyed");

    }
}
