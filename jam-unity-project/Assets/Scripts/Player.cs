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

	private BaseRoom _currentRoom;
	private const float UseRate = 0.5f;
	private float _nextUse;

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

	private void FixedUpdate()
	{
		MoveHorizontal = Input.GetAxis(_controlls[_playerIndex][Controll.Horizontal]);
		MoveVertical = Input.GetAxis(_controlls[_playerIndex][Controll.Vertical]);

		var action = Input.GetAxis(_controlls[_playerIndex][Controll.Activate]) > 0;
		var cansel = Input.GetAxis(_controlls[_playerIndex][Controll.Cancel]) > 0;
		
		if (GamePad.GetButtonDown(GamePad.Button.B, _gamePadMap[_playerIndex]))
		{
			Debug.Log("Activate_P" + ((int)_playerIndex + 1));
			action = true;
		}
		
		if (GamePad.GetButtonDown(GamePad.Button.X, _gamePadMap[_playerIndex]))
		{
			cansel = true;
			Debug.Log("Cansel_P" + ((int)_playerIndex + 1));
		}
		
		if (action && _currentRoom != null && Time.time > _nextUse)
		{
			_nextUse = Time.time + UseRate;
			_currentRoom.Use(this);
		}

		if (cansel)
		{
			if (_currentRoom != null)
				_currentRoom.Cansel(this);
		}
		
		if(!CanControll)
			return;
		
		var movement = new Vector3 (MoveHorizontal, 0.0f, MoveVertical);

		var rigid = GetComponent<Rigidbody>(); 
		
		rigid.velocity = movement * _speed;
	}

	private void OnTriggerEnter(Collider other)
	{
		var room = other.GetComponent<BaseRoom>();
		
		if(room == null)
			return;

		_currentRoom = room;
	}
	
	private void OnTriggerExit(Collider other)
	{
		var room = other.GetComponent<BaseRoom>();
		
		if(room == null)
			return;

		_currentRoom = null;
	}
}