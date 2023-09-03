using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffScreenIndicator : MonoBehaviour
{
    public GameObject IndicatorPrfab;
    public GameObject Player;
    private GameObject Indicator;
    Renderer Renderer;
    private float Xdiff = 12.15f;
    private float Ydiff = 6.6f;


    private void Start()
    {
        Renderer = GetComponent<Renderer>();
    }
    private void Update()
    {

        if (!Renderer.isVisible && Indicator == null)
        {
            Indicator = Instantiate(IndicatorPrfab, transform.position, Quaternion.identity);
        }

        if (Indicator != null)
        {
            Vector3 Look = Indicator.transform.InverseTransformPoint(transform.position);
            float Angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg - 90f;
            Indicator.transform.Rotate(0, 0, Angle);
            float Xpos = Mathf.Clamp(transform.position.x, Player.transform.position.x - Xdiff, Player.transform.position.x + Xdiff);
            float Ypos = Mathf.Clamp(transform.position.y, Player.transform.position.y - Ydiff, Player.transform.position.y + Ydiff);
            Indicator.transform.position = new Vector2(Xpos, Ypos);
        }
        if (Renderer.isVisible && Indicator != null)
        {
            Destroy(Indicator);
        }
        if (Vector3.Distance(Player.transform.position, transform.position) > 30f)
        {
            Destroy(Indicator);
        }
        if (Vector3.Distance(Player.transform.position, transform.position) < 30f && Indicator == null)
        {
            Indicator = Instantiate(IndicatorPrfab, transform.position, Quaternion.identity);

        }
    }
}
