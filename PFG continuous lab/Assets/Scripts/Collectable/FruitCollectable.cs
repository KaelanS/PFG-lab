using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollectable : Collectable
{
    [SerializeField] private FruitType fruitType;
    enum FruitType {Apple, Watermelon, Banana, Strawberry, Kiwi}
    
    public void CallPrint() 
    {
        switch(fruitType){
            case FruitType.Apple:
            PrintCollectableType("Apple");
            break;
            case FruitType.Watermelon:
            PrintCollectableType("Watermelon");
            break;
            case FruitType.Banana:
            PrintCollectableType("Banana");
            break;
            case FruitType.Strawberry:
            PrintCollectableType("Strawberry");
            break;
            case FruitType.Kiwi:
            PrintCollectableType("Kiwi");
            break;
        }
    }

    public override void PrintCollectableType(string type)
    {
        base.PrintCollectableType(type);
    }
}
