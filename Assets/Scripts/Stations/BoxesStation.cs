using UnityEngine;

public class BoxesStation : InteractableStation
{
    protected override void Interact()
    {
        if(PlayerNear)
            print("Placed cake inside box");
    }
}
