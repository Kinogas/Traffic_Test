using UnityEngine;

public class CarControllerDemo : MonoBehaviour
{
    private float speed = 0.1f; // 動く速さ（Z軸方向）

    void Update()
    {
        /*// スペースキーが押されている間
        if (Input.GetKey(KeyCode.Space))
        {
            // Z軸正方向に移動
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }*/
        LevelSystem levelSystem;
        GameObject obj = GameObject.Find("LevelSystem");
        levelSystem = obj.GetComponent<LevelSystem>();

        Rigidbody rb = this.GetComponent<Rigidbody> ();  // rigidbodyを取得
        Vector3 force = new Vector3 (0.0f,0.0f,speed);    // 力を設定


        if(rb.linearVelocity.magnitude < levelSystem.maxSpeed)
        {
            rb.AddForce(force);
        }

        Debug.Log(rb.linearVelocity.magnitude);

    }
}
