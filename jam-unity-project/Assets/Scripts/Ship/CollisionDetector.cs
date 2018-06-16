using System;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
  private static CollisionDetector _instance;

  public static CollisionDetector Instance
  {
    get { return _instance; }
  }

  public event Action SpaceHit = delegate { };

  // Use this for initialization
  void Awake()
  {
    _instance = this;
  }


  public void Rise()
  {
    SpaceHit();
  }
}