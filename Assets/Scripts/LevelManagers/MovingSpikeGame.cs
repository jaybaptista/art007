using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovingSpikeGame : ScoreManager
{
  // Start is called before the first frame update
  public Text scoreKeeper;
  void Update()
  {
    scoreKeeper.text = base.score + "/6";

    if (base.score >= 6)
    {
      SceneManager.LoadScene("diag_2");
    }
  }
}
