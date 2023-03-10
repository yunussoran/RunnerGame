using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform target;
    public Vector3 target_offset;
    public bool SonaGeldikMi;
    public GameObject GidecegiYer;

    void Start()
    {
        target_offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        if(!SonaGeldikMi)
        transform.position = Vector3.Lerp(transform.position, target.position + target_offset, .125f);
        else
            transform.position = Vector3.Lerp(transform.position, GidecegiYer.transform.position, .015f);

    }


}
