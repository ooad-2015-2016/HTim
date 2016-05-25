using UnityEngine;
using System.Collections;

public class CreateCoin : MonoBehaviour {
	public GameObject coinPrefab;
	public GameObject kanisterPrefab;
	public GameObject bombaPrefab;

	public Transform gornjiZid;
	public Transform donjiZid;
	public Transform desniZid;
	public Transform lijeviZid;
    
	void Start () {
        if (Screen.fullScreen) { Screen.fullScreen = false; }
        InvokeRepeating ("kreirajCoin", 1, 3);
		//InvokeRepeating ("kreirajKanister", 5, 6);
		InvokeRepeating ("kreirajBombu", 2, 2);
	}
	void Update () {
	
	}

	public void kreirajCoin()
	{
		int x = (int)Random.Range (lijeviZid.position.x, desniZid.position.x);
		int y = (int)Random.Range (donjiZid.position.y, gornjiZid.position.y);
		Instantiate (coinPrefab, new Vector2 (x, y), Quaternion.identity);
	}

	public void kreirajKanister()
	{
		int x = (int)Random.Range (lijeviZid.position.x, desniZid.position.x);
		int y = (int)Random.Range (donjiZid.position.y, gornjiZid.position.y);
		Instantiate (kanisterPrefab, new Vector2 (x, y), Quaternion.identity);
	}

	public void kreirajBombu()
	{
		int x = (int)Random.Range (lijeviZid.position.x, desniZid.position.x);
		int y = (int)Random.Range (donjiZid.position.y, gornjiZid.position.y);
		Instantiate (bombaPrefab, new Vector2 (x, y), Quaternion.identity);
	}
}
