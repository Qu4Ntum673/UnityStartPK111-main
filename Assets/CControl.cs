using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CControl : MonoBehaviour
{
    [SerializeField]
    GameObject Ctxt;
    [SerializeField]
    List<GameObject> ChestList;
    bool canOpen = true;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animator>().enabled = false;
        Ctxt.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Player"))
        {
            Ctxt.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        Ctxt.GetComponent<MeshRenderer>().enabled = false;
    }
    public void OpenChest()
    {
        gameObject.GetComponent<Animator>().enabled = true;
        Ctxt.GetComponent<TextMesh>().text = "Сундук пуст!";
        if(canOpen)
        {
            float rnd = 1;
            int num = -1;
            do
            {
                rnd = Random.Range(0, 1f);
                num++;
                if (num == ChestList.Count - 1)
                {
                    num = 0;
                }
            }
            while (rnd > 0.25f);
            GameObject drop = Instantiate(ChestList[num], transform.position, transform.rotation);
            drop.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * 5, ForceMode2D.Impulse);
            canOpen = false;
        }
        
            
    }
}
