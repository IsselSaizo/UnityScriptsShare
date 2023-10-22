using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] int _damage;
    [SerializeField] int _periodicalDamage = 1;
    [SerializeField] bool _canAway = false;

    private void OnTriggerEnter(Collider other)
    {
        PlayerModifier playerModifier = other.GetComponent<PlayerModifier>();
        //ѕроверка на то, что будет наноситьс€ урон персонажу
        if (playerModifier)
        {
            StartCoroutine(playerModifier.OnTakeAnyDamage(_damage));
        }
        if (_canAway)
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        PlayerModifier playerModifier = other.GetComponent<PlayerModifier>();
        //ѕроверка на то, что будет наноситьс€ урон персонажу
        if (playerModifier)
        {
            StartCoroutine(playerModifier.OnTakeAnyDamage(_periodicalDamage));
        }
    }
}