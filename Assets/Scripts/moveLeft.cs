using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class moveLeft : MonoBehaviour
{
    public float speed = 5f;
    Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x < startPos.x - 60)
        {
            transform.position = startPos;
        }
    }
}
