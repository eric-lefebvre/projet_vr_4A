using UnityEngine;

public partial class BasketLogic : MonoBehaviour
{
    public GameEvent basketFullEvent;
    public GameEvent ballIsInBasket;
    public AudioSource scoreSound; // <--- Added this
    public int ballsNeeded = 3;
    private int currentBalls = 0;

    private void OnTriggerEnter(Collider other)
    {
        Balles ball = other.GetComponent<Balles>();

        if (ball != null && !ball.isAlreadyInBasket)
        {
            // Play the sound
            if (scoreSound != null)
            {
                scoreSound.Play();
            }

            ballIsInBasket.TriggerEvent();
            ball.isAlreadyInBasket = true;
            currentBalls++;

            Debug.Log("Unique ball added! Count: " + currentBalls);

            if (currentBalls >= ballsNeeded)
            {
                Debug.Log("Door Open");
                basketFullEvent.TriggerEvent();
            }
        }
    }
}