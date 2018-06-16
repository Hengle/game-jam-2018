using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
  private GameObject Shield;

  public void Start()
  {
    Shield = transform.GetChild(0).gameObject;
  }
  
  // Update is called once per frame
  void Update()
  {
    if (GameGod.Instance.ShieldIsActivated && !Shield.activeInHierarchy)
    {
      Shield.SetActive(true);
    }

    if (!GameGod.Instance.ShieldIsActivated && Shield.activeInHierarchy)
    {
      Shield.SetActive(false);
    }
  }
}