using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }
    public void ReloadGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Debug.Log("Application Quit");
        Application.Quit();
    }
}
