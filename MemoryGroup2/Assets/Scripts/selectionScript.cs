using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class selectionScript : MonoBehaviour {

	public Canvas selectionMenu;
	public Canvas valueCanvas;
	public Button characterOne;
	public Button characterTwo;
	public Button characterThree;
	public Button valueOne;
	public Button valueTwo;
	public Image char1;
	public Image char2;
	public Image char3;
	public Image char4;
	public Image char5;
	public Image char6;
	public Text User1;
	public Text CPU;
	public int selectCounter;


	// Use this for initialization
	void Start () {
		selectionMenu = selectionMenu.GetComponent<Canvas> ();
		valueCanvas = valueCanvas.GetComponent<Canvas> ();
		characterOne = characterOne.GetComponent<Button> ();
		characterTwo = characterTwo.GetComponent<Button> ();
		characterThree = characterThree.GetComponent<Button> ();
		valueOne = valueOne.GetComponent<Button> ();
		valueTwo = valueTwo.GetComponent<Button> ();
		char1 = char1.GetComponent<Image> ();
		char2 = char2.GetComponent<Image> ();
		char3 = char3.GetComponent<Image> ();
		char4 = char4.GetComponent<Image> ();
		char5 = char5.GetComponent<Image> ();
		char6 = char6.GetComponent<Image> ();
		valueCanvas.enabled = false;
		char1.enabled = false;
		char2.enabled = false;
		char3.enabled = false;
		char4.enabled = false;
		char5.enabled = false;
		char6.enabled = false;
		User1.enabled = true;
		CPU.enabled = false;
		valueOne.enabled = false;
		valueTwo.enabled = false;
		selectCounter = 0;
	}

	public void turnFinder (){
		if (selectCounter % 2 == 0) {
			CPU.enabled = false;
			User1.enabled = true;
		} 
		else {
			User1.enabled = false;
			CPU.enabled = true;
		}
	}

	public void valuePicker (){
		characterOne.interactable = false;
		characterTwo.interactable = false;
		characterThree.interactable = false;
		valueCanvas.enabled = true;
		valueOne.enabled = true;
		valueTwo.enabled = true;
	}

	public void spawnOne (){
		characterOne.interactable = true;
		characterTwo.interactable = true;
		characterThree.interactable = true;
		valueCanvas.enabled = false;
		//associate value to character
	}

	public void spawnTwo (){
		characterOne.interactable = true;
		characterTwo.interactable = true;
		characterThree.interactable = true;
		valueCanvas.enabled = false;
		//associate value to character
	}

	public void characterOnePress(){
		selectCounter = selectCounter + 1;
		turnFinder ();
		if(selectCounter % 2 != 0){
			char1.enabled = true;
			char2.enabled = false;
			char3.enabled = false;
			char4.enabled = false;
			char5.enabled = false;
			char6.enabled = false;
			}
		else{
			char1.enabled = false;
			char2.enabled = false;
			char3.enabled = false;
			char4.enabled = true;
			char5.enabled = false;
			char6.enabled = false;
		}
		valuePicker ();
	}

	public void characterTwoPress(){
		selectCounter = selectCounter + 1;
		turnFinder ();
		if(selectCounter % 2 != 0){
			char1.enabled = false;
			char2.enabled = true;
			char3.enabled = false;
			char4.enabled = false;
			char5.enabled = false;
			char6.enabled = false;
		}
		else{
			char1.enabled = false;
			char2.enabled = false;
			char3.enabled = false;
			char4.enabled = false;
			char5.enabled = true;
			char6.enabled = false;
		}
		valuePicker ();
	}

	public void characterThreePress(){
		selectCounter = selectCounter + 1;
		turnFinder ();
		if(selectCounter % 2 != 0){
			char1.enabled = false;
			char2.enabled = false;
			char3.enabled = true;
			char4.enabled = false;
			char5.enabled = false;
			char6.enabled = false;
		}
		else{
			char1.enabled = false;
			char2.enabled = false;
			char3.enabled = false;
			char4.enabled = false;
			char5.enabled = false;
			char6.enabled = true;
		}
		valuePicker ();
	}


}
