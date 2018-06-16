using System.Collections;
using Rooms;
using UnityEngine;

public class NavigationRoom : BaseRoom
{
  public static Player CurrentPlayer;

  protected override void CancelImpl(Player player)
  {
    if (CurrentPlayer == null)
      return;

    CurrentPlayer.CanControll = true;
    CurrentPlayer = null;
  }

  protected override void UseImpl(Player player)
  {
    if (CurrentPlayer == null)
    {
      CurrentPlayer = player;
      CurrentPlayer.CanControll = false;
      StartCoroutine(EnergyConsumption());
    }
  }
  
  private void FixedUpdate()
  {
    if (CurrentPlayer == null)
      return;
    
    if (NeedToStop())
    {
      StopCoroutine(EnergyConsumption());
      return;
    }

    var moveHorizontal = CurrentPlayer.MoveHorizontal;
    var moveVertical = CurrentPlayer.MoveVertical;

    Done_PlayerController.Instance.MoveHorizontal(moveHorizontal);
    Done_PlayerController.Instance.MoveVertical(moveVertical);

    //TODO link navigation room to ship
  }

  private IEnumerator EnergyConsumption()
  {
    while (true)
    {
      if (NeedToStop())
        break;
      
      if(CurrentPlayer.MoveHorizontal > 0 || CurrentPlayer.MoveVertical > 0)
        GameGod.Instance.Energy -= GameGod.Instance.NavigationEnergyConsumption;
      
      yield return new WaitForSeconds(GameGod.Instance.NavigationEnergyTimeOut); 
    }
  }

  private bool NeedToStop()
  {
    var lowEnergy = GameGod.Instance.Energy < .001f;
    
    return CurrentPlayer == null || lowEnergy;
  }
}