using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndShoot : MonoBehaviour
{
    //references for Gameobjects
    public GameObject player;
    public GameObject crosshair;
    public GameObject gun;
    public GameObject bulletPrefab;
    public GameObject shootingPoint;

    public static bool isShooting;
    
    //firerate of the gun
    public float fireRate;
    public float readyForNextShot;

    //accesing CrosshairMovement class object
    public CrosshairMovement cameraCrossHair;
   
    [SerializeField] public float bulletSpeed;

    //for crosshair's position
    private Vector3 target;

    //vector for recoil
    public Vector3 recoilMovement; 
    // private void Awake() {
    //     rigidbody2D = GetComponent<Rigidbody2D>();
    // }
    void Start()
    {
        Cursor.visible = false; 
        cameraCrossHair = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CrosshairMovement>();
        
    }
    //calling Firebullet method(Below) and using crosshairMove() to shoot on aim 
    void shootOnAim(){
        //calling crosshairMove form cameraCrossHair class
        cameraCrossHair.crosshairMove();
        target = cameraCrossHair.cameraPosition();

        //Vector to get angles on aim
        Vector3 difference = target - gun.transform.position;

        //asigning Vector values above to Euler's method
        float rotationZ = Mathf.Atan2(difference.y,difference.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0.0f,0.0f, rotationZ);

       
        //making sure that player will face same way as gun is. 
        //0.7 is value corresponding with pie/2
        if(Mathf.Abs(gun.transform.rotation.z) < 0.7){
            float scaleX = player.transform.localScale.x, scaleY=player.transform.localScale.y, scaleZ=player.transform.localScale.z;
            player.transform.localScale = new Vector3(1, scaleY, scaleZ);
    
        } else if(Mathf.Abs(gun.transform.rotation.z) > 0.7){
            float scaleX = player.transform.localScale.x, scaleY=player.transform.localScale.y, scaleZ=player.transform.localScale.z;
            player.transform.localScale = new Vector3(-1, scaleY, scaleZ);
        }

        //firing shot under this conditions
        if(Input.GetMouseButton(0) && Time.time > readyForNextShot){
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            readyForNextShot = Time.time + 1/fireRate;

        //calling FireBullet function(Below)
            FireBullet(direction, rotationZ);
            isShooting = true;
            
        }
    }
    //Method for instantiating and giving direction to bullets
    public void FireBullet(Vector2 direction, float rotationZ){
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = shootingPoint.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f,0.0f,rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        
        Destroy(b, 3);

        
    }

    
    //recoil pushing back player after every shot
    void Recoil(){
        if(isShooting){
            if(transform.localScale.x > 0)
            transform.position += recoilMovement;
            else transform.position -= recoilMovement;
            isShooting = false;
        }
    }
    
    
    void Update()
    {
        //calling methods
        shootOnAim();
        Recoil();
        
    }
    

    
        
    

    
}
