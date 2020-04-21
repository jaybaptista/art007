using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpShovel : Interactable
{
  // Start is called before the first frame update
  public bool triggered = false;
  List<GameObject> rocks;
  int[] rand = new int[3];
  void Start() {
    rocks = new List<GameObject>(GameObject.FindGameObjectsWithTag("Rock"));
      for (int j = 0; j < rand.Length; j++) {
          rand[j] = Random.Range(0, rocks.Count - 1);
      }

    List<GameObject> chooseRocks = rocks;

    for (int k = 0; k < rand.Length; k++)
    {
      chooseRocks[rand[k]].GetComponent<HitRock>().hasMemory = true;
      chooseRocks.Remove(chooseRocks[rand[k]]);
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
