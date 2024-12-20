using UnityEngine;

public class CarPositionCheck: MonoBehaviour
{
    [SerializeField] private GameObject car;
    [SerializeField] private GameObject stopLine;
    private float _relativePos;
    private readonly float _carHeadLength; // length between center of car and head of car

    void Start()
    {
        // this code should attach stop line prefab object
        stopLine = gameObject;
        car = GameObject.FindWithTag("car");
    }

    void Update()
    {
        if (CheckCarPos() < 0)
        {
            GameOverManager.IsGameOver = true;
        }
    }
    
    // call it if the car stops
    public float CheckCarPos()
    {
        _relativePos = stopLine.transform.position.z - car.transform.position.z - _carHeadLength;
        return _relativePos;
    }
}
