using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    [SerializeField] SO_Shooter shooter;

    float shootDelay;

        SpriteRenderer spriteRenderer;

    [SerializeField] PlayerController player;

    bool isFireing = false;

    bool lookingRight = true;

    [SerializeField] Transform bulletSpawnPoint;
    float currentDelay = 0.0f;

    [SerializeField] List<SO_Clip> laserShotClips_;

    AudioManager audioManager_;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetAudioManager(AudioManager audioManager)
    {
        audioManager_ = audioManager;
    }

    void Update()
    {
        /*Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 lookDirection = lookPos - transform.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        if (!lookingRight)
        {
            angle -= 180;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else
        {
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }*/
        if (currentDelay > 0)
        {
            currentDelay -= Time.deltaTime;
        }


        if (Input.GetButtonDown("Fire1"))
        {
            isFireing = true;
        }

        if (Input.GetButton("Fire1"))
        {
            if (currentDelay <= 0)
            {
                Fire(transform, bulletSpawnPoint);
                currentDelay = shooter.Delay;
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            isFireing = false;
        }
    }

    /*public void SetNewGun(SO_Gun newGun)
    {
        shootDelay = newGun.Delay;
        spriteRenderer.sprite = newGun.Sprite;

        shooter = newGun;
    }*/

    /*public void FlipSprite(bool flip)
    {
        if (!flip)
        {
            lookingRight = true;
        }
        else
        {
            lookingRight = false;
        }
    }*/

    public void Fire(Transform transform, Transform bulletSpawnPoint)
    {
        for (int i = 0; i < shooter.Numb; i++)
        {
            GameObject laserGreen = Instantiate(shooter.PrefablaserGreen, bulletSpawnPoint);
            laserGreen.transform.parent = null;
            laserGreen.transform.localScale = Vector3.one;

            laserGreen.transform.position += (Vector3)Random.insideUnitCircle * shooter.Dispertion;

            laserGreen.GetComponent<Rigidbody2D>().velocity = transform.right * shooter.BulletSpeed;

            audioManager_.PlayWithRandomPitch(laserShotClips_[Random.Range(0, laserShotClips_.Count)]);
        }
    }
}
