using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    // private変数をInspectorウィンドウに表示するために"[SerializeField]"を付ける
    // 水平方向の減速
    [SerializeField]
    private float horizonDamping;
    // 垂直方向の減速
    [SerializeField]
    private float verticalDamping;
    // 奥行き（マウスホイール回転値）の乗算
    [SerializeField]
    private float depthMultiply;
    // マウスカーソル座標
    private Vector3 mousePos;
    // スクリーン座標をワールド座標に変換した位置座標
    private Vector3 screenToWorldPointPosition;

    void Update()
    {
        // オブジェクトのX座標を変数に格納
        float currentWidth = transform.position.x;
        // オブジェクトのY座標を変数に格納
        float currentHeight = transform.position.y;
        // オブジェクトのZ座標を変数に格納
        float currentDepth = transform.position.z;
        // マウスホイール回転値を変数に格納
        float mouseScroll = Input.GetAxis("Mouse ScrollWheel");
        // マウス座標を変数に格納
        mousePos = Input.mousePosition;
        //マウスカーソル座標にカメラのZ座標を代入（カメラのZ座標が-の場合は=-にする）
        mousePos.z = -Camera.main.transform.position.z;
        // マウスカーソル座標をスクリーン座標からワールド座標に変換する
        screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(mousePos);
        //オブジェクトの座標にマウスカーソルX座標の減速値を加える（マウスカーソル値に徐々に近づく）
        currentWidth += (screenToWorldPointPosition.x - currentWidth) * horizonDamping;
        //オブジェクトの座標にマウスカーソルY座標の減速値を加える（マウスカーソル値に徐々に近づく）
        currentHeight += (screenToWorldPointPosition.y - currentHeight) * verticalDamping;
        //オブジェクト座標にマウスホイール回転値を加える
        currentDepth += (mouseScroll * depthMultiply);
        //オブジェクトの座標に変数の値を代入
        transform.position = new Vector3(currentWidth, currentHeight, currentDepth);
    }
}