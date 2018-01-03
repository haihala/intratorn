using UnityEngine;

public class InventoryHandle : MonoBehaviour {

    public Inventory inventory;
    public GameObject inventoryUIPrefab;
    public IntVariable UIOpen;
    GameObject inventoryUI;
    Transform canvas;

    void Start() {
        canvas = GameObject.Find("Canvas").transform;
    }

    void Update() {
        if (Input.GetButtonDown("Inventory")) {
            if (inventoryUI) {
                // If UI is open, close it and vice versa
                Close();
            } else {
                Open();
            }
        }

        // ESC closes inventory if open.
        if (Input.GetButtonDown("Cancel")) {
            if (inventoryUI) {
                Close();
            }
        }
    }

    void Open() {
        if (!inventoryUI) {
            inventoryUI = Instantiate(inventoryUIPrefab, canvas);
            inventoryUI.GetComponent<InventoryUI>().target = inventory;
            inventoryUI.GetComponent<InventoryUI>().Open_tab("ALL");
            UIOpen.Value++;
        }
    }

    void Close() {
        if (inventoryUI) {
            Destroy(inventoryUI);
            UIOpen.Value--;
        }
    }
}
