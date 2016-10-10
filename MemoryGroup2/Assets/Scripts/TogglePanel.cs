using UnityEngine;
using System.Collections;

public class TogglePanel : MonoBehaviour {
	
	public void Toggle_Panel (GameObject panel) {
		panel.SetActive (!panel.activeSelf);
	}
}
