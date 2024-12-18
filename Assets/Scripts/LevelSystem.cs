using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public float [,]speedLevel = new float[4,5]{{0,0,0,50,50},{1,50,1000,50,30},{2,70,5000,70,50},{3,100,10000,90,60}};
    //{ゲーム内のレベル, 車の最大速度, レベルアップに必要なスコア, 信号が来る確率, 信号が来る時赤になる確率}(数値は仮)
    [SerializeField]public float maxSpeed;
    [SerializeField] public int currentLevel;
    void Start()
    {

    }

    void Update()
    {
        ScoreCalc scoreCalc;
        GameObject obj = GameObject.Find("ScoreCalculator");
        scoreCalc = obj.GetComponent<ScoreCalc>();

        for(int i =0; i < speedLevel.GetLength(0); i++)//スコアに応じてレベルと速度を代入
        {
            if(speedLevel[i,2] <= scoreCalc.GetCurrentScore() && scoreCalc.GetCurrentScore() < speedLevel[i+1,2])
            {
                currentLevel = (int)speedLevel[i+1,0];
                maxSpeed = speedLevel[i+1,1];
            }
        }

                Debug.Log("レベル" + currentLevel);
                Debug.Log("マックススピード" + maxSpeed);
                Debug.Log("スコア" + scoreCalc.GetCurrentScore());
    }
}
