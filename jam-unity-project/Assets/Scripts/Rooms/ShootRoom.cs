using Rooms;

public class ShootRoom : BaseRoom
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
    }
    else
    {
      Done_PlayerController.Instance.Shoot();
    }
  }
}