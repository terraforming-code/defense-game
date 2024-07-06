using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 1;
    [SerializeField] private int DeathCoinReward = 1;    
    [SerializeField] private Waypoint Waypoint;    

    private int _currentWaypointIndex = 0;
    private Vector3 CurrentPointPosition;
    private Vector3 _lastPointPosition;
    private SpriteRenderer _spriteRenderer;

    public UnityEvent OnEndReached => _onEndReached;
    private static UnityEvent _onEndReached;
    
    void Start()
    {
        // print($"Enemy.Start.CurrentPointPosition:{Waypoint.GetWayPointPosition(_currentWaypointIndex)}");
        CurrentPointPosition = Waypoint.GetWayPointPosition(_currentWaypointIndex);
        _lastPointPosition = CurrentPointPosition;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (CurrentPointPositionReached())
        {
            UpdateCurrentPointIndex();
            Rotate();
        }        
    }
    
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, CurrentPointPosition, MoveSpeed*Time.deltaTime);
    }

    private void Rotate()
    {
        if (CurrentPointPosition.x > _lastPointPosition.x)
        {
            _spriteRenderer.flipX = false;
        }
        else
        {
            _spriteRenderer.flipX = true;
        }
    }

    private bool CurrentPointPositionReached()
    {
        float distanceToNextPointPosition = (transform.position - CurrentPointPosition).magnitude;
        if(distanceToNextPointPosition < 0.1f)
        {
            _lastPointPosition = transform.position;
            return true;
        }

        return false;
    }

    private void UpdateCurrentPointIndex()
    {
        print(Waypoint.Points.Length);
        int lastWaypointIndex = Waypoint.Points.Length - 1;
        if(_currentWaypointIndex < lastWaypointIndex)
        {
            _currentWaypointIndex++;
            CurrentPointPosition = Waypoint.GetWayPointPosition(_currentWaypointIndex);
        }
        else
        {
            EndPointReached();
        }
    }

    private void EndPointReached()
    {
        OnEndReached?.Invoke();
        // _enenmyHealth.ResetHealth();
        ObjectPooler.ReturnToPool(gameObject);
    }
}
