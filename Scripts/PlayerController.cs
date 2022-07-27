using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    public float moveSpeed;
   // public Rigidbody Rb;
    public float jumpForce;
    public CharacterController controller;

    public float gravityScale;
    private Vector3 moveDirection;

    //private float activeMoveSpeed;
    //public float dashSpeed;

    //public float dashLength = .5f, dashCoolDown = 1f;

    //public float dashCounter; 
    //public float dashCoolCounter; 

    public Animator anim;

    public Transform pivot;
    public float rotateSpeed;


    public GameObject playerModel;



    // Start is called before the first frame update
    void Start()
    {
        // Rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        //activeMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //Rb.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, Rb.velocity.y, Input.GetAxis("Vertical") * moveSpeed);

        /*if(Input.GetButtonDown("Jump"))
        {
            Rb.velocity = new Vector3(Rb.velocity.x, jumpForce, Rb.velocity.z);
        }*/

        float yStore = moveDirection.y;
        //moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
        moveDirection = (transform.forward * Input.GetAxis("Vertical") * moveSpeed) + (transform.right * Input.GetAxis("Horizontal") * moveSpeed);
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;




        if (controller.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);


        //Move the player in different direction
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }

        //////Animation
        anim.SetBool("isGrounded", controller.isGrounded);
        anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));

        /*
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (dashCoolCounter <=0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }

            if (dashCounter > 0)
            {
                dashCounter -= Time.deltaTime;

                if (dashCounter <= 0)
                {
                    activeMoveSpeed = moveSpeed;
                    dashCoolCounter = dashCoolDown;
                }
            }

            if (dashCounter > 0)
            {
                dashCoolCounter -= Time.deltaTime;
            }
        }
        */

    }
}
