namespace AnimalMatchingGame;

public partial class MainPage : ContentPage
{
    int tenthsOfSecondsElapsed;
    int matchesFound;
    bool disappearing = false;

    public MainPage()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Turn off the timer on disappearing to avoid an exception when closing the app when the timer is running
    /// System.Runtime.InteropServices.COMException: 'Catastrophic failure (0x8000FFFF (E_UNEXPECTED))'
    /// </summary>
    protected override void OnDisappearing()
    {
        disappearing = true;
        base.OnDisappearing();
    }

    /// <summary>
    /// Re-enable the timer if the app appears again
    /// </summary>
    protected override void OnAppearing()
    {
        disappearing = false;
        base.OnAppearing();
    }

    /// <summary>
    /// When the timer elapses
    /// </summary>
    /// <returns></returns>
    private bool Timer_Elapsed()
    {
        if (disappearing) return false;

        tenthsOfSecondsElapsed++;

        TimeElapsedLabel.Text = "Time elapsed: " + (tenthsOfSecondsElapsed / 10F).ToString("0.0s");
        if (matchesFound == 8)
        {
            AnimalButtons.IsVisible = false;
            PlayAgainButton.IsVisible = true;
            return false;
        }

        return true;
    }

    /// <summary>
    /// Start the game by randomizing the animals and starting the timer
    /// </summary>
    private void SetUpGame(object sender, EventArgs e)
    {
        List<string> animalEmoji = new List<string>()
            {
                "🐙", "🐙",
                "🐡", "🐡",
                "🐘", "🐘",
                "🐳", "🐳",
                "🐪", "🐪",
                "🦕", "🦕",
                "🦘", "🦘",
                "🦔", "🦔",
            };

        foreach (var button in AnimalButtons.Children.OfType<Button>())
        {
            button.IsVisible = true;
            int index = Random.Shared.Next(animalEmoji.Count);
            string nextEmoji = animalEmoji[index];
            button.Text = nextEmoji;
            animalEmoji.RemoveAt(index);
        }

        tenthsOfSecondsElapsed = 0;
        matchesFound = 0;
        PlayAgainButton.IsVisible = false;
        AnimalButtons.IsVisible = true;

        Dispatcher.StartTimer(TimeSpan.FromSeconds(.1), Timer_Elapsed);
    }

    Button lastButtonClicked;
    bool findingMatch = false;

    /// <summary>
    /// When an animal is clicked, check for a match and end the game if all matches are found
    /// </summary>
    private void OnAnimalClicked(object sender, EventArgs e)
    {
        if (sender is Button buttonClicked)
        {
            if (!string.IsNullOrEmpty(buttonClicked.Text) && (findingMatch == false))
            {
                buttonClicked.BackgroundColor = Colors.Red;
                lastButtonClicked = buttonClicked;
                findingMatch = true;
            }
            else
            {
                if ((buttonClicked != lastButtonClicked) && (buttonClicked.Text == lastButtonClicked.Text))
                {
                    matchesFound++;
                    lastButtonClicked.Text = "";
                    buttonClicked.Text = "";
                }
                lastButtonClicked.BackgroundColor = Colors.LightBlue;
                buttonClicked.BackgroundColor = Colors.LightBlue;
                findingMatch = false;
            }
        }
    }
}

