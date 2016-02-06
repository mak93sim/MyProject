using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Avtomat
    {
        private int one;//количество 1 монет
        private int two;//количество 2 монет
        private int five;//количество 5 монет
        private int ten;//количество 10 монет
        private string product;//наименование выбранного продукта
        private int delivery;//сдача для покупателя
        private int keks;//количество кексов
        private int pechenie;//количество печенья
        private int vafli;//количество вафлей
        public Avtomat(int one,int two,int five,int ten)
        {
            this.one = one;
            this.two = two;
            this.five = five;
            this.ten = ten;
            product = "Unknown";//продукт не выбран
            delivery = 0;
            keks = 4;
            pechenie = 3;
            vafli = 10;
        }
        public void select(string str)//выбор продукта
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
        public void buy(ref int money)//покупка выбранного продукта
        {
            Console.WriteLine("Input money or input exit");
            if (product == "Unknown")
            {
                Console.WriteLine("Product isn't selected");
            }
            switch(product)
            {
                case "keks":
                    input_money(50, ref money, ref keks);
                    break;
                case "pechenie":
                    input_money(10, ref money, ref pechenie);
                    break;
                case "vafli":
                    input_money(30, ref money, ref vafli);
                    break;
            }
            product = "Unknown";
        }
        protected void input_money(int price, ref int money, ref int n)//метод, обрабатывающий ввод пользователем денег при покупке выбранного продукта
        {
            int counter = 0;
            string str = "";
            while (counter < price && str != "exit" && money > 0)
            {
                str = Console.ReadLine();
                if (str == "1" || str == "2" || str == "5" || str == "10")
                {
                    counter = counter + Convert.ToInt32(str, 10);
                    if (str == "1")
                    {
                        one += 1;
                        money -= 1;
                        delivery += 1;
                    }
                    if (str == "2")
                    {
                        two += 1;
                        money -= 2;
                        delivery += 2;
                    }
                    if (str == "5")
                    {
                        five += 1;
                        money -= 5;
                        delivery += 5;
                    }
                    if (str == "10")
                    {
                        ten += 1;
                        money -= 10;
                        delivery += 10;
                    }
                }
            }
            if (money == 0)
            {
                Console.WriteLine("Your money is over");
            }
            else if (str != "exit")
            {
                Console.WriteLine("OK");
                delivery = counter - price;
                n -= 1;
            }
            else if (str == "exit")
            {
                Console.WriteLine("Not enough money");
            }
        }
        public void take(ref int money)//берем сдачу
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
                Console.WriteLine("OK");
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int money = 10;// кошелек покупателя
            string str = "";
            Avtomat Avt = new Avtomat(1, 1, 1, 1);
            while (true)//бесконечный цикл для работы автомата
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
            }
        }
    }
}
