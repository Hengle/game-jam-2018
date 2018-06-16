using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGod : MonoBehaviour {

	private static GameGod _instance;

	public static GameGod Instance
	{
		get { return _instance ?? (_instance = GameObject.Find("GameGod").GetComponent<GameGod>()); }
	}
	
	public event Action Updated = delegate {  };

	public float EnergyIncrement;
	public float Energy;
	public float MaximumEnergy;

	public float ShieldActivationEnergy = 20;
	public bool ShieldIsActivated;
	
	public void AddEnergy()
	{
		Energy += EnergyIncrement;
		if (Energy > MaximumEnergy)
		{
			Energy = MaximumEnergy;
		}
	}

	public void ActivateShield()
	{
		if (Energy > ShieldActivationEnergy)
		{
			ShieldIsActivated = true;
			Energy -= ShieldActivationEnergy;
		}
		Updated();
	}

	public void DeactivateShield()
	{
		ShieldIsActivated = false;
		Updated();
	}
}
