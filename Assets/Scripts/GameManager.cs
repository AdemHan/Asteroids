using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;

    public ParticleSystem explosion;

    public float respawneTime = 3.0f;

    public int lives = 3;

    public float respawneInvulnerabilityTime = 3.0f;                                                //yeniden dogdugunda carpismayacagi sure


    public void AsteroidDestroyed(Asteroid asteroid)                                                //Asteroid yok oldugunda
    {
        this.explosion.transform.position = asteroid.transform.position;                            //patlama efektinin konumunu asteroidin konumuna esitle
        this.explosion.Play();                                                                      //efekti oynat
    }

    public void PlayerDied()                                                                        //oyuncu oldugunde
    {
        this.explosion.transform.position = this.player.transform.position;                         //patlama efektinin konumunu asteroidin konumuna esitle
        this.explosion.Play();                                                                      //efekti oynat

        this.lives--;                                                                               //caný bir azalt

        if (this.lives <= 0)                                                                        //can 0 a esit ve 0 ýn altinda ise
        {
            GameOver();                                                                             //oyun biter
        }
        else
        {
            Invoke(nameof(Respawne), this.respawneTime);                                            //degilse yeniden canlandirir, belirtilen süre sonra
        }
    }
    
    private void Respawne()                                                                         //yeniden canlanma
    {
        this.player.transform.position = Vector3.zero;                                              //oyuncunun pozisyonu sifirlanir
        this.player.gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");                  //oyuncunun layerý degistirilir ve boylece carpismasi kapatilmis olur
        this.player.gameObject.SetActive(true);                                                     //oyuncu sahneye tekrar gelir

        Invoke(nameof(TurnOnCollisions), respawneInvulnerabilityTime);                              //TurnOnCollisions uyandýrýlýr, belirlenen süre sonra
    }

    private void TurnOnCollisions()                                                                 //carpisma ozelligini acma
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");                             //oyuncunun layer özelliði player ile degistirilir
    }

    private void GameOver()
    {
                                                                                                    //yazilacak
    }
}
