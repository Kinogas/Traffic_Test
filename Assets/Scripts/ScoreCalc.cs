using UnityEngine;
using UnityEngine.Serialization;

public class ScoreCalc : MonoBehaviour
{
    private GameObject _car;
    private Rigidbody _carRb;
    private GameObject _stopLine;
    private float _score;
    private float _weight;
    private readonly float _baseScore = 400;
    private Vector3 _prevPos;
    private float _deltaCarPos;
    private bool _isStop;
    private bool _existPrevStopLine;
    [SerializeField] private GameOverManager gameOverManager;
    
    void Start()
    {
        _car = GameObject.FindWithTag("car");
        _carRb = _car.GetComponent<Rigidbody>();
        _prevPos = _car.transform.position;
        _isStop = true;
        _existPrevStopLine = false;
        _weight = - _baseScore / 400;
    }

    // call it if you need score
    public float GetCurrentScore()
    {
        return _score;
    }
    
    void Update()
    {
        if(gameOverManager.isGameOver) return;
        
        _deltaCarPos = _car.transform.position.z - _prevPos.z;
        _score += _deltaCarPos;
        _prevPos = _car.transform.position;
        if (_isStop && _deltaCarPos > 0.001f) // just start moving
        {
            _isStop = false;
            return;
        }
        
        CalcTrafficLightScore();
    }

    void CalcTrafficLightScore()
    {
        _stopLine = GameObject.Find("StopAreaRoad_StopLine");
        if (_stopLine == null)
        {
            _stopLine = null;
            if (CarJustStopped()) // stop line doesn't exist, but car stops just now
            {
                Debug.Log("You stopped where is nothing");
                gameOverManager.TooChicken();
            }
            
            return;
        }

        var carPositionCheck = _stopLine.GetComponent<CarPositionCheck>();
        var carRelativePos = carPositionCheck.CheckCarPos();
        
        if (carPositionCheck.isPrevStopLine) {
            if (carPositionCheck.CheckCarPos() < 0 && CarJustStopped())  // 前回の停止線が後ろに残っているかつroad_normalでの停止
            {
                Debug.Log("You stopped where is nothing");
                gameOverManager.TooChicken();
            }
            return;  // stop line exists and it is prev stop line
        }
        
        if (carRelativePos < 0)
        {
            Debug.Log("You passed the stop line!");
            gameOverManager.BreakRule();
            return;
        }
        
        if (CarJustStopped())
        {
            _isStop = true;
            carPositionCheck.isPrevStopLine = true;
            if (carRelativePos > 20)
            {
                Debug.Log("You stopped too away from the stop line!");
                gameOverManager.TooChicken();
                return;
            }
            _score += _baseScore + _weight * carRelativePos * carRelativePos;
        }
        
    }

    bool CarJustStopped()
    {
        return !_isStop && _carRb.linearVelocity.magnitude < 0.001f;
    }
}
