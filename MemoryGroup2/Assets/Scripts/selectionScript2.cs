using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class selectionScript2 : MonoBehaviour {

	public Button Exit;
	public Button characterOne;
	public Button characterTwo;
	public Button characterThree;
	public Button characterFour;
	public Button characterFive;
	public Button characterSix;
	public Canvas selectionScene;
	public Canvas valueCanvas;
	public static Dictionary<string, List<string>> theHash;
	public Dictionary<string, string> computerDict;
	public Dictionary<string, string> playerDict;
	public Image spawnCharacter;
	public string characterOneString;
	public string characterTwoString;
	public string characterThreeString;
	public string characterFourString;
	public string characterFiveString;
	public string characterSixString;
	public string value4Map;
	public Text valueOne;
	public Text valueTwo;
	public Text turnPlayer;
	public Text turnComp;
	public int counter;
	public string valueMap;
	public string value4One;
	public string value4Two;
	public int playerOneCounter;
	public int playerTwoCounter;
	string currentCharacter;
	public Text playeroneCharacter1;
	public Text playeroneCharacter2;
	public Text playeroneCharacter3;
	public Text computerCharacter1;
	public Text computerCharacter2;
	public Text computerCharacter3;
	public int CharacterPanelcount;
	public Button startButton;
	public bool turn;


	void Start () {
		startButton = startButton.GetComponent<Button> ();
		characterOne = characterOne.GetComponent<Button> ();
		characterTwo = characterTwo.GetComponent<Button> ();
		characterThree = characterThree.GetComponent<Button> ();
		characterFour = characterFour.GetComponent<Button> ();
		characterFive = characterFive.GetComponent<Button> ();
		characterSix = characterSix.GetComponent<Button> ();
		selectionScene = selectionScene.GetComponent<Canvas> ();
		valueCanvas = valueCanvas.GetComponent<Canvas> ();
		theHash = new Dictionary<string, List<string>>();
		computerDict = new Dictionary<string, string>();
		playerDict = new Dictionary<string, string>();
		valueCanvas.enabled = false;
		startButton.enabled = false;
		characterOneString = "";
		characterTwoString = "";
		characterThreeString = "";
		playerOneCounter = 0;
		playerTwoCounter = 0;
		buttonText ();
		counter = 0;
		turn = true;

	}

	public void Awake(){
		DontDestroyOnLoad (this);
	}

	public void exitMain(){
		SceneManager.LoadScene ("Title");
	}
	public void startCombat(){
		SceneManager.LoadScene ("Game"); //Last character Choosen
	}

	public void generateMap(){//generates dictionary for starting selection phase
		theHash.Add("Frank", generateValue());
		theHash.Add("Joe", generateValue());
		theHash.Add("Billybob", generateValue());
		theHash.Add ("Mike", generateValue ());
		theHash.Add ("Jimmy", generateValue ());
		theHash.Add ("Rony", generateValue ());

	}

	public List<string> generateValue(){//generates value for static map
		List<string> generator = new List<string> ();
		generator.Add (""+Random.Range(200,800));
		generator.Add (""+Random.Range(200,800));
		return generator;
	}

	public void buttonText(){//updates text for buttons character name
		turnText ();
		generateMap();
		int count = 0;
		foreach (string pair in theHash.Keys) {
			if (count == 0) {
				characterTwo.GetComponentInChildren<Text> ().text = pair;
				characterOneString = pair;
			} else if (count == 1) {
				characterOne.GetComponentInChildren<Text> (). text = pair;
				characterTwoString = pair;
			} else if (count == 2) {
				characterThree.GetComponentInChildren<Text> ().text = pair;
				characterThreeString = pair;
			} else if (count == 3) {
				characterFour.GetComponentInChildren<Text> ().text = pair;
				characterFourString = pair;
			} else if (count == 4) {
				characterFive.GetComponentInChildren<Text> ().text = pair;
				characterFiveString = pair;
			}  else if (count == 5) {
				characterSix.GetComponentInChildren<Text> ().text = pair;
				characterSixString = pair;
			} 
			count = count + 1;
		}
	}
	public void turnText(){
		turnPlayer.enabled = true;
		if (counter % 2 == 0) {
			turn = true;
			turnPlayer.text = "Player One's Turn";
		} else {
			turn = false;
			turnPlayer.text = "Computers Turn";
		}
	}
	public void characterOnePress(){
		currentCharacter = characterOneString;
		counter = counter + 1;
		List<string> valuesfromHash = theHash [characterOneString];
		valueText (valuesfromHash);
		if (counter % 2 != 0) {
			playerDict.Add (characterOneString,"");

		} else {
			computerDict.Add (characterOneString,"");
		}
		characterTwo.enabled = false;
		characterTwo.GetComponentInChildren<Text> ().text = "-";
		//change the image to the character name
		//add the character/value to dictionary depending on the turn
	}

	public void characterTwoPress(){
		currentCharacter = characterTwoString;
		counter = counter + 1;
		List<string> valuesfromHash = theHash [characterTwoString];
		valueText (valuesfromHash);
		if (counter % 2 != 0) {
			playerDict.Add (characterTwoString,"");

		} else {
			computerDict.Add (characterTwoString,"");
		}
		characterOne.enabled = false;
		characterOne.GetComponentInChildren<Text> ().text = "-";
		//change the image to the character name
		//add the character/value to dictionary depending on the turn

	}

	public void characterThreePress(){
		currentCharacter = characterThreeString;
		counter = counter + 1;
		List<string> valuesfromHash = theHash [characterThreeString];
		valueText (valuesfromHash);
		if (counter % 2 != 0) {
			playerDict.Add (characterThreeString,"");

		} else {
			computerDict.Add (characterThreeString,"");
		}
		characterThree.enabled = false;
		characterThree.GetComponentInChildren<Text> ().text = "-";
		//change the image to the character name
		//add the character/value to dictionary depending on the turn

	}

	public void characterFourPress(){
		currentCharacter = characterFourString;
		counter = counter + 1;
		List<string> valuesfromHash = theHash [characterFourString];
		valueText (valuesfromHash);
		if (counter % 2 != 0) {
			playerDict.Add (characterFourString,"");
		} else {
			computerDict.Add (characterFourString,"");
		}
		//change the image to the character name
		//add the character/value to dictionary depending on the turn
		characterFour.enabled = false;
		characterFour.GetComponentInChildren<Text> ().text = "-";
	}

	public void characterFivePress(){
		currentCharacter = characterFiveString;
		counter = counter + 1;
		List<string> valuesfromHash = theHash [characterFiveString];
		valueText (valuesfromHash);
		if (counter % 2 != 0) {
			playerDict.Add (characterFiveString,"");

		} else {
			computerDict.Add (characterFiveString,"");
		}
		characterFive.enabled = false;
		characterFive.GetComponentInChildren<Text> ().text = "-";
		//change the image to the character name
		//add the character/value to dictionary depending on the turn
	}

	public void characterSixPress(){
		currentCharacter = characterSixString;
		counter = counter + 1;
		List<string> valuesfromHash = theHash [characterSixString];
		valueText (valuesfromHash);
		if (counter % 2 != 0) {
			playerDict.Add (characterSixString,"");

		} else {
			computerDict.Add (characterSixString,"");
		}
		characterSix.enabled = false;
		characterSix.GetComponentInChildren<Text> ().text = "-";
		//change the image to the character name
		//add the character/value to dictionary depending on the turn
	}
		
	public void valueText(List<string> values){
		int valueCounter = 0;
		valueCanvas.enabled = true;
		foreach (string str in values) {//value button text is made by looping threw the list of the dictionary
			if (valueCounter == 0) {
				valueOne.text = str;
				value4One = str;
			} else if (valueCounter == 1) {
				valueTwo.text = str;
				value4Two = str;
			}
			valueCounter = valueCounter + 1;
		}
	}

	public void valueOnePress(){
		valueCanvas.enabled = false;
		if (turn == true) {
			playerDict [currentCharacter] = value4One;
		} else if (turn == false) {
			computerDict [currentCharacter] = value4One;
		}
		characterUpdate ();
		//store into a map
	}

	public void valueTwoPress(){
		valueCanvas.enabled = false;
		if (turn == true) {
			playerDict [currentCharacter] = value4Two;
		} else if (turn == false) {
			computerDict [currentCharacter] = value4Two;
		}
		characterUpdate ();
		//store into a map
	}

	public void characterUpdate(){
		if (CharacterPanelcount == 0) {
			playeroneCharacter1.text = currentCharacter + " Value: " + playerDict [currentCharacter];
		} else if (CharacterPanelcount == 1) {
			computerCharacter1.text = currentCharacter + " Value: " + computerDict [currentCharacter];
		} else if (CharacterPanelcount == 2) {
			playeroneCharacter2.text = currentCharacter + " Value: " + playerDict [currentCharacter];
		} else if (CharacterPanelcount == 3) {
			computerCharacter2.text = currentCharacter + " Value: " + computerDict [currentCharacter];
		} else if (CharacterPanelcount == 4) {
			playeroneCharacter3.text = currentCharacter + " Value: " + playerDict [currentCharacter];
		} else if (CharacterPanelcount == 5) {
			computerCharacter3.text = currentCharacter + " Value: " + computerDict [currentCharacter];
			startButton.enabled = true;

		}
		turnText ();
		if (CharacterPanelcount == 5) {
			turnPlayer.text = "Press Start";
		}
		CharacterPanelcount = CharacterPanelcount + 1;

	}

	public Dictionary<string, string> dictionaryCPU(){
		return computerDict;
	}

	public Dictionary<string, string> dictionaryP1(){
		return playerDict;
	}







}
