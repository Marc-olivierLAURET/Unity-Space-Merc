using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStat : MonoBehaviour
{
    public GameObject user;
    public GameObject bulletPrefab;
    public GameObject AudioPrefab;
    public List<GameObject> bullets = new List<GameObject>();

    public int damage = 20;
    public float fire_rate = 0.2f;
    public float reload_time = 2f;
    public float range = 40;
    public int clip_size = 12;
    public int current_clip = 12;
    public bool automatic = true;

    public bool reloading = false;

    public GameObject muzzle;

    private float cooldown_shoot;
    private float cooldown_reload;

    public AudioSource RifleRiload;

    public bool Is2HGun = true;

    void Start() {
        cooldown_shoot = Time.time;
        cooldown_reload = Time.time;
    }

    void Update() {
        bulletCleaner();
        if (reloading) {
            CheckClip();
        }
    }

    public bool Reload() {
        if (current_clip != clip_size && !reloading) {
            RifleRiload.Play(0);
            reloading = true;
            cooldown_reload = Time.time + reload_time;
            return (true);
        }
        return (false);
    }

    public bool shoot() {
        if (CheckClip() && (Time.time > cooldown_shoot)) {
            cooldown_shoot = Time.time + fire_rate;
            ShootBullet();
            return (true);
        }
        return (false);
    }

    bool CheckClip() {
        if ((current_clip == 0 && !reloading)) {
            Reload();
        }
        if (reloading) {
            if (Time.time > cooldown_reload) {
                reloading = false;
                current_clip = clip_size;
                return (true);
            }
            return (false);
        }
        return (true);
    }

    void bulletCleaner() {
        if(bullets.Count > 20) {
            GameObject bullet = bullets[0];
            Destroy(bullet);
            bullets.Remove(bullet);
        }
    }

    void ShootBullet() {
        current_clip -= 1;
        GameObject bullet = GameObject.Instantiate(bulletPrefab);
        GameObject sound = GameObject.Instantiate(AudioPrefab);
        bullet.GetComponent<bulletBehaviour>().setDamage(damage);

        Vector3 bulletRotation = user.transform.rotation.eulerAngles;
        bullet.transform.eulerAngles = bulletRotation;

        bullet.transform.position = muzzle.transform.position;
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * (range * 100));
        bullets.Add(bullet);
    }
}
