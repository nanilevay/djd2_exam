using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    [SerializeField]private string horizontalInputName;
    [SerializeField]private string verticalInputName;

    [SerializeField]private float walkSpeed, runSpeed;
    [SerializeField]private float runBuildUpSpeed;
    [SerializeField]private KeyCode runKey;

    private float movementSpeed;

    private bool walking;

    private CharacterController charController;

   private Animator _animator;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        _animator = GetComponentInChildren<Animator>();
        walking = false;
    }

    private void Update()
    {
        PlayerMovement();

        if(walking == false)
        { 
            _animator.SetBool("Walk", false);
            _animator.SetBool("Run", false);
        }
    }

    private void PlayerMovement()
    {
        float horizInput = Input.GetAxis(horizontalInputName);
        float vertInput = Input.GetAxis(verticalInputName);

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(Vector3.ClampMagnitude(forwardMovement + rightMovement, 1.0f) * movementSpeed);

        SetMovementSpeed();

    }

    private void SetMovementSpeed()
    {
        if (Input.GetKey(runKey))
        {
            walking = true;
            _animator.SetBool("Run", true);
            _animator.SetBool("Walk", false);
            movementSpeed = Mathf.Lerp(movementSpeed, runSpeed, Time.deltaTime * runBuildUpSpeed);
        }

        else
        {
            _animator.SetBool("Walk", true);
            _animator.SetBool("Run", false);
            walking = true;
            movementSpeed = Mathf.Clamp(movementSpeed, walkSpeed, Time.deltaTime * runBuildUpSpeed);
        }
    }
}
