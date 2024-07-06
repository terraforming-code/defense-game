using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour
{

    public static Action<Enemy> OnEnemykilled;
    public static Action<Enemy> OnEnenemyHit;

    [SerializeField] private GameObject healthBarPrefab;
    [SerializeField] private Transform barPosition;
    [SerializeField] private GameObject healthBarPrefab2;
    [SerializeField] private float initialHealth = 10f;
    [SerializeField] private float maxHelath = 10f;

    public float CurrentHealth;

    private Enemy _enemy;
    // private Image _healthBar;

    // Start is called before the first frame update
    void Start()
    {
        CreateHealthBar();
        CurrentHealth = initialHealth;
        _enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            DealDamage(5f);
        }
        // _healthBar.fillAmount = Mathf.Lerp(_healthBar.fillAmount, 0,);
    }

    private void CreateHealthBar()
    {
        
    }

    private void DealDamage(float damageReceived)
    {
        CurrentHealth -= damageReceived;
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Die();
        }
        else{
            OnEnenemyHit?.Invoke(_enemy);
        }
    }

    private void Die()
    {

    }
}
