using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTiles : MonoBehaviour
{
    public GameObject leftSide;
    public GameObject rightSide;
    public GameObject tile_prefab;
    Vector3 left_position;
    Vector3 right_position;
    GameObject current_object;

    private int idx;
    private int idx_comb;
    //private Random rnd;
    private bool hit;
    private int type;
    int i;
    private bool left_handed;
    //private int[,] combinations = { { 1, 2, 2 }, { 1, 2, 3, 4, 5, 6 }, { 1, 2, 1 }, { 1, 2, 1, 1 }, { 1, 1 }, { 1, 1, 1 }, { 1, 2, 2 }, { 2, 2, 2 }, { 1, 2, 3 }, { 2, 3, 4 }, { 1, 6, 5 }, { 5, 6 }, { 1, 2, 2 }, { 1, 2, 2 }, { 1, 2, 2, 2, 1 }, { 4, 3 }, { 4, 1 }, { 1, 4 }, { 2, 3 }, { 5, 4 }, { 4, 4 }, { 6, 5, 4, 3 }, { 1, 1, 1, 1, 1, 1 }, { 2, 2, 2, 2 }, { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 } };
    private int[,] combinations = {
        { 1, 2, 3, 2, 1, 4, 5, 6 }
   
    };

    private int timer;

    // Start is called before the first frame update
    void Start()
    {
        left_position = leftSide.transform.position;
        right_position = rightSide.transform.position;
        left_handed = false;
        timer = 0;
        hit = false;
        idx = 0;
        i = 0;
        //GetTileRotation(3);
        //GetTileRotation(4);
    }

    // Update is called once per frame
    void Update()
    {
        i = 0;
        timer += 1;
        //Random rnd = new Random();
        //int idx_comb = rnd.Next(combinations.GetLength(0))
        //int[] curr =
        
        hit = false;
        type = combinations[i, idx];
        if (left_handed)
        {
            if (type % 2 == 0) {
                type -= 1;
            } else
            {
                type += 1;
            }
        }
        //Get Tile spawned
        //Debug.Log(timer);
        if (timer > 200)
        {
            hit = true;
            if (current_object != null)
            {
                Destroy(current_object);
                Debug.Log("current:" + current_object);
            }
            GetTileRotation(type);
            if (idx < 5)
            {
                idx++;
                timer = 0;
                Debug.Log("change idx");
            }
            else
            {
                idx = 0;
                i++;
                timer = 0;
            }
        }
        
        /*if (hit == true)
        {

            hit = false;
            timer = 0;
            if(idx < 1)
            {
                idx++;
                Debug.Log("change idx");
            }
            
        }*/
    }

    void GetTileRotation(int type)
    {
        if (type == 1)
        {
            Vector3 new_rotation = new Vector3(0, 90, 0);
            current_object = Instantiate(tile_prefab, left_position, Quaternion.Euler(new_rotation));
            
        }
        if (type == 2)
        {
            Vector3 new_rotation = new Vector3(0, 90, 0);
            current_object = Instantiate(tile_prefab, right_position, Quaternion.Euler(new_rotation));
        }
        if (type == 3)
        {
            Vector3 new_rotation = new Vector3(270, 90, 90);
            current_object = Instantiate(tile_prefab, left_position, Quaternion.Euler(new_rotation));
        }
        if (type == 4)
        {
            Vector3 new_rotation = new Vector3(90, 90, 90);
            current_object = Instantiate(tile_prefab, right_position, Quaternion.Euler(new_rotation));
        }
        if (type == 5)
        {
            Vector3 new_rotation = new Vector3(0, 90, 270);
            current_object = Instantiate(tile_prefab, left_position, Quaternion.Euler(new_rotation));
            Debug.Log("5 init");
        }
        if (type == 6)
        {
            Debug.Log("6 enter");
            Vector3 new_rotation = new Vector3(0, 90, 270);
            current_object = Instantiate(tile_prefab, right_position, Quaternion.Euler(new_rotation));
            Debug.Log("6 init");
        }
    }
}
