using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeathTrap : MonoBehaviour
{
    [SerializeField] GameObject HaHa;
    [SerializeField] bool IsJoke;

    private void Start()
    {
        if (HaHa != null)
        {
            HaHa.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsJoke)
        {
            HaHa.SetActive(true);
            HaHa.transform.parent = null;
        }
        Destroy(gameObject);
    }
}
