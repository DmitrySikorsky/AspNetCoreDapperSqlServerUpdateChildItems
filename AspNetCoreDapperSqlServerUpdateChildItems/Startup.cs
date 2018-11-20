// Copyright © 2018 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using AspNetCoreDapperSqlServerUpdateChildItems.Repositories.Abstractions;
using AspNetCoreDapperSqlServerUpdateChildItems.Repositories.DapperSqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreDapperSqlServerUpdateChildItems
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
      services.AddScoped<IParentItemRepository, ParentItemRepository>();
      services.AddScoped<IChildItemRepository, ChildItemRepository>();
    }

    public void Configure(IApplicationBuilder applicationBuilder)
    {
      applicationBuilder.UseDeveloperExceptionPage();
      applicationBuilder.UseMvcWithDefaultRoute();
    }
  }
}