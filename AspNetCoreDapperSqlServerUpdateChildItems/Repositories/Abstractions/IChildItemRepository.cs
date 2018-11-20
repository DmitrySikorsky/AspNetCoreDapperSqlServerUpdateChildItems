// Copyright © 2018 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using AspNetCoreDapperSqlServerUpdateChildItems.Entities;

namespace AspNetCoreDapperSqlServerUpdateChildItems.Repositories.Abstractions
{
  public interface IChildItemRepository
  {
    void Create(ChildItem childItem);
    void Edit(ChildItem childItem);
    void Delete(ChildItem childItem);
    void Merge(int parentItemId, IEnumerable<ChildItem> childItems);
  }
}