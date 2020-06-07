using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine
{
    public class Products
    {
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        int intProductA = 0;
        int intProductB = 0;
        int intProductC = 0;
        int intProductD = 0;

        public void ProductSelection()
        {
        STEP1:
            Console.WriteLine("select the product from below list\nProduct(A)\nProduct(B)\nProduct(C)\nProduct(D)");
            string strProduct = Console.ReadLine();
            switch (strProduct.ToUpper())
            {
                case "A":
                    Console.WriteLine("Enter the quantity");
                    int itemA = Convert.ToInt32(Console.ReadLine());
                    intProductA += itemA;
                    break;
                case "B":
                    Console.WriteLine("Enter the quantity");
                    int itemB = Convert.ToInt32(Console.ReadLine());
                    intProductB += itemB;
                    break;
                case "C":
                    Console.WriteLine("Enter the quantity");
                    int itemC = Convert.ToInt32(Console.ReadLine());
                    intProductC += itemC;
                    break;
                case "D":
                    Console.WriteLine("Enter the quantity");
                    int itemD = Convert.ToInt32(Console.ReadLine());
                    intProductD += itemD;
                    break;

                default:
                    break;
            }
            Console.WriteLine("Want to add another item(Y/N)");
            var strOption = Console.ReadLine();
            if (strOption.ToUpper() == "Y")
            {
                goto STEP1;
            }
            else
            {
                Console.WriteLine("You have selected ");
                if (intProductA > 0)
                {
                    Console.WriteLine("ProductA:" + intProductA + " Qty");
                }
                if (intProductB > 0)
                {
                    Console.WriteLine("ProductB:" + intProductB + " Qty");
                }
                if (intProductC > 0)
                {
                    Console.WriteLine("ProductC:" + intProductC + " Qty");
                }
                if (intProductD > 0)
                {
                    Console.WriteLine("ProductD:" + intProductD + " Qty");
                }
                Console.WriteLine("Press \"B\" to proceed for billing Press \"C\" to Continue shopping");
                var strVal = Console.ReadLine();
                if (strVal.ToUpper() == "B")
                {
                    Dictionary<string, int> finalProducts = new Dictionary<string, int>()
                    {
                    {"ProductA",intProductA},
                    {"ProductB",intProductB},
                    {"ProductC",intProductC},
                    {"ProductD",intProductD},
                    };

                    ProductBilling objProductBilling = new ProductBilling();
                    var finalValue = objProductBilling.BillGenerator(finalProducts);
                    if (finalValue > 0)
                    {
                        Console.WriteLine("Prodduct Summary are as Follows:");
                        foreach (var item in finalProducts)
                        {
                            if (item.Value > 0)
                            {
                                Console.WriteLine("Item= {0}, Qty = {1}", item.Key, item.Value);
                            }
                        }
                        Console.WriteLine("Total Amount: {0}", finalValue);
                    }

                }
                else if (strVal.ToUpper() == "C")
                {
                    goto STEP1;
                }
            }
        }
    }
}
