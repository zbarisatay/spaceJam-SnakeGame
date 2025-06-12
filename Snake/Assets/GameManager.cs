using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public TMP_Text scoreText;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Yeni sahnede scoreText’i bul ve güncelle
        scoreText = GameObject.Find("ScoreText")?.GetComponent<TMP_Text>();

        UpdateScoreUI();
    }

    private void Awake()
    {
        // Singleton pattern (tek bir GameManager olsun)
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // İstersen sahneler arası kaybolmasın
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
