using UnityEngine;

public class OvenStation : InteractableStation
{
    protected override void Interact()
    {
        if(playerNear)
            print("Oven activated!");
    }

}
