using UnityEngine;

public class Garbage : InteractableStation
{
    protected override void Interact()
    {
        if(playerNear)
            print("Garbage activated!");
    }
}
