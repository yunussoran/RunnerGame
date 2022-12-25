using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class Character : MonoBehaviour
{

    public GameManager _GameManager;
    public GameObject _Kamera;
    public bool SonaGeldikMi;
    public GameObject GidecegiYer;
    public Slider _Slider;
    public GameObject GecisNoktasi;
    Vector3 startpos;
    private float minx = -1.03f;
    private float maxx = 1.07f;
    private void FixedUpdate()

    {
        if (!SonaGeldikMi)
        {

             transform.Translate(Vector3.forward * .5F * Time.deltaTime);
            



        }
           
       
    }


    private void Start()
    {
        startpos = transform.position;
        float Fark = Vector3.Distance(transform.position, GecisNoktasi.transform.position);
        _Slider.maxValue = Fark;
       
    }



    void Update()
    {

      


        if (SonaGeldikMi)
        {
            transform.position = Vector3.Lerp(transform.position, GidecegiYer.transform.position, .015f);
            if (_Slider.value != 0)
                _Slider.value -= .01f;
        }
        else
        {
            float Fark = Vector3.Distance(transform.position, GecisNoktasi.transform.position);
            _Slider.value = Fark;

            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (Input.GetAxis("Mouse X") < 0)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3( Mathf.Clamp(transform.position.x -.1f, minx,maxx) , transform.position.y, transform.position.z), .3f);
                }
                if (Input.GetAxis("Mouse X") > 0)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(Mathf.Clamp(transform.position.x + .1f, minx, maxx), transform.position.y, transform.position.z), .3f);
                }
             
                 

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SayisalBlok"))
        {
            BlokControl blok = other.GetComponent<BlokControl>();

            blok.OnTrigger(); //Diger Collideri kapatma
            int sayi = blok.GetValue(); //Deger
            string islemTuru = blok.GetBlokType(); //Islem Turu
            _GameManager.AdamYonetim(islemTuru, sayi, other.transform);
        }
        else if (other.CompareTag("SonTetikleyici"))
        {
            _Kamera.GetComponent<Camera>().SonaGeldikMi = true;
            _GameManager.DusmanlariTetikle();
            SonaGeldikMi = true;
        }
        else if (other.CompareTag("BosKarakter"))
        {
            _GameManager.Karakterler.Add(other.gameObject);
        }

    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Direk")  || collision.gameObject.CompareTag("PervaneIgneler"))
        {




            if (transform.position.x > 0)
                transform.position = new Vector3(transform.position.x - .2f, transform.position.y, transform.position.z);
            else
                transform.position = new Vector3(transform.position.x + .2f, transform.position.y, transform.position.z);
        }
        else if (collision.gameObject.CompareTag("igneliKutu"))
        {

            if (transform.position.x > 0)
                transform.position = new Vector3(transform.position.x - .4f, transform.position.y, transform.position.z);
            else
                transform.position = new Vector3(transform.position.x + .4f, transform.position.y, transform.position.z);
        }

       
            



        


    }



}