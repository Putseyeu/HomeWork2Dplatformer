using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private Transform _pointOne;
    [SerializeField] private Transform _pointTwo;
    [SerializeField] private float _speed;

    private Transform _target;
    private bool _facingRight = true;

    private void Start()
    {
        _target = _pointOne;
    }

    private void Update()
    {        
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        if (transform.position == _target.position)
        {
            if (_target == _pointOne)
            {
                Flip();
                _target = _pointTwo;
            }
            else
            {
                Flip();
                _target = _pointOne;
            }           
        }
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
