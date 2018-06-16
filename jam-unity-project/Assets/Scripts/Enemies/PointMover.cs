using System.Collections;
using UnityEngine;

namespace Enemies
{
  public class PointMover : MonoBehaviour
  {
    private Rigidbody RigidBody;
    public int Speed;

    void Awake()
    {
      RigidBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
      StartCoroutine(Move());
    }

    IEnumerator Move()
    {
      while (true)
      {
        var rand = new System.Random().Next(-Speed, Speed);
        RigidBody.velocity = new Vector3(rand, RigidBody.velocity.y, RigidBody.velocity.z);
        yield return new WaitForSeconds(2);
      }

//      yield return null;
    }

    public void Update()
    {
      var pos = transform.localPosition;

      var boundaryMin = -6.5f;
      var boundaryMax = 6.5f;

      if (pos.x > boundaryMax)
      {
        pos.x = boundaryMin + 0.2f;
      }
      else if (pos.x <boundaryMin)
      {
        pos.x = boundaryMax - 0.2f;
      }

      transform.localPosition = pos;
    }
  }
}