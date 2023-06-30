using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites;    //spritelarýmýzý tutacak olan sprite dizisini olusturduk

    public float size = 1.0f;   //boyut

    public float minSize = 0.5f;    //minimum boyut

    public float maxSize = 1.5f;    //maksimum boyut

    private SpriteRenderer _spriteRenderer;     // spritrenderer refansý olusturur

    private Rigidbody2D _rigidBody;     //rigidbody referansý olusturur

    private void Awake()    //uyandýgýnda
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();   //spriterenderer atamasi yapildi
        _rigidBody = GetComponent<Rigidbody2D>();   //rigidbody atamasi yapildi
    }

    void Start()    
    {
        _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];      //spriterenderer'in spritena, sptires dizisinden belirlenen aralýkta üretilen random degere karsýlýk gelen spirete atanýr

        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);        //rotasyonun z bileþenine random value ve 360 ýn carpimindan gelecek olan sonucu atar(random.value 0 ve 1 aralýginda ondalik bir deger dondurur
        this.transform.localScale = Vector3.one * this.size;    // new vector3(this.size, this.size, this.size) ile ayný anlamý tasir. Girilen size degerini x,y ve z icin ayný degerde yeniden boyutlandirir. 

        _rigidBody.mass = this.size;    //nesnenin rigidbodysinin yercekimi kuvvetine size degiskenin sahip oldugu degeri atadik
    }
}
