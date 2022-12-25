using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dusman : MonoBehaviour
{
    public GameObject SaldýrýHedefi;
     NavMeshAgent Navmeshx;
    public GameManager _Gamemanager;
    bool Saldiri_Basladimi;
    void Start()
    {
        Navmeshx=GetComponent<NavMeshAgent>();  
    }
    public void AnimasyonTetikle()
    {
        GetComponent<Animator>().SetBool("Saldýr", true);
        Saldiri_Basladimi = true;
    }
     void LateUpdate()
    {
        if (Saldiri_Basladimi)  
            Navmeshx.SetDestination(SaldýrýHedefi.transform.position);           
        

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("AltKarakterler")) 
        { 
            Vector3 yeniPoz = new Vector3(transform.position.x, .23f, transform.position.z);
            _Gamemanager.YokOlmaEfektleriOlustur(yeniPoz, false, true);
            gameObject.SetActive(false);

        }
    }
}
