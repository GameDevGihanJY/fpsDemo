using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private float _shootRange = 300f;
    [SerializeField] private ParticleSystem _muzzleFlashFX;
    [SerializeField] private GameObject _hitImpactEffect;
    [SerializeField] private AudioClip _shootAudio;

    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            PlayerShoot();
            _muzzleFlashFX.Play();

            if (!_audioSource.isPlaying)
            {
                _audioSource.PlayOneShot(_shootAudio);
            }
        }
        else
        {
            _muzzleFlashFX.Stop();
            _audioSource.Stop();
        }
    }

    private void PlayerShoot()
    {
        RaycastHit _hitInfo;        // Variable to store raycast hit details

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out _hitInfo, _shootRange))
        { /*                      ^                               ^                             ^                 ^
                      main camera position                  fire direction                store details     max distance (ex :- 100m)
          */
            CreateHitImpact(_hitInfo);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hitInfo)
    {
        GameObject _hitImpactClone = Instantiate(_hitImpactEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
        // Instantiate hit impact effect and hit impact always face to the main camera

        Destroy(_hitImpactClone, 1f);
        // Destroy cloned hitImpactFX
    }
}
