using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace MTCore_AC.DTO;

public class Script
{
    public string script {  get; set; }

    public virtual async Task Execute(string connectionString)
    {
        await Task.CompletedTask;
    }

}
