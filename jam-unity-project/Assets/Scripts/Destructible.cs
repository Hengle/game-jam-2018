using System;
using System.Linq;
using UnityEngine;

public class Destructible : MonoBehaviour
{
  public event Action<Destructible> OnDestroy = d => { }; 

  [SerializeField] private int _health;
  [SerializeField] private int _score;
  
  [SerializeField] private GameObject _destroyEffect;
  [SerializeField] private GameObject _damageEffect;

  [SerializeField] private string[] _affectedTags; 

  private void Awake()
  {
    OnDestroy += OnDestroyIvoked;
  }

  private void OnTriggerEnter (Collider other)
  {
    foreach (var t in _affectedTags)
    {
      if (other.CompareTag(t))
      {
        //    if(other.gameObject.CompareTag("Player"))
//      CollisionDetector.Instance.HitOnPlayer();
        #warning fixed Player hit

        CollisionDetector.Instance.AnyHit();
    
        TakeDamage(1);
      }
    }
  }

  private void TakeDamage(int damage)
  {
    _health -= damage;
    
    if (_damageEffect != null)
    {
      Instantiate(_damageEffect, transform.position, transform.rotation);
    }    

    if (_health <= 0)
      OnDestroy(this);
  }
  
  private void OnDestroyIvoked(Destructible obj)
  {
    if (_destroyEffect != null)
    {
      Instantiate(_destroyEffect, transform.position, transform.rotation);
    }

    GameGod.Instance.AddScore(_score);
		
    Destroy (gameObject);
  }
}