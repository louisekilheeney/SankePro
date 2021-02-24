using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public int speed;
    public int level;
    private int bodyCount;
    public Rigidbody2D rb;
    private Vector2 movement = Vector2.right;
    private int snakeSize;
    private List<Vector2> sankePastPositionList;
    

    // Start is called before the first frame update
    void Start()
    {
        if (speed == 0) {
            speed = 1;
        }
        bodyCount = 0;

        // Move the Snake every 300ms
        InvokeRepeating("Move", 0.3f, 0.3f);
        sankePastPositionList = new List<Vector2>();
        snakeSize = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (movement.y != -speed)
            {
                movement.y = speed;
                movement.x = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (movement.y != +speed)
            {
                movement.y = -speed;
                movement.x = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (movement.x != -speed)
            {
                movement.x = speed;
                movement.y = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(movement.x != +speed)
            movement.x = -speed;
            movement.y = 0;
        }
    }

    void Move()
    {
        sankePastPositionList.Insert(0, rb.position); //current postion
        if (sankePastPositionList.Count >= snakeSize + 1)
        {
            sankePastPositionList.RemoveAt(sankePastPositionList.Count - 1);
        }

        // Move head into new direction
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(movement) - 90);
      

    }

    private float GetAngleFromVector(Vector2 dir) {
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }
}
 




