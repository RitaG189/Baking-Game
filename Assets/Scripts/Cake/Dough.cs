using UnityEngine;

public class Dough : MonoBehaviour
{
    public void SetCake(ShapeSO shape, Transform placeItem)
    {
        Instantiate(shape.prefab, placeItem);
        Destroy(gameObject);
    }
}
