using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public int health = 64;

    public void ReduceHealth(int Amount)
    {
        health -= Amount;

        if (health < 0)
        {
            health = 0;

        } else
        {
            // decrease in size
            transform.localScale -= new Vector3(0.015f, 0.015f, 0.015f);
        }
            

        
    }

    public bool IsAlive()
    {
        return health > 0;
    }
}
