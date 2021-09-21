using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosController : MonoBehaviour
{
    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0, 0, 0.3f);
        //Gizmos.DrawCube(transform.position, new Vector3(1, 3, 1));
        Gizmos.DrawWireCube(transform.position, this.transform.localScale);
    }
}
