using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpShovel : Interactable
{
  // Start is called before the first frame update
  public bool triggered = false;
  public int numberOfMems = 3;
  List<GameObject> rocks;
  List<int> rand = new List<int>();
  void Start() {
    rocks = new List<GameObject>(GameObject.FindGameObjectsWithTag("Rock"));
    for (int j = 0; j < numberOfMems; j++) {
        int randNum = Random.Range(0, rocks.Count);
        while (rand.Contains(randNum)) {
        randNum = Random.Range(0, rocks.Count);
        };
        rand.Add(randNum);
    }
    
    List<GameObject> chooseRocks = rocks;

    for (int k = 0; k < rand.Count; k++)
    {
      chooseRocks[rand[k]].GetComponent<HitRock>().hasMemory = true;
    }
  }

  public override void InProximity()
  {
    base.UI(triggered);
  }

  public override void InteractEvents()
  {
    rocks = new List<GameObject>(GameObject.FindGameObjectsWithTag("Rock"));
    for (int i = 0; i < rocks.Count; i++) {
        rocks[i].tag = "Interactable";
    }
    
    Destroy(gameObject);
  }
}
