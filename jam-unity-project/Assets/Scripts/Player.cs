using System.Collections.Generic;
using GamepadInput;
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
	Vertical
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
					}
				}
			}
		};

	public bool CanControll = true;

	public float MoveHorizontal = 0f;
	public float MoveVertical = 0f;
	
	[SerializeField] private float _speed = 5;
	[SerializeField] private PlayerIndex _playerIndex;

	private BaseRoom _currentRoom;
	private const float UseRate = 0.5f;
	private float _nextUse;

	private void FixedUpdate()
	{
		MoveHorizontal = Input.GetAxis(_controlls[_playerIndex][Controll.Horizontal]);
		MoveVertical = Input.GetAxis(_controlls[_playerIndex][Controll.Vertical]);
		
		if(!CanControll)
			return;
		
		var movement = new Vector3 (MoveHorizontal, 0.0f, MoveVertical);

		var rigid = GetComponent<Rigidbody>(); 
		
		rigid.velocity = movement * _speed;

		var action = false;
		
		if (GamePad.GetButtonDown(GamePad.Button.B, GamePad.Index.One))
		{
			if (_currentRoom != null)
				_currentRoom.Use(this);
			
			Debug.Log("Activate_P1");
			action = true;
		}
		
		if (GamePad.GetButtonDown(GamePad.Button.X, GamePad.Index.One))
		{
			
			Debug.Log("Cansel_P1");
			action = true;
		}
		
		if (GamePad.GetButtonDown(GamePad.Button.X, GamePad.Index.Two))
		{
			Debug.Log("Fire_P2");
			action = true;
		}
		
		if (GamePad.GetButtonDown(GamePad.Button.X, GamePad.Index.Two))
		{
			Debug.Log("Fire_P3");
			action = true;
		}
		
		if (action && _currentRoom != null && Time.time > _nextUse)
		{
			_nextUse = Time.time + UseRate;
			_currentRoom.Use(this);
		}
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
	}
}