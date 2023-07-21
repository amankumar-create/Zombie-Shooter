using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameOverHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] TextMeshProUGUI gameOverText;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameOverCanvas.enabled = false;
    }
    public void DisplayGameOverCanvas(string gameOverText)
    {
        StartCoroutine(ShowGameOver(gameOverText));
    }

    IEnumerator ShowGameOver(string gameOverText)
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameOverCanvas.enabled = true;
        this.gameOverText.text = gameOverText;
    }
}
