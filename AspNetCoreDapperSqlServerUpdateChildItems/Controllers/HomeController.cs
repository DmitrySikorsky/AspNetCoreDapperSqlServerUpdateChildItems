// Copyright © 2018 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using AspNetCoreDapperSqlServerUpdateChildItems.Entities;
using AspNetCoreDapperSqlServerUpdateChildItems.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDapperSqlServerUpdateChildItems.Repositories.DapperSqlServer
{
  public class HomeController : Controller
  {
    private IParentItemRepository parentItemRepository;
    private IChildItemRepository childItemRepository;

    public HomeController(IParentItemRepository parentItemRepository, IChildItemRepository childItemRepository)
    {
      this.parentItemRepository = parentItemRepository;
      this.childItemRepository = childItemRepository;
    }

    public IActionResult Index()
    {
      ParentItem parentItem = new ParentItem();

      parentItem.SomeProperty1 = "Aaa_1";
      parentItem.SomeProperty2 = "Aaa_1";
      parentItem.SomeProperty3 = "Aaa_1";
      this.parentItemRepository.Create(parentItem);
      
      // Parent item is created now

      ChildItem childItem1 = new ChildItem();

      childItem1.ParentItemId = parentItem.Id;
      childItem1.SomeProperty1 = "Aaa1_1";
      childItem1.SomeProperty2 = "Aaa1_2";
      childItem1.SomeProperty3 = "Aaa1_3";

      ChildItem childItem2 = new ChildItem();

      childItem2.ParentItemId = parentItem.Id;
      childItem2.SomeProperty1 = "Aaa2_1";
      childItem2.SomeProperty2 = "Aaa2_2";
      childItem2.SomeProperty3 = "Aaa2_3";

      ChildItem childItem3 = new ChildItem();

      childItem3.ParentItemId = parentItem.Id;
      childItem3.SomeProperty1 = "Aaa3_1";
      childItem3.SomeProperty2 = "Aaa3_2";
      childItem3.SomeProperty3 = "Aaa3_3";
      this.childItemRepository.Merge(parentItem.Id, new ChildItem[] { childItem1, childItem2, childItem3 });

      // Child items are created now
      childItem3.SomeProperty1 = "Bbb3_1";
      childItem3.SomeProperty2 = "Bbb3_2";
      childItem3.SomeProperty3 = "Bbb3_3";

      ChildItem childItem4 = new ChildItem();

      childItem4.ParentItemId = parentItem.Id;
      childItem4.SomeProperty1 = "Bbb4_1";
      childItem4.SomeProperty2 = "Bbb4_2";
      childItem4.SomeProperty3 = "Bbb4_3";
      this.childItemRepository.Merge(parentItem.Id, new ChildItem[] { childItem2, childItem3, childItem4 });

      // Child item 1 is now deleted, child item 2 is not updated, child item 3 is updated, and child item 4 is inserted

      return this.NoContent();
    }
  }
}