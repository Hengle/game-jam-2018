using Rooms;

public class AmmunitionRoom : BaseRoom
{
  protected override void CancelImpl(Player player) { }

  protected override void UseImpl(Player player)
  {
    player.SetAmmo();
  }
}