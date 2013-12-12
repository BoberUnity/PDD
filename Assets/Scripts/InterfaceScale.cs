using UnityEngine;

public class InterfaceScale : MonoBehaviour
{
    [SerializeField] private bool positionX = true;
    [SerializeField] private bool positionY = true;
    [SerializeField] private bool scaleX = false;
    [SerializeField] private bool scaleY = false;
    [SerializeField] private bool inv = false;

    private void Start()
    {
        float sx = transform.localScale.x;
        float sy = transform.localScale.y;
        float sz = transform.localScale.z;

        if (positionX)
            transform.localPosition = new Vector3(transform.localPosition.x * 1.7777f/((float)Screen.height / (float)Screen.width), transform.localPosition.y, transform.localPosition.z);

        if (positionY)
          transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y * 0.5625f * Screen.height / Screen.width, transform.localPosition.z);
      if (scaleY || scaleX)
      {
          float scaleFactor = 0.5625f*(Screen.height/Screen.width);
          if (inv)
              scaleFactor = 1.7777f/((float)Screen.height / (float)Screen.width);
          if (scaleX && !scaleY)
              transform.localScale = new Vector3(sx * scaleFactor, sy, sz);
          if (scaleY && !scaleX)
              transform.localScale = new Vector3(sx, sy * scaleFactor, sz * scaleFactor);
          if (scaleY && scaleX)
              transform.localScale = new Vector3(sx * scaleFactor, sy * scaleFactor, sz * scaleFactor);

      }
  }
}
