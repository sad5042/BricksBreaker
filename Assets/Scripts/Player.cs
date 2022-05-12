using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    static public Player Instance { get; set; }
    [SerializeField] int lives = 3;
    [SerializeField] GameObject deadText;
    public bool isMove;
    bool ballOn;
    [SerializeField] Text livesText;

    private void Awake()
    {
        Instance = this;
        ballOn = true;
        isMove = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(1) && ballOn)
        {
            isMove = false;
            ballOn = false;
            Ball.Instance.isShoot = true;
        }
        if (isMove)
        {
            Vector3 mosPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(Mathf.Clamp(mosPos.x, -9, 9), -11, 0);
        }
        else transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public void Hurt()
    {
        lives--;
        livesText.text = $"Lives: {lives}";
        if(lives == 0)
        {
            Ball.Instance.gameObject.SetActive(false);
            deadText.SetActive(true);
            transform.gameObject.SetActive(false);
        }
        Ball.Instance.rigBody.velocity = Vector2.zero;
        transform.position = new Vector3(0, -11, 0);
        Ball.Instance.transform.SetParent(transform);
        Ball.Instance.transform.position = new Vector3(0, -10.35f, 0);
        Ball.Instance.isShoot = false;
        isMove = true;
        ballOn = true;
    }

    public void Bonus()
    {

    }
}
