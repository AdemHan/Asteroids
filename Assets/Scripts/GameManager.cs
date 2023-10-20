using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;

    public float respawneTime = 3.0f;

    public int lives = 3;

    public float respawneInvulnerabilityTime = 3.0f;    //yeniden dogdugunda carpismayacagi sure

    public void PlayerDied()
    {
        this.lives--;

        if (this.lives <= 0)
        {
            GameOver();
        }
        else
        {
            Invoke(nameof(Respawne), this.respawneTime);
        }
    }
    
    private void Respawne()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
        this.player.gameObject.SetActive(true);

        Invoke(nameof(TurnOnCollisions), respawneInvulnerabilityTime);
    }

    private void TurnOnCollisions()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver()
    {
        //yazilacak
    }
}
