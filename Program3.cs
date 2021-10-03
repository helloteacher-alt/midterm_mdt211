using System;
using System.Collections.Generic;

namespace midterm_Quiz1 //63120501029
{
    class Program
    {
        static void Main(string[] args)
        {
            string decide = "y";
            string selectFlower;
            FlowerStore flowerStore = new FlowerStore();
            do
            {
                ShowHeaderText(); // ใช้ฟังก์ชันมาช่วยแยกการแสดงข้อความ
                foreach (string i in flowerStore.flowerList)
                {
                    Console.Write((flowerStore.flowerList.IndexOf(i) + 1) + " ");
                    Console.WriteLine(i);
                }
                selectFlower = Console.ReadLine();
                switch (selectFlower)
                {
                    case "1":
                        flowerStore.addToCart(flowerStore.flowerList[0]);
                        Console.WriteLine("Added " + flowerStore.flowerList[0]);
                        break;
                    case "2":
                        flowerStore.addToCart(flowerStore.flowerList[1]);
                        Console.WriteLine("Added " + flowerStore.flowerList[1]);
                        break;
                    default:
                        Console.WriteLine("Not Added to cart. found select number of flower");
                        break;
                }

                StopProgressOrContinue(); // ใช้ฟังก์ชันมาช่วยแยกการแสดงข้อความ
                decide = Console.ReadLine();
                if (decide == "exit")
                {
                    Console.Write("Current my cart");
                    flowerStore.showCart();
                }
            }
            while (decide != "exit");
        }

        static void ShowHeaderText() // แสดงข้อความให้เลือกประเภทของดอไม้ที่จะซื้อ
        {
            Console.WriteLine("Select number for buy flower :");
        }

        static void StopProgressOrContinue() // แสดงข้อความให้ผู้ซื้อเลือกระหว่างซื้อต่อหรือไม่ซื้อแล้ว
        {
            Console.WriteLine("You can stop this progress ? exit for >> exit << progress and pressany key for continue");
        }

    }
    class FlowerStore // สร้าง class FlowerStore
    {
        public List<string> flowerList = new List<string>(); // สร้าง list
        List<string> cart = new List<string>();
        public FlowerStore()
        {
            flowerList.Add("Rose"); 
            flowerList.Add("Lotus");
        }
        public void addToCart(string name) // Add ดอกไม้ใส่ตะกร้า
        {
            cart.Add(name);
        }

        public void showCart() // แสดงผลว่าในตะกร้ามีอะไรบ้าง
        {
            if (cart.Count == 0)
            {
                Console.WriteLine("Cart is empty");
            }
            else
            {
                Console.WriteLine("My Cart :");
                foreach (string i in cart)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
    




