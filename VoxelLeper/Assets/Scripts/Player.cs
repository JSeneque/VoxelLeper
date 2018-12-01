using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public int health = 64;
    public Text healthTextUI;

    private void Start()
    {
        // maybe put this somewhere better to manage UI updates
        DisplayHealth();
    }

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

        DisplayHealth();

    }

    public bool IsAlive()
    {
        return health > 0;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Killzone")
        {
            Destroy(gameObject);
        }
    }

    private void DisplayHealth()
    {
        healthTextUI.text = "Health: " + health.ToString();
    }
}
