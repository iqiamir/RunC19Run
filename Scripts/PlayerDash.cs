using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    PlayerController moveScript;

    public float dashSpeed;
    public float dashTime;

    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;

        while(Time.time < startTime + dashTime)
        {
            transform.Translate(Vector3.forward * dashSpeed);

            yield return null;
        }
    }
}
