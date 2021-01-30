using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : LostGameObject
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        directionX = (int) Input.GetAxisRaw("Horizontal");
        directionY = (int)Input.GetAxisRaw("Vertical");
    }

    public override void UpdatePosition()
    {
        base.UpdatePosition();

    }
}
