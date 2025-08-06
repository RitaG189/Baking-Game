using System;
using UnityEngine;

public class Cake : MonoBehaviour
{
    [SerializeField] Material cookedMaterial, burntMaterial;
    [SerializeField] GameObject shape;

    public CookingState CookedState { get; private set; } = CookingState.Raw;
    public ShapeSO Shape { get; private set; }
    public ToppingSO Topping { get; private set; }
    public DecorationSO Decoration { get; private set; }
    public bool IsOnBox { get; set; } = false;
    public bool IsCooked { get; private set; } = false;
    public bool IsShaped { get; private set; } = true;

    public void SetShape(ShapeSO shape)
    {
        Shape = shape;

        IsShaped = true;
    }

    public void SetTopping(ToppingSO topping)
    {
        Topping = topping;

        if (Shape.shapeName == "Round")
            Instantiate(topping.prefabRound, gameObject.transform);   
        else if(Shape.shapeName == "Square")
            Instantiate(topping.prefabSquare, gameObject.transform);    
    }

    public void SetDecoration(DecorationSO decoration)
    {
        Decoration = decoration;
        Instantiate(decoration.prefab, gameObject.transform);
    }

    public void SetCookingState(CookingState state)
    {
        CookedState = state;

        switch (CookedState)
        {
            case CookingState.Raw:
                IsCooked = false;
                break;

            case CookingState.Cooked:
                IsCooked = true;
                gameObject.GetComponent<MeshRenderer>().material = cookedMaterial;
                break;

            case CookingState.Burnt:
                IsCooked = true;
                gameObject.GetComponent<MeshRenderer>().material = burntMaterial;
                break;

            default:
                break;
        }
    }

    public void RemoveShape()
    {
        Destroy(shape);
        IsShaped = false;
    }

    public enum CookingState
    {
        Raw,
        Cooked,
        Burnt
    }
}
