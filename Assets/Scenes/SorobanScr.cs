using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems; // 追加
using UnityEngine;

public class SorobanScr : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool _isPushed = false; // マウスが押されているか押されていないか
    //private Vector3 _nowMousePosi; // 現在のマウスのワールド座標


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

        // マウスが押下されている時、オブジェクトを動かす
        if (_isPushed)
        {
            mouse = Input.mousePosition;
            
            mouse.z =10f;
            mouse3d = Camera.main.ScreenToWorldPoint(mouse);
            mouse3d.y =1f;
            Debug.Log(mouse);
            Debug.Log(mouse3d);
            transform.position = mouse3d;
            // 現在のマウスのワールド座標を取得
           // nowmouseposi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // 一つ前のマウス座標との差分を計算して変化量を取得
            //diffposi = nowmouseposi - _nowMousePosi;
            //　Y成分のみ変化させる
           // diffposi.x = 0;
           // diffposi.z = 0;
            // 開始時のオブジェクトの座標にマウスの変化量を足して新しい座標を設定
            //GetComponent<Transform>().position += diffposi;
            // 現在のマウスのワールド座標を更新
            //_nowMousePosi = nowmouseposi;
            //Debug.Log("ugoku");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // 押下開始　フラグを立てる
        _isPushed = true;
        // マウスのワールド座標を保存
        //_nowMousePosi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("hozon");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // 押下終了　フラグを落とす
        _isPushed = false;
        //_nowMousePosi = Vector3.zero;
        Debug.Log("UP");
    }
}
