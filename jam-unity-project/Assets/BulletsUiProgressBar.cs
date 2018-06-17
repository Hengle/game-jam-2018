using UnityEngine;
using UnityEngine.UI;

public class BulletsUiProgressBar : MonoBehaviour
{
  [SerializeField] private Image _slider;

  private void Update()
  {
    var max = GameGod.Instance.MaximumBullets;
    var cur = GameGod.Instance.CurrentBullets;
    
    var value = ((float)cur / max);
    
    _slider.fillAmount = value;
  }
}
