using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }
    [SerializeField] private GameObject playerHand;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public GameObject GetItemOnHands()
    {
        var cake = playerHand.GetComponentInChildren<Cake>()?.gameObject;
        if (cake != null)
            return cake;

        var dough = playerHand.GetComponentInChildren<Dough>()?.gameObject;
        if (dough != null)
            return dough;

        return null;
    }
}
