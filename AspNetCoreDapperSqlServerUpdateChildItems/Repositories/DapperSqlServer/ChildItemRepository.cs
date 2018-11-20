// Copyright © 2018 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Data;
using System.Linq;
using AspNetCoreDapperSqlServerUpdateChildItems.Entities;
using AspNetCoreDapperSqlServerUpdateChildItems.Extensions;
using AspNetCoreDapperSqlServerUpdateChildItems.Repositories.Abstractions;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace AspNetCoreDapperSqlServerUpdateChildItems.Repositories.DapperSqlServer
{
  public class ChildItemRepository : RepositoryBase, IChildItemRepository
  {
    public ChildItemRepository(IConfiguration configuration)
      : base(configuration)
    {
    }

    public void Create(ChildItem childItem)
    {
      using (IDbConnection db = this.CreateDbConnection())
        childItem.Id = db.Query<int>(
          @"
            INSERT INTO ChildItems VALUES (@ParentItemId, @SomeProperty1, @SomeProperty2, @SomeProperty3);
            SELECT SCOPE_IDENTITY() AS Id;
          ",
          childItem
        ).Single();
    }

    public void Edit(ChildItem childItem)
    {
      using (IDbConnection db = this.CreateDbConnection())
        db.Execute(
          "UPDATE ChildItems SET ParentItemId = @ParentItemId, SomeProperty1 = @SomeProperty1, SomeProperty2 = @SomeProperty2, SomeProperty3 = @SomeProperty3 WHERE Id = @Id",
          childItem
        );
    }

    public void Delete(ChildItem childItem)
    {
      using (IDbConnection db = this.CreateDbConnection())
        db.Execute(
          "DELETE FROM ChildItems WHERE Id = @Id",
          childItem
        );
    }

    public void Merge(int parentItemId, IEnumerable<ChildItem> childItems)
    {
      using (IDbConnection db = this.CreateDbConnection())
        db.Execute(
          "UpdateChildItems",
          new { ParentItemId = parentItemId, ChildItems = childItems.ToDataTable("ParentItem") },
          commandType: CommandType.StoredProcedure
        );
    }
  }
}