using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a chunk 
/// </summary>
public class Chunk : MonoBehaviour {

    public static Bounds? ChunkSize = null;
    Sprite sprite = null;



    Placeable currentPlaceable = null;
    

    public Placeable Placeable
    {
        get
        {
            return currentPlaceable;
        }
        set
        {
            if(currentPlaceable!=null)
            {
                Destroy(currentPlaceable.gameObject);
            }

            currentPlaceable = Instantiate(value, transform);
        }
    }

    private void OnValidate()
    {
        Sprite temp = GetComponent<Sprite>();
        if (sprite != null && sprite != temp)
        {
            sprite = temp;
            if(sprite == null)
                Debug.LogError("Sprite in " + this + " is null!");
            if (ChunkSize == null)
            {
                ChunkSize = sprite.bounds;
            }
            else if (ChunkSize != sprite.bounds)
            {
                Debug.LogError("Chunk Size Sprite Bounding Error in " + this + "!");
            }
        }
    }



}
