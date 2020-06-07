using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine
{
    class PromoEngine
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome");
            STEP1:
                Console.WriteLine("Select the options from below");
                Console.WriteLine("1.Purchase\n2.Billing\n3.Exit");

                int option = Convert.ToInt16(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Products objProducts = new Products();
                        objProducts.ProductSelection();
                        break;
                    case 2:
                        Console.WriteLine("Cannot perform billing without product selection\n");
                        goto STEP1;
                    default:
                        Environment.Exit(0);
                        break;
                }
                Console.ReadLine();

            }

        }
    }
}
