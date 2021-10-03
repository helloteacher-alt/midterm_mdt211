using System;
using System.Collections.Generic;

namespace midterm_Quiz3 //63120501029
{
    enum Menu // สร้าง enum Menu เพื่อโอนค่าเมื่อผู้เล่นเลือกเมนู
    {
        PlayGame = 1,
        Exit
    }
    class Program
    {
        static void Main(string[] args)
        {
            ShowScreen(); // ใช้ฟังก์ชันแสดงหน้าจอตอนเริ่มต้น
        }

        static void ShowScreen() // แสดงจอเริ่มต้น
        {
            Console.Clear();
            ShowWelcomeText();
            ShowMenuScreen();
            SelectMenuFromKeyboard();
        }

        static void ShowWelcomeText() // แสดงข้อความ Welcome
        {
            Console.WriteLine("Welcome to Hangman Game");
            Console.WriteLine("----------------------------------------");
        }

        static void ShowMenuScreen() // แสดงหน้าจอเมนู
        {
            Console.WriteLine("1. Play game");
            Console.WriteLine("2. Exit");
        }

        static void SelectMenuFromKeyboard() // แสดงข้อความให้กดเบือกเมนู
        {
            Console.Write("Please Select Menu:");
            Menu menu = (Menu)(int.Parse(Console.ReadLine()));
            NextScreenMenu(menu);
        }
        static void NextScreenMenu(Menu menu) // ดูค่าว่าผู้เล่นเลือกเมนูในจากคีย์บอร์ดร่วมกับการใช้ enum
        {
            if (menu == Menu.PlayGame)
            {
                ShowPlayGameScreen(); // เรียกใช้ฟังก์ชัน ShowPlayGameScreen();
            }
            else if (menu == Menu.Exit)
            {
                // จบการทำงาน
            }
            else ShowInputMenuIsIncorrect(); //เรียกใช้ฟังก์ชัน ShowInputMenuIsIncorrect();
        }

        static void ShowPlayGameScreen() // แสดงผลหน้าจอหน้าเล่นเกม
        {
            string[] wordList = new string[3]; // สร้าง array เพื่อใส่รายการคำต่าง ๆ 
            wordList[0] = "Tennis";
            wordList[1] = "Football";
            wordList[2] = "Badminton";
            Random random = new Random(); // สร้างการ random
            int word = random.Next(0, 2); // สุ่มคำจากคำที่ 0-2
            string spaceword = wordList[word]; // สร้างตัวแปรคำที่เป็นช่องว่างและนำไปใส่ใน array 
            char[] guess = new char[spaceword.Length]; // สร้างตัวแปรไว้เก็บค่าตัวอักษรที่ผู้เล่นจะทำการเดา
            InputLetter(); // เรียกใช้ฟังก์ชัน InputLetter();

            int incorrect = 0;
            Console.WriteLine("Incorrect Score: {0}", incorrect); // แสดงค่า score ที่เดาผิด

            InputAlphabet();
            for (int i = 0; i < spaceword.Length; i++) // ตรวจสอบเงื่อนไขตัวแปร i ว่าน้อยกว่าความยาวของตัวแปร sapceword
                guess[i] = '_'; // ใช้ for loop และแทนตำแหน่งตัวอักษรที่ต้องทำการเดาเป็น "_"
            while (true) // ดำเนินตามคำสั่งเมื่อ i = spaceword
            {
                char playGuess = char.Parse(Console.ReadLine());
                for (int j = 0; j < spaceword.Length; j++)   
                {
                    if (playGuess == spaceword[j]) 
                        guess[j] = playGuess;
                }
                Console.WriteLine(guess);
            }
        }

        static void InputAlphabet() // แสดงข้อความให้ใส่ตัวอักษร
        {
            Console.Write("Input letter alphabet: ");
        }
        static void InputLetter() // แสดงข้อความหน้าเกม
        {
            Console.Clear();
            Console.WriteLine("Play game Hangman");
            Console.WriteLine("----------------------------------------");
        }

        static void ShowInputMenuIsIncorrect() // แสดงข้อความหากป้อนเมนูผิดพลาด
        {
            Console.WriteLine("Incorrect menu. Insert 1 or 2 only.");
            SelectMenuFromKeyboard(); // เรียกใช้ฟังก์ชัน SelectMenuFromKeyboard();
        }
    }
}
