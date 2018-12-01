using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public enum CharacterAnimation { Idle, Bobbing };

    public CharacterAnimation charAnim;

    float originalY;

    public float floatStrength = 1;
    public float speed;


    void Start()
    {
        this.originalY = this.transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x,
            originalY + ((float)Mathf.Sin(Time.time * speed) * floatStrength),
            transform.position.z);
    }
}

