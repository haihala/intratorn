using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItem : MonoBehaviour {
	public TextMeshProUGUI Name;
	public TextMeshProUGUI Weight;
	private InventoryUI master;
	[HideInInspector]
	public Item item;

    public void Set_values(Item item, InventoryUI master){
		Name.text = item.Name;
		Weight.text = item.Weight.ToString();

		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(Inspect);

		this.master = master;
		this.item = item;
    }

	public void On_hover () {
		master.Select(this.item);
	}

	public void Off_hover () {
		master.Deselect();
	}

	void Inspect(){
		master.Inspect(item);
	}
}
