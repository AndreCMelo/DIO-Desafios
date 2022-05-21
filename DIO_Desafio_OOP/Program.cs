using System;
using DIO_Desafio_OOP.src.Entities;

namespace DIO_Desafio_OOP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Knight arus = new Knight("Arus", 42, "Knight", 749, 72);
            Ninja wedge = new Ninja("Wedge", 42, "Ninja", 574, 89);
            Wizard jenica = new Wizard("Jenica", 42, "White Wizard", 601, 482);
            Wizard topapa = new Wizard("Topapa", 42, "Black Wizard", 385, 641);

            Console.WriteLine(arus);
            Console.WriteLine(wedge);
            Console.WriteLine(jenica);
            Console.WriteLine(topapa);
        }
    }      
}