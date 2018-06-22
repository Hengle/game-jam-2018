using System;
using UnityEngine;

public class CollisionObject : MonoBehaviour
{
  [SerializeField] private bool _takeDamange;
  [SerializeField] private bool _receiveDamage;
  
  [SerializeField] private GameObject _destroyEffect;
  [SerializeField] private GameObject _damageEffect;
  
  public event Action<CollisionObject> OnDestroy = d => { }; 

  [SerializeField] private int _health;
  [SerializeField] private int _score;
  
  [SerializeField] private int _damage;  
  [SerializeField] private string[] _affectedTags;

  private void Awake()
  {
    OnDestroy += OnDestroyIvoked;
  }
    
  private void OnTriggerEnter (Collider other)
  {
    foreach (var t in _affectedTags)
    {
      if (!other.CompareTag(t)) 
        continue;
      
      if(other.gameObject.CompareTag(ProjectConstants.PLAYER_TAG))
        CollisionDetector.Instance.HitOnPlayer();
        
      var destructible = other.GetComponent<Destructible>();
        
      if(destructible == null)
        return;

      destructible.TakeDamage(_damage);
    }
  }
  
  private void TakeDamage(int damage)
  {
    _health -= damage;
    
    Debug.Log(gameObject.name + " take " + damage);
    
    if (_damageEffect != null)
    {
      Instantiate(_damageEffect, transform.position, transform.rotation);
    }    

    if (_health <= 0)
      OnDestroy(this);
  }
  
  private void OnDestroyIvoked(CollisionObject obj)
  {
    if (_destroyEffect != null)
    {
      Instantiate(_destroyEffect, transform.position, transform.rotation);
    }

    GameGod.Instance.AddScore(_score);
		
    Destroy (gameObject);
  }
}