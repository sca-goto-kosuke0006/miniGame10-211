using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimlMove : MonoBehaviour
{

    [SerializeField] private float AnimalSpeed;

    bool isMoving;
    Vector3 mousePos,worldPos;

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            mousePos =Input.mousePosition;

            worldPos =Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x,mousePos.y,10f));

            StartCoroutine(_move());
        }
    }

    private void StartCoroutine(IEnumerable enumerable)
    {
        throw new NotImplementedException();
    }

    IEnumerable _move()
    {
        isMoving = true;

        //ワールド座標と自身の座標を比較しループ
        while ((worldPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            //指定した座標に向かって移動
            transform.position = Vector3.MoveTowards(transform.position, worldPos, AnimalSpeed * Time.deltaTime);
            //1フレーム待つ
            yield return null;
        }
        //移動フラグをfalse
        isMoving = false;
    }
}
