using UnityEngine;
using UnityEngine.UI;

public class FireBonus : BonusBase
{
    public override void BonusActivate()
    {
        print("BONUS FIRE ACTIVATE");

        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        if (balls == null) return;

        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].GetComponent<BallScript>().damage = 4;
            SpriteRenderer sprite = balls[i].GetComponent<SpriteRenderer>();
            sprite.color = new Color(1.0f, 0.64f, 0.0f);
        }
    }
}
