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
        // �}�E�X�̍��{�^�����������ꂽ��A�ΏۃI�u�W�F�N�g�𒲂ׂ鏈��
       
      
        CastRay();
    }
    void OnDisable()
    {
       
    }
    // �}�E�X�J�[�\���̈ʒu����u���C�v���΂��āA�����̃R���C�_�[�ɓ����邩�ǂ������`�F�b�N
    void CastRay()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("Player"))
            {
                
                RayOn();
                
                Debug.Log("�v���C���[����");
            }
        }
        else
        {
          //Debug.Log("�����Ȃ�");
            //RayOn();
        }
    }
    // �Ώۂ̃I�u�W�F�N�g�𒲂ׂ鏈��
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