using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollide : MonoBehaviour
{
  public ScoreManager manager;
  public bool solid = false;
  void Start()
  {
    manager = Object.FindObjectOfType<ScoreManager>();
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    // Debug.Log("Collided with " + other.name);
    if (other.tag == "Player")
    {
      Destroy(gameObject);
      Debug.Log("Player Point Scored");
      manager.Iterate();
    } else if ((other.tag == "Tilemap" && !solid) && gameObject.transform.position.y < -10) {
      Destroy(gameObject);
    }
  }

  void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerComponent")
    {
      Destroy(gameObject);
      Debug.Log("Player Point Scored");
      manager.Iterate();
    }
  }
}
