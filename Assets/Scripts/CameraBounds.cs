using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    private Camera cam;
    private float camX, camY;

    private void Awake()
    {
        cam = Camera.main;
        camX = ((float)Screen.width / (float)Screen.height * cam.orthographicSize * 2) / 2;
        camY = cam.orthographicSize;
    }

    public Vector2 GetRandomPointOffScreen()
    {
        var extra = 10f;
        var offTheScreenGuard = 2f;

        while (true)
        {
            var x = Random.Range(-camX - extra, camX + extra);
            var y = Random.Range(-camY - extra, camY + extra);

            if (x > camX + offTheScreenGuard || x < -camX - offTheScreenGuard) // + 2 to not spawn enemies on the edge of the screen
            {

                return new Vector2(x, y);
            }

            if (y > camY + offTheScreenGuard || y < -camY - offTheScreenGuard)
            {
                return new Vector2(x, y);
            }
        }
    }
}
