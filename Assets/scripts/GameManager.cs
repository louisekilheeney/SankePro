using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject FoodPrefab;

    public Transform BorderTop;
    public Transform BorderBottom;
    public Transform BorderLeft;
    public Transform BorderRight;
    // Did the snake eat something?
    bool ate = false;
    Vector2 pos;

 
    void Start()
    {
        InvokeRepeating("Spawn", 3, 4);

    }

    void Spawn()
    {
    
        pos.x = Random.Range(BorderLeft.position.x + 5, BorderRight.position.x - 5);

        pos.y = Random.Range(BorderBottom.position.y + 5, BorderTop.position.y - 5);

        Instantiate(FoodPrefab, pos, Quaternion.identity);

    }
}
