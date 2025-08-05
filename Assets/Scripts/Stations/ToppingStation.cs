using UnityEngine;

public class ToppingStation : InteractableStation
{
    public bool IsCakeOnStation { get; private set; } = false;


    protected override void Interact()
    {
        if (PlayerNear && !IsCakeOnStation)
        {
            print("Placed cake on topping station");
            IsCakeOnStation = true;
        }
        else if (PlayerNear && IsCakeOnStation)
        {
            print("Picked cake from topping station");
            IsCakeOnStation = false;
        }
    }

}
