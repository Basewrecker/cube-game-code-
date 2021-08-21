using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public Transform target; //where we want to shoot(player? mouse?)
	public Transform weaponMuzzle; //The empty game object which will be our weapon muzzle to shoot from
	public GameObject bullet; //Your set-up prefab
	public float fireRate = 3000f; //Fire every 3 seconds
	public float shootingPower = 20f; //force of projection

	private float shootingTime;

	public int health = 100;

	public GameObject deathEffect;

    private void Update()
    {
		Fire();
    }

	private void Fire()
	{
		if (Time.time > shootingTime)
		{
			shootingTime = Time.time + fireRate / 1000; //set the local var. to current time of shooting
			Vector2 myPos = new Vector2(weaponMuzzle.position.x, weaponMuzzle.position.y); //our curr position is where our muzzle points
			GameObject projectile = Instantiate(bullet, myPos, Quaternion.identity); //create our bullet
			Vector2 direction = myPos - (Vector2)target.position; //get the direction to the target
			projectile.GetComponent<Rigidbody2D>().velocity = direction * shootingPower; //shoot the bullet
		}
	}

	public void TakeDamage(int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

} 
