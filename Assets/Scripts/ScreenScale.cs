using System;
using UnityEngine;

public sealed class ScreenScale : MonoBehaviour
{
  [SerializeField] private Camera camera2d = null;
  [SerializeField] private GUISkin guISkin = null;
  [SerializeField] private Texture2D buttonA = null;
  [SerializeField] private Texture2D buttonB = null;
  [SerializeField] private Texture2D buttonC = null;
  [SerializeField] private float scrollSpeed = 0.1f;
  private float actualAspect = 0;
  private int level = 1;
  private float sfx;
  private float sfy;
  private bool freeze = false;
  private bool scroll = false;
  private float lastMousePos = 0;
  private float lastMousePos2 = 0;
  private bool scrollOn = false;
  private float scrollPos = 0;
  private Camera camera3d = null;
  private int scrollTorque = 0;//1 - down; 2 - up

  public bool ScrollOn
  {
    get { return scrollOn; }
  }

  public bool Scroll
  {
    get { return scroll; }
    set { scroll = value; }
  }

  public float ScrollPos
  {
    get { return scrollPos; }
  }

  public Camera Camera3D
  {
    set { camera3d = value;}
  }

  public event Action RightAnswer;

  void Start()
  {
    DontDestroyOnLoad(this);
    Application.LoadLevel(1);
    camera2d.orthographicSize = Screen.height / 2;
    if ((float)Screen.width / (float)Screen.height > 0.65f)//0.59
    {
      Debug.Log("Start IPhone4");
      transform.localScale = new Vector3(Screen.width / 10, 1, Screen.height / 8.45f);
      scrollOn = true;
    }
    else
    {
      Debug.Log("Start IPhone5");
      transform.localScale = new Vector3(Screen.width / 10, 1, Screen.height / 10);
    }
    
  }

  void Update()
  {
    sfx = (float)Screen.width / 320;
    sfy = (float)Screen.height / 480;
    actualAspect = Screen.height;
    actualAspect /= Screen.width;

    if (scrollOn)
    {
      if (Input.GetMouseButtonDown(0) && Input.touchCount < 2 && !freeze)
      {
        scroll = true;
        lastMousePos = Input.mousePosition.y;
        scrollTorque = 0;
      }

      if (Input.GetMouseButtonUp(0) && scroll)
      {
        scroll = false;
        // Dokrutka scrolla
        if (lastMousePos2 - Input.mousePosition.y > 0)
          scrollTorque = 1;
        if (lastMousePos2 - Input.mousePosition.y < 0)
          scrollTorque = 2;
      }

      if (scroll)
      {
        scrollPos += Mathf.Clamp((lastMousePos - Input.mousePosition.y) / 50, -0.3f, 0.3f);
        lastMousePos2 = lastMousePos;
        scrollPos = Mathf.Clamp(scrollPos, -1, 1);
        lastMousePos = Input.mousePosition.y;
        MoveScroll();
      }

      if (scrollTorque > 0)//Докрутка скролла
      {
        if (scrollTorque == 1)
        {
          scrollPos += scrollSpeed;
          if (scrollPos >= 1)
          {
            scrollTorque = 0;
            scrollPos = 1;
          }
          MoveScroll();
        }

        if (scrollTorque == 2)
        {
          scrollPos -= scrollSpeed;
          if (scrollPos <= -1)
          {
            scrollTorque = 0;
            scrollPos = -1;
          }
          MoveScroll();
        }
      }
    }
  }

  private void OnGUI()
  {
    GUI.skin = guISkin;
    if (GUI.Button(new Rect(20 * sfx, 330 * sfy + scrollPos * 45 * Screen.height / 480, 280 * sfx, 45 * sfy), buttonA))
    {
      if (level < 5)
      {
        var handler = RightAnswer;
        if (handler != null)
          handler();
      }
    }
    
    if (GUI.Button(new Rect(20 * sfx, 380 * sfy + scrollPos * 45 * Screen.height / 480, 280 * sfx, 45 * sfy), buttonB))
    {

    }

    if (GUI.Button(new Rect(20 * sfx, 430 * sfy + scrollPos * 45 * Screen.height / 480, 280 * sfx, 45 * sfy), buttonC))
    {

    }
  }

  private void MoveScroll()
  {
    camera2d.transform.position = new Vector3(0, scrollPos * 45 * Screen.height / 480, camera2d.transform.position.z);
    lastMousePos = Input.mousePosition.y;
    if (camera3d != null)
      camera3d.rect = new Rect(0.05f, 0.6f - scrollPos * 0.1f, 0.9f, 0.3f);
    else
      Debug.Log("camera3d == null");
  }
}
