using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    // private�ϐ���Inspector�E�B���h�E�ɕ\�����邽�߂�"[SerializeField]"��t����
    // ���������̌���
    [SerializeField]
    private float horizonDamping;
    // ���������̌���
    [SerializeField]
    private float verticalDamping;
    // ���s���i�}�E�X�z�C�[����]�l�j�̏�Z
    [SerializeField]
    private float depthMultiply;
    // �}�E�X�J�[�\�����W
    private Vector3 mousePos;
    // �X�N���[�����W�����[���h���W�ɕϊ������ʒu���W
    private Vector3 screenToWorldPointPosition;

    void Update()
    {
        // �I�u�W�F�N�g��X���W��ϐ��Ɋi�[
        float currentWidth = transform.position.x;
        // �I�u�W�F�N�g��Y���W��ϐ��Ɋi�[
        float currentHeight = transform.position.y;
        // �I�u�W�F�N�g��Z���W��ϐ��Ɋi�[
        float currentDepth = transform.position.z;
        // �}�E�X�z�C�[����]�l��ϐ��Ɋi�[
        float mouseScroll = Input.GetAxis("Mouse ScrollWheel");
        // �}�E�X���W��ϐ��Ɋi�[
        mousePos = Input.mousePosition;
        //�}�E�X�J�[�\�����W�ɃJ������Z���W�����i�J������Z���W��-�̏ꍇ��=-�ɂ���j
        mousePos.z = -Camera.main.transform.position.z;
        // �}�E�X�J�[�\�����W���X�N���[�����W���烏�[���h���W�ɕϊ�����
        screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(mousePos);
        //�I�u�W�F�N�g�̍��W�Ƀ}�E�X�J�[�\��X���W�̌����l��������i�}�E�X�J�[�\���l�ɏ��X�ɋ߂Â��j
        currentWidth += (screenToWorldPointPosition.x - currentWidth) * horizonDamping;
        //�I�u�W�F�N�g�̍��W�Ƀ}�E�X�J�[�\��Y���W�̌����l��������i�}�E�X�J�[�\���l�ɏ��X�ɋ߂Â��j
        currentHeight += (screenToWorldPointPosition.y - currentHeight) * verticalDamping;
        //�I�u�W�F�N�g���W�Ƀ}�E�X�z�C�[����]�l��������
        currentDepth += (mouseScroll * depthMultiply);
        //�I�u�W�F�N�g�̍��W�ɕϐ��̒l����
        transform.position = new Vector3(currentWidth, currentHeight, currentDepth);
    }
}