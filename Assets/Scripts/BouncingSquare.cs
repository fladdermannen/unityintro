using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BouncingSquare : MonoBehaviour {

    [Range(0f,1f)]
    public float speed = 0.03f;

    float maxSizeX = 3;
    float maxSizeY = 3;
    float minSizeX = 0.1f;
    float minSizeY = 0.1f;
    float maxPositionX = 7;
    float minPositionX = -7;
    float maxPositionY = 4;
    float minPositionY = -4;

    float directionX = 1;
    float directionY = 1;
    float sizing = 1;

    SpriteRenderer spriteRenderer;

    public List<Color> coolColors = new List<Color>();

    // Use this for initialization
    void Start () {
        Debug.Log("Vector3: " + Vector3.zero);
        transform.position = Vector3.zero;
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = Color.cyan;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 position = transform.position;
        position.x += speed * directionX;
        position.y += speed * directionY;
        transform.position = position;


        Vector3 scale = transform.localScale;
        scale.x += speed * sizing;
        scale.y += speed * sizing;
        transform.localScale = scale;

        if(position.x > maxPositionX || position.x < minPositionX)
        {
            ChangeDirectionX();
        }
        if(position.y > maxPositionY || position.y < minPositionY)
        {
            ChangeDirectionY();
        }

        if(scale.x > maxSizeX && scale.y > maxSizeY || scale.x < minSizeX && scale.y < minSizeY)
        {
            ChangeSizing();
        }
        

	}

    private void OnMouseDown()
    {
        Debug.Log("Click");
        ChangeDirectionY();
    }

    void ChangeDirectionX()
    {
        directionX *= -1;
    }
    void ChangeDirectionY()
    {
        directionY *= -1;
    }

    void ChangeSizing()
    {
        sizing *= -1;
        ChangeColor();
    }

    void ChangeColor()
    { 

        Color color = coolColors[Random.Range(0, coolColors.Count)];

        spriteRenderer.color = color;
    }
}
