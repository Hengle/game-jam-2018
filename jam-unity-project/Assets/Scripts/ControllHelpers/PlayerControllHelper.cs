using Rooms;
using UnityEngine;

namespace ControllHelpers
{
  public class PlayerControllHelper : MonoBehaviour
  {
    [SerializeField] private GameObject LeftStick;
    [SerializeField] private GameObject XButton;
    [SerializeField] private GameObject OButton;

    private void Start()
    {
      var player = GetComponentInChildren<Player>();
      player.OnRoomChange += PlayerOnRoomChange;
      
      PlayerOnRoomChange(player.CurrentRoom);
    }

    private void PlayerOnRoomChange(BaseRoom room)
    {
      if (room == null)
      {
        LeftStick.SetActive(false);
        XButton.SetActive(false);
        OButton.SetActive(false);
        
        return;
      }

      foreach (var key in room.HelperKeys)
      {
        if (key == ControllHelperKey.LeftStick)
          LeftStick.SetActive(true);
        
        if(key == ControllHelperKey.ButtonX)
          XButton.SetActive(true);
        
        if(key == ControllHelperKey.ButtonO)
          OButton.SetActive(true);
      }
    }
  }
}