using UnityEngine;
using System.Collections;

public class LevelsGUI : MonoBehaviour {
	public string[] Levels;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
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
