namespace LevelControll
{
  public class LevelDataDto
  {
    public int EnemiesCount { get; private set; }
    public int AsteroidsCount { get; private set; }

    public LevelDataDto(int enemiesCount, int asteroidsCount)
    {
      EnemiesCount = enemiesCount;
      AsteroidsCount = asteroidsCount;
    }
  }
}