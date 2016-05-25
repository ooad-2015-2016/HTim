using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GorivoBar : MonoBehaviour {
	public KretanjeAutomobila sg;
	public float gorivoBar=1;
	public int scoreGui;
    
	public Text rezultatIspis;
	void Start () {
	
	}
	void Update () {;
		gorivoBar = sg.gorivo;
		scoreGui = sg.score;
		Image image = GetComponent<Image>();
		image.fillAmount = gorivoBar;
		rezultatIspis.text = scoreGui.ToString();
	}
}
