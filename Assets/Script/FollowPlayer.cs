using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player, view;
    float speed = 20f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveAndJump();
    }
    void MoveAndJump()
    {

        float xAxis = Input.GetAxis("Horizontal");
        float yAxix = Input.GetAxis("Vertical");
    /*    float zAxis = Input.GetAxis("");*/
        Vector3 pos = transform.position;
        pos.x = pos.x + (xAxis * speed * Time.deltaTime);
        pos.y = pos.y + (yAxix * speed * Time.deltaTime);
       /* pos.z = pos.z + (zAxis * speed * Time.deltaTime);*/
        transform.position = pos;
    }
}
