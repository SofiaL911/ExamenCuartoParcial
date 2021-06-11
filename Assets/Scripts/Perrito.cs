using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perrito : MonoBehaviour
{
    public Animator animator;

    public SpriteRenderer perrito;

    public Rigidbody2D rigidbody;

    public float moveSpeed;
    public float jumpForce = 1;


    private float horizontal;
    private float vertical;
    private Vector3 direction;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Salto de personaje
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        direction = new Vector3(horizontal, 0f, vertical);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            animator.SetBool("JumpAnimation", true);
        }



        //Movimiento del Personaje
        //a -> Left
        if (Input.GetKey(KeyCode.A))
        {
            perrito.flipX = true;
            //transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            animator.SetBool("WalkAnimation", true);
            transform.position = new Vector2(transform.position.x - moveSpeed, transform.position.y);
        }

        //d -> Right
        if (Input.GetKey(KeyCode.D))
        {
            perrito.flipX = false;
            //transform.localScale = new Vector3(-0.2f, -0.2f, -0.2f);

            animator.SetBool("WalkAnimation", true);
            transform.position = new Vector2(transform.position.x + moveSpeed, transform.position.y);
        }
        if (direction.magnitude == 0f)
        {
            animator.SetBool("WalkAnimation", false);

        }
    }
}
