using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;

    float x;
    float y;

    float bottomLimit;
    float topLimit;
    float rightLimit;
    float leftLimit;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer render = GetComponent<SpriteRenderer>();

        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(Vector3.zero);
        bottomLimit = bottomLeft.y;
        leftLimit = bottomLeft.x;

        Vector3 topRight = Camera.main.ViewportToWorldPoint(Vector3.one);
        topLimit = topRight.y;
        rightLimit = topRight.x;

        bottomLimit += render.bounds.extents.y;
        topLimit += render.bounds.extents.y;
        leftLimit += render.bounds.extents.y;
        rightLimit += render.bounds.extents.y;
    }
    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        //transform.position += new Vector3(x, y, 0f) * speed * Time.deltaTime;

        //rb.velocity = new Vector2(x, y) * speed;
    }

    private void FixedUpdate()
    {

        Vector3 desiredPosition = transform.position + new Vector3(x, y, 0f) * speed * Time.fixedDeltaTime;

        //Vector3 topRigh = Camera.main.ViewportToWorldPoint(Vector3.one);
        //float topLimit = bottomLeft.y;
        //float rightLimit = bottomLeft.x;

        desiredPosition.x = Mathf.Clamp(desiredPosition.x, leftLimit, rightLimit);

        //if (desiredPosition.x < leftLimit)
        //    desiredPosition.x = leftLimit;
        //else if (desiredPosition.x > rightLimit)
        //    desiredPosition.x = rightLimit;

        //if (desiredPosition.y < bottomLimit)
        //    desiredPosition.y = bottomLimit;
        //else if (desiredPosition.y > topLimit)
        //    desiredPosition.y = topLimit;

        desiredPosition.y = Mathf.Clamp(desiredPosition.y, bottomLimit, topLimit);



        rb.MovePosition(desiredPosition);

        //rb.MovePosition(transform.position + new Vector3(x, y, 0f) * speed * Time.fixedDeltaTime);
    }
}
