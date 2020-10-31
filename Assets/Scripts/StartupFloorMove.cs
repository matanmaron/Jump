using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupFloorMove : MonoBehaviour
{
    float FallSpeed = 0;
    bool touched = false;

    void FixedUpdate()
    {
        transform.position += Vector3.down * FallSpeed;
    }
    void Start()
    {
        StartCoroutine(FallDelay());
        Destroy(gameObject, 9f);
    }

    IEnumerator FallDelay()
    {
        yield return new WaitForSeconds(3);
        FallSpeed = GameManager.Instance.FallSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!touched && collision.gameObject.tag == "Player")
        {
            touched = true;
            GameManager.Instance.TouchLevelUp();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (gameObject.name == "Floor"  && collision.gameObject.tag == "Player")
        {
            Destroy(gameObject, 0.1f);
        }
    }
}
