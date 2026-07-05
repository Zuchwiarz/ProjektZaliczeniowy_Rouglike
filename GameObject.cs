using System.Numerics;

namespace GrTypuRouglike;

public abstract class GameObject
{
    protected Vector2 _position = new Vector2(0, 0); //<"protected" czyli tylko dla dzieci
    protected char _avatar = '@';

    public GameObject(char avatar, Vector2 position)
    {
        _avatar = avatar;
        _position = position;  // a to mili państwo jest KONSTRUKTOR
    }

    public void Display()
    {
        Display(_position);
        // ciekawa praktyka, robimy 2 przeciążenia, przy czym to jest prostsze
        //ma być chyba po prostu postawowym wyświetlaniem w CurrentPosition bez precyzowania ręcznego
    }

    public void Display(Vector2 screenPosition)
    {
        Console.SetCursorPosition(screenPosition.X, screenPosition.Y); //<< !! czemu??? błąd???
        Console.Write(_avatar);
        // 1. ruszamy kursor
        // 2. piszemy GameObject na jego pozycji
        //** ciekwe że to działa jak Insert a nie normalny kursor, hmmm
    }
    
    /*
     *  PODSUMOWAWSZY:
     * 1. W GameObjecie jest:
     *  > pozycja
     *  > wygląd obiektu 'char'
     *  > i funkcja Display do jego wyświetlania
     *
     *  Czyli wszystko czego potrzebuje każda rzecz. Mądre.
     */
}

//Test
//Test

// push test krzysztof

