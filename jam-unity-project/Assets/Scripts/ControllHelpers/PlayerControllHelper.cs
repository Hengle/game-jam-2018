using Rooms;
using UnityEngine;

namespace ControllHelpers
{
  public class PlayerControllHelper : MonoBehaviour
  {
    [SerializeField] private GameObject LeftStick;
    [SerializeField] private GameObject XButton;
    [SerializeField] private GameObject OButton;
    [SerializeField] private GameObject RapaireButton;

    private void Start()
    {
      var player = GetComponentInChildren<Player>();
      player.OnRoomStateChange += PlayerOnRoomChange;
      
      PlayerOnRoomChange(player.CurrentRoom);
    }

    private void PlayerOnRoomChange(BaseRoom room)
    {
      LeftStick.SetActive(false);
      XButton.SetActive(false);
      OButton.SetActive(false);
      RapaireButton.SetActive(false);
      
      if (room == null)
      {
        return;
      }

      if (room.CurrentHealth < room.MaxHealth)
      {
        RapaireButton.SetActive(true);
        return;
      }

      if(room.IsLocked)
      {
        foreach (var key in room.HelperActiveKeys)
        {
          if (key == ControllHelperKey.LeftStick)
            LeftStick.SetActive(true);
        
          if(key == ControllHelperKey.ButtonX)
            XButton.SetActive(true);
        
          if(key == ControllHelperKey.ButtonO)
            OButton.SetActive(true);
        }
      }
      else
      {
        foreach (var key in room.HelperInactiveKeys)
        {
          if (key == ControllHelperKey.LeftStick)
            LeftStick.SetActive(true);

          if (key == ControllHelperKey.ButtonX)
            XButton.SetActive(true);

          if (key == ControllHelperKey.ButtonO)
            OButton.SetActive(true);
        }
      }
    }
  }
}