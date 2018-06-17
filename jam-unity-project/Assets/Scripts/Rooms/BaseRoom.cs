using System.Collections.Generic;
using ControllHelpers;
using UnityEngine;

namespace Rooms
{
  public abstract class BaseRoom : MonoBehaviour
  {
    public List<GameObject> Lights;
    
    public int CurrentHealth = 9;
    public int MaxHealth = 9;

    [SerializeField] private GameObject _damaged;
    [SerializeField] private ControllHelperKey[] _inactiveKeys;
    [SerializeField] private ControllHelperKey[] _activeKeys;

    private Player _currentPlayer;
    
    public bool IsLocked = false;
    
    public ControllHelperKey[] HelperInactiveKeys
    {
      get { return _inactiveKeys; }
    }

    public ControllHelperKey[] HelperActiveKeys
    {
      get { return _activeKeys; }
    }

    public void Use(Player player)
    {
      if (player.HaveRepairKey && CurrentHealth < MaxHealth)
      {
        CurrentHealth += GameGod.Instance.RepaireKeyPower;
        player.RepairKeyHealth -= GameGod.Instance.RepaireKeyDecrement;
        
        if (CurrentHealth > MaxHealth)
          CurrentHealth = MaxHealth;
        
        return;
      }

      if(CurrentHealth < MaxHealth)
        return;

      _currentPlayer = player;
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
      Cansel(_currentPlayer);
    }

    private void Update()
    {
      _damaged.SetActive(CurrentHealth < MaxHealth);

      if (Lights == null)
        return;

      var damaged = CurrentHealth == 0;
      if (damaged)
      {
        foreach (var o in Lights)
        {
          o.SetActive(false);
        }
      }
      else
      {
        foreach (var o in Lights)
        {
          o.SetActive(true);
        }
      }
    }
  }
}