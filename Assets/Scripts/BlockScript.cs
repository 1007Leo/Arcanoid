using UnityEngine;
using UnityEngine.UI;

public class BlockScript : MonoBehaviour
{
  public GameObject textObject;

  Text textComponent;
  public int hitsToDestroy;
  public int points;

  PlayerScript playerScript;
  void Start()
  {
    if (textObject != null)
    {
      textComponent = textObject.GetComponent<Text>();
      if (!textComponent.text.Equals("O"))
        textComponent.text = hitsToDestroy.ToString();
    }
    playerScript = GameObject.FindGameObjectWithTag("Player")
        .GetComponent<PlayerScript>();
  }

  bool allModBlocksIsX()
  {
    var blocksArray = GameObject.FindGameObjectsWithTag("ModBlock");

    if (blocksArray.Length == 0)
      return false;

    foreach (var block in blocksArray)
    {
      BlockScript curScript = block.gameObject.GetComponent<BlockScript>();
      if (curScript.textComponent != null && curScript.textComponent.text.Equals("O"))
      {
        return false;
      }
    }
    return true;
  }

  void deleteAllModBlocks()
  {
    var blocksArray = GameObject.FindGameObjectsWithTag("ModBlock");
    if (blocksArray.Length == 0)
      return;

    foreach (var block in blocksArray)
    {
      BlockScript curScript = block.gameObject.GetComponent<BlockScript>();
      if (curScript.textComponent != null && curScript.textComponent.text.Equals("X"))
      {
        Destroy(block.gameObject);
        playerScript.BlockDestroyed(points);
      }
    }
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    print(collision.gameObject.GetComponent<BallScript>().damage);
    hitsToDestroy -= collision.gameObject.GetComponent<BallScript>().damage;
    if (gameObject.tag.Contains("Mod"))
    {
      if (textComponent != null)
      {
        if (textComponent.text.Equals("O"))
        {
          textComponent.text = "X";
          if (allModBlocksIsX())
          {
            deleteAllModBlocks();
          }
        }
        else if (textComponent.text.Equals("X"))
        {
          textComponent.text = "O";
        }
      }
    }
    else if (hitsToDestroy <= 0)
    {
      if (gameObject.name.Contains("Green"))
      {
        int bonusType;
        if (playerScript.gameData != null)
        {
          bonusType = playerScript.gameData.getBonusType();
        }
        else
        {
          bonusType = 5;
        }
        print(bonusType);

        switch (bonusType)
        {
          case 0:
            print("NO SPAWN");
            break;
          case 1:
            print("SPAWN BASE");
            playerScript.CreateBaseBonusObject(transform.position);
            break;
          case 2:
            print("SPAWN FIRE");
            playerScript.CreateFireBonusObject(transform.position);
            break;
          case 3:
            print("SPAWN NORM");
            playerScript.CreateNormBonusObject(transform.position);
            break;
          case 4:
            print("SPAWN STEEL");
            playerScript.CreateSteelBonusObject(transform.position);
            break;
          default:
            break;
        }
      } 
      Destroy(gameObject);
      playerScript.BlockDestroyed(points);
    }
    else
    {
      if (textComponent != null)
        textComponent.text = hitsToDestroy.ToString();
    }
  }
}
