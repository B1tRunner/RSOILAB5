using System;
using EmployeeRecords.Enums;

namespace EmployeeRecords.Interfaces
{
    public interface IUserInterface
    {
        void DisplayMenu();
        string GetUserChoice();
        void ShowMessage(string message);
        void ShowEmptyLine();
        string ReadString(string prompt);
        int ReadValidAge(string prompt);
        Position ReadValidPosition(string prompt);
        decimal ReadDecimal(string prompt);
        Guid ReadGuid(string prompt);}
}