using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMove : MonoBehaviour
{   
    private　Vector3 setTapPos;
    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            setTapPos =Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            setTapPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            setTapPos.y = 1;// カメラとプレイヤーの距離

            // Lerpで動かす
            transform.position = Vector3.Lerp(transform.position, setTapPos, speed * Time.deltaTime);
        }
    }
}


