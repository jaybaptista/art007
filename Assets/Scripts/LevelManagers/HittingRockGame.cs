using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HittingRockGame : ScoreManager
{
  public Text scoreKeeper;
  void Update()
  {
    scoreKeeper.text = base.score + "/3";

    if (base.score >= 3)
    {
      SceneManager.LoadScene("diag_1");
    }
  }
}
