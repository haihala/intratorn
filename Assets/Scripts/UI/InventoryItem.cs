using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItem : MonoBehaviour {
	public TextMeshProUGUI Name;
	public TextMeshProUGUI Type;
	public TextMeshProUGUI Weight;
	private InventoryUI master;
	private Item item;

    public void Set_values(Item item, InventoryUI master){
		Name.text = item.Name;
		Type.text = item.GetType().ToString();
		Weight.text = item.Weight.ToString();

		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(Inspect);

		this.master = master;
		this.item = item;
    }

	void Inspect(){
		master.Inspect(item);
	}
}
