using UnityEngine;

public class BuildingDestroyer : MonoBehaviour
{
    [SerializeField] float destDis;

    GameObject car;

    void Start()
    {
        car = GameObject.FindWithTag("car");
    }

    void Update()
    {
        // ���H���\���ɎԂ̌��ɂȂ����瓹�H������
        if (car.transform.position.z - this.transform.position.z > destDis)
        {
            Destroy(this.gameObject);
        }
    }
}
