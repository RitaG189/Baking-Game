using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Baking/Decoration")]
public class DecorationSO : ScriptableObject
{
    public string decorationName;
    public Image sprite;
    public GameObject prefab;
}
