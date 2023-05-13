using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] NavMeshAgent player;
    [SerializeField] GameObject ray;

    PlayerInput input;
    bool isReady = true;
    void Start()
    {
        input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isReady) return;

        if (Input.GetMouseButtonDown(0))
        {
            player.SetDestination(input.GetPosition());
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name.StartsWith("Astronaut") && isReady)
        {
            isReady = false;
            other.transform.parent.GetChild(0).GetComponent<Animator>().SetBool("IsFly",true);
            StartCoroutine(CatchOtherPlayer(other.transform.parent));
        }

        if (other.name.StartsWith("Enemy"))
        {
            UI.Instance.ShowGameOver();

        }
    }


    IEnumerator CatchOtherPlayer(Transform t)
    {
        yield return new WaitForSeconds(.35f);
        player.velocity = Vector3.zero;
        player.isStopped = true;
        ray.SetActive(true);

        while(t.localPosition.y < 25f)
        {
            var p = t.localPosition;
            t.localPosition = new Vector3(p.x,p.y+.25f,p.z);
            yield return new WaitForEndOfFrame();
        }

        Destroy(t.gameObject);

        isReady = true;
        ray.SetActive(false);
        player.isStopped = false;

        Game.Instance.IsGameComplete();

    }
}
