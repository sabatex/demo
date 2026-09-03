using System;

namespace FacadeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class SubsustemA
    {
        public void A1() { }
    }
    public class SubsustemB
    {
        public void B1() { }
    }
    public class SubsustemC
    {
        public void C1() { }
    }

    public class Facade
    {
        SubsustemA subsustemA;
        SubsustemB subsustemB;
        SubsustemC subsustemC;
        public void Operation1()
        {
            subsustemA.A1();
            subsustemB.B1();
            subsustemC.C1();
        }
        public void Operation2()
        {
            subsustemB.B1();
            subsustemC.C1();
        }
    }


    public class Money
    {
        static decimal Total = 100;
        public void Sell(decimal summ)=>Total = Total + summ;
        public void ReturnMoney(decimal summ) => Total = Total - summ;
    }

    public class Shop
    {
        public static int Count = 10;
        public void Sell(int count) => Count = Count- count;
        public void ReturnItem(int count) => Count = Count + count;

    }

    public class Store
    {
        public static int Count = 100;
        public void MoveToShop(int count) => Count = Count - count;
        public void ReturnItem(int count) => Count = Count + count;

    }

    public class Cassa
    {
        Money money= new Money();
        Shop shop = new Shop();
        Store store = new Store();

        public void Sell(int count) 
        {
            money.Sell(35*count);
            shop.Sell(count);
            if (Shop.Count < 5)
            {
                int needItem = 10 - Shop.Count;
                store.MoveToShop(needItem);
                shop.ReturnItem(needItem);
            }
                
        }

        public void ReturnItem(int count)
        {
            money.ReturnMoney(35*count);
            store.ReturnItem(count);

        }

    }



}
