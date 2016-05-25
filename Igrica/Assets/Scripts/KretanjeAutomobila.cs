using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class KretanjeAutomobila : MonoBehaviour {
	private float brzina=0.05f;

	public GameObject donjiZid;
	public GameObject gornjiZid;
	public GameObject lijeviZid;
	public GameObject desniZid;

	public enum SmjerAutomobila {lijevo, desno, gore, dolje};
	public SmjerAutomobila smjer;

	public Vector2 vektor = -Vector2.right;
	public Vector2 vektorPomjeranja;

	public int highscore;
	public string highScoreKey="HighScore";
	public int score=0;

	public float gorivo=1;
    
	public Highscore hs;

	public int vratiScore(){
		return score;
	}

	public void attach(Observer o){
		hs=(Highscore)o;
	}

	public void notifyAllObservers(){
		if (score > highscore) {
			highscore = score;
			PlayerPrefs.SetInt (highScoreKey, score);
			PlayerPrefs.Save ();
		}
		hs = new Highscore ();
		hs.update ();
	}

	void Start () {
		score = 0;
		attach (hs);
		InvokeRepeating ("kretanje", 0.3f, brzina);
		highscore = PlayerPrefs.GetInt (highScoreKey,0);
	}
	
	void Update () {
		if (Input.GetKey (KeyCode.RightArrow)) {

			vektor = Vector2.right;
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			vektor = -Vector2.right;
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			vektor = Vector2.up;
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			vektor = -Vector2.up;
		}
		vektorPomjeranja = vektor / 2f;
	}

	void onDisable(){
		if (score > highscore) {
			highscore=score;
			PlayerPrefs.SetInt (highScoreKey, score);
			PlayerPrefs.Save ();
		}
	}

	public void kretanje(){
		smjer = SmjerAutomobila.lijevo;
		transform.Translate (vektorPomjeranja);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.name.StartsWith ("CoinPrefab")) {
			Destroy (coll.gameObject);
			score++;
		} else if (coll.name.StartsWith ("KanisterPrefab")) {
			if (gorivo != 100)
				gorivo += 10;
			Destroy (coll.gameObject);
		} else if (coll.name.StartsWith ("BombaPrefab")) {
			notifyAllObservers ();
			Application.LoadLevel ("Menu");
		} else if (coll.name.StartsWith ("GornjiZid")) {
			notifyAllObservers ();
			Application.LoadLevel ("Menu");
		} else if (coll.name.StartsWith ("DonjiZid")) {
			notifyAllObservers ();
			Application.LoadLevel ("Menu");
		} else if (coll.name.StartsWith ("LijeviZid")) {
			notifyAllObservers ();
			Application.LoadLevel ("Menu");
		} else if (coll.name.StartsWith ("DesniZid")) {
			notifyAllObservers ();
			Application.LoadLevel ("Menu");
		}
	}
	public void rotirajZa90(){
		transform.Rotate (Vector3.forward * -90);
	}
	public void rotirajZa180(){
		transform.Rotate (Vector3.forward * -180);
	}
	public void rotirajZa270(){
		transform.Rotate (Vector3.forward * -270);
	}
}
