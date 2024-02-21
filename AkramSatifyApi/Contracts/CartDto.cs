using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class CartDto
    {
        public int UserId { get; set; }
        public List<CartItemDto> CartItems { get; set; } = new();
        public float TotalCost => CalculateTotalCost();

        private float CalculateTotalCost()
        {
            if (CartItems == null || CartItems.Count == 0)
            {
                return 0;
            }

            return (float)CartItems.Sum(item => item.FinalPrice);
        }
    }
}
