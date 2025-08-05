using UnityEngine;

public class OvenStation : InteractableStation
{
    protected override void Interact()
    {
        if(PlayerNear)
            print("Placed dough on oven station");
    }
}
