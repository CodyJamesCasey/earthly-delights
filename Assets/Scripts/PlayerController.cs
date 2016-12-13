using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
  [Tooltip("The initial force added to the arrow, when it is fired")]
  public float projectileLaunchForce;

  [Tooltip("The speed in which the bow pivots")]
  public float pivotSpeed;

  public float speed;
  public float tilt;

  public GameObject arrow;
  public Transform shotSpawn;
  public float fireRate;

  private float nextFire, pivotDirection = 1f;;

  void Update ()
  {
    transform.RotateAround(Vector3.zero, Vector3.up*pivotDirection, pivotSpeed * Time.deltaTime);
    if (Input.GetButton("Fire1") && Time.time > nextFire)
    {
      nextFire = Time.time + fireRate;
      GameObject projectile = Instantiate(arrow, shotSpawn.position, shotSpawn.rotation) as GameObject;

      // assigns the newly Instantiated arrow GameObject to be a child of the "Shot Spawn" GameObject
      projectile.transform.parent = shotSpawn;

      LaunchArrow(projectile);
    }
  }
    // Function Launches the arrow in the direction of the 'X' axis, relative to the "Shot Spawn" GameObject
    void LaunchArrow (GameObject launchingArrow)
    {
        Rigidbody2D arrowRB = launchingArrow.GetComponent<Rigidbody2D>();
        arrowRB.AddForce(launchingArrow.transform.TransformDirection(Vector3.right*projectileLaunchForce));
    }

    void ChangePivotDirection ()
    {
      pivotDirection = -pivotDirection;
    }
}
