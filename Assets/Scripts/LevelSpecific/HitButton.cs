using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitButton : Interactable
{
  public bool triggered = false;
  public MovingPlatform[] platforms;
  public bool triggerOscillate = false;
  public bool triggerOpen = false;
  public bool triggerClose = false;
  public Sprite triggerSprite;
  public Sprite disableSprite;

  public override void InProximity()
  {
    base.UI(triggered);
  }
  public override void InteractEvents()
  {
    triggered = true;
    Toggle();
  }

  private void Toggle()
  {

    if (triggered) {
        gameObject.GetComponent<SpriteRenderer>().sprite = triggerSprite;
    } else if (!triggered) {
      gameObject.GetComponent<SpriteRenderer>().sprite = disableSprite;
    }

    if (triggerOscillate) {
      for (int i = 0; i < platforms.Length; i++)
      {
        platforms[i].RequestOscillate();
      }
    } else if (triggerOpen) {
      for (int i = 0; i < platforms.Length; i++)
      {
        platforms[i].RequestOpen();
      }
    } else if (triggerClose) {
      for (int i = 0; i < platforms.Length; i++)
      {
        platforms[i].RequestClose();
      }
    }
  }


}
