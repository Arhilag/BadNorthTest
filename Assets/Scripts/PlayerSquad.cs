public class PlayerSquad : Squad
{
    protected override void AddStart()
    {
        MoveToPanel(transform.position);
    }
}
