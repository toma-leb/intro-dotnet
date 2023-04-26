using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtremeCarpaccio
{
    public class Biller
    {
        //public decimal ComputeOrder(Order order) => throw new NotImplementedException();
        public decimal ComputeOrder(Order order)
        {
            var red = 0.00f;
            var taxe = 0.00f;
            var reduction = new Dictionary<String, float>()
            {
                { "PayThePrice", 1.00f },
                { "HalfPrice", 0.50f },
            };
            //List<(int limitValue, double reduction)> reductionStandard = null;
            var reductionStandard = new Dictionary<int, float>()
            {
                { 100, 1.00f },
                { 500, 0.97f },
                { 700, 0.95f },
                { 1000, 0.93f },
                { 5000, 0.90f },
                { int.MaxValue, 0.85f }
            };
            var taxDict = new Dictionary<string, float>()
            {
                { "FR", 1.20f },
                { "UK", 1.21f },
                { "PT", 1.23f },
            };

            float price = order.Items.Aggregate(0.00f, (acc, x) => (acc + ((float)x.Quantity * (float)x.Price)));

            if (order.ReductionName == "Standard")
            {
                for (int j = 0; j < reductionStandard.Keys.Count(); j++ )
                {
                    int limit = reductionStandard.Keys.ToList()[j];
                    if (price < limit)
                    {
                        red = reductionStandard[limit];
                        break;
                    }
                }
            } else
            {
                red = reduction[order.ReductionName];
            }

            taxDict.TryGetValue(order.CountryCode, out taxe);

            float res = taxe * (price * red);

            return (decimal)Math.Round(res, 2);
        }
    }
}
