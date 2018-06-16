using ControllHelpers;
using UnityEngine;

namespace Rooms
{
  public abstract class BaseRoom : MonoBehaviour
  {
    public int CurrentHealth = 1;
    public int MaxHealth = 10;

    [SerializeField] private GameObject _damaged;
    [SerializeField] private ControllHelperKey[] _keys;

    public ControllHelperKey[] HelperKeys
    {
      get { return _keys; }
    }

    public void Use(Player player)
    {
      if (player.HaveRepairKey && CurrentHealth == 0)
      {
        CurrentHealth = MaxHealth;
        player.RepairKeyHealth = 0;
        
        if (CurrentHealth > MaxHealth)
          CurrentHealth = MaxHealth;
        
        return;
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
      CurrentHealth = 0;
    }

    private void Update()
    {
      _damaged.SetActive(CurrentHealth == 0);
    }
  }
}