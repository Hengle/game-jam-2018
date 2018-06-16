using Rooms;

public class ShieldRoom : BaseRoom
{
  protected override void CancelImpl(Player player)
  {
  }

  protected override void UseImpl(Player player)
  {
    GameGod.Instance.ActivateShield();
  }
}