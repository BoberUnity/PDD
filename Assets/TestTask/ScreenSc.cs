using UnityEngine;

public class ScreenSc : MonoBehaviour
{
    public float actualAspect = 0;

    void Start()
    {
        actualAspect = Screen.height;
        actualAspect /= Screen.width;
        transform.localScale = new Vector3(48.1f / actualAspect, 49.1f, 48.1f);
    }

    void Update()
    {
        actualAspect = Screen.height;
        actualAspect /= Screen.width;
        transform.localScale = new Vector3(48.1f / actualAspect, 49.1f, 48.1f);
    }

    //private void OnGUI()
    //{

    //}
}
