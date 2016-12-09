using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
  public float speed;
  public float tilt;

  public GameObject arrow;
  public Transform shotSpawn;
  public float fireRate;

  private float nextFire;

  void Update ()
  {
    if (Input.GetButton("Fire1") && Time.time > nextFire) 
    {
      nextFire = Time.time + fireRate;
      Instantiate(arrow, shotSpawn.position, shotSpawn.rotation);
    }
  }
}
