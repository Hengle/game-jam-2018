using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
  [SerializeField] private GameObject _stab;
  [SerializeField] private GameObject _instance;

  private void Awake()
  {
    _stab.SetActive(false);
    
    if(_instance == null)
      throw new NullReferenceException("[Spawner] You need to set instance to spawn");

    Instantiate(_instance, transform);
  }
}