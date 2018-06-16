using UnityEngine;
using System.Collections;

public class Done_EvasiveManeuver : MonoBehaviour
{
	public Done_Boundary boundary;
	public float tilt;
	public float dodge;
	public float smoothing;
	public Vector2 startWait;
	public Vector2 maneuverTime;
	public Vector2 maneuverWait;

	private float currentSpeed;
	private float targetManeuver;

	void Start ()
	{
		currentSpeed = GetComponent<Rigidbody>().velocity.z;
		StartCoroutine(Evade());
	}
	
	IEnumerator Evade ()
	{
		yield return new WaitForSeconds (Random.Range (startWait.x, startWait.y));
		while (true)
		{
			targetManeuver = Random.Range (1, dodge) * -Mathf.Sign (transform.position.x);
			yield return new WaitForSeconds (Random.Range (maneuverTime.x, maneuverTime.y));
			targetManeuver = 0;
			yield return new WaitForSeconds (Random.Range (maneuverWait.x, maneuverWait.y));
		}
	}
	
	void FixedUpdate ()
	{
		var rigid = GetComponent<Rigidbody>();
		
		float newManeuver = Mathf.MoveTowards (rigid.velocity.x, targetManeuver, smoothing * Time.deltaTime);
		rigid.velocity = new Vector3 (newManeuver, rigid.velocity.y, rigid.velocity.z);
		
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (rigid.rotation.eulerAngles.x, rigid.rotation.eulerAngles.y, rigid.velocity.x * -tilt);
	}
}
