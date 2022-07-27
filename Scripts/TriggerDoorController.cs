using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;

    [SerializeField] private bool LevelOneTrigger = false;
    [SerializeField] private bool LevelTwoTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (LevelOneTrigger)
            {
                myDoor.Play("Bottle", 0, 0.0f);
                gameObject.SetActive(false);
            }

            else if (LevelTwoTrigger)
            {
                myDoor.Play("openMouth", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }
}
