using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JUMPMAN : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] Vector2 impulse_jump;
    [SerializeField] Vector2 force_right;
    [SerializeField] Vector2 force_left;
    [SerializeField] float speed;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jump()
    {
        //Debug.Log(context);
        rb.AddForce(impulse_jump, ForceMode2D.Impulse);
    }

    public void WalkRight(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        rb.AddForce(force_right * speed, ForceMode2D.Force);
    }

    public void WalkLeft(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        rb.AddForce(force_left * speed, ForceMode2D.Force);
    }
}
