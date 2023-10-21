using UnityEngine;
using System.Collections;

public class MouseMove : MonoBehaviour
{

	//�@���C���΂�����
	private float rayRange = 100f;
	//�@�ړ�����ʒu
	private Vector3 targetPosition;
	//�@���x
	private Vector3 velocity;
	//�@�ړ��X�s�[�h
	[SerializeField]
	private float moveSpeed = 1.5f;
	//�@�}�E�X�N���b�N�ňړ�����ʒu�����肷�邩�ǂ���
	[SerializeField]
	private bool isMouseDownMode = true;
	//�@�X���[�X�ɃL�����N�^�[�̌�����ύX���邩�ǂ���
	[SerializeField]
	private bool smoothRotateMode = true;
	//�@��]�x����
	[SerializeField]
	private float smoothRotateSpeed = 180f;
	private CharacterController characterController;
	private Animator animator;

	void Start()
	{
		characterController = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
		targetPosition = transform.position;
		velocity = Vector3.zero;
	}

	void Update()
	{
		if (characterController.isGrounded)
		{
			velocity = Vector3.zero;
			//�@�}�E�X�N���b�N�܂���isMouseDownMode��Off�̎��}�E�X�̈ʒu���ړ�����ʒu�ɂ���
			if (Input.GetButton("Fire1") || !isMouseDownMode)
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit, rayRange, LayerMask.GetMask("Field")))
				{
					targetPosition = hit.point;
				}
			}
			//�@�ړ��̖ړI�n��0.1m��苗�������鎞�͑��x���v�Z
			if (Vector3.Distance(transform.position, targetPosition) > 0.1f)
			{
				var moveDirection = (targetPosition - transform.position).normalized;
				velocity = new Vector3(moveDirection.x * moveSpeed, velocity.y, moveDirection.z * moveSpeed);
				//�@�X���[�X���[�h�̎��͏��X�ɃL�����N�^�[�̌�����ύX����
				if (smoothRotateMode)
				{
					transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(new Vector3(moveDirection.x, 0, moveDirection.z)), smoothRotateSpeed * Time.deltaTime);
					//�@�X���[�X���[�h�łȂ���Έ�C�ɖړI�n�̕�������������
				}
				else
				{
					transform.LookAt(transform.position + new Vector3(moveDirection.x, 0, moveDirection.z));
				}
				//�@�A�j���[�V�����p�����[�^�̐ݒ�
				animator.SetFloat("Speed", moveDirection.magnitude);
				//�@�ړI�n�ɋߕt�����瑖��A�j���[�V��������߂�
			}
			else
			{
				animator.SetFloat("Speed", 0f);
			}
		}

		velocity.y += Physics.gravity.y * Time.deltaTime;
		characterController.Move(velocity * Time.deltaTime);
	}
}