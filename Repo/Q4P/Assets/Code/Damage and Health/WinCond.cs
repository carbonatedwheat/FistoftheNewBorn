﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class WinCond : MonoBehaviour
{
    public TextMesh Scoretxt;
    public int StartingScore, WinCondition, Score;
    // Start is called before the first frame update
    void Start()
    {
        Score = StartingScore;
    }
    // Update is called once per frame
    void Update()
    {

        Scoretxt.text = "Score: " + Score;
        if(Score >= WinCondition)
        {
            SceneManager.LoadScene("Victory Screen");
            //gameObject.SetActive(false);
        }
    }
}
