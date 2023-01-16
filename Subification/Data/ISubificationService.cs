using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SUBIFICATION.Entities;

namespace SUBIFICATION.Data
{
    /// <summary>
    /// An interface that represents the Subscriptions Service.  It can be implemented
    /// multiple ways, including an in-memory store, remote table, or local table.
    /// </summary>
    public interface ISubficationService
    {
        /// <summary>
        /// An event handler that is triggered when the list of items changes.
        /// </summary>
        event EventHandler<SubificationServiceEventArgs> SubscriptionssUpdated;

        /// <summary>
        /// Get all the items in the list.
        /// </summary>
        /// <returns>The list of items (asynchronously)</returns>
        Task<IEnumerable<Subscriptions>> GetItemsAsync();

        /// <summary>
        /// Refreshes the Subscriptionss list manually.
        /// </summary>
        /// <returns>A task that completes when the refresh is done.</returns>
        Task RefreshItemsAsync();

        /// <summary>
        /// Removes an item in the list, if it exists.
        /// </summary>
        /// <param name="item">The item to be removed</param>
        /// <returns>A task that completes when the item is removed.</returns>
        Task RemoveItemAsync(Subscriptions item);

        /// <summary>
        /// Saves an item to the list.  If the item does not have an Id, then the item
        /// is considered new and will be added to the end of the list.  Otherwise, the
        /// item is considered existing and is replaced.
        /// </summary>
        /// <param name="item">The new item</param>
        /// <returns>A task that completes when the item is saved.</returns>
        Task SaveItemAsync(Subscriptions item);
    }
}