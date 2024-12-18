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
        // “¹˜H‚ª\•ª‚ÉŽÔ‚ÌŒã‚ë‚É‚È‚Á‚½‚ç“¹˜H‚ðÁ‚·
        if (car.transform.position.z - this.transform.position.z > destDis)
        {
            Destroy(this.gameObject);
        }
    }
}
