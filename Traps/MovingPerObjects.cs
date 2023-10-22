using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPerObjects : MonoBehaviour
{
    [SerializeField] GameObject[] _waypoints; //“очки, по которым будет перемещатьс€ объект
    [SerializeField] float _speed;
    [SerializeField] float _timerWait = 0f;
    [SerializeField] bool _isDavilka = false;

    public AudioSource _downHit;

    int currentTarget = 0;                    //“екущий таргет
    bool isDown = false;
    float timerWait;
    float waypointRadius = 0.5f;             //–ассто€ние, на котором засчитываетс€ то, что мы дошли до точки

    private void Update()
    {
        // проверка на то, что мы доехали до точки и зацикленное движение между ними
        if (Vector3.Distance(_waypoints[currentTarget].transform.position, transform.position) < waypointRadius)
        {
            currentTarget++;
            if (currentTarget >= _waypoints.Length)
            {
                currentTarget = 0;
                if (_isDavilka)
                {
                    isDown = true;
                    _downHit.Play();
                }
            }
        }

        if(isDown)
        {
            timerWait -= 1 * Time.deltaTime;
            if(timerWait < 0 )
            {
                isDown = false;
                timerWait = _timerWait;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _waypoints[currentTarget].transform.position, _speed * Time.deltaTime);
        }

    }
}
