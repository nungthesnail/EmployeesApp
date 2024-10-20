﻿using EmployeesCLI.Services;

namespace EmployeesCLI.Commands
{
	public class GetAllCommand : ICommand<Task>
	{
		private readonly IServiceFactory _serviceFactory = new ServiceFactory();

		public async Task Execute()
		{
			PrintPrimaryText();

			var apiConnector = _serviceFactory.CreateApiConnector();
			var result = await apiConnector.GetAllAsync();
			foreach (var employee in result)
			{
				Console.WriteLine(employee);
			}

			if (!result.Any())
			{
				Console.WriteLine("В базу данных не внесен ни один сотрудник.");
			}
		}

		private void PrintPrimaryText()
		{
            Console.WriteLine("Данные всех сотрудников: ");
		}
	}
}
