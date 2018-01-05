using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

    public Inventory target;
    public Transform items;
    public Transform effects;
    public TextMeshProUGUI hilight;
    public GameObject itemPrefab;
    public GameObject effectPrefab;
    public Item selected;

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

    public void Inspect(Item item){
        hilight.text = item.Inspect();
    }

    public void Select(Item item) {
        selected = item;
    }

    public void Deselect() {
        selected = null;
    }

    #region Privates
    
    void Update() {
        if (selected) {
            if (Input.GetMouseButtonDown(1)) {
                Type stype = selected.GetType();
                if (stype == typeof(Armor)) {
                    if (target.armor == selected) {
                        target.armor = null;
                    } else {
                        target.armor = selected;
                    }
                    Show_selection();
                } else if (stype.IsSubclassOf(typeof(Weapon))
                        || stype == typeof(Tool)) {
                    if (target.primary == selected) {
                        target.primary = null;
                    } else {
                        target.primary = selected;
                    }
                    Show_selection();
                }
            }
        }
    }
    void Clear_items(){
        foreach (Transform child in items) {
            GameObject.Destroy(child.gameObject);
        }
    }

    void Show_selection() {
        foreach (Transform item in items) {
            InventoryItem Iitem = item.gameObject.GetComponent<InventoryItem>();
            Dehighlight(item.gameObject);
            if (Iitem.item == target.primary
             || Iitem.item == target.armor) {
                item.transform.SetSiblingIndex(0);
                Highlight(item.gameObject);
            }
        }
    }

    void Highlight(GameObject item) {
        // Makes selected items ugly yellow
        item.GetComponent<Image>().color = Color.yellow;
    }

    void Dehighlight(GameObject item) {
        // Reverts back to prefab
        item.GetComponent<Image>().color = Color.white;
    }

    void Add_items(List<Item> to_add){
        foreach(Item item in to_add) {
            InventoryItem tmp = Instantiate(itemPrefab, items).GetComponent<InventoryItem>();
            tmp.Set_values(item, this);
        }
        Show_selection();
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
