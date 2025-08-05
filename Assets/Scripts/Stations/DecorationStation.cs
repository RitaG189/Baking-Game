using UnityEngine;

public class DecorationStation : InteractableStation
{
    protected override void Interact()
    {
        if(PlayerNear)
            print("Placed cake on decoration station");
    }
}
