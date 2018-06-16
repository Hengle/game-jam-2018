﻿using System;
using UnityEngine;

public class GameGod : MonoBehaviour {

	private static GameGod _instance;

	public static GameGod Instance
	{
		get { return _instance; }
	}
	
	public event Action Updated = delegate {  };

	public float NavigationEnergyConsumption = 3;
	public float NavigationEnergyTimeOut = 1;
	
	public float EnergyIncrement;
	public float Energy;
	public float MaximumEnergy;

	public int BulletsIncrement = 10;
	public int CurrentBullets = 10;
	public int MaximumBullets = 10;

	private void Awake()
	{
		_instance = this;
	}

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
	
	public void AddBullets()
	{
		CurrentBullets += BulletsIncrement;
		if (CurrentBullets > MaximumBullets)
			CurrentBullets = MaximumBullets;
	}
}
