using UnityEngine;

public class BoxesStation : InteractableStation
{
    protected override void Interact()
    {
        if(playerNear)
            print("Box activated!");
    }
}
