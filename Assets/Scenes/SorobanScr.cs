using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems; // �ǉ�
using UnityEngine;

public class SorobanScr : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool _isPushed = false; // �}�E�X��������Ă��邩������Ă��Ȃ���
    //private Vector3 _nowMousePosi; // ���݂̃}�E�X�̃��[���h���W


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 nowmouseposi;
        Vector3 diffposi;
        Vector3 mouse;
        Vector3 mouse3d;

        // �}�E�X����������Ă��鎞�A�I�u�W�F�N�g�𓮂���
        if (_isPushed)
        {
            mouse = Input.mousePosition;
            
            mouse.z =10f;
            mouse3d = Camera.main.ScreenToWorldPoint(mouse);
            mouse3d.y =1f;
            Debug.Log(mouse);
            Debug.Log(mouse3d);
            transform.position = mouse3d;
            // ���݂̃}�E�X�̃��[���h���W���擾
           // nowmouseposi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // ��O�̃}�E�X���W�Ƃ̍������v�Z���ĕω��ʂ��擾
            //diffposi = nowmouseposi - _nowMousePosi;
            //�@Y�����̂ݕω�������
           // diffposi.x = 0;
           // diffposi.z = 0;
            // �J�n���̃I�u�W�F�N�g�̍��W�Ƀ}�E�X�̕ω��ʂ𑫂��ĐV�������W��ݒ�
            //GetComponent<Transform>().position += diffposi;
            // ���݂̃}�E�X�̃��[���h���W���X�V
            //_nowMousePosi = nowmouseposi;
            //Debug.Log("ugoku");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // �����J�n�@�t���O�𗧂Ă�
        _isPushed = true;
        // �}�E�X�̃��[���h���W��ۑ�
        //_nowMousePosi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("hozon");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // �����I���@�t���O�𗎂Ƃ�
        _isPushed = false;
        //_nowMousePosi = Vector3.zero;
        Debug.Log("UP");
    }
}
