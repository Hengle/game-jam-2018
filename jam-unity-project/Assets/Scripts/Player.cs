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

	[SerializeField] private float _speed = 1;
	[SerializeField] private PlayerIndex _playerIndex;

	private BaseRoom _currentRoom;
	private const float UseRate = 0.5f;
	private float _nextUse;

	private void FixedUpdate()
	{
		var moveHorizontal = Input.GetAxis(_controlls[_playerIndex][Controll.Horizontal]);
		var moveVertical = Input.GetAxis(_controlls[_playerIndex][Controll.Vertical]);
		
		if(moveHorizontal != 0)
			Debug.Log("H: " + _playerIndex + " " + moveHorizontal);
		
		if(moveVertical != 0)
			Debug.Log("V: " + _playerIndex + " " + moveVertical);

		var movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		var rigid = GetComponent<Rigidbody>(); 
		
		rigid.velocity = movement * _speed;
		
		if (GamePad.GetButtonDown(GamePad.Button.X, GamePad.Index.One))
		{
			Debug.Log("Fire_P1");
		}
		
		if (GamePad.GetButtonDown(GamePad.Button.X, GamePad.Index.Two))
		{
			Debug.Log("Fire_P2");
		}
		
		if (GamePad.GetButtonDown(GamePad.Button.X, GamePad.Index.Two))
		{
			Debug.Log("Fire_P3");
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Room"))
		{
			_currentRoom = other.GetComponent<BaseRoom>();
			Debug.LogError("Get room " + _currentRoom.name);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Room"))
		{
			_currentRoom = null;
			Debug.Log("Free room ");
		}
	}
}