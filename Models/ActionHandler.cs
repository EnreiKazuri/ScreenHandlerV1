public class ActionHandler
{
    public void Exit()
    {
        Environment.Exit(0);
    }
    public void NextScreen(string NextScreen, ScreenHandler handler)
    {
        handler.LoadScreen(handler.screens.Where(s => s.ID == NextScreen).First());
    }
    public void Execute(string choice, ScreenHandler handler, Action action)
    {
        string method = action.Handler;
        switch (method.ToLower())
        {
            case "exit":
                Exit();
                break;
            case "nextscreen":
                NextScreen(action.NextScreen, handler);
                break;
            default:
                break;
        }
    }
}