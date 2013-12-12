using UnityEngine;

public class DimensionScale : MonoBehaviour
{
    private void Start()
    {
        UILabel label = GetComponent<UILabel>();
        float sf = 1.7777f/((float) Screen.height/(float) Screen.width);
        label.mWidth = (int)((float)label.mWidth*sf);
    }
}
