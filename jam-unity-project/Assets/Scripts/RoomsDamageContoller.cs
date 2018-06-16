using System.Collections.Generic;
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
    
    Done_PlayerController.Instance.SpaceHit += InstanceOnSpaceHit;
  }

  private void InstanceOnSpaceHit()
  {
    if (GameGod.Instance.ShieldIsActivated)
    {
      GameGod.Instance.DeactivateShield();
    }
    else
    {
      var randomRoom = new System.Random().Next(0,_rooms.Count);
      var targetRoom = _rooms[randomRoom];

      targetRoom.SufferBitch();
    }
  }
}