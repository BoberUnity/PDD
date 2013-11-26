using UnityEngine;
using System.Collections;

public class turnsignal : MonoBehaviour {
	public float Delay;
	public float Delay2;
	private float T = 0;
	private bool B;
	// Use this for initialization
	void Start () {
		//T = Time.time;
	}

	void SwitchTurn()
	{
		GetComponent<MeshRenderer>().material.color = B?Color.black:Color.yellow; //SetColor(1,Color.red);
		B = !B;
	}
	// Update is called once per frame
	void Update () {
		if (transform.parent.parent.animation.isPlaying){
			if (T == 0)
				T = Time.time;
			if (!IsInvoking())
			{
				if (Time.time > T+Delay2)
					return;
				if (Time.time > T+Delay)
					Invoke("SwitchTurn",0.5f);
			}
		}

	}
}
