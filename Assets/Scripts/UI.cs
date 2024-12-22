using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject speed_object = null;
    public GameObject level_object = null;
    public GameObject score_object = null;
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
        level_text.text = "レベル：" + (int)levelSystem.currentLevel;

        Text score_text = score_object.GetComponent<Text>();
        score_text.text = "スコア：" + (int)scoreCalc.GetCurrentScore();
    }
}
