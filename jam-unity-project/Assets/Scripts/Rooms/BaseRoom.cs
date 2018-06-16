using UnityEngine;

namespace Rooms
{
  public abstract class BaseRoom : MonoBehaviour
  {
    public int Health = 1;

    public void Use(Player player)
    {
      if(Health == 0)
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
      Health = 0;
    }
  }
}