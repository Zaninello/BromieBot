using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;


namespace DataBase;

public static class GlobalConnections
{
    public static TelegramBotContex ConnectionTask { get; set; } = new TelegramBotContex();
}


