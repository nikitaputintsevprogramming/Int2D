using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public Transform ShotPrefab;

    public float ShootingRate = 0.25f;

    private float shootCoolDown;


    // Start is called before the first frame update
    void Start()
    {
        shootCoolDown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(shootCoolDown > 0)
        {
            shootCoolDown -= Time.deltaTime;
        }
    }

    public void Attack(bool isEnemy)
    {
        shootCoolDown = ShootingRate;

        var shotTransform = Instantiate(ShotPrefab) as Transform;

        shotTransform.position = transform.position;

        ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();

        if (shot != null)
        {
            shot.isEnemyShot = isEnemy;
        }
        MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();

        if(move != null)
        {
            move.direction = this.transform.right;
        }
    }

    public bool CanAttack
    {
        get
        {
            return shootCoolDown <= 0f;
        }
    }
}
