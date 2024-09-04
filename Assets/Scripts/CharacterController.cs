using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Animator animator;
    public float characterSpeed;
    Rigidbody rg;
    public float jumpingPower;
    public float runningSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        rg = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        float yatay = Input.GetAxis("Horizontal");
        float dikey = Input.GetAxis("Vertical");
        animator.SetFloat("Horizontal", yatay);
        animator.SetFloat("Vertical", dikey);
        this.gameObject.transform.Translate(yatay * characterSpeed * Time.deltaTime, 0, dikey * characterSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Space))
        {
            rg.useGravity = false;
            animator.SetBool("IsJump", true);
            rg.AddForce(Vector3.up * jumpingPower, ForceMode.Impulse);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rg.useGravity = true;
            animator.SetBool("IsJump", false);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            animator.SetFloat("Speed", 0.9f);
             this.gameObject.transform.Translate(yatay * runningSpeed * Time.deltaTime, 0, dikey * runningSpeed * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            animator.SetFloat("Speed", 0.1f);
        }
    }
    public void Jump()
    {
       
        rg.useGravity = false;
        animator.SetBool("IsJump", true);
        rg.AddForce(Vector3.up * jumpingPower, ForceMode.Impulse);
        rg.useGravity = true;
    }
    public void Running()
    {
        animator.SetFloat("Speed", 0.1f);
    }
    private void OnCollisionEnter(Collision other)
    {
       
        
    }
}
