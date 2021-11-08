using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    private Camera _cam;
    private float _camX, _camY;

    private void Awake()
    {
        _cam = Camera.main;
        _camX = ((float)Screen.width / (float)Screen.height * _cam.orthographicSize * 2) / 2;
        _camY = _cam.orthographicSize;
    }

    public Vector2 GetRandomPointOffScreen()
    {
        var extra = 10f;
        var offTheScreenGuard = 2f;

        while (true)
        {
            var x = Random.Range(-_camX - extra, _camX + extra);
            var y = Random.Range(-_camY - extra, _camY + extra);

            if (x > _camX + offTheScreenGuard || x < -_camX - offTheScreenGuard) // + - 2 to not spawn enemies on the edge of the screen
            {
                return new Vector2(x, y);
            }

            if (y > _camY + offTheScreenGuard || y < -_camY - offTheScreenGuard)
            {
                return new Vector2(x, y);
            }
        }
    }
}
