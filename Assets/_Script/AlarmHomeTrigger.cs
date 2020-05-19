using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlarmHomeTrigger : MonoBehaviour
{
    [SerializeField] private float _volumeSpeed;

    private float _helpVolumeSpeed;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
    }

    private void Update()
    {
        _audioSource.volume += _helpVolumeSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Movement>(out Movement movement))
        {
            _helpVolumeSpeed = _volumeSpeed;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Movement>(out Movement movement))
        {
            _helpVolumeSpeed = -_volumeSpeed;
        }
    }
}
