public class PlayerCollisionObject : CollisionObject
{
  protected override void ReceiveDamageImpl(int damage)
  {
    CollisionDetector.Instance.HitOnPlayer();
  }
}