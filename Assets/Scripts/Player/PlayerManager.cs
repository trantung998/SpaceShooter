using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour, IPLayerHealth
{
    private float health;

    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TakeDamage(float damage)
    {
        if (damage >= 0)
        {
            Health -= damage;
        }
    }
}
