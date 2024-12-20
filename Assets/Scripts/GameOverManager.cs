using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public static bool IsGameOver = false;
    public static bool IsChicken = false;

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
        if (IsGameOver)
        {
            ShowGameOverObject();
        }
    }

    void ShowGameOverObject()
    {
        if(IsChicken)
            chickenText.SetActive(true);
        else
            gameOverText.SetActive(true);
        retryButton.SetActive(true);
        titleButton.SetActive(true);
    }
}
