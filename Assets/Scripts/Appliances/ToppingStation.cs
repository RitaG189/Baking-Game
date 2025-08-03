using UnityEngine;

public class ToppingStation : InteractableStation
{
    protected override void Interact()
    {
        if(playerNear)
            print("Topping activated!");
    }
}
