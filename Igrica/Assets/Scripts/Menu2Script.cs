using UnityEngine;
using System.Collections;

public class Menu2Script : MonoBehaviour {
	void Start () { if (Screen.fullScreen) { Screen.fullScreen = false; } }
	
	void Update () {
	
	}
	
	public void ponovi()
	{
		Application.LoadLevel ("Igra");
	}
	public void idiNaGlavniMeni()
	{
		Application.LoadLevel ("MainMenu");
	}
	public void exit()
	{
		Application.Quit ();
	}
}
