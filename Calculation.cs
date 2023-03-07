using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSUniversalLib
{
    /// <summary>
    /// Class using for implementation calculation the amount of raw material for product manufacturing
    /// </summary>
    public static class Calculation
    {
        /// <summary>
        /// Method calculates amount of material what need to use for production with manufacture defection
        /// </summary>
        /// <param name="productType">Number of product type</param>
        /// <param name="materialType">Number of material type</param>
        /// <param name="count">Amount of product items</param>
        /// <param name="width">Width of product item</param>
        /// <param name="length">Length of product item</param>
        /// <returns>Amount of material</returns>
        public static int GetQuantityForProduct(int productType, int materialType, int count, float width, float length)
        {
            if(ProductType.GetValue(productType)>0&&Material.GetValue(materialType)>0){
                int amount = 0;
                if (length>0&&width>0&&count>0)
                {
                    try
                    {
                        float result = width * length * (float)(count) * ProductType.GetValue(productType);
                        result /= Material.GetValue(materialType);
                        amount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(result)));
                        return amount;
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }    
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }
    }
    /// <summary>
    /// Class using for implementation getting a percentage of manufacture defection for some matrials
    /// </summary>
    static class Material
    {
        //Material type is a percentage of manufacture defection for product made of definite material
        const float materialType1 = 0.3f;
        const float materialType2 = 0.12f;

        /// <summary>
        /// Method returns percentage of manufacture defection for material type
        /// </summary>
        /// <param name="number">Number of material type</param>
        /// <returns>Value percentage of manufacture defection</returns>
        public static float GetValue(int number)
        {
            try
            {
                int check = number;
                if (check > 0 && check <= 2)
                {
                    switch (check)
                    {
                        case 1:
                            return (1.0f - (materialType1 / 100));
                            break;
                        case 2:
                            return (1.0f - (materialType2 / 100));
                            break;
                        default:
                            return 0;
                            break;
                    }
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
    /// <summary>
    /// Class using for implementation getting a coefficient of material consumption for some product
    /// </summary>
    static class ProductType
    {
        //Product type is a coefficient of consumption the material for manufacture the product
        const float productType1 = 1.1f;
        const float productType2 = 2.5f;
        const float productType3 = 8.43f;

        /// <summary>
        /// Method returns coefficient of consumption for product type
        /// </summary>
        /// <param name="number">Number of product type</param>
        /// <returns>coefficient of consumption the material</returns>
        public static float GetValue(int number)
        {
            try
            {
                int check = number;
                if(check>0&&check<=3)
                {
                    switch (check)
                    {
                        case 1:
                            return productType1;
                            break;
                        case 2:
                            return productType2;
                            break;
                        case 3:
                            return productType3;
                            break;
                        default:
                            return 0;
                            break;
                    }
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
