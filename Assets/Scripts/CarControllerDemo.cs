using UnityEngine;

public class CarControllerDemo : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // ���������iZ�������j

    void Update()
    {
        // �X�y�[�X�L�[��������Ă����
        if (Input.GetKey(KeyCode.Space))
        {
            // Z���������Ɉړ�
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
