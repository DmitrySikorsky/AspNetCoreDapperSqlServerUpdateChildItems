// Copyright © 2018 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace AspNetCoreDapperSqlServerUpdateChildItems.Repositories.DapperSqlServer
{
  public abstract class RepositoryBase
  {
    private readonly IConfiguration configuration;

    public RepositoryBase(IConfiguration configuration)
    {
      this.configuration = configuration;
    }

    protected IDbConnection CreateDbConnection()
    {
      return new SqlConnection(this.configuration.GetConnectionString("Default"));
    }
  }
}