using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxFollow : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed, 0, Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed);
    }
}
