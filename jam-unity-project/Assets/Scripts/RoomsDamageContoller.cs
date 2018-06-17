using System.Collections.Generic;
using System.Linq;
using EZCameraShake;
using Rooms;
using UnityEngine;

public class RoomsDamageContoller : MonoBehaviour
{
  public float Magnitude = 2f;
  public float Roughness = 10f;
  public float FadeOutTime = 5f;

  private List<BaseRoom> _rooms = new List<BaseRoom>();
 
  private void Start()
  {
    var ammoRoom = FindObjectOfType<AmmunitionRoom>();
    var energyRoom = FindObjectOfType<EnergyPumpingRoom>();
    var navigationRoom = FindObjectOfType<NavigationRoom>();
    var shieldRoom = FindObjectOfType<ShieldRoom>();
    var shootRoom = FindObjectOfType<ShootRoom>();
    
    _rooms.AddRange(new List<BaseRoom>
    {
      ammoRoom,
      energyRoom,
      navigationRoom,
      shootRoom,
      shieldRoom
    });
    
    CollisionDetector.Instance.PlayerSpaceHit += OnPlayerSpaceHit;
  }

  private void OnPlayerSpaceHit()
  {
    CameraShaker.Instance.ShakeOnce(Magnitude, Roughness, 0, FadeOutTime);
    
    if (GameGod.Instance.ShieldIsActivated)
    {
      GameGod.Instance.DeactivateShield();
    }
    else
    {
      var randomRoom = GetRandomRoom();

      if (randomRoom != null)
      {
//        Debug.Log(randomRoom.GetType().FullName);
        randomRoom.SufferBitch();
      }
    }
  }

  private BaseRoom GetRandomRoom()
  {
    var index = Random.Range(0, _rooms.Count);
    var room = _rooms[index];

    var enyWorking = false; //AWOID CRASH
    foreach (var r in _rooms)
    {
      if (r.CurrentHealth > 0)
        enyWorking = true;
    }

    if (!enyWorking)
    {
      Debug.Log("Ship is destroyed");
      return null;
    }
    
    if (room.CurrentHealth == 0)
      return GetRandomRoom();
    
    return _rooms[index];
  }
}