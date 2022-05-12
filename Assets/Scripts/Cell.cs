using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    int lives = 1;

    private void Start()
    {
        if (transform.tag == "Brick") lives = 3;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Ball")
        {
            if (transform.tag == "Bonus") Player.Instance.Bonus();
            lives--;
            if (lives == 0) Destroy(transform.gameObject);
        }
    }
}
