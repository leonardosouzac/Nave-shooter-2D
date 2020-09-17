using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    private playerController _playerController;

    public GameObject explosãoPrefab;
    public GameObject[] loot;

    public Transform arma;
    public GameObject tiro;

    public float[] delayEntreTiros;
    // Start is called before the first frame update
    void Start()
    {
        _playerController = FindObjectOfType(typeof(playerController)) as playerController;

        StartCoroutine("atirar");
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    void OnTriggerEnter2D(Collider2D col)
    {
       switch(col.gameObject.tag)
        {
            case "playerShot":
                GameObject temp = Instantiate(explosãoPrefab, transform.position, transform.localRotation);
                Destroy(col.gameObject);
                Destroy(temp.gameObject, 0.5f);
                Destroy(this.gameObject);

                spawnLoot();

                break;
        }
    }

    void spawnLoot()
    {
        int idItem = 0;
        int rand = Random.Range(0, 100);
        if (rand < 50)
        {
            rand = Random.Range(0, 100);
            if (rand > 85)
            {
                idItem = 2; // cx bomba
            }
            else if (rand > 50)

            {
                idItem = 1; // cx saúde
            }
            else
            {
                idItem = 0; // cx moeda
            }

            Instantiate(loot[idItem], transform.position, transform.localRotation);
        }
    }

    void Shot()
    {
        arma.right = _playerController.transform.position - transform.position;
        GameObject temp = Instantiate(tiro, arma.position, arma.localRotation);
        temp.GetComponent<Rigidbody2D>().velocity = arma.right * 3;
    }
    IEnumerator atirar ()
    {

        yield return new WaitForSeconds(Random.Range(delayEntreTiros[0], delayEntreTiros[1]));
        Shot();

        StartCoroutine("atirar");
    }
}
