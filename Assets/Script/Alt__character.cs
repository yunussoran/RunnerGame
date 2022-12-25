using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Alt__character : MonoBehaviour
{
    GameObject Target;
    NavMeshAgent _Navmesh;
    public GameManager _Gamemanager;
    void Start()
    {

        _Navmesh = GetComponent<NavMeshAgent>();
        Target = _Gamemanager.Destination;

    }

    private void LateUpdate()
    {
        _Navmesh.SetDestination(Target.transform.position);

    }

    Vector3 PozisyonVer()
    {

        return new Vector3(transform.position.x, .23f, transform.position.z);
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("igneliKutu"))
        {
            _Gamemanager.YokOlmaEfektleriOlustur(PozisyonVer());
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("Testere"))
        {
            _Gamemanager.YokOlmaEfektleriOlustur(PozisyonVer());
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("PervaneIgneler"))
        {
            _Gamemanager.YokOlmaEfektleriOlustur(PozisyonVer());
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("Balyoz"))
        {
            _Gamemanager.YokOlmaEfektleriOlustur(PozisyonVer(), true);
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("Dusman"))
        {
            _Gamemanager.YokOlmaEfektleriOlustur(PozisyonVer(), false, false);
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("BosKarakter"))
        {
            _Gamemanager.Karakterler.Add(other.gameObject);
           
        }

            


    }



}
