using UnityEngine;
using System.Collections;

public class EditorOnlyMaterial : MonoBehaviour {

    void Start()
    {
        GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
    }
}
