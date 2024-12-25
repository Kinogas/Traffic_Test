using System.Collections;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.Serialization;
using TMPro;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    private float speed = 10f; // 動く速さ（Z軸方向）
    private bool IsBrake = false;//ブレーキボタンが押されたかどうか
    public float currentSpeed;
    [SerializeField] private GameOverManager gameOverManager;  // GameOverManagerからゲームオーバーかどうかを教えてもらう

    public GameObject highScore_object = null;
    public GameObject score_object_2 = null;

    public int highScore;
    public int myScore;
    public bool IsBreak()
    {
        return isBreak;
    }

    void Update()
    {
        LevelSystem levelSystem;
        GameObject obj = GameObject.Find("LevelSystem");
        levelSystem = obj.GetComponent<LevelSystem>();

        ScoreCalc scoreCalc;
        GameObject score = GameObject.Find("ScoreCalculator");
        scoreCalc = score.GetComponent<ScoreCalc>();

        Rigidbody rb = this.GetComponent<Rigidbody> ();  // rigidbodyを取得
        Vector3 force = new Vector3 (0.0f,0.0f,speed);    // 力を設定

        currentSpeed = rb.linearVelocity.magnitude;

        if (!gameOverManager.isGameOver)  // scoreCalcの_isGameoverがfalse、つまりゲームオーバーでなければ車を動かす
        {

            if (Input.GetKeyDown(KeyCode.Space))//スペース押したら減速する
            {
                isBreak = true;
            }

            if(isBreak == true)
            {
                if (rb.linearVelocity.z > 0)
                {
                    rb.AddForce(-force * 4);
                }
                else
                {
                    rb.linearVelocity = Vector3.zero;
                    StartCoroutine(ReStartCountDown());
                }
            }
            else if (rb.linearVelocity.magnitude < levelSystem.maxSpeed)//車を最大速度まで加速する
            {
                rb.AddForce(force);
            }

            Debug.Log("今の速さ" + rb.linearVelocity.magnitude);
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
        }

        if (gameOverManager.isGameOver)
        {
            myScore = (int)scoreCalc.GetCurrentScore();
            highScore = PlayerPrefs.GetInt("SCORE", 0);
            if (highScore < myScore)  //ハイスコアを超えた場合に更新
            {
            highScore = myScore;

        　　　//"SCORE"をキーとして、ハイスコアを保存
            PlayerPrefs.SetInt("SCORE", highScore);
            PlayerPrefs.Save();//ディスクへの書き込み
            }
            Text highScore_text = highScore_object.GetComponent<Text>();
            highScore_text.text = "ハイスコア：" + highScore;
            Text score_text_2 = score_object_2.GetComponent<Text>();
            score_text_2.text = " ス コ ア ：" + (int)scoreCalc.GetCurrentScore();
            //Debug.Log("ハイスコア" + highScore);
        }

    }

    IEnumerator ReStartCountDown()
    {
        yield return new WaitForSeconds(2);
        isBreak = false;
    }
}
