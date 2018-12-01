using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCube : MonoBehaviour {
    public GameObject cube;


    public void Spawn()
    {
        Instantiate(cube, transform.position, Quaternion.identity);
    }
}
