using UnityEngine;
using UnityEngine.UI;

public class UiEnergyProgressbar : MonoBehaviour
{
  [SerializeField] private Image _slider;
  
  private void Update()
  {
    var max = GameGod.Instance.MaximumEnergy;
    var cur = GameGod.Instance.Energy;
    
    var value = ((float)cur / max);
    
    _slider.fillAmount = value;
  }
}