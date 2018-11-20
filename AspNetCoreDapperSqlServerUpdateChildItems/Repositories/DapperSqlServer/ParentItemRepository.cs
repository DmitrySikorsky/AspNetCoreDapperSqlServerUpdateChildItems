// Copyright © 2018 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Data;
using System.Linq;
using AspNetCoreDapperSqlServerUpdateChildItems.Entities;
using AspNetCoreDapperSqlServerUpdateChildItems.Repositories.Abstractions;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace AspNetCoreDapperSqlServerUpdateChildItems.Repositories.DapperSqlServer
{
  public class ParentItemRepository : RepositoryBase, IParentItemRepository
  {
    public ParentItemRepository(IConfiguration configuration)
      : base(configuration)
    {
    }

    public void Create(ParentItem parentItem)
    {
      using (IDbConnection db = this.CreateDbConnection())
        parentItem.Id = db.Query<int>(
          @"
            INSERT INTO ParentItems VALUES (@SomeProperty1, @SomeProperty2, @SomeProperty3);
            SELECT SCOPE_IDENTITY() AS Id;
          ",
          parentItem
        ).Single();
    }
  }
}