using UnityEngine;

public class CanObject : MonoBehaviour
{
    private bool isHit;
    public GameObject DropEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string name = collision.gameObject.name;

        if (name.Substring(0, 5) == "myCar" && !isHit)
        {
            isHit = true;
            collision.gameObject.GetComponent<CarController>().AddBenzin();
            GetComponent<Animator>().Play("CanAnimFade");
            GameObject drops = Instantiate(DropEffect, new Vector3(transform.position.x, transform.position.y, -1f), Quaternion.identity);
            drops.transform.SetParent(gameObject.transform);            
            Destroy(gameObject, 0.5f);
        }        
    }
}
