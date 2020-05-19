using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpExemple : MonoBehaviour
{
    [SerializeField] private Transform _a;
    [SerializeField] private Transform _b;
    [SerializeField] private Transform _target;

    [SerializeField] private float _pathTime;
    [SerializeField] private float _pathRunningTime;

    private int _index;

    private void Update()
    {
        _pathRunningTime += Time.deltaTime;
        _target.position = Vector3.Lerp(_a.position, _b.position, _pathRunningTime / _pathTime);

        if (_target.position == _b.position)
        {
            var newPosition = _a.position;

            _a.position = _b.position;
            _b.position = newPosition;
        }
        
    }


}
