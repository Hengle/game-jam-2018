using System.Collections.Generic;
using System.Linq;
using Rooms;
using UnityEngine;

public class RoomsDamageContoller : MonoBehaviour
{
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
    
    CollisionDetector.Instance.SpaceHit += InstanceOnSpaceHit;
  }

  private void InstanceOnSpaceHit()
  {
    if (GameGod.Instance.ShieldIsActivated)
    {
      GameGod.Instance.DeactivateShield();
    }
    else
    {
      var randomRoom = GetRandomRoom();

      if (randomRoom != null)
      {
        Debug.Log(randomRoom.GetType().FullName);
        randomRoom.SufferBitch();
      }
    }
  }

  private BaseRoom GetRandomRoom()
  {
    var index = new System.Random().Next(0, _rooms.Count - 1);
    var room = _rooms[index];

    if (_rooms.All(r => r.CurrentHealth == 0))
      return null;
    
    if (room.CurrentHealth == 0)
      return GetRandomRoom();
    
    return _rooms[index];
  }
}