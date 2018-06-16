using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
	private static Done_PlayerController _instance;
	public static Done_PlayerController Instance
	{
		get
		{
			return _instance ?? (_instance = GameObject.Find("Done_Player").GetComponent<Done_PlayerController>());
		}
	}
	public float speed;
	public float tilt;
	public Done_Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	 
	private float nextFire;
	
	void Update ()
	{
//		if (Input.GetButton("Fire1") && Time.time > nextFire) 
//		{
//			nextFire = Time.time + fireRate;
//			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
//			GetComponent<AudioSource>().Play ();
//		}
	}

	void FixedUpdate ()
	{
//		float moveHorizontal = Input.GetAxis ("Horizontal");
//		float moveVertical = Input.GetAxis ("Vertical");
//
//		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
//		GetComponent<Rigidbody>().velocity = movement * speed;
//		
//		GetComponent<Rigidbody>().position = new Vector3
//		(
//			Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
//			0.0f, 
//			Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
//		);
		
		var rigidBody = GetComponent<Rigidbody>();
		var rotation =  Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
		rotation.x = rigidBody.rotation.x;
		rotation.y = rigidBody.rotation.y;
		rigidBody.rotation = rotation;
	}

	public void MoveHorizontal(float directionAndPower)
	{
		var rigid = GetComponent<Rigidbody>();
		Vector3 movement = new Vector3 (directionAndPower, 0.0f, rigid.velocity.y);
		rigid.velocity = movement * speed;
	}

	public void MoveVertical(float directionAndPower)
	{
		var rigid = GetComponent<Rigidbody>();
		Vector3 movement = new Vector3 (rigid.velocity.x, 0.0f, directionAndPower);
		rigid.velocity = movement * speed;
		
	}
}
