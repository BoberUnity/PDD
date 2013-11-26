using UnityEngine;
using System.Collections;

public class Car_Anim : MonoBehaviour {
	public bool Play = false;
	public float speed = 0.3f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Play)
			transform.Translate(transform.forward*speed);
	}
}
