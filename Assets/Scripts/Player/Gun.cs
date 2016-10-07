using UnityEngine;
using System.Collections;

public abstract class Gun : MonoBehaviour {
    //[SerializeField]
    protected float fireRate = Config.GameConfig.MAIN_GUN_FIRE_RATE;
    [SerializeField]
    protected GameObject bulletPrefap;

    protected float nextFire;

    abstract public void Fire();

    void Start()
    {
        TrashMan.recycleBinForGameObject(bulletPrefap).onSpawnedEvent += go => Debug.Log("spawned object: " + go);
        TrashMan.recycleBinForGameObject(bulletPrefap).onDespawnedEvent += go => Debug.Log("DEspawned object: " + go);
    }
}
