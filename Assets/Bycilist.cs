using UnityEngine;
using System.Collections;

public class Bycilist : MonoBehaviour {
	public float speed = 0.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (animation.isPlaying)
			transform.Translate(transform.right*speed);
	}
}
