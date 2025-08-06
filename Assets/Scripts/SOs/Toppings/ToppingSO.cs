using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Baking/Topping")]
public class ToppingSO : ScriptableObject
{
    public string toppingName;
    public Image sprite;
    public GameObject prefabRound;
    public GameObject prefabSquare;

}
