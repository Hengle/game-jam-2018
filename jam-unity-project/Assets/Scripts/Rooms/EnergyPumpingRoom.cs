using Rooms;

public class EnergyPumpingRoom : BaseRoom
{
  public static Player CurrentPlayer;
  
  protected override void CancelImpl(Player player)
  {
    if (CurrentPlayer == null)
      return;

    CurrentPlayer = null;
  }

  protected override void UseImpl(Player player)
  {
    if (CurrentPlayer == null)
    {
      CurrentPlayer = player;
    } else
    {
      GameGod.Instance.AddEnergy();
    }
  }
}