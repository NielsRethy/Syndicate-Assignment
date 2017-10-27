using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_HUD : MonoBehaviour
{
    // ================================== 
    // HUD class: 
    // ================================== 
    //  - Update information on the HUD
    // ----------------------------------

    // Use this for initialization
    private List<List<GameObject>> _playersBulletsHUD = new List<List<GameObject>>();       //List of a list that holds the icon objects for the bulets on the HUD (4 players = 4 list of bullets)
    private List<GameObject> _playerGunHUD = new List<GameObject>();                        //List of the gun icons on the HUD
    private List<GameObject> _playerIconHUD = new List<GameObject>();                       //List of the player icon on the HUD
    private int _characterCount = 4;                                                        //Characters in game
    void Start()
    {
        //ordering icons in right list
        OrderingIcons();

        //Resetting bullets so every icon is not active
        for (int a = 0; a < _playersBulletsHUD.Count; a++)
        {
            for (int b = 0; b < _playersBulletsHUD[a].Count; b++)
            {
                _playersBulletsHUD[a][b].SetActive(false);
            }
        }

    }

    public void OrderingIcons()
    {
        //Getting HUD informtion

        var UIP1 = GameObject.FindWithTag("GunPLayer1UI");
        var UIP2 = GameObject.FindWithTag("GunPLayer2UI");
        var UIP3 = GameObject.FindWithTag("GunPLayer3UI");
        var UIP4 = GameObject.FindWithTag("GunPLayer4UI");
        var playerIcons = GameObject.Find("PlayerIcon");

        //Sorting all the icons in the right list (0 = gun background, 1 = gun texture, 2-13 = bullets

        //==============
        //GunIcon
        //==============
        _playerGunHUD.Add(UIP1.GetComponentsInChildren<Transform>()[1].gameObject);
        _playerGunHUD.Add(UIP2.GetComponentsInChildren<Transform>()[1].gameObject);
        _playerGunHUD.Add(UIP3.GetComponentsInChildren<Transform>()[1].gameObject);
        _playerGunHUD.Add(UIP4.GetComponentsInChildren<Transform>()[1].gameObject);

        //==============
        //BulletsIcons
        //==============
        for (int i = 0; i < _characterCount; i++)
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

        //==============
        //PlayerIcons
        //==============
        for (int i = 1; i < playerIcons.GetComponentsInChildren<Transform>().Length; i++)
        {
            _playerIconHUD.Add(playerIcons.GetComponentsInChildren<Transform>()[i].gameObject);
        }

    }

    public void AmmoUpdate(int player, int AmmoCount)
    {
        //Updating Bullets on HUD

        //dissable every one
        for (int i = 0; i < _playersBulletsHUD[player].Count; i++)
        {
            _playersBulletsHUD[player][i].SetActive(false);
        }
        //enable correct amount
        for (int i = 0; i < AmmoCount; i++)
        {
            _playersBulletsHUD[player][i].SetActive(true);
        }
    }

    public void SetNewWeaponIcon(int player, string iconLocation)
    {
        //Updating weapon icon to the correct one
        _playerGunHUD[player].GetComponent<RawImage>().texture = Resources.Load<Texture>(iconLocation);
    }

    public void UpdateSelectedPlayer(int player)
    {
        //Updating selected player to highlight (change color) 
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

    

