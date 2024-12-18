using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public void OnClicked()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
