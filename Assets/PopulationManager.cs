//                                          ▂ ▃ ▅ ▆ █ ZEN █ ▆ ▅ ▃ ▂ 
//                                        ..........<(+_+)>...........
// .cs (//)
//Autor: Alejandro Rivas                 alejandrotejemundos@hotmail.es
//Desc:
//Mod : 
//Rev :
//..............................................................................................\\
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class PopulationManager : MonoBehaviour {
    public GameObject personPrefab;

    public int PopulationSize = 10;
    List<GameObject> population = new List<GameObject>();
    public static float elapsed = 0;
    public int trialtimee = 10;
    int generation = 1;

    public Text gen;
    public Text trialtime;
	void Start () {
        for (int i = 0; i < PopulationSize; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-9, 9), Random.Range(-4.5f, 4.5f), 0);
            GameObject go = Instantiate(personPrefab, pos, Quaternion.identity);
            go.GetComponent<ADN>().r = Random.Range(0.0f, 1.0f);
            go.GetComponent<ADN>().g = Random.Range(0.0f, 1.0f);
            go.GetComponent<ADN>().b = Random.Range(0.0f, 1.0f);
            go.GetComponent<ADN>().s = Random.Range(0.1f, 0.4f);
            population.Add(go);
        }
	}
	
	
	void Update () {
        gen.text = "Gen " + generation;
        trialtime.text = "Time: " + trialtimee;
        elapsed += Time.deltaTime;
        if (elapsed > trialtimee)
        {
            BreedNewPopulation();
            elapsed = 0;
        }
	}
    GameObject Breed(GameObject parent1, GameObject parent2)
    {
        Vector3 pos = new Vector3(Random.Range(-9, 9), Random.Range(-4.5f, 4.5f), 0);
        GameObject go = Instantiate(personPrefab, pos, Quaternion.identity);
        ADN adn1 = parent1.GetComponent<ADN>();
        ADN adn2 = parent2.GetComponent<ADN>();
        if (Random.Range(0, 10) < 9)
        {
            go.GetComponent<ADN>().r = Random.Range(0, 10) < 5 ? adn1.r : adn2.r;
            go.GetComponent<ADN>().g = Random.Range(0, 10) < 5 ? adn1.g : adn2.g;
            go.GetComponent<ADN>().b = Random.Range(0, 10) < 5 ? adn1.b : adn2.b;
            go.GetComponent<ADN>().s = Random.Range(0, 10) < 5 ? adn1.s : adn2.s;
        }
        else
        {
            go.GetComponent<ADN>().r = Random.Range(0.0f, 1.0f);
            go.GetComponent<ADN>().g = Random.Range(0.0f, 1.0f);
            go.GetComponent<ADN>().b = Random.Range(0.0f, 1.0f);
            go.GetComponent<ADN>().s = Random.Range(0.1f, 0.4f);

        }
        return go;
    }
    void BreedNewPopulation()
    {
        List<GameObject> newpopulation= new List<GameObject>();
        List<GameObject> sortedList = population.OrderByDescending(o => o.GetComponent<ADN>().timeToDie).ToList();
        population.Clear();
        for (int i = (int) (sortedList.Count/2.0f)-1; i < sortedList.Count-1; i++)
        {
            population.Add(Breed(sortedList[i], sortedList[i + 1]));
            population.Add(Breed(sortedList[i + 1], sortedList[i]));
        }
        for (int i = 0; i < sortedList.Count; i++)
        {
            Destroy(sortedList[i]);
        }
        generation++;

    }
}
