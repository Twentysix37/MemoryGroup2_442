using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class CharacterSelection : MonoBehaviour {

	public Dictionary<string,List<string>> Characters = new Dictionary<string,List<string>>();

	void FillDictionary (){
		for (int i = 10; i > 0; i--) {
		}
	}

	// Use this for initialization
	void Start () {
		GameObject CharactorSelectButton = new GameObject ();
		//CharactorSelectButton.transform.SetParent();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
