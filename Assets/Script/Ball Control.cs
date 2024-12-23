using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); //mengambil rigidbody component dari sebuah bole
        Invoke("Goball", 2); //memanggil function GoBall dlm 2 detik
    }
    void Goball()
    {
        float rand = Random.Range(0, 2); //akan random nilai diantara 0-1
        if (rand < 1)
        { 
            rb2d.AddForce(new Vector2(20, -15)); //add force memberikan tenaga
						//liat doc add force disini https://docs.unity3d.com/ScriptReference/Rigidbody.AddForce.html

        }
        else
        {
            rb2d.AddForce(new Vector2(-20, -15));
        }
    }

    void Resetball() //ini kita buat nilai transform jadi 0
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame()
    {
        Debug.Log("Restart!");
        Resetball();
        Invoke("Goball", 2f);
    }

    [SerializeField] private int wallCollisionCount;
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Left") //jika terkena player
        {
            //Debug.Log("King Punch!");
            rb2d.AddForce(new Vector2(20,-15));
            wallCollisionCount = 0;

        }
        else if (coll.gameObject.name == "Right") //jika terkena enemy
        {
            //Debug.Log("Pig Punch!");
            rb2d.AddForce(new Vector2(-20,-15));
            wallCollisionCount = 0;
        }
        else //jika terkena wall
        {
            wallCollisionCount = wallCollisionCount + 1;
            Debug.Log("Wall Collision! = " + wallCollisionCount);
            if (wallCollisionCount > 6) Goball();
        }
    }


}
