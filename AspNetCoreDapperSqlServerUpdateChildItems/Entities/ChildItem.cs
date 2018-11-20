// Copyright © 2018 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace AspNetCoreDapperSqlServerUpdateChildItems.Entities
{
  public class ChildItem
  {
    public int Id { get; set; }
    public int ParentItemId { get; set; }
    public string SomeProperty1 { get; set; }
    public string SomeProperty2 { get; set; }
    public string SomeProperty3 { get; set; }

    public virtual ParentItem ParentItem { get; set; }
  }
}