using System.Collections;
using System.Collections.Generic;
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
        var blocksArray = GameObject.FindGameObjectsWithTag("Block");

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
        var blocksArray = GameObject.FindGameObjectsWithTag("Block");
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
        hitsToDestroy--;
        if (hitsToDestroy == 0)
        {
            Destroy(gameObject);
            playerScript.BlockDestroyed(points);
        }
        else if (textComponent != null)
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
            else
            {
                textComponent.text = hitsToDestroy.ToString();
            }
        }
    }
}
