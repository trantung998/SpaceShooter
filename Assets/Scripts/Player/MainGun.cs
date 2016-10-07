using UnityEngine;
using System.Collections;
using System;

public class MainGun : Gun {

    public override void Fire()
    {
        var bullet = TrashMan.spawn(bulletPrefap, this.transform.position, this.transform.rotation);
        TrashMan.despawnAfterDelay(bullet, 2.0f);
    }

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    if (!(Time.time > nextFire)) return;

	    nextFire = Time.time + fireRate;
	    Fire();
	}


}
