using UnityEngine;
using UnityEngine.UI;

public class FillAmountTest : MonoBehaviour {
    public float Amount;
    public Image Target;
    
	// Update is called once per frame
	void Update () {
        Target.fillAmount = Amount;
	}
}
