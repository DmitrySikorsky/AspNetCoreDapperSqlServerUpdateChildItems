﻿// Copyright © 2018 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using AspNetCoreDapperSqlServerUpdateChildItems.Entities;

namespace AspNetCoreDapperSqlServerUpdateChildItems.Repositories.Abstractions
{
  public interface IParentItemRepository
  {
    void Create(ParentItem parentItem);
  }
}