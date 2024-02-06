using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public int startLife = 10;
    private int _currentLife;

    public bool _destroyOnKill = false;

    private bool _isDead = false;


    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _isDead = false;
        _currentLife = startLife;
    }

    public void Damage(int damage)
    {
        if (_isDead) return;

        _currentLife -= damage;

        if(_currentLife <= 0)
        {
            Kill();
        }
    }


    private void Kill()
    {
        _isDead = true;

        if (_destroyOnKill)
        {
            Destroy(gameObject);
        }
    }
}
