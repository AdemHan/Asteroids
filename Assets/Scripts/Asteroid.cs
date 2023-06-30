using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites;    //spritelar�m�z� tutacak olan sprite dizisini olusturduk

    public float size = 1.0f;   //boyut

    public float minSize = 0.5f;    //minimum boyut

    public float maxSize = 1.5f;    //maksimum boyut

    private SpriteRenderer _spriteRenderer;     // spritrenderer refans� olusturur

    private Rigidbody2D _rigidBody;     //rigidbody referans� olusturur

    private void Awake()    //uyand�g�nda
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();   //spriterenderer atamasi yapildi
        _rigidBody = GetComponent<Rigidbody2D>();   //rigidbody atamasi yapildi
    }

    void Start()    
    {
        _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];      //spriterenderer'in spritena, sptires dizisinden belirlenen aral�kta �retilen random degere kars�l�k gelen spirete atan�r

        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);        //rotasyonun z bile�enine random value ve 360 �n carpimindan gelecek olan sonucu atar(random.value 0 ve 1 aral�ginda ondalik bir deger dondurur
        this.transform.localScale = Vector3.one * this.size;    // new vector3(this.size, this.size, this.size) ile ayn� anlam� tasir. Girilen size degerini x,y ve z icin ayn� degerde yeniden boyutlandirir. 

        _rigidBody.mass = this.size;    //nesnenin rigidbodysinin yercekimi kuvvetine size degiskenin sahip oldugu degeri atadik
    }
}
