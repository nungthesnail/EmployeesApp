using EmployeesCLI.Models;
using EmployeesCLI.Services.Configuration;
using System.Text.Json;
using System.Net.Http.Json;
using EmployeesCLI.Exceptions;
using System.Text;


namespace EmployeesCLI.Services.Api
{
	public class ApiConnector : IApiConnector
	{
		private static HttpClient _httpClient = new();

		private IConfigurationVendor _config;
		private JsonSerializerOptions _jsonOptions = new JsonSerializerOptions()
		{
			PropertyNameCaseInsensitive = true
		};

		public ApiConnector()
		{
			var serviceFactory = new ServiceFactory();
			_config = serviceFactory.CreateConfigurationVendor();
		}

		public async Task CreateAsync(EmployeeModel employee)
		{
			var response = await SendCreateRequest(employee);
			if (!response.IsSuccessStatusCode)
			{
				throw new ApiErrorException(response);
			}
		}

		private async Task<HttpResponseMessage> SendCreateRequest(EmployeeModel employee)
		{
			try
			{
				const string path = "/api/employees";
				var url = BuildUrl(path);

				var request = new HttpRequestMessage(HttpMethod.Post, url);
				request.Content = JsonContent.Create(employee);

				return await _httpClient.SendAsync(request);
			}
			catch (HttpRequestException)
			{
				throw new ApiRequestFailedException();
			}
		}

		private Uri BuildUrl(string route, string? query = null)
		{
			var builder = new UriBuilder();
			builder.Scheme = "http";
			builder.Host = _config.Configuration["ApiHost"];
			builder.Port = Int32.Parse(_config.Configuration["ApiPort"] ?? "5000");
			builder.Path = route;
			builder.Query = query;
			return builder.Uri;
		}

		public async Task<EmployeeModel> GetAsync(string employeeName)
		{
			var response = await SendGetRequest(employeeName);
			if (!response.IsSuccessStatusCode)
			{
				throw new ApiErrorException(response);
			}

			return Deserialize<EmployeeModel>(response.Content.ReadAsStream());
		}

		private async Task<HttpResponseMessage> SendGetRequest(string employeeName)
		{
			try
			{
				const string path = "/api/employees";
				var url = BuildUrl($"{path}/{employeeName}");

				var request = new HttpRequestMessage(HttpMethod.Get, url);

				return await _httpClient.SendAsync(request);
			}
			catch (HttpRequestException)
			{
				throw new ApiRequestFailedException();
			}
		}

		public async Task<IEnumerable<EmployeeModel>> GetAllAsync()
		{
			var response = await SendGetAllRequest();
			if (!response.IsSuccessStatusCode)
			{
				throw new ApiErrorException(response);
			}

			return Deserialize<IEnumerable<EmployeeModel>>(response.Content.ReadAsStream());
		}

		private async Task<HttpResponseMessage> SendGetAllRequest()
		{
			try
			{
				const string path = "/api/employees";
				var url = BuildUrl(path);

				var request = new HttpRequestMessage(HttpMethod.Get, url);

				return await _httpClient.SendAsync(request);
			}
			catch (HttpRequestException)
			{
				throw new ApiRequestFailedException();
			}
		}

		public async Task UpdateAsync(EmployeeModel employee)
		{
			var response = await SendUpdateRequest(employee);
			if (!response.IsSuccessStatusCode)
			{
				throw new ApiErrorException(response);
			}
		}

		private async Task<HttpResponseMessage> SendUpdateRequest(EmployeeModel employee)
		{
			try
			{
				const string path = "/api/employees";
				var url = BuildUrl(path);

				var request = new HttpRequestMessage(HttpMethod.Put, url);
				request.Content = JsonContent.Create(employee);

				return await _httpClient.SendAsync(request);
			}
			catch (HttpRequestException)
			{
				throw new ApiRequestFailedException();
			}
		}

		public async Task DeleteAsync(string employeeName)
		{
			var response = await SendDeleteRequest(employeeName);
			if (!response.IsSuccessStatusCode)
			{
				throw new ApiErrorException(response);
			}
		}

		private async Task<HttpResponseMessage> SendDeleteRequest(string employeeName)
		{
			try
			{
				const string path = "/api/employees";
				var url = BuildUrl($"{path}/{employeeName}");

				var request = new HttpRequestMessage(HttpMethod.Delete, url);

				return await _httpClient.SendAsync(request);
			}
			catch (HttpRequestException)
			{
				throw new ApiRequestFailedException();
			}
		}

		public async Task<decimal> SalaryAsync(SalaryRequestModel salaryRequest)
		{
			var response = await SendSalaryRequestAsync(salaryRequest);
			if (!response.IsSuccessStatusCode)
			{
				throw new ApiErrorException(response);
			}

			var result = Deserialize<decimal>(response.Content.ReadAsStream());
			return result;
		}

		private async Task<HttpResponseMessage> SendSalaryRequestAsync(SalaryRequestModel salaryRequest)
		{
			try
			{
				const string path = "/api/salary";
				var query = BuildQuery(salaryRequest);
				var url = BuildUrl(path, query);

				var request = new HttpRequestMessage(HttpMethod.Get, url);

				return await _httpClient.SendAsync(request);
			}
			catch (HttpRequestException)
			{
				throw new ApiRequestFailedException();
			}
		}

		private string BuildQuery(SalaryRequestModel salaryRequest)
		{
			var periodFrom = $"{salaryRequest.Period.From.Year}-{salaryRequest.Period.From.Month}-{salaryRequest.Period.From.Day}";
			var periodTo = $"{salaryRequest.Period.To.Year}-{salaryRequest.Period.To.Month}-{salaryRequest.Period.To.Day}";

			var sb = new StringBuilder();
			sb.Append($"EmployeeName={salaryRequest.EmployeeName}&");
			sb.Append($"Period.From={periodFrom}&");
			sb.Append($"Period.To={periodTo}");
			return sb.ToString();
		}

		private T Deserialize<T>(Stream jsonStream)
		{
			return JsonSerializer.Deserialize<T>(jsonStream, _jsonOptions)!;
		}

		private string Serialize<T>(T obj)
		{
			return JsonSerializer.Serialize(obj, _jsonOptions);
		}
	}
}
