namespace Rooms
{
  public class RepairKeyRoom : BaseRoom
  {
    protected override void CancelImpl(Player player) {}

    protected override void UseImpl(Player player)
    {
      if(player.HaveAmmo)
        return;
      
      player.SetRapairKey();
    }
  }
}