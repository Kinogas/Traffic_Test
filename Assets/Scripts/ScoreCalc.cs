using UnityEngine;

public class ScoreCalc : MonoBehaviour
{
    private GameObject _car;
    private GameObject _stopLine;
    private float _score;
    private float _weight;
    private readonly float _baseScore = 400;
    private Vector3 _prevPos;
    private bool _isStop;
    private float _currentTime = 0.0f;
    private float _prevTime = 0.0f;
    
    void Start()
    {
        _car = GameObject.FindWithTag("car");
        _prevPos = _car.transform.position;
        _isStop = true;
        _weight = - _baseScore / 400;
    }

    public float GetCurrentScore()
    {
        Debug.Log(_score);
        _prevTime = _currentTime;
        return _score;
    }
    
    void Update()
    {
        if(Mathf.Approximately(Time.deltaTime, 0))
            return;
        
        _currentTime += Time.deltaTime;
        if(_currentTime - _prevTime > 2.0f)
            GetCurrentScore();
        
        var deltaCarPos = _car.transform.position.z - _prevPos.z;
        var velocity = _car.GetComponent<Rigidbody>().linearVelocity.magnitude;
        
        _score += deltaCarPos;
        _prevPos = _car.transform.position;

        if (_isStop && velocity > 0.001f)
        {
            _isStop = false;
        }
        else if (!_isStop && velocity < 0.001f)
        {
            _stopLine = GameObject.Find("StopAreaRoad_StopLine");
            if (_stopLine == null)
            {
                Debug.Log("Stop line is not found");
                return;
            }
            _isStop = true;
            var carRelativePos = _stopLine.GetComponent<CarPositionCheck>().CheckCarPos();
            Debug.Log("carRelativePos: "+carRelativePos);
            if (carRelativePos < 0)
            {
                Debug.Log("You passed the stop line!");
                _score = 0;
                // Game over
                return;
            }
            else if (carRelativePos > _baseScore)
            {
                Debug.Log("You stopped too away from the stop line!");
                _score = 0;
                // Game over
                return;
            }
            _score += _baseScore + _weight * carRelativePos * carRelativePos;
        }
    }
}
