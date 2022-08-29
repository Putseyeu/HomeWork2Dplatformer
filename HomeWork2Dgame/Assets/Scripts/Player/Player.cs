using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _pointStart;
    [SerializeField] private GameObject _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy  enemy))
        {
            _player.transform.position = _pointStart.transform.position;
        }
    }
}
