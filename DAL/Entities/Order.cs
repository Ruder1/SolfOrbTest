﻿namespace DAL.Entities
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Id Заказа
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Номер заказа
        /// </summary>
        public string Number { get; init; }

        /// <summary>
        /// Время когда был сделан заказ
        /// </summary>
        public DateTime Date { get; init; }

        /// <summary>
        /// Id поставщика элемента заказа
        /// </summary>
        public int ProviderId { get; init; }
    }
}