using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D _rigidbody;      

    public float speed = 500.0f;    //mermi hizi

    public float maxLifetime = 10.0f;   //merminin yok olma süresi

    private void Awake()    //uyandiginda calisir
    {
        _rigidbody = GetComponent<Rigidbody2D>();   //scriptin bagli oldugu nesnenin rigidbodysini, _rigidbody isimli degiskene atar
    }

    public void Project(Vector2 direction)      //project isimli fonksiyon olusturuldu
    {
        _rigidbody.AddForce(direction * this.speed);    //_rigidbodye kuvvet uygular(girilen yonde ve belirlenen hizda)

        Destroy(this.gameObject, this.maxLifetime);     //nesneyi istenen zaman sonra yok eder
    }

    private void OnCollisionEnter2D(Collision2D collision)      //carpisma saglandiginda calisir
    {
        Destroy(this.gameObject);   //nesneyi yok eder
    }
}
