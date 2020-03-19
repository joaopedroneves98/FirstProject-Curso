using FirstProject.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstProject.Entities {
    class Order {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public Client Client { get; set; }

        public Order(OrderStatus status, Client client) {
            Status = status;
            Client = client;
            Moment = DateTime.Now;
        }

        public void AddItem(OrderItem item) {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item) {
            Items.Remove(item);
        }

        public double Total() {
            double total = 0;

            foreach (var item in Items) {
                total += item.SubTotal();
            }

            return total;
        }
    }
}
