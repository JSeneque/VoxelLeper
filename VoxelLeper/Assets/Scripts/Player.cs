using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    public int health = 10;
    public Text healthTextUI;

    private int startHealth;

    private void Start()
    {
        // maybe put this somewhere better to manage UI updates
        DisplayHealth();
        startHealth = health;
    }

    public void ReduceHealth(int Amount)
    {
        health -= Amount;

        if (health <= 0)
        {
            health = 0;

            // reload scene
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene, LoadSceneMode.Single);

        } else
        {
            // shrink the player each move
            transform.localScale -= new Vector3(transform.localScale.x / startHealth, transform.localScale.y / startHealth, transform.localScale.z / startHealth);
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
