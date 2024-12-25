using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject speed_object = null;
    public GameObject level_object = null;
    public GameObject score_object_1 = null;
    //public GameObject score_object_2 = null;
    //public GameObject highScore_object = null;

    public int highScore;
    public int myScore;
    private GameOverManager gameOverManager;
    void Start()
    {

    }
    void Update()
    {
        CarController carController;
        GameObject car = GameObject.FindWithTag("car");
        carController = car.GetComponent<CarController>();

        LevelSystem levelSystem;
        GameObject level = GameObject.Find("LevelSystem");
        levelSystem = level.GetComponent<LevelSystem>();

        ScoreCalc scoreCalc;
        GameObject score = GameObject.Find("ScoreCalculator");
        scoreCalc = score.GetComponent<ScoreCalc>();


        Text speed_text = speed_object.GetComponent<Text>();
        speed_text.text = "スピード：" + (int)carController.currentSpeed;

        Text level_text = level_object.GetComponent<Text>();
        level_text.text = " レ ベ ル ：" + (int)levelSystem.currentLevel;

        Text score_text_1 = score_object_1.GetComponent<Text>();
        score_text_1.text = " ス コ ア ：" + (int)scoreCalc.GetCurrentScore();

        /*Text score_text_2 = score_object_2.GetComponent<Text>();
        score_text_2.text = " ス コ ア ：" + (int)scoreCalc.GetCurrentScore();*/

        

        /*if (gameOverManager.isGameOver)
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
            Debug.Log("ハイスコア" + highScore);
        }*/
    }
}
