using System.Linq;
using UnityEngine;

public class MousePositionTest : MonoBehaviour
{
    private Vector3 setTapPos;
    [SerializeField]
    private Camera mainCamera;
    private Vector3 currentPosition = Vector3.zero;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            var raycastHitList = Physics.RaycastAll(ray).ToList();
            if (raycastHitList.Any())
            {
                var distance = Vector3.Distance(mainCamera.transform.position, raycastHitList.First().point);
                var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);

                currentPosition = mainCamera.ScreenToWorldPoint(mousePosition);
                currentPosition.y = 0;
                Debug.Log("a");
                setTapPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
    }

    void OnDrawGizmos()
    {
        if (currentPosition != Vector3.zero)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(currentPosition, 1);
        }
    }
}