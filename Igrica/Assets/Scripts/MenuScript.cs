using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	void Start () {
        if (Screen.fullScreen) { Screen.fullScreen = false; }
    }
	void Update () {
	
	}

	public void pokreniIgru()
	{
		Application.LoadLevel ("Igra");
	}
	public void prikazHighscora()
	{
		Application.LoadLevel ("Highscore");
	}
}
