using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visibility : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private void Awake()
    {
        //meshRenderer = GetComponent<MeshRenderer>();
        //meshRenderer.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        //meshRenderer.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        //meshRenderer.enabled = false;
    }
}
