using UnityEngine;
using UnityEngine.Serialization;

public class ScoreCalc : MonoBehaviour
{
    private GameObject _car;
    private GameObject _stopLine;
    private float _score;
    private float _weight;
    private readonly float _baseScore = 400;
    private Vector3 _prevPos;
    private bool _isStop;
    
    void Start()
    {
        _car = GameObject.FindWithTag("car");
        _prevPos = _car.transform.position;
        _isStop = true;
        _weight = - _baseScore / 400;
    }

    // call it if you need score
    public float GetCurrentScore()
    {
        return _score;
    }
    
    void Update()
    {
        if(Mathf.Approximately(Time.deltaTime, 0))
            return;
        
        var deltaCarPos = _car.transform.position.z - _prevPos.z;
        var velocity = _car.GetComponent<Rigidbody>().linearVelocity.magnitude;
        
        _score += deltaCarPos;
        _prevPos = _car.transform.position;

        if (_isStop && velocity > 0.001f)  // stopping -> move
        {
            _isStop = false;
        }
        else if (!_isStop && velocity < 0.001f)  // moving -> stop
        {
            _stopLine = GameObject.Find("StopAreaRoad_StopLine");
            if (_stopLine == null)
            {
                Debug.Log("Stop line is not found");
                Debug.Log("You stopped where you don't have to stop!");
                _score = 0;
                GameOverManager.IsChicken = true;
                GameOverManager.IsGameOver = true;
                return;
            }
            _isStop = true;
            var carRelativePos = _stopLine.GetComponent<CarPositionCheck>().CheckCarPos();
            Debug.Log("carRelativePos: "+carRelativePos);
            if (carRelativePos < 0)
            {
                Debug.Log("You passed the stop line!");
                _score = 0;
                GameOverManager.IsGameOver = true;
                return;
            }
            else if (carRelativePos > 20)
            {
                Debug.Log("You stopped too away from the stop line!");
                _score = 0;
                GameOverManager.IsChicken = true;
                GameOverManager.IsGameOver = true;
                return;
            }
            _score += _baseScore + _weight * carRelativePos * carRelativePos;
        }
    }
}
