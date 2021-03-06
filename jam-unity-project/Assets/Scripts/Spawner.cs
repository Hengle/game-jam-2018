﻿using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
  [SerializeField] private GameObject _stab;
  [SerializeField] private GameObject _instance;
  [SerializeField] private string _spawnName;

  private void Awake()
  {
    if (_stab != null)
      Destroy(_stab);

    if (_instance == null)
      throw new NullReferenceException("[Spawner] You need to set instance to spawn");

    var obj = Instantiate(_instance, transform);
    if (!string.IsNullOrEmpty(_spawnName))
    {
      obj.name = _spawnName;
    }
  }
}