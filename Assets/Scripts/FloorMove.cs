using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMove : MonoBehaviour
{
    float FallSpeed = 0;
    bool touched = false;
    void FixedUpdate()
    {
        transform.position += Vector3.down * FallSpeed;
    }
    void Start()
    {
        FallSpeed = GameManager.Instance.FallSpeed;
        Destroy(gameObject, 6f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!touched && collision.gameObject.tag == "Player")
        {
            touched = true;
            GameManager.Instance.LevelUp();
        }
    }
}
