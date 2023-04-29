using System.Reflection;
using System.Text;
using System.Text.Json;

namespace CarCatalog.Web.Pages.CarsFilter;

public class FilterService : IFilterService
{
    private readonly HttpClient _httpClient;

    public FilterService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<CarListItem>> GetCarsFilter(GetCarsFilterModel model)
    {
        string queryModel = string.Empty;
        foreach (var pi in typeof(GetCarsFilterModel).GetProperties())
        {
            if (pi.GetValue(model) != null)
                queryModel += $"{pi.Name}={pi.GetValue(model)}&";
        }

            /*queryModel = $"?{model.CarMarkUid?.ToString() ?? ""}" +
            $"&{model.CarModelUid?.ToString() ?? ""}" +
            $"&{model.CarGenerationUid?.ToString() ?? ""}" +
            $"&{model.CarBodyTypeId?.ToString() ?? ""}" +
            $"&{model.CarDriveTypeId?.ToString() ?? ""}" +
            $"&{model.CarEngineTypeId?.ToString() ?? ""}" +
            $"&{model.CarTransmissionTypeId?.ToString() ?? ""}" +
            $"&{model.CarPrice?.ToString() ?? ""}" +
            $"&{model.Mileage?.ToString() ?? ""}";*/

        string url = $"{Settings.ApiRoot}/v1/carsFilter?{queryModel}";

        var response = await _httpClient.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        var data = JsonSerializer.Deserialize<IEnumerable<CarListItem>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true}) ?? new List<CarListItem>();

        return data;
    }

    public async Task<IEnumerable<CarMarkItem>> GetCarMarksList()
    {
        string url = $"{Settings.ApiRoot}/v1/carMarks";

        var response = await _httpClient.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        var data = JsonSerializer.Deserialize<IEnumerable<CarMarkItem>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<CarMarkItem>();

        return data;
    }

    public async Task<IEnumerable<CarModelItem>> GetCarModelsByCarMarkIdList(int? carMarkId)
    {
        if (carMarkId == null)
            return new List<CarModelItem>();

        string url = $"{Settings.ApiRoot}/v1/carMarks/{carMarkId}/carModels";

        var response = await _httpClient.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        var data = JsonSerializer.Deserialize<IEnumerable<CarModelItem>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<CarModelItem>();

        return data;
    }

    public async Task<IEnumerable<CarGenerationItem>> GetCarGenerationsByCarModelidList(int? carModelId)
    {
        if (carModelId == null)
            return new List<CarGenerationItem>();

        string url = $"{Settings.ApiRoot}/v1/carModels/{carModelId}/carGenerations";

        var response = await _httpClient.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        var data = JsonSerializer.Deserialize<IEnumerable<CarGenerationItem>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<CarGenerationItem>();

        return data;
    }

    public async Task<IEnumerable<CarBodyTypeItem>> GetCarBodyTypesList()
    {
        string url = $"{Settings.ApiRoot}/v1/carBodyTypes";

        var response = await _httpClient.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        var data = JsonSerializer.Deserialize<IEnumerable<CarBodyTypeItem>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<CarBodyTypeItem>();

        return data;
    }

    public async Task<IEnumerable<CarDriveTypeItem>> GetCarDriveTypesList()
    {
        string url = $"{Settings.ApiRoot}/v1/carDriveTypes";

        var response = await _httpClient.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        var data = JsonSerializer.Deserialize<IEnumerable<CarDriveTypeItem>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<CarDriveTypeItem>();

        return data;
    }

    public async Task<IEnumerable<CarEngineTypeItem>> GetCarEgineTypesList()
    {
        string url = $"{Settings.ApiRoot}/v1/carEngineTypes";

        var response = await _httpClient.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        var data = JsonSerializer.Deserialize<IEnumerable<CarEngineTypeItem>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<CarEngineTypeItem>();

        return data;
    }

    public async Task<IEnumerable<CarTransmissonItem>> GetCarTransmissonsList()
    {
        string url = $"{Settings.ApiRoot}/v1/carTransmissions";

        var response = await _httpClient.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        var data = JsonSerializer.Deserialize<IEnumerable<CarTransmissonItem>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<CarTransmissonItem>();

        return data;
    }
}
