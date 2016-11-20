using UnityEngine;
using System.Collections;

public class WeaponFire : MonoBehaviour {

  public Weapon CurrentWeapon;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    if(Input.GetButton("Fire1")) {
      CurrentWeapon.Fire();
    }
	}
}
