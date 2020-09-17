using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAInimigoA : MonoBehaviour
{

    public float velocidadeMovimento;
    public float pontoInicialCurva;
    public float pontoCurvaX;

    private bool isCurva;

    public float grausCurva;
    private float incrementado;
    private float rotacaoZ;
    public float incrementar;

    // Start is called before the first frame updateS
    void Start()
    {
        rotacaoZ = transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= pontoInicialCurva && isCurva == false && rotacaoZ < 90)
        {
            isCurva = true;
          
        }

        if (transform.position.x >= pontoCurvaX)
        {

            isCurva = true;
        }

        if (isCurva == true && incrementado < grausCurva)
        {
            rotacaoZ += incrementar;
            transform.rotation = Quaternion.Euler(0, 0, rotacaoZ);

            if (incrementar < 0)
            {
                incrementado += (incrementar * -1);
            }
            else
            {
                incrementado += incrementar;
            }
            
        }
        transform.Translate(Vector3.down * velocidadeMovimento * Time.deltaTime);
    }
}
