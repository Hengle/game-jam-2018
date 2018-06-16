using UnityEngine;

public class NavigationRoom : BaseRoom
{
  public static Player CurrentPlayer;

  protected override void UseImpl(Player player)
  {
    if (CurrentPlayer == null)
    {
      CurrentPlayer = player;
      CurrentPlayer.CanControll = false;
    }
  }
  
  private void FixedUpdate()
  {
    if(CurrentPlayer == null)
      return;
    
    var moveHorizontal = CurrentPlayer.MoveHorizontal;
    var moveVertical = CurrentPlayer.MoveVertical;

    Done_PlayerController.Instance.MoveHorizontal(moveHorizontal);
    Done_PlayerController.Instance.MoveVertical(moveVertical);

    //TODO link navigation room to ship
  }
}