using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdamLekesi : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Pasiflestir());
    }
    IEnumerator Pasiflestir()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
}
