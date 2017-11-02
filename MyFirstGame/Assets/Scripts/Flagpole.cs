using System.Collections;
using UnityEngine;

public class Flagpole : Interactable {

    public Sprite flagSprite;
    private GameObject flag;
    bool flagPlanted = false;
    bool gameFinished = false;

    public override void Interact()
    {
        PlantFlag();

        if (flagPlanted && !gameFinished)
        {
            gameFinished = true;
            StartCoroutine(LevelComplete());
        }
    }

    private void PlantFlag()
    {
        if (!flagPlanted && !gameFinished)
        {
            Debug.Log("Planting Flag!");
            RemovePlayerFlag();
            CreateFlag();
            flagPlanted = true;
        }
    }

    private void CreateFlag()
    {
        //Add Gameobject
        flag = new GameObject("Flag");

        //Set position
        flag.transform.SetPositionAndRotation(new Vector3(8.949f, 0.5f, 0), new Quaternion());

        //Render Sprite
        SpriteRenderer spriteRenderer = flag.AddComponent<SpriteRenderer>() as SpriteRenderer;
        spriteRenderer.sprite = flagSprite;
    }

    private void RemovePlayerFlag()
    {
        //Get child from player
        Transform childTransform = player.GetChild(1);
        GameObject child = childTransform.gameObject;

        //Destoy child
        if (child.transform.name.Equals("DutchFlag"))
            Destroy(child);
        else
            Debug.Log("I'm not removing that child!");
    }

    private IEnumerator LevelComplete()
    {
        yield return new WaitForSecondsRealtime(3);
        Debug.Log("You won!");
    }
}
