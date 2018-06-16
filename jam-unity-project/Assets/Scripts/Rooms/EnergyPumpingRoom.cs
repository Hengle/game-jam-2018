using Rooms;

public class EnergyPumpingRoom : BaseRoom
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
    } else
    {
      GameGod.Instance.AddEnergy();
    }
  }
}