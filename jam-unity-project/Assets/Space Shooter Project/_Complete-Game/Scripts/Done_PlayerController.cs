using System;
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
    get { return _instance; }
  }

  public float speed;
  public float tilt;
  public Done_Boundary boundary;

  public GameObject shot;
  public Transform shotSpawn;
  public float fireRate;


  private float nextFire;

  public void Awake()
  {
    _instance = this;
  }

  public void Shoot()
  {
    if (Time.time > nextFire)
    {
      nextFire = Time.time + fireRate;
      var obj = Instantiate(shot, shotSpawn);
      obj.transform.Rotate(shotSpawn.forward);
      //GetComponent<AudioSource>().Play();
    }
  }

  void FixedUpdate()
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
    var rotation = Quaternion.Euler(0.0f, 0.0f, 0); //GetComponent<Rigidbody>().velocity.x * -tilt);
    rotation.x = rigidBody.rotation.x;
    rotation.y = rigidBody.rotation.y;
//    rigidBody.rotation = rotation;

    var pos = transform.localPosition;


    if (pos.x > boundary.xMax)
    {
      pos.x = boundary.xMin + 0.2f;
    }
    else if (pos.x < boundary.xMin)
    {
      pos.x = boundary.xMax - 0.2f;
    }

    transform.localPosition = pos;
  }

  public void MoveHorizontal(float directionAndPower)
  {
    var rigid = GetComponent<Rigidbody>();
    Vector3 movement = new Vector3(directionAndPower, 0.0f, rigid.velocity.z);
    rigid.velocity = movement * speed;
  }

  public void MoveVertical(float directionAndPower)
  {
    var rigid = GetComponent<Rigidbody>();
    Vector3 movement = new Vector3(rigid.velocity.x, directionAndPower, 0);
    rigid.velocity = movement * speed;
  }
}