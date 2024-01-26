using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float minX; // Aseta minimikoordinaatti Unityn Inspectorissa
    public float maxX; // Aseta maksimikoordinaatti Unityn Inspectorissa
    public float speed = 2.0f; // Aseta liikkumisnopeus

    private int direction = 1; // Suunta, johon olio liikkuu (1 = oikealle, -1 = vasemmalle)

    // Update is called once per frame
    void Update()
    {
        // Liikuta oliota vaakasuunnassa
        transform.position += new Vector3(speed * direction * Time.deltaTime, 0, 0);

        // Jos olio saavuttaa minimi- tai maksimikoordinaatin, vaihda suuntaa
        if (transform.position.x < minX)
        {
            direction = 1;
        }
        else if (transform.position.x > maxX)
        {
            direction = -1;
        }
    }
}