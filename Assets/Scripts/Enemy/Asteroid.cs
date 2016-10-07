using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour, IHealth
{
    private float health;
    private float damage;

    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    // Use this for initialization
	void Start ()
	{
	    Health = Config.GameConfig.ASTEROID_HEALTH;
	    Damage = Config.GameConfig.ASTEROID_DAMAGE;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("OnCollisionEnter");
        TrashMan.despawn(collision.gameObject);

        var hp = collision.gameObject.GetComponent<IPLayerHealth>();
        if (hp != null)
        {
            hp.TakeDamage(damage);
        }
    }

    public void TakeDamage(float damageTaken)
    {
        if (damageTaken > 0)
        {
            Health -= damageTaken;
            if (Health <= 0)
            {
                TrashMan.despawn(gameObject);
            }
            
        }
    }
}
