﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FallingRockGame : ScoreManager
{
  public GameObject player;
  public Text scoreKeeper;
  public GameObject[] spike;
  public GameObject[] spawnLocations;
  public GameObject memory;
  public int fallingObjects;
  void Update()
  {
    scoreKeeper.text = base.score + "/3";

    if (base.score >= 3) {
        SceneManager.LoadScene("diag_1");
    }
  }

  void LateUpdate()
  {
    fallingObjects = GameObject.FindGameObjectsWithTag("FallingObject").Length;
    if (fallingObjects < 4)
    {
        Debug.Log("Spawning... POP: " + fallingObjects);
      spawnSpike();
    }
    
    if (fallingObjects < 4)
    {
      Debug.Log("Spawning... POP: " + fallingObjects);
      spawnMemory();
    }
  }
  override public void resetScore()
  {
    base.resetScore();
    player.transform.position = new Vector3(0, 0, 0);
  }

  private void spawnSpike()
  {
    int spike_type = Random.Range(0, spike.Length);
    int location_type = Random.Range(0, spawnLocations.Length);
    Vector3 location = spawnLocations[location_type].transform.position;
    Instantiate(spike[spike_type], location, new Quaternion(0, 0, 0, 0));
  }

  private void spawnMemory()
  {
    int location_type = Random.Range(0, spawnLocations.Length);
    Vector3 location = spawnLocations[location_type].transform.position;
    Instantiate(memory, location, new Quaternion(0, 0, 0, 0));
  }
}
