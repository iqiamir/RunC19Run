using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject uiText;
    public int currentGold;
    [SerializeField]private Animator jetpack;

    void Start()
    {
       jetpack = GetComponent<Animator>();
       uiText.SetActive(false);
    }
    public void AddGold(int goldToAdd)
    {
        currentGold += goldToAdd;

    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(currentGold == 3)
            {
                jetpack.SetBool("isCollect", true);
                Debug.Log("3 stars collected!");
            }
        }
    }
    */

    void Update()
    {
        if (currentGold == 3)
        {
            uiText.SetActive(true);
            jetpack.SetBool("isCollect", true);
            Debug.Log("3 stars collected!");
        }
        else
        {
            jetpack.SetBool("isCollect", false);
        }
    }
}
