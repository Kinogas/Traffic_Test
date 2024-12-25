using UnityEngine;
using UnityEngine.InputSystem.XR;

public class TrafficLightManager : MonoBehaviour
{
    [SerializeField] GameObject trafficLightGreen;
    [SerializeField] GameObject trafficLightRed;
    GameObject suv;
    CarController carController;

    bool isStoped = false;
    bool isBreak = false;
 
    void Start()
    {
        suv = GameObject.Find("suv");
        carController = suv.GetComponent<CarController>();
    }
    void Update()
    {
        isBreak = carController.IsBrake();

        if (isBreak && !isStoped)
            isStoped = true;

        if (!isBreak && isStoped)
        {
            trafficLightGreen.SetActive(true);
            trafficLightRed.SetActive(false);

            isStoped = false;
        }
    }
}
