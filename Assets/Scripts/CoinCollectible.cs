using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinCollectible : MonoBehaviour
{
    float score = 0;
    public TextMeshProUGUI stateText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthyText;
    public Button button;
    private int health = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            stateText.text = "Oyunu Kaybettin";
            Time.timeScale = 0;
            button.gameObject.SetActive(true);
        }
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            score += 1;
            scoreText.text = "Skor: " + score.ToString();
            Debug.Log(score);
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
            health -= 1;
            healthyText.text = "Can: " + health.ToString();
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            stateText.text = "OYUNU KAZANDIN";
            Time.timeScale = 0;
            button.gameObject.SetActive(true);
        }
    }
}
