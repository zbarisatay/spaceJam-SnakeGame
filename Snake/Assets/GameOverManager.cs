using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TMP_Text finalScoreText;

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        finalScoreText.text = "Skorun: " + GameManager.Instance.score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("start");
    }
}
