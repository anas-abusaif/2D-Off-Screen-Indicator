using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControles : MonoBehaviour
{
    float Speed = 8f;
    void Update()
    {
        Vector2 Direction = new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime, Input.GetAxis("Vertical") * Time.deltaTime);
        transform.Translate(Direction * Speed);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -30f, 30f), Mathf.Clamp(transform.position.y, -22f, 22f));
    }
}
