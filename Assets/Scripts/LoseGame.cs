using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LoseGame : MonoBehaviour
{
    public GameObject perrito;
    public Transform posicionIncial;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            {
            perrito.transform.position = posicionIncial.position;
            }

        
    }

    //Posicion inical 
    //personaje
    //condicion 
}
