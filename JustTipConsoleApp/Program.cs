﻿// See https://aka.ms/new-console-template for more information
using JustTipConsoleApp.Controllers;
using JustTipConsoleApp.Strategy;
using JustTipConsoleApp.Views;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("JustTipTest")]
class Program
{
    static void Main(string[] args)
    {
        ITipCalcStrategy strategy = new ProportionalDistribution();
        MainController controller = new MainController(strategy);

        MainView view = new MainView(controller);
        view.MainMenu();
    }
}
