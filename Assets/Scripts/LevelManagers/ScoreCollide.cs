using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollide : MonoBehaviour
{
  public ScoreManager manager;

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
      
    } else {
      Destroy(gameObject);
    }
  }
}
