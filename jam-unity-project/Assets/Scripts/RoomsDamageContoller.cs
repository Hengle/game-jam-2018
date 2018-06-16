using UnityEngine;

public class RoomsDamageContoller : MonoBehaviour
{
  private void Start()
  {
    Done_PlayerController.Instance.SpaceHit += InstanceOnSpaceHit;
  }

  private void InstanceOnSpaceHit()
  {
    if (GameGod.Instance.ShieldIsActivated)
    {
      
      GameGod.Instance.DeactivateShield();
    }
  }
}