using System;
using UnityEngine;

public class CollisionObject : MonoBehaviour
{
  [SerializeField] private bool _takeDamage = true;
  [SerializeField] private bool _receiveDamage = true;
  
  [SerializeField] private GameObject _destroyEffect;
  [SerializeField] private GameObject _damageEffect;
  
  [SerializeField] private bool _takeDamageFxPlay = true;
  
  public event Action<CollisionObject> OnDestroy = d => { }; 

  [SerializeField] private int _health;
  [SerializeField] private int _score;
  
  [SerializeField] private int _damage;
  [SerializeField] private string[] _affectedTags;

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
      
      if(other.gameObject.CompareTag(ProjectConstants.PLAYER_TAG))
        CollisionDetector.Instance.HitOnPlayer();
        
      var destructible = other.GetComponent<CollisionObject>();
        
      if(destructible == null)
        continue;
   
      destructible.ReceiveDamage(damage);
    }
  }

  private void ReceiveDamage(int damage)
  {
    if(gameObject.CompareTag(ProjectConstants.PLAYER_TAG))
      Console.Write("");
    
    if(_takeDamageFxPlay && _damageEffect != null)
      Instantiate(_damageEffect, transform.position, transform.rotation);
    
    if(!_receiveDamage)
      return;
    
    _health -= damage;
    
    Debug.Log(gameObject.name + " take " + damage);
    
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
		
    Destroy(gameObject);
  }
}