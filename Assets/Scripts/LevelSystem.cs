using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    
    private float [,]speedLevel = new float[4,2]{{0,0},{1,50},{2,60},{3,80}};//{ゲーム内のレベル,その速度}
    public float maxSpeed;
    public int currentLevel;
    void Start()
    {
        
    }

    void Update()
    {

        ScoreCalc scoreCalc;
        GameObject obj = GameObject.Find("ScoreCalc");
        scoreCalc = obj.GetComponent<LevelSystem>();

        for(int i =0; i < speedLevel.Length; i++)//maxSpeedに速度を代入
        {
            if(speedLevel[i,0] == i)
            {
                maxSpeed = speedLevel[i,1];
            }
        }
    }
}
