using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public Vector2 speed = new Vector2(10, 10);

    public Vector2 direction = new Vector2(1, 0);

    private Vector2 movement;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(
            speed.x * direction.x,
            speed.y * direction.y);
    }

    private void FixedUpdate()
    {
        rb.velocity = movement;
    }
}
