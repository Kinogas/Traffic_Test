using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void Quit()
    {
        // ゲームを終了
        Application.Quit();

        // エディター上で確認用のログを表示（ビルド後には不要）
        Debug.Log("Game Quit Requested");
    }
}
