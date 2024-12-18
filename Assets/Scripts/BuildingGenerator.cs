using UnityEngine;

public class BuildingGenerator : MonoBehaviour
{
    [SerializeField] GameObject car;  // 車をアタッチ
    [SerializeField] GameObject[] buildings;
    [SerializeField] float buildingWidth; // 建物の横幅
    [SerializeField] float buildingDist;  // 建物間の距離
    [SerializeField] float leftGeneratingPos;  // 左側の建物のx座標
    [SerializeField] float rightGeneratingPos; // 右側の建物のx座標
    [SerializeField] int buildingSetLength; // 片方の列に建物を一度に何個まとめて生成するか

    float _zGeneratingPos;  // 車の位置がここを超えたら新しい道路を作る
    float _allBuildingLength; // 今ある道路の長さの合計

    void Start()
    {
        _zGeneratingPos = 0;
        _allBuildingLength = 6 * (buildingWidth + buildingDist);
    }

    void Update()
    {
        if (car.transform.position.z > _zGeneratingPos)
        {
            for (int i = 0; i < buildingSetLength; i++)
            {
                int randomNumForLeftBuilding = Random.Range(0, buildings.Length);
                int randomNumForRightBuilding = Random.Range(0, buildings.Length);

                Instantiate(buildings[randomNumForLeftBuilding], new Vector3(leftGeneratingPos, -2, _allBuildingLength + i * (buildingWidth + buildingDist)), Quaternion.Euler(0, -90, 0));
                Instantiate(buildings[randomNumForRightBuilding], new Vector3(rightGeneratingPos, -2, _allBuildingLength + i * (buildingWidth + buildingDist)), Quaternion.Euler(0, 90, 0));
            }

            _allBuildingLength += buildingSetLength * (buildingWidth + buildingDist);
            _zGeneratingPos += buildingSetLength * (buildingWidth + buildingDist);
        }

    }
}
