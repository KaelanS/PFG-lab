using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollectable : Collectable
{
    [SerializeField] private string fruitType;
    
    public void CallPrint() 
    {
        PrintCollectableType(fruitType);
    }

    public override void PrintCollectableType(string type)
    {
        base.PrintCollectableType(type);
    }
}
