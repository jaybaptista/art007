using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCollide : MonoBehaviour
{
    public GameObject spawnPoint;
  // Start is called before the first frame update
  void OnTriggerEnter2D(Collider2D other)
  {
    // Debug.Log("TAG HIT: " + other.tag);
    if (other.tag == "Player")
    {
      // Debug.Log("Respawning..");
      other.transform.position = spawnPoint.transform.position;
    }

    if (other.tag == "FallBlock" && gameObject.tag == "FallingObject") {
      Destroy(gameObject);
    }
  }
}
