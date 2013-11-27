using UnityEngine;

public class Ramka : MonoBehaviour 
{
  public Texture2D ramkatex;

  private void OnGUI()
  {
    GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), ramkatex);
  }
}
