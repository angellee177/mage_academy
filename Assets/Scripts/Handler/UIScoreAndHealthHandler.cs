using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreAndHealthHandler : MonoBehaviour
{  
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] HealthHandler playerHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreManagerHandler scoreKeeper;

    void Start()
    {
        scoreKeeper = FindFirstObjectByType<ScoreManagerHandler>();
        healthSlider.maxValue =  playerHealth.GetHealth();
    }

    void Update()
    {
        scoreText.text = scoreKeeper.GetScore().ToString("00000000000");
        healthSlider.value = playerHealth.GetHealth();
    }
}
