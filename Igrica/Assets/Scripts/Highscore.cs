using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Highscore : Observer {

	public List<int> highscoreLista= new List<int> ();
	public KretanjeAutomobila kretanjeAutica;
	public Text scoreovi;
	public int highscore;
	public string highScoreKey="HighScore";

	public void Start(){
		highscore = PlayerPrefs.GetInt(highScoreKey,0);
		ispisiHighscore ();
	}
	public Highscore() {
	}

	public Highscore(KretanjeAutomobila ka){
		this.kretanjeAutica = ka;
		this.kretanjeAutica.attach (this);
	}

	override public void update(){
		highscore= PlayerPrefs.GetInt(highScoreKey);
	}
	void ispisiHighscore(){
		scoreovi.text = highscore.ToString();
	}



}
