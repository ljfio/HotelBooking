using System.Data.Common;
using HotelBooking.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;

var server = AnsiConsole.Prompt(new TextPrompt<string>("Enter server:").DefaultValue("(local)"));
var database = AnsiConsole.Prompt(new TextPrompt<string>("Enter database:").DefaultValue("HotelBooking"));
var userName = AnsiConsole.Prompt(new TextPrompt<string>("Enter username:"));
var password = AnsiConsole.Prompt(new TextPrompt<string>("Enter password:").Secret());

var connectionStringBuilder = new DbConnectionStringBuilder();

connectionStringBuilder.Add("Server", server);
connectionStringBuilder.Add("Database", database);
connectionStringBuilder.Add("User Id", userName);
connectionStringBuilder.Add("Password", password);

var optionsBuilder = new DbContextOptionsBuilder();

optionsBuilder.UseSqlServer(connectionStringBuilder.ConnectionString);

try
{
    await using var context = new ModelContext(optionsBuilder.Options);

    await context.Database.EnsureDeletedAsync();
    
    await context.Database.EnsureCreatedAsync();
}
catch (Exception ex)
{
    AnsiConsole.WriteException(ex);
}