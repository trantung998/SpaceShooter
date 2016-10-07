using UnityEngine;
using System.Collections;

public class Bolt : MonoBehaviour {
    [SerializeField]
    float speed;
    float damage;

    public float Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }

    Rigidbody _rigidbd;

    // Use this for initialization
    void Start()
    {
        Damage = Config.GameConfig.MAIN_GUN_DAMAGE;
        _rigidbd = GetComponent<Rigidbody>();
        _rigidbd.velocity = Config.GameConfig.BULLET_SPEED * transform.forward;
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("OnCollisionEnter");
        
        var hp = collision.gameObject.GetComponent<IHealth>();
        if (hp != null)
        {
            hp.TakeDamage(damage);
        }
    }
}
