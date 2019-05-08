using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionAfterTime : MonoBehaviour
{
    public float delay = 10;
    public string NewLevel = "ActualLevel";
    void Start()
    {
        StartCoroutine(LoadLevelAfterDelay(delay)); 
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(NewLevel);

    }
   
}
