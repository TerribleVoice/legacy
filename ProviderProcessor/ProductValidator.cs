using System.Collections.Generic;
using System.Linq;
using ProviderProcessing.ProcessReports;
using ProviderProcessing.ProviderDatas;
using ProviderProcessing.References;

namespace ProviderProcessing
{
    public class ProductValidator
    {
        public IList<ProductValidationResult> ValidateProduct(ProductData product)
        {
            return ValidateName(product)
                .Concat(ValidatePrices(product))
                .Concat(MeasureUnitCodes(product))
                .ToList();
        }

        private static IEnumerable<ProductValidationResult> ValidateName(ProductData product)
        {
            var reference = ProductsReference.GetInstance();
            if (!reference.FindCodeByName(product.Name).HasValue)
            {
                yield return new ProductValidationResult(product,
                    "Unknown product name",
                    ProductValidationSeverity.Error);
            }
        }

        private static IEnumerable<ProductValidationResult> ValidatePrices(ProductData product)
        {
            if (product.Price <= 0)
            {
                yield return new ProductValidationResult(product, "Bad price", ProductValidationSeverity.Warning);
            }
        }

        private static IEnumerable<ProductValidationResult> MeasureUnitCodes(ProductData product)
        {
            if (!IsValidMeasureUnitCode(product.MeasureUnitCode))
            {
                yield return new ProductValidationResult(product,
                    "Bad units of measure",
                    ProductValidationSeverity.Warning);
            }
        }

        private static bool IsValidMeasureUnitCode(string measureUnitCode)
        {
            var reference = MeasureUnitsReference.GetInstance();
            return reference.FindByCode(measureUnitCode) != null;
        }
    }
}