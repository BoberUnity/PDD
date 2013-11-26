using UnityEngine;
using System.Collections;

public class Scene4_script : MonoBehaviour {
	public Car_Anim car;
	public Bycilist[] bycilists;
	public string[] Levels;
	public float Duration = 5.0f;
	private float startTime;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (startTime != 0 && Time.time > startTime+Duration)
		{
			car.Play = false;
			foreach (Bycilist b in bycilists)
			{
				b.animation.Stop();
				Application.LoadLevel(Application.loadedLevel);
			}
		}

	}

	void OnGUI()
	{
		GUILayout.BeginArea(new Rect(Screen.width/2 - 50.0f,Screen.height*0.8f+30,100.0f,Screen.height*0.1f));
		if(GUILayout.Button("Play"))
		{
			startTime = Time.time;

			car.Play = true;
			foreach (Bycilist b in bycilists)
			{

				b.animation.Play();
			}
		}
		GUILayout.EndArea();

		GUILayout.BeginArea(new Rect(Screen.width*0.1f,Screen.height*0.1f,100.0f,Screen.height*0.5f));
		foreach (string sLevel in Levels)
		{
			if(GUILayout.Button(sLevel))
			{
				Application.LoadLevel(sLevel);
			}
		}
		GUILayout.EndArea();


	}
}
