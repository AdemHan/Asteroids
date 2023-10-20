using UnityEngine;

public class Player : MonoBehaviour
{
    public Bullet bulletPrefab; 

    public float thrustSpeed = 1.0f;   //itme hizi

    public float turnSpeed = 1.0f;     //Donme hizi

    private Rigidbody2D _rigidbody;

    private bool _thrusting;    //itme 

    private float _turnDirections;  //donus yonu

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();       //Scriptin bagli olduðu objenin Rigidbody2d bilgisini _rigidnody degiskenimize atýyoruz
    }

    private void Update()
    {
        _thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);  // w veya yukari ok yonune basilirsa _thrusting = 0 olur

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))     //Sol ok veya A tusuna basilirsa 
        {
            _turnDirections = 1.0f;     //kuvvet eklendiginde sola dogru donmesi icin 1 verdik
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))       //Sag ok veya D tusuna basilirsa 
        {
            _turnDirections = -1.0f;    //kuvvet eklendiginde saga dogru donmesi icin -1 verdik
        }
        else
        {
            _turnDirections = 0.0f;     //hicbir tusa basilmazsa donme hareketi olmayacak
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        if (_thrusting) // bir degerle kontrol etmememizin nedeni bool deger eger 1 ise calisacak olmasidir. Yani parantez icine _thrusting == 1 yazmakla ayni anlama gelir
        {
            _rigidbody.AddForce(this.transform.up * thrustSpeed);   //yukari yönde, thrustSpeed in sahip olduðu degerle kuvvet uyguladik
        }

        if (_turnDirections != 0)   //donus yonu 0 dan farklýysa 
        {
            _rigidbody.AddTorque(_turnDirections * turnSpeed);      //donus yonu ve donus hýzý carpýlýyor, o yonde ve hýzda tork uygulanýyor
        }
    }

    private void Shoot()    //ates etme fonksiyonu
    {
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);   //bullet isimli degiskenin klonunu yaratmak iscin istenen degiskenleri girdik.(hangi nesneyi, hangi pozisyonda, hangi rotasyonda)
        bullet.Project(this.transform.up);  //bullet nesnesinin bilgisini Project fonksiyonunda yerine koyduk
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = 0.0f;

            this.gameObject.SetActive(false);
            FindObjectOfType<GameManager>().PlayerDied();
        }
    }
}
