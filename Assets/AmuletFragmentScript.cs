using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmuletFragmentScript : MonoBehaviour
{
    //Lo unico que hace este script es añadir una esquirla de amuleto al jugador cuando se acerca a este objeto

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ProgressTracker.PT.addPiece();
            this.gameObject.GetComponent<SphereCollider>().enabled = false;
            //StartCoroutine(absorbeFragmentVFX(this.transform.position,other.transform.position,100));
            Destroy(this.gameObject);
        }
    }

    //Esto de momento no funciona. Su intencion es hacer un lerp suave que mueva el fragmento hacia el jugador al mismo tiempo que va disminiuyendo su escala hasta 0,
    //dando la sensación de que lo 'absorbe'
    IEnumerator absorbeFragmentVFX(Vector3 from, Vector3 to, float speed)
    {
        Vector3 startPos = this.gameObject.transform.position;
        Vector3 startScale = this.gameObject.transform.localScale;

        

        while (this.gameObject.transform.position != to)
        {
            Vector3 temp = (this.transform.position - startPos) * speed;
            Vector3 tempPos = Vector3.Lerp(from, to, temp.magnitude);
            //float tempX = Mathf.Lerp(from.x, to.x, (this.transform.position.x - startPos.x) * speed);
            //float tempY = Mathf.Lerp(from.y, to.y, (this.transform.position.y - startPos.y) * speed);
            //float tempZ = Mathf.Lerp(from.z, to.z, (this.transform.position.z - startPos.z) * speed);
            this.transform.position = tempPos;

            //transform.position = Vector3.Lerp(from, to, speed);
            //this.transform.localScale = new Vector3(this.transform.localScale.x - 0.05f, this.transform.localScale.y - 0.05f, this.transform.localScale.z - 0.05f);

            yield return null;
        }


        //while (Time.timeScale != to)
        //{
        //    float tempTime = Mathf.Lerp(from, to, (Time.unscaledTime - startTime) * speed);
        //    Time.timeScale = tempTime;
        //    yield return null;
        //}

    }


}
