using UnityEngine;

public class Damaging : MonoBehaviour
{
  [SerializeField] private int _damage;
  
  [SerializeField] private string[] _affectedTags;
  
  private void OnTriggerEnter (Collider other)
  {
    foreach (var t in _affectedTags)
    {
      if (!other.CompareTag(t)) 
        continue;
      
      if(other.gameObject.CompareTag("Player"))
        CollisionDetector.Instance.HitOnPlayer();
        
      var destructible = other.GetComponent<Destructible>();
        
      if(destructible == null)
        return;

      destructible.TakeDamage(_damage);
    }
  }
}