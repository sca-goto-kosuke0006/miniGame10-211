using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class MoveToClickPoint : MonoBehaviour
{
    NavMeshAgent agent;
    private bool isMove=false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isMove) { 
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
                {
                agent.destination = hit.point;
                }
            }
        }
        //if (Input.GetMouseButtonDown(1))
       // {
       //     Move();
       // }
    }
    public void Move()
    {
        if (isMove == false)
        {
            isMove = true;
        }
        else
        {
            isMove = false;
        }
        Debug.Log("Move");
    }
}