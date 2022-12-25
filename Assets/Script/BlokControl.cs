using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlokType { Toplama, Cikarma, Carpma, Bolme}

public class BlokControl : MonoBehaviour
{
    [SerializeField] BlokType blokType = BlokType.Toplama; //Default
    [SerializeField] int value = 0;

    [SerializeField] Collider otherCollider;

    [SerializeField] TMPro.TMP_Text blokText;

    private void OnValidate()
    {
        transform.name = blokType.ToString() + " " + value;
        blokText.text = blokType == BlokType.Toplama ? "+" + value : (blokType == BlokType.Cikarma ? "-" + value : (blokType == BlokType.Carpma ? "x" + value : "/" + value));
    }

    public void OnTrigger()
    {
        otherCollider.enabled = false;
    }

    public int GetValue()
    {
        return value;
    }

    public string GetBlokType()
    {
        return blokType.ToString();
    }
}
