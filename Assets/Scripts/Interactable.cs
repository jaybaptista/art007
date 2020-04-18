using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Interactable : MonoBehaviour
{
    public GameObject interactUI;

    public string message;
    public Sprite image;

    public Text UIText;
    public Image UISprite;

    // Start is called before the first frame update
    public virtual void Interact()
    {
        Debug.Log("Interacting...");
        InteractEvents();
        interactUI.SetActive(false);
    }

    public virtual void UI(bool cond)
    {
        UISprite.sprite = image;
        UIText.text = message;

        if (!cond) {
            //Debug.Log(gameObject.name + " Enabling UI");
            interactUI.SetActive(true);
        } else
        {
            //Debug.Log(gameObject.name + "Disabling UI");
            interactUI.SetActive(false);
        }
    }

    public virtual void InProximity()
    {
        Debug.Log(gameObject.name + " Proximal distance");
    }

    // Update is called once per frame
    void Update()
    {
        // Nothing here!
    }

    public virtual void InteractEvents()
    {
        // nothing yet;
        Debug.Log("Override events!");
    }
}
