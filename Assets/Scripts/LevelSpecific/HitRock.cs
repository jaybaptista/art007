using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitRock : Interactable
{
  // Start is called before the first frame update
  // Update is called once per frame

  public bool triggered = false;
  public bool hasMemory = false;
  public GameObject memory;
  public override void InProximity()
  {
    base.UI(triggered);
  }
  public override void InteractEvents()
  {
      if (hasMemory) { Instantiate(memory, transform.position, new Quaternion(0,0,0,0)); }
      
      Destroy(gameObject);
  }
}
