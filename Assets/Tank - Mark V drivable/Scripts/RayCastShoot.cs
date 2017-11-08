using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RayCastShoot : MonoBehaviour {

    public float weaponRange = 32000f;
    public Transform gunEnd;
    private float time =  0f;
    public Camera fpsCam;
    public Light lightEff ;
    public GameObject explosion; // drag your explosion prefab here
    public GameObject enemySmoke;
    private float bulletOffset ;
    private bool fire = true;
    public AudioSource firingAudio;
    public Text scoreText;
    public int score = 0;

    void Start () {
        lightEff.intensity=0f;
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
	}

    private void Explosion(Vector3 hitPos)
    {
        GameObject expl = Instantiate(explosion, hitPos, Quaternion.identity) as GameObject;
        Destroy(expl, 3); // delete the explosion after 3 seconds
    }

    IEnumerator FireReload()
    {
        fire = false;
        // Debug.Log("Before Waiting 4 seconds");
        yield return new WaitForSeconds(4);
        // Debug.Log("After Waiting 4 Seconds");
        fire = true;
    }

    IEnumerator EnemySmoke(GameObject hitObj)
    {
        yield return new WaitForSeconds(3);
        // Debug.Log("After Waiting 4 Seconds");
        Vector3 enemyPos = hitObj.transform.position;
        GameObject smoke;
        if (hitObj.tag == "Enemy")
        {
          score += 10;
          scoreText.text = "Score: " + score;
          smoke = Instantiate(enemySmoke, enemyPos, Quaternion.identity) as GameObject;
          if (hitObj.transform.parent != null) // if object has a parent
          {
            Destroy(hitObj.transform.parent.gameObject, 12); // destroy parent a few frames later
          }
          else
          {
            Destroy(hitObj, 12);
          }
        }
    }

    void Update () {

        if(Input.GetButton("Fire1"))
        {

            lightEff.intensity = 1f;
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit ;

            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {

                bulletOffset = hit.distance / 10000f;
                if (Physics.Raycast(rayOrigin, fpsCam.transform.forward - new Vector3(0.0f,bulletOffset,0.0f), out hit, weaponRange))
                {
                    if (fire)
                    {
                        print(hit.collider.gameObject.name);
                        Explosion(hit.point);
                        StartCoroutine(FireReload());
                        StartCoroutine(EnemySmoke(hit.collider.gameObject));
                        time = 2f;
                        firingAudio.Play();
                    }

                }

            }

        }
        if (time > 0)
            time--;
        if(time == 0f)
            lightEff.intensity = 0f;




    }
}
