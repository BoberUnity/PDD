using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public Transform Target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(transform.position,Target.position,10.0f*Time.deltaTime);
		transform.rotation = Target.rotation;
	}
}
