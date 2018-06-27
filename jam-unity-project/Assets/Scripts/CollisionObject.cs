using System;
using UnityEngine;

public class CollisionObject : MonoBehaviour
{
  [SerializeField] private bool _takeDamage = true;
  [SerializeField] private bool _receiveDamage = true;
  
  [SerializeField] private GameObject _destroyEffect;
  [SerializeField] private GameObject _damageEffect;
  
  [SerializeField] private bool _takeDamageFxPlay = true;
  
  [SerializeField] private int _health;
  [SerializeField] private int _score;
  
  [SerializeField] private int _damage;
  [SerializeField] private string[] _affectedTags;
  
  public event Action<CollisionObject> OnDestroy = d => { };

  private void Awake()
  {
    OnDestroy += OnDestroyIvoked;
  }
    
  private void OnTriggerEnter(Collider other)
  {
    TakeDamage(other, _damage);
  }

  private void TakeDamage(Component other, int damage)
  {
    if(!_takeDamage)
      return;
    
    foreach (var t in _affectedTags)
    {
      if (!other.CompareTag(t)) 
        continue;
        
      var destructible = other.GetComponent<CollisionObject>();
        
      if(destructible == null)
        continue;
   
      destructible.ReceiveDamage(damage);
    }
  }

  private void ReceiveDamage(int damage)
  {    
    if(_takeDamageFxPlay && _damageEffect != null)
      Instantiate(_damageEffect, transform.position, transform.rotation);

    if(!_receiveDamage)
      return;
    
    ReceiveDamageImpl(damage);
  }

  protected virtual void ReceiveDamageImpl(int damage)
  {    
    _health -= damage;
    
    if (_health <= 0)
      OnDestroyCall();
  }

  protected void OnDestroyCall()
  {
    OnDestroy(this);
  }

  private void OnDestroyIvoked(CollisionObject obj)
  {
    if (_destroyEffect != null)
    {
      Instantiate(_destroyEffect, transform.position, transform.rotation);
    }

    GameGod.Instance.AddScore(_score);
		
    Destroy(gameObject);
  }
}