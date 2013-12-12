using UnityEngine;

public class ButtonDontKnow : MonoBehaviour
{
  [SerializeField] private TextChild textController = null;
  [SerializeField] private UILabel label = null;
  
  protected virtual void OnPress(bool isPressed)
  {
      if (!isPressed)
      {
          textController.DontKnow(label);
          
      }
  }
}
