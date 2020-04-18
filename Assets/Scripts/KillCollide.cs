using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCollide : MonoBehaviour
{
    public ScoreManager manager;

    void Start() {
        manager = Object.FindObjectOfType<ScoreManager>();
    }

    void OnTriggerEnter2D(Collider2D other) {
    // Debug.Log("Collided with " + other.name);
        if (other.tag == "Player") {
            Debug.Log("Player Death Triggered");
            manager.resetScore();
        }

        if (gameObject.tag == "FallingObject") {
            Destroy(gameObject);
        }
    }
}
