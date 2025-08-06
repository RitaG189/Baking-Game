using System.Collections;
using UnityEngine;

public class OvenStation : InteractableStation
{
    public bool IsCakeOnStation { get; private set; } = false;

    [SerializeField] Transform placeCake;
    [SerializeField] Transform playerHand;
    [SerializeField] private int cookingTime;

    private GameObject cake;
    private Coroutine coroutine;

    protected override void Interact()
    {
        if (PlayerNear == true && IsCakeOnStation == false)
        {
            cake = PlayerManager.Instance.GetItemOnHands();

            Cake cakeScript = cake.GetComponent<Cake>();

            if (cakeScript.IsShaped == true && cakeScript.IsOnBox == false)
            {
                cake.transform.SetParent(placeCake);
                cake.transform.position = placeCake.position;

                IsCakeOnStation = true;

                StartCooking(cakeScript);
            }
        }
        else if (PlayerNear == true && IsCakeOnStation == true && PlayerManager.Instance.GetItemOnHands() == null)
        {
            StopCoroutine();

            cake.transform.SetParent(playerHand);
            cake.transform.position = playerHand.position;

            IsCakeOnStation = false;
        }
    }

    private void StartCooking(Cake cakeScript)
    {

        switch (cakeScript.CookedState)
        {
            case Cake.CookingState.Raw:
                coroutine = StartCoroutine(CookingTimer(cakeScript));
                break;

            case Cake.CookingState.Cooked:
                coroutine = StartCoroutine(CookingTimer(cakeScript));
                break;

            case Cake.CookingState.Burnt:
                break;
            default:
                break;
        }
    }

    private void StopCoroutine()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }

    IEnumerator CookingTimer(Cake cakeScript)
    {
        if (cakeScript.CookedState == Cake.CookingState.Raw)
        {
            print("Raw");
            yield return new WaitForSeconds(cookingTime);
            cakeScript.SetCookingState(Cake.CookingState.Cooked);
            print("Cooked");
        }

        if (cakeScript.CookedState == Cake.CookingState.Cooked)
        {
            yield return new WaitForSeconds(cookingTime);
            cakeScript.SetCookingState(Cake.CookingState.Burnt);
            print("Burnt");
        }
    }

}

