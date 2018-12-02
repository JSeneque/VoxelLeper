using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
    public string loadNextLevel;
    public AudioClip goalReachSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            audioSource.PlayOneShot(goalReachSound);
            FindObjectOfType<SceneTransitions>().LoadScene(loadNextLevel);
        }
    }
}
