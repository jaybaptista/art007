using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FallingApartGame : ScoreManager
{
  // Start is called before the first frame update
  public Text scoreKeeper;

  public int numberOfTreeMems = 3;
  List<GameObject> trees;
  List<int> rand = new List<int>();


  void Start() {
    trees = new List<GameObject>(GameObject.FindGameObjectsWithTag("Tree"));

    for (int j = 0; j < numberOfTreeMems; j++)
    {
      int randNum = Random.Range(0, trees.Count);
      while (rand.Contains(randNum))
      {
        randNum = Random.Range(0, trees.Count);
      };
      rand.Add(randNum);
    }

    for (int i = 0; i < trees.Count; i++)
    {
      trees[i].tag = "Interactable";
    }

    List<GameObject> chooseTrees = trees;

    for (int k = 0; k < rand.Count; k++)
    {
      chooseTrees[rand[k]].GetComponent<ShakeRandomTree>().hasMemory = true;
    }

    

  }
  void Update()
  {
    scoreKeeper.text = base.score + "/3";

    if (base.score >= 3)
    {
      SceneManager.LoadScene("memorychasm");
    }
  }
}
