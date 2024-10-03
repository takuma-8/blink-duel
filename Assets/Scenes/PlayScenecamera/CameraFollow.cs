using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // PlayerオブジェクトのTransform
    public float fixedX = 0f; // 固定するX位置
    public float offsetY = 5f; // プレイヤーからの高さオフセット
    public float distanceZ = -10f; // プレイヤーからのZ距離オフセット

    public GameObject speedEffect; // 速度エフェクトのプレハブ
    public float speedThreshold = 15f; // エフェクトを表示する速度の閾値
    private bool isEffectActive = false; // エフェクトが表示されているかどうか

    private Vector3 previousPosition; // プレイヤーの前回の位置を記録

    void Start()
    {
        // プレイヤーの初期位置を記録
        previousPosition = player.position;

        // エフェクトを一旦非表示にする
        speedEffect.SetActive(false);
    }

    void LateUpdate()
    {
        if (player != null) // プレイヤーが設定されているか確認
        {
            // カメラの位置をプレイヤーのZ位置に基づいて更新
            transform.position = new Vector3(fixedX, player.position.y + offsetY, player.position.z + distanceZ);

            // プレイヤーの速度を計算 (フレーム間の移動距離/時間)
            float playerSpeed = (player.position - previousPosition).magnitude / Time.deltaTime;

            // スピードが30fを超えた場合にエフェクトを有効化
            if (playerSpeed > speedThreshold && !isEffectActive)
            {
                speedEffect.SetActive(true); // エフェクトを表示
                isEffectActive = true;
            }
            // スピードが30f以下になったらエフェクトを非表示にする
            else if (playerSpeed <= speedThreshold && isEffectActive)
            {
                speedEffect.SetActive(false); // エフェクトを非表示
                isEffectActive = false;
            }

            // 現在のプレイヤーの位置を次のフレーム用に保存
            previousPosition = player.position;
        }
    }
}
