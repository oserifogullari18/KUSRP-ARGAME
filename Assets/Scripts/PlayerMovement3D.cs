using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    public float speed = 20;
    private Vector3 motion;
    private Rigidbody rb;
    Animator _animator;
    Vector3 lastPos;
    bool moved = false;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        lastPos = rb.position;

    }

    // Update is called once per frame
    void Update()
    {
        motion = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        rb.velocity = motion * speed;

        Vector3 offset = rb.position - lastPos;
        lastPos = rb.position;

        Debug.Log("position " + rb.position);
        Debug.Log("change in position " + offset);

        Debug.Log("motion " + motion);
        Debug.Log("velocity" + rb.velocity);
        Debug.Log("speed" + speed);

        if(!offset.Equals(new Vector3(0,0,0)))
        {
            moved = true;
        }
        else
        {
            moved = false;
        }
        
        _animator.SetBool("isMoving", moved);
    }
}
