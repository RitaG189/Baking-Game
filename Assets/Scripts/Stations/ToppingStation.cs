using UnityEngine;

public class ToppingStation : InteractableStation
{
    public bool IsCakeOnStation { get; private set; } = false;
    [SerializeField] Transform station;
    [SerializeField] Transform playerHand;

    private GameObject cake;

    protected override void Interact()
    {
        if (PlayerNear && !IsCakeOnStation)
        {
            cake = PlayerManager.Instance.GetCakeOnHands();

            cake.transform.SetParent(station);
            cake.transform.position = station.transform.position;

            print("Placed cake on topping station");
            IsCakeOnStation = true;
        }
        else if (PlayerNear && IsCakeOnStation && PlayerManager.Instance.GetCakeOnHands() == null)
        {
            cake.transform.SetParent(playerHand);
            cake.transform.position = playerHand.transform.position;


            print("Picked cake from topping station");
            IsCakeOnStation = false;
        }
    }

}
