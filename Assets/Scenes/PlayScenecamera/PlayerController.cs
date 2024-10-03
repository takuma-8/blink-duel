using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float playerspeed = 10f;
    void Update()
    {

        Vector3 position = transform.position;

        position.z += playerspeed * Time.deltaTime;
        // Aキーが押されていると左に移動
        if (Input.GetKey(KeyCode.A))
        {
            position.x -= 5f * Time.deltaTime; // 左に移動
        }
        // Dキーが押されていると右に移動
        if (Input.GetKey(KeyCode.D))
        {
            position.x += 5f * Time.deltaTime; // 右に移動
        }
            

        // 新しい位置を設定
        transform.position = position;
    }
}


