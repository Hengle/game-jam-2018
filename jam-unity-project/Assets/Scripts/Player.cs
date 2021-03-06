﻿using System;
using System.Collections.Generic;
using GamepadInput;
using Rooms;
using UnityEngine;

public enum PlayerIndex
{
	One,
	Two,
	Three
}

public enum Controll
{
	Horizontal,
	Vertical,
	Activate,
	Cancel
}

public class Player : MonoBehaviour
{
	public Action<BaseRoom> OnRoomStateChange = r => { };

	public BaseRoom CurrentRoom
	{
		get { return _currentRoom; }
	}

	public bool CanControll = true;

	public float MoveHorizontal = 0f;
	public float MoveVertical = 0f;
	
	[SerializeField] private float _speed = 5;
	[SerializeField] private PlayerIndex _playerIndex;

	[SerializeField] private GameObject _ammo;
	[SerializeField] private GameObject _repairKey;
	
	public bool HaveAmmo
	{
		get { return _ammo.activeInHierarchy; }
	}

	public bool HaveRepairKey
	{
		get { return _repairKey != null && _repairKey.activeInHierarchy; }
	}

	public int RepairKeyHealth
	{
		get { return _repairKeyHealth; }
		set 
		{ 
			_repairKeyHealth = value;
			
			if (_repairKeyHealth == 0)
				DropRepairKey();
		}
	}

	public int RepairKeyMaxHealth = 1;

	private BaseRoom _currentRoom;
	private const float UseRate = 0.1f;
	private float _nextUse;
	private int _repairKeyHealth = 9;

	public void SetAmmo()
	{
		if (HaveRepairKey)
		{
			Debug.Log("repair key is active!");
			return;
		}

		_ammo.SetActive(true);
	}

	public void DropAmmo()
	{
		_ammo.SetActive(false);
	}

	public void SetRapairKey()
	{
		RepairKeyHealth = RepairKeyMaxHealth;
		
		if (HaveAmmo)
		{
			Debug.Log("ammo key is active!");
			return;
		}

		_repairKey.SetActive(true);		
	}

	public void DropRepairKey()
	{
		_repairKey.SetActive(false);
	}

	public void Cancel()
	{
		if (_currentRoom != null)
			_currentRoom.Cansel(this);
			
		DropAmmo();
		DropRepairKey();
		OnRoomStateChange(_currentRoom);
	}

	private void Start()
	{
		DropAmmo();
		DropRepairKey();
	}

	private void FixedUpdate()
	{
		if(GameGod.Instance.ISGAMEOVER)
			return;
		
		MoveHorizontal = Input.GetAxis(_controlls[_playerIndex][Controll.Horizontal]);
		MoveVertical = Input.GetAxis(_controlls[_playerIndex][Controll.Vertical]);

		var action = Input.GetAxis(_controlls[_playerIndex][Controll.Activate]) > 0;
		var needCansel = Input.GetAxis(_controlls[_playerIndex][Controll.Cancel]) > 0;
		
		if (GamePad.GetButtonDown(GamePad.Button.B, _gamePadMap[_playerIndex]))
		{
//			Debug.Log("Activate_P" + ((int)_playerIndex + 1));
			action = true;
		}
		
		if (GamePad.GetButtonDown(GamePad.Button.X, _gamePadMap[_playerIndex]))
		{
			needCansel = true;
//			Debug.Log("Cansel_P" + ((int)_playerIndex + 1));
		}
		
		if (action && _currentRoom != null && Time.time > _nextUse)
		{
			_nextUse = Time.time + UseRate;
			_currentRoom.Use(this);
			
			OnRoomStateChange(_currentRoom);
		}

		if (needCansel)
		{
			Cancel();
		}
		
		if(!CanControll)
			return;
		
		var movement = new Vector3 (MoveHorizontal, 0.0f, MoveVertical);
		
		if(_animator.gameObject.activeSelf){
			_animator.SetBool("isRunning", movement != Vector3.zero);
		}
		

		var rigid = GetComponent<Rigidbody>(); 
		
		rigid.velocity = movement * _speed;
		
		// The step size is equal to speed times frame time.
		float step = 5 * Time.deltaTime;
		var vector = Quaternion.AngleAxis(90, Vector3.up) * rigid.velocity;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, vector, step, 0.0f);
		// Move our position a step closer to the target.
		rigid.rotation = Quaternion.LookRotation(newDir);
	}

	private void OnTriggerEnter(Collider other)
	{
		var room = other.GetComponent<BaseRoom>();
		
		if(room == null)
			return;

		_currentRoom = room;

		OnRoomStateChange(_currentRoom);
	}
	
	private void OnTriggerExit(Collider other)
	{
		var room = other.GetComponent<BaseRoom>();
		
		if(room == null)
			return;

		_currentRoom = null;

		OnRoomStateChange(_currentRoom);
	}
	
	private Dictionary<PlayerIndex, Dictionary<Controll, string>> _controlls =
		new Dictionary<PlayerIndex, Dictionary<Controll, string>>
		{
			{
				PlayerIndex.One, new Dictionary<Controll, string>
				{
					{
						Controll.Horizontal, "Horizontal_P1"
					},
					{
						Controll.Vertical, "Vertical_P1"
					},
					{
						Controll.Activate, "Activate_P1"
					},
					{
						Controll.Cancel, "Cancel_P1"
					}
				}
			},
			{
				PlayerIndex.Two,
				new Dictionary<Controll, string>
				{
					{
						Controll.Horizontal, "Horizontal_P2"
					},
					{
						Controll.Vertical, "Vertical_P2"
					},
					{
						Controll.Activate, "Activate_P2"
					},
					{
						Controll.Cancel, "Cancel_P2"
					}
				}
			},
			{
				PlayerIndex.Three,
				new Dictionary<Controll, string>
				{
					{
						Controll.Horizontal, "Horizontal_P3"
					},
					{
						Controll.Vertical, "Vertical_P3"
					},
					{
						Controll.Activate, "Activate_P3"
					},
					{
						Controll.Cancel, "Cancel_P3"
					}
				}
			}
		};
	
	private Dictionary<PlayerIndex, GamePad.Index> _gamePadMap = new Dictionary<PlayerIndex, GamePad.Index>
	{
		{
			PlayerIndex.One, GamePad.Index.One
		},
		{
			PlayerIndex.Two, GamePad.Index.Two
		},
		{
			PlayerIndex.Three, GamePad.Index.Three
		},
	};

	[SerializeField] private Animator _animator;
}