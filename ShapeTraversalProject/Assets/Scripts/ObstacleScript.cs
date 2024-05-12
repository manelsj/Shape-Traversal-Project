using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    private ShapeStats stats;

    public SpriteRenderer spriteRenderer;
    public Sprite square;
    public Sprite circle;
    public Sprite triangle;
    // Start is called before the first frame update
    void Start()
    {
        stats = this.GetComponent<ShapeStats> ();
        SetColor();
        SetShape();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetColor()
    {
        if (stats.color == ShapeStats.Colors.Red)
            this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);

        else if (stats.color == ShapeStats.Colors.Green)
            this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);

        else if (stats.color == ShapeStats.Colors.Blue)
            this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
    }

    void SetShape()
    {
        if (stats.shape == ShapeStats.Shapes.Square)
            spriteRenderer.sprite = square;

        else if (stats.shape == ShapeStats.Shapes.Circle)
            spriteRenderer.sprite = circle;

        else if (stats.shape == ShapeStats.Shapes.Triangle)
            spriteRenderer.sprite = triangle;
    }
}
