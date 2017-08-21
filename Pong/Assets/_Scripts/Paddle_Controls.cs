using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle_Controls : MonoBehaviour {

    public float speed = 8f;
    public string axis = "Horizontal";

    private void FixedUpdate()
    {
        float input = Input.GetAxisRaw(axis);
        transform.Translate(Vector2.up * input * speed * Time.fixedDeltaTime);
    }
}
