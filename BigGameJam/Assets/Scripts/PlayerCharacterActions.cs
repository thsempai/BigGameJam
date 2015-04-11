using InControl;

public class PlayerCharacterActions : PlayerActionSet {

    public PlayerAction Left;
    public PlayerAction Right;
    public PlayerOneAxisAction Move;
    public PlayerAction Jump;
    public PlayerAction Punch;

    public PlayerCharacterActions()
    {
        Left = CreatePlayerAction( "Move Left" );
        Right = CreatePlayerAction( "Move Right" );
        Move = CreateOneAxisPlayerAction( Left, Right );
        Jump = CreatePlayerAction( "Jump" );
        Punch = CreatePlayerAction( "Punch" );
    }

}

