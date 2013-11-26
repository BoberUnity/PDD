#pragma strict

var TimeStamp : float;
var myCar : Car;

var Durations : float[];
var Steers : float[];
var Throttles : float[];
var i : int = 0;

var isPlaying = false;
function Start () {

	 
	 myCar = GetComponent("Car");
	 
}

function Update () {
	if (isPlaying)
	{
		if (i > Durations.Length){
			isPlaying = false;
			return;
		}
		var d = Durations[i];
		var t = Time.time;
		if (t > TimeStamp+d)
		{
			i++;
		}
		
		myCar.steer = Steers[i];
		myCar.throttle = Throttles[i];
	}


}

function OnGUI()
{
	
	GUILayout.BeginArea( Rect(Screen.width/2 - 50.0,Screen.height*0.8+30,100.0,Screen.height*0.1));
	if(GUILayout.Button("Play"))
	{
		TimeStamp = Time.time;	
		isPlaying = true;
		rigidbody.isKinematic = false;
		
	}
	GUILayout.EndArea();

}