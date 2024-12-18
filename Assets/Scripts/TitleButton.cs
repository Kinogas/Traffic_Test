using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    public void OnClicked()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
