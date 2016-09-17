using UnityEngine;
using System.Collections;

public class menuScript : MonoBehaviour {

	public Canvas quitMenu;
	public Button startText;
	public Button exitText;
	public Button optionsText;
	public Canvas optionsMenu;

	// Use this for initialization
	void Start () {
		quitMenu = quitMenu.GetComponent<Canvas> ();
		optionsMenu = optionsMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		optionsText = optionsText.GetComponent<Button> ();
		quitMenu.enabled = false;
		optionsMenu.enabled = false;
	}

	public void ExitPress(){
		quitMenu.enabled = true;
		optionsMenu.enabled = false;
		optionsText.enabled = false;
		startText.enabled = false;
		exitText.enabled = false;
	}
	public void OptionsPress(){
		quitMenu.enabled = false;
		optionsMenu.enabled = true;
		optionsText.enabled = false;
		startText.enabled = false;
		exitText.enabled = false;
	}

	public void noPress (){
		optionsMenu.enabled = false;
		quitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
		optionsText.enabled = true;

	}

	public void Startlevel(){
		//load a picture
	}

	public void ExitGame(){
		Application.Quit ();
	}

}
