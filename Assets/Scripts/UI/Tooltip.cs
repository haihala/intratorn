using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

[RequireComponent(typeof(EventTrigger))]
public class Tooltip : MonoBehaviour {
	public string tooltip;

	GameObject tooltip_obj;
	GameObject tooltip_prefab;
	Transform canvas;

	void Start() {
		tooltip_prefab = PrefabManager.GetPrefab("UI/Inventory/Tooltip");
		canvas = GameObject.Find("Canvas").transform;
	}

	public void Open_tooltip() {
		if (!tooltip_obj) {
			tooltip_obj = Instantiate(tooltip_prefab, canvas);
			Vector3 pos = tooltip_obj.transform.position;
			pos.y = Input.mousePosition.y - 30;
			tooltip_obj.transform.position = pos;
			tooltip_obj.GetComponentInChildren<TextMeshProUGUI>().text = tooltip;
		}
	}

	public void Close_tooltip() {
		if (tooltip_obj) {
			Destroy(tooltip_obj);
		}
	}
}
