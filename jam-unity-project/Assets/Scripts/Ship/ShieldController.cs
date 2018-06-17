using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
  private GameObject Shield;
  private CameraFilterPack_AAA_SuperHexagon _shipPostEffect;

  public void Start()
  {
    Shield = transform.GetChild(0).gameObject;
    _shipPostEffect = FindObjectOfType<CameraFilterPack_AAA_SuperHexagon>();
  }
  
  // Update is called once per frame
  void Update()
  {
    if (GameGod.Instance.ShieldIsActivated)
    {
      Shield.SetActive(true);
      _shipPostEffect.enabled = true;
    }

    if (!GameGod.Instance.ShieldIsActivated)
    {
      Shield.SetActive(false);
      _shipPostEffect.enabled = false;
    }
  }
}