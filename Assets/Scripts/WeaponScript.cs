using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponScript : MonoBehaviour
{
    public TextMeshProUGUI ammoDisplay;

    [SerializeField] private float _shootRange = 300f;
    [SerializeField] private ParticleSystem _muzzleFlashFX;
    [SerializeField] private GameObject _hitImpactEffect;

    [SerializeField] private AudioClip _shootAudio;
    private AudioSource _audioSource;

    [SerializeField] private Camera _fpCamera;
    private float _normalFOV = 60.0f;
    private float _zoomedFOV = 25.0f;

    [SerializeField]private int _currentAmmo;
    private int _maxAmmo = 50;

    private bool _isReload = false;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _currentAmmo = _maxAmmo;
    }

    void Update()
    {
        ammoDisplay.text = _currentAmmo.ToString();
        
        if (_isReload)
        {
            return;
        }

        Shoot();
        ZoomWeapon();
        ReloadButton();
    }

    private void ReloadButton()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(WeaponReload());
        }
        else
        {
            _isReload = false;
        }
    }

    private void Shoot()
    {
        if (Input.GetButton("Fire1") && 0<_currentAmmo)
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

    private void ZoomWeapon()
    {
        if (Input.GetButton("Fire2"))
        {
            _fpCamera.fieldOfView = _zoomedFOV;
        }
        else
        {
            _fpCamera.fieldOfView = _normalFOV;
        }
    }

    private void PlayerShoot()
    {
        _currentAmmo--;
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

    private IEnumerator WeaponReload()
    {
        _isReload = true;
        yield return new WaitForSeconds(1.25f);
        _currentAmmo = _maxAmmo;
        _isReload = false;
    }
}