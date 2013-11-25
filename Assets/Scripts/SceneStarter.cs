using System.Collections;
using UnityEngine;

public sealed class SceneStarter : MonoBehaviour
{
  [SerializeField] private int nextLevel = 1;
  [SerializeField] private Camera camera3d = null;
  private ScreenScale screenScale = null;

  private void Start()
  {
    screenScale = GameObject.Find("Controller").GetComponent<ScreenScale>();
    screenScale.RightAnswer += StartAnimation;
    if (!screenScale.ScrollOn)
    {
      camera3d.rect = new Rect(0.05f, 0.6f, 0.9f, 0.25f);
    }
    else
    {
      screenScale.Camera3D = camera3d;
      camera3d.rect = new Rect(0.05f, 0.6f - screenScale.ScrollPos * 0.1f, 0.9f, 0.3f);
    }
  }

  private void Destroy()
  {
    screenScale.RightAnswer -= StartAnimation;
  }

  private void StartAnimation()
  {
    animation.Play();
    StartCoroutine(LoadNextLevel(animation.clip.length));
  }

  private IEnumerator LoadNextLevel(float time)
  {
    yield return new WaitForSeconds(time);
    screenScale.Scroll = false;
    Application.LoadLevel(nextLevel);
    Destroy();
  }
}
