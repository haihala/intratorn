using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Galilei/Inventory")]
public class Inventory : ScriptableObject {
    public List<Item> Content;

    public float Weight() {
        float sum = 0;
        foreach (Item i in Content) {
            sum += i.Weight;
        }
        return sum;
    }
}
