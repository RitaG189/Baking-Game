using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Baking/Shape")]
public class ShapeSO : ScriptableObject
{
    public string shapeName;
    public Image sprite;
    public GameObject prefab;
}
