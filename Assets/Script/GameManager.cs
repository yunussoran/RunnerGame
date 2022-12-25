using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GeneralControl;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    public GameObject Destination;
    public int AnlikKarakterSayisi = 1;
    public List<GameObject> OlusmaEfektleri;
    public List<GameObject> YokOlmaEfektleri;
    public List<GameObject> Karakterler;
    public List<GameObject> AdamLekesiEfektleri;




    [Header("LEVEL VERÝLERÝ")]
    public List<GameObject> Dusmanlar;
    public int KacDusmanOlsun;
    public GameObject _AnaKarakter;
    public bool OyunBittiMi;
    bool SonaGeldikMi;

    Matematiksel_islemler _Matematiksel_islemler = new Matematiksel_islemler();

    BellekYonetim _BellekYonetim = new BellekYonetim();

    private void Start()
    {
        DusmanlariOlustur();





        Debug.Log(_BellekYonetim.VeriOku_i("Puan"));
    }


    public void DusmanlariOlustur()
    {
        for (int i = 0; i < KacDusmanOlsun; i++)
        {
            Dusmanlar[i].SetActive(true);
        }
    }

    public void DusmanlariTetikle()
    {
        foreach (var item in Dusmanlar)
        {
            if (item.activeInHierarchy)
            {
                item.GetComponent<Dusman>().AnimasyonTetikle();
            }
        }
        SonaGeldikMi = true;
        SavasDurumu();
    }

    void Update()
    {

        /*   foreach (var item in Karakterler)
           {
               if (!item.activeInHierarchy)
               {
                   item.transform.position = SpawnPoint.transform.position;
                   item.SetActive(true);
                   AnlikKarakterSayisi++;
                   break;
               }
          */

    }

    void SavasDurumu()
    {
        if (SonaGeldikMi)
        {
            if (AnlikKarakterSayisi == 1 || KacDusmanOlsun == 0)
            {
                OyunBittiMi = true;
                foreach (var item in Dusmanlar)
                {
                    if (item.activeInHierarchy)
                    {
                        item.GetComponent<Animator>().SetBool("Saldýr", false);
                    }
                }
                foreach (var item in Karakterler)
                {
                    if (item.activeInHierarchy)
                    {
                        item.GetComponent<Animator>().SetBool("Saldýr", false);
                    }
                }
                _AnaKarakter.GetComponent<Animator>().SetBool("Saldýr", false);

                if (AnlikKarakterSayisi <= KacDusmanOlsun && AnlikKarakterSayisi == 1)
                {
                    Debug.Log("kaybettýn");


                }
                else
                {
                    if (AnlikKarakterSayisi > 5)
                        _BellekYonetim.VeriKaydet_int("Puan", _BellekYonetim.VeriOku_i("Puan") + 600);
                    else
                        _BellekYonetim.VeriKaydet_int("Puan", _BellekYonetim.VeriOku_i("Puan") + 200);

                    // Debug.Log("kazandýn");
                }

            }
        }


    }

    public void AdamYonetim(string islemturu, int GelenSayý, Transform Pozisyon)
    {
        switch (islemturu)
        {

            case "Carpma":
                _Matematiksel_islemler.Carpma(GelenSayý, Karakterler, Pozisyon, OlusmaEfektleri);
                break;

            case "Toplama":
                _Matematiksel_islemler.Toplama(GelenSayý, Karakterler, Pozisyon, OlusmaEfektleri);
                break;

            case "Cikarma":
                _Matematiksel_islemler.Cikarma(GelenSayý, Karakterler, YokOlmaEfektleri);
                break;

            case "Bolme":
                _Matematiksel_islemler.Bolme(GelenSayý, Karakterler, YokOlmaEfektleri);
                break;
        }
    }

    public void YokOlmaEfektleriOlustur(Vector3 Pozisyon, bool Balyoz = false, bool Durum = false)
    {
        foreach (var item in YokOlmaEfektleri)
        {
            if (!item.activeInHierarchy)
            {
                item.SetActive(true);
                item.transform.position = Pozisyon;
                item.GetComponent<ParticleSystem>().Play();
               

                if (!Durum)
                    AnlikKarakterSayisi--;
                else
                    KacDusmanOlsun--;
                break;


            }

        }


        if (Balyoz)
        {
            Vector3 yenipoz = new Vector3(Pozisyon.x, .005f, Pozisyon.z);

            foreach (var item in AdamLekesiEfektleri)
            {
                if (!item.activeInHierarchy)
                {
                    item.SetActive(true);
                    item.transform.position = yenipoz;
                    break;


                }
            }
        }
        if (!OyunBittiMi)
            SavasDurumu();
    }





}
