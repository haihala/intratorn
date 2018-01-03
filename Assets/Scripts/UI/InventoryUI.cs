using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class InventoryUI : MonoBehaviour {

    public Inventory target;
    public Transform items;
    public Transform effects;
    public TextMeshProUGUI hilight;
    public GameObject itemPrefab;
    public GameObject effectPrefab;

    public void Open_tab(string Tab){
        Clear_items();

        switch (Tab) {
            case "ALL": 
                Add_items(target.Content);
                break;
            
            default:
                System.Type type = System.Type.GetType(Tab);
                Add_items(Items_of_type(type));
                break;
        }
    }

    public void Inspect(Item to_inspect){
        hilight.text = to_inspect.Inspect();
    }

    #region Privates
    void Clear_items(){
        foreach (Transform child in items) {
            GameObject.Destroy(child.gameObject);
        }
    }

    void Add_items(List<Item> to_add){
        foreach(Item item in to_add) {
            InventoryItem tmp = Instantiate(itemPrefab, items).GetComponent<InventoryItem>();
            tmp.Set_values(item, this);
        }
    }

    List<Item> Items_of_type(System.Type type){
        List<Item> ret = new List<Item>();
        foreach(Item item in target.Content) {
            if (item.GetType() == type 
                || item.GetType().IsSubclassOf(type)) {
                ret.Add(item);
            }
        }
        return ret;
    }
    
    void Add_effect (Effect effect) {

    }

    #endregion Privates
}
