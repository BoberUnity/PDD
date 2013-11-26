#pragma strict

var clip1 : AnimationClip; 
var obj : Transform; 
static var recStart = false; 
static var isRecording = false; 
static var nowTime:float; 
static var posXCurve: AnimationCurve; 
static var posYCurve: AnimationCurve; 
static var posZCurve: AnimationCurve; 
static var rotXCurve: AnimationCurve; 
static var rotYCurve: AnimationCurve; 
static var rotZCurve: AnimationCurve; 
static var rotX2Curve: AnimationCurve; 
static var rotY2Curve: AnimationCurve; 
static var rotZ2Curve: AnimationCurve; 

function OnGUI () { 
        GUI.Box (Rect (10,10,100,120), "Motion Capture"); 
        if (GUI.Button (Rect (20,40,80,20), "Rec")) { 
                startRec(); 
        } 
        if (GUI.Button (Rect (20,70,80,20), "Stop")) { 
                stopRec(); 
        } 
        if (GUI.Button (Rect (20,100,80,20), "Play")) { 
                playAnim(); 
        } 
} 

function startRec() { 
    posXCurve = new AnimationCurve(); 
    posYCurve = new AnimationCurve(); 
    posZCurve = new AnimationCurve(); 
    rotXCurve = new AnimationCurve(); 
    rotYCurve = new AnimationCurve(); 
    rotZCurve = new AnimationCurve(); 
    rotX2Curve = new AnimationCurve(); 
    rotY2Curve = new AnimationCurve(); 
    rotZ2Curve = new AnimationCurve(); 
    recStart = true; 
    isRecording = true; 
    print("REC"); 
} 

function stopRec() { 

    isRecording = false; 
    clip1.SetCurve("", Transform, "localPosition.x", posXCurve); 
    clip1.SetCurve("", Transform, "localPosition.y", posYCurve); 
    clip1.SetCurve("", Transform, "localPosition.z", posZCurve); 

    clip1.SetCurve("", Transform, "localRotation.x", rotXCurve); 
    clip1.SetCurve("", Transform, "localRotation.y", rotYCurve); 
    clip1.SetCurve("", Transform, "localRotation.z", rotZCurve); 

    clip1.SetCurve("_d_camera", Transform, "localRotation.x", 
rotX2Curve); 
    clip1.SetCurve("_d_camera", Transform, "localRotation.y", 
rotY2Curve); 
    clip1.SetCurve("_d_camera", Transform, "localRotation.z", 
rotZ2Curve); 

    obj.animation.AddClip (clip1, "aniMo"); 
        print("STOPPED!!"); 
} 

function playAnim() { 
    obj.animation.Play("aniMo"); 
    print("PLAY"); 
} 

function FixedUpdate () { 
    if(recStart) { 
        nowTime = 0; 
        recStart = false; 
    } 

    if(isRecording){ 
        posXCurve.AddKey(nowTime, obj.transform.localPosition.x); 
        posYCurve.AddKey(nowTime, obj.transform.localPosition.y); 
        posZCurve.AddKey(nowTime, obj.transform.localPosition.z); 

        rotXCurve.AddKey(nowTime, obj.transform.localRotation.x); 
        rotYCurve.AddKey(nowTime, obj.transform.localRotation.y); 
        rotZCurve.AddKey(nowTime, obj.transform.localRotation.z); 

        rotX2Curve.AddKey(nowTime, obj.transform.localRotation.x); 
        rotY2Curve.AddKey(nowTime, obj.transform.localRotation.y); 
        rotZ2Curve.AddKey(nowTime, obj.transform.localRotation.z); 

        nowTime = nowTime + Time.deltaTime; 
        print(nowTime); 
    } 
} 
