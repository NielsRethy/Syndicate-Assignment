using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_CharacterManager
{

    private readonly List<SCR_Character> _charactersList = new List<SCR_Character>();
    private SCR_Character _selectedCharacter;
    private int _maxCharacters = 4;

    public void Initialize()
    {
        //First character is always the first selected
        if (_charactersList.Count < 4)
        {
            for (int i = 0; i < _maxCharacters ; i++)
            {
                _charactersList.Add( new SCR_Character("Player" + (i + 1).ToString(), i + 1));
            }
        }
        _selectedCharacter = _charactersList[0];
        foreach (var character in _charactersList)
        {
            character.Initialize(character == _selectedCharacter);
        }
      


    }

    public void ChangeSelectedCharacter()
    {
        //Change player when clickt on
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (hit.transform.gameObject.GetComponent<SCR_VisualCharacter>() != null)
            {
                SCR_VisualCharacter vc = hit.transform.gameObject.GetComponent<SCR_VisualCharacter>();
                _selectedCharacter.IsSelected = false;
                _selectedCharacter = _charactersList[vc.Character.Id];
                vc.IsSelected = true;

            }
        }

    }
}
