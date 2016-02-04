using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Avtomat
    {
        private int one;
        private int two;
        private int five;
        private int ten;
        private int state;
        private string product;
        private int delivery;
        private int keks;
        private int pechenie;
        private int vafli;
        public Avtomat(int one,int two,int five,int ten)
        {
            this.one = one;
            this.two = two;
            this.five = five;
            this.ten = ten;
            this.state = 1;
            product = "Unknown";
            delivery = 0;
            keks = 4;
            pechenie = 3;
            vafli = 10;
        }
        public void select(string str)
        {
            switch(str)
            {
                case "keks":
                    if (keks > 0)
                    {
                        product = "keks";
                        break;
                    }
                    else
                        Console.WriteLine("No such product");
                    break;
                case "vafli":
                    if (vafli > 0)
                    {
                        product = "vafli";
                        break;
                    }
                    else
                        Console.WriteLine("No such product");
                    break;
                case "pechenie":
                    if (pechenie > 0)
                    {
                        product = "pechenie";
                        break;
                    }
                    else
                        Console.WriteLine("No such product");
                    break;
                default:
                    product = "Unknown";
                    break;
            }
        }
        public void buy(ref int money)
        {
            string str = "";
            int price = 0;
            Console.WriteLine("Input money or input exit");
            if (product == "Unknown")
            {
                Console.WriteLine("Product isn't selected");
            }
            switch(product)
            {
                case "keks":
                    while(price<50 && str != "exit" && money>0)
                    {
                        str = Console.ReadLine();
                        if (str == "1" || str == "2" || str == "5" || str == "10")
                        {
                            price = price + Convert.ToInt32(str, 10);
                            if (str == "1")
                            {
                                one += 1;
                                money -= 1;
                            }
                            if (str == "2")
                            {
                                two += 1;
                                money -= 2;
                            }
                            if (str == "5")
                            {
                                five += 1;
                                money -= 5;
                            }
                            if (str == "10")
                            {
                                ten += 1;
                                money -= 10;
                            }
                        }
                    }
                    if (str == "exit" || money == 0)
                    {
                        Console.WriteLine("Not enough money");
                    }
                    else
                    {
                        Console.WriteLine("OK");
                        delivery = price - 50;
                        keks -= 1;
                    }
                    break;
                case "pechenie":
                    while (price < 10 && str != "exit")
                    {
                        str = Console.ReadLine();
                        if (str == "1" || str == "2" || str == "5" || str == "10")
                        {
                            price = price + Convert.ToInt32(str, 10);
                            if (str == "1")
                            {
                                one += 1;
                                money -= 1;
                            }
                            if (str == "2")
                            {
                                two += 1;
                                money -= 2;
                            }
                            if (str == "5")
                            {
                                five += 1;
                                money -= 5;
                            }
                            if (str == "10")
                            {
                                ten += 1;
                                money -= 10;
                            }
                        }
                    }
                    if (str == "exit" || money == 0)
                    {
                        Console.WriteLine("Not enough money");
                    }
                    else
                    {
                        Console.WriteLine("OK");
                        delivery = price - 10;
                        pechenie -= 1;
                    }
                    break;
                case "vafli":
                    while (price < 30 && str != "exit")
                    {
                        str = Console.ReadLine();
                        if (str == "1" || str == "2" || str == "5" || str == "10")
                        {
                            price = price + Convert.ToInt32(str, 10);
                            if (str == "1")
                            {
                                one += 1;
                                money -= 1;
                            }
                            if (str == "2")
                            {
                                two += 1;
                                money -= 2;
                            }
                            if (str == "5")
                            {
                                five += 1;
                                money -= 5;
                            }
                            if (str == "10")
                            {
                                ten += 1;
                                money -= 10;
                            }
                        }
                    }
                    if (str == "exit" || money == 0)
                    {
                        Console.WriteLine("Not enough money");
                    }
                    else
                    {
                        Console.WriteLine("OK");
                        delivery = price - 30;
                        vafli -= 1;
                    }
                    break;
            }
            product = "Unknown";
        }
        public void take(ref int money)
        {
            if (delivery == 0)
            {
                Console.WriteLine("Sorry, you have't delivery");
                return;
            }
            else
            {
                while (delivery>0)
                {
                    if (ten > 0 && (delivery - 10) >= 0)
                    {
                        delivery -= 10;
                        money += 10;
                        ten -= 1;
                    }
                    else if (five > 0 && (delivery - 5) >= 0)
                    {
                        delivery -= 5;
                        money += 5;
                        five -= 1;
                    }
                    else if (two > 0 && (delivery - 2) >= 0)
                    {
                        delivery -= 2;
                        money += 2;
                        two -= 1;
                    }
                    else if (one > 0 && (delivery - 1) >= 0)
                    {
                        delivery -= 1;
                        money += 1;
                        one -= 1;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, Avtomat hasn't coins");
                        return;
                    }
                }
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int money = 150;
            string str;
            Avtomat Avt = new Avtomat(1, 1, 1, 1);
            while (true)
            {
                Console.WriteLine("Do one of the actions: select, buy, take or stop");
                str = Console.ReadLine();
                if (str == "select")
                {
                    Console.WriteLine("Select product");
                    str = Console.ReadLine();
                    Avt.select(str);
                }
                else if (str == "buy")
                {
                    Avt.buy(ref money);
                }
                else if (str == "take")
                {
                    Avt.take(ref money);
                }
                else if (str == "stop")
                {
                    return;
                }
                if (money == 0)
                {
                    return;
                }
            }
        }
    }
}
