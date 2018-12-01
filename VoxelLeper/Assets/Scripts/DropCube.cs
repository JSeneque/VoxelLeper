using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCube : MonoBehaviour {
    public GameObject cube;
    public int ReduceHealthAmount = 1;

    private Player player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    public void Spawn()
    {
        if (player.IsAlive())
        {
            Instantiate(cube, transform.position + new Vector3(0.0f, 0.25f, 0.0f), Quaternion.identity);
            player.ReduceHealth(ReduceHealthAmount);
        }
        
    }
}
