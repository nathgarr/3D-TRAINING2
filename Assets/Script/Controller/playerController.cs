using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] private GameObject player, cam;
    [SerializeField] float speed = 5f;
    public float MaxSpeed;
    Vector3 inputDir;
    float currentVelocity;
    float smoothTime = 0.05f;
    [SerializeField] Animator animator;
    [SerializeField] LayerMask groundMask;
    bool jumpKeyPressed;
    float lastJumpTime = -1000;
    [SerializeField] float jumpPower = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        inputDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        inputDir.Normalize();
        if (!jumpKeyPressed && Input.GetAxis("Jump")>0) { jumpKeyPressed = true; }

    }
    private void FixedUpdate()
    {
        float inputMagnitude = Mathf.Clamp01(inputDir.magnitude);
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            inputMagnitude /= 2;
        }
        animator.SetFloat("Input Magnetude", inputMagnitude);
        float speed = inputMagnitude * MaxSpeed;
        IsGrounded();
        Move(speed);
        rb.angularVelocity= Vector3.zero;
    }
    void Move(float speed)
    {
        Vector3 forwardDir = transform.forward * inputDir.z;
        forwardDir.Normalize();
        forwardDir *= speed;

        Vector3 strafeDir = Vector3.Cross(Vector3.up, transform.forward) * inputDir.x;
        strafeDir.Normalize();
        strafeDir *= speed;

        Vector3 moveDir = forwardDir + strafeDir;

        rb.MovePosition(transform.position + (moveDir * Time.deltaTime));

        float targetRotation = cam.transform.eulerAngles.y;
        float playerAngleDamp = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0, playerAngleDamp, 0);



        if (jumpKeyPressed && IsGrounded())
        {
            JumpPower();
        }


        /*float xAxis = Input.GetAxis("Horizontal");*/
        /*float yAxix = Input.GetAxis("Vertical");*/
        /*float zAxis = Input.GetAxis("");*/
        /*Vector3 pos = transform.position;
        pos.x = pos.x + (xAxis * speed * Time.deltaTime);
        pos.y = pos.y + (yAxix * speed * Time.deltaTime);*/
        /* pos.z = pos.z + (zAxis * speed * Time.deltaTime);*/
        /* transform.position = pos;*/
    }

    public void JumpPower()
    {
        jumpKeyPressed = false;
        if (Time.timeSinceLevelLoad - lastJumpTime < 1) return; 
        lastJumpTime = Time.timeSinceLevelLoad;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(0, jumpPower, 0, ForceMode.Impulse);
    }

    /// <summary>
    /// return true if player is on the ground
    /// </summary>
    /// <returns></returns>
    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position + new Vector3(0, 0.1f, 0), Vector3.down, 0.11f, groundMask);
    }
}
