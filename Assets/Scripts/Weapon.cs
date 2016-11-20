using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
public class Weapon : MonoBehaviour {
  public int Ammo;
  public int MaxAmmo;
  public int ClipSize;
  public float FireRate;
  public bool InfiniteAmmo;
  public LayerMask Mask;
  public Transform PlayerCamera;
  //public Projectile ProjectilePrefab;
  public Renderer MuzzleFlash;

  float nextShot;
  AudioSource fireSound;

  public void RefillAmmo(int amount) {
    Ammo += amount;

    if(Ammo > MaxAmmo){
      Ammo = MaxAmmo;
    }

    nextShot = 0f;
  }
  
  public void Fire() {
    if(nextShot < Time.time) {
      RaycastHit hit;

      if(Physics.Raycast(PlayerCamera.position, PlayerCamera.forward, out hit, 20f, Mask)) {
        Target target = hit.collider.GetComponent<Target>();
        if(target != null) {
          target.OnHit();
        }
      }

      StartCoroutine(Flash());
      fireSound.PlayOneShot(fireSound.clip);

      nextShot = Time.time + (1 / FireRate);
    }
  }

  public void Reload() {

  }

  IEnumerator Flash() {
    MuzzleFlash.enabled = true;
    
    yield return new WaitForSeconds(0.01f);

    MuzzleFlash.enabled = false;
  }

  // Use this for initialization
	void Start () {
    MuzzleFlash.enabled = false;
    fireSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
