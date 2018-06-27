using UnityEngine;

namespace LevelControll
{
  public class LevelMaster : MonoBehaviour
  {
    private int _enemiesCount;
    private int _asteroidsCount;

    public void Pass(LevelDataDto dto)
    {
      _enemiesCount = dto.EnemiesCount;
      _asteroidsCount = dto.AsteroidsCount;
    }
  }
}