using UnityEngine;

public class RoadDestroyer : MonoBehaviour
{
    [SerializeField] float roadLength;

    GameObject car;

    void Start()
    {
        car = GameObject.FindWithTag("car");
    }

    void Update()
    {
        // 道路が十分に車の後ろになったら道路を消す
        if (car.transform.position.z - this.transform.position.z > roadLength )
        {
            Destroy(this.gameObject);
        }
    }
}
