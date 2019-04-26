using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinCond : MonoBehaviour
{
    public int StartingScore, WinCondition, Score;
    // Start is called before the first frame update
    void Start()
    {
        Score = StartingScore;
    }
    // Update is called once per frame
    void Update()
    {
        if(Score >= WinCondition)
        {
            SceneManager.LoadScene("Victory Screen");
            //gameObject.SetActive(false);
        }
    }
}
