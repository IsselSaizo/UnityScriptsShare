using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] int _damage;
    [SerializeField] int _periodicalDamage;
    [SerializeField] int _moveSpeed;
    [SerializeField] float _moveTime;
    [SerializeField] Animator l_Animator;
    float CurrentTimer;

    public bool _reverse = false;
    bool IsOn = false;

    private void Start()
    {
        RefreshTimer();
    }

    private void Update()
    {
        Straight();
        Reverse();
        if(IsOn)
        {
            CurrentTimer -= Time.deltaTime;
            if(CurrentTimer < 0)
            {
                IsOn = false;
                RefreshTimer();
            }
        }
    }

    private void RefreshTimer()
    {
        CurrentTimer = _moveTime;
    }

    private void Straight()
    {
        if (_reverse || IsOn) return;
        SendToAnim();
        ChangeStates();
    }

    private void Reverse()
    {
        if (!_reverse || IsOn) return;
        SendToAnim();
        ChangeStates();
    }

    private void ChangeStates()
    {
        _reverse = !_reverse;
        IsOn = !IsOn;
    }

    private void SendToAnim()
    {
        l_Animator.SetBool("Reverse", _reverse);
        l_Animator.SetBool("IsOn", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerModifier playerModifier = other.GetComponent<PlayerModifier>();
        //ѕроверка на то, что будет наноситьс€ урон персонажу
        if (playerModifier)
        {
            StartCoroutine(playerModifier.OnTakeAnyDamage(_damage));
        }
    }

    private void OnTriggerStay(Collider other)
    {
        PlayerModifier playerModifier = other.GetComponent<PlayerModifier>();
        if (playerModifier)
        {
            StartCoroutine(playerModifier.OnTakeAnyDamage(_periodicalDamage));
        }
    }
}
