using System;
using UnityEngine;

public class BaseStation : InteractableStation
{
    public bool IsItemOnStation { get; private set; } = false;
    [SerializeField] Transform placeItem;
    [SerializeField] Transform playerHand;

    private GameObject item;

    protected override void Interact()
    {
        if (PlayerNear && !IsItemOnStation)
        {
            item = PlayerManager.Instance.GetItemOnHands();
            print(item);

            if (item != null)
            {
                item.transform.SetParent(placeItem);
                item.transform.position = placeItem.position;
                IsItemOnStation = true;
            }
        }
        else if (PlayerNear && IsItemOnStation && PlayerManager.Instance.GetItemOnHands() == null && item != null)
        {
            item.transform.SetParent(playerHand);
            item.transform.position = playerHand.position;

            IsItemOnStation = false;
        }
    }

    public void SetNewCake()
    {
        item = gameObject.GetComponentInChildren<Cake>()?.gameObject;;
    }

}
