using UnityEngine;
using UnityEngine.UI;

public class SteelBonus : BonusBase
{
  public override void BonusActivate()
  {
    print("BONUS STEEL ACTIVATE");

    GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
    if (balls == null) return;
    for (int i = 0; i < balls.Length; i++)
    {
      balls[i].GetComponent<BallScript>().damage = 40;
      SpriteRenderer sprite = balls[i].GetComponent<SpriteRenderer>();
      sprite.color = Color.gray;
    }
  }
}