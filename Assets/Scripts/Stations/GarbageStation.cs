using UnityEngine;

public class GarbageStation : InteractableStation
{
    protected override void Interact()
    {
        if(PlayerNear)
            print("Threw cake away");
    }
}
