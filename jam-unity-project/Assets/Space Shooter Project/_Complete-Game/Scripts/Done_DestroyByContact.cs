using UnityEngine;
using System.Collections;

public class Done_DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;

	void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
		{
			return;
		}

		if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}

		if (other.CompareTag("Player") && playerExplosion != null)
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
		}

	
		GameGod.Instance.AddScore(scoreValue);
		
		if(other.gameObject.CompareTag("Player"))
			CollisionDetector.Instance.HitOnPlayer();
		
		Destroy (gameObject);
	}
}