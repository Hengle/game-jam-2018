using UnityEngine;

public class FollowToPosition : MonoBehaviour
{
	[SerializeField] private GameObject _target;
	
	void LateUpdate ()
	{
		transform.position = new Vector3(_target.transform.position.x,
			_target.transform.position.y + 2.5f,
			_target.transform.position.z - 1.5f);
	}
}
