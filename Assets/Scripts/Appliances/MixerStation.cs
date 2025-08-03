using UnityEngine;
using UnityEngine.EventSystems;

public class MixerStation : InteractableStation
{
    protected override void Interact()
    {
        if(playerNear)
            print("Mixer activated!");
    }
}
