using UnityEngine;

public class CarControllerDemo : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // 動く速さ（Z軸方向）

    void Update()
    {
        // スペースキーが押されている間
        if (Input.GetKey(KeyCode.Space))
        {
            // Z軸正方向に移動
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
