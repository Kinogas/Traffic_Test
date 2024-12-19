using System.Collections;
using UnityEditor;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float speed = 2f; // 動く速さ（Z軸方向）
    private bool IsBrake = false;//ブレーキボタンが押されたかどうか

    [SerializeField] private ScoreCalc scoreCalc;  // scoreCalcからゲームオーバーかどうかを教えてもらう

    void Update()
    {
        LevelSystem levelSystem;
        GameObject obj = GameObject.Find("LevelSystem");
        levelSystem = obj.GetComponent<LevelSystem>();

        Rigidbody rb = this.GetComponent<Rigidbody> ();  // rigidbodyを取得
        Vector3 force = new Vector3 (0.0f,0.0f,speed);    // 力を設定

        if (!scoreCalc.IsGameover)  // scoreCalcの_isGameoverがfalse、つまりゲームオーバーでなければ車を動かす
        {

            if (Input.GetKeyDown(KeyCode.Space))//スペース押したら減速する
            {
                IsBrake = true;
            }

            if(IsBrake == true)
            {
                if (rb.linearVelocity.z > 0)
                {
                    rb.AddForce(-force * 3);
                }
                else
                {
                    rb.linearVelocity = Vector3.zero;
                    StartCoroutine(ReStartCountDown());
                }
            }
            else if (rb.linearVelocity.magnitude < levelSystem.maxSpeed)//車を最大速度まで加速する
            {
                rb.AddForce(force);
            }

            Debug.Log("今の速さ" + rb.linearVelocity.magnitude);
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
        }

    }

    IEnumerator ReStartCountDown()
    {
        yield return new WaitForSeconds(3);
        IsBrake = false;
    }
}
