using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
   
    private Rigidbody2D playerRb;
    public float velocidade;
    public GameObject bulletPrefab;
    public Transform armaPosition;

    public float velocidadeTiro;

    // Start is called before the first frame update
    void Start()
    {
        
        playerRb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        playerRb.velocity = new Vector2(horizontal * velocidade, vertical * velocidade);

        if (Input.GetButtonDown("Fire1"))
        {
            Shot();
        }
    }   

    void Shot ()
    {
        GameObject temp = Instantiate(bulletPrefab);
        temp.transform.position = armaPosition.position;
        temp.GetComponent<Rigidbody2D>().velocity = new Vector2(0, velocidadeTiro);
    }
}
