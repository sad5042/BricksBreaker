using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    static public Ball Instance { get; set; }
    public Rigidbody2D rigBody;
    public bool isShoot;

    private void Awake()
    {
        Instance = this;
        isShoot = false;
        rigBody = transform.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isShoot)
        {
            transform.SetParent(GameObject.Find("GameObjects").transform);
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonUp(0)) Move(mousePos);
        }
    }

    private void Move(Vector3 mousePos)
    {
        isShoot = false;
        Player.Instance.isMove = true;
        rigBody.AddForce(new Vector3(mousePos.x, mousePos.y, 0) * 1.5f, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.transform.name);
        if (collision.transform.tag == "DeadZone") Player.Instance.Hurt();
    }
}
