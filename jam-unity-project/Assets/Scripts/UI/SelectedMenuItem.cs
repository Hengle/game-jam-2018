using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SelectedMenuItem : MonoBehaviour
{
  public Color DefaultColor;

  public Color BlinkColor;
  public float BlinkSpeed;

  private Text _text;

  // Use this for initialization
  void Start()
  {
    _text = GetComponent<Text>();
    Select();
  }

  private void Select()
  {
    StartCoroutine("ChangeColor");
  }

  private void Deselect()
  {
    StopCoroutine("ChangeColor");
  }

  private IEnumerator ChangeColor()
  {
    while (true)
    {
      //yield return new WaitForSeconds(BlinkSpeed);
      _text.color = BlinkColor;
      yield return new WaitForSeconds(BlinkSpeed);
      _text.color = DefaultColor;
      yield return new WaitForSeconds(BlinkSpeed);
    }
  }


}