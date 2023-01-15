using Newtonsoft.Json;

public class ScreenHandler
{
    public Screen[] screens {get; set;}
    ActionHandler actionHandler = new ActionHandler();
    private string _path {get; set;}
    public ScreenHandler(string path)
    {
        _path = path;
        Deserialize(path);
        Initialize();
    }
    public void Deserialize(string path)
    {
        using (var reader = new StreamReader(path))
        {
            string readingsFromJson = reader.ReadToEnd();
            Screen[] screensFromJson = JsonConvert.DeserializeObject<Screen[]>(readingsFromJson);
            this.screens = screensFromJson;
        }
        for (int i = 0; i < screens.Length; i++)
        {
            foreach (var item in screens[i].Actions)
            {
                item.Option = item.Option.ToLower();
            }
        }
    }
    public void Initialize()
    {
        LoadScreen(screens.Where(s => s.EntryPoint == true).First());
    }
    public void LoadScreen(Screen screen)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(screen.Title + Environment.NewLine);
            if (screen.Message != null)
            {
                Console.WriteLine(screen.Message);
                string choice = Console.ReadLine()[0].ToString().ToLower();
                if (string.Equals(choice, screen.Actions.Where(s => s.Option.ToString() == choice).First().Option.ToString()))
                {
                    actionHandler.Execute(choice, this, screen.Actions.Where(s => s.Option.ToString() == choice).First());
                }
            }
            else if (screen.Actions != null)
            {
                Console.WriteLine("Actions: ");
                foreach(var action in screen.Actions)
                {
                    Console.WriteLine("({0}) {1}", action.Option, action.Name);
                }
                string choice = Console.ReadLine()[0].ToString();
                if (string.Equals(choice, screen.Actions.Where(s => s.Option.ToString() == choice).First().Option.ToString()))
                {
                    actionHandler.Execute(choice, this, screen.Actions.Where(s => s.Option.ToString() == choice).First());
                }
            }
        }
    }
    public void ChangeScreens(string NextScreen)
    {
        actionHandler.NextScreen(NextScreen, this);
    }
}