using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Done_WeaponController : MonoBehaviour
{
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;
	
	public List<AudioClip> Clips;

	void Start ()
	{
		InvokeRepeating ("Fire", delay, fireRate);
	}

	void Fire ()
	{
		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		var randNum = new System.Random().Next(0, Clips.Count);
		var audioSource = GetComponent<AudioSource>();
		audioSource.clip = Clips[randNum];
		audioSource.Play();
	}
}
