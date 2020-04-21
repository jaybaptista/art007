using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeTree : Interactable
{

    public GameObject photograph;
    public bool triggered = false;

    public override void InProximity()
    {
        base.UI(triggered);
    }

    public override void InteractEvents()
    {
        if (!triggered)
        {
            photograph.GetComponent<Interactable>().enabled = true;
            photograph.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            triggered = true;
        }
    }
}
