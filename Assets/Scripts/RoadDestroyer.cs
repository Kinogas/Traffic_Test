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
        // ���H���\���ɎԂ̌��ɂȂ����瓹�H������
        if (car.transform.position.z - this.transform.position.z > roadLength )
        {
            Destroy(this.gameObject);
        }
    }
}
