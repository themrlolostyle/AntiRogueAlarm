using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class AlarmHomeTrigger : MonoBehaviour
{
    [SerializeField] private float _speedChange;

    private float _nextValue;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
    }

    private void Update()
    {
        _audioSource.volume = Mathf.Lerp(_audioSource.volume, _nextValue, _speedChange * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Movement>(out Movement movement))
        {
            _nextValue = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Movement>(out Movement movement))
        {
            _nextValue = 0;
        }
    }
}
