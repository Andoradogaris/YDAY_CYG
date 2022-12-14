using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private float damage = 50f;
    [SerializeField]
    private float range = 1000f;
    public int actualAmmoInLoader;
    [SerializeField]
    private int maxAmmoInLoader;
    public int totalAmmo;

    [SerializeField]
    private float shootTime;
    [SerializeField]
    private float reloadTime;

    [SerializeField]
    private bool canFire;

    [SerializeField]
    private Camera fpsCam;

    [SerializeField]
    private GameObject muzzleFlash;
    [SerializeField]
    private ParticleSystem muzzle;

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.UpdateAmmo(actualAmmoInLoader, totalAmmo);
    }

    void Update()
    {
        if(actualAmmoInLoader > 0 && !gameManager.isShooting && !gameManager.isReloading && !gameManager.isDead)
        {
            canFire = true;
        }
        else
        {
            canFire = false;
        }

        if (Input.GetButtonDown("Fire1") && canFire)
        {
            Shoot();
            StartCoroutine(ShootCoroutine());
        }
        else if (((Input.GetButtonDown("Fire1") && !canFire && !gameManager.isShooting) || Input.GetKeyDown(KeyCode.R)) && totalAmmo != 0 && actualAmmoInLoader < maxAmmoInLoader)
        {
            StartCoroutine(ReloadCoroutine());
        }
    }

    void Shoot()
    {
        actualAmmoInLoader--;
        Instantiate(muzzle, muzzleFlash.transform.position, muzzleFlash.transform.rotation);

        RaycastHit hit;
        int mask = 1 << LayerMask.NameToLayer("Alien");
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, ~(LayerMask.NameToLayer("Ignore Raycast"))))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Alien"))
            {
                IAController_V2 iaController = hit.transform.GetComponent<IAController_V2>();
                if (iaController != null)
                {
                    iaController.TakeDamage(damage);
                }
            }
        }
        gameManager.UpdateAmmo(actualAmmoInLoader, totalAmmo);
    }

    void Reload()
    {
        if(maxAmmoInLoader <= totalAmmo)
        {
            totalAmmo -= maxAmmoInLoader - actualAmmoInLoader;
            actualAmmoInLoader = maxAmmoInLoader;
        }
        else
        {
            if(actualAmmoInLoader + totalAmmo <= maxAmmoInLoader)
            {
                actualAmmoInLoader += totalAmmo;
                totalAmmo -= totalAmmo;
            }
            else
            {
                totalAmmo -= maxAmmoInLoader - actualAmmoInLoader;
                actualAmmoInLoader += maxAmmoInLoader - actualAmmoInLoader;
            }

        }
        gameManager.UpdateAmmo(actualAmmoInLoader, totalAmmo);
    }

    public void GetAmmo(int ammoToAdd)
    {
        totalAmmo += ammoToAdd;
        gameManager.UpdateAmmo(actualAmmoInLoader, totalAmmo);
    }

    IEnumerator ShootCoroutine()
    {
        gameManager.isShooting = true;
        yield return new WaitForSeconds(shootTime);
        gameManager.isShooting = false;
    }

    IEnumerator ReloadCoroutine()
    {
        gameManager.isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        Reload();
        gameManager.isReloading = false;
    }
}
