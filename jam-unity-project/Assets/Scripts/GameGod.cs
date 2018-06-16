using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGod : MonoBehaviour {

	private static GameGod _instance;

	public static GameGod Instance
	{
		get { return _instance ?? (_instance = GameObject.Find("GameGod").GetComponent<GameGod>()); }
	}

	public float EnergyIncrement;
	public float Energy;
	public float MaximumEnergy;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddEnergy()
	{
		Energy += EnergyIncrement;
		if (Energy > MaximumEnergy)
		{
			Energy = MaximumEnergy;
		}
	}
}
