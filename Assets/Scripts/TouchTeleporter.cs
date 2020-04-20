using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TouchTeleporter : Interactable
{
    public bool triggered = false;
    public string scene;

    public override void InProximity()
    {
        //base.InProximity();
        base.UI(triggered);
    }

    public override void InteractEvents()
    {
        if (!triggered)
        {
            Debug.Log("Teleporting...");
            SceneManager.LoadScene(scene);
        }
        
    }
}
