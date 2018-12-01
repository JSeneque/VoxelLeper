using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public float tumblingDuration = 0.2f;

    private DropCube drop;

    void Start()
    {
        drop = GameObject.FindGameObjectWithTag("DropPoint").GetComponent<DropCube>();   
    }

    void Update()
    {
        var dir = Vector3.zero;

        //if (Input.GetKey(KeyCode.UpArrow))
        if (Input.GetAxisRaw("Vertical" ) > 0)
            dir = Vector3.forward;

        if (Input.GetAxisRaw("Vertical") < 0)
            dir = Vector3.back;

        if (Input.GetAxisRaw("Horizontal") < 0)
            dir = Vector3.left;

        if (Input.GetAxisRaw("Horizontal") > 0)
            dir = Vector3.right;

        if (dir != Vector3.zero && !isTumbling)
        {
            StartCoroutine(Tumble(dir));
        }
    }

    bool isTumbling = false;
    IEnumerator Tumble(Vector3 direction)
    {
        isTumbling = true;

        var rotAxis = Vector3.Cross(Vector3.up, direction);
        var pivot = (transform.position + Vector3.down * 0.5f) + direction * 0.5f;

        var startRotation = transform.rotation;
        var endRotation = Quaternion.AngleAxis(90.0f, rotAxis) * startRotation;

        var startPosition = transform.position;
        var endPosition = transform.position + direction;

        var rotSpeed = 90.0f / tumblingDuration;
        var t = 0.0f;

        while (t < tumblingDuration)
        {
            t += Time.deltaTime;
            if (t < tumblingDuration)
            {
                transform.RotateAround(pivot, rotAxis, rotSpeed * Time.deltaTime);
                yield return null;
            }
            else
            {
                transform.rotation = endRotation;
                transform.position = endPosition;
            }
        }

        isTumbling = false;

        // drop a piece of the player behind
        drop.Spawn();
    }
}
