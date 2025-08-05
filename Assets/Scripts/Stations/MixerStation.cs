using UnityEngine;
using UnityEngine.EventSystems;

public class MixerStation : InteractableStation
{
    protected override void Interact()
    {
        if(PlayerNear)
            print("Mixer activated!");
    }
}
