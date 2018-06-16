using UnityEngine;

namespace Rooms
{
  public abstract class BaseRoom : MonoBehaviour
  {
    public int CurrentHealth = 1;
    public int MaxHealth = 10;

    public void Use(Player player)
    {
      if (player.HaveRepairKey && CurrentHealth == 0)
      {
        CurrentHealth++;
        player.RepairKeyHealth--;
        
        if (CurrentHealth > MaxHealth)
          CurrentHealth = MaxHealth;
      }

      if(CurrentHealth == 0)
        return;

      UseImpl(player);
    }

    public void Cansel(Player player)
    {
      CancelImpl(player);
    }

    protected abstract void CancelImpl(Player player);
    protected abstract void UseImpl(Player player);

    public void SufferBitch()
    {
      //CurrentHealth = 0;
    }
  }
}