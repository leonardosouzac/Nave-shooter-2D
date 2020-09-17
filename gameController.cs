using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class gameController : MonoBehaviour
{
    public playerController _playerController;


    [Header("Limites de Movimento")]
    public Transform limiteSuperior, limiteInferior, limiteEsquerdo, limiteDireito;

    [Header("Limite lateral Câmera")]
    public Transform limiteCamEsquerda;
    public Transform limiteCamDireita;

    public Camera camera1;
    public float velocidadeLateralCamera;

    public Transform posFinalCamera;
    public float velocidadeFase;

  
    // Start is called before the first frame update
    void Start()
    {
        _playerController = FindObjectOfType(typeof(playerController)) as playerController;

    }

    // Update is called once per frame
    void Update()
    {
        limitarMovimentoPlayer();
    }

    void LateUpdate()
    {
        controlePosicaoCamera();

        camera1.transform.position = Vector3.MoveTowards(camera1.transform.position, new Vector3(camera1.transform.position.x, posFinalCamera.position.y, -10), velocidadeFase *Time.deltaTime);        


    }
    void controlePosicaoCamera()
    {
        if (camera1.transform.position.x > limiteCamEsquerda.position.x && camera1.transform.position.x < limiteCamDireita.position.x)
        {
            moverCamera();
        }
        else if (camera1.transform.position.x <= limiteCamEsquerda.position.x && _playerController.transform.position.x > limiteCamEsquerda.position.x)
        {
            moverCamera();
        }
        else
        {
            moverCamera();
        }
    }

    void moverCamera()
    {
        Vector3 posicaoDestinoCamera = new Vector3(_playerController.transform.position.x, camera1.transform.position.y, -10);
        camera1.transform.position = Vector3.Lerp(camera1.transform.position, posicaoDestinoCamera, velocidadeLateralCamera * Time.deltaTime);
    }

    void limitarMovimentoPlayer ()
    {
        float posY = _playerController.transform.position.y;
        float posX = _playerController.transform.position.x;

        if (_playerController.transform.position.y > limiteSuperior.position.y)
        {
            _playerController.transform.position = new Vector3(posX, limiteSuperior.position.y, 0);
        }
        else if(posY < limiteInferior.position.y)
        {
            _playerController.transform.position = new Vector3(posX, limiteInferior.position.y, 0);
        }

        if (posX > limiteDireito.position.x)
        {
            _playerController.transform.position = new Vector3(limiteDireito.position.x, posY, 0);
        }
        else if (posX < limiteEsquerdo.position.x)
        {
            _playerController.transform.position = new Vector3(limiteEsquerdo.position.x, posY, 0);
        }
    }
}
