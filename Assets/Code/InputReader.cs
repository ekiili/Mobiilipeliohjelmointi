using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private PlayerControls _inputs = null;
    [SerializeField] private Vector2 _movementInput = Vector2.zero;
    [SerializeField] private bool _interactInput = false;

    /// <summary>
    /// C#:n properetyt korvaavat mm. Javan getterit ja setterit.
    /// Property näyttää käyttäjälle muuttujalta, mutta se käyttäytyy
    /// kuin get ja set metodit.
    /// </summary>
    public Vector2 Move
    {
        get { return _movementInput; }
    }

    public bool Jump {
        get {return _interactInput; }
    }

    private void Awake()
    {
        // Alustetaan Inputs-olio Awakessa luomalla new:llä uusi Inputs-olio.
        _inputs = new PlayerControls();
    }

    private void OnEnable()
    {
        // Aktivoidaan input OnEnablessa, eli kun objekti aktivoituu
        _inputs.Player.Enable();
    }

    private void OnDisable()
    {
        // Deaktivoidaan input OnDisablessa, eli kun objekti deaktivoituu
        _inputs.Player.Disable();
    }

    // Luetaan inputin arvo jokaisella framella
    private void Update()
    {
        _movementInput = _inputs.Player.Move.ReadValue<Vector2>();
        _interactInput = _inputs.Player.Jump.ReadValue<float>() > 0 ;

        // TODO: Lue interaktio-inputin arvo (eventti)
    }
}