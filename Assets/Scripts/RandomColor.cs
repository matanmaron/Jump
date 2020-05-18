using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    void Start()
    {
        float r = Random.Range(0, 1f);
        float g = Random.Range(0, 1f);
        float b = Random.Range(0, 1f);
        gameObject.GetComponent<MeshRenderer>().material.color = new Color(r, g, b);
    }
}
