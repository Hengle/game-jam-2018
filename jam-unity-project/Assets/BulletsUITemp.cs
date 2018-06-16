using UnityEngine;
using UnityEngine.UI;

public class BulletsUITemp : MonoBehaviour
{
  [SerializeField] private Text _text;
  
  private void Update()
  {
    _text.text = "Bullets: " + GameGod.Instance.CurrentBullets;
  }
}
