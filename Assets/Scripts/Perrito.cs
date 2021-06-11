using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perrito : MonoBehaviour
{
    public Animator animator;

    public SpriteRenderer perrito;

    public Rigidbody2D rb;

    public float moveSpeed;
    public float jumpForce = 1;

    private bool esPiso;

    private float horizontal;
    private float vertical;
    private Vector3 direction;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
            esPiso = true;

    }

    void Update()
    {
        //Salto de personaje
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        direction = new Vector3(horizontal, vertical, 0f);

        if (esPiso == true)
        { 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                animator.SetBool("JumpAnimation", true);
                esPiso = false;
            }
        }
            if (Input.GetKeyUp(KeyCode.Space))
                animator.SetBool("JumpAnimation", false);


        //bool 
        //usarlo en condicion
        //hacerlo falso
        //hacerlo verdadero
        //colision para ver si es piso y que se haga verdadero




        //Movimiento del Personaje
        //a -> Left
        if (Input.GetKey(KeyCode.A))
        {
            perrito.flipX = true;
            animator.SetBool("WalkAnimation", true);
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
            //rb.AddForce(new Vector2(-moveSpeed, 0f), ForceMode2D.Force);
        }

        //d -> Right
        if (Input.GetKey(KeyCode.D))
        {
            //rb.AddForce(new Vector2(moveSpeed, 0f), ForceMode2D.Force);

            perrito.flipX = false;

            animator.SetBool("WalkAnimation", true);
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        if (direction.magnitude == 0f)
        {
            animator.SetBool("WalkAnimation", false);
        }
    }

   

}
