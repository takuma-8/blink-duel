using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Player�I�u�W�F�N�g��Transform
    public float fixedX = 0f; // �Œ肷��X�ʒu
    public float offsetY = 5f; // �v���C���[����̍����I�t�Z�b�g
    public float distanceZ = -10f; // �v���C���[�����Z�����I�t�Z�b�g

    public GameObject speedEffect; // ���x�G�t�F�N�g�̃v���n�u
    public GameObject speedEffect2;
    public float speedThreshold = 15f; // �G�t�F�N�g��\�����鑬�x��臒l
    public float speedThreshold2 = 50f;
    private bool isSpeedEffectActive = false; // speedEffect���\������Ă��邩�ǂ���
    private bool isSpeedEffect2Active = false; // speedEffect2���\������Ă��邩�ǂ���

    private Vector3 previousPosition; // �v���C���[�̑O��̈ʒu���L�^

    void Start()
    {
        // �v���C���[�̏����ʒu���L�^
        previousPosition = player.position;

        // �G�t�F�N�g����U��\���ɂ���
        speedEffect.SetActive(false);
        speedEffect2.SetActive(false);
    }

    void LateUpdate()
    {
        if (player != null) // �v���C���[���ݒ肳��Ă��邩�m�F
        {
            // �J�����̈ʒu���v���C���[��Z�ʒu�Ɋ�Â��čX�V
            transform.position = new Vector3(fixedX, player.position.y + offsetY, player.position.z + distanceZ);

            // �v���C���[�̑��x���v�Z (�t���[���Ԃ̈ړ�����/����)
            float playerSpeed = (player.position - previousPosition).magnitude / Time.deltaTime;

            // �v���C���[�̑��x�� speedThreshold2 �𒴂����ꍇ
            if (playerSpeed > speedThreshold2 && !isSpeedEffect2Active)
            {
                speedEffect2.SetActive(true); // �G�t�F�N�g2��\��
                isSpeedEffect2Active = true;
                speedEffect.SetActive(true); // �G�t�F�N�g2��\��
                isSpeedEffectActive = true;
            }
            // �v���C���[�̑��x�� speedThreshold2 ����������ꍇ�� speedEffect2 ���\��
            else if (playerSpeed <= speedThreshold2 && isSpeedEffect2Active)
            {
                speedEffect2.SetActive(false); // �G�t�F�N�g2���\��
                isSpeedEffect2Active = false;
            }

            // �v���C���[�̑��x�� speedThreshold �𒴂����ꍇ (speedEffect2 ��臒l�����̏ꍇ)
            if (playerSpeed > speedThreshold && playerSpeed <= speedThreshold2 && !isSpeedEffectActive)
            {
                speedEffect.SetActive(true); // �G�t�F�N�g1��\��
                isSpeedEffectActive = true;
            }
            // �v���C���[�̑��x�� speedThreshold ����������ꍇ�� speedEffect ���\��
            else if (playerSpeed <= speedThreshold && isSpeedEffectActive)
            {
                speedEffect.SetActive(false); // �G�t�F�N�g1���\��
                isSpeedEffectActive = false;
            }

            // ���݂̃v���C���[�̈ʒu�����̃t���[���p�ɕۑ�
            previousPosition = player.position;
        }
    }
}
