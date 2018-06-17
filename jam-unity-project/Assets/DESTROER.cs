using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DESTROER : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
	if(transform.position.z < -5)
		Destroy(this);
	}
}
