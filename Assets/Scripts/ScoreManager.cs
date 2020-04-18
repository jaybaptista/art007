using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update

    public int score = 0;
    // Update is called once per frame
    public virtual void resetScore() {
        Debug.Log("Resetting score...");
        score = 0;
    }

    public virtual void Iterate() {
    Debug.Log("Adding score...");
    score += 1;
    }

    public virtual void Subtract() {
    Debug.Log("Subtracting score...");
    score -= 1;
    }
}
