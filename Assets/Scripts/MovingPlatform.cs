using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
  // Start is called before the first frame update

  private Vector3 start;
  private Vector3 delta;
  public GameObject towardObject;

  private Vector3 setpoint;

  public float speed = 10f;
  public float waitTime = 1;
  public bool oscillate = true;

  public bool open = true;

  public bool goBack = false;

  public float currentDistanceToSetPoint;
  public float currentDistanceToStart;
  void Start()
  {
    start = transform.position;
  }

  // Update is called once per frame
  void Update()
  {
    setpoint = towardObject.transform.position;

    if (oscillate) {
      Oscillate();
    } else if (open) {
      Open();
    } else if (!open) {
      Close();
    }
     else {
      Disable();
    }

    transform.position = delta;

    Debug.DrawLine(start, setpoint, Color.yellow);

    currentDistanceToStart = Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(start.x, start.y));

    currentDistanceToSetPoint = Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(towardObject.transform.position.x, towardObject.transform.position.y));

    if (Mathf.Abs(currentDistanceToSetPoint) < 1f)
    {
      StartCoroutine(PlatformGoBack(true));
    }
    else if (Mathf.Abs(currentDistanceToStart) < 1f)
    {
      StartCoroutine(PlatformGoBack(false));
    }

  }

   private IEnumerator PlatformGoBack(bool cond) {
       yield return new WaitForSeconds(waitTime);
       goBack = cond;
   }

  public void Disable() {
    delta = transform.position;
  }

  public void Oscillate() {
    if (goBack)
    {
      Open();
    }
    else
    {
      Close();
    }
  }

  public void Open() {
    delta = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(start.x, start.y), Time.deltaTime * speed);
  }

  public void Close()
  {
    delta = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(towardObject.transform.position.x, towardObject.transform.position.y), Time.deltaTime * speed);
  }

  public void RequestClose() {
    oscillate = false;
    open = false;
  }

  public void RequestOpen() {
    oscillate = false;
    open = true;
  }

  public void RequestOscillate() {
    oscillate = true;
    open = true;
  }

  public void RequestOscillate(bool openCond)
  {
    oscillate = true;
    open = openCond;
  }

}
