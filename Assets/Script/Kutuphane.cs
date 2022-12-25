using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace GeneralControl
{
    public class Matematiksel_islemler
    {

        public void Carpma(int GelenSayi, List<GameObject> Karakterler, Transform Pozisyon, List<GameObject> OlusturmaEfektleri)
        {
            int DonguSayisi = (GameManager.instance.AnlikKarakterSayisi * GelenSayi) - GameManager.instance.AnlikKarakterSayisi;


            GameManager.instance.AnlikKarakterSayisi *= GelenSayi;

            for (int i = 0; i < Karakterler.Count; i++)
            {
                if (DonguSayisi <= 0) break;

                if (!Karakterler[i].activeInHierarchy)
                {
                    for (int j = 0; j < OlusturmaEfektleri.Count; j++)
                    {
                        if (!OlusturmaEfektleri[j].activeInHierarchy)
                        {
                            OlusturmaEfektleri[j].SetActive(true);
                            OlusturmaEfektleri[j].transform.position = Pozisyon.position;
                            OlusturmaEfektleri[j].GetComponent<ParticleSystem>().Play();
                            OlusturmaEfektleri[j].GetComponent<AudioSource>().Play();
                            break;
                        }
                    }

                    Karakterler[i].transform.position = Pozisyon.position;
                    Karakterler[i].SetActive(true);

                    DonguSayisi--;
                }
            }

        }

        public void Toplama(int GelenSayi, List<GameObject> Karakterler, Transform Pozisyon, List<GameObject> OlusturmaEfektleri)
        {
            int count = GelenSayi;

            GameManager.instance.AnlikKarakterSayisi += GelenSayi;

            for (int i = 0; i < Karakterler.Count; i++)
            {
                if (count <= 0) break;

                if (!Karakterler[i].activeInHierarchy)
                {
                    for (int j = 0; j < OlusturmaEfektleri.Count; j++)
                    {
                        if (!OlusturmaEfektleri[j].activeInHierarchy)
                        {
                            OlusturmaEfektleri[j].SetActive(true);
                            OlusturmaEfektleri[j].transform.position = Pozisyon.position;
                            OlusturmaEfektleri[j].GetComponent<ParticleSystem>().Play();
                            OlusturmaEfektleri[j].GetComponent<AudioSource>().Play();
                            break;
                        }
                    }

                    Karakterler[i].transform.position = Pozisyon.position;
                    Karakterler[i].SetActive(true);

                    count--;
                }
            }

        }

        public void Cikarma(int GelenSayi, List<GameObject> Karakterler, List<GameObject> YokOlmaEfektleri)
        {


            if (GameManager.instance.AnlikKarakterSayisi < GelenSayi)
            {
                foreach (var item in Karakterler)
                {
                    foreach (var item2 in YokOlmaEfektleri)
                    {
                        if (!item2.activeInHierarchy)
                        {
                            Vector3 yenipoz = new Vector3(item.transform.position.x, .23f, item.transform.position.z);

                            item2.SetActive(true);
                            item2.transform.position = yenipoz;
                            item2.GetComponent<ParticleSystem>().Play();
                            item2.GetComponent<AudioSource>().Play();

                            break;
                        }
                    }



                    item.transform.position = Vector3.zero;
                    item.SetActive(false);
                }
                GameManager.instance.AnlikKarakterSayisi = 1;
            }
            else
            {
                int sayi3 = 0;
                foreach (var item in Karakterler)
                {

                    foreach (var item2 in YokOlmaEfektleri)
                    {
                        if (!item2.activeInHierarchy)
                        {
                            Vector3 yenipoz = new Vector3(item.transform.position.x, .23f, item.transform.position.z);

                            item2.SetActive(true);
                            item2.transform.position = yenipoz;
                            item2.GetComponent<ParticleSystem>().Play();
                            item2.GetComponent<AudioSource>().Play();

                            break;
                        }
                    }

                    if (sayi3 != GelenSayi)
                    {

                        if (item.activeInHierarchy)
                        {

                            item.transform.position = Vector3.zero;
                            item.SetActive(false);
                            sayi3++;


                        }

                    }
                    else
                    {

                        sayi3 = 0;
                        break;
                    }


                }
                GameManager.instance.AnlikKarakterSayisi -= GelenSayi;

            }



        }

        public void Bolme(int GelenSayi, List<GameObject> Karakterler, List<GameObject> YokOlmaEfektleri)
        {



            if (GameManager.instance.AnlikKarakterSayisi <= GelenSayi)
            {
                foreach (var item in Karakterler)
                {
                    foreach (var item2 in YokOlmaEfektleri)
                    {
                        if (!item2.activeInHierarchy)
                        {
                            Vector3 yenipoz = new Vector3(item.transform.position.x, .23f, item.transform.position.z);

                            item2.SetActive(true);
                            item2.transform.position = yenipoz;
                            item2.GetComponent<ParticleSystem>().Play();
                            item2.GetComponent<AudioSource>().Play();

                            break;
                        }
                    }
                    item.transform.position = Vector3.zero;
                    item.SetActive(false);
                }
                GameManager.instance.AnlikKarakterSayisi = 1;
            }
            else
            {
                int bolen = GameManager.instance.AnlikKarakterSayisi / GelenSayi;
                int sayi3 = 0;
                foreach (var item in Karakterler)
                {

                    if (sayi3 != bolen)
                    {

                        if (item.activeInHierarchy)
                        {
                            foreach (var item2 in YokOlmaEfektleri)
                            {
                                if (!item2.activeInHierarchy)
                                {
                                    Vector3 yenipoz = new Vector3(item.transform.position.x, .23f, item.transform.position.z);

                                    item2.SetActive(true);
                                    item2.transform.position = yenipoz;
                                    item2.GetComponent<ParticleSystem>().Play();
                                    item2.GetComponent<AudioSource>().Play();

                                    break;
                                }
                            }
                            item.transform.position = Vector3.zero;
                            item.SetActive(false);
                            sayi3++;


                        }

                    }
                    else
                    {

                        sayi3 = 0;
                        break;
                    }


                }

                if (GameManager.instance.AnlikKarakterSayisi % GelenSayi == 0)
                {
                    GameManager.instance.AnlikKarakterSayisi /= GelenSayi;
                }
                else if (GameManager.instance.AnlikKarakterSayisi % GelenSayi == 1)
                {
                    GameManager.instance.AnlikKarakterSayisi /= GelenSayi;
                    GameManager.instance.AnlikKarakterSayisi++;
                }
                else if (GameManager.instance.AnlikKarakterSayisi % GelenSayi == 2)
                {
                    GameManager.instance.AnlikKarakterSayisi /= GelenSayi;
                    GameManager.instance.AnlikKarakterSayisi += 2;
                }




            }

        }

    }


    public class BellekYonetim
    {

        public void VeriKaydet_String(string Key,string value)
        {
            PlayerPrefs.SetString(Key, value);
            PlayerPrefs.Save();
        }
        public void VeriKaydet_int(string Key, int value)
        {
            PlayerPrefs.SetInt(Key, value);
            PlayerPrefs.Save();
        }
        public void VeriKaydet_float(string Key, float value) 
        {
            PlayerPrefs.SetFloat(Key, value);
            PlayerPrefs.Save();
        }
   
    
    public string VeriOku_s(string Key)
        {
           return  PlayerPrefs.GetString(Key);
        }
        public int VeriOku_i(string Key)
        {
            return PlayerPrefs.GetInt(Key);
        }

        public float VeriOku_f(string Key)
        {
            return PlayerPrefs.GetFloat(Key);
        }
    }



}



