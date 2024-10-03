using UnityEngine;

public class LineTrigger : MonoBehaviour
{
    // プレイヤーコントローラーの参照
    private PlayerController playerController;

    private void Start()
    {
        // プレイヤーコントローラーを取得
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // プレイヤーのタグを確認
        if (other.CompareTag("Player"))
        {
            // プレイヤーが触れた時の処理
            Debug.Log("プレイヤーがラインに触れました。");

            // プレイヤーの速度を取得して増加させる
            if (playerController != null)
            {
                playerController.playerspeed += 30f; // 速度を増加（5fは任意の増加値）
                Debug.Log("新しいプレイヤー速度: " + playerController.playerspeed);
            }

            // 他の処理をここに追加
        }
    }
}
