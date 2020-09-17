using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trajetoInimigo : MonoBehaviour
{
    public Transform[] checkpoints;

    public float velocidadeMovimento;
    public float delayParado;

    public Transform naveInimiga;

    private int idCheckpoints;
    private bool movimentar;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("iniciarMovimento");
    }

    // Update is called once per frame
    void Update()
    {
        if(movimentar == true)
        {
            naveInimiga.localPosition = Vector3.MoveTowards(naveInimiga.localPosition, checkpoints[idCheckpoints].position, velocidadeMovimento * Time.deltaTime);
            if (naveInimiga.localPosition == checkpoints[idCheckpoints].position)
            {
                movimentar = false;
                StartCoroutine("iniciarMovimento");

            }
        }
    }

    IEnumerator iniciarMovimento()
    {
        idCheckpoints += 1;
        if (idCheckpoints >= checkpoints.Length)
        {
            idCheckpoints = 0;
        }
        yield return new WaitForSeconds(delayParado);
        movimentar = true;
    }
}
