using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro_LogoFadeIn : MonoBehaviour
{
    Animator anim;
    public Text logoText;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (logoText.color.a == 1)
        {
            anim.SetBool("isLogoDone", true);


        }
        else
        {
            anim.SetBool("isLogoDone", false);
        }

        if (GetComponent<Text>().color.a == 1)
        {
            SceneManager.LoadScene("titleCard");
        }
    }
}