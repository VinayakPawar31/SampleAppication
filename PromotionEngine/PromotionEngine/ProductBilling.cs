using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine
{
    public class ProductBilling
    {
        private readonly double dblProductA,
                                dblProductB,
                                dblProductC,
                                dblProductD,
                                dblPromoA,
                                dblPromoB,
                                dblPromoCD;
        public ProductBilling()
        {
            dblProductA = 50;
            dblProductB = 30;
            dblProductC = 20;
            dblProductD = 15;
            dblPromoA = 130;
            dblPromoB = 45;
            dblPromoCD = 30;
        }
        public double BillGenerator(Dictionary<string, int> finalproducts)
        {
            double totalAmount = 0;
            int trackC = 0;

            foreach (KeyValuePair<string, int> finProduct in finalproducts)
            {
                try
                {
                    switch (finProduct.Key)
                    {
                        case "ProductA":
                            if (finProduct.Value > 0)
                            {
                                if ((finProduct.Value % 3) == 0)
                                {
                                    totalAmount += (finProduct.Value / 3) * (dblPromoA);
                                }
                                else
                                {
                                    int checkA = (finProduct.Value / 3);
                                    int variableA = (finProduct.Value - (checkA * 3));
                                    totalAmount += (checkA * dblPromoA) + (variableA * dblProductA);
                                }
                            }
                            break;
                        case "ProductB":
                            if (finProduct.Value > 0)
                            {
                                if ((finProduct.Value % 2) == 0)
                                {
                                    totalAmount += (finProduct.Value / 2) * (dblPromoB);
                                }
                                else
                                {
                                    int checkB = (finProduct.Value / 2);
                                    int variableB = (finProduct.Value - (checkB * 2));
                                    totalAmount += (checkB * dblPromoB) + (variableB * dblProductB);
                                }
                            }

                            break;
                        case "ProductC":
                            trackC = finProduct.Value;
                            totalAmount += (finProduct.Value * dblProductC);
                            break;

                        case "ProductD":
                            if (trackC > 0)
                            {
                                if (trackC == finProduct.Value)
                                {
                                    totalAmount = totalAmount - (trackC * dblProductC) + (finProduct.Value * (dblPromoCD));
                                }
                                else
                                {
                                    totalAmount += (finProduct.Value * dblProductD);//this should not be the case as Product C and D are clubed
                                }
                            }
                            else
                            {
                                totalAmount += (finProduct.Value * dblProductD);
                            }
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error:" +  ex.Message.ToString());
                }
            }
            return totalAmount;
        }

    }
}
