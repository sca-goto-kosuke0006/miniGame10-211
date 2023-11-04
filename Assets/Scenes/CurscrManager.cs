using UnityEngine;
public class CursorManager : MonoBehaviour
{
    [SerializeField]
    Texture2D defaultCursor = null;
    [SerializeField]
    Texture2D interactCursor = null;
    Camera mainCamera;
    RaycastHit hit;
    [SerializeField]
    GameObject targetObject;
    public MoveToClickPoint movepoin;
    void Start()
    {
        mainCamera = Camera.main;
     
    }
    void Update()
    {
        // マウスの左ボタンが押下されたら、対象オブジェクトを調べる処理
       
      
        CastRay();
    }
    void OnDisable()
    {
       
    }
    // マウスカーソルの位置から「レイ」を飛ばして、何かのコライダーに当たるかどうかをチェック
    void CastRay()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("Player"))
            {
                
                RayOn();
                
                Debug.Log("プレイヤー発見");
            }
        }
        else
        {
          //Debug.Log("何もない");
            //RayOn();
        }
    }
    // 対象のオブジェクトを調べる処理
    void LookUpTargetObject()
    {

        targetObject.GetComponent<MoveToClickPoint>().Move();
 
    }
  
    public void RayOn()
    {

        if (Input.GetMouseButtonDown(1))
        {
            LookUpTargetObject();
            movepoin.Move();
            return;
        }
    }
}