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

    public GameObject GetCakeOnHands()
    {
        GameObject cake = playerHand.GetComponentInChildren<Cake>()?.gameObject;

        if (cake != null)
            return cake;

        return null;
    }
}
