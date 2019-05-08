using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    private void OnMouseDown()
    {
        SceneManager.LoadScene("StarryNight");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
