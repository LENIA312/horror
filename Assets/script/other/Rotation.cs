using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeReference]float rotateX, rotateY, rotateZ;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateX,rotateY,rotateZ);
    }
}
