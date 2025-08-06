using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MixerStation : InteractableStation
{
    [SerializeField] GameObject doughPrefab;
    [SerializeField] Transform playerHand;
    [SerializeField] float remixTime;
    [SerializeField] int maxDoughProduced;
    [SerializeField] TextMeshProUGUI doughQuantityText;

    private int doughAvailable = 0;
    private bool isRemixing = false;

    void Start()
    {
        doughAvailable = maxDoughProduced;
        UpdateText();
    }

    protected override void Interact()
    {
        if (PlayerNear && doughAvailable >= 1 && PlayerManager.Instance.GetItemOnHands() == null)
        {
            Instantiate(doughPrefab, playerHand);
            doughAvailable -= 1;
            UpdateText();
        }
        else if (doughAvailable < 1 && !isRemixing)
            Remix();
    }

    private void Remix()
    {
        // remixes for the set time, player can't interact with mixer
        StartCoroutine(RemixTimer());
    }

    IEnumerator RemixTimer()
    {
        yield return new WaitForSeconds(remixTime);
        doughAvailable = maxDoughProduced;
        UpdateText();
    }

    private void UpdateText()
    {
        doughQuantityText.text = doughAvailable.ToString();
    }
}
