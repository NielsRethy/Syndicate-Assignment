using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_HUD : MonoBehaviour
{

    // Use this for initialization
    private List<List<GameObject>> _playersBullets = new List<List<GameObject>>();

    private List<GameObject> _playerGun = new List<GameObject>();

    //private int bulletCount = 8;

    void Start()
    {
        //Getting HUD informtion

        var UIP1 = GameObject.FindWithTag("GunPLayer1UI");
        var UIP2 = GameObject.FindWithTag("GunPLayer2UI");
        var UIP3 = GameObject.FindWithTag("GunPLayer3UI");
        var UIP4 = GameObject.FindWithTag("GunPLayer4UI");

        _playerGun.Add(UIP1.GetComponentsInChildren<Transform>()[1].gameObject);
        _playerGun.Add(UIP2.GetComponentsInChildren<Transform>()[1].gameObject);
        _playerGun.Add(UIP3.GetComponentsInChildren<Transform>()[1].gameObject);
        _playerGun.Add(UIP4.GetComponentsInChildren<Transform>()[1].gameObject);

        //Storing gun texture (0 = gun background, 1 = gun texture, 2-13 = bullets
        for (int i = 0; i < 4; i++)
        {
            _playersBullets.Add(new List<GameObject>());

        }

        for (int i = 2; i < UIP1.GetComponentsInChildren<Transform>().Length; i++)
        {
            _playersBullets[0].Add(UIP1.GetComponentsInChildren<Transform>()[i].gameObject);
        }
        for (int i = 2; i < UIP2.GetComponentsInChildren<Transform>().Length; i++)
        {
            _playersBullets[1].Add(UIP2.GetComponentsInChildren<Transform>()[i].gameObject);
        }
        for (int i = 2; i < UIP3.GetComponentsInChildren<Transform>().Length; i++)
        {
            _playersBullets[2].Add(UIP3.GetComponentsInChildren<Transform>()[i].gameObject);
        }
        for (int i = 2; i < UIP4.GetComponentsInChildren<Transform>().Length; i++)
        {
            _playersBullets[3].Add(UIP4.GetComponentsInChildren<Transform>()[i].gameObject);
        }

        //Setting Bullets on 0
        for (int a = 0; a < _playersBullets.Count; a++)
        {
            for (int b = 0; b < _playersBullets[a].Count; b++)
            {
                _playersBullets[a][b].SetActive(false);

            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AmmoUpdate(int player, int AmmoCount)
    {

        //Updating Bullets on HUD
        for (int i = 0; i < _playersBullets[player].Count; i++)
        {
            _playersBullets[player][i].SetActive(false);

        }

        //Updating Bullets on HUD
        for (int i = 0; i < AmmoCount; i++)
        {
            _playersBullets[player][i].SetActive(true);

        }
    }

    public void SetNewWeaponIcon(int player, string iconLocation)
    {
        var t = new Texture();
        _playerGun[player].GetComponent<RawImage>().texture = Resources.Load<Texture>(iconLocation);
    }
}

    

