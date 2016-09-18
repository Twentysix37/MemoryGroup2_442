using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class menuScript : MonoBehaviour {

	public Canvas quitMenu;
	public Button startText;
	public Button exitText;
	public Button optionsText;
	public Canvas optionsMenu;
	public Canvas difficultyMenu;

	// Use this for initialization
	void Start () {
		quitMenu = quitMenu.GetComponent<Canvas> ();
		optionsMenu = optionsMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		optionsText = optionsText.GetComponent<Button> ();
		difficultyMenu = difficultyMenu.GetComponent<Canvas> ();
		quitMenu.enabled = false;
		optionsMenu.enabled = false;
		difficultyMenu.enabled = false;
	}

	public void ExitPress(){
		quitMenu.enabled = true;
		optionsMenu.enabled = false;
		optionsText.enabled = false;
		startText.enabled = false;
		exitText.enabled = false;
		difficultyMenu.enabled = false;
	}
	public void OptionsPress(){
		quitMenu.enabled = false;
		optionsMenu.enabled = true;
		optionsText.enabled = false;
		startText.enabled = false;
		exitText.enabled = false;
		difficultyMenu.enabled = false;
	}

	public void noPress (){
		optionsMenu.enabled = false;
		quitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
		optionsText.enabled = true;
		difficultyMenu.enabled = false;

	}

	public void difficultPress(){
		quitMenu.enabled = false;
		optionsMenu.enabled = false;
		optionsText.enabled = false;
		startText.enabled = false;
		exitText.enabled = false;
		difficultyMenu.enabled = true;
	}
	public void backPress(){
		optionsMenu.enabled = false;
		quitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
		optionsText.enabled = true;
		difficultyMenu.enabled = false;
	}
	public void EasyMedHardPress() {
		//set to go back to menu
		backPress();
	}

	public void Startlevel(){
		//Application.LoadLevel ("Game");
		SceneManager.LoadScene ("Game");
	}

	public void ExitGame(){
		Application.Quit ();
	}

}
