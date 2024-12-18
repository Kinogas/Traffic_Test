using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public bool isGameOver = false;

    [SerializeField] GameObject chickenText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject retryButton;
    [SerializeField] GameObject titleButton;
    
    
    void Start()
    {
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
        gameOverText.SetActive(true);
        retryButton.SetActive(true);
        titleButton.SetActive(true);
    }
}
