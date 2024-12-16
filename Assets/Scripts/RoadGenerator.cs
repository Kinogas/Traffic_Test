using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField] GameObject car;  //車をアタッチ
    [SerializeField] float roadNormalLength;  // 何もない道路の長さ
    [SerializeField] float roadWithCrosswalkLength;  // 横断歩道のある道路の長さ

    [SerializeField] int genetatingTrafficLightinterval; // 信号機が多くても何道路に1回生成されるか
    int _generatingCount = 0;

    // 何もない道路を生成する確率は ( 100 - persentOfGeneratingCrosswalk ) [%]
    [SerializeField] int persentOfGeneratingCrosswalk; // 横断歩道のある道路を生成するパーセント(最大100)

    // 信号機が青の確率は ( 100 - PersentOfRedTrafficLight ) [%]
    [SerializeField] int PersentOfRedTrafficLight; // 信号機が赤信号のパーセント(最大100)

    [SerializeField] GameObject roadNormal;
    [SerializeField] GameObject roadStopArea;
    [SerializeField] GameObject roadZebra;

    float _roadGeneratingPosition;  // 車の位置がここを超えたら新しい道路を作る
    float _allRoadLength; // 今ある道路の長さの合計

    void Start()
    {
        _roadGeneratingPosition = 0;
        _allRoadLength = 2 * roadNormalLength;
    }

    void Update()
    {

        LevelSystem levelSystem;
        GameObject obj = GameObject.Find("LevelSystem");
        levelSystem = obj.GetComponent<LevelSystem>();

        for(int i =0; i < levelSystem.speedLevel.GetLength(0); i++)//レベルに応じて信号の確率を変更
        {
            if(levelSystem.currentLevel == i)
            {
                persentOfGeneratingCrosswalk = (int)levelSystem.speedLevel[i,3];
                PersentOfRedTrafficLight = (int)levelSystem.speedLevel[i,4];
            }
        }

        if (car.transform.position.z > _roadGeneratingPosition)
        {
            int randomNumForCrossWalk = Random.Range(0, 100); // 横断歩道のある道路を生成するかどうかのための乱数
            if (randomNumForCrossWalk < persentOfGeneratingCrosswalk && _generatingCount == 0)
            {
                // 次に道路を生成する場所を新しく設定する
                _roadGeneratingPosition += roadWithCrosswalkLength;

                int randomNumForTrafficLight = Random.Range(0, 100); // 信号を赤にするかどうかのための乱数
                if (randomNumForTrafficLight < PersentOfRedTrafficLight)
                {
                    // 今ある道路の先に赤信号付き道路を生成する
                    Instantiate(roadStopArea, new Vector3(0, 0, _allRoadLength), Quaternion.Euler(0, 180, 0));
                }
                else
                {
                    // 今ある道路の先に青信号付き道路を生成する
                    Instantiate(roadZebra, new Vector3(0, 0, _allRoadLength), Quaternion.Euler(0, 180, 0));
                }

                _allRoadLength += roadWithCrosswalkLength;
                _generatingCount = genetatingTrafficLightinterval - 1;
            }
            else
            {
                // 次に道路を生成する場所を新しく設定する
                _roadGeneratingPosition += roadNormalLength;

                // 今ある道路の先に何もない道路を生成する
                Instantiate(roadNormal, new Vector3(0, 0, _allRoadLength),Quaternion.Euler(0, 180, 0));

                _allRoadLength += roadNormalLength;

                if (_generatingCount > 0)
                    _generatingCount--;
            }
        }
    }
}
