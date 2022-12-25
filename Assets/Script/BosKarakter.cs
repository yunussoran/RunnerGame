using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BosKarakter : MonoBehaviour
{
    public SkinnedMeshRenderer _Renderer;
    public Material AtanacakOlanMateryal;
    public NavMeshAgent _Navmesh;
    public Animator _Animator;
    public GameObject Target;
    bool Temasvar;
    public GameManager _GameManager;

    private void LateUpdate()
    {
        if (Temasvar)
        {

            _Navmesh.SetDestination(Target.transform.position);

        }
    }

    Vector3 PozisyonVer()
    {

        return new Vector3(transform.position.x, .23f, transform.position.z);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AltKarakterler") || other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("BosKarakter"))
            {
                MaterialDegistirVeAnimasyonTetikle();
                Temasvar = true;
                GetComponent<AudioSource>().Play();
            }
           
        }
        else if (other.CompareTag("igneliKutu"))
        {
            _GameManager.YokOlmaEfektleriOlustur(PozisyonVer());
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("Testere"))
        {
            _GameManager.YokOlmaEfektleriOlustur(PozisyonVer());
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("PervaneIgneler"))
        {
            _GameManager.YokOlmaEfektleriOlustur(PozisyonVer());
            gameObject.SetActive(false); 
        }
        else if (other.CompareTag("Balyoz"))
        {
            _GameManager.YokOlmaEfektleriOlustur(PozisyonVer(), true);
            gameObject.SetActive(false);
        }

        else if (other.CompareTag("Dusman"))
        {
            _GameManager.YokOlmaEfektleriOlustur(PozisyonVer(), false, false);
            gameObject.SetActive(false);
        }

    }

    void MaterialDegistirVeAnimasyonTetikle()
    {

        Material[] mats = _Renderer.materials;
        mats[0] = AtanacakOlanMateryal;
        _Renderer.materials = mats;
        _Animator.SetBool("Saldýr", true);
       
        gameObject.tag = "AltKarakterler";
        GameManager.instance.AnlikKarakterSayisi++;

    }
}
