using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    private float [,]speedLevel = new float[4,3]{{0,0,0},{1,50,1000},{2,60,5000},{3,80,10000}};//{ゲーム内のレベル,車の最大速度,レベルアップに必要なスコア}
    public float maxSpeed;
    public int currentLevel;
    void Start()
    {

    }

    void Update()
    {
        ScoreCalc scoreCalc;
        GameObject obj = GameObject.Find("ScoreCalculator");
        scoreCalc = obj.GetComponent<ScoreCalc>();

        /*if(0 <= scoreCalc.GetCurrentScore() && scoreCalc.GetCurrentScore() < speedLevel[1,2])
        {
            currentLevel = (int)speedLevel[1,0];
            maxSpeed = speedLevel[1,1];
        }

        if(speedLevel[1,2] <= scoreCalc.GetCurrentScore() && scoreCalc.GetCurrentScore() < speedLevel[2,2])
        {
            currentLevel = (int)speedLevel[2,0];
        }

        if(5000 <= scoreCalc.GetCurrentScore() && scoreCalc.GetCurrentScore() < 10000)
        {
            currentLevel = 3;
        }*/


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
                //Debug.Log();
    }
}
