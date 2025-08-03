using UnityEngine;

public class DecorationStation : InteractableStation
{
    protected override void Interact()
    {
        if(playerNear)
            print("Decoration activated!");
    }
}
