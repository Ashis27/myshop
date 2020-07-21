using MyShop.Catalog.Application.DomainEventHandlers.CatalogItemCreated;
using MyShop.Catalog.Application.DomainEventHandlers.CatalogItemDeleted;
using MyShop.Catalog.Application.DomainEventHandlers.CatalogPriceUpdated;
using MyShop.Catalog.Infrastructure;
using MyShop.Catalog.Infrastructure.Enum;
using MyShop.CommonUtility.SeedWork;
using MyShop.CommonUtility.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Catalog.Application.Domains
{
    public class CatalogItem : BaseEntity
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; private set; }

        public string PictureFileName { get; private set; }

        public string PictureUri { get; private set; }

        public int CatalogTypeId { get; private set; }

        public CatalogType CatalogType { get; private set; }

        public int CatalogBrandId { get; private set; }

        public CatalogBrand CatalogBrand { get; private set; }

        public int CatalogStatusId { get; private set; }

        public int AvailableStock { get; private set; }

        // Available stock at which we should reorder
        public int RestockThreshold { get; private set; }

        // Maximum number of units that can be in-stock at any time (due to physicial/logistical constraints in warehouses)
        public int MaxStockThreshold { get; private set; }

        public CatalogItem()
        {

        }
        public CatalogItem(string name, string description, decimal price, string pictureFileName,
            string pictureUri, int availableStock, int catalogBrandId, int catalogTypeId)
        {
            Name = name;
            Description = description;
            Price = price;
            PictureFileName = pictureFileName;
            PictureUri = pictureUri;
            AvailableStock = availableStock;
            CatalogBrandId = catalogBrandId;
            CatalogTypeId = catalogTypeId;

            //Add Catalog item created event to notifuy the domain that state has changed to 'created'
            AddCatalogItemCreatedDomainEvent();
        }

        public int RemoveStock(int quantityDesired)
        {
            if (AvailableStock == 0)
            {
                throw new CatalogDomainException($"Empty stock, product item {Name} is sold out");
            }

            if (quantityDesired <= 0)
            {
                throw new CatalogDomainException($"Item units desired should be greater than zero");
            }

            int removed = Math.Min(quantityDesired, this.AvailableStock);

            this.AvailableStock -= removed;

            return removed;
        }

        /// <summary>
        /// Increments the quantity of a particular item in inventory.
        /// <param name="quantity"></param>
        /// <returns>int: Returns the quantity that has been added to stock</returns>
        /// </summary>
        public int AddStock(int quantity)
        {
            int original = this.AvailableStock;

            // The quantity that the client is trying to add to stock is greater than what can be physically accommodated in the Warehouse
            if ((this.AvailableStock + quantity) > this.MaxStockThreshold)
            {
                // For now, this method only adds new units up maximum stock threshold. In an expanded version of this application, we
                //could include tracking for the remaining units and store information about overstock elsewhere. 
                this.AvailableStock += (this.MaxStockThreshold - this.AvailableStock);
            }
            else
            {
                this.AvailableStock += quantity;
            }

            return this.AvailableStock - original;
        }

        private void AddCatalogItemCreatedDomainEvent()
        {
            this.CatalogStatusId =  (int)CatalogStatus.Created;
            this.AddDomainEvent(new CatalogItemCreatedDomainEvent(this));
        }

        public void SetApprovedStatus()
        {
            this.CatalogStatusId = (int)CatalogStatus.Approved;
        }

        public void SetCancelledStatus()
        {
            this.CatalogStatusId = (int)CatalogStatus.Declained;
        }

        public void SetDeleteStatus()
        {
            this.CatalogStatusId = (int)CatalogStatus.Deleted;
            this.AddDomainEvent(new DeleteCatalogItemDomainEvent(this.Id,this.CatalogStatusId));
        }

        public void SetNewPrice(decimal price)
        {
            this.CatalogStatusId = (int)CatalogStatus.PriceChanged;
            this.AddDomainEvent(new ProductPriceUpdateDomainEvent(this.Id,price,this.Price, this.CatalogStatusId));
            this.Price = price;
        }

    }
}
