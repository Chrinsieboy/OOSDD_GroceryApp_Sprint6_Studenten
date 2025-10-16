using Microsoft.Data.Sqlite;
﻿using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class GroceryListItemsRepository : DatabaseConnection, IGroceryListItemsRepository
    {
        private readonly List<GroceryListItem> groceryListItems = [];

        public GroceryListItemsRepository()
        {
            CreateTable(@"CREATE TABLE IF NOT EXISTS GroceryListItems (
                            [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                            [GroceryListId] INTEGER NOT NULL,
                            [ProductId] INTEGER NOT NULL,
                            [Amount] INTEGER NOT NULL,
                            Unique(GroceryListId, ProductId)
                        )");

            List<string> insertQueries = [
                @"INSERT OR REPLACE INTO GroceryListItems(GroceryListId, ProductId, Amount) VALUES(1, 1, 3)",
                @"INSERT OR REPLACE INTO GroceryListItems(GroceryListId, ProductId, Amount) VALUES(1, 2, 1)",
                @"INSERT OR REPLACE INTO GroceryListItems(GroceryListId, ProductId, Amount) VALUES(1, 3, 4)",
                @"INSERT OR REPLACE INTO GroceryListItems(GroceryListId, ProductId, Amount) VALUES(2, 1, 2)",
                @"INSERT OR REPLACE INTO GroceryListItems(GroceryListId, ProductId, Amount) VALUES(2, 2, 5)"
            ];
            
            InsertMultipleWithTransaction(insertQueries);
            GetAll();
        }

        public List<GroceryListItem> GetAll()
        {
            groceryListItems.Clear();

            string selectQuery = "SELECT Id, GroceryListId, ProductId, Amount FROM GroceryListItems";
            
            OpenConnection();
            using (SqliteCommand command = new(selectQuery, Connection))
            {
                SqliteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    int groceryListId = reader.GetInt32(1);
                    int productId = reader.GetInt32(2);
                    int amount = reader.GetInt32(3);
                    
                    groceryListItems.Add(new GroceryListItem(id, groceryListId, productId, amount));
                }
            }
            CloseConnection();
            
            return groceryListItems;
        }

        public List<GroceryListItem> GetAllOnGroceryListId(int id)
        {
            List<GroceryListItem> items = new();
            
            string selectQuery = "SELECT Id, GroceryListId, ProductId, Amount FROM GroceryListItems WHERE GroceryListId = @GroceryListId";
            
            OpenConnection();
            using (SqliteCommand command = new(selectQuery, Connection))
            {
                command.Parameters.AddWithValue("@GroceryListId", id);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int itemId = reader.GetInt32(0);
                        int groceryListId = reader.GetInt32(1);
                        int productId = reader.GetInt32(2);
                        int amount = reader.GetInt32(3);
                        
                        items.Add(new GroceryListItem(itemId, groceryListId, productId, amount));
        }
                }
            }
            CloseConnection();

            return items;
        }

        public GroceryListItem Add(GroceryListItem item)
        {
            int newId = groceryListItems.Max(g => g.Id) + 1;
            item.Id = newId;
            groceryListItems.Add(item);
            return Get(item.Id);
        }

        public GroceryListItem? Delete(GroceryListItem item)
        {
            throw new NotImplementedException();
        }

        public GroceryListItem? Get(int id)
        {
            return groceryListItems.FirstOrDefault(g => g.Id == id);
        }

        public GroceryListItem? Update(GroceryListItem item)
        {
            GroceryListItem? listItem = groceryListItems.FirstOrDefault(i => i.Id == item.Id);
            listItem = item;
            return listItem;
        }
    }
}
