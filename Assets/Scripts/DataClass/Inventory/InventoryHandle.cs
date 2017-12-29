using UnityEngine;

public class InventoryHandle : MonoBehaviour {

    public Inventory inventory;
    public GameObject inventoryUIPrefab;
    private GameObject inventoryUI;


    public void Open() {
        if (!inventoryUI) {
            inventoryUI = Instantiate(inventoryUIPrefab);
            inventoryUI.GetComponent<InventoryUI>().target = inventory;
        }
    }

    public void Close() {
        if (inventoryUI) {
            Destroy(inventoryUI);
        }
    }
}
