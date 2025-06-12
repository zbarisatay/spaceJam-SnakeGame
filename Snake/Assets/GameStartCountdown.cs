using System.Collections;
using TMPro;
using UnityEngine;

public class GameStartCountdown : MonoBehaviour
{
    public TMP_Text countdownText; // UI Text referansı
    public float countdownTime = 3f;

    public Snake snakeScript; // Yılan script referansı

    private void Start()
    {
        // Başlangıçta yılan hareket etmesin
        snakeScript.enabled = false;

        // Geri saymayı başlat
        StartCoroutine(CountdownRoutine());
    }

    private IEnumerator CountdownRoutine()
    {
        float currentTime = countdownTime;

        while (currentTime > 0)
        {
            countdownText.text = Mathf.Ceil(currentTime).ToString();
            yield return new WaitForSeconds(1f);
            currentTime--;
        }

        countdownText.text = "Start!"; // İstersen son mesaj

        yield return new WaitForSeconds(1f);

        countdownText.gameObject.SetActive(false);

        // Yılan hareket etmeye başlasın
        snakeScript.enabled = true;
    }
}
