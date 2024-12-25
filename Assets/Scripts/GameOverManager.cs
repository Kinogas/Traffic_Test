using UnityEngine;
using UnityEngine.Serialization;

public class GameOverManager : MonoBehaviour
{
    public bool isGameOver = false;
    public bool isChicken = false;

    [SerializeField] GameObject chickenText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject retryButton;
    [SerializeField] GameObject titleButton;
    [SerializeField] GameObject scoreBackground;
    [SerializeField] GameObject canvas;
    
    
    void Start()
    {
        chickenText.SetActive(false);
        gameOverText.SetActive(false);
        retryButton.SetActive(false);
        titleButton.SetActive(false);
        scoreBackground.SetActive(false);
        canvas.SetActive(true);
    }

    
    void Update()
    {
        if (isGameOver)
        {
            ShowGameOverObject();
        }
    }

    void ShowGameOverObject()
    {
        if(isChicken)
            chickenText.SetActive(true);
        else
            gameOverText.SetActive(true);
        retryButton.SetActive(true);
        titleButton.SetActive(true);
        canvas.SetActive(false);
        scoreBackground.SetActive(true);
    }

    public void TooChicken()
    {
        isChicken = true;
        isGameOver = true;
    }

    public void BreakRule()
    {
        isGameOver = true;
    }
}
