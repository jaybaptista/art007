using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FracturedGame : ScoreManager
{
  public GameObject playerSpawn;
  public RespawnCollide[] spike;
  public GameObject[] spawnLocations;
  private int fallingObjects;
  public int maxFallObj;
  public int numberOfTreeMems = 4;
  public string scene;
  public Text scoreKeeper;
  public PickUpShovel shovel;
  List<GameObject> trees;
  List<int> rand = new List<int>();
  void Start()
  {
    trees = new List<GameObject>(GameObject.FindGameObjectsWithTag("Tree"));

    for (int j = 0; j < numberOfTreeMems; j++)
    {
      int randNum = Random.Range(0, trees.Count);
      while (rand.Contains(randNum))
      {
        randNum = Random.Range(0, trees.Count);
      };
      rand.Add(randNum);
    }

    for (int i = 0; i < trees.Count; i++)
    {
      trees[i].tag = "Interactable";
    }

    List<GameObject> chooseTrees = trees;

    for (int k = 0; k < rand.Count; k++)
    {
      chooseTrees[rand[k]].GetComponent<ShakeRandomTree>().hasMemory = true;
    }
  }

  // Update is called once per frame
  void Update()
  {
    scoreKeeper.text = base.score + "/" + (numberOfTreeMems + shovel.numberOfMems);

    if (base.score >= (numberOfTreeMems + shovel.numberOfMems))
    {
      SceneManager.LoadScene(scene);
    }
  }

  public void spawnSpike()
  {
    int spike_type = Random.Range(0, spike.Length);
    int location_type = Random.Range(0, spawnLocations.Length);
    Vector3 location = spawnLocations[location_type].transform.position;
    Debug.Log("Spawning at " + location);
    RespawnCollide spikeObj = Instantiate(spike[spike_type], location, new Quaternion(0, 0, 0, 0)) as RespawnCollide;
    spikeObj.spawnPoint = playerSpawn;
  }
  void LateUpdate()
  {
    fallingObjects = GameObject.FindGameObjectsWithTag("FallingObject").Length;
    if (fallingObjects < maxFallObj)
    {
      spawnSpike();
    }
  }

  

  
}
