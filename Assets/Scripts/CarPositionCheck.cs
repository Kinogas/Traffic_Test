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
        car = GameObject.FindWithTag("car"); // or directly attach in inspector of stop line
    }
    
    // call it if the car stops
    public float CheckCarPos()
    {
        _relativePos = stopLine.transform.position.x - car.transform.position.x - _carHeadLength;
        return _relativePos;
    }
}
