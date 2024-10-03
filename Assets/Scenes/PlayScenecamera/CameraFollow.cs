using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // PlayerオブジェクトのTransform
    public float fixedX = 0f; // 固定するX位置
    public float offsetY = 5f; // プレイヤーからの高さオフセット
    public float distanceZ = -10f; // プレイヤーからのZ距離オフセット

    public GameObject speedEffect; // 速度エフェクトのプレハブ
    public GameObject speedEffect2;
    public float speedThreshold = 15f; // エフェクトを表示する速度の閾値
    public float speedThreshold2 = 50f;
    private bool isSpeedEffectActive = false; // speedEffectが表示されているかどうか
    private bool isSpeedEffect2Active = false; // speedEffect2が表示されているかどうか

    private Vector3 previousPosition; // プレイヤーの前回の位置を記録

    void Start()
    {
        // プレイヤーの初期位置を記録
        previousPosition = player.position;

        // エフェクトを一旦非表示にする
        speedEffect.SetActive(false);
        speedEffect2.SetActive(false);
    }

    void LateUpdate()
    {
        if (player != null) // プレイヤーが設定されているか確認
        {
            // カメラの位置をプレイヤーのZ位置に基づいて更新
            transform.position = new Vector3(fixedX, player.position.y + offsetY, player.position.z + distanceZ);

            // プレイヤーの速度を計算 (フレーム間の移動距離/時間)
            float playerSpeed = (player.position - previousPosition).magnitude / Time.deltaTime;

            // プレイヤーの速度が speedThreshold2 を超えた場合
            if (playerSpeed > speedThreshold2 && !isSpeedEffect2Active)
            {
                speedEffect2.SetActive(true); // エフェクト2を表示
                isSpeedEffect2Active = true;
                speedEffect.SetActive(true); // エフェクト2を表示
                isSpeedEffectActive = true;
            }
            // プレイヤーの速度が speedThreshold2 を下回った場合に speedEffect2 を非表示
            else if (playerSpeed <= speedThreshold2 && isSpeedEffect2Active)
            {
                speedEffect2.SetActive(false); // エフェクト2を非表示
                isSpeedEffect2Active = false;
            }

            // プレイヤーの速度が speedThreshold を超えた場合 (speedEffect2 の閾値未満の場合)
            if (playerSpeed > speedThreshold && playerSpeed <= speedThreshold2 && !isSpeedEffectActive)
            {
                speedEffect.SetActive(true); // エフェクト1を表示
                isSpeedEffectActive = true;
            }
            // プレイヤーの速度が speedThreshold を下回った場合に speedEffect を非表示
            else if (playerSpeed <= speedThreshold && isSpeedEffectActive)
            {
                speedEffect.SetActive(false); // エフェクト1を非表示
                isSpeedEffectActive = false;
            }

            // 現在のプレイヤーの位置を次のフレーム用に保存
            previousPosition = player.position;
        }
    }
}
