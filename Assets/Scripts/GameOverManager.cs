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
    
    
    void Start()
    {
        chickenText.SetActive(false);
        gameOverText.SetActive(false);
        retryButton.SetActive(false);
        titleButton.SetActive(false);
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
