using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_HUD : MonoBehaviour
{

    // Use this for initialization
    private List<List<GameObject>> _playersBulletsHUD = new List<List<GameObject>>();
    private List<GameObject> _playerGunHUD = new List<GameObject>();
    private List<GameObject> _playerIconHUD = new List<GameObject>();

    //private int bulletCount = 8;

    void Start()
    {
        //Getting HUD informtion

        var UIP1 = GameObject.FindWithTag("GunPLayer1UI");
        var UIP2 = GameObject.FindWithTag("GunPLayer2UI");
        var UIP3 = GameObject.FindWithTag("GunPLayer3UI");
        var UIP4 = GameObject.FindWithTag("GunPLayer4UI");
        var playerIcons = GameObject.Find("PlayerIcon");

        _playerGunHUD.Add(UIP1.GetComponentsInChildren<Transform>()[1].gameObject);
        _playerGunHUD.Add(UIP2.GetComponentsInChildren<Transform>()[1].gameObject);
        _playerGunHUD.Add(UIP3.GetComponentsInChildren<Transform>()[1].gameObject);
        _playerGunHUD.Add(UIP4.GetComponentsInChildren<Transform>()[1].gameObject);

        //Storing gun texture (0 = gun background, 1 = gun texture, 2-13 = bullets
        for (int i = 0; i < 4; i++)
        {
            _playersBulletsHUD.Add(new List<GameObject>());

        }

        for (int i = 2; i < UIP1.GetComponentsInChildren<Transform>().Length; i++)
        {
            _playersBulletsHUD[0].Add(UIP1.GetComponentsInChildren<Transform>()[i].gameObject);
        }
        for (int i = 2; i < UIP2.GetComponentsInChildren<Transform>().Length; i++)
        {
            _playersBulletsHUD[1].Add(UIP2.GetComponentsInChildren<Transform>()[i].gameObject);
        }
        for (int i = 2; i < UIP3.GetComponentsInChildren<Transform>().Length; i++)
        {
            _playersBulletsHUD[2].Add(UIP3.GetComponentsInChildren<Transform>()[i].gameObject);
        }
        for (int i = 2; i < UIP4.GetComponentsInChildren<Transform>().Length; i++)
        {
            _playersBulletsHUD[3].Add(UIP4.GetComponentsInChildren<Transform>()[i].gameObject);
        }
        for (int i = 1; i < playerIcons.GetComponentsInChildren<Transform>().Length; i++)
        {
            _playerIconHUD.Add(playerIcons.GetComponentsInChildren<Transform>()[i].gameObject);
        }

        //Setting Bullets on 0
        for (int a = 0; a < _playersBulletsHUD.Count; a++)
        {
            for (int b = 0; b < _playersBulletsHUD[a].Count; b++)
            {
                _playersBulletsHUD[a][b].SetActive(false);

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
        for (int i = 0; i < _playersBulletsHUD[player].Count; i++)
        {
            _playersBulletsHUD[player][i].SetActive(false);

        }

        //Updating Bullets on HUD
        for (int i = 0; i < AmmoCount; i++)
        {
            _playersBulletsHUD[player][i].SetActive(true);

        }
    }

    public void SetNewWeaponIcon(int player, string iconLocation)
    {
        var t = new Texture();
        _playerGunHUD[player].GetComponent<RawImage>().texture = Resources.Load<Texture>(iconLocation);
    }

    public void UpdateSelectedPLayer(int player)
    {
        for (int i = 0; i < _playerIconHUD.Count; i++)
        {
            if (i == player )
            {
                _playerIconHUD[i].GetComponent<RawImage>().color = Color.yellow;
            }
            else
            {
                _playerIconHUD[i].GetComponent<RawImage>().color = Color.white;
            }
        }
    }
}

    

