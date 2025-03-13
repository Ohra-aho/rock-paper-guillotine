using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vitsikirja : MonoBehaviour
{
    private List<string> jokes = new List<string> { 
        "Mit‰ eroa on l‰‰k‰rill‰ ja insinˆˆrill‰? L‰‰k‰ri tappaa vain yhden ihmisen kerrallaan.",
        "Suomalainen introvertti katsoo omiin kenkiins‰ keskustellessaan vieraan ihmisen kanssa, kun suomalainen ekstrovertti katsoo toisen ihmisen kenkiin keskustellessaan h‰nen kanssaan.",
        "-Vaimoni mielest‰ olen aivan liian utelias\n-Kuinka niin, mist‰ sen tied‰t?\n-Luin sen h‰nen p‰iv‰kirjastaan.",
        "-En usko, ett‰ menit prostituoidulle!\n-No mit‰ oikein odotit? Mit‰‰n ei ole tapahtunut kuukausiin.\n-Olisit voinut kertoa, ett‰ olet valmis maksamaan."
    };

    private void Start()
    {
        ChooseAJoke();
    }

    private void Awake()
    {
        ChooseAJoke();
    }

    public void ChooseAJoke()
    {
        int i = Random.Range(0, jokes.Count);
        GetComponent<Weapon>().description = jokes[i];
    }
}
