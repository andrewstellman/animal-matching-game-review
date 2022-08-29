# Head First C# - Animal Matching Game

![](https://raw.githubusercontent.com/head-first-csharp/fourth-edition/master/Images/Head_First_CSharp_cover_glasses.png)

Thanks so much for having a look at the code for the .NET MAUI version of the Animal Matching Game for Chapter 1 of [Head First C#](https://github.com/head-first-csharp/fourth-edition). I'd really appreciate any feedback you have, whether it's about the code, aesthetics, basic idea, or anything else!

We'll have our readers:
1. Create a new .NET MAUI project in Visual Studio
2. Change the title in [AppShell.xaml](https://github.com/andrewstellman/animal-matching-game-review/blob/main/AnimalMatchingGame/AnimalMatchingGame/AppShell.xaml) and run the application to start getting used to running and debugging in Visual Studio.
3. Edit [MainPage.xaml](https://github.com/andrewstellman/animal-matching-game-review/blob/main/AnimalMatchingGame/AnimalMatchingGame/MainPage.xaml) to create the basic layout
4. Update [MainPage.xaml.cs](https://github.com/andrewstellman/animal-matching-game-review/blob/main/AnimalMatchingGame/AnimalMatchingGame/MainPage.xaml.cs) – they'll go through a few iterations, first adding animals, then randomizing them, then handling clicks, then adding a timer

One thing I'd really like some guidance on is whether I'm using the timer correctly. I'm using `Dispatcher.StartTimer` to start a timer. I need to override `OnDisappearing` to stop the timer if the app is disappearing, otherwise I get this exception:

![image](https://user-images.githubusercontent.com/7516297/187253153-4bdfb635-6c01-400b-bb67-45b5c2a2748b.png)

Is there a cleaner way to use a timer that might protect the readers from having to do that?

*- Andrew*

